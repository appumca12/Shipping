<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserNavigate
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserNavigate))
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.LastRec = New Infragistics.Win.Misc.UltraButton
        Me.NextRec = New Infragistics.Win.Misc.UltraButton
        Me.PrivRec = New Infragistics.Win.Misc.UltraButton
        Me.FirstRec = New Infragistics.Win.Misc.UltraButton
        Me.SuspendLayout()
        '
        'LastRec
        '
        Appearance1.Image = CType(resources.GetObject("Appearance1.Image"), Object)
        Me.LastRec.Appearance = Appearance1
        Me.LastRec.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button
        Me.LastRec.Location = New System.Drawing.Point(70, 2)
        Me.LastRec.Name = "LastRec"
        Me.LastRec.Size = New System.Drawing.Size(22, 22)
        Me.LastRec.SupportThemes = False
        Me.LastRec.TabIndex = 7
        '
        'NextRec
        '
        Appearance2.Image = CType(resources.GetObject("Appearance2.Image"), Object)
        Me.NextRec.Appearance = Appearance2
        Me.NextRec.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button
        Me.NextRec.Location = New System.Drawing.Point(48, 2)
        Me.NextRec.Name = "NextRec"
        Me.NextRec.Size = New System.Drawing.Size(23, 22)
        Me.NextRec.SupportThemes = False
        Me.NextRec.TabIndex = 6
        '
        'PrivRec
        '
        Appearance3.Image = CType(resources.GetObject("Appearance3.Image"), Object)
        Me.PrivRec.Appearance = Appearance3
        Me.PrivRec.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button
        Me.PrivRec.Location = New System.Drawing.Point(26, 2)
        Me.PrivRec.Name = "PrivRec"
        Me.PrivRec.Size = New System.Drawing.Size(23, 22)
        Me.PrivRec.SupportThemes = False
        Me.PrivRec.TabIndex = 5
        '
        'FirstRec
        '
        Appearance4.Image = CType(resources.GetObject("Appearance4.Image"), Object)
        Me.FirstRec.Appearance = Appearance4
        Me.FirstRec.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button
        Me.FirstRec.Location = New System.Drawing.Point(4, 2)
        Me.FirstRec.Name = "FirstRec"
        Me.FirstRec.Size = New System.Drawing.Size(22, 22)
        Me.FirstRec.SupportThemes = False
        Me.FirstRec.TabIndex = 4
        '
        'UserNavigate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LastRec)
        Me.Controls.Add(Me.NextRec)
        Me.Controls.Add(Me.PrivRec)
        Me.Controls.Add(Me.FirstRec)
        Me.Name = "UserNavigate"
        Me.Size = New System.Drawing.Size(96, 26)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LastRec As Infragistics.Win.Misc.UltraButton
    Friend WithEvents NextRec As Infragistics.Win.Misc.UltraButton
    Friend WithEvents PrivRec As Infragistics.Win.Misc.UltraButton
    Friend WithEvents FirstRec As Infragistics.Win.Misc.UltraButton

End Class
