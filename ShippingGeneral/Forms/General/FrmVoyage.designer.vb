<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmVoyage
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
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
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
        Me.GroupBox = New Infragistics.Win.Misc.UltraGroupBox
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel35 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel34 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel23 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel22 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel21 = New Infragistics.Win.Misc.UltraLabel
        Me.lbl = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.ErrProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GridSof = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ButtonSofNew = New System.Windows.Forms.ToolStripButton
        Me.ButtonSofEdit = New System.Windows.Forms.ToolStripButton
        Me.ButtonDelete = New System.Windows.Forms.ToolStripButton
        Me.TFCCode = New Shipping.UserText
        Me.VoyageAccount = New Shipping.UserText
        Me.ExchangeThc = New Shipping.UserNum
        Me.ExchangeFrt = New Shipping.UserNum
        Me.Vessel = New Shipping.UserComboVessel
        Me.Carrier = New Shipping.UserComboCode
        Me.Service = New Shipping.UserComboCode
        Me.StartDate = New Shipping.UserGnrlDate
        Me.VoyageNo = New Shipping.UserText
        Me.GeneralForms = New Shipping.UserGeneralForms
        CType(Me.GroupBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox.SuspendLayout()
        CType(Me.ErrProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.GridSof, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
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
        Me.GroupBox.Controls.Add(Me.TFCCode)
        Me.GroupBox.Controls.Add(Me.UltraLabel3)
        Me.GroupBox.Controls.Add(Me.VoyageAccount)
        Me.GroupBox.Controls.Add(Me.UltraLabel2)
        Me.GroupBox.Controls.Add(Me.UltraLabel35)
        Me.GroupBox.Controls.Add(Me.UltraLabel34)
        Me.GroupBox.Controls.Add(Me.ExchangeThc)
        Me.GroupBox.Controls.Add(Me.ExchangeFrt)
        Me.GroupBox.Controls.Add(Me.Vessel)
        Me.GroupBox.Controls.Add(Me.UltraLabel23)
        Me.GroupBox.Controls.Add(Me.UltraLabel22)
        Me.GroupBox.Controls.Add(Me.Carrier)
        Me.GroupBox.Controls.Add(Me.UltraLabel21)
        Me.GroupBox.Controls.Add(Me.Service)
        Me.GroupBox.Controls.Add(Me.StartDate)
        Me.GroupBox.Controls.Add(Me.VoyageNo)
        Me.GroupBox.Controls.Add(Me.lbl)
        Me.GroupBox.Controls.Add(Me.UltraLabel1)
        Me.GroupBox.Location = New System.Drawing.Point(14, 14)
        Me.GroupBox.Name = "GroupBox"
        Me.GroupBox.Size = New System.Drawing.Size(608, 117)
        Me.GroupBox.TabIndex = 0
        '
        'UltraLabel3
        '
        Appearance2.BackHatchStyle = Infragistics.Win.BackHatchStyle.None
        Me.UltraLabel3.Appearance = Appearance2
        Me.UltraLabel3.BackColorInternal = System.Drawing.Color.CornflowerBlue
        Me.UltraLabel3.Location = New System.Drawing.Point(420, 76)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(52, 17)
        Me.UltraLabel3.TabIndex = 33
        Me.UltraLabel3.Text = "TFC"
        '
        'UltraLabel2
        '
        Appearance22.BackHatchStyle = Infragistics.Win.BackHatchStyle.None
        Me.UltraLabel2.Appearance = Appearance22
        Me.UltraLabel2.BackColorInternal = System.Drawing.Color.CornflowerBlue
        Me.UltraLabel2.Location = New System.Drawing.Point(420, 49)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(52, 17)
        Me.UltraLabel2.TabIndex = 33
        Me.UltraLabel2.Text = "Account"
        '
        'UltraLabel35
        '
        Appearance3.BackHatchStyle = Infragistics.Win.BackHatchStyle.None
        Me.UltraLabel35.Appearance = Appearance3
        Me.UltraLabel35.BackColorInternal = System.Drawing.Color.CornflowerBlue
        Me.UltraLabel35.Location = New System.Drawing.Point(233, 77)
        Me.UltraLabel35.Name = "UltraLabel35"
        Me.UltraLabel35.Size = New System.Drawing.Size(62, 18)
        Me.UltraLabel35.TabIndex = 31
        Me.UltraLabel35.Text = "THC.Exchg"
        '
        'UltraLabel34
        '
        Appearance4.BackHatchStyle = Infragistics.Win.BackHatchStyle.None
        Me.UltraLabel34.Appearance = Appearance4
        Me.UltraLabel34.BackColorInternal = System.Drawing.Color.CornflowerBlue
        Me.UltraLabel34.Location = New System.Drawing.Point(18, 77)
        Me.UltraLabel34.Name = "UltraLabel34"
        Me.UltraLabel34.Size = New System.Drawing.Size(53, 18)
        Me.UltraLabel34.TabIndex = 30
        Me.UltraLabel34.Text = "Frt.Exchg"
        '
        'UltraLabel23
        '
        Appearance5.BackHatchStyle = Infragistics.Win.BackHatchStyle.None
        Me.UltraLabel23.Appearance = Appearance5
        Me.UltraLabel23.BackColorInternal = System.Drawing.Color.CornflowerBlue
        Me.UltraLabel23.Location = New System.Drawing.Point(233, 54)
        Me.UltraLabel23.Name = "UltraLabel23"
        Me.UltraLabel23.Size = New System.Drawing.Size(52, 17)
        Me.UltraLabel23.TabIndex = 26
        Me.UltraLabel23.Text = "Start"
        '
        'UltraLabel22
        '
        Appearance6.BackHatchStyle = Infragistics.Win.BackHatchStyle.None
        Me.UltraLabel22.Appearance = Appearance6
        Me.UltraLabel22.BackColorInternal = System.Drawing.Color.CornflowerBlue
        Me.UltraLabel22.Location = New System.Drawing.Point(18, 53)
        Me.UltraLabel22.Name = "UltraLabel22"
        Me.UltraLabel22.Size = New System.Drawing.Size(39, 18)
        Me.UltraLabel22.TabIndex = 25
        Me.UltraLabel22.Text = "Carrier"
        '
        'UltraLabel21
        '
        Appearance7.BackHatchStyle = Infragistics.Win.BackHatchStyle.None
        Me.UltraLabel21.Appearance = Appearance7
        Me.UltraLabel21.BackColorInternal = System.Drawing.Color.CornflowerBlue
        Me.UltraLabel21.Location = New System.Drawing.Point(420, 25)
        Me.UltraLabel21.Name = "UltraLabel21"
        Me.UltraLabel21.Size = New System.Drawing.Size(47, 18)
        Me.UltraLabel21.TabIndex = 23
        Me.UltraLabel21.Text = "Service"
        '
        'lbl
        '
        Appearance8.BackHatchStyle = Infragistics.Win.BackHatchStyle.None
        Me.lbl.Appearance = Appearance8
        Me.lbl.BackColorInternal = System.Drawing.Color.CornflowerBlue
        Me.lbl.Location = New System.Drawing.Point(18, 21)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(71, 15)
        Me.lbl.TabIndex = 9
        Me.lbl.Text = "Vessel"
        '
        'UltraLabel1
        '
        Appearance9.BackHatchStyle = Infragistics.Win.BackHatchStyle.None
        Me.UltraLabel1.Appearance = Appearance9
        Me.UltraLabel1.BackColorInternal = System.Drawing.Color.CornflowerBlue
        Me.UltraLabel1.Location = New System.Drawing.Point(233, 23)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(52, 17)
        Me.UltraLabel1.TabIndex = 20
        Me.UltraLabel1.Text = "Voyage"
        '
        'ErrProvider
        '
        Me.ErrProvider.ContainerControl = Me
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.GroupBox1)
        Me.UltraGroupBox1.Controls.Add(Me.GroupBox)
        Me.UltraGroupBox1.Location = New System.Drawing.Point(12, 48)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(642, 559)
        Me.UltraGroupBox1.TabIndex = 4
        Me.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.VisualStudio2005
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GridSof)
        Me.GroupBox1.Controls.Add(Me.ToolStrip1)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 140)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(606, 389)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "S.O.F. List"
        '
        'GridSof
        '
        Appearance10.BackColor = System.Drawing.SystemColors.Window
        Appearance10.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.GridSof.DisplayLayout.Appearance = Appearance10
        Me.GridSof.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.GridSof.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance11.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance11.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance11.BorderColor = System.Drawing.SystemColors.Window
        Me.GridSof.DisplayLayout.GroupByBox.Appearance = Appearance11
        Appearance12.ForeColor = System.Drawing.SystemColors.GrayText
        Me.GridSof.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance12
        Me.GridSof.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance13.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance13.BackColor2 = System.Drawing.SystemColors.Control
        Appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance13.ForeColor = System.Drawing.SystemColors.GrayText
        Me.GridSof.DisplayLayout.GroupByBox.PromptAppearance = Appearance13
        Me.GridSof.DisplayLayout.MaxColScrollRegions = 1
        Me.GridSof.DisplayLayout.MaxRowScrollRegions = 1
        Appearance14.BackColor = System.Drawing.SystemColors.Window
        Appearance14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GridSof.DisplayLayout.Override.ActiveCellAppearance = Appearance14
        Appearance15.BackColor = System.Drawing.SystemColors.Highlight
        Appearance15.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.GridSof.DisplayLayout.Override.ActiveRowAppearance = Appearance15
        Me.GridSof.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.GridSof.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance16.BackColor = System.Drawing.SystemColors.Window
        Me.GridSof.DisplayLayout.Override.CardAreaAppearance = Appearance16
        Appearance17.BorderColor = System.Drawing.Color.Silver
        Appearance17.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.GridSof.DisplayLayout.Override.CellAppearance = Appearance17
        Me.GridSof.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.GridSof.DisplayLayout.Override.CellPadding = 0
        Appearance18.BackColor = System.Drawing.SystemColors.Control
        Appearance18.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance18.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance18.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance18.BorderColor = System.Drawing.SystemColors.Window
        Me.GridSof.DisplayLayout.Override.GroupByRowAppearance = Appearance18
        Appearance19.TextHAlignAsString = "Left"
        Me.GridSof.DisplayLayout.Override.HeaderAppearance = Appearance19
        Me.GridSof.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.GridSof.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance20.BackColor = System.Drawing.SystemColors.Window
        Appearance20.BorderColor = System.Drawing.Color.Silver
        Me.GridSof.DisplayLayout.Override.RowAppearance = Appearance20
        Me.GridSof.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance21.BackColor = System.Drawing.SystemColors.ControlLight
        Me.GridSof.DisplayLayout.Override.TemplateAddRowAppearance = Appearance21
        Me.GridSof.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.GridSof.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.GridSof.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.GridSof.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridSof.Location = New System.Drawing.Point(3, 41)
        Me.GridSof.Name = "GridSof"
        Me.GridSof.Size = New System.Drawing.Size(600, 345)
        Me.GridSof.TabIndex = 0
        Me.GridSof.Text = "UltraGrid1"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ButtonSofNew, Me.ButtonSofEdit, Me.ButtonDelete})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 16)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(600, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ButtonSofNew
        '
        Me.ButtonSofNew.Image = Global.Shipping.My.Resources.Resources.add_24
        Me.ButtonSofNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonSofNew.Name = "ButtonSofNew"
        Me.ButtonSofNew.Size = New System.Drawing.Size(51, 22)
        Me.ButtonSofNew.Text = "New"
        '
        'ButtonSofEdit
        '
        Me.ButtonSofEdit.Image = Global.Shipping.My.Resources.Resources.edit_24
        Me.ButtonSofEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonSofEdit.Name = "ButtonSofEdit"
        Me.ButtonSofEdit.Size = New System.Drawing.Size(47, 22)
        Me.ButtonSofEdit.Text = "Edit"
        '
        'ButtonDelete
        '
        Me.ButtonDelete.Image = Global.Shipping.My.Resources.Resources.delete_24
        Me.ButtonDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonDelete.Name = "ButtonDelete"
        Me.ButtonDelete.Size = New System.Drawing.Size(60, 22)
        Me.ButtonDelete.Text = "Delete"
        '
        'TFCCode
        '
        Me.TFCCode.AutoComplete = False
        Me.TFCCode.BackColor = System.Drawing.Color.Transparent
        Me.TFCCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TFCCode.CustomMaxLength = CType(100, Byte)
        Me.TFCCode.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.TFCCode.Location = New System.Drawing.Point(468, 76)
        Me.TFCCode.Name = "TFCCode"
        Me.TFCCode.Size = New System.Drawing.Size(114, 21)
        Me.TFCCode.TabIndex = 5
        Me.TFCCode.TextValue = ""
        '
        'VoyageAccount
        '
        Me.VoyageAccount.AutoComplete = False
        Me.VoyageAccount.BackColor = System.Drawing.Color.Transparent
        Me.VoyageAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.VoyageAccount.CustomMaxLength = CType(100, Byte)
        Me.VoyageAccount.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.VoyageAccount.Location = New System.Drawing.Point(468, 49)
        Me.VoyageAccount.Name = "VoyageAccount"
        Me.VoyageAccount.Size = New System.Drawing.Size(114, 21)
        Me.VoyageAccount.TabIndex = 5
        Me.VoyageAccount.TextValue = ""
        '
        'ExchangeThc
        '
        Me.ExchangeThc.CtrlValue = 0
        Me.ExchangeThc.Location = New System.Drawing.Point(299, 75)
        Me.ExchangeThc.Name = "ExchangeThc"
        Me.ExchangeThc.Size = New System.Drawing.Size(113, 23)
        Me.ExchangeThc.TabIndex = 7
        '
        'ExchangeFrt
        '
        Me.ExchangeFrt.CtrlValue = 0
        Me.ExchangeFrt.Location = New System.Drawing.Point(71, 74)
        Me.ExchangeFrt.Name = "ExchangeFrt"
        Me.ExchangeFrt.Size = New System.Drawing.Size(101, 23)
        Me.ExchangeFrt.TabIndex = 6
        '
        'Vessel
        '
        Me.Vessel.Location = New System.Drawing.Point(71, 20)
        Me.Vessel.Name = "Vessel"
        Me.Vessel.Size = New System.Drawing.Size(156, 20)
        Me.Vessel.TabIndex = 0
        Me.Vessel.VesselID = New System.Guid("00000000-0000-0000-0000-000000000000")
        '
        'Carrier
        '
        Me.Carrier.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Carrier.Code = ""
        Me.Carrier.CustomShowAll = False
        Me.Carrier.Location = New System.Drawing.Point(71, 49)
        Me.Carrier.Name = "Carrier"
        Me.Carrier.Size = New System.Drawing.Size(156, 21)
        Me.Carrier.TabIndex = 3
        '
        'Service
        '
        Me.Service.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Service.Code = ""
        Me.Service.CustomShowAll = False
        Me.Service.Location = New System.Drawing.Point(468, 21)
        Me.Service.Name = "Service"
        Me.Service.Size = New System.Drawing.Size(127, 22)
        Me.Service.TabIndex = 2
        '
        'StartDate
        '
        Me.StartDate.DateValue = Nothing
        Me.StartDate.Location = New System.Drawing.Point(299, 49)
        Me.StartDate.Name = "StartDate"
        Me.StartDate.ShowTime = False
        Me.StartDate.Size = New System.Drawing.Size(114, 21)
        Me.StartDate.TabIndex = 4
        '
        'VoyageNo
        '
        Me.VoyageNo.AutoComplete = False
        Me.VoyageNo.BackColor = System.Drawing.Color.Transparent
        Me.VoyageNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.VoyageNo.CustomMaxLength = CType(100, Byte)
        Me.VoyageNo.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.VoyageNo.Location = New System.Drawing.Point(299, 21)
        Me.VoyageNo.Name = "VoyageNo"
        Me.VoyageNo.Size = New System.Drawing.Size(114, 21)
        Me.VoyageNo.TabIndex = 1
        Me.VoyageNo.TextValue = ""
        '
        'GeneralForms
        '
        Me.GeneralForms.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GeneralForms.Location = New System.Drawing.Point(0, 0)
        Me.GeneralForms.Name = "GeneralForms"
        Me.GeneralForms.ShowHistoryButtom = False
        Me.GeneralForms.ShowNavigate = False
        Me.GeneralForms.ShowPrintButtom = False
        Me.GeneralForms.Size = New System.Drawing.Size(672, 651)
        Me.GeneralForms.TabIndex = 3
        '
        'FrmVoyage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(672, 651)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Controls.Add(Me.GeneralForms)
        Me.Name = "FrmVoyage"
        Me.Text = "Voyage"
        CType(Me.GroupBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox.ResumeLayout(False)
        CType(Me.ErrProvider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.GridSof, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GeneralForms As Shipping.UserGeneralForms
    Friend WithEvents GroupBox As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents lbl As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents VoyageNo As Shipping.UserText
    Friend WithEvents ErrProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents StartDate As Shipping.UserGnrlDate
    Friend WithEvents UltraLabel21 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Service As Shipping.UserComboCode
    Friend WithEvents UltraLabel23 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel22 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Carrier As Shipping.UserComboCode
    Friend WithEvents Vessel As Shipping.UserComboVessel
    Friend WithEvents UltraLabel35 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel34 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents ExchangeThc As Shipping.UserNum
    Friend WithEvents ExchangeFrt As Shipping.UserNum
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GridSof As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ButtonSofNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents ButtonSofEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ButtonDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents VoyageAccount As Shipping.UserText
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents TFCCode As Shipping.UserText
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
End Class
