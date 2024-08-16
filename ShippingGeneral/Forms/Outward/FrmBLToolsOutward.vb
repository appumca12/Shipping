Imports OrmLib
Imports ShippingBiz
Public Class FrmBLToolsOutward

    Private DM As DataManager
    Private OriginBL As TB_OutwardBLS
    Private DestBL As TB_OutwardBLS
    Private TBCnOrigin As DataTable
    Private TBCnDest As DataTable
    Private IsValidOrigin As Boolean
    Private IsValidDest As Boolean
    Private BLDestIsNew As Boolean

    Private Sub ButtonPickupSource_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPickupSource.Click
        Dim Dr As DataRow
        Dim nDr As DataRow


        TBCnOrigin.Clear()
        TBCnOrigin.AcceptChanges()


        Me.GridBLOrigin.DataSource = Nothing
        Me.GridCnOrigin.DataSource = Nothing

        DM = New DataManager(My.Settings.DSN)
        DM.QueryCriteria.And(JoinPath.TB_OutwardBLS.Columns.Line, CurrentShippingLine, MatchType.Exact)
        DM.QueryCriteria.And(JoinPath.TB_OutwardBLS.Columns.BlNo, TxtBLSource.Text, MatchType.Exact)
        OriginBL = DM.GetTB_OutwardBLS

        If OriginBL Is Nothing Then
            MsgBox("Invalid B/L No.")
            Exit Sub
        End If

        DM.QueryCriteria.Clear()
        DM.QueryCriteria.And(JoinPath.TB_OutwardCntrs.Columns.BLID, OriginBL.ID, MatchType.Exact)
        DM.GetTB_OutwardCntrs()

        For Each Dr In DM.DataSet.Tables("TB_OutwardCntrs").Rows
            nDr = TBCnOrigin.NewRow
            nDr("ID") = Dr("ID")
            nDr("CntrNo") = Dr("CntrNo")
            nDr("CnSize") = Dr("CnSize")
            nDr("CnType") = Dr("CnType")
            nDr("Select") = False
            TBCnOrigin.Rows.Add(nDr)
        Next

        Me.GridBLOrigin.DataSource = DM.DataSet.Tables("TB_OutwardBLS").Copy
        Me.GridCnOrigin.DataSource = TBCnOrigin
        GridNumSeperator(Me.GridBLOrigin)
        GridNumSeperator(Me.GridCnOrigin)
    End Sub

    Private Sub ButtonApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonApply.Click
        Select Case OptionSet.Value
            Case "C"
                Call CopyBL()
            Case "S"
                Call SplitBL()
            Case "M"
                Call MergeBL()
        End Select
    End Sub

    Private Sub ButtonPickupDest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPickupDest.Click
        Dim Dr As DataRow
        Dim nDr As DataRow
        Dim TB As New DataTable

        TBCnDest.Clear()
        TBCnDest.AcceptChanges()

        DM.QueryCriteria.Clear()
        DM.QueryCriteria.And(JoinPath.TB_OutwardBLS.Columns.Line, CurrentShippingLine, MatchType.Exact)
        DM.QueryCriteria.And(JoinPath.TB_OutwardBLS.Columns.BlNo, TxtBLDest.Text, MatchType.Exact)
        DestBL = DM.GetTB_OutwardBLS

        If DestBL Is Nothing Then
            MsgBox("Invalid B/L No.")
            BLDestIsNew = True
            Exit Sub
        Else
            BLDestIsNew = False
        End If

        DM.QueryCriteria.Clear()
        DM.QueryCriteria.And(JoinPath.TB_OutwardCntrs.Columns.BLID, DestBL.ID, MatchType.Exact)
        DM.GetTB_OutwardCntrs()

        For Each Dr In DM.DataSet.Tables("TB_OutwardCntrs").Select("BLID = '" & DestBL.ID.ToString & "'")
            nDr = TBCnDest.NewRow
            nDr("ID") = Dr("ID")
            nDr("CntrNo") = Dr("CntrNo")
            nDr("CnSize") = Dr("CnSize")
            nDr("CnType") = Dr("CnType")

            TBCnDest.Rows.Add(nDr)
        Next

        TB = DM.DataSet.Tables("TB_OutwardBLS").Copy
        TB.Clear()
        TB.AcceptChanges()

        For Each Dr In DM.DataSet.Tables("TB_OutwardBLS").Select("BLNO = '" & TxtBLDest.Text & "'")
            TB.ImportRow(Dr)
        Next

        Me.GridBLDest.DataSource = TB

        Me.GridCnDest.DataSource = TBCnDest
        GridNumSeperator(Me.GridCnDest)
        GridNumSeperator(Me.GridBLDest)
    End Sub

    Private Sub CopyBL()

        Dim Drs() As DataRow
        Dim DR As DataRow
        Dim NewDr As DataRow
        Dim Ref As Long
        Dim GID As Guid = Guid.NewGuid
        Dim aFld() As String = {"Reference"}
        Dim lResult As Boolean
        Dim nDrs() As DataRow
        Dim ColName As String
        Dim LogDataset As DataSet

        If GridBLOrigin Is Nothing Then
            MsgBox("No Valid Origin B/L !")
            Exit Sub
        End If

        If TxtBLDest.Text = "" Then
            MsgBox("Please Fill Detination B/L !")
            Exit Sub
        End If


        If BLDestIsNew = False Then
            MsgBox("B/L Already Existed !")
            Exit Sub
        End If

        Ref = FieldsBySql("SP_GetLastOutwardReference '" & CurrentShippingLine & "'", aFld, lResult).Item(0).ToString
        Ref += 1

        DM.QueryCriteria.Clear()
        DM.QueryCriteria.And(JoinPath.TB_OutwardBlsGoods.Columns.BLID, OriginBL.ID, MatchType.Exact)
        DM.GetTB_OutwardBlsGoods()

        DM.QueryCriteria.Clear()
        DM.QueryCriteria.And(JoinPath.TB_OutwardBlsNames.Columns.BLID, OriginBL.ID, MatchType.Exact)
        DM.GetTB_OutwardBlsNames()

        With DM.DataSet

            Drs = .Tables("TB_OutwardBls").Select("ID = '" & OriginBL.ID.ToString & "'")
            DR = Drs(0)
            NewDr = .Tables("TB_OutwardBls").NewRow

            For Each Col As DataColumn In DR.Table.Columns
                Try
                    NewDr.Item(Col.ColumnName) = DR.Item(Col.ColumnName)
                Catch ex As Exception
                End Try
            Next

            NewDr("ID") = GID
            NewDr("Reference") = Ref
            NewDr("JobNumber") = GenerateJobNumber("I")
            NewDr("BlNo") = TxtBLDest.Text
            .Tables("TB_OutwardBls").Rows.Add(NewDr)
            DM.CommitAll()

            Drs = .Tables("TB_OutwardBlsNames").Select("BLID = '" & OriginBL.ID.ToString & "'")
            DR = Drs(0)
            NewDr = .Tables("TB_OutwardBlsNames").NewRow
            For Each Col As DataColumn In DR.Table.Columns
                Try
                    NewDr.Item(Col.ColumnName) = DR.Item(Col.ColumnName)
                Catch ex As Exception
                End Try
            Next
            NewDr("ID") = Guid.NewGuid
            NewDr("BLID") = GID
            .Tables("TB_OutwardBlsNames").Rows.Add(NewDr)


            Drs = .Tables("TB_OutwardBlsGoods").Select("BLID = '" & OriginBL.ID.ToString & "'")
            DR = Drs(0)
            NewDr = .Tables("TB_OutwardBlsGoods").NewRow
            For Each Col As DataColumn In DR.Table.Columns
                Try
                    NewDr.Item(Col.ColumnName) = DR.Item(Col.ColumnName)
                Catch ex As Exception
                End Try
            Next
            NewDr("ID") = Guid.NewGuid
            NewDr("BLID") = GID
            .Tables("TB_OutwardBlsGoods").Rows.Add(NewDr)


            Drs = TBCnOrigin.Select("Select = true")
            For Each DR In Drs
                nDrs = DM.DataSet.Tables("TB_OutwardCntrs").Select("ID = '" & DR("ID").ToString & "'")
                If nDrs.Length > 0 Then
                    nDrs(0).Item("FLE") = "L"
                    NewDr = DM.DataSet.Tables("TB_OutwardCntrs").NewRow
                    For Each Col As DataColumn In DM.DataSet.Tables("TB_OutwardCntrs").Columns
                        ColName = Col.ColumnName
                        NewDr(ColName) = nDrs(0).Item(ColName)
                    Next
                    NewDr("ID") = Guid.NewGuid
                    NewDr("BLID") = GID
                    DM.DataSet.Tables("TB_OutwardCntrs").Rows.Add(NewDr)
                End If
            Next

        End With

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


        If BLDestIsNew = False Then
            MsgBox("B/L Already Existed !")
            Exit Sub
        End If


        If GridBLOrigin Is Nothing Then
            MsgBox("No Valid Origin B/L !")
            Exit Sub
        End If

        If TxtBLDest.Text = "" Then
            MsgBox("Please Fill Detination B/L !")
            Exit Sub
        End If


        If BLDestIsNew = False Then
            MsgBox("B/L Already Existed !")
            Exit Sub
        End If


        Drs = TBCnOrigin.Select("Select = true")
        If Drs.Length = 0 Then
            MsgBox("No any Continer Select !")
            Exit Sub
        End If



        Ref = FieldsBySql("SP_GetLastOutwardReference '" & CurrentShippingLine & "'", aFld, lResult).Item(0).ToString
        Ref += 1

        DM.QueryCriteria.Clear()
        DM.QueryCriteria.And(JoinPath.TB_OutwardBlsGoods.Columns.BLID, OriginBL.ID, MatchType.Exact)
        DM.GetTB_OutwardBlsGoods()

        DM.QueryCriteria.Clear()
        DM.QueryCriteria.And(JoinPath.TB_OutwardBlsNames.Columns.BLID, OriginBL.ID, MatchType.Exact)
        DM.GetTB_OutwardBlsNames()

        With DM.DataSet

            Drs = .Tables("TB_OutwardBls").Select("ID = '" & OriginBL.ID.ToString & "'")
            DR = Drs(0)
            NewDr = .Tables("TB_OutwardBls").NewRow

            For Each Col As DataColumn In DR.Table.Columns
                Try
                    NewDr.Item(Col.ColumnName) = DR.Item(Col.ColumnName)
                Catch ex As Exception
                End Try
            Next



            NewDr("ID") = GID
            NewDr("Reference") = Ref
            NewDr("JobNumber") = GenerateJobNumber("I")
            NewDr("BlNo") = TxtBLDest.Text
            .Tables("TB_OutwardBls").Rows.Add(NewDr)
            DM.CommitAll()

            Drs = .Tables("TB_OutwardBlsNames").Select("BLID = '" & OriginBL.ID.ToString & "'")
            DR = Drs(0)
            NewDr = .Tables("TB_OutwardBlsNames").NewRow
            For Each Col As DataColumn In DR.Table.Columns
                Try
                    NewDr.Item(Col.ColumnName) = DR.Item(Col.ColumnName)
                Catch ex As Exception
                End Try
            Next
            NewDr("ID") = Guid.NewGuid
            NewDr("BLID") = GID
            .Tables("TB_OutwardBlsNames").Rows.Add(NewDr)


            Drs = .Tables("TB_OutwardBlsGoods").Select("BLID = '" & OriginBL.ID.ToString & "'")
            DR = Drs(0)
            NewDr = .Tables("TB_OutwardBlsGoods").NewRow
            For Each Col As DataColumn In DR.Table.Columns
                Try
                    NewDr.Item(Col.ColumnName) = DR.Item(Col.ColumnName)
                Catch ex As Exception
                End Try
            Next
            NewDr("ID") = Guid.NewGuid
            NewDr("BLID") = GID
            .Tables("TB_OutwardBlsGoods").Rows.Add(NewDr)

        End With

        Drs = TBCnOrigin.Select("Select = true")
        For Each DR In Drs
            nDrs = DM.DataSet.Tables("TB_OutwardCntrs").Select("ID = '" & DR("ID").ToString & "'")
            If nDrs.Length > 0 Then
                nDrs(0).Item("BLID") = GID
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

    Private Sub MergeBL()

        Dim Drs() As DataRow
        Dim nDrs() As DataRow
        Dim Dr As DataRow
        Dim LogDataSet As DataSet
        Me.GridCnOrigin.UpdateData()

        If OriginBL Is Nothing Then
            MsgBox("No Valid Origin BL !")
            Exit Sub
        End If

        If DestBL Is Nothing Then
            MsgBox("No Valid Destination BL !")
            Exit Sub
        End If

        Drs = TBCnOrigin.Select("Select = true")
        If Drs.Length = 0 Then
            MsgBox("No any Continer Select !")
            Exit Sub
        End If

        For Each Dr In Drs
            nDrs = DM.DataSet.Tables("TB_OutwardCntrs").Select("ID = '" & Dr("ID").ToString & "'")
            If nDrs.Length > 0 Then
                nDrs(0).Item("BLID") = DestBL.ID
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

  


    Private Sub FrmBLToolsOutward_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

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


End Class