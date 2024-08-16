<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmUsers
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
        Me.components = New System.ComponentModel.Container()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.UserGroupDetail = New Infragistics.Win.Misc.UltraGroupBox()
        Me.BookingViewer = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.IsEcsAdmin = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.IsDocAdmin = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.IsAccountAdmin = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.IsSalesAdmin = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel()
        Me.LblLogin = New Infragistics.Win.Misc.UltraLabel()
        Me.LblName = New Infragistics.Win.Misc.UltraLabel()
        Me.Tel = New Shipping.UserText()
        Me.EMailOffice = New Shipping.UserText()
        Me.Password = New Shipping.UserText()
        Me.UserCode = New Shipping.UserText()
        Me.UserAccount = New Shipping.UserText()
        Me.UserLastName = New Shipping.UserText()
        Me.UserFirstName = New Shipping.UserText()
        Me.FormErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lbAccesslevels = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.LableSearch = New System.Windows.Forms.Label()
        Me.TxtSearch = New Shipping.UserText()
        Me.TreeAccess = New Infragistics.Win.UltraWinTree.UltraTree()
        Me.GeneralForms = New Shipping.UserGeneralForms()
        CType(Me.UserGroupDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UserGroupDetail.SuspendLayout()
        CType(Me.BookingViewer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IsEcsAdmin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IsDocAdmin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IsAccountAdmin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IsSalesAdmin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FormErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.TreeAccess, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UserGroupDetail
        '
        Me.UserGroupDetail.Controls.Add(Me.BookingViewer)
        Me.UserGroupDetail.Controls.Add(Me.IsEcsAdmin)
        Me.UserGroupDetail.Controls.Add(Me.IsDocAdmin)
        Me.UserGroupDetail.Controls.Add(Me.IsAccountAdmin)
        Me.UserGroupDetail.Controls.Add(Me.IsSalesAdmin)
        Me.UserGroupDetail.Controls.Add(Me.UltraLabel5)
        Me.UserGroupDetail.Controls.Add(Me.UltraLabel4)
        Me.UserGroupDetail.Controls.Add(Me.UltraLabel3)
        Me.UserGroupDetail.Controls.Add(Me.UltraLabel2)
        Me.UserGroupDetail.Controls.Add(Me.LblLogin)
        Me.UserGroupDetail.Controls.Add(Me.LblName)
        Me.UserGroupDetail.Controls.Add(Me.Tel)
        Me.UserGroupDetail.Controls.Add(Me.EMailOffice)
        Me.UserGroupDetail.Controls.Add(Me.Password)
        Me.UserGroupDetail.Controls.Add(Me.UserCode)
        Me.UserGroupDetail.Controls.Add(Me.UserAccount)
        Me.UserGroupDetail.Controls.Add(Me.UserLastName)
        Me.UserGroupDetail.Controls.Add(Me.UserFirstName)
        Me.UserGroupDetail.Location = New System.Drawing.Point(15, 45)
        Me.UserGroupDetail.Name = "UserGroupDetail"
        Me.UserGroupDetail.Size = New System.Drawing.Size(527, 215)
        Me.UserGroupDetail.TabIndex = 10
        Me.UserGroupDetail.Text = "User Details"
        '
        'BookingViewer
        '
        Me.BookingViewer.Location = New System.Drawing.Point(383, 178)
        Me.BookingViewer.Name = "BookingViewer"
        Me.BookingViewer.Size = New System.Drawing.Size(120, 20)
        Me.BookingViewer.TabIndex = 18
        Me.BookingViewer.Text = "Booking Viewer"
        '
        'IsEcsAdmin
        '
        Me.IsEcsAdmin.Location = New System.Drawing.Point(239, 178)
        Me.IsEcsAdmin.Name = "IsEcsAdmin"
        Me.IsEcsAdmin.Size = New System.Drawing.Size(120, 20)
        Me.IsEcsAdmin.TabIndex = 17
        Me.IsEcsAdmin.Text = "E.C.S. Admin"
        '
        'IsDocAdmin
        '
        Me.IsDocAdmin.Location = New System.Drawing.Point(239, 145)
        Me.IsDocAdmin.Name = "IsDocAdmin"
        Me.IsDocAdmin.Size = New System.Drawing.Size(153, 20)
        Me.IsDocAdmin.TabIndex = 16
        Me.IsDocAdmin.Text = "Documentation Admin"
        '
        'IsAccountAdmin
        '
        Me.IsAccountAdmin.Location = New System.Drawing.Point(100, 178)
        Me.IsAccountAdmin.Name = "IsAccountAdmin"
        Me.IsAccountAdmin.Size = New System.Drawing.Size(120, 20)
        Me.IsAccountAdmin.TabIndex = 15
        Me.IsAccountAdmin.Text = "Account Admin"
        '
        'IsSalesAdmin
        '
        Me.IsSalesAdmin.Location = New System.Drawing.Point(100, 146)
        Me.IsSalesAdmin.Name = "IsSalesAdmin"
        Me.IsSalesAdmin.Size = New System.Drawing.Size(120, 20)
        Me.IsSalesAdmin.TabIndex = 14
        Me.IsSalesAdmin.Text = "Sales Admin"
        '
        'UltraLabel5
        '
        Me.UltraLabel5.Location = New System.Drawing.Point(359, 112)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.Size = New System.Drawing.Size(67, 17)
        Me.UltraLabel5.TabIndex = 13
        Me.UltraLabel5.Text = "User Code"
        '
        'UltraLabel4
        '
        Me.UltraLabel4.Location = New System.Drawing.Point(27, 109)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.Size = New System.Drawing.Size(67, 18)
        Me.UltraLabel4.TabIndex = 12
        Me.UltraLabel4.Text = "Tel"
        '
        'UltraLabel3
        '
        Me.UltraLabel3.Location = New System.Drawing.Point(27, 80)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(67, 20)
        Me.UltraLabel3.TabIndex = 11
        Me.UltraLabel3.Text = "E-Mail"
        '
        'UltraLabel2
        '
        Me.UltraLabel2.Location = New System.Drawing.Point(239, 22)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(67, 17)
        Me.UltraLabel2.TabIndex = 10
        Me.UltraLabel2.Text = "Password"
        '
        'LblLogin
        '
        Me.LblLogin.Location = New System.Drawing.Point(27, 21)
        Me.LblLogin.Name = "LblLogin"
        Me.LblLogin.Size = New System.Drawing.Size(67, 21)
        Me.LblLogin.TabIndex = 9
        Me.LblLogin.Text = "Login"
        '
        'LblName
        '
        Me.LblName.Location = New System.Drawing.Point(27, 51)
        Me.LblName.Name = "LblName"
        Me.LblName.Size = New System.Drawing.Size(67, 19)
        Me.LblName.TabIndex = 8
        Me.LblName.Text = "User Name"
        '
        'Tel
        '
        Me.Tel.BackColor = System.Drawing.Color.Transparent
        Me.Tel.CustomMaxLength = CType(100, Byte)
        Me.Tel.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Tel.Location = New System.Drawing.Point(100, 107)
        Me.Tel.Name = "Tel"
        Me.Tel.Size = New System.Drawing.Size(250, 23)
        Me.Tel.TabIndex = 5
        Me.Tel.TextValue = ""
        '
        'EMailOffice
        '
        Me.EMailOffice.BackColor = System.Drawing.Color.Transparent
        Me.EMailOffice.CustomMaxLength = CType(100, Byte)
        Me.EMailOffice.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.EMailOffice.Location = New System.Drawing.Point(100, 77)
        Me.EMailOffice.Name = "EMailOffice"
        Me.EMailOffice.Size = New System.Drawing.Size(250, 23)
        Me.EMailOffice.TabIndex = 4
        Me.EMailOffice.TextValue = ""
        '
        'Password
        '
        Me.Password.BackColor = System.Drawing.Color.Transparent
        Me.Password.CustomMaxLength = CType(100, Byte)
        Me.Password.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Password.Location = New System.Drawing.Point(312, 17)
        Me.Password.Name = "Password"
        Me.Password.Size = New System.Drawing.Size(191, 23)
        Me.Password.TabIndex = 1
        Me.Password.TextValue = ""
        '
        'UserCode
        '
        Me.UserCode.BackColor = System.Drawing.Color.Transparent
        Me.UserCode.CustomMaxLength = CType(100, Byte)
        Me.UserCode.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.UserCode.Location = New System.Drawing.Point(432, 109)
        Me.UserCode.Name = "UserCode"
        Me.UserCode.Size = New System.Drawing.Size(58, 23)
        Me.UserCode.TabIndex = 6
        Me.UserCode.TextValue = ""
        '
        'UserAccount
        '
        Me.UserAccount.BackColor = System.Drawing.Color.Transparent
        Me.UserAccount.CustomMaxLength = CType(100, Byte)
        Me.UserAccount.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.UserAccount.Location = New System.Drawing.Point(100, 17)
        Me.UserAccount.Name = "UserAccount"
        Me.UserAccount.Size = New System.Drawing.Size(125, 23)
        Me.UserAccount.TabIndex = 0
        Me.UserAccount.TextValue = ""
        '
        'UserLastName
        '
        Me.UserLastName.BackColor = System.Drawing.Color.Transparent
        Me.UserLastName.CustomMaxLength = CType(100, Byte)
        Me.UserLastName.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.UserLastName.Location = New System.Drawing.Point(312, 46)
        Me.UserLastName.Name = "UserLastName"
        Me.UserLastName.Size = New System.Drawing.Size(191, 23)
        Me.UserLastName.TabIndex = 3
        Me.UserLastName.TextValue = ""
        '
        'UserFirstName
        '
        Me.UserFirstName.BackColor = System.Drawing.Color.Transparent
        Me.UserFirstName.CustomMaxLength = CType(100, Byte)
        Me.UserFirstName.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.UserFirstName.Location = New System.Drawing.Point(100, 47)
        Me.UserFirstName.Name = "UserFirstName"
        Me.UserFirstName.Size = New System.Drawing.Size(188, 23)
        Me.UserFirstName.TabIndex = 2
        Me.UserFirstName.TextValue = ""
        '
        'FormErrorProvider
        '
        Me.FormErrorProvider.ContainerControl = Me
        '
        'lbAccesslevels
        '
        Appearance1.BackColor = System.Drawing.Color.Black
        Appearance1.BackColor2 = System.Drawing.Color.Aqua
        Appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance1.BackHatchStyle = Infragistics.Win.BackHatchStyle.Vertical
        Appearance1.FontData.BoldAsString = "False"
        Appearance1.FontData.ItalicAsString = "True"
        Appearance1.FontData.Name = "Verdana"
        Appearance1.FontData.SizeInPoints = 12.0!
        Appearance1.ForeColor = System.Drawing.Color.White
        Appearance1.TextHAlignAsString = "Center"
        Appearance1.TextVAlignAsString = "Middle"
        Me.lbAccesslevels.Appearance = Appearance1
        Me.lbAccesslevels.Location = New System.Drawing.Point(15, 276)
        Me.lbAccesslevels.Name = "lbAccesslevels"
        Me.lbAccesslevels.Size = New System.Drawing.Size(525, 23)
        Me.lbAccesslevels.TabIndex = 14
        Me.lbAccesslevels.Text = "Access Levels"
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.TreeAccess)
        Me.UltraGroupBox1.Controls.Add(Me.LableSearch)
        Me.UltraGroupBox1.Controls.Add(Me.TxtSearch)
        Me.UltraGroupBox1.Controls.Add(Me.lbAccesslevels)
        Me.UltraGroupBox1.Controls.Add(Me.UserGroupDetail)
        Me.UltraGroupBox1.Location = New System.Drawing.Point(5, 45)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(574, 585)
        Me.UltraGroupBox1.TabIndex = 15
        Me.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.VisualStudio2005
        '
        'LableSearch
        '
        Me.LableSearch.AutoSize = True
        Me.LableSearch.Location = New System.Drawing.Point(18, 22)
        Me.LableSearch.Name = "LableSearch"
        Me.LableSearch.Size = New System.Drawing.Size(60, 13)
        Me.LableSearch.TabIndex = 15
        Me.LableSearch.Text = "User Name"
        '
        'TxtSearch
        '
        Me.TxtSearch.BackColor = System.Drawing.Color.Transparent
        Me.TxtSearch.CustomMaxLength = CType(100, Byte)
        Me.TxtSearch.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.TxtSearch.Location = New System.Drawing.Point(91, 19)
        Me.TxtSearch.Name = "TxtSearch"
        Me.TxtSearch.Size = New System.Drawing.Size(168, 20)
        Me.TxtSearch.TabIndex = 0
        Me.TxtSearch.TextValue = ""
        '
        'TreeAccess
        '
        Me.TreeAccess.Location = New System.Drawing.Point(14, 305)
        Me.TreeAccess.Name = "TreeAccess"
        Me.TreeAccess.Size = New System.Drawing.Size(526, 262)
        Me.TreeAccess.TabIndex = 15
        '
        'GeneralForms
        '
        Me.GeneralForms.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GeneralForms.Location = New System.Drawing.Point(0, 0)
        Me.GeneralForms.Name = "GeneralForms"
        Me.GeneralForms.ShowHistoryButtom = False
        Me.GeneralForms.ShowNavigate = False
        Me.GeneralForms.ShowPrintButtom = False
        Me.GeneralForms.Size = New System.Drawing.Size(591, 642)
        Me.GeneralForms.TabIndex = 0
        '
        'FrmUsers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(591, 642)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Controls.Add(Me.GeneralForms)
        Me.Name = "FrmUsers"
        Me.Text = "Users"
        CType(Me.UserGroupDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UserGroupDetail.ResumeLayout(False)
        CType(Me.BookingViewer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IsEcsAdmin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IsDocAdmin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IsAccountAdmin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IsSalesAdmin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FormErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        CType(Me.TreeAccess, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GeneralForms As Shipping.UserGeneralForms
    Friend WithEvents TxtSearch As Shipping.UserText
    Friend WithEvents UserGroupDetail As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents EMailOffice As Shipping.UserText
    Friend WithEvents Password As Shipping.UserText
    Friend WithEvents UserCode As Shipping.UserText
    Friend WithEvents UserAccount As Shipping.UserText
    Friend WithEvents UserLastName As Shipping.UserText
    Friend WithEvents UserFirstName As Shipping.UserText
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents LblLogin As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents LblName As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Tel As Shipping.UserText
    Friend WithEvents FormErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents lbAccesslevels As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents TreeAccess As Infragistics.Win.UltraWinTree.UltraTree
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents IsEcsAdmin As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents IsDocAdmin As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents IsAccountAdmin As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents IsSalesAdmin As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents LableSearch As System.Windows.Forms.Label
    Friend WithEvents BookingViewer As Infragistics.Win.UltraWinEditors.UltraCheckEditor
End Class
