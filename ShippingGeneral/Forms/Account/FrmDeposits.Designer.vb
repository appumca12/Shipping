<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDeposits
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
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("TB_Deposits", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID")
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("BLID")
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ChargesCodes")
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Remarks")
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Amount")
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ReturnBackDate")
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ReturnBackAmount")
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ReturnBackRef")
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PaidRef", -1, Nothing, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Descending, False)
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
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.DropDownCharges = New Infragistics.Win.UltraWinGrid.UltraDropDown
        Me.GridDeposits = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.FormDataSet = New System.Data.DataSet
        Me.TB_Deposits = New System.Data.DataTable
        Me.DataColumn1 = New System.Data.DataColumn
        Me.DataColumn2 = New System.Data.DataColumn
        Me.DataColumn3 = New System.Data.DataColumn
        Me.DataColumn4 = New System.Data.DataColumn
        Me.DataColumn5 = New System.Data.DataColumn
        Me.DataColumn6 = New System.Data.DataColumn
        Me.DataColumn7 = New System.Data.DataColumn
        Me.DataColumn8 = New System.Data.DataColumn
        Me.UserMenuItem1 = New Shipping.UserMenuItem
        Me.DataColumn9 = New System.Data.DataColumn
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.DropDownCharges, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridDeposits, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FormDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TB_Deposits, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.DropDownCharges)
        Me.UltraGroupBox1.Controls.Add(Me.GridDeposits)
        Me.UltraGroupBox1.Location = New System.Drawing.Point(12, 37)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(1063, 341)
        Me.UltraGroupBox1.TabIndex = 2
        Me.UltraGroupBox1.Text = "List Of Items"
        '
        'DropDownCharges
        '
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.DropDownCharges.DisplayLayout.Appearance = Appearance1
        Me.DropDownCharges.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.DropDownCharges.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.SystemColors.Window
        Me.DropDownCharges.DisplayLayout.GroupByBox.Appearance = Appearance2
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.DropDownCharges.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
        Me.DropDownCharges.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance4.BackColor2 = System.Drawing.SystemColors.Control
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.DropDownCharges.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
        Me.DropDownCharges.DisplayLayout.MaxColScrollRegions = 1
        Me.DropDownCharges.DisplayLayout.MaxRowScrollRegions = 1
        Appearance5.BackColor = System.Drawing.SystemColors.Window
        Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DropDownCharges.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.SystemColors.Highlight
        Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.DropDownCharges.DisplayLayout.Override.ActiveRowAppearance = Appearance6
        Me.DropDownCharges.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.DropDownCharges.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Me.DropDownCharges.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.DropDownCharges.DisplayLayout.Override.CellAppearance = Appearance8
        Me.DropDownCharges.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.DropDownCharges.DisplayLayout.Override.CellPadding = 0
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.DropDownCharges.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance10.TextHAlignAsString = "Left"
        Me.DropDownCharges.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.DropDownCharges.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.DropDownCharges.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Me.DropDownCharges.DisplayLayout.Override.RowAppearance = Appearance11
        Me.DropDownCharges.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
        Me.DropDownCharges.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
        Me.DropDownCharges.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.DropDownCharges.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.DropDownCharges.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.DropDownCharges.Location = New System.Drawing.Point(21, 210)
        Me.DropDownCharges.Name = "DropDownCharges"
        Me.DropDownCharges.PreferredDropDownSize = New System.Drawing.Size(0, 0)
        Me.DropDownCharges.Size = New System.Drawing.Size(118, 68)
        Me.DropDownCharges.TabIndex = 12
        Me.DropDownCharges.Text = "UltraDropDown1"
        Me.DropDownCharges.Visible = False
        '
        'GridDeposits
        '
        Me.GridDeposits.DataMember = "TB_Deposits"
        Me.GridDeposits.DataSource = Me.FormDataSet
        Appearance13.BackColor = System.Drawing.SystemColors.Window
        Appearance13.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.GridDeposits.DisplayLayout.Appearance = Appearance13
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Width = 33
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn3.Header.VisiblePosition = 2
        UltraGridColumn4.Header.VisiblePosition = 3
        UltraGridColumn5.Header.VisiblePosition = 4
        UltraGridColumn6.Header.VisiblePosition = 6
        UltraGridColumn7.Header.VisiblePosition = 7
        UltraGridColumn8.Header.VisiblePosition = 8
        UltraGridColumn10.Header.VisiblePosition = 5
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn10})
        Me.GridDeposits.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.GridDeposits.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.GridDeposits.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance14.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance14.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance14.BorderColor = System.Drawing.SystemColors.Window
        Me.GridDeposits.DisplayLayout.GroupByBox.Appearance = Appearance14
        Appearance15.ForeColor = System.Drawing.SystemColors.GrayText
        Me.GridDeposits.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance15
        Me.GridDeposits.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.GridDeposits.DisplayLayout.GroupByBox.Hidden = True
        Appearance16.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance16.BackColor2 = System.Drawing.SystemColors.Control
        Appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance16.ForeColor = System.Drawing.SystemColors.GrayText
        Me.GridDeposits.DisplayLayout.GroupByBox.PromptAppearance = Appearance16
        Appearance17.BackColor = System.Drawing.SystemColors.Window
        Appearance17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GridDeposits.DisplayLayout.Override.ActiveCellAppearance = Appearance17
        Appearance18.BackColor = System.Drawing.SystemColors.Highlight
        Appearance18.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.GridDeposits.DisplayLayout.Override.ActiveRowAppearance = Appearance18
        Me.GridDeposits.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.GridDeposits.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[True]
        Me.GridDeposits.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.GridDeposits.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.[False]
        Me.GridDeposits.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[True]
        Me.GridDeposits.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.GridDeposits.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance19.BackColor = System.Drawing.SystemColors.Window
        Me.GridDeposits.DisplayLayout.Override.CardAreaAppearance = Appearance19
        Appearance20.BorderColor = System.Drawing.Color.Silver
        Appearance20.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.GridDeposits.DisplayLayout.Override.CellAppearance = Appearance20
        Me.GridDeposits.DisplayLayout.Override.CellPadding = 0
        Appearance21.BackColor = System.Drawing.SystemColors.Control
        Appearance21.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance21.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance21.BorderColor = System.Drawing.SystemColors.Window
        Me.GridDeposits.DisplayLayout.Override.GroupByRowAppearance = Appearance21
        Appearance22.TextHAlignAsString = "Left"
        Me.GridDeposits.DisplayLayout.Override.HeaderAppearance = Appearance22
        Me.GridDeposits.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.GridDeposits.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance23.BackColor = System.Drawing.SystemColors.Window
        Appearance23.BorderColor = System.Drawing.Color.Silver
        Me.GridDeposits.DisplayLayout.Override.RowAppearance = Appearance23
        Appearance24.BackColor = System.Drawing.SystemColors.ControlLight
        Me.GridDeposits.DisplayLayout.Override.TemplateAddRowAppearance = Appearance24
        Me.GridDeposits.DisplayLayout.UseFixedHeaders = True
        Me.GridDeposits.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridDeposits.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.GridDeposits.Location = New System.Drawing.Point(3, 16)
        Me.GridDeposits.Name = "GridDeposits"
        Me.GridDeposits.Size = New System.Drawing.Size(1057, 322)
        Me.GridDeposits.TabIndex = 12
        Me.GridDeposits.Text = "UltraGrid1"
        '
        'FormDataSet
        '
        Me.FormDataSet.DataSetName = "NewDataSet"
        Me.FormDataSet.Tables.AddRange(New System.Data.DataTable() {Me.TB_Deposits})
        '
        'TB_Deposits
        '
        Me.TB_Deposits.Columns.AddRange(New System.Data.DataColumn() {Me.DataColumn1, Me.DataColumn2, Me.DataColumn3, Me.DataColumn4, Me.DataColumn5, Me.DataColumn6, Me.DataColumn7, Me.DataColumn8, Me.DataColumn9})
        Me.TB_Deposits.TableName = "TB_Deposits"
        '
        'DataColumn1
        '
        Me.DataColumn1.ColumnName = "ID"
        Me.DataColumn1.DataType = GetType(System.Guid)
        '
        'DataColumn2
        '
        Me.DataColumn2.ColumnName = "BLID"
        Me.DataColumn2.DataType = GetType(System.Guid)
        '
        'DataColumn3
        '
        Me.DataColumn3.ColumnName = "ChargesCodes"
        '
        'DataColumn4
        '
        Me.DataColumn4.ColumnName = "Remarks"
        '
        'DataColumn5
        '
        Me.DataColumn5.ColumnName = "Amount"
        Me.DataColumn5.DataType = GetType(Double)
        '
        'DataColumn6
        '
        Me.DataColumn6.ColumnName = "ReturnBackDate"
        Me.DataColumn6.DataType = GetType(Date)
        '
        'DataColumn7
        '
        Me.DataColumn7.ColumnName = "ReturnBackAmount"
        Me.DataColumn7.DataType = GetType(Decimal)
        '
        'DataColumn8
        '
        Me.DataColumn8.ColumnName = "ReturnBackRef"
        '
        'UserMenuItem1
        '
        Me.UserMenuItem1.Dock = System.Windows.Forms.DockStyle.Top
        Me.UserMenuItem1.Location = New System.Drawing.Point(0, 0)
        Me.UserMenuItem1.Name = "UserMenuItem1"
        Me.UserMenuItem1.ShowAdditional = False
        Me.UserMenuItem1.ShowCancel = False
        Me.UserMenuItem1.ShowConfirm = False
        Me.UserMenuItem1.ShowDelete = False
        Me.UserMenuItem1.ShowDeposits = False
        Me.UserMenuItem1.ShowDeSelectAll = False
        Me.UserMenuItem1.ShowEdit = False
        Me.UserMenuItem1.ShowExcel = False
        Me.UserMenuItem1.ShowFileOpen = False
        Me.UserMenuItem1.ShowNew = False
        Me.UserMenuItem1.ShowPickup = False
        Me.UserMenuItem1.ShowPrint = True
        Me.UserMenuItem1.ShowProcess = False
        Me.UserMenuItem1.ShowRecivedItems = False
        Me.UserMenuItem1.ShowRefresh = False
        Me.UserMenuItem1.ShowRest = False
        Me.UserMenuItem1.ShowSave = True
        Me.UserMenuItem1.ShowSelectAll = False
        Me.UserMenuItem1.Size = New System.Drawing.Size(1087, 31)
        Me.UserMenuItem1.TabIndex = 0
        '
        'DataColumn9
        '
        Me.DataColumn9.ColumnName = "PaidRef"
        '
        'FrmDeposits
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1087, 415)
        Me.Controls.Add(Me.UserMenuItem1)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Name = "FrmDeposits"
        Me.Text = "Deposits"
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        CType(Me.DropDownCharges, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridDeposits, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FormDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TB_Deposits, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UserMenuItem1 As Shipping.UserMenuItem
    Friend WithEvents FormDataSet As System.Data.DataSet
    Friend WithEvents TB_Deposits As System.Data.DataTable
    Friend WithEvents DataColumn1 As System.Data.DataColumn
    Friend WithEvents DataColumn2 As System.Data.DataColumn
    Friend WithEvents DataColumn3 As System.Data.DataColumn
    Friend WithEvents DataColumn4 As System.Data.DataColumn
    Friend WithEvents DataColumn5 As System.Data.DataColumn
    Friend WithEvents GridDeposits As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents DropDownCharges As Infragistics.Win.UltraWinGrid.UltraDropDown
    Friend WithEvents DataColumn6 As System.Data.DataColumn
    Friend WithEvents DataColumn7 As System.Data.DataColumn
    Friend WithEvents DataColumn8 As System.Data.DataColumn
    Friend WithEvents DataColumn9 As System.Data.DataColumn
End Class
