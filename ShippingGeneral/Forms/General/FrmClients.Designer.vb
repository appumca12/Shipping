<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmClients
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
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("TB_Clients", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID")
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("lName")
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("LAddress")
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FName")
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FAddress")
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("EMail")
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Fax")
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TEL")
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Country")
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Remarks")
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim UltraTab2 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.GridClients = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.FormDataSet = New System.Data.DataSet
        Me.DataTable1 = New System.Data.DataTable
        Me.DataColumn1 = New System.Data.DataColumn
        Me.DataColumn2 = New System.Data.DataColumn
        Me.DataColumn3 = New System.Data.DataColumn
        Me.DataColumn4 = New System.Data.DataColumn
        Me.DataColumn5 = New System.Data.DataColumn
        Me.DataColumn6 = New System.Data.DataColumn
        Me.DataColumn7 = New System.Data.DataColumn
        Me.DataColumn8 = New System.Data.DataColumn
        Me.DataColumn9 = New System.Data.DataColumn
        Me.DataColumn10 = New System.Data.DataColumn
        Me.UltraTabPageControl2 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.GroupBox = New Infragistics.Win.Misc.UltraGroupBox
        Me.UltraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox
        Me.Deposit = New Shipping.UserNum
        Me.GroupMainData = New Infragistics.Win.Misc.UltraGroupBox
        Me.GroupWebData = New Infragistics.Win.Misc.UltraGroupBox
        Me.AccountStatus = New Shipping.UserComboCode
        Me.ClientType = New Shipping.UserComboCode
        Me.lName = New Shipping.UserText
        Me.WebUserId = New Shipping.UserText
        Me.WebUserPass = New Shipping.UserText
        Me.DOB = New Shipping.UserGnrlDate
        Me.Label17 = New System.Windows.Forms.Label
        Me.LAddress = New Shipping.UserText
        Me.AccountB = New Shipping.UserText
        Me.Label16 = New System.Windows.Forms.Label
        Me.AccountC = New Shipping.UserText
        Me.FName = New Shipping.UserTextFarsi
        Me.AccountA = New Shipping.UserText
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.FAddress = New Shipping.UserTextFarsi
        Me.Remarks = New Shipping.UserText
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.EMail = New Shipping.UserText
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.City = New Shipping.UserComboCode
        Me.State = New Shipping.UserComboCode
        Me.Country = New Shipping.UserComboCode
        Me.Fax = New Shipping.UserText
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Tel = New Shipping.UserText
        Me.GroupAdditional = New Infragistics.Win.Misc.UltraGroupBox
        Me.EconomicNo = New Shipping.UserTextFarsi
        Me.Label25 = New System.Windows.Forms.Label
        Me.IsReal = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.IsIndividual = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.POBOX = New Shipping.UserTextFarsi
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.NationalID = New Shipping.UserTextFarsi
        Me.NationalCode = New Shipping.UserTextFarsi
        Me.RegestrationNo = New Shipping.UserTextFarsi
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.GroupBoxSendDocs = New Infragistics.Win.Misc.UltraGroupBox
        Me.SendDocsByEmail = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.SendDocsByFax = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.TabControl = New Infragistics.Win.UltraWinTabControl.UltraTabControl
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox2 = New Infragistics.Win.Misc.UltraGroupBox
        Me.SearchText = New Shipping.UserText
        Me.Clients = New Shipping.UserClients
        Me.FormErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.GeneralForms = New Shipping.UserGeneralForms
        Me.Inactive = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.UltraTabPageControl1.SuspendLayout()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.GridClients, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FormDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl2.SuspendLayout()
        CType(Me.GroupBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox.SuspendLayout()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox2.SuspendLayout()
        CType(Me.GroupMainData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupMainData.SuspendLayout()
        CType(Me.GroupWebData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupWebData.SuspendLayout()
        CType(Me.GroupAdditional, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupAdditional.SuspendLayout()
        CType(Me.IsReal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IsIndividual, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupBoxSendDocs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxSendDocs.SuspendLayout()
        CType(Me.SendDocsByEmail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SendDocsByFax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Inactive, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TabControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl.SuspendLayout()
        CType(Me.GroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.FormErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.UltraGroupBox1)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(856, 402)
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.GridClients)
        Me.UltraGroupBox1.Location = New System.Drawing.Point(13, 15)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(814, 371)
        Me.UltraGroupBox1.TabIndex = 0

        ''
        ''ClientLabel
        ''
        'Me.ClientLabel.Location = New System.Drawing.Point(14, 68)
        'Me.ClientLabel.Name = "ClientLabel"
        'Me.ClientLabel.Size = New System.Drawing.Size(39, 19)
        'Me.ClientLabel.TabIndex = 7
        'Me.ClientLabel.Text = "Clients"
        '
        'Clients
        '
        Me.Clients.ClientID = New System.Guid("00000000-0000-0000-0000-000000000000")
        Me.Clients.CustomShowALL = False
        Me.Clients.Location = New System.Drawing.Point(485, 18)
        Me.Clients.Name = "Clients"
        Me.Clients.Size = New System.Drawing.Size(271, 21)
        Me.Clients.TabIndex = 8
        '
        'GridClients
        '
        Me.GridClients.DataMember = Nothing
        Me.GridClients.DataSource = Me.FormDataSet
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn3.Header.VisiblePosition = 2
        UltraGridColumn4.Header.VisiblePosition = 3
        UltraGridColumn5.Header.VisiblePosition = 4
        UltraGridColumn6.Header.VisiblePosition = 5
        UltraGridColumn7.Header.VisiblePosition = 6
        UltraGridColumn8.Header.VisiblePosition = 7
        UltraGridColumn9.Header.VisiblePosition = 8
        UltraGridColumn10.Header.VisiblePosition = 9
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10})
        Me.GridClients.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.GridClients.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.GridClients.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.GridClients.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.GridClients.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.[False]
        Me.GridClients.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.GridClients.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.GridClients.DisplayLayout.UseFixedHeaders = True
        Me.GridClients.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.GridClients.Location = New System.Drawing.Point(19, 15)
        Me.GridClients.Name = "GridClients"
        Me.GridClients.Size = New System.Drawing.Size(775, 336)
        Me.GridClients.TabIndex = 0
        '
        'FormDataSet
        '
        Me.FormDataSet.DataSetName = "NewDataSet"
        Me.FormDataSet.Tables.AddRange(New System.Data.DataTable() {Me.DataTable1})
        '
        'DataTable1
        '
        Me.DataTable1.Columns.AddRange(New System.Data.DataColumn() {Me.DataColumn1, Me.DataColumn2, Me.DataColumn3, Me.DataColumn4, Me.DataColumn5, Me.DataColumn6, Me.DataColumn7, Me.DataColumn8, Me.DataColumn9, Me.DataColumn10})
        Me.DataTable1.TableName = "TB_Clients"
        '
        'DataColumn1
        '
        Me.DataColumn1.ColumnName = "ID"
        Me.DataColumn1.DataType = GetType(System.Guid)
        '
        'DataColumn2
        '
        Me.DataColumn2.ColumnName = "lName"
        '
        'DataColumn3
        '
        Me.DataColumn3.ColumnName = "LAddress"
        '
        'DataColumn4
        '
        Me.DataColumn4.ColumnName = "FName"
        '
        'DataColumn5
        '
        Me.DataColumn5.ColumnName = "FAddress"
        '
        'DataColumn6
        '
        Me.DataColumn6.ColumnName = "EMail"
        '
        'DataColumn7
        '
        Me.DataColumn7.Caption = "Tel"
        Me.DataColumn7.ColumnName = "Fax"
        '
        'DataColumn8
        '
        Me.DataColumn8.ColumnName = "TEL"
        '
        'DataColumn9
        '
        Me.DataColumn9.ColumnName = "Country"
        '
        'DataColumn10
        '
        Me.DataColumn10.ColumnName = "Remarks"
        '
        'UltraTabPageControl2
        '
        Me.UltraTabPageControl2.Controls.Add(Me.GroupBox)
        Me.UltraTabPageControl2.Location = New System.Drawing.Point(2, 21)
        Me.UltraTabPageControl2.Name = "UltraTabPageControl2"
        Me.UltraTabPageControl2.Size = New System.Drawing.Size(856, 430)
        '
        'GroupBox
        '
        Appearance1.BackColor = System.Drawing.Color.CornflowerBlue
        Appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance1.BorderColor = System.Drawing.Color.White
        Appearance1.BorderColor3DBase = System.Drawing.Color.White
        Me.GroupBox.Appearance = Appearance1
        Me.GroupBox.BackColorInternal = System.Drawing.SystemColors.ControlLightLight
        Me.GroupBox.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.RectangularRaised
        Me.GroupBox.Controls.Add(Me.UltraGroupBox2)
        Me.GroupBox.Controls.Add(Me.GroupMainData)
        Me.GroupBox.Controls.Add(Me.GroupWebData)
        Me.GroupBox.Controls.Add(Me.GroupAdditional)
        Me.GroupBox.Controls.Add(Me.GroupBoxSendDocs)
        Me.GroupBox.Location = New System.Drawing.Point(16, 21)
        Me.GroupBox.Name = "GroupBox"
        Me.GroupBox.Size = New System.Drawing.Size(824, 520)
        Me.GroupBox.TabIndex = 0
        '
        'UltraGroupBox2
        '
        Me.UltraGroupBox2.Controls.Add(Me.Deposit)
        Me.UltraGroupBox2.Location = New System.Drawing.Point(449, 93)
        Me.UltraGroupBox2.Name = "UltraGroupBox2"
        Me.UltraGroupBox2.Size = New System.Drawing.Size(359, 65)
        Me.UltraGroupBox2.TabIndex = 46
        Me.UltraGroupBox2.Text = "Deposit "
        '
        'Deposit
        '
        Me.Deposit.CtrlValue = 0
        Me.Deposit.Location = New System.Drawing.Point(33, 28)
        Me.Deposit.Name = "Deposit"
        Me.Deposit.Size = New System.Drawing.Size(193, 23)
        Me.Deposit.TabIndex = 0
        '
        'GroupMainData
        '
        Me.GroupMainData.Controls.Add(Me.AccountStatus)
        Me.GroupMainData.Controls.Add(Me.ClientType)
        Me.GroupMainData.Controls.Add(Me.lName)
        Me.GroupMainData.Controls.Add(Me.Label17)
        Me.GroupMainData.Controls.Add(Me.LAddress)
        Me.GroupMainData.Controls.Add(Me.AccountB)
        Me.GroupMainData.Controls.Add(Me.Label16)
        Me.GroupMainData.Controls.Add(Me.AccountC)
        Me.GroupMainData.Controls.Add(Me.FName)
        Me.GroupMainData.Controls.Add(Me.AccountA)
        Me.GroupMainData.Controls.Add(Me.Label15)
        Me.GroupMainData.Controls.Add(Me.Label2)
        Me.GroupMainData.Controls.Add(Me.FAddress)
        Me.GroupMainData.Controls.Add(Me.Remarks)
        Me.GroupMainData.Controls.Add(Me.Label14)
        Me.GroupMainData.Controls.Add(Me.Label18)
        Me.GroupMainData.Controls.Add(Me.Label20)
        Me.GroupMainData.Controls.Add(Me.EMail)
        Me.GroupMainData.Controls.Add(Me.Label9)
        Me.GroupMainData.Controls.Add(Me.Label8)
        Me.GroupMainData.Controls.Add(Me.Label7)
        Me.GroupMainData.Controls.Add(Me.Label10)
        Me.GroupMainData.Controls.Add(Me.Label13)
        Me.GroupMainData.Controls.Add(Me.City)
        Me.GroupMainData.Controls.Add(Me.State)
        Me.GroupMainData.Controls.Add(Me.Country)
        Me.GroupMainData.Controls.Add(Me.Fax)
        Me.GroupMainData.Controls.Add(Me.Label11)
        Me.GroupMainData.Controls.Add(Me.Label12)
        Me.GroupMainData.Controls.Add(Me.Tel)
        Me.GroupMainData.Location = New System.Drawing.Point(20, 20)
        Me.GroupMainData.Name = "GroupMainData"
        Me.GroupMainData.Size = New System.Drawing.Size(414, 325)
        Me.GroupMainData.TabIndex = 0
        Me.GroupMainData.Text = "Clinet Main Data"

        'GroupWebData
        Me.GroupWebData.Controls.Add(Me.Label26)
        Me.GroupWebData.Controls.Add(Me.Label27)
        Me.GroupWebData.Controls.Add(Me.Inactive)
        Me.GroupWebData.Controls.Add(Me.WebUserId)
        Me.GroupWebData.Controls.Add(Me.WebUserPass)
        Me.GroupWebData.Location = New System.Drawing.Point(20, 350)
        Me.GroupWebData.Name = "GroupWebData"
        Me.GroupWebData.Size = New System.Drawing.Size(414, 120)
        Me.GroupWebData.TabIndex = 0
        Me.GroupWebData.Text = "Web Details"
        '
        'AccountStatus
        '
        Me.AccountStatus.BackColor = System.Drawing.Color.WhiteSmoke
        Me.AccountStatus.Code = ""
        Me.AccountStatus.CustomShowAll = False
        Me.AccountStatus.Location = New System.Drawing.Point(259, 210)
        Me.AccountStatus.Name = "AccountStatus"
        Me.AccountStatus.Size = New System.Drawing.Size(140, 22)
        Me.AccountStatus.TabIndex = 8
        '
        'ClientType
        '
        Me.ClientType.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientType.Code = ""
        Me.ClientType.CustomShowAll = False
        Me.ClientType.Location = New System.Drawing.Point(259, 264)
        Me.ClientType.Name = "ClientType"
        Me.ClientType.Size = New System.Drawing.Size(140, 22)
        Me.ClientType.TabIndex = 8
        '
        'lName
        '
        Me.lName.AutoComplete = False
        Me.lName.AutoCompleteColumnName = Nothing
        Me.lName.AutoCompleteExtraWhere = Nothing
        Me.lName.AutoCompleteTableName = Nothing
        Me.lName.BackColor = System.Drawing.Color.Transparent
        Me.lName.CustomMaxLength = CType(100, Byte)
        Me.lName.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.lName.Location = New System.Drawing.Point(83, 19)
        Me.lName.Name = "lName"
        Me.lName.Size = New System.Drawing.Size(316, 22)
        Me.lName.TabIndex = 0
        Me.lName.TextValue = ""
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(19, 22)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(35, 13)
        Me.Label17.TabIndex = 11
        Me.Label17.Text = "Name"
        '
        'LAddress
        '
        Me.LAddress.AutoComplete = False
        Me.LAddress.AutoCompleteColumnName = Nothing
        Me.LAddress.AutoCompleteExtraWhere = Nothing
        Me.LAddress.AutoCompleteTableName = Nothing
        Me.LAddress.BackColor = System.Drawing.Color.Transparent
        Me.LAddress.CustomMaxLength = CType(100, Byte)
        Me.LAddress.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.LAddress.Location = New System.Drawing.Point(83, 47)
        Me.LAddress.Name = "LAddress"
        Me.LAddress.Size = New System.Drawing.Size(316, 22)
        Me.LAddress.TabIndex = 1
        Me.LAddress.TextValue = ""
        '
        'AccountB
        '
        Me.AccountB.AutoComplete = False
        Me.AccountB.AutoCompleteColumnName = Nothing
        Me.AccountB.AutoCompleteExtraWhere = Nothing
        Me.AccountB.AutoCompleteTableName = Nothing
        Me.AccountB.BackColor = System.Drawing.Color.Transparent
        Me.AccountB.CustomMaxLength = CType(100, Byte)
        Me.AccountB.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.AccountB.Location = New System.Drawing.Point(196, 289)
        Me.AccountB.Name = "AccountB"
        Me.AccountB.Size = New System.Drawing.Size(89, 22)
        Me.AccountB.TabIndex = 10
        Me.AccountB.TextValue = ""
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(19, 50)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(45, 13)
        Me.Label16.TabIndex = 13
        Me.Label16.Text = "Address"
        '
        'AccountC
        '
        Me.AccountC.AutoComplete = False
        Me.AccountC.AutoCompleteColumnName = Nothing
        Me.AccountC.AutoCompleteExtraWhere = Nothing
        Me.AccountC.AutoCompleteTableName = Nothing
        Me.AccountC.BackColor = System.Drawing.Color.Transparent
        Me.AccountC.CustomMaxLength = CType(100, Byte)
        Me.AccountC.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.AccountC.Location = New System.Drawing.Point(310, 289)
        Me.AccountC.Name = "AccountC"
        Me.AccountC.Size = New System.Drawing.Size(89, 22)
        Me.AccountC.TabIndex = 11
        Me.AccountC.TextValue = ""
        '
        'FName
        '
        Me.FName.IsMultiline = False
        Me.FName.Location = New System.Drawing.Point(82, 75)
        Me.FName.Name = "FName"
        Me.FName.Size = New System.Drawing.Size(317, 20)
        Me.FName.TabIndex = 2
        Me.FName.TextValue = ""
        '
        'AccountA
        '
        Me.AccountA.AutoComplete = False
        Me.AccountA.AutoCompleteColumnName = Nothing
        Me.AccountA.AutoCompleteExtraWhere = Nothing
        Me.AccountA.AutoCompleteTableName = Nothing
        Me.AccountA.BackColor = System.Drawing.Color.Transparent
        Me.AccountA.CustomMaxLength = CType(100, Byte)
        Me.AccountA.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.AccountA.Location = New System.Drawing.Point(82, 289)
        Me.AccountA.Name = "AccountA"
        Me.AccountA.Size = New System.Drawing.Size(89, 22)
        Me.AccountA.TabIndex = 9
        Me.AccountA.TextValue = ""
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(19, 79)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(44, 13)
        Me.Label15.TabIndex = 15
        Me.Label15.Text = "F.Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 293)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "Accounts"
        '
        'FAddress
        '
        Me.FAddress.IsMultiline = False
        Me.FAddress.Location = New System.Drawing.Point(82, 101)
        Me.FAddress.Name = "FAddress"
        Me.FAddress.Size = New System.Drawing.Size(317, 20)
        Me.FAddress.TabIndex = 3
        Me.FAddress.TextValue = ""
        '
        'Remarks
        '
        Me.Remarks.AutoComplete = False
        Me.Remarks.AutoCompleteColumnName = Nothing
        Me.Remarks.AutoCompleteExtraWhere = Nothing
        Me.Remarks.AutoCompleteTableName = Nothing
        Me.Remarks.BackColor = System.Drawing.Color.Transparent
        Me.Remarks.CustomMaxLength = CType(100, Byte)
        Me.Remarks.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Remarks.Location = New System.Drawing.Point(83, 263)
        Me.Remarks.Name = "Remarks"
        Me.Remarks.Size = New System.Drawing.Size(132, 22)
        Me.Remarks.TabIndex = 11
        Me.Remarks.TextValue = ""
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(19, 105)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(54, 13)
        Me.Label14.TabIndex = 17
        Me.Label14.Text = "F.Address"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(19, 264)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(49, 13)
        Me.Label18.TabIndex = 27
        Me.Label18.Text = "Remarks"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(220, 264)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(49, 13)
        Me.Label20.TabIndex = 27
        Me.Label20.Text = "Type"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(13, 25)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(24, 13)
        Me.Label26.TabIndex = 25
        Me.Label26.Text = "UserId"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(200, 25)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(24, 13)
        Me.Label27.TabIndex = 25
        Me.Label27.Text = "Password"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(15, 241)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(24, 13)
        Me.Label28.TabIndex = 25
        Me.Label28.Text = "Inactive"
        '
        'Inactive
        '
        Appearance10.FontData.Name = "B Nazanin"
        Me.Inactive.Appearance = Appearance10
        Appearance11.FontData.Name = "B Elham"
        Me.Inactive.CheckedAppearance = Appearance11
        Me.Inactive.Location = New System.Drawing.Point(15, 50)
        Me.Inactive.Name = "Inactive"
        Me.Inactive.Size = New System.Drawing.Size(100, 20)
        Me.Inactive.TabIndex = 0
        Me.Inactive.Text = "InActive"
        '
        'WebUserId
        '

        Me.WebUserId.BackColor = System.Drawing.Color.Transparent
        Me.WebUserId.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.WebUserId.Location = New System.Drawing.Point(55, 25)
        Me.WebUserId.Name = "WebUserId"
        Me.WebUserId.Size = New System.Drawing.Size(145, 22)
        Me.WebUserId.TabIndex = 30
        Me.WebUserId.TextValue = ""
        '
        'WebUserPass
        '

        Me.WebUserPass.BackColor = System.Drawing.Color.Transparent
        Me.WebUserPass.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.WebUserPass.Location = New System.Drawing.Point(255, 25)
        Me.WebUserPass.Name = "WebUserPass"
        Me.WebUserPass.Size = New System.Drawing.Size(145, 22)
        Me.WebUserPass.TabIndex = 30
        Me.WebUserPass.TextValue = ""
        '
        'EMail
        '
        Me.EMail.AutoComplete = False
        Me.EMail.AutoCompleteColumnName = Nothing
        Me.EMail.AutoCompleteExtraWhere = Nothing
        Me.EMail.AutoCompleteTableName = Nothing
        Me.EMail.BackColor = System.Drawing.Color.Transparent
        Me.EMail.CustomMaxLength = CType(100, Byte)
        Me.EMail.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.EMail.Location = New System.Drawing.Point(83, 127)
        Me.EMail.Name = "EMail"
        Me.EMail.Size = New System.Drawing.Size(220, 22)
        Me.EMail.TabIndex = 4
        Me.EMail.TextValue = ""
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(220, 218)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(37, 13)
        Me.Label9.TabIndex = 25
        Me.Label9.Text = "Status"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(220, 241)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(24, 13)
        Me.Label8.TabIndex = 25
        Me.Label8.Text = "City"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(20, 241)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(32, 13)
        Me.Label7.TabIndex = 25
        Me.Label7.Text = "State"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(19, 213)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(43, 13)
        Me.Label10.TabIndex = 25
        Me.Label10.Text = "Country"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(19, 131)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(33, 13)
        Me.Label13.TabIndex = 19
        Me.Label13.Text = "EMail"
        '
        'City
        '
        Me.City.BackColor = System.Drawing.Color.WhiteSmoke
        Me.City.Code = ""
        Me.City.CustomShowAll = False
        Me.City.Location = New System.Drawing.Point(259, 236)
        Me.City.Name = "City"
        Me.City.Size = New System.Drawing.Size(140, 22)
        Me.City.TabIndex = 10
        '
        'State
        '
        Me.State.BackColor = System.Drawing.Color.WhiteSmoke
        Me.State.Code = ""
        Me.State.CustomShowAll = False
        Me.State.Location = New System.Drawing.Point(82, 236)
        Me.State.Name = "State"
        Me.State.Size = New System.Drawing.Size(132, 22)
        Me.State.TabIndex = 9
        '
        'Country
        '
        Me.Country.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Country.Code = ""
        Me.Country.CustomShowAll = False
        Me.Country.Location = New System.Drawing.Point(82, 209)
        Me.Country.Name = "Country"
        Me.Country.Size = New System.Drawing.Size(132, 22)
        Me.Country.TabIndex = 7
        '
        'Fax
        '
        Me.Fax.AutoComplete = False
        Me.Fax.AutoCompleteColumnName = Nothing
        Me.Fax.AutoCompleteExtraWhere = Nothing
        Me.Fax.AutoCompleteTableName = Nothing
        Me.Fax.BackColor = System.Drawing.Color.Transparent
        Me.Fax.CustomMaxLength = CType(100, Byte)
        Me.Fax.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Fax.Location = New System.Drawing.Point(82, 183)
        Me.Fax.Name = "Fax"
        Me.Fax.Size = New System.Drawing.Size(220, 22)
        Me.Fax.TabIndex = 6
        Me.Fax.TextValue = ""
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(18, 155)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(22, 13)
        Me.Label11.TabIndex = 23
        Me.Label11.Text = "Tel"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(18, 183)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(24, 13)
        Me.Label12.TabIndex = 21
        Me.Label12.Text = "Fax"
        '
        'Tel
        '
        Me.Tel.AutoComplete = False
        Me.Tel.AutoCompleteColumnName = Nothing
        Me.Tel.AutoCompleteExtraWhere = Nothing
        Me.Tel.AutoCompleteTableName = Nothing
        Me.Tel.BackColor = System.Drawing.Color.Transparent
        Me.Tel.CustomMaxLength = CType(100, Byte)
        Me.Tel.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Tel.Location = New System.Drawing.Point(82, 155)
        Me.Tel.Name = "Tel"
        Me.Tel.Size = New System.Drawing.Size(220, 22)
        Me.Tel.TabIndex = 5
        Me.Tel.TextValue = ""
        '
        'GroupAdditional
        '
        Me.GroupAdditional.Controls.Add(Me.EconomicNo)
        Me.GroupAdditional.Controls.Add(Me.Label25)
        Me.GroupAdditional.Controls.Add(Me.IsReal)
        Me.GroupAdditional.Controls.Add(Me.IsIndividual)
        Me.GroupAdditional.Controls.Add(Me.POBOX)
        Me.GroupAdditional.Controls.Add(Me.Label6)
        Me.GroupAdditional.Controls.Add(Me.Label5)
        Me.GroupAdditional.Controls.Add(Me.Label4)
        Me.GroupAdditional.Controls.Add(Me.NationalID)
        Me.GroupAdditional.Controls.Add(Me.NationalCode)
        Me.GroupAdditional.Controls.Add(Me.RegestrationNo)
        Me.GroupAdditional.Controls.Add(Me.Label3)
        Me.GroupAdditional.Controls.Add(Me.DOB)
        Me.GroupAdditional.Controls.Add(Me.Label29)
        Me.GroupAdditional.Location = New System.Drawing.Point(449, 166)
        Me.GroupAdditional.Name = "GroupAdditional"
        Me.GroupAdditional.Size = New System.Drawing.Size(359, 200)
        Me.GroupAdditional.TabIndex = 45
        Me.GroupAdditional.Text = "Official Invoice Additional Data"
        '
        'EconomicNo
        '
        Me.EconomicNo.IsMultiline = False
        Me.EconomicNo.Location = New System.Drawing.Point(71, 42)
        Me.EconomicNo.Name = "EconomicNo"
        Me.EconomicNo.Size = New System.Drawing.Size(155, 20)
        Me.EconomicNo.TabIndex = 0
        Me.EconomicNo.TextValue = ""
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(264, 45)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(63, 13)
        Me.Label25.TabIndex = 11
        Me.Label25.Text = "کد اقتصادی"
        '
        'IsReal
        '
        Appearance3.FontData.Name = "B Nazanin"
        Me.IsReal.Appearance = Appearance3
        Appearance8.FontData.Name = "B Elham"
        Me.IsReal.CheckedAppearance = Appearance8
        Me.IsReal.Location = New System.Drawing.Point(235, 17)
        Me.IsReal.Name = "IsReal"
        Me.IsReal.Size = New System.Drawing.Size(100, 20)
        Me.IsReal.TabIndex = 0
        Me.IsReal.Text = "شخص حقیقی است"
        '
        'IsIndividual
        '

        Me.IsIndividual.Appearance = Appearance3

        Me.IsIndividual.CheckedAppearance = Appearance8
        Me.IsIndividual.Location = New System.Drawing.Point(135, 17)
        Me.IsIndividual.Name = "IsIndividual"
        Me.IsIndividual.Size = New System.Drawing.Size(100, 20)
        Me.IsIndividual.TabIndex = 0
        Me.IsIndividual.Text = "Is Individual"
        Me.IsIndividual.Visible = False
        '
        'POBOX
        '
        Me.POBOX.IsMultiline = False
        Me.POBOX.Location = New System.Drawing.Point(71, 68)
        Me.POBOX.Name = "POBOX"
        Me.POBOX.Size = New System.Drawing.Size(156, 20)
        Me.POBOX.TabIndex = 1
        Me.POBOX.TextValue = ""
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label6.Location = New System.Drawing.Point(269, 142)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 13)
        Me.Label6.TabIndex = 42
        Me.Label6.Text = "شناسه ملی"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label5.Location = New System.Drawing.Point(283, 117)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 13)
        Me.Label5.TabIndex = 42
        Me.Label5.Text = "کد ملی"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label4.Location = New System.Drawing.Point(271, 92)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 42
        Me.Label4.Text = "شماره ثبت"
        '
        'NationalID
        '
        Me.NationalID.IsMultiline = False
        Me.NationalID.Location = New System.Drawing.Point(72, 142)
        Me.NationalID.Name = "NationalID"
        Me.NationalID.Size = New System.Drawing.Size(156, 19)
        Me.NationalID.TabIndex = 4
        Me.NationalID.TextValue = ""
        '
        'NationalCode
        '
        Me.NationalCode.IsMultiline = False
        Me.NationalCode.Location = New System.Drawing.Point(72, 117)
        Me.NationalCode.Name = "NationalCode"
        Me.NationalCode.Size = New System.Drawing.Size(156, 19)
        Me.NationalCode.TabIndex = 3
        Me.NationalCode.TextValue = ""
        '
        'RegestrationNo
        '
        Me.RegestrationNo.IsMultiline = False
        Me.RegestrationNo.Location = New System.Drawing.Point(71, 92)
        Me.RegestrationNo.Name = "RegestrationNo"
        Me.RegestrationNo.Size = New System.Drawing.Size(156, 19)
        Me.RegestrationNo.TabIndex = 2
        Me.RegestrationNo.TextValue = ""
        '
        'DOB
        '
        Me.DOB.DateValue = Nothing
        Me.DOB.Location = New System.Drawing.Point(72, 170)
        Me.DOB.Name = "DOB"
        Me.DOB.ShowTime = False
        Me.DOB.Size = New System.Drawing.Size(156, 22)
        Me.DOB.TabIndex = 1
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label29.Location = New System.Drawing.Point(258, 170)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(69, 13)
        Me.Label29.TabIndex = 41
        Me.Label29.Text = "تاریخ تولد"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label3.Location = New System.Drawing.Point(258, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 13)
        Me.Label3.TabIndex = 41
        Me.Label3.Text = "صندوق پستی"
        '
        'GroupBoxSendDocs
        '
        Me.GroupBoxSendDocs.Controls.Add(Me.SendDocsByEmail)
        Me.GroupBoxSendDocs.Controls.Add(Me.SendDocsByFax)
        Me.GroupBoxSendDocs.Location = New System.Drawing.Point(449, 21)
        Me.GroupBoxSendDocs.Name = "GroupBoxSendDocs"
        Me.GroupBoxSendDocs.Size = New System.Drawing.Size(359, 68)
        Me.GroupBoxSendDocs.TabIndex = 44
        Me.GroupBoxSendDocs.Text = "Send Documents  "
        '
        'SendDocsByEmail
        '
        Appearance2.FontData.Name = "B Nazanin"
        Me.SendDocsByEmail.Appearance = Appearance2
        Appearance9.FontData.Name = "B Elham"
        Me.SendDocsByEmail.CheckedAppearance = Appearance9
        Me.SendDocsByEmail.Location = New System.Drawing.Point(185, 30)
        Me.SendDocsByEmail.Name = "SendDocsByEmail"
        Me.SendDocsByEmail.Size = New System.Drawing.Size(101, 20)
        Me.SendDocsByEmail.TabIndex = 1
        Me.SendDocsByEmail.Text = "By Email"
        '
        'SendDocsByFax
        '
        Appearance10.FontData.Name = "B Nazanin"
        Me.SendDocsByFax.Appearance = Appearance10
        Appearance11.FontData.Name = "B Elham"
        Me.SendDocsByFax.CheckedAppearance = Appearance11
        Me.SendDocsByFax.Location = New System.Drawing.Point(79, 30)
        Me.SendDocsByFax.Name = "SendDocsByFax"
        Me.SendDocsByFax.Size = New System.Drawing.Size(56, 20)
        Me.SendDocsByFax.TabIndex = 0
        Me.SendDocsByFax.Text = "By Fax"
        '
        'TabControl
        '
        Me.TabControl.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.TabControl.Controls.Add(Me.UltraTabPageControl1)
        Me.TabControl.Controls.Add(Me.UltraTabPageControl2)
        Me.TabControl.Location = New System.Drawing.Point(13, 47)
        Me.TabControl.Name = "TabControl"
        Me.TabControl.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.TabControl.Size = New System.Drawing.Size(860, 600)
        Me.TabControl.TabIndex = 0
        UltraTab1.TabPage = Me.UltraTabPageControl1
        UltraTab1.Text = "Clients List"
        UltraTab2.TabPage = Me.UltraTabPageControl2
        UltraTab2.Text = "Client Details"
        Me.TabControl.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab1, UltraTab2})
        Me.TabControl.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.VisualStudio2005
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(856, 402)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Search"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.SearchText)
        Me.GroupBox2.Controls.Add(Me.Clients)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.TabControl)
        Me.GroupBox2.Location = New System.Drawing.Point(24, 50)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(901, 600)
        Me.GroupBox2.TabIndex = 17
        Me.GroupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.VisualStudio2005
        '
        'SearchText
        '
        Me.SearchText.AutoComplete = False
        Me.SearchText.AutoCompleteColumnName = Nothing
        Me.SearchText.AutoCompleteExtraWhere = Nothing
        Me.SearchText.AutoCompleteTableName = Nothing
        Me.SearchText.BackColor = System.Drawing.Color.Transparent
        Me.SearchText.CustomMaxLength = CType(100, Byte)
        Me.SearchText.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.SearchText.Location = New System.Drawing.Point(72, 19)
        Me.SearchText.Name = "SearchText"
        Me.SearchText.Size = New System.Drawing.Size(403, 22)
        Me.SearchText.TabIndex = 15
        Me.SearchText.TextValue = ""
        '
        'FormErrorProvider
        '
        Me.FormErrorProvider.ContainerControl = Me
        '
        'GeneralForms
        '
        Me.GeneralForms.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GeneralForms.Location = New System.Drawing.Point(0, 0)
        Me.GeneralForms.Name = "GeneralForms"
        Me.GeneralForms.ShowHistoryButtom = False
        Me.GeneralForms.ShowNavigate = False
        Me.GeneralForms.ShowPrintButtom = False
        Me.GeneralForms.Size = New System.Drawing.Size(926, 547)
        Me.GeneralForms.TabIndex = 0
        '
        'FrmClients
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(926, 547)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GeneralForms)
        Me.Name = "FrmClients"
        Me.Text = "Clients"
        Me.UltraTabPageControl1.ResumeLayout(False)
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        CType(Me.GridClients, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FormDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl2.ResumeLayout(False)
        CType(Me.GroupBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox.ResumeLayout(False)
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox2.ResumeLayout(False)
        CType(Me.GroupMainData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupMainData.ResumeLayout(False)
        Me.GroupMainData.PerformLayout()
        CType(Me.GroupAdditional, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupAdditional.ResumeLayout(False)
        Me.GroupAdditional.PerformLayout()
        CType(Me.IsReal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupBoxSendDocs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxSendDocs.ResumeLayout(False)
        CType(Me.SendDocsByEmail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SendDocsByFax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TabControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl.ResumeLayout(False)
        CType(Me.GroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.FormErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GeneralForms As Shipping.UserGeneralForms
    Friend WithEvents GroupBox As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents lName As Shipping.UserText
    Friend WithEvents Remarks As Shipping.UserText
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Country As Shipping.UserComboCode
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Tel As Shipping.UserText
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Fax As Shipping.UserText
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents EMail As Shipping.UserText
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents FAddress As Shipping.UserTextFarsi
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents FName As Shipping.UserTextFarsi
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents LAddress As Shipping.UserText
    Friend WithEvents TabControl As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraTabPageControl2 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents GridClients As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents FormDataSet As System.Data.DataSet
    Friend WithEvents DataTable1 As System.Data.DataTable
    Friend WithEvents DataColumn1 As System.Data.DataColumn
    Friend WithEvents DataColumn2 As System.Data.DataColumn
    Friend WithEvents DataColumn3 As System.Data.DataColumn
    Friend WithEvents DataColumn4 As System.Data.DataColumn
    Friend WithEvents DataColumn5 As System.Data.DataColumn
    Friend WithEvents DataColumn6 As System.Data.DataColumn
    Friend WithEvents DataColumn7 As System.Data.DataColumn
    Friend WithEvents DataColumn8 As System.Data.DataColumn
    Friend WithEvents DataColumn9 As System.Data.DataColumn
    Friend WithEvents DataColumn10 As System.Data.DataColumn
    Friend WithEvents SearchText As Shipping.UserText
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents AccountB As Shipping.UserText
    Friend WithEvents AccountC As Shipping.UserText
    Friend WithEvents AccountA As Shipping.UserText
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents FormErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents RegestrationNo As Shipping.UserTextFarsi
    Friend WithEvents EconomicNo As Shipping.UserTextFarsi
    Friend WithEvents POBOX As Shipping.UserTextFarsi
    Friend WithEvents IsReal As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents IsIndividual As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents GroupAdditional As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents GroupBoxSendDocs As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents SendDocsByEmail As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents SendDocsByFax As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents GroupMainData As Infragistics.Win.Misc.UltraGroupBox

    Friend WithEvents GroupWebData As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
   
    Friend WithEvents City As Shipping.UserComboCode
    Friend WithEvents State As Shipping.UserComboCode
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents NationalID As Shipping.UserTextFarsi
    Friend WithEvents NationalCode As Shipping.UserTextFarsi
    Friend WithEvents AccountStatus As Shipping.UserComboCode
    Friend WithEvents ClientType As Shipping.UserComboCode
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents UltraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents Deposit As Shipping.UserNum
    Friend WithEvents Clients As Shipping.UserClients
    Friend WithEvents WebUserId As Shipping.UserText
    Friend WithEvents WebUserPass As Shipping.UserText
    Friend WithEvents Inactive As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents DOB As Shipping.UserGnrlDate
End Class
