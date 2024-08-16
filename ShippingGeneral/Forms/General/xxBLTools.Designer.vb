<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class xxBLTools
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim ValueListItem3 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem4 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem5 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.OptionSet = New Infragistics.Win.UltraWinEditors.UltraOptionSet()
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.UltraGroupBox3 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.DestinationBL = New System.Windows.Forms.TextBox()
        Me.SourceBL = New System.Windows.Forms.TextBox()
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.GridCntrs = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Strip = New System.Windows.Forms.ToolStrip()
        Me.ButtonPickup = New System.Windows.Forms.ToolStripButton()
        Me.ButtonSave = New System.Windows.Forms.ToolStripButton()
        CType(Me.OptionSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox3.SuspendLayout()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox2.SuspendLayout()
        CType(Me.GridCntrs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Strip.SuspendLayout()
        Me.SuspendLayout()
        '
        'OptionSet
        '
        Me.OptionSet.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        ValueListItem3.CheckState = System.Windows.Forms.CheckState.Checked
        ValueListItem3.DataValue = "C"
        ValueListItem3.DisplayText = "Copy"
        ValueListItem4.CheckState = System.Windows.Forms.CheckState.Checked
        ValueListItem4.DataValue = "M"
        ValueListItem4.DisplayText = "Merge"
        ValueListItem5.DataValue = "S"
        ValueListItem5.DisplayText = "Split"
        Me.OptionSet.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem3, ValueListItem4, ValueListItem5})
        Me.OptionSet.ItemSpacingHorizontal = 3
        Me.OptionSet.ItemSpacingVertical = 8
        Me.OptionSet.Location = New System.Drawing.Point(22, 28)
        Me.OptionSet.Name = "OptionSet"
        Me.OptionSet.Size = New System.Drawing.Size(80, 84)
        Me.OptionSet.TabIndex = 0
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.OptionSet)
        Me.UltraGroupBox1.Location = New System.Drawing.Point(17, 216)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(185, 139)
        Me.UltraGroupBox1.TabIndex = 1
        Me.UltraGroupBox1.Text = "Direction"
        '
        'UltraGroupBox3
        '
        Me.UltraGroupBox3.Controls.Add(Me.DestinationBL)
        Me.UltraGroupBox3.Controls.Add(Me.SourceBL)
        Me.UltraGroupBox3.Controls.Add(Me.UltraLabel3)
        Me.UltraGroupBox3.Controls.Add(Me.UltraLabel4)
        Me.UltraGroupBox3.Location = New System.Drawing.Point(17, 50)
        Me.UltraGroupBox3.Name = "UltraGroupBox3"
        Me.UltraGroupBox3.Size = New System.Drawing.Size(185, 160)
        Me.UltraGroupBox3.TabIndex = 2
        Me.UltraGroupBox3.Text = "B/Ls"
        '
        'DestinationBL
        '
        Me.DestinationBL.AcceptsReturn = True
        Me.DestinationBL.Location = New System.Drawing.Point(22, 100)
        Me.DestinationBL.Name = "DestinationBL"
        Me.DestinationBL.Size = New System.Drawing.Size(142, 20)
        Me.DestinationBL.TabIndex = 1
        '
        'SourceBL
        '
        Me.SourceBL.Location = New System.Drawing.Point(22, 46)
        Me.SourceBL.Name = "SourceBL"
        Me.SourceBL.Size = New System.Drawing.Size(142, 20)
        Me.SourceBL.TabIndex = 1
        '
        'UltraLabel3
        '
        Me.UltraLabel3.Location = New System.Drawing.Point(22, 81)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(100, 23)
        Me.UltraLabel3.TabIndex = 0
        Me.UltraLabel3.Text = "Destination B/L"
        '
        'UltraLabel4
        '
        Me.UltraLabel4.Location = New System.Drawing.Point(22, 28)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.Size = New System.Drawing.Size(100, 23)
        Me.UltraLabel4.TabIndex = 0
        Me.UltraLabel4.Text = "Source B/L"
        '
        'UltraGroupBox2
        '
        Me.UltraGroupBox2.Controls.Add(Me.GridCntrs)
        Me.UltraGroupBox2.Location = New System.Drawing.Point(224, 34)
        Me.UltraGroupBox2.Name = "UltraGroupBox2"
        Me.UltraGroupBox2.Size = New System.Drawing.Size(336, 318)
        Me.UltraGroupBox2.TabIndex = 3
        Me.UltraGroupBox2.Text = "List Of Containers"
        '
        'GridCntrs
        '
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.GridCntrs.DisplayLayout.Appearance = Appearance1
        Me.GridCntrs.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.GridCntrs.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.SystemColors.Window
        Me.GridCntrs.DisplayLayout.GroupByBox.Appearance = Appearance2
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.GridCntrs.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance4
        Me.GridCntrs.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance3.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance3.BackColor2 = System.Drawing.SystemColors.Control
        Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.GridCntrs.DisplayLayout.GroupByBox.PromptAppearance = Appearance3
        Me.GridCntrs.DisplayLayout.MaxColScrollRegions = 1
        Me.GridCntrs.DisplayLayout.MaxRowScrollRegions = 1
        Appearance9.BackColor = System.Drawing.SystemColors.Window
        Appearance9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GridCntrs.DisplayLayout.Override.ActiveCellAppearance = Appearance9
        Appearance5.BackColor = System.Drawing.SystemColors.Highlight
        Appearance5.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.GridCntrs.DisplayLayout.Override.ActiveRowAppearance = Appearance5
        Me.GridCntrs.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.GridCntrs.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance12.BackColor = System.Drawing.SystemColors.Window
        Me.GridCntrs.DisplayLayout.Override.CardAreaAppearance = Appearance12
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.GridCntrs.DisplayLayout.Override.CellAppearance = Appearance8
        Me.GridCntrs.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.GridCntrs.DisplayLayout.Override.CellPadding = 0
        Appearance6.BackColor = System.Drawing.SystemColors.Control
        Appearance6.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance6.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance6.BorderColor = System.Drawing.SystemColors.Window
        Me.GridCntrs.DisplayLayout.Override.GroupByRowAppearance = Appearance6
        Appearance7.TextHAlignAsString = "Left"
        Me.GridCntrs.DisplayLayout.Override.HeaderAppearance = Appearance7
        Me.GridCntrs.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.GridCntrs.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance10.BackColor = System.Drawing.SystemColors.Window
        Appearance10.BorderColor = System.Drawing.Color.Silver
        Me.GridCntrs.DisplayLayout.Override.RowAppearance = Appearance10
        Me.GridCntrs.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance11.BackColor = System.Drawing.SystemColors.ControlLight
        Me.GridCntrs.DisplayLayout.Override.TemplateAddRowAppearance = Appearance11
        Me.GridCntrs.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.GridCntrs.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.GridCntrs.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.GridCntrs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridCntrs.Location = New System.Drawing.Point(3, 16)
        Me.GridCntrs.Name = "GridCntrs"
        Me.GridCntrs.Size = New System.Drawing.Size(330, 299)
        Me.GridCntrs.TabIndex = 0
        Me.GridCntrs.Text = "UltraGrid1"
        '
        'Strip
        '
        Me.Strip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.Strip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ButtonPickup, Me.ButtonSave})
        Me.Strip.Location = New System.Drawing.Point(0, 0)
        Me.Strip.Name = "Strip"
        Me.Strip.Size = New System.Drawing.Size(589, 31)
        Me.Strip.TabIndex = 4
        Me.Strip.Text = "ToolStrip1"
        '
        'ButtonPickup
        '
        Me.ButtonPickup.Image = Global.Shipping.My.Resources.Resources.search_24
        Me.ButtonPickup.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonPickup.Name = "ButtonPickup"
        Me.ButtonPickup.Size = New System.Drawing.Size(71, 28)
        Me.ButtonPickup.Text = "Pickup"
        '
        'ButtonSave
        '
        Me.ButtonSave.Image = Global.Shipping.My.Resources.Resources.save_24
        Me.ButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonSave.Name = "ButtonSave"
        Me.ButtonSave.Size = New System.Drawing.Size(59, 28)
        Me.ButtonSave.Text = "Save"
        '
        'FrmBLTools
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(589, 381)
        Me.Controls.Add(Me.Strip)
        Me.Controls.Add(Me.UltraGroupBox2)
        Me.Controls.Add(Me.UltraGroupBox3)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Name = "FrmBLTools"
        Me.Text = "BL Tools"
        CType(Me.OptionSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox3.ResumeLayout(False)
        Me.UltraGroupBox3.PerformLayout()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox2.ResumeLayout(False)
        CType(Me.GridCntrs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Strip.ResumeLayout(False)
        Me.Strip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OptionSet As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraGroupBox3 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents DestinationBL As System.Windows.Forms.TextBox
    Friend WithEvents SourceBL As System.Windows.Forms.TextBox
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents GridCntrs As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Strip As System.Windows.Forms.ToolStrip
    Friend WithEvents ButtonPickup As System.Windows.Forms.ToolStripButton
    Friend WithEvents ButtonSave As System.Windows.Forms.ToolStripButton
End Class
