<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserComboCode
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
        Me.ComboCode = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'ComboCode
        '
        Me.ComboCode.AllowDrop = True
        Me.ComboCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboCode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComboCode.FormattingEnabled = True
        Me.ComboCode.Location = New System.Drawing.Point(0, 0)
        Me.ComboCode.Name = "ComboCode"
        Me.ComboCode.Size = New System.Drawing.Size(203, 21)
        Me.ComboCode.Sorted = True
        Me.ComboCode.TabIndex = 0
        '
        'UserComboCode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Controls.Add(Me.ComboCode)
        Me.Name = "UserComboCode"
        Me.Size = New System.Drawing.Size(203, 22)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ComboCode As System.Windows.Forms.ComboBox

End Class
