<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ThumbnailControl
    Inherits System.Windows.Forms.UserControl

    'UserControl1 overrides dispose to clean up the component list.
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
        Me.ImageThumbnail = New System.Windows.Forms.Panel
        Me.Menu = New System.Windows.Forms.ToolStrip
        Me.ShowHeader = New System.Windows.Forms.ToolStripLabel
        Me.ButtonShow = New System.Windows.Forms.ToolStripButton
        Me.ButtonDownLoad = New System.Windows.Forms.ToolStripButton
        Me.ButtonRemove = New System.Windows.Forms.ToolStripButton
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        Me.ButtonRefresh = New System.Windows.Forms.ToolStripButton
        Me.ImageThumbnail.SuspendLayout()
        Me.Menu.SuspendLayout()
        Me.SuspendLayout()
        '
        'ImageThumbnail
        '
        Me.ImageThumbnail.AutoScroll = True
        Me.ImageThumbnail.BackColor = System.Drawing.Color.Gainsboro
        Me.ImageThumbnail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ImageThumbnail.Controls.Add(Me.Menu)
        Me.ImageThumbnail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ImageThumbnail.Location = New System.Drawing.Point(0, 0)
        Me.ImageThumbnail.Name = "ImageThumbnail"
        Me.ImageThumbnail.Size = New System.Drawing.Size(350, 188)
        Me.ImageThumbnail.TabIndex = 3
        '
        'Menu
        '
        Me.Menu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ShowHeader, Me.ButtonRefresh, Me.ButtonShow, Me.ButtonDownLoad, Me.ButtonRemove})
        Me.Menu.Location = New System.Drawing.Point(0, 0)
        Me.Menu.Name = "Menu"
        Me.Menu.Size = New System.Drawing.Size(348, 25)
        Me.Menu.TabIndex = 0
        Me.Menu.Text = "ToolStrip1"
        '
        'ShowHeader
        '
        Me.ShowHeader.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ShowHeader.Name = "ShowHeader"
        Me.ShowHeader.Size = New System.Drawing.Size(107, 22)
        Me.ShowHeader.Text = "ToolStripLabel1"
        '
        'ButtonShow
        '
        Me.ButtonShow.Image = Global.Shipping.My.Resources.Resources.documents_16
        Me.ButtonShow.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonShow.Name = "ButtonShow"
        Me.ButtonShow.Size = New System.Drawing.Size(86, 22)
        Me.ButtonShow.Text = "Show Image"
        '
        'ButtonDownLoad
        '
        Me.ButtonDownLoad.Image = Global.Shipping.My.Resources.Resources.export_24
        Me.ButtonDownLoad.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonDownLoad.Name = "ButtonDownLoad"
        Me.ButtonDownLoad.Size = New System.Drawing.Size(76, 20)
        Me.ButtonDownLoad.Text = "AddImage"
        '
        'ButtonRemove
        '
        Me.ButtonRemove.Image = Global.Shipping.My.Resources.Resources.delete_24
        Me.ButtonRemove.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonRemove.Name = "ButtonRemove"
        Me.ButtonRemove.Size = New System.Drawing.Size(91, 20)
        Me.ButtonRemove.Text = "Delete Image"
        '
        'ButtonRefresh
        '
        Me.ButtonRefresh.Image = Global.Shipping.My.Resources.Resources.refresh_24
        Me.ButtonRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonRefresh.Name = "ButtonRefresh"
        Me.ButtonRefresh.Size = New System.Drawing.Size(65, 22)
        Me.ButtonRefresh.Text = "Refresh"
        '
        'ThumbnailControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ImageThumbnail)
        Me.Name = "ThumbnailControl"
        Me.Size = New System.Drawing.Size(350, 188)
        Me.ImageThumbnail.ResumeLayout(False)
        Me.ImageThumbnail.PerformLayout()
        Me.Menu.ResumeLayout(False)
        Me.Menu.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ImageThumbnail As System.Windows.Forms.Panel
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents Menu As System.Windows.Forms.ToolStrip
    Friend WithEvents ButtonShow As System.Windows.Forms.ToolStripButton
    Friend WithEvents ButtonRemove As System.Windows.Forms.ToolStripButton
    Friend WithEvents ButtonDownLoad As System.Windows.Forms.ToolStripButton
    Friend WithEvents ShowHeader As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ButtonRefresh As System.Windows.Forms.ToolStripButton

End Class
