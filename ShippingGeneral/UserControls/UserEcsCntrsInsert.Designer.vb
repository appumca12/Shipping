<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserEcsCntrsInsert
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.UltraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox
        Me.CheckIsFull = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.CheckAsGateIn = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.GridCntrs = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.ButtonCancel = New Infragistics.Win.Misc.UltraButton
        Me.ButtonAccept = New Infragistics.Win.Misc.UltraButton
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox2.SuspendLayout()
        CType(Me.CheckIsFull, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckAsGateIn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridCntrs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.UltraGroupBox2)
        Me.UltraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(429, 478)
        Me.UltraGroupBox1.TabIndex = 0
        '
        'UltraGroupBox2
        '
        Me.UltraGroupBox2.Controls.Add(Me.CheckIsFull)
        Me.UltraGroupBox2.Controls.Add(Me.CheckAsGateIn)
        Me.UltraGroupBox2.Controls.Add(Me.GridCntrs)
        Me.UltraGroupBox2.Controls.Add(Me.ButtonCancel)
        Me.UltraGroupBox2.Controls.Add(Me.ButtonAccept)
        Me.UltraGroupBox2.Location = New System.Drawing.Point(16, 16)
        Me.UltraGroupBox2.Name = "UltraGroupBox2"
        Me.UltraGroupBox2.Size = New System.Drawing.Size(388, 437)
        Me.UltraGroupBox2.TabIndex = 1
        Me.UltraGroupBox2.Text = "Paset Selected Container in Grid"
        '
        'CheckIsFull
        '
        Me.CheckIsFull.Checked = True
        Me.CheckIsFull.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckIsFull.Location = New System.Drawing.Point(136, 401)
        Me.CheckIsFull.Name = "CheckIsFull"
        Me.CheckIsFull.Size = New System.Drawing.Size(72, 20)
        Me.CheckIsFull.TabIndex = 2
        Me.CheckIsFull.Text = "Is Empty"
        '
        'CheckAsGateIn
        '
        Me.CheckAsGateIn.Checked = True
        Me.CheckAsGateIn.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckAsGateIn.Location = New System.Drawing.Point(7, 401)
        Me.CheckAsGateIn.Name = "CheckAsGateIn"
        Me.CheckAsGateIn.Size = New System.Drawing.Size(114, 20)
        Me.CheckAsGateIn.TabIndex = 2
        Me.CheckAsGateIn.Text = "Import as Gate In"
        '
        'GridCntrs
        '
        Appearance4.BackColor = System.Drawing.SystemColors.Window
        Appearance4.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.GridCntrs.DisplayLayout.Appearance = Appearance4
        Me.GridCntrs.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.GridCntrs.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance1.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance1.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance1.BorderColor = System.Drawing.SystemColors.Window
        Me.GridCntrs.DisplayLayout.GroupByBox.Appearance = Appearance1
        Appearance2.ForeColor = System.Drawing.SystemColors.GrayText
        Me.GridCntrs.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance2
        Me.GridCntrs.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance3.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance3.BackColor2 = System.Drawing.SystemColors.Control
        Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.GridCntrs.DisplayLayout.GroupByBox.PromptAppearance = Appearance3
        Appearance12.BackColor = System.Drawing.SystemColors.Window
        Appearance12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GridCntrs.DisplayLayout.Override.ActiveCellAppearance = Appearance12
        Appearance7.BackColor = System.Drawing.SystemColors.Highlight
        Appearance7.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.GridCntrs.DisplayLayout.Override.ActiveRowAppearance = Appearance7
        Me.GridCntrs.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.GridCntrs.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[True]
        Me.GridCntrs.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.GridCntrs.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.[True]
        Me.GridCntrs.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[True]
        Me.GridCntrs.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.GridCntrs.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance6.BackColor = System.Drawing.SystemColors.Window
        Me.GridCntrs.DisplayLayout.Override.CardAreaAppearance = Appearance6
        Appearance5.BorderColor = System.Drawing.Color.Silver
        Appearance5.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.GridCntrs.DisplayLayout.Override.CellAppearance = Appearance5
        Me.GridCntrs.DisplayLayout.Override.CellPadding = 0
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.GridCntrs.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance11.TextHAlignAsString = "Left"
        Me.GridCntrs.DisplayLayout.Override.HeaderAppearance = Appearance11
        Me.GridCntrs.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.GridCntrs.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance10.BackColor = System.Drawing.SystemColors.Window
        Appearance10.BorderColor = System.Drawing.Color.Silver
        Me.GridCntrs.DisplayLayout.Override.RowAppearance = Appearance10
        Appearance8.BackColor = System.Drawing.SystemColors.ControlLight
        Me.GridCntrs.DisplayLayout.Override.TemplateAddRowAppearance = Appearance8
        Me.GridCntrs.DisplayLayout.UseFixedHeaders = True
        Me.GridCntrs.Location = New System.Drawing.Point(7, 19)
        Me.GridCntrs.Name = "GridCntrs"
        Me.GridCntrs.Size = New System.Drawing.Size(363, 373)
        Me.GridCntrs.TabIndex = 1
        Me.GridCntrs.Text = "UltraGrid1"
        '
        'ButtonCancel
        '
        Me.ButtonCancel.Location = New System.Drawing.Point(214, 398)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(75, 23)
        Me.ButtonCancel.TabIndex = 0
        Me.ButtonCancel.Text = "Cancel"
        '
        'ButtonAccept
        '
        Me.ButtonAccept.Location = New System.Drawing.Point(295, 398)
        Me.ButtonAccept.Name = "ButtonAccept"
        Me.ButtonAccept.Size = New System.Drawing.Size(75, 23)
        Me.ButtonAccept.TabIndex = 0
        Me.ButtonAccept.Text = "Accept"
        '
        'UserEcsCntrsInsert
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Name = "UserEcsCntrsInsert"
        Me.Size = New System.Drawing.Size(429, 478)
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox2.ResumeLayout(False)
        CType(Me.CheckIsFull, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckAsGateIn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridCntrs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents ButtonAccept As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents GridCntrs As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents ButtonCancel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents CheckAsGateIn As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents CheckIsFull As Infragistics.Win.UltraWinEditors.UltraCheckEditor

End Class
