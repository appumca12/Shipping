<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRaiseError
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
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Error", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Section")
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Message")
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MsgType")
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
        Me.DataSetForm = New System.Data.DataSet
        Me.DataTable1 = New System.Data.DataTable
        Me.DataColumn1 = New System.Data.DataColumn
        Me.DataColumn2 = New System.Data.DataColumn
        Me.DataColumn3 = New System.Data.DataColumn
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.CmdOk = New Infragistics.Win.Misc.UltraButton
        Me.GridMsgs = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.TTLW = New System.Windows.Forms.TextBox
        Me.TTLE = New System.Windows.Forms.TextBox
        CType(Me.DataSetForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.GridMsgs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataSetForm
        '
        Me.DataSetForm.DataSetName = "NewDataSet"
        Me.DataSetForm.Tables.AddRange(New System.Data.DataTable() {Me.DataTable1})
        '
        'DataTable1
        '
        Me.DataTable1.Columns.AddRange(New System.Data.DataColumn() {Me.DataColumn1, Me.DataColumn2, Me.DataColumn3})
        Me.DataTable1.TableName = "Error"
        '
        'DataColumn1
        '
        Me.DataColumn1.ColumnName = "Section"
        '
        'DataColumn2
        '
        Me.DataColumn2.ColumnName = "Message"
        '
        'DataColumn3
        '
        Me.DataColumn3.ColumnName = "MsgType"
        Me.DataColumn3.DataType = GetType(Short)
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.TableLayoutPanel1)
        Me.UltraGroupBox1.Controls.Add(Me.CmdOk)
        Me.UltraGroupBox1.Controls.Add(Me.GridMsgs)
        Me.UltraGroupBox1.Location = New System.Drawing.Point(12, 15)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(502, 415)
        Me.UltraGroupBox1.SupportThemes = False
        Me.UltraGroupBox1.TabIndex = 0
        Me.UltraGroupBox1.Text = "List Of Messages"
        '
        'CmdOk
        '
        Me.CmdOk.Location = New System.Drawing.Point(407, 369)
        Me.CmdOk.Name = "CmdOk"
        Me.CmdOk.Size = New System.Drawing.Size(75, 23)
        Me.CmdOk.TabIndex = 2
        Me.CmdOk.Text = "Ok"
        '
        'GridMsgs
        '
        Me.GridMsgs.DataSource = Me.DataSetForm
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.GridMsgs.DisplayLayout.Appearance = Appearance1
        Me.GridMsgs.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Appearance2.TextHAlign = Infragistics.Win.HAlign.Left
        Appearance2.TextVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn1.CellAppearance = Appearance2
        UltraGridColumn1.GroupByMode = Infragistics.Win.UltraWinGrid.GroupByMode.Value
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.MergedCellEvaluationType = Infragistics.Win.UltraWinGrid.MergedCellEvaluationType.MergeSameValue
        UltraGridColumn1.MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always
        UltraGridColumn1.Width = 186
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn2.Width = 180
        UltraGridColumn3.Header.VisiblePosition = 2
        UltraGridColumn3.Width = 112
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3})
        Me.GridMsgs.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.GridMsgs.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.GridMsgs.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance3.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance3.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance3.BorderColor = System.Drawing.SystemColors.Window
        Me.GridMsgs.DisplayLayout.GroupByBox.Appearance = Appearance3
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.GridMsgs.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance4
        Me.GridMsgs.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance5.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance5.BackColor2 = System.Drawing.SystemColors.Control
        Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance5.ForeColor = System.Drawing.SystemColors.GrayText
        Me.GridMsgs.DisplayLayout.GroupByBox.PromptAppearance = Appearance5
        Me.GridMsgs.DisplayLayout.MaxColScrollRegions = 1
        Me.GridMsgs.DisplayLayout.MaxRowScrollRegions = 1
        Appearance6.BackColor = System.Drawing.SystemColors.Window
        Appearance6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GridMsgs.DisplayLayout.Override.ActiveCellAppearance = Appearance6
        Appearance7.BackColor = System.Drawing.SystemColors.Highlight
        Appearance7.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.GridMsgs.DisplayLayout.Override.ActiveRowAppearance = Appearance7
        Me.GridMsgs.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.GridMsgs.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance8.BackColor = System.Drawing.SystemColors.Window
        Me.GridMsgs.DisplayLayout.Override.CardAreaAppearance = Appearance8
        Appearance9.BorderColor = System.Drawing.Color.Silver
        Appearance9.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.GridMsgs.DisplayLayout.Override.CellAppearance = Appearance9
        Me.GridMsgs.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.GridMsgs.DisplayLayout.Override.CellPadding = 0
        Appearance10.BackColor = System.Drawing.SystemColors.Control
        Appearance10.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance10.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance10.BorderColor = System.Drawing.SystemColors.Window
        Me.GridMsgs.DisplayLayout.Override.GroupByRowAppearance = Appearance10
        Appearance11.TextHAlign = Infragistics.Win.HAlign.Left
        Me.GridMsgs.DisplayLayout.Override.HeaderAppearance = Appearance11
        Me.GridMsgs.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.GridMsgs.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance12.BackColor = System.Drawing.SystemColors.Window
        Appearance12.BorderColor = System.Drawing.Color.Silver
        Me.GridMsgs.DisplayLayout.Override.RowAppearance = Appearance12
        Me.GridMsgs.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance13.BackColor = System.Drawing.SystemColors.ControlLight
        Me.GridMsgs.DisplayLayout.Override.TemplateAddRowAppearance = Appearance13
        Me.GridMsgs.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.GridMsgs.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.GridMsgs.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.GridMsgs.Location = New System.Drawing.Point(12, 21)
        Me.GridMsgs.Name = "GridMsgs"
        Me.GridMsgs.Size = New System.Drawing.Size(480, 330)
        Me.GridMsgs.TabIndex = 0
        Me.GridMsgs.Text = "GridMsgs"
        '
        'UltraLabel1
        '
        Me.UltraLabel1.Location = New System.Drawing.Point(3, 3)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(94, 20)
        Me.UltraLabel1.TabIndex = 3
        Me.UltraLabel1.Text = "Total Warning"
        '
        'UltraLabel2
        '
        Me.UltraLabel2.Location = New System.Drawing.Point(3, 29)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(94, 21)
        Me.UltraLabel2.TabIndex = 4
        Me.UltraLabel2.Text = "Total Error"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.UltraLabel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.UltraLabel2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TTLW, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TTLE, 1, 1)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(12, 356)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(200, 53)
        Me.TableLayoutPanel1.TabIndex = 5
        '
        'TTLW
        '
        Me.TTLW.Location = New System.Drawing.Point(103, 3)
        Me.TTLW.Name = "TTLW"
        Me.TTLW.Size = New System.Drawing.Size(94, 20)
        Me.TTLW.TabIndex = 5
        '
        'TTLE
        '
        Me.TTLE.Location = New System.Drawing.Point(103, 29)
        Me.TTLE.Name = "TTLE"
        Me.TTLE.Size = New System.Drawing.Size(94, 20)
        Me.TTLE.TabIndex = 6
        '
        'FrmRaiseError
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(530, 442)
        Me.ControlBox = False
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Name = "FrmRaiseError"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Validation Result"
        CType(Me.DataSetForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        CType(Me.GridMsgs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataSetForm As System.Data.DataSet
    Friend WithEvents DataTable1 As System.Data.DataTable
    Friend WithEvents DataColumn1 As System.Data.DataColumn
    Friend WithEvents DataColumn2 As System.Data.DataColumn
    Friend WithEvents DataColumn3 As System.Data.DataColumn
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents GridMsgs As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents CmdOk As Infragistics.Win.Misc.UltraButton
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents TTLW As System.Windows.Forms.TextBox
    Friend WithEvents TTLE As System.Windows.Forms.TextBox
End Class
