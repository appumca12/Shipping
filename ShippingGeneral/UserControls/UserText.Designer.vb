<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserText
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
        Me.GeneralText = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'GeneralText
        '
        Me.GeneralText.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GeneralText.Location = New System.Drawing.Point(0, 0)
        Me.GeneralText.Name = "GeneralText"
        Me.GeneralText.Size = New System.Drawing.Size(250, 20)
        Me.GeneralText.TabIndex = 0
        '
        'UserText
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.GeneralText)
        Me.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Name = "UserText"
        Me.Size = New System.Drawing.Size(250, 23)
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub
    Friend WithEvents GeneralText As System.Windows.Forms.TextBox
    Friend WithEvents GeneralForms As Shipping.UserGeneralForms ' For ILS Shortcuts
End Class
