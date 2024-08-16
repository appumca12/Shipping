<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserDetentionByDay
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.Detention = New Infragistics.Win.Misc.UltraButton
        Me.UltraNumericEditor1 = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        CType(Me.UltraNumericEditor1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Detention
        '
        Appearance1.Image = Global.Shipping.My.Resources.Resources.print_24
        Appearance1.TextHAlign = Infragistics.Win.HAlign.Left
        Appearance1.TextVAlign = Infragistics.Win.VAlign.Middle
        Me.Detention.Appearance = Appearance1
        Me.Detention.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Detention.ImageSize = New System.Drawing.Size(24, 24)
        Me.Detention.Location = New System.Drawing.Point(0, 0)
        Me.Detention.Name = "Detention"
        Me.Detention.Size = New System.Drawing.Size(129, 41)
        Me.Detention.TabIndex = 0
        Me.Detention.Text = "Detention"
        '
        'UltraNumericEditor1
        '
        Me.UltraNumericEditor1.AllowDrop = True
        Me.UltraNumericEditor1.Location = New System.Drawing.Point(83, 10)
        Me.UltraNumericEditor1.Name = "UltraNumericEditor1"
        Me.UltraNumericEditor1.ShowInkButton = Infragistics.Win.ShowInkButton.Always
        Me.UltraNumericEditor1.Size = New System.Drawing.Size(35, 21)
        Me.UltraNumericEditor1.TabIndex = 1
        '
        'UserDetentionByDay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.UltraNumericEditor1)
        Me.Controls.Add(Me.Detention)
        Me.Name = "UserDetentionByDay"
        Me.Size = New System.Drawing.Size(129, 41)
        CType(Me.UltraNumericEditor1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Detention As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraNumericEditor1 As Infragistics.Win.UltraWinEditors.UltraNumericEditor

End Class
