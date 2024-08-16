Imports ShippingBiz
Imports OrmLib
Imports Infragistics.Win.UltraWinToolbars
Imports Shipping.UserText
Imports Shipping.FrmPMain
Public Class UserGeneralForms

    Public Shared Event CustomFindClick(ByVal sender As Object, ByVal formId As Integer)
    Public Shared Event CustomNewClick()
    Public Shared Event CustomEditClick()
    Public Shared Event CustomSaveClick()
    Public Shared Event CustomDeleteClick()
    Public Shared Event CustomPrintClick()
    Public Shared Event CustomHistory()
    Public Shared Event CustomOthers()
    Public Shared Event CustomHomeClick()
    Public Event CustomNavigateFirstClick()
    Public Event CustomNavigateLastClick()
    Public Event CustomNavigatePrivClick()
    Public Event CustomNavigateNextClick()
    Private dm As DataManager
    Private Shared lClose As Boolean
    Private sKeySelect As String
    'For ILS Shortcuts
    Shared otherBtnClicked As String = ""
    Private Shared isButtonClicked As Boolean
    Private Shared userTabSelect As String
    Private formId As Integer

   
    Public Shared Property UserTabSelected() As String
        Get
            Return userTabSelect
        End Get
        Set(ByVal value As String)
            userTabSelect = value
        End Set
    End Property

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub InitControl(ByVal Title As String)
        'Me.Toolbar.Toolbars("FormCaption").Tools.Item(0).SharedProps.Caption = Title
        'Me.Toolbar.Toolbars("FormCaption").Settings.Appearance.BackColor = My.Settings.MainColor
        'Me.Toolbar.Toolbars("FormCaption").Settings.Appearance.BackColor2 = My.Settings.MainColor2
        Me.BackColor = My.Settings.MainColor
        Me.FillPanel.BackColor = My.Settings.MainColor
    End Sub

    Public Sub InitControl(ByVal Title As String, ByVal Level As String)
        'Me.Toolbar.Toolbars("FormCaption").Tools.Item(0).SharedProps.Caption = Title
        'Me.Toolbar.Toolbars("FormCaption").Settings.Appearance.BackColor = My.Settings.MainColor
        'Me.Toolbar.Toolbars("FormCaption").Settings.Appearance.BackColor2 = My.Settings.MainColor2
        Me.BackColor = My.Settings.MainColor
        Me.FillPanel.BackColor = My.Settings.MainColor
        SetLevelAccess(Level)
    End Sub

    Private Sub Navigate_PrivRecClick() Handles Navigate.PrivRecClick
        RaiseEvent CustomNavigatePrivClick()
    End Sub

    Private Sub Navigate_NextRecClick() Handles Navigate.NextRecClick
        RaiseEvent CustomNavigateNextClick()
    End Sub

    Private Sub Navigate_FirstRecClick() Handles Navigate.FirstRecClick
        RaiseEvent CustomNavigateFirstClick()
    End Sub

    Private Sub Navigate_LastRecClick() Handles Navigate.LastRecClick
        RaiseEvent CustomNavigateLastClick()
    End Sub

    Public ReadOnly Property IsClosed() As Boolean
        Get
            Return lClose
        End Get
    End Property

    Public Property CustomToolbar() As UltraToolbarsManager
        Get
            Return Me.Toolbar
        End Get
        Set(ByVal value As UltraToolbarsManager)
            Me.Toolbar = value
        End Set
    End Property

    Private Sub SetLevelAccess(ByVal Level As String)

        Dim Dm As New DataManager(My.Settings.DSN)
        Dim Dr As DataRow
        Dim Drs() As DataRow

        Dm.QueryCriteria.And(JoinPath.TB_AccessLevel.Columns.UserID, CurrentUser.ID.ToString, MatchType.Exact)
        Dm.GetTB_AccessLevelCollection()
        Dm.QueryCriteria.Clear()

        Dm.QueryCriteria.And(JoinPath.TB_MenuItems.Columns.ItemLevel, Level, MatchType.StartsWith)
        Dm.GetTB_MenuItemsCollection()

        ' Dm.DataSet.Tables("Tb_MenuItems").WriteXml("c:\m.xml")


        For Each Dr In Dm.DataSet.Tables("Tb_MenuItems").Rows
            If Len(Dr("ItemLevel")) > 3 Then
                Drs = Dm.DataSet.Tables("Tb_AccessLevel").Select("MenuItemID = '" & Dr("ID").ToString & "'")
                If Drs.Length > 0 Then
                    If Drs(0).Item("Accessble") = False Then
                        Toolbar.Tools.Item(Dr("ItemKey")).SharedProps.Tag() = "NoAccess"
                    Else
                        Toolbar.Tools.Item(Dr("ItemKey")).SharedProps.Tag() = ""
                    End If
                End If
            End If

        Next
    End Sub

    Public Property ShowPrintButtom() As Boolean
        Get
            Return Me.Toolbar.Toolbars("TopToolbar").Tools("Print").SharedProps.Visible
        End Get
        Set(ByVal value As Boolean)
            Me.Toolbar.Toolbars("TopToolbar").Tools("Print").SharedProps.Visible = value
        End Set
    End Property

    Public Property ShowHistoryButtom() As Boolean
        Get
            Return Me.Toolbar.Toolbars("TopToolbar").Tools("History").SharedProps.Visible
        End Get
        Set(ByVal value As Boolean)
            Me.Toolbar.Toolbars("TopToolbar").Tools("History").SharedProps.Visible = value
        End Set
    End Property

    Public Property ShowNavigate() As Boolean
        Get
            Return Me.Toolbar.Toolbars("TopToolbar").Tools("NavigateContainer").SharedProps.Visible
        End Get
        Set(ByVal value As Boolean)
            Me.Toolbar.Toolbars("TopToolbar").Tools("NavigateContainer").SharedProps.Visible = value
        End Set
    End Property

    Public ReadOnly Property KeySelect() As String
        Get
            Return sKeySelect
        End Get
    End Property

    Public Sub AddCustomTools(ByVal Caption As String, ByVal Key As String, ByVal Img As Image)

        Dim Tools As New Infragistics.Win.UltraWinToolbars.ButtonTool(Key)
        Tools.SharedProps.Caption = Caption
        Tools.SharedProps.DisplayStyle = ToolDisplayStyle.ImageAndText
        Tools.SharedProps.AppearancesSmall.Appearance.Image = Img
        Tools.SharedProps.Visible = True
        Me.Toolbar.Tools.Add(Tools)
        Me.Toolbar.Toolbars("TopToolbar").Tools.Add(Tools)

    End Sub

    'For ILS Shortcuts: Added 
    Public Sub InitControlBatchUpdate(ByVal Title As String)
        userTabSelected = Title
    End Sub
  
    Public Shared Function getItemLevel(ByVal frmName As String)
        Dim formId As Integer
        If frmName = "FrmInwardBls" Then
            formId = 0
        ElseIf frmName = "FrmInquery" Then
            formId = 7
        ElseIf frmName = "FrmOutwardBls" Then
            formId = 100
        ElseIf frmName = "FrmPermits" Then
            formId = 102
        ElseIf frmName = "FrmEcs" Then
            formId = 200
        ElseIf frmName = "FrmSetelment" Then
            formId = 302
        ElseIf frmName = "FrmClientMerge" Then
            formId = 306
        ElseIf frmName = "FrmInwardDiscount" Then
            formId = 308
        ElseIf frmName = "FrmOutwardDiscount" Then
            formId = 309
        ElseIf frmName = "FrmVoyage" Then
            formId = 400
        ElseIf frmName = "FrmVessels" Then
            formId = 401
        ElseIf frmName = "FrmPorts" Then
            formId = 402
        ElseIf frmName = "FrmReferences" Then
            formId = 403
        ElseIf frmName = "FrmClients" Then
            formId = 404
        ElseIf frmName = "FrmUsers" Then
            formId = 405
        ElseIf frmName = "FrmBLCharges" Then
            formId = 406
        ElseIf frmName = "FrmDetentionBase" Then
            formId = 407
        ElseIf frmName = "FrmAgents" Then
            formId = 408
        ElseIf frmName = "FrmCluses" Then
            formId = 410
        ElseIf frmName = "FrmExchange" Then
            formId = 411
        ElseIf frmName = "FrmTaxBase" Then
            formId = 412
        ElseIf frmName = "FrmBooking" Then
            formId = 600
        ElseIf frmName = "FrmLines" Then
            formId = 703
        ElseIf frmName = "FrmEcsBank" Then
            formId = 999
        End If
        Return formId
    End Function

    'Existing modified for ILS Shortcuts
    Public Sub Toolbar_ToolClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinToolbars.ToolClickEventArgs) Handles Toolbar.ToolClick
        formId = getItemLevel(UserTabSelected)

        Try
            If e Is Nothing Then
                formId = getItemLevel(UserTabSelected)
                Call FindClick(sender, Convert.ToString(formId), False)
            Else
                sKeySelect = e.Tool.Key
                Select Case e.Tool.Key
                    Case "Find"
                        otherBtnClicked = ""
                        formId = getItemLevel(UserTabSelected)
                        Call FindClick(sender, formId, True)
                    Case "New"
                        otherBtnClicked = ""
                        formId = getItemLevel(UserTabSelected)
                        Call NewClick(sender, Convert.ToString(formId), True)
                    Case "Edit"
                        otherBtnClicked = "Edit"
                        formId = getItemLevel(UserTabSelected)
                        otherBtnClicked = otherBtnClicked & "Edit" & formId
                        Call EditClick(sender, Convert.ToString(formId), True)
                    Case "Save"
                        otherBtnClicked = ""
                        formId = getItemLevel(UserTabSelected)
                        Call SaveClick(sender, Convert.ToString(formId), True)
                    Case "Delete"
                        otherBtnClicked = ""
                        formId = getItemLevel(UserTabSelected)
                        Call DeleteClick(sender, Convert.ToString(formId), True)
                    Case "Print"
                        otherBtnClicked = ""
                        formId = getItemLevel(UserTabSelected)
                        Call PrintClick(sender, Convert.ToString(formId), True)
                    Case "History"
                        otherBtnClicked = ""
                        formId = getItemLevel(UserTabSelected)
                        Call HistoryClick(sender, Convert.ToString(formId), True)
                    Case "Close"
                        otherBtnClicked = ""
                        formId = getItemLevel(UserTabSelected)
                        Call CloseClick(sender, Convert.ToString(formId), True)
                    Case Else
                        otherBtnClicked = ""
                        formId = getItemLevel(UserTabSelected)
                        Call OthersClick(sender, Convert.ToString(formId), True)
                        'RaiseEvent CustomOthers()
                End Select
            End If
        Catch ex As Exception

        End Try

    End Sub

    Public Sub ButtonPickupClientMergeText_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Handles ButtonPickupClientMerge.Click

        If e Is Nothing Then
            formId = getItemLevel(UserTabSelected)
            If formId = 306 Then
                FrmClientMerge.ButtonPickupClientMergeText_Click(sender, e)
            End If
        Else
            formId = getItemLevel(UserTabSelected)
            If formId = 306 Then
                FrmClientMerge.ButtonPickupClientMergeText_Click(sender, e)
            End If
        End If

    End Sub

    Public Shared Sub FindClick(ByVal sender As System.Object, ByVal formId As Integer, ByVal isButtonClick As Boolean)
        Dim pos As Integer
        Dim poswithFrm As Integer

        pos = InStr(otherBtnClicked, "Edit")
        If (isButtonClick = False) Then 'Text box
            If pos = 0 Then
                If (formId = 0) Then
                    FrmInwardBls.GeneralForms_CustomFindClick(sender, formId)
                ElseIf (formId = 7) Then
                    FrmInquery.GeneralForms_CustomFindClick(sender, formId)
                ElseIf (formId = 100) Then
                    FrmOutwardBls.GeneralForms_CustomFindClick(sender, formId)
                ElseIf (formId = 102) Then
                    FrmPermits.GeneralForms_CustomFindClick(sender, formId)
                ElseIf (formId = 200) Then
                    FrmEcs.GeneralForms_CustomFindClick(sender, formId)
                ElseIf (formId = 302) Then
                    FrmSetelment.GeneralForms_CustomFindClick(sender, formId)
                ElseIf (formId = 308) Then
                    FrmInwardDiscount.GeneralForms_CustomFindClick(sender, formId)
                ElseIf (formId = 309) Then
                    FrmOutwardDiscount.GeneralForms_CustomFindClick(sender, formId)
                ElseIf (formId = 400) Then
                    FrmVoyage.GeneralForms_CustomFindClick(sender, formId)
                ElseIf (formId = 401) Then
                    FrmVessels.GeneralForms_CustomFindClick(sender, formId)
                ElseIf (formId = 999) Then
                    FrmEcsBank.GeneralForms_CustomFindClick(sender, formId)
                ElseIf (formId = 402) Then
                    FrmPorts.GeneralForms_CustomFindClick(sender, formId)
                ElseIf (formId = 403) Then
                    FrmReferences.GeneralForms_CustomFindClick(sender, formId)
                ElseIf (formId = 404) Then
                    FrmClients.GeneralForms_CustomFindClick(sender, formId)
                ElseIf (formId = 405) Then
                    FrmUsers.GeneralForms_CustomFindClick(sender, formId)
                ElseIf (formId = 406) Then
                    FrmBLCharges.GeneralForms_CustomFindClick(sender, formId)
                ElseIf (formId = 407) Then
                    FrmDetentionBase.GeneralForms_CustomFindClick(sender, formId)
                ElseIf (formId = 408) Then
                    FrmAgents.GeneralForms_CustomFindClick(sender, formId)
                ElseIf (formId = 410) Then
                    FrmCluses.GeneralForms_CustomFindClick(sender, formId)
                ElseIf (formId = 411) Then
                    FrmExchange.GeneralForms_CustomFindClick(sender, formId)
                ElseIf (formId = 412) Then
                    FrmTaxBase.GeneralForms_CustomFindClick(sender, formId)
                ElseIf (formId = 600) Then
                    FrmBooking.GeneralForms_CustomFindClick(sender, formId)
                ElseIf (formId = 703) Then
                    FrmLines.GeneralForms_CustomFindClick(sender, formId)
                End If
            Else
                poswithFrm = InStr(otherBtnClicked, formId)
                If poswithFrm = 0 Then
                    If (formId = 0) Then
                        FrmInwardBls.GeneralForms_CustomFindClick(sender, formId)
                    ElseIf (formId = 7) Then
                        FrmInquery.GeneralForms_CustomFindClick(sender, formId)
                    ElseIf (formId = 100) Then
                        FrmOutwardBls.GeneralForms_CustomFindClick(sender, formId)
                    ElseIf (formId = 102) Then
                        FrmPermits.GeneralForms_CustomFindClick(sender, formId)
                    ElseIf (formId = 200) Then
                        FrmEcs.GeneralForms_CustomFindClick(sender, formId)
                    ElseIf (formId = 302) Then
                        FrmSetelment.GeneralForms_CustomFindClick(sender, formId)
                    ElseIf (formId = 308) Then
                        FrmInwardDiscount.GeneralForms_CustomFindClick(sender, formId)
                    ElseIf (formId = 309) Then
                        FrmOutwardDiscount.GeneralForms_CustomFindClick(sender, formId)
                    ElseIf (formId = 400) Then
                        FrmVoyage.GeneralForms_CustomFindClick(sender, formId)
                    ElseIf (formId = 401) Then
                        FrmVessels.GeneralForms_CustomFindClick(sender, formId)
                    ElseIf (formId = 999) Then
                        FrmEcsBank.GeneralForms_CustomFindClick(sender, formId)
                    ElseIf (formId = 402) Then
                        FrmPorts.GeneralForms_CustomFindClick(sender, formId)
                    ElseIf (formId = 403) Then
                        FrmReferences.GeneralForms_CustomFindClick(sender, formId)
                    ElseIf (formId = 404) Then
                        FrmClients.GeneralForms_CustomFindClick(sender, formId)
                    ElseIf (formId = 405) Then
                        FrmUsers.GeneralForms_CustomFindClick(sender, formId)
                    ElseIf (formId = 406) Then
                        FrmBLCharges.GeneralForms_CustomFindClick(sender, formId)
                    ElseIf (formId = 407) Then
                        FrmDetentionBase.GeneralForms_CustomFindClick(sender, formId)
                    ElseIf (formId = 408) Then
                        FrmAgents.GeneralForms_CustomFindClick(sender, formId)
                    ElseIf (formId = 410) Then
                        FrmCluses.GeneralForms_CustomFindClick(sender, formId)
                    ElseIf (formId = 411) Then
                        FrmExchange.GeneralForms_CustomFindClick(sender, formId)
                    ElseIf (formId = 412) Then
                        FrmTaxBase.GeneralForms_CustomFindClick(sender, formId)
                    ElseIf (formId = 703) Then
                        FrmLines.GeneralForms_CustomFindClick(sender, formId)
                    ElseIf (formId = 600) Then
                        FrmBooking.GeneralForms_CustomFindClick(sender, formId)
                    End If
                End If
            End If
        ElseIf (isButtonClick = True) Then 'Toolbar
            If (formId = 0) Then
                FrmInwardBls.GeneralForms_CustomFindClick(sender, formId)
            ElseIf (formId = 7) Then
                FrmInquery.GeneralForms_CustomFindClick(sender, formId)
            ElseIf (formId = 100) Then
                FrmOutwardBls.GeneralForms_CustomFindClick(sender, formId)
            ElseIf (formId = 102) Then
                FrmPermits.GeneralForms_CustomFindClick(sender, formId)
            ElseIf (formId = 200) Then
                FrmEcs.GeneralForms_CustomFindClick(sender, formId)
            ElseIf (formId = 302) Then
                FrmSetelment.GeneralForms_CustomFindClick(sender, formId)
            ElseIf (formId = 308) Then
                FrmInwardDiscount.GeneralForms_CustomFindClick(sender, formId)
            ElseIf (formId = 309) Then
                FrmOutwardDiscount.GeneralForms_CustomFindClick(sender, formId)
            ElseIf (formId = 400) Then
                FrmVoyage.GeneralForms_CustomFindClick(sender, formId)
            ElseIf (formId = 401) Then
                FrmVessels.GeneralForms_CustomFindClick(sender, formId)
            ElseIf (formId = 999) Then
                FrmEcsBank.GeneralForms_CustomFindClick(sender, formId)

            ElseIf (formId = 402) Then
                FrmPorts.GeneralForms_CustomFindClick(sender, formId)
            ElseIf (formId = 403) Then
                FrmReferences.GeneralForms_CustomFindClick(sender, formId)
            ElseIf (formId = 404) Then
                FrmClients.GeneralForms_CustomFindClick(sender, formId)
            ElseIf (formId = 405) Then
                FrmUsers.GeneralForms_CustomFindClick(sender, formId)
            ElseIf (formId = 406) Then
                FrmBLCharges.GeneralForms_CustomFindClick(sender, formId)
            ElseIf (formId = 407) Then
                FrmDetentionBase.GeneralForms_CustomFindClick(sender, formId)
            ElseIf (formId = 408) Then
                FrmAgents.GeneralForms_CustomFindClick(sender, formId)
            ElseIf (formId = 410) Then
                FrmCluses.GeneralForms_CustomFindClick(sender, formId)
            ElseIf (formId = 411) Then
                FrmExchange.GeneralForms_CustomFindClick(sender, formId)
            ElseIf (formId = 412) Then
                FrmTaxBase.GeneralForms_CustomFindClick(sender, formId)
            ElseIf (formId = 600) Then
                FrmBooking.GeneralForms_CustomFindClick(sender, formId)
            ElseIf (formId = 703) Then
                FrmLines.GeneralForms_CustomFindClick(sender, formId)
            End If
        End If
    End Sub

    Public Shared Sub NewClick(ByVal sender As System.Object, ByVal formId As Integer, ByVal isButtonClick As Boolean)
        If (formId = 0) Then
            FrmInwardBls.GeneralForms_CustomNewClick(sender, formId)
        ElseIf (formId = 7) Then
            FrmInquery.GeneralForms_CustomNewClick(sender, formId)
        ElseIf (formId = 100) Then
            FrmOutwardBls.GeneralForms_CustomNewClick(sender, formId)
        ElseIf (formId = 102) Then
            FrmPermits.GeneralForms_CustomNewClick(sender, formId)
        ElseIf (formId = 302) Then
            FrmSetelment.GeneralForms_CustomNewClick(sender, formId)
        ElseIf (formId = 308) Then
            FrmInwardDiscount.GeneralForms_CustomNewClick(sender, formId)
        ElseIf (formId = 309) Then
            FrmOutwardDiscount.GeneralForms_CustomNewClick(sender, formId)
        ElseIf (formId = 400) Then
            FrmVoyage.GeneralForms_CustomNewClick(sender, formId)
        ElseIf (formId = 401) Then
            FrmVessels.GeneralForms_CustomNewClick(sender, formId)
        ElseIf (formId = 999) Then
            FrmEcsBank.GeneralForms_CustomNewClick(sender, formId)
        ElseIf (formId = 402) Then
            FrmPorts.GeneralForms_CustomNewClick(sender, formId)
        ElseIf (formId = 403) Then
            FrmReferences.GeneralForms_CustomNewClick(sender, formId)
        ElseIf (formId = 404) Then
            FrmClients.GeneralForms_CustomNewClick(sender, formId)
        ElseIf (formId = 405) Then
            FrmUsers.GeneralForms_CustomNewClick(sender, formId)
        ElseIf (formId = 406) Then
            FrmBLCharges.GeneralForms_CustomNewClick(sender, formId)
        ElseIf (formId = 407) Then
            FrmDetentionBase.GeneralForms_CustomNewClick(sender, formId)
        ElseIf (formId = 408) Then
            FrmAgents.GeneralForms_CustomNewClick(sender, formId)
        ElseIf (formId = 410) Then
            FrmCluses.GeneralForms_CustomNewClick(sender, formId)
        ElseIf (formId = 411) Then
            FrmExchange.GeneralForms_CustomNewClick(sender, formId)
        ElseIf (formId = 412) Then
            FrmTaxBase.GeneralForms_CustomNewClick(sender, formId)
        ElseIf (formId = 600) Then
            FrmBooking.GeneralForms_CustomNewClick(sender, formId)
        ElseIf (formId = 703) Then
            FrmLines.GeneralForms_CustomNewClick(sender, formId)
        End If

    End Sub

    Public Shared Sub EditClick(ByVal sender As System.Object, ByVal formId As Integer, ByVal isButtonClick As Boolean)
        If (formId = 0) Then
            FrmInwardBls.GeneralForms_CustomEditClick(sender, formId)
        ElseIf (formId = 7) Then
            FrmInquery.GeneralForms_CustomEditClick(sender, formId)
        ElseIf (formId = 100) Then
            FrmOutwardBls.GeneralForms_CustomEditClick(sender, formId)
        ElseIf (formId = 102) Then
            FrmPermits.GeneralForms_CustomEditClick(sender, formId)
        ElseIf (formId = 200) Then
            FrmEcs.GeneralForms_CustomEditClick(sender, formId)
        ElseIf (formId = 302) Then
            FrmSetelment.GeneralForms_CustomEditClick(sender, formId)
        ElseIf (formId = 308) Then
            FrmInwardDiscount.GeneralForms_CustomEditClick(sender, formId)
        ElseIf (formId = 309) Then
            FrmOutwardDiscount.GeneralForms_CustomEditClick(sender, formId)
        ElseIf (formId = 400) Then
            FrmVoyage.GeneralForms_CustomEditClick(sender, formId)
        ElseIf (formId = 401) Then
            FrmVessels.GeneralForms_CustomEditClick(sender, formId)
        ElseIf (formId = 999) Then
            FrmEcsBank.GeneralForms_CustomEditClick(sender, formId)
        ElseIf (formId = 402) Then
            FrmPorts.GeneralForms_CustomEditClick(sender, formId)
        ElseIf (formId = 403) Then
            FrmReferences.GeneralForms_CustomEditClick(sender, formId)
        ElseIf (formId = 404) Then
            FrmClients.GeneralForms_CustomEditClick(sender, formId)
        ElseIf (formId = 405) Then
            FrmUsers.GeneralForms_CustomEditClick(sender, formId)
        ElseIf (formId = 406) Then
            FrmBLCharges.GeneralForms_CustomEditClick(sender, formId)
        ElseIf (formId = 407) Then
            FrmDetentionBase.GeneralForms_CustomEditClick(sender, formId)
        ElseIf (formId = 408) Then
            FrmAgents.GeneralForms_CustomEditClick(sender, formId)
        ElseIf (formId = 410) Then
            FrmCluses.GeneralForms_CustomEditClick(sender, formId)
        ElseIf (formId = 411) Then
            FrmExchange.GeneralForms_CustomEditClick(sender, formId)
        ElseIf (formId = 412) Then
            FrmTaxBase.GeneralForms_CustomEditClick(sender, formId)
        ElseIf (formId = 600) Then
            FrmBooking.GeneralForms_CustomEditClick(sender, formId)
        ElseIf (formId = 703) Then
            FrmLines.GeneralForms_CustomEditClick(sender, formId)
        End If

    End Sub

    Public Shared Sub SaveClick(ByVal sender As System.Object, ByVal formId As Integer, ByVal isButtonClick As Boolean)
        If (formId = 0) Then
            FrmInwardBls.GeneralForms_CustomSaveClick(sender, formId)
        ElseIf (formId = 7) Then
            FrmInquery.GeneralForms_CustomSaveClick(sender, formId)
        ElseIf (formId = 100) Then
            FrmOutwardBls.GeneralForms_CustomSaveClick(sender, formId)
        ElseIf (formId = 102) Then
            FrmPermits.GeneralForms_CustomSaveClick(sender, formId)
        ElseIf (formId = 200) Then
            FrmEcs.GeneralForms_CustomSaveClick(sender, formId)
        ElseIf (formId = 302) Then
            FrmSetelment.GeneralForms_CustomSaveClick(sender, formId)
        ElseIf (formId = 308) Then
            FrmInwardDiscount.GeneralForms_CustomSaveClick(sender, formId)
        ElseIf (formId = 309) Then
            FrmOutwardDiscount.GeneralForms_CustomSaveClick(sender, formId)
        ElseIf (formId = 400) Then
            FrmVoyage.GeneralForms_CustomSaveClick(sender, formId)
        ElseIf (formId = 401) Then
            FrmVessels.GeneralForms_CustomSaveClick(sender, formId)
        ElseIf (formId = 999) Then
            FrmEcsBank.GeneralForms_CustomSaveClick(sender, formId)
        ElseIf (formId = 402) Then
            FrmPorts.GeneralForms_CustomSaveClick(sender, formId)
        ElseIf (formId = 403) Then
            FrmReferences.GeneralForms_CustomSaveClick(sender, formId)
        ElseIf (formId = 404) Then
            FrmClients.GeneralForms_CustomSaveClick(sender, formId)
        ElseIf (formId = 405) Then
            FrmUsers.GeneralForms_CustomSaveClick(sender, formId)
        ElseIf (formId = 406) Then
            FrmBLCharges.GeneralForms_CustomSaveClick(sender, formId)
        ElseIf (formId = 407) Then
            FrmDetentionBase.GeneralForms_CustomSaveClick(sender, formId)
        ElseIf (formId = 408) Then
            FrmAgents.GeneralForms_CustomSaveClick(sender, formId)
        ElseIf (formId = 410) Then
            FrmCluses.GeneralForms_CustomSaveClick(sender, formId)
        ElseIf (formId = 411) Then
            FrmExchange.GeneralForms_CustomSaveClick(sender, formId)
        ElseIf (formId = 412) Then
            FrmTaxBase.GeneralForms_CustomSaveClick(sender, formId)
        ElseIf (formId = 600) Then
            FrmBooking.GeneralForms_CustomSaveClick(sender, formId)
        ElseIf (formId = 703) Then
            FrmLines.GeneralForms_CustomSaveClick(sender, formId)
        End If
    End Sub

    Public Shared Sub DeleteClick(ByVal sender As System.Object, ByVal formId As Integer, ByVal isButtonClick As Boolean)
        If (formId = 0) Then
            FrmInwardBls.GeneralForms_CustomDeleteClick(sender, formId)
        ElseIf (formId = 100) Then
            FrmOutwardBls.GeneralForms_CustomDeleteClick(sender, formId)
        ElseIf (formId = 102) Then
            FrmPermits.GeneralForms_CustomDeleteClick(sender, formId)
        ElseIf (formId = 200) Then
            FrmEcs.GeneralForms_CustomDeleteClick(sender, formId)
        ElseIf (formId = 308) Then
            FrmInwardDiscount.GeneralForms_CustomDeleteClick(sender, formId)
        ElseIf (formId = 309) Then
            FrmOutwardDiscount.GeneralForms_CustomDeleteClick(sender, formId)
        ElseIf (formId = 400) Then
            FrmVoyage.GeneralForms_CustomDeleteClick(sender, formId)
        ElseIf (formId = 401) Then
            FrmVessels.GeneralForms_CustomDeleteClick(sender, formId)
        ElseIf (formId = 999) Then
            FrmEcsBank.GeneralForms_CustomDeleteClick(sender, formId)
        ElseIf (formId = 402) Then
            FrmPorts.GeneralForms_CustomDeleteClick(sender, formId)
        ElseIf (formId = 403) Then
            FrmReferences.GeneralForms_CustomDeleteClick(sender, formId)
        ElseIf (formId = 404) Then
            FrmClients.GeneralForms_CustomDeleteClick(sender, formId)
        ElseIf (formId = 405) Then
            FrmUsers.GeneralForms_CustomDeleteClick(sender, formId)
        ElseIf (formId = 406) Then
            FrmBLCharges.GeneralForms_CustomDeleteClick(sender, formId)
        ElseIf (formId = 407) Then
            FrmDetentionBase.GeneralForms_CustomDeleteClick(sender, formId)
        ElseIf (formId = 408) Then
            FrmAgents.GeneralForms_CustomDeleteClick(sender, formId)
        ElseIf (formId = 410) Then
            FrmCluses.GeneralForms_CustomDeleteClick(sender, formId)
        ElseIf (formId = 411) Then
            FrmExchange.GeneralForms_CustomDeleteClick(sender, formId)
        ElseIf (formId = 412) Then
            FrmTaxBase.GeneralForms_CustomDeleteClick(sender, formId)
        ElseIf (formId = 600) Then
            FrmBooking.GeneralForms_CustomDeleteClick(sender, formId)
        ElseIf (formId = 703) Then
            FrmLines.GeneralForms_CustomDeleteClick(sender, formId)
        End If
    End Sub
    
    Public Shared Sub PrintClick(ByVal sender As System.Object, ByVal formId As Integer, ByVal isButtonClick As Boolean)
        If (formId = 0) Then
            FrmInwardBls.GeneralForms_CustomPrintClick(sender, formId)
        ElseIf (formId = 600) Then
            FrmBooking.GeneralForms_CustomPrintClick(sender, formId)
        ElseIf (formId = 100) Then
            FrmOutwardBls.GeneralForms_CustomPrintClick(sender, formId)
        End If
    End Sub

    Public Shared Sub HistoryClick(ByVal sender As System.Object, ByVal formId As Integer, ByVal isButtonClick As Boolean)
        If (formId = 0) Then
            FrmInwardBls.GeneralForms_CustomHistory(sender, formId)
        ElseIf (formId = 100) Then
            FrmOutwardBls.GeneralForms_CustomHistory(sender, formId)
        ElseIf (formId = 200) Then
            FrmEcs.GeneralForms_CustomHistory(sender, formId)
        End If
    End Sub

    Public Shared Sub CloseClick(ByVal sender As System.Object, ByVal formId As Integer, ByVal isButtonClick As Boolean)

    End Sub

    Public Shared Sub OthersClick(ByVal sender As System.Object, ByVal formId As Integer, ByVal isButtonClick As Boolean)
        If (formId = 0) Then
            FrmInwardBls.GeneralForms_CustomOthers(sender, formId)
        ElseIf (formId = 100) Then
            FrmOutwardBls.GeneralForms_CustomOthers(sender, formId)
        ElseIf (formId = 200) Then
            FrmEcs.GeneralForms_CustomOthers(sender, formId)
        ElseIf (formId = 308) Then
            FrmInwardDiscount.GeneralForms_CustomOthers(sender, formId)
        ElseIf (formId = 404) Then
            FrmClients.GeneralForms_CustomOthers(sender, formId)
        ElseIf (formId = 406) Then
            FrmBLCharges.GeneralForms_CustomOthers(sender, formId)
        ElseIf (formId = 407) Then
            FrmDetentionBase.GeneralForms_CustomOthers(sender, formId)
        ElseIf (formId = 600) Then
            FrmBooking.GeneralForms_CustomOthers(sender, formId)
        End If
    End Sub
    'For ILS Shortcuts: End   
End Class
