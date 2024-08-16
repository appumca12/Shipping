Imports OrmLib
Imports ShippingBiz

Public Class FrmBLTools

    Private DM As DataManager
    Private OriginBL As TB_InwardBLS
    Private DestBL As TB_InwardBLS
    Private TBCnOrigin As DataTable
    Private TBCnDest As DataTable
    Private IsValidOrigin As Boolean
    Private IsValidDest As Boolean
    Private BLDestIsNew As Boolean

    Private Sub ButtonPickupSource_Click(sender As System.Object, e As System.EventArgs) Handles ButtonPickupSource.Click


        Dim Dr As DataRow
        Dim nDr As DataRow

        TBCnOrigin.Clear()

        'Me.GridBLDest.DataSource = Nothing
        'Me.GridCnDest.DataSource = Nothing
        Me.GridBLOrigin.DataSource = Nothing
        Me.GridCnOrigin.DataSource = Nothing

        DM = New DataManager(My.Settings.DSN)
        DM.QueryCriteria.And(JoinPath.TB_InwardBLS.Columns.Line, CurrentShippingLine, MatchType.Exact)
        DM.QueryCriteria.And(JoinPath.TB_InwardBLS.Columns.BlNo, TxtBLSource.Text, MatchType.Exact)
        OriginBL = DM.GetTB_InwardBLS

        If OriginBL Is Nothing Then
            MsgBox("Invalid B/L No.")
            Exit Sub
        End If

        DM.QueryCriteria.Clear()
        DM.QueryCriteria.And(JoinPath.TB_InwardCntrs.Columns.BLID, OriginBL.ID, MatchType.Exact)
        DM.GetTB_InwardCntrs()

        For Each Dr In DM.DataSet.Tables("TB_InwardCntrs").Rows
            nDr = TBCnOrigin.NewRow
            nDr("ID") = Dr("ID")
            nDr("CntrNo") = Dr("CntrNo")
            nDr("CnSize") = Dr("CnSize")
            nDr("CnType") = Dr("CnType")
            nDr("Select") = False
            TBCnOrigin.Rows.Add(nDr)
        Next

        Me.GridBLOrigin.DataSource = DM.DataSet.Tables("TB_InwardBLS").Copy
        Me.GridCnOrigin.DataSource = TBCnOrigin
        GridNumSeperator(Me.GridBLOrigin)
        GridNumSeperator(Me.GridCnOrigin)

    End Sub

    Private Sub Form2_Load(sender As Object, e As System.EventArgs) Handles Me.Load

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

        With Me.Line
            .AddOutSide(TB)
            .CustomDisplayMember = "LineCode"
            .CustomValueMember = "LineCode"
        End With

        Me.Line.CustomData = CurrentShippingLine


    End Sub

    Private Sub ButtonPickupDest_Click(sender As System.Object, e As System.EventArgs) Handles ButtonPickupDest.Click

        Dim Dr As DataRow
        Dim nDr As DataRow
        Dim TB As New DataTable

        TBCnDest.Clear()
        TBCnDest.AcceptChanges()

        DM.QueryCriteria.Clear()
        DM.QueryCriteria.And(JoinPath.TB_InwardBLS.Columns.Line, CurrentShippingLine, MatchType.Exact)
        DM.QueryCriteria.And(JoinPath.TB_InwardBLS.Columns.BlNo, TxtBLDest.Text, MatchType.Exact)
        DestBL = DM.GetTB_InwardBLS

        If DestBL Is Nothing Then
            MsgBox("Invalid B/L No.")
            BlDestIsNew = True
            Exit Sub
        Else
            BlDestIsNew = False
        End If

        DM.QueryCriteria.Clear()
        DM.QueryCriteria.And(JoinPath.TB_InwardCntrs.Columns.BLID, DestBL.ID, MatchType.Exact)
        DM.GetTB_InwardCntrs()

        For Each Dr In DM.DataSet.Tables("TB_InwardCntrs").Select("BLID = '" & DestBL.ID.ToString & "'")
            nDr = TBCnDest.NewRow
            nDr("ID") = Dr("ID")
            nDr("CntrNo") = Dr("CntrNo")
            nDr("CnSize") = Dr("CnSize")
            nDr("CnType") = Dr("CnType")

            TBCnDest.Rows.Add(nDr)
        Next

        TB = DM.DataSet.Tables("TB_InwardBLS").Copy
        TB.Clear()
        TB.AcceptChanges()

        For Each Dr In DM.DataSet.Tables("TB_InwardBLS").Select("BLNO = '" & TxtBLDest.Text & "'")
            TB.ImportRow(Dr)
        Next

        Me.GridBLDest.DataSource = TB

        Me.GridCnDest.DataSource = TBCnDest
        GridNumSeperator(Me.GridCnDest)
        GridNumSeperator(Me.GridBLDest)

    End Sub

    Private Sub ButtonApply_Click(sender As System.Object, e As System.EventArgs) Handles ButtonApply.Click

        Select Case OptionSet.Value
            Case "C"
                Call CopyBL()
            Case "S"
                Call SplitBL()
            Case "M"
                Call MergeBL()
        End Select
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

        Ref = FieldsBySql("SP_GetLastInwardReference '" & CurrentShippingLine & "'", aFld, lResult).Item(0).ToString
        Ref += 1

        DM.QueryCriteria.Clear()
        DM.QueryCriteria.And(JoinPath.TB_InwardBlsGoods.Columns.BLID, OriginBL.ID, MatchType.Exact)
        DM.GetTB_InwardBlsGoods()

        DM.QueryCriteria.Clear()
        DM.QueryCriteria.And(JoinPath.TB_InwardBlsNames.Columns.BLID, OriginBL.ID, MatchType.Exact)
        DM.GetTB_InwardBlsNames()

        With DM.DataSet

            Drs = .Tables("TB_InwardBls").Select("ID = '" & OriginBL.ID.ToString & "'")
            DR = Drs(0)
            NewDr = .Tables("TB_InwardBls").NewRow

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
            NewDr("Line") = Me.Line.CustomSelectedItem
            .Tables("TB_InwardBls").Rows.Add(NewDr)
            DM.CommitAll()

            Drs = .Tables("TB_InwardBlsNames").Select("BLID = '" & OriginBL.ID.ToString & "'")
            DR = Drs(0)
            NewDr = .Tables("TB_InwardBlsNames").NewRow
            For Each Col As DataColumn In DR.Table.Columns
                Try
                    NewDr.Item(Col.ColumnName) = DR.Item(Col.ColumnName)
                Catch ex As Exception
                End Try
            Next
            NewDr("ID") = Guid.NewGuid
            NewDr("BLID") = GID
            .Tables("TB_InwardBlsNames").Rows.Add(NewDr)
 
            Drs = .Tables("TB_InwardBlsGoods").Select("BLID = '" & OriginBL.ID.ToString & "'")
            DR = Drs(0)
            NewDr = .Tables("TB_InwardBlsGoods").NewRow
            For Each Col As DataColumn In DR.Table.Columns
                Try
                    NewDr.Item(Col.ColumnName) = DR.Item(Col.ColumnName)
                Catch ex As Exception
                End Try
            Next
            NewDr("ID") = Guid.NewGuid
            NewDr("BLID") = GID
            .Tables("TB_InwardBlsGoods").Rows.Add(NewDr)


            Drs = TBCnOrigin.Select("Select = true")
            For Each DR In Drs
                nDrs = DM.DataSet.Tables("TB_InwardCntrs").Select("ID = '" & DR("ID").ToString & "'")
                If nDrs.Length > 0 Then
                    nDrs(0).Item("FLE") = "L"
                    NewDr = DM.DataSet.Tables("TB_InwardCntrs").NewRow
                    For Each Col As DataColumn In DM.DataSet.Tables("TB_InwardCntrs").Columns
                        ColName = Col.ColumnName
                        NewDr(ColName) = nDrs(0).Item(ColName)
                    Next
                    NewDr("ID") = Guid.NewGuid
                    NewDr("BLID") = GID
                    DM.DataSet.Tables("TB_InwardCntrs").Rows.Add(NewDr)
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



        Ref = FieldsBySql("SP_GetLastInwardReference '" & CurrentShippingLine & "'", aFld, lResult).Item(0).ToString
        Ref += 1

        DM.QueryCriteria.Clear()
        DM.QueryCriteria.And(JoinPath.TB_InwardBlsGoods.Columns.BLID, OriginBL.ID, MatchType.Exact)
        DM.GetTB_InwardBlsGoods()

        DM.QueryCriteria.Clear()
        DM.QueryCriteria.And(JoinPath.TB_InwardBlsNames.Columns.BLID, OriginBL.ID, MatchType.Exact)
        DM.GetTB_InwardBlsNames()

        With DM.DataSet

            Drs = .Tables("TB_InwardBls").Select("ID = '" & OriginBL.ID.ToString & "'")
            DR = Drs(0)
            NewDr = .Tables("TB_InwardBls").NewRow

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
            NewDr("Line") = Me.Line.CustomSelectedItem
            NewDr("FrtCoverdBlNo") = TxtBLSource.Text
            .Tables("TB_InwardBls").Rows.Add(NewDr)
            DM.CommitAll()

            Drs = .Tables("TB_InwardBlsNames").Select("BLID = '" & OriginBL.ID.ToString & "'")
            DR = Drs(0)
            NewDr = .Tables("TB_InwardBlsNames").NewRow
            For Each Col As DataColumn In DR.Table.Columns
                Try
                    NewDr.Item(Col.ColumnName) = DR.Item(Col.ColumnName)
                Catch ex As Exception
                End Try
            Next
            NewDr("ID") = Guid.NewGuid
            NewDr("BLID") = GID
            .Tables("TB_InwardBlsNames").Rows.Add(NewDr)


            Drs = .Tables("TB_InwardBlsGoods").Select("BLID = '" & OriginBL.ID.ToString & "'")
            DR = Drs(0)
            NewDr = .Tables("TB_InwardBlsGoods").NewRow
            For Each Col As DataColumn In DR.Table.Columns
                Try
                    NewDr.Item(Col.ColumnName) = DR.Item(Col.ColumnName)
                Catch ex As Exception
                End Try
            Next
            NewDr("ID") = Guid.NewGuid
            NewDr("BLID") = GID
            .Tables("TB_InwardBlsGoods").Rows.Add(NewDr)

        End With

        Drs = TBCnOrigin.Select("Select = true")
        For Each DR In Drs
            nDrs = DM.DataSet.Tables("TB_InwardCntrs").Select("ID = '" & DR("ID").ToString & "'")
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
            nDrs = DM.DataSet.Tables("TB_InwardCntrs").Select("ID = '" & Dr("ID").ToString & "'")
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

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
End Class