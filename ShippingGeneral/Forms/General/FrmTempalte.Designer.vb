<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTempalte
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
        Dim UltraToolbar1 As Infragistics.Win.UltraWinToolbars.UltraToolbar = New Infragistics.Win.UltraWinToolbars.UltraToolbar("TopToolbar")
        Dim ButtonTool1 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Find")
        Dim ButtonTool2 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("New")
        Dim ButtonTool3 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Edit")
        Dim ButtonTool4 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Save")
        Dim ButtonTool5 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Delete")
        Dim ButtonTool6 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Close")
        Dim UltraToolbar2 As Infragistics.Win.UltraWinToolbars.UltraToolbar = New Infragistics.Win.UltraWinToolbars.UltraToolbar("BottomToolbar")
        Dim ControlContainerTool1 As Infragistics.Win.UltraWinToolbars.ControlContainerTool = New Infragistics.Win.UltraWinToolbars.ControlContainerTool("NavigateContainer")
        Dim UltraToolbar3 As Infragistics.Win.UltraWinToolbars.UltraToolbar = New Infragistics.Win.UltraWinToolbars.UltraToolbar("FormCaption")
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim LabelTool1 As Infragistics.Win.UltraWinToolbars.LabelTool = New Infragistics.Win.UltraWinToolbars.LabelTool("FormHeader")
        Dim ButtonTool7 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Find")
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTempalte))
        Dim ButtonTool8 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("New")
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ButtonTool9 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Save")
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ButtonTool10 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Delete")
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ButtonTool11 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Close")
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ButtonTool12 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Edit")
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ControlContainerTool2 As Infragistics.Win.UltraWinToolbars.ControlContainerTool = New Infragistics.Win.UltraWinToolbars.ControlContainerTool("NavigateContainer")
        Dim LabelTool2 As Infragistics.Win.UltraWinToolbars.LabelTool = New Infragistics.Win.UltraWinToolbars.LabelTool("FormHeader")
        Dim ControlContainerTool3 As Infragistics.Win.UltraWinToolbars.ControlContainerTool = New Infragistics.Win.UltraWinToolbars.ControlContainerTool("NavegateCntr")
        Me.Navigate = New Shipping.UserNavigate
        Me.DataSetForm = New System.Data.DataSet
        Me.ToolbarsManager = New Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(Me.components)
        Me.FrmTempalte_Fill_Panel = New System.Windows.Forms.Panel
        Me._FrmTempalte_Toolbars_Dock_Area_Left = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
        Me._FrmTempalte_Toolbars_Dock_Area_Right = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
        Me._FrmTempalte_Toolbars_Dock_Area_Top = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
        Me._FrmTempalte_Toolbars_Dock_Area_Bottom = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
        CType(Me.DataSetForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ToolbarsManager, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Navigate
        '
        Me.Navigate.Location = New System.Drawing.Point(391, 314)
        Me.Navigate.Name = "Navigate"
        Me.Navigate.Size = New System.Drawing.Size(97, 28)
        Me.Navigate.TabIndex = 5
        Me.Navigate.Visible = False
        '
        'DataSetForm
        '
        Me.DataSetForm.DataSetName = "NewDataSet"
        '
        'ToolbarsManager
        '
        Me.ToolbarsManager.AlphaBlendMode = Infragistics.Win.AlphaBlendMode.Disabled
        Me.ToolbarsManager.DesignerFlags = 1
        Me.ToolbarsManager.DockWithinContainer = Me
        Me.ToolbarsManager.ImageSizeSmall = New System.Drawing.Size(24, 24)
        Me.ToolbarsManager.LockToolbars = True
        Me.ToolbarsManager.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.VisualStudio2005
        UltraToolbar1.DockedColumn = 0
        UltraToolbar1.DockedRow = 1
        UltraToolbar1.FloatingLocation = New System.Drawing.Point(167, 165)
        UltraToolbar1.FloatingSize = New System.Drawing.Size(375, 52)
        UltraToolbar1.Text = "TopToolbar"
        UltraToolbar1.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool1, ButtonTool2, ButtonTool3, ButtonTool4, ButtonTool5, ButtonTool6})
        UltraToolbar2.DockedColumn = 0
        UltraToolbar2.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom
        UltraToolbar2.DockedRow = 0
        UltraToolbar2.Text = "BottomToolbar"
        ControlContainerTool1.Control = Me.Navigate
        UltraToolbar2.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ControlContainerTool1})
        UltraToolbar3.DockedColumn = 0
        UltraToolbar3.DockedRow = 0
        UltraToolbar3.FloatingLocation = New System.Drawing.Point(33, 129)
        UltraToolbar3.FloatingSize = New System.Drawing.Size(190, 190)
        Appearance1.BackColor = System.Drawing.Color.RoyalBlue
        Appearance1.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance1.FontData.BoldAsString = "True"
        Appearance1.FontData.ItalicAsString = "True"
        Appearance1.FontData.Name = "Verdana"
        Appearance1.FontData.SizeInPoints = 15.0!
        Appearance1.ForeColor = System.Drawing.Color.White
        UltraToolbar3.Settings.Appearance = Appearance1
        UltraToolbar3.Settings.FillEntireRow = Infragistics.Win.DefaultableBoolean.[True]
        UltraToolbar3.Text = "Form Name"
        LabelTool1.InstanceProps.Width = 99
        UltraToolbar3.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {LabelTool1})
        Me.ToolbarsManager.Toolbars.AddRange(New Infragistics.Win.UltraWinToolbars.UltraToolbar() {UltraToolbar1, UltraToolbar2, UltraToolbar3})
        Appearance2.Image = CType(resources.GetObject("Appearance2.Image"), Object)
        ButtonTool7.SharedProps.AppearancesSmall.Appearance = Appearance2
        ButtonTool7.SharedProps.Caption = "Find"
        ButtonTool7.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText
        Appearance3.Image = CType(resources.GetObject("Appearance3.Image"), Object)
        ButtonTool8.SharedProps.AppearancesSmall.Appearance = Appearance3
        ButtonTool8.SharedProps.Caption = "New"
        ButtonTool8.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText
        Appearance4.Image = CType(resources.GetObject("Appearance4.Image"), Object)
        ButtonTool9.SharedProps.AppearancesSmall.Appearance = Appearance4
        ButtonTool9.SharedProps.Caption = "Save"
        ButtonTool9.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText
        Appearance5.Image = CType(resources.GetObject("Appearance5.Image"), Object)
        ButtonTool10.SharedProps.AppearancesSmall.Appearance = Appearance5
        ButtonTool10.SharedProps.Caption = "Delete"
        ButtonTool10.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText
        Appearance6.Image = CType(resources.GetObject("Appearance6.Image"), Object)
        ButtonTool11.SharedProps.AppearancesSmall.Appearance = Appearance6
        ButtonTool11.SharedProps.Caption = "Close"
        ButtonTool11.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText
        Appearance7.Image = CType(resources.GetObject("Appearance7.Image"), Object)
        ButtonTool12.SharedProps.AppearancesSmall.Appearance = Appearance7
        ButtonTool12.SharedProps.Caption = "Edit"
        ButtonTool12.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText
        ControlContainerTool2.Control = Me.Navigate
        ControlContainerTool2.SharedProps.Caption = "NavigateContainer"
        LabelTool2.SharedProps.Caption = "FormHeader"
        LabelTool2.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyInMenus
        ControlContainerTool3.SharedProps.Caption = "NavegateCntr"
        Me.ToolbarsManager.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool7, ButtonTool8, ButtonTool9, ButtonTool10, ButtonTool11, ButtonTool12, ControlContainerTool2, LabelTool2, ControlContainerTool3})
        '
        'FrmTempalte_Fill_Panel
        '
        Me.FrmTempalte_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default
        Me.FrmTempalte_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FrmTempalte_Fill_Panel.Location = New System.Drawing.Point(0, 69)
        Me.FrmTempalte_Fill_Panel.Name = "FrmTempalte_Fill_Panel"
        Me.FrmTempalte_Fill_Panel.Size = New System.Drawing.Size(616, 385)
        Me.FrmTempalte_Fill_Panel.TabIndex = 0
        '
        '_FrmTempalte_Toolbars_Dock_Area_Left
        '
        Me._FrmTempalte_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._FrmTempalte_Toolbars_Dock_Area_Left.AlphaBlendMode = Infragistics.Win.AlphaBlendMode.Disabled
        Me._FrmTempalte_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me._FrmTempalte_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left
        Me._FrmTempalte_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText
        Me._FrmTempalte_Toolbars_Dock_Area_Left.Location = New System.Drawing.Point(0, 69)
        Me._FrmTempalte_Toolbars_Dock_Area_Left.Name = "_FrmTempalte_Toolbars_Dock_Area_Left"
        Me._FrmTempalte_Toolbars_Dock_Area_Left.Size = New System.Drawing.Size(0, 385)
        Me._FrmTempalte_Toolbars_Dock_Area_Left.ToolbarsManager = Me.ToolbarsManager
        '
        '_FrmTempalte_Toolbars_Dock_Area_Right
        '
        Me._FrmTempalte_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._FrmTempalte_Toolbars_Dock_Area_Right.AlphaBlendMode = Infragistics.Win.AlphaBlendMode.Disabled
        Me._FrmTempalte_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me._FrmTempalte_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right
        Me._FrmTempalte_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText
        Me._FrmTempalte_Toolbars_Dock_Area_Right.Location = New System.Drawing.Point(616, 69)
        Me._FrmTempalte_Toolbars_Dock_Area_Right.Name = "_FrmTempalte_Toolbars_Dock_Area_Right"
        Me._FrmTempalte_Toolbars_Dock_Area_Right.Size = New System.Drawing.Size(0, 385)
        Me._FrmTempalte_Toolbars_Dock_Area_Right.ToolbarsManager = Me.ToolbarsManager
        '
        '_FrmTempalte_Toolbars_Dock_Area_Top
        '
        Me._FrmTempalte_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._FrmTempalte_Toolbars_Dock_Area_Top.AlphaBlendMode = Infragistics.Win.AlphaBlendMode.Disabled
        Me._FrmTempalte_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me._FrmTempalte_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top
        Me._FrmTempalte_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText
        Me._FrmTempalte_Toolbars_Dock_Area_Top.Location = New System.Drawing.Point(0, 0)
        Me._FrmTempalte_Toolbars_Dock_Area_Top.Name = "_FrmTempalte_Toolbars_Dock_Area_Top"
        Me._FrmTempalte_Toolbars_Dock_Area_Top.Size = New System.Drawing.Size(616, 69)
        Me._FrmTempalte_Toolbars_Dock_Area_Top.ToolbarsManager = Me.ToolbarsManager
        '
        '_FrmTempalte_Toolbars_Dock_Area_Bottom
        '
        Me._FrmTempalte_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._FrmTempalte_Toolbars_Dock_Area_Bottom.AlphaBlendMode = Infragistics.Win.AlphaBlendMode.Disabled
        Me._FrmTempalte_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me._FrmTempalte_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom
        Me._FrmTempalte_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText
        Me._FrmTempalte_Toolbars_Dock_Area_Bottom.Location = New System.Drawing.Point(0, 454)
        Me._FrmTempalte_Toolbars_Dock_Area_Bottom.Name = "_FrmTempalte_Toolbars_Dock_Area_Bottom"
        Me._FrmTempalte_Toolbars_Dock_Area_Bottom.Size = New System.Drawing.Size(616, 34)
        Me._FrmTempalte_Toolbars_Dock_Area_Bottom.ToolbarsManager = Me.ToolbarsManager
        '
        'FrmTempalte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(616, 488)
        Me.Controls.Add(Me.FrmTempalte_Fill_Panel)
        Me.Controls.Add(Me._FrmTempalte_Toolbars_Dock_Area_Left)
        Me.Controls.Add(Me._FrmTempalte_Toolbars_Dock_Area_Right)
        Me.Controls.Add(Me._FrmTempalte_Toolbars_Dock_Area_Top)
        Me.Controls.Add(Me._FrmTempalte_Toolbars_Dock_Area_Bottom)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FrmTempalte"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "General"
        CType(Me.DataSetForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ToolbarsManager, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Protected WithEvents Navigate As Shipping.UserNavigate
    Protected WithEvents DataSetForm As System.Data.DataSet
    Friend WithEvents FrmTempalte_Fill_Panel As System.Windows.Forms.Panel
    Friend WithEvents _FrmTempalte_Toolbars_Dock_Area_Left As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _FrmTempalte_Toolbars_Dock_Area_Right As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _FrmTempalte_Toolbars_Dock_Area_Top As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _FrmTempalte_Toolbars_Dock_Area_Bottom As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Protected WithEvents ToolbarsManager As Infragistics.Win.UltraWinToolbars.UltraToolbarsManager
End Class
