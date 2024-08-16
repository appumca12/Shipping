<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserRemarks
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
        Me.GeneralLabel = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'GeneralText
        '
        Me.GeneralLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GeneralLabel.Location = New System.Drawing.Point(0, 0)
        Me.GeneralLabel.Name = "GeneralLabel"
        Me.GeneralLabel.Size = New System.Drawing.Size(250, 20)
        Me.GeneralLabel.TabIndex = 0
        '
        'UserText
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.GeneralLabel)
        Me.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Name = "UserText"
        Me.Size = New System.Drawing.Size(250, 23)
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub
    Friend WithEvents GeneralLabel As System.Windows.Forms.Label
    Friend WithEvents GeneralForms As Shipping.UserGeneralForms ' For ILS Shortcuts
End Class
