Imports ShippingBiz
Imports OrmLib
Public Class CLGeneralForm

    Inherits Form
    Public Event ToolStripClick()
    Private components As System.ComponentModel.IContainer
    Friend WithEvents MenuStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents BTNFind As System.Windows.Forms.ToolStripButton
    Friend WithEvents BTNNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents BTNEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents BTNSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents BTNDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Private BTN As String

    Private Sub InitializeComponent()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.MenuStrip = New System.Windows.Forms.ToolStrip
        Me.BTNFind = New System.Windows.Forms.ToolStripButton
        Me.BTNNew = New System.Windows.Forms.ToolStripButton
        Me.BTNEdit = New System.Windows.Forms.ToolStripButton
        Me.BTNSave = New System.Windows.Forms.ToolStripButton
        Me.BTNDelete = New System.Windows.Forms.ToolStripButton
        Me.TableLayoutPanel1.SuspendLayout()
        Me.MenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.MenuStrip, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(449, 358)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'MenuStrip
        '
        Me.MenuStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BTNFind, Me.BTNNew, Me.BTNEdit, Me.BTNSave, Me.BTNDelete})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(449, 31)
        Me.MenuStrip.TabIndex = 0
        Me.MenuStrip.Text = "ToolStrip1"
        '
        'BTNFind
        '
        Me.BTNFind.Image = Global.Shipping.My.Resources.Resources.search_24
        Me.BTNFind.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BTNFind.Name = "BTNFind"
        Me.BTNFind.Size = New System.Drawing.Size(55, 28)
        Me.BTNFind.Text = "Find"
        '
        'BTNNew
        '
        Me.BTNNew.Image = Global.Shipping.My.Resources.Resources.documents_24
        Me.BTNNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BTNNew.Name = "BTNNew"
        Me.BTNNew.Size = New System.Drawing.Size(56, 28)
        Me.BTNNew.Text = "New"
        '
        'BTNEdit
        '
        Me.BTNEdit.Image = Global.Shipping.My.Resources.Resources.edit_24
        Me.BTNEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BTNEdit.Name = "BTNEdit"
        Me.BTNEdit.Size = New System.Drawing.Size(53, 28)
        Me.BTNEdit.Text = "Edit"
        '
        'BTNSave
        '
        Me.BTNSave.Image = Global.Shipping.My.Resources.Resources.save_24
        Me.BTNSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BTNSave.Name = "BTNSave"
        Me.BTNSave.Size = New System.Drawing.Size(59, 28)
        Me.BTNSave.Text = "Save"
        '
        'BTNDelete
        '
        Me.BTNDelete.Image = Global.Shipping.My.Resources.Resources.delete_24
        Me.BTNDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BTNDelete.Name = "BTNDelete"
        Me.BTNDelete.Size = New System.Drawing.Size(66, 28)
        Me.BTNDelete.Text = "Delete"
        '
        'CLGeneralForm
        '
        Me.ClientSize = New System.Drawing.Size(449, 358)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "CLGeneralForm"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Private Sub SetLevelAccess(ByVal Level As String)

        Dim Dm As New DataManager(My.Settings.DSN)
        Dim Dr As DataRow
        Dim Drs() As DataRow
        Dim CtrlName As String
        Dim ctrl As ToolStripButton

        Dm.QueryCriteria.And(JoinPath.TB_AccessLevel.Columns.UserID, CurrentUser.ID.ToString, MatchType.Exact)
        Dm.GetTB_AccessLevelCollection()
        Dm.QueryCriteria.Clear()

        Dm.QueryCriteria.And(JoinPath.TB_MenuItems.Columns.ItemLevel, Level, MatchType.StartsWith)
        Dm.GetTB_MenuItemsCollection()

        For Each Dr In Dm.DataSet.Tables("Tb_MenuItems").Rows
            If Len(Dr("ItemLevel")) > 3 Then
                Drs = Dm.DataSet.Tables("Tb_AccessLevel").Select("MenuItemID = '" & Dr("ID").ToString & "'")
                If Drs.Length > 0 Then
                    CtrlName = "BTN" & Dr("ItemKey")
                    ctrl = Me.MenuStrip.Items(CtrlName)
                    If Drs(0).Item("Accessble") = False Then
                        ctrl.Tag = "NoAccess"
                    Else
                        ctrl.Tag = ""
                    End If
                End If
            End If

        Next
    End Sub

    Public Sub New()
        InitializeComponent()
    End Sub
    Public Sub InitControl(ByVal Title As String)
        'Me.Toolbar.Toolbars("FormCaption").Tools.Item(0).SharedProps.Caption = Title
        'Me.Toolbar.Toolbars("FormCaption").Settings.Appearance.BackColor = My.Settings.MainColor
        'Me.Toolbar.Toolbars("FormCaption").Settings.Appearance.BackColor2 = My.Settings.MainColor2
        Me.BackColor = My.Settings.MainColor

    End Sub
    Public Sub InitControl(ByVal Title As String, ByVal Level As String)
        'Me.Toolbar.Toolbars("FormCaption").Tools.Item(0).SharedProps.Caption = Title
        'Me.Toolbar.Toolbars("FormCaption").Settings.Appearance.BackColor = My.Settings.MainColor
        'Me.Toolbar.Toolbars("FormCaption").Settings.Appearance.BackColor2 = My.Settings.MainColor2
        Me.BackColor = My.Settings.MainColor

        SetLevelAccess(Level)
    End Sub

    Private Sub MenuStrip_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuStrip.Click


        BTN = ""
        RaiseEvent ToolStripClick()
    End Sub

    Public ReadOnly Property SelectedButton() As String
        Get
            Return BTN
        End Get
    End Property



End Class
