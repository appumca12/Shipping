<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEcsImport
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
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand2 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("ListOfCntrs", -1)
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CntrNo")
        Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CnSize")
        Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CnType")
        Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SOC")
        Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("POD")
        Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FLE")
        Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CurrentStatus")
        Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DschCmpl")
        Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ToLine")
        Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Sel")
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEcsImport))
        Me.FillPanel = New System.Windows.Forms.Panel
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.Vessel = New Shipping.UserComboVessel
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.GroupBox = New Infragistics.Win.Misc.UltraGroupBox
        Me.GridContainers = New Infragistics.Win.UltraWinGrid.UltraGrid
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
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel
        Me.Voyage = New Shipping.UserComboVoyage
        Me.ToLine = New Shipping.UserGnrlDate
        Me.Depot = New Shipping.UserComboCode
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel
        Me.DschCmpl = New Shipping.UserGnrlDate
        Me.TopToolBar = New System.Windows.Forms.ToolStrip
        Me.ButtonFind = New System.Windows.Forms.ToolStripButton
        Me.ButtonSave = New System.Windows.Forms.ToolStripButton
        Me.FormErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Lbl20 = New System.Windows.Forms.Label
        Me.Lbl40 = New System.Windows.Forms.Label
        Me.LBL45 = New System.Windows.Forms.Label
        Me.FillPanel.SuspendLayout()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.GroupBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox.SuspendLayout()
        CType(Me.GridContainers, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSetForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TopToolBar.SuspendLayout()
        CType(Me.FormErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FillPanel
        '
        Me.FillPanel.Controls.Add(Me.UltraGroupBox1)
        Me.FillPanel.Controls.Add(Me.TopToolBar)
        Me.FillPanel.Cursor = System.Windows.Forms.Cursors.Default
        Me.FillPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FillPanel.Location = New System.Drawing.Point(0, 0)
        Me.FillPanel.Name = "FillPanel"
        Me.FillPanel.Size = New System.Drawing.Size(752, 550)
        Me.FillPanel.TabIndex = 0
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.RectangularRaised
        Me.UltraGroupBox1.Controls.Add(Me.LBL45)
        Me.UltraGroupBox1.Controls.Add(Me.Lbl40)
        Me.UltraGroupBox1.Controls.Add(Me.Lbl20)
        Me.UltraGroupBox1.Controls.Add(Me.Vessel)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel1)
        Me.UltraGroupBox1.Controls.Add(Me.GroupBox)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel4)
        Me.UltraGroupBox1.Controls.Add(Me.Voyage)
        Me.UltraGroupBox1.Controls.Add(Me.ToLine)
        Me.UltraGroupBox1.Controls.Add(Me.Depot)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel3)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel2)
        Me.UltraGroupBox1.Controls.Add(Me.DschCmpl)
        Me.UltraGroupBox1.Location = New System.Drawing.Point(12, 40)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(720, 498)
        Me.UltraGroupBox1.SupportThemes = False
        Me.UltraGroupBox1.TabIndex = 18
        '
        'Vessel
        '
        Me.Vessel.Location = New System.Drawing.Point(111, 22)
        Me.Vessel.Name = "Vessel"
        Me.Vessel.Size = New System.Drawing.Size(181, 24)
        Me.Vessel.TabIndex = 0
        Me.Vessel.VesselID = New System.Guid("00000000-0000-0000-0000-000000000000")
        '
        'UltraLabel1
        '
        Me.UltraLabel1.Location = New System.Drawing.Point(25, 26)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(81, 20)
        Me.UltraLabel1.TabIndex = 10
        Me.UltraLabel1.Text = "Vessel/Voyage"
        '
        'GroupBox
        '
        Me.GroupBox.Controls.Add(Me.GridContainers)
        Me.GroupBox.Location = New System.Drawing.Point(20, 78)
        Me.GroupBox.Name = "GroupBox"
        Me.GroupBox.Size = New System.Drawing.Size(684, 381)
        Me.GroupBox.SupportThemes = False
        Me.GroupBox.TabIndex = 7
        Me.GroupBox.Text = "Containers List"
        '
        'GridContainers
        '
        Me.GridContainers.DataMember = "ListOfCntrs"
        Me.GridContainers.DataSource = Me.DataSetForm
        Appearance13.BackColor = System.Drawing.SystemColors.Window
        Appearance13.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.GridContainers.DisplayLayout.Appearance = Appearance13
        UltraGridColumn11.Header.VisiblePosition = 0
        UltraGridColumn12.Header.VisiblePosition = 1
        UltraGridColumn13.Header.VisiblePosition = 2
        UltraGridColumn14.Header.VisiblePosition = 3
        UltraGridColumn15.Header.VisiblePosition = 4
        UltraGridColumn16.Header.VisiblePosition = 5
        UltraGridColumn17.Header.VisiblePosition = 6
        UltraGridColumn18.Header.VisiblePosition = 7
        UltraGridColumn19.Header.VisiblePosition = 8
        UltraGridColumn20.Header.VisiblePosition = 9
        UltraGridBand2.Columns.AddRange(New Object() {UltraGridColumn11, UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn15, UltraGridColumn16, UltraGridColumn17, UltraGridColumn18, UltraGridColumn19, UltraGridColumn20})
        Me.GridContainers.DisplayLayout.BandsSerializer.Add(UltraGridBand2)
        Me.GridContainers.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.GridContainers.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance14.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance14.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance14.BorderColor = System.Drawing.SystemColors.Window
        Me.GridContainers.DisplayLayout.GroupByBox.Appearance = Appearance14
        Appearance15.ForeColor = System.Drawing.SystemColors.GrayText
        Me.GridContainers.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance15
        Me.GridContainers.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance16.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance16.BackColor2 = System.Drawing.SystemColors.Control
        Appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance16.ForeColor = System.Drawing.SystemColors.GrayText
        Me.GridContainers.DisplayLayout.GroupByBox.PromptAppearance = Appearance16
        Me.GridContainers.DisplayLayout.MaxColScrollRegions = 1
        Me.GridContainers.DisplayLayout.MaxRowScrollRegions = 1
        Appearance17.BackColor = System.Drawing.SystemColors.Window
        Appearance17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GridContainers.DisplayLayout.Override.ActiveCellAppearance = Appearance17
        Appearance18.BackColor = System.Drawing.SystemColors.Highlight
        Appearance18.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.GridContainers.DisplayLayout.Override.ActiveRowAppearance = Appearance18
        Me.GridContainers.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.GridContainers.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.[True]
        Me.GridContainers.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.GridContainers.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance19.BackColor = System.Drawing.SystemColors.Window
        Me.GridContainers.DisplayLayout.Override.CardAreaAppearance = Appearance19
        Appearance20.BorderColor = System.Drawing.Color.Silver
        Appearance20.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.GridContainers.DisplayLayout.Override.CellAppearance = Appearance20
        Me.GridContainers.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.GridContainers.DisplayLayout.Override.CellPadding = 0
        Appearance21.BackColor = System.Drawing.SystemColors.Control
        Appearance21.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance21.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance21.BorderColor = System.Drawing.SystemColors.Window
        Me.GridContainers.DisplayLayout.Override.GroupByRowAppearance = Appearance21
        Appearance22.TextHAlign = Infragistics.Win.HAlign.Left
        Me.GridContainers.DisplayLayout.Override.HeaderAppearance = Appearance22
        Me.GridContainers.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.GridContainers.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance23.BackColor = System.Drawing.SystemColors.Window
        Appearance23.BorderColor = System.Drawing.Color.Silver
        Me.GridContainers.DisplayLayout.Override.RowAppearance = Appearance23
        Me.GridContainers.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Appearance24.BackColor = System.Drawing.SystemColors.ControlLight
        Me.GridContainers.DisplayLayout.Override.TemplateAddRowAppearance = Appearance24
        Me.GridContainers.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.GridContainers.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.GridContainers.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.GridContainers.Location = New System.Drawing.Point(8, 20)
        Me.GridContainers.Name = "GridContainers"
        Me.GridContainers.Size = New System.Drawing.Size(667, 351)
        Me.GridContainers.TabIndex = 0
        Me.GridContainers.Text = "UltraGrid1"
        '
        'DataSetForm
        '
        Me.DataSetForm.DataSetName = "NewDataSet"
        Me.DataSetForm.Tables.AddRange(New System.Data.DataTable() {Me.DataTable1})
        '
        'DataTable1
        '
        Me.DataTable1.Columns.AddRange(New System.Data.DataColumn() {Me.DataColumn1, Me.DataColumn2, Me.DataColumn3, Me.DataColumn4, Me.DataColumn5, Me.DataColumn6, Me.DataColumn7, Me.DataColumn8, Me.DataColumn9, Me.DataColumn10})
        Me.DataTable1.TableName = "ListOfCntrs"
        '
        'DataColumn1
        '
        Me.DataColumn1.Caption = "Container"
        Me.DataColumn1.ColumnName = "CntrNo"
        '
        'DataColumn2
        '
        Me.DataColumn2.Caption = "Size"
        Me.DataColumn2.ColumnName = "CnSize"
        '
        'DataColumn3
        '
        Me.DataColumn3.Caption = "Type"
        Me.DataColumn3.ColumnName = "CnType"
        '
        'DataColumn4
        '
        Me.DataColumn4.Caption = "SOC"
        Me.DataColumn4.ColumnName = "SOC"
        '
        'DataColumn5
        '
        Me.DataColumn5.ColumnName = "POD"
        '
        'DataColumn6
        '
        Me.DataColumn6.Caption = "FUll/Empty"
        Me.DataColumn6.ColumnName = "FLE"
        '
        'DataColumn7
        '
        Me.DataColumn7.Caption = "Status"
        Me.DataColumn7.ColumnName = "CurrentStatus"
        '
        'DataColumn8
        '
        Me.DataColumn8.Caption = "Discharge"
        Me.DataColumn8.ColumnName = "DschCmpl"
        Me.DataColumn8.DataType = GetType(Date)
        '
        'DataColumn9
        '
        Me.DataColumn9.ColumnName = "ToLine"
        Me.DataColumn9.DataType = GetType(Date)
        '
        'DataColumn10
        '
        Me.DataColumn10.ColumnName = "Sel"
        Me.DataColumn10.DataType = GetType(Boolean)
        '
        'UltraLabel4
        '
        Me.UltraLabel4.Location = New System.Drawing.Point(473, 52)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.Size = New System.Drawing.Size(42, 20)
        Me.UltraLabel4.TabIndex = 16
        Me.UltraLabel4.Text = "To Line"
        '
        'Voyage
        '
        Me.Voyage.Location = New System.Drawing.Point(297, 22)
        Me.Voyage.Name = "Voyage"
        Me.Voyage.Size = New System.Drawing.Size(153, 24)
        Me.Voyage.TabIndex = 1
        Me.Voyage.VoyageID = New System.Guid("00000000-0000-0000-0000-000000000000")
        '
        'ToLine
        '
        Me.ToLine.DateValue = Nothing
        Me.ToLine.Location = New System.Drawing.Point(521, 50)
        Me.ToLine.Name = "ToLine"
        Me.ToLine.Size = New System.Drawing.Size(170, 20)
        Me.ToLine.TabIndex = 4
        '
        'Depot
        '
        Me.Depot.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Depot.Code = ""
        Me.Depot.CustomShowAll = False
        Me.Depot.Location = New System.Drawing.Point(520, 21)
        Me.Depot.Name = "Depot"
        Me.Depot.Size = New System.Drawing.Size(171, 22)
        Me.Depot.TabIndex = 2
        '
        'UltraLabel3
        '
        Me.UltraLabel3.Location = New System.Drawing.Point(26, 52)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(80, 20)
        Me.UltraLabel3.TabIndex = 14
        Me.UltraLabel3.Text = "Discharge date"
        '
        'UltraLabel2
        '
        Me.UltraLabel2.Location = New System.Drawing.Point(479, 22)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(35, 20)
        Me.UltraLabel2.TabIndex = 12
        Me.UltraLabel2.Text = "Depot"
        '
        'DschCmpl
        '
        Me.DschCmpl.DateValue = Nothing
        Me.DschCmpl.Location = New System.Drawing.Point(112, 52)
        Me.DschCmpl.Name = "DschCmpl"
        Me.DschCmpl.Size = New System.Drawing.Size(179, 20)
        Me.DschCmpl.TabIndex = 3
        '
        'TopToolBar
        '
        Me.TopToolBar.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.TopToolBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ButtonFind, Me.ButtonSave})
        Me.TopToolBar.Location = New System.Drawing.Point(0, 0)
        Me.TopToolBar.Name = "TopToolBar"
        Me.TopToolBar.Size = New System.Drawing.Size(752, 31)
        Me.TopToolBar.TabIndex = 17
        Me.TopToolBar.Text = "ToolStrip1"
        '
        'ButtonFind
        '
        Me.ButtonFind.Image = CType(resources.GetObject("ButtonFind.Image"), System.Drawing.Image)
        Me.ButtonFind.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonFind.Name = "ButtonFind"
        Me.ButtonFind.Size = New System.Drawing.Size(55, 28)
        Me.ButtonFind.Text = "Find"
        '
        'ButtonSave
        '
        Me.ButtonSave.Image = CType(resources.GetObject("ButtonSave.Image"), System.Drawing.Image)
        Me.ButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonSave.Name = "ButtonSave"
        Me.ButtonSave.Size = New System.Drawing.Size(59, 28)
        Me.ButtonSave.Text = "Save"
        '
        'FormErrorProvider
        '
        Me.FormErrorProvider.ContainerControl = Me
        '
        'Lbl20
        '
        Me.Lbl20.AutoSize = True
        Me.Lbl20.Location = New System.Drawing.Point(25, 466)
        Me.Lbl20.Name = "Lbl20"
        Me.Lbl20.Size = New System.Drawing.Size(65, 13)
        Me.Lbl20.TabIndex = 17
        Me.Lbl20.Text = "TOTAL 20' :"
        '
        'Lbl40
        '
        Me.Lbl40.AutoSize = True
        Me.Lbl40.Location = New System.Drawing.Point(136, 466)
        Me.Lbl40.Name = "Lbl40"
        Me.Lbl40.Size = New System.Drawing.Size(65, 13)
        Me.Lbl40.TabIndex = 18
        Me.Lbl40.Text = "TOTAL 40' :"
        '
        'LBL45
        '
        Me.LBL45.AutoSize = True
        Me.LBL45.Location = New System.Drawing.Point(251, 466)
        Me.LBL45.Name = "LBL45"
        Me.LBL45.Size = New System.Drawing.Size(65, 13)
        Me.LBL45.TabIndex = 19
        Me.LBL45.Text = "TOTAL 45' :"
        '
        'FrmEcsImport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(752, 550)
        Me.Controls.Add(Me.FillPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FrmEcsImport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "E.C.S. Import"
        Me.FillPanel.ResumeLayout(False)
        Me.FillPanel.PerformLayout()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        CType(Me.GroupBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox.ResumeLayout(False)
        CType(Me.GridContainers, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSetForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TopToolBar.ResumeLayout(False)
        Me.TopToolBar.PerformLayout()
        CType(Me.FormErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents FillPanel As System.Windows.Forms.Panel
    Friend WithEvents GroupBox As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents GridContainers As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents DataSetForm As System.Data.DataSet
    Friend WithEvents DataTable1 As System.Data.DataTable
    Friend WithEvents DataColumn1 As System.Data.DataColumn
    Friend WithEvents DataColumn2 As System.Data.DataColumn
    Friend WithEvents DataColumn3 As System.Data.DataColumn
    Friend WithEvents DataColumn4 As System.Data.DataColumn
    Friend WithEvents DataColumn5 As System.Data.DataColumn
    Friend WithEvents DataColumn6 As System.Data.DataColumn
    Friend WithEvents Voyage As Shipping.UserComboVoyage
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Vessel As Shipping.UserComboVessel
    Friend WithEvents DataColumn7 As System.Data.DataColumn
    Friend WithEvents DataColumn8 As System.Data.DataColumn
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Depot As Shipping.UserComboCode
    Friend WithEvents DschCmpl As Shipping.UserGnrlDate
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents ToLine As Shipping.UserGnrlDate
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents DataColumn9 As System.Data.DataColumn
    Friend WithEvents DataColumn10 As System.Data.DataColumn
    Friend WithEvents FormErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents TopToolBar As System.Windows.Forms.ToolStrip
    Friend WithEvents ButtonFind As System.Windows.Forms.ToolStripButton
    Friend WithEvents ButtonSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents LBL45 As System.Windows.Forms.Label
    Friend WithEvents Lbl40 As System.Windows.Forms.Label
    Friend WithEvents Lbl20 As System.Windows.Forms.Label
End Class
