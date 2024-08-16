<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPortDialog
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("TB_Ports", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID")
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PortCode", -1, Nothing, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, False)
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PortName")
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FPortName")
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Country")
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraToolbar1 As Infragistics.Win.UltraWinToolbars.UltraToolbar = New Infragistics.Win.UltraWinToolbars.UltraToolbar("TopToolbar")
        Dim LabelTool1 As Infragistics.Win.UltraWinToolbars.LabelTool = New Infragistics.Win.UltraWinToolbars.LabelTool("Part Of Port Name")
        Dim TextBoxTool1 As Infragistics.Win.UltraWinToolbars.TextBoxTool = New Infragistics.Win.UltraWinToolbars.TextBoxTool("TxtPortName")
        Dim ButtonTool1 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Search")
        Dim ButtonTool2 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Search")
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPortDialog))
        Dim LabelTool2 As Infragistics.Win.UltraWinToolbars.LabelTool = New Infragistics.Win.UltraWinToolbars.LabelTool("Part Of Port Name")
        Dim TextBoxTool2 As Infragistics.Win.UltraWinToolbars.TextBoxTool = New Infragistics.Win.UltraWinToolbars.TextBoxTool("TxtPortName")
        Me.UltraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox
        Me.GridPorts = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.DatasetForm = New System.Data.DataSet
        Me.DataTable1 = New System.Data.DataTable
        Me.DataColumn1 = New System.Data.DataColumn
        Me.DataColumn2 = New System.Data.DataColumn
        Me.DataColumn3 = New System.Data.DataColumn
        Me.DataColumn4 = New System.Data.DataColumn
        Me.DataColumn5 = New System.Data.DataColumn
        Me.TopToolbars = New Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(Me.components)
        Me.FrmPortDialog_Fill_Panel = New System.Windows.Forms.Panel
        Me._FrmPortDialog_Toolbars_Dock_Area_Left = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
        Me._FrmPortDialog_Toolbars_Dock_Area_Right = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
        Me._FrmPortDialog_Toolbars_Dock_Area_Top = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
        Me._FrmPortDialog_Toolbars_Dock_Area_Bottom = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox2.SuspendLayout()
        CType(Me.GridPorts, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DatasetForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TopToolbars, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FrmPortDialog_Fill_Panel.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraGroupBox2
        '
        Me.UltraGroupBox2.Controls.Add(Me.GridPorts)
        Me.UltraGroupBox2.Location = New System.Drawing.Point(12, 6)
        Me.UltraGroupBox2.Name = "UltraGroupBox2"
        Me.UltraGroupBox2.Size = New System.Drawing.Size(580, 326)
        Me.UltraGroupBox2.SupportThemes = False
        Me.UltraGroupBox2.TabIndex = 4
        Me.UltraGroupBox2.Text = "List Of Ports"
        '
        'GridPorts
        '
        Me.GridPorts.DataMember = "TB_Ports"
        Me.GridPorts.DataSource = Me.DatasetForm
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.GridPorts.DisplayLayout.Appearance = Appearance1
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn3.Header.VisiblePosition = 2
        UltraGridColumn4.Header.VisiblePosition = 3
        UltraGridColumn5.Header.VisiblePosition = 4
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5})
        Me.GridPorts.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.GridPorts.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.GridPorts.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.SystemColors.Window
        Me.GridPorts.DisplayLayout.GroupByBox.Appearance = Appearance2
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.GridPorts.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
        Me.GridPorts.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance4.BackColor2 = System.Drawing.SystemColors.Control
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.GridPorts.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
        Me.GridPorts.DisplayLayout.MaxColScrollRegions = 1
        Me.GridPorts.DisplayLayout.MaxRowScrollRegions = 1
        Appearance5.BackColor = System.Drawing.SystemColors.Window
        Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GridPorts.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.SystemColors.Highlight
        Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.GridPorts.DisplayLayout.Override.ActiveRowAppearance = Appearance6
        Me.GridPorts.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.GridPorts.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Me.GridPorts.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.GridPorts.DisplayLayout.Override.CellAppearance = Appearance8
        Me.GridPorts.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.GridPorts.DisplayLayout.Override.CellPadding = 0
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.GridPorts.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance10.TextHAlign = Infragistics.Win.HAlign.Left
        Me.GridPorts.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.GridPorts.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.GridPorts.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Me.GridPorts.DisplayLayout.Override.RowAppearance = Appearance11
        Me.GridPorts.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
        Me.GridPorts.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
        Me.GridPorts.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.GridPorts.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.GridPorts.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.GridPorts.Location = New System.Drawing.Point(12, 20)
        Me.GridPorts.Name = "GridPorts"
        Me.GridPorts.Size = New System.Drawing.Size(558, 297)
        Me.GridPorts.TabIndex = 0
        Me.GridPorts.Text = "UltraGrid1"
        '
        'DatasetForm
        '
        Me.DatasetForm.DataSetName = "NewDataSet"
        Me.DatasetForm.Tables.AddRange(New System.Data.DataTable() {Me.DataTable1})
        '
        'DataTable1
        '
        Me.DataTable1.Columns.AddRange(New System.Data.DataColumn() {Me.DataColumn1, Me.DataColumn2, Me.DataColumn3, Me.DataColumn4, Me.DataColumn5})
        Me.DataTable1.TableName = "TB_Ports"
        '
        'DataColumn1
        '
        Me.DataColumn1.ColumnName = "ID"
        Me.DataColumn1.DataType = GetType(System.Guid)
        '
        'DataColumn2
        '
        Me.DataColumn2.ColumnName = "PortCode"
        '
        'DataColumn3
        '
        Me.DataColumn3.ColumnName = "PortName"
        '
        'DataColumn4
        '
        Me.DataColumn4.ColumnName = "FPortName"
        '
        'DataColumn5
        '
        Me.DataColumn5.ColumnName = "Country"
        '
        'TopToolbars
        '
        Appearance13.TextHAlign = Infragistics.Win.HAlign.Left
        Me.TopToolbars.Appearance = Appearance13
        Me.TopToolbars.DesignerFlags = 1
        Me.TopToolbars.DockWithinContainer = Me
        Me.TopToolbars.ImageSizeSmall = New System.Drawing.Size(24, 24)
        Me.TopToolbars.ShowFullMenusDelay = 500
        Me.TopToolbars.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.VisualStudio2005
        UltraToolbar1.DockedColumn = 0
        UltraToolbar1.DockedRow = 0
        UltraToolbar1.Settings.AllowCustomize = Infragistics.Win.DefaultableBoolean.[False]
        UltraToolbar1.Settings.AllowDockBottom = Infragistics.Win.DefaultableBoolean.[False]
        UltraToolbar1.Settings.AllowDockLeft = Infragistics.Win.DefaultableBoolean.[False]
        UltraToolbar1.Settings.AllowDockRight = Infragistics.Win.DefaultableBoolean.[False]
        UltraToolbar1.Settings.AllowDockTop = Infragistics.Win.DefaultableBoolean.[True]
        UltraToolbar1.Settings.AllowFloating = Infragistics.Win.DefaultableBoolean.[False]
        UltraToolbar1.Settings.AllowHiding = Infragistics.Win.DefaultableBoolean.[False]
        UltraToolbar1.Settings.FillEntireRow = Infragistics.Win.DefaultableBoolean.[True]
        UltraToolbar1.Text = "TopToolbar"
        TextBoxTool1.InstanceProps.Width = 221
        UltraToolbar1.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {LabelTool1, TextBoxTool1, ButtonTool1})
        Me.TopToolbars.Toolbars.AddRange(New Infragistics.Win.UltraWinToolbars.UltraToolbar() {UltraToolbar1})
        Appearance14.Image = CType(resources.GetObject("Appearance14.Image"), Object)
        ButtonTool2.SharedProps.AppearancesSmall.Appearance = Appearance14
        ButtonTool2.SharedProps.Caption = "Search"
        ButtonTool2.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.DefaultForToolType
        LabelTool2.SharedProps.Caption = "Part Of Port Name"
        TextBoxTool2.SharedProps.Caption = "TxtPortName"
        Me.TopToolbars.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool2, LabelTool2, TextBoxTool2})
        '
        'FrmPortDialog_Fill_Panel
        '
        Me.FrmPortDialog_Fill_Panel.Controls.Add(Me.UltraGroupBox2)
        Me.FrmPortDialog_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default
        Me.FrmPortDialog_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FrmPortDialog_Fill_Panel.Location = New System.Drawing.Point(0, 35)
        Me.FrmPortDialog_Fill_Panel.Name = "FrmPortDialog_Fill_Panel"
        Me.FrmPortDialog_Fill_Panel.Size = New System.Drawing.Size(608, 344)
        Me.FrmPortDialog_Fill_Panel.TabIndex = 0
        '
        '_FrmPortDialog_Toolbars_Dock_Area_Left
        '
        Me._FrmPortDialog_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._FrmPortDialog_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me._FrmPortDialog_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left
        Me._FrmPortDialog_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText
        Me._FrmPortDialog_Toolbars_Dock_Area_Left.Location = New System.Drawing.Point(0, 35)
        Me._FrmPortDialog_Toolbars_Dock_Area_Left.Name = "_FrmPortDialog_Toolbars_Dock_Area_Left"
        Me._FrmPortDialog_Toolbars_Dock_Area_Left.Size = New System.Drawing.Size(0, 344)
        Me._FrmPortDialog_Toolbars_Dock_Area_Left.ToolbarsManager = Me.TopToolbars
        '
        '_FrmPortDialog_Toolbars_Dock_Area_Right
        '
        Me._FrmPortDialog_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._FrmPortDialog_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me._FrmPortDialog_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right
        Me._FrmPortDialog_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText
        Me._FrmPortDialog_Toolbars_Dock_Area_Right.Location = New System.Drawing.Point(608, 35)
        Me._FrmPortDialog_Toolbars_Dock_Area_Right.Name = "_FrmPortDialog_Toolbars_Dock_Area_Right"
        Me._FrmPortDialog_Toolbars_Dock_Area_Right.Size = New System.Drawing.Size(0, 344)
        Me._FrmPortDialog_Toolbars_Dock_Area_Right.ToolbarsManager = Me.TopToolbars
        '
        '_FrmPortDialog_Toolbars_Dock_Area_Top
        '
        Me._FrmPortDialog_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._FrmPortDialog_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me._FrmPortDialog_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top
        Me._FrmPortDialog_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText
        Me._FrmPortDialog_Toolbars_Dock_Area_Top.Location = New System.Drawing.Point(0, 0)
        Me._FrmPortDialog_Toolbars_Dock_Area_Top.Name = "_FrmPortDialog_Toolbars_Dock_Area_Top"
        Me._FrmPortDialog_Toolbars_Dock_Area_Top.Size = New System.Drawing.Size(608, 35)
        Me._FrmPortDialog_Toolbars_Dock_Area_Top.ToolbarsManager = Me.TopToolbars
        '
        '_FrmPortDialog_Toolbars_Dock_Area_Bottom
        '
        Me._FrmPortDialog_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._FrmPortDialog_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me._FrmPortDialog_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom
        Me._FrmPortDialog_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText
        Me._FrmPortDialog_Toolbars_Dock_Area_Bottom.Location = New System.Drawing.Point(0, 379)
        Me._FrmPortDialog_Toolbars_Dock_Area_Bottom.Name = "_FrmPortDialog_Toolbars_Dock_Area_Bottom"
        Me._FrmPortDialog_Toolbars_Dock_Area_Bottom.Size = New System.Drawing.Size(608, 0)
        Me._FrmPortDialog_Toolbars_Dock_Area_Bottom.ToolbarsManager = Me.TopToolbars
        '
        'FrmPortDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(608, 379)
        Me.Controls.Add(Me.FrmPortDialog_Fill_Panel)
        Me.Controls.Add(Me._FrmPortDialog_Toolbars_Dock_Area_Left)
        Me.Controls.Add(Me._FrmPortDialog_Toolbars_Dock_Area_Right)
        Me.Controls.Add(Me._FrmPortDialog_Toolbars_Dock_Area_Top)
        Me.Controls.Add(Me._FrmPortDialog_Toolbars_Dock_Area_Bottom)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPortDialog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Port Search "
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox2.ResumeLayout(False)
        CType(Me.GridPorts, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DatasetForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TopToolbars, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FrmPortDialog_Fill_Panel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UltraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents GridPorts As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents DatasetForm As System.Data.DataSet
    Friend WithEvents DataTable1 As System.Data.DataTable
    Friend WithEvents DataColumn1 As System.Data.DataColumn
    Friend WithEvents DataColumn2 As System.Data.DataColumn
    Friend WithEvents DataColumn3 As System.Data.DataColumn
    Friend WithEvents DataColumn4 As System.Data.DataColumn
    Friend WithEvents DataColumn5 As System.Data.DataColumn
    Friend WithEvents TopToolbars As Infragistics.Win.UltraWinToolbars.UltraToolbarsManager
    Friend WithEvents FrmPortDialog_Fill_Panel As System.Windows.Forms.Panel
    Friend WithEvents _FrmPortDialog_Toolbars_Dock_Area_Left As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _FrmPortDialog_Toolbars_Dock_Area_Right As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _FrmPortDialog_Toolbars_Dock_Area_Top As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _FrmPortDialog_Toolbars_Dock_Area_Bottom As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea

End Class
