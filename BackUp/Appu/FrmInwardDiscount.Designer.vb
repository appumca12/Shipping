<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmInwardDiscount
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
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.LinesGroupDetail = New Infragistics.Win.Misc.UltraGroupBox
        Me.FreeTime = New Shipping.UserFreeTime
        Me.UltraExpandableGroupBox1 = New Infragistics.Win.Misc.UltraExpandableGroupBox
        Me.UltraExpandableGroupBoxPanel1 = New Infragistics.Win.Misc.UltraExpandableGroupBoxPanel
        Me.NoTax = New Shipping.UserComboCode
        Me.DetentionID = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.IsFDaysAsDiscount = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.dAmount = New Shipping.UserNum
        Me.dPercent = New Shipping.UserNum
        Me.dFreeDays = New Shipping.UserNum
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel
        Me.LblName = New Infragistics.Win.Misc.UltraLabel
        Me.LabelBL = New Infragistics.Win.Misc.UltraLabel
        Me.BLNO = New Shipping.UserText
        Me.GeneralForms = New Shipping.UserGeneralForms
        Me.PopupControl = New Infragistics.Win.Misc.UltraPopupControlContainer(Me.components)
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.LinesGroupDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LinesGroupDetail.SuspendLayout()
        CType(Me.UltraExpandableGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraExpandableGroupBox1.SuspendLayout()
        Me.UltraExpandableGroupBoxPanel1.SuspendLayout()
        CType(Me.DetentionID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IsFDaysAsDiscount, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.LinesGroupDetail)
        Me.UltraGroupBox1.Location = New System.Drawing.Point(12, 81)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(402, 289)
        Me.UltraGroupBox1.TabIndex = 18
        Me.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.VisualStudio2005
        '
        'LinesGroupDetail
        '
        Me.LinesGroupDetail.Controls.Add(Me.UltraExpandableGroupBox1)
        Me.LinesGroupDetail.Controls.Add(Me.IsFDaysAsDiscount)
        Me.LinesGroupDetail.Controls.Add(Me.dAmount)
        Me.LinesGroupDetail.Controls.Add(Me.dPercent)
        Me.LinesGroupDetail.Controls.Add(Me.dFreeDays)
        Me.LinesGroupDetail.Controls.Add(Me.UltraLabel4)
        Me.LinesGroupDetail.Controls.Add(Me.UltraLabel3)
        Me.LinesGroupDetail.Controls.Add(Me.LblName)
        Me.LinesGroupDetail.Location = New System.Drawing.Point(13, 16)
        Me.LinesGroupDetail.Name = "LinesGroupDetail"
        Me.LinesGroupDetail.Size = New System.Drawing.Size(371, 250)
        Me.LinesGroupDetail.TabIndex = 10
        Me.LinesGroupDetail.Text = "Discount Details"
        '
        'FreeTime
        '
        Me.FreeTime.Location = New System.Drawing.Point(165, 40)
        Me.FreeTime.Name = "FreeTime"
        Me.FreeTime.Size = New System.Drawing.Size(326, 370)
        Me.FreeTime.TabIndex = 15
        Me.FreeTime.Visible = False
        '
        'UltraExpandableGroupBox1
        '
        Me.UltraExpandableGroupBox1.Controls.Add(Me.UltraExpandableGroupBoxPanel1)
        Me.UltraExpandableGroupBox1.ExpandedSize = New System.Drawing.Size(270, 89)
        Me.UltraExpandableGroupBox1.Location = New System.Drawing.Point(23, 146)
        Me.UltraExpandableGroupBox1.Name = "UltraExpandableGroupBox1"
        Me.UltraExpandableGroupBox1.Size = New System.Drawing.Size(270, 89)
        Me.UltraExpandableGroupBox1.TabIndex = 14
        Me.UltraExpandableGroupBox1.Text = "Special Calculation "
        '
        'UltraExpandableGroupBoxPanel1
        '
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.NoTax)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.DetentionID)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.UltraLabel1)
        Me.UltraExpandableGroupBoxPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraExpandableGroupBoxPanel1.Location = New System.Drawing.Point(3, 19)
        Me.UltraExpandableGroupBoxPanel1.Name = "UltraExpandableGroupBoxPanel1"
        Me.UltraExpandableGroupBoxPanel1.Size = New System.Drawing.Size(264, 67)
        Me.UltraExpandableGroupBoxPanel1.TabIndex = 0
        '
        'NoTax
        '
        Me.NoTax.BackColor = System.Drawing.Color.WhiteSmoke
        Me.NoTax.Code = ""
        Me.NoTax.CustomShowAll = False
        Me.NoTax.Location = New System.Drawing.Point(86, 36)
        Me.NoTax.Name = "NoTax"
        Me.NoTax.Size = New System.Drawing.Size(166, 22)
        Me.NoTax.TabIndex = 1
        '
        'DetentionID
        '
        Me.DetentionID.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.DetentionID.AutoSuggestFilterMode = Infragistics.Win.AutoSuggestFilterMode.StartsWith
        Me.DetentionID.CheckedListSettings.CheckStateMember = ""
        Appearance4.BackColor = System.Drawing.SystemColors.Window
        Appearance4.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.DetentionID.DisplayLayout.Appearance = Appearance4
        Me.DetentionID.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.DetentionID.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance1.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance1.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance1.BorderColor = System.Drawing.SystemColors.Window
        Me.DetentionID.DisplayLayout.GroupByBox.Appearance = Appearance1
        Appearance2.ForeColor = System.Drawing.SystemColors.GrayText
        Me.DetentionID.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance2
        Me.DetentionID.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance3.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance3.BackColor2 = System.Drawing.SystemColors.Control
        Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.DetentionID.DisplayLayout.GroupByBox.PromptAppearance = Appearance3
        Me.DetentionID.DisplayLayout.MaxColScrollRegions = 1
        Me.DetentionID.DisplayLayout.MaxRowScrollRegions = 1
        Appearance12.BackColor = System.Drawing.SystemColors.Window
        Appearance12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DetentionID.DisplayLayout.Override.ActiveCellAppearance = Appearance12
        Appearance7.BackColor = System.Drawing.SystemColors.Highlight
        Appearance7.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.DetentionID.DisplayLayout.Override.ActiveRowAppearance = Appearance7
        Me.DetentionID.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.DetentionID.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance6.BackColor = System.Drawing.SystemColors.Window
        Me.DetentionID.DisplayLayout.Override.CardAreaAppearance = Appearance6
        Appearance5.BorderColor = System.Drawing.Color.Silver
        Appearance5.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.DetentionID.DisplayLayout.Override.CellAppearance = Appearance5
        Me.DetentionID.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.DetentionID.DisplayLayout.Override.CellPadding = 0
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.DetentionID.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance11.TextHAlignAsString = "Left"
        Me.DetentionID.DisplayLayout.Override.HeaderAppearance = Appearance11
        Me.DetentionID.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.DetentionID.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance10.BackColor = System.Drawing.SystemColors.Window
        Appearance10.BorderColor = System.Drawing.Color.Silver
        Me.DetentionID.DisplayLayout.Override.RowAppearance = Appearance10
        Me.DetentionID.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance8.BackColor = System.Drawing.SystemColors.ControlLight
        Me.DetentionID.DisplayLayout.Override.TemplateAddRowAppearance = Appearance8
        Me.DetentionID.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.DetentionID.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.DetentionID.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.DetentionID.Location = New System.Drawing.Point(12, 5)
        Me.DetentionID.Name = "DetentionID"
        Me.DetentionID.PreferredDropDownSize = New System.Drawing.Size(0, 0)
        Me.DetentionID.Size = New System.Drawing.Size(241, 22)
        Me.DetentionID.TabIndex = 0
        '
        'UltraLabel1
        '
        Me.UltraLabel1.Location = New System.Drawing.Point(13, 39)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(67, 18)
        Me.UltraLabel1.TabIndex = 12
        Me.UltraLabel1.Text = "No Tax"
        '
        'IsFDaysAsDiscount
        '
        Me.IsFDaysAsDiscount.Location = New System.Drawing.Point(210, 31)
        Me.IsFDaysAsDiscount.Name = "IsFDaysAsDiscount"
        Me.IsFDaysAsDiscount.Size = New System.Drawing.Size(83, 20)
        Me.IsFDaysAsDiscount.TabIndex = 1
        Me.IsFDaysAsDiscount.Text = "As Discount"
        '
        'dAmount
        '
        Me.dAmount.CtrlValue = 0
        Me.dAmount.Location = New System.Drawing.Point(84, 88)
        Me.dAmount.Name = "dAmount"
        Me.dAmount.Size = New System.Drawing.Size(104, 23)
        Me.dAmount.TabIndex = 3
        '
        'dPercent
        '
        Me.dPercent.CtrlValue = 0
        Me.dPercent.Location = New System.Drawing.Point(84, 57)
        Me.dPercent.Name = "dPercent"
        Me.dPercent.Size = New System.Drawing.Size(104, 23)
        Me.dPercent.TabIndex = 2
        '
        'dFreeDays
        '
        Me.dFreeDays.CtrlValue = 0
        Me.dFreeDays.Location = New System.Drawing.Point(84, 28)
        Me.dFreeDays.Name = "dFreeDays"
        Me.dFreeDays.Size = New System.Drawing.Size(104, 23)
        Me.dFreeDays.TabIndex = 0
        '
        'UltraLabel4
        '
        Me.UltraLabel4.Location = New System.Drawing.Point(23, 88)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.Size = New System.Drawing.Size(67, 18)
        Me.UltraLabel4.TabIndex = 12
        Me.UltraLabel4.Text = "Amount"
        '
        'UltraLabel3
        '
        Me.UltraLabel3.Location = New System.Drawing.Point(23, 61)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(67, 20)
        Me.UltraLabel3.TabIndex = 11
        Me.UltraLabel3.Text = "Percent"
        '
        'LblName
        '
        Me.LblName.Location = New System.Drawing.Point(23, 32)
        Me.LblName.Name = "LblName"
        Me.LblName.Size = New System.Drawing.Size(67, 19)
        Me.LblName.TabIndex = 8
        Me.LblName.Text = "Free Days"
        '
        'LabelBL
        '
        Appearance13.BackColor = System.Drawing.Color.Transparent
        Appearance13.BackColor2 = System.Drawing.Color.Transparent
        Appearance13.BackColorDisabled = System.Drawing.Color.Transparent
        Appearance13.BackColorDisabled2 = System.Drawing.Color.Transparent
        Me.LabelBL.Appearance = Appearance13
        Me.LabelBL.Location = New System.Drawing.Point(12, 51)
        Me.LabelBL.Name = "LabelBL"
        Me.LabelBL.Size = New System.Drawing.Size(51, 17)
        Me.LabelBL.TabIndex = 20
        Me.LabelBL.Text = "B/L No"
        '
        'BLNO
        '
        Me.BLNO.AutoComplete = False
        Me.BLNO.AutoCompleteColumnName = Nothing
        Me.BLNO.AutoCompleteExtraWhere = Nothing
        Me.BLNO.AutoCompleteTableName = Nothing
        Me.BLNO.BackColor = System.Drawing.Color.Transparent
        Me.BLNO.CustomMaxLength = CType(100, Byte)
        Me.BLNO.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BLNO.Location = New System.Drawing.Point(75, 49)
        Me.BLNO.Name = "BLNO"
        Me.BLNO.Size = New System.Drawing.Size(276, 22)
        Me.BLNO.TabIndex = 0
        Me.BLNO.TextValue = ""
        '
        'GeneralForms
        '
        Me.GeneralForms.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GeneralForms.Location = New System.Drawing.Point(0, 0)
        Me.GeneralForms.Name = "GeneralForms"
        Me.GeneralForms.ShowHistoryButtom = False
        Me.GeneralForms.ShowNavigate = False
        Me.GeneralForms.ShowPrintButtom = False
        Me.GeneralForms.Size = New System.Drawing.Size(436, 393)
        Me.GeneralForms.TabIndex = 0
        '
        'PopupControl
        '
        Me.PopupControl.PopupControl = Me.FreeTime
        Me.PopupControl.PreferredDropDownSize = New System.Drawing.Size(0, 0)
        '
        'FrmInwardDiscount
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(436, 393)
        Me.Controls.Add(Me.FreeTime)
        Me.Controls.Add(Me.BLNO)
        Me.Controls.Add(Me.LabelBL)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Controls.Add(Me.GeneralForms)
        Me.Name = "FrmInwardDiscount"
        Me.Text = "Inward Discount"
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        CType(Me.LinesGroupDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LinesGroupDetail.ResumeLayout(False)
        CType(Me.UltraExpandableGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraExpandableGroupBox1.ResumeLayout(False)
        Me.UltraExpandableGroupBoxPanel1.ResumeLayout(False)
        Me.UltraExpandableGroupBoxPanel1.PerformLayout()
        CType(Me.DetentionID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IsFDaysAsDiscount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GeneralForms As Shipping.UserGeneralForms
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents LinesGroupDetail As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents LblName As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents BLNO As Shipping.UserText
    Friend WithEvents LabelBL As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents dAmount As Shipping.UserNum
    Friend WithEvents dPercent As Shipping.UserNum
    Friend WithEvents dFreeDays As Shipping.UserNum
    Friend WithEvents IsFDaysAsDiscount As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents UltraExpandableGroupBox1 As Infragistics.Win.Misc.UltraExpandableGroupBox
    Friend WithEvents UltraExpandableGroupBoxPanel1 As Infragistics.Win.Misc.UltraExpandableGroupBoxPanel
    Friend WithEvents DetentionID As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents NoTax As Shipping.UserComboCode
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents FreeTime As Shipping.UserFreeTime
    Friend WithEvents PopupControl As Infragistics.Win.Misc.UltraPopupControlContainer
End Class
