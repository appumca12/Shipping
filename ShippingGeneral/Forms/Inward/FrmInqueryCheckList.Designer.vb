<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmInqueryCheckList
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ButtonSearch = New System.Windows.Forms.ToolStripButton
        Me.ButtonSave = New System.Windows.Forms.ToolStripButton
        Me.GridBls = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.GridCost = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.Vessel = New Shipping.UserComboVessel
        Me.Voyage = New Shipping.UserComboVoyage
        Me.FUDate = New Shipping.UserGnrlDate
        Me.IssueFU = New System.Windows.Forms.CheckBox
        Me.SaveFU = New System.Windows.Forms.Button
        Me.TableLayoutPanel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.GridBls, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridCost, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.ToolStrip1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.GridBls, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.GridCost, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.85146!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 72.14854!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 121.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(900, 498)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ButtonSearch, Me.ButtonSave})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(900, 31)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ButtonSearch
        '
        Me.ButtonSearch.Image = Global.Shipping.My.Resources.Resources.search_24
        Me.ButtonSearch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonSearch.Name = "ButtonSearch"
        Me.ButtonSearch.Size = New System.Drawing.Size(70, 28)
        Me.ButtonSearch.Text = "Search"
        '
        'ButtonSave
        '
        Me.ButtonSave.Image = Global.Shipping.My.Resources.Resources.save_24
        Me.ButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonSave.Name = "ButtonSave"
        Me.ButtonSave.Size = New System.Drawing.Size(59, 28)
        Me.ButtonSave.Text = "Save"
        '
        'GridBls
        '
        Me.GridBls.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.GridBls.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.GridBls.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.GridBls.DisplayLayout.MaxColScrollRegions = 1
        Me.GridBls.DisplayLayout.MaxRowScrollRegions = 1
        Me.GridBls.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.GridBls.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.GridBls.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.GridBls.DisplayLayout.Override.CellPadding = 0
        Me.GridBls.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.GridBls.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Me.GridBls.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.GridBls.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.GridBls.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.GridBls.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.GridBls.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridBls.Location = New System.Drawing.Point(3, 108)
        Me.GridBls.Name = "GridBls"
        Me.GridBls.Size = New System.Drawing.Size(894, 69)
        Me.GridBls.TabIndex = 2
        Me.GridBls.Text = "UltraGrid1"
        '
        'GridCost
        '
        Me.GridCost.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.GridCost.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.GridCost.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.GridCost.DisplayLayout.MaxColScrollRegions = 1
        Me.GridCost.DisplayLayout.MaxRowScrollRegions = 1
        Me.GridCost.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.GridCost.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.GridCost.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.GridCost.DisplayLayout.Override.CellPadding = 0
        Me.GridCost.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.GridCost.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Me.GridCost.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.GridCost.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.GridCost.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.GridCost.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.GridCost.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridCost.Location = New System.Drawing.Point(3, 183)
        Me.GridCost.Name = "GridCost"
        Me.GridCost.Size = New System.Drawing.Size(894, 190)
        Me.GridCost.TabIndex = 3
        Me.GridCost.Text = "UltraGrid1"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.GroupBox1, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.UltraGroupBox1, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 43)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(894, 59)
        Me.TableLayoutPanel2.TabIndex = 4
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.SaveFU)
        Me.GroupBox1.Controls.Add(Me.IssueFU)
        Me.GroupBox1.Controls.Add(Me.FUDate)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(450, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(441, 53)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "FU Issue"
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.Vessel)
        Me.UltraGroupBox1.Controls.Add(Me.Voyage)
        Me.UltraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(441, 53)
        Me.UltraGroupBox1.TabIndex = 1
        Me.UltraGroupBox1.Text = "Vessel/Voyage"
        '
        'Vessel
        '
        Me.Vessel.Location = New System.Drawing.Point(19, 19)
        Me.Vessel.Name = "Vessel"
        Me.Vessel.Size = New System.Drawing.Size(179, 22)
        Me.Vessel.TabIndex = 1
        Me.Vessel.VesselID = New System.Guid("00000000-0000-0000-0000-000000000000")
        '
        'Voyage
        '
        Me.Voyage.Location = New System.Drawing.Point(204, 19)
        Me.Voyage.Name = "Voyage"
        Me.Voyage.Size = New System.Drawing.Size(174, 21)
        Me.Voyage.TabIndex = 0
        Me.Voyage.VoyageID = New System.Guid("00000000-0000-0000-0000-000000000000")
        '
        'FUDate
        '
        Me.FUDate.DateValue = Nothing
        Me.FUDate.Location = New System.Drawing.Point(89, 20)
        Me.FUDate.Name = "FUDate"
        Me.FUDate.ShowTime = False
        Me.FUDate.Size = New System.Drawing.Size(97, 21)
        Me.FUDate.TabIndex = 0
        '
        'IssueFU
        '
        Me.IssueFU.AutoSize = True
        Me.IssueFU.Location = New System.Drawing.Point(15, 23)
        Me.IssueFU.Name = "IssueFU"
        Me.IssueFU.Size = New System.Drawing.Size(68, 17)
        Me.IssueFU.TabIndex = 1
        Me.IssueFU.Text = "Issue FU"
        Me.IssueFU.UseVisualStyleBackColor = True
        '
        'SaveFU
        '
        Me.SaveFU.Image = Global.Shipping.My.Resources.Resources.save_24
        Me.SaveFU.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.SaveFU.Location = New System.Drawing.Point(206, 15)
        Me.SaveFU.Name = "SaveFU"
        Me.SaveFU.Size = New System.Drawing.Size(113, 30)
        Me.SaveFU.TabIndex = 2
        Me.SaveFU.Text = "Save FU"
        Me.SaveFU.UseVisualStyleBackColor = True
        '
        'FrmInqueryCheckList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(900, 498)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "FrmInqueryCheckList"
        Me.Text = "Inquery Checking"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.GridBls, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridCost, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ButtonSearch As System.Windows.Forms.ToolStripButton
    Friend WithEvents ButtonSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents Vessel As Shipping.UserComboVessel
    Friend WithEvents Voyage As Shipping.UserComboVoyage
    Friend WithEvents GridBls As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents GridCost As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents SaveFU As System.Windows.Forms.Button
    Friend WithEvents IssueFU As System.Windows.Forms.CheckBox
    Friend WithEvents FUDate As Shipping.UserGnrlDate
End Class
