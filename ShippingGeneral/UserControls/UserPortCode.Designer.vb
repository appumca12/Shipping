<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserPortCode
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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.TxtPortCode = New Shipping.UserText
        Me.LblPortName = New Infragistics.Win.Misc.UltraLabel
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.TxtPortCode)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.LblPortName)
        Me.SplitContainer1.Size = New System.Drawing.Size(419, 25)
        Me.SplitContainer1.SplitterDistance = 76
        Me.SplitContainer1.TabIndex = 13
        '
        'TxtPortCode
        '
        Me.TxtPortCode.BackColor = System.Drawing.Color.Transparent
        Me.TxtPortCode.CustomMaxLength = CType(100, Byte)
        Me.TxtPortCode.Dock = System.Windows.Forms.DockStyle.Top
        Me.TxtPortCode.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.TxtPortCode.Location = New System.Drawing.Point(0, 0)
        Me.TxtPortCode.Name = "TxtPortCode"
        Me.TxtPortCode.Size = New System.Drawing.Size(76, 23)
        Me.TxtPortCode.TabIndex = 11
        Me.TxtPortCode.TextValue = ""
        '
        'LblPortName
        '
        Appearance1.BorderColor = System.Drawing.Color.White
        Appearance1.TextHAlign = Infragistics.Win.HAlign.Left
        Appearance1.TextVAlign = Infragistics.Win.VAlign.Middle
        Me.LblPortName.Appearance = Appearance1
        Me.LblPortName.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblPortName.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid
        Me.LblPortName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LblPortName.Location = New System.Drawing.Point(0, 0)
        Me.LblPortName.Name = "LblPortName"
        Me.LblPortName.Size = New System.Drawing.Size(339, 25)
        Me.LblPortName.TabIndex = 12
        '
        'UserPortCode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "UserPortCode"
        Me.Size = New System.Drawing.Size(419, 25)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents TxtPortCode As Shipping.UserText
    Friend WithEvents LblPortName As Infragistics.Win.Misc.UltraLabel

End Class
