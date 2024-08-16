Imports ShippingBiz
Imports OrmLib
Imports Infragistics.Win.UltraWinGrid
Public Class FrmPorts

    Private ItemLevel As String = "402"
    Private f As UltraGrid
    Private FrmStaus As FormStatus
    Private Dm As ShippingBiz.DataManager
    Private PortsData As TB_PortsCollection
    Private Isinit As Boolean
    Private CurrentID As Guid

    Private Sub FrmPorts_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me.GridPorts.DisplayLayout.Bands(0)
            .Columns("ID").Hidden = True
        End With
        GeneralForms.InitControl("PORTS DATA", ItemLevel)
        Me.Top = 1
        Me.Left = 1
        Me.Country.InitControl("CY", UserComboCode.ShowCoumn.Meaning)
        ChangeStatus(FormStatus.NoAction)

        Me.GroupBox.Appearance.BackColor = My.Settings.MainColor
        Me.GroupBoxSearch.Appearance.BackColor = My.Settings.MainColor
        ChangeControlColor(Me.GroupBox, UltraLabel1.GetType.ToString, My.Settings.MainColor, My.Settings.LableForeColor)
        ChangeControlColor(Me.GroupBoxSearch, UltraLabel1.GetType.ToString, My.Settings.MainColor, My.Settings.LableForeColor)



    End Sub

    'For ILS Shortcuts: Changed from Private Sub GeneralForms_CustomFindClick() Handles GeneralForms.CustomFindClick to GeneralForms_CustomFindClick(ByVal sender As Object, ByVal formId As Integer)
    Public Sub GeneralForms_CustomFindClick(ByVal sender As Object, ByVal formId As Integer)

        If (UserGeneralForms.getItemLevel(UserGeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts  

            Dim Dummy As String
            Dummy = Me.TxtSrch.TextValue
            CurrentID = Nothing
            ClearControl(Me)
            TxtSrch.TextValue = Dummy

            If Me.TxtSrch.TextValue = "" Then
                MessageBox.Show("No Any Text For Search !")
                Exit Sub
            End If
            Dm = New DataManager(My.Settings.DSN)
            Dm.QueryCriteria.Clear()
            Dm.QueryCriteria.And(JoinPath.TB_Ports.Columns.PortName, Me.TxtSrch.TextValue, MatchType.Partial)
            PortsData = Dm.GetTB_PortsCollection
            If PortsData Is Nothing Then
                MsgBox("No Valid Vessel Code !")
                ChangeStatus(FormStatus.NoAction)
            Else
                Me.GridPorts.DataSource = Dm.DataSet.Tables("TB_Ports")
                ChangeStatus(FormStatus.HasData)
            End If
        End If

    End Sub

    'For ILS Shortcuts: Changed from Private Sub GeneralForms_CustomNewClick() Handles GeneralForms.CustomNewClick
    Public Sub GeneralForms_CustomNewClick(ByVal sender As Object, ByVal formId As Integer)

        If (UserGeneralForms.getItemLevel(UserGeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts
            ClearControl(Me)
            Me.PortCode.Focus()
            ChangeStatus(FormStatus.NewRecord)
        End If

    End Sub

    'For ILS Shortcuts Changed from Private Sub GeneralForms_CustomEditClick() Handles GeneralForms.CustomEditClick
    Public Sub GeneralForms_CustomEditClick(ByVal sender As Object, ByVal formId As Integer)

        If (UserGeneralForms.getItemLevel(UserGeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts

            CurrentID = GetID()

            If CurrentID = Nothing Then
                MessageBox.Show("No valid Data !")
                ChangeStatus(FormStatus.NoAction)
            Else
                ChangeStatus(FormStatus.EditRecord)
                CopyRowToEdiArea()
            End If
        End If

    End Sub

    'For ILS Shortcuts: Changed from Private Sub GeneralForms_CustomSaveClick() Handles GeneralForms.CustomSaveClick
    Public Sub GeneralForms_CustomSaveClick(ByVal sender As Object, ByVal formId As Integer)

        If (UserGeneralForms.getItemLevel(UserGeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts

            Dim LogDataSet As New DataSet

            Dim Port As TB_Ports

            If ValidateData() = False Then
                General.MsgBoxValidateFaild()
                Exit Sub
            End If
            If FrmStaus = FormStatus.NewRecord Then
                If General.MsgBoxUpdate = Windows.Forms.DialogResult.Yes Then
                    If Dm Is Nothing Then
                        Dm = New DataManager(My.Settings.DSN)
                        PortsData = New TB_PortsCollection
                    End If
                    Port = Dm.NewTB_Ports(Me.PortCode.TextValue, Me.PortName.TextValue, Me.Country.Code)
                    Port.FPortName = Me.FPortName.TextValue
                    PortsData.Add(Port)
                    Try
                        LogDataSet = Dm.DataSet.Copy
                        Dm.CommitAll()
                        GenerateLog(LogDataSet)
                        General.MsgBoxSaveSuccessful()
                        ClearControl(Me)
                        ChangeStatus(FormStatus.NoAction)
                    Catch ex As Exception
                        General.MsgBoxSaveFailed()
                        MessageBox.Show(ex.ToString)
                    End Try
                End If
            Else
                If Not CurrentID = Nothing Then
                    If General.MsgBoxUpdate() = Windows.Forms.DialogResult.Yes Then
                        Port = PortsData.FindByID(CurrentID)
                        If Not Port Is Nothing Then
                            Port.PortCode = Me.PortCode.TextValue
                            Port.PortName = Me.PortName.TextValue
                            Port.FPortName = Me.FPortName.TextValue
                            Port.Country = Me.Country.Code
                            Try
                                LogDataSet = Dm.DataSet.Copy
                                Dm.CommitAll()
                                GenerateLog(LogDataSet)
                                General.MsgBoxSaveSuccessful()
                                ClearControl(Me)
                                ChangeStatus(FormStatus.NoAction)
                            Catch ex As Exception
                                General.MsgBoxSaveFailed()
                                MessageBox.Show(ex.ToString)
                            End Try
                        End If
                    End If
                End If
            End If
        End If

    End Sub

    'For ILS Shortcuts Changed from Private Sub GeneralForms_CustomDeleteClick() Handles GeneralForms.CustomDeleteClick
    Public Sub GeneralForms_CustomDeleteClick(ByVal sender As Object, ByVal formId As Integer)

        If (UserGeneralForms.getItemLevel(UserGeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts

            Dim LogDataSet As New DataSet

            Dim Port As TB_Ports
            If Not CurrentID = Nothing Then
                If General.MsgBoxDelete = Windows.Forms.DialogResult.Yes Then
                    Port = PortsData.FindByID(CurrentID)
                    If Not Port Is Nothing Then
                        Port.Delete()
                        Try
                            LogDataSet = Dm.DataSet.Copy
                            Dm.CommitAll()
                            GenerateLog(LogDataSet)
                            ClearControl(Me)
                            ChangeStatus(FormStatus.NoAction)
                            General.MsgBoxDeleteSuccessful()
                        Catch ex As Exception
                            General.MsgBoxDeleteFailed()
                            MessageBox.Show(ex.ToString)
                        End Try
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub GeneralForms_CustomHomeClick() Handles GeneralForms.CustomHomeClick
        Me.Close()
    End Sub

    Private Function GetID() As Guid

        If Me.GridPorts.Rows.Count = 0 Then
            Return Nothing
        Else
            Return Me.GridPorts.ActiveRow.Cells("ID").Value
        End If

    End Function

    Private Sub CopyRowToEdiArea()

        Dim Port As TB_Ports = PortsData.FindByID(CurrentID)
        If Not Port Is Nothing Then
            Me.PortCode.TextValue = Port.PortCode
            Me.PortName.TextValue = Port.PortName
            Me.FPortName.TextValue = Port.FPortName
            Me.Country.Code = Port.Country
        End If

    End Sub

    Private Sub ChangeStatus(ByVal Status As FormStatus)
        FrmStaus = Status
        General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStaus)
    End Sub

    Private Function ValidateData() As Boolean

        Dim Ans As Boolean = True

        If Len(Me.PortCode.TextValue) < 4 Then
            Ans = False
        End If

        If Len(Me.PortName.TextValue) = 0 Then
            Ans = False
        End If

        If Me.Country.Code = "" Then
            Ans = False
        End If

        Return Ans

    End Function

    Private Sub GeneralForms_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GeneralForms.Load

    End Sub


End Class