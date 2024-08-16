<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserInfo
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.MailRelease = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.LCNO = New Shipping.UserText
        Me.FrtCoverdBLNo = New Shipping.UserText
        Me.MailReleaseRem = New Shipping.UserText
        Me.ClientID = New Shipping.UserClients
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.Label4)
        Me.UltraGroupBox1.Controls.Add(Me.Label3)
        Me.UltraGroupBox1.Controls.Add(Me.Label2)
        Me.UltraGroupBox1.Controls.Add(Me.Label1)
        Me.UltraGroupBox1.Controls.Add(Me.LCNO)
        Me.UltraGroupBox1.Controls.Add(Me.FrtCoverdBLNo)
        Me.UltraGroupBox1.Controls.Add(Me.MailReleaseRem)
        Me.UltraGroupBox1.Controls.Add(Me.MailRelease)
        Me.UltraGroupBox1.Controls.Add(Me.ClientID)
        Me.UltraGroupBox1.Location = New System.Drawing.Point(5, 7)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(731, 249)
        Me.UltraGroupBox1.SupportThemes = False
        Me.UltraGroupBox1.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(33, 113)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "L/C No."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(30, 88)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Freight Coverd By"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(30, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Mail Release"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(33, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Client"
        '
        'MailRelease
        '
        Me.MailRelease.Location = New System.Drawing.Point(126, 56)
        Me.MailRelease.Name = "MailRelease"
        Me.MailRelease.Size = New System.Drawing.Size(16, 20)
        Me.MailRelease.TabIndex = 1
        Me.MailRelease.Text = "Mail Release"
        '
        'LCNO
        '
        Me.LCNO.BackColor = System.Drawing.Color.Transparent
        Me.LCNO.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.LCNO.Location = New System.Drawing.Point(126, 110)
        Me.LCNO.Name = "LCNO"
        Me.LCNO.Size = New System.Drawing.Size(151, 22)
        Me.LCNO.TabIndex = 4
        Me.LCNO.TextValue = ""
        '
        'FrtCoverdBLNo
        '
        Me.FrtCoverdBLNo.BackColor = System.Drawing.Color.Transparent
        Me.FrtCoverdBLNo.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.FrtCoverdBLNo.Location = New System.Drawing.Point(126, 82)
        Me.FrtCoverdBLNo.Name = "FrtCoverdBLNo"
        Me.FrtCoverdBLNo.Size = New System.Drawing.Size(151, 22)
        Me.FrtCoverdBLNo.TabIndex = 3
        Me.FrtCoverdBLNo.TextValue = ""
        '
        'MailReleaseRem
        '
        Me.MailReleaseRem.BackColor = System.Drawing.Color.Transparent
        Me.MailReleaseRem.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.MailReleaseRem.Location = New System.Drawing.Point(148, 54)
        Me.MailReleaseRem.Name = "MailReleaseRem"
        Me.MailReleaseRem.Size = New System.Drawing.Size(287, 22)
        Me.MailReleaseRem.TabIndex = 2
        Me.MailReleaseRem.TextValue = ""
        '
        'ClientID
        '
        Me.ClientID.ClientID = New System.Guid("00000000-0000-0000-0000-000000000000")
        Me.ClientID.Location = New System.Drawing.Point(126, 25)
        Me.ClientID.Name = "ClientID"
        Me.ClientID.Size = New System.Drawing.Size(384, 25)
        Me.ClientID.TabIndex = 0
        '
        'UserInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Name = "UserInfo"
        Me.Size = New System.Drawing.Size(746, 266)
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents ClientID As Shipping.UserClients
    Friend WithEvents FrtCoverdBLNo As Shipping.UserText
    Friend WithEvents MailReleaseRem As Shipping.UserText
    Friend WithEvents MailRelease As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LCNO As Shipping.UserText
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label

End Class
