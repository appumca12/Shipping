Imports System.Data.SqlClient
Imports System.IO
Imports System.Data
Imports Aspose.Cells
Imports System.Reflection
Imports Microsoft.Office.Interop.Excel
Imports Microsoft.Office.Interop
Imports OrmLib
Imports ShippingBiz
Imports Infragistics.Shared
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinEditors
Imports System.Text.RegularExpressions

Public Class frmIGCReport
    Private Dm As DataManager
    Dim TB As New System.Data.DataTable
    Private Sub CheckWHL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckWHL.CheckedChanged

    End Sub

    Private Sub UltraToolbarsManager1_ToolClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinToolbars.ToolClickEventArgs)
        Beep()
    End Sub

    Private Sub ButtonPickup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPickup.Click
        If Me.TabControl.SelectedTab.Text = "IGC Report" Then
            PickupMovement()
        End If

    End Sub
    Private Sub ButtonToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonToExcel.Click

        Dim SaveDialog As New SaveFileDialog
        SaveDialog.Filter = "Excel Files (*.xls)|*.xls|All files (*.*)|*.*"
        SaveDialog.Title = "Save an Excel File"
        SaveDialog.ShowDialog()
        If SaveDialog.FileName <> "" Then
            saveExcelFile(SaveDialog.FileName)
        End If

    End Sub
    Private Sub PickupMovement()

        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim Cnn As New SqlConnection(My.Settings.DSN)
        Dim DS As New DataSet
        Dim dFrom As Date
        Dim dTo As Date
        Dim RL As DataRelation
        Dim PCol(0) As DataColumn
        Dim cCol(0) As DataColumn
        Dim DS2 As DataSet
        Dim Detn As New CLDetention
        Dim CalBase As New CLCalculationBase
        Dim Tax As Double

        TB.Clear()
        dFrom = Me.MoveDateFrom.DateValue
        dTo = Me.MoveDateTo.DateValue
        dTo = DateAdd(DateInterval.Minute, 1434, dTo)

        Me.Cursor = Cursors.WaitCursor
        Cmd = New SqlCommand("SP_IGCReport")
        Cnn = New SqlConnection(My.Settings.DSN)
        Cnn.Open()
        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.Parameters.AddWithValue("@Line", CurrentShippingLine)
        Cmd.Parameters.AddWithValue("@dFrom", dFrom)
        Cmd.Parameters.AddWithValue("@dTO", dTo)
        Cmd.Connection = Cnn
        DA.SelectCommand = Cmd
        DA.Fill(TB)

        Me.Cursor = Cursors.Default

        For Each Dr In TB.Rows
            DS = Detn.CalDetention(Dr("BLNO"), Dr("ID"), False)
            CalBase.GetTaxDutyInward(Dr("ID"), "DETN")

            'If NullToValue(Dr("ConfirmTime"), Now) >= "2013-12-01" And NullToValue(Dr("ConfirmTime"), Now) <= "2014-03-17" Then
            '    Tax = 0
            'Else
            Tax = CalBase.Tax + CalBase.Duty
            ' End If

            'If NullToValue(Dr("TTLDetention"), 0) - (Detn.Paid + Detn.TotalDiscount + Detn.FirstPaid) = NullToValue(Dr("Cash Deposit"), 0) Then
            ' By appu
            ' ''If Dr("Allcontainersreturned") = "YES" Then
            ' ''    Dr("Outstanding Demurrage") = Detn.Balance + Detn.TaxAmount
            ' ''Else
            ' ''    Dr("Outstanding Demurrage") = Detn.Balance
            ' ''End If  

            If Dr("Allcontainersreturned") = "YES" Then
                If Detn.Balance = 0 Then
                    Dr("Outstanding Demurrage") = Detn.Balance
                Else
                    Dr("Outstanding Demurrage") = Detn.Balance + Detn.TaxAmount
                End If
            Else
                Dr("Outstanding Demurrage") = Detn.Balance
            End If
            'NullToValue(Dr("TTLDetention"), 0) - (Dr("Paid") + Detn.FirstPaid) - NullToValue(Dr("Cash Deposit"), 0)
        Next


        Me.GridSummary.DataSource = TB
        GridNumSeperator(Me.GridSummary)

    End Sub
    'Private Sub ExcelDs()



    '    Dim oXL As Excel.Application = CType(CreateObject("Excel.Application"), Excel.Application)
    '    Dim oWB As Excel.Workbook
    '    Dim oSheet As Excel.Worksheet
    '    Dim oRng As Excel.Range
    '    oXL.Visible = True

    '    oWB = oXL.Workbooks.Add
    '    oSheet = CType(oWB.ActiveSheet, Excel.Worksheet)

    '    Dim dc As DataColumn
    '    Dim dr As DataRow
    '    Dim colIndex As Integer = 0
    '    Dim rowIndex As Integer = 0
    '    For Each dc In DS.Tables(0).Columns
    '        colIndex = colIndex + 1
    '        oXL.Cells(1, colIndex) = dc.ColumnName
    '    Next
    '    For Each dr In DS.Tables(0).Rows
    '        rowIndex = rowIndex + 1
    '        colIndex = 0
    '        For Each dc In DS.Tables(0).Columns
    '            colIndex = colIndex + 1
    '            oXL.Cells(rowIndex + 1, colIndex) = dr(dc.ColumnName)
    '        Next
    '    Next

    '    oSheet.Cells.Select()
    '    'oSheet.Columns.AutoFit()
    '    oSheet.Rows.AutoFit()

    '    oXL.Visible = True
    '    oXL.UserControl = True

    '    oWB.SaveAs("C:\yahova1")
    '    oRng = Nothing
    '    oXL.Quit()

    '    ExcelCleanUp(oXL, oWB, oSheet)
    '    'Return DS.Tables(0)

    'End Sub
    Private Sub frmIGCReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AnnualYear.SetLength(4)
        Me.AnnualYear.TextValue = Now.Year.ToString
    End Sub

    Private Sub saveExcelFile(ByVal FileName As String)
        Dim dsExcelExport As New DataSet
        Dim daExcelExport As New SqlDataAdapter
        Dim Excel As Microsoft.Office.Interop.Excel.Application = New Microsoft.Office.Interop.Excel.Application
        Dim intColumn, intRow, intColumnValue As Integer
        Dim strExcelFile As String
        Dim strFileName As String
        Dim varConnection As New SqlConnection
        Dim conCurrent As New SqlConnection
        Dim varCommand As SqlCommand
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim Cnn As New SqlConnection(My.Settings.DSN)
        Dim DS As New DataSet
        Dim dFrom As Date
        Dim dTo As Date
        Dim RL As DataRelation
        Dim PCol(0) As DataColumn
        Dim cCol(0) As DataColumn
        Dim DS2 As DataSet

        dFrom = Me.MoveDateFrom.DateValue
        dTo = Me.MoveDateTo.DateValue
        dTo = DateAdd(DateInterval.Minute, 1434, dTo)

        'Cnn.Open()
        ''
        'With Cmd
        '    .CommandText = "SP_IGCReport"
        '    .CommandType = CommandType.StoredProcedure
        '    .Connection = Cnn
        '    .Parameters.AddWithValue("@dFrom", dFrom)
        '    .Parameters.AddWithValue("@dTo", dTo)
        '    .Parameters.AddWithValue("@Line", CurrentShippingLine)
        'End With

        'DA.SelectCommand = Cmd
        'DA.Fill(dsExcelExport)
        DataGridView1.DataSource = TB
        System.Threading.Thread.CurrentThread.CurrentCulture = _
               System.Globalization.CultureInfo.CreateSpecificCulture("en-US")
        Dim xlApp As Microsoft.Office.Interop.Excel.Application
        Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook
        Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet

        Dim misValue As Object = System.Reflection.Missing.Value
        Dim i As Integer
        Dim j As Integer

        xlApp = New Microsoft.Office.Interop.Excel.ApplicationClass
        xlWorkBook = xlApp.Workbooks.Add(misValue)
        xlWorkSheet = xlWorkBook.Sheets("sheet1")
        Dim DataTable As New System.Data.DataTable
        Dim table As New System.Data.DataTable
        Dim iCol As Integer = 0
        For Each c As DataColumn In DataTable.Columns
            iCol = iCol + 1
            xlApp.Cells(1, iCol) = c.ColumnName
        Next

        Dim rowIndex As Integer = 0
        Dim ColumnIndex As Integer = 0

        For Each row As DataRow In table.Rows
            rowIndex = (rowIndex + 1)
            ColumnIndex = 0
            For Each col As DataColumn In table.Columns
                ColumnIndex = (ColumnIndex + 1)
            Next
        Next
        xlApp.Visible = True
        Dim worksheet As Microsoft.Office.Interop.Excel.Worksheet = CType(xlApp.ActiveSheet, Microsoft.Office.Interop.Excel.Worksheet)
        worksheet.Activate()
        worksheet.AutoFilterMode = False
        'worksheet.Range("J:N").NumberFormat = "dd/MM/yyyy"
        worksheet.Range("A1:M1").Interior.Color = RGB(248, 248, 220)
        worksheet.Range("A:M").Font.Name = "Microsoft Sans Serif"
        worksheet.Range("A:M").Font.Size = 8

        worksheet.StandardWidth = 10.2
        worksheet.Range("A:N").RowHeight = 15

        'For displaying the column name in the the excel file.                        
        For intColumn = 0 To DataGridView1.ColumnCount - 1
            xlWorkSheet.Cells(1, intColumn + 1).Value = TB.Columns(intColumn).ColumnName.ToString
        Next

        For i = 0 To DataGridView1.RowCount - 2
            'If i = 2063 Then
            For j = 0 To DataGridView1.ColumnCount - 1
                ' If (j = 4) Or (j = 5) Or (j = 6) Or (j = 7) Then
                If (j = 50) Then
                    If (DataGridView1(j, i).Value.ToString() <> "NIL" And Not DataGridView1(j, i).Value.ToString() = "") Then
                        xlWorkSheet.Cells(i + 2, j + 1).Value = CDate(DateTime.Parse(DataGridView1(j, i).Value.ToString(), Globalization.CultureInfo.CreateSpecificCulture("en-CA").DateTimeFormat))
                    Else
                        xlWorkSheet.Cells(i + 2, j + 1).Value = "NIL"
                    End If
                Else
                    xlWorkSheet.Cells(i + 2, j + 1) = DataGridView1(j, i).Value.ToString()
                End If
            Next
            'End If
        Next

        xlWorkSheet.SaveAs(FileName)
        xlWorkBook.Close()
        xlApp.Quit()
        DA.Dispose()
        Exit Sub
        Me.Close()
    End Sub
End Class
