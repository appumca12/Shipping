Imports OrmLib
Imports ShippingBiz


Public Class FrmInwardDiscount
    Implements IFGeneral
    Private FrmStatus As FormStatus = FormStatus.NoAction
    'Private ItemLevel As String = "303"
    Private ItemLevel As String = "308"
    Private dm As DataManager
    Private BLDoc As TB_InwardBLS
    Private BLDscnt As TB_InwardDiscount
    Dim frmGenSearch As New FrmGeneralSearch(InwardOutward.Inward)
    Dim UsrText As New Shipping.UserText
    Private formlocalId As Integer 'For ILS Shortcuts  
    Private blTxtBox As System.Windows.Forms.TextBox 'For ILS Shortcuts  

    Private Sub FrmInwardDiscount_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        FrmStatus = FormStatus.NoAction

        'UsrGenFrm.InitControl(Convert.ToInt32(ItemLevel))

        'For ILS Shortcuts: Added 
        '
        Me.GeneralForms.InitControl(Convert.ToInt32(ItemLevel))
        '

        Me.dFreeDays.InitControl(3, 0)
        Me.dPercent.InitControl(2, 0)
        Me.dAmount.InitControl(10, 0)
        Me.NoTax.InitControl("YN", UserComboCode.ShowCoumn.Meaning)

        LockStatus(False)

        Me.GeneralForms.InitControl("Discount Data", ItemLevel)
        General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)

        Me.BLNO.Enabled = True
        Me.BLNO.GeneralTxt.Enabled = True

        dm = New DataManager(My.Settings.DSN)
        dm.QueryCriteria.Clear()
        dm.QueryCriteria.And(JoinPath.TB_DetentionBase.Columns.ImpExp, "I", MatchType.Exact)
        dm.QueryCriteria.And(JoinPath.TB_DetentionBase.Columns.IsBase, "N", MatchType.Exact)
        dm.GetTB_DetentionBaseCollection()

        With DetentionID
            .DataSource = dm.DataSet.Tables("TB_DetentionBase").Copy
            For Each Col In .DisplayLayout.Bands(0).Columns
                Col.Hidden = True
            Next
            .DisplayLayout.Bands(0).Columns("Remarks").Hidden = False
            .DisplayMember = "Remarks"
            .ValueMember = "ID"
            .DisplayLayout.Bands(0).Columns("Remarks").Width = Me.DetentionID.Width
        End With
        Me.GeneralForms.AddCustomTools("From Excel", "FromExcel", My.Resources.tdx_excel2424)

    End Sub

    Private Sub LockStatus(ByVal Status As Boolean) Implements IFGeneral.LockStatus
        General.LockControls(Me, Status)

    End Sub

    Private Sub BLNO_CustomKeyDown() Handles BLNO.CustomKeyDown
        'Call frmGenSearch.ButtonSearchClick()
    End Sub

    Private Sub SendDataToClass() Implements IFGeneral.SendDataToClass

        Dim dAmount As Double
        If FrmStatus = FormStatus.NewRecord Then
            BLDscnt = dm.NewTB_InwardDiscount(BLDoc)
            BLDscnt.ID = Guid.NewGuid
            BLDscnt.BLID = BLDoc.ID
        End If

        BLDscnt.dFreeDays = Int32.Parse(Me.dFreeDays.GnrlNum.Value.ToString)
        BLDscnt.dPercent = Int32.Parse(Me.dPercent.GnrlNum.Value.ToString)
        BLDscnt.dAmount = Int64.Parse(Me.dAmount.GnrlNum.Value.ToString)
        BLDscnt.IsFDaysAsDiscount = Me.IsFDaysAsDiscount.Checked

        If Me.DetentionID.Text <> "" Then
            BLDscnt.SpecialCalculate = True
            BLDscnt.DetentionID = Me.DetentionID.Value
            BLDscnt.NoTax = Me.NoTax.Code
        Else
            BLDscnt.SpecialCalculate = False
            BLDscnt.DetentionID = Nothing
            BLDscnt.NoTax = "N"
        End If

    End Sub

    Private Sub Populate() Implements IFGeneral.Populate

        Dim dAmount As Double
        Me.dFreeDays.GnrlNum.Value = Int16.Parse(NullToValue(BLDscnt.dFreeDays, 0).ToString)
        If BLDscnt.dPercent.IsNull = True Then
            Me.dPercent.GnrlNum.Value = 0
        Else
            Me.dPercent.GnrlNum.Value = Int16.Parse(NullToValue(BLDscnt.dPercent, 0).ToString)
        End If

        If BLDscnt.dAmount.IsNull = True Then
            Me.dAmount.GnrlNum.Value = 0
        Else
            Me.dAmount.GnrlNum.Value = Int64.Parse(NullToValue(BLDscnt.dAmount, 0).ToString)
        End If



        Me.NoTax.Code = NullToValue(BLDscnt.NoTax, "N")

        If BLDscnt.IsFDaysAsDiscount.IsNull = True Then
            Me.IsFDaysAsDiscount.Checked = False
        Else
            Me.IsFDaysAsDiscount.Checked = BLDscnt.IsFDaysAsDiscount
        End If

        If BLDscnt.SpecialCalculate = True Then
            Try
                Me.DetentionID.Value = BLDscnt.DetentionID
            Catch ex As Exception
                Me.DetentionID.Value = Nothing
            End Try
        Else
            Me.DetentionID.Value = Nothing
        End If

    End Sub

    'Added for Search removal asper Nazanin skype chat thru muthu
    Private Sub ChangeStatus(ByVal Status As FormStatus)
        FrmStatus = Status
        General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)
    End Sub

    'For ILS Shortcuts: Changed from Private Sub  GeneralForms_CustomFindClick() Handles GeneralForms.CustomFindClick to GeneralForms_CustomFindClick(ByVal sender As Object, ByVal formId As Integer)
    Public Sub GeneralForms_CustomFindClick(ByVal sender As Object, ByVal formId As Integer)
        'For ILS Shortcuts
        If (UserGeneralForms.getItemLevel(UserGeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then
            formlocalId = formId
            Me.BLNO.Focus()
            If (sender.ToString().Contains("Text")) Then
                blTxtBox = DirectCast(sender, System.Windows.Forms.TextBox)
                Me.BLNO.TextValue = blTxtBox.Text
            End If
            'For ILS Shortcuts End

            Dim Frm As New FrmGeneralSearch(FrmGeneralSearch.InwardOutward.InWard)
            FrmStatus = FormStatus.NoAction
            'Frm.ShowDialog()
            If Frm.BLNo <> "" Then
                If Frm.Line <> CurrentShippingLine Then
                    MsgBox("Line in not equal with selected line !")
                Else
                    Me.BLNO.TextValue = Frm.BLNo
                End If
            End If

            If Me.BLNO.GeneralTxt.Text = "" Then
                Exit Sub
            End If

            If dm Is Nothing Then
                dm = New DataManager(My.Settings.DSN)
            End If

            dm.QueryCriteria.Clear()
            dm.QueryCriteria.And(JoinPath.TB_InwardBLS.Columns.Line, CurrentShippingLine, MatchType.Exact)
            dm.QueryCriteria.And(JoinPath.TB_InwardBLS.Columns.BlNo, Me.BLNO.GeneralTxt.Text, MatchType.Exact)
            BLDoc = dm.GetTB_InwardBLS
            If BLDoc Is Nothing Then
                MsgBoxGeneral("Invalid B/L No", "Error")
                Exit Sub
            End If

            dm.QueryCriteria.Clear()
            dm.QueryCriteria.And(JoinPath.TB_InwardDiscount.Columns.BLID, BLDoc.ID, MatchType.Exact)
            BLDscnt = dm.GetTB_InwardDiscount
            If BLDscnt Is Nothing Then
                MsgBoxGeneral("No Discount Data", "Error")
                FrmStatus = FormStatus.NoAction
            Else
                Populate()
                FrmStatus = FormStatus.HasData

            End If
            'General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)
            General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)
            LockStatus(False)
        End If
    End Sub
  
    'For ILS Shortcuts: Changed from Private Sub GeneralForms_CustomNewClick() Handles GeneralForms.CustomNewClick
    Public Sub GeneralForms_CustomNewClick(ByVal sender As Object, ByVal formId As Integer)
        If (UserGeneralForms.getItemLevel(UserGeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts
            Dim Dumm As String = Me.BLNO.TextValue
            If dm Is Nothing Then
                dm = New DataManager(My.Settings.DSN)
            End If
            dm.QueryCriteria.Clear()
            ClearControl(Me)
            Me.BLNO.TextValue = Dumm
            Me.BLNO.Focus()
            LockStatus(True)
            FrmStatus = FormStatus.NewRecord
            General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FormStatus.NewRecord)
        End If
    End Sub

    'For ILS Shortcuts Changed from Private Sub GeneralForms_CustomEditClick() Handles GeneralForms.CustomEditClick
    Public Sub GeneralForms_CustomEditClick(ByVal sender As Object, ByVal formId As Integer)
        If (UserGeneralForms.getItemLevel(UserGeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts
            LockStatus(True)
            FrmStatus = FormStatus.EditRecord
            General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FormStatus.EditRecord)
        End If
    End Sub

    'For ILS Shortcuts Changed from Private Sub GeneralForms_CustomSaveClick() Handles GeneralForms.CustomSaveClick
    Public Sub GeneralForms_CustomSaveClick(ByVal sender As Object, ByVal formId As Integer)
        If (UserGeneralForms.getItemLevel(UserGeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts
            Dim LogDataSet As New DataSet

            If Me.dFreeDays.GnrlNum.Value + Me.dPercent.GnrlNum.Value + Me.dAmount.GnrlNum.Value = 0 Then
                MsgBoxGeneral("Please Fill On Of Fields !", "Validate")
                Exit Sub
            End If

            If MsgBoxUpdate() = Windows.Forms.DialogResult.Yes Then
                Try
                    SendDataToClass()
                    LogDataSet = dm.DataSet.Copy
                    dm.CommitAll()
                    GenerateLog(LogDataSet)
                    MsgBoxSaveSuccessful()
                    'Added for Search removal asper Nazanin skype chat thru muthu
                    FrmStatus = FormStatus.NoAction
                    LockStatus(False)
                    General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FormStatus.NoAction)
                    'FrmStatus = FormStatus.HasData 'Newly added by thenmozhi
                    'ChangeStatus(FrmStatus) 'Newly added by thenmozhi
                Catch ex As Exception
                    MsgBoxSaveFailed()
                    MsgBox(dm.LastCommitText)
                    MsgBox(ex.ToString)
                End Try
            End If
        End If
    End Sub

    'For ILS Shortcuts Changed from Private Sub GeneralForms_CustomDeleteClick() Handles GeneralForms.CustomDeleteClick
    Public Sub GeneralForms_CustomDeleteClick(ByVal sender As Object, ByVal formId As Integer)

        If (UserGeneralForms.getItemLevel(UserGeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts

            Dim LogDataSet As New DataSet
            If MsgBoxDelete() <> Windows.Forms.DialogResult.Yes Then
                Exit Sub
            End If

            If General.MsgBoxDelete = Windows.Forms.DialogResult.Yes Then
                BLDscnt.Delete()
                Try
                    LogDataSet = dm.DataSet.Copy
                    dm.CommitAll()
                    GenerateLog(LogDataSet)
                    MsgBoxDeleteSuccessful()
                    FrmStatus = FormStatus.NoAction
                    General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)
                Catch ex As Exception
                    MsgBoxDeleteFailed()
                    MsgBoxGeneral(ex.ToString, "Error")
                End Try
            End If
        End If
    End Sub

    'For ILS Shortcuts Changed from Private Sub GeneralForms_CustomOthers() Handles GeneralForms.CustomOthers
    Public Sub GeneralForms_CustomOthers(ByVal sender As Object, ByVal formId As Integer)

        If (UserGeneralForms.getItemLevel(UserGeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts
            Me.FreeTime.Enabled = True
            Me.FreeTime.InitTable()
            Me.PopupControl.Show()
        End If

    End Sub

    Private Sub GeneralForms_CustomHomeClick() Handles GeneralForms.CustomHomeClick
        Me.Close()
    End Sub
    
End Class