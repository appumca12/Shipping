<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmNosaConfirm
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
        Me.DateGenerate = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.ButtonGenerate = New Infragistics.Win.Misc.UltraButton
        Me.ButtonFinal = New Infragistics.Win.Misc.UltraButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.ButtonVchExp = New Infragistics.Win.Misc.UltraButton
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.ReGenerate = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.ButtonReGen = New Infragistics.Win.Misc.UltraButton
        Me.ButtonUpdateBL = New Infragistics.Win.Misc.UltraButton
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.GridData = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.ButtonDBDetn = New Infragistics.Win.Misc.UltraButton
        CType(Me.DateGenerate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.ReGenerate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.GridData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DateGenerate
        '
        Me.DateGenerate.Location = New System.Drawing.Point(59, 30)
        Me.DateGenerate.Name = "DateGenerate"
        Me.DateGenerate.Size = New System.Drawing.Size(144, 21)
        Me.DateGenerate.TabIndex = 0
        '
        'ButtonGenerate
        '
        Me.ButtonGenerate.Location = New System.Drawing.Point(209, 28)
        Me.ButtonGenerate.Name = "ButtonGenerate"
        Me.ButtonGenerate.Size = New System.Drawing.Size(92, 23)
        Me.ButtonGenerate.TabIndex = 1
        Me.ButtonGenerate.Text = "Generate Daily"
        '
        'ButtonFinal
        '
        Me.ButtonFinal.Location = New System.Drawing.Point(6, 60)
        Me.ButtonFinal.Name = "ButtonFinal"
        Me.ButtonFinal.Size = New System.Drawing.Size(135, 23)
        Me.ButtonFinal.TabIndex = 1
        Me.ButtonFinal.Text = "Generate Final Xml"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.ButtonDBDetn)
        Me.GroupBox1.Controls.Add(Me.ButtonVchExp)
        Me.GroupBox1.Controls.Add(Me.ButtonGenerate)
        Me.GroupBox1.Controls.Add(Me.DateGenerate)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(684, 74)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Genearte Daily"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Date:"
        '
        'ButtonVchExp
        '
        Me.ButtonVchExp.Location = New System.Drawing.Point(307, 28)
        Me.ButtonVchExp.Name = "ButtonVchExp"
        Me.ButtonVchExp.Size = New System.Drawing.Size(123, 23)
        Me.ButtonVchExp.TabIndex = 1
        Me.ButtonVchExp.Text = "Generate Daily(Exp)"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox2, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(690, 555)
        Me.TableLayoutPanel1.TabIndex = 3
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TableLayoutPanel2)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(3, 83)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(684, 469)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Generate Final"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.GroupBox3, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.GroupBox4, 1, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 16)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(678, 450)
        Me.TableLayoutPanel2.TabIndex = 3
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.ReGenerate)
        Me.GroupBox3.Controls.Add(Me.ButtonFinal)
        Me.GroupBox3.Controls.Add(Me.ButtonReGen)
        Me.GroupBox3.Controls.Add(Me.ButtonUpdateBL)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox3.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(144, 444)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Date:"
        '
        'ReGenerate
        '
        Me.ReGenerate.Location = New System.Drawing.Point(42, 33)
        Me.ReGenerate.Name = "ReGenerate"
        Me.ReGenerate.Size = New System.Drawing.Size(96, 21)
        Me.ReGenerate.TabIndex = 4
        '
        'ButtonReGen
        '
        Me.ButtonReGen.Location = New System.Drawing.Point(6, 145)
        Me.ButtonReGen.Name = "ButtonReGen"
        Me.ButtonReGen.Size = New System.Drawing.Size(135, 23)
        Me.ButtonReGen.TabIndex = 2
        Me.ButtonReGen.Text = "Regenerate"
        '
        'ButtonUpdateBL
        '
        Me.ButtonUpdateBL.Location = New System.Drawing.Point(6, 89)
        Me.ButtonUpdateBL.Name = "ButtonUpdateBL"
        Me.ButtonUpdateBL.Size = New System.Drawing.Size(135, 23)
        Me.ButtonUpdateBL.TabIndex = 2
        Me.ButtonUpdateBL.Text = "Update B/L data"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.GridData)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox4.Location = New System.Drawing.Point(153, 3)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(522, 444)
        Me.GroupBox4.TabIndex = 1
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "List Of B/Ls"
        '
        'GridData
        '
        Appearance13.BackColor = System.Drawing.SystemColors.Window
        Appearance13.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.GridData.DisplayLayout.Appearance = Appearance13
        Me.GridData.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.GridData.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance14.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance14.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance14.BorderColor = System.Drawing.SystemColors.Window
        Me.GridData.DisplayLayout.GroupByBox.Appearance = Appearance14
        Appearance15.ForeColor = System.Drawing.SystemColors.GrayText
        Me.GridData.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance15
        Me.GridData.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance16.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance16.BackColor2 = System.Drawing.SystemColors.Control
        Appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance16.ForeColor = System.Drawing.SystemColors.GrayText
        Me.GridData.DisplayLayout.GroupByBox.PromptAppearance = Appearance16
        Appearance17.BackColor = System.Drawing.SystemColors.Window
        Appearance17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GridData.DisplayLayout.Override.ActiveCellAppearance = Appearance17
        Appearance18.BackColor = System.Drawing.SystemColors.Highlight
        Appearance18.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.GridData.DisplayLayout.Override.ActiveRowAppearance = Appearance18
        Me.GridData.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.GridData.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[True]
        Me.GridData.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.GridData.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.[True]
        Me.GridData.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[True]
        Me.GridData.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.GridData.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance19.BackColor = System.Drawing.SystemColors.Window
        Me.GridData.DisplayLayout.Override.CardAreaAppearance = Appearance19
        Appearance20.BorderColor = System.Drawing.Color.Silver
        Appearance20.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.GridData.DisplayLayout.Override.CellAppearance = Appearance20
        Me.GridData.DisplayLayout.Override.CellPadding = 0
        Appearance21.BackColor = System.Drawing.SystemColors.Control
        Appearance21.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance21.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance21.BorderColor = System.Drawing.SystemColors.Window
        Me.GridData.DisplayLayout.Override.GroupByRowAppearance = Appearance21
        Appearance22.TextHAlignAsString = "Left"
        Me.GridData.DisplayLayout.Override.HeaderAppearance = Appearance22
        Me.GridData.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.GridData.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance23.BackColor = System.Drawing.SystemColors.Window
        Appearance23.BorderColor = System.Drawing.Color.Silver
        Me.GridData.DisplayLayout.Override.RowAppearance = Appearance23
        Appearance24.BackColor = System.Drawing.SystemColors.ControlLight
        Me.GridData.DisplayLayout.Override.TemplateAddRowAppearance = Appearance24
        Me.GridData.DisplayLayout.UseFixedHeaders = True
        Me.GridData.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.GridData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridData.Location = New System.Drawing.Point(3, 16)
        Me.GridData.Name = "GridData"
        Me.GridData.Size = New System.Drawing.Size(516, 425)
        Me.GridData.TabIndex = 0
        Me.GridData.Text = "UltraGrid1"
        '
        'ButtonDBDetn
        '
        Me.ButtonDBDetn.Location = New System.Drawing.Point(436, 28)
        Me.ButtonDBDetn.Name = "ButtonDBDetn"
        Me.ButtonDBDetn.Size = New System.Drawing.Size(123, 23)
        Me.ButtonDBDetn.TabIndex = 1
        Me.ButtonDBDetn.Text = "Debit Detention"
        '
        'FrmNosaConfirm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(690, 555)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "FrmNosaConfirm"
        Me.Text = "Nosa Confirm"
        CType(Me.DateGenerate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.ReGenerate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.GridData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DateGenerate As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents ButtonGenerate As Infragistics.Win.Misc.UltraButton
    Friend WithEvents ButtonFinal As Infragistics.Win.Misc.UltraButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents ButtonUpdateBL As Infragistics.Win.Misc.UltraButton
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ReGenerate As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents ButtonReGen As Infragistics.Win.Misc.UltraButton
    Friend WithEvents GridData As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents ButtonVchExp As Infragistics.Win.Misc.UltraButton
    Friend WithEvents ButtonDBDetn As Infragistics.Win.Misc.UltraButton
End Class
