<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAgents
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
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.LinesGroupDetail = New Infragistics.Win.Misc.UltraGroupBox
        Me.Address = New System.Windows.Forms.TextBox
        Me.AgentName = New System.Windows.Forms.TextBox
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel
        Me.Code = New Shipping.UserText
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.Fax = New Shipping.UserText
        Me.PortCode = New Shipping.UserPortCode
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel
        Me.LblName = New Infragistics.Win.Misc.UltraLabel
        Me.Tel = New Shipping.UserText
        Me.FormErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Lbl = New System.Windows.Forms.Label
        Me.SearchPort = New Shipping.UserPortCode
        Me.GeneralForms = New Shipping.UserGeneralForms
        Me.UltraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox
        Me.DetentionClause = New Shipping.UserMemo
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.LinesGroupDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LinesGroupDetail.SuspendLayout()
        CType(Me.FormErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.UltraGroupBox2)
        Me.UltraGroupBox1.Controls.Add(Me.LinesGroupDetail)
        Me.UltraGroupBox1.Location = New System.Drawing.Point(12, 77)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(832, 316)
        Me.UltraGroupBox1.TabIndex = 17
        Me.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.VisualStudio2005
        '
        'LinesGroupDetail
        '
        Me.LinesGroupDetail.Controls.Add(Me.Address)
        Me.LinesGroupDetail.Controls.Add(Me.AgentName)
        Me.LinesGroupDetail.Controls.Add(Me.UltraLabel2)
        Me.LinesGroupDetail.Controls.Add(Me.Code)
        Me.LinesGroupDetail.Controls.Add(Me.UltraLabel1)
        Me.LinesGroupDetail.Controls.Add(Me.Fax)
        Me.LinesGroupDetail.Controls.Add(Me.PortCode)
        Me.LinesGroupDetail.Controls.Add(Me.UltraLabel5)
        Me.LinesGroupDetail.Controls.Add(Me.UltraLabel4)
        Me.LinesGroupDetail.Controls.Add(Me.UltraLabel3)
        Me.LinesGroupDetail.Controls.Add(Me.LblName)
        Me.LinesGroupDetail.Controls.Add(Me.Tel)
        Me.LinesGroupDetail.Location = New System.Drawing.Point(15, 16)
        Me.LinesGroupDetail.Name = "LinesGroupDetail"
        Me.LinesGroupDetail.Size = New System.Drawing.Size(474, 274)
        Me.LinesGroupDetail.TabIndex = 0
        Me.LinesGroupDetail.Text = "Line Details"
        '
        'Address
        '
        Me.Address.Location = New System.Drawing.Point(94, 72)
        Me.Address.MaxLength = 500
        Me.Address.Multiline = True
        Me.Address.Name = "Address"
        Me.Address.Size = New System.Drawing.Size(369, 68)
        Me.Address.TabIndex = 1
        '
        'AgentName
        '
        Me.AgentName.Location = New System.Drawing.Point(94, 29)
        Me.AgentName.MaxLength = 500
        Me.AgentName.Multiline = True
        Me.AgentName.Name = "AgentName"
        Me.AgentName.Size = New System.Drawing.Size(369, 37)
        Me.AgentName.TabIndex = 0
        '
        'UltraLabel2
        '
        Me.UltraLabel2.Location = New System.Drawing.Point(23, 229)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(67, 17)
        Me.UltraLabel2.TabIndex = 22
        Me.UltraLabel2.Text = "Code"
        '
        'Code
        '
        Me.Code.AutoComplete = False
        Me.Code.AutoCompleteColumnName = Nothing
        Me.Code.AutoCompleteExtraWhere = Nothing
        Me.Code.AutoCompleteTableName = Nothing
        Me.Code.BackColor = System.Drawing.Color.Transparent
        Me.Code.CustomMaxLength = CType(50, Byte)
        Me.Code.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Code.Location = New System.Drawing.Point(96, 231)
        Me.Code.Name = "Code"
        Me.Code.Size = New System.Drawing.Size(86, 21)
        Me.Code.TabIndex = 5
        Me.Code.TextValue = ""
        '
        'UltraLabel1
        '
        Me.UltraLabel1.Location = New System.Drawing.Point(23, 177)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(67, 18)
        Me.UltraLabel1.TabIndex = 20
        Me.UltraLabel1.Text = "Fax"
        '
        'Fax
        '
        Me.Fax.AutoComplete = False
        Me.Fax.AutoCompleteColumnName = Nothing
        Me.Fax.AutoCompleteExtraWhere = Nothing
        Me.Fax.AutoCompleteTableName = Nothing
        Me.Fax.BackColor = System.Drawing.Color.Transparent
        Me.Fax.CustomMaxLength = CType(50, Byte)
        Me.Fax.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Fax.Location = New System.Drawing.Point(96, 174)
        Me.Fax.Name = "Fax"
        Me.Fax.Size = New System.Drawing.Size(198, 21)
        Me.Fax.TabIndex = 3
        Me.Fax.TextValue = ""
        '
        'PortCode
        '
        Me.PortCode.Location = New System.Drawing.Point(96, 202)
        Me.PortCode.Name = "PortCode"
        Me.PortCode.PortCode = ""
        Me.PortCode.Size = New System.Drawing.Size(314, 23)
        Me.PortCode.TabIndex = 4
        '
        'UltraLabel5
        '
        Me.UltraLabel5.Location = New System.Drawing.Point(23, 206)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.Size = New System.Drawing.Size(67, 17)
        Me.UltraLabel5.TabIndex = 13
        Me.UltraLabel5.Text = "Port"
        '
        'UltraLabel4
        '
        Me.UltraLabel4.Location = New System.Drawing.Point(23, 148)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.Size = New System.Drawing.Size(67, 18)
        Me.UltraLabel4.TabIndex = 12
        Me.UltraLabel4.Text = "Tel"
        '
        'UltraLabel3
        '
        Me.UltraLabel3.Location = New System.Drawing.Point(21, 74)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(67, 20)
        Me.UltraLabel3.TabIndex = 11
        Me.UltraLabel3.Text = "Address"
        '
        'LblName
        '
        Me.LblName.Location = New System.Drawing.Point(23, 32)
        Me.LblName.Name = "LblName"
        Me.LblName.Size = New System.Drawing.Size(67, 19)
        Me.LblName.TabIndex = 8
        Me.LblName.Text = "Name"
        '
        'Tel
        '
        Me.Tel.AutoComplete = False
        Me.Tel.AutoCompleteColumnName = Nothing
        Me.Tel.AutoCompleteExtraWhere = Nothing
        Me.Tel.AutoCompleteTableName = Nothing
        Me.Tel.BackColor = System.Drawing.Color.Transparent
        Me.Tel.CustomMaxLength = CType(50, Byte)
        Me.Tel.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Tel.Location = New System.Drawing.Point(96, 146)
        Me.Tel.Name = "Tel"
        Me.Tel.Size = New System.Drawing.Size(198, 21)
        Me.Tel.TabIndex = 2
        Me.Tel.TextValue = ""
        '
        'FormErrorProvider
        '
        Me.FormErrorProvider.ContainerControl = Me
        '
        'Lbl
        '
        Me.Lbl.AutoSize = True
        Me.Lbl.Location = New System.Drawing.Point(12, 47)
        Me.Lbl.Name = "Lbl"
        Me.Lbl.Size = New System.Drawing.Size(41, 13)
        Me.Lbl.TabIndex = 21
        Me.Lbl.Text = "Search"
        '
        'SearchPort
        '
        Me.SearchPort.Location = New System.Drawing.Point(59, 43)
        Me.SearchPort.Name = "SearchPort"
        Me.SearchPort.PortCode = ""
        Me.SearchPort.Size = New System.Drawing.Size(314, 23)
        Me.SearchPort.TabIndex = 0
        '
        'GeneralForms
        '
        Me.GeneralForms.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GeneralForms.Location = New System.Drawing.Point(0, 0)
        Me.GeneralForms.Name = "GeneralForms"
        Me.GeneralForms.ShowHistoryButtom = False
        Me.GeneralForms.ShowNavigate = False
        Me.GeneralForms.ShowPrintButtom = False
        Me.GeneralForms.Size = New System.Drawing.Size(856, 412)
        Me.GeneralForms.TabIndex = 0
        '
        'UltraGroupBox2
        '
        Me.UltraGroupBox2.Controls.Add(Me.DetentionClause)
        Me.UltraGroupBox2.Location = New System.Drawing.Point(496, 16)
        Me.UltraGroupBox2.Name = "UltraGroupBox2"
        Me.UltraGroupBox2.Size = New System.Drawing.Size(318, 274)
        Me.UltraGroupBox2.TabIndex = 1
        Me.UltraGroupBox2.Text = "Detention Clause"
        '
        'DetentionClause
        '
        Me.DetentionClause.Location = New System.Drawing.Point(6, 19)
        Me.DetentionClause.Name = "DetentionClause"
        Me.DetentionClause.Size = New System.Drawing.Size(306, 249)
        Me.DetentionClause.TabIndex = 7
        Me.DetentionClause.TextValue = ""
        '
        'FrmAgents
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(856, 412)
        Me.Controls.Add(Me.Lbl)
        Me.Controls.Add(Me.SearchPort)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Controls.Add(Me.GeneralForms)
        Me.Name = "FrmAgents"
        Me.Text = "Agents"
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        CType(Me.LinesGroupDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LinesGroupDetail.ResumeLayout(False)
        Me.LinesGroupDetail.PerformLayout()
        CType(Me.FormErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GeneralForms As Shipping.UserGeneralForms
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents LinesGroupDetail As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents LblName As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Tel As Shipping.UserText
    Friend WithEvents PortCode As Shipping.UserPortCode
    Friend WithEvents SearchPort As Shipping.UserPortCode
    Friend WithEvents FormErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Fax As Shipping.UserText
    Friend WithEvents Lbl As System.Windows.Forms.Label
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Code As Shipping.UserText
    Friend WithEvents Address As System.Windows.Forms.TextBox
    Friend WithEvents AgentName As System.Windows.Forms.TextBox
    Friend WithEvents UltraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents DetentionClause As Shipping.UserMemo
End Class
