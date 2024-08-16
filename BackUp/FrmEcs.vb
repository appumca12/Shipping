Imports OrmLib
Imports ShippingBiz
Imports System.IO
Imports Infragistics.Win.UltraWinGrid

Public Class FrmEcs
    Private ItemLevel As String = "201"
    Private dm As DataManager
    Private MoveCode As DataTable
    Private EcsID As Guid
    Private FrmStatus As FormStatus = FormStatus.NoAction


    Private Sub GeneralForms_CustomDeleteClick() Handles GeneralForms.CustomDeleteClick

        Dim LogDataSet As New DataSet
        Dim Dr As DataRow

        If MsgBoxDelete() = Windows.Forms.DialogResult.Yes Then

            Try
                dm.DataSet.Tables("TB_EcsContainers").Rows(0).Delete()
                If dm.DataSet.Tables("TB_Damage").Rows.Count > 0 Then
                    dm.DataSet.Tables("TB_Damage").Rows(0).Delete()
                End If
                For Each Dr In dm.DataSet.Tables("TB_EcsMoves").Rows
                    Dr.Delete()
                Next
                LogDataSet = dm.DataSet.Copy
                dm.CommitAll()
                GenerateLog(LogDataSet)
                Me.GeneralForms_CustomFindClick()
                Me.EcsTab.Tabs(0).Selected = True
                MsgBoxDeleteSuccessful()
            Catch ex As Exception
                MsgBoxDeleteFailed()
            End Try

        End If
    End Sub

    Private Sub GeneralForms_CustomEditClick() Handles GeneralForms.CustomEditClick

        If Me.GridResult.Rows.Count = 0 Then
            MsgBoxGeneral("No Container For Edit !", "Error")
            Exit Sub
        End If
        SetDocument()
        Me.EcsTab.Tabs(1).Selected = True
        FrmStatus = FormStatus.EditRecord
        General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)
        LockStatus(True)

        'Added the below code for GETTING ECS LOCKED AFTER INPUTTING SPECIFIC MOVMENET
        If (CurrentUser.IsAccountAdmin = False) Then
            For Each GR In Me.GridMoves.Rows
                If Me.GridMoves.ActiveRow.Cells("Status").Text <> "" Then
                    GR.Activation = Activation.Disabled
                End If
            Next
        End If
    End Sub
    Private Sub GeneralForms_CustomFindClick() Handles GeneralForms.CustomFindClick

        Dim sDummy As String = Me.SrchCntrNo.TextValue
        Dim sSql As String
        Dim Tb As New DataTable
        Dim lResult As Boolean

        If Not Me.DataSetForm.Tables("TBSearchResult") Is Nothing Then
            Me.DataSetForm.Tables("TBSearchResult").Clear()
        End If

        ClearControl(Me)
        Me.SrchCntrNo.TextValue = sDummy

        dm = New DataManager(My.Settings.DSN)

        sSql = "SP_EcsContainerSearch '" & Me.SrchCntrNo.TextValue & "' , '" & CurrentShippingLine & "'"
        TableBySql(sSql, Tb, lResult)

        Me.DataSetForm.Tables("TBSearchResult").Merge(Tb)

        If Tb.Rows.Count = 0 Then
            MsgBoxGeneral("No Any Containers !", "Search Result")
            FrmStatus = FormStatus.NoAction
        Else
            FrmStatus = FormStatus.HasData
        End If

        General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)

        Me.EcsTab.Tabs(0).Selected = True

    End Sub

    Private Sub GeneralForms_CustomHistory() Handles GeneralForms.CustomHistory

        Dim Frm As FrmLogViewByID
        Dim aTable As New ArrayList

        If Me.CntrNo.TextValue = "" Then
            Exit Sub
        End If

        If Me.FrmStatus = FormStatus.NewRecord Then
            Exit Sub
        End If

        aTable.Add("TB_EcsMoves")
        aTable.Add("TB_Damage")

        Frm = New FrmLogViewByID(Me.CntrNo.TextValue, EcsID, "TB_EcsContainers", aTable, "CntrID")
        Frm.ShowDialog()


    End Sub

    Private Sub GeneralForms_CustomHomeClick() Handles GeneralForms.CustomHomeClick
        Me.Close()
    End Sub

    Private Sub FrmEcs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim Col As Infragistics.Win.UltraWinGrid.UltraGridColumn

        Me.Top = 0
        Me.Left = 0

        Me.SrchCntrNo.SetLength(11)
        Me.GeneralForms.InitControl("E.C.S. Data", ItemLevel)
        Me.CntrNo.SetLength(11)
        Me.CnType.InitControl("CT", UserComboCode.ShowCoumn.StdCode)
        Me.CnSize.InitControl("CS", UserComboCode.ShowCoumn.StdCode)
        Me.InVessel.InitControl(Me.GroupBoxMain.Appearance.BackColor)
        Me.InVoyage.InitControl(Me.GroupBoxMain.Appearance.BackColor, Me.InVessel)
        Me.DischargeTo.InitControl(Me.GroupBoxMain.Appearance.BackColor)
        Me.InStatus.InitControl("FE", UserComboCode.ShowCoumn.Meaning)
        Me.OutVessel.InitControl(Me.GroupBoxMain.Appearance.BackColor)
        Me.OutVoyage.InitControl(Me.GroupBoxMain.Appearance.BackColor, Me.OutVessel)
        Me.OutStatus.InitControl("FE", UserComboCode.ShowCoumn.Meaning)
        Me.InCellNo.InitControl(6, 0)
        Me.OutCellNo.InitControl(6, 0)
        Me.ReturnTo.InitControl(Me.GroupBoxMain.Appearance.BackColor)
        Me.Destination.InitControl(Me.GroupBoxMain.Appearance.BackColor)

        Me.BookingID.InitControl()
        With Me.GridResult
            .DisplayLayout.Bands(0).Columns("ID").Hidden = True
        End With

        ReportDate.InitControl(False, False)
        Me.Description.SetLength(100)
        Me.RepairShop.SetLength(100)
        Me.StartRepair.InitControl(False, False)
        Me.FinishedRepair.InitControl(False, False)
        Me.RepairCost.InitControl(12, 2)
        Me.Currency.InitControl("CU", UserComboCode.ShowCoumn.StdCode)
        Me.RepairCost2.InitControl(12, 2)
        Me.Currency2.InitControl("CU", UserComboCode.ShowCoumn.StdCode)
        Me.InvoiceTo.InitControl(Me.DamageGroupBox.BackColor)
        Me.InvoiceAmount.InitControl(12, 2)
        Me.InvCurrency.InitControl("CU", UserComboCode.ShowCoumn.StdCode)
        Me.InvoiceAmount2.InitControl(12, 2)
        Me.InvCurrency2.InitControl("CU", UserComboCode.ShowCoumn.StdCode)
        Me.SOC.InitControl("YN", UserComboCode.ShowCoumn.Meaning)
        Me.SpecialOperation.InitControl("MO", UserComboCode.ShowCoumn.Meaning)

        With Me.DropDownStatus
            .DataSource = GetCodeList("ES")
            .DisplayMember = "StdCode"
            .ValueMember = "StdCode"
            For Each Col In .DisplayLayout.Bands(0).Columns
                Col.Hidden = True
            Next
            .DisplayLayout.Bands(0).Columns("StdCode").Hidden = False
        End With

        With Me.DropDownDepot
            .DataSource = GetCodeList("DP")
            .DisplayMember = "Meaning"
            .ValueMember = "StdCode"

            For Each Col In .DisplayLayout.Bands(0).Columns
                Col.Hidden = True
            Next
            .DisplayLayout.Bands(0).Columns("Meaning").Hidden = False
        End With

        FrmStatus = FormStatus.NoAction
        General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)

        Me.ThumbnailControlAfter.InitControl("Aftre Repair Images")
        Me.ThumbnailControlBefore.InitControl("Before Repair Images")

        LockStatus(False)
        Me.GeneralForms.ShowHistoryButtom = True
        Me.GeneralForms.AddCustomTools("Booking Search", "BookingSearch", My.Resources.search_24)
        Me.BookingSearch.InitControl(Me.BookingID)



    End Sub

    Private Sub SetDocument()

        Dim Dr As DataRow
        Dim nI As Byte

        Dim dtfi As System.Globalization.DateTimeFormatInfo
        Dim sMask As String

        dtfi = New System.Globalization.DateTimeFormatInfo()


        EcsID = Me.GridResult.ActiveRow.Cells("ID").Value
        Dim aTables() As String = {"TB_EcsContainers", "TB_EcsMoves", "TB_Damage"}
        dm = New DataManager(My.Settings.DSN)
        Dim ds As DataSet = StoredProcedures.SP_EcsAllDataByID(EcsID.ToString)
        dm.PopulateObjectsFromDataSet(ds, aTables)

        For nI = 0 To aTables.Length - 1
            dm.DataSet.Tables(aTables(nI)).Merge(ds.Tables(nI))
        Next

        Me.DataSetForm.Tables("TB_EcsMoves").Clear()
        Me.DataSetForm.Tables("TB_EcsMoves").Merge(dm.DataSet.Tables("TB_EcsMoves"))

        Dr = dm.DataSet.Tables("TB_EcsContainers").Rows(0)

        Me.CntrNo.TextValue = Dr("CntrNo")
        Me.CnSize.Code = IIf(IsDBNull(Dr("CnSize")), "", Dr("CnSize"))
        Me.CnType.Code = IIf(IsDBNull(Dr("CnType")), "", Dr("CnType"))
        Me.InVoyage.VoyageID = (IIf(IsDBNull(Dr("InVoyageID")), Guid.Empty, Dr("InVoyageID")))
        Me.DischargeTo.PortCode = IIf(IsDBNull(Dr("DischargeTo")), "", Dr("DischargeTo"))
        Me.InStatus.Code = IIf(IsDBNull(Dr("InStatus")), "", Dr("InStatus"))
        Me.OutVoyage.VoyageID = IIf(IsDBNull(Dr("OutVoyageID")), Guid.Empty, Dr("OutVoyageID"))
        Me.OutStatus.Code = IIf(IsDBNull(Dr("OutStatus")), "", Dr("OutStatus"))
        Me.ReturnTo.PortCode = IIf(IsDBNull(Dr("ReturnTo")), "", Dr("ReturnTo"))
        Me.Destination.PortCode = IIf(IsDBNull(Dr("Destination")), "", Dr("Destination"))
        Me.InCellNo.GnrlNum.Value = IIf(IsDBNull(Dr("InCellNo")), 0, Dr("InCellNo"))
        Me.OutCellNo.GnrlNum.Value = IIf(IsDBNull(Dr("OutCellNo")), 0, Dr("OutCellNo"))
        Me.BookingID.BookingID = IIf(IsDBNull(Dr("BookingID")), Guid.Empty, Dr("BookingID"))

        Me.SOC.Code = IIf(IsDBNull(Dr("SOC")), "N", Dr("SOC"))
        Me.SpecialOperation.Code = IIf(IsDBNull(Dr("SpecialOpr")), "", Dr("SpecialOpr"))

        Me.GridMoves.DisplayLayout.Bands(0).Columns("StatusDate").SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Ascending

        If dm.DataSet.Tables("TB_Damage").Rows.Count > 0 Then
            Dr = dm.DataSet.Tables("TB_Damage").Rows(0)
            Me.IsDamaged.Checked = True
            Me.ReportDate.DateValue = IIf(IsDBNull(Dr("ReportDate")), "", Dr("ReportDate"))
            Me.Description.TextValue = IIf(IsDBNull(Dr("Description")), "", Dr("Description"))
            Me.RepairShop.TextValue = IIf(IsDBNull(Dr("RepairShop")), "", Dr("RepairShop"))
            Me.StartRepair.DateValue = IIf(IsDBNull(Dr("StartRepair")), "", Dr("StartRepair"))
            Me.FinishedRepair.DateValue = IIf(IsDBNull(Dr("FinishedRepair")), 0, Dr("FinishedRepair"))
            Me.RepairCost.GnrlNum.Value = IIf(IsDBNull(Dr("RepairCost")), 0, Dr("RepairCost"))
            Me.Currency.Code = IIf(IsDBNull(Dr("Currency")), "", Dr("Currency"))
            Me.InvoiceTo.ClientID = IIf(IsDBNull(Dr("InvoiceTo")), "", Dr("InvoiceTo"))
            Me.InvoiceAmount.GnrlNum.Value = IIf(IsDBNull(Dr("InvoiceAmount")), 0, Dr("InvoiceAmount"))
            Me.InvCurrency.Code = IIf(IsDBNull(Dr("InvCurrency")), "", Dr("InvCurrency"))
            Me.RepairCost2.GnrlNum.Value = IIf(IsDBNull(Dr("RepairCost2")), 0, Dr("RepairCost2"))
            Me.Currency2.Code = IIf(IsDBNull(Dr("Currency2")), "", Dr("Currency2"))
            Me.InvoiceAmount2.GnrlNum.Value = IIf(IsDBNull(Dr("InvoiceAmount2")), 0, Dr("InvoiceAmount2"))
            Me.InvCurrency2.Code = IIf(IsDBNull(Dr("InvCurrency2")), "", Dr("InvCurrency2"))
        Else
            ClearContainer(DamageGroupBox)
            Me.IsDamaged.Checked = False
        End If

        FrmStatus = FormStatus.HasData
        General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)

        ds = StoredProcedures.SP_BlsByVoyCntr(Me.InVoyage.VoyageID.ToString, Me.CntrNo.TextValue)

        If Not ds Is Nothing Then
            Me.GridBls.DataSource = ds.Tables(0)
            Me.GridBls.DisplayLayout.Bands(0).Columns("ID").Hidden = True
            Me.GridBls.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn
            Me.GridBls.DisplayLayout.Bands(0).Header.Caption = "List Of B/L(s)"
        End If

        With Me.GridMoves
            .DisplayLayout.Bands(0).Columns("ID").Hidden = True
            .DisplayLayout.Bands(0).Columns("CntrID").Hidden = True
            .DisplayLayout.Bands(0).Columns("StatusDate").MaskInput = "{date} {time}"
            .DisplayLayout.Bands(0).Columns("StatusDateToLine").MaskInput = "{date} {time}" ' "{LOC}" & dtfi.CurrentInfo.ShortDatePattern.ToLower & " hh:mm"

            With .DisplayLayout.Bands(0)

                .Columns("Status").Style _
                                           = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate
                .Columns("Status").ValueList = Me.DropDownStatus


                .Columns("depot").Style _
                                           = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate
                .Columns("Depot").ValueList = Me.DropDownDepot

            End With

        End With

        dm.QueryCriteria.Clear()
        dm.QueryCriteria.And(JoinPath.TB_PermitDetails.Columns.CntrID, Dr("ID"), MatchType.Exact)

        If Not dm.GetTB_PermitDetails Is Nothing Then
            For Each nDr As DataRow In dm.DataSet.Tables("TB_PermitDetails").Rows
                dm.QueryCriteria.Clear()
                dm.QueryCriteria.And(JoinPath.TB_Permits.Columns.ID, nDr("PermitID"), MatchType.Exact)
                dm.GetTB_Permits()
            Next
        End If

        Me.GridPermits.DataSource = dm.DataSet.Tables("TB_Permits")

        For Each col As UltraGridColumn In GridPermits.DisplayLayout.Bands(0).Columns
            col.Hidden = True
        Next
        GridPermits.DisplayLayout.Bands(0).Columns("PermitNo").Hidden = False
        GridNumSeperator(Me.GridPermits)

        ' ThumbnailControlBefore_CustomRefresh()


    End Sub

    Private Function ValidateData() As Boolean

        Dim Ans As Boolean = True
        Dim DV As DataView
        Dim DRV As DataRowView
        Dim PrivStatus As String = ""
        Dim DvMove As DataView
        Dim aList As New ArrayList
        Dim GR As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim aError As New ArrayList
        Dim nI As Long

        FormErrorProvider.Clear()
        Me.GridMoves.UpdateData()
        For Each GR In Me.GridMoves.Rows
            GR.Appearance.BackColor = Color.White
            GR.Appearance.ForeColor = Color.Black
        Next

        If Me.CntrNo.TextValue = "" Then
            aError.Add(Me.CntrNo)
        End If

        If Me.CnType.Code = "" Then
            aError.Add(Me.CnType)
        End If

        If Me.CnSize.Code = "" Then
            aError.Add(Me.CnSize)
        End If

        If Me.InStatus.Code = "" Then
            aError.Add(Me.InStatus)
        End If

        If Me.DischargeTo.PortCode = "" Then
            aError.Add(Me.DischargeTo)
        End If

        If Me.InVoyage.VoyageID.ToString = "" Or Me.InVoyage.VoyageID = Guid.Empty Then
            aError.Add(Me.InVoyage)
        End If

        If aError.Count > 0 Then

            If aError.Count > 0 Then
                For nI = 0 To aError.Count - 1
                    FormErrorProvider.SetError(aError(nI), "Data Requird")
                Next
                MsgBoxValidateFaild()
                Return False
            End If
        Else
            If MoveCode Is Nothing Then
                MoveCode = GetCodeList("ES")
            End If
        End If

        DV = New DataView(Me.DataSetForm.Tables("TB_EcsMoves"), "", "StatusDate", DataViewRowState.CurrentRows)
        For Each DRV In DV
            If PrivStatus <> "" Then
                DvMove = New DataView(MoveCode, "StdCode = '" & PrivStatus & "'", "", DataViewRowState.CurrentRows)
                If DvMove.Count > 0 Then
                    If InStr(1, DvMove.Item(0).Item("NextCode").ToString, DRV("Status").ToString) = 0 Then
                        aList.Add(DRV("ID"))
                    End If
                End If
            End If
            PrivStatus = DRV.Item("Status")
        Next

        For Each DRV In DV
            If IIf(IsDBNull(DRV.Item("Depot")), "", DRV.Item("Depot")) = "" Then
                If aList.IndexOf(DRV.Item("ID")) <> -1 Then
                    aList.Add(DRV("ID"))
                End If
            End If
        Next

        If aList.Count > 0 Then
            Ans = False
            For Each GR In Me.GridMoves.Rows
                If aList.IndexOf(GR.Cells("ID").Value) <> -1 Then
                    GR.Appearance.BackColor = Color.Red
                    GR.Appearance.ForeColor = Color.Yellow
                Else
                    GR.Appearance.BackColor = Color.White
                    GR.Appearance.ForeColor = Color.Black
                    'GR.Cells("Status").
                End If
            Next
            MsgBoxGeneral("Please Check Moves !", "Validate Failed")
        End If

        Return Ans

    End Function

    Private Sub GeneralForms_CustomOthers() Handles GeneralForms.CustomOthers

        Me.PopupControl.Show()
    End Sub

    Private Sub GeneralForms_CustomSaveClick() Handles GeneralForms.CustomSaveClick
        If ValidateData() = True Then
            If MsgBoxUpdate() = Windows.Forms.DialogResult.Yes Then
                SaveDocument()
            End If
        End If
    End Sub

    Private Sub GridMoves_AfterCellUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles GridMoves.AfterCellUpdate

        Try
            If Me.GridMoves.ActiveCell.Column.Key = "StatusDate" Then
                If Me.GridMoves.ActiveRow.Cells("StatusDateToLine").Text = "" Then
                    Me.GridMoves.ActiveRow.Cells("StatusDateToLine").Value = Me.GridMoves.ActiveRow.Cells("StatusDate").Value
                End If
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub GridMoves_BeforeRowUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CancelableRowEventArgs) Handles GridMoves.BeforeRowUpdate
        With Me.GridMoves.ActiveRow
            If .Cells("ID").Text = "" Then
                .Cells("ID").Value = Guid.NewGuid
                .Cells("CntrID").Value = EcsID
            End If
        End With
    End Sub
    Private Sub SaveDocument()

        Dim ChgsDs As DataSet = DataSetForm.GetChanges
        Dim Dr As DataRow = dm.DataSet.Tables("TB_EcsContainers").Rows(0)
        Dim MoveDr As DataRow
        Dim Tb As New DataTable
        Dim Dv As DataView
        Dim cLen As Long
        Dim DC As DataColumn
        Dim Dummy As DataRow
        Dim LogDataSet As New DataSet

        Try
            'appu
            If Me.InvCurrency.Code = Me.InvCurrency2.Code And Not Me.InvCurrency2.Code = "" Then
                MessageBox.Show("Invoice Currencies are Same", "Update Record", _
     MessageBoxButtons.OK, _
     MessageBoxIcon.Exclamation, _
     MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If Me.Currency.Code = Me.Currency2.Code And Not Me.Currency2.Code = "" Then
                MessageBox.Show("Repair Currencies are Same", "Update Record", _
                 MessageBoxButtons.OK, _
                 MessageBoxIcon.Exclamation, _
                 MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If Me.RepairCost2.GnrlNum.Value > 0 And Me.Currency2.Code = "" Then
                MessageBox.Show("Choose Repair Cost II Currency", "Update Record", _
                 MessageBoxButtons.OK, _
                 MessageBoxIcon.Exclamation, _
                 MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If Me.InvoiceAmount2.GnrlNum.Value > 0 And Me.InvCurrency2.Code = "" Then
                MessageBox.Show("Choose Inv.Amount II Currency", "Update Record", _
                 MessageBoxButtons.OK, _
                 MessageBoxIcon.Exclamation, _
                 MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If Me.RepairCost2.GnrlNum.Value = 0 And Not Me.Currency2.Code = "" Then
                MessageBox.Show("Choose Repair Cost II", "Update Record", _
                 MessageBoxButtons.OK, _
                 MessageBoxIcon.Exclamation, _
                 MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If Me.InvoiceAmount2.GnrlNum.Value = 0 And Not Me.InvCurrency2.Code = "" Then
                MessageBox.Show("Choose Inv.Amount II", "Update Record", _
                 MessageBoxButtons.OK, _
                 MessageBoxIcon.Exclamation, _
                 MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            Dv = New DataView(DataSetForm.Tables("TB_EcsMoves"), "", "StatusDate Desc", DataViewRowState.CurrentRows)

            Dr("CntrNo") = Me.CntrNo.TextValue
            Dr("CnSize") = Me.CnSize.Code
            Dr("CnType") = Me.CnType.Code
            Dr("InVoyageID") = Me.InVoyage.VoyageID
            Dr("DischargeTo") = Me.DischargeTo.PortCode
            Dr("InStatus") = Me.InStatus.Code
            Dr("OutVoyageID") = IIf(Me.OutVoyage.VoyageID = Guid.Empty, DBNull.Value, Me.OutVoyage.VoyageID)
            Dr("ReturnTo") = IIf(Me.ReturnTo.PortCode = "", DBNull.Value, Me.ReturnTo.PortCode)
            Dr("Destination") = IIf(Me.Destination.PortCode = "", DBNull.Value, Me.Destination.PortCode)
            Dr("InCellNo") = Me.InCellNo.GnrlNum.Value
            Dr("OutCellNo") = Me.OutCellNo.GnrlNum.Value
            Dr("OutStatus") = Me.OutStatus.Code
            Dr("LastDepot") = Dv.Item(0).Item("Depot")
            Dr("LastStatus") = Dv.Item(0).Item("Status")
            Dr("LastStatusDate") = Dv.Item(0).Item("StatusDate")
            Dr("BookingID") = IIf(Me.BookingID.BookingID = Guid.Empty, DBNull.Value, Me.BookingID.BookingID)

            Dr("SOC") = Me.SOC.Code
            Dr("SpecialOpr") = Me.SpecialOperation.Code

            If Not ChgsDs Is Nothing Then
                Tb = ChgsDs.Tables("TB_EcsMoves")
                For Each MoveDr In Tb.Rows
                    Select Case MoveDr.RowState
                        Case DataRowState.Added
                            dm.DataSet.Tables("TB_EcsMoves").ImportRow(MoveDr)
                        Case DataRowState.Deleted

                            Dv = New DataView(dm.DataSet.Tables("TB_EcsMoves"), "ID = '" & MoveDr(0, DataRowVersion.Original).ToString & "'", "", DataViewRowState.CurrentRows)
                            If Dv.Count > 0 Then
                                Dv.Item(0).Delete()
                            End If

                        Case DataRowState.Modified
                            Dv = New DataView(dm.DataSet.Tables("TB_EcsMoves"), "ID = '" & MoveDr.Item("ID").ToString & "'", "", DataViewRowState.CurrentRows)
                            If Dv.Count > 0 Then
                                Dummy = DirectCast(Dv.Item(0).Row, DataRow)
                                cLen = Dr.ItemArray.Length
                                For Each DC In Tb.Columns
                                    Dummy(DC.ColumnName) = MoveDr.Item(DC.ColumnName)
                                Next
                            End If
                    End Select
                Next
            End If

            If Me.IsDamaged.Checked = False Then
                If dm.DataSet.Tables("TB_Damage").Rows.Count > 0 Then
                    dm.DataSet.Tables("TB_Damage").Rows(0).Delete()
                End If
            Else

                If dm.DataSet.Tables("TB_Damage").Rows.Count = 0 Then
                    Dr = dm.DataSet.Tables("TB_Damage").NewRow
                    Dr("ID") = System.Guid.NewGuid
                    Dr("CntrID") = EcsID
                Else
                    Dr = dm.DataSet.Tables("TB_Damage").Rows(0)
                End If

                Dr("ReportDate") = Me.ReportDate.DateValue

                If Not IsNothing(Me.Description.TextValue) Then
                    Dr("Description") = Me.Description.TextValue
                End If

                If Not IsNothing(Me.RepairShop.TextValue) Then
                    Dr("RepairShop") = Me.RepairShop.TextValue
                End If

                If Not IsNothing(Me.StartRepair.DateValue) Then
                    Dr("StartRepair") = Me.StartRepair.DateValue
                End If

                If Not IsNothing(Me.FinishedRepair.DateValue) Then
                    Dr("FinishedRepair") = Me.FinishedRepair.DateValue
                End If

                If Not IsNothing(Me.RepairCost.GnrlNum.Value) Then
                    Dr("RepairCost") = Me.RepairCost.GnrlNum.Value
                End If

                If Not IsNothing(Me.Currency.Code) Then
                    Dr("Currency") = Me.Currency.Code
                End If
                'appu
                If Not IsNothing(Me.RepairCost2.GnrlNum.Value) Then
                    Dr("RepairCost2") = Me.RepairCost2.GnrlNum.Value
                End If

                If Not IsNothing(Me.Currency2.Code) Then
                    Dr("Currency2") = Me.Currency2.Code
                End If

                If Not IsNothing(Me.InvoiceTo.ClientID) Then
                    Dr("InvoiceTo") = Me.InvoiceTo.ClientID
                End If

                If Not IsNothing(Me.InvoiceAmount.GnrlNum.Value) Then
                    Dr("InvoiceAmount") = Me.InvoiceAmount.GnrlNum.Value
                End If

                If Not IsNothing(Me.InvCurrency.Code) Then
                    Dr("InvCurrency") = Me.InvCurrency.Code
                End If
                'appu
                If Not IsNothing(Me.InvoiceAmount2.GnrlNum.Value) Then
                    Dr("InvoiceAmount2") = Me.InvoiceAmount2.GnrlNum.Value
                End If

                If Not IsNothing(Me.InvCurrency2.Code) Then
                    Dr("InvCurrency2") = Me.InvCurrency2.Code
                End If

                If dm.DataSet.Tables("TB_Damage").Rows.Count = 0 Then
                    dm.DataSet.Tables("TB_Damage").Rows.Add(Dr)
                End If

            End If
            LogDataSet = dm.DataSet.Copy
            dm.CommitAll()
            GenerateLog(LogDataSet)
            MsgBoxSaveSuccessful()
            Me.DataSetForm.AcceptChanges()
        Catch ex As Exception
            MsgBoxSaveFailed()
        End Try

    End Sub


    Private Sub GridResult_AfterRowActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridResult.AfterRowActivate
        SetDocument()
    End Sub
    'Private Sub GridMoves_AfterRowActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridMoves.AfterRowActivate
    '    If (CurrentUser.IsAccountAdmin = False) Then
    '        If ValidateData() = True Then
    '            If Me.GridMoves.ActiveRow.Cells("Status").Text <> "" Then
    '                Me.GridMoves.ActiveRow.Cells("Status").Activation = Activation.Disabled
    '            End If
    '        End If
    '    End If
    'End Sub

    Private Sub LockStatus(ByVal Status As Boolean)
        General.LockControls(Me, Status)
        Me.SrchCntrNo.GeneralTxt.Enabled = True
        Me.GridResult.Enabled = True
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub GridMoves_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles GridMoves.InitializeLayout


        Try


        Catch ex As Exception

        End Try


    End Sub

    Private Sub ButtonShowBeforRepair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim CFTP As New FTP
        Dim aList As New ArrayList
        Dim Img As Image
        Dim ImgList As New ImageList
        Dim Ms As MemoryStream
        Dim aByte() As Byte
        Dim Obj As Object
        Dim aImages As New ArrayList
        Dim aFiles As New ArrayList
        Dim Path As String

        Me.ThumbnailControlAfter.RemoveImages()
        Me.ThumbnailControlBefore.RemoveImages()

        Path = "containers\" & EcsID.ToString & "\before"
        CFTP.DownloadAllFileToAlist(Path, aList, aFiles)

        For Each Obj In aList
            aByte = DirectCast(Obj, Array)
            Ms = New MemoryStream(aByte, 0, aByte.Length)
            Ms.Write(aByte, 0, aByte.Length)
            Img = Image.FromStream(Ms)
            aImages.Add(Img)
        Next
        Me.ThumbnailControlBefore.GenerateThumbsFromArryList(Path, aImages, aFiles)

        aImages = New ArrayList
        aList = New ArrayList
        Path = "containers\" & EcsID.ToString & "\After"
        CFTP.DownloadAllFileToAlist(Path, aList, aFiles)

        For Each Obj In aList
            aByte = DirectCast(Obj, Array)
            Ms = New MemoryStream(aByte, 0, aByte.Length)
            Ms.Write(aByte, 0, aByte.Length)
            Img = Image.FromStream(Ms)
            aImages.Add(Img)
        Next
        Me.ThumbnailControlAfter.GenerateThumbsFromArryList(Path, aImages, aFiles)


    End Sub

    Private Sub ButtonUploadBeforeImages_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim dialog As New OpenFileDialog
        Dim cFTP As FTP
        dialog.Filter = "JPG Files (*.jpg)|*.jpg|jpg files (*.jpg)|*.jpg|All files (*.*)|*.*"
        dialog.ShowDialog()
        If dialog.FileName <> "" Then
            cFTP = New FTP
            cFTP.UploadFile(EcsID.ToString & "\before", dialog.FileName)
        End If
    End Sub



    Private Sub Thumbnail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ThumbnailControlBefore_CustomRefresh() Handles ThumbnailControlBefore.CustomRefresh

        Dim CFTP As New FTP
        Dim aList As New ArrayList
        Dim Img As Image
        Dim ImgList As New ImageList
        Dim Ms As MemoryStream
        Dim aByte() As Byte
        Dim Obj As Object
        Dim aImages As New ArrayList
        Dim aFiles As New ArrayList
        Dim Path As String

        Me.ThumbnailControlBefore.RemoveImages()

        Path = "containers\" & EcsID.ToString & "\before"
        CFTP.DownloadAllFileToAlist(Path, aList, aFiles)

        For Each Obj In aList
            aByte = DirectCast(Obj, Array)
            Ms = New MemoryStream(aByte, 0, aByte.Length)
            Ms.Write(aByte, 0, aByte.Length)
            Img = Image.FromStream(Ms)
            aImages.Add(Img)
        Next
        Me.ThumbnailControlBefore.GenerateThumbsFromArryList(Path, aImages, aFiles)

    End Sub

    Private Sub ThumbnailControlAfter_CustomRefresh() Handles ThumbnailControlAfter.CustomRefresh

        Dim CFTP As New FTP
        Dim aList As New ArrayList
        Dim Img As Image
        Dim ImgList As New ImageList
        Dim Ms As MemoryStream
        Dim aByte() As Byte
        Dim Obj As Object
        Dim aImages As New ArrayList
        Dim aFiles As New ArrayList
        Dim Path As String

        Me.ThumbnailControlAfter.RemoveImages()

        aImages = New ArrayList
        aList = New ArrayList
        Path = "containers\" & EcsID.ToString & "\After"
        CFTP.DownloadAllFileToAlist(Path, aList, aFiles)

        For Each Obj In aList
            aByte = DirectCast(Obj, Array)
            Ms = New MemoryStream(aByte, 0, aByte.Length)
            Ms.Write(aByte, 0, aByte.Length)
            Img = Image.FromStream(Ms)
            aImages.Add(Img)
        Next
        Me.ThumbnailControlAfter.GenerateThumbsFromArryList(Path, aImages, aFiles)

    End Sub


End Class