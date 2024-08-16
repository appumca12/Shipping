Imports System.Data.SqlClient
Imports System.IO
Imports Aspose.Cells
Imports System.Reflection
Imports Microsoft.Office.Interop.Excel
Imports Microsoft.Office.Interop
Imports System.Data
Imports OrmLib
Imports ShippingBiz
Imports Infragistics.Shared
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinEditors
Imports System.Text.RegularExpressions

Public Class FrmCustomerDemurageReport
    Private Dm As DataManager
    Dim TB As New System.Data.DataTable
    Private Sub CheckWHL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckWHL.CheckedChanged

    End Sub

    Private Sub FrmAccGnrlReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Clients.InitControl()
    End Sub


    Private Sub UltraToolbarsManager1_ToolClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinToolbars.ToolClickEventArgs)
        Beep()
    End Sub

    Private Sub ButtonPickup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPickup.Click
        If Me.TabControl.SelectedTab.Text = "Customers Demurrage Report" Then
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
        Dim DA1 As New SqlDataAdapter
        Dim Cnn As New SqlConnection(My.Settings.DSN)
        Dim DS As New DataSet
        Dim dFrom As Date
        Dim dTo As Date
        Dim RL As DataRelation
        Dim PCol(0) As DataColumn
        Dim cCol(0) As DataColumn
        Dim DS2 As DataSet

        Dim TB1 As New System.Data.DataTable
        Dim Detn As New CLDetention
        Dim CalBase As New CLCalculationBase
        Dim Tax As Double

        Dim Sum As CLInwardBlsSummary
        Dim Dtn As New CLDetention
        Dim BLID As Guid

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
        Dim TbSum As New System.Data.DataTable
        Dim sSql As String

        TB.Clear() 'Added by appu on 18-01-2016
        'dFrom = Me.MoveDateFrom.DateValue
        'dTo = Me.MoveDateTo.DateValue
        'dTo = DateAdd(DateInterval.Minute, 1434, dTo)
        Dm = New DataManager(My.Settings.DSN)
        Me.Cursor = Cursors.WaitCursor
        Cmd = New SqlCommand("SP_CustomerDemurageReport")
        Cnn = New SqlConnection(My.Settings.DSN)
        Cnn.Open()
        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.Parameters.AddWithValue("@Client", Me.Clients.ClientID)
        Cmd.Parameters.AddWithValue("@Line", CurrentShippingLine)

        Cmd.Connection = Cnn
        DA1.SelectCommand = Cmd
        DA1.Fill(TB)



        'DS.Tables(0).TableName = "Result"
        'Me.GridResult.DataSource = DS.Tables(0)
        'Me.GridSummary.DataSource = DS.Tables(0)

        Me.Cursor = Cursors.Default

        'For Each Dr In TB.Rows
        '    DS = Detn.CalDetention(Dr("BLNO"), Dr("ID"), False)
        '    GenSummaryDetention(Dtn, DS)
        '    CalBase.GetTaxDutyInward(Dr("ID"), "DETN")

        '    'If NullToValue(Dr("ConfirmTime"), Now) >= "2013-12-01" And NullToValue(Dr("ConfirmTime"), Now) <= "2014-03-17" Then
        '    '    Tax = 0
        '    'Else
        '    Tax = CalBase.Tax + CalBase.Duty
        '    'End If
        '    Dr("Paid") = Detn.Paid + (Detn.Paid * Tax / 100) + Detn.FirstPaid
        '    Dr("TTLDetention") = Detn.TotalAmount - Detn.TotalDiscount
        '    Dr("TTLDetention") += Dr("TTLDetention") * Tax / 100
        '    'If NullToValue(Dr("TTLDetention"), 0) - (Detn.Paid + Detn.TotalDiscount + Detn.FirstPaid) = NullToValue(Dr("Cash Deposit"), 0) Then
        '    If Dr("AllContainerReturnBack") = "YES" And Dr("Paid") <> Dr("TTLDetention") Then
        '        Dr("Outstanding Amount") = Detn.Balance + Detn.TaxAmount
        '    Else
        '        Dr("Outstanding Amount") = Detn.Balance
        '    End If
        '    'NullToValue(Dr("TTLDetention"), 0) - (Dr("Paid") + Detn.FirstPaid) - NullToValue(Dr("Cash Deposit"), 0)
        'Next


        '******** foe amount calc-appu ********
        For Each Dr In TB.Rows

            DS = StoredProcedures.SP_InwardBlsByLineBlNo(CurrentShippingLine, Dr("BLNO"))

            If DS.Tables(0).Rows.Count = 0 Then
                MsgBoxGeneral("No valid B/L No ?", "Data Requird")
                Exit Sub
            End If
            Sum = New CLInwardBlsSummary(DS.Tables(0).Rows(0).Item("Id"))

            BLID = DS.Tables(0).Rows(0).Item("ID")
            '     Dtn.GenerateImportDetention(BLID)
            'ds = Dtn.CalDetentionInwardInvoice(Me.TextBlNo.TextValue, BLID, , Me.ExtraDays.Value)
            'Above code commented and below code added for demurrage invoices changes (removal of last label - Company Account Details) REMOVING ONE SENTENCE FROM DEMURRAGE INVOICES
            'If Dr("BLNO") = "0314540917" Then
            '    Dim a As Integer
            '    a = 0
            'End If
            DS = Dtn.CalDetentionInwardInvoice(Dr("BLNO"), BLID, False, Dr("FreeDays"))
            Dm.QueryCriteria.Clear()
            Dm.QueryCriteria.And(JoinPath.TB_InwardDiscount.Columns.BLID, BLID, MatchType.Exact)
            Dscnt = Dm.GetTB_InwardDiscount()
            If Not Dscnt Is Nothing Then
                If Dscnt.dFreeDays > 0 And Dscnt.IsFDaysAsDiscount = True Then
                    sDscnt = "Free Days is " & Dscnt.dFreeDays.ToString
                End If
                If Dscnt.dAmount > 0 Then
                    sDscnt += IIf(sDscnt = "", "", vbCrLf) & " Amount is " & Format(Double.Parse(Dscnt.dAmount), "#,###")
                End If
                If Dscnt.dPercent > 0 Then
                    sDscnt += IIf(sDscnt = "", "", vbCrLf) & " Persent is " & Dscnt.dPercent.ToString
                End If
                sDscnt = IIf(sDscnt <> "", "DISCOUNT DETAILS :", "") & sDscnt
            End If
            Dm.QueryCriteria.Clear()
            Dm.QueryCriteria.And(JoinPath.TB_Clients.Columns.ID, Dr("ClientID"), MatchType.Exact)
            Clnt = Dm.GetTB_Clients


            Col = New DataColumn("TEL", System.Type.GetType("System.String"))
            Col.DefaultValue = ""
            DS.Tables(0).Columns.Add(Col)

            Col = New DataColumn("FAX", System.Type.GetType("System.String"))
            Col.DefaultValue = ""
            DS.Tables(0).Columns.Add(Col)

            Col = New DataColumn("EMAIL", System.Type.GetType("System.String"))
            Col.DefaultValue = ""
            DS.Tables(0).Columns.Add(Col)

            Col = New DataColumn("Reference", System.Type.GetType("System.Int64"))
            Col.DefaultValue = 0
            DS.Tables(0).Columns.Add(Col)

            Col = New DataColumn("DoDate", System.Type.GetType("System.DateTime"))
            DS.Tables(0).Columns.Add(Col)

            Col = New DataColumn("IssueDate", System.Type.GetType("System.DateTime"))
            DS.Tables(0).Columns.Add(Col)

            Dm.QueryCriteria.Clear()
            Dm.QueryCriteria.And(JoinPath.TB_InwardStatus.Columns.BLID, BLID, MatchType.Exact)
            Status = Dm.GetTB_InwardStatus


            sSql = "Select Top 1 I.IssueTime  From TB_Invoice I, TB_InvoiceDetails D Where I.ID =D.InvoiceID and D.ChargesCode ='DETN' and I.Status < 4  and I.BLID = '" & BLID.ToString & "' Order by I.Status"
            TableBySql(sSql, TB1, lResult)

            For Each dr1 As DataRow In DS.Tables(0).Rows

                Try
                    dr1("Reference") = 0
                Catch ex As Exception
                    dr1("Reference") = 0
                End Try
                If Not Clnt Is Nothing Then
                    dr1("TEL") = Clnt.TEL
                    dr1("Fax") = Clnt.Fax
                    dr1("EMAIL") = Clnt.Email
                End If

                If Not Status Is Nothing Then
                    Try
                        dr1("DoDate") = CDate(Status.DoDate)
                    Catch ex As Exception

                    End Try

                End If

                If TB1.Rows.Count > 0 Then
                    dr1("IssueDate") = TB1.Rows(0).Item(0)
                Else
                    dr1("IssueDate") = Today
                End If


            Next

            TbSum = GenSummaryDetention(Dtn, DS)
            Dim Invoice As Double
            Dim TotalPaid As Double
            Invoice = 0
            TotalPaid = 0
            For Each Dr1 In TbSum.Rows

                If TbSum.Rows.Count > 0 Then
                    Invoice += (NullToValue(Dr1("ToPaidIrr"), 0)) + (NullToValue(Dr1("ToBePaidIrrTax"), 0))
                    TotalPaid += (NullToValue(Dr1("PaidIrr"), 0)) + (NullToValue(Dr1("PaidIrrTax"), 0))
                    'BalanceAmount += (Dr1("ToPaidIrr") + Dr1("ToBePaidIrrTax")) - (TbSum.Rows(0).Item("PaidIrr") + TbSum.Rows(0).Item("PaidIrrTax"))
                Else
                    Dr("Invoice Total Amount") = 0
                    Dr("Total Paid") = 0
                    Dr("Balance Amount") = 0
                End If
            Next
            Dr("Invoice Total Amount") = Invoice
            Dr("Total Paid") = TotalPaid
            Dr("Balance Amount") = Invoice - TotalPaid

            Dim TEUFull As String
            Dim FirstTEU As Integer
            TEUFull = Dr("Total TEU")

            Dim isbns As New List(Of Integer)()
            FirstTEU = 0
            For Each i As Match In Regex.Matches(TEUFull, "X")
                isbns.Add(i.Index())
                If (TEUFull.IndexOf(i.Index() - 2) > 0) Then
                    FirstTEU += Convert.ToInt32(TEUFull.Substring(i.Index() - 2, 2)) * (Convert.ToInt32(TEUFull.Substring(i.Index() + 1, 2)) / 20)
                Else
                    FirstTEU += Convert.ToInt32(TEUFull.Substring(i.Index() - 1, 1)) * (Convert.ToInt32(TEUFull.Substring(i.Index() + 1, 2)) / 20)
                End If

            Next

            ' FirstTEU = Convert.ToInt32(TEUFull.Substring(0, 1)) * (Convert.ToInt32(TEUFull.Substring(2, 2)) / 20)

            Dr("Total TEU") = FirstTEU.ToString()
        Next


        Me.GridSummary.DataSource = TB
        With Me.GridSummary.DisplayLayout.Bands(0)
            .HeaderVisible = True
            .Header.Activated = True

            .Header.Appearance.BackColor = Color.Maroon
            .Header.Appearance.ForeColor = Color.Yellow
            .Header.Appearance.FontData.Name = "Verdana"
            .Header.Appearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.True
            .Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
            .Header.Appearance.FontData.SizeInPoints = 8
        End With
        GridNumSeperator(Me.GridSummary)

        'With Me.GridResult.DisplayLayout.Bands(0)
        '    .HeaderVisible = True
        '    .Header.Activated = True
        '    '.Header.Caption = "Demurrage Control From: " & Format(Me.DateFrom.GnrlDate.Value, "short date") & " To:" & Format(Me.DateTo.GnrlDate.Value.ToString, "short date")
        '    .Header.Appearance.BackColor = Color.Maroon
        '    .Header.Appearance.ForeColor = Color.Yellow
        '    .Header.Appearance.FontData.Name = "Verdana"
        '    .Header.Appearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.True
        '    .Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        '    .Header.Appearance.FontData.SizeInPoints = 8
        'End With

        Me.Cursor = Cursors.Default


        GridNumSeperator(Me.GridSummary)

    End Sub

    Private Function GenSummaryDetention(ByVal DET As CLDetention, ByVal Ds As DataSet) As System.Data.DataTable

        Dim TB As New System.Data.DataTable
        Dim Dr As DataRow

        Dim PaidDMUsd As Double
        Dim PaidDM As Double

        Dim PaidDet As Double
        Dim PaidDetUsd As Double

        Dim Seq As Integer
        Dim Deposit As Double

        Dim PaifFromDeposit As Double
        Dim PaifFromDepositUsd As Double

        With TB
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
        End With

        If DET.TotalAmount > 0 Then
            Seq += 1
            Dr = TB.NewRow
            Dr("ChargeCode") = "DETN"
            Dr = TB.NewRow
            Dr("Seq") = Seq
            Dr("Description") = "Detention"
            Dr("ToPaidIrr") = DET.TotalAmount - DET.TotalDiscount
            Dr("ToBePaidIrrTax") = (DET.TotalAmount - DET.TotalDiscount) * DET.TaxPercent / 100
            Dr("ToPaidUsd") = 0
            Dr("ToBePaidUsdTax") = 0
            Dr("PaidIrr") = 0
            Dr("PaidIrrTax") = 0
            Dr("PaidUsd") = 0
            Dr("PaidUsdTax") = 0
            TB.Rows.Add(Dr)
        End If

        If DET.TotalDamageCost + DET.TotalDamageCostUsd > 0 Then

            Seq += 1
            Dr = TB.NewRow
            Dr("ChargeCode") = "Damage Cost"
            Dr = TB.NewRow
            Dr("Seq") = Seq
            Dr("Description") = "Damage Cost"

            Dr("ToPaidUsd") = 0
            Dr("ToBePaidUsdTax") = 0
            Dr("ToPaidIrr") = 0
            Dr("ToBePaidIrrTax") = 0

            If DET.TotalDamageCost > 0 Then
                Dr("ToPaidIrr") = DET.TotalDamageCost
                Dr("ToBePaidIrrTax") = DET.TotalDamageCost * DET.TaxPercent / 100
            End If

            If DET.TotalDamageCostUsd > 0 Then
                Dr("ToPaidUsd") = DET.TotalDamageCostUsd
                Dr("ToBePaidUsdTax") = DET.TotalDamageCostUsd * DET.TaxPercent / 100

            End If
            TB.Rows.Add(Dr)
        End If


        For Each Dr In Ds.Tables(3).Select("ChargesCodes = 'DD'")
            If NullToValue(Dr("PaidRef"), "") <> "" Then
                ' Deposit += (NullToValue(Dr("Amount"), 0) - NullToValue(Dr("ReturnBackAmount"), 0))
                Deposit += (NullToValue(Dr("Amount"), 0))
            End If
        Next

        If Deposit > 0 Then
            Seq += 1
            Dr = TB.NewRow
            Dr("ChargeCode") = "Deposit"
            Dr = TB.NewRow
            Dr("Seq") = Seq
            Dr("ToPaidIrr") = 0
            Dr("ToBePaidIrrTax") = 0
            Dr("Description") = "Deposit"
            Dr("ToPaidUsd") = 0
            Dr("ToBePaidUsdTax") = 0
            Dr("PaidIrr") = Deposit
            Dr("PaidIrrTax") = 0
            Dr("PaidUsd") = 0
            Dr("PaidUsdTax") = 0
            TB.Rows.Add(Dr)
        End If

        If DET.FirstPaid + DET.FirstPaidUsd > 0 Then
            Seq += 1
            Dr = TB.NewRow
            Dr("ChargeCode") = "First Paid"
            Dr = TB.NewRow
            Dr("Seq") = Seq
            Dr("ToPaidIrr") = 0
            Dr("ToBePaidIrrTax") = 0
            Dr("Description") = "First Paid"
            Dr("ToPaidUsd") = 0
            Dr("ToBePaidUsdTax") = 0
            If DET.FirstPaidUsd > 0 Then
                Dr("PaidIrr") = 0
                Dr("PaidIrrTax") = 0
                Dr("PaidUsd") = DET.FirstPaidUsd
                Dr("PaidUsdTax") = 0
            Else
                Dr("PaidIrr") = DET.FirstPaid
                Dr("PaidIrrTax") = 0
                Dr("PaidUsd") = 0
                Dr("PaidUsdTax") = 0
            End If
            TB.Rows.Add(Dr)
        End If

        For Each Dr In Ds.Tables(2).Rows
            If Dr("Currency") = "IRR" Or Dr("IrrAmount") > 0 Then
                Select Case Dr("ChargesCode")
                    Case "DMCT"
                        PaidDM += Dr("IrrAmount")
                    Case "DETN"
                        PaidDet += Dr("IrrAmount")
                End Select
            Else
                Select Case Dr("ChargesCode")
                    Case "DMCT"
                        PaidDMUsd += Dr("Amount")
                    Case "DETN"
                        PaidDetUsd += Dr("Amount")
                End Select
            End If
        Next


        If PaidDM + PaidDMUsd > 0 Then
            Seq += 1
            Dr = TB.NewRow
            Dr("ChargeCode") = "Paid Damage"
            Dr = TB.NewRow
            Dr("Seq") = Seq
            Dr("ToPaidIrr") = 0
            Dr("ToBePaidIrrTax") = 0
            Dr("Description") = "Paid (Damage)"
            Dr("ToPaidUsd") = 0
            Dr("ToBePaidUsdTax") = 0
            If PaidDMUsd > 0 Then
                'Dr("PaidIrr") = 0
                ' Dr("PaidIrrTax") = 0
                Dr("PaidUsd") = PaidDMUsd
                Dr("PaidUsdTax") = PaidDMUsd * DET.TaxPercent / 100
            Else
                Dr("PaidIrr") = PaidDM
                Dr("PaidIrrTax") = PaidDM * DET.TaxPercent / 100
                ' Dr("PaidUsd") = 0
                'Dr("PaidUsdTax") = 0
            End If
            TB.Rows.Add(Dr)
        End If

        If PaidDet + PaidDetUsd > 0 Then
            Seq += 1
            Dr = TB.NewRow
            Dr("ChargeCode") = "Invoice"
            Dr = TB.NewRow
            Dr("Seq") = Seq
            Dr("ToPaidIrr") = 0
            Dr("ToBePaidIrrTax") = 0
            Dr("Description") = "Invoice"
            Dr("ToPaidUsd") = 0
            Dr("ToBePaidUsdTax") = 0
            If PaidDetUsd > 0 Then
                'Dr("PaidIrr") = 0
                'Dr("PaidIrrTax") = 0
                Dr("PaidUsd") = PaidDet
                Dr("PaidUsdTax") = (PaidDetUsd + DET.FirstPaidUsd) * DET.TaxPercent / 100
            Else
                Dr("PaidIrr") = PaidDet
                Dr("PaidIrrTax") = ((DET.TotalAmount - DET.TotalDiscount) * DET.TaxPercent) / 100
                ' Dr("PaidUsd") = 0
                'Dr("PaidUsdTax") = 0
            End If
            TB.Rows.Add(Dr)
        End If

        For Each Dr In Ds.Tables(4).Rows
            If Dr("Currency") = "IRR" Then
                PaifFromDeposit += Dr("Amount")
            Else
                PaifFromDepositUsd += Dr("Amount")
            End If
        Next

        If PaifFromDeposit + PaifFromDepositUsd > 0 Then
            Seq += 1
            Dr = TB.NewRow
            Dr("ChargeCode") = "Paid From Deposit"
            Dr = TB.NewRow
            Dr("Seq") = Seq
            Dr("ToPaidIrr") = 0
            Dr("ToBePaidIrrTax") = 0
            Dr("Description") = "Paid From Deposit"
            Dr("ToPaidUsd") = 0
            Dr("ToBePaidUsdTax") = 0
            If PaifFromDepositUsd > 0 Then
                'Dr("PaidIrr") = 0
                'Dr("PaidIrrTax") = 0
                Dr("PaidUsd") = PaifFromDepositUsd * -1
                Dr("PaidUsdTax") = 0
            Else
                Dr("PaidIrr") = PaifFromDeposit * -1
                Dr("PaidIrrTax") = 0
                'Dr("PaidUsd") = 0
                'Dr("PaidUsdTax") = 0
            End If
            TB.Rows.Add(Dr)
        End If

        Deposit = 0
        For Each Dr In Ds.Tables(3).Select("ChargesCodes = 'DD'")
            If NullToValue(Dr("PaidRef"), "") <> "" Then
                Deposit += NullToValue(Dr("ReturnBackAmount"), 0)
            End If
        Next

        If Deposit > 0 Then
            Seq += 1
            Dr = TB.NewRow
            Dr("ChargeCode") = "Settlement"
            Dr = TB.NewRow
            Dr("Seq") = Seq
            Dr("ToPaidIrr") = 0
            Dr("ToBePaidIrrTax") = 0
            Dr("Description") = "Settlement"
            Dr("ToPaidUsd") = 0
            Dr("ToBePaidUsdTax") = 0
            Dr("PaidIrr") = Deposit * -1
            Dr("PaidIrrTax") = 0
            Dr("PaidUsd") = 0
            Dr("PaidUsdTax") = 0
            TB.Rows.Add(Dr)
        End If


        Return TB

    End Function
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
    Private Sub FrmCustomerDemurageReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

        'dFrom = Me.MoveDateFrom.DateValue
        'dTo = Me.MoveDateTo.DateValue
        'dTo = DateAdd(DateInterval.Minute, 1434, dTo)

        'Cnn.Open()
        ''
        'With Cmd
        '    .CommandText = "SP_CustomerDemurageReport"
        '    .CommandType = CommandType.StoredProcedure
        '    .Connection = Cnn
        '    .Parameters.AddWithValue("@Client", Me.Clients.ClientID)

        'End With

        'DA.SelectCommand = Cmd
        'DA.Fill(dsExcelExport)
        DataGridView1.DataSource = TB

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
