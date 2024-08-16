<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserComboGnrl
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
        Me.ComboGnrl = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'ComboGnrl
        '
        Me.ComboGnrl.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboGnrl.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboGnrl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComboGnrl.FormattingEnabled = True
        Me.ComboGnrl.Location = New System.Drawing.Point(0, 0)
        Me.ComboGnrl.Name = "ComboGnrl"
        Me.ComboGnrl.Size = New System.Drawing.Size(217, 21)
        Me.ComboGnrl.Sorted = True
        Me.ComboGnrl.TabIndex = 0
        '
        'UserComboGnrl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ComboGnrl)
        Me.Name = "UserComboGnrl"
        Me.Size = New System.Drawing.Size(217, 22)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ComboGnrl As System.Windows.Forms.ComboBox

End Class
