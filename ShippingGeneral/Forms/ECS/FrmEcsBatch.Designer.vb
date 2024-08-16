<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEcsBatch
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.MenuItem = New Shipping.UserMenuItem
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.GroupBoxMain = New Infragistics.Win.Misc.UltraGroupBox
        Me.CheckPermitNo = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.CheckDjwaz = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.CheckDestination = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.CheckReturnTo = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.CheckReturnBy = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.CheckBooking = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.CheckMaster = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.Remarks = New Shipping.UserText
        Me.StatusDateToLine = New Shipping.UserGnrlDate
        Me.Depot = New Shipping.UserComboCode
        Me.StatusDate = New Shipping.UserGnrlDate
        Me.CheckDetail = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.UltraLabel25 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel15 = New Infragistics.Win.Misc.UltraLabel
        Me.ExportPermit = New Shipping.UserText
        Me.InDjwazNo = New Shipping.UserText
        Me.UltraLabel24 = New Infragistics.Win.Misc.UltraLabel
        Me.BookingID = New Shipping.UserBookingNo
        Me.UltraLabel11 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel10 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel8 = New Infragistics.Win.Misc.UltraLabel
        Me.Destination = New Shipping.UserPortCode
        Me.ReturnTo = New Shipping.UserPortCode
        Me.OutVoyage = New Shipping.UserComboVoyage
        Me.OutVessel = New Shipping.UserComboVessel
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.GridResult = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.UltraGroupBox3 = New Infragistics.Win.Misc.UltraGroupBox
        Me.UltraLabel6 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel
        Me.ToStatus = New Shipping.UserComboCode
        Me.FromStatus = New Shipping.UserComboCode
        Me.FormErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.GroupBoxMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxMain.SuspendLayout()
        CType(Me.CheckPermitNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckDjwaz, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckDestination, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckReturnTo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckReturnBy, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckBooking, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckMaster, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.GridResult, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox3.SuspendLayout()
        CType(Me.FormErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 951.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.MenuItem, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.UltraGroupBox3, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 364.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(988, 491)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'MenuItem
        '
        Me.MenuItem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MenuItem.Location = New System.Drawing.Point(3, 3)
        Me.MenuItem.Name = "MenuItem"
        Me.MenuItem.ShowAdditional = False
        Me.MenuItem.ShowCancel = False
        Me.MenuItem.ShowConfirm = False
        Me.MenuItem.ShowDelete = False
        Me.MenuItem.ShowDeposits = False
        Me.MenuItem.ShowDeSelectAll = True
        Me.MenuItem.ShowEdit = False
        Me.MenuItem.ShowExcel = False
        Me.MenuItem.ShowFileOpen = True
        Me.MenuItem.ShowNew = False
        Me.MenuItem.ShowPickup = True
        Me.MenuItem.ShowPrint = False
        Me.MenuItem.ShowProcess = False
        Me.MenuItem.ShowRecivedItems = False
        Me.MenuItem.ShowRefresh = False
        Me.MenuItem.ShowRest = False
        Me.MenuItem.ShowSave = True
        Me.MenuItem.ShowSelectAll = True
        Me.MenuItem.Size = New System.Drawing.Size(982, 31)
        Me.MenuItem.TabIndex = 0
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.GroupBoxMain, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.UltraGroupBox1, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 90)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(982, 398)
        Me.TableLayoutPanel2.TabIndex = 1
        '
        'GroupBoxMain
        '
        Me.GroupBoxMain.Controls.Add(Me.CheckPermitNo)
        Me.GroupBoxMain.Controls.Add(Me.CheckDjwaz)
        Me.GroupBoxMain.Controls.Add(Me.CheckDestination)
        Me.GroupBoxMain.Controls.Add(Me.CheckReturnTo)
        Me.GroupBoxMain.Controls.Add(Me.CheckReturnBy)
        Me.GroupBoxMain.Controls.Add(Me.CheckBooking)
        Me.GroupBoxMain.Controls.Add(Me.CheckMaster)
        Me.GroupBoxMain.Controls.Add(Me.UltraLabel4)
        Me.GroupBoxMain.Controls.Add(Me.UltraLabel3)
        Me.GroupBoxMain.Controls.Add(Me.UltraLabel2)
        Me.GroupBoxMain.Controls.Add(Me.UltraLabel1)
        Me.GroupBoxMain.Controls.Add(Me.Remarks)
        Me.GroupBoxMain.Controls.Add(Me.StatusDateToLine)
        Me.GroupBoxMain.Controls.Add(Me.Depot)
        Me.GroupBoxMain.Controls.Add(Me.StatusDate)
        Me.GroupBoxMain.Controls.Add(Me.CheckDetail)
        Me.GroupBoxMain.Controls.Add(Me.UltraLabel25)
        Me.GroupBoxMain.Controls.Add(Me.UltraLabel15)
        Me.GroupBoxMain.Controls.Add(Me.ExportPermit)
        Me.GroupBoxMain.Controls.Add(Me.InDjwazNo)
        Me.GroupBoxMain.Controls.Add(Me.UltraLabel24)
        Me.GroupBoxMain.Controls.Add(Me.BookingID)
        Me.GroupBoxMain.Controls.Add(Me.UltraLabel11)
        Me.GroupBoxMain.Controls.Add(Me.UltraLabel10)
        Me.GroupBoxMain.Controls.Add(Me.UltraLabel8)
        Me.GroupBoxMain.Controls.Add(Me.Destination)
        Me.GroupBoxMain.Controls.Add(Me.ReturnTo)
        Me.GroupBoxMain.Controls.Add(Me.OutVoyage)
        Me.GroupBoxMain.Controls.Add(Me.OutVessel)
        Me.GroupBoxMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBoxMain.Location = New System.Drawing.Point(592, 3)
        Me.GroupBoxMain.Name = "GroupBoxMain"
        Me.GroupBoxMain.Size = New System.Drawing.Size(387, 392)
        Me.GroupBoxMain.TabIndex = 31
        Me.GroupBoxMain.Text = "E.C.S. Container Details"
        '
        'CheckPermitNo
        '
        Me.CheckPermitNo.Location = New System.Drawing.Point(11, 188)
        Me.CheckPermitNo.Name = "CheckPermitNo"
        Me.CheckPermitNo.Size = New System.Drawing.Size(17, 20)
        Me.CheckPermitNo.TabIndex = 77
        '
        'CheckDjwaz
        '
        Me.CheckDjwaz.Location = New System.Drawing.Point(11, 161)
        Me.CheckDjwaz.Name = "CheckDjwaz"
        Me.CheckDjwaz.Size = New System.Drawing.Size(17, 20)
        Me.CheckDjwaz.TabIndex = 76
        '
        'CheckDestination
        '
        Me.CheckDestination.Location = New System.Drawing.Point(11, 134)
        Me.CheckDestination.Name = "CheckDestination"
        Me.CheckDestination.Size = New System.Drawing.Size(17, 20)
        Me.CheckDestination.TabIndex = 75
        '
        'CheckReturnTo
        '
        Me.CheckReturnTo.Location = New System.Drawing.Point(11, 107)
        Me.CheckReturnTo.Name = "CheckReturnTo"
        Me.CheckReturnTo.Size = New System.Drawing.Size(17, 20)
        Me.CheckReturnTo.TabIndex = 74
        '
        'CheckReturnBy
        '
        Me.CheckReturnBy.Location = New System.Drawing.Point(11, 80)
        Me.CheckReturnBy.Name = "CheckReturnBy"
        Me.CheckReturnBy.Size = New System.Drawing.Size(17, 20)
        Me.CheckReturnBy.TabIndex = 73
        '
        'CheckBooking
        '
        Me.CheckBooking.Location = New System.Drawing.Point(11, 53)
        Me.CheckBooking.Name = "CheckBooking"
        Me.CheckBooking.Size = New System.Drawing.Size(17, 20)
        Me.CheckBooking.TabIndex = 72
        '
        'CheckMaster
        '
        Me.CheckMaster.Location = New System.Drawing.Point(11, 26)
        Me.CheckMaster.Name = "CheckMaster"
        Me.CheckMaster.Size = New System.Drawing.Size(120, 20)
        Me.CheckMaster.TabIndex = 0
        Me.CheckMaster.Text = "Apply To Master"
        '
        'UltraLabel4
        '
        Me.UltraLabel4.Location = New System.Drawing.Point(12, 327)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.Size = New System.Drawing.Size(49, 21)
        Me.UltraLabel4.TabIndex = 71
        Me.UltraLabel4.Text = "Remarks"
        '
        'UltraLabel3
        '
        Me.UltraLabel3.Location = New System.Drawing.Point(12, 300)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(49, 21)
        Me.UltraLabel3.TabIndex = 70
        Me.UltraLabel3.Text = "Depot"
        '
        'UltraLabel2
        '
        Me.UltraLabel2.Location = New System.Drawing.Point(12, 273)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(49, 21)
        Me.UltraLabel2.TabIndex = 69
        Me.UltraLabel2.Text = "To Line"
        '
        'UltraLabel1
        '
        Me.UltraLabel1.Location = New System.Drawing.Point(12, 246)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(49, 21)
        Me.UltraLabel1.TabIndex = 68
        Me.UltraLabel1.Text = "Date"
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
        Me.Remarks.Location = New System.Drawing.Point(76, 324)
        Me.Remarks.Name = "Remarks"
        Me.Remarks.Size = New System.Drawing.Size(267, 21)
        Me.Remarks.TabIndex = 11
        Me.Remarks.TextValue = ""
        '
        'StatusDateToLine
        '
        Me.StatusDateToLine.DateValue = Nothing
        Me.StatusDateToLine.Location = New System.Drawing.Point(76, 273)
        Me.StatusDateToLine.Name = "StatusDateToLine"
        Me.StatusDateToLine.ShowTime = False
        Me.StatusDateToLine.Size = New System.Drawing.Size(164, 21)
        Me.StatusDateToLine.TabIndex = 9
        '
        'Depot
        '
        Me.Depot.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Depot.Code = ""
        Me.Depot.CustomShowAll = False
        Me.Depot.Location = New System.Drawing.Point(76, 298)
        Me.Depot.Name = "Depot"
        Me.Depot.Size = New System.Drawing.Size(164, 21)
        Me.Depot.TabIndex = 10
        '
        'StatusDate
        '
        Me.StatusDate.DateValue = Nothing
        Me.StatusDate.Location = New System.Drawing.Point(76, 246)
        Me.StatusDate.Name = "StatusDate"
        Me.StatusDate.ShowTime = False
        Me.StatusDate.Size = New System.Drawing.Size(164, 21)
        Me.StatusDate.TabIndex = 8
        '
        'CheckDetail
        '
        Me.CheckDetail.Location = New System.Drawing.Point(11, 219)
        Me.CheckDetail.Name = "CheckDetail"
        Me.CheckDetail.Size = New System.Drawing.Size(120, 20)
        Me.CheckDetail.TabIndex = 7
        Me.CheckDetail.Text = "Apply To Detail"
        '
        'UltraLabel25
        '
        Me.UltraLabel25.Location = New System.Drawing.Point(35, 166)
        Me.UltraLabel25.Name = "UltraLabel25"
        Me.UltraLabel25.Size = New System.Drawing.Size(49, 21)
        Me.UltraLabel25.TabIndex = 60
        Me.UltraLabel25.Text = "Djawaz"
        '
        'UltraLabel15
        '
        Me.UltraLabel15.Location = New System.Drawing.Point(36, 194)
        Me.UltraLabel15.Name = "UltraLabel15"
        Me.UltraLabel15.Size = New System.Drawing.Size(57, 19)
        Me.UltraLabel15.TabIndex = 59
        Me.UltraLabel15.Text = "Permit No"
        '
        'ExportPermit
        '
        Me.ExportPermit.AutoComplete = False
        Me.ExportPermit.AutoCompleteColumnName = Nothing
        Me.ExportPermit.AutoCompleteExtraWhere = Nothing
        Me.ExportPermit.AutoCompleteTableName = Nothing
        Me.ExportPermit.BackColor = System.Drawing.Color.Transparent
        Me.ExportPermit.CustomMaxLength = CType(10, Byte)
        Me.ExportPermit.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.ExportPermit.Location = New System.Drawing.Point(100, 191)
        Me.ExportPermit.Name = "ExportPermit"
        Me.ExportPermit.Size = New System.Drawing.Size(103, 21)
        Me.ExportPermit.TabIndex = 7
        Me.ExportPermit.TextValue = ""
        '
        'InDjwazNo
        '
        Me.InDjwazNo.AutoComplete = False
        Me.InDjwazNo.AutoCompleteColumnName = Nothing
        Me.InDjwazNo.AutoCompleteExtraWhere = Nothing
        Me.InDjwazNo.AutoCompleteTableName = Nothing
        Me.InDjwazNo.BackColor = System.Drawing.Color.Transparent
        Me.InDjwazNo.CustomMaxLength = CType(10, Byte)
        Me.InDjwazNo.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.InDjwazNo.Location = New System.Drawing.Point(100, 164)
        Me.InDjwazNo.Name = "InDjwazNo"
        Me.InDjwazNo.Size = New System.Drawing.Size(103, 21)
        Me.InDjwazNo.TabIndex = 6
        Me.InDjwazNo.TextValue = ""
        '
        'UltraLabel24
        '
        Me.UltraLabel24.Location = New System.Drawing.Point(31, 54)
        Me.UltraLabel24.Name = "UltraLabel24"
        Me.UltraLabel24.Size = New System.Drawing.Size(54, 19)
        Me.UltraLabel24.TabIndex = 56
        Me.UltraLabel24.Text = "Booking"
        '
        'BookingID
        '
        Me.BookingID.BookingID = New System.Guid("00000000-0000-0000-0000-000000000000")
        Me.BookingID.Location = New System.Drawing.Point(100, 51)
        Me.BookingID.Name = "BookingID"
        Me.BookingID.Size = New System.Drawing.Size(270, 24)
        Me.BookingID.TabIndex = 1
        '
        'UltraLabel11
        '
        Me.UltraLabel11.Location = New System.Drawing.Point(33, 137)
        Me.UltraLabel11.Name = "UltraLabel11"
        Me.UltraLabel11.Size = New System.Drawing.Size(67, 19)
        Me.UltraLabel11.TabIndex = 53
        Me.UltraLabel11.Text = "Destination"
        '
        'UltraLabel10
        '
        Me.UltraLabel10.Location = New System.Drawing.Point(33, 110)
        Me.UltraLabel10.Name = "UltraLabel10"
        Me.UltraLabel10.Size = New System.Drawing.Size(58, 19)
        Me.UltraLabel10.TabIndex = 52
        Me.UltraLabel10.Text = "Return To"
        '
        'UltraLabel8
        '
        Me.UltraLabel8.Location = New System.Drawing.Point(31, 82)
        Me.UltraLabel8.Name = "UltraLabel8"
        Me.UltraLabel8.Size = New System.Drawing.Size(54, 19)
        Me.UltraLabel8.TabIndex = 50
        Me.UltraLabel8.Text = "Return By"
        '
        'Destination
        '
        Me.Destination.Location = New System.Drawing.Point(100, 134)
        Me.Destination.Name = "Destination"
        Me.Destination.PortCode = ""
        Me.Destination.Size = New System.Drawing.Size(266, 23)
        Me.Destination.TabIndex = 5
        '
        'ReturnTo
        '
        Me.ReturnTo.Location = New System.Drawing.Point(100, 106)
        Me.ReturnTo.Name = "ReturnTo"
        Me.ReturnTo.PortCode = ""
        Me.ReturnTo.Size = New System.Drawing.Size(267, 23)
        Me.ReturnTo.TabIndex = 4
        '
        'OutVoyage
        '
        Me.OutVoyage.Location = New System.Drawing.Point(267, 79)
        Me.OutVoyage.Name = "OutVoyage"
        Me.OutVoyage.Size = New System.Drawing.Size(106, 21)
        Me.OutVoyage.TabIndex = 3
        Me.OutVoyage.VoyageID = New System.Guid("00000000-0000-0000-0000-000000000000")
        '
        'OutVessel
        '
        Me.OutVessel.Location = New System.Drawing.Point(100, 79)
        Me.OutVessel.Name = "OutVessel"
        Me.OutVessel.Size = New System.Drawing.Size(162, 21)
        Me.OutVessel.TabIndex = 2
        Me.OutVessel.VesselID = New System.Guid("00000000-0000-0000-0000-000000000000")
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.GridResult)
        Me.UltraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(583, 392)
        Me.UltraGroupBox1.TabIndex = 0
        Me.UltraGroupBox1.Text = "List Of Containers"
        '
        'GridResult
        '
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.GridResult.DisplayLayout.Appearance = Appearance1
        Me.GridResult.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Me.GridResult.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.GridResult.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.SystemColors.Window
        Me.GridResult.DisplayLayout.GroupByBox.Appearance = Appearance2
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.GridResult.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
        Me.GridResult.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance4.BackColor2 = System.Drawing.SystemColors.Control
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.GridResult.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
        Appearance5.BackColor = System.Drawing.SystemColors.Window
        Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GridResult.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.SystemColors.Highlight
        Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.GridResult.DisplayLayout.Override.ActiveRowAppearance = Appearance6
        Me.GridResult.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.GridResult.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[True]
        Me.GridResult.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.GridResult.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.[True]
        Me.GridResult.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[True]
        Me.GridResult.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.GridResult.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Me.GridResult.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.GridResult.DisplayLayout.Override.CellAppearance = Appearance8
        Me.GridResult.DisplayLayout.Override.CellPadding = 0
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.GridResult.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance10.TextHAlignAsString = "Left"
        Me.GridResult.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.GridResult.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.GridResult.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Me.GridResult.DisplayLayout.Override.RowAppearance = Appearance11
        Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
        Me.GridResult.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
        Me.GridResult.DisplayLayout.UseFixedHeaders = True
        Me.GridResult.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.GridResult.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridResult.Location = New System.Drawing.Point(3, 16)
        Me.GridResult.Name = "GridResult"
        Me.GridResult.Size = New System.Drawing.Size(577, 373)
        Me.GridResult.TabIndex = 0
        Me.GridResult.Text = "GridCntrs"
        '
        'UltraGroupBox3
        '
        Me.UltraGroupBox3.Controls.Add(Me.UltraLabel6)
        Me.UltraGroupBox3.Controls.Add(Me.UltraLabel5)
        Me.UltraGroupBox3.Controls.Add(Me.ToStatus)
        Me.UltraGroupBox3.Controls.Add(Me.FromStatus)
        Me.UltraGroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGroupBox3.Location = New System.Drawing.Point(3, 40)
        Me.UltraGroupBox3.Name = "UltraGroupBox3"
        Me.UltraGroupBox3.Size = New System.Drawing.Size(982, 44)
        Me.UltraGroupBox3.TabIndex = 0
        '
        'UltraLabel6
        '
        Me.UltraLabel6.Location = New System.Drawing.Point(292, 12)
        Me.UltraLabel6.Name = "UltraLabel6"
        Me.UltraLabel6.Size = New System.Drawing.Size(22, 19)
        Me.UltraLabel6.TabIndex = 66
        Me.UltraLabel6.Text = "To:"
        '
        'UltraLabel5
        '
        Me.UltraLabel5.Location = New System.Drawing.Point(19, 12)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.Size = New System.Drawing.Size(39, 19)
        Me.UltraLabel5.TabIndex = 65
        Me.UltraLabel5.Text = "Status:"
        '
        'ToStatus
        '
        Me.ToStatus.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ToStatus.Code = ""
        Me.ToStatus.CustomShowAll = False
        Me.ToStatus.Location = New System.Drawing.Point(319, 10)
        Me.ToStatus.Name = "ToStatus"
        Me.ToStatus.Size = New System.Drawing.Size(214, 21)
        Me.ToStatus.TabIndex = 1
        '
        'FromStatus
        '
        Me.FromStatus.BackColor = System.Drawing.Color.WhiteSmoke
        Me.FromStatus.Code = ""
        Me.FromStatus.CustomShowAll = False
        Me.FromStatus.Location = New System.Drawing.Point(78, 10)
        Me.FromStatus.Name = "FromStatus"
        Me.FromStatus.Size = New System.Drawing.Size(211, 21)
        Me.FromStatus.TabIndex = 0
        '
        'FormErrorProvider
        '
        Me.FormErrorProvider.ContainerControl = Me
        '
        'FrmEcsBatch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(988, 491)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "FrmEcsBatch"
        Me.Text = "Ecs Batch Update"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        CType(Me.GroupBoxMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxMain.ResumeLayout(False)
        CType(Me.CheckPermitNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckDjwaz, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckDestination, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckReturnTo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckReturnBy, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckBooking, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckMaster, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        CType(Me.GridResult, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox3.ResumeLayout(False)
        CType(Me.FormErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MenuItem As Shipping.UserMenuItem
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents GridResult As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraGroupBox3 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents GroupBoxMain As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraLabel25 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel15 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents ExportPermit As Shipping.UserText
    Friend WithEvents InDjwazNo As Shipping.UserText
    Friend WithEvents UltraLabel24 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents BookingID As Shipping.UserBookingNo
    Friend WithEvents UltraLabel11 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel10 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel8 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Destination As Shipping.UserPortCode
    Friend WithEvents ReturnTo As Shipping.UserPortCode
    Friend WithEvents OutVoyage As Shipping.UserComboVoyage
    Friend WithEvents OutVessel As Shipping.UserComboVessel
    Friend WithEvents CheckDetail As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents StatusDate As Shipping.UserGnrlDate
    Friend WithEvents ToStatus As Shipping.UserComboCode
    Friend WithEvents FromStatus As Shipping.UserComboCode
    Friend WithEvents Depot As Shipping.UserComboCode
    Friend WithEvents Remarks As Shipping.UserText
    Friend WithEvents StatusDateToLine As Shipping.UserGnrlDate
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel6 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents CheckMaster As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents FormErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents CheckDjwaz As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents CheckDestination As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents CheckReturnTo As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents CheckReturnBy As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents CheckBooking As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents CheckPermitNo As Infragistics.Win.UltraWinEditors.UltraCheckEditor
End Class
