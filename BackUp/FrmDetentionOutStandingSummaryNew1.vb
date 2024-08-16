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

Public Class FrmDetentionOutStandingSummary

    Private InvID As Guid
    Private Bls As TB_InwardBLSCollection
    Private Bl As TB_InwardBLS
    Private Clnt As TB_Clients
    Private Voy As TB_Voyage
    Private Vsl As TB_Vessels
    Private Sof As TB_SOF
    Private InvStatus As InvoiceStatus
    Private ItemLevel As String = "300"
    Private lValidBlNno As Boolean
    Private Dm As DataManager
    Private IsDetention As Boolean
    Private TotalCostIrr As Double
    Private TotalCostUsd As Double
    Dim Arvl As CLArrivalNotice
    Dim isArrival As Boolean
    Dim IsBlank As Boolean
    Dim ds As New DataSet
    Dim TBlInward As New System.Data.DataTable
    Dim TBlOutstandingSummary As New System.Data.DataTable
    Dim tblCreated As Boolean = False
    Dim tblOutStandingCreated As Boolean = False
    Private Sub CheckWHL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckWHL.CheckedChanged

    End Sub

    Private Sub UltraToolbarsManager1_ToolClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinToolbars.ToolClickEventArgs)
        Beep()
    End Sub

    Private Sub ButtonPickup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPickup.Click
        If Me.TabControl.SelectedTab.Text = "Detention Outstanding Summary" Then
            'PickupMovement()
            GenerateDetention()
        End If

    End Sub
    Private Sub ButtonToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonToExcel.Click

        Dim SaveDialog As New SaveFileDialog
        SaveDialog.Filter = "Excel Files (*.xls)|*.xls|All files (*.*)|*.*"
        SaveDialog.Title = "Save an Excel File"
        SaveDialog.ShowDialog()
        If SaveDialog.FileName <> "" Then
            saveExcelFileDetentionOutstanding(SaveDialog.FileName)
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
        dFrom = Me.MoveDateFrom.DateValue
        dTo = Me.MoveDateTo.DateValue
        dTo = DateAdd(DateInterval.Minute, 1434, dTo)

        Cnn.Open()
        '
        With Cmd
            .CommandText = "SP_IMPORTSHIPMENT"
            .CommandType = CommandType.StoredProcedure
            .Connection = Cnn
            .Parameters.AddWithValue("@dFrom", dFrom)
            .Parameters.AddWithValue("@dTo", dTo)
            .Parameters.AddWithValue("@Line", CurrentShippingLine)
        End With

        DA.SelectCommand = Cmd
        DA.Fill(DS)


        DS.Tables(0).TableName = "Result"
        Me.GridResult.DataSource = DS.Tables(0)
        Me.GridSummary.DataSource = DS.Tables(0)

        GridNumSeperator(Me.GridSummary)

    End Sub
    Private Sub GenerateDetention()

        Dim Sum As CLInwardBlsSummary
        Dim Dtn As New CLDetention
        Dim BLID As Guid
        Dim ds As New DataSet
        Dim Report As RptInwardDetention
        Dim Frm As New FrmGeneralReportShow
        Dim PH As New CLPrintHdr
        Dim Dscnt As TB_InwardDiscount
        Dim sDscnt As String = ""
        Dim Col As DataColumn
        Dim Clnt As TB_Clients
        Dim Status As TB_InwardStatus
        Dim Inv As TB_Invoice
        Dim InvD As TB_InvoiceDetails
        Dim lResult As Boolean
        Dim TB As New System.Data.DataTable
        Dim sSql As String
        Dim TbSum As New System.Data.DataTable
        Dim dFrom As Date
        Dim dTo As Date
        Dim QryBlID As String
        Dim TblBlID As New System.Data.DataTable
        TBlOutstandingSummary.Clear()
        TBlInward.Clear()

        With TBlInward
            If (tblCreated = False) Then
                .Columns.Add(New DataColumn("ChargeCode", System.Type.GetType("System.String")))
                .Columns.Add(New DataColumn("Seq", System.Type.GetType("System.Int16")))
                .Columns.Add(New DataColumn("Description", System.Type.GetType("System.String")))
                .Columns.Add(New DataColumn("ToPaidIrr", System.Type.GetType("System.Double")))
                .Columns.Add(New DataColumn("ToBePaidIrrTax", System.Type.GetType("System.Double")))
                .Columns.Add(New DataColumn("ToPaidUsd", System.Type.GetType("System.Double")))
                .Columns.Add(New DataColumn("ToBePaidUsdTax", System.Type.GetType("System.Double")))
                .Columns.Add(New DataColumn("PaidIrr", System.Type.GetType("System.Double")))
                .Columns.Add(New DataColumn("PaidIrrTax", System.Type.GetType("System.Double")))
                .Columns.Add(New DataColumn("PaidUsd", System.Type.GetType("System.Double")))
                .Columns.Add(New DataColumn("PaidUsdTax", System.Type.GetType("System.Double")))
                .Columns.Add(New DataColumn("Year", System.Type.GetType("System.Int64")))
                .Columns.Add(New DataColumn("Month", System.Type.GetType("System.String")))
                .Columns.Add(New DataColumn("OutstandingAmount", System.Type.GetType("System.String")))

                tblCreated = True
            End If
        End With

        With TBlOutstandingSummary
            If (tblOutStandingCreated = False) Then
                .Columns.Add(New DataColumn("Year", System.Type.GetType("System.Int64")))
                .Columns.Add(New DataColumn("Month", System.Type.GetType("System.String")))
                .Columns.Add(New DataColumn("OutstandingAmount", System.Type.GetType("System.String")))
                tblOutStandingCreated = True
            End If
        End With

        dFrom = Me.MoveDateFrom.DateValue
        dTo = Me.MoveDateTo.DateValue
        'dTo = DateAdd(DateInterval.Minute, 1434, dTo)


        Dim TBLInwardBls As New System.Data.DataTable
        'sSql = "Select * From Tb_InwardBls WHERE IssueDate between '" & dFrom & "' AND '" & dTo & "' AND LINE='" & CurrentShippingLine & "'"
        'sSql = "Select InwBL.BlNo,Inv.IssueTime From Tb_InwardBls InwBL ,TB_Invoice Inv where InwBL.ID=Inv.BLID AND  InwBL.BlNo='0272656886'  AND LINE='WHL'  order by Inv.IssueTime"
        'sSql = "Select InwBL.BlNo,Inv.IssueTime From Tb_InwardBls InwBL ,TB_Invoice Inv where InwBL.ID=Inv.BLID AND Inv.IssueTime between '" & dFrom & "' AND '" & dTo & "' AND LINE='" & CurrentShippingLine & "'  order by Inv.IssueTime"

        sSql = "with T as (  select year(Inv.IssueTime) Month, month(Inv.IssueTime) Year, InwBL.BlNo, Inv.IssueTime From Tb_InwardBls InwBL ,TB_Invoice Inv  where InwBL.ID=Inv.BLID  AND Inv.IssueTime between '" & dFrom.ToString("yyyy-MM-dd") & "' AND '" & dTo.ToString("yyyy-MM-dd") & "' AND LINE='" & CurrentShippingLine & "') select Month, Year, max(BlNo) BlNo from T group by Month,Year ORDER BY 1,2"karti 

        TableBySql(sSql, TBLInwardBls, lResult)
        For Each drInwardBls As DataRow In TBLInwardBls.Rows
            'ds = StoredProcedures.SP_InwardBlsByLineBlNo(CurrentShippingLine, drInwardBls("BlNo").ToString)

            QryBlID = ("select ID from Tb_InwardBls where BLNO ='" & drInwardBls("BlNo") & "'")
            TableBySql(QryBlID, TblBlID, lResult)
            BLID = TblBlID.Rows(0).Item("ID")
            ds = Dtn.CalDetentionOutStandingSummary(drInwardBls("BlNo").ToString, BLID, False, 0)

            Dm = New DataManager(My.Settings.DSN)
            sSql = "Select Top 1 I.IssueTime  From TB_Invoice I, TB_InvoiceDetails D Where I.ID =D.InvoiceID and D.ChargesCode ='DETN' and I.Status < 4  and I.BLID = '" & BLID.ToString & "' Order by I.Status"
            TableBySql(sSql, TB, lResult)
            'TbSum = GenSummaryDetention(Dtn, ds, TBlInward, drInwardBls("IssueTime"), Year(drInwardBls("IssueTime")), Month(drInwardBls("IssueTime")), TBlOutstandingSummary)

            Dim Dr As DataRow
            Dim DrOutstanding As DataRow
            Dim PaidDMUsd As Double
            Dim PaidDM As Double

            Dim PaidDet As Double
            Dim PaidDetUsd As Double

            Dim Seq As Integer
            Dim Deposit As Double

            Dim PaifFromDeposit As Double
            Dim PaifFromDepositUsd As Double

            If Dtn.TotalAmount > 0 Then
                Seq += 1
                Dr = TBlInward.NewRow
                DrOutstanding = TBlOutstandingSummary.NewRow
                Dr("ChargeCode") = "DETN"
                Dr = TBlInward.NewRow
                Dr("Seq") = Seq
                Dr("Description") = "Detention"
                Dr("ToPaidIrr") = Dtn.TotalAmount - Dtn.TotalDiscount
                Dr("ToBePaidIrrTax") = (Dtn.TotalAmount - Dtn.TotalDiscount) * Dtn.TaxPercent / 100
                Dr("ToPaidUsd") = 0
                Dr("ToBePaidUsdTax") = 0
                Dr("PaidIrr") = 0
                Dr("PaidIrrTax") = 0
                Dr("PaidUsd") = 0
                Dr("PaidUsdTax") = 0
                Dr("Year") = drInwardBls("Month")
                Dr("Month") = GetMonthName(drInwardBls("Year"))
                Dr("OutstandingAmount") = (NullToValue(Dr("ToPaidIrr"), 0)) - (NullToValue(Dr("PaidIrr"), 0))
                DrOutstanding("Year") = drInwardBls("Month")
                DrOutstanding("Month") = GetMonthName(drInwardBls("Year"))
                DrOutstanding("OutstandingAmount") = "IRR " & (NullToValue(Dr("ToPaidIrr"), 0)) - (NullToValue(Dr("PaidIrr"), 0))
                TBlOutstandingSummary.Rows.Add(DrOutstanding)
                TBlInward.Rows.Add(Dr)
            End If
        Next
        Me.GridResult.DataSource = TBlOutstandingSummary
        Me.GridSummary.DataSource = TBlOutstandingSummary
    End Sub
    Private Function GetMonthName(ByVal monthNum As Integer) As String
        Try
            Dim strDate As New DateTime(1, monthNum, 1)
            Return strDate.ToString("MMM")
        Catch ex As Exception
        End Try
    End Function
    Private Sub FrmDetentionSummary_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

        Cnn.Open()
        '
        With Cmd
            .CommandText = "SP_IMPORTSHIPMENT"
            .CommandType = CommandType.StoredProcedure
            .Connection = Cnn
            .Parameters.AddWithValue("@dFrom", dFrom)
            .Parameters.AddWithValue("@dTo", dTo)
            .Parameters.AddWithValue("@Line", CurrentShippingLine)
        End With

        DA.SelectCommand = Cmd
        DA.Fill(dsExcelExport)
        DataGridView1.DataSource = dsExcelExport.Tables(0)

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
            xlWorkSheet.Cells(1, intColumn + 1).Value = dsExcelExport.Tables(0).Columns(intColumn).ColumnName.ToString
        Next

        For i = 0 To DataGridView1.RowCount - 2
            'If i = 2063 Then
            For j = 0 To DataGridView1.ColumnCount - 1
                If (j = 13) Or (j = 14) Or (j = 16) Or (j = 17) Then
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
    Private Sub saveExcelFileDetentionOutstanding(ByVal FileName As String)

        DataGridView1.DataSource = TBlOutstandingSummary

        Dim xlApp As Microsoft.Office.Interop.Excel.Application
        Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook
        Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet

        Dim misValue As Object = System.Reflection.Missing.Value
        Dim i As Integer
        Dim j As Integer
        'Dim xlWorkSheet.Cells.VerticalAlignment.ToString()

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
        worksheet.Range("A1:C1").Interior.Color = RGB(248, 248, 220)
        worksheet.Range("A:C").Font.Name = "Microsoft Sans Serif"
        'worksheet.Range("A:M").Font.Size = 8

        'worksheet.StandardWidth = 10.2
        'worksheet.Range("A:N").RowHeight = 15



        'For displaying the column name in the the excel file.                        
        For intColumn = 0 To DataGridView1.ColumnCount - 1
            'If (TBlInward.Columns(intColumn).ColumnName.ToString = "Year" Or TBlInward.Columns(intColumn).ColumnName.ToString = "Month" Or TBlInward.Columns(intColumn).ColumnName.ToString = "Balance" Or TBlInward.Columns(intColumn).ColumnName.ToString = "IssueDate") Then
            If (intColumn = 2) Then
                xlWorkSheet.Cells(1, intColumn + 1).Value = "Outstanding amount"
            Else
                xlWorkSheet.Cells(1, intColumn + 1).Value = TBlOutstandingSummary.Columns(intColumn).ColumnName.ToString
            End If


            'End If
        Next
        Dim YearCount As Integer = 0
        Dim CellMerge As Integer = 1
        Dim CellMegeInitVal As Integer = 2
        Dim finalMerge As Boolean = False
        For i = 0 To DataGridView1.RowCount - 2
            For j = 0 To DataGridView1.ColumnCount - 1
                If i = 0 And j = 0 Then
                    YearCount = DataGridView1(j, i).Value.ToString()
                End If
                If (DataGridView1(0, i).Value.ToString() = YearCount + 1) Or (i = DataGridView1.RowCount - 2) Then
                    Dim cellRange As String = "A" & CellMegeInitVal & ":A" & CellMerge
                    xlApp.DisplayAlerts = False
                    xlWorkSheet.Range(cellRange).Merge()
                    xlWorkSheet.Range(cellRange).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                    xlWorkSheet.Range(cellRange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    xlApp.DisplayAlerts = True
                    YearCount = YearCount + 1
                    CellMegeInitVal = CellMerge + 1
                End If                '
                xlWorkSheet.Cells(i + 2, j + 1) = DataGridView1(j, i).Value.ToString()
            Next
            CellMerge = CellMerge + 1
        Next
        xlWorkSheet.SaveAs(FileName)
        xlWorkBook.Close()
        xlApp.Quit()
        'DA.Dispose()
        Exit Sub
        Me.Close()
    End Sub


End Class
