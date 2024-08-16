<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmVessels
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
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.GroupBox = New Infragistics.Win.Misc.UltraGroupBox
        Me.LineiD = New Shipping.UserComboCode
        Me.UltraLabel11 = New Infragistics.Win.Misc.UltraLabel
        Me.BuiltDate = New Shipping.UserGnrlDate
        Me.Capacity = New Shipping.UserNum
        Me.lbl = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel10 = New Infragistics.Win.Misc.UltraLabel
        Me.VesselCode = New Shipping.UserText
        Me.UltraLabel9 = New Infragistics.Win.Misc.UltraLabel
        Me.OfficeCalNo = New Shipping.UserText
        Me.UltraLabel8 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel7 = New Infragistics.Win.Misc.UltraLabel
        Me.GW = New Shipping.UserNum
        Me.Nationality = New Shipping.UserComboCode
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel
        Me.CalLetter = New Shipping.UserText
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel
        Me.Speed = New Shipping.UserNum
        Me.UltraLabel6 = New Infragistics.Win.Misc.UltraLabel
        Me.NET = New Shipping.UserNum
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel
        Me.VesselName = New Shipping.UserText
        Me.DeadWeight = New Shipping.UserNum
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.GeneralForms = New Shipping.UserGeneralForms
        Me.UltraLabel12 = New Infragistics.Win.Misc.UltraLabel
        Me.VesselAccount = New Shipping.UserText
        Me.UltraLabel13 = New Infragistics.Win.Misc.UltraLabel
        Me.IMONo = New Shipping.UserText
        CType(Me.GroupBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox.SuspendLayout()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox
        '
        Appearance1.BackColor = System.Drawing.Color.CornflowerBlue
        Appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance1.BorderColor = System.Drawing.Color.White
        Appearance1.BorderColor3DBase = System.Drawing.Color.White
        Me.GroupBox.Appearance = Appearance1
        Me.GroupBox.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.GroupBox.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.RectangularRaised
        Me.GroupBox.Controls.Add(Me.UltraLabel12)
        Me.GroupBox.Controls.Add(Me.VesselAccount)
        Me.GroupBox.Controls.Add(Me.UltraLabel13)
        Me.GroupBox.Controls.Add(Me.IMONo)
        Me.GroupBox.Controls.Add(Me.LineiD)
        Me.GroupBox.Controls.Add(Me.UltraLabel11)
        Me.GroupBox.Controls.Add(Me.BuiltDate)
        Me.GroupBox.Controls.Add(Me.Capacity)
        Me.GroupBox.Controls.Add(Me.lbl)
        Me.GroupBox.Controls.Add(Me.UltraLabel10)
        Me.GroupBox.Controls.Add(Me.VesselCode)
        Me.GroupBox.Controls.Add(Me.UltraLabel9)
        Me.GroupBox.Controls.Add(Me.OfficeCalNo)
        Me.GroupBox.Controls.Add(Me.UltraLabel8)
        Me.GroupBox.Controls.Add(Me.UltraLabel1)
        Me.GroupBox.Controls.Add(Me.UltraLabel7)
        Me.GroupBox.Controls.Add(Me.GW)
        Me.GroupBox.Controls.Add(Me.Nationality)
        Me.GroupBox.Controls.Add(Me.UltraLabel2)
        Me.GroupBox.Controls.Add(Me.UltraLabel3)
        Me.GroupBox.Controls.Add(Me.CalLetter)
        Me.GroupBox.Controls.Add(Me.UltraLabel4)
        Me.GroupBox.Controls.Add(Me.Speed)
        Me.GroupBox.Controls.Add(Me.UltraLabel6)
        Me.GroupBox.Controls.Add(Me.NET)
        Me.GroupBox.Controls.Add(Me.UltraLabel5)
        Me.GroupBox.Controls.Add(Me.VesselName)
        Me.GroupBox.Controls.Add(Me.DeadWeight)
        Me.GroupBox.Location = New System.Drawing.Point(22, 20)
        Me.GroupBox.Name = "GroupBox"
        Me.GroupBox.Size = New System.Drawing.Size(379, 389)
        Me.GroupBox.SupportThemes = False
        Me.GroupBox.TabIndex = 0
        '
        'LineiD
        '
        Me.LineiD.BackColor = System.Drawing.Color.WhiteSmoke
        Me.LineiD.Code = ""
        Me.LineiD.CustomShowAll = False
        Me.LineiD.Location = New System.Drawing.Point(125, 318)
        Me.LineiD.Name = "LineiD"
        Me.LineiD.Size = New System.Drawing.Size(89, 20)
        Me.LineiD.TabIndex = 12
        '
        'UltraLabel11
        '
        Appearance3.BackHatchStyle = Infragistics.Win.BackHatchStyle.None
        Me.UltraLabel11.Appearance = Appearance3
        Me.UltraLabel11.BackColor = System.Drawing.Color.CornflowerBlue
        Me.UltraLabel11.Location = New System.Drawing.Point(38, 318)
        Me.UltraLabel11.Name = "UltraLabel11"
        Me.UltraLabel11.Size = New System.Drawing.Size(81, 19)
        Me.UltraLabel11.TabIndex = 38
        Me.UltraLabel11.Text = "Action Vessel"
        '
        'BuiltDate
        '
        Me.BuiltDate.DateValue = Nothing
        Me.BuiltDate.Location = New System.Drawing.Point(125, 266)
        Me.BuiltDate.Name = "BuiltDate"
        Me.BuiltDate.ShowTime = False
        Me.BuiltDate.Size = New System.Drawing.Size(89, 21)
        Me.BuiltDate.TabIndex = 10
        '
        'Capacity
        '
        Me.Capacity.CtrlValue = 0
        Me.Capacity.Location = New System.Drawing.Point(125, 103)
        Me.Capacity.Name = "Capacity"
        Me.Capacity.Size = New System.Drawing.Size(89, 21)
        Me.Capacity.TabIndex = 4
        '
        'lbl
        '
        Appearance4.BackHatchStyle = Infragistics.Win.BackHatchStyle.None
        Me.lbl.Appearance = Appearance4
        Me.lbl.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbl.Location = New System.Drawing.Point(38, 22)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(71, 15)
        Me.lbl.TabIndex = 9
        Me.lbl.Text = "Vessel Code"
        '
        'UltraLabel10
        '
        Appearance5.BackHatchStyle = Infragistics.Win.BackHatchStyle.None
        Me.UltraLabel10.Appearance = Appearance5
        Me.UltraLabel10.BackColor = System.Drawing.Color.CornflowerBlue
        Me.UltraLabel10.Location = New System.Drawing.Point(38, 293)
        Me.UltraLabel10.Name = "UltraLabel10"
        Me.UltraLabel10.Size = New System.Drawing.Size(81, 19)
        Me.UltraLabel10.TabIndex = 37
        Me.UltraLabel10.Text = "Nationality"
        '
        'VesselCode
        '
        Me.VesselCode.BackColor = System.Drawing.Color.Transparent
        Me.VesselCode.CustomMaxLength = CType(100, Byte)
        Me.VesselCode.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.VesselCode.Location = New System.Drawing.Point(125, 22)
        Me.VesselCode.Name = "VesselCode"
        Me.VesselCode.Size = New System.Drawing.Size(56, 21)
        Me.VesselCode.TabIndex = 1
        Me.VesselCode.TextValue = ""
        '
        'UltraLabel9
        '
        Appearance6.BackHatchStyle = Infragistics.Win.BackHatchStyle.None
        Me.UltraLabel9.Appearance = Appearance6
        Me.UltraLabel9.BackColor = System.Drawing.Color.CornflowerBlue
        Me.UltraLabel9.Location = New System.Drawing.Point(38, 267)
        Me.UltraLabel9.Name = "UltraLabel9"
        Me.UltraLabel9.Size = New System.Drawing.Size(81, 19)
        Me.UltraLabel9.TabIndex = 36
        Me.UltraLabel9.Text = "Build Date"
        '
        'OfficeCalNo
        '
        Me.OfficeCalNo.BackColor = System.Drawing.Color.Transparent
        Me.OfficeCalNo.CustomMaxLength = CType(100, Byte)
        Me.OfficeCalNo.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.OfficeCalNo.Location = New System.Drawing.Point(125, 211)
        Me.OfficeCalNo.Name = "OfficeCalNo"
        Me.OfficeCalNo.Size = New System.Drawing.Size(89, 21)
        Me.OfficeCalNo.TabIndex = 8
        Me.OfficeCalNo.TextValue = ""
        '
        'UltraLabel8
        '
        Appearance7.BackHatchStyle = Infragistics.Win.BackHatchStyle.None
        Me.UltraLabel8.Appearance = Appearance7
        Me.UltraLabel8.BackColor = System.Drawing.Color.CornflowerBlue
        Me.UltraLabel8.Location = New System.Drawing.Point(38, 240)
        Me.UltraLabel8.Name = "UltraLabel8"
        Me.UltraLabel8.Size = New System.Drawing.Size(81, 19)
        Me.UltraLabel8.TabIndex = 35
        Me.UltraLabel8.Text = "Call Letter"
        '
        'UltraLabel1
        '
        Appearance8.BackHatchStyle = Infragistics.Win.BackHatchStyle.None
        Me.UltraLabel1.Appearance = Appearance8
        Me.UltraLabel1.BackColor = System.Drawing.Color.CornflowerBlue
        Me.UltraLabel1.Location = New System.Drawing.Point(38, 49)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(71, 15)
        Me.UltraLabel1.TabIndex = 20
        Me.UltraLabel1.Text = "Vessel Name"
        '
        'UltraLabel7
        '
        Appearance9.BackHatchStyle = Infragistics.Win.BackHatchStyle.None
        Me.UltraLabel7.Appearance = Appearance9
        Me.UltraLabel7.BackColor = System.Drawing.Color.CornflowerBlue
        Me.UltraLabel7.Location = New System.Drawing.Point(38, 213)
        Me.UltraLabel7.Name = "UltraLabel7"
        Me.UltraLabel7.Size = New System.Drawing.Size(81, 19)
        Me.UltraLabel7.TabIndex = 34
        Me.UltraLabel7.Text = "Office Call No."
        '
        'GW
        '
        Me.GW.CtrlValue = 0
        Me.GW.Location = New System.Drawing.Point(125, 130)
        Me.GW.Name = "GW"
        Me.GW.Size = New System.Drawing.Size(89, 21)
        Me.GW.TabIndex = 5
        '
        'Nationality
        '
        Me.Nationality.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Nationality.Code = ""
        Me.Nationality.CustomShowAll = False
        Me.Nationality.Location = New System.Drawing.Point(125, 293)
        Me.Nationality.Name = "Nationality"
        Me.Nationality.Size = New System.Drawing.Size(89, 22)
        Me.Nationality.TabIndex = 11
        '
        'UltraLabel2
        '
        Appearance10.BackHatchStyle = Infragistics.Win.BackHatchStyle.None
        Me.UltraLabel2.Appearance = Appearance10
        Me.UltraLabel2.BackColor = System.Drawing.Color.CornflowerBlue
        Me.UltraLabel2.Location = New System.Drawing.Point(38, 76)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(71, 15)
        Me.UltraLabel2.TabIndex = 21
        Me.UltraLabel2.Text = "Dead Weight"
        '
        'UltraLabel3
        '
        Appearance11.BackHatchStyle = Infragistics.Win.BackHatchStyle.None
        Me.UltraLabel3.Appearance = Appearance11
        Me.UltraLabel3.BackColor = System.Drawing.Color.CornflowerBlue
        Me.UltraLabel3.Location = New System.Drawing.Point(38, 103)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(71, 15)
        Me.UltraLabel3.TabIndex = 22
        Me.UltraLabel3.Text = "Capacity"
        '
        'CalLetter
        '
        Me.CalLetter.BackColor = System.Drawing.Color.Transparent
        Me.CalLetter.CustomMaxLength = CType(100, Byte)
        Me.CalLetter.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.CalLetter.Location = New System.Drawing.Point(125, 238)
        Me.CalLetter.Name = "CalLetter"
        Me.CalLetter.Size = New System.Drawing.Size(89, 21)
        Me.CalLetter.TabIndex = 9
        Me.CalLetter.TextValue = ""
        '
        'UltraLabel4
        '
        Appearance12.BackHatchStyle = Infragistics.Win.BackHatchStyle.None
        Me.UltraLabel4.Appearance = Appearance12
        Me.UltraLabel4.BackColor = System.Drawing.Color.CornflowerBlue
        Me.UltraLabel4.Location = New System.Drawing.Point(38, 130)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.Size = New System.Drawing.Size(71, 15)
        Me.UltraLabel4.TabIndex = 23
        Me.UltraLabel4.Text = "G.W."
        '
        'Speed
        '
        Me.Speed.CtrlValue = 0
        Me.Speed.Location = New System.Drawing.Point(125, 184)
        Me.Speed.Name = "Speed"
        Me.Speed.Size = New System.Drawing.Size(89, 21)
        Me.Speed.TabIndex = 7
        '
        'UltraLabel6
        '
        Appearance13.BackHatchStyle = Infragistics.Win.BackHatchStyle.None
        Me.UltraLabel6.Appearance = Appearance13
        Me.UltraLabel6.BackColor = System.Drawing.Color.CornflowerBlue
        Me.UltraLabel6.Location = New System.Drawing.Point(38, 186)
        Me.UltraLabel6.Name = "UltraLabel6"
        Me.UltraLabel6.Size = New System.Drawing.Size(71, 19)
        Me.UltraLabel6.TabIndex = 25
        Me.UltraLabel6.Text = "Speed"
        '
        'NET
        '
        Me.NET.CtrlValue = 0
        Me.NET.Location = New System.Drawing.Point(125, 157)
        Me.NET.Name = "NET"
        Me.NET.Size = New System.Drawing.Size(89, 21)
        Me.NET.TabIndex = 6
        '
        'UltraLabel5
        '
        Appearance14.BackHatchStyle = Infragistics.Win.BackHatchStyle.None
        Me.UltraLabel5.Appearance = Appearance14
        Me.UltraLabel5.BackColor = System.Drawing.Color.CornflowerBlue
        Me.UltraLabel5.Location = New System.Drawing.Point(38, 157)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.Size = New System.Drawing.Size(71, 15)
        Me.UltraLabel5.TabIndex = 24
        Me.UltraLabel5.Text = "N.W."
        '
        'VesselName
        '
        Me.VesselName.BackColor = System.Drawing.Color.Transparent
        Me.VesselName.CustomMaxLength = CType(100, Byte)
        Me.VesselName.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.VesselName.Location = New System.Drawing.Point(125, 49)
        Me.VesselName.Name = "VesselName"
        Me.VesselName.Size = New System.Drawing.Size(215, 21)
        Me.VesselName.TabIndex = 2
        Me.VesselName.TextValue = ""
        '
        'DeadWeight
        '
        Me.DeadWeight.CtrlValue = 0
        Me.DeadWeight.Location = New System.Drawing.Point(125, 76)
        Me.DeadWeight.Name = "DeadWeight"
        Me.DeadWeight.Size = New System.Drawing.Size(89, 21)
        Me.DeadWeight.TabIndex = 3
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.UltraGroupBox1.Controls.Add(Me.GroupBox)
        Me.UltraGroupBox1.Location = New System.Drawing.Point(8, 47)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(425, 432)
        Me.UltraGroupBox1.SupportThemes = False
        Me.UltraGroupBox1.TabIndex = 1
        Me.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.VisualStudio2005
        '
        'GeneralForms
        '
        Me.GeneralForms.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GeneralForms.Location = New System.Drawing.Point(0, 0)
        Me.GeneralForms.Name = "GeneralForms"
        Me.GeneralForms.ShowHistoryButtom = False
        Me.GeneralForms.ShowNavigate = False
        Me.GeneralForms.ShowPrintButtom = False
        Me.GeneralForms.Size = New System.Drawing.Size(445, 505)
        Me.GeneralForms.TabIndex = 0
        '
        'UltraLabel12
        '
        Appearance2.BackHatchStyle = Infragistics.Win.BackHatchStyle.None
        Me.UltraLabel12.Appearance = Appearance2
        Me.UltraLabel12.BackColor = System.Drawing.Color.CornflowerBlue
        Me.UltraLabel12.Location = New System.Drawing.Point(38, 346)
        Me.UltraLabel12.Name = "UltraLabel12"
        Me.UltraLabel12.Size = New System.Drawing.Size(81, 19)
        Me.UltraLabel12.TabIndex = 40
        Me.UltraLabel12.Text = "VesselAccount"
        '
        'VesselAccount
        '
        Me.VesselAccount.BackColor = System.Drawing.Color.Transparent
        Me.VesselAccount.CustomMaxLength = CType(100, Byte)
        Me.VesselAccount.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.VesselAccount.Location = New System.Drawing.Point(125, 344)
        Me.VesselAccount.Name = "VesselAccount"
        Me.VesselAccount.Size = New System.Drawing.Size(127, 21)
        Me.VesselAccount.TabIndex = 39
        Me.VesselAccount.TextValue = ""
        '
        'UltraLabel13
        '
        Appearance2.BackHatchStyle = Infragistics.Win.BackHatchStyle.None
        Me.UltraLabel13.Appearance = Appearance2
        Me.UltraLabel13.BackColor = System.Drawing.Color.CornflowerBlue
        Me.UltraLabel13.Location = New System.Drawing.Point(38, 370)
        Me.UltraLabel13.Name = "UltraLabel13"
        Me.UltraLabel13.Size = New System.Drawing.Size(81, 19)
        Me.UltraLabel13.TabIndex = 40
        Me.UltraLabel13.Text = "IMO No."
        '
        'IMONo
        '
        Me.IMONo.BackColor = System.Drawing.Color.Transparent
        Me.IMONo.CustomMaxLength = CType(100, Byte)
        Me.IMONo.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.IMONo.Location = New System.Drawing.Point(125, 370)
        Me.IMONo.Name = "IMONo"
        Me.IMONo.Size = New System.Drawing.Size(127, 21)
        Me.IMONo.TabIndex = 39
        Me.IMONo.TextValue = ""
        '
        'FrmVessels
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(445, 505)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Controls.Add(Me.GeneralForms)
        Me.Name = "FrmVessels"
        Me.Text = "Vessels"
        CType(Me.GroupBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox.ResumeLayout(False)
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GeneralForms As Shipping.UserGeneralForms
    Friend WithEvents GroupBox As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents lbl As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents VesselCode As Shipping.UserText
    Friend WithEvents OfficeCalNo As Shipping.UserText
    Friend WithEvents GW As Shipping.UserNum
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel6 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents VesselName As Shipping.UserText
    Friend WithEvents DeadWeight As Shipping.UserNum
    Friend WithEvents Capacity As Shipping.UserNum
    Friend WithEvents NET As Shipping.UserNum
    Friend WithEvents Speed As Shipping.UserNum
    Friend WithEvents CalLetter As Shipping.UserText
    Friend WithEvents Nationality As Shipping.UserComboCode
    Friend WithEvents UltraLabel7 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel8 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel9 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel10 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents BuiltDate As Shipping.UserGnrlDate
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents LineiD As Shipping.UserComboCode
    Friend WithEvents UltraLabel11 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel12 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel13 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents VesselAccount As Shipping.UserText
    Friend WithEvents IMONo As Shipping.UserText
End Class
