Imports OrmLib
Imports ShippingBiz

Public Class FrmAgents

    Implements IFGeneral
    Private ItemLevel = "408"
    Private FrmStatus As FormStatus = FormStatus.NoAction
    Private AgentID As Guid
    Private Dm As DataManager
    Private Document As TB_Agents
    Private formlocalId As Integer 'For ILS Shortcuts  
    Private blTxtBox As System.Windows.Forms.TextBox 'For ILS Shortcuts 

    Private Sub FrmAgents_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.PortCode.InitControl(Me.LinesGroupDetail.Appearance.BackColor)
        Me.SearchPort.InitControl(My.Settings.MainColor)

        Me.Lbl.BackColor = My.Settings.MainColor

        Me.Code.SetLength(10)
        Me.GeneralForms.InitControl("", ItemLevel)
        FrmStatus = FormStatus.NoAction
        General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)
        LockStatus(False)
        Me.SearchPort.Enabled = True
        Me.SearchPort.TextPort.GeneralText.Enabled = True
        Dm = New DataManager(My.Settings.DSN)

        Me.Fax.SetLength(20)
        Me.Tel.SetLength(20)


    End Sub

    Private Function ValidateForm() As Boolean

        Dim Ans As Boolean = True
        Dim nI As Byte
        Dim aList As New ArrayList

        FormErrorProvider.Clear()

        If Me.AgentName.Text = "" Then
            aList.Add(Me.AgentName)
        End If

        If Me.Address.Text = "" Then
            aList.Add(Me.Address)
        End If

        If Me.PortCode.IsValidPort = False Then
            aList.Add(Me.PortCode)
        End If

        If Me.Code.TextValue = "" Then
            aList.Add(Me.Code)
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

    Private Sub SendDataToClass() Implements IFGeneral.SendDataToClass

        With Document
            .AgentName = Me.AgentName.Text
            .Address = Me.Address.Text
            .Line = CurrentShippingLine
            .Port = Me.PortCode.PortCode
            .Tel = Me.Tel.TextValue
            .Fax = Me.Fax.TextValue
            .Code = Me.Code.TextValue
            .DetentionClause = Me.DetentionClause.TextValue
        End With

    End Sub

    Private Sub Populate() Implements IFGeneral.Populate

        With Document
            Me.AgentName.Text = .AgentName
            Me.Address.Text = .Address
            Me.PortCode.PortCode = .Port
            Me.Tel.TextValue = .Tel
            Me.Fax.TextValue = .Fax
            Me.Code.TextValue = .Code
            Me.DetentionClause.TextValue = NullToValue(.DetentionClause, "")

        End With

    End Sub

    Private Sub LockStatus(ByVal Status As Boolean) Implements IFGeneral.LockStatus
        General.LockControls(Me, Status)
        Me.SearchPort.Enabled = True
        Me.SearchPort.TextPort.GeneralText.Enabled = True
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

            Dim Dummy As String = Me.SearchPort.PortCode
            ClearControl(Me)
            Me.SearchPort.PortCode = Dummy
            If Dummy = "" Then
                Exit Sub
            End If
            Dm.QueryCriteria.Clear()
            Dm.QueryCriteria.And(JoinPath.TB_Agents.Columns.Line, CurrentShippingLine, MatchType.Exact)
            Dm.QueryCriteria.And(JoinPath.TB_Agents.Columns.Port, Dummy, MatchType.Exact)

            Document = Dm.GetTB_Agents
            If Document Is Nothing Then
                MsgBoxGeneral("No Valid Agent For This Port !")
                FrmStatus = FormStatus.NoAction
                Exit Sub
            Else
                Populate()
                FrmStatus = FormStatus.HasData
            End If

            General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)
            LockStatus(False)
            Me.SearchPort.Enabled = True
        End If
    End Sub

    'For ILS Shortcuts: Changed from Private Sub GeneralForms_CustomNewClick() Handles GeneralForms.CustomNewClick
    Public Sub GeneralForms_CustomNewClick(ByVal sender As Object, ByVal formId As Integer)
        If (UserGeneralForms.getItemLevel(UserGeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts
            ClearControl(Me)
            Me.SearchPort.Focus()
            Dm = New DataManager(My.Settings.DSN)
            FrmStatus = FormStatus.NewRecord
            AgentID = System.Guid.NewGuid
            General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)
            LockStatus(True)
        End If
    End Sub

    'Private Sub GeneralForms_CustomEditClick() Handles GeneralForms.CustomEditClick
    Public Sub GeneralForms_CustomEditClick(ByVal sender As Object, ByVal formId As Integer)
        If (UserGeneralForms.getItemLevel(UserGeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts
            FrmStatus = FormStatus.EditRecord
            General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)
            LockStatus(True)
        End If
    End Sub

    'For ILS Shortcuts: Changed from Private Sub GeneralForms_CustomSaveClick() Handles GeneralForms.CustomSaveClick
    Public Sub GeneralForms_CustomSaveClick(ByVal sender As Object, ByVal formId As Integer)

        If (UserGeneralForms.getItemLevel(UserGeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts
            Dim LogDataSet As New DataSet
            If ValidateForm() = True Then
                If MsgBoxUpdate() = Windows.Forms.DialogResult.Yes Then
                    If FrmStatus = FormStatus.NewRecord Then
                        Dm = New DataManager(My.Settings.DSN)
                        Document = Dm.NewTB_Agents(CurrentShippingLine, Me.PortCode.PortCode, Me.AgentName.Text, Me.Address.Text)
                        Document.ID = AgentID
                    End If
                    SendDataToClass()
                    Try
                        LogDataSet = Dm.DataSet.Copy
                        Dm.CommitAll()
                        GenerateLog(LogDataSet)
                        MsgBoxSaveSuccessful()
                    Catch ex As Exception
                        MsgBoxSaveFailed()
                    End Try
                End If
            End If
        End If

    End Sub

    'For ILS Shortcuts Changed from Private Sub GeneralForms_CustomDeleteClick() Handles GeneralForms.CustomDeleteClick
    Public Sub GeneralForms_CustomDeleteClick(ByVal sender As Object, ByVal formId As Integer)

        If (UserGeneralForms.getItemLevel(UserGeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts
            Dim LogDataSet As New DataSet
            If Not Document Is Nothing Then
                If MsgBoxDelete() = Windows.Forms.DialogResult.Yes Then

                    Try
                        Document.Delete()
                        LogDataSet = Dm.DataSet.Copy
                        Dm.CommitAll()
                        GenerateLog(LogDataSet)
                        ClearControl(Me)
                        FrmStatus = FormStatus.NoAction
                        General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)
                        LockStatus(False)
                        Me.SearchPort.Enabled = True
                        MsgBoxDeleteSuccessful()
                    Catch ex As Exception
                        MsgBoxDeleteFailed()
                    End Try

                End If
            End If
        End If

    End Sub

End Class