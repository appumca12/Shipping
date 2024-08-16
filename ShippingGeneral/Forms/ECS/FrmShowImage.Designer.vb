<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmShowImage
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.Picture = New System.Windows.Forms.PictureBox
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ButtonSave = New System.Windows.Forms.ToolStripButton
        Me.CNetHelpProvider = New System.Windows.Forms.HelpProvider
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.Picture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Picture, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ToolStrip1, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CNetHelpProvider.SetHelpKeyword(Me.TableLayoutPanel1, "Shipping_Form_FrmShowImage.htm#FrmShowImage_TableLayoutPanel1")
        Me.CNetHelpProvider.SetHelpNavigator(Me.TableLayoutPanel1, System.Windows.Forms.HelpNavigator.Topic)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.845209!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.15479!))
        Me.CNetHelpProvider.SetShowHelp(Me.TableLayoutPanel1, True)
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(756, 407)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Picture
        '
        Me.Picture.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CNetHelpProvider.SetHelpKeyword(Me.Picture, "Shipping_Form_FrmShowImage.htm#FrmShowImage_Picture")
        Me.CNetHelpProvider.SetHelpNavigator(Me.Picture, System.Windows.Forms.HelpNavigator.Topic)
        Me.Picture.Location = New System.Drawing.Point(3, 39)
        Me.Picture.Name = "Picture"
        Me.CNetHelpProvider.SetShowHelp(Me.Picture, True)
        Me.Picture.Size = New System.Drawing.Size(750, 365)
        Me.Picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Picture.TabIndex = 0
        Me.Picture.TabStop = False
        '
        'ToolStrip1
        '
        Me.CNetHelpProvider.SetHelpKeyword(Me.ToolStrip1, "Shipping_Form_FrmShowImage.htm#FrmShowImage_ToolStrip1")
        Me.CNetHelpProvider.SetHelpNavigator(Me.ToolStrip1, System.Windows.Forms.HelpNavigator.Topic)
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ButtonSave})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.CNetHelpProvider.SetShowHelp(Me.ToolStrip1, True)
        Me.ToolStrip1.Size = New System.Drawing.Size(756, 31)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ButtonSave
        '
        Me.ButtonSave.Image = Global.Shipping.My.Resources.Resources.save_24
        Me.ButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonSave.Name = "ButtonSave"
        Me.ButtonSave.Size = New System.Drawing.Size(59, 28)
        Me.ButtonSave.Text = "Save"
        '
        'CNetHelpProvider
        '
        Me.CNetHelpProvider.HelpNamespace = "Shipping.chm"
        '
        'FrmShowImage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(756, 407)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.CNetHelpProvider.SetHelpKeyword(Me, "Shipping_Form_FrmShowImage.htm")
        Me.CNetHelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.Topic)
        Me.Name = "FrmShowImage"
        Me.CNetHelpProvider.SetShowHelp(Me, True)
        Me.Text = "Show Image"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.Picture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Picture As System.Windows.Forms.PictureBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ButtonSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents CNetHelpProvider As System.Windows.Forms.HelpProvider
End Class
