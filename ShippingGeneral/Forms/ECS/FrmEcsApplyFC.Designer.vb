<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEcsApplyFC
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
        Me.GridData = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.GroupBoxMain = New Infragistics.Win.Misc.UltraGroupBox
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.DropDownType = New Infragistics.Win.UltraWinGrid.UltraDropDown
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel
        Me.MenuItem = New Shipping.UserMenuItem
        Me.dTo = New Shipping.UserGnrlDate
        Me.dFrom = New Shipping.UserGnrlDate
        Me.Depot = New Shipping.UserComboCode
        Me.Remarks = New Shipping.UserText
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.GridData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupBoxMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxMain.SuspendLayout()
        CType(Me.DropDownType, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.MenuItem, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.GridData, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBoxMain, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 139.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 316.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(829, 596)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'GridData
        '
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.GridData.DisplayLayout.Appearance = Appearance1
        Me.GridData.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.GridData.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.SystemColors.Window
        Me.GridData.DisplayLayout.GroupByBox.Appearance = Appearance2
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.GridData.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
        Me.GridData.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance4.BackColor2 = System.Drawing.SystemColors.Control
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.GridData.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
        Appearance5.BackColor = System.Drawing.SystemColors.Window
        Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GridData.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.SystemColors.Highlight
        Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.GridData.DisplayLayout.Override.ActiveRowAppearance = Appearance6
        Me.GridData.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.GridData.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[True]
        Me.GridData.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.GridData.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.[True]
        Me.GridData.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[True]
        Me.GridData.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.GridData.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Me.GridData.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.GridData.DisplayLayout.Override.CellAppearance = Appearance8
        Me.GridData.DisplayLayout.Override.CellPadding = 0
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.GridData.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance10.TextHAlignAsString = "Left"
        Me.GridData.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.GridData.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.GridData.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Me.GridData.DisplayLayout.Override.RowAppearance = Appearance11
        Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
        Me.GridData.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
        Me.GridData.DisplayLayout.UseFixedHeaders = True
        Me.GridData.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.GridData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridData.Location = New System.Drawing.Point(3, 182)
        Me.GridData.Name = "GridData"
        Me.GridData.Size = New System.Drawing.Size(823, 411)
        Me.GridData.TabIndex = 1
        Me.GridData.Text = "UltraGrid1"
        '
        'GroupBoxMain
        '
        Me.GroupBoxMain.Controls.Add(Me.UltraLabel2)
        Me.GroupBoxMain.Controls.Add(Me.UltraLabel1)
        Me.GroupBoxMain.Controls.Add(Me.dTo)
        Me.GroupBoxMain.Controls.Add(Me.dFrom)
        Me.GroupBoxMain.Controls.Add(Me.DropDownType)
        Me.GroupBoxMain.Controls.Add(Me.UltraLabel3)
        Me.GroupBoxMain.Controls.Add(Me.Depot)
        Me.GroupBoxMain.Controls.Add(Me.UltraLabel4)
        Me.GroupBoxMain.Controls.Add(Me.Remarks)
        Me.GroupBoxMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBoxMain.Location = New System.Drawing.Point(3, 43)
        Me.GroupBoxMain.Name = "GroupBoxMain"
        Me.GroupBoxMain.Size = New System.Drawing.Size(823, 133)
        Me.GroupBoxMain.TabIndex = 1
        Me.GroupBoxMain.Text = "Change Data To"
        '
        'UltraLabel2
        '
        Me.UltraLabel2.Location = New System.Drawing.Point(225, 33)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(54, 21)
        Me.UltraLabel2.TabIndex = 75
        Me.UltraLabel2.Text = "D.O. To"
        '
        'UltraLabel1
        '
        Me.UltraLabel1.Location = New System.Drawing.Point(19, 33)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(67, 21)
        Me.UltraLabel1.TabIndex = 74
        Me.UltraLabel1.Text = "D.O. From"
        '
        'DropDownType
        '
        Appearance13.BackColor = System.Drawing.SystemColors.Window
        Appearance13.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.DropDownType.DisplayLayout.Appearance = Appearance13
        Me.DropDownType.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.DropDownType.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance14.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance14.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance14.BorderColor = System.Drawing.SystemColors.Window
        Me.DropDownType.DisplayLayout.GroupByBox.Appearance = Appearance14
        Appearance15.ForeColor = System.Drawing.SystemColors.GrayText
        Me.DropDownType.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance15
        Me.DropDownType.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance16.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance16.BackColor2 = System.Drawing.SystemColors.Control
        Appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance16.ForeColor = System.Drawing.SystemColors.GrayText
        Me.DropDownType.DisplayLayout.GroupByBox.PromptAppearance = Appearance16
        Me.DropDownType.DisplayLayout.MaxColScrollRegions = 1
        Me.DropDownType.DisplayLayout.MaxRowScrollRegions = 1
        Appearance17.BackColor = System.Drawing.SystemColors.Window
        Appearance17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DropDownType.DisplayLayout.Override.ActiveCellAppearance = Appearance17
        Appearance18.BackColor = System.Drawing.SystemColors.Highlight
        Appearance18.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.DropDownType.DisplayLayout.Override.ActiveRowAppearance = Appearance18
        Me.DropDownType.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.DropDownType.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance19.BackColor = System.Drawing.SystemColors.Window
        Me.DropDownType.DisplayLayout.Override.CardAreaAppearance = Appearance19
        Appearance20.BorderColor = System.Drawing.Color.Silver
        Appearance20.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.DropDownType.DisplayLayout.Override.CellAppearance = Appearance20
        Me.DropDownType.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.DropDownType.DisplayLayout.Override.CellPadding = 0
        Appearance21.BackColor = System.Drawing.SystemColors.Control
        Appearance21.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance21.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance21.BorderColor = System.Drawing.SystemColors.Window
        Me.DropDownType.DisplayLayout.Override.GroupByRowAppearance = Appearance21
        Appearance22.TextHAlignAsString = "Left"
        Me.DropDownType.DisplayLayout.Override.HeaderAppearance = Appearance22
        Me.DropDownType.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.DropDownType.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance23.BackColor = System.Drawing.SystemColors.Window
        Appearance23.BorderColor = System.Drawing.Color.Silver
        Me.DropDownType.DisplayLayout.Override.RowAppearance = Appearance23
        Me.DropDownType.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance24.BackColor = System.Drawing.SystemColors.ControlLight
        Me.DropDownType.DisplayLayout.Override.TemplateAddRowAppearance = Appearance24
        Me.DropDownType.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.DropDownType.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.DropDownType.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.DropDownType.Location = New System.Drawing.Point(508, 193)
        Me.DropDownType.Name = "DropDownType"
        Me.DropDownType.PreferredDropDownSize = New System.Drawing.Size(0, 0)
        Me.DropDownType.Size = New System.Drawing.Size(103, 38)
        Me.DropDownType.TabIndex = 7
        Me.DropDownType.Text = "UltraDropDown1"
        Me.DropDownType.Visible = False
        '
        'UltraLabel3
        '
        Me.UltraLabel3.Location = New System.Drawing.Point(19, 95)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(49, 21)
        Me.UltraLabel3.TabIndex = 70
        Me.UltraLabel3.Text = "Depot"
        '
        'UltraLabel4
        '
        Me.UltraLabel4.Location = New System.Drawing.Point(19, 68)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.Size = New System.Drawing.Size(49, 21)
        Me.UltraLabel4.TabIndex = 71
        Me.UltraLabel4.Text = "Remarks"
        '
        'MenuItem
        '
        Me.MenuItem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MenuItem.Location = New System.Drawing.Point(3, 3)
        Me.MenuItem.Name = "MenuItem"
        Me.MenuItem.ShowAdditional = False
        Me.MenuItem.ShowCancel = False
        Me.MenuItem.ShowConfirm = False
        Me.MenuItem.ShowDelete = False
        Me.MenuItem.ShowDeposits = False
        Me.MenuItem.ShowDeSelectAll = True
        Me.MenuItem.ShowEdit = False
        Me.MenuItem.ShowExcel = True
        Me.MenuItem.ShowFileOpen = False
        Me.MenuItem.ShowNew = False
        Me.MenuItem.ShowPickup = True
        Me.MenuItem.ShowPrint = False
        Me.MenuItem.ShowProcess = False
        Me.MenuItem.ShowRecivedItems = False
        Me.MenuItem.ShowRefresh = False
        Me.MenuItem.ShowRest = False
        Me.MenuItem.ShowSave = True
        Me.MenuItem.ShowSelectAll = True
        Me.MenuItem.Size = New System.Drawing.Size(823, 34)
        Me.MenuItem.TabIndex = 0
        '
        'dTo
        '
        Me.dTo.DateValue = Nothing
        Me.dTo.Location = New System.Drawing.Point(285, 30)
        Me.dTo.Name = "dTo"
        Me.dTo.ShowTime = False
        Me.dTo.Size = New System.Drawing.Size(143, 24)
        Me.dTo.TabIndex = 1
        '
        'dFrom
        '
        Me.dFrom.DateValue = Nothing
        Me.dFrom.Location = New System.Drawing.Point(92, 30)
        Me.dFrom.Name = "dFrom"
        Me.dFrom.ShowTime = False
        Me.dFrom.Size = New System.Drawing.Size(127, 24)
        Me.dFrom.TabIndex = 0
        '
        'Depot
        '
        Me.Depot.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Depot.Code = ""
        Me.Depot.CustomShowAll = False
        Me.Depot.Location = New System.Drawing.Point(92, 95)
        Me.Depot.Name = "Depot"
        Me.Depot.Size = New System.Drawing.Size(164, 21)
        Me.Depot.TabIndex = 3
        '
        'Remarks
        '
        Me.Remarks.AutoComplete = False
        Me.Remarks.AutoCompleteColumnName = Nothing
        Me.Remarks.AutoCompleteExtraWhere = Nothing
        Me.Remarks.AutoCompleteTableName = Nothing
        Me.Remarks.BackColor = System.Drawing.Color.Transparent
        Me.Remarks.CustomMaxLength = CType(100, Byte)
        Me.Remarks.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Remarks.Location = New System.Drawing.Point(92, 68)
        Me.Remarks.Name = "Remarks"
        Me.Remarks.Size = New System.Drawing.Size(336, 21)
        Me.Remarks.TabIndex = 2
        Me.Remarks.TextValue = ""
        '
        'FrmEcsApplyFC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(829, 596)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "FrmEcsApplyFC"
        Me.Text = "APPLY FU BY D.O."
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.GridData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupBoxMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxMain.ResumeLayout(False)
        CType(Me.DropDownType, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents MenuItem As Shipping.UserMenuItem
    Friend WithEvents GridData As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents GroupBoxMain As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents DropDownType As Infragistics.Win.UltraWinGrid.UltraDropDown
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Depot As Shipping.UserComboCode
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Remarks As Shipping.UserText
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents dTo As Shipping.UserGnrlDate
    Friend WithEvents dFrom As Shipping.UserGnrlDate
End Class
