<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReferences
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
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("CodeMaster", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("GroupCode")
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("GroupName")
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID")
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
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.FormDataSet = New System.Data.DataSet
        Me.DataTable1 = New System.Data.DataTable
        Me.DataColumn1 = New System.Data.DataColumn
        Me.DataColumn2 = New System.Data.DataColumn
        Me.DataColumn3 = New System.Data.DataColumn
        Me.DataTable2 = New System.Data.DataTable
        Me.DataColumn4 = New System.Data.DataColumn
        Me.DataColumn5 = New System.Data.DataColumn
        Me.DataColumn6 = New System.Data.DataColumn
        Me.DataColumn7 = New System.Data.DataColumn
        Me.DataColumn8 = New System.Data.DataColumn
        Me.DataColumn9 = New System.Data.DataColumn
        Me.DataColumn10 = New System.Data.DataColumn
        Me.CmbMain = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.GridCodes = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.GroupBox = New Infragistics.Win.Misc.UltraGroupBox
        Me.MeaningF = New Shipping.UserTextFarsi
        Me.Meaning = New Shipping.UserText
        Me.StdCode = New Shipping.UserText
        Me.UltraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GeneralForms = New Shipping.UserGeneralForms
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        CType(Me.FormDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CmbMain, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.GridCodes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox.SuspendLayout()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'FormDataSet
        '
        Me.FormDataSet.DataSetName = "NewDataSet"
        Me.FormDataSet.Tables.AddRange(New System.Data.DataTable() {Me.DataTable1, Me.DataTable2})
        '
        'DataTable1
        '
        Me.DataTable1.Columns.AddRange(New System.Data.DataColumn() {Me.DataColumn1, Me.DataColumn2, Me.DataColumn3})
        Me.DataTable1.TableName = "CodeMaster"
        '
        'DataColumn1
        '
        Me.DataColumn1.Caption = "GroupCode"
        Me.DataColumn1.ColumnName = "GroupCode"
        '
        'DataColumn2
        '
        Me.DataColumn2.Caption = "GroupName"
        Me.DataColumn2.ColumnName = "GroupName"
        '
        'DataColumn3
        '
        Me.DataColumn3.Caption = "ID"
        Me.DataColumn3.ColumnName = "ID"
        Me.DataColumn3.DataType = GetType(System.Guid)
        '
        'DataTable2
        '
        Me.DataTable2.Columns.AddRange(New System.Data.DataColumn() {Me.DataColumn4, Me.DataColumn5, Me.DataColumn6, Me.DataColumn7, Me.DataColumn8, Me.DataColumn9, Me.DataColumn10})
        Me.DataTable2.TableName = "Codes"
        '
        'DataColumn4
        '
        Me.DataColumn4.ColumnName = "ID"
        Me.DataColumn4.DataType = GetType(System.Guid)
        '
        'DataColumn5
        '
        Me.DataColumn5.ColumnName = "GroupCode"
        '
        'DataColumn6
        '
        Me.DataColumn6.Caption = "Code"
        Me.DataColumn6.ColumnName = "StdCode"
        '
        'DataColumn7
        '
        Me.DataColumn7.ColumnName = "NextCode"
        '
        'DataColumn8
        '
        Me.DataColumn8.Caption = "Description"
        Me.DataColumn8.ColumnName = "Meaning"
        '
        'DataColumn9
        '
        Me.DataColumn9.Caption = "Persian Description"
        Me.DataColumn9.ColumnName = "MeaningF"
        '
        'DataColumn10
        '
        Me.DataColumn10.ColumnName = "IsEditable"
        Me.DataColumn10.DataType = GetType(Boolean)
        '
        'CmbMain
        '
        Me.CmbMain.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CmbMain.DataSource = Me.FormDataSet
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.CmbMain.DisplayLayout.Appearance = Appearance1
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn3.Header.VisiblePosition = 2
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3})
        Me.CmbMain.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.CmbMain.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.CmbMain.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.SystemColors.Window
        Me.CmbMain.DisplayLayout.GroupByBox.Appearance = Appearance2
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.CmbMain.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
        Me.CmbMain.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance4.BackColor2 = System.Drawing.SystemColors.Control
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.CmbMain.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
        Me.CmbMain.DisplayLayout.MaxColScrollRegions = 1
        Me.CmbMain.DisplayLayout.MaxRowScrollRegions = 1
        Appearance5.BackColor = System.Drawing.SystemColors.Window
        Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmbMain.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.SystemColors.Highlight
        Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.CmbMain.DisplayLayout.Override.ActiveRowAppearance = Appearance6
        Me.CmbMain.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.CmbMain.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Me.CmbMain.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.CmbMain.DisplayLayout.Override.CellAppearance = Appearance8
        Me.CmbMain.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.CmbMain.DisplayLayout.Override.CellPadding = 0
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.CmbMain.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance10.TextHAlign = Infragistics.Win.HAlign.Left
        Me.CmbMain.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.CmbMain.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.CmbMain.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Me.CmbMain.DisplayLayout.Override.RowAppearance = Appearance11
        Me.CmbMain.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CmbMain.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
        Me.CmbMain.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.CmbMain.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.CmbMain.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.CmbMain.DisplayMember = "GroupName"
        Me.CmbMain.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.CmbMain.Location = New System.Drawing.Point(102, 18)
        Me.CmbMain.Name = "CmbMain"
        Me.CmbMain.Size = New System.Drawing.Size(166, 22)
        Me.CmbMain.TabIndex = 1
        Me.CmbMain.ValueMember = "GroupCode"
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.GridCodes)
        Me.UltraGroupBox1.Location = New System.Drawing.Point(17, 156)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(593, 261)
        Me.UltraGroupBox1.SupportThemes = False
        Me.UltraGroupBox1.TabIndex = 11
        Me.UltraGroupBox1.Text = "List Of Codes"
        '
        'GridCodes
        '
        Appearance13.BackColor = System.Drawing.Color.WhiteSmoke
        Appearance13.BackColor2 = System.Drawing.Color.White
        Appearance13.BackHatchStyle = Infragistics.Win.BackHatchStyle.LightHorizontal
        Me.GridCodes.DisplayLayout.Appearance = Appearance13
        Me.GridCodes.DisplayLayout.GroupByBox.Hidden = True
        Me.GridCodes.DisplayLayout.InterBandSpacing = 10
        Me.GridCodes.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.GridCodes.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.GridCodes.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.GridCodes.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.[False]
        Me.GridCodes.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.GridCodes.DisplayLayout.Override.BorderStyleHeader = Infragistics.Win.UIElementBorderStyle.Etched
        Me.GridCodes.DisplayLayout.Override.BorderStyleRowSelector = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance14.BackColor = System.Drawing.Color.Transparent
        Me.GridCodes.DisplayLayout.Override.CardAreaAppearance = Appearance14
        Appearance15.BackColor = System.Drawing.Color.LightYellow
        Appearance15.BackColor2 = System.Drawing.Color.PaleGoldenrod
        Appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.GridCodes.DisplayLayout.Override.CellAppearance = Appearance15
        Appearance16.BackColor = System.Drawing.Color.CornflowerBlue
        Appearance16.BackColor2 = System.Drawing.Color.RoyalBlue
        Appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance16.FontData.SizeInPoints = 10.0!
        Appearance16.ForeColor = System.Drawing.Color.Navy
        Appearance16.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.GridCodes.DisplayLayout.Override.HeaderAppearance = Appearance16
        Me.GridCodes.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance17.BackColor = System.Drawing.Color.Transparent
        Appearance17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridCodes.DisplayLayout.Override.RowSelectorAppearance = Appearance17
        Me.GridCodes.DisplayLayout.Override.RowSelectorWidth = 10
        Me.GridCodes.DisplayLayout.Override.RowSpacingAfter = 3
        Me.GridCodes.DisplayLayout.Override.RowSpacingBefore = 3
        Appearance18.BackColor = System.Drawing.Color.Navy
        Appearance18.BackGradientStyle = Infragistics.Win.GradientStyle.None
        Appearance18.BackHatchStyle = Infragistics.Win.BackHatchStyle.None
        Appearance18.ForeColor = System.Drawing.Color.White
        Me.GridCodes.DisplayLayout.Override.SelectedRowAppearance = Appearance18
        Me.GridCodes.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridCodes.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid
        Me.GridCodes.DisplayLayout.UseFixedHeaders = True
        Me.GridCodes.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.GridCodes.Location = New System.Drawing.Point(12, 19)
        Me.GridCodes.Name = "GridCodes"
        Me.GridCodes.Size = New System.Drawing.Size(566, 225)
        Me.GridCodes.TabIndex = 11
        '
        'GroupBox
        '
        Appearance19.BackColor = System.Drawing.Color.CornflowerBlue
        Appearance19.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance19.BorderColor = System.Drawing.Color.White
        Appearance19.BorderColor3DBase = System.Drawing.Color.White
        Me.GroupBox.Appearance = Appearance19
        Me.GroupBox.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.GroupBox.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.RectangularRaised
        Me.GroupBox.Controls.Add(Me.Label4)
        Me.GroupBox.Controls.Add(Me.Label3)
        Me.GroupBox.Controls.Add(Me.Label2)
        Me.GroupBox.Controls.Add(Me.MeaningF)
        Me.GroupBox.Controls.Add(Me.Meaning)
        Me.GroupBox.Controls.Add(Me.StdCode)
        Me.GroupBox.Location = New System.Drawing.Point(17, 46)
        Me.GroupBox.Name = "GroupBox"
        Me.GroupBox.Size = New System.Drawing.Size(593, 104)
        Me.GroupBox.SupportThemes = False
        Me.GroupBox.TabIndex = 12
        '
        'MeaningF
        '
        Me.MeaningF.Location = New System.Drawing.Point(79, 66)
        Me.MeaningF.Name = "MeaningF"
        Me.MeaningF.Size = New System.Drawing.Size(350, 22)
        Me.MeaningF.TabIndex = 3
        Me.MeaningF.TextValue = ""
        '
        'Meaning
        '
        Me.Meaning.BackColor = System.Drawing.Color.Transparent
        Me.Meaning.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Meaning.Location = New System.Drawing.Point(80, 42)
        Me.Meaning.Name = "Meaning"
        Me.Meaning.Size = New System.Drawing.Size(348, 20)
        Me.Meaning.TabIndex = 2
        Me.Meaning.TextValue = ""
        '
        'StdCode
        '
        Me.StdCode.BackColor = System.Drawing.Color.Transparent
        Me.StdCode.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.StdCode.Location = New System.Drawing.Point(80, 18)
        Me.StdCode.Name = "StdCode"
        Me.StdCode.Size = New System.Drawing.Size(67, 20)
        Me.StdCode.TabIndex = 1
        Me.StdCode.TextValue = ""
        '
        'UltraGroupBox2
        '
        Me.UltraGroupBox2.Controls.Add(Me.Label1)
        Me.UltraGroupBox2.Controls.Add(Me.CmbMain)
        Me.UltraGroupBox2.Controls.Add(Me.UltraGroupBox1)
        Me.UltraGroupBox2.Controls.Add(Me.GroupBox)
        Me.UltraGroupBox2.Location = New System.Drawing.Point(12, 39)
        Me.UltraGroupBox2.Name = "UltraGroupBox2"
        Me.UltraGroupBox2.Size = New System.Drawing.Size(633, 436)
        Me.UltraGroupBox2.SupportThemes = False
        Me.UltraGroupBox2.TabIndex = 13
        Me.UltraGroupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.VisualStudio2005
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Group Code"
        '
        'GeneralForms
        '
        Me.GeneralForms.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GeneralForms.Location = New System.Drawing.Point(0, 0)
        Me.GeneralForms.Name = "GeneralForms"
        Me.GeneralForms.Size = New System.Drawing.Size(657, 487)
        Me.GeneralForms.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 13)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Code"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(20, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 13)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Name"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(20, 70)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 13)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "F.Name"
        '
        'FrmReferences
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(657, 487)
        Me.Controls.Add(Me.UltraGroupBox2)
        Me.Controls.Add(Me.GeneralForms)
        Me.Name = "FrmReferences"
        Me.Text = "CODING"
        CType(Me.FormDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CmbMain, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        CType(Me.GridCodes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox.ResumeLayout(False)
        Me.GroupBox.PerformLayout()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox2.ResumeLayout(False)
        Me.UltraGroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GeneralForms As Shipping.UserGeneralForms
    Friend WithEvents FormDataSet As System.Data.DataSet
    Friend WithEvents DataTable1 As System.Data.DataTable
    Friend WithEvents DataColumn1 As System.Data.DataColumn
    Friend WithEvents DataColumn2 As System.Data.DataColumn
    Friend WithEvents DataColumn3 As System.Data.DataColumn
    Friend WithEvents CmbMain As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents DataTable2 As System.Data.DataTable
    Friend WithEvents DataColumn4 As System.Data.DataColumn
    Friend WithEvents DataColumn5 As System.Data.DataColumn
    Friend WithEvents DataColumn6 As System.Data.DataColumn
    Friend WithEvents DataColumn7 As System.Data.DataColumn
    Friend WithEvents DataColumn8 As System.Data.DataColumn
    Friend WithEvents DataColumn9 As System.Data.DataColumn
    Friend WithEvents DataColumn10 As System.Data.DataColumn
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents GridCodes As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents GroupBox As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents MeaningF As Shipping.UserTextFarsi
    Friend WithEvents Meaning As Shipping.UserText
    Friend WithEvents StdCode As Shipping.UserText
    Friend WithEvents UltraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
