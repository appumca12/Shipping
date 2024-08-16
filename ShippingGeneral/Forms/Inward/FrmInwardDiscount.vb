Imports OrmLib
Imports ShippingBiz
Imports System.Data.SqlClient


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
    Dim isNewClicked As Boolean = False
    Dim isEditClicked As Boolean = False
    Dim firsttime As String
    Dim isEdit As String

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
        firsttime = "y" 'For Shortcuts in Application
        isEdit = "N" 'For Shortcuts in Application 
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
                firsttime = "y"
            Else
                Populate()
                FrmStatus = FormStatus.HasData

            End If
            'General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)
            General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)
           
                LockStatus(True)

        End If
    End Sub
  
    'For ILS Shortcuts: Changed from Private Sub GeneralForms_CustomNewClick() Handles GeneralForms.CustomNewClick
    Public Sub GeneralForms_CustomNewClick(ByVal sender As Object, ByVal formId As Integer)
        isNewClicked = True 'For Shortcuts in Application 
        isEdit = "N" 'For Shortcuts in Application 
        Dim Dumm As String = Me.BLNO.TextValue
       

        If (UserGeneralForms.getItemLevel(UserGeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts
            'Dim Dumm As String = Me.BLNO.TextValue
            If dm Is Nothing Then
                dm = New DataManager(My.Settings.DSN)
            End If
            dm.QueryCriteria.Clear()
            ClearControl(Me)
            Me.BLNO.TextValue = Dumm
           

            dm.QueryCriteria.Clear()
            dm.QueryCriteria.And(JoinPath.TB_InwardBLS.Columns.Line, CurrentShippingLine, MatchType.Exact)
            dm.QueryCriteria.And(JoinPath.TB_InwardBLS.Columns.BlNo, Me.BLNO.GeneralTxt.Text, MatchType.Exact)
            BLDoc = dm.GetTB_InwardBLS
            If Not Me.BLNO.TextValue = "" Then
                If BLDoc Is Nothing Then
                    MsgBoxGeneral("Invalid B/L No", "Error")
                    Exit Sub
                End If
            End If
            'dm.QueryCriteria.Clear()
            'dm.QueryCriteria.And(JoinPath.TB_InwardDiscount.Columns.BLID, BLDoc.ID, MatchType.Exact)
            'BLDscnt = dm.GetTB_InwardDiscount
            'If Not BLDscnt Is Nothing Then
            '    MsgBoxGeneral("Duplicate records not allowed.", "Error")
            '    Exit Sub
            'End If

            LockStatus(True)
            FrmStatus = FormStatus.NewRecord
            General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FormStatus.NewRecord)
            If firsttime = "n" Then 'For Shortcuts in Application 
                dm.QueryCriteria.Clear()
                ClearControl(Me)
                Me.BLNO.Enabled = True
                Me.BLNO.GeneralTxt.Enabled = True
                Me.BLNO.Focus()
            End If 'For Shortcuts in Application End

        End If
    End Sub

    'For ILS Shortcuts Changed from Private Sub GeneralForms_CustomEditClick() Handles GeneralForms.CustomEditClick
    Public Sub GeneralForms_CustomEditClick(ByVal sender As Object, ByVal formId As Integer)
        If (UserGeneralForms.getItemLevel(UserGeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts

            Dim TB2 As New System.Data.DataTable
            Dim lResult2 As Boolean
            Dim rflag As Boolean
            rflag = False
            Dim sSql2 As String = "select [dbo].[FC_IsAllContainerReturnBack]('" & BLDoc.ID.ToString() & "') as returnback"
            TableBySql(sSql2, TB2, lResult2)

            If TB2.Rows.Count > 0 Then
                If TB2.Rows(0).Item("returnback") = "YES" Then
                    rflag = True
                Else
                    rflag = False
                End If
            End If
            If rflag And Not CurrentUser.UserCode = "LH" Then
                MessageBox.Show("All Cntr Return Back - Edit not Allowed!")
            Else
                LockStatus(True)
                FrmStatus = FormStatus.EditRecord
                General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FormStatus.EditRecord)
                isEdit = "Y" 'For Shortcuts in Application 
            End If

            
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
                    'For Shortcuts in Application 
                    dm.QueryCriteria.Clear()
                    dm.QueryCriteria.And(JoinPath.TB_InwardBLS.Columns.Line, CurrentShippingLine, MatchType.Exact)
                    dm.QueryCriteria.And(JoinPath.TB_InwardBLS.Columns.BlNo, Me.BLNO.GeneralTxt.Text, MatchType.Exact)
                    BLDoc = dm.GetTB_InwardBLS
                    If BLDoc Is Nothing Then
                        MsgBoxGeneral("invalid b/l no", "error")
                        Exit Sub
                    End If

                    If isNewClicked = True Then
                        Dim TB2 As New System.Data.DataTable
                        Dim lResult2 As Boolean

                        Dim sSql2 As String = "select blid from TB_InwardDiscount where blid = (select id from tb_Inwardbls where blno = '" & Me.BLNO.TextValue.Trim() & "' and Line = '" & CurrentShippingLine.ToString() & "')"
                        TableBySql(sSql2, TB2, lResult2)

                        If TB2.Rows.Count > 0 Then
                            MsgBoxGeneral("Discount Already Exist for this BL", "error")
                            Exit Sub
                        End If
                    End If
                    Dim Cmd As New SqlCommand
                    Dim DA As New SqlDataAdapter
                    Dim Cnn As New SqlConnection(My.Settings.DSN)
                    Dim DS As New DataSet
                    Dim PCol(0) As DataColumn
                    Dim cCol(0) As DataColumn
                    Cnn.Open()

                    With Cmd
                        .CommandText = "SP_InwardDuplicateFreeDays"
                        .CommandType = CommandType.StoredProcedure
                        .Connection = Cnn
                        .Parameters.AddWithValue("@Line", CurrentShippingLine)
                        .Parameters.AddWithValue("@BLno", Me.BLNO.GeneralTxt.Text)
                    End With

                    DA.SelectCommand = Cmd
                    DA.Fill(DS)

                    dm.QueryCriteria.Clear()
                    dm.QueryCriteria.And(JoinPath.TB_InwardDiscount.Columns.BLID, BLDoc.ID, MatchType.Exact)
                    BLDscnt = dm.GetTB_InwardDiscount

                    If (DS.Tables(0).Rows.Count > 0) Then
                        Dim TB1 As New System.Data.DataTable
                        Dim lResult As Boolean
                        Dim sSql As String = "SELECT * FROM TB_InwardDiscount where BLID ='" & DS.Tables(0).Rows(0)(0).ToString() & "'"
                        TableBySql(sSql, TB1, lResult)

                        'If TB1.Rows.Count = 1 And isEditClicked = False And isNewClicked = True Then
                        '    MsgBoxGeneral("Duplicate exists hence can not save.", "Error")
                        '    Exit Sub
                        'ElseIf TB1.Rows.Count = 1 And isEditClicked = True Then
                        '    '    MsgBoxGeneral("Duplicate records not allowed.", "Error")
                        '    'Exit Sub
                        'End If
                        ' latest comment by appu for temp
                        'If TB1.Rows.Count > 1 Then
                        '    MsgBoxGeneral("Duplicate exists hence can not save.", "Error")
                        '    Exit Sub
                        'ElseIf TB1.Rows.Count = 1 And isEdit = "N" Then
                        '    MsgBoxGeneral("Duplicate records not allowed.", "Error")
                        '    Exit Sub
                        'End If

                    End If

                    isNewClicked = False
                    'For Shortcuts in Application End

                    SendDataToClass()
                    LogDataSet = dm.DataSet.Copy
                    dm.CommitAll()
                    GenerateLog(LogDataSet)
                    MsgBoxSaveSuccessful()

                    ''  Significant Remark Required For B/Ls with Discount
                    'If (Me.dPercent.GnrlNum.Value = 0 And Me.dAmount.GnrlNum.Value = 0) Then
                    '    Me.LabelBL.Text = "B/L No"
                    'ElseIf (Me.dPercent.GnrlNum.Value > 0 Or Me.dAmount.GnrlNum.Value > 0) Then
                    '    Me.LabelBL.Text = "B/L No **"
                    'End If
                    ''End  Significant Remark Required For B/Ls with Discount


                    'Added for Search removal asper Nazanin skype chat thru muthu
                    FrmStatus = FormStatus.NoAction
                    LockStatus(False)
                    General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FormStatus.NoAction)
                    'FrmStatus = FormStatus.HasData 'Newly added by thenmozhi
                    'ChangeStatus(FrmStatus) 'Newly added by thenmozhi
                    ' dm.QueryCriteria.Clear()
                    ' ClearControl(Me)
                    ' Me.BLNO.TextValue = Dumm

                    firsttime = "n" 'For Shortcuts in Application 
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