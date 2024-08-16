<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserTextFarsi
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
        Me.FarsiText = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'FarsiText
        '
        Me.FarsiText.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FarsiText.Font = New System.Drawing.Font("B Traffic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FarsiText.Location = New System.Drawing.Point(0, 0)
        Me.FarsiText.Name = "FarsiText"
        Me.FarsiText.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.FarsiText.Size = New System.Drawing.Size(349, 22)
        Me.FarsiText.TabIndex = 0
        '
        'UserTextFarsi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.FarsiText)
        Me.Name = "UserTextFarsi"
        Me.Size = New System.Drawing.Size(349, 22)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FarsiText As System.Windows.Forms.TextBox

End Class
