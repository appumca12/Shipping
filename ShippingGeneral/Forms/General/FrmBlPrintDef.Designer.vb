<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBlPrintDef
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
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.BodyLines = New Shipping.UserNum
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel
        Me.ObjectRemarks = New Shipping.UserText
        Me.ObjectName = New Shipping.UserText
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ButtonRetrieve = New System.Windows.Forms.ToolStripButton
        Me.ButtonSave = New System.Windows.Forms.ToolStripButton
        Me.ComboList = New Shipping.UserComboGnrl
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraLabel1
        '
        Me.UltraLabel1.Location = New System.Drawing.Point(12, 53)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(49, 23)
        Me.UltraLabel1.TabIndex = 2
        Me.UltraLabel1.Text = "Reports"
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.BodyLines)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel3)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel4)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel2)
        Me.UltraGroupBox1.Controls.Add(Me.ObjectRemarks)
        Me.UltraGroupBox1.Controls.Add(Me.ObjectName)
        Me.UltraGroupBox1.Location = New System.Drawing.Point(12, 88)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(394, 200)
        Me.UltraGroupBox1.TabIndex = 3
        Me.UltraGroupBox1.Text = "Details"
        '
        'BodyLines
        '
        Me.BodyLines.CtrlValue = 0
        Me.BodyLines.Location = New System.Drawing.Point(81, 60)
        Me.BodyLines.Name = "BodyLines"
        Me.BodyLines.Size = New System.Drawing.Size(60, 23)
        Me.BodyLines.TabIndex = 2
        '
        'UltraLabel3
        '
        Me.UltraLabel3.Location = New System.Drawing.Point(6, 91)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(70, 23)
        Me.UltraLabel3.TabIndex = 1
        Me.UltraLabel3.Text = "Remarks"
        '
        'UltraLabel4
        '
        Me.UltraLabel4.Location = New System.Drawing.Point(6, 64)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.Size = New System.Drawing.Size(70, 23)
        Me.UltraLabel4.TabIndex = 1
        Me.UltraLabel4.Text = "Body lines"
        '
        'UltraLabel2
        '
        Me.UltraLabel2.Location = New System.Drawing.Point(6, 35)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(43, 23)
        Me.UltraLabel2.TabIndex = 1
        Me.UltraLabel2.Text = "Name"
        '
        'ObjectRemarks
        '
        Me.ObjectRemarks.BackColor = System.Drawing.Color.Transparent
        Me.ObjectRemarks.CustomMaxLength = CType(100, Byte)
        Me.ObjectRemarks.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.ObjectRemarks.Location = New System.Drawing.Point(82, 91)
        Me.ObjectRemarks.Name = "ObjectRemarks"
        Me.ObjectRemarks.Size = New System.Drawing.Size(250, 77)
        Me.ObjectRemarks.TabIndex = 0
        Me.ObjectRemarks.TextValue = ""
        '
        'ObjectName
        '
        Me.ObjectName.BackColor = System.Drawing.Color.Transparent
        Me.ObjectName.CustomMaxLength = CType(100, Byte)
        Me.ObjectName.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.ObjectName.Location = New System.Drawing.Point(82, 31)
        Me.ObjectName.Name = "ObjectName"
        Me.ObjectName.Size = New System.Drawing.Size(250, 23)
        Me.ObjectName.TabIndex = 0
        Me.ObjectName.TextValue = ""
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ButtonRetrieve, Me.ButtonSave})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(422, 31)
        Me.ToolStrip1.TabIndex = 4
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ButtonRetrieve
        '
        Me.ButtonRetrieve.Image = Global.Shipping.My.Resources.Resources.folder_open_24
        Me.ButtonRetrieve.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonRetrieve.Name = "ButtonRetrieve"
        Me.ButtonRetrieve.Size = New System.Drawing.Size(77, 28)
        Me.ButtonRetrieve.Text = "Retrieve"
        '
        'ButtonSave
        '
        Me.ButtonSave.Image = Global.Shipping.My.Resources.Resources.save_24
        Me.ButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonSave.Name = "ButtonSave"
        Me.ButtonSave.Size = New System.Drawing.Size(59, 28)
        Me.ButtonSave.Text = "Save"
        '
        'ComboList
        '
        Me.ComboList.CustomDatasource = Nothing
        Me.ComboList.CustomDisplayMember = ""
        Me.ComboList.CustomSelectedItem = Nothing
        Me.ComboList.CustomValueMember = ""
        Me.ComboList.Location = New System.Drawing.Point(67, 50)
        Me.ComboList.Name = "ComboList"
        Me.ComboList.Size = New System.Drawing.Size(290, 22)
        Me.ComboList.TabIndex = 1
        '
        'FrmBlPrintDef
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(422, 300)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Controls.Add(Me.UltraLabel1)
        Me.Controls.Add(Me.ComboList)
        Me.Name = "FrmBlPrintDef"
        Me.Text = "B/L Print Design"
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ComboList As Shipping.UserComboGnrl
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents ObjectRemarks As Shipping.UserText
    Friend WithEvents ObjectName As Shipping.UserText
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ButtonRetrieve As System.Windows.Forms.ToolStripButton
    Friend WithEvents ButtonSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents BodyLines As Shipping.UserNum
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    '    Friend WithEvents GeneralForms As Shipping.UserGeneralForms
End Class
