<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserGeneralForms
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim UltraToolbar1 As Infragistics.Win.UltraWinToolbars.UltraToolbar = New Infragistics.Win.UltraWinToolbars.UltraToolbar("TopToolbar")
        Dim ButtonTool1 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Find")
        Dim ButtonTool2 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("New")
        Dim ButtonTool3 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Edit")
        Dim ButtonTool4 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Save")
        Dim ButtonTool5 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Delete")
        Dim ButtonTool6 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Print")
        Dim ButtonTool7 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("History")
        Dim ControlContainerTool1 As Infragistics.Win.UltraWinToolbars.ControlContainerTool = New Infragistics.Win.UltraWinToolbars.ControlContainerTool("NavigateContainer")
        Dim ButtonTool8 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Find")
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserGeneralForms))
        Dim ButtonTool9 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("New")
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool10 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Save")
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool11 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Delete")
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool12 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Edit")
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool13 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Print")
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ControlContainerTool2 As Infragistics.Win.UltraWinToolbars.ControlContainerTool = New Infragistics.Win.UltraWinToolbars.ControlContainerTool("NavigateContainer")
        Dim ButtonTool14 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("History")
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.FillPanel = New System.Windows.Forms.Panel()
        Me._UserGeneralForms_Toolbars_Dock_Area_Left = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me._UserGeneralForms_Toolbars_Dock_Area_Right = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me._UserGeneralForms_Toolbars_Dock_Area_Top = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me._UserGeneralForms_Toolbars_Dock_Area_Bottom = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me.DS = New System.Data.DataSet()
        Me.Navigate = New Shipping.UserNavigate()
        Me.Toolbar = New Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(Me.components)
        Me.FillPanel.SuspendLayout()
        CType(Me.DS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Toolbar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FillPanel
        '
        Me.FillPanel.BackColor = System.Drawing.Color.CornflowerBlue
        Me.FillPanel.Controls.Add(Me.Navigate)
        Me.FillPanel.Cursor = System.Windows.Forms.Cursors.Default
        Me.FillPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FillPanel.Location = New System.Drawing.Point(0, 36)
        Me.FillPanel.Name = "FillPanel"
        Me.FillPanel.Size = New System.Drawing.Size(599, 352)
        Me.FillPanel.TabIndex = 0
        '
        '_UserGeneralForms_Toolbars_Dock_Area_Left
        '
        Me._UserGeneralForms_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._UserGeneralForms_Toolbars_Dock_Area_Left.AlphaBlendMode = Infragistics.Win.AlphaBlendMode.Disabled
        Me._UserGeneralForms_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(215, Byte), Integer))
        Me._UserGeneralForms_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left
        Me._UserGeneralForms_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText
        Me._UserGeneralForms_Toolbars_Dock_Area_Left.Location = New System.Drawing.Point(0, 36)
        Me._UserGeneralForms_Toolbars_Dock_Area_Left.Name = "_UserGeneralForms_Toolbars_Dock_Area_Left"
        Me._UserGeneralForms_Toolbars_Dock_Area_Left.Size = New System.Drawing.Size(0, 352)
        Me._UserGeneralForms_Toolbars_Dock_Area_Left.ToolbarsManager = Me.Toolbar
        '
        '_UserGeneralForms_Toolbars_Dock_Area_Right
        '
        Me._UserGeneralForms_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._UserGeneralForms_Toolbars_Dock_Area_Right.AlphaBlendMode = Infragistics.Win.AlphaBlendMode.Disabled
        Me._UserGeneralForms_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(215, Byte), Integer))
        Me._UserGeneralForms_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right
        Me._UserGeneralForms_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText
        Me._UserGeneralForms_Toolbars_Dock_Area_Right.Location = New System.Drawing.Point(599, 36)
        Me._UserGeneralForms_Toolbars_Dock_Area_Right.Name = "_UserGeneralForms_Toolbars_Dock_Area_Right"
        Me._UserGeneralForms_Toolbars_Dock_Area_Right.Size = New System.Drawing.Size(0, 352)
        Me._UserGeneralForms_Toolbars_Dock_Area_Right.ToolbarsManager = Me.Toolbar
        '
        '_UserGeneralForms_Toolbars_Dock_Area_Top
        '
        Me._UserGeneralForms_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._UserGeneralForms_Toolbars_Dock_Area_Top.AlphaBlendMode = Infragistics.Win.AlphaBlendMode.Disabled
        Me._UserGeneralForms_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(215, Byte), Integer))
        Me._UserGeneralForms_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top
        Me._UserGeneralForms_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText
        Me._UserGeneralForms_Toolbars_Dock_Area_Top.Location = New System.Drawing.Point(0, 0)
        Me._UserGeneralForms_Toolbars_Dock_Area_Top.Name = "_UserGeneralForms_Toolbars_Dock_Area_Top"
        Me._UserGeneralForms_Toolbars_Dock_Area_Top.Size = New System.Drawing.Size(599, 36)
        Me._UserGeneralForms_Toolbars_Dock_Area_Top.ToolbarsManager = Me.Toolbar
        '
        '_UserGeneralForms_Toolbars_Dock_Area_Bottom
        '
        Me._UserGeneralForms_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._UserGeneralForms_Toolbars_Dock_Area_Bottom.AlphaBlendMode = Infragistics.Win.AlphaBlendMode.Disabled
        Me._UserGeneralForms_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(215, Byte), Integer))
        Me._UserGeneralForms_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom
        Me._UserGeneralForms_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText
        Me._UserGeneralForms_Toolbars_Dock_Area_Bottom.Location = New System.Drawing.Point(0, 388)
        Me._UserGeneralForms_Toolbars_Dock_Area_Bottom.Name = "_UserGeneralForms_Toolbars_Dock_Area_Bottom"
        Me._UserGeneralForms_Toolbars_Dock_Area_Bottom.Size = New System.Drawing.Size(599, 0)
        Me._UserGeneralForms_Toolbars_Dock_Area_Bottom.ToolbarsManager = Me.Toolbar
        '
        'DS
        '
        Me.DS.DataSetName = "NewDataSet"
        '
        'Navigate
        '
        Me.Navigate.Location = New System.Drawing.Point(496, 360)
        Me.Navigate.Name = "Navigate"
        Me.Navigate.Size = New System.Drawing.Size(97, 28)
        Me.Navigate.TabIndex = 6
        Me.Navigate.Visible = False
        '
        'Toolbar
        '
        Me.Toolbar.AlphaBlendMode = Infragistics.Win.AlphaBlendMode.Disabled
        Me.Toolbar.DesignerFlags = 1
        Me.Toolbar.DockWithinContainer = Me
        Me.Toolbar.ImageSizeSmall = New System.Drawing.Size(24, 24)
        Me.Toolbar.LockToolbars = True
        Me.Toolbar.ShowFullMenusDelay = 500
        Me.Toolbar.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.VisualStudio2005
        UltraToolbar1.DockedColumn = 0
        UltraToolbar1.DockedRow = 0
        UltraToolbar1.FloatingLocation = New System.Drawing.Point(167, 165)
        UltraToolbar1.FloatingSize = New System.Drawing.Size(375, 52)
        ControlContainerTool1.ControlName = "Navigate"
        UltraToolbar1.NonInheritedTools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool1, ButtonTool2, ButtonTool3, ButtonTool4, ButtonTool5, ButtonTool6, ButtonTool7, ControlContainerTool1})
        UltraToolbar1.Text = "TopToolbar"
        Me.Toolbar.Toolbars.AddRange(New Infragistics.Win.UltraWinToolbars.UltraToolbar() {UltraToolbar1})
        Appearance1.Image = CType(resources.GetObject("Appearance1.Image"), Object)
        ButtonTool8.SharedPropsInternal.AppearancesSmall.Appearance = Appearance1
        ButtonTool8.SharedPropsInternal.Caption = "Find"
        ButtonTool8.SharedPropsInternal.Shortcut = Shortcut.CtrlF
        ButtonTool8.SharedPropsInternal.ToolTipText = "Shortcut Ctrl+F"
        ButtonTool8.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText
        Appearance2.Image = CType(resources.GetObject("Appearance2.Image"), Object)
        ButtonTool9.SharedPropsInternal.AppearancesSmall.Appearance = Appearance2
        ButtonTool9.SharedPropsInternal.Caption = "New"
        ButtonTool9.SharedPropsInternal.Shortcut = Shortcut.CtrlN
        ButtonTool9.SharedPropsInternal.ToolTipText = "Shortcut Ctrl+N"
        ButtonTool9.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText
        Appearance3.Image = CType(resources.GetObject("Appearance3.Image"), Object)
        ButtonTool10.SharedPropsInternal.AppearancesSmall.Appearance = Appearance3
        ButtonTool10.SharedPropsInternal.Caption = "Save"
        ButtonTool10.SharedPropsInternal.Shortcut = Shortcut.CtrlS
        ButtonTool10.SharedPropsInternal.ToolTipText = "Shortcut Ctrl+S"
        ButtonTool10.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText
        Appearance4.Image = CType(resources.GetObject("Appearance4.Image"), Object)
        ButtonTool11.SharedPropsInternal.AppearancesSmall.Appearance = Appearance4
        ButtonTool11.SharedPropsInternal.Caption = "Delete"
        ButtonTool11.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText
        Appearance5.Image = CType(resources.GetObject("Appearance5.Image"), Object)
        ButtonTool12.SharedPropsInternal.AppearancesSmall.Appearance = Appearance5
        ButtonTool12.SharedPropsInternal.Caption = "Edit"
        ButtonTool12.SharedPropsInternal.Shortcut = Shortcut.CtrlE
        ButtonTool12.SharedPropsInternal.ToolTipText = "Shortcut Ctrl+E"
        ButtonTool12.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText
        Appearance6.Image = Global.Shipping.My.Resources.Resources.print_24
        ButtonTool13.SharedPropsInternal.AppearancesSmall.Appearance = Appearance6
        ButtonTool13.SharedPropsInternal.Caption = "Print"
        ButtonTool13.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText
        ButtonTool13.SharedPropsInternal.Visible = False
        ControlContainerTool2.ControlName = "Navigate"
        ControlContainerTool2.SharedPropsInternal.Caption = "NavigateContainer"
        ControlContainerTool2.SharedPropsInternal.Visible = False
        Appearance7.Image = Global.Shipping.My.Resources.Resources.notes_24
        ButtonTool14.SharedPropsInternal.AppearancesSmall.Appearance = Appearance7
        ButtonTool14.SharedPropsInternal.Caption = "History"
        ButtonTool14.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText
        ButtonTool14.SharedPropsInternal.Visible = False
        Me.Toolbar.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool8, ButtonTool9, ButtonTool10, ButtonTool11, ButtonTool12, ButtonTool13, ControlContainerTool2, ButtonTool14})
        '
        'UserGeneralForms
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.FillPanel)
        Me.Controls.Add(Me._UserGeneralForms_Toolbars_Dock_Area_Left)
        Me.Controls.Add(Me._UserGeneralForms_Toolbars_Dock_Area_Right)
        Me.Controls.Add(Me._UserGeneralForms_Toolbars_Dock_Area_Top)
        Me.Controls.Add(Me._UserGeneralForms_Toolbars_Dock_Area_Bottom)
        Me.Name = "UserGeneralForms"
        Me.Size = New System.Drawing.Size(599, 388)
        Me.FillPanel.ResumeLayout(False)
        CType(Me.DS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Toolbar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
    End Sub
    Friend WithEvents FillPanel As System.Windows.Forms.Panel
    Friend WithEvents _UserGeneralForms_Toolbars_Dock_Area_Left As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _UserGeneralForms_Toolbars_Dock_Area_Right As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _UserGeneralForms_Toolbars_Dock_Area_Top As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _UserGeneralForms_Toolbars_Dock_Area_Bottom As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Protected WithEvents Navigate As Shipping.UserNavigate
    Friend WithEvents DS As System.Data.DataSet
    Friend WithEvents Toolbar As Infragistics.Win.UltraWinToolbars.UltraToolbarsManager
    'For ILS Shortcuts: Added 
    Friend WithEvents FrmInwardBls As Shipping.FrmInwardBls
    Friend WithEvents FrmInwardDiscount As Shipping.FrmInwardDiscount
    Friend WithEvents FrmPMain As Shipping.FrmPMain
End Class
