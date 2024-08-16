
Imports OrmLib
Imports ShippingBiz

Public Class FrmClients

    Private ItemLevel As String = "404"
    Private FrmStatus As FormStatus
    Private dm As DataManager
    Private Clnts As TB_ClientsCollection
    Private ID As Guid

    Private Sub FrmClients_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.GeneralForms.InitControl("Clients", ItemLevel)
        Me.Left = 0
        Me.Top = 1
        With Me.GridClients
            With .DisplayLayout.Bands(0)
                .Columns("ID").Hidden = True
            End With
        End With

        'Me.Label10.BackColor = My.Settings.MainColor
        'Me.Label11.BackColor = My.Settings.MainColor
        'Me.Label12.BackColor = My.Settings.MainColor
        'Me.Label13.BackColor = My.Settings.MainColor
        'Me.Label14.BackColor = My.Settings.MainColor
        'Me.Label15.BackColor = My.Settings.MainColor
        'Me.Label16.BackColor = My.Settings.MainColor
        'Me.Label17.BackColor = My.Settings.MainColor
        'Me.Label18.BackColor = My.Settings.MainColor
        'Me.Label1.BackColor = My.Settings.MainColor

        Me.lName.SetLength(100)
        Me.FName.SetLength(100)

        Me.LAddress.SetLength(255)
        Me.FAddress.SetLength(255)

        Me.EMail.SetLength(100)
        Me.Fax.SetLength(100)
        Me.Tel.SetLength(100)

        Me.POBOX.SetLength(15)
        Me.RegestrationNo.SetLength(20)
        Me.EconomicNo.SetLength(20)

        Me.Remarks.SetLength(100)
        Me.Country.InitControl("CY", UserComboCode.ShowCoumn.Meaning)

        Me.AccountA.SetLength(30)
        Me.AccountB.SetLength(30)
        Me.AccountC.SetLength(30)

        Me.NationalCode.SetLength(20)
        Me.NationalID.SetLength(20)

        Me.Deposit.InitControl(20, 0)

        Me.State.InitControl("OS", UserComboCode.ShowCoumn.MeaningF)
        Me.City.InitControl("CI", UserComboCode.ShowCoumn.MeaningF)
        Me.AccountStatus.InitControl("AS", UserComboCode.ShowCoumn.Meaning)
        Me.ClientType.InitControl("TC", UserComboCode.ShowCoumn.Meaning)

        Me.ClientType.Code = "NR"

        FrmStatus = FormStatus.NoAction
        General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)
        Me.Clients.InitControl()
        Me.Clients.Text = ""

        LockStatus(False)

        Me.GeneralForms.AddCustomTools("Save To Excel", "SaveExcel", My.Resources.tdx_excel2424)
        Me.GroupBox.Appearance.BackColor = My.Settings.MainColor
        Me.GroupBox.Appearance.BackColor2 = My.Settings.MainColor2
        GroupAdditional.Appearance.BackColor = Color.Transparent
        GroupBoxSendDocs.Appearance.BackColor = Color.Transparent
        GroupMainData.Appearance.BackColor = Color.Transparent
        Me.Label1.BackColor = Me.GroupBox2.BackColor

        Me.Clients.ClientID = Guid.Empty
    End Sub

    'For ILS Shortcuts: Changed from Private Sub GeneralForms_CustomFindClick() Handles GeneralForms.CustomFindClick to GeneralForms_CustomFindClick(ByVal sender As Object, ByVal formId As Integer)
    Public Sub GeneralForms_CustomFindClick(ByVal sender As Object, ByVal formId As Integer)

        If (UserGeneralForms.getItemLevel(UserGeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts  

            dm = New DataManager(My.Settings.DSN)
            dm.QueryCriteria.Clear()
            If (Me.Clients.ClientID = Guid.Empty) Then
                dm.QueryCriteria.And(JoinPath.TB_Clients.Columns.lName, Me.SearchText.TextValue, MatchType.Partial)
            Else
                dm.QueryCriteria.And(JoinPath.TB_Clients.Columns.ID, Me.Clients.ClientID, MatchType.Partial)
            End If

            Clnts = dm.GetTB_ClientsCollection()

            If Clnts.Count = 0 Then
                FrmStatus = FormStatus.NoAction
                MsgBoxGeneral("No Any Data !", "Search Result")
            Else
                FrmStatus = FormStatus.HasData
                'Me.FormDataSet.Tables(0).Clear()
                'Me.FormDataSet.Tables(0).Merge(dm.DataSet.Tables("TB_Clients").Copy)
                Me.GridClients.DataSource = dm.DataSet.Tables("TB_Clients").Copy
                '      Me.GridClients.DataSource = Me.FormDataSet.Tables(0)
            End If

            General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)

            LockStatus(False)
        End If

    End Sub

    'For ILS Shortcuts: Changed from Private Sub GeneralForms_CustomNewClick() Handles GeneralForms.CustomNewClick
    Public Sub GeneralForms_CustomNewClick(ByVal sender As Object, ByVal formId As Integer)

        If (UserGeneralForms.getItemLevel(UserGeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts

            ClearControl(Me)
            Me.SearchText.Focus()
            Me.ID = System.Guid.NewGuid
            FrmStatus = FormStatus.NewRecord

            Me.ClientType.Code = "NR"
            General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)
            LockStatus(True)

        End If

    End Sub

    'For ILS Shortcuts: Changed from Private Sub GeneralForms_CustomEditClick() Handles GeneralForms.CustomEditClick
    Public Sub GeneralForms_CustomEditClick(ByVal sender As Object, ByVal formId As Integer)
        Dim sql As String
        Dim lResult As Boolean
        Dim TB As DataTable
        If (UserGeneralForms.getItemLevel(UserGeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts

            If Not Me.GridClients.ActiveRow Is Nothing Then
                With Me.GridClients.ActiveRow

                    ID = .Cells("ID").Value
                    Me.lName.TextValue = IIf(IsDBNull(.Cells("lName").Value), "", .Cells("lName").Value)
                    Me.LAddress.TextValue = IIf(IsDBNull(.Cells("lAddress").Value), "", .Cells("lAddress").Value)
                    Me.FName.TextValue = IIf(IsDBNull(.Cells("fName").Value), "", .Cells("fName").Value)
                    Me.FAddress.TextValue = IIf(IsDBNull(.Cells("FAddress").Value), "", .Cells("FAddress").Value)
                    Me.EMail.TextValue = IIf(IsDBNull(.Cells("EMail").Value), "", .Cells("EMail").Value)
                    Me.Tel.TextValue = IIf(IsDBNull(.Cells("Tel").Value), "", .Cells("Tel").Value)
                    Me.Fax.TextValue = IIf(IsDBNull(.Cells("Fax").Value), "", .Cells("Fax").Value)
                    Me.Country.Code = IIf(IsDBNull(.Cells("Country").Value), "", .Cells("Country").Value)
                    Me.Remarks.TextValue = IIf(IsDBNull(.Cells("Remarks").Value), "", .Cells("Remarks").Value)
                    Me.AccountA.TextValue = IIf(IsDBNull(.Cells("AccountA").Value), "", .Cells("AccountA").Value)
                    Me.AccountB.TextValue = IIf(IsDBNull(.Cells("Accountb").Value), "", .Cells("Accountb").Value)
                    Me.AccountC.TextValue = IIf(IsDBNull(.Cells("Accountc").Value), "", .Cells("Accountc").Value)
                    Me.EconomicNo.TextValue = IIf(IsDBNull(.Cells("EconomicNo").Value), "", .Cells("EconomicNo").Value)
                    Me.POBOX.TextValue = IIf(IsDBNull(.Cells("POBOX").Value), "", .Cells("POBOX").Value)
                    Me.RegestrationNo.TextValue = IIf(IsDBNull(.Cells("RegestrationNo").Value), "", .Cells("RegestrationNo").Value)
                    Me.IsReal.Checked = IIf(IsDBNull(.Cells("IsReal").Value), False, .Cells("IsReal").Value)
                    Me.SendDocsByFax.Checked = IIf(IsDBNull(.Cells("SendDocsByFax").Value), False, .Cells("SendDocsByFax").Value)
                    Me.SendDocsByEmail.Checked = IIf(IsDBNull(.Cells("SendDocsByEmail").Value), False, .Cells("SendDocsByEmail").Value)
                    Me.City.Code = IIf(IsDBNull(.Cells("City").Value), "", .Cells("City").Value)
                    Me.State.Code = IIf(IsDBNull(.Cells("State").Value), "", .Cells("State").Value)
                    Me.NationalCode.TextValue = IIf(IsDBNull(.Cells("NationalCode").Value), "", .Cells("NationalCode").Value)
                    Me.NationalID.TextValue = IIf(IsDBNull(.Cells("NationalId").Value), "", .Cells("NationalId").Value)
                    Me.AccountStatus.Code = IIf(IsDBNull(.Cells("AccountStatus").Value), "", .Cells("AccountStatus").Value)
                    Me.ClientType.Code = IIf(IsDBNull(.Cells("ClientType").Value), "", .Cells("ClientType").Value)
                    Me.Deposit.GnrlNum.Value = IIf(IsDBNull(.Cells("Deposit").Value), 0, .Cells("Deposit").Value)
                    Me.WebUserId.TextValue = IIf(IsDBNull(.Cells("WebUserId").Value), "", .Cells("WebUserId").Value)
                    Me.WebUserPass.TextValue = IIf(IsDBNull(.Cells("WebUserPass").Value), "", .Cells("WebUserPass").Value)
                    Me.Inactive.Checked = IIf(IsDBNull(.Cells("WebInactive").Value), False, .Cells("WebInactive").Value)
                    Me.DOB.DateValue = IIf(IsDBNull(.Cells("DOB").Value), "", .Cells("DOB").Value)
                    Me.IsIndividual.Checked = IIf(IsDBNull(.Cells("IsCompany").Value), False, .Cells("IsCompany").Value)
                End With

                FrmStatus = FormStatus.EditRecord
                General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)

                LockStatus(True)
                Me.TabControl.Tabs(1).Selected = True
            Else
                MsgBoxGeneral("Please Select a row !", "Error")
            End If
        End If

    End Sub

    'For ILS Shortcuts: Changed from Private Sub GeneralForms_CustomSaveClick() Handles GeneralForms.CustomSaveClick
    Public Sub GeneralForms_CustomSaveClick(ByVal sender As Object, ByVal formId As Integer)
        Dim sql As String
        Dim lResult As Boolean
        Dim TB As DataTable
        If (UserGeneralForms.getItemLevel(UserGeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts


            Dim DV As DataView
            Dim Dr As DataRow
            Dim LogDataSet As New DataSet
            If ValidateData() = False Then
                Exit Sub
            End If

            If MsgBoxUpdate() <> Windows.Forms.DialogResult.Yes Then
                Exit Sub
            End If

            If dm Is Nothing Then
                dm = New DataManager(My.Settings.DSN)
            End If


            Try
                DV = New DataView(dm.DataSet.Tables("TB_Clients"), "ID = '" & ID.ToString & "'", "", DataViewRowState.CurrentRows)
                If DV.Count = 0 Then
                    Dr = dm.DataSet.Tables("TB_Clients").NewRow
                    Dr("ID") = ID
                    Dr("lName") = Me.lName.TextValue
                    Dr("lAddress") = Me.LAddress.TextValue
                    Dr("fName") = Me.FName.TextValue
                    Dr("FAddress") = Me.FAddress.TextValue
                    Dr("EMail") = Me.EMail.TextValue
                    Dr("Tel") = Me.Tel.TextValue
                    Dr("Fax") = Me.Fax.TextValue
                    Dr("Country") = Me.Country.Code
                    Dr("Remarks") = Me.Remarks.TextValue
                    Dr("Accounta") = Me.AccountA.TextValue
                    Dr("Accountb") = Me.AccountB.TextValue
                    Dr("Accountc") = Me.AccountC.TextValue
                    Dr("isReal") = Me.IsReal.Checked
                    Dr("POBOX") = Me.POBOX.TextValue
                    Dr("RegestrationNo") = Me.RegestrationNo.TextValue
                    Dr("EconomicNo") = Me.EconomicNo.TextValue

                    Dr("SendDocsByEmail") = Me.SendDocsByEmail.Checked
                    Dr("SendDocsByFax") = Me.SendDocsByFax.Checked

                    Dr("City") = Me.City.Code
                    Dr("State") = Me.State.Code
                    Dr("NationalID") = Me.NationalID.TextValue
                    Dr("NationalCode") = Me.NationalCode.TextValue
                    Dr("AccountStatus") = Me.AccountStatus.Code
                    Dr("ClientType") = Me.ClientType.Code
                    Dr("Deposit") = Me.Deposit.GnrlNum.Value
                    Dr("isCompany") = Me.IsIndividual.Checked
                    Sql = "SELECT top 1 replace(webuserid, 'U','') as NextId FROM TB_Clients where WebUserId is not null ORDER BY WebUserId desc"
                    TableBySql(Sql, TB, lResult)
                    If TB.Rows.Count > 0 Then
                        Dim nextid As String
                        nextid = (Convert.ToInt64(TB.Rows(0).Item("NextId").ToString()) + 1).ToString()
                        Dr("WebUserId") = "U" + nextid
                        Me.WebUserId.TextValue = "U" + nextid
                        Dr("WebUserPass") = "PWD" + nextid
                        Me.WebUserPass.TextValue = "PWD" + nextid
                        Dr("WebInactive") = Me.Inactive.Checked
                    End If
                    Dr("DOB") = IIf(Me.DOB.DateValue = Nothing, DBNull.Value, Me.DOB.DateValue)
                    dm.DataSet.Tables("TB_Clients").Rows.Add(Dr)
                Else
                    DV.Item(0).Item("lName") = Me.lName.TextValue
                    DV.Item(0).Item("lAddress") = Me.LAddress.TextValue
                    DV.Item(0).Item("fName") = Me.FName.TextValue
                    DV.Item(0).Item("FAddress") = Me.FAddress.TextValue
                    DV.Item(0).Item("EMail") = Me.EMail.TextValue
                    DV.Item(0).Item("Tel") = Me.Tel.TextValue
                    DV.Item(0).Item("Fax") = Me.Fax.TextValue
                    DV.Item(0).Item("Country") = Me.Country.Code
                    DV.Item(0).Item("Remarks") = Me.Remarks.TextValue
                    DV.Item(0).Item("Accounta") = Me.AccountA.TextValue
                    DV.Item(0).Item("Accountb") = Me.AccountB.TextValue
                    DV.Item(0).Item("Accountc") = Me.AccountC.TextValue
                    DV.Item(0).Item("isReal") = Me.IsReal.Checked
                    DV.Item(0).Item("POBOX") = Me.POBOX.TextValue
                    DV.Item(0).Item("RegestrationNo") = Me.RegestrationNo.TextValue
                    DV.Item(0).Item("EconomicNo") = Me.EconomicNo.TextValue
                    DV.Item(0).Item("SendDocsByEmail") = Me.SendDocsByEmail.Checked
                    DV.Item(0).Item("SendDocsByFax") = Me.SendDocsByFax.Checked

                    DV.Item(0).Item("City") = Me.City.Code
                    DV.Item(0).Item("State") = Me.State.Code
                    DV.Item(0).Item("NationalID") = Me.NationalID.TextValue
                    DV.Item(0).Item("NationalCode") = Me.NationalCode.TextValue
                    DV.Item(0).Item("AccountStatus") = Me.AccountStatus.Code
                    DV.Item(0).Item("ClientType") = Me.ClientType.Code
                    DV.Item(0).Item("Deposit") = Me.Deposit.GnrlNum.Value
                    DV.Item(0).Item("WebUserId") = Me.WebUserId.TextValue.Trim
                    DV.Item(0).Item("WebUserPass") = Me.WebUserPass.TextValue.Trim
                    DV.Item(0).Item("WebInactive") = Me.Inactive.Checked
                    DV.Item(0).Item("DOB") = IIf(Me.DOB.DateValue = Nothing, DBNull.Value, Me.DOB.DateValue)
                    DV.Item(0).Item("isCompany") = Me.IsIndividual.Checked
                End If
                LogDataSet = dm.DataSet.Copy
                dm.CommitAll()
                GenerateLog(LogDataSet)
                MsgBoxSaveSuccessful()
                GeneralForms_CustomFindClick(sender, formId)
                LockStatus(False)
            Catch ex As Exception
                General.MsgBoxSaveFailed()
                MessageBox.Show(ex.ToString)
            End Try
        End If

    End Sub

    'For ILS Shortcuts Changed from Private Sub GeneralForms_CustomDeleteClick() Handles GeneralForms.CustomDeleteClick
    Public Sub GeneralForms_CustomDeleteClick(ByVal sender As Object, ByVal formId As Integer)

        If (UserGeneralForms.getItemLevel(UserGeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts

            Dim DV As DataView
            Dim LogDataSet As New DataSet

            If MsgBoxDelete() <> Windows.Forms.DialogResult.Yes Then
                Exit Sub
            End If

            DV = New DataView(dm.DataSet.Tables("TB_Clients"), "ID = '" & ID.ToString & "'", "", DataViewRowState.CurrentRows)

            If DV.Count > 0 Then
                If General.MsgBoxDelete = Windows.Forms.DialogResult.Yes Then
                    DV.Item(0).Delete()
                    Try
                        LogDataSet = dm.DataSet.Copy
                        dm.CommitAll()
                        GenerateLog(LogDataSet)
                        ClearControl(Me)
                        LockStatus(True)
                        MsgBoxDeleteSuccessful()
                        FrmStatus = FormStatus.NoAction
                        General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)
                    Catch ex As Exception
                        MsgBoxDeleteFailed()
                        MsgBoxGeneral(ex.ToString, "Error")
                    End Try
                End If
            End If
        End If
    End Sub

    'For ILS Shortcuts: Changed from Private Sub GeneralForms_CustomOthers() Handles GeneralForms.CustomOthers
    Public Sub GeneralForms_CustomOthers(ByVal sender As Object, ByVal formId As Integer)

        If (UserGeneralForms.getItemLevel(UserGeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts
            If Me.GeneralForms.KeySelect = "SaveExcel" Then
                If Me.GridClients.Rows.Count > 0 Then
                    SaveGridToExcel(Me.GridClients)
                End If
            End If
        End If

    End Sub

    Private Sub GeneralForms_CustomHomeClick() Handles GeneralForms.CustomHomeClick
        Me.Close()
    End Sub

    Private Function ValidateData() As Boolean

        Dim aList As New ArrayList
        Dim nI As Long
        Dim Ans As Boolean = True
        FormErrorProvider.Clear()

        If Me.lName.TextValue = "" Then
            aList.Add(Me.lName)
        End If

        If Me.LAddress.TextValue = "" Then
            aList.Add(Me.LAddress)
        End If

        If Me.Country.Code = "" Then
            aList.Add(Me.Country)
        End If

        If Me.FName.TextValue = "" Then
            aList.Add(Me.FName)
        End If

        If Me.FAddress.TextValue = "" Then
            aList.Add(Me.FAddress)
        End If

        If Me.EMail.TextValue = "" Then
            aList.Add(Me.EMail)
        End If

        If Me.Fax.TextValue = "" Then
            aList.Add(Me.Fax)
        End If

        If Me.Tel.TextValue = "" Then
            aList.Add(Me.Tel)
        End If

        If aList.Count > 0 Then
            For nI = 0 To aList.Count - 1
                FormErrorProvider.SetError(aList(nI), "Data Requird")
            Next
            MsgBoxValidateFaild()
            Ans = False
        End If

        Return Ans


    End Function

    Private Sub LockStatus(ByVal Status As Boolean)

        Me.lName.Enabled = Status
        Me.LAddress.Enabled = Status
        Me.FName.Enabled = Status
        Me.FAddress.Enabled = Status
        Me.EMail.Enabled = Status
        Me.Tel.Enabled = Status
        Me.Fax.Enabled = Status
        Me.Country.Enabled = Status
        Me.Remarks.Enabled = Status
        Me.AccountA.Enabled = Status
        Me.AccountB.Enabled = Status
        Me.AccountC.Enabled = Status

    End Sub

    Private Sub GroupBox_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles GroupBox.Paint

        Dim Ctl As Control
        For Each Ctl In GroupBox.Controls
            If TypeOf Ctl Is Windows.Forms.Label Then
                DrawTransParentLabel(Ctl, e)
            End If
        Next
    End Sub

    Private Sub State_CustomValueChanged() Handles State.CustomValueChanged
        Me.City.ApplyFilterByNextCode(Me.State.Code, UserComboCode.ShowCoumn.MeaningF)

    End Sub
End Class