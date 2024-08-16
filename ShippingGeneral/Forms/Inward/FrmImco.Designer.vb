<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmImco
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
        Dim UltraToolbar1 As Infragistics.Win.UltraWinToolbars.UltraToolbar = New Infragistics.Win.UltraWinToolbars.UltraToolbar("TopToolBar")
        Dim ButtonTool1 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Apply")
        Dim ButtonTool2 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("To All")
        Dim ButtonTool3 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Delete")
        Dim ButtonTool4 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Delete All")
        Dim ButtonTool5 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Return")
        Dim ButtonTool6 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Apply")
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmImco))
        Dim ButtonTool7 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("To All")
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ButtonTool8 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Delete")
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ButtonTool9 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Delete All")
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ButtonTool10 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Return")
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.EMSNumber = New Shipping.UserText
        Me.SubsidaryHazard = New Shipping.UserText
        Me.PSN = New Shipping.UserText
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.PageNumber = New Shipping.UserNum
        Me.UnNo = New Shipping.UserText
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.FlashPoint = New Shipping.UserNum
        Me.PackingGroup = New Shipping.UserComboCode
        Me.MarinePollutant = New Shipping.UserComboCode
        Me.IMDG = New Shipping.UserComboCode
        Me.ToolbarsManager = New Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(Me.components)
        Me.FrmImco_Fill_Panel = New System.Windows.Forms.Panel
        Me._FrmImco_Toolbars_Dock_Area_Left = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
        Me._FrmImco_Toolbars_Dock_Area_Right = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
        Me._FrmImco_Toolbars_Dock_Area_Top = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
        Me._FrmImco_Toolbars_Dock_Area_Bottom = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.ToolbarsManager, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FrmImco_Fill_Panel.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.Label6)
        Me.UltraGroupBox1.Controls.Add(Me.EMSNumber)
        Me.UltraGroupBox1.Controls.Add(Me.SubsidaryHazard)
        Me.UltraGroupBox1.Controls.Add(Me.PSN)
        Me.UltraGroupBox1.Controls.Add(Me.Label5)
        Me.UltraGroupBox1.Controls.Add(Me.Label7)
        Me.UltraGroupBox1.Controls.Add(Me.Label8)
        Me.UltraGroupBox1.Controls.Add(Me.Label9)
        Me.UltraGroupBox1.Controls.Add(Me.Label4)
        Me.UltraGroupBox1.Controls.Add(Me.PageNumber)
        Me.UltraGroupBox1.Controls.Add(Me.UnNo)
        Me.UltraGroupBox1.Controls.Add(Me.Label3)
        Me.UltraGroupBox1.Controls.Add(Me.Label2)
        Me.UltraGroupBox1.Controls.Add(Me.Label1)
        Me.UltraGroupBox1.Controls.Add(Me.FlashPoint)
        Me.UltraGroupBox1.Controls.Add(Me.PackingGroup)
        Me.UltraGroupBox1.Controls.Add(Me.MarinePollutant)
        Me.UltraGroupBox1.Controls.Add(Me.IMDG)
        Me.UltraGroupBox1.Location = New System.Drawing.Point(12, 15)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(685, 378)
        Me.UltraGroupBox1.SupportThemes = False
        Me.UltraGroupBox1.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 96)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(30, 13)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "EMS"
        '
        'EMSNumber
        '
        Me.EMSNumber.BackColor = System.Drawing.Color.Transparent
        Me.EMSNumber.CustomMaxLength = CType(100, Byte)
        Me.EMSNumber.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.EMSNumber.Location = New System.Drawing.Point(93, 96)
        Me.EMSNumber.Name = "EMSNumber"
        Me.EMSNumber.Size = New System.Drawing.Size(165, 19)
        Me.EMSNumber.TabIndex = 4
        Me.EMSNumber.TextValue = ""
        '
        'SubsidaryHazard
        '
        Me.SubsidaryHazard.BackColor = System.Drawing.Color.Transparent
        Me.SubsidaryHazard.CustomMaxLength = CType(100, Byte)
        Me.SubsidaryHazard.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.SubsidaryHazard.Location = New System.Drawing.Point(93, 176)
        Me.SubsidaryHazard.Name = "SubsidaryHazard"
        Me.SubsidaryHazard.Size = New System.Drawing.Size(165, 19)
        Me.SubsidaryHazard.TabIndex = 4
        Me.SubsidaryHazard.TextValue = ""
        '
        'PSN
        '
        Me.PSN.BackColor = System.Drawing.Color.Transparent
        Me.PSN.CustomMaxLength = CType(100, Byte)
        Me.PSN.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.PSN.Location = New System.Drawing.Point(93, 200)
        Me.PSN.Name = "PSN"
        Me.PSN.Size = New System.Drawing.Size(165, 19)
        Me.PSN.TabIndex = 4
        Me.PSN.TextValue = ""
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 124)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 13)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Page No."
        '
        'Label6
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(13, 230)
        Me.Label9.Name = "Label6"
        Me.Label9.Size = New System.Drawing.Size(52, 13)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "Marine Pollutant"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(13, 175)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Subsidar Haz"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(13, 200)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(52, 13)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "PSN"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 71)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "UNNO"
        '
        'PageNumber
        '
        Me.PageNumber.CtrlValue = 0
        Me.PageNumber.Location = New System.Drawing.Point(93, 120)
        Me.PageNumber.Name = "PageNumber"
        Me.PageNumber.Size = New System.Drawing.Size(104, 23)
        Me.PageNumber.TabIndex = 5
        '
        'UnNo
        '
        Me.UnNo.BackColor = System.Drawing.Color.Transparent
        Me.UnNo.CustomMaxLength = CType(100, Byte)
        Me.UnNo.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.UnNo.Location = New System.Drawing.Point(93, 71)
        Me.UnNo.Name = "UnNo"
        Me.UnNo.Size = New System.Drawing.Size(165, 19)
        Me.UnNo.TabIndex = 3
        Me.UnNo.TextValue = ""
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 149)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Flash Point"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Packing Group"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "IMDG"
        '
        'FlashPoint
        '
        Me.FlashPoint.CtrlValue = 0
        Me.FlashPoint.Location = New System.Drawing.Point(93, 146)
        Me.FlashPoint.Name = "FlashPoint"
        Me.FlashPoint.Size = New System.Drawing.Size(104, 23)
        Me.FlashPoint.TabIndex = 6
        '
        'PackingGroup
        '
        Me.PackingGroup.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PackingGroup.Code = ""
        Me.PackingGroup.CustomShowAll = False
        Me.PackingGroup.Location = New System.Drawing.Point(93, 44)
        Me.PackingGroup.Name = "PackingGroup"
        Me.PackingGroup.Size = New System.Drawing.Size(165, 22)
        Me.PackingGroup.TabIndex = 2
        '
        'MarinePollutant
        '
        Me.MarinePollutant.BackColor = System.Drawing.Color.WhiteSmoke
        Me.MarinePollutant.Code = ""
        Me.MarinePollutant.CustomShowAll = False
        Me.MarinePollutant.Location = New System.Drawing.Point(93, 230)
        Me.MarinePollutant.Name = "MarinePollutant"
        Me.MarinePollutant.Size = New System.Drawing.Size(165, 22)
        Me.MarinePollutant.TabIndex = 2
        '
        'IMDG
        '
        Me.IMDG.BackColor = System.Drawing.Color.WhiteSmoke
        Me.IMDG.Code = ""
        Me.IMDG.CustomShowAll = False
        Me.IMDG.Location = New System.Drawing.Point(93, 17)
        Me.IMDG.Name = "IMDG"
        Me.IMDG.Size = New System.Drawing.Size(165, 21)
        Me.IMDG.TabIndex = 1
        '
        'ToolbarsManager
        '
        Me.ToolbarsManager.DesignerFlags = 1
        Me.ToolbarsManager.DockWithinContainer = Me
        Me.ToolbarsManager.ShowFullMenusDelay = 500
        Me.ToolbarsManager.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2003
        UltraToolbar1.DockedColumn = 0
        UltraToolbar1.DockedRow = 0
        UltraToolbar1.Text = "TopToolBar"
        UltraToolbar1.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool1, ButtonTool2, ButtonTool3, ButtonTool4, ButtonTool5})
        Me.ToolbarsManager.Toolbars.AddRange(New Infragistics.Win.UltraWinToolbars.UltraToolbar() {UltraToolbar1})
        Appearance1.Image = CType(resources.GetObject("Appearance1.Image"), Object)
        ButtonTool6.SharedProps.AppearancesSmall.Appearance = Appearance1
        ButtonTool6.SharedProps.Caption = "Apply"
        ButtonTool6.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText
        Appearance2.Image = CType(resources.GetObject("Appearance2.Image"), Object)
        ButtonTool7.SharedProps.AppearancesSmall.Appearance = Appearance2
        ButtonTool7.SharedProps.Caption = "To All"
        ButtonTool7.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText
        Appearance3.Image = CType(resources.GetObject("Appearance3.Image"), Object)
        ButtonTool8.SharedProps.AppearancesSmall.Appearance = Appearance3
        ButtonTool8.SharedProps.Caption = "Delete"
        ButtonTool8.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText
        Appearance4.Image = CType(resources.GetObject("Appearance4.Image"), Object)
        ButtonTool9.SharedProps.AppearancesSmall.Appearance = Appearance4
        ButtonTool9.SharedProps.Caption = "Delete All"
        ButtonTool9.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText
        Appearance5.Image = CType(resources.GetObject("Appearance5.Image"), Object)
        ButtonTool10.SharedProps.AppearancesSmall.Appearance = Appearance5
        ButtonTool10.SharedProps.Caption = "Return"
        Me.ToolbarsManager.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool6, ButtonTool7, ButtonTool8, ButtonTool9, ButtonTool10})
        '
        'FrmImco_Fill_Panel
        '
        Me.FrmImco_Fill_Panel.Controls.Add(Me.UltraGroupBox1)
        Me.FrmImco_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default
        Me.FrmImco_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FrmImco_Fill_Panel.Location = New System.Drawing.Point(0, 27)
        Me.FrmImco_Fill_Panel.Name = "FrmImco_Fill_Panel"
        Me.FrmImco_Fill_Panel.Size = New System.Drawing.Size(808, 405)
        Me.FrmImco_Fill_Panel.TabIndex = 0
        '
        '_FrmImco_Toolbars_Dock_Area_Left
        '
        Me._FrmImco_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._FrmImco_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me._FrmImco_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left
        Me._FrmImco_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText
        Me._FrmImco_Toolbars_Dock_Area_Left.Location = New System.Drawing.Point(0, 27)
        Me._FrmImco_Toolbars_Dock_Area_Left.Name = "_FrmImco_Toolbars_Dock_Area_Left"
        Me._FrmImco_Toolbars_Dock_Area_Left.Size = New System.Drawing.Size(0, 205)
        Me._FrmImco_Toolbars_Dock_Area_Left.ToolbarsManager = Me.ToolbarsManager
        '
        '_FrmImco_Toolbars_Dock_Area_Right
        '
        Me._FrmImco_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._FrmImco_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me._FrmImco_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right
        Me._FrmImco_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText
        Me._FrmImco_Toolbars_Dock_Area_Right.Location = New System.Drawing.Point(408, 27)
        Me._FrmImco_Toolbars_Dock_Area_Right.Name = "_FrmImco_Toolbars_Dock_Area_Right"
        Me._FrmImco_Toolbars_Dock_Area_Right.Size = New System.Drawing.Size(0, 205)
        Me._FrmImco_Toolbars_Dock_Area_Right.ToolbarsManager = Me.ToolbarsManager
        '
        '_FrmImco_Toolbars_Dock_Area_Top
        '
        Me._FrmImco_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._FrmImco_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me._FrmImco_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top
        Me._FrmImco_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText
        Me._FrmImco_Toolbars_Dock_Area_Top.Location = New System.Drawing.Point(0, 0)
        Me._FrmImco_Toolbars_Dock_Area_Top.Name = "_FrmImco_Toolbars_Dock_Area_Top"
        Me._FrmImco_Toolbars_Dock_Area_Top.Size = New System.Drawing.Size(408, 27)
        Me._FrmImco_Toolbars_Dock_Area_Top.ToolbarsManager = Me.ToolbarsManager
        '
        '_FrmImco_Toolbars_Dock_Area_Bottom
        '
        Me._FrmImco_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._FrmImco_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me._FrmImco_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom
        Me._FrmImco_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText
        Me._FrmImco_Toolbars_Dock_Area_Bottom.Location = New System.Drawing.Point(0, 232)
        Me._FrmImco_Toolbars_Dock_Area_Bottom.Name = "_FrmImco_Toolbars_Dock_Area_Bottom"
        Me._FrmImco_Toolbars_Dock_Area_Bottom.Size = New System.Drawing.Size(408, 0)
        Me._FrmImco_Toolbars_Dock_Area_Bottom.ToolbarsManager = Me.ToolbarsManager
        '
        'FrmImco
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(408, 432)
        Me.Controls.Add(Me.FrmImco_Fill_Panel)
        Me.Controls.Add(Me._FrmImco_Toolbars_Dock_Area_Left)
        Me.Controls.Add(Me._FrmImco_Toolbars_Dock_Area_Right)
        Me.Controls.Add(Me._FrmImco_Toolbars_Dock_Area_Top)
        Me.Controls.Add(Me._FrmImco_Toolbars_Dock_Area_Bottom)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmImco"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Imco"
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        CType(Me.ToolbarsManager, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FrmImco_Fill_Panel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents FlashPoint As Shipping.UserNum
    Friend WithEvents PackingGroup As Shipping.UserComboCode
    Friend WithEvents MarinePollutant As Shipping.UserComboCode
    Friend WithEvents IMDG As Shipping.UserComboCode
    Friend WithEvents ToolbarsManager As Infragistics.Win.UltraWinToolbars.UltraToolbarsManager
    Friend WithEvents FrmImco_Fill_Panel As System.Windows.Forms.Panel
    Friend WithEvents _FrmImco_Toolbars_Dock_Area_Left As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _FrmImco_Toolbars_Dock_Area_Right As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _FrmImco_Toolbars_Dock_Area_Top As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _FrmImco_Toolbars_Dock_Area_Bottom As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents EMSNumber As Shipping.UserText
    Friend WithEvents SubsidaryHazard As Shipping.UserText
    Friend WithEvents PSN As Shipping.UserText
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PageNumber As Shipping.UserNum
    Friend WithEvents UnNo As Shipping.UserText

End Class
