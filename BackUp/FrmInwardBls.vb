Imports OrmLib
Imports ShippingBiz
Imports System.Data.SqlClient

Public Class FrmInwardBls

    Private dm As DataManager
    Private FrmStatus As FormStatus
    Private BL As TB_InwardBLSCollection
    Private BLID As Guid
    Private TBSummary As DataTable
    Private Voyage As TB_Voyage
    Private SOF As TB_SOF
    Private DETN As CLDetention
    Private ItemLevel As String = "000"
    Private Sub FrmInwardBls_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Cursor = Cursors.WaitCursor
        Me.GeneralForms.InitControl("Inward B/LS", ItemLevel)
        Me.BLSData.InitControl(UserBLS.InwardOutward.Inward, My.Settings.MainColor)
        Me.BlsGoods.InitControl()
        Me.BlsCharges.InitControl()
        Me.BlsDocs.InitControl()
        Me.BLMisc.InitControl()
        Me.BlsPersian.InitControl()
        Me.BlsComments.InitControl(UserBlsComments.InwardOutward.Inward)
        Me.UserFinancial.InitControl()

        Me.Top = 0
        Me.Left = 0
        BlsCntrs.InitControl(UserBlsCntrs.InwardOutward.Inward)
        FrmStatus = FormStatus.NoAction
        ChangeStatus(FrmStatus)
        ChangeLocked()
        Me.Cursor = Cursors.Default

        TBSummary = New DataTable
        TBSummary.Columns.Add(New DataColumn("Description", System.Type.GetType("System.String")))
        TBSummary.Columns.Add(New DataColumn("Value", System.Type.GetType("System.String")))
        Me.GridSummary.DataSource = TBSummary
        FrmStatus = FormStatus.NoAction
        ChangeStatus(FrmStatus)

        Me.GeneralForms.AddCustomTools("Advance Search", "Advance Search", My.Resources.search_24)
        Me.GeneralForms.ShowHistoryButtom = True

    End Sub

    Private Sub GeneralForms_CustomDeleteClick() Handles GeneralForms.CustomDeleteClick

        Dim LogDataSet As DataSet
        If dm.DataSet.Tables("TB_InwardBls").Rows.Count > 0 Then
            If MsgBoxDelete() = Windows.Forms.DialogResult.Yes Then
                Try
                    dm.DataSet.Tables("TB_InwardBls").Rows(0).Delete()
                    LogDataSet = dm.DataSet.Copy
                    dm.CommitAll()
                    GenerateLog(LogDataSet)
                    MsgBoxDeleteSuccessful()
                    Me.BlsDetailTab.Tabs(0).Selected = True
                    LockStatus(True)
                    ClearControl(Me)
                    FrmStatus = FormStatus.NoAction
                    General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)
                Catch ex As Exception
                    MsgBoxDeleteFailed()
                    MsgBox(ex.ToString)
                End Try
            End If
        End If
    End Sub

    Private Sub GeneralForms_CustomEditClick() Handles GeneralForms.CustomEditClick
        FrmStatus = FormStatus.EditRecord
        ChangeStatus(FrmStatus)
        ChangeLocked()
    End Sub

    Private Sub GeneralForms_CustomFindClick() Handles GeneralForms.CustomFindClick

        Dim DummyBl As String = Me.BLNO.TextValue
        Dim aTables() As String = {"TB_InwardBls", "Tb_InwardBlsNames", "TB_InwardBlsGoods", "TB_InwardCharges", "Tb_InwardCntrs", "TB_InwardCnsImco", "TB_InwardCnsTemprature", "TB_InwardCnsPkgs", "TB_InwardCntrsCharges", "Tb_InwardBlsFrs", "TB_InwardBlsComments"}
        Dim Dr As DataRow
        Dim nI As Byte
        Dim nTab As Byte
        Dim Discount As TB_InwardDiscount

        TBSummary.Clear()
        nTab = Me.BlsDetailTab.SelectedTab.Index
        Me.BlsDetailTab.Tabs(0).Selected = True
        LockStatus(True)

        ClearControl(Me)
        Me.BLNO.TextValue = DummyBl

        FrmStatus = FormStatus.NoAction

        If Me.BLNO.TextValue = "" Then
            MsgBoxGeneral("Please Fill B/L No", "B/L No Requird")
            Exit Sub
        End If

        dm = New DataManager(My.Settings.DSN)

        Dim ds As DataSet = StoredProcedures.SP_InwardAllDataByLineBlNo(CurrentShippingLine, Me.BLNO.TextValue)
        dm.PopulateObjectsFromDataSet(ds, aTables)

        For nI = 0 To aTables.Length - 1
            dm.DataSet.Tables(aTables(nI)).Merge(ds.Tables(nI))
        Next

        If dm.DataSet.Tables("TB_InwardBls").Rows.Count = 0 Then
            MsgBoxGeneral("No Valid B/L No !", "Information")
            ChangeStatus(FormStatus.NoAction)
            ChangeLocked()
            BLID = Guid.NewGuid
            General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FormStatus.NoAction)
            Me.TFCCode.TextValue = ""
        Else
            FrmStatus = FormStatus.HasData
            ChangeLocked()
            BLID = dm.DataSet.Tables("TB_Inwardbls").Rows(0).Item("ID")
            Me.TFCCode.TextValue = NullToValue(dm.DataSet.Tables("TB_Inwardbls").Rows(0).Item("TFCCode"), "")
            dm.QueryCriteria.Clear()
            dm.QueryCriteria.And(JoinPath.TB_InwardDiscount.Columns.BLID, BLID, MatchType.Exact)
            Discount = dm.GetTB_InwardDiscount

            ChangeStatus(FormStatus.HasData)
            Me.BLSData.SetDocument(dm.DataSet.Tables("TB_InwardBls").Rows(0))

            If dm.DataSet.Tables("TB_InwardBlsNames").Rows.Count = 0 Then
                Dr = dm.DataSet.Tables("TB_InwardBlsNames").NewRow
                Dr("ID") = System.Guid.NewGuid
                Dr("BLID") = BLID
                dm.DataSet.Tables("TB_InwardBlsNames").Rows.Add(Dr)
            End If

            If dm.DataSet.Tables("TB_InwardBlsGoods").Rows.Count = 0 Then
                Dr = dm.DataSet.Tables("TB_InwardBlsGoods").NewRow
                Dr("ID") = System.Guid.NewGuid
                Dr("BLID") = BLID
                dm.DataSet.Tables("TB_InwardBlsGoods").Rows.Add(Dr)
            End If
            Me.BlsNames.SetDocument(dm.DataSet.Tables("TB_InwardBlsNames").Rows(0))
            Me.BlsGoods.SetDocument(dm.DataSet.Tables("TB_InwardBlsGoods").Rows(0))
            If dm.DataSet.Tables("Tb_InwardBlsFrs").Rows.Count > 0 Then
                Me.BlsPersian.SetDocument(dm.DataSet.Tables("Tb_InwardBlsFrs").Rows(0))
            Else
                Me.BlsPersian.InitControl()
            End If
            Me.BlsCntrs.SetDocument(BLID, dm.DataSet)

            If Discount Is Nothing Then
                Me.BLMisc.SetDocument(dm.DataSet.Tables("TB_InwardBls").Rows(0))
            Else
                Me.BLMisc.SetDocument(dm.DataSet.Tables("TB_InwardBls").Rows(0), Discount)
            End If

            Me.BLMisc.HSCode.TextValue = NullToValue(dm.DataSet.Tables("TB_InwardBls").Rows(0).Item("HSCode"), "")

            General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)
            Me.BlsDocs.SetDocument(Me.BLNO.TextValue, BLID)

            Me.TFCCode.TextValue = NullToValue(dm.DataSet.Tables("TB_InwardBls").Rows(0).Item("TFCCODE"), "")


        End If

        Me.BlsCntrs.SetDocument(BLID, dm.DataSet)
        Me.BlsCharges.SetDocument(BLID, dm.DataSet.Tables("TB_InwardCharges"), UserBlsCharges.InwardOutward.Inward)
        Me.BlsComments.SetDocument(BLID, dm.DataSet.Tables("TB_InwardBlsComments"))

        Me.BlsDetailTab.Tabs(nTab).Selected = True
        SetSummary()
        SetFinancial()
        Me.GridSummary.Enabled = True
        Me.UserFinancial.GridData.Enabled = True

    End Sub

    Private Sub GeneralForms_CustomHistory() Handles GeneralForms.CustomHistory

        Dim Frm As FrmLogViewByID
        Dim aTable As New ArrayList

        If Me.BLNO.TextValue = "" Then
            Exit Sub
        End If

        If Me.FrmStatus = FormStatus.NewRecord Then
            Exit Sub
        End If

        aTable.Add("Tb_InwardBlsNames")
        aTable.Add("TB_InwardBlsGoods")
        aTable.Add("TB_InwardCharges")
        aTable.Add("Tb_InwardCntrs")
        'aTable.Add("TB_InwardCnsImco")
        'aTable.Add("TB_InwardCnsTemprature")
        'aTable.Add("TB_InwardCnsPkgs")

        Frm = New FrmLogViewByID(BLNO.TextValue, BLID, "TB_InwardBls", aTable, "BLID")
        '   Frm = New FrmLogViewByID(Me.BLID, Me.BLNO.TextValue)
        Frm.ShowDialog()
    End Sub

    Private Sub GeneralForms_CustomHomeClick() Handles GeneralForms.CustomHomeClick
        Me.Close()
    End Sub

    Private Sub ChangeLocked()

        Select Case FrmStatus
            Case FormStatus.EditRecord
                LockStatus(True)
            Case FormStatus.HasData
                LockStatus(False)
            Case FormStatus.NewRecord
                LockStatus(True)
            Case FormStatus.NoAction
                LockStatus(False)
        End Select

    End Sub

    Private Sub GeneralForms_CustomNavigateFirstClick() Handles GeneralForms.CustomNavigateFirstClick
        Navigate(NavigateType.FirstRecord)

    End Sub

    Private Sub GeneralForms_CustomNavigateLastClick() Handles GeneralForms.CustomNavigateLastClick
        Navigate(NavigateType.LastRecord)
    End Sub

    Private Sub GeneralForms_CustomNavigateNextClick() Handles GeneralForms.CustomNavigateNextClick
        Navigate(NavigateType.NextRecord)

    End Sub

    Private Sub GeneralForms_CustomNavigatePrivClick() Handles GeneralForms.CustomNavigatePrivClick
        Navigate(NavigateType.PreviousRecord)
    End Sub

    Private Sub GeneralForms_CustomNewClick() Handles GeneralForms.CustomNewClick
        Dim dummyBl As String = Me.BLNO.TextValue
        dm = New DataManager(My.Settings.DSN)
        FrmStatus = FormStatus.NewRecord
        BLID = Guid.NewGuid
        ChangeStatus(FrmStatus)
        ChangeLocked()
        ClearControl(Me)
        BlsCntrs.SetDocument(BLID, dm.DataSet)

        BlsCharges.SetDocument(BLID, dm.DataSet.Tables("TB_InwardCharges"), UserBlsCharges.InwardOutward.Inward)
        Me.BLNO.TextValue = dummyBl

    End Sub

    Private Sub ChangeStatus(ByVal Status As FormStatus)
        FrmStatus = Status
        General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)
    End Sub

    Private Sub GeneralForms_CustomOthers() Handles GeneralForms.CustomOthers
        Dim Frm As New FrmGeneralSearch(FrmGeneralSearch.InwardOutward.InWard)
        Frm.ShowDialog()
        If Frm.BLNo <> "" Then
            If Frm.Line <> CurrentShippingLine Then
                MsgBox("Line in not equal with selected line !")
            Else
                Me.BLNO.TextValue = Frm.BLNo
                GeneralForms_CustomFindClick()
            End If
        End If
    End Sub

    Private Sub GeneralForms_CustomPrintClick() Handles GeneralForms.CustomPrintClick
        Dim Frm As FrmDialogPrint = New FrmDialogPrint(FrmDialogPrint.InwardOutward.Inward, Me.BLNO.TextValue)
        Frm.ShowDialog()
    End Sub

    Private Sub GeneralForms_CustomSaveClick() Handles GeneralForms.CustomSaveClick

        Dim Dr As DataRow
        Dim Bl As DataRow
        Dim Tb As DataTable
        Dim nErrCount As Byte = 0
        Dim DsTemp As New DataSet
        Dim TbName As String
        Dim Dv As DataView
        Dim cLen As Byte
        Dim DC As DataColumn
        Dim LogDataSet As New DataSet
        Dim DtnStat As DataRow
        Dim Drs() As DataRow
        Dim dDr As DataRow

        If Me.BLNO.TextValue = "" Then
            MsgBoxGeneral("Please Fill B/L NO.", "Validate")
            Exit Sub
        End If

        CheckTotal()

        Me.BLSData.Checking(Tb)
        Me.BlsGoods.Checking(Tb, Me.BlsCntrs.GridCntrs.DataSource.tables(0).copy)
        Me.BlsCntrs.Checking(Tb)
        Me.BlsCharges.Checking(Tb)
        Me.BLMisc.Checking(Tb)
 
        If Not Tb Is Nothing Then
            nErrCount = RaiseError(Tb)
            If nErrCount > 0 Then
                MsgBoxValidateFaild()
                Exit Sub
            End If
            If MsgBox("Do You Want Continue With Warnings ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If

        If MsgBoxUpdate() = Windows.Forms.DialogResult.Yes Then
            With dm.DataSet.Tables("TB_InwardBls")
                If .Rows.Count = 0 Then
                    Bl = .NewRow
                    Bl("ID") = BLID
                    .Rows.Add(Bl)

                End If
                BLSData.GetDocument(.Rows(0), Me.BLNO.TextValue)
                BLMisc.GetDocument(.Rows(0))
                If NullToValue(dm.DataSet.Tables("TB_InwardBls").Rows(0).Item("TFCCode"), "") <> Me.TFCCode.TextValue Then
                    dm.DataSet.Tables("TB_InwardBls").Rows(0).Item("TFCCode") = Me.TFCCode.TextValue
                End If
                dm.DataSet.Tables("TB_InwardBls").Rows(0).Item("BarCode") = Me.BLMisc.BarCode.TextValue
                dm.DataSet.Tables("TB_InwardBls").Rows(0).Item("HSCode") = Me.BLMisc.HSCode.TextValue
            End With

            DsTemp = Me.BlsCntrs.GetCntrsChanges

            If Not DsTemp Is Nothing Then
                For Each Tb In DsTemp.Tables
                    TbName = "TB_Inward" & Tb.TableName
                    For Each Dr In Tb.Rows
                        Select Case Dr.RowState
                            Case DataRowState.Added
                                dm.DataSet.Tables(TbName).ImportRow(Dr)
                            Case DataRowState.Deleted
                                Dv = New DataView(dm.DataSet.Tables(TbName), "ID = '" & Dr(0, DataRowVersion.Original).ToString & "'", "", DataViewRowState.CurrentRows)
                                If Dv.Count > 0 Then
                                    Dv.Item(0).Delete()
                                End If
                            Case DataRowState.Modified
                                Dv = New DataView(dm.DataSet.Tables(TbName), "ID = '" & Dr.Item("ID").ToString & "'", "", DataViewRowState.CurrentRows)
                                If Dv.Count > 0 Then
                                    cLen = Dr.ItemArray.Length
                                    For Each DC In Tb.Columns
                                        Dv.Item(0).Item(DC.ColumnName) = Dr.Item(DC.ColumnName)
                                    Next
                                End If
                        End Select
                    Next
                Next
            End If
            Me.BlsCntrs.AcceptCntrsChanges()
 
            With dm.DataSet.Tables("TB_InwardBlsNames")
                If .Rows.Count = 0 Then
                    Dr = .NewRow
                    Dr("ID") = Guid.NewGuid
                    Dr("BLID") = BLID
                Else
                    Dr = .Rows(0)
                End If
                Me.BlsNames.getDocument(Dr)

                If dm.DataSet.Tables("TB_InwardBlsNames").Rows.Count = 0 Then
                    dm.DataSet.Tables("TB_InwardBlsNames").Rows.Add(Dr)
                End If
            End With

            With dm.DataSet.Tables("TB_InwardBlsGoods")
                If .Rows.Count = 0 Then
                    Dr = .NewRow
                    Dr("ID") = Guid.NewGuid
                    Dr("BLID") = BLID
                Else
                    Dr = .Rows(0)
                End If
                Me.BlsGoods.getDocument(Dr)
                If dm.DataSet.Tables("TB_InwardBlsGoods").Rows.Count = 0 Then
                    dm.DataSet.Tables("TB_InwardBlsGoods").Rows.Add(Dr)
                End If
            End With


            With dm.DataSet.Tables("Tb_InwardBlsFrs")
                If .Rows.Count = 0 Then
                    Dr = .NewRow
                    Dr("ID") = Guid.NewGuid
                    Dr("BLID") = BLID
                Else
                    Dr = .Rows(0)
                End If
                Me.BlsPersian.getDocument(Dr)
                If dm.DataSet.Tables("Tb_InwardBlsFrs").Rows.Count = 0 Then
                    dm.DataSet.Tables("Tb_InwardBlsFrs").Rows.Add(Dr)
                End If
            End With

            Me.BlsCharges.GetDocument(dm.DataSet.Tables("TB_InwardCharges"))

            If Me.BLMisc.FreeDays <> 0 Or Me.BLMisc.DetentionID.ToString = "" Then
                If dm.DataSet.Tables("TB_InwardDiscount").Rows.Count = 0 Then
                    dDr = dm.DataSet.Tables("TB_InwardDiscount").NewRow
                    dDr("ID") = Guid.NewGuid
                    dDr("BLID") = BLID
                    dDr("dFreeDays") = Me.BLMisc.FreeDays
                    dDr("IsFDaysAsDiscount") = Me.BLMisc.FreeDaysAsDiscount

                    If Me.BLMisc.DetentionID.ToString <> "" And Me.BLMisc.DetentionID.ToString <> Guid.Empty.ToString Then
                        dDr("DetentionID") = Me.BLMisc.DetentionID
                        dDr("SpecialCalculate") = True
                    Else
                        dDr("DetentionID") = DBNull.Value
                        dDr("SpecialCalculate") = False
                    End If
                    dDr("NoTax") = "N"

                    dm.DataSet.Tables("TB_InwardDiscount").Rows.Add(dDr)
                Else
                    dDr = dm.DataSet.Tables("TB_InwardDiscount").Rows(0)
                    dDr("dFreeDays") = Me.BLMisc.FreeDays
                    dDr("IsFDaysAsDiscount") = Me.BLMisc.FreeDaysAsDiscount
                    If Me.BLMisc.DetentionID.ToString <> "" And Me.BLMisc.DetentionID.ToString <> Guid.Empty.ToString Then
                        dDr("DetentionID") = Me.BLMisc.DetentionID
                        dDr("SpecialCalculate") = True
                    Else
                        dDr("DetentionID") = DBNull.Value
                        dDr("SpecialCalculate") = False
                    End If
                    dDr("NoTax") = "N"
                End If
            Else
                If dm.DataSet.Tables("TB_InwardDiscount").Rows.Count > 0 Then
                    dm.DataSet.Tables("TB_InwardDiscount").Rows(0).Delete()
                End If
            End If

            Me.BlsComments.GetDocument(dm.DataSet.Tables("TB_InwardBlsComments"))

            Try
                If FrmStatus = FormStatus.NewRecord Then
                    Drs = dm.DataSet.Tables("TB_InwardStatus").Select("BLID = '" & BLID.ToString & "'", "")
                    If Drs.Length = 0 Then
                        Dr = dm.DataSet.Tables("TB_InwardStatus").NewRow
                        Dr("ID") = Guid.NewGuid
                        Dr("BLID") = BLID
                        dm.DataSet.Tables("TB_InwardStatus").Rows.Add(Dr)
                    End If
                End If
                LogDataSet = dm.DataSet.Copy
                dm.CommitAll()
                GenerateLog(LogDataSet)
                MsgBoxSaveSuccessful()
                FrmStatus = FormStatus.HasData
                ChangeStatus(FrmStatus)
                Me.BlsCharges.ChrgesTable.AcceptChanges()
            Catch ex As Exception
                MsgBoxSaveFailed()
                MsgBoxGeneral(ex.ToString, "Error On Save B/L !")
            End Try

        End If

    End Sub

    Private Sub LockStatus(ByVal Status As Boolean)

        LockControls(Me, Status)
        Me.BLNO.GeneralText.Enabled = True
        'Me.BLSData.Enabled = Status
        'Me.BlsCharges.Enabled = Status
        'Me.BlsGoods.Enabled = Status
        'Me.BlsCntrs.Enabled = Status
        'Me.BlsNames.Enabled = Status

    End Sub

    Private Sub BLNO_CustomTextChanged() Handles BLNO.CustomTextChanged, TFCCode.CustomTextChanged
        If FrmStatus = FormStatus.NewRecord Then
            Dim aTables() As String = {"TB_InwardBls", "Tb_InwardBlsNames", "TB_InwardBlsGoods", "TB_InwardCharges", "Tb_InwardCntrs", "TB_InwardCnsImco", "TB_InwardCnsTemprature", "TB_InwardCnsPkgs"}
            dm = New DataManager(My.Settings.DSN)
            Dim ds As DataSet = StoredProcedures.SP_InwardAllDataByLineBlNo(CurrentShippingLine, Me.BLNO.TextValue)
            dm.PopulateObjectsFromDataSet(ds, aTables)
            If ds.Tables(0).Rows.Count > 0 Then
                MsgBoxGeneral("B/L Already Existed !", "Validate ")
                Exit Sub
            End If

        End If
    End Sub

    Private Sub BLNO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BLNO.Load, TFCCode.Load

        If FrmStatus = FormStatus.NewRecord Then

        End If

    End Sub

    Private Sub CheckTotal()

        Dim nTTW As Long = 0
        Dim nTGW As Double = 0
        Dim nTNW As Double = 0

        Dim NPkgs As Long = 0
        Dim nNwgt As Double = 0

        Dim R As Infragistics.Win.UltraWinGrid.UltraGridRow
        With Me.BlsCntrs.GridCntrs
            For Each R In .Rows
                nTTW += NullToValue(R.Cells("TW").Value, 0)
                nTGW += NullToValue(R.Cells("GW").Value, 0)
                nTNW += NullToValue(R.Cells("NET").Value, 0)
                NPkgs += NullToValue(R.Cells("NoOFPkgs").Value, 0)
            Next
        End With

        If NullToValue(Me.BlsGoods.TGW.GnrlNum.Value, 0) <> nTTW Or _
            NullToValue(Me.BlsGoods.TGW.GnrlNum.Value, 0) <> nTGW Or _
            NullToValue(Me.BlsGoods.TTLNET.GnrlNum.Value, 0) <> nTNW Or _
            NullToValue(Me.BlsGoods.TTW.GnrlNum.Value, 0) <> nTTW Or _
            NullToValue(Me.BlsGoods.TTLPKGS.GnrlNum.Value, 0) <> NPkgs Then
            If MsgBox("Do You Want Weighs Come Equal With Containers ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Me.BlsGoods.TTW.GnrlNum.Value = nTTW
                Me.BlsGoods.TGW.GnrlNum.Value = nTGW
                Me.BlsGoods.TTLNET.GnrlNum.Value = nTNW
                Me.BlsGoods.TTW.GnrlNum.Value = nTTW
                Me.BlsGoods.TTLPKGS.GnrlNum.Value = NPkgs
            End If
        End If

    End Sub

    Private Sub SetSummary()

        Dim Sof As TB_SOF
        Dim Dr As DataRow
        Dim VoyID As Guid
        Dim ST As TB_InwardStatus
        Dim DTN As New CLDetention
        Dim Ds As DataSet

        TBSummary.Clear()
        VoyID = NullToValue(Me.BLSData.FVoyage.VoyageID, Guid.NewGuid)
        dm.QueryCriteria.Clear()
        dm.QueryCriteria.And(JoinPath.TB_SOF.Columns.VoyageID, VoyID, MatchType.Exact)
        Sof = dm.GetTB_SOF
        Me.SOF = Sof


        If Not Sof Is Nothing Then

            Dr = TBSummary.NewRow
            Dr("DEscription") = "Arrival"
            Dr("Value") = Sof.Arrival.ToString
            TBSummary.Rows.Add(Dr)

            Dr = TBSummary.NewRow
            Dr("DEscription") = "Commence Dischare"
            Dr("Value") = Sof.DschCmnc.ToString
            TBSummary.Rows.Add(Dr)

            Dr = TBSummary.NewRow
            Dr("DEscription") = "Complet Dischare"
            Dr("Value") = Sof.DschCmpl.ToString
            TBSummary.Rows.Add(Dr)
        End If

        dm.QueryCriteria.Clear()
        dm.QueryCriteria.And(JoinPath.TB_InwardStatus.Columns.BLID, Me.BLID, MatchType.Exact)
        ST = dm.GetTB_InwardStatus

        If Not ST Is Nothing Then

            Dr = TBSummary.NewRow
            Dr("Description") = "D.O. Office"
            Dr("Value") = ST.DoOffice
            TBSummary.Rows.Add(Dr)

            Dr = TBSummary.NewRow
            Dr("DEscription") = "D.O. Date"
            Dr("Value") = Format(ST.DoDate.ToString, "Short Date")
            TBSummary.Rows.Add(Dr)

        End If

        Dr = TBSummary.NewRow
        Dr("DEscription") = "Total Containers"
        Dr("Value") = Replace(Me.BlsCntrs.TotalCntrString, "No Of Containers :", "")
        TBSummary.Rows.Add(Dr)
        '      DTN.GenerateImportDetention(Me.BLID)
        Ds = DTN.CalDetention(Me.BLNO.TextValue, BLID)


        Dr = TBSummary.NewRow
        Dr("DEscription") = "All Container(s) Returned Back"
        Dr("Value") = IIf(DTN.IsCntrsReturnBack = True, "YES", "NO")
        TBSummary.Rows.Add(Dr)

        Dr = TBSummary.NewRow
        Dr("DEscription") = "Detention"
        Dr("Value") = Format(DTN.TotalAmount, "#,###,###,###,###")
        TBSummary.Rows.Add(Dr)

        Dr = TBSummary.NewRow
        Dr("DEscription") = "First Paid"
        Dr("Value") = Format(DTN.FirstPaid, "#,###,###,###,###")
        TBSummary.Rows.Add(Dr)

        Dr = TBSummary.NewRow
        Dr("DEscription") = "Paid By Invoice"
        Dr("Value") = Format(DTN.Paid, "#,###,###,###,###")
        TBSummary.Rows.Add(Dr)

        Dr = TBSummary.NewRow
        Dr("DEscription") = "Balance"
        Dr("Value") = Format(DTN.Balance, "#,###,###,###,###")
        TBSummary.Rows.Add(Dr)

        If Not ST Is Nothing Then
            Dr = TBSummary.NewRow
            Dr("DEscription") = "Setelment Date"
            Dr("Value") = Mid(ST.SetelmentDate.ToString, 1, 10)
            TBSummary.Rows.Add(Dr)
        End If

        DETN = DTN

    End Sub

    Private Sub Navigate(ByVal NavType As NavigateType)

        Dim Ds As New DataSet

        Dim Prm As SqlClient.SqlParameter
        Dim arrayParams As New ArrayList

        Prm = New SqlClient.SqlParameter("Line", SqlDbType.VarChar, 10, ParameterDirection.Input)
        Prm.Value = CurrentShippingLine
        arrayParams.Add(Prm)

        Prm = New SqlClient.SqlParameter("BLNO", SqlDbType.Char, 36, ParameterDirection.Input)
        Prm.Value = Me.BLNO.TextValue
        arrayParams.Add(Prm)


        dm = New DataManager(My.Settings.DSN)


        dm.QueryCriteria.Clear()
        dm.QueryCriteria.And(JoinPath.TB_InwardBLS.Columns.Line, CurrentShippingLine, MatchType.Exact)

        Prm = New SqlClient.SqlParameter("Direction", SqlDbType.Char, 1, ParameterDirection.Input)
        Select Case NavType
            Case NavigateType.FirstRecord
                Prm.Value = "F"
            Case NavigateType.LastRecord
                Prm.Value = "L"
            Case NavigateType.NextRecord
                Prm.Value = "N"
            Case NavigateType.PreviousRecord
                Prm.Value = "P"
        End Select
        arrayParams.Add(Prm)
        Ds = dm.ExecuteProcedure("SP_InwardBlsNavigate", CType(arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))

        Try
            Me.BLNO.TextValue = Ds.Tables(0).Rows(0).Item("BLNO")
            Call GeneralForms_CustomFindClick()
        Catch ex As Exception

        End Try


    End Sub

    Private Sub BLSData_ClickArrivalNotice() Handles BLSData.ClickArrivalNotice

        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim Frm As New FrmGeneralReportShow
        Dim Dm As DataManager
        Dim Arvl As New CLArrivalNotice
        Dim Voy As TB_Voyage
        Dim Sof As TB_SOF
        Dim TB As DataTable = New DataTable
        Dim TB2 As DataTable = New DataTable
        Dim Dr As DataRow
        Dim PH As New CLPrintHdr
        Dim PCol(0) As DataColumn
        Dim cCol(0) As DataColumn
        Dim RptItems As TB_ReportCustomFieldsCollection
        Dim RptItem As TB_ReportCustomFields
        Dim LN As TB_Lines
        Dim sql As String
        Dim lResult As Boolean
        'appu-client info
        Dim Table As New DataTable
        Dim Table2 As New DataTable
        Dim adapter As New SqlDataAdapter
        Dim Cnn As New SqlConnection(My.Settings.DSN)
        Dim Cmd As New SqlCommand
        Dim Rows() As DataRow
        Dim Detn As CLDetention
        Dim Ds As DataSet
        Dim sSql As String
        Dim dv As DataView = Table.DefaultView
        Dim Nr As DataRow

        sql = "Select Line , BlNo , POD , dbo.FC_GetPortNameWithPortCode(POL) as POL , Reference , dbo.FC_GetMeaningWithGroupStdCode('ST',BlStatus) as Status from tb_inwardbls Where  ID = '" & BLID.ToString & "'"
        TableBySql(sql, TB, lResult)


        Report = New RptArrivalNotice
        Dm = New DataManager(My.Settings.DSN)
        Dm.QueryCriteria.And(JoinPath.TB_Voyage.Columns.ID, Me.BLSData.VoyageID, MatchType.Exact)
        Voy = Dm.GetTB_Voyage

        If Not Voy Is Nothing Then
            Dm.QueryCriteria.Clear()
            Dm.QueryCriteria.And(JoinPath.TB_SOF.Columns.VoyageID, Me.BLSData.VoyageID, MatchType.Exact)
            Sof = Dm.GetTB_SOF
            If Sof Is Nothing Then
                MsgBoxGeneral("No SOF For This Voyage !", "Data Requird")
                Exit Sub
            Else
                If Sof.Arrival.IsNull Then
                    MsgBoxGeneral("Arrival date is not filled !", "Data Requird")
                    Exit Sub
                End If
            End If
        Else
            MsgBoxGeneral("Invalid Voyage !", "Data Requird")
            Exit Sub
        End If

        TB.Rows(0).Item("POD") = Sof.Port
        Dr = TB.Rows(0)

        Arvl.GenArrivalNotice(Dr, CDate(Format(DateTime.Parse(Sof.DschCmpl), "Short Date")), Voy, True)


        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_ReportCustomFields.Columns.ReportName, "RptArrivalNotice", MatchType.Exact)
        RptItems = Dm.GetTB_ReportCustomFieldsCollection

        'new code start
        sql = "Select ClientID as ClientID from tb_inwardbls Where  ID = '" & BLID.ToString & "'"
        TableBySql(sql, TB, lResult)

        Me.Cursor = Cursors.WaitCursor
        sSql = "exec SP_InwardCleintInfo @ClientID "
        Cmd = New SqlCommand(sSql, Cnn)
        Cmd.Parameters.AddWithValue("@ClientID", TB.Rows(0).Item("ClientID").ToString())
        Cmd.CommandTimeout = 3000
        adapter = New SqlDataAdapter(Cmd)

        'Try
        If Cnn.State = ConnectionState.Closed Then
            Cnn.Open()
        End If

        adapter.Fill(Table)
        Table.Columns.Add(New DataColumn("Balance", System.Type.GetType("System.Double")))
        Table.Columns.Add(New DataColumn("TTL Detention", System.Type.GetType("System.Double")))
        Table.Columns.Add(New DataColumn("Devan"))
        If Table.Rows.Count > 0 Then
            For Each Dr In Table.Rows
                InwardCntrsCount(Dr("ID"), Dr("TotalCntrs"))
            Next
            '          Rows = Table.Select("Setelment is null")
            For Each Dr In Table.Rows
                Detn = New CLDetention
                Ds = Detn.CalDetention(Dr("BLNO"), Dr("ID"), False)
                'Detn.GenerateImportDetention(Dr("ID"), False)
                Dr("IsReturnBack") = Detn.IsCntrsReturnBack
                Dr("Discount") = Detn.TotalDiscount
                Dr("Detention") = Detn.TotalAmount



                If Detn.IsCalculateByError = True Then
                    Dr.RowError = "Calculate Wrong !"
                End If

                'sql = "Select Top 1 TB_EcsMoves.StatusDate From TB_EcsMoves Where Status = 'MA' and TB_EcsMoves.CntrID = (select Top 1 ID from TB_EcsContainers where TB_EcsContainers.CntrNo =  (select top 1 CntrNo from TB_InwardCntrs where TB_InwardCntrs.BLID = (select top 1 ID from TB_InwardBLS where  TB_InwardBLS.BlNo ='" & Dr("BLNO").ToString() & "')))"
                'sql = "Select Top 1 TB_EcsMoves.StatusDate From TB_EcsMoves Where Status = 'MA' and TB_EcsMoves.CntrID = (select Top 1 ID from TB_EcsContainers where Line = '" & CurrentShippingLine & "' and TB_EcsContainers.CntrNo =  (select top 1 CntrNo from TB_InwardCntrs where TB_InwardCntrs.BLID = (select top 1 ID from TB_InwardBLS where  TB_InwardBLS.BlNo ='" & Dr("BLNO").ToString() & "')))"
                sql = "Select Top 1 TB_EcsMoves.StatusDate From TB_EcsMoves Where Status = 'MA' and TB_EcsMoves.CntrID = (select Top 1 ID from TB_EcsContainers where Line = '" & CurrentShippingLine & "' and InVoyageID = (Select TB_InwardBLS.VoyageID from TB_InwardBLS where TB_InwardBLS.BlNo ='" & Dr("BLNO").ToString() & "' ) and TB_EcsContainers.CntrNo =  (select top 1 CntrNo from TB_InwardCntrs where TB_InwardCntrs.BLID = (select top 1 ID from TB_InwardBLS where  TB_InwardBLS.BlNo ='" & Dr("BLNO").ToString() & "')))"
                TableBySql(sql, TB2, lResult)
                If TB2.Rows.Count > 0 Then
                    Dr("Devan") = "RETURNED"
                Else
                    Dr("Devan") = "NOT RETURNED"
                End If
                Dr("TaxBase") = NullToValue(Dr("TaxBase"), 0)
                Dr("Detention") = Dr("Detention") - Dr("Discount")
                If Dr("IsReturnBack") = True Then
                    Dr("TTL Detention") = Dr("Detention") + (Dr("Detention") * Dr("TaxBase")) / 100
                Else : Dr("TTL Detention") = NullToValue(Dr("Detention"), 0)
                End If

                If Dr("IsReturnBack") = False Or Dr("Paid") = 0 Then
                    Dr("FirstPaid") = NullToValue(Dr("FirstPaid"), 0)
                    Dr("Paid") = 0
                ElseIf Dr("Paid") + ((Dr("Paid") * Dr("TaxBase")) / 100) <> Dr("TTL Detention") Then
                    Dr("Paid") = NullToValue(Dr("Paid"), 0) + ((Dr("Paid") * Dr("TaxBase")) / 100) + ((Dr("FirstPaid") * Dr("TaxBase")) / 100)
                Else
                    Dr("Paid") += (Dr("Paid") * Dr("TaxBase")) / 100
                End If


                'If Dr("IsReturnBack") = True Then 'NullToValue(Dr("FirstPaid"), 0) > 0 Or NullToValue(Dr("Paid"), 0) > 0 Then

                If Dr("IsReturnBack") = False Then
                    Dr("Balance") = NullToValue(Dr("TTL Detention"), 0)
                ElseIf NullToValue(Dr("Deposit"), 0) - NullToValue(Dr("ReturnBackAmount"), 0) = Dr("Paid") Then
                    Dr("Balance") = NullToValue(Dr("TTL Detention"), 0) - (NullToValue(Dr("FirstPaid"), 0) + NullToValue(Dr("Paid"), 0))
                Else
                    Dr("Balance") = NullToValue(Dr("TTL Detention"), 0) - (NullToValue(Dr("FirstPaid"), 0) + NullToValue(Dr("Paid"), 0)) - ((NullToValue(Dr("Deposit"), 0) - NullToValue(Dr("ReturnBackAmount"), 0)) - NullToValue(Dr("PaidDeposit"), 0)) '+ IIf(NullToValue(0 < Dr("ReturnBackAmount"), 0) < NullToValue(Dr("Deposit"), 0), NullToValue(Dr("Deposit"), 0) - NullToValue(Dr("ReturnBackAmount"), 0), NullToValue(Dr("Paid"), 0)))
                End If
            Next

            
        End If
        Table2.Columns.Add(New DataColumn("BLNO", System.Type.GetType("System.String")))
        Table2.Columns.Add(New DataColumn("Vessel", System.Type.GetType("System.String")))
        Table2.Columns.Add(New DataColumn("Voyage", System.Type.GetType("System.String")))
        Table2.Columns.Add(New DataColumn("TotalCntrs", System.Type.GetType("System.String")))
        Table2.Columns.Add(New DataColumn("Setelment")) ', System.Type.GetType("System.Date")))
        Table2.Columns.Add(New DataColumn("Deposit", System.Type.GetType("System.Double")))
        Table2.Columns.Add(New DataColumn("FirstPaid", System.Type.GetType("System.Double")))
        Table2.Columns.Add(New DataColumn("TaxBaseDate")) ', System.Type.GetType("System.Date")))
        Table2.Columns.Add(New DataColumn("Balance", System.Type.GetType("System.Double")))
        Table2.Columns.Add(New DataColumn("TTL Detention", System.Type.GetType("System.Double")))
        Table2.Columns.Add(New DataColumn("Devan", System.Type.GetType("System.String")))

        For Each Dr In Table.Rows
            If Dr("Balance") > 0 Then
                Nr = Table2.NewRow
                Nr("BLNO") = Dr("BLNO")
                Nr("Vessel") = Dr("Vessel")
                Nr("Voyage") = Dr("Voyage")
                Nr("TotalCntrs") = Dr("TotalCntrs")
                Nr("Setelment") = Dr("Setelment")
                Nr("Deposit") = Dr("Deposit")
                Nr("FirstPaid") = Dr("FirstPaid")
                Nr("TaxBaseDate") = Dr("TaxBaseDate")
                Nr("Balance") = Dr("Balance")
                Nr("TTL Detention") = Dr("TTL Detention")
                Nr("Devan") = Dr("Devan")

                Table2.Rows.Add(Nr)
            End If
        Next

        'new code end
        Report.SetDataSource(Arvl.Master)
        Report.Subreports("Details").SetDataSource(Arvl.Detail)
        Report.Subreports("SUBB").SetDataSource(Arvl.BLCharges)
        Report.Subreports("SUBC").SetDataSource(Table2)

        For Each RptItem In RptItems
            Report.SetParameterValue(RptItem.FieldName, GetImageInStr(RptItem.ID.ToString))
        Next

        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_Lines.Columns.LineCode, CurrentShippingLine, MatchType.Exact)
        LN = Dm.GetTB_Lines

        Report.SetParameterValue("ShippingLine", LN.LineName)

        Frm.ReportViewer.ReportSource = Report

        Frm.Text = "Arrival Notice"
        Frm.MaximizeBox = False
        Frm.Show()
    End Sub

    Private Sub BLSData_ClickBLPrint() Handles BLSData.ClickBLPrint

        Me.BLPrint.Init(UserBLPrint.InwardOutward.Inward, Me.BLNO.TextValue)
        Me.BLPrint.ComboType.Enabled = True
        Me.BLPrint.ComboType.ComboGnrl.Enabled = True

        Me.BLPrint.CmdAttachment.Enabled = True
        Me.BLPrint.CmdPrint.Enabled = True
        Me.BLPrint.CmdTemplace.Enabled = False

        PopupControl.Show()
        'Dim Frm As FrmDialogPrint = New FrmDialogPrint(FrmDialogPrint.InwardOutward.Inward, Me.BLNO.TextValue)
        'Frm.ShowDialog()
    End Sub

    Private Sub BLSData_ClickFMNFPrint() Handles BLSData.ClickFMNFPrint
        Dim mnf As New CLInwardManifest
        mnf.GenrateMnf(CurrentShippingLine, Me.BLNO.TextValue)
        mnf.ShowReport("N")

    End Sub

    Private Sub BLSData_ClieckCMNFPrint() Handles BLSData.ClieckCMNFPrint
        Dim mnf As New CLInwardManifest
        mnf.GenrateMnf(CurrentShippingLine, Me.BLNO.TextValue)
        mnf.ShowReport("Y")

    End Sub

    Private Sub SetFinancial()

        dm.QueryCriteria.Clear()
        dm.QueryCriteria.And(JoinPath.TB_Voyage.Columns.ID, Me.BLSData.VoyageID, MatchType.Exact)
        Voyage = dm.GetTB_Voyage

        If dm.DataSet.Tables("TB_InwardBls").Rows.Count > 0 Then
            With Me.UserFinancial
                .SetDocument(UserBlsFinancial.InwardOutward.Inward, _
                            dm.DataSet.Tables("TB_InwardBls").Rows(0), _
                            Voyage, SOF, DETN)

            End With
        End If

    End Sub

End Class