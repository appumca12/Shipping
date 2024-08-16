Imports OrmLib
Imports ShippingBiz
Public Class UserMenuItem


    Public Event CustomPickupClick()
    Public Event CustomNewClick()
    Public Event CustomEditClick()
    Public Event CustomSaveClick()
    Public Event CustomDeleteClick()
    Public Event CustomPrintClick()
    Public Event CustomRefreshClick()
    Public Event CustomRestClick()
    Public Event CustomConfirmClick()
    Public Event CustomCancelClick()
    Public Event CustomOpenFileClick()
    Public Event CustomRecivedItemsClick()
    Public Event CustomToExcelClick()
    Public Event CustomDeposits()
    Public Event CustomProcess()
    Public Event CustomSelectAll()
    Public Event CustomDeSelectAll()
    Public Event CustomAdditional()


    Public Property ShowPickup() As Boolean
        Get
            Return ButtonPickup.Visible
        End Get
        Set(ByVal value As Boolean)
            ButtonPickup.Visible = value
        End Set
    End Property

    Public Property ShowEdit() As Boolean
        Get
            Return ButtonEdit.Visible
        End Get
        Set(ByVal value As Boolean)
            ButtonEdit.Visible = value
        End Set
    End Property

    Public Property ShowNew() As Boolean
        Get
            Return ButtonNew.Visible
        End Get
        Set(ByVal value As Boolean)
            ButtonNew.Visible = value
        End Set
    End Property

    Public Property ShowDelete() As Boolean
        Get
            Return ButtonDelete.Visible
        End Get
        Set(ByVal value As Boolean)
            ButtonDelete.Visible = value
        End Set
    End Property

    Public Property ShowSave() As Boolean
        Get
            Return ButtonSave.Visible
        End Get
        Set(ByVal value As Boolean)
            ButtonSave.Visible = value
        End Set
    End Property
    Public Property ShowPrint() As Boolean
        Get
            Return ButtonPrint.Visible
        End Get
        Set(ByVal value As Boolean)
            ButtonPrint.Visible = value
        End Set
    End Property
    Public Property ShowRest() As Boolean
        Get
            Return ButtonReset.Visible
        End Get
        Set(ByVal value As Boolean)
            ButtonReset.Visible = value
        End Set
    End Property
    Public Property ShowRefresh() As Boolean
        Get
            Return ButtonRefresh.Visible
        End Get
        Set(ByVal value As Boolean)
            ButtonRefresh.Visible = value
        End Set
    End Property
    Public Property ShowConfirm() As Boolean
        Get
            Return ButtonConfirm.Visible
        End Get
        Set(ByVal value As Boolean)
            ButtonConfirm.Visible = value
        End Set
    End Property
    Public Property ShowCancel() As Boolean
        Get
            Return ButtonCancel.Visible
        End Get
        Set(ByVal value As Boolean)
            ButtonCancel.Visible = value
        End Set
    End Property
    Public Property ShowRecivedItems() As Boolean
        Get
            Return ButtonRecivedItems.Visible
        End Get
        Set(ByVal value As Boolean)
            ButtonRecivedItems.Visible = value
        End Set
    End Property
    Public Property ShowFileOpen() As Boolean
        Get
            Return ButtonOpenFile.Visible
        End Get
        Set(ByVal value As Boolean)
            ButtonOpenFile.Visible = value
        End Set
    End Property
    Public Property ShowExcel() As Boolean
        Get
            Return ButtonExcel.Visible
        End Get
        Set(ByVal value As Boolean)
            ButtonExcel.Visible = value
        End Set
    End Property
    Public Property ShowDeposits() As Boolean
        Get
            Return ButtonDeposits.Visible
        End Get
        Set(ByVal value As Boolean)
            ButtonDeposits.Visible = value
        End Set
    End Property
    Public Property ShowProcess() As Boolean
        Get
            Return ButtonProcess.Visible
        End Get
        Set(ByVal value As Boolean)
            ButtonProcess.Visible = value
        End Set
    End Property
    Public Property ShowSelectAll() As Boolean
        Get
            Return ButtonSelectAll.Visible
        End Get
        Set(ByVal value As Boolean)
            ButtonSelectAll.Visible = value
        End Set
    End Property
    Public Property ShowDeSelectAll() As Boolean
        Get
            Return ButtonDeselectAll.Visible
        End Get
        Set(ByVal value As Boolean)
            ButtonDeselectAll.Visible = value
        End Set
    End Property
    Public Property ShowAdditional() As Boolean
        Get
            Return ButtonAdditional.Visible
        End Get
        Set(ByVal value As Boolean)
            ButtonAdditional.Visible = value
        End Set
    End Property

    Private Sub ButtonPickup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPickup.Click
        RaiseEvent CustomPickupClick()
    End Sub

    Private Sub ButtonNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNew.Click
        RaiseEvent CustomNewClick()
    End Sub

    Private Sub ButtonEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEdit.Click
        RaiseEvent CustomEditClick()
    End Sub

    Private Sub ButtonSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSave.Click
        RaiseEvent CustomSaveClick()
    End Sub

    Private Sub ButtonDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDelete.Click
        RaiseEvent CustomDeleteClick()
    End Sub

    Private Sub ButtonRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRefresh.Click
        RaiseEvent CustomRefreshClick()
    End Sub

    Private Sub ButtonPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPrint.Click
        RaiseEvent CustomPrintClick()
    End Sub

    Private Sub ButtonrReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonReset.Click
        RaiseEvent CustomRestClick()
    End Sub

    Private Sub ButtonConfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonConfirm.Click
        RaiseEvent CustomConfirmClick()
    End Sub

    Private Sub ButtonCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancel.Click
        RaiseEvent CustomCancelClick()
    End Sub

    Private Sub ButtonOpenFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonOpenFile.Click
        RaiseEvent CustomOpenFileClick()
    End Sub

    Private Sub ButtonRecivedItems_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonRecivedItems.Click
        RaiseEvent CustomRecivedItemsClick()
    End Sub
    'Public Sub CustomSetAdditonalItem(ByVal Caption As String)
    '    Me.GnrlToolStrip.Items("ButtonAdditional").Text = Caption
    'End Sub
    Public Sub CustomSetAdditonalItem(ByVal Caption As String, ByVal Img As Image)
        Me.GnrlToolStrip.Items("ButtonAdditional").Text = Caption
        Me.GnrlToolStrip.Items("ButtonAdditional").Image = Img
    End Sub

    Public Sub MenuItemsSetupOutSide(ByVal ItemLevel As String)

        Dim DM As New DataManager(My.Settings.DSN)
        Dim Menu As TB_MenuItems
        Dim Menus As TB_MenuItemsCollection
        Dim ItemLevelID As Guid

        Dim Items As TB_AccessLevelCollection
        Dim Item As TB_AccessLevel

        DM.QueryCriteria.And(JoinPath.TB_MenuItems.Columns.ItemLevel, ItemLevel & "0", MatchType.StartsWith)
        Menus = DM.GetTB_MenuItemsCollection

        If Menus Is Nothing Then
            Exit Sub
        End If

        For Each Menu In Menus
            ItemLevelID = Menu.ID
            DM.QueryCriteria.Clear()
            DM.QueryCriteria.And(JoinPath.TB_AccessLevel.Columns.MenuItemID, ItemLevelID, MatchType.Exact)
            DM.QueryCriteria.And(JoinPath.TB_AccessLevel.Columns.UserID, CurrentUser.ID, MatchType.Exact)
            Items = DM.GetTB_AccessLevelCollection
            If Not Items Is Nothing Then
                For Each Item In Items
                    Me.GnrlToolStrip.Items(Menu.ItemKey).Visible = Item.Accessble
                Next
            End If
        Next

    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExcel.Click
        RaiseEvent CustomToExcelClick()
    End Sub

    Private Sub ButtonDeposits_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDeposits.Click
        RaiseEvent CustomDeposits()
    End Sub
    Private Sub ButtonProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonProcess.Click
        RaiseEvent CustomProcess()
    End Sub

    Private Sub ButtonSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSelectAll.Click
        RaiseEvent CustomSelectAll()
    End Sub
    Private Sub ButtonDeselectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDeselectAll.Click
        RaiseEvent CustomDeSelectAll()
    End Sub

    Private Sub ButtonAdditional_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonAdditional.Click
        RaiseEvent CustomAdditional()
    End Sub

    Public Sub CustomSetAdditonalItem(ByVal Caption As String)
        Me.GnrlToolStrip.Items("ButtonAdditional").Text = Caption
    End Sub




End Class
