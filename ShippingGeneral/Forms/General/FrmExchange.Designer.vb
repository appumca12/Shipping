<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmExchange
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
        Me.GroupBox = New Infragistics.Win.Misc.UltraGroupBox
        Me.DropDownCurrency = New Infragistics.Win.UltraWinGrid.UltraDropDown
        Me.GridData = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.Label1 = New System.Windows.Forms.Label
        Me.ExchangeDate = New Shipping.UserGnrlDate
        Me.GeneralForms = New Shipping.UserGeneralForms
        CType(Me.GroupBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox.SuspendLayout()
        CType(Me.DropDownCurrency, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox
        '
        Me.GroupBox.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox.Controls.Add(Me.DropDownCurrency)
        Me.GroupBox.Controls.Add(Me.GridData)
        Me.GroupBox.Controls.Add(Me.Label1)
        Me.GroupBox.Controls.Add(Me.ExchangeDate)
        Me.GroupBox.Location = New System.Drawing.Point(21, 52)
        Me.GroupBox.Name = "GroupBox"
        Me.GroupBox.Size = New System.Drawing.Size(558, 485)
        Me.GroupBox.SupportThemes = False
        Me.GroupBox.TabIndex = 1
        '
        'DropDownCurrency
        '
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.DropDownCurrency.DisplayLayout.Appearance = Appearance1
        Me.DropDownCurrency.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.DropDownCurrency.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.SystemColors.Window
        Me.DropDownCurrency.DisplayLayout.GroupByBox.Appearance = Appearance2
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.DropDownCurrency.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
        Me.DropDownCurrency.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance4.BackColor2 = System.Drawing.SystemColors.Control
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.DropDownCurrency.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
        Me.DropDownCurrency.DisplayLayout.MaxColScrollRegions = 1
        Me.DropDownCurrency.DisplayLayout.MaxRowScrollRegions = 1
        Appearance5.BackColor = System.Drawing.SystemColors.Window
        Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DropDownCurrency.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.SystemColors.Highlight
        Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.DropDownCurrency.DisplayLayout.Override.ActiveRowAppearance = Appearance6
        Me.DropDownCurrency.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.DropDownCurrency.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Me.DropDownCurrency.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.DropDownCurrency.DisplayLayout.Override.CellAppearance = Appearance8
        Me.DropDownCurrency.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.DropDownCurrency.DisplayLayout.Override.CellPadding = 0
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.DropDownCurrency.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance10.TextHAlign = Infragistics.Win.HAlign.Left
        Me.DropDownCurrency.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.DropDownCurrency.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.DropDownCurrency.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Me.DropDownCurrency.DisplayLayout.Override.RowAppearance = Appearance11
        Me.DropDownCurrency.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
        Me.DropDownCurrency.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
        Me.DropDownCurrency.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.DropDownCurrency.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.DropDownCurrency.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.DropDownCurrency.DisplayMember = ""
        Me.DropDownCurrency.Location = New System.Drawing.Point(343, 435)
        Me.DropDownCurrency.Name = "DropDownCurrency"
        Me.DropDownCurrency.Size = New System.Drawing.Size(172, 31)
        Me.DropDownCurrency.TabIndex = 5
        Me.DropDownCurrency.Text = "UltraDropDown1"
        Me.DropDownCurrency.ValueMember = ""
        Me.DropDownCurrency.Visible = False
        '
        'GridData
        '
        Appearance13.BackColor = System.Drawing.Color.White
        Appearance13.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(191, Byte), Integer))
        Appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.ForwardDiagonal
        Me.GridData.DisplayLayout.Appearance = Appearance13
        Me.GridData.DisplayLayout.InterBandSpacing = 10
        Me.GridData.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.GridData.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[True]
        Me.GridData.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.GridData.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.[True]
        Me.GridData.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[True]
        Appearance14.BackColor = System.Drawing.Color.Transparent
        Me.GridData.DisplayLayout.Override.CardAreaAppearance = Appearance14
        Appearance15.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(249, Byte), Integer))
        Appearance15.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(191, Byte), Integer))
        Appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance15.ForeColor = System.Drawing.Color.Black
        Appearance15.TextHAlign = Infragistics.Win.HAlign.Left
        Appearance15.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.GridData.DisplayLayout.Override.HeaderAppearance = Appearance15
        Me.GridData.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance16.BorderColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.GridData.DisplayLayout.Override.RowAppearance = Appearance16
        Appearance17.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(249, Byte), Integer))
        Appearance17.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(191, Byte), Integer))
        Appearance17.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.GridData.DisplayLayout.Override.RowSelectorAppearance = Appearance17
        Me.GridData.DisplayLayout.Override.RowSelectorWidth = 12
        Me.GridData.DisplayLayout.Override.RowSpacingBefore = 2
        Appearance18.BackColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(191, Byte), Integer))
        Appearance18.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(249, Byte), Integer))
        Appearance18.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance18.ForeColor = System.Drawing.Color.Black
        Me.GridData.DisplayLayout.Override.SelectedRowAppearance = Appearance18
        Me.GridData.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.GridData.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid
        Me.GridData.DisplayLayout.UseFixedHeaders = True
        Me.GridData.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.GridData.Location = New System.Drawing.Point(15, 51)
        Me.GridData.Name = "GridData"
        Me.GridData.Size = New System.Drawing.Size(525, 415)
        Me.GridData.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Date:"
        '
        'ExchangeDate
        '
        Me.ExchangeDate.DateValue = Nothing
        Me.ExchangeDate.Location = New System.Drawing.Point(54, 14)
        Me.ExchangeDate.Name = "ExchangeDate"
        Me.ExchangeDate.ShowTime = False
        Me.ExchangeDate.Size = New System.Drawing.Size(127, 24)
        Me.ExchangeDate.TabIndex = 2
        '
        'GeneralForms
        '
        Me.GeneralForms.Location = New System.Drawing.Point(-2, 2)
        Me.GeneralForms.Name = "GeneralForms"
        Me.GeneralForms.ShowHistoryButtom = False
        Me.GeneralForms.ShowNavigate = False
        Me.GeneralForms.ShowPrintButtom = False
        Me.GeneralForms.Size = New System.Drawing.Size(604, 552)
        Me.GeneralForms.TabIndex = 0
        '
        'FrmExchange
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(601, 554)
        Me.Controls.Add(Me.GroupBox)
        Me.Controls.Add(Me.GeneralForms)
        Me.Name = "FrmExchange"
        Me.Text = "Daily Exchange Rate"
        CType(Me.GroupBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox.ResumeLayout(False)
        Me.GroupBox.PerformLayout()
        CType(Me.DropDownCurrency, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GeneralForms As Shipping.UserGeneralForms
    Friend WithEvents GroupBox As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents ExchangeDate As Shipping.UserGnrlDate
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GridData As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents DropDownCurrency As Infragistics.Win.UltraWinGrid.UltraDropDown
End Class
