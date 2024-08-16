Imports ShippingBiz
Imports OrmLib
Public Class FrmVesselList
    Inherits CLGeneralForm

    Private ItemLevel As String = "401"
    Private FrmStaus As FormStatus
    Private Dm As ShippingBiz.DataManager
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents VesselText As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GridVessels As Infragistics.Win.UltraWinGrid.UltraGrid
    Private Vesseldata As TB_Vessels
    Private Sub FrmVesselList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dm = New ShippingBiz.DataManager(My.Settings.DSN)
        Me.InitControl("VESSEL DATA", ItemLevel)
        'Me.VesselCode.SetLength(4)
        'Me.VesselName.SetLength(30)
        'Me.DeadWeight.InitControl(6, 2)
        'Me.Capacity.InitControl(6, 0)
        'Me.GW.InitControl(10, 2)
        'Me.NET.InitControl(10, 2)
        'Me.Speed.InitControl(3, 1)
        'Me.OfficeCalNo.SetLength(10)
        'Me.CalLetter.SetLength(10)
        'Me.BuiltDate.InitControl(False, False)
        'Me.Nationality.InitControl("CY", UserComboCode.ShowCoumn.Meaning)
        'Me.VesselAccount.SetLength(25)
        Me.Top = 0
        Me.Left = 0

        LockStatus(False)
        FrmStaus = FormStatus.NoAction
        General.GnrlFormKeyStatusChange(Me.MenuStrip, FormStatus.NoAction)

        Me.BackColor = My.Settings.MainColor
        
        'For Each Ctl As Object In GroupBox.Controls
        '    Try
        '        If TypeOf Ctl Is Windows.Forms.TextBox Then
        '            Ctl.backcolor = My.Settings.MainColor
        '            Ctl.forecolor = My.Settings.LableForeColor
        '        End If
        '        If TypeOf Ctl Is Infragistics.Win.Misc.UltraLabel Then
        '            Ctl.Appearance.backcolor = My.Settings.MainColor
        '            Ctl.Appearance.ForeColor = My.Settings.LableForeColor
        '        End If
        '    Catch ex As Exception
        '    End Try
        'Next
        'Me.UltraGroupBox1.Appearance.BackColor = Color.Gainsboro

    End Sub
    Private Sub LockStatus(ByVal Status As Boolean)

    End Sub
    Private Sub InitializeComponent()
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.VesselText = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GridVessels = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.GridVessels, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox2, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 35)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(428, 428)
        Me.TableLayoutPanel1.TabIndex = 4
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.VesselText)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(422, 44)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filter "
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.GridVessels)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(3, 53)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(422, 372)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Vessels List"
        '
        'VesselText
        '
        Me.VesselText.Location = New System.Drawing.Point(111, 16)
        Me.VesselText.Name = "VesselText"
        Me.VesselText.Size = New System.Drawing.Size(186, 20)
        Me.VesselText.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(36, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Vessel Name"
        '
        'GridVessels
        '
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.GridVessels.DisplayLayout.Appearance = Appearance1
        Me.GridVessels.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.GridVessels.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.SystemColors.Window
        Me.GridVessels.DisplayLayout.GroupByBox.Appearance = Appearance2
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.GridVessels.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
        Me.GridVessels.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance4.BackColor2 = System.Drawing.SystemColors.Control
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.GridVessels.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
        Me.GridVessels.DisplayLayout.MaxColScrollRegions = 1
        Me.GridVessels.DisplayLayout.MaxRowScrollRegions = 1
        Appearance5.BackColor = System.Drawing.SystemColors.Window
        Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GridVessels.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.SystemColors.Highlight
        Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.GridVessels.DisplayLayout.Override.ActiveRowAppearance = Appearance6
        Me.GridVessels.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.GridVessels.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Me.GridVessels.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.GridVessels.DisplayLayout.Override.CellAppearance = Appearance8
        Me.GridVessels.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.GridVessels.DisplayLayout.Override.CellPadding = 0
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.GridVessels.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance10.TextHAlign = Infragistics.Win.HAlign.Left
        Me.GridVessels.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.GridVessels.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.GridVessels.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Me.GridVessels.DisplayLayout.Override.RowAppearance = Appearance11
        Me.GridVessels.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
        Me.GridVessels.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
        Me.GridVessels.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.GridVessels.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.GridVessels.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.GridVessels.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridVessels.Location = New System.Drawing.Point(3, 16)
        Me.GridVessels.Name = "GridVessels"
        Me.GridVessels.Size = New System.Drawing.Size(416, 353)
        Me.GridVessels.TabIndex = 0
        Me.GridVessels.Text = "UltraGrid1"
        '
        'FrmVesselList
        '
        Me.ClientSize = New System.Drawing.Size(428, 463)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "FrmVesselList"
        Me.Controls.SetChildIndex(Me.TableLayoutPanel1, 0)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.GridVessels, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Private Sub FrmVesselList_ToolStripClick() Handles Me.ToolStripClick

    End Sub
End Class
