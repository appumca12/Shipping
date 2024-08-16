<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTemp
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTemp))
        Dim ButtonTool7 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("To All")
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ButtonTool8 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Delete")
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ButtonTool9 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Delete All")
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ButtonTool10 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Return")
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.ToolbarsManager = New Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(Me.components)
        Me.FrmImco_Fill_Panel = New System.Windows.Forms.Panel
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.TempMin = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.Label1 = New System.Windows.Forms.Label
        Me.TemperatureBase = New Shipping.UserComboCode
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me._FrmImco_Toolbars_Dock_Area_Left = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
        Me._FrmImco_Toolbars_Dock_Area_Right = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
        Me._FrmImco_Toolbars_Dock_Area_Top = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
        Me._FrmImco_Toolbars_Dock_Area_Bottom = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
        Me.TempMax = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        CType(Me.ToolbarsManager, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FrmImco_Fill_Panel.SuspendLayout()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.TempMin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TempMax, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.FrmImco_Fill_Panel.Size = New System.Drawing.Size(307, 134)
        Me.FrmImco_Fill_Panel.TabIndex = 0
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.TempMax)
        Me.UltraGroupBox1.Controls.Add(Me.TempMin)
        Me.UltraGroupBox1.Controls.Add(Me.Label1)
        Me.UltraGroupBox1.Controls.Add(Me.TemperatureBase)
        Me.UltraGroupBox1.Controls.Add(Me.Label5)
        Me.UltraGroupBox1.Controls.Add(Me.Label3)
        Me.UltraGroupBox1.Location = New System.Drawing.Point(12, 15)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(279, 108)
        Me.UltraGroupBox1.SupportThemes = False
        Me.UltraGroupBox1.TabIndex = 1
        '
        'TempMin
        '
        Me.TempMin.Location = New System.Drawing.Point(70, 41)
        Me.TempMin.MaskInput = "-nnnnnnnnn"
        Me.TempMin.Name = "TempMin"
        Me.TempMin.Size = New System.Drawing.Size(77, 21)
        Me.TempMin.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Base On"
        '
        'TemperatureBase
        '
        Me.TemperatureBase.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TemperatureBase.Code = ""
        Me.TemperatureBase.CustomShowAll = False
        Me.TemperatureBase.Location = New System.Drawing.Point(70, 14)
        Me.TemperatureBase.Name = "TemperatureBase"
        Me.TemperatureBase.Size = New System.Drawing.Size(165, 21)
        Me.TemperatureBase.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 45)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 13)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Minimum"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Maximum"
        '
        '_FrmImco_Toolbars_Dock_Area_Left
        '
        Me._FrmImco_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._FrmImco_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me._FrmImco_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left
        Me._FrmImco_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText
        Me._FrmImco_Toolbars_Dock_Area_Left.Location = New System.Drawing.Point(0, 27)
        Me._FrmImco_Toolbars_Dock_Area_Left.Name = "_FrmImco_Toolbars_Dock_Area_Left"
        Me._FrmImco_Toolbars_Dock_Area_Left.Size = New System.Drawing.Size(0, 134)
        Me._FrmImco_Toolbars_Dock_Area_Left.ToolbarsManager = Me.ToolbarsManager
        '
        '_FrmImco_Toolbars_Dock_Area_Right
        '
        Me._FrmImco_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._FrmImco_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me._FrmImco_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right
        Me._FrmImco_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText
        Me._FrmImco_Toolbars_Dock_Area_Right.Location = New System.Drawing.Point(307, 27)
        Me._FrmImco_Toolbars_Dock_Area_Right.Name = "_FrmImco_Toolbars_Dock_Area_Right"
        Me._FrmImco_Toolbars_Dock_Area_Right.Size = New System.Drawing.Size(0, 134)
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
        Me._FrmImco_Toolbars_Dock_Area_Top.Size = New System.Drawing.Size(307, 27)
        Me._FrmImco_Toolbars_Dock_Area_Top.ToolbarsManager = Me.ToolbarsManager
        '
        '_FrmImco_Toolbars_Dock_Area_Bottom
        '
        Me._FrmImco_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._FrmImco_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me._FrmImco_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom
        Me._FrmImco_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText
        Me._FrmImco_Toolbars_Dock_Area_Bottom.Location = New System.Drawing.Point(0, 161)
        Me._FrmImco_Toolbars_Dock_Area_Bottom.Name = "_FrmImco_Toolbars_Dock_Area_Bottom"
        Me._FrmImco_Toolbars_Dock_Area_Bottom.Size = New System.Drawing.Size(307, 0)
        Me._FrmImco_Toolbars_Dock_Area_Bottom.ToolbarsManager = Me.ToolbarsManager
        '
        'TempMax
        '
        Me.TempMax.Location = New System.Drawing.Point(70, 69)
        Me.TempMax.MaskInput = "-nnnnnnnnn"
        Me.TempMax.Name = "TempMax"
        Me.TempMax.Size = New System.Drawing.Size(77, 21)
        Me.TempMax.TabIndex = 2
        '
        'FrmTemp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(307, 161)
        Me.Controls.Add(Me.FrmImco_Fill_Panel)
        Me.Controls.Add(Me._FrmImco_Toolbars_Dock_Area_Left)
        Me.Controls.Add(Me._FrmImco_Toolbars_Dock_Area_Right)
        Me.Controls.Add(Me._FrmImco_Toolbars_Dock_Area_Top)
        Me.Controls.Add(Me._FrmImco_Toolbars_Dock_Area_Bottom)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmTemp"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Temperature"
        CType(Me.ToolbarsManager, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FrmImco_Fill_Panel.ResumeLayout(False)
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        CType(Me.TempMin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TempMax, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolbarsManager As Infragistics.Win.UltraWinToolbars.UltraToolbarsManager
    Friend WithEvents FrmImco_Fill_Panel As System.Windows.Forms.Panel
    Friend WithEvents _FrmImco_Toolbars_Dock_Area_Left As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _FrmImco_Toolbars_Dock_Area_Right As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _FrmImco_Toolbars_Dock_Area_Top As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _FrmImco_Toolbars_Dock_Area_Bottom As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TemperatureBase As Shipping.UserComboCode
    Friend WithEvents TempMin As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents TempMax As Infragistics.Win.UltraWinEditors.UltraNumericEditor

End Class
