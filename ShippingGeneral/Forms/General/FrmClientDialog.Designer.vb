<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmClientDialog
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
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("TB_Clients", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID")
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("lName")
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("LAddress", -1, Nothing, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, False)
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FName")
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FAddress")
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("EMail")
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Fax")
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Tel")
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Country")
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Remarks")
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ClientCode")
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
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraToolbar1 As Infragistics.Win.UltraWinToolbars.UltraToolbar = New Infragistics.Win.UltraWinToolbars.UltraToolbar("TopToolbar")
        Dim LabelTool1 As Infragistics.Win.UltraWinToolbars.LabelTool = New Infragistics.Win.UltraWinToolbars.LabelTool("Part Of Client Name ")
        Dim TextBoxTool1 As Infragistics.Win.UltraWinToolbars.TextBoxTool = New Infragistics.Win.UltraWinToolbars.TextBoxTool("TxtClientSrch")
        Dim ButtonTool1 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("GoSearch")
        Dim ButtonTool2 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("By Code")
        Dim ButtonTool3 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Select")
        Dim LabelTool2 As Infragistics.Win.UltraWinToolbars.LabelTool = New Infragistics.Win.UltraWinToolbars.LabelTool("Part Of Client Name ")
        Dim TextBoxTool2 As Infragistics.Win.UltraWinToolbars.TextBoxTool = New Infragistics.Win.UltraWinToolbars.TextBoxTool("TxtClientSrch")
        Dim ButtonTool4 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("GoSearch")
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmClientDialog))
        Dim ButtonTool5 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Select")
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ButtonTool6 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("By Code")
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.DataSetForm = New System.Data.DataSet
        Me.DataTable1 = New System.Data.DataTable
        Me.DataColumn1 = New System.Data.DataColumn
        Me.DataColumn2 = New System.Data.DataColumn
        Me.DataColumn3 = New System.Data.DataColumn
        Me.DataColumn4 = New System.Data.DataColumn
        Me.DataColumn5 = New System.Data.DataColumn
        Me.DataColumn6 = New System.Data.DataColumn
        Me.DataColumn7 = New System.Data.DataColumn
        Me.DataColumn8 = New System.Data.DataColumn
        Me.DataColumn9 = New System.Data.DataColumn
        Me.DataColumn10 = New System.Data.DataColumn
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.GridClients = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.ToolbarManager = New Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(Me.components)
        Me.FrmClientDialog_Fill_Panel = New System.Windows.Forms.Panel
        Me._FrmClientDialog_Toolbars_Dock_Area_Left = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
        Me._FrmClientDialog_Toolbars_Dock_Area_Right = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
        Me._FrmClientDialog_Toolbars_Dock_Area_Top = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
        Me._FrmClientDialog_Toolbars_Dock_Area_Bottom = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
        Me.DataColumn11 = New System.Data.DataColumn
        CType(Me.DataSetForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.GridClients, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ToolbarManager, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FrmClientDialog_Fill_Panel.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataSetForm
        '
        Me.DataSetForm.DataSetName = "NewDataSet"
        Me.DataSetForm.Tables.AddRange(New System.Data.DataTable() {Me.DataTable1})
        '
        'DataTable1
        '
        Me.DataTable1.Columns.AddRange(New System.Data.DataColumn() {Me.DataColumn1, Me.DataColumn2, Me.DataColumn3, Me.DataColumn4, Me.DataColumn5, Me.DataColumn6, Me.DataColumn7, Me.DataColumn8, Me.DataColumn9, Me.DataColumn10, Me.DataColumn11})
        Me.DataTable1.TableName = "TB_Clients"
        '
        'DataColumn1
        '
        Me.DataColumn1.ColumnName = "ID"
        Me.DataColumn1.DataType = GetType(System.Guid)
        '
        'DataColumn2
        '
        Me.DataColumn2.ColumnName = "lName"
        '
        'DataColumn3
        '
        Me.DataColumn3.ColumnName = "LAddress"
        '
        'DataColumn4
        '
        Me.DataColumn4.ColumnName = "FName"
        '
        'DataColumn5
        '
        Me.DataColumn5.ColumnName = "FAddress"
        '
        'DataColumn6
        '
        Me.DataColumn6.ColumnName = "EMail"
        '
        'DataColumn7
        '
        Me.DataColumn7.ColumnName = "Fax"
        '
        'DataColumn8
        '
        Me.DataColumn8.ColumnName = "Tel"
        '
        'DataColumn9
        '
        Me.DataColumn9.ColumnName = "Country"
        '
        'DataColumn10
        '
        Me.DataColumn10.ColumnName = "Remarks"
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.GridClients)
        Me.UltraGroupBox1.Location = New System.Drawing.Point(9, 6)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(714, 361)
        Me.UltraGroupBox1.SupportThemes = False
        Me.UltraGroupBox1.TabIndex = 1
        '
        'GridClients
        '
        Me.GridClients.DataMember = "TB_Clients"
        Me.GridClients.DataSource = Me.DataSetForm
        Appearance1.BackColor = System.Drawing.Color.WhiteSmoke
        Appearance1.BackColor2 = System.Drawing.Color.White
        Appearance1.BackHatchStyle = Infragistics.Win.BackHatchStyle.LightHorizontal
        Me.GridClients.DisplayLayout.Appearance = Appearance1
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn2.Header.VisiblePosition = 2
        UltraGridColumn3.Header.VisiblePosition = 3
        UltraGridColumn4.Header.VisiblePosition = 4
        UltraGridColumn5.Header.VisiblePosition = 5
        UltraGridColumn6.Header.VisiblePosition = 6
        UltraGridColumn7.Header.VisiblePosition = 7
        UltraGridColumn8.Header.VisiblePosition = 8
        UltraGridColumn9.Header.VisiblePosition = 9
        UltraGridColumn10.Header.VisiblePosition = 10
        UltraGridColumn11.Header.VisiblePosition = 1
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11})
        Me.GridClients.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.GridClients.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.GridClients.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.SystemColors.Window
        Me.GridClients.DisplayLayout.GroupByBox.Appearance = Appearance2
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.GridClients.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
        Me.GridClients.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.GridClients.DisplayLayout.GroupByBox.Hidden = True
        Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance4.BackColor2 = System.Drawing.SystemColors.Control
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.GridClients.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
        Me.GridClients.DisplayLayout.InterBandSpacing = 10
        Me.GridClients.DisplayLayout.MaxColScrollRegions = 1
        Me.GridClients.DisplayLayout.MaxRowScrollRegions = 1
        Appearance5.BackColor = System.Drawing.SystemColors.Window
        Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GridClients.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.SystemColors.Highlight
        Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.GridClients.DisplayLayout.Override.ActiveRowAppearance = Appearance6
        Me.GridClients.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.GridClients.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.GridClients.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.GridClients.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.[False]
        Me.GridClients.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.GridClients.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.GridClients.DisplayLayout.Override.BorderStyleHeader = Infragistics.Win.UIElementBorderStyle.Etched
        Me.GridClients.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance7.BackColor = System.Drawing.Color.Transparent
        Me.GridClients.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BackColor = System.Drawing.Color.LightYellow
        Appearance8.BackColor2 = System.Drawing.Color.PaleGoldenrod
        Appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.GridClients.DisplayLayout.Override.CellAppearance = Appearance8
        Me.GridClients.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.GridClients.DisplayLayout.Override.CellPadding = 0
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.GridClients.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance10.BackColor = System.Drawing.Color.CornflowerBlue
        Appearance10.BackColor2 = System.Drawing.Color.RoyalBlue
        Appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance10.FontData.SizeInPoints = 10.0!
        Appearance10.ForeColor = System.Drawing.Color.Navy
        Appearance10.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.GridClients.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.GridClients.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.GridClients.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Me.GridClients.DisplayLayout.Override.RowAppearance = Appearance11
        Appearance12.BackColor = System.Drawing.Color.Transparent
        Appearance12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridClients.DisplayLayout.Override.RowSelectorAppearance = Appearance12
        Me.GridClients.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.GridClients.DisplayLayout.Override.RowSelectorWidth = 10
        Me.GridClients.DisplayLayout.Override.RowSpacingAfter = 3
        Me.GridClients.DisplayLayout.Override.RowSpacingBefore = 3
        Appearance13.BackColor = System.Drawing.Color.Navy
        Appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.None
        Appearance13.BackHatchStyle = Infragistics.Win.BackHatchStyle.None
        Appearance13.ForeColor = System.Drawing.Color.White
        Me.GridClients.DisplayLayout.Override.SelectedRowAppearance = Appearance13
        Appearance14.BackColor = System.Drawing.SystemColors.ControlLight
        Me.GridClients.DisplayLayout.Override.TemplateAddRowAppearance = Appearance14
        Me.GridClients.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridClients.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid
        Me.GridClients.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.GridClients.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.GridClients.DisplayLayout.UseFixedHeaders = True
        Me.GridClients.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.GridClients.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.GridClients.Location = New System.Drawing.Point(12, 13)
        Me.GridClients.Name = "GridClients"
        Me.GridClients.Size = New System.Drawing.Size(686, 337)
        Me.GridClients.TabIndex = 0
        Me.GridClients.Text = "UltraGrid1"
        '
        'ToolbarManager
        '
        Me.ToolbarManager.DesignerFlags = 1
        Me.ToolbarManager.DockWithinContainer = Me
        Me.ToolbarManager.ImageSizeSmall = New System.Drawing.Size(24, 24)
        Me.ToolbarManager.ShowFullMenusDelay = 500
        Me.ToolbarManager.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.VisualStudio2005
        UltraToolbar1.DockedColumn = 0
        UltraToolbar1.DockedRow = 0
        UltraToolbar1.FloatingSize = New System.Drawing.Size(8000, 40)
        UltraToolbar1.IsStockToolbar = False
        UltraToolbar1.Text = "TopToolbar"
        LabelTool1.InstanceProps.Width = 137
        TextBoxTool1.InstanceProps.Width = 182
        UltraToolbar1.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {LabelTool1, TextBoxTool1, ButtonTool1, ButtonTool2, ButtonTool3})
        Me.ToolbarManager.Toolbars.AddRange(New Infragistics.Win.UltraWinToolbars.UltraToolbar() {UltraToolbar1})
        Me.ToolbarManager.ToolbarSettings.AllowCustomize = Infragistics.Win.DefaultableBoolean.[False]
        Me.ToolbarManager.ToolbarSettings.AllowDockBottom = Infragistics.Win.DefaultableBoolean.[False]
        Me.ToolbarManager.ToolbarSettings.AllowDockLeft = Infragistics.Win.DefaultableBoolean.[False]
        Me.ToolbarManager.ToolbarSettings.AllowDockRight = Infragistics.Win.DefaultableBoolean.[False]
        Me.ToolbarManager.ToolbarSettings.AllowFloating = Infragistics.Win.DefaultableBoolean.[False]
        Me.ToolbarManager.ToolbarSettings.AllowHiding = Infragistics.Win.DefaultableBoolean.[False]
        LabelTool2.SharedProps.Caption = "Part Of Client Name "
        TextBoxTool2.SharedProps.Caption = "TxtClientSrch"
        Appearance15.Image = CType(resources.GetObject("Appearance15.Image"), Object)
        ButtonTool4.SharedProps.AppearancesSmall.Appearance = Appearance15
        ButtonTool4.SharedProps.Caption = "By Name"
        ButtonTool4.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText
        Appearance16.Image = Global.Shipping.My.Resources.Resources.import_24
        ButtonTool5.SharedProps.AppearancesSmall.Appearance = Appearance16
        ButtonTool5.SharedProps.Caption = "Select"
        ButtonTool5.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText
        Appearance17.Image = Global.Shipping.My.Resources.Resources.search_24
        ButtonTool6.SharedProps.AppearancesSmall.Appearance = Appearance17
        ButtonTool6.SharedProps.Caption = "By Code"
        ButtonTool6.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText
        Me.ToolbarManager.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {LabelTool2, TextBoxTool2, ButtonTool4, ButtonTool5, ButtonTool6})
        '
        'FrmClientDialog_Fill_Panel
        '
        Me.FrmClientDialog_Fill_Panel.Controls.Add(Me.UltraGroupBox1)
        Me.FrmClientDialog_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default
        Me.FrmClientDialog_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FrmClientDialog_Fill_Panel.Location = New System.Drawing.Point(0, 60)
        Me.FrmClientDialog_Fill_Panel.Name = "FrmClientDialog_Fill_Panel"
        Me.FrmClientDialog_Fill_Panel.Size = New System.Drawing.Size(735, 353)
        Me.FrmClientDialog_Fill_Panel.TabIndex = 0
        '
        '_FrmClientDialog_Toolbars_Dock_Area_Left
        '
        Me._FrmClientDialog_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._FrmClientDialog_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me._FrmClientDialog_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left
        Me._FrmClientDialog_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText
        Me._FrmClientDialog_Toolbars_Dock_Area_Left.Location = New System.Drawing.Point(0, 60)
        Me._FrmClientDialog_Toolbars_Dock_Area_Left.Name = "_FrmClientDialog_Toolbars_Dock_Area_Left"
        Me._FrmClientDialog_Toolbars_Dock_Area_Left.Size = New System.Drawing.Size(0, 353)
        Me._FrmClientDialog_Toolbars_Dock_Area_Left.ToolbarsManager = Me.ToolbarManager
        '
        '_FrmClientDialog_Toolbars_Dock_Area_Right
        '
        Me._FrmClientDialog_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._FrmClientDialog_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me._FrmClientDialog_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right
        Me._FrmClientDialog_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText
        Me._FrmClientDialog_Toolbars_Dock_Area_Right.Location = New System.Drawing.Point(735, 60)
        Me._FrmClientDialog_Toolbars_Dock_Area_Right.Name = "_FrmClientDialog_Toolbars_Dock_Area_Right"
        Me._FrmClientDialog_Toolbars_Dock_Area_Right.Size = New System.Drawing.Size(0, 353)
        Me._FrmClientDialog_Toolbars_Dock_Area_Right.ToolbarsManager = Me.ToolbarManager
        '
        '_FrmClientDialog_Toolbars_Dock_Area_Top
        '
        Me._FrmClientDialog_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._FrmClientDialog_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me._FrmClientDialog_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top
        Me._FrmClientDialog_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText
        Me._FrmClientDialog_Toolbars_Dock_Area_Top.Location = New System.Drawing.Point(0, 0)
        Me._FrmClientDialog_Toolbars_Dock_Area_Top.Name = "_FrmClientDialog_Toolbars_Dock_Area_Top"
        Me._FrmClientDialog_Toolbars_Dock_Area_Top.Size = New System.Drawing.Size(735, 60)
        Me._FrmClientDialog_Toolbars_Dock_Area_Top.ToolbarsManager = Me.ToolbarManager
        '
        '_FrmClientDialog_Toolbars_Dock_Area_Bottom
        '
        Me._FrmClientDialog_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._FrmClientDialog_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me._FrmClientDialog_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom
        Me._FrmClientDialog_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText
        Me._FrmClientDialog_Toolbars_Dock_Area_Bottom.Location = New System.Drawing.Point(0, 413)
        Me._FrmClientDialog_Toolbars_Dock_Area_Bottom.Name = "_FrmClientDialog_Toolbars_Dock_Area_Bottom"
        Me._FrmClientDialog_Toolbars_Dock_Area_Bottom.Size = New System.Drawing.Size(735, 0)
        Me._FrmClientDialog_Toolbars_Dock_Area_Bottom.ToolbarsManager = Me.ToolbarManager
        '
        'DataColumn11
        '
        Me.DataColumn11.ColumnName = "ClientCode"
        '
        'FrmClientDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(735, 413)
        Me.Controls.Add(Me.FrmClientDialog_Fill_Panel)
        Me.Controls.Add(Me._FrmClientDialog_Toolbars_Dock_Area_Left)
        Me.Controls.Add(Me._FrmClientDialog_Toolbars_Dock_Area_Right)
        Me.Controls.Add(Me._FrmClientDialog_Toolbars_Dock_Area_Top)
        Me.Controls.Add(Me._FrmClientDialog_Toolbars_Dock_Area_Bottom)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FrmClientDialog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Client Search"
        CType(Me.DataSetForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        CType(Me.GridClients, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ToolbarManager, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FrmClientDialog_Fill_Panel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataSetForm As System.Data.DataSet
    Friend WithEvents DataTable1 As System.Data.DataTable
    Friend WithEvents DataColumn1 As System.Data.DataColumn
    Friend WithEvents DataColumn2 As System.Data.DataColumn
    Friend WithEvents DataColumn3 As System.Data.DataColumn
    Friend WithEvents DataColumn4 As System.Data.DataColumn
    Friend WithEvents DataColumn5 As System.Data.DataColumn
    Friend WithEvents DataColumn6 As System.Data.DataColumn
    Friend WithEvents DataColumn7 As System.Data.DataColumn
    Friend WithEvents DataColumn8 As System.Data.DataColumn
    Friend WithEvents DataColumn9 As System.Data.DataColumn
    Friend WithEvents DataColumn10 As System.Data.DataColumn
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents GridClients As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents ToolbarManager As Infragistics.Win.UltraWinToolbars.UltraToolbarsManager
    Friend WithEvents FrmClientDialog_Fill_Panel As System.Windows.Forms.Panel
    Friend WithEvents _FrmClientDialog_Toolbars_Dock_Area_Left As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _FrmClientDialog_Toolbars_Dock_Area_Right As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _FrmClientDialog_Toolbars_Dock_Area_Top As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _FrmClientDialog_Toolbars_Dock_Area_Bottom As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents DataColumn11 As System.Data.DataColumn

End Class
