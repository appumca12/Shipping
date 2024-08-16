<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLines
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
        Me.components = New System.ComponentModel.Container
        Me.GeneralForms = New Shipping.UserGeneralForms
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.LinesGroupDetail = New Infragistics.Win.Misc.UltraGroupBox
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel
        Me.EDICode = New Shipping.UserText
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.LineCode = New Shipping.UserText
        Me.Country = New Shipping.UserComboCode
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel
        Me.LblName = New Infragistics.Win.Misc.UltraLabel
        Me.Tel = New Shipping.UserText
        Me.Address = New Shipping.UserText
        Me.LineName = New Shipping.UserText
        Me.LblLineCode = New Infragistics.Win.Misc.UltraLabel
        Me.SearchCode = New Shipping.UserText
        Me.FormErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.LinesGroupDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LinesGroupDetail.SuspendLayout()
        CType(Me.FormErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GeneralForms
        '
        Me.GeneralForms.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GeneralForms.Location = New System.Drawing.Point(0, 0)
        Me.GeneralForms.Name = "GeneralForms"
        Me.GeneralForms.ShowHistoryButtom = False
        Me.GeneralForms.ShowNavigate = False
        Me.GeneralForms.ShowPrintButtom = False
        Me.GeneralForms.Size = New System.Drawing.Size(575, 330)
        Me.GeneralForms.TabIndex = 0
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.LinesGroupDetail)
        Me.UltraGroupBox1.Location = New System.Drawing.Point(7, 79)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(559, 225)
        Me.UltraGroupBox1.SupportThemes = False
        Me.UltraGroupBox1.TabIndex = 16
        Me.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.VisualStudio2005
        '
        'LinesGroupDetail
        '
        Me.LinesGroupDetail.Controls.Add(Me.UltraLabel2)
        Me.LinesGroupDetail.Controls.Add(Me.EDICode)
        Me.LinesGroupDetail.Controls.Add(Me.UltraLabel1)
        Me.LinesGroupDetail.Controls.Add(Me.LineCode)
        Me.LinesGroupDetail.Controls.Add(Me.Country)
        Me.LinesGroupDetail.Controls.Add(Me.UltraLabel5)
        Me.LinesGroupDetail.Controls.Add(Me.UltraLabel4)
        Me.LinesGroupDetail.Controls.Add(Me.UltraLabel3)
        Me.LinesGroupDetail.Controls.Add(Me.LblName)
        Me.LinesGroupDetail.Controls.Add(Me.Tel)
        Me.LinesGroupDetail.Controls.Add(Me.Address)
        Me.LinesGroupDetail.Controls.Add(Me.LineName)
        Me.LinesGroupDetail.Location = New System.Drawing.Point(15, 16)
        Me.LinesGroupDetail.Name = "LinesGroupDetail"
        Me.LinesGroupDetail.Size = New System.Drawing.Size(527, 192)
        Me.LinesGroupDetail.SupportThemes = False
        Me.LinesGroupDetail.TabIndex = 10
        Me.LinesGroupDetail.Text = "Line Details"
        '
        'UltraLabel2
        '
        Me.UltraLabel2.Location = New System.Drawing.Point(27, 162)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(67, 21)
        Me.UltraLabel2.TabIndex = 19
        Me.UltraLabel2.Text = "EDI Code"
        '
        'EDICode
        '
        Me.EDICode.BackColor = System.Drawing.Color.Transparent
        Me.EDICode.CustomMaxLength = CType(10, Byte)
        Me.EDICode.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.EDICode.Location = New System.Drawing.Point(100, 161)
        Me.EDICode.Name = "EDICode"
        Me.EDICode.Size = New System.Drawing.Size(75, 21)
        Me.EDICode.TabIndex = 5
        Me.EDICode.TextValue = ""
        '
        'UltraLabel1
        '
        Me.UltraLabel1.Location = New System.Drawing.Point(27, 21)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(67, 21)
        Me.UltraLabel1.TabIndex = 17
        Me.UltraLabel1.Text = "Code"
        '
        'LineCode
        '
        Me.LineCode.BackColor = System.Drawing.Color.Transparent
        Me.LineCode.CustomMaxLength = CType(5, Byte)
        Me.LineCode.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.LineCode.Location = New System.Drawing.Point(100, 15)
        Me.LineCode.Name = "LineCode"
        Me.LineCode.Size = New System.Drawing.Size(75, 21)
        Me.LineCode.TabIndex = 0
        Me.LineCode.TextValue = ""
        '
        'Country
        '
        Me.Country.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Country.Code = ""
        Me.Country.CustomShowAll = False
        Me.Country.Location = New System.Drawing.Point(100, 133)
        Me.Country.Name = "Country"
        Me.Country.Size = New System.Drawing.Size(198, 21)
        Me.Country.TabIndex = 4
        '
        'UltraLabel5
        '
        Me.UltraLabel5.Location = New System.Drawing.Point(27, 136)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.Size = New System.Drawing.Size(67, 17)
        Me.UltraLabel5.TabIndex = 13
        Me.UltraLabel5.Text = "Country"
        '
        'UltraLabel4
        '
        Me.UltraLabel4.Location = New System.Drawing.Point(27, 106)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.Size = New System.Drawing.Size(67, 18)
        Me.UltraLabel4.TabIndex = 12
        Me.UltraLabel4.Text = "Tel"
        '
        'UltraLabel3
        '
        Me.UltraLabel3.Location = New System.Drawing.Point(27, 77)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(67, 20)
        Me.UltraLabel3.TabIndex = 11
        Me.UltraLabel3.Text = "Address"
        '
        'LblName
        '
        Me.LblName.Location = New System.Drawing.Point(27, 48)
        Me.LblName.Name = "LblName"
        Me.LblName.Size = New System.Drawing.Size(67, 19)
        Me.LblName.TabIndex = 8
        Me.LblName.Text = "Name"
        '
        'Tel
        '
        Me.Tel.BackColor = System.Drawing.Color.Transparent
        Me.Tel.CustomMaxLength = CType(100, Byte)
        Me.Tel.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Tel.Location = New System.Drawing.Point(100, 104)
        Me.Tel.Name = "Tel"
        Me.Tel.Size = New System.Drawing.Size(198, 21)
        Me.Tel.TabIndex = 3
        Me.Tel.TextValue = ""
        '
        'Address
        '
        Me.Address.BackColor = System.Drawing.Color.Transparent
        Me.Address.CustomMaxLength = CType(100, Byte)
        Me.Address.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Address.Location = New System.Drawing.Point(100, 74)
        Me.Address.Name = "Address"
        Me.Address.Size = New System.Drawing.Size(405, 21)
        Me.Address.TabIndex = 2
        Me.Address.TextValue = ""
        '
        'LineName
        '
        Me.LineName.BackColor = System.Drawing.Color.Transparent
        Me.LineName.CustomMaxLength = CType(100, Byte)
        Me.LineName.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.LineName.Location = New System.Drawing.Point(100, 44)
        Me.LineName.Name = "LineName"
        Me.LineName.Size = New System.Drawing.Size(403, 21)
        Me.LineName.TabIndex = 1
        Me.LineName.TextValue = ""
        '
        'LblLineCode
        '
        Me.LblLineCode.Location = New System.Drawing.Point(7, 49)
        Me.LblLineCode.Name = "LblLineCode"
        Me.LblLineCode.Size = New System.Drawing.Size(52, 19)
        Me.LblLineCode.TabIndex = 9
        Me.LblLineCode.Text = "Name"
        '
        'SearchCode
        '
        Me.SearchCode.BackColor = System.Drawing.Color.Transparent
        Me.SearchCode.CustomMaxLength = CType(3, Byte)
        Me.SearchCode.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.SearchCode.Location = New System.Drawing.Point(65, 47)
        Me.SearchCode.Name = "SearchCode"
        Me.SearchCode.Size = New System.Drawing.Size(75, 21)
        Me.SearchCode.TabIndex = 0
        Me.SearchCode.TextValue = ""
        '
        'FormErrorProvider
        '
        Me.FormErrorProvider.ContainerControl = Me
        '
        'FrmLines
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(575, 330)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Controls.Add(Me.SearchCode)
        Me.Controls.Add(Me.LblLineCode)
        Me.Controls.Add(Me.GeneralForms)
        Me.Name = "FrmLines"
        Me.Text = "Lines Information"
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        CType(Me.LinesGroupDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LinesGroupDetail.ResumeLayout(False)
        CType(Me.FormErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GeneralForms As Shipping.UserGeneralForms
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents LinesGroupDetail As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents LblLineCode As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents LblName As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Tel As Shipping.UserText
    Friend WithEvents Address As Shipping.UserText
    Friend WithEvents LineName As Shipping.UserText
    Friend WithEvents SearchCode As Shipping.UserText
    Friend WithEvents Country As Shipping.UserComboCode
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents LineCode As Shipping.UserText
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents EDICode As Shipping.UserText
    Friend WithEvents FormErrorProvider As System.Windows.Forms.ErrorProvider
End Class
