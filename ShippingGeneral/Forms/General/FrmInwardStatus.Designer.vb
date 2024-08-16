<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmInwardStatus
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
        Me.GroupBox2 = New Infragistics.Win.Misc.UltraGroupBox
        Me.SearchBlNo = New Shipping.UserText
        Me.Label1 = New System.Windows.Forms.Label
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        CType(Me.GroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GeneralForms
        '
        Me.GeneralForms.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GeneralForms.Location = New System.Drawing.Point(0, 0)
        Me.GeneralForms.Name = "GeneralForms"
        Me.GeneralForms.Size = New System.Drawing.Size(503, 453)
        Me.GeneralForms.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.UltraGroupBox1)
        Me.GroupBox2.Controls.Add(Me.SearchBlNo)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(11, 45)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(483, 396)
        Me.GroupBox2.SupportThemes = False
        Me.GroupBox2.TabIndex = 18
        Me.GroupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.VisualStudio2005
        '
        'SearchBlNo
        '
        Me.SearchBlNo.BackColor = System.Drawing.Color.Transparent
        Me.SearchBlNo.CustomMaxLength = CType(100, Byte)
        Me.SearchBlNo.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.SearchBlNo.Location = New System.Drawing.Point(63, 16)
        Me.SearchBlNo.Name = "SearchBlNo"
        Me.SearchBlNo.Size = New System.Drawing.Size(169, 22)
        Me.SearchBlNo.TabIndex = 15
        Me.SearchBlNo.TextValue = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "B/L No."
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Location = New System.Drawing.Point(19, 44)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(447, 334)
        Me.UltraGroupBox1.SupportThemes = False
        Me.UltraGroupBox1.TabIndex = 17
        '
        'FrmInwardStatus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(503, 453)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GeneralForms)
        Me.Name = "FrmInwardStatus"
        Me.Text = "Inward Status"
        CType(Me.GroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GeneralForms As Shipping.UserGeneralForms
    Friend WithEvents GroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents SearchBlNo As Shipping.UserText
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
