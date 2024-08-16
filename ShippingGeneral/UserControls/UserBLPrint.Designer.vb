<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserBLPrint
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox = New Infragistics.Win.Misc.UltraGroupBox
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.ButtonTemplate = New Infragistics.Win.Misc.UltraButton
        Me.ButtonPrint = New Infragistics.Win.Misc.UltraButton
        Me.ButtonAttachment = New Infragistics.Win.Misc.UltraButton
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.ComboList = New Shipping.UserComboGnrl
        CType(Me.GroupBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox.SuspendLayout()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox
        '
        Me.GroupBox.Controls.Add(Me.UltraGroupBox1)
        Me.GroupBox.Controls.Add(Me.UltraLabel1)
        Me.GroupBox.Controls.Add(Me.ComboList)
        Me.GroupBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox.Name = "GroupBox"
        Me.GroupBox.Size = New System.Drawing.Size(388, 176)
        Me.GroupBox.TabIndex = 0
        Me.GroupBox.Text = "B/L Print"
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.ButtonTemplate)
        Me.UltraGroupBox1.Controls.Add(Me.ButtonPrint)
        Me.UltraGroupBox1.Controls.Add(Me.ButtonAttachment)
        Me.UltraGroupBox1.Location = New System.Drawing.Point(34, 86)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(329, 58)
        Me.UltraGroupBox1.TabIndex = 3
        '
        'ButtonTemplate
        '
        Me.ButtonTemplate.Location = New System.Drawing.Point(219, 16)
        Me.ButtonTemplate.Name = "ButtonTemplate"
        Me.ButtonTemplate.Size = New System.Drawing.Size(88, 23)
        Me.ButtonTemplate.TabIndex = 2
        Me.ButtonTemplate.Text = "Template"
        '
        'ButtonPrint
        '
        Me.ButtonPrint.Location = New System.Drawing.Point(22, 16)
        Me.ButtonPrint.Name = "ButtonPrint"
        Me.ButtonPrint.Size = New System.Drawing.Size(88, 23)
        Me.ButtonPrint.TabIndex = 2
        Me.ButtonPrint.Text = "Print B/L"
        '
        'ButtonAttachment
        '
        Me.ButtonAttachment.Location = New System.Drawing.Point(121, 16)
        Me.ButtonAttachment.Name = "ButtonAttachment"
        Me.ButtonAttachment.Size = New System.Drawing.Size(88, 23)
        Me.ButtonAttachment.TabIndex = 2
        Me.ButtonAttachment.Text = "Print Attachment"
        '
        'UltraLabel1
        '
        Me.UltraLabel1.Location = New System.Drawing.Point(23, 38)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(53, 23)
        Me.UltraLabel1.TabIndex = 1
        Me.UltraLabel1.Text = "B/L Form"
        '
        'ComboList
        '
        Me.ComboList.CustomData = Nothing
        Me.ComboList.CustomDatasource = Nothing
        Me.ComboList.CustomDisplayMember = ""
        Me.ComboList.CustomSelectedItem = Nothing
        Me.ComboList.CustomValueMember = ""
        Me.ComboList.Location = New System.Drawing.Point(82, 38)
        Me.ComboList.Name = "ComboList"
        Me.ComboList.Size = New System.Drawing.Size(270, 22)
        Me.ComboList.TabIndex = 0
        '
        'UserBLPrint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.GroupBox)
        Me.Name = "UserBLPrint"
        Me.Size = New System.Drawing.Size(388, 176)
        CType(Me.GroupBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox.ResumeLayout(False)
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents ComboList As Shipping.UserComboGnrl
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents ButtonTemplate As Infragistics.Win.Misc.UltraButton
    Friend WithEvents ButtonPrint As Infragistics.Win.Misc.UltraButton
    Friend WithEvents ButtonAttachment As Infragistics.Win.Misc.UltraButton

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
End Class
