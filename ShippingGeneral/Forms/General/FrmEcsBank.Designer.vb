<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEcsBank
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
        Me.TareWeight = New Shipping.UserNum
        Me.MaxGW = New Shipping.UserNum
        Me.Payload = New Shipping.UserNum
        Me.CreatedDate = New Shipping.UserText
        Me.ModifiedDate = New Shipping.UserText
        Me.lbl = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel10 = New Infragistics.Win.Misc.UltraLabel
        Me.ContainerNo = New Shipping.UserText
        Me.UltraLabel9 = New Infragistics.Win.Misc.UltraLabel
        Me.OfficeCalNo = New Shipping.UserText
        Me.UltraLabel8 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel13 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel14 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel7 = New Infragistics.Win.Misc.UltraLabel
        Me.GW = New Shipping.UserNum
        Me.Nationality = New Shipping.UserComboCode
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel7 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel8 = New Infragistics.Win.Misc.UltraLabel
        Me.CalLetter = New Shipping.UserText
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel
        Me.Speed = New Shipping.UserNum
        Me.UltraLabel6 = New Infragistics.Win.Misc.UltraLabel
        Me.NET = New Shipping.UserNum
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel
        'Me.CntrSize = New Shipping.UserNum
        'Me.CntrType = New Shipping.UserText
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.GeneralForms = New Shipping.UserGeneralForms
        Me.UltraLabel12 = New Infragistics.Win.Misc.UltraLabel
        Me.VesselAccount = New Shipping.UserText
        Me.CntrSize = New Shipping.UserComboCode
        Me.CntrType = New Shipping.UserComboCode
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

        Me.GroupBox.Controls.Add(Me.TareWeight)
        Me.GroupBox.Controls.Add(Me.MaxGW)
        Me.GroupBox.Controls.Add(Me.Payload)
        Me.GroupBox.Controls.Add(Me.CreatedDate)
        Me.GroupBox.Controls.Add(Me.ModifiedDate)
        Me.GroupBox.Controls.Add(Me.lbl)
        Me.GroupBox.Controls.Add(Me.ContainerNo)
        Me.GroupBox.Controls.Add(Me.UltraLabel1)
        Me.GroupBox.Controls.Add(Me.UltraLabel3)
        Me.GroupBox.Controls.Add(Me.UltraLabel2)
        ' Me.GroupBox.Controls.Add(Me.CntrSize)
        'Me.GroupBox.Controls.Add(Me.CntrType)
        Me.GroupBox.Location = New System.Drawing.Point(22, 20)
        Me.GroupBox.Name = "GroupBox"
        Me.GroupBox.Size = New System.Drawing.Size(379, 389)
        Me.GroupBox.SupportThemes = False
        Me.GroupBox.TabIndex = 0
        Me.GroupBox.Controls.Add(Me.CntrSize)
        Me.GroupBox.Controls.Add(Me.CntrType)
        Me.GroupBox.Controls.Add(Me.UltraLabel7)
        Me.GroupBox.Controls.Add(Me.UltraLabel8)
        Me.GroupBox.Controls.Add(Me.UltraLabel13)
        Me.GroupBox.Controls.Add(Me.UltraLabel14)
        '
        'TareWeight
        '
        Me.TareWeight.CtrlValue = 0
        Me.TareWeight.Location = New System.Drawing.Point(125, 103)
        Me.TareWeight.Name = "TareWeight"
        Me.TareWeight.Size = New System.Drawing.Size(89, 21)
        Me.TareWeight.TabIndex = 4
        '
        'MaxGW
        '
        Me.MaxGW.CtrlValue = 0
        Me.MaxGW.Location = New System.Drawing.Point(125, 130)
        Me.MaxGW.Name = "MaxGW"
        Me.MaxGW.Size = New System.Drawing.Size(89, 21)
        Me.MaxGW.TabIndex = 4
        '
        'Payload
        '
        Me.Payload.CtrlValue = 0
        Me.Payload.Location = New System.Drawing.Point(125, 157)
        Me.Payload.Name = "Payload"
        Me.Payload.Size = New System.Drawing.Size(89, 21)
        Me.Payload.TabIndex = 4

        '
        'CreatedDate
        '

        Me.CreatedDate.Location = New System.Drawing.Point(125, 187)
        Me.CreatedDate.Name = "CreatedDate"
        Me.CreatedDate.Size = New System.Drawing.Size(125, 21)
        Me.CreatedDate.TabIndex = 5
        Me.CreatedDate.Enabled = False

        '
        'CreatedDate
        '

        Me.ModifiedDate.Location = New System.Drawing.Point(125, 217)
        Me.ModifiedDate.Name = "ModifiedDate"
        Me.ModifiedDate.Size = New System.Drawing.Size(125, 21)
        Me.ModifiedDate.TabIndex = 5
        Me.ModifiedDate.Enabled = False

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
        Me.lbl.Text = "Container No"

        '
        'ContainerNo
        '
        Me.ContainerNo.BackColor = System.Drawing.Color.Transparent
        Me.ContainerNo.CustomMaxLength = CType(100, Byte)
        Me.ContainerNo.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.ContainerNo.Location = New System.Drawing.Point(125, 22)
        Me.ContainerNo.Name = "ContainerNo"
        Me.ContainerNo.Size = New System.Drawing.Size(150, 21)
        Me.ContainerNo.TabIndex = 1
        Me.ContainerNo.TextValue = ""


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
        Me.UltraLabel1.Text = "Size"



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
        Me.UltraLabel3.Text = "Tare Weight"
        '
        'UltraLabel7
        '
        Appearance11.BackHatchStyle = Infragistics.Win.BackHatchStyle.None
        Me.UltraLabel7.Appearance = Appearance11
        Me.UltraLabel7.BackColor = System.Drawing.Color.CornflowerBlue
        Me.UltraLabel7.Location = New System.Drawing.Point(38, 130)
        Me.UltraLabel7.Name = "UltraLabel7"
        Me.UltraLabel7.Size = New System.Drawing.Size(71, 15)
        Me.UltraLabel7.TabIndex = 22
        Me.UltraLabel7.Text = "Max G.W"
        '
        'UltraLabel3
        '
        Appearance11.BackHatchStyle = Infragistics.Win.BackHatchStyle.None
        Me.UltraLabel8.Appearance = Appearance11
        Me.UltraLabel8.BackColor = System.Drawing.Color.CornflowerBlue
        Me.UltraLabel8.Location = New System.Drawing.Point(38, 157)
        Me.UltraLabel8.Name = "UltraLabel8"
        Me.UltraLabel8.Size = New System.Drawing.Size(71, 15)
        Me.UltraLabel8.TabIndex = 22
        Me.UltraLabel8.Text = "Pay Load"
        '
        'UltraLabel13
        '
        Appearance11.BackHatchStyle = Infragistics.Win.BackHatchStyle.None
        Me.UltraLabel13.Appearance = Appearance11
        Me.UltraLabel13.BackColor = System.Drawing.Color.CornflowerBlue
        Me.UltraLabel13.Location = New System.Drawing.Point(38, 187)
        Me.UltraLabel13.Name = "UltraLabel13"
        Me.UltraLabel13.Size = New System.Drawing.Size(71, 15)
        Me.UltraLabel13.TabIndex = 22
        Me.UltraLabel13.Text = "Created Date"

        '
        'UltraLabel14
        '
        Appearance11.BackHatchStyle = Infragistics.Win.BackHatchStyle.None
        Me.UltraLabel14.Appearance = Appearance11
        Me.UltraLabel14.BackColor = System.Drawing.Color.CornflowerBlue
        Me.UltraLabel14.Location = New System.Drawing.Point(38, 217)
        Me.UltraLabel14.Name = "UltraLabel14"
        Me.UltraLabel14.Size = New System.Drawing.Size(78, 15)
        Me.UltraLabel14.TabIndex = 22
        Me.UltraLabel14.Text = "Modified Date"

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
        Me.UltraLabel2.Text = "Type"


        ''
        ''CntrSize
        ''
        'Me.CntrSize.BackColor = System.Drawing.Color.Transparent
        'Me.CntrSize.CtrlValue = 0
        'Me.CntrSize.ForeColor = System.Drawing.Color.WhiteSmoke
        'Me.CntrSize.Location = New System.Drawing.Point(125, 49)
        'Me.CntrSize.Name = "CntrSize"
        'Me.CntrSize.Size = New System.Drawing.Size(75, 21)
        'Me.CntrSize.TabIndex = 2

        '
        'CnSize
        '
        Me.CntrSize.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CntrSize.Code = ""
        Me.CntrSize.CustomShowAll = False
        Me.CntrSize.Location = New System.Drawing.Point(125, 49)
        Me.CntrSize.Name = "CntrSize"
        Me.CntrSize.Size = New System.Drawing.Size(95, 22)
        Me.CntrSize.TabIndex = 2
        ''
        ''CntrType
        ''

        'Me.CntrType.Location = New System.Drawing.Point(125, 76)
        'Me.CntrType.Name = "CntrType"
        'Me.CntrType.Size = New System.Drawing.Size(89, 21)
        'Me.CntrType.TabIndex = 3
        '
        'CnType
        '
        Me.CntrType.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CntrType.Code = ""
        Me.CntrType.CustomShowAll = False
        Me.CntrType.Location = New System.Drawing.Point(125, 76)
        Me.CntrType.Name = "CntrType"
        Me.CntrType.Size = New System.Drawing.Size(95, 22)
        Me.CntrType.TabIndex = 3
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
        'FrmVessels
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(445, 505)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Controls.Add(Me.GeneralForms)
        Me.Name = "FrmEcsBank"
        Me.Text = "Container Bank"
        CType(Me.GroupBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox.ResumeLayout(False)
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GeneralForms As Shipping.UserGeneralForms
    Friend WithEvents GroupBox As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents lbl As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents ContainerNo As Shipping.UserText
    Friend WithEvents OfficeCalNo As Shipping.UserText
    Friend WithEvents GW As Shipping.UserNum
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel6 As Infragistics.Win.Misc.UltraLabel
    'Friend WithEvents UltraLabel7 As Infragistics.Win.Misc.UltraLabel
    'Friend WithEvents UltraLabel8 As Infragistics.Win.Misc.UltraLabel
    'Friend WithEvents CntrSize As Shipping.UserNum
    'Friend WithEvents CntrType As Shipping.UserText
    Friend WithEvents TareWeight As Shipping.UserNum
    Friend WithEvents MaxGW As Shipping.UserNum
    Friend WithEvents Payload As Shipping.UserNum
    Friend WithEvents CreatedDate As Shipping.UserText
    Friend WithEvents ModifiedDate As Shipping.UserText
    Friend WithEvents NET As Shipping.UserNum
    Friend WithEvents Speed As Shipping.UserNum
    Friend WithEvents CalLetter As Shipping.UserText
    Friend WithEvents Nationality As Shipping.UserComboCode
    Friend WithEvents UltraLabel7 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel8 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel9 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel10 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel13 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel14 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents BuiltDate As Shipping.UserGnrlDate
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents LineiD As Shipping.UserComboCode
    Friend WithEvents UltraLabel11 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel12 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents VesselAccount As Shipping.UserText
    Friend WithEvents CntrSize As Shipping.UserComboCode
    Friend WithEvents CntrType As Shipping.UserComboCode
End Class
