Imports OrmLib
Imports ShippingBiz

Public Class FrmBLCharges

    Implements IFGeneral
    Private ItemLevel As String = "406"
    Private FrmStatus As FormStatus
    Private dm As DataManager
    Private MasterID As Guid

    Private Sub LockStatus(ByVal Status As Boolean) Implements IFGeneral.LockStatus
        General.LockControls(Me, Status)
        Me.SearchChgCode.Enabled = True
    End Sub

    Private Sub Populate() Implements IFGeneral.Populate

        Dim Dv As DataView
        Dim ds As New DataSet


        MasterID = GridCharges.DisplayLayout.ActiveRow.Cells("ID").Value
        Dv = New DataView(dm.DataSet.Tables("TB_ChgLevelMaster"), "ID = '" & MasterID.ToString & "'", "", DataViewRowState.CurrentRows)

        If Dv.Count > 0 Then
            With Dv.Item(0)
                Me.ChargeItem.Code = .Item("ChargeItem")
                Me.Validity.Value = IIf(IsDBNull(.Item("Validity")), DBNull.Value, .Item("Validity"))
                Me.ApplyDate.Value = IIf(IsDBNull(.Item("ApplyDate")), DBNull.Value, .Item("ApplyDate"))
                Me.IsDeposit.Checked = IIf(IsDBNull(.Item("IsDeposit")), False, .Item("IsDeposit"))
                Me.BaseOn.Code = IIf(IsDBNull(.Item("BaseOn")), "", .Item("BaseOn"))
                Me.CurCode.Code = IIf(IsDBNull(.Item("CurCode")), "", .Item("CurCode"))
                Me.DefaultAmount.GnrlNum.Value = IIf(IsDBNull(.Item("DefaultAmount")), 0, .Item("DefaultAmount"))
                Me.DividInLCL.Checked = IIf(IsDBNull(.Item("DividInLCL")), False, .Item("DividInLCL"))
                Me.Description.TextValue = IIf(IsDBNull(.Item("Description")), "", .Item("Description"))
                Me.Condition.Code = IIf(IsDBNull(.Item("Condition")), "", .Item("Condition"))
                Me.Seq.GnrlNum.Value = IIf(IsDBNull(.Item("seq")), 0, .Item("seq"))
                Me.ImportExport.Code = IIf(IsDBNull(.Item("ImportExport")), "", .Item("ImportExport"))
                Me.Tax.GnrlNum.Value = IIf(IsDBNull(.Item("Tax")), 0, .Item("Tax"))
                Me.Toll.GnrlNum.Value = IIf(IsDBNull(.Item("Toll")), 0, .Item("Toll"))
                Me.Line.SelectedValue = IIf(IsDBNull(.Item("Line")), "***", .Item("Line"))
                If NullToValue(.Item("Port"), "***") <> "***" Then
                    Me.Port.PortCode = IIf(IsDBNull(.Item("Port")), "***", .Item("Port"))
                Else
                    Port.PortCode = ""
                End If

                Me.ClientID.ClientID = IIf(IsDBNull(.Item("ClientID")), Guid.Empty, .Item("ClientID"))
            End With
        End If

        dm.QueryCriteria.Clear()
        dm.QueryCriteria.And(JoinPath.TB_ChgLevelDetails.Columns.MasterID, MasterID, MatchType.Exact)
        dm.GetTB_ChgLevelDetailsCollection()

        Me.DataSetForm.Tables("Tb_ChgLevelDetails").Clear()
        Me.DataSetForm.Tables("Tb_ChgLevelDetails").Merge(dm.DataSet.Tables("Tb_ChgLevelDetails"))

        FrmStatus = FormStatus.EditRecord
        General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)

    End Sub

    Private Sub SendDataToClass() Implements IFGeneral.SendDataToClass

        Dim Dr As DataRow
        Dim Drs() As DataRow
        Dim nDr As DataRow

        Dim TbChgs As DataTable
        Dim dv As DataView

        If FrmStatus = FormStatus.NewRecord Then
            Dr = dm.DataSet.Tables("Tb_ChgLevelMaster").NewRow
            Dr("ID") = MasterID
        Else
            Drs = dm.DataSet.Tables("Tb_ChgLevelMaster").Select("ID = '" & MasterID.ToString & "'")
            Dr = Drs(0)
        End If

        Dr("ChargeItem") = Me.ChargeItem.Code
        Dr("Validity") = Me.Validity.Value
        Dr("ApplyDate") = Me.ApplyDate.Value
        Dr("IsDeposit") = Me.IsDeposit.Checked
        Dr("BaseOn") = Me.BaseOn.Code
        Dr("CurCode") = Me.CurCode.Code
        Dr("DefaultAmount") = Me.DefaultAmount.GnrlNum.Value
        Dr("DividInLCL") = Me.DividInLCL.Checked
        Dr("Description") = Me.Description.TextValue
        Dr("Condition") = Me.Condition.Code
        Dr("Seq") = Me.Seq.GnrlNum.Value
        Dr("ImportExport") = Me.ImportExport.Code
        Dr("Tax") = Me.Tax.GnrlNum.Value
        Dr("Toll") = Me.Toll.GnrlNum.Value
        Dr("Line") = Me.Line.SelectedValue
        If Me.Port.TextPort.TextValue = "" Or Me.Port.PortCode = "" Then
            Dr("Port") = "***"
        Else
            Dr("Port") = Me.Port.PortCode
        End If

        If Me.ClientID.ClientName = "" Or Me.ClientID.ClientID = Guid.Empty Then
            Dr("ClientID") = DBNull.Value
        Else
            Dr("ClientID") = Me.ClientID.ClientID
        End If

        If FrmStatus = FormStatus.NewRecord Then
            dm.DataSet.Tables("Tb_ChgLevelMaster").Rows.Add(Dr)
        End If

        TbChgs = Me.DataSetForm.Tables("Tb_ChgLevelDetails").GetChanges

        If Not TbChgs Is Nothing Then
            For Each Dr In TbChgs.Rows
                Select Case Dr.RowState
                    Case DataRowState.Added
                        nDr = dm.DataSet.Tables("Tb_ChgLevelDetails").NewRow
                        nDr("ID") = Guid.NewGuid
                        nDr("MasterID") = MasterID
                        nDr("CnType") = Dr("CnType")
                        nDr("SOC") = Dr("SOC")
                        nDr("ShipmentType") = Dr("ShipmentType")
                        nDr("Imco") = Dr("Imco")
                        nDr("IsFull") = Dr("IsFull")
                        nDr("Amount20") = Dr("Amount20")
                        nDr("Amount40") = Dr("Amount40")
                        nDr("Amount45") = Dr("Amount45")
                        dm.DataSet.Tables("Tb_ChgLevelDetails").Rows.Add(nDr)
                    Case DataRowState.Deleted
                        dv = New DataView(dm.DataSet.Tables("Tb_ChgLevelDetails"), "Id = '" & Dr("ID", DataRowVersion.Original).ToString & "'", "", DataViewRowState.CurrentRows)
                        If dv.Count > 0 Then
                            dv.Item(0).Delete()
                        End If
                    Case DataRowState.Modified
                        dv = New DataView(dm.DataSet.Tables("Tb_ChgLevelDetails"), "Id = '" & Dr("ID", DataRowVersion.Original).ToString & "'", "", DataViewRowState.CurrentRows)
                        If dv.Count > 0 Then
                            With dv.Item(0)
                                .Item("CnType") = Dr("CnType")
                                .Item("SOC") = Dr("SOC")
                                .Item("ShipmentType") = Dr("ShipmentType")
                                .Item("Imco") = Dr("Imco")
                                .Item("IsFull") = Dr("IsFull")
                                .Item("Amount20") = Dr("Amount20")
                                .Item("Amount40") = Dr("Amount40")
                                .Item("Amount45") = Dr("Amount45")
                            End With
                        End If
                End Select
            Next
        End If


    End Sub

    Private Sub FrmBLCharges_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        Dim ArCode As New ArrayList
        Dim ArMean As New ArrayList
        Dim Col As Infragistics.Win.UltraWinGrid.UltraGridColumn
        Dim TB As New DataTable
        Dim Dr As DataRow
        Dim Sql As String


        Dim lResult As Boolean
        Me.Top = 0
        Me.Left = 0

        dm = New DataManager(My.Settings.DSN)

        Me.GeneralForms.InitControl("Charges For B/Ls", ItemLevel)
        Me.SearchChgCode.InitControl("CG", UserComboCode.ShowCoumn.Meaning)
        Me.SearchChgCode.BackColor = My.Settings.MainColor

        Me.ChargeItem.InitControl("CG", UserComboCode.ShowCoumn.Meaning)
        Me.CurCode.InitControl("CU", UserComboCode.ShowCoumn.StdCode)
        Me.Condition.InitControl("AG", UserComboCode.ShowCoumn.Meaning)
        Me.Seq.InitControl(2, 0)
        Me.Tax.InitControl(2, 1)
        Me.Toll.InitControl(2, 1)

        ArCode.Add("B")
        ArMean.Add("B/L")

        ArCode.Add("C")
        ArMean.Add("Container")

        ArCode.Add("W")
        ArMean.Add("Weight")

        ArCode.Add("LT")
        ArMean.Add("LCL Containers(Total)")

        ArCode.Add("LW")
        ArMean.Add("LCL Containers(Weight)")

        ArCode.Add("BS")
        ArMean.Add("Split B/L")

        ArCode.Add("BL")
        ArMean.Add("LCL B/L")

        ArCode.Add("BF")
        ArMean.Add("FCL B/L")

        ArCode.Add("CL")
        ArMean.Add("CONTAINER LCL")

        BaseOn.InitControl(ArCode, ArMean, UserComboCode.ShowCoumn.Meaning)


        ArCode = New ArrayList
        ArMean = New ArrayList

        ArCode.Add("I")
        ArMean.Add("Import")

        ArCode.Add("E")
        ArMean.Add("Export")

        ArCode.Add("B")
        ArMean.Add("Both")

        Me.ImportExport.InitControl(ArCode, ArMean, UserComboCode.ShowCoumn.Meaning)


        With Me.GridCharges
            .DisplayLayout.Bands(0).Columns("ID").Hidden = True
            .DisplayLayout.Appearance.BackColor = Color.Aqua
            .DisplayLayout.Appearance.BackColor2 = Color.Black
            .DisplayLayout.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.BackwardDiagonal
        End With

        FrmStatus = FormStatus.NoAction
        General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)
        Me.SearchChgCode.ComboCode.Enabled = True
        ClearControl(Me)

        With Me.DropDownType
            TB = GetCodeList("CT")
            Dr = TB.NewRow
            Dr("ID") = Guid.NewGuid
            Dr("StdCode") = "***"
            Dr("Meaning") = "(ALL)"
            TB.Rows.Add(Dr)
            .DataSource = TB.Copy
            .DisplayMember = "Meaning"
            .ValueMember = "StdCode"
            For Each Col In .DisplayLayout.Bands(0).Columns
                Col.Hidden = True
            Next
            .DisplayLayout.Bands(0).Columns("Meaning").Hidden = False
            .DisplayLayout.Bands(0).SortedColumns.Add("Meaning", False, False)
        End With

        With Me.DropDownSOC
            TB = GetCodeList("YN")
            Dr = TB.NewRow
            Dr("ID") = Guid.NewGuid
            Dr("StdCode") = "***"
            Dr("Meaning") = "(ALL)"
            TB.Rows.Add(Dr)
            .DataSource = TB.Copy
            .DisplayMember = "Meaning"
            .ValueMember = "StdCode"
            For Each Col In .DisplayLayout.Bands(0).Columns
                Col.Hidden = True
            Next
            .DisplayLayout.Bands(0).Columns("Meaning").Hidden = False
            .DisplayLayout.Bands(0).SortedColumns.Add("Meaning", False, False)
        End With

        With Me.DropDownImco
            TB = GetCodeList("YN")
            Dr = TB.NewRow
            Dr("ID") = Guid.NewGuid
            Dr("StdCode") = "***"
            Dr("Meaning") = "(ALL)"
            TB.Rows.Add(Dr)
            .DataSource = TB.Copy
            .DisplayMember = "Meaning"
            .ValueMember = "StdCode"
            For Each Col In .DisplayLayout.Bands(0).Columns
                Col.Hidden = True
            Next
            .DisplayLayout.Bands(0).Columns("Meaning").Hidden = False
            .DisplayLayout.Bands(0).SortedColumns.Add("Meaning", False, False)
        End With

        With Me.DropDownIsFull
            TB = GetCodeList("YN")
            Dr = TB.NewRow
            Dr("ID") = Guid.NewGuid
            Dr("StdCode") = "***"
            Dr("Meaning") = "(ALL)"
            TB.Rows.Add(Dr)
            .DataSource = TB.Copy
            .DisplayMember = "Meaning"
            .ValueMember = "StdCode"
            For Each Col In .DisplayLayout.Bands(0).Columns
                Col.Hidden = True
            Next
            .DisplayLayout.Bands(0).Columns("Meaning").Hidden = False
            .DisplayLayout.Bands(0).SortedColumns.Add("Meaning", False, False)
        End With

        With Me.DropDownShipmentType
            TB = GetCodeList("ST")
            Dr = TB.NewRow
            Dr("ID") = Guid.NewGuid
            Dr("StdCode") = "***"
            Dr("Meaning") = "(ALL)"
            TB.Rows.Add(Dr)
            .DataSource = TB.Copy
            .DisplayMember = "Meaning"
            .ValueMember = "StdCode"
            For Each Col In .DisplayLayout.Bands(0).Columns
                Col.Hidden = True
            Next
            .DisplayLayout.Bands(0).Columns("Meaning").Hidden = False
            .DisplayLayout.Bands(0).SortedColumns.Add("Meaning", False, False)
        End With

        With Me.DropDownCondition
            TB = GetCodeList("AG")
            Dr = TB.NewRow
            .DataSource = TB.Copy
            .DisplayMember = "Meaning"
            .ValueMember = "StdCode"
            For Each Col In .DisplayLayout.Bands(0).Columns
                Col.Hidden = True
            Next
            .DisplayLayout.Bands(0).Columns("Meaning").Hidden = False
            .DisplayLayout.Bands(0).SortedColumns.Add("Meaning", False, False)
        End With

        With Me.GridDetails.DisplayLayout.Bands(0)

            .Columns("ID").Hidden = True
            .Columns("MasterID").Hidden = True

            .Columns("CnType").Style _
                                          = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate
            .Columns("CnType").ValueList = Me.DropDownType

            .Columns("SOC").Style _
                             = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate
            .Columns("SOC").ValueList = Me.DropDownSOC

            .Columns("ShipmentType").Style _
                                   = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate
            .Columns("ShipmentType").ValueList = Me.DropDownShipmentType

            .Columns("Imco").Style _
                                       = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate
            .Columns("Imco").ValueList = Me.DropDownImco

            .Columns("IsFull").Style _
                                                  = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate
            .Columns("IsFull").ValueList = Me.DropDownImco

        End With

        With Me.GridCharges
            .DisplayLayout.Bands(0).Columns("ID").Hidden = True
            .DisplayLayout.Appearance.BackColor = Color.Aqua
            .DisplayLayout.Appearance.BackColor2 = Color.Black
            .DisplayLayout.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.BackwardDiagonal
            .DisplayLayout.Bands(0).Columns("Condition").Style _
                                              = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate
            .DisplayLayout.Bands(0).Columns("Condition").ValueList = Me.DropDownImco
        End With

        Sql = "Select LineCode , LineName From Tb_Lines"
        TableBySql(Sql, TB, lResult)
        Dr = TB.NewRow
        Dr("LineCode") = "***"
        Dr("LineName") = "(All)"
        TB.Rows.Add(Dr)
        With Line
            .DataSource = TB.Copy
            .DisplayMember = "LineName"
            .ValueMember = "LineCode"
            .DropDownStyle = ComboBoxStyle.DropDown

        End With

        LockStatus(False)
        Me.SearchChgCode.Enabled = True
        Me.SearchChgCode.ComboCode.Enabled = True


        Me.TableLayoutPanel1.BackColor = My.Settings.MainColor
        Me.UltraGroupBox1.Appearance.BackColor = My.Settings.MainColor
        ChangeControlColor(UltraGroupBox1, Me.UltraLabel1.GetType.ToString, My.Settings.MainColor, My.Settings.LableForeColor)
        Me.Port.InitControl(Me.UltraGroupBox1.BackColor)
        Me.GeneralForms.AddCustomTools("Copy", "Copy", My.Resources.copy_24)

    End Sub

    Private Function ValidateForm() As Boolean

        Dim aErrorList As New ArrayList
        Dim nI As Long
        Dim Ans As Boolean = True

        FormErrorProvider.Clear()

        If Me.Seq.GnrlNum.Value = 0 Then
            aErrorList.Add(Me.Seq)
        End If

        If Me.ImportExport.Code = "" Then
            aErrorList.Add(Me.ImportExport)
        End If


        If Me.ChargeItem.Code = "" Then
            aErrorList.Add(Me.ChargeItem)
        End If

        If Me.ApplyDate.Value Is Nothing Then
            aErrorList.Add(ApplyDate)
        End If

        If Me.Validity.Value Is Nothing Then
            aErrorList.Add(Me.Validity)
        End If

        If Me.BaseOn.Code = "" Then
            aErrorList.Add(Me.BaseOn)
        End If

        If Me.CurCode.Code = "" Then
            aErrorList.Add(Me.CurCode)
        End If

        If Me.Condition.Code = "" Then
            aErrorList.Add(Me.Condition)
        End If

        If aErrorList.Count > 0 Then
            For nI = 0 To aErrorList.Count - 1
                FormErrorProvider.SetError(aErrorList(nI), "Data Requird")
            Next
            MsgBoxValidateFaild()
            Ans = False
        End If

        Return Ans

    End Function

    Private Sub GridDetails_BeforeRowUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CancelableRowEventArgs) Handles GridDetails.BeforeRowUpdate

        If Me.GridDetails.DisplayLayout.ActiveRow.Cells("ID").Text = "" Then
            Me.GridDetails.DisplayLayout.ActiveRow.Cells("ID").Value = Guid.NewGuid
            Me.GridDetails.DisplayLayout.ActiveRow.Cells("MasterID").Value = MasterID
        End If

    End Sub

    Private Sub UltraGroupBox2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles UltraGroupBox2.Paint

        Dim L As Label
        Me.Label9.Visible = False
        L = Me.Label9
        e.Graphics.DrawString(L.Text, L.Font, New SolidBrush(L.ForeColor), Label9.Left, Label9.Top)

    End Sub
    Private Sub bButtonExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExcel.Click

        Dim Exporter As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter

        Dim SaveDialog As SaveFileDialog

        If GridDetails.Rows.Count = 0 Then
            Exit Sub
        End If
        'Dim S As String
        'For Each col As UltraGridColumn In Grid.DisplayLayout.Bands(0).Columns

        '    S = S & col.Key & vbCrLf
        'Next
        '  Grid.DisplayLayout.Bands(0).Hidden = True
        SaveDialog = New SaveFileDialog
        Exporter = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
        SaveDialog.Filter = "Excel Files (*.xls)|*.xls|All files (*.*)|*.*"
        SaveDialog.ShowDialog()
        If SaveDialog.FileName = "" Then
            Exit Sub
        End If

        Try
            Exporter.Export(GridDetails, SaveDialog.FileName)
            Process.Start(SaveDialog.FileName)
        Catch ex As Exception
            'MsgBox("Export to Excel Faild !", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub GeneralForms_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    'For ILS Shortcuts: Changed from Private Sub GeneralForms_CustomFindClick() Handles GeneralForms.CustomFindClick to GeneralForms_CustomFindClick(ByVal sender As Object, ByVal formId As Integer)
    Public Sub GeneralForms_CustomFindClick(ByVal sender As Object, ByVal formId As Integer)
        If (UserGeneralForms.getItemLevel(UserGeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts  
            'formlocalId = formId
            'If (sender.ToString().Contains("Text")) Then
            '    blTxtBox = DirectCast(sender, System.Windows.Forms.TextBox)
            '    Me.BLNO.TextValue = blTxtBox.Text
            'End If
            'For ILS Shortcuts End


            Dim DummyCode As String = Me.SearchChgCode.Code
            Dim sSQl As String
            Dim TB As New DataTable
            Dim lResult As Boolean

            Me.DataSetForm.Tables("TB_ChgLevelMaster").Clear()

            Me.DataSetForm.Tables("TB_ChgLevelDetails").Clear()
            Me.DataSetForm.AcceptChanges()
            If Me.SearchChgCode.Code = "" Then
                General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)
                Exit Sub
            End If

            ClearControl(Me)
            Me.DataSetForm.Tables("TB_ChgLevelDetails").Clear()
            Me.SearchChgCode.Code = DummyCode

            FrmStatus = FormStatus.NoAction

            dm = New DataManager(My.Settings.DSN)
            dm.QueryCriteria.Clear()
            dm.QueryCriteria.And(JoinPath.TB_ChgLevelMaster.Columns.ChargeItem, Me.SearchChgCode.Code, MatchType.Exact)
            dm.GetTB_ChgLevelMasterCollection()

            sSQl = "Select * , (Select Top 1 lName From Tb_Clients Where ID = ClientID) as [Client Name] " & _
                   "From TB_ChgLevelMaster Where ChargeItem = '" & Me.SearchChgCode.Code & "'"

            TableBySql(sSQl, TB, lResult)


            Me.DataSetForm.Tables("TB_ChgLevelMaster").Clear()

            '  Me.DataSetForm.Tables("TB_ChgLevelMaster").Merge(dm.DataSet.Tables("TB_ChgLevelMaster").Copy)
            Me.DataSetForm.Tables("TB_ChgLevelMaster").Merge(TB.Copy)


            If Me.GridCharges.Rows.Count > 0 Then
                FrmStatus = FormStatus.HasData
            Else
                FrmStatus = FormStatus.NoAction
            End If

            General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)

            GridNumSeperator(Me.GridCharges)
        End If
    End Sub

    'For ILS Shortcuts: Changed from Private Sub GeneralForms_CustomNewClick() Handles GeneralForms.CustomNewClick
    Public Sub GeneralForms_CustomNewClick(ByVal sender As Object, ByVal formId As Integer)

        If (UserGeneralForms.getItemLevel(UserGeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts

            Dim dummyCode = SearchChgCode.Code

            MasterID = Guid.NewGuid
            dm.DataSet.Tables("TB_ChgLevelMaster").Clear()
            dm.DataSet.Tables("TB_ChgLevelDetails").Clear()

            ClearControl(Me)
            SearchChgCode.Code = dummyCode

            Me.DataSetForm.Tables("TB_ChgLevelMaster").Clear()
            Me.DataSetForm.Tables("TB_ChgLevelDetails").Clear()

            FrmStatus = FormStatus.NewRecord
            General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)
            LockStatus(True)
        End If

    End Sub

    'Private Sub GeneralForms_CustomEditClick() Handles GeneralForms.CustomEditClick
    Public Sub GeneralForms_CustomEditClick(ByVal sender As Object, ByVal formId As Integer)

        If (UserGeneralForms.getItemLevel(UserGeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts
            Populate()
            FrmStatus = FormStatus.EditRecord
            General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)
            LockStatus(True)
        End If

    End Sub

    'For ILS Shortcuts: Changed from Private Sub GeneralForms_CustomSaveClick() Handles GeneralForms.CustomSaveClick
    Public Sub GeneralForms_CustomSaveClick(ByVal sender As Object, ByVal formId As Integer)

        If (UserGeneralForms.getItemLevel(UserGeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts

            Dim LogDataSet As New DataSet

            If ValidateForm() = False Then
                MsgBoxValidateFaild()
                Exit Sub
            End If

            If MsgBoxUpdate() = Windows.Forms.DialogResult.Yes Then
                Try
                    SendDataToClass()
                    LogDataSet = dm.DataSet.Copy
                    dm.CommitAll()
                    GenerateLog(LogDataSet)
                    MsgBoxSaveSuccessful()
                    FrmStatus = FormStatus.HasData
                    General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)
                    Me.DataSetForm.AcceptChanges()
                Catch ex As Exception
                    MsgBoxSaveFailed()
                    MsgBox(ex.ToString)
                End Try
            End If
        End If
    End Sub

    'For ILS Shortcuts Changed from Private Sub GeneralForms_CustomDeleteClick() Handles GeneralForms.CustomDeleteClick
    Public Sub GeneralForms_CustomDeleteClick(ByVal sender As Object, ByVal formId As Integer)

        If (UserGeneralForms.getItemLevel(UserGeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts

            Dim Dr As DataRow
            Dim LogDataSet As New DataSet
            Dim PID As Guid

            If Me.GridCharges.Rows.Count = 0 Then
                Exit Sub
            End If


            PID = Me.GridCharges.ActiveRow.Cells("ID").Value
            dm = New DataManager(My.Settings.DSN)

            If MsgBoxDelete() = Windows.Forms.DialogResult.Yes Then

                dm.QueryCriteria.And(JoinPath.TB_ChgLevelMaster.Columns.ID, PID, MatchType.Exact)
                dm.GetTB_ChgLevelMaster()


                dm.DataSet.Tables("TB_ChgLevelMaster").Rows(0).Delete()

                Try
                    LogDataSet = dm.DataSet.Copy
                    dm.CommitAll()
                    GenerateLog(LogDataSet)
                    FrmStatus = FormStatus.NoAction
                    General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)
                    MsgBoxDeleteSuccessful()
                    ClearControl(Me)
                    LockStatus(False)
                    Me.SearchChgCode.Enabled = True
                    Me.SearchChgCode.ComboCode.Enabled = True
                    Me.DataSetForm.Tables("TB_ChgLevelMaster").Clear()
                    Me.DataSetForm.Tables("TB_ChgLevelDetails").Clear()
                    FrmStatus = FormStatus.NoAction
                    General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)
                Catch ex As Exception
                    MsgBoxDeleteFailed()
                End Try

            End If
        End If

    End Sub

    'Private Sub GeneralForms_CustomOthers() Handles GeneralForms.CustomOthers
    Public Sub GeneralForms_CustomOthers(ByVal sender As Object, ByVal formId As Integer)

        If (UserGeneralForms.getItemLevel(UserGeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts
            Dim TbMaster As DataTable
            Dim TbDetail As DataTable
            Dim lResult As Boolean
            Dim PID As Guid
            Dim NewPID As Guid = Guid.NewGuid
            Dim sSql As String
            Dim Dr As DataRow
            Dim LogDataSet As New DataSet
            Dim NewDr As DataRow
            Dim Col As DataColumn

            If Me.GridCharges.Rows.Count = 0 Then
                Exit Sub
            End If

            If MsgBox("Do You Want To Copy Charge ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                PID = Me.GridCharges.ActiveRow.Cells("ID").Value
                dm = New DataManager(My.Settings.DSN)

                sSql = "Select  * From TB_ChgLevelMaster where ID = '" & PID.ToString & "'"

                TableBySql(sSql, TbMaster, lResult)
                sSql = "Select  * From TB_ChgLevelDetails where MasterID = '" & PID.ToString & "'"


                TableBySql(sSql, TbDetail, lResult)



                TbMaster.Rows(0).Item("ID") = NewPID
                TbMaster.Rows(0).Item("Description") = "Create By Copy"
                TbMaster.AcceptChanges()
                NewDr = dm.DataSet.Tables("TB_ChgLevelMaster").NewRow
                For Each Col In TbMaster.Columns
                    NewDr(Col.ColumnName) = TbMaster.Rows(0).Item(Col.ColumnName)
                Next
                dm.DataSet.Tables("TB_ChgLevelMaster").Rows.Add(NewDr)


                For Each Dr In TbDetail.Rows
                    Dr("ID") = Guid.NewGuid
                    Dr("MasterID") = NewPID
                Next

                TbDetail.AcceptChanges()

                For Each Dr In TbDetail.Rows
                    NewDr = dm.DataSet.Tables("TB_ChgLevelDetails").NewRow
                    For Each Col In TbDetail.Columns
                        NewDr(Col.ColumnName) = Dr(Col.ColumnName)
                    Next
                    dm.DataSet.Tables("TB_ChgLevelDetails").Rows.Add(NewDr)
                Next

                Try
                    LogDataSet = dm.DataSet.Copy
                    dm.CommitAll()
                    GenerateLog(LogDataSet)
                    MsgBoxSaveSuccessful()
                    ClearControl(Me)
                    LockStatus(False)
                    Me.SearchChgCode.Enabled = True
                    Me.SearchChgCode.ComboCode.Enabled = True
                    Me.DataSetForm.Tables("TB_ChgLevelMaster").Clear()
                    Me.DataSetForm.Tables("TB_ChgLevelDetails").Clear()
                    FrmStatus = FormStatus.NoAction
                    General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)
                Catch ex As Exception
                    MsgBoxSaveFailed()
                    MsgBox(ex.ToString)
                End Try

            End If
        End If
    End Sub

    Private Sub GeneralForms_CustomHomeClick() Handles GeneralForms.CustomHomeClick
        Me.Close()
    End Sub

End Class