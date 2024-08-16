<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReleaseLetter
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.UltraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox
        Me.RadioByIssue = New System.Windows.Forms.RadioButton
        Me.RadioByRequest = New System.Windows.Forms.RadioButton
        Me.FromLabel = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.DateFrom = New Shipping.UserGnrlDate
        Me.Dateto = New Shipping.UserGnrlDate
        Me.MenuItem = New Shipping.UserMenuItem
        Me.GridRelease = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox2.SuspendLayout()
        CType(Me.GridRelease, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.UltraGroupBox2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.MenuItem, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.GridRelease, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(674, 431)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'UltraGroupBox2
        '
        Me.UltraGroupBox2.Controls.Add(Me.RadioByIssue)
        Me.UltraGroupBox2.Controls.Add(Me.RadioByRequest)
        Me.UltraGroupBox2.Controls.Add(Me.FromLabel)
        Me.UltraGroupBox2.Controls.Add(Me.UltraLabel1)
        Me.UltraGroupBox2.Controls.Add(Me.DateFrom)
        Me.UltraGroupBox2.Controls.Add(Me.Dateto)
        Me.UltraGroupBox2.Location = New System.Drawing.Point(3, 41)
        Me.UltraGroupBox2.Name = "UltraGroupBox2"
        Me.UltraGroupBox2.Size = New System.Drawing.Size(302, 88)
        Me.UltraGroupBox2.TabIndex = 11
        Me.UltraGroupBox2.Text = "By Date"
        '
        'RadioByIssue
        '
        Me.RadioByIssue.AutoSize = True
        Me.RadioByIssue.Location = New System.Drawing.Point(8, 48)
        Me.RadioByIssue.Name = "RadioByIssue"
        Me.RadioByIssue.Size = New System.Drawing.Size(91, 17)
        Me.RadioByIssue.TabIndex = 11
        Me.RadioByIssue.Text = "By Issue Date"
        Me.RadioByIssue.UseVisualStyleBackColor = True
        '
        'RadioByRequest
        '
        Me.RadioByRequest.AutoSize = True
        Me.RadioByRequest.Checked = True
        Me.RadioByRequest.Location = New System.Drawing.Point(8, 24)
        Me.RadioByRequest.Name = "RadioByRequest"
        Me.RadioByRequest.Size = New System.Drawing.Size(106, 17)
        Me.RadioByRequest.TabIndex = 10
        Me.RadioByRequest.TabStop = True
        Me.RadioByRequest.Text = "By Request Date"
        Me.RadioByRequest.UseVisualStyleBackColor = True
        '
        'FromLabel
        '
        Me.FromLabel.Location = New System.Drawing.Point(132, 24)
        Me.FromLabel.Name = "FromLabel"
        Me.FromLabel.Size = New System.Drawing.Size(36, 19)
        Me.FromLabel.TabIndex = 7
        Me.FromLabel.Text = "From"
        '
        'UltraLabel1
        '
        Me.UltraLabel1.Location = New System.Drawing.Point(148, 52)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(20, 19)
        Me.UltraLabel1.TabIndex = 9
        Me.UltraLabel1.Text = "To"
        '
        'DateFrom
        '
        Me.DateFrom.DateValue = Nothing
        Me.DateFrom.Location = New System.Drawing.Point(174, 21)
        Me.DateFrom.Name = "DateFrom"
        Me.DateFrom.ShowTime = False
        Me.DateFrom.Size = New System.Drawing.Size(111, 21)
        Me.DateFrom.TabIndex = 6
        '
        'Dateto
        '
        Me.Dateto.DateValue = Nothing
        Me.Dateto.Location = New System.Drawing.Point(174, 48)
        Me.Dateto.Name = "Dateto"
        Me.Dateto.ShowTime = False
        Me.Dateto.Size = New System.Drawing.Size(111, 21)
        Me.Dateto.TabIndex = 8
        '
        'MenuItem
        '
        Me.MenuItem.Location = New System.Drawing.Point(3, 3)
        Me.MenuItem.Name = "MenuItem"
        Me.MenuItem.ShowAdditional = False
        Me.MenuItem.ShowCancel = True
        Me.MenuItem.ShowConfirm = True
        Me.MenuItem.ShowDelete = False
        Me.MenuItem.ShowDeposits = False
        Me.MenuItem.ShowDeSelectAll = False
        Me.MenuItem.ShowEdit = False
        Me.MenuItem.ShowExcel = False
        Me.MenuItem.ShowFileOpen = False
        Me.MenuItem.ShowNew = False
        Me.MenuItem.ShowPickup = False
        Me.MenuItem.ShowPrint = False
        Me.MenuItem.ShowProcess = False
        Me.MenuItem.ShowRecivedItems = False
        Me.MenuItem.ShowRefresh = True
        Me.MenuItem.ShowRest = False
        Me.MenuItem.ShowSave = False
        Me.MenuItem.ShowSelectAll = False
        Me.MenuItem.Size = New System.Drawing.Size(668, 31)
        Me.MenuItem.TabIndex = 0
        '
        'GridRelease
        '
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.GridRelease.DisplayLayout.Appearance = Appearance1
        Me.GridRelease.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.GridRelease.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.SystemColors.Window
        Me.GridRelease.DisplayLayout.GroupByBox.Appearance = Appearance2
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.GridRelease.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
        Me.GridRelease.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance4.BackColor2 = System.Drawing.SystemColors.Control
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.GridRelease.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
        Me.GridRelease.DisplayLayout.MaxColScrollRegions = 1
        Me.GridRelease.DisplayLayout.MaxRowScrollRegions = 1
        Appearance5.BackColor = System.Drawing.SystemColors.Window
        Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GridRelease.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.SystemColors.Highlight
        Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.GridRelease.DisplayLayout.Override.ActiveRowAppearance = Appearance6
        Me.GridRelease.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.GridRelease.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Me.GridRelease.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.GridRelease.DisplayLayout.Override.CellAppearance = Appearance8
        Me.GridRelease.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.GridRelease.DisplayLayout.Override.CellPadding = 0
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.GridRelease.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance10.TextHAlignAsString = "Left"
        Me.GridRelease.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.GridRelease.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.GridRelease.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Me.GridRelease.DisplayLayout.Override.RowAppearance = Appearance11
        Me.GridRelease.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
        Me.GridRelease.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
        Me.GridRelease.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.GridRelease.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.GridRelease.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.GridRelease.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridRelease.Location = New System.Drawing.Point(3, 141)
        Me.GridRelease.Name = "GridRelease"
        Me.GridRelease.Size = New System.Drawing.Size(668, 287)
        Me.GridRelease.TabIndex = 1
        Me.GridRelease.Text = "UltraGrid1"
        '
        'FrmReleaseLetter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(674, 431)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "FrmReleaseLetter"
        Me.Text = "Release Letter"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox2.ResumeLayout(False)
        Me.UltraGroupBox2.PerformLayout()
        CType(Me.GridRelease, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents MenuItem As Shipping.UserMenuItem
    Friend WithEvents GridRelease As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents RadioByIssue As System.Windows.Forms.RadioButton
    Friend WithEvents RadioByRequest As System.Windows.Forms.RadioButton
    Friend WithEvents FromLabel As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents DateFrom As Shipping.UserGnrlDate
    Friend WithEvents Dateto As Shipping.UserGnrlDate
End Class
