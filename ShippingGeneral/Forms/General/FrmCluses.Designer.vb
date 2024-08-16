<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCluses
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
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.GeneralForms = New Shipping.UserGeneralForms
        Me.UltraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.GridCluses = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.GroupBox = New Infragistics.Win.Misc.UltraGroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.CluseGroup = New Shipping.UserComboCode
        Me.Detail = New Shipping.UserMemo
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Description = New Shipping.UserText
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
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox2.SuspendLayout()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.GridCluses, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox.SuspendLayout()
        CType(Me.FormDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GeneralForms
        '
        Me.GeneralForms.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GeneralForms.Location = New System.Drawing.Point(0, 0)
        Me.GeneralForms.Name = "GeneralForms"
        Me.GeneralForms.Size = New System.Drawing.Size(602, 547)
        Me.GeneralForms.TabIndex = 0
        '
        'UltraGroupBox2
        '
        Me.UltraGroupBox2.Controls.Add(Me.UltraGroupBox1)
        Me.UltraGroupBox2.Controls.Add(Me.GroupBox)
        Me.UltraGroupBox2.Location = New System.Drawing.Point(12, 47)
        Me.UltraGroupBox2.Name = "UltraGroupBox2"
        Me.UltraGroupBox2.Size = New System.Drawing.Size(577, 488)
        Me.UltraGroupBox2.SupportThemes = False
        Me.UltraGroupBox2.TabIndex = 14
        Me.UltraGroupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.VisualStudio2005
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.GridCluses)
        Me.UltraGroupBox1.Location = New System.Drawing.Point(17, 229)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(542, 243)
        Me.UltraGroupBox1.SupportThemes = False
        Me.UltraGroupBox1.TabIndex = 11
        Me.UltraGroupBox1.Text = "List Of Cluses"
        '
        'GridCluses
        '
        Appearance1.BackColor = System.Drawing.Color.WhiteSmoke
        Appearance1.BackColor2 = System.Drawing.Color.White
        Appearance1.BackHatchStyle = Infragistics.Win.BackHatchStyle.LightHorizontal
        Me.GridCluses.DisplayLayout.Appearance = Appearance1
        Me.GridCluses.DisplayLayout.GroupByBox.Hidden = True
        Me.GridCluses.DisplayLayout.InterBandSpacing = 10
        Me.GridCluses.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.GridCluses.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.GridCluses.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.GridCluses.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.[False]
        Me.GridCluses.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.GridCluses.DisplayLayout.Override.BorderStyleHeader = Infragistics.Win.UIElementBorderStyle.Etched
        Me.GridCluses.DisplayLayout.Override.BorderStyleRowSelector = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance2.BackColor = System.Drawing.Color.Transparent
        Me.GridCluses.DisplayLayout.Override.CardAreaAppearance = Appearance2
        Appearance3.BackColor = System.Drawing.Color.LightYellow
        Appearance3.BackColor2 = System.Drawing.Color.PaleGoldenrod
        Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.GridCluses.DisplayLayout.Override.CellAppearance = Appearance3
        Appearance4.BackColor = System.Drawing.Color.CornflowerBlue
        Appearance4.BackColor2 = System.Drawing.Color.RoyalBlue
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance4.FontData.SizeInPoints = 10.0!
        Appearance4.ForeColor = System.Drawing.Color.Navy
        Appearance4.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.GridCluses.DisplayLayout.Override.HeaderAppearance = Appearance4
        Me.GridCluses.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance5.BackColor = System.Drawing.Color.Transparent
        Appearance5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridCluses.DisplayLayout.Override.RowSelectorAppearance = Appearance5
        Me.GridCluses.DisplayLayout.Override.RowSelectorWidth = 10
        Me.GridCluses.DisplayLayout.Override.RowSpacingAfter = 3
        Me.GridCluses.DisplayLayout.Override.RowSpacingBefore = 3
        Appearance6.BackColor = System.Drawing.Color.Navy
        Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.None
        Appearance6.BackHatchStyle = Infragistics.Win.BackHatchStyle.None
        Appearance6.ForeColor = System.Drawing.Color.White
        Me.GridCluses.DisplayLayout.Override.SelectedRowAppearance = Appearance6
        Me.GridCluses.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridCluses.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid
        Me.GridCluses.DisplayLayout.UseFixedHeaders = True
        Me.GridCluses.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.GridCluses.Location = New System.Drawing.Point(12, 19)
        Me.GridCluses.Name = "GridCluses"
        Me.GridCluses.Size = New System.Drawing.Size(513, 207)
        Me.GridCluses.TabIndex = 11
        '
        'GroupBox
        '
        Appearance7.BackColor = System.Drawing.Color.CornflowerBlue
        Appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance7.BorderColor = System.Drawing.Color.White
        Appearance7.BorderColor3DBase = System.Drawing.Color.White
        Me.GroupBox.Appearance = Appearance7
        Me.GroupBox.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.GroupBox.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.RectangularRaised
        Me.GroupBox.Controls.Add(Me.Label1)
        Me.GroupBox.Controls.Add(Me.CluseGroup)
        Me.GroupBox.Controls.Add(Me.Detail)
        Me.GroupBox.Controls.Add(Me.Label3)
        Me.GroupBox.Controls.Add(Me.Label2)
        Me.GroupBox.Controls.Add(Me.Description)
        Me.GroupBox.Location = New System.Drawing.Point(17, 20)
        Me.GroupBox.Name = "GroupBox"
        Me.GroupBox.Size = New System.Drawing.Size(542, 202)
        Me.GroupBox.SupportThemes = False
        Me.GroupBox.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Section"
        '
        'CluseGroup
        '
        Me.CluseGroup.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CluseGroup.Code = ""
        Me.CluseGroup.CustomShowAll = False
        Me.CluseGroup.Location = New System.Drawing.Point(87, 43)
        Me.CluseGroup.Name = "CluseGroup"
        Me.CluseGroup.Size = New System.Drawing.Size(203, 21)
        Me.CluseGroup.TabIndex = 21
        '
        'Detail
        '
        Me.Detail.Location = New System.Drawing.Point(87, 68)
        Me.Detail.Name = "Detail"
        Me.Detail.Size = New System.Drawing.Size(438, 121)
        Me.Detail.TabIndex = 20
        Me.Detail.TextValue = ""
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(20, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Details"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Description"
        '
        'Description
        '
        Me.Description.BackColor = System.Drawing.Color.Transparent
        Me.Description.CustomMaxLength = CType(100, Byte)
        Me.Description.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Description.Location = New System.Drawing.Point(87, 18)
        Me.Description.Name = "Description"
        Me.Description.Size = New System.Drawing.Size(438, 20)
        Me.Description.TabIndex = 1
        Me.Description.TextValue = ""
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
        'FrmCluses
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(602, 547)
        Me.Controls.Add(Me.UltraGroupBox2)
        Me.Controls.Add(Me.GeneralForms)
        Me.Name = "FrmCluses"
        Me.Text = "Cluses"
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox2.ResumeLayout(False)
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        CType(Me.GridCluses, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox.ResumeLayout(False)
        Me.GroupBox.PerformLayout()
        CType(Me.FormDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GeneralForms As Shipping.UserGeneralForms
    Friend WithEvents UltraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents GridCluses As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents GroupBox As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents Detail As Shipping.UserMemo
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Description As Shipping.UserText
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CluseGroup As Shipping.UserComboCode
    Friend WithEvents FormDataSet As System.Data.DataSet
    Friend WithEvents DataTable1 As System.Data.DataTable
    Friend WithEvents DataColumn1 As System.Data.DataColumn
    Friend WithEvents DataColumn2 As System.Data.DataColumn
    Friend WithEvents DataColumn3 As System.Data.DataColumn
    Friend WithEvents DataTable2 As System.Data.DataTable
    Friend WithEvents DataColumn4 As System.Data.DataColumn
    Friend WithEvents DataColumn5 As System.Data.DataColumn
    Friend WithEvents DataColumn6 As System.Data.DataColumn
    Friend WithEvents DataColumn7 As System.Data.DataColumn
    Friend WithEvents DataColumn8 As System.Data.DataColumn
    Friend WithEvents DataColumn9 As System.Data.DataColumn
    Friend WithEvents DataColumn10 As System.Data.DataColumn
End Class
