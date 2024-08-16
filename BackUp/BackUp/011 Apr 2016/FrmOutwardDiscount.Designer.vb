<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOutwardDiscount
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
        Me.GeneralForms = New Shipping.UserGeneralForms
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.LinesGroupDetail = New Infragistics.Win.Misc.UltraGroupBox
        Me.IsFDaysAsDiscount = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.dAmount = New Shipping.UserNum
        Me.dPercent = New Shipping.UserNum
        Me.dFreeDays = New Shipping.UserNum
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel
        Me.LblName = New Infragistics.Win.Misc.UltraLabel
        Me.BLNO = New Shipping.UserText
        Me.LabelBL = New Infragistics.Win.Misc.UltraLabel
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.LinesGroupDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LinesGroupDetail.SuspendLayout()
        Me.SuspendLayout()
        '
        'GeneralForms
        '
        Me.GeneralForms.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GeneralForms.Location = New System.Drawing.Point(0, 0)
        Me.GeneralForms.Name = "GeneralForms"
        Me.GeneralForms.ShowPrintButtom = False
        Me.GeneralForms.Size = New System.Drawing.Size(358, 244)
        Me.GeneralForms.TabIndex = 0
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.LinesGroupDetail)
        Me.UltraGroupBox1.Location = New System.Drawing.Point(12, 70)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(336, 160)
        Me.UltraGroupBox1.SupportThemes = False
        Me.UltraGroupBox1.TabIndex = 18
        Me.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.VisualStudio2005
        '
        'LinesGroupDetail
        '
        Me.LinesGroupDetail.Controls.Add(Me.IsFDaysAsDiscount)
        Me.LinesGroupDetail.Controls.Add(Me.dAmount)
        Me.LinesGroupDetail.Controls.Add(Me.dPercent)
        Me.LinesGroupDetail.Controls.Add(Me.dFreeDays)
        Me.LinesGroupDetail.Controls.Add(Me.UltraLabel4)
        Me.LinesGroupDetail.Controls.Add(Me.UltraLabel3)
        Me.LinesGroupDetail.Controls.Add(Me.LblName)
        Me.LinesGroupDetail.Location = New System.Drawing.Point(8, 16)
        Me.LinesGroupDetail.Name = "LinesGroupDetail"
        Me.LinesGroupDetail.Size = New System.Drawing.Size(312, 132)
        Me.LinesGroupDetail.SupportThemes = False
        Me.LinesGroupDetail.TabIndex = 10
        Me.LinesGroupDetail.Text = "Discount Details"
        '
        'IsFDaysAsDiscount
        '
        Me.IsFDaysAsDiscount.Location = New System.Drawing.Point(210, 31)
        Me.IsFDaysAsDiscount.Name = "IsFDaysAsDiscount"
        Me.IsFDaysAsDiscount.Size = New System.Drawing.Size(83, 20)
        Me.IsFDaysAsDiscount.TabIndex = 1
        Me.IsFDaysAsDiscount.Text = "As Discount"
        '
        'dAmount
        '
        Me.dAmount.CtrlValue = 0
        Me.dAmount.Location = New System.Drawing.Point(84, 88)
        Me.dAmount.Name = "dAmount"
        Me.dAmount.Size = New System.Drawing.Size(104, 23)
        Me.dAmount.TabIndex = 3
        '
        'dPercent
        '
        Me.dPercent.CtrlValue = 0
        Me.dPercent.Location = New System.Drawing.Point(84, 57)
        Me.dPercent.Name = "dPercent"
        Me.dPercent.Size = New System.Drawing.Size(104, 23)
        Me.dPercent.TabIndex = 2
        '
        'dFreeDays
        '
        Me.dFreeDays.CtrlValue = 0
        Me.dFreeDays.Location = New System.Drawing.Point(84, 28)
        Me.dFreeDays.Name = "dFreeDays"
        Me.dFreeDays.Size = New System.Drawing.Size(104, 23)
        Me.dFreeDays.TabIndex = 0
        '
        'UltraLabel4
        '
        Me.UltraLabel4.Location = New System.Drawing.Point(23, 88)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.Size = New System.Drawing.Size(67, 18)
        Me.UltraLabel4.TabIndex = 12
        Me.UltraLabel4.Text = "Amount"
        '
        'UltraLabel3
        '
        Me.UltraLabel3.Location = New System.Drawing.Point(23, 61)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(67, 20)
        Me.UltraLabel3.TabIndex = 11
        Me.UltraLabel3.Text = "Percent"
        '
        'LblName
        '
        Me.LblName.Location = New System.Drawing.Point(23, 32)
        Me.LblName.Name = "LblName"
        Me.LblName.Size = New System.Drawing.Size(67, 19)
        Me.LblName.TabIndex = 8
        Me.LblName.Text = "Free Days"
        '
        'BLNO
        '
        Me.BLNO.BackColor = System.Drawing.Color.Transparent
        Me.BLNO.CustomMaxLength = CType(100, Byte)
        Me.BLNO.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BLNO.Location = New System.Drawing.Point(75, 42)
        Me.BLNO.Name = "BLNO"
        Me.BLNO.Size = New System.Drawing.Size(125, 22)
        Me.BLNO.TabIndex = 0
        Me.BLNO.TextValue = ""
        '
        'LabelBL
        '
        Me.LabelBL.Location = New System.Drawing.Point(12, 42)
        Me.LabelBL.Name = "LabelBL"
        Me.LabelBL.Size = New System.Drawing.Size(51, 17)
        Me.LabelBL.TabIndex = 20
        Me.LabelBL.Text = "B/L No"
        '
        'FrmOutwardDiscount
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(358, 244)
        Me.Controls.Add(Me.BLNO)
        Me.Controls.Add(Me.LabelBL)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Controls.Add(Me.GeneralForms)
        Me.Name = "FrmOutwardDiscount"
        Me.Text = "Outward Discount"
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        CType(Me.LinesGroupDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LinesGroupDetail.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GeneralForms As Shipping.UserGeneralForms
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents LinesGroupDetail As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents LblName As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents BLNO As Shipping.UserText
    Friend WithEvents LabelBL As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents dAmount As Shipping.UserNum
    Friend WithEvents dPercent As Shipping.UserNum
    Friend WithEvents dFreeDays As Shipping.UserNum
    Friend WithEvents IsFDaysAsDiscount As Infragistics.Win.UltraWinEditors.UltraCheckEditor
End Class
