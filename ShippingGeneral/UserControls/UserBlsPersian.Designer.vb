<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserBlsPersian
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
        Me.GroupBox = New Infragistics.Win.Misc.UltraGroupBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.FPkgs = New Shipping.UserTextFarsi
        Me.FGoods = New Shipping.UserTextFarsi
        Me.FCnee = New Shipping.UserTextFarsi
        CType(Me.GroupBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox
        '
        Appearance1.BorderAlpha = Infragistics.Win.Alpha.Opaque
        Appearance1.BorderColor = System.Drawing.Color.White
        Appearance1.BorderColor3DBase = System.Drawing.Color.White
        Me.GroupBox.Appearance = Appearance1
        Me.GroupBox.Controls.Add(Me.Label2)
        Me.GroupBox.Controls.Add(Me.Label1)
        Me.GroupBox.Controls.Add(Me.Label17)
        Me.GroupBox.Controls.Add(Me.FPkgs)
        Me.GroupBox.Controls.Add(Me.FGoods)
        Me.GroupBox.Controls.Add(Me.FCnee)
        Me.GroupBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox.Name = "GroupBox"
        Me.GroupBox.Size = New System.Drawing.Size(665, 276)
        Me.GroupBox.TabIndex = 1
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(587, 33)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(38, 13)
        Me.Label17.TabIndex = 12
        Me.Label17.Text = "گیرنده"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(587, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "شرح کالا"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(587, 82)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "نوع بسته"
        '
        'FPkgs
        '
        Me.FPkgs.IsMultiline = False
        Me.FPkgs.Location = New System.Drawing.Point(38, 82)
        Me.FPkgs.Name = "FPkgs"
        Me.FPkgs.Size = New System.Drawing.Size(525, 22)
        Me.FPkgs.TabIndex = 2
        Me.FPkgs.TextValue = ""
        '
        'FGoods
        '
        Me.FGoods.IsMultiline = False
        Me.FGoods.Location = New System.Drawing.Point(38, 54)
        Me.FGoods.Name = "FGoods"
        Me.FGoods.Size = New System.Drawing.Size(525, 22)
        Me.FGoods.TabIndex = 1
        Me.FGoods.TextValue = ""
        '
        'FCnee
        '
        Me.FCnee.IsMultiline = False
        Me.FCnee.Location = New System.Drawing.Point(38, 25)
        Me.FCnee.Name = "FCnee"
        Me.FCnee.Size = New System.Drawing.Size(525, 22)
        Me.FCnee.TabIndex = 0
        Me.FCnee.TextValue = ""
        '
        'UserBlsPersian
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupBox)
        Me.Name = "UserBlsPersian"
        Me.Size = New System.Drawing.Size(665, 276)
        CType(Me.GroupBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox.ResumeLayout(False)
        Me.GroupBox.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents FPkgs As Shipping.UserTextFarsi
    Friend WithEvents FGoods As Shipping.UserTextFarsi
    Friend WithEvents FCnee As Shipping.UserTextFarsi
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label

End Class
