<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserMemo
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
        Me.GeneralText = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        CType(Me.GeneralText, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GeneralText
        '
        Me.GeneralText.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GeneralText.Location = New System.Drawing.Point(0, 0)
        Me.GeneralText.Multiline = True
        Me.GeneralText.Name = "GeneralText"
        Me.GeneralText.Size = New System.Drawing.Size(196, 87)
        Me.GeneralText.TabIndex = 0
        '
        'UserMemo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GeneralText)
        Me.Name = "UserMemo"
        Me.Size = New System.Drawing.Size(196, 87)
        CType(Me.GeneralText, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GeneralText As Infragistics.Win.UltraWinEditors.UltraTextEditor

End Class
