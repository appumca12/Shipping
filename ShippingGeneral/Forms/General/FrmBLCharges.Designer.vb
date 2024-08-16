<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBLCharges
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
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Tb_ChgLevelDetails", -1)
        Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID")
        Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MasterID")
        Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CnType", -1, Nothing, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, False)
        Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SOC")
        Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ShipmentType")
        Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Imco")
        Dim UltraGridColumn28 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IsFull")
        Dim UltraGridColumn29 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Amount20")
        Dim UltraGridColumn30 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Amount40")
        Dim UltraGridColumn31 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Amount45")
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
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand2 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("TB_ChgLevelMaster", -1)
        Dim UltraGridColumn32 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID", -1, Nothing, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, False)
        Dim UltraGridColumn33 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ApplyDate")
        Dim UltraGridColumn34 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Validity")
        Dim UltraGridColumn35 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ChargeItem")
        Dim UltraGridColumn36 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Isdeposit")
        Dim UltraGridColumn37 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("BaseOn")
        Dim UltraGridColumn38 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CurCode")
        Dim UltraGridColumn39 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DefaultAmount")
        Dim UltraGridColumn40 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DividInLCL")
        Dim UltraGridColumn41 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Condition")
        Dim UltraGridColumn42 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Description")
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance36 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance37 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance38 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance39 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance40 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance41 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance42 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance43 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance44 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance45 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance46 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance47 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance48 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance49 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance50 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance51 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance52 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance53 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance54 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance55 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance56 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance57 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance58 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance59 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance60 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance61 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance62 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance63 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance64 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance65 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance66 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance67 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance68 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance69 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance70 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance71 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance72 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance73 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance74 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance75 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance76 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance77 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance78 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance79 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance80 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance81 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance82 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance83 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance84 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance85 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance86 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance87 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance88 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance89 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance90 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance91 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance92 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance93 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance94 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance95 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance96 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.GridDetails = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.DataSetForm = New System.Data.DataSet
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
        Me.DataColumn11 = New System.Data.DataColumn
        Me.DataColumn21 = New System.Data.DataColumn
        Me.DataTable2 = New System.Data.DataTable
        Me.DataColumn12 = New System.Data.DataColumn
        Me.DataColumn13 = New System.Data.DataColumn
        Me.DataColumn14 = New System.Data.DataColumn
        Me.DataColumn15 = New System.Data.DataColumn
        Me.DataColumn16 = New System.Data.DataColumn
        Me.DataColumn17 = New System.Data.DataColumn
        Me.DataColumn10 = New System.Data.DataColumn
        Me.DataColumn18 = New System.Data.DataColumn
        Me.DataColumn19 = New System.Data.DataColumn
        Me.DataColumn20 = New System.Data.DataColumn
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.UltraLabel13 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel12 = New Infragistics.Win.Misc.UltraLabel
        Me.Line = New System.Windows.Forms.ComboBox
        Me.UltraLabel11 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel10 = New Infragistics.Win.Misc.UltraLabel
        Me.DropDownCondition = New Infragistics.Win.UltraWinGrid.UltraDropDown
        Me.UltraLabel9 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel7 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel6 = New Infragistics.Win.Misc.UltraLabel
        Me.DividInLCL = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.UltraLabel14 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel8 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.LblCharge = New Infragistics.Win.Misc.UltraLabel
        Me.IsDeposit = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.Validity = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.ApplyDate = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.GridCharges = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.DropDownSOC = New Infragistics.Win.UltraWinGrid.UltraDropDown
        Me.DropDownShipmentType = New Infragistics.Win.UltraWinGrid.UltraDropDown
        Me.DropDownImco = New Infragistics.Win.UltraWinGrid.UltraDropDown
        Me.DropDownType = New Infragistics.Win.UltraWinGrid.UltraDropDown
        Me.DropDownIsFull = New Infragistics.Win.UltraWinGrid.UltraDropDown
        Me.FormErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.UltraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.ButtonExcel = New System.Windows.Forms.Button
        Me.SearchChgCode = New Shipping.UserComboCode
        Me.ClientID = New Shipping.UserClientText
        Me.Port = New Shipping.UserPortCode
        Me.Toll = New Shipping.UserNum
        Me.Tax = New Shipping.UserNum
        Me.ImportExport = New Shipping.UserComboCode
        Me.Seq = New Shipping.UserNum
        Me.Condition = New Shipping.UserComboCode
        Me.Description = New Shipping.UserText
        Me.DefaultAmount = New Shipping.UserNum
        Me.CurCode = New Shipping.UserComboCode
        Me.BaseOn = New Shipping.UserComboCode
        Me.ChargeItem = New Shipping.UserComboCode
        Me.GeneralForms = New Shipping.UserGeneralForms
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.GridDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSetForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.DropDownCondition, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DividInLCL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IsDeposit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Validity, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ApplyDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridCharges, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DropDownSOC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DropDownShipmentType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DropDownImco, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DropDownType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DropDownIsFull, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FormErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.GridCharges, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(16, 48)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 425.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1040, 585)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.66667!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.33333!))
        Me.TableLayoutPanel2.Controls.Add(Me.GridDetails, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.UltraGroupBox1, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 163)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1034, 419)
        Me.TableLayoutPanel2.TabIndex = 1
        '
        'GridDetails
        '
        Me.GridDetails.DataMember = "Tb_ChgLevelDetails"
        Me.GridDetails.DataSource = Me.DataSetForm
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.GridDetails.DisplayLayout.Appearance = Appearance1
        UltraGridColumn22.Header.VisiblePosition = 0
        UltraGridColumn22.Width = 29
        UltraGridColumn23.Header.VisiblePosition = 1
        UltraGridColumn23.Width = 58
        UltraGridColumn24.Header.VisiblePosition = 2
        UltraGridColumn25.Header.VisiblePosition = 4
        UltraGridColumn26.Header.VisiblePosition = 5
        UltraGridColumn27.Header.VisiblePosition = 6
        UltraGridColumn28.Header.VisiblePosition = 3
        UltraGridColumn29.Header.VisiblePosition = 7
        UltraGridColumn30.Header.VisiblePosition = 8
        UltraGridColumn31.Header.VisiblePosition = 9
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn22, UltraGridColumn23, UltraGridColumn24, UltraGridColumn25, UltraGridColumn26, UltraGridColumn27, UltraGridColumn28, UltraGridColumn29, UltraGridColumn30, UltraGridColumn31})
        Me.GridDetails.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.GridDetails.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.GridDetails.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.SystemColors.Window
        Me.GridDetails.DisplayLayout.GroupByBox.Appearance = Appearance2
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.GridDetails.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
        Me.GridDetails.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance4.BackColor2 = System.Drawing.SystemColors.Control
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.GridDetails.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
        Appearance5.BackColor = System.Drawing.SystemColors.Window
        Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GridDetails.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.SystemColors.Highlight
        Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.GridDetails.DisplayLayout.Override.ActiveRowAppearance = Appearance6
        Me.GridDetails.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.GridDetails.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[True]
        Me.GridDetails.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.GridDetails.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[True]
        Me.GridDetails.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.GridDetails.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Me.GridDetails.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.GridDetails.DisplayLayout.Override.CellAppearance = Appearance8
        Me.GridDetails.DisplayLayout.Override.CellPadding = 0
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.GridDetails.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance10.TextHAlignAsString = "Left"
        Me.GridDetails.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.GridDetails.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.GridDetails.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Me.GridDetails.DisplayLayout.Override.RowAppearance = Appearance11
        Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
        Me.GridDetails.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
        Me.GridDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridDetails.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.GridDetails.Location = New System.Drawing.Point(485, 3)
        Me.GridDetails.Name = "GridDetails"
        Me.GridDetails.Size = New System.Drawing.Size(546, 413)
        Me.GridDetails.TabIndex = 0
        Me.GridDetails.Text = "UltraGrid2"
        '
        'DataSetForm
        '
        Me.DataSetForm.DataSetName = "NewDataSet"
        Me.DataSetForm.Tables.AddRange(New System.Data.DataTable() {Me.DataTable1, Me.DataTable2})
        '
        'DataTable1
        '
        Me.DataTable1.Columns.AddRange(New System.Data.DataColumn() {Me.DataColumn1, Me.DataColumn2, Me.DataColumn3, Me.DataColumn4, Me.DataColumn5, Me.DataColumn6, Me.DataColumn7, Me.DataColumn8, Me.DataColumn9, Me.DataColumn11, Me.DataColumn21})
        Me.DataTable1.TableName = "TB_ChgLevelMaster"
        '
        'DataColumn1
        '
        Me.DataColumn1.ColumnName = "ID"
        Me.DataColumn1.DataType = GetType(System.Guid)
        '
        'DataColumn2
        '
        Me.DataColumn2.Caption = "Apply Date"
        Me.DataColumn2.ColumnName = "ApplyDate"
        Me.DataColumn2.DataType = GetType(Date)
        '
        'DataColumn3
        '
        Me.DataColumn3.ColumnName = "Validity"
        Me.DataColumn3.DataType = GetType(Date)
        '
        'DataColumn4
        '
        Me.DataColumn4.Caption = "Charge"
        Me.DataColumn4.ColumnName = "ChargeItem"
        '
        'DataColumn5
        '
        Me.DataColumn5.Caption = "Is deposit"
        Me.DataColumn5.ColumnName = "Isdeposit"
        Me.DataColumn5.DataType = GetType(Boolean)
        '
        'DataColumn6
        '
        Me.DataColumn6.Caption = "Base On"
        Me.DataColumn6.ColumnName = "BaseOn"
        '
        'DataColumn7
        '
        Me.DataColumn7.Caption = "Currency"
        Me.DataColumn7.ColumnName = "CurCode"
        '
        'DataColumn8
        '
        Me.DataColumn8.Caption = "Default Amount"
        Me.DataColumn8.ColumnName = "DefaultAmount"
        Me.DataColumn8.DataType = GetType(Double)
        '
        'DataColumn9
        '
        Me.DataColumn9.Caption = "Divide In LCL"
        Me.DataColumn9.ColumnName = "DividInLCL"
        Me.DataColumn9.DataType = GetType(Boolean)
        '
        'DataColumn11
        '
        Me.DataColumn11.ColumnName = "Condition"
        '
        'DataColumn21
        '
        Me.DataColumn21.ColumnName = "Description"
        '
        'DataTable2
        '
        Me.DataTable2.Columns.AddRange(New System.Data.DataColumn() {Me.DataColumn12, Me.DataColumn13, Me.DataColumn14, Me.DataColumn15, Me.DataColumn16, Me.DataColumn17, Me.DataColumn10, Me.DataColumn18, Me.DataColumn19, Me.DataColumn20})
        Me.DataTable2.TableName = "Tb_ChgLevelDetails"
        '
        'DataColumn12
        '
        Me.DataColumn12.ColumnName = "ID"
        Me.DataColumn12.DataType = GetType(System.Guid)
        '
        'DataColumn13
        '
        Me.DataColumn13.ColumnName = "MasterID"
        Me.DataColumn13.DataType = GetType(System.Guid)
        '
        'DataColumn14
        '
        Me.DataColumn14.Caption = "CntrType"
        Me.DataColumn14.ColumnName = "CnType"
        '
        'DataColumn15
        '
        Me.DataColumn15.ColumnName = "SOC"
        '
        'DataColumn16
        '
        Me.DataColumn16.ColumnName = "ShipmentType"
        '
        'DataColumn17
        '
        Me.DataColumn17.ColumnName = "Imco"
        '
        'DataColumn10
        '
        Me.DataColumn10.ColumnName = "IsFull"
        '
        'DataColumn18
        '
        Me.DataColumn18.Caption = "20'"
        Me.DataColumn18.ColumnName = "Amount20"
        Me.DataColumn18.DataType = GetType(Double)
        '
        'DataColumn19
        '
        Me.DataColumn19.Caption = "40'"
        Me.DataColumn19.ColumnName = "Amount40"
        Me.DataColumn19.DataType = GetType(Double)
        '
        'DataColumn20
        '
        Me.DataColumn20.Caption = "45'"
        Me.DataColumn20.ColumnName = "Amount45"
        Me.DataColumn20.DataType = GetType(Double)
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.ClientID)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel13)
        Me.UltraGroupBox1.Controls.Add(Me.Port)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel12)
        Me.UltraGroupBox1.Controls.Add(Me.Line)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel11)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel10)
        Me.UltraGroupBox1.Controls.Add(Me.DropDownCondition)
        Me.UltraGroupBox1.Controls.Add(Me.Toll)
        Me.UltraGroupBox1.Controls.Add(Me.Tax)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel9)
        Me.UltraGroupBox1.Controls.Add(Me.ImportExport)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel7)
        Me.UltraGroupBox1.Controls.Add(Me.Seq)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel6)
        Me.UltraGroupBox1.Controls.Add(Me.Condition)
        Me.UltraGroupBox1.Controls.Add(Me.DividInLCL)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel14)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel8)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel5)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel4)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel3)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel2)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel1)
        Me.UltraGroupBox1.Controls.Add(Me.LblCharge)
        Me.UltraGroupBox1.Controls.Add(Me.Description)
        Me.UltraGroupBox1.Controls.Add(Me.DefaultAmount)
        Me.UltraGroupBox1.Controls.Add(Me.CurCode)
        Me.UltraGroupBox1.Controls.Add(Me.BaseOn)
        Me.UltraGroupBox1.Controls.Add(Me.IsDeposit)
        Me.UltraGroupBox1.Controls.Add(Me.ChargeItem)
        Me.UltraGroupBox1.Controls.Add(Me.Validity)
        Me.UltraGroupBox1.Controls.Add(Me.ApplyDate)
        Me.UltraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(476, 413)
        Me.UltraGroupBox1.TabIndex = 0
        Me.UltraGroupBox1.Text = "Master Data"
        '
        'UltraLabel13
        '
        Me.UltraLabel13.Location = New System.Drawing.Point(16, 100)
        Me.UltraLabel13.Name = "UltraLabel13"
        Me.UltraLabel13.Size = New System.Drawing.Size(82, 21)
        Me.UltraLabel13.TabIndex = 34
        Me.UltraLabel13.Text = "Port"
        '
        'UltraLabel12
        '
        Me.UltraLabel12.Location = New System.Drawing.Point(17, 73)
        Me.UltraLabel12.Name = "UltraLabel12"
        Me.UltraLabel12.Size = New System.Drawing.Size(82, 21)
        Me.UltraLabel12.TabIndex = 32
        Me.UltraLabel12.Text = "Line"
        '
        'Line
        '
        Me.Line.FormattingEnabled = True
        Me.Line.Location = New System.Drawing.Point(102, 73)
        Me.Line.Name = "Line"
        Me.Line.Size = New System.Drawing.Size(141, 21)
        Me.Line.TabIndex = 2
        '
        'UltraLabel11
        '
        Me.UltraLabel11.Location = New System.Drawing.Point(169, 312)
        Me.UltraLabel11.Name = "UltraLabel11"
        Me.UltraLabel11.Size = New System.Drawing.Size(25, 18)
        Me.UltraLabel11.TabIndex = 30
        Me.UltraLabel11.Text = "Toll"
        '
        'UltraLabel10
        '
        Me.UltraLabel10.Location = New System.Drawing.Point(17, 309)
        Me.UltraLabel10.Name = "UltraLabel10"
        Me.UltraLabel10.Size = New System.Drawing.Size(69, 18)
        Me.UltraLabel10.TabIndex = 29
        Me.UltraLabel10.Text = "Tax"
        '
        'DropDownCondition
        '
        Appearance13.BackColor = System.Drawing.SystemColors.Window
        Appearance13.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.DropDownCondition.DisplayLayout.Appearance = Appearance13
        Me.DropDownCondition.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.DropDownCondition.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance14.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance14.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance14.BorderColor = System.Drawing.SystemColors.Window
        Me.DropDownCondition.DisplayLayout.GroupByBox.Appearance = Appearance14
        Appearance15.ForeColor = System.Drawing.SystemColors.GrayText
        Me.DropDownCondition.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance15
        Me.DropDownCondition.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance16.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance16.BackColor2 = System.Drawing.SystemColors.Control
        Appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance16.ForeColor = System.Drawing.SystemColors.GrayText
        Me.DropDownCondition.DisplayLayout.GroupByBox.PromptAppearance = Appearance16
        Me.DropDownCondition.DisplayLayout.MaxColScrollRegions = 1
        Me.DropDownCondition.DisplayLayout.MaxRowScrollRegions = 1
        Appearance17.BackColor = System.Drawing.SystemColors.Window
        Appearance17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DropDownCondition.DisplayLayout.Override.ActiveCellAppearance = Appearance17
        Appearance18.BackColor = System.Drawing.SystemColors.Highlight
        Appearance18.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.DropDownCondition.DisplayLayout.Override.ActiveRowAppearance = Appearance18
        Me.DropDownCondition.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.DropDownCondition.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance19.BackColor = System.Drawing.SystemColors.Window
        Me.DropDownCondition.DisplayLayout.Override.CardAreaAppearance = Appearance19
        Appearance20.BorderColor = System.Drawing.Color.Silver
        Appearance20.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.DropDownCondition.DisplayLayout.Override.CellAppearance = Appearance20
        Me.DropDownCondition.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.DropDownCondition.DisplayLayout.Override.CellPadding = 0
        Appearance21.BackColor = System.Drawing.SystemColors.Control
        Appearance21.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance21.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance21.BorderColor = System.Drawing.SystemColors.Window
        Me.DropDownCondition.DisplayLayout.Override.GroupByRowAppearance = Appearance21
        Appearance22.TextHAlignAsString = "Left"
        Me.DropDownCondition.DisplayLayout.Override.HeaderAppearance = Appearance22
        Me.DropDownCondition.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.DropDownCondition.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance23.BackColor = System.Drawing.SystemColors.Window
        Appearance23.BorderColor = System.Drawing.Color.Silver
        Me.DropDownCondition.DisplayLayout.Override.RowAppearance = Appearance23
        Me.DropDownCondition.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance24.BackColor = System.Drawing.SystemColors.ControlLight
        Me.DropDownCondition.DisplayLayout.Override.TemplateAddRowAppearance = Appearance24
        Me.DropDownCondition.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.DropDownCondition.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.DropDownCondition.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.DropDownCondition.Location = New System.Drawing.Point(267, -3)
        Me.DropDownCondition.Name = "DropDownCondition"
        Me.DropDownCondition.PreferredDropDownSize = New System.Drawing.Size(0, 0)
        Me.DropDownCondition.Size = New System.Drawing.Size(102, 31)
        Me.DropDownCondition.TabIndex = 18
        Me.DropDownCondition.Text = "UltraDropDown1"
        Me.DropDownCondition.Visible = False
        '
        'UltraLabel9
        '
        Me.UltraLabel9.Location = New System.Drawing.Point(17, 51)
        Me.UltraLabel9.Name = "UltraLabel9"
        Me.UltraLabel9.Size = New System.Drawing.Size(82, 21)
        Me.UltraLabel9.TabIndex = 26
        Me.UltraLabel9.Text = "Import/Export"
        '
        'UltraLabel7
        '
        Me.UltraLabel7.Location = New System.Drawing.Point(17, 23)
        Me.UltraLabel7.Name = "UltraLabel7"
        Me.UltraLabel7.Size = New System.Drawing.Size(69, 21)
        Me.UltraLabel7.TabIndex = 24
        Me.UltraLabel7.Text = "Seq"
        '
        'UltraLabel6
        '
        Me.UltraLabel6.Location = New System.Drawing.Point(17, 287)
        Me.UltraLabel6.Name = "UltraLabel6"
        Me.UltraLabel6.Size = New System.Drawing.Size(69, 18)
        Me.UltraLabel6.TabIndex = 22
        Me.UltraLabel6.Text = "Condition"
        '
        'DividInLCL
        '
        Me.DividInLCL.Location = New System.Drawing.Point(292, 258)
        Me.DividInLCL.Name = "DividInLCL"
        Me.DividInLCL.Size = New System.Drawing.Size(106, 20)
        Me.DividInLCL.TabIndex = 11
        Me.DividInLCL.Text = "Divide in LCL"
        '
        'UltraLabel14
        '
        Me.UltraLabel14.Location = New System.Drawing.Point(16, 366)
        Me.UltraLabel14.Name = "UltraLabel14"
        Me.UltraLabel14.Size = New System.Drawing.Size(69, 23)
        Me.UltraLabel14.TabIndex = 19
        Me.UltraLabel14.Text = "Client"
        '
        'UltraLabel8
        '
        Me.UltraLabel8.Location = New System.Drawing.Point(17, 337)
        Me.UltraLabel8.Name = "UltraLabel8"
        Me.UltraLabel8.Size = New System.Drawing.Size(69, 23)
        Me.UltraLabel8.TabIndex = 19
        Me.UltraLabel8.Text = "Description"
        '
        'UltraLabel5
        '
        Me.UltraLabel5.Location = New System.Drawing.Point(17, 261)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.Size = New System.Drawing.Size(82, 23)
        Me.UltraLabel5.TabIndex = 16
        Me.UltraLabel5.Text = "Default Amount"
        '
        'UltraLabel4
        '
        Me.UltraLabel4.Location = New System.Drawing.Point(17, 232)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.Size = New System.Drawing.Size(69, 23)
        Me.UltraLabel4.TabIndex = 15
        Me.UltraLabel4.Text = "Currency"
        '
        'UltraLabel3
        '
        Me.UltraLabel3.Location = New System.Drawing.Point(17, 209)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(69, 23)
        Me.UltraLabel3.TabIndex = 14
        Me.UltraLabel3.Text = "Base On"
        '
        'UltraLabel2
        '
        Me.UltraLabel2.Location = New System.Drawing.Point(17, 183)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(69, 23)
        Me.UltraLabel2.TabIndex = 13
        Me.UltraLabel2.Text = "Validity"
        '
        'UltraLabel1
        '
        Me.UltraLabel1.Location = New System.Drawing.Point(17, 157)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(69, 23)
        Me.UltraLabel1.TabIndex = 12
        Me.UltraLabel1.Text = "Apply Date"
        '
        'LblCharge
        '
        Me.LblCharge.Location = New System.Drawing.Point(17, 131)
        Me.LblCharge.Name = "LblCharge"
        Me.LblCharge.Size = New System.Drawing.Size(69, 23)
        Me.LblCharge.TabIndex = 11
        Me.LblCharge.Text = "Charge Item"
        '
        'IsDeposit
        '
        Me.IsDeposit.Location = New System.Drawing.Point(321, 128)
        Me.IsDeposit.Name = "IsDeposit"
        Me.IsDeposit.Size = New System.Drawing.Size(77, 20)
        Me.IsDeposit.TabIndex = 5
        Me.IsDeposit.Text = "Is Deposit"
        '
        'Validity
        '
        Me.Validity.Location = New System.Drawing.Point(101, 180)
        Me.Validity.Name = "Validity"
        Me.Validity.Size = New System.Drawing.Size(144, 21)
        Me.Validity.TabIndex = 7
        '
        'ApplyDate
        '
        Me.ApplyDate.Location = New System.Drawing.Point(101, 154)
        Me.ApplyDate.Name = "ApplyDate"
        Me.ApplyDate.Size = New System.Drawing.Size(144, 21)
        Me.ApplyDate.TabIndex = 6
        '
        'GridCharges
        '
        Me.GridCharges.DataMember = "TB_ChgLevelMaster"
        Me.GridCharges.DataSource = Me.DataSetForm
        Appearance25.BackColor = System.Drawing.SystemColors.Window
        Appearance25.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.GridCharges.DisplayLayout.Appearance = Appearance25
        UltraGridColumn32.Header.VisiblePosition = 0
        UltraGridColumn33.Header.VisiblePosition = 1
        UltraGridColumn34.Header.VisiblePosition = 2
        UltraGridColumn35.Header.VisiblePosition = 3
        UltraGridColumn36.Header.VisiblePosition = 4
        UltraGridColumn37.Header.VisiblePosition = 5
        UltraGridColumn38.Header.VisiblePosition = 6
        UltraGridColumn39.Header.VisiblePosition = 7
        UltraGridColumn40.Header.VisiblePosition = 8
        UltraGridColumn41.Header.VisiblePosition = 9
        UltraGridColumn42.Header.VisiblePosition = 10
        UltraGridBand2.Columns.AddRange(New Object() {UltraGridColumn32, UltraGridColumn33, UltraGridColumn34, UltraGridColumn35, UltraGridColumn36, UltraGridColumn37, UltraGridColumn38, UltraGridColumn39, UltraGridColumn40, UltraGridColumn41, UltraGridColumn42})
        Me.GridCharges.DisplayLayout.BandsSerializer.Add(UltraGridBand2)
        Me.GridCharges.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.GridCharges.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance26.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance26.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance26.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance26.BorderColor = System.Drawing.SystemColors.Window
        Me.GridCharges.DisplayLayout.GroupByBox.Appearance = Appearance26
        Appearance27.ForeColor = System.Drawing.SystemColors.GrayText
        Me.GridCharges.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance27
        Me.GridCharges.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance28.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance28.BackColor2 = System.Drawing.SystemColors.Control
        Appearance28.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance28.ForeColor = System.Drawing.SystemColors.GrayText
        Me.GridCharges.DisplayLayout.GroupByBox.PromptAppearance = Appearance28
        Me.GridCharges.DisplayLayout.MaxColScrollRegions = 1
        Me.GridCharges.DisplayLayout.MaxRowScrollRegions = 1
        Appearance29.BackColor = System.Drawing.SystemColors.Window
        Appearance29.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GridCharges.DisplayLayout.Override.ActiveCellAppearance = Appearance29
        Appearance30.BackColor = System.Drawing.SystemColors.Highlight
        Appearance30.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.GridCharges.DisplayLayout.Override.ActiveRowAppearance = Appearance30
        Me.GridCharges.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.GridCharges.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.GridCharges.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.GridCharges.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.GridCharges.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance31.BackColor = System.Drawing.SystemColors.Window
        Me.GridCharges.DisplayLayout.Override.CardAreaAppearance = Appearance31
        Appearance32.BorderColor = System.Drawing.Color.Silver
        Appearance32.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.GridCharges.DisplayLayout.Override.CellAppearance = Appearance32
        Me.GridCharges.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.GridCharges.DisplayLayout.Override.CellPadding = 0
        Appearance33.BackColor = System.Drawing.SystemColors.Control
        Appearance33.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance33.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance33.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance33.BorderColor = System.Drawing.SystemColors.Window
        Me.GridCharges.DisplayLayout.Override.GroupByRowAppearance = Appearance33
        Appearance34.TextHAlignAsString = "Left"
        Me.GridCharges.DisplayLayout.Override.HeaderAppearance = Appearance34
        Me.GridCharges.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.GridCharges.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance35.BackColor = System.Drawing.SystemColors.Window
        Appearance35.BorderColor = System.Drawing.Color.Silver
        Me.GridCharges.DisplayLayout.Override.RowAppearance = Appearance35
        Me.GridCharges.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance36.BackColor = System.Drawing.SystemColors.ControlLight
        Me.GridCharges.DisplayLayout.Override.TemplateAddRowAppearance = Appearance36
        Me.GridCharges.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.GridCharges.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.GridCharges.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridCharges.Location = New System.Drawing.Point(3, 3)
        Me.GridCharges.Name = "GridCharges"
        Me.GridCharges.Size = New System.Drawing.Size(1034, 154)
        Me.GridCharges.TabIndex = 2
        Me.GridCharges.Text = "UltraGrid1"
        '
        'DropDownSOC
        '
        Appearance37.BackColor = System.Drawing.SystemColors.Window
        Appearance37.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.DropDownSOC.DisplayLayout.Appearance = Appearance37
        Me.DropDownSOC.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.DropDownSOC.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance38.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance38.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance38.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance38.BorderColor = System.Drawing.SystemColors.Window
        Me.DropDownSOC.DisplayLayout.GroupByBox.Appearance = Appearance38
        Appearance39.ForeColor = System.Drawing.SystemColors.GrayText
        Me.DropDownSOC.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance39
        Me.DropDownSOC.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance40.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance40.BackColor2 = System.Drawing.SystemColors.Control
        Appearance40.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance40.ForeColor = System.Drawing.SystemColors.GrayText
        Me.DropDownSOC.DisplayLayout.GroupByBox.PromptAppearance = Appearance40
        Me.DropDownSOC.DisplayLayout.MaxColScrollRegions = 1
        Me.DropDownSOC.DisplayLayout.MaxRowScrollRegions = 1
        Appearance41.BackColor = System.Drawing.SystemColors.Window
        Appearance41.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DropDownSOC.DisplayLayout.Override.ActiveCellAppearance = Appearance41
        Appearance42.BackColor = System.Drawing.SystemColors.Highlight
        Appearance42.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.DropDownSOC.DisplayLayout.Override.ActiveRowAppearance = Appearance42
        Me.DropDownSOC.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.DropDownSOC.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance43.BackColor = System.Drawing.SystemColors.Window
        Me.DropDownSOC.DisplayLayout.Override.CardAreaAppearance = Appearance43
        Appearance44.BorderColor = System.Drawing.Color.Silver
        Appearance44.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.DropDownSOC.DisplayLayout.Override.CellAppearance = Appearance44
        Me.DropDownSOC.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.DropDownSOC.DisplayLayout.Override.CellPadding = 0
        Appearance45.BackColor = System.Drawing.SystemColors.Control
        Appearance45.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance45.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance45.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance45.BorderColor = System.Drawing.SystemColors.Window
        Me.DropDownSOC.DisplayLayout.Override.GroupByRowAppearance = Appearance45
        Appearance46.TextHAlignAsString = "Left"
        Me.DropDownSOC.DisplayLayout.Override.HeaderAppearance = Appearance46
        Me.DropDownSOC.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.DropDownSOC.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance47.BackColor = System.Drawing.SystemColors.Window
        Appearance47.BorderColor = System.Drawing.Color.Silver
        Me.DropDownSOC.DisplayLayout.Override.RowAppearance = Appearance47
        Me.DropDownSOC.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance48.BackColor = System.Drawing.SystemColors.ControlLight
        Me.DropDownSOC.DisplayLayout.Override.TemplateAddRowAppearance = Appearance48
        Me.DropDownSOC.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.DropDownSOC.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.DropDownSOC.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.DropDownSOC.Location = New System.Drawing.Point(320, 526)
        Me.DropDownSOC.Name = "DropDownSOC"
        Me.DropDownSOC.PreferredDropDownSize = New System.Drawing.Size(0, 0)
        Me.DropDownSOC.Size = New System.Drawing.Size(102, 31)
        Me.DropDownSOC.TabIndex = 13
        Me.DropDownSOC.Text = "UltraDropDown1"
        Me.DropDownSOC.Visible = False
        '
        'DropDownShipmentType
        '
        Appearance49.BackColor = System.Drawing.SystemColors.Window
        Appearance49.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.DropDownShipmentType.DisplayLayout.Appearance = Appearance49
        Me.DropDownShipmentType.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.DropDownShipmentType.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance50.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance50.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance50.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance50.BorderColor = System.Drawing.SystemColors.Window
        Me.DropDownShipmentType.DisplayLayout.GroupByBox.Appearance = Appearance50
        Appearance51.ForeColor = System.Drawing.SystemColors.GrayText
        Me.DropDownShipmentType.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance51
        Me.DropDownShipmentType.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance52.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance52.BackColor2 = System.Drawing.SystemColors.Control
        Appearance52.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance52.ForeColor = System.Drawing.SystemColors.GrayText
        Me.DropDownShipmentType.DisplayLayout.GroupByBox.PromptAppearance = Appearance52
        Me.DropDownShipmentType.DisplayLayout.MaxColScrollRegions = 1
        Me.DropDownShipmentType.DisplayLayout.MaxRowScrollRegions = 1
        Appearance53.BackColor = System.Drawing.SystemColors.Window
        Appearance53.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DropDownShipmentType.DisplayLayout.Override.ActiveCellAppearance = Appearance53
        Appearance54.BackColor = System.Drawing.SystemColors.Highlight
        Appearance54.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.DropDownShipmentType.DisplayLayout.Override.ActiveRowAppearance = Appearance54
        Me.DropDownShipmentType.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.DropDownShipmentType.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance55.BackColor = System.Drawing.SystemColors.Window
        Me.DropDownShipmentType.DisplayLayout.Override.CardAreaAppearance = Appearance55
        Appearance56.BorderColor = System.Drawing.Color.Silver
        Appearance56.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.DropDownShipmentType.DisplayLayout.Override.CellAppearance = Appearance56
        Me.DropDownShipmentType.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.DropDownShipmentType.DisplayLayout.Override.CellPadding = 0
        Appearance57.BackColor = System.Drawing.SystemColors.Control
        Appearance57.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance57.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance57.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance57.BorderColor = System.Drawing.SystemColors.Window
        Me.DropDownShipmentType.DisplayLayout.Override.GroupByRowAppearance = Appearance57
        Appearance58.TextHAlignAsString = "Left"
        Me.DropDownShipmentType.DisplayLayout.Override.HeaderAppearance = Appearance58
        Me.DropDownShipmentType.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.DropDownShipmentType.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance59.BackColor = System.Drawing.SystemColors.Window
        Appearance59.BorderColor = System.Drawing.Color.Silver
        Me.DropDownShipmentType.DisplayLayout.Override.RowAppearance = Appearance59
        Me.DropDownShipmentType.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance60.BackColor = System.Drawing.SystemColors.ControlLight
        Me.DropDownShipmentType.DisplayLayout.Override.TemplateAddRowAppearance = Appearance60
        Me.DropDownShipmentType.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.DropDownShipmentType.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.DropDownShipmentType.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.DropDownShipmentType.Location = New System.Drawing.Point(428, 528)
        Me.DropDownShipmentType.Name = "DropDownShipmentType"
        Me.DropDownShipmentType.PreferredDropDownSize = New System.Drawing.Size(0, 0)
        Me.DropDownShipmentType.Size = New System.Drawing.Size(102, 31)
        Me.DropDownShipmentType.TabIndex = 14
        Me.DropDownShipmentType.Text = "UltraDropDown1"
        Me.DropDownShipmentType.Visible = False
        '
        'DropDownImco
        '
        Appearance61.BackColor = System.Drawing.SystemColors.Window
        Appearance61.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.DropDownImco.DisplayLayout.Appearance = Appearance61
        Me.DropDownImco.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.DropDownImco.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance62.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance62.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance62.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance62.BorderColor = System.Drawing.SystemColors.Window
        Me.DropDownImco.DisplayLayout.GroupByBox.Appearance = Appearance62
        Appearance63.ForeColor = System.Drawing.SystemColors.GrayText
        Me.DropDownImco.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance63
        Me.DropDownImco.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance64.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance64.BackColor2 = System.Drawing.SystemColors.Control
        Appearance64.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance64.ForeColor = System.Drawing.SystemColors.GrayText
        Me.DropDownImco.DisplayLayout.GroupByBox.PromptAppearance = Appearance64
        Me.DropDownImco.DisplayLayout.MaxColScrollRegions = 1
        Me.DropDownImco.DisplayLayout.MaxRowScrollRegions = 1
        Appearance65.BackColor = System.Drawing.SystemColors.Window
        Appearance65.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DropDownImco.DisplayLayout.Override.ActiveCellAppearance = Appearance65
        Appearance66.BackColor = System.Drawing.SystemColors.Highlight
        Appearance66.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.DropDownImco.DisplayLayout.Override.ActiveRowAppearance = Appearance66
        Me.DropDownImco.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.DropDownImco.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance67.BackColor = System.Drawing.SystemColors.Window
        Me.DropDownImco.DisplayLayout.Override.CardAreaAppearance = Appearance67
        Appearance68.BorderColor = System.Drawing.Color.Silver
        Appearance68.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.DropDownImco.DisplayLayout.Override.CellAppearance = Appearance68
        Me.DropDownImco.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.DropDownImco.DisplayLayout.Override.CellPadding = 0
        Appearance69.BackColor = System.Drawing.SystemColors.Control
        Appearance69.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance69.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance69.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance69.BorderColor = System.Drawing.SystemColors.Window
        Me.DropDownImco.DisplayLayout.Override.GroupByRowAppearance = Appearance69
        Appearance70.TextHAlignAsString = "Left"
        Me.DropDownImco.DisplayLayout.Override.HeaderAppearance = Appearance70
        Me.DropDownImco.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.DropDownImco.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance71.BackColor = System.Drawing.SystemColors.Window
        Appearance71.BorderColor = System.Drawing.Color.Silver
        Me.DropDownImco.DisplayLayout.Override.RowAppearance = Appearance71
        Me.DropDownImco.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance72.BackColor = System.Drawing.SystemColors.ControlLight
        Me.DropDownImco.DisplayLayout.Override.TemplateAddRowAppearance = Appearance72
        Me.DropDownImco.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.DropDownImco.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.DropDownImco.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.DropDownImco.Location = New System.Drawing.Point(536, 528)
        Me.DropDownImco.Name = "DropDownImco"
        Me.DropDownImco.PreferredDropDownSize = New System.Drawing.Size(0, 0)
        Me.DropDownImco.Size = New System.Drawing.Size(102, 31)
        Me.DropDownImco.TabIndex = 15
        Me.DropDownImco.Text = "UltraDropDown1"
        Me.DropDownImco.Visible = False
        '
        'DropDownType
        '
        Appearance73.BackColor = System.Drawing.SystemColors.Window
        Appearance73.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.DropDownType.DisplayLayout.Appearance = Appearance73
        Me.DropDownType.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.DropDownType.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance74.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance74.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance74.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance74.BorderColor = System.Drawing.SystemColors.Window
        Me.DropDownType.DisplayLayout.GroupByBox.Appearance = Appearance74
        Appearance75.ForeColor = System.Drawing.SystemColors.GrayText
        Me.DropDownType.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance75
        Me.DropDownType.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance76.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance76.BackColor2 = System.Drawing.SystemColors.Control
        Appearance76.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance76.ForeColor = System.Drawing.SystemColors.GrayText
        Me.DropDownType.DisplayLayout.GroupByBox.PromptAppearance = Appearance76
        Me.DropDownType.DisplayLayout.MaxColScrollRegions = 1
        Me.DropDownType.DisplayLayout.MaxRowScrollRegions = 1
        Appearance77.BackColor = System.Drawing.SystemColors.Window
        Appearance77.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DropDownType.DisplayLayout.Override.ActiveCellAppearance = Appearance77
        Appearance78.BackColor = System.Drawing.SystemColors.Highlight
        Appearance78.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.DropDownType.DisplayLayout.Override.ActiveRowAppearance = Appearance78
        Me.DropDownType.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.DropDownType.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance79.BackColor = System.Drawing.SystemColors.Window
        Me.DropDownType.DisplayLayout.Override.CardAreaAppearance = Appearance79
        Appearance80.BorderColor = System.Drawing.Color.Silver
        Appearance80.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.DropDownType.DisplayLayout.Override.CellAppearance = Appearance80
        Me.DropDownType.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.DropDownType.DisplayLayout.Override.CellPadding = 0
        Appearance81.BackColor = System.Drawing.SystemColors.Control
        Appearance81.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance81.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance81.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance81.BorderColor = System.Drawing.SystemColors.Window
        Me.DropDownType.DisplayLayout.Override.GroupByRowAppearance = Appearance81
        Appearance82.TextHAlignAsString = "Left"
        Me.DropDownType.DisplayLayout.Override.HeaderAppearance = Appearance82
        Me.DropDownType.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.DropDownType.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance83.BackColor = System.Drawing.SystemColors.Window
        Appearance83.BorderColor = System.Drawing.Color.Silver
        Me.DropDownType.DisplayLayout.Override.RowAppearance = Appearance83
        Me.DropDownType.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance84.BackColor = System.Drawing.SystemColors.ControlLight
        Me.DropDownType.DisplayLayout.Override.TemplateAddRowAppearance = Appearance84
        Me.DropDownType.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.DropDownType.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.DropDownType.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.DropDownType.Location = New System.Drawing.Point(644, 531)
        Me.DropDownType.Name = "DropDownType"
        Me.DropDownType.PreferredDropDownSize = New System.Drawing.Size(0, 0)
        Me.DropDownType.Size = New System.Drawing.Size(102, 31)
        Me.DropDownType.TabIndex = 16
        Me.DropDownType.Text = "UltraDropDown1"
        Me.DropDownType.Visible = False
        '
        'DropDownIsFull
        '
        Appearance85.BackColor = System.Drawing.SystemColors.Window
        Appearance85.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.DropDownIsFull.DisplayLayout.Appearance = Appearance85
        Me.DropDownIsFull.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.DropDownIsFull.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance86.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance86.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance86.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance86.BorderColor = System.Drawing.SystemColors.Window
        Me.DropDownIsFull.DisplayLayout.GroupByBox.Appearance = Appearance86
        Appearance87.ForeColor = System.Drawing.SystemColors.GrayText
        Me.DropDownIsFull.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance87
        Me.DropDownIsFull.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance88.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance88.BackColor2 = System.Drawing.SystemColors.Control
        Appearance88.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance88.ForeColor = System.Drawing.SystemColors.GrayText
        Me.DropDownIsFull.DisplayLayout.GroupByBox.PromptAppearance = Appearance88
        Me.DropDownIsFull.DisplayLayout.MaxColScrollRegions = 1
        Me.DropDownIsFull.DisplayLayout.MaxRowScrollRegions = 1
        Appearance89.BackColor = System.Drawing.SystemColors.Window
        Appearance89.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DropDownIsFull.DisplayLayout.Override.ActiveCellAppearance = Appearance89
        Appearance90.BackColor = System.Drawing.SystemColors.Highlight
        Appearance90.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.DropDownIsFull.DisplayLayout.Override.ActiveRowAppearance = Appearance90
        Me.DropDownIsFull.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.DropDownIsFull.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance91.BackColor = System.Drawing.SystemColors.Window
        Me.DropDownIsFull.DisplayLayout.Override.CardAreaAppearance = Appearance91
        Appearance92.BorderColor = System.Drawing.Color.Silver
        Appearance92.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.DropDownIsFull.DisplayLayout.Override.CellAppearance = Appearance92
        Me.DropDownIsFull.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.DropDownIsFull.DisplayLayout.Override.CellPadding = 0
        Appearance93.BackColor = System.Drawing.SystemColors.Control
        Appearance93.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance93.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance93.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance93.BorderColor = System.Drawing.SystemColors.Window
        Me.DropDownIsFull.DisplayLayout.Override.GroupByRowAppearance = Appearance93
        Appearance94.TextHAlignAsString = "Left"
        Me.DropDownIsFull.DisplayLayout.Override.HeaderAppearance = Appearance94
        Me.DropDownIsFull.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.DropDownIsFull.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance95.BackColor = System.Drawing.SystemColors.Window
        Appearance95.BorderColor = System.Drawing.Color.Silver
        Me.DropDownIsFull.DisplayLayout.Override.RowAppearance = Appearance95
        Me.DropDownIsFull.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance96.BackColor = System.Drawing.SystemColors.ControlLight
        Me.DropDownIsFull.DisplayLayout.Override.TemplateAddRowAppearance = Appearance96
        Me.DropDownIsFull.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.DropDownIsFull.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.DropDownIsFull.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.DropDownIsFull.Location = New System.Drawing.Point(745, 528)
        Me.DropDownIsFull.Name = "DropDownIsFull"
        Me.DropDownIsFull.PreferredDropDownSize = New System.Drawing.Size(0, 0)
        Me.DropDownIsFull.Size = New System.Drawing.Size(102, 31)
        Me.DropDownIsFull.TabIndex = 17
        Me.DropDownIsFull.Text = "UltraDropDown1"
        Me.DropDownIsFull.Visible = False
        '
        'FormErrorProvider
        '
        Me.FormErrorProvider.ContainerControl = Me
        '
        'UltraGroupBox2
        '
        Me.UltraGroupBox2.Controls.Add(Me.Label9)
        Me.UltraGroupBox2.Controls.Add(Me.ButtonExcel)
        Me.UltraGroupBox2.Controls.Add(Me.DropDownIsFull)
        Me.UltraGroupBox2.Controls.Add(Me.DropDownType)
        Me.UltraGroupBox2.Controls.Add(Me.SearchChgCode)
        Me.UltraGroupBox2.Controls.Add(Me.TableLayoutPanel1)
        Me.UltraGroupBox2.Controls.Add(Me.DropDownImco)
        Me.UltraGroupBox2.Controls.Add(Me.DropDownSOC)
        Me.UltraGroupBox2.Controls.Add(Me.DropDownShipmentType)
        Me.UltraGroupBox2.Location = New System.Drawing.Point(0, 38)
        Me.UltraGroupBox2.Name = "UltraGroupBox2"
        Me.UltraGroupBox2.Size = New System.Drawing.Size(1078, 655)
        Me.UltraGroupBox2.TabIndex = 19
        Me.UltraGroupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.VisualStudio2005
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(18, 24)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(69, 13)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "Charge Code"

        '
        'ButtonExcel
        '
        Me.ButtonExcel.AutoSize = True
        Me.ButtonExcel.Location = New System.Drawing.Point(950, 24)
        Me.ButtonExcel.Name = "ButtonExcel"
        Me.ButtonExcel.Size = New System.Drawing.Size(69, 13)

        Me.ButtonExcel.Text = "To Excel"
        '
        'SearchChgCode
        '
        Me.SearchChgCode.BackColor = System.Drawing.Color.WhiteSmoke
        Me.SearchChgCode.Code = ""
        Me.SearchChgCode.CustomShowAll = False
        Me.SearchChgCode.Location = New System.Drawing.Point(95, 21)
        Me.SearchChgCode.Name = "SearchChgCode"
        Me.SearchChgCode.Size = New System.Drawing.Size(347, 21)
        Me.SearchChgCode.TabIndex = 2
        '
        'ClientID
        '
        Me.ClientID.ClientID = New System.Guid("00000000-0000-0000-0000-000000000000")
        Me.ClientID.ClientName = ""
        Me.ClientID.Location = New System.Drawing.Point(98, 364)
        Me.ClientID.Name = "ClientID"
        Me.ClientID.Size = New System.Drawing.Size(355, 28)
        Me.ClientID.TabIndex = 35
        '
        'Port
        '
        Me.Port.Location = New System.Drawing.Point(104, 100)
        Me.Port.Name = "Port"
        Me.Port.PortCode = ""
        Me.Port.Size = New System.Drawing.Size(265, 23)
        Me.Port.TabIndex = 3
        '
        'Toll
        '
        Me.Toll.CtrlValue = 0
        Me.Toll.Location = New System.Drawing.Point(196, 309)
        Me.Toll.Name = "Toll"
        Me.Toll.Size = New System.Drawing.Size(49, 21)
        Me.Toll.TabIndex = 14
        '
        'Tax
        '
        Me.Tax.CtrlValue = 0
        Me.Tax.Location = New System.Drawing.Point(102, 309)
        Me.Tax.Name = "Tax"
        Me.Tax.Size = New System.Drawing.Size(54, 21)
        Me.Tax.TabIndex = 13
        '
        'ImportExport
        '
        Me.ImportExport.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ImportExport.Code = ""
        Me.ImportExport.CustomShowAll = False
        Me.ImportExport.Location = New System.Drawing.Point(101, 48)
        Me.ImportExport.Name = "ImportExport"
        Me.ImportExport.Size = New System.Drawing.Size(142, 21)
        Me.ImportExport.TabIndex = 1
        '
        'Seq
        '
        Me.Seq.CtrlValue = 0
        Me.Seq.Location = New System.Drawing.Point(101, 23)
        Me.Seq.Name = "Seq"
        Me.Seq.Size = New System.Drawing.Size(55, 21)
        Me.Seq.TabIndex = 0
        '
        'Condition
        '
        Me.Condition.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Condition.Code = ""
        Me.Condition.CustomShowAll = False
        Me.Condition.Location = New System.Drawing.Point(101, 285)
        Me.Condition.Name = "Condition"
        Me.Condition.Size = New System.Drawing.Size(144, 21)
        Me.Condition.TabIndex = 12
        '
        'Description
        '
        Me.Description.AutoComplete = False
        Me.Description.AutoCompleteColumnName = Nothing
        Me.Description.AutoCompleteExtraWhere = Nothing
        Me.Description.AutoCompleteTableName = Nothing
        Me.Description.BackColor = System.Drawing.Color.Transparent
        Me.Description.CustomMaxLength = CType(100, Byte)
        Me.Description.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Description.Location = New System.Drawing.Point(101, 336)
        Me.Description.Name = "Description"
        Me.Description.Size = New System.Drawing.Size(247, 21)
        Me.Description.TabIndex = 15
        Me.Description.TextValue = ""
        '
        'DefaultAmount
        '
        Me.DefaultAmount.CtrlValue = 0
        Me.DefaultAmount.Location = New System.Drawing.Point(101, 256)
        Me.DefaultAmount.Name = "DefaultAmount"
        Me.DefaultAmount.Size = New System.Drawing.Size(144, 23)
        Me.DefaultAmount.TabIndex = 10
        '
        'CurCode
        '
        Me.CurCode.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CurCode.Code = ""
        Me.CurCode.CustomShowAll = False
        Me.CurCode.Location = New System.Drawing.Point(101, 230)
        Me.CurCode.Name = "CurCode"
        Me.CurCode.Size = New System.Drawing.Size(144, 21)
        Me.CurCode.TabIndex = 9
        '
        'BaseOn
        '
        Me.BaseOn.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BaseOn.Code = ""
        Me.BaseOn.CustomShowAll = False
        Me.BaseOn.Location = New System.Drawing.Point(101, 205)
        Me.BaseOn.Name = "BaseOn"
        Me.BaseOn.Size = New System.Drawing.Size(144, 21)
        Me.BaseOn.TabIndex = 8
        '
        'ChargeItem
        '
        Me.ChargeItem.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ChargeItem.Code = ""
        Me.ChargeItem.CustomShowAll = False
        Me.ChargeItem.Location = New System.Drawing.Point(101, 128)
        Me.ChargeItem.Name = "ChargeItem"
        Me.ChargeItem.Size = New System.Drawing.Size(214, 21)
        Me.ChargeItem.TabIndex = 4
        '
        'GeneralForms
        '
        Me.GeneralForms.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GeneralForms.Location = New System.Drawing.Point(0, 0)
        Me.GeneralForms.Name = "GeneralForms"
        Me.GeneralForms.ShowHistoryButtom = False
        Me.GeneralForms.ShowNavigate = False
        Me.GeneralForms.ShowPrintButtom = False
        Me.GeneralForms.Size = New System.Drawing.Size(1098, 671)
        Me.GeneralForms.TabIndex = 0
        '
        'FrmBLCharges
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1098, 671)
        Me.Controls.Add(Me.UltraGroupBox2)
        Me.Controls.Add(Me.GeneralForms)
        Me.Name = "FrmBLCharges"
        Me.Text = "B/Ls Charges"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        CType(Me.GridDetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSetForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        CType(Me.DropDownCondition, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DividInLCL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IsDeposit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Validity, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ApplyDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridCharges, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DropDownSOC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DropDownShipmentType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DropDownImco, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DropDownType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DropDownIsFull, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FormErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox2.ResumeLayout(False)
        Me.UltraGroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GeneralForms As Shipping.UserGeneralForms
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents GridDetails As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents SearchChgCode As Shipping.UserComboCode
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents DataSetForm As System.Data.DataSet
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
    Friend WithEvents DataTable2 As System.Data.DataTable
    Friend WithEvents DataColumn12 As System.Data.DataColumn
    Friend WithEvents DataColumn13 As System.Data.DataColumn
    Friend WithEvents DataColumn14 As System.Data.DataColumn
    Friend WithEvents DataColumn15 As System.Data.DataColumn
    Friend WithEvents DataColumn16 As System.Data.DataColumn
    Friend WithEvents DataColumn17 As System.Data.DataColumn
    Friend WithEvents Validity As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents ApplyDate As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents IsDeposit As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents ChargeItem As Shipping.UserComboCode
    Friend WithEvents DefaultAmount As Shipping.UserNum
    Friend WithEvents CurCode As Shipping.UserComboCode
    Friend WithEvents BaseOn As Shipping.UserComboCode
    Friend WithEvents Description As Shipping.UserText
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents LblCharge As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel8 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents GridCharges As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents DividInLCL As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents DropDownSOC As Infragistics.Win.UltraWinGrid.UltraDropDown
    Friend WithEvents DropDownShipmentType As Infragistics.Win.UltraWinGrid.UltraDropDown
    Friend WithEvents DropDownImco As Infragistics.Win.UltraWinGrid.UltraDropDown
    Friend WithEvents DropDownType As Infragistics.Win.UltraWinGrid.UltraDropDown
    Friend WithEvents DataColumn10 As System.Data.DataColumn
    Friend WithEvents DataColumn18 As System.Data.DataColumn
    Friend WithEvents DataColumn19 As System.Data.DataColumn
    Friend WithEvents DataColumn20 As System.Data.DataColumn
    Friend WithEvents DropDownIsFull As Infragistics.Win.UltraWinGrid.UltraDropDown
    Friend WithEvents FormErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents UltraLabel6 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Condition As Shipping.UserComboCode
    Friend WithEvents DataColumn11 As System.Data.DataColumn
    Friend WithEvents DataColumn21 As System.Data.DataColumn
    Friend WithEvents DropDownCondition As Infragistics.Win.UltraWinGrid.UltraDropDown
    Friend WithEvents UltraLabel7 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Seq As Shipping.UserNum
    Friend WithEvents UltraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents UltraLabel9 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents ImportExport As Shipping.UserComboCode
    Friend WithEvents UltraLabel11 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel10 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Toll As Shipping.UserNum
    Friend WithEvents Tax As Shipping.UserNum
    Friend WithEvents UltraLabel12 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Line As System.Windows.Forms.ComboBox
    Friend WithEvents UltraLabel13 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Port As Shipping.UserPortCode
    Friend WithEvents UltraLabel14 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents ClientID As Shipping.UserClientText
    Friend WithEvents ButtonExcel As System.Windows.Forms.Button
End Class
