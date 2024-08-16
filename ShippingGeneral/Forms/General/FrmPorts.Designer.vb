<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPorts
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
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("TB_Ports", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID")
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PortCode")
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PortName")
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FPortName", -1, Nothing, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Descending, False)
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Country")
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.GeneralForms = New Shipping.UserGeneralForms
        Me.GroupBox = New Infragistics.Win.Misc.UltraGroupBox
        Me.FPortName = New Shipping.UserTextFarsi
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.Country = New Shipping.UserComboCode
        Me.PortName = New Shipping.UserText
        Me.PortCode = New Shipping.UserText
        Me.lbl = New Infragistics.Win.Misc.UltraLabel
        Me.GroupBoxSearch = New Infragistics.Win.Misc.UltraGroupBox
        Me.TxtSrch = New Shipping.UserText
        Me.FormDs = New System.Data.DataSet
        Me.DataTable1 = New System.Data.DataTable
        Me.DataColumn1 = New System.Data.DataColumn
        Me.DataColumn2 = New System.Data.DataColumn
        Me.DataColumn3 = New System.Data.DataColumn
        Me.DataColumn4 = New System.Data.DataColumn
        Me.DataColumn5 = New System.Data.DataColumn
        Me.GridPorts = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        CType(Me.GroupBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox.SuspendLayout()
        CType(Me.GroupBoxSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxSearch.SuspendLayout()
        CType(Me.FormDs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridPorts, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GeneralForms
        '
        Me.GeneralForms.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GeneralForms.Location = New System.Drawing.Point(0, 0)
        Me.GeneralForms.Name = "GeneralForms"
        Me.GeneralForms.ShowHistoryButtom = False
        Me.GeneralForms.ShowNavigate = False
        Me.GeneralForms.ShowPrintButtom = False
        Me.GeneralForms.Size = New System.Drawing.Size(546, 518)
        Me.GeneralForms.TabIndex = 0
        '
        'GroupBox
        '
        Appearance1.BackColor = System.Drawing.Color.CornflowerBlue
        Appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance1.BorderColor = System.Drawing.Color.White
        Appearance1.BorderColor3DBase = System.Drawing.Color.White
        Me.GroupBox.Appearance = Appearance1
        Me.GroupBox.BackColorInternal = System.Drawing.SystemColors.ControlLightLight
        Me.GroupBox.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.RectangularRaised
        Me.GroupBox.Controls.Add(Me.FPortName)
        Me.GroupBox.Controls.Add(Me.UltraLabel4)
        Me.GroupBox.Controls.Add(Me.UltraLabel3)
        Me.GroupBox.Controls.Add(Me.UltraLabel2)
        Me.GroupBox.Controls.Add(Me.UltraLabel1)
        Me.GroupBox.Controls.Add(Me.Country)
        Me.GroupBox.Controls.Add(Me.PortName)
        Me.GroupBox.Controls.Add(Me.PortCode)
        Me.GroupBox.Location = New System.Drawing.Point(16, 81)
        Me.GroupBox.Name = "GroupBox"
        Me.GroupBox.Size = New System.Drawing.Size(491, 126)
        Me.GroupBox.TabIndex = 1
        '
        'FPortName
        '
        Me.FPortName.IsMultiline = False
        Me.FPortName.Location = New System.Drawing.Point(80, 62)
        Me.FPortName.Name = "FPortName"
        Me.FPortName.Size = New System.Drawing.Size(348, 21)
        Me.FPortName.TabIndex = 3
        Me.FPortName.TextValue = ""
        '
        'UltraLabel4
        '
        Appearance2.BackHatchStyle = Infragistics.Win.BackHatchStyle.None
        Me.UltraLabel4.Appearance = Appearance2
        Me.UltraLabel4.BackColorInternal = System.Drawing.Color.CornflowerBlue
        Me.UltraLabel4.Location = New System.Drawing.Point(15, 89)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.Size = New System.Drawing.Size(59, 18)
        Me.UltraLabel4.TabIndex = 18
        Me.UltraLabel4.Text = "Country"
        '
        'UltraLabel3
        '
        Appearance3.BackHatchStyle = Infragistics.Win.BackHatchStyle.None
        Me.UltraLabel3.Appearance = Appearance3
        Me.UltraLabel3.BackColorInternal = System.Drawing.Color.CornflowerBlue
        Me.UltraLabel3.Location = New System.Drawing.Point(15, 67)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(59, 15)
        Me.UltraLabel3.TabIndex = 17
        Me.UltraLabel3.Text = "F. Name "
        '
        'UltraLabel2
        '
        Appearance4.BackHatchStyle = Infragistics.Win.BackHatchStyle.None
        Me.UltraLabel2.Appearance = Appearance4
        Me.UltraLabel2.BackColorInternal = System.Drawing.Color.CornflowerBlue
        Me.UltraLabel2.Location = New System.Drawing.Point(15, 45)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(59, 15)
        Me.UltraLabel2.TabIndex = 16
        Me.UltraLabel2.Text = "Name "
        '
        'UltraLabel1
        '
        Appearance5.BackHatchStyle = Infragistics.Win.BackHatchStyle.None
        Me.UltraLabel1.Appearance = Appearance5
        Me.UltraLabel1.BackColorInternal = System.Drawing.Color.CornflowerBlue
        Me.UltraLabel1.Location = New System.Drawing.Point(15, 19)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(59, 20)
        Me.UltraLabel1.TabIndex = 15
        Me.UltraLabel1.Text = "Code"
        '
        'Country
        '
        Me.Country.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Country.Code = ""
        Me.Country.CustomShowAll = False
        Me.Country.Location = New System.Drawing.Point(80, 85)
        Me.Country.Name = "Country"
        Me.Country.Size = New System.Drawing.Size(145, 21)
        Me.Country.TabIndex = 4
        '
        'PortName
        '
        Me.PortName.AutoComplete = False
        Me.PortName.AutoCompleteColumnName = Nothing
        Me.PortName.AutoCompleteExtraWhere = Nothing
        Me.PortName.AutoCompleteTableName = Nothing
        Me.PortName.BackColor = System.Drawing.Color.Transparent
        Me.PortName.CustomMaxLength = CType(100, Byte)
        Me.PortName.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.PortName.Location = New System.Drawing.Point(80, 40)
        Me.PortName.Name = "PortName"
        Me.PortName.Size = New System.Drawing.Size(348, 20)
        Me.PortName.TabIndex = 2
        Me.PortName.TextValue = ""
        '
        'PortCode
        '
        Me.PortCode.AutoComplete = False
        Me.PortCode.AutoCompleteColumnName = Nothing
        Me.PortCode.AutoCompleteExtraWhere = Nothing
        Me.PortCode.AutoCompleteTableName = Nothing
        Me.PortCode.BackColor = System.Drawing.Color.Transparent
        Me.PortCode.CustomMaxLength = CType(100, Byte)
        Me.PortCode.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.PortCode.Location = New System.Drawing.Point(80, 18)
        Me.PortCode.Name = "PortCode"
        Me.PortCode.Size = New System.Drawing.Size(67, 20)
        Me.PortCode.TabIndex = 1
        Me.PortCode.TextValue = ""
        '
        'lbl
        '
        Appearance6.BackHatchStyle = Infragistics.Win.BackHatchStyle.None
        Me.lbl.Appearance = Appearance6
        Me.lbl.BackColorInternal = System.Drawing.Color.CornflowerBlue
        Me.lbl.Location = New System.Drawing.Point(15, 22)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(123, 15)
        Me.lbl.TabIndex = 9
        Me.lbl.Text = "Search Port Name "
        '
        'GroupBoxSearch
        '
        Appearance7.BackColor = System.Drawing.Color.CornflowerBlue
        Appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance7.BorderColor = System.Drawing.Color.White
        Appearance7.BorderColor3DBase = System.Drawing.Color.White
        Me.GroupBoxSearch.Appearance = Appearance7
        Me.GroupBoxSearch.BackColorInternal = System.Drawing.SystemColors.ControlLightLight
        Me.GroupBoxSearch.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.RectangularRaised
        Me.GroupBoxSearch.Controls.Add(Me.TxtSrch)
        Me.GroupBoxSearch.Controls.Add(Me.lbl)
        Me.GroupBoxSearch.Location = New System.Drawing.Point(17, 20)
        Me.GroupBoxSearch.Name = "GroupBoxSearch"
        Me.GroupBoxSearch.Size = New System.Drawing.Size(491, 55)
        Me.GroupBoxSearch.TabIndex = 0
        '
        'TxtSrch
        '
        Me.TxtSrch.AutoComplete = False
        Me.TxtSrch.AutoCompleteColumnName = Nothing
        Me.TxtSrch.AutoCompleteExtraWhere = Nothing
        Me.TxtSrch.AutoCompleteTableName = Nothing
        Me.TxtSrch.BackColor = System.Drawing.Color.Transparent
        Me.TxtSrch.CustomMaxLength = CType(100, Byte)
        Me.TxtSrch.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.TxtSrch.Location = New System.Drawing.Point(120, 19)
        Me.TxtSrch.Name = "TxtSrch"
        Me.TxtSrch.Size = New System.Drawing.Size(348, 20)
        Me.TxtSrch.TabIndex = 0
        Me.TxtSrch.TextValue = ""
        '
        'FormDs
        '
        Me.FormDs.DataSetName = "NewDataSet"
        Me.FormDs.Tables.AddRange(New System.Data.DataTable() {Me.DataTable1})
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
        'GridPorts
        '
        Me.GridPorts.DataMember = "TB_Ports"
        Me.GridPorts.DataSource = Me.FormDs
        Appearance8.BackColor = System.Drawing.SystemColors.Window
        Appearance8.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.GridPorts.DisplayLayout.Appearance = Appearance8
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn3.Header.VisiblePosition = 2
        UltraGridColumn4.Header.VisiblePosition = 3
        UltraGridColumn5.Header.VisiblePosition = 4
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5})
        Me.GridPorts.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.GridPorts.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.GridPorts.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance9.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.GridPorts.DisplayLayout.GroupByBox.Appearance = Appearance9
        Appearance10.ForeColor = System.Drawing.SystemColors.GrayText
        Me.GridPorts.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance10
        Me.GridPorts.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance11.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance11.BackColor2 = System.Drawing.SystemColors.Control
        Appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance11.ForeColor = System.Drawing.SystemColors.GrayText
        Me.GridPorts.DisplayLayout.GroupByBox.PromptAppearance = Appearance11
        Me.GridPorts.DisplayLayout.MaxColScrollRegions = 1
        Me.GridPorts.DisplayLayout.MaxRowScrollRegions = 1
        Appearance12.BackColor = System.Drawing.SystemColors.Window
        Appearance12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GridPorts.DisplayLayout.Override.ActiveCellAppearance = Appearance12
        Appearance13.BackColor = System.Drawing.SystemColors.Highlight
        Appearance13.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.GridPorts.DisplayLayout.Override.ActiveRowAppearance = Appearance13
        Me.GridPorts.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.GridPorts.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance14.BackColor = System.Drawing.SystemColors.Window
        Me.GridPorts.DisplayLayout.Override.CardAreaAppearance = Appearance14
        Appearance15.BorderColor = System.Drawing.Color.Silver
        Appearance15.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.GridPorts.DisplayLayout.Override.CellAppearance = Appearance15
        Me.GridPorts.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.GridPorts.DisplayLayout.Override.CellPadding = 0
        Appearance16.BackColor = System.Drawing.SystemColors.Control
        Appearance16.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance16.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance16.BorderColor = System.Drawing.SystemColors.Window
        Me.GridPorts.DisplayLayout.Override.GroupByRowAppearance = Appearance16
        Appearance17.TextHAlignAsString = "Left"
        Me.GridPorts.DisplayLayout.Override.HeaderAppearance = Appearance17
        Me.GridPorts.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.GridPorts.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance18.BackColor = System.Drawing.SystemColors.Window
        Appearance18.BorderColor = System.Drawing.Color.Silver
        Me.GridPorts.DisplayLayout.Override.RowAppearance = Appearance18
        Me.GridPorts.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance19.BackColor = System.Drawing.SystemColors.ControlLight
        Me.GridPorts.DisplayLayout.Override.TemplateAddRowAppearance = Appearance19
        Me.GridPorts.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.GridPorts.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.GridPorts.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.GridPorts.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.GridPorts.Location = New System.Drawing.Point(17, 212)
        Me.GridPorts.Name = "GridPorts"
        Me.GridPorts.Size = New System.Drawing.Size(490, 238)
        Me.GridPorts.TabIndex = 3
        Me.GridPorts.Text = "UltraGrid1"
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.GroupBoxSearch)
        Me.UltraGroupBox1.Controls.Add(Me.GridPorts)
        Me.UltraGroupBox1.Controls.Add(Me.GroupBox)
        Me.UltraGroupBox1.Location = New System.Drawing.Point(12, 42)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(524, 467)
        Me.UltraGroupBox1.TabIndex = 4
        Me.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.VisualStudio2005
        '
        'FrmPorts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(546, 518)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Controls.Add(Me.GeneralForms)
        Me.Name = "FrmPorts"
        Me.Text = "PORTS"
        CType(Me.GroupBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox.ResumeLayout(False)
        CType(Me.GroupBoxSearch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxSearch.ResumeLayout(False)
        CType(Me.FormDs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridPorts, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GeneralForms As Shipping.UserGeneralForms
    Friend WithEvents GroupBox As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents lbl As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents GroupBoxSearch As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents TxtSrch As Shipping.UserText
    Friend WithEvents FormDs As System.Data.DataSet
    Friend WithEvents DataTable1 As System.Data.DataTable
    Friend WithEvents DataColumn1 As System.Data.DataColumn
    Friend WithEvents DataColumn2 As System.Data.DataColumn
    Friend WithEvents DataColumn3 As System.Data.DataColumn
    Friend WithEvents DataColumn4 As System.Data.DataColumn
    Friend WithEvents DataColumn5 As System.Data.DataColumn
    Friend WithEvents GridPorts As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents PortName As Shipping.UserText
    Friend WithEvents PortCode As Shipping.UserText
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Country As Shipping.UserComboCode
    Friend WithEvents FPortName As Shipping.UserTextFarsi
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
End Class
