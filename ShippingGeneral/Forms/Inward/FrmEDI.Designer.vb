<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEDI
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEDI))
        Dim ValueListItem1 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem2 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
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
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("TBMsgs", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("OurPort")
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("EDIIPPORT")
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PortName")
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.ToolStripForm = New System.Windows.Forms.ToolStrip
        Me.ButtonPickup = New System.Windows.Forms.ToolStripButton
        Me.ButtonChecking = New System.Windows.Forms.ToolStripButton
        Me.ButtonTctsCheck = New System.Windows.Forms.ToolStripButton
        Me.ButtonMap = New System.Windows.Forms.ToolStripButton
        Me.ButtonXML = New System.Windows.Forms.ToolStripButton
        Me.ButtonDirect = New System.Windows.Forms.ToolStripButton
        Me.ButtonUpdateWrongPorts = New System.Windows.Forms.ToolStripButton
        Me.ButtonSelect = New System.Windows.Forms.ToolStripButton
        Me.ButtonDeselect = New System.Windows.Forms.ToolStripButton
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.OptionSet = New Infragistics.Win.UltraWinEditors.UltraOptionSet
        Me.ProgressBar = New Infragistics.Win.UltraWinProgressBar.UltraProgressBar
        Me.UltraLabel11 = New Infragistics.Win.Misc.UltraLabel
        Me.FVessel = New Shipping.UserComboVessel
        Me.FVoyage = New Shipping.UserComboVoyage
        Me.GridResult = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.GridMsgs = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.DataSetForm = New System.Data.DataSet
        Me.DataTable1 = New System.Data.DataTable
        Me.DataColumn1 = New System.Data.DataColumn
        Me.DataColumn2 = New System.Data.DataColumn
        Me.DataColumn3 = New System.Data.DataColumn
        Me.FileDialog = New System.Windows.Forms.OpenFileDialog
        Me.ButtonForCustom = New System.Windows.Forms.ToolStripButton
        Me.ButtonForCustomNew = New System.Windows.Forms.ToolStripButton
        Me.TableLayoutPanel1.SuspendLayout()
        Me.ToolStripForm.SuspendLayout()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.OptionSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridResult, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridMsgs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSetForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.ToolStripForm, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.UltraGroupBox1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.GridResult, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.GridMsgs, 0, 3)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1068, 538)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'ToolStripForm
        '
        Me.ToolStripForm.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStripForm.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ButtonPickup, Me.ButtonChecking, Me.ButtonTctsCheck, Me.ButtonMap, Me.ButtonXML, Me.ButtonDirect, Me.ButtonUpdateWrongPorts, Me.ButtonSelect, Me.ButtonDeselect, Me.ButtonForCustom, Me.ButtonForCustomNew})
        Me.ToolStripForm.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripForm.Name = "ToolStripForm"
        Me.ToolStripForm.Size = New System.Drawing.Size(1068, 31)
        Me.ToolStripForm.TabIndex = 0
        Me.ToolStripForm.Text = "ToolStrip1"
        '
        'ButtonPickup
        '
        Me.ButtonPickup.Image = CType(resources.GetObject("ButtonPickup.Image"), System.Drawing.Image)
        Me.ButtonPickup.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonPickup.Name = "ButtonPickup"
        Me.ButtonPickup.Size = New System.Drawing.Size(71, 28)
        Me.ButtonPickup.Text = "Pickup"
        '
        'ButtonChecking
        '
        Me.ButtonChecking.Image = CType(resources.GetObject("ButtonChecking.Image"), System.Drawing.Image)
        Me.ButtonChecking.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonChecking.Name = "ButtonChecking"
        Me.ButtonChecking.Size = New System.Drawing.Size(85, 28)
        Me.ButtonChecking.Text = "Checking"
        '
        'ButtonTctsCheck
        '
        Me.ButtonTctsCheck.Image = Global.Shipping.My.Resources.Resources.confirm_24
        Me.ButtonTctsCheck.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonTctsCheck.Name = "ButtonTctsCheck"
        Me.ButtonTctsCheck.Size = New System.Drawing.Size(129, 28)
        Me.ButtonTctsCheck.Text = "Check TCTS Ports"
        '
        'ButtonMap
        '
        Me.ButtonMap.Image = CType(resources.GetObject("ButtonMap.Image"), System.Drawing.Image)
        Me.ButtonMap.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonMap.Name = "ButtonMap"
        Me.ButtonMap.Size = New System.Drawing.Size(107, 28)
        Me.ButtonMap.Text = "Map To TCTS"
        '
        'ButtonXML
        '
        Me.ButtonXML.Image = Global.Shipping.My.Resources.Resources.applications_24
        Me.ButtonXML.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonXML.Name = "ButtonXML"
        Me.ButtonXML.Size = New System.Drawing.Size(109, 28)
        Me.ButtonXML.Text = "Generate XML"
        Me.ButtonXML.ToolTipText = "Generate XML"
        '
        'ButtonDirect
        '
        Me.ButtonDirect.Image = Global.Shipping.My.Resources.Resources.applications_24
        Me.ButtonDirect.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonDirect.Name = "ButtonDirect"
        Me.ButtonDirect.Size = New System.Drawing.Size(93, 28)
        Me.ButtonDirect.Text = "Map Direct"
        '
        'ButtonUpdateWrongPorts
        '
        Me.ButtonUpdateWrongPorts.Image = Global.Shipping.My.Resources.Resources.web_24
        Me.ButtonUpdateWrongPorts.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonUpdateWrongPorts.Name = "ButtonUpdateWrongPorts"
        Me.ButtonUpdateWrongPorts.Size = New System.Drawing.Size(103, 28)
        Me.ButtonUpdateWrongPorts.Text = "Update Ports"
        '
        'ButtonSelect
        '
        Me.ButtonSelect.Image = Global.Shipping.My.Resources.Resources.confirm_24
        Me.ButtonSelect.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonSelect.Name = "ButtonSelect"
        Me.ButtonSelect.Size = New System.Drawing.Size(83, 28)
        Me.ButtonSelect.Text = "Select All"
        Me.ButtonSelect.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        '
        'ButtonDeselect
        '
        Me.ButtonDeselect.Image = Global.Shipping.My.Resources.Resources.undo_24
        Me.ButtonDeselect.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonDeselect.Name = "ButtonDeselect"
        Me.ButtonDeselect.Size = New System.Drawing.Size(79, 28)
        Me.ButtonDeselect.Text = "Deselect"
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.OptionSet)
        Me.UltraGroupBox1.Controls.Add(Me.ProgressBar)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel11)
        Me.UltraGroupBox1.Controls.Add(Me.FVessel)
        Me.UltraGroupBox1.Controls.Add(Me.FVoyage)
        Me.UltraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGroupBox1.Location = New System.Drawing.Point(3, 35)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(1062, 44)
        Me.UltraGroupBox1.TabIndex = 1
        '
        'OptionSet
        '
        Me.OptionSet.BorderStyle = Infragistics.Win.UIElementBorderStyle.Etched
        Me.OptionSet.ItemOrigin = New System.Drawing.Point(5, 2)
        ValueListItem1.CheckState = System.Windows.Forms.CheckState.Checked
        ValueListItem1.DataValue = "COC"
        ValueListItem1.DisplayText = "C.O.C."
        ValueListItem2.DataValue = "SOC"
        ValueListItem2.DisplayText = "S.O.C."
        Me.OptionSet.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem1, ValueListItem2})
        Me.OptionSet.ItemSpacingHorizontal = 10
        Me.OptionSet.ItemSpacingVertical = 10
        Me.OptionSet.Location = New System.Drawing.Point(475, 4)
        Me.OptionSet.Margin = New System.Windows.Forms.Padding(3, 5, 3, 3)
        Me.OptionSet.Name = "OptionSet"
        Me.OptionSet.Size = New System.Drawing.Size(139, 34)
        Me.OptionSet.TabIndex = 36
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(782, 10)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(125, 17)
        Me.ProgressBar.TabIndex = 35
        Me.ProgressBar.Text = "[Formatted]"
        Me.ProgressBar.Visible = False
        '
        'UltraLabel11
        '
        Me.UltraLabel11.Location = New System.Drawing.Point(15, 14)
        Me.UltraLabel11.Name = "UltraLabel11"
        Me.UltraLabel11.Size = New System.Drawing.Size(70, 16)
        Me.UltraLabel11.TabIndex = 34
        Me.UltraLabel11.Text = "Vsl/Voyage"
        '
        'FVessel
        '
        Me.FVessel.Location = New System.Drawing.Point(92, 11)
        Me.FVessel.Name = "FVessel"
        Me.FVessel.Size = New System.Drawing.Size(187, 21)
        Me.FVessel.TabIndex = 32
        Me.FVessel.VesselID = New System.Guid("00000000-0000-0000-0000-000000000000")
        '
        'FVoyage
        '
        Me.FVoyage.Location = New System.Drawing.Point(285, 11)
        Me.FVoyage.Name = "FVoyage"
        Me.FVoyage.Size = New System.Drawing.Size(165, 21)
        Me.FVoyage.TabIndex = 33
        Me.FVoyage.VoyageID = New System.Guid("00000000-0000-0000-0000-000000000000")
        '
        'GridResult
        '
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.GridResult.DisplayLayout.Appearance = Appearance1
        Me.GridResult.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.GridResult.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.SystemColors.Window
        Me.GridResult.DisplayLayout.GroupByBox.Appearance = Appearance2
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.GridResult.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
        Me.GridResult.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance4.BackColor2 = System.Drawing.SystemColors.Control
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.GridResult.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
        Me.GridResult.DisplayLayout.MaxColScrollRegions = 1
        Me.GridResult.DisplayLayout.MaxRowScrollRegions = 1
        Appearance5.BackColor = System.Drawing.SystemColors.Window
        Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GridResult.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.SystemColors.Highlight
        Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.GridResult.DisplayLayout.Override.ActiveRowAppearance = Appearance6
        Me.GridResult.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.GridResult.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Me.GridResult.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.GridResult.DisplayLayout.Override.CellAppearance = Appearance8
        Me.GridResult.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.GridResult.DisplayLayout.Override.CellPadding = 0
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.GridResult.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance10.TextHAlignAsString = "Left"
        Me.GridResult.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.GridResult.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.GridResult.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Me.GridResult.DisplayLayout.Override.RowAppearance = Appearance11
        Me.GridResult.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
        Me.GridResult.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
        Me.GridResult.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.GridResult.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.GridResult.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.GridResult.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridResult.Location = New System.Drawing.Point(3, 85)
        Me.GridResult.Name = "GridResult"
        Me.GridResult.Size = New System.Drawing.Size(1062, 222)
        Me.GridResult.TabIndex = 2
        Me.GridResult.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChangeOrLostFocus
        '
        'GridMsgs
        '
        Me.GridMsgs.DataMember = Nothing
        Me.GridMsgs.DataSource = Me.DataSetForm
        Appearance13.BackColor = System.Drawing.SystemColors.Window
        Appearance13.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.GridMsgs.DisplayLayout.Appearance = Appearance13
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn3.Header.VisiblePosition = 2
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3})
        Me.GridMsgs.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.GridMsgs.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.GridMsgs.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance14.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance14.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance14.BorderColor = System.Drawing.SystemColors.Window
        Me.GridMsgs.DisplayLayout.GroupByBox.Appearance = Appearance14
        Appearance15.ForeColor = System.Drawing.SystemColors.GrayText
        Me.GridMsgs.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance15
        Me.GridMsgs.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance16.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance16.BackColor2 = System.Drawing.SystemColors.Control
        Appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance16.ForeColor = System.Drawing.SystemColors.GrayText
        Me.GridMsgs.DisplayLayout.GroupByBox.PromptAppearance = Appearance16
        Appearance17.BackColor = System.Drawing.SystemColors.Window
        Appearance17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GridMsgs.DisplayLayout.Override.ActiveCellAppearance = Appearance17
        Appearance18.BackColor = System.Drawing.SystemColors.Highlight
        Appearance18.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.GridMsgs.DisplayLayout.Override.ActiveRowAppearance = Appearance18
        Me.GridMsgs.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.GridMsgs.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.GridMsgs.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.GridMsgs.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.[False]
        Me.GridMsgs.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[True]
        Me.GridMsgs.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.GridMsgs.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance19.BackColor = System.Drawing.SystemColors.Window
        Me.GridMsgs.DisplayLayout.Override.CardAreaAppearance = Appearance19
        Appearance20.BorderColor = System.Drawing.Color.Silver
        Appearance20.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.GridMsgs.DisplayLayout.Override.CellAppearance = Appearance20
        Me.GridMsgs.DisplayLayout.Override.CellPadding = 0
        Appearance21.BackColor = System.Drawing.SystemColors.Control
        Appearance21.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance21.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance21.BorderColor = System.Drawing.SystemColors.Window
        Me.GridMsgs.DisplayLayout.Override.GroupByRowAppearance = Appearance21
        Appearance22.TextHAlignAsString = "Left"
        Me.GridMsgs.DisplayLayout.Override.HeaderAppearance = Appearance22
        Me.GridMsgs.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.GridMsgs.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance23.BackColor = System.Drawing.SystemColors.Window
        Appearance23.BorderColor = System.Drawing.Color.Silver
        Me.GridMsgs.DisplayLayout.Override.RowAppearance = Appearance23
        Appearance24.BackColor = System.Drawing.SystemColors.ControlLight
        Me.GridMsgs.DisplayLayout.Override.TemplateAddRowAppearance = Appearance24
        Me.GridMsgs.DisplayLayout.UseFixedHeaders = True
        Me.GridMsgs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridMsgs.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.GridMsgs.Location = New System.Drawing.Point(3, 313)
        Me.GridMsgs.Name = "GridMsgs"
        Me.GridMsgs.Size = New System.Drawing.Size(1062, 222)
        Me.GridMsgs.TabIndex = 3
        Me.GridMsgs.Text = "UltraGrid2"
        '
        'DataSetForm
        '
        Me.DataSetForm.DataSetName = "NewDataSet"
        Me.DataSetForm.Tables.AddRange(New System.Data.DataTable() {Me.DataTable1})
        '
        'DataTable1
        '
        Me.DataTable1.Columns.AddRange(New System.Data.DataColumn() {Me.DataColumn1, Me.DataColumn2, Me.DataColumn3})
        Me.DataTable1.TableName = "TBMsgs"
        '
        'DataColumn1
        '
        Me.DataColumn1.Caption = "Our Port"
        Me.DataColumn1.ColumnName = "OurPort"
        '
        'DataColumn2
        '
        Me.DataColumn2.Caption = "EDIIP PORT"
        Me.DataColumn2.ColumnName = "EDIIPPORT"
        '
        'DataColumn3
        '
        Me.DataColumn3.ColumnName = "PortName"
        '
        'ButtonForCustom
        '
        Me.ButtonForCustom.Image = Global.Shipping.My.Resources.Resources.applications_24
        Me.ButtonForCustom.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonForCustom.Name = "ButtonForCustom"
        Me.ButtonForCustom.Size = New System.Drawing.Size(126, 28)
        Me.ButtonForCustom.Text = "MAP For Custom"

        '
        'ButtonForCustomNew
        '
        Me.ButtonForCustomNew.Image = Global.Shipping.My.Resources.Resources.applications_24
        Me.ButtonForCustomNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonForCustomNew.Name = "ButtonForCustomNew"
        Me.ButtonForCustomNew.Size = New System.Drawing.Size(133, 28)
        Me.ButtonForCustomNew.Text = "MAP Custom New"
        '
        'FrmEDI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1068, 538)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "FrmEDI"
        Me.Text = "E.D.I. Tools"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ToolStripForm.ResumeLayout(False)
        Me.ToolStripForm.PerformLayout()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        CType(Me.OptionSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridResult, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridMsgs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSetForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ToolStripForm As System.Windows.Forms.ToolStrip
    Friend WithEvents ButtonPickup As System.Windows.Forms.ToolStripButton
    Friend WithEvents ButtonChecking As System.Windows.Forms.ToolStripButton
    Friend WithEvents ButtonMap As System.Windows.Forms.ToolStripButton
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents DataSetForm As System.Data.DataSet
    Friend WithEvents DataTable1 As System.Data.DataTable
    Friend WithEvents DataColumn1 As System.Data.DataColumn
    Friend WithEvents DataColumn2 As System.Data.DataColumn
    Friend WithEvents UltraLabel11 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents FVessel As Shipping.UserComboVessel
    Friend WithEvents FVoyage As Shipping.UserComboVoyage
    Friend WithEvents GridResult As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents GridMsgs As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents ProgressBar As Infragistics.Win.UltraWinProgressBar.UltraProgressBar
    Friend WithEvents FileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ButtonTctsCheck As System.Windows.Forms.ToolStripButton
    Friend WithEvents ButtonXML As System.Windows.Forms.ToolStripButton
    Friend WithEvents ButtonDirect As System.Windows.Forms.ToolStripButton
    Friend WithEvents ButtonUpdateWrongPorts As System.Windows.Forms.ToolStripButton
    Friend WithEvents DataColumn3 As System.Data.DataColumn
    Friend WithEvents OptionSet As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Friend WithEvents ButtonSelect As System.Windows.Forms.ToolStripButton
    Friend WithEvents ButtonDeselect As System.Windows.Forms.ToolStripButton
    Friend WithEvents ButtonForCustom As System.Windows.Forms.ToolStripButton
    Friend WithEvents ButtonForCustomNew As System.Windows.Forms.ToolStripButton
End Class
