Imports OrmLib
Imports ShippingBiz
Public Class FrmPermitSplitOutward

    Private DM As DataManager
    Private OriginBL As TB_OutwardBLS
    Private DestBL As TB_OutwardBLS
    Private TBCnOrigin As DataTable
    Private TBCnDest As DataTable
    Private IsValidOrigin As Boolean
    Private IsValidDest As Boolean
    Private BLDestIsNew As Boolean

    Private OriginalPermits As TB_Permits
    Private Ds As DataSet

    Private Sub FrmPermitSplitOutward_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim TB As New DataTable
        Dim lResult As Boolean

        TableBySql("Select LineCode , LineName from TB_Lines", TB, lResult)

        TBCnOrigin = New DataTable
        TBCnDest = New DataTable

        With TBCnOrigin
            .Columns.Add(New DataColumn("ID", System.Type.GetType("System.Guid")))
            .Columns.Add(New DataColumn("CntrNo"))
            .Columns.Add(New DataColumn("CnSize"))
            .Columns.Add(New DataColumn("CnType"))
        End With

        TBCnDest = TBCnOrigin.Copy
        TBCnOrigin.Columns.Add(New DataColumn("Select", System.Type.GetType("System.Boolean")))

    End Sub

    Private Sub ButtonPickupSource_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPickupSource.Click

        Dim nDr As DataRow
        TBCnOrigin.Clear()
        TBCnOrigin.AcceptChanges()
        Me.GridBLOrigin.DataSource = Nothing
        Me.GridCnOrigin.DataSource = Nothing

        'Source --> Permit Details
        Ds = StoredProcedures.SP_PermitsAllByPermitNo(Me.TxtBLSource.Text)
        If Ds.Tables(0).Rows.Count = 0 Then
            MsgBoxGeneral("No Valid Permit!", "Search Result")
            Exit Sub
        End If
        Me.GridBLOrigin.DataSource = Ds.Tables(0).Copy
        GridNumSeperator(Me.GridBLOrigin)

        'Source --> Assigned containers
        For Each Dr In Ds.Tables(1).Rows
            nDr = TBCnOrigin.NewRow
            nDr("ID") = Dr("ID")
            nDr("CntrNo") = Dr("CntrNo")
            nDr("CnSize") = Dr("CnSize")
            nDr("CnType") = Dr("CnType")
            nDr("Select") = False
            TBCnOrigin.Rows.Add(nDr)
        Next
        Me.GridCnOrigin.DataSource = TBCnOrigin
        GridNumSeperator(Me.GridCnOrigin)

    End Sub

    Private Sub ButtonApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonApply.Click
        Select Case OptionSet.Value
            'Case "C"
            'Call CopyBL()
            Case "S"
                Call SplitBL()
                'Case "M"
                'Call MergeBL()
            Case Else
                MsgBox("Please select split option.")
        End Select
    End Sub

    Private Sub ButtonPickupDest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPickupDest.Click

        Dim nDr As DataRow
        TBCnDest.Clear()
        TBCnDest.AcceptChanges()
        Me.GridBLDest.DataSource = Nothing
        Me.GridCnDest.DataSource = Nothing

        'Destination --> Permit Details
        Ds = StoredProcedures.SP_PermitsAllByPermitNo(Me.TxtBLDest.Text)
        If Ds.Tables(0).Rows.Count = 0 Then
            MsgBoxGeneral("No Valid Permit!", "Search Result")
            BLDestIsNew = True
            Exit Sub
        End If
        Me.GridBLDest.DataSource = Ds.Tables(0).Copy
        GridNumSeperator(Me.GridBLDest)

        'Destination --> Assigned containers
        For Each Dr In Ds.Tables(1).Rows
            nDr = TBCnDest.NewRow
            nDr("ID") = Dr("ID")
            nDr("CntrNo") = Dr("CntrNo")
            nDr("CnSize") = Dr("CnSize")
            nDr("CnType") = Dr("CnType")
            TBCnDest.Rows.Add(nDr)
        Next
        Me.GridCnDest.DataSource = TBCnDest
        GridNumSeperator(Me.GridCnDest)

    End Sub

    Private Sub SplitBL()

        Dim nDrs() As DataRow
        Dim Drs() As DataRow
        Dim DR As DataRow
        Dim NewDr As DataRow
        Dim Ref As Long
        Dim GID As Guid = Guid.NewGuid
        Dim aFld() As String = {"Reference"}
        Dim lResult As Boolean
        Dim LogDataSet As DataSet

        If GridBLOrigin.Rows.Count = 0 Then
            MsgBox("No Valid Original Permit!")
            Exit Sub
        End If

        If TxtBLDest.Text = "" Then
            MsgBox("Please Fill Destination Permit Number!")
            Exit Sub
        End If

        If BLDestIsNew = False Then
            MsgBox("Permit Number Already Existed!")
            Exit Sub
        End If

        Drs = TBCnOrigin.Select("Select = true")
        If Drs.Length = 0 Then
            MsgBox("Please select any Container!")
            Exit Sub
        End If

        'Save concept
        DM = New DataManager(My.Settings.DSN)
        DM.QueryCriteria.Clear()
        DM.QueryCriteria.And(JoinPath.TB_Permits.Columns.PermitNo, TxtBLSource.Text, MatchType.Exact)
        OriginalPermits = DM.GetTB_Permits

        DM.QueryCriteria.Clear()
        DM.QueryCriteria.And(JoinPath.TB_PermitDetails.Columns.PermitID, OriginalPermits.ID, MatchType.Exact)
        DM.GetTB_PermitDetails()

        With DM.DataSet

            Drs = .Tables("TB_Permits").Select("ID = '" & OriginalPermits.ID.ToString & "'")
            DR = Drs(0)
            NewDr = .Tables("TB_Permits").NewRow

            For Each Col As DataColumn In DR.Table.Columns
                Try
                    NewDr.Item(Col.ColumnName) = DR.Item(Col.ColumnName)
                Catch ex As Exception
                End Try
            Next

            NewDr("ID") = GID
            NewDr("PermitNo") = TxtBLDest.Text
            .Tables("TB_Permits").Rows.Add(NewDr)
            DM.CommitAll()

        End With

        Drs = TBCnOrigin.Select("Select = true")
        For Each DR In Drs
            nDrs = DM.DataSet.Tables("TB_PermitDetails").Select("ID = '" & DR("ID").ToString & "'")
            If nDrs.Length > 0 Then
                nDrs(0).Item("PermitID") = GID
            End If
        Next

        Try

            LogDataSet = DM.DataSet.Copy
            DM.CommitAll()
            GenerateLog(LogDataSet)
            BLDestIsNew = False
            OriginBL = Nothing
            DestBL = Nothing
            TBCnDest.Clear()
            TBCnOrigin.Clear()

            Me.GridBLOrigin.DataSource = Nothing
            Me.GridCnOrigin.DataSource = Nothing
            Me.GridBLDest.DataSource = Nothing
            Me.GridCnDest.DataSource = Nothing

            MsgBoxSaveSuccessful()
        Catch ex As Exception
            MsgBoxSaveFailed()
            MsgBox(ex.ToString)

        End Try
    End Sub

End Class