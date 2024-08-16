<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserBlsGoods
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.GroupBox = New Infragistics.Win.Misc.UltraGroupBox
        Me.UltraLabel8 = New Infragistics.Win.Misc.UltraLabel
        Me.TTLCBM = New Shipping.UserNum
        Me.UltraLabel7 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel6 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel
        Me.TTLPKGS = New Shipping.UserNum
        Me.TTLNET = New Shipping.UserNum
        Me.TGW = New Shipping.UserNum
        Me.TTW = New Shipping.UserNum
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel
        Me.MainCom = New Shipping.UserMemo
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.Marks = New Shipping.UserMemo
        Me.Goods = New Shipping.UserMemo
        CType(Me.GroupBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox
        '
        Appearance1.BorderAlpha = Infragistics.Win.Alpha.Opaque
        Appearance1.BorderColor = System.Drawing.Color.White
        Appearance1.BorderColor3DBase = System.Drawing.Color.White
        Me.GroupBox.Appearance = Appearance1
        Me.GroupBox.Controls.Add(Me.UltraLabel8)
        Me.GroupBox.Controls.Add(Me.TTLCBM)
        Me.GroupBox.Controls.Add(Me.UltraLabel7)
        Me.GroupBox.Controls.Add(Me.UltraLabel6)
        Me.GroupBox.Controls.Add(Me.UltraLabel4)
        Me.GroupBox.Controls.Add(Me.UltraLabel3)
        Me.GroupBox.Controls.Add(Me.TTLPKGS)
        Me.GroupBox.Controls.Add(Me.TTLNET)
        Me.GroupBox.Controls.Add(Me.TGW)
        Me.GroupBox.Controls.Add(Me.TTW)
        Me.GroupBox.Controls.Add(Me.UltraLabel5)
        Me.GroupBox.Controls.Add(Me.MainCom)
        Me.GroupBox.Controls.Add(Me.UltraLabel2)
        Me.GroupBox.Controls.Add(Me.UltraLabel1)
        Me.GroupBox.Controls.Add(Me.Marks)
        Me.GroupBox.Controls.Add(Me.Goods)
        Me.GroupBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox.Name = "GroupBox"
        Me.GroupBox.Size = New System.Drawing.Size(665, 276)
        Me.GroupBox.SupportThemes = False
        Me.GroupBox.TabIndex = 1
        '
        'UltraLabel8
        '
        Me.UltraLabel8.Location = New System.Drawing.Point(418, 48)
        Me.UltraLabel8.Name = "UltraLabel8"
        Me.UltraLabel8.Size = New System.Drawing.Size(33, 15)
        Me.UltraLabel8.TabIndex = 19
        Me.UltraLabel8.Text = "CBM"
        '
        'TTLCBM
        '
        Me.TTLCBM.CtrlValue = 0
        Me.TTLCBM.Location = New System.Drawing.Point(455, 42)
        Me.TTLCBM.Name = "TTLCBM"
        Me.TTLCBM.Size = New System.Drawing.Size(79, 23)
        Me.TTLCBM.TabIndex = 4
        '
        'UltraLabel7
        '
        Me.UltraLabel7.Location = New System.Drawing.Point(534, 48)
        Me.UltraLabel7.Name = "UltraLabel7"
        Me.UltraLabel7.Size = New System.Drawing.Size(37, 15)
        Me.UltraLabel7.TabIndex = 17
        Me.UltraLabel7.Text = "PKGS"
        '
        'UltraLabel6
        '
        Me.UltraLabel6.Location = New System.Drawing.Point(282, 48)
        Me.UltraLabel6.Name = "UltraLabel6"
        Me.UltraLabel6.Size = New System.Drawing.Size(43, 15)
        Me.UltraLabel6.TabIndex = 16
        Me.UltraLabel6.Text = "N.WGT"
        '
        'UltraLabel4
        '
        Me.UltraLabel4.Location = New System.Drawing.Point(153, 48)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.Size = New System.Drawing.Size(44, 15)
        Me.UltraLabel4.TabIndex = 15
        Me.UltraLabel4.Text = "G.WGT"
        '
        'UltraLabel3
        '
        Me.UltraLabel3.Location = New System.Drawing.Point(13, 48)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(56, 15)
        Me.UltraLabel3.TabIndex = 14
        Me.UltraLabel3.Text = "T.WGT"
        '
        'TTLPKGS
        '
        Me.TTLPKGS.CtrlValue = 0
        Me.TTLPKGS.Location = New System.Drawing.Point(574, 42)
        Me.TTLPKGS.Name = "TTLPKGS"
        Me.TTLPKGS.Size = New System.Drawing.Size(80, 23)
        Me.TTLPKGS.TabIndex = 5
        '
        'TTLNET
        '
        Me.TTLNET.CtrlValue = 0
        Me.TTLNET.Location = New System.Drawing.Point(327, 43)
        Me.TTLNET.Name = "TTLNET"
        Me.TTLNET.Size = New System.Drawing.Size(79, 23)
        Me.TTLNET.TabIndex = 3
        '
        'TGW
        '
        Me.TGW.CtrlValue = 0
        Me.TGW.Location = New System.Drawing.Point(200, 42)
        Me.TGW.Name = "TGW"
        Me.TGW.Size = New System.Drawing.Size(79, 23)
        Me.TGW.TabIndex = 2
        '
        'TTW
        '
        Me.TTW.CtrlValue = 0
        Me.TTW.Location = New System.Drawing.Point(72, 42)
        Me.TTW.Name = "TTW"
        Me.TTW.Size = New System.Drawing.Size(79, 23)
        Me.TTW.TabIndex = 1
        '
        'UltraLabel5
        '
        Me.UltraLabel5.Location = New System.Drawing.Point(13, 21)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.Size = New System.Drawing.Size(56, 23)
        Me.UltraLabel5.TabIndex = 9
        Me.UltraLabel5.Text = "Main Com"
        '
        'MainCom
        '
        Me.MainCom.Location = New System.Drawing.Point(72, 17)
        Me.MainCom.Name = "MainCom"
        Me.MainCom.Size = New System.Drawing.Size(582, 23)
        Me.MainCom.TabIndex = 0
        Me.MainCom.TextValue = ""
        '
        'UltraLabel2
        '
        Me.UltraLabel2.Location = New System.Drawing.Point(402, 71)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(38, 23)
        Me.UltraLabel2.TabIndex = 5
        Me.UltraLabel2.Text = "Marks"
        '
        'UltraLabel1
        '
        Me.UltraLabel1.Location = New System.Drawing.Point(15, 74)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(55, 23)
        Me.UltraLabel1.TabIndex = 4
        Me.UltraLabel1.Text = "Goods"
        '
        'Marks
        '
        Me.Marks.Location = New System.Drawing.Point(445, 68)
        Me.Marks.Name = "Marks"
        Me.Marks.Size = New System.Drawing.Size(209, 200)
        Me.Marks.TabIndex = 7
        Me.Marks.TextValue = ""
        '
        'Goods
        '
        Me.Goods.Location = New System.Drawing.Point(72, 69)
        Me.Goods.Name = "Goods"
        Me.Goods.Size = New System.Drawing.Size(323, 197)
        Me.Goods.TabIndex = 6
        Me.Goods.TextValue = ""
        '
        'UserBlsGoods
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupBox)
        Me.Name = "UserBlsGoods"
        Me.Size = New System.Drawing.Size(665, 276)
        CType(Me.GroupBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents MainCom As Shipping.UserMemo
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Marks As Shipping.UserMemo
    Friend WithEvents Goods As Shipping.UserMemo
    Friend WithEvents UltraLabel7 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel6 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents TTLPKGS As Shipping.UserNum
    Friend WithEvents TTLNET As Shipping.UserNum
    Friend WithEvents TGW As Shipping.UserNum
    Friend WithEvents TTW As Shipping.UserNum
    Friend WithEvents UltraLabel8 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents TTLCBM As Shipping.UserNum

End Class
