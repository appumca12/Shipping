<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmShowDamage
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton
        Me.ButtonUploadBeforeImages = New System.Windows.Forms.ToolStripButton
        Me.ButtonUploadAfter = New System.Windows.Forms.ToolStripButton
        Me.CNetHelpProvider = New System.Windows.Forms.HelpProvider
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.CNetHelpProvider.SetHelpKeyword(Me.ToolStrip1, "Shipping_Form_FrmShowDamage.htm#FrmShowDamage_ToolStrip1")
        Me.CNetHelpProvider.SetHelpNavigator(Me.ToolStrip1, System.Windows.Forms.HelpNavigator.Topic)
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton3, Me.ToolStripButton1, Me.ToolStripButton2, Me.ButtonUploadBeforeImages, Me.ButtonUploadAfter})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.CNetHelpProvider.SetShowHelp(Me.ToolStrip1, True)
        Me.ToolStrip1.Size = New System.Drawing.Size(755, 31)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton3.Image = Global.Shipping.My.Resources.Resources.refresh_24
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(28, 28)
        Me.ToolStripButton3.Text = "ToolStripButton3"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = Global.Shipping.My.Resources.Resources.arrow_back_24
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(28, 28)
        Me.ToolStripButton1.Text = "ToolStripButton1"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = Global.Shipping.My.Resources.Resources.arrow_forward_24
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(28, 28)
        Me.ToolStripButton2.Text = "ToolStripButton2"
        '
        'ButtonUploadBeforeImages
        '
        Me.ButtonUploadBeforeImages.Image = Global.Shipping.My.Resources.Resources.export_24
        Me.ButtonUploadBeforeImages.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonUploadBeforeImages.Name = "ButtonUploadBeforeImages"
        Me.ButtonUploadBeforeImages.Size = New System.Drawing.Size(175, 28)
        Me.ButtonUploadBeforeImages.Text = "Upload Before Repair Images"
        '
        'ButtonUploadAfter
        '
        Me.ButtonUploadAfter.Image = Global.Shipping.My.Resources.Resources.export_24
        Me.ButtonUploadAfter.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonUploadAfter.Name = "ButtonUploadAfter"
        Me.ButtonUploadAfter.Size = New System.Drawing.Size(162, 28)
        Me.ButtonUploadAfter.Text = "Upload After Rapir Images"
        '
        'CNetHelpProvider
        '
        Me.CNetHelpProvider.HelpNamespace = "Shipping.chm"
        '
        'FrmShowDamage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(755, 433)
        Me.Controls.Add(Me.ToolStrip1)
        Me.CNetHelpProvider.SetHelpKeyword(Me, "Shipping_Form_FrmShowDamage.htm")
        Me.CNetHelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.Topic)
        Me.Name = "FrmShowDamage"
        Me.CNetHelpProvider.SetShowHelp(Me, True)
        Me.Text = "FrmShowDamage"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ButtonUploadBeforeImages As System.Windows.Forms.ToolStripButton
    Friend WithEvents ButtonUploadAfter As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents CNetHelpProvider As System.Windows.Forms.HelpProvider
End Class
