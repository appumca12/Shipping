<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDOPrint
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
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.ShowTIP = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.LabelNotify2 = New Infragistics.Win.Misc.UltraLabel
        Me.LabelNotify1 = New Infragistics.Win.Misc.UltraLabel
        Me.LabelCnee = New Infragistics.Win.Misc.UltraLabel
        Me.LabelShortCnee = New Infragistics.Win.Misc.UltraLabel
        Me.RadioShortCnee = New System.Windows.Forms.RadioButton
        Me.RadioNotify2 = New System.Windows.Forms.RadioButton
        Me.RadioNotify1 = New System.Windows.Forms.RadioButton
        Me.RadioCnee = New System.Windows.Forms.RadioButton
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel
        Me.FormErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.UltraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox
        Me.DoDate = New Shipping.UserGnrlDate
        Me.DoOffice = New Shipping.UserComboCode
        Me.MenuItem = New Shipping.UserMenuItem
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.ShowTIP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FormErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.ShowTIP)
        Me.UltraGroupBox1.Controls.Add(Me.LabelNotify2)
        Me.UltraGroupBox1.Controls.Add(Me.LabelNotify1)
        Me.UltraGroupBox1.Controls.Add(Me.LabelCnee)
        Me.UltraGroupBox1.Controls.Add(Me.LabelShortCnee)
        Me.UltraGroupBox1.Controls.Add(Me.RadioShortCnee)
        Me.UltraGroupBox1.Controls.Add(Me.RadioNotify2)
        Me.UltraGroupBox1.Controls.Add(Me.RadioNotify1)
        Me.UltraGroupBox1.Controls.Add(Me.RadioCnee)
        Me.UltraGroupBox1.Location = New System.Drawing.Point(12, 118)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(529, 415)
        Me.UltraGroupBox1.TabIndex = 2
        Me.UltraGroupBox1.Text = "DO. Issue To"
        '
        'ShowTIP
        '
        Me.ShowTIP.Checked = True
        Me.ShowTIP.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ShowTIP.Location = New System.Drawing.Point(30, 23)
        Me.ShowTIP.Name = "ShowTIP"
        Me.ShowTIP.Size = New System.Drawing.Size(218, 20)
        Me.ShowTIP.TabIndex = 8
        Me.ShowTIP.Text = "Show T.I.P. In Print"
        '
        'LabelNotify2
        '
        Appearance1.ForeColor = System.Drawing.Color.Maroon
        Me.LabelNotify2.Appearance = Appearance1
        Me.LabelNotify2.Location = New System.Drawing.Point(44, 328)
        Me.LabelNotify2.Name = "LabelNotify2"
        Me.LabelNotify2.Size = New System.Drawing.Size(449, 69)
        Me.LabelNotify2.TabIndex = 7
        Me.LabelNotify2.Text = "UltraLabel6"
        '
        'LabelNotify1
        '
        Appearance2.ForeColor = System.Drawing.Color.Maroon
        Me.LabelNotify1.Appearance = Appearance2
        Me.LabelNotify1.Location = New System.Drawing.Point(44, 234)
        Me.LabelNotify1.Name = "LabelNotify1"
        Me.LabelNotify1.Size = New System.Drawing.Size(449, 64)
        Me.LabelNotify1.TabIndex = 6
        Me.LabelNotify1.Text = "UltraLabel5"
        '
        'LabelCnee
        '
        Appearance3.ForeColor = System.Drawing.Color.Maroon
        Me.LabelCnee.Appearance = Appearance3
        Me.LabelCnee.Location = New System.Drawing.Point(44, 140)
        Me.LabelCnee.Name = "LabelCnee"
        Me.LabelCnee.Size = New System.Drawing.Size(449, 61)
        Me.LabelCnee.TabIndex = 5
        Me.LabelCnee.Text = "UltraLabel4"
        '
        'LabelShortCnee
        '
        Appearance4.ForeColor = System.Drawing.Color.Maroon
        Me.LabelShortCnee.Appearance = Appearance4
        Me.LabelShortCnee.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.None
        Me.LabelShortCnee.Location = New System.Drawing.Point(44, 80)
        Me.LabelShortCnee.Name = "LabelShortCnee"
        Me.LabelShortCnee.Size = New System.Drawing.Size(449, 43)
        Me.LabelShortCnee.TabIndex = 4
        Me.LabelShortCnee.Text = "UltraLabel3"
        '
        'RadioShortCnee
        '
        Me.RadioShortCnee.AutoSize = True
        Me.RadioShortCnee.Location = New System.Drawing.Point(26, 58)
        Me.RadioShortCnee.Name = "RadioShortCnee"
        Me.RadioShortCnee.Size = New System.Drawing.Size(64, 17)
        Me.RadioShortCnee.TabIndex = 0
        Me.RadioShortCnee.TabStop = True
        Me.RadioShortCnee.Text = "Messers"
        Me.RadioShortCnee.UseVisualStyleBackColor = True
        '
        'RadioNotify2
        '
        Me.RadioNotify2.AutoSize = True
        Me.RadioNotify2.Location = New System.Drawing.Point(26, 304)
        Me.RadioNotify2.Name = "RadioNotify2"
        Me.RadioNotify2.Size = New System.Drawing.Size(94, 17)
        Me.RadioNotify2.TabIndex = 3
        Me.RadioNotify2.TabStop = True
        Me.RadioNotify2.Text = "Notify Party (2)"
        Me.RadioNotify2.UseVisualStyleBackColor = True
        '
        'RadioNotify1
        '
        Me.RadioNotify1.AutoSize = True
        Me.RadioNotify1.Location = New System.Drawing.Point(26, 210)
        Me.RadioNotify1.Name = "RadioNotify1"
        Me.RadioNotify1.Size = New System.Drawing.Size(94, 17)
        Me.RadioNotify1.TabIndex = 2
        Me.RadioNotify1.TabStop = True
        Me.RadioNotify1.Text = "Notify Party (1)"
        Me.RadioNotify1.UseVisualStyleBackColor = True
        '
        'RadioCnee
        '
        Me.RadioCnee.AutoSize = True
        Me.RadioCnee.Location = New System.Drawing.Point(26, 121)
        Me.RadioCnee.Name = "RadioCnee"
        Me.RadioCnee.Size = New System.Drawing.Size(50, 17)
        Me.RadioCnee.TabIndex = 1
        Me.RadioCnee.TabStop = True
        Me.RadioCnee.Text = "Cnee"
        Me.RadioCnee.UseVisualStyleBackColor = True
        '
        'UltraLabel1
        '
        Me.UltraLabel1.Location = New System.Drawing.Point(9, 26)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(38, 23)
        Me.UltraLabel1.TabIndex = 4
        Me.UltraLabel1.Text = "Office"
        '
        'UltraLabel2
        '
        Me.UltraLabel2.Location = New System.Drawing.Point(265, 27)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(58, 23)
        Me.UltraLabel2.TabIndex = 6
        Me.UltraLabel2.Text = "Issue Date"
        '
        'FormErrorProvider
        '
        Me.FormErrorProvider.ContainerControl = Me
        '
        'UltraGroupBox2
        '
        Me.UltraGroupBox2.Controls.Add(Me.DoDate)
        Me.UltraGroupBox2.Controls.Add(Me.UltraLabel2)
        Me.UltraGroupBox2.Controls.Add(Me.DoOffice)
        Me.UltraGroupBox2.Controls.Add(Me.UltraLabel1)
        Me.UltraGroupBox2.Location = New System.Drawing.Point(12, 39)
        Me.UltraGroupBox2.Name = "UltraGroupBox2"
        Me.UltraGroupBox2.Size = New System.Drawing.Size(529, 61)
        Me.UltraGroupBox2.TabIndex = 7
        Me.UltraGroupBox2.Text = "D.O. Office Information"
        '
        'DoDate
        '
        Me.DoDate.DateValue = Nothing
        Me.DoDate.Location = New System.Drawing.Point(329, 24)
        Me.DoDate.Name = "DoDate"
        Me.DoDate.ShowTime = False
        Me.DoDate.Size = New System.Drawing.Size(148, 24)
        Me.DoDate.TabIndex = 5
        '
        'DoOffice
        '
        Me.DoOffice.BackColor = System.Drawing.Color.WhiteSmoke
        Me.DoOffice.Code = ""
        Me.DoOffice.CustomShowAll = False
        Me.DoOffice.Location = New System.Drawing.Point(53, 24)
        Me.DoOffice.Name = "DoOffice"
        Me.DoOffice.Size = New System.Drawing.Size(191, 21)
        Me.DoOffice.TabIndex = 3
        '
        'MenuItem
        '
        Me.MenuItem.Dock = System.Windows.Forms.DockStyle.Top
        Me.MenuItem.Location = New System.Drawing.Point(0, 0)
        Me.MenuItem.Name = "MenuItem"
        Me.MenuItem.ShowAdditional = False
        Me.MenuItem.ShowCancel = False
        Me.MenuItem.ShowConfirm = False
        Me.MenuItem.ShowDelete = False
        Me.MenuItem.ShowDeposits = False
        Me.MenuItem.ShowDeSelectAll = False
        Me.MenuItem.ShowEdit = False
        Me.MenuItem.ShowExcel = False
        Me.MenuItem.ShowFileOpen = False
        Me.MenuItem.ShowNew = False
        Me.MenuItem.ShowPickup = False
        Me.MenuItem.ShowPrint = True
        Me.MenuItem.ShowProcess = False
        Me.MenuItem.ShowRecivedItems = False
        Me.MenuItem.ShowRefresh = False
        Me.MenuItem.ShowRest = False
        Me.MenuItem.ShowSave = True
        Me.MenuItem.ShowSelectAll = False
        Me.MenuItem.Size = New System.Drawing.Size(558, 31)
        Me.MenuItem.TabIndex = 1
        '
        'FrmDOPrint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(558, 555)
        Me.Controls.Add(Me.UltraGroupBox2)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Controls.Add(Me.MenuItem)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmDOPrint"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DO Print"
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        CType(Me.ShowTIP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FormErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MenuItem As Shipping.UserMenuItem
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents RadioNotify2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioNotify1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioCnee As System.Windows.Forms.RadioButton
    Friend WithEvents RadioShortCnee As System.Windows.Forms.RadioButton
    Friend WithEvents DoOffice As Shipping.UserComboCode
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents DoDate As Shipping.UserGnrlDate
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents FormErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents UltraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents LabelNotify2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents LabelNotify1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents LabelCnee As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents LabelShortCnee As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents ShowTIP As Infragistics.Win.UltraWinEditors.UltraCheckEditor

End Class
