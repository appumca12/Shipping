<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEcsBankImport
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
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.UltraTabPageControl2 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.DataSetForm = New System.Data.DataSet
        Me.DataTable1 = New System.Data.DataTable
        Me.DataColumn1 = New System.Data.DataColumn
        Me.DataColumn2 = New System.Data.DataColumn
        Me.DataColumn3 = New System.Data.DataColumn
        Me.DataColumn4 = New System.Data.DataColumn
        Me.DataColumn5 = New System.Data.DataColumn
        Me.DataColumn6 = New System.Data.DataColumn
        Me.DataColumn7 = New System.Data.DataColumn
        Me.DataColumn8 = New System.Data.DataColumn
        Me.DataColumn12 = New System.Data.DataColumn
        Me.DataColumn13 = New System.Data.DataColumn
        Me.DataColumn14 = New System.Data.DataColumn
        Me.DataTable2 = New System.Data.DataTable
        Me.DataColumn9 = New System.Data.DataColumn
        Me.DataColumn10 = New System.Data.DataColumn
        Me.DataColumn11 = New System.Data.DataColumn
        Me.Selection = New System.Windows.Forms.GroupBox
        Me.ButtonAll = New System.Windows.Forms.RadioButton
        Me.ButtonExists = New System.Windows.Forms.RadioButton
        Me.ButtonNoExists = New System.Windows.Forms.RadioButton
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
        Me.MenuItem = New Shipping.UserMenuItem
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.FleName = New Shipping.UserText
        Me.gridCntrs = New System.Windows.Forms.DataGridView
        Me.Button1 = New System.Windows.Forms.Button
        CType(Me.DataSetForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Selection.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.gridCntrs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(2, 21)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(874, 231)
        '
        'UltraTabPageControl2
        '
        Me.UltraTabPageControl2.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl2.Name = "UltraTabPageControl2"
        Me.UltraTabPageControl2.Size = New System.Drawing.Size(874, 231)
        '
        'DataSetForm
        '
        Me.DataSetForm.DataSetName = "NewDataSet"
        Me.DataSetForm.Tables.AddRange(New System.Data.DataTable() {Me.DataTable1, Me.DataTable2})
        '
        'DataTable1
        '
        Me.DataTable1.Columns.AddRange(New System.Data.DataColumn() {Me.DataColumn1, Me.DataColumn2, Me.DataColumn3, Me.DataColumn4, Me.DataColumn5, Me.DataColumn6, Me.DataColumn7, Me.DataColumn8, Me.DataColumn12, Me.DataColumn13, Me.DataColumn14})
        Me.DataTable1.TableName = "TB"
        '
        'DataColumn1
        '
        Me.DataColumn1.Caption = "ShowBL"
        Me.DataColumn1.ColumnName = "ShowBL"
        '
        'DataColumn2
        '
        Me.DataColumn2.ColumnName = "Cnee"
        '
        'DataColumn3
        '
        Me.DataColumn3.ColumnName = "Status"
        '
        'DataColumn4
        '
        Me.DataColumn4.ColumnName = "Goods"
        '
        'DataColumn5
        '
        Me.DataColumn5.ColumnName = "Client"
        '
        'DataColumn6
        '
        Me.DataColumn6.ColumnName = "ClientID"
        Me.DataColumn6.DataType = GetType(System.Guid)
        '
        'DataColumn7
        '
        Me.DataColumn7.ColumnName = "Select"
        Me.DataColumn7.DataType = GetType(Boolean)
        '
        'DataColumn8
        '
        Me.DataColumn8.ColumnName = "Exists"
        Me.DataColumn8.DataType = GetType(Boolean)
        '
        'DataColumn12
        '
        Me.DataColumn12.Caption = "Marks & No"
        Me.DataColumn12.ColumnName = "Marks"
        '
        'DataColumn13
        '
        Me.DataColumn13.Caption = "BLNO"
        Me.DataColumn13.ColumnName = "BLNO"
        '
        'DataColumn14
        '
        Me.DataColumn14.ColumnName = "Notify"
        '
        'DataTable2
        '
        Me.DataTable2.Columns.AddRange(New System.Data.DataColumn() {Me.DataColumn9, Me.DataColumn10, Me.DataColumn11})
        Me.DataTable2.TableName = "Errors"
        '
        'DataColumn9
        '
        Me.DataColumn9.Caption = "Where"
        Me.DataColumn9.ColumnName = "TableName"
        '
        'DataColumn10
        '
        Me.DataColumn10.Caption = "What"
        Me.DataColumn10.ColumnName = "Code"
        '
        'DataColumn11
        '
        Me.DataColumn11.ColumnName = "sValue"
        '
        'Selection
        '
        Me.Selection.Controls.Add(Me.ButtonAll)
        Me.Selection.Controls.Add(Me.ButtonExists)
        Me.Selection.Controls.Add(Me.ButtonNoExists)
        Me.Selection.Location = New System.Drawing.Point(472, 19)
        Me.Selection.Name = "Selection"
        Me.Selection.Size = New System.Drawing.Size(247, 42)
        Me.Selection.TabIndex = 8
        Me.Selection.TabStop = False
        Me.Selection.Text = "Record Selector"
        '
        'ButtonAll
        '
        Me.ButtonAll.AutoSize = True
        Me.ButtonAll.Location = New System.Drawing.Point(183, 16)
        Me.ButtonAll.Name = "ButtonAll"
        Me.ButtonAll.Size = New System.Drawing.Size(36, 17)
        Me.ButtonAll.TabIndex = 2
        Me.ButtonAll.Text = "All"
        Me.ButtonAll.UseVisualStyleBackColor = True
        '
        'ButtonExists
        '
        Me.ButtonExists.AutoSize = True
        Me.ButtonExists.Location = New System.Drawing.Point(109, 16)
        Me.ButtonExists.Name = "ButtonExists"
        Me.ButtonExists.Size = New System.Drawing.Size(59, 17)
        Me.ButtonExists.TabIndex = 1
        Me.ButtonExists.Text = "Existed"
        Me.ButtonExists.UseVisualStyleBackColor = True
        '
        'ButtonNoExists
        '
        Me.ButtonNoExists.AutoSize = True
        Me.ButtonNoExists.Checked = True
        Me.ButtonNoExists.Location = New System.Drawing.Point(15, 16)
        Me.ButtonNoExists.Name = "ButtonNoExists"
        Me.ButtonNoExists.Size = New System.Drawing.Size(79, 17)
        Me.ButtonNoExists.TabIndex = 0
        Me.ButtonNoExists.TabStop = True
        Me.ButtonNoExists.Text = "Not Existed"
        Me.ButtonNoExists.UseVisualStyleBackColor = True
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(874, 231)
        '
        'MenuItem
        '
        Me.MenuItem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MenuItem.Location = New System.Drawing.Point(3, 3)
        Me.MenuItem.Name = "MenuItem"
        Me.MenuItem.ShowAdditional = False
        Me.MenuItem.ShowCancel = False
        Me.MenuItem.ShowConfirm = False
        Me.MenuItem.ShowDelete = False
        Me.MenuItem.ShowDeposits = False
        Me.MenuItem.ShowDeSelectAll = False
        Me.MenuItem.ShowEdit = False
        Me.MenuItem.ShowExcel = False
        Me.MenuItem.ShowFileOpen = True
        Me.MenuItem.ShowNew = False
        Me.MenuItem.ShowPickup = True
        Me.MenuItem.ShowPrint = False
        Me.MenuItem.ShowProcess = False
        Me.MenuItem.ShowRecivedItems = False
        Me.MenuItem.ShowRefresh = False
        Me.MenuItem.ShowRest = False
        Me.MenuItem.ShowSave = False
        Me.MenuItem.ShowSelectAll = False
        Me.MenuItem.Size = New System.Drawing.Size(878, 32)
        Me.MenuItem.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.MenuItem, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.gridCntrs, 0, 3)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(884, 478)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.FleName)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(3, 41)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(878, 74)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "File Name"

        '
        'FleName
        '
        Me.FleName.AutoComplete = False
        Me.FleName.AutoCompleteColumnName = Nothing
        Me.FleName.AutoCompleteExtraWhere = Nothing
        Me.FleName.AutoCompleteTableName = Nothing
        Me.FleName.BackColor = System.Drawing.Color.Transparent
        Me.FleName.CustomMaxLength = CType(100, Byte)
        Me.FleName.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.FleName.Location = New System.Drawing.Point(91, 45)
        Me.FleName.Name = "FleName"
        Me.FleName.Size = New System.Drawing.Size(366, 19)
        Me.FleName.TabIndex = 3
        Me.FleName.TextValue = ""
        '
        'gridCntrs
        '
        Me.gridCntrs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridCntrs.Location = New System.Drawing.Point(3, 129)
        Me.gridCntrs.Name = "gridCntrs"
        Me.gridCntrs.Size = New System.Drawing.Size(473, 201)
        Me.gridCntrs.TabIndex = 3
        Me.gridCntrs.Visible = False
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Impact", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button1.Location = New System.Drawing.Point(502, 29)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(110, 25)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Sample Excel"

        Me.Button1.UseVisualStyleBackColor = True
        '
        'FrmEcsBankImport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 478)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "FrmEcsBankImport"
        Me.Text = "Container Import"
        CType(Me.DataSetForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Selection.ResumeLayout(False)
        Me.Selection.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.gridCntrs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents FleName As Shipping.UserText
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox

    Friend WithEvents VoyNo As Shipping.UserText
    Friend WithEvents VslName As Shipping.UserText
    Friend WithEvents DataSetForm As System.Data.DataSet
    Friend WithEvents DataTable1 As System.Data.DataTable
    Friend WithEvents DataColumn1 As System.Data.DataColumn
    Friend WithEvents DataColumn2 As System.Data.DataColumn
    Friend WithEvents DataColumn3 As System.Data.DataColumn
    Friend WithEvents DataColumn4 As System.Data.DataColumn
    Friend WithEvents DataColumn5 As System.Data.DataColumn
    Friend WithEvents DataColumn6 As System.Data.DataColumn
    Friend WithEvents DataColumn7 As System.Data.DataColumn
    Friend WithEvents DropDownStatus As Infragistics.Win.UltraWinGrid.UltraDropDown
    Friend WithEvents DataColumn8 As System.Data.DataColumn
    Friend WithEvents UltraTabControl1 As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl

    Friend WithEvents DataTable2 As System.Data.DataTable
    Friend WithEvents DataColumn9 As System.Data.DataColumn
    Friend WithEvents DataColumn10 As System.Data.DataColumn
    Friend WithEvents DataColumn11 As System.Data.DataColumn
    Friend WithEvents UltraTabPageControl2 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents GridErrors As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Selection As System.Windows.Forms.GroupBox
    Friend WithEvents ButtonAll As System.Windows.Forms.RadioButton
    Friend WithEvents ButtonExists As System.Windows.Forms.RadioButton
    Friend WithEvents ButtonNoExists As System.Windows.Forms.RadioButton
    Friend WithEvents DataColumn12 As System.Data.DataColumn
    Friend WithEvents DataColumn13 As System.Data.DataColumn
    Friend WithEvents DataColumn14 As System.Data.DataColumn
    Friend WithEvents MenuItem As Shipping.UserMenuItem
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents gridCntrs As System.Windows.Forms.DataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
