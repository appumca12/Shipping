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
    Dim TBlFinalOutstandingSummary As New System.Data.DataTable
    Dim TBlDetentionOutstandingSummary As New System.Data.DataTable
    Dim tblCreated As Boolean = False
    Dim tblOutStandingCreated As Boolean = False
    Dim tblFinalOutStandingCreated As Boolean = False
    Dim tblDetentionOutStandingCreated As Boolean = False
    Dim TB As New System.Data.DataTable
    Dim TBLInwardDtMonth As New System.Data.DataTable
    Dim TBLYear As New System.Data.DataTable
    Private Sub CheckWHL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckWHL.CheckedChanged

    End Sub

    Private Sub UltraToolbarsManager1_ToolClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinToolbars.ToolClickEventArgs)
        Beep()
    End Sub

    Private Sub ButtonPickup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPickup.Click
        If Me.TabControl.SelectedTab.Text = "Detention Outstanding Summary" Then
            PickupMovement()
            'GenerateDetention()
        End If

    End Sub
    Private Sub ButtonToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonToExcel.Click

        Dim SaveDialog As New SaveFileDialog
        SaveDialog.Filter = "Excel Files (*.xls)|*.xls|All files (*.*)|*.*"
        SaveDialog.Title = "Save an Excel File"
        SaveDialog.ShowDialog()
        If SaveDialog.FileName <> "" Then
            saveExcelFileDetentionOutstanding(SaveDialog.FileName)
            'saveExcelFile(SaveDialog.FileName)
        End If
    End Sub
    Private Sub GenerateDetention()

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
        Dim nTotalOutstanding As Long
        Dim DrOutstanding As DataRow
        Dim sDateMonthQry As String
        Dim DrOutstandingFinal As DataRow
        Dim DrDetentionOutstanding As DataRow
        Dim monthForSummary As String
        Dim allMonths As String() = New String(12) {}
        allMonths(0) = "Jan"
        allMonths(1) = "Feb"
        allMonths(2) = "Mar"
        allMonths(3) = "Apr"
        allMonths(4) = "May"
        allMonths(5) = "Jun"
        allMonths(6) = "Jul"
        allMonths(7) = "Aug"
        allMonths(8) = "Sep"
        allMonths(9) = "Oct"
        allMonths(10) = "Nov"
        allMonths(11) = "Dec"
        Dim months As Integer() = New Integer(12) {}
        months(0) = 1
        months(1) = 2
        months(2) = 3
        months(3) = 4
        months(4) = 5
        months(5) = 6
        months(6) = 7
        months(7) = 8
        months(8) = 9
        months(9) = 10
        months(10) = 11
        months(11) = 12
        Dim dateSplit() As String
        Dim fromDtSplit() As String

        Dim toDateString As String
        Dim fromDateString As String

        TB.Clear()
        dFrom = Me.MoveDateFrom.DateValue
        dTo = Me.MoveDateTo.DateValue
        dTo = DateAdd(DateInterval.Minute, 1434, dTo)
        Dm = New DataManager(My.Settings.DSN)
        Me.Cursor = Cursors.WaitCursor
        Cmd = New SqlCommand("SP_DetentionOutStandingSummary")
        Cnn = New SqlConnection(My.Settings.DSN)
        Cnn.Open()
        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.Parameters.AddWithValue("@Line", CurrentShippingLine)
        Cmd.Parameters.AddWithValue("@dFrom", dFrom)
        Cmd.Parameters.AddWithValue("@dTO", dTo)
        Cmd.Connection = Cnn
        DA1.SelectCommand = Cmd
        DA1.Fill(TB)

        TBlOutstandingSummary.Clear()
        TBlFinalOutstandingSummary.Clear()
        TBlDetentionOutstandingSummary.Clear()
        'DrOutstandingFinal
        With TBlOutstandingSummary
            If (tblOutStandingCreated = False) Then
                .Columns.Add(New DataColumn("Y", System.Type.GetType("System.String")))
                .Columns.Add(New DataColumn("M", System.Type.GetType("System.String")))
                .Columns.Add(New DataColumn("OutstandingAmount", System.Type.GetType("System.Double")))
                tblOutStandingCreated = True
            End If
        End With

        With TBlFinalOutstandingSummary
            If (tblFinalOutStandingCreated = False) Then
                .Columns.Add(New DataColumn("Y", System.Type.GetType("System.String")))
                .Columns.Add(New DataColumn("M", System.Type.GetType("System.String")))
                .Columns.Add(New DataColumn("OutstandingAmount", System.Type.GetType("System.Double")))
                tblFinalOutStandingCreated = True
            End If
        End With

        With TBlDetentionOutstandingSummary
            If (tblDetentionOutStandingCreated = False) Then
                .Columns.Add(New DataColumn("Y", System.Type.GetType("System.String")))
                .Columns.Add(New DataColumn("M", System.Type.GetType("System.String")))
                .Columns.Add(New DataColumn("OutstandingAmount", System.Type.GetType("System.Double")))
                tblDetentionOutStandingCreated = True
            End If
        End With
        Me.Cursor = Cursors.Default
        '******** foe amount calc-appu ********
        For Each Dr In TB.Rows

            DS = StoredProcedures.SP_InwardBlsByLineBlNo(CurrentShippingLine, Dr("BLNO"))

            If DS.Tables(0).Rows.Count = 0 Then
                MsgBoxGeneral("No valid B/L No ?", "Data Requird")
                Exit Sub
            End If
            Sum = New CLInwardBlsSummary(DS.Tables(0).Rows(0).Item("Id"))

            BLID = DS.Tables(0).Rows(0).Item("ID")
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
        Me.Cursor = Cursors.Default
        Me.GridSummary.DataSource = TB
        With Me.GridSummary.DisplayLayout.Bands(0)
            .HeaderVisible = True
            .Header.Activated = True
            .Header.Caption = "Demurrage Contro Report:" & dFrom & "  To:" & dFrom
            .Header.Appearance.BackColor = Color.Maroon
            .Header.Appearance.ForeColor = Color.Yellow
            .Header.Appearance.FontData.Name = "Verdana"
            .Header.Appearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.True
            .Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
            .Header.Appearance.FontData.SizeInPoints = 8
        End With
        GridNumSeperator(Me.GridSummary)
        Me.Cursor = Cursors.Default


        GridNumSeperator(Me.GridSummary)
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
        Dim nTotalOutstanding As Long
        Dim DrOutstanding As DataRow
        Dim sDateMonthQry As String
        Dim DrOutstandingFinal As DataRow
        Dim DrDetentionOutstanding As DataRow
        Dim monthForSummary As String
        Dim allMonths As String() = New String(12) {}
        allMonths(0) = "Jan"
        allMonths(1) = "Feb"
        allMonths(2) = "Mar"
        allMonths(3) = "Apr"
        allMonths(4) = "May"
        allMonths(5) = "Jun"
        allMonths(6) = "Jul"
        allMonths(7) = "Aug"
        allMonths(8) = "Sep"
        allMonths(9) = "Oct"
        allMonths(10) = "Nov"
        allMonths(11) = "Dec"
        Dim months As Integer() = New Integer(12) {}
        months(0) = 1
        months(1) = 2
        months(2) = 3
        months(3) = 4
        months(4) = 5
        months(5) = 6
        months(6) = 7
        months(7) = 8
        months(8) = 9
        months(9) = 10
        months(10) = 11
        months(11) = 12
        Dim dateSplit() As String
        Dim fromDtSplit() As String

        Dim toDateString As String
        Dim fromDateString As String

        TB.Clear()
        dFrom = Me.MoveDateFrom.DateValue
        dTo = Me.MoveDateTo.DateValue
        ''dTo = DateAdd(DateInterval.Minute, 1434, dTo)
        Dm = New DataManager(My.Settings.DSN)
        Me.Cursor = Cursors.WaitCursor
        Cmd = New SqlCommand("SP_DetentionOutStandingSummary")
        Cnn = New SqlConnection(My.Settings.DSN)
        Cnn.Open()
        Cmd.CommandTimeout = 2000
        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.Parameters.AddWithValue("@Line", CurrentShippingLine)
        Cmd.Parameters.AddWithValue("@dFrom", dFrom)
        Cmd.Parameters.AddWithValue("@dTO", dTo)
        Cmd.Connection = Cnn
        DA1.SelectCommand = Cmd
        DA1.Fill(TB)

        TBlOutstandingSummary.Clear()
        TBlFinalOutstandingSummary.Clear()
        TBlDetentionOutstandingSummary.Clear()
        'DrOutstandingFinal
        With TBlOutstandingSummary
            If (tblOutStandingCreated = False) Then
                .Columns.Add(New DataColumn("Y", System.Type.GetType("System.String")))
                .Columns.Add(New DataColumn("M", System.Type.GetType("System.String")))
                .Columns.Add(New DataColumn("OutstandingAmount", System.Type.GetType("System.Double")))
                tblOutStandingCreated = True
            End If
        End With

        With TBlFinalOutstandingSummary
            If (tblFinalOutStandingCreated = False) Then
                .Columns.Add(New DataColumn("Y", System.Type.GetType("System.String")))
                .Columns.Add(New DataColumn("M", System.Type.GetType("System.String")))
                .Columns.Add(New DataColumn("OutstandingAmount", System.Type.GetType("System.Double")))
                tblFinalOutStandingCreated = True
            End If
        End With

        With TBlDetentionOutstandingSummary
            If (tblDetentionOutStandingCreated = False) Then
                .Columns.Add(New DataColumn("Y", System.Type.GetType("System.String")))
                .Columns.Add(New DataColumn("M", System.Type.GetType("System.String")))
                .Columns.Add(New DataColumn("OutstandingAmount", System.Type.GetType("System.Double")))
                tblDetentionOutStandingCreated = True
            End If
        End With
        Me.Cursor = Cursors.Default
        '******** foe amount calc-appu ********
        For Each Dr In TB.Rows

            DS = StoredProcedures.SP_InwardBlsByLineBlNo(CurrentShippingLine, Dr("BLNO"))

            If DS.Tables(0).Rows.Count = 0 Then
                MsgBoxGeneral("No valid B/L No ?", "Data Requird")
                Exit Sub
            End If
            Sum = New CLInwardBlsSummary(DS.Tables(0).Rows(0).Item("Id"))

            BLID = DS.Tables(0).Rows(0).Item("ID")
            
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
            Dim Invoice_USD As Double
            Dim TotalPaid_USD As Double

            Invoice = 0
            TotalPaid = 0
            Invoice_USD = 0
            TotalPaid_USD = 0
            For Each Dr1 In TbSum.Rows

                If TbSum.Rows.Count > 0 Then
                    Invoice += (NullToValue(Dr1("ToPaidIrr"), 0)) + (NullToValue(Dr1("ToBePaidIrrTax"), 0))
                    TotalPaid += (NullToValue(Dr1("PaidIrr"), 0)) + (NullToValue(Dr1("PaidIrrTax"), 0))
                    Invoice_USD += (NullToValue(Dr1("ToPaidUsd"), 0)) + (NullToValue(Dr1("ToBePaidUsdTax"), 0))
                    TotalPaid_USD += (NullToValue(Dr1("PaidUsd"), 0)) + (NullToValue(Dr1("PaidUsdTax"), 0))
                    'BalanceAmount += (Dr1("ToPaidIrr") + Dr1("ToBePaidIrrTax")) - (TbSum.Rows(0).Item("PaidIrr") + TbSum.Rows(0).Item("PaidIrrTax"))
                Else
                    Dr("Invoice Total Amount") = 0
                    Dr("Total Paid") = 0
                    Dr("Balance Amount") = 0
                    Dr("Invoice TotalAmount USD") = 0
                    Dr("TotalPaid USD") = 0
                    Dr("BalanceAmount USD") = 0
                End If
            Next
            Dr("Invoice Total Amount") = Invoice
            Dr("Total Paid") = TotalPaid
            Dr("Balance Amount") = Invoice - TotalPaid
            Dr("Invoice TotalAmount USD") = Invoice_USD
            Dr("TotalPaid USD") = TotalPaid_USD
            Dr("BalanceAmount USD") = Invoice_USD - TotalPaid_USD
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
        Me.Cursor = Cursors.Default
        '/* Detention Outstanding Summary*/
        '**********************************
        Dim cntrmaxdate As String
        cntrmaxdate = TB.Compute("max(AllContainerReturnBackDate)", String.Empty)
        sDateMonthQry = "select Distinct(year(IssueTime)) as Y, month(IssueTime) as M From TB_Invoice where IssueTime between '" & dFrom.ToString("yyyy-MM-dd") & "' AND '" & cntrmaxdate & "' order by Y,M"
        TableBySql(sDateMonthQry, TBLInwardDtMonth, lResult)

        'Drs = Temp.Select("CntrNo = '" & Row("CntrNo") & "'")
        Dim isMonthSame As Boolean = False
        Dim monthCounter As Integer = 0
        Dim isBalanceZero As Boolean = False
        Dim tblRecCounter As Integer = 0
        Dim issueDate As Date
        Dim MonthYearSplit() As String
        Dim MonthYear As String

        For Each drDtMonth As DataRow In TBLInwardDtMonth.Rows
            nTotalOutstanding = 0
            For Each drBalance As DataRow In TB.Rows
                tblRecCounter = tblRecCounter + 1
                issueDate = drBalance("AllContainerReturnBackDate")
                MonthYearSplit = Split(issueDate.ToString("yyyy-MM-dd"), "-")
                'If (drDtMonth("Y").ToString() = drBalance("Y").ToString() And drDtMonth("M").ToString() = drBalance("M").ToString()) Then
                If (drDtMonth("Y").ToString() = MonthYearSplit(0).ToString() And Int64.Parse(drDtMonth("M").ToString()) = Int64.Parse(MonthYearSplit(1).ToString())) Then
                    If (drBalance("Balance Amount") > 0) Then
                        nTotalOutstanding += drBalance("Balance Amount")
                        'MessageBox.Show(drBalance("Balance Amount").ToString() & tblRecCounter.ToString())
                    End If
                End If
            Next
            If (nTotalOutstanding > 0) Then
                DrOutstanding = TBlOutstandingSummary.NewRow
                DrOutstanding("Y") = drDtMonth("Y").ToString()
                DrOutstanding("M") = GetMonthName(Int64.Parse(drDtMonth("M").ToString().Trim()))
                DrOutstanding("OutstandingAmount") = nTotalOutstanding
                TBlOutstandingSummary.Rows.Add(DrOutstanding)
            End If
        Next
        Dim sqlYear As String
       
        sqlYear = "select Distinct(year(IssueTime)) as Y From TB_Invoice where IssueTime between '" & dFrom.ToString("yyyy-MM-dd") & "' AND '" & cntrmaxdate & "' order by Y"


        TableBySql(sqlYear, TBLYear, lResult)

        toDateString = dTo.ToString("yyyy-MM-dd")
        dateSplit = Split(toDateString, "-")
        Dim endMonth As Integer = Int64.Parse(dateSplit(1).ToString())
        Dim monthCount As Integer = 0

        fromDateString = dFrom.ToString("yyyy-MM-dd")
        fromDtSplit = Split(fromDateString, "-")
        Dim fromMonth As Integer = Int64.Parse(fromDtSplit(1).ToString())

        monthForSummary = String.Empty
        Dim isRowProcessed As Boolean = False

        For Each dr As DataRow In TBLYear.Rows
            monthForSummary = String.Empty
            
            For Each drOutSum As DataRow In TBlOutstandingSummary.Rows
                If (dr("Y") = drOutSum("Y")) Then
                    For Each s As String In allMonths
                        If (s <> Nothing) Then
                            isRowProcessed = False
                            DrOutstandingFinal = TBlFinalOutstandingSummary.NewRow
                            If (drOutSum("M") = s And monthForSummary.Contains(drOutSum("M").ToString()) = False) Then
                                If drOutSum("OutstandingAmount") > 0 Then
                                    DrOutstandingFinal("Y") = dr("Y").ToString()
                                    DrOutstandingFinal("M") = drOutSum("M").ToString()
                                    DrOutstandingFinal("OutstandingAmount") = drOutSum("OutstandingAmount")
                                    TBlFinalOutstandingSummary.Rows.Add(DrOutstandingFinal)
                                    isRowProcessed = True
                                    If (monthForSummary = String.Empty) Then
                                        monthForSummary = drOutSum("M")
                                    Else
                                        monthForSummary = monthForSummary & "," & drOutSum("M")
                                    End If
                                    Exit For
                                Else
                                    DrOutstandingFinal("Y") = dr("Y").ToString()
                                    DrOutstandingFinal("M") = drOutSum("M").ToString()
                                    DrOutstandingFinal("OutstandingAmount") = 0
                                    TBlFinalOutstandingSummary.Rows.Add(DrOutstandingFinal)
                                    isRowProcessed = True
                                    If (monthForSummary = String.Empty) Then
                                        monthForSummary = drOutSum("M")
                                    Else
                                        monthForSummary = monthForSummary & "," & drOutSum("M")
                                    End If
                                    Exit For
                                End If
                            End If
                        End If
                    Next
                    
                End If
            Next
            Dim tempMonth As String = String.Empty
            For Each i As Integer In months
                If (i <> Nothing) Then

                    If (i = 1) Then
                        tempMonth = "Jan"
                    End If
                    If (i = 2) Then
                        tempMonth = "Feb"
                    End If
                    If (i = 3) Then
                        tempMonth = "Mar"
                    End If
                    If (i = 4) Then
                        tempMonth = "Apr"
                    End If
                    If (i = 5) Then
                        tempMonth = "May"
                    End If
                    If (i = 6) Then
                        tempMonth = "Jun"
                    End If
                    If (i = 7) Then
                        tempMonth = "Jul"
                    End If
                    If (i = 8) Then
                        tempMonth = "Aug"
                    End If
                    If (i = 9) Then
                        tempMonth = "Sep"
                    End If
                    If (i = 10) Then
                        tempMonth = "Oct"
                    End If
                    If (i = 11) Then
                        tempMonth = "Nov"
                    End If
                    If (i = 12) Then
                        tempMonth = "Dec"
                    End If
                    If (TBLYear.Rows.Count = 1) Then
                        If (monthForSummary.Contains(tempMonth) = False And i >= fromMonth And i <= endMonth) Then
                            DrOutstandingFinal = TBlFinalOutstandingSummary.NewRow
                            DrOutstandingFinal("Y") = dr("Y").ToString()
                            DrOutstandingFinal("M") = GetMonthName(i)
                            DrOutstandingFinal("OutstandingAmount") = 0
                            TBlFinalOutstandingSummary.Rows.Add(DrOutstandingFinal)
                        End If
                    Else
                        If (monthForSummary.Contains(tempMonth) = False And i >= 1 And i <= 12 And i >= fromMonth And Int64.Parse(dr("Y").ToString()) < Int64.Parse(dateSplit(0).ToString())) Then
                            DrOutstandingFinal = TBlFinalOutstandingSummary.NewRow
                            DrOutstandingFinal("Y") = dr("Y").ToString()
                            DrOutstandingFinal("M") = GetMonthName(i)
                            DrOutstandingFinal("OutstandingAmount") = 0
                            TBlFinalOutstandingSummary.Rows.Add(DrOutstandingFinal)
                        ElseIf (monthForSummary.Contains(tempMonth) = False And i >= 1 And i <= 12 And i <= endMonth And Int64.Parse(dr("Y").ToString()) = Int64.Parse(dateSplit(0).ToString())) Then
                            DrOutstandingFinal = TBlFinalOutstandingSummary.NewRow
                            DrOutstandingFinal("Y") = dr("Y").ToString()
                            DrOutstandingFinal("M") = GetMonthName(i)
                            DrOutstandingFinal("OutstandingAmount") = 0
                            TBlFinalOutstandingSummary.Rows.Add(DrOutstandingFinal)
                        End If
                    End If
                End If
            Next
        Next
        For Each dr As DataRow In TBLYear.Rows
            For Each drOutSum As DataRow In TBlFinalOutstandingSummary.Rows
                If (dr("Y") = drOutSum("Y")) Then
                    DrDetentionOutstanding = TBlDetentionOutstandingSummary.NewRow
                    If (drOutSum("M") = "Jan") Then
                        DrDetentionOutstanding("Y") = dr("Y").ToString()
                        DrDetentionOutstanding("M") = drOutSum("M").ToString()
                        DrDetentionOutstanding("OutstandingAmount") = drOutSum("OutstandingAmount")
                        TBlDetentionOutstandingSummary.Rows.Add(DrDetentionOutstanding)
                    End If
                    If (drOutSum("M") = "Feb") Then
                        DrDetentionOutstanding("Y") = dr("Y").ToString()
                        DrDetentionOutstanding("M") = drOutSum("M").ToString()
                        DrDetentionOutstanding("OutstandingAmount") = drOutSum("OutstandingAmount")
                        TBlDetentionOutstandingSummary.Rows.Add(DrDetentionOutstanding)
                    End If
                    If (drOutSum("M") = "Mar") Then
                        DrDetentionOutstanding("Y") = dr("Y").ToString()
                        DrDetentionOutstanding("M") = drOutSum("M").ToString()
                        DrDetentionOutstanding("OutstandingAmount") = drOutSum("OutstandingAmount")
                        TBlDetentionOutstandingSummary.Rows.Add(DrDetentionOutstanding)
                    End If
                    If (drOutSum("M") = "Apr") Then
                        DrDetentionOutstanding("Y") = dr("Y").ToString()
                        DrDetentionOutstanding("M") = drOutSum("M").ToString()
                        DrDetentionOutstanding("OutstandingAmount") = drOutSum("OutstandingAmount")
                        TBlDetentionOutstandingSummary.Rows.Add(DrDetentionOutstanding)
                    End If
                    If (drOutSum("M") = "May") Then
                        DrDetentionOutstanding("Y") = dr("Y").ToString()
                        DrDetentionOutstanding("M") = drOutSum("M").ToString()
                        DrDetentionOutstanding("OutstandingAmount") = drOutSum("OutstandingAmount")
                        TBlDetentionOutstandingSummary.Rows.Add(DrDetentionOutstanding)
                    End If
                    If (drOutSum("M") = "Jun") Then
                        DrDetentionOutstanding("Y") = dr("Y").ToString()
                        DrDetentionOutstanding("M") = drOutSum("M").ToString()
                        DrDetentionOutstanding("OutstandingAmount") = drOutSum("OutstandingAmount")
                        TBlDetentionOutstandingSummary.Rows.Add(DrDetentionOutstanding)
                    End If
                    If (drOutSum("M") = "Jul") Then
                        DrDetentionOutstanding("Y") = dr("Y").ToString()
                        DrDetentionOutstanding("M") = drOutSum("M").ToString()
                        DrDetentionOutstanding("OutstandingAmount") = drOutSum("OutstandingAmount")
                        TBlDetentionOutstandingSummary.Rows.Add(DrDetentionOutstanding)
                    End If
                    If (drOutSum("M") = "Aug") Then
                        DrDetentionOutstanding("Y") = dr("Y").ToString()
                        DrDetentionOutstanding("M") = drOutSum("M").ToString()
                        DrDetentionOutstanding("OutstandingAmount") = drOutSum("OutstandingAmount")
                        TBlDetentionOutstandingSummary.Rows.Add(DrDetentionOutstanding)
                    End If
                    If (drOutSum("M") = "Sep") Then
                        DrDetentionOutstanding("Y") = dr("Y").ToString()
                        DrDetentionOutstanding("M") = drOutSum("M").ToString()
                        DrDetentionOutstanding("OutstandingAmount") = drOutSum("OutstandingAmount")
                        TBlDetentionOutstandingSummary.Rows.Add(DrDetentionOutstanding)
                    End If
                    If (drOutSum("M") = "Oct") Then
                        DrDetentionOutstanding("Y") = dr("Y").ToString()
                        DrDetentionOutstanding("M") = drOutSum("M").ToString()
                        DrDetentionOutstanding("OutstandingAmount") = drOutSum("OutstandingAmount")
                        TBlDetentionOutstandingSummary.Rows.Add(DrDetentionOutstanding)
                    End If
                    If (drOutSum("M") = "Nov") Then
                        DrDetentionOutstanding("Y") = dr("Y").ToString()
                        DrDetentionOutstanding("M") = drOutSum("M").ToString()
                        DrDetentionOutstanding("OutstandingAmount") = drOutSum("OutstandingAmount")
                        TBlDetentionOutstandingSummary.Rows.Add(DrDetentionOutstanding)
                    End If
                    If (drOutSum("M") = "Dec") Then
                        DrDetentionOutstanding("Y") = dr("Y").ToString()
                        DrDetentionOutstanding("M") = drOutSum("M").ToString()
                        DrDetentionOutstanding("OutstandingAmount") = drOutSum("OutstandingAmount")
                        TBlDetentionOutstandingSummary.Rows.Add(DrDetentionOutstanding)
                    End If
                End If
            Next
        Next
       
        Me.GridSummary.DataSource = TBlDetentionOutstandingSummary
        With Me.GridSummary.DisplayLayout.Bands(0)
            .HeaderVisible = True
            .Header.Activated = True
            .Header.Caption = "Detention Outstanding Summary:" & dFrom & "  To:" & dTo
            .Header.Appearance.BackColor = Color.Maroon
            .Header.Appearance.ForeColor = Color.Yellow
            .Header.Appearance.FontData.Name = "Verdana"
            .Header.Appearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.True
            .Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
            .Header.Appearance.FontData.SizeInPoints = 8
        End With

        GridNumSeperator(Me.GridSummary)

    End Sub
    

    'Private Function GenSummaryDetention(ByVal DET As CLDetention, ByVal Ds As DataSet) As System.Data.DataTable

    '    Dim TB As New System.Data.DataTable
    '    Dim Dr As DataRow

    '    Dim PaidDMUsd As Double
    '    Dim PaidDM As Double

    '    Dim PaidDet As Double
    '    Dim PaidDetUsd As Double

    '    Dim Seq As Integer
    '    Dim Deposit As Double

    '    Dim PaifFromDeposit As Double
    '    Dim PaifFromDepositUsd As Double

    '    With TB
    '        .Columns.Add(New DataColumn("ChargeCode", System.Type.GetType("System.String")))
    '        .Columns.Add(New DataColumn("Seq", System.Type.GetType("System.Int16")))
    '        .Columns.Add(New DataColumn("Description", System.Type.GetType("System.String")))
    '        .Columns.Add(New DataColumn("ToPaidIrr", System.Type.GetType("System.Double")))
    '        .Columns.Add(New DataColumn("ToBePaidIrrTax", System.Type.GetType("System.Double")))
    '        .Columns.Add(New DataColumn("ToPaidUsd", System.Type.GetType("System.Double")))
    '        .Columns.Add(New DataColumn("ToBePaidUsdTax", System.Type.GetType("System.Double")))
    '        .Columns.Add(New DataColumn("PaidIrr", System.Type.GetType("System.Double")))
    '        .Columns.Add(New DataColumn("PaidIrrTax", System.Type.GetType("System.Double")))
    '        .Columns.Add(New DataColumn("PaidUsd", System.Type.GetType("System.Double")))
    '        .Columns.Add(New DataColumn("PaidUsdTax", System.Type.GetType("System.Double")))
    '    End With

    '    If DET.TotalAmount > 0 Then
    '        Seq += 1
    '        Dr = TB.NewRow
    '        Dr("ChargeCode") = "DETN"
    '        Dr = TB.NewRow
    '        Dr("Seq") = Seq
    '        Dr("Description") = "Detention"
    '        Dr("ToPaidIrr") = DET.TotalAmount - DET.TotalDiscount
    '        Dr("ToBePaidIrrTax") = (DET.TotalAmount - DET.TotalDiscount) * DET.TaxPercent / 100
    '        Dr("ToPaidUsd") = 0
    '        Dr("ToBePaidUsdTax") = 0
    '        Dr("PaidIrr") = 0
    '        Dr("PaidIrrTax") = 0
    '        Dr("PaidUsd") = 0
    '        Dr("PaidUsdTax") = 0
    '        TB.Rows.Add(Dr)
    '    End If

    '    If DET.TotalDamageCost + DET.TotalDamageCostUsd > 0 Then

    '        Seq += 1
    '        Dr = TB.NewRow
    '        Dr("ChargeCode") = "Damage Cost"
    '        Dr = TB.NewRow
    '        Dr("Seq") = Seq
    '        Dr("Description") = "Damage Cost"

    '        Dr("ToPaidUsd") = 0
    '        Dr("ToBePaidUsdTax") = 0
    '        Dr("ToPaidIrr") = 0
    '        Dr("ToBePaidIrrTax") = 0

    '        If DET.TotalDamageCost > 0 Then
    '            Dr("ToPaidIrr") = DET.TotalDamageCost
    '            Dr("ToBePaidIrrTax") = DET.TotalDamageCost * DET.TaxPercent / 100
    '        End If

    '        If DET.TotalDamageCostUsd > 0 Then
    '            Dr("ToPaidUsd") = DET.TotalDamageCostUsd
    '            Dr("ToBePaidUsdTax") = DET.TotalDamageCostUsd * DET.TaxPercent / 100

    '        End If
    '        TB.Rows.Add(Dr)
    '    End If


    '    For Each Dr In Ds.Tables(3).Select("ChargesCodes = 'DD'")
    '        If NullToValue(Dr("PaidRef"), "") <> "" Then
    '            ' Deposit += (NullToValue(Dr("Amount"), 0) - NullToValue(Dr("ReturnBackAmount"), 0))
    '            Deposit += (NullToValue(Dr("Amount"), 0))
    '        End If
    '    Next

    '    If Deposit > 0 Then
    '        Seq += 1
    '        Dr = TB.NewRow
    '        Dr("ChargeCode") = "Deposit"
    '        Dr = TB.NewRow
    '        Dr("Seq") = Seq
    '        Dr("ToPaidIrr") = 0
    '        Dr("ToBePaidIrrTax") = 0
    '        Dr("Description") = "Deposit"
    '        Dr("ToPaidUsd") = 0
    '        Dr("ToBePaidUsdTax") = 0
    '        Dr("PaidIrr") = Deposit
    '        Dr("PaidIrrTax") = 0
    '        Dr("PaidUsd") = 0
    '        Dr("PaidUsdTax") = 0
    '        TB.Rows.Add(Dr)
    '    End If

    '    If DET.FirstPaid + DET.FirstPaidUsd > 0 Then
    '        Seq += 1
    '        Dr = TB.NewRow
    '        Dr("ChargeCode") = "First Paid"
    '        Dr = TB.NewRow
    '        Dr("Seq") = Seq
    '        Dr("ToPaidIrr") = 0
    '        Dr("ToBePaidIrrTax") = 0
    '        Dr("Description") = "First Paid"
    '        Dr("ToPaidUsd") = 0
    '        Dr("ToBePaidUsdTax") = 0
    '        If DET.FirstPaidUsd > 0 Then
    '            Dr("PaidIrr") = 0
    '            Dr("PaidIrrTax") = 0
    '            Dr("PaidUsd") = DET.FirstPaidUsd
    '            Dr("PaidUsdTax") = 0
    '        Else
    '            Dr("PaidIrr") = DET.FirstPaid
    '            Dr("PaidIrrTax") = 0
    '            Dr("PaidUsd") = 0
    '            Dr("PaidUsdTax") = 0
    '        End If
    '        TB.Rows.Add(Dr)
    '    End If

    '    For Each Dr In Ds.Tables(2).Rows
    '        If Dr("Currency") = "IRR" Or Dr("IrrAmount") > 0 Then
    '            Select Case Dr("ChargesCode")
    '                Case "DMCT"
    '                    PaidDM += Dr("IrrAmount")
    '                Case "DETN"
    '                    PaidDet += Dr("IrrAmount")
    '            End Select
    '        Else
    '            Select Case Dr("ChargesCode")
    '                Case "DMCT"
    '                    PaidDMUsd += Dr("Amount")
    '                Case "DETN"
    '                    PaidDetUsd += Dr("Amount")
    '            End Select
    '        End If
    '    Next


    '    If PaidDM + PaidDMUsd > 0 Then
    '        Seq += 1
    '        Dr = TB.NewRow
    '        Dr("ChargeCode") = "Paid Damage"
    '        Dr = TB.NewRow
    '        Dr("Seq") = Seq
    '        Dr("ToPaidIrr") = 0
    '        Dr("ToBePaidIrrTax") = 0
    '        Dr("Description") = "Paid (Damage)"
    '        Dr("ToPaidUsd") = 0
    '        Dr("ToBePaidUsdTax") = 0
    '        If PaidDMUsd > 0 Then
    '            'Dr("PaidIrr") = 0
    '            ' Dr("PaidIrrTax") = 0
    '            Dr("PaidUsd") = PaidDMUsd
    '            Dr("PaidUsdTax") = PaidDMUsd * DET.TaxPercent / 100
    '        Else
    '            Dr("PaidIrr") = PaidDM
    '            Dr("PaidIrrTax") = PaidDM * DET.TaxPercent / 100
    '            'Dr("PaidUsd") = 0
    '            'Dr("PaidUsdTax") = 0
    '        End If
    '        TB.Rows.Add(Dr)
    '    End If

    '    If PaidDet + PaidDetUsd > 0 Then
    '        Seq += 1
    '        Dr = TB.NewRow
    '        Dr("ChargeCode") = "Invoice"
    '        Dr = TB.NewRow
    '        Dr("Seq") = Seq
    '        Dr("ToPaidIrr") = 0
    '        Dr("ToBePaidIrrTax") = 0
    '        Dr("Description") = "Invoice"
    '        Dr("ToPaidUsd") = 0
    '        Dr("ToBePaidUsdTax") = 0
    '        If PaidDetUsd > 0 Then
    '            'Dr("PaidIrr") = 0
    '            'Dr("PaidIrrTax") = 0
    '            Dr("PaidUsd") = PaidDet
    '            Dr("PaidUsdTax") = (PaidDetUsd + DET.FirstPaidUsd) * DET.TaxPercent / 100
    '        Else
    '            Dr("PaidIrr") = PaidDet
    '            Dr("PaidIrrTax") = ((DET.TotalAmount - DET.TotalDiscount) * DET.TaxPercent) / 100
    '            'Dr("PaidUsd") = 0
    '            'Dr("PaidUsdTax") = 0
    '        End If
    '        TB.Rows.Add(Dr)
    '    End If

    '    For Each Dr In Ds.Tables(4).Rows
    '        If Dr("Currency") = "IRR" Then
    '            PaifFromDeposit += Dr("Amount")
    '        Else
    '            PaifFromDepositUsd += Dr("Amount")
    '        End If
    '    Next

    '    If PaifFromDeposit + PaifFromDepositUsd > 0 Then
    '        Seq += 1
    '        Dr = TB.NewRow
    '        Dr("ChargeCode") = "Paid From Deposit"
    '        Dr = TB.NewRow
    '        Dr("Seq") = Seq
    '        Dr("ToPaidIrr") = 0
    '        Dr("ToBePaidIrrTax") = 0
    '        Dr("Description") = "Paid From Deposit"
    '        Dr("ToPaidUsd") = 0
    '        Dr("ToBePaidUsdTax") = 0
    '        If PaifFromDepositUsd > 0 Then
    '            'Dr("PaidIrr") = 0
    '            'Dr("PaidIrrTax") = 0
    '            Dr("PaidUsd") = PaifFromDepositUsd * -1
    '            Dr("PaidUsdTax") = 0
    '        Else
    '            Dr("PaidIrr") = PaifFromDeposit * -1
    '            Dr("PaidIrrTax") = 0
    '            'Dr("PaidUsd") = 0
    '            'Dr("PaidUsdTax") = 0
    '        End If
    '        TB.Rows.Add(Dr)
    '    End If

    '    Deposit = 0
    '    For Each Dr In Ds.Tables(3).Select("ChargesCodes = 'DD'")
    '        If NullToValue(Dr("PaidRef"), "") <> "" Then
    '            Deposit += NullToValue(Dr("ReturnBackAmount"), 0)
    '        End If
    '    Next

    '    If Deposit > 0 Then
    '        Seq += 1
    '        Dr = TB.NewRow
    '        Dr("ChargeCode") = "Settlement"
    '        Dr = TB.NewRow
    '        Dr("Seq") = Seq
    '        Dr("ToPaidIrr") = 0
    '        Dr("ToBePaidIrrTax") = 0
    '        Dr("Description") = "Settlement"
    '        Dr("ToPaidUsd") = 0
    '        Dr("ToBePaidUsdTax") = 0
    '        Dr("PaidIrr") = Deposit * -1
    '        Dr("PaidIrrTax") = 0
    '        Dr("PaidUsd") = 0
    '        Dr("PaidUsdTax") = 0
    '        TB.Rows.Add(Dr)
    '    End If


    '    Return TB

    'End Function

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
            Dr("PaidIrr") = 0
            Dr("PaidIrrTax") = 0
            Dr("PaidUsd") = 0
            Dr("PaidUsdTax") = 0
            If PaidDMUsd > 0 Then
                'Dr("PaidIrr") = 0
                'Dr("PaidIrrTax") = 0
                Dr("PaidUsd") = PaidDMUsd
                Dr("PaidUsdTax") = PaidDMUsd * DET.TaxPercent / 100
            End If
            If PaidDM > 0 Then
                Dr("PaidIrr") = PaidDM
                Dr("PaidIrrTax") = PaidDM * DET.TaxPercent / 100
                'Dr("PaidUsd") = 0
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
                Dr("PaidUsd") = PaidDetUsd
                Dr("PaidUsdTax") = (PaidDetUsd + DET.FirstPaidUsd) * DET.TaxPercent / 100
            Else
                Dr("PaidIrr") = PaidDet
                Dr("PaidIrrTax") = ((DET.TotalAmount - DET.TotalDiscount) * DET.TaxPercent) / 100
                'Dr("PaidUsd") = 0
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
                ' Dr("PaidIrr") = 0
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

        'dFrom = Me.MoveDateFrom.DateValue
        'dTo = Me.MoveDateTo.DateValue
        'dTo = DateAdd(DateInterval.Minute, 1434, dTo)

        'Cnn.Open()
        ''
        'With Cmd
        '    .CommandText = "SP_DemurageControlReport"
        '    .CommandType = CommandType.StoredProcedure
        '    .Connection = Cnn
        '    .Parameters.AddWithValue("@dFrom", dFrom)
        '    .Parameters.AddWithValue("@dTo", dTo)
        '    .Parameters.AddWithValue("@Line", CurrentShippingLine)
        'End With

        'DA.SelectCommand = Cmd
        'DA.Fill(TB)
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
    Private Sub saveExcelFileDetentionOutstanding(ByVal FileName As String)

        DataGridView1.DataSource = TBlDetentionOutstandingSummary
        'TBlFinalOutstandingSummary()
        System.Threading.Thread.CurrentThread.CurrentCulture = _
               System.Globalization.CultureInfo.CreateSpecificCulture("en-US")
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
                End If
                If (j = 3) Then
                    'xlWorkSheet.Range("A:A").fo()
                    xlWorkSheet.Range("C:C").NumberFormat = "###.###"
                End If
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
