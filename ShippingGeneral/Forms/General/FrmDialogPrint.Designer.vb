<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDialogPrint
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
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("TBBLFormat", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Line")
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("LineName")
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.BLLineFormat = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.DataSetForm = New System.Data.DataSet()
        Me.DataTable1 = New System.Data.DataTable()
        Me.DataColumn1 = New System.Data.DataColumn()
        Me.DataColumn2 = New System.Data.DataColumn()
        Me.DataColumn3 = New System.Data.DataColumn()
        Me.DataColumn4 = New System.Data.DataColumn()
        Me.DataTable2 = New System.Data.DataTable()
        Me.DataColumn5 = New System.Data.DataColumn()
        Me.DataColumn6 = New System.Data.DataColumn()
        Me.DataColumn7 = New System.Data.DataColumn()
        Me.DataColumn8 = New System.Data.DataColumn()
        Me.DataColumn9 = New System.Data.DataColumn()
        Me.DataColumn11 = New System.Data.DataColumn()
        Me.DataColumn12 = New System.Data.DataColumn()
        Me.DataColumn13 = New System.Data.DataColumn()
        Me.DataColumn14 = New System.Data.DataColumn()
        Me.DataColumn15 = New System.Data.DataColumn()
        Me.DataColumn16 = New System.Data.DataColumn()
        Me.DataColumn17 = New System.Data.DataColumn()
        Me.DataColumn10 = New System.Data.DataColumn()
        Me.DataColumn18 = New System.Data.DataColumn()
        Me.DataColumn21 = New System.Data.DataColumn()
        Me.TBBLFormat = New System.Data.DataTable()
        Me.DataColumn19 = New System.Data.DataColumn()
        Me.DataColumn20 = New System.Data.DataColumn()
        Me.CheckAll = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BLtype = New Shipping.UserComboCode()
        Me.BlNo = New Shipping.UserText()
        Me.CheckForce = New System.Windows.Forms.CheckBox()
        Me.CheckAttach = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Details = New Shipping.UserMemo()
        Me.FrmPrnt_Button = New System.Windows.Forms.Button()
        Me.UltraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.CheckFormAttach = New System.Windows.Forms.CheckBox()
        Me.UltraGroupBox3 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.ShowImage = New System.Windows.Forms.CheckBox()
        Me.Button2 = New System.Windows.Forms.Button()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.BLLineFormat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSetForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TBBLFormat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckAll, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox2.SuspendLayout()
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.BLLineFormat)
        Me.UltraGroupBox1.Controls.Add(Me.CheckAll)
        Me.UltraGroupBox1.Controls.Add(Me.Label4)
        Me.UltraGroupBox1.Controls.Add(Me.Label2)
        Me.UltraGroupBox1.Controls.Add(Me.Label1)
        Me.UltraGroupBox1.Controls.Add(Me.BLtype)
        Me.UltraGroupBox1.Controls.Add(Me.BlNo)
        Me.UltraGroupBox1.Location = New System.Drawing.Point(13, 13)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(411, 121)
        Me.UltraGroupBox1.TabIndex = 1
        Me.UltraGroupBox1.Text = "Print B/L Option Settings"
        '
        'BLLineFormat
        '
        Me.BLLineFormat.CheckedListSettings.CheckStateMember = ""
        Me.BLLineFormat.DataMember = "TBBLFormat"
        Me.BLLineFormat.DataSource = Me.DataSetForm
        Appearance13.BackColor = System.Drawing.SystemColors.Window
        Appearance13.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.BLLineFormat.DisplayLayout.Appearance = Appearance13
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2})
        Me.BLLineFormat.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.BLLineFormat.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.BLLineFormat.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance14.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance14.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance14.BorderColor = System.Drawing.SystemColors.Window
        Me.BLLineFormat.DisplayLayout.GroupByBox.Appearance = Appearance14
        Appearance16.ForeColor = System.Drawing.SystemColors.GrayText
        Me.BLLineFormat.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance16
        Me.BLLineFormat.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance15.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance15.BackColor2 = System.Drawing.SystemColors.Control
        Appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance15.ForeColor = System.Drawing.SystemColors.GrayText
        Me.BLLineFormat.DisplayLayout.GroupByBox.PromptAppearance = Appearance15
        Me.BLLineFormat.DisplayLayout.MaxColScrollRegions = 1
        Me.BLLineFormat.DisplayLayout.MaxRowScrollRegions = 1
        Appearance21.BackColor = System.Drawing.SystemColors.Window
        Appearance21.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BLLineFormat.DisplayLayout.Override.ActiveCellAppearance = Appearance21
        Appearance17.BackColor = System.Drawing.SystemColors.Highlight
        Appearance17.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.BLLineFormat.DisplayLayout.Override.ActiveRowAppearance = Appearance17
        Me.BLLineFormat.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.BLLineFormat.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance24.BackColor = System.Drawing.SystemColors.Window
        Me.BLLineFormat.DisplayLayout.Override.CardAreaAppearance = Appearance24
        Appearance20.BorderColor = System.Drawing.Color.Silver
        Appearance20.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.BLLineFormat.DisplayLayout.Override.CellAppearance = Appearance20
        Me.BLLineFormat.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.BLLineFormat.DisplayLayout.Override.CellPadding = 0
        Appearance18.BackColor = System.Drawing.SystemColors.Control
        Appearance18.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance18.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance18.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance18.BorderColor = System.Drawing.SystemColors.Window
        Me.BLLineFormat.DisplayLayout.Override.GroupByRowAppearance = Appearance18
        Appearance19.TextHAlignAsString = "Left"
        Me.BLLineFormat.DisplayLayout.Override.HeaderAppearance = Appearance19
        Me.BLLineFormat.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.BLLineFormat.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance22.BackColor = System.Drawing.SystemColors.Window
        Appearance22.BorderColor = System.Drawing.Color.Silver
        Me.BLLineFormat.DisplayLayout.Override.RowAppearance = Appearance22
        Me.BLLineFormat.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance23.BackColor = System.Drawing.SystemColors.ControlLight
        Me.BLLineFormat.DisplayLayout.Override.TemplateAddRowAppearance = Appearance23
        Me.BLLineFormat.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.BLLineFormat.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.BLLineFormat.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.BLLineFormat.DisplayMember = "Line"
        Me.BLLineFormat.Location = New System.Drawing.Point(73, 79)
        Me.BLLineFormat.Name = "BLLineFormat"
        Me.BLLineFormat.PreferredDropDownSize = New System.Drawing.Size(0, 0)
        Me.BLLineFormat.Size = New System.Drawing.Size(305, 22)
        Me.BLLineFormat.TabIndex = 11
        Me.BLLineFormat.ValueMember = "Line"
        '
        'DataSetForm
        '
        Me.DataSetForm.DataSetName = "NewDataSet"
        Me.DataSetForm.Tables.AddRange(New System.Data.DataTable() {Me.DataTable1, Me.DataTable2, Me.TBBLFormat})
        '
        'DataTable1
        '
        Me.DataTable1.Columns.AddRange(New System.Data.DataColumn() {Me.DataColumn1, Me.DataColumn2, Me.DataColumn3, Me.DataColumn4})
        Me.DataTable1.TableName = "TBCluse"
        '
        'DataColumn1
        '
        Me.DataColumn1.ColumnName = "ID"
        Me.DataColumn1.DataType = GetType(System.Guid)
        '
        'DataColumn2
        '
        Me.DataColumn2.ColumnName = "CluseGroup"
        '
        'DataColumn3
        '
        Me.DataColumn3.ColumnName = "Description"
        '
        'DataColumn4
        '
        Me.DataColumn4.ColumnName = "Detail"
        '
        'DataTable2
        '
        Me.DataTable2.Columns.AddRange(New System.Data.DataColumn() {Me.DataColumn5, Me.DataColumn6, Me.DataColumn7, Me.DataColumn8, Me.DataColumn9, Me.DataColumn11, Me.DataColumn12, Me.DataColumn13, Me.DataColumn14, Me.DataColumn15, Me.DataColumn16, Me.DataColumn17, Me.DataColumn10, Me.DataColumn18, Me.DataColumn21})
        Me.DataTable2.TableName = "TBDetails"
        '
        'DataColumn5
        '
        Me.DataColumn5.ColumnName = "Seq"
        Me.DataColumn5.DataType = GetType(Integer)
        '
        'DataColumn6
        '
        Me.DataColumn6.ColumnName = "Cns"
        '
        'DataColumn7
        '
        Me.DataColumn7.ColumnName = "Pkgs"
        '
        'DataColumn8
        '
        Me.DataColumn8.ColumnName = "NPkgs"
        Me.DataColumn8.DataType = GetType(Long)
        '
        'DataColumn9
        '
        Me.DataColumn9.ColumnName = "Goods"
        '
        'DataColumn11
        '
        Me.DataColumn11.ColumnName = "NW"
        Me.DataColumn11.DataType = GetType(Double)
        '
        'DataColumn12
        '
        Me.DataColumn12.ColumnName = "GW"
        Me.DataColumn12.DataType = GetType(Double)
        '
        'DataColumn13
        '
        Me.DataColumn13.ColumnName = "TW"
        Me.DataColumn13.DataType = GetType(Double)
        '
        'DataColumn14
        '
        Me.DataColumn14.ColumnName = "BLNO"
        '
        'DataColumn15
        '
        Me.DataColumn15.ColumnName = "Vessel"
        '
        'DataColumn16
        '
        Me.DataColumn16.ColumnName = "Voyage"
        '
        'DataColumn17
        '
        Me.DataColumn17.ColumnName = "POD"
        '
        'DataColumn10
        '
        Me.DataColumn10.ColumnName = "Flag"
        '
        'DataColumn18
        '
        Me.DataColumn18.ColumnName = "FPOD"
        '
        'DataColumn21
        '
        Me.DataColumn21.ColumnName = "Column1"
        '
        'TBBLFormat
        '
        Me.TBBLFormat.Columns.AddRange(New System.Data.DataColumn() {Me.DataColumn19, Me.DataColumn20})
        Me.TBBLFormat.TableName = "TBBLFormat"
        '
        'DataColumn19
        '
        Me.DataColumn19.ColumnName = "Line"
        '
        'DataColumn20
        '
        Me.DataColumn20.ColumnName = "LineName"
        '
        'CheckAll
        '
        Me.CheckAll.Location = New System.Drawing.Point(265, 28)
        Me.CheckAll.Name = "CheckAll"
        Me.CheckAll.Size = New System.Drawing.Size(133, 20)
        Me.CheckAll.TabIndex = 10
        Me.CheckAll.Text = "Print All Selected B/Ls"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 79)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "PrintFormat"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "B/L type"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "B/L No."
        '
        'BLtype
        '
        Me.BLtype.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BLtype.Code = ""
        Me.BLtype.CustomShowAll = False
        Me.BLtype.Location = New System.Drawing.Point(73, 52)
        Me.BLtype.Name = "BLtype"
        Me.BLtype.Size = New System.Drawing.Size(187, 21)
        Me.BLtype.TabIndex = 1
        '
        'BlNo
        '
        Me.BlNo.BackColor = System.Drawing.Color.Transparent
        Me.BlNo.CustomMaxLength = CType(20, Byte)
        Me.BlNo.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BlNo.Location = New System.Drawing.Point(73, 27)
        Me.BlNo.Name = "BlNo"
        Me.BlNo.Size = New System.Drawing.Size(183, 19)
        Me.BlNo.TabIndex = 0
        Me.BlNo.TextValue = ""
        '
        'CheckForce
        '
        Me.CheckForce.AutoSize = True
        Me.CheckForce.Location = New System.Drawing.Point(6, 19)
        Me.CheckForce.Name = "CheckForce"
        Me.CheckForce.Size = New System.Drawing.Size(125, 17)
        Me.CheckForce.TabIndex = 5
        Me.CheckForce.Text = "Force To attachment"
        Me.CheckForce.UseVisualStyleBackColor = True
        '
        'CheckAttach
        '
        Me.CheckAttach.AutoSize = True
        Me.CheckAttach.Location = New System.Drawing.Point(6, 42)
        Me.CheckAttach.Name = "CheckAttach"
        Me.CheckAttach.Size = New System.Drawing.Size(98, 17)
        Me.CheckAttach.TabIndex = 4
        Me.CheckAttach.Text = "Print Attchment"
        Me.CheckAttach.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Details)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 140)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(412, 120)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Cluses Detail"
        '
        'Details
        '
        Me.Details.Location = New System.Drawing.Point(9, 19)
        Me.Details.Name = "Details"
        Me.Details.Size = New System.Drawing.Size(388, 87)
        Me.Details.TabIndex = 0
        Me.Details.TextValue = ""
        '
        'FrmPrnt_Button
        '
        Me.FrmPrnt_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.FrmPrnt_Button.Location = New System.Drawing.Point(106, 37)
        Me.FrmPrnt_Button.Name = "FrmPrnt_Button"
        Me.FrmPrnt_Button.Size = New System.Drawing.Size(88, 23)
        Me.FrmPrnt_Button.TabIndex = 3
        Me.FrmPrnt_Button.Text = "Print Attachment"
        '
        'UltraGroupBox2
        '
        Me.UltraGroupBox2.Controls.Add(Me.CheckFormAttach)
        Me.UltraGroupBox2.Controls.Add(Me.FrmPrnt_Button)
        Me.UltraGroupBox2.Location = New System.Drawing.Point(13, 267)
        Me.UltraGroupBox2.Name = "UltraGroupBox2"
        Me.UltraGroupBox2.Size = New System.Drawing.Size(200, 86)
        Me.UltraGroupBox2.TabIndex = 4
        Me.UltraGroupBox2.Text = "B/L Form"
        '
        'CheckFormAttach
        '
        Me.CheckFormAttach.AutoSize = True
        Me.CheckFormAttach.Location = New System.Drawing.Point(8, 19)
        Me.CheckFormAttach.Name = "CheckFormAttach"
        Me.CheckFormAttach.Size = New System.Drawing.Size(98, 17)
        Me.CheckFormAttach.TabIndex = 5
        Me.CheckFormAttach.Text = "Print Attchment"
        Me.CheckFormAttach.UseVisualStyleBackColor = True
        '
        'UltraGroupBox3
        '
        Me.UltraGroupBox3.Controls.Add(Me.ShowImage)
        Me.UltraGroupBox3.Controls.Add(Me.Button2)
        Me.UltraGroupBox3.Controls.Add(Me.CheckForce)
        Me.UltraGroupBox3.Controls.Add(Me.CheckAttach)
        Me.UltraGroupBox3.Location = New System.Drawing.Point(224, 266)
        Me.UltraGroupBox3.Name = "UltraGroupBox3"
        Me.UltraGroupBox3.Size = New System.Drawing.Size(200, 89)
        Me.UltraGroupBox3.TabIndex = 5
        Me.UltraGroupBox3.Text = "B/L Original"
        '
        'ShowImage
        '
        Me.ShowImage.AutoSize = True
        Me.ShowImage.Location = New System.Drawing.Point(6, 65)
        Me.ShowImage.Name = "ShowImage"
        Me.ShowImage.Size = New System.Drawing.Size(85, 17)
        Me.ShowImage.TabIndex = 6
        Me.ShowImage.Text = "Show Image"
        Me.ShowImage.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button2.Location = New System.Drawing.Point(103, 36)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(88, 23)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Print Attachment"
        '
        'FrmDialogPrint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(438, 371)
        Me.Controls.Add(Me.UltraGroupBox3)
        Me.Controls.Add(Me.UltraGroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmDialogPrint"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Print B/L"
        Me.TopMost = True
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        CType(Me.BLLineFormat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSetForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TBBLFormat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckAll, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox2.ResumeLayout(False)
        Me.UltraGroupBox2.PerformLayout()
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox3.ResumeLayout(False)
        Me.UltraGroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents BlNo As Shipping.UserText
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BLtype As Shipping.UserComboCode
    Friend WithEvents CheckAttach As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CheckForce As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Details As Shipping.UserMemo
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DataSetForm As System.Data.DataSet
    Friend WithEvents DataTable1 As System.Data.DataTable
    Friend WithEvents DataColumn1 As System.Data.DataColumn
    Friend WithEvents DataColumn2 As System.Data.DataColumn
    Friend WithEvents DataColumn3 As System.Data.DataColumn
    Friend WithEvents DataColumn4 As System.Data.DataColumn
    Friend WithEvents DataTable2 As System.Data.DataTable
    Friend WithEvents DataColumn5 As System.Data.DataColumn
    Friend WithEvents DataColumn6 As System.Data.DataColumn
    Friend WithEvents DataColumn7 As System.Data.DataColumn
    Friend WithEvents DataColumn8 As System.Data.DataColumn
    Friend WithEvents DataColumn9 As System.Data.DataColumn
    Friend WithEvents DataColumn11 As System.Data.DataColumn
    Friend WithEvents DataColumn12 As System.Data.DataColumn
    Friend WithEvents DataColumn13 As System.Data.DataColumn
    Friend WithEvents DataColumn14 As System.Data.DataColumn
    Friend WithEvents DataColumn15 As System.Data.DataColumn
    Friend WithEvents DataColumn16 As System.Data.DataColumn
    Friend WithEvents DataColumn17 As System.Data.DataColumn
    Friend WithEvents DataColumn10 As System.Data.DataColumn
    Friend WithEvents FrmPrnt_Button As System.Windows.Forms.Button
    Friend WithEvents UltraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraGroupBox3 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents CheckFormAttach As System.Windows.Forms.CheckBox
    Friend WithEvents DataColumn18 As System.Data.DataColumn
    Friend WithEvents ShowImage As System.Windows.Forms.CheckBox
    Friend WithEvents CheckAll As Infragistics.Win.UltraWinEditors.UltraCheckEditor

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Friend WithEvents BLLineFormat As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents TBBLFormat As System.Data.DataTable
    Friend WithEvents DataColumn19 As System.Data.DataColumn
    Friend WithEvents DataColumn20 As System.Data.DataColumn
    Friend WithEvents DataColumn21 As System.Data.DataColumn
End Class
