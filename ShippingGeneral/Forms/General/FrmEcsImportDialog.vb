Imports System.Windows.Forms

Public Class FrmEcsImportDialog

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub FrmEcsImportDialog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    
    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Dim dsExcelExport As New DataSet

        Dim Excel As Microsoft.Office.Interop.Excel.Application = New Microsoft.Office.Interop.Excel.Application
        Dim intColumn, intRow, intColumnValue As Integer
        Dim strExcelFile As String
        Dim strFileName As String
       
        Dim DS As New DataSet
        Dim dFrom As Date
        Dim dTo As Date
        Dim RL As DataRelation
        Dim PCol(0) As DataColumn
        Dim cCol(0) As DataColumn
        Dim DS2 As DataSet
        Dim SaveDialog As New SaveFileDialog
        SaveDialog.Filter = "Excel Files (*.xls)|*.xls|All files (*.*)|*.*"
        SaveDialog.Title = "Save an Excel File"
        SaveDialog.ShowDialog()
        If SaveDialog.FileName <> "" Then

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
            For intColumn = 0 To grdDBDup.ColumnCount - 1
                xlWorkSheet.Cells(1, intColumn + 1).Value = grdDBDup.Columns(intColumn).Name.ToString
            Next

            For i = 0 To grdDBDup.RowCount - 2
                'If i = 2063 Then
                For j = 0 To grdDBDup.ColumnCount - 1
                    ' If (j = 4) Or (j = 5) Or (j = 6) Or (j = 7) Then
                    If (j = 50) Then
                        If (grdDBDup(j, i).Value.ToString() <> "NIL" And Not grdDBDup(j, i).Value.ToString() = "") Then
                            xlWorkSheet.Cells(i + 2, j + 1).Value = CDate(DateTime.Parse(grdDBDup(j, i).Value.ToString(), Globalization.CultureInfo.CreateSpecificCulture("en-CA").DateTimeFormat))
                        Else
                            xlWorkSheet.Cells(i + 2, j + 1).Value = "NIL"
                        End If
                    Else
                        xlWorkSheet.Cells(i + 2, j + 1) = grdDBDup(j, i).Value.ToString()
                    End If
                Next
                'End If
            Next

            xlWorkSheet.SaveAs(SaveDialog.FileName)
            xlWorkBook.Close()
            xlApp.Quit()

            Exit Sub
            Me.Close()
        End If
    End Sub
End Class
