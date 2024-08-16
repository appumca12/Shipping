<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmChangeLineDialog
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.OK_Button = New System.Windows.Forms.Button
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.FormDataSet = New System.Data.DataSet
        Me.DataTable2 = New System.Data.DataTable
        Me.DataColumn4 = New System.Data.DataColumn
        Me.DataColumn5 = New System.Data.DataColumn
        Me.DataColumn6 = New System.Data.DataColumn
        Me.DataColumn7 = New System.Data.DataColumn
        Me.DataColumn8 = New System.Data.DataColumn
        Me.DataColumn9 = New System.Data.DataColumn
        Me.DataColumn10 = New System.Data.DataColumn
        Me.Label1 = New System.Windows.Forms.Label
        Me.LineCode = New System.Windows.Forms.TextBox
        Me.label6 = New System.Windows.Forms.Label
        Me.LineName = New System.Windows.Forms.TextBox
        Me.UltraTabStripControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabStripControl
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.FormDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraTabStripControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabStripControl1.SuspendLayout()
        Me.UltraTabSharedControlsPage1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(211, 197)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'FormDataSet
        '
        Me.FormDataSet.DataSetName = "NewDataSet"
        Me.FormDataSet.Tables.AddRange(New System.Data.DataTable() {Me.DataTable2})
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
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(23, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 20)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Line Code"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LineCode
        '
        Me.LineCode.Location = New System.Drawing.Point(89, 40)
        Me.LineCode.Name = "LineCode"
        Me.LineCode.Size = New System.Drawing.Size(117, 20)
        Me.LineCode.TabIndex = 19
        '
        'label6
        '
        Me.label6.BackColor = System.Drawing.Color.Transparent
        Me.label6.Location = New System.Drawing.Point(23, 66)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(61, 20)
        Me.label6.TabIndex = 16
        Me.label6.Text = "Line Name"
        Me.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LineName
        '
        Me.LineName.Location = New System.Drawing.Point(89, 66)
        Me.LineName.Name = "LineName"
        Me.LineName.Size = New System.Drawing.Size(224, 20)
        Me.LineName.TabIndex = 17
        '
        'UltraTabStripControl1
        '
        Appearance1.BackColorAlpha = Infragistics.Win.Alpha.UseAlphaLevel
        Me.UltraTabStripControl1.Appearance = Appearance1
        Me.UltraTabStripControl1.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.UltraTabStripControl1.Location = New System.Drawing.Point(12, 7)
        Me.UltraTabStripControl1.Name = "UltraTabStripControl1"
        Me.UltraTabStripControl1.SharedControls.AddRange(New System.Windows.Forms.Control() {Me.LineName, Me.TableLayoutPanel1, Me.Label1, Me.label6, Me.LineCode})
        Me.UltraTabStripControl1.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.UltraTabStripControl1.Size = New System.Drawing.Size(364, 252)
        Me.UltraTabStripControl1.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.PropertyPage2003
        Me.UltraTabStripControl1.TabIndex = 20
        Me.UltraTabStripControl1.TabLayoutStyle = Infragistics.Win.UltraWinTabs.TabLayoutStyle.MultiRowAutoSize
        UltraTab1.Text = "tab1"
        Me.UltraTabStripControl1.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab1})
        Me.UltraTabStripControl1.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.VisualStudio2005
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Controls.Add(Me.LineName)
        Me.UltraTabSharedControlsPage1.Controls.Add(Me.TableLayoutPanel1)
        Me.UltraTabSharedControlsPage1.Controls.Add(Me.Label1)
        Me.UltraTabSharedControlsPage1.Controls.Add(Me.label6)
        Me.UltraTabSharedControlsPage1.Controls.Add(Me.LineCode)
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(2, 21)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(360, 229)
        '
        'FrmChangeLineDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(388, 271)
        Me.Controls.Add(Me.UltraTabStripControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmChangeLineDialog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Change Working Line"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.FormDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraTabStripControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabStripControl1.ResumeLayout(False)
        Me.UltraTabSharedControlsPage1.ResumeLayout(False)
        Me.UltraTabSharedControlsPage1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents FormDataSet As System.Data.DataSet
    Friend WithEvents DataTable2 As System.Data.DataTable
    Friend WithEvents DataColumn4 As System.Data.DataColumn
    Friend WithEvents DataColumn5 As System.Data.DataColumn
    Friend WithEvents DataColumn6 As System.Data.DataColumn
    Friend WithEvents DataColumn7 As System.Data.DataColumn
    Friend WithEvents DataColumn8 As System.Data.DataColumn
    Friend WithEvents DataColumn9 As System.Data.DataColumn
    Friend WithEvents DataColumn10 As System.Data.DataColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LineCode As System.Windows.Forms.TextBox
    Friend WithEvents label6 As System.Windows.Forms.Label
    Friend WithEvents LineName As System.Windows.Forms.TextBox
    Friend WithEvents UltraTabStripControl1 As Infragistics.Win.UltraWinTabControl.UltraTabStripControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage

End Class
