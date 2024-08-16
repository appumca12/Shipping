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

Public Class FrmExportDetentionReport

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
    Dim tblCreated As Boolean = False
    Dim TB As New System.Data.DataTable
    Dim TBLInwardDtMonth As New System.Data.DataTable
    Dim TBLYear As New System.Data.DataTable
    ' For Export
    Dim TBlPaidDet As New System.Data.DataTable
    Dim TBDetExp As New System.Data.DataTable
    Dim tblDetPaidCreated As Boolean = False
    ' 25 Feb 2016
    Dim dFrom As Date
    Dim dTo As Date
    Dim TbShowdetList As New System.Data.DataTable

    Private TotalDetention As Double
    Private lAllReturnBack As Boolean = True
    Private lHasError As Boolean
    Private BLID As Guid
    Private nFistPaid As Int64
    Private nPaid As Int64
    Private nPaidUsd As Double
    Private nTotalDiscount As Int64
    Private nTotaldetention
    Private nBalance As Int64
    Private nTax As Double
    Private nTaxAmount As Int64
    Private nTotalDamageCost As Long
    Private nPaidDamage As Double
    Private nPaidDamageUsd As Double
    Private nDamageTax As Double
    Private sDamageCurrency As String
    Private nFirstPaidUsd As Double
    Private nTotalDamageCostUsd As Double
    Private nDamageTaxUsd As Double
    Private IsChildBl As Boolean = False
    Private IsMasterBL As Boolean = False
    Private ResultTable As System.Data.DataTable
    Private TotalDetantion As Long
    Private TotalDiscount As Long
    Private TotalDamageCost As Long
    Private TotalDamageCostUsd As Double
    Private lIsMasterBL As Boolean = False
    Private lIsChaildBL As Boolean = False
    Private IsBlSetFromOutSide As Boolean = False
    Private Cnn As SqlConnection
    Private Cmd As SqlCommand

    Public ReadOnly Property TaxAmount() As Int64
        Get
            Return nTaxAmount
        End Get
    End Property

    Public Property IsChaildBL() As Boolean
        Get
            Return lIsChaildBL
        End Get
        Set(ByVal value As Boolean)
            lIsChaildBL = value
        End Set
    End Property

    Private Sub UltraToolbarsManager1_ToolClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinToolbars.ToolClickEventArgs)
        Beep()
    End Sub

    Private Sub ButtonPickup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPickup.Click
        If Me.TabControl.SelectedTab.Text = "Export Detention Report" Then
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
            'saveExcelFileDetentionOutstanding(SaveDialog.FileName)
            saveExcelFile(SaveDialog.FileName)
        End If
    End Sub

    Private Sub ExportDetention()

        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim Cnn As New SqlConnection(My.Settings.DSN)
        Dim DS As New DataSet
        Dim dFrom As Date
        Dim dTo As Date
        Dim cCol(0) As DataColumn
        Dim Detn As New CLDetention
        Dim CalBase As New CLCalculationBase
        Dim Dtn As New CLDetention
        Dim PH As New CLPrintHdr
        Dim TbSum As New System.Data.DataTable

        TBDetExp.Clear()
        dFrom = Me.MoveDateFrom.DateValue
        dTo = Me.MoveDateTo.DateValue
        Dm = New DataManager(My.Settings.DSN)
        Me.Cursor = Cursors.WaitCursor
        Cmd = New SqlCommand("SP_ExportDetentionReport")
        Cnn = New SqlConnection(My.Settings.DSN)
        Cnn.Open()
        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.Parameters.AddWithValue("@Line", CurrentShippingLine)
        Cmd.Parameters.AddWithValue("@dFrom", CDate(dFrom))
        Cmd.Parameters.AddWithValue("@dTO", CDate(dTo))
        Cmd.Connection = Cnn
        DA.SelectCommand = Cmd
        DA.Fill(TBDetExp)
    End Sub

    Private Sub saveExcelFile(ByVal FileName As String)
        Dim dsExcelExport As New DataSet
        Dim daExcelExport As New SqlDataAdapter
        Dim Excel As Microsoft.Office.Interop.Excel.Application = New Microsoft.Office.Interop.Excel.Application
        Dim varConnection As New SqlConnection
        Dim conCurrent As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim Cnn As New SqlConnection(My.Settings.DSN)
        Dim DS As New DataSet
        Dim cCol(0) As DataColumn

        DataGridView1.DataSource = TBlPaidDet
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
            xlWorkSheet.Cells(1, intColumn + 1).Value = TBlPaidDet.Columns(intColumn).ColumnName.ToString
        Next

        For i = 0 To DataGridView1.RowCount - 2
            For j = 0 To DataGridView1.ColumnCount - 1
                If (j = 1 Or j = 7) Then
                    Dim SaccountDetails() As String = DataGridView1(j, i).Value.ToString().Split(" ")
                    xlWorkSheet.Cells(i + 2, j + 1) = SaccountDetails(0)
                    '    If (Not DataGridView1(j, i).Value.ToString() = "") Then
                    '        xlWorkSheet.Cells(i + 2, j + 1) = CDate(DateTime.Parse(DataGridView1(j, i).Value.ToString(), Globalization.CultureInfo.CreateSpecificCulture("en-CA").DateTimeFormat))
                    '        'xlWorkSheet.Cells(1, intColumn + 1).Value = TBlOutstandingSummary.Columns(intColumn).ColumnName.ToString
                End If
                'Else
                xlWorkSheet.Cells(i + 2, j + 1) = DataGridView1(j, i).Value.ToString()
                'End If
            Next
        Next

        xlWorkSheet.SaveAs(FileName)
        xlWorkBook.Close()
        xlApp.Quit()
        DA.Dispose()
        Exit Sub
        Me.Close()
    End Sub

    Private Sub ShowdetentionListByConfirm(ByVal ImportExport As InOut)
        dFrom = Me.MoveDateFrom.DateValue
        dTo = Me.MoveDateTo.DateValue
        dTo = DateAdd(DateInterval.Minute, 1434, dTo)
        Dim lResult As Boolean
        Dim Err As New System.Data.DataTable
        Dim Frm As FrmRaiseError
        Me.GridResult.DataSource = Nothing

        Me.Cursor = Cursors.WaitCursor
        ' Changed from ModulGetData.DetentionListByConfirmDate to DetentionListByConfirmDateExport
        ModulGetData.DetentionListByConfirmDateExport(ImportExport, CurrentShippingLine, dFrom, dTo, TbShowdetList, lResult)
        Me.Cursor = Cursors.Default

        If Err.Rows.Count > 0 Then
            ' MsgBox("Some Containers Have Error !" & vbCr & "Plesae Check List Of Errors ", MsgBoxStyle.Critical)
            'Frm = New FrmRaiseError(Err)
        End If

        If lResult = True Then

            Try
                TbShowdetList.Columns.Remove(TB.Columns("BLID"))
                TbShowdetList.Columns.Remove(TB.Columns("CnSize"))
            Catch ex As Exception

            End Try

            Me.GridResult.DataSource = TbShowdetList.Copy
            With Me.GridResult.DisplayLayout.Bands(0)
                .HeaderVisible = True
                .Header.Activated = True
                If ImportExport = InOut.InWard Then
                    .Header.Caption = "Detention List By Received Amount From:" & Format(dFrom, "Short date") & "  To:" & Format(dTo, "Short date") & " (Inward)"
                Else
                    .Header.Caption = "Detention List By Received Amount From:" & Format(dFrom, "Short date") & "  To:" & Format(dTo, "Short date") & " (Outward)"
                    '.Columns("EA").Header.Caption = "FL Date"
                    '.Columns("DF").Header.Caption = "ES Date"
                End If
                .Header.Appearance.BackColor = Color.Maroon
                .Header.Appearance.ForeColor = Color.Yellow
                .Header.Appearance.FontData.Name = "Verdana"
                .Header.Appearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.True
                .Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                .Header.Appearance.FontData.SizeInPoints = 8
            End With
            'Me.UltraTabControl1.Tabs(1).Selected = True
            GridNumSeperator(Me.GridResult)
        Else
            MsgBox("No Data !")
        End If


    End Sub
    'New
    Private Sub GenerateDetention()

        Dim Sum As CLOutwardBlsSummary
        Dim Dtn As New CLDetention
        Dim BLID As Guid
        Dim ds As New DataSet
        Dim Report As RptOutwardDetention
        Dim Frm As New FrmGeneralReportShow
        Dim PH As New CLPrintHdr
        Dim Dscnt As TB_OutwardDiscount
        Dim sDscnt As String = ""
        Dim Col As DataColumn
        Dim DrExpPaid As DataRow
        TBlPaidDet.Dispose()
        TBlPaidDet.Clear()
        With TBlPaidDet
            If (tblDetPaidCreated = False) Then
                .Columns.Add(New DataColumn("B/L Number", System.Type.GetType("System.String")))
                .Columns.Add(New DataColumn("B/L Issuance Date", System.Type.GetType("System.DateTime")))
                .Columns.Add(New DataColumn("Release Code", System.Type.GetType("System.String")))
                .Columns.Add(New DataColumn("Remarks", System.Type.GetType("System.String")))
                .Columns.Add(New DataColumn("Client", System.Type.GetType("System.String")))
                .Columns.Add(New DataColumn("Shipper", System.Type.GetType("System.String")))
                .Columns.Add(New DataColumn("Vessel/Voyage", System.Type.GetType("System.String")))
                .Columns.Add(New DataColumn("Sailing Date", System.Type.GetType("System.DateTime")))
                .Columns.Add(New DataColumn("Detention", System.Type.GetType("System.Double")))
                .Columns.Add(New DataColumn("Total Collection", System.Type.GetType("System.Double")))
                tblDetPaidCreated = True
            End If
        End With
        ExportDetention()
        For Each drExp As DataRow In TBDetExp.Rows
            ds = StoredProcedures.SP_OutwardBlsByLineBlNo(CurrentShippingLine, drExp("BlNo").ToString().Trim)

            If ds.Tables(0).Rows.Count = 0 Then
                MsgBoxGeneral("No valid B/L No ?", "Data Requird")
                Exit Sub
            End If
            Sum = New CLOutwardBlsSummary(ds.Tables(0).Rows(0).Item("Id"))

            BLID = ds.Tables(0).Rows(0).Item("ID")
            Dtn.GenerateExportDetention(BLID)
            ds = CalExpDetention(drExp("BlNo").ToString().Trim, BLID)

            Dm.QueryCriteria.Clear()
            Dm.QueryCriteria.And(JoinPath.TB_OutwardDiscount.Columns.BLID, BLID, MatchType.Exact)
            Dscnt = Dm.GetTB_OutwardDiscount()
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
                sDscnt = IIf(sDscnt = "", "", "DISCOUNT DETAILS :") & sDscnt
            End If
            Dm.QueryCriteria.Clear()
            'Dm.QueryCriteria.And(JoinPath.TB_Clients.Columns.ID, Bl.ClientID, MatchType.Exact)
            'Clnt = Dm.GetTB_Clients

            Col = New DataColumn("dscnt", System.Type.GetType("System.String"))
            Col.DefaultValue = sDscnt
            ds.Tables(1).Columns.Add(Col)

            Col = New DataColumn("TEL", System.Type.GetType("System.String"))
            Col.DefaultValue = ""
            ds.Tables(0).Columns.Add(Col)

            Col = New DataColumn("FAX", System.Type.GetType("System.String"))
            Col.DefaultValue = ""
            ds.Tables(0).Columns.Add(Col)

            Col = New DataColumn("EMAIL", System.Type.GetType("System.String"))
            Col.DefaultValue = ""
            ds.Tables(0).Columns.Add(Col)

            Col = New DataColumn("Reference", System.Type.GetType("System.Int64"))
            Col.DefaultValue = 0
            ds.Tables(0).Columns.Add(Col)


            Col = New DataColumn("Paid", System.Type.GetType("System.Int64"))
            Col.DefaultValue = 0
            ds.Tables(1).Columns.Add(Col)
            For Each dr As DataRow In ds.Tables(1).Rows
                If NullToValue(ds.Tables(0).Rows(0).Item("Paid"), 0) > 0 Then
                    dr("Paid") = NullToValue(ds.Tables(0).Rows(0).Item("Paid"), 0) + ds.Tables(1).Rows(0).Item("Tax")
                Else
                    dr("Paid") = NullToValue(ds.Tables(0).Rows(0).Item("Paid"), 0)
                End If


            Next

            'If Dtn.IsCalculateByError = True Then
            '    MsgBox("Some Container Calculate Failed !")
            'End If
            For Each dr As DataRow In ds.Tables(1).Rows
                dr("Dscnt") = sDscnt
            Next
            Dim paid As New Double
            DrExpPaid = TBlPaidDet.NewRow
            DrExpPaid("B/L Number") = drExp("BlNo")
            DrExpPaid("B/L Issuance Date") = CDate(DateTime.Parse(drExp("IssueDate").ToString(), Globalization.CultureInfo.CreateSpecificCulture("en-CA").DateTimeFormat))
            DrExpPaid("Release Code") = drExp("ReleaseCode")
            DrExpPaid("Remarks") = drExp("Remarks")
            DrExpPaid("Client") = drExp("Client")
            DrExpPaid("Shipper") = drExp("Shipper")
            DrExpPaid("Vessel/Voyage") = drExp("VesselVoyage")
            DrExpPaid("Sailing Date") = CDate(DateTime.Parse(drExp("SailingDate").ToString(), Globalization.CultureInfo.CreateSpecificCulture("en-CA").DateTimeFormat))
            DrExpPaid("Detention") = NullToValue(ds.Tables(0).Rows(0).Item("Detention"), 0)
            paid = (NullToValue(ds.Tables(0).Rows(0).Item("Detention"), 0) - (NullToValue(ds.Tables(0).Rows(0).Item("Discount"), 0) + NullToValue(ds.Tables(0).Rows(0).Item("Balance"), 0))) 'NullToValue(ds.Tables(0).Rows(0).Item("Paid"), 0) ' )
            If (paid = 0 Or paid < 0) Then
                DrExpPaid("Total Collection") = NullToValue(ds.Tables(0).Rows(0).Item("Detention"), 0)
            Else
                DrExpPaid("Total Collection") = paid
            End If
            TBlPaidDet.Rows.Add(DrExpPaid)


        Next
        'Me.Cursor = Cursors.Default
        Me.GridSummary.DataSource = TBlPaidDet
        With Me.GridSummary.DisplayLayout.Bands(0)
            .HeaderVisible = True
            .Header.Activated = True
            .Header.Caption = "Export Detention Report:" & dFrom & "  To:" & dFrom
            .Header.Appearance.BackColor = Color.Maroon
            .Header.Appearance.ForeColor = Color.Yellow
            .Header.Appearance.FontData.Name = "Verdana"
            .Header.Appearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.True
            .Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
            .Header.Appearance.FontData.SizeInPoints = 8
        End With
        Me.Cursor = Cursors.Default
        GridNumSeperator(Me.GridSummary)
    End Sub

    Public Function CalExpDetention(ByVal BLNO As String, ByVal BID As Guid, Optional ByVal ForLine As Boolean = False) As DataSet

        Dim Ds As New DataSet
        Dim DPC As New ClDetentionPerCntr
        Dim Row As DataRow
        Dim Temp As System.Data.DataTable
        Dim Dr As DataRow
        Dim Drs() As DataRow
        Dim sCntrs As String = ""
        Dim DT As Date
        Dim Cmd As SqlClient.SqlCommand
        Dim tempTB As System.Data.DataTable
        Dim Base As New CLCalculationBase

        If ForLine = False Then
            Ds = StoredProcedures.SP_DetentionExpGnrlReportByLineBL(CurrentShippingLine, BLNO)
        Else
            Ds = StoredProcedures.SP_DetentionExpGnrlReportByLineBLForLine(CurrentShippingLine, BLNO)
        End If

        lHasError = False
        Ds.Tables(1).Columns.Add(New DataColumn("DiscountCntr", System.Type.GetType("System.Int64")))

        For Each Row In Ds.Tables(1).Rows

            If IsDBNull(Row("DF")) Then
                Row.RowError = "Please Check MS Date & FL Date"
                lHasError = True
            Else

                Temp = DPC.DetentionPerCntr("E", Row("CnSize"), Row("Cntype"), Row("DF"), _
                                           NullToValue(Row("EA"), Now()), Row("ID").ToString, _
                                            Int16.Parse(Row("LCLCount").ToString), Row("LCLWgtPercent"), Row("CntrNo"))
                Drs = Temp.Select("CntrNo = '" & Row("CntrNo") & "'")
                Row("FreeDays") = Drs(0).Item("OriginFreedays")
                Row("Days") = IIf(Drs(0).Item("TotalDays") < 1, 0, Drs(0).Item("TotalDays"))
                Row("Detention") = Drs(0).Item("Detention")
                Row("DiscountCntr") = Drs(0).Item("Discount")
            End If
        Next

        nFistPaid = NullToValue(Ds.Tables(0).Rows(0).Item("FirstPaid"), 0)
        nPaid = NullToValue(Ds.Tables(0).Rows(0).Item("Paid"), 0)
        TotalDetention = DPC.GetTotaldetention
        Ds.Tables(0).Rows(0).Item("Detention") = DPC.GetTotaldetention
        Ds.Tables(0).Rows(0).Item("Discount") = DPC.GetTotalDiscount
        Ds.Tables(0).Rows(0).Item("Balance") = DPC.GetTotaldetention - (DPC.GetTotalDiscount + nFistPaid + nPaid)

        nBalance = DPC.GetTotaldetention - (DPC.GetTotalDiscount + nFistPaid + nPaid)
        nTotalDiscount = DPC.GetTotalDiscount
        nTotaldetention = DPC.GetTotaldetention
        nTotalDamageCost = DPC.GetDamageCost

        OutwardCntrsCount(BID, sCntrs)
        Ds.Tables(0).Rows(0).Item("Totalcntrs") = sCntrs

        Dr = Ds.Tables(0).Rows(0)
        For Each Row In Ds.Tables(1).Rows
            Row("FirstPaid") = NullToValue(Dr("FirstPaid"), 0)
            Row("Discount") = DPC.GetTotalDiscount
        Next


        If TotalDetention > 0 Then


            Dim sSql As String = "Select * , isnull(Remarks,0) as Tax  From TB_DetentionBase Where @Date Between  Applydate and Validity and ImpExp = 'I'"
            Dim Cnn As New SqlClient.SqlConnection(My.Settings.DSN)
            Dim adapter2 As SqlClient.SqlDataAdapter
            Dim Parm As New SqlClient.SqlParameter("@Date", SqlDbType.DateTime)

            Drs = Ds.Tables(1).Select("FreeDays > 0", "DF DESC")
            DT = Drs(0).Item("DF")
            DT = DT.Date
            Base.GetTaxDutyDyDate(DT)
            nTax = Base.Tax + Base.Duty
            If nTax > 0 Then
                If TotalDetention - nTotalDiscount > 0 Then
                    nTaxAmount = ((TotalDetention - nTotalDiscount) * nTax) / 100
                End If
            End If
        End If

        Ds.Tables(1).Columns.Add(New DataColumn("TAX", System.Type.GetType("System.Int64")))
        For Each Dr In Ds.Tables(1).Rows
            Dr("Tax") = TaxAmount
        Next

        Ds.Tables(0).Columns.Add(New DataColumn("AccountDetails", System.Type.GetType("System.String")))
        Ds.Tables(0).Rows(0).Item("AccountDetails") = CurrentCompany.CompanyAccount

        Return Ds

    End Function

    Public Function DetentionPerCntr(ByVal ImportExport As String, _
                                              ByVal CnSize As String, _
                                              ByVal CnType As String, _
                                              ByVal dFrom As DateTime, _
                                              ByVal dTo As DateTime, _
                                              ByVal BLID As String, ByVal LCLCount As Int16, ByVal WGTPercent As Double, Optional ByVal CntrNo As String = "na")

        Dim DtnTable As New System.Data.DataTable
        Dim Table As New System.Data.DataTable
        Dim adapter As New SqlDataAdapter
        Dim adapter2 As New SqlDataAdapter
        Dim dr As DataRow
        Dim nFrreDaysNoDiscount As Int16 = 0
        Dim TotalCntrs As Long

        Dim Msg As String = ""
        Dim sSql As String

        Dim FreeDays As Long
        Dim Totaldays As Long
        Dim TotalAmt As Long
        Dim Amount As Long
        Dim detentionNet As Long
        Dim AmountDiscount As Long
        Dim ds As New DataSet
        Dim OriginFreedays As Long
        Dim DSCNT As New System.Data.DataTable

        Dim DummyBoolean As Boolean
        Dim DetentionID As Guid
        Dim lResult As Boolean

        Dim DA As New SqlDataAdapter

        If lIsMasterBL = True Then
            WGTPercent = 100
            LCLCount = 1
        End If

        dFrom = dFrom.Date
        dTo = dTo.Date

        ResultTable.Clear()
        ResultTable.AcceptChanges()

        If ImportExport = "I" Then
            sSql = "Select Count(*) as TotalCntrs From Tb_InwardCntrs Where BLID = @BLID"
        Else
            sSql = "Select Count(*) As TotalCntrs From  Tb_OutwardCntrs Where BLID = @BLID"
        End If

        Cmd = New SqlCommand(sSql, Cnn)
        Cmd.Parameters.AddWithValue("@BLID", BLID)
        adapter2 = New SqlDataAdapter(Cmd)
        adapter2.Fill(Table)
        TotalCntrs = NullToValue(Table.Rows(0).Item(0), 1)

        Table = New System.Data.DataTable

        If ImportExport = "I" Then
            sSql = "Select * From TB_InwardDiscount Where BLID = @BLID"
        Else
            sSql = "Select * From TB_OutwardDiscount Where BLID = @BLID"
        End If

        Cmd = New SqlCommand(sSql, Cnn)
        Cmd.Parameters.AddWithValue("@BLID", BLID)
        adapter2 = New SqlDataAdapter(Cmd)
        adapter2.Fill(Table)

        If Table.Rows.Count > 0 Then
            If NullToValue(Table.Rows(0).Item("IsFDaysAsDiscount"), True) = False Then
                If Table.Rows(0).Item("dFreeDays") > 0 Then
                    nFrreDaysNoDiscount = Table.Rows(0).Item("dFreeDays")

                End If
            End If
            DetentionID = NullToValue(Table.Rows(0).Item("DetentionID"), Guid.Empty)
        End If

        If IsBlSetFromOutSide = False Then
            SetBlMasterChild(BLID)
        End If


        If CurrentCompany.DetentionBySlab = True Then
            If DetentionID = Guid.Empty Then
                Cnn.Open()
                Cmd = New SqlCommand("SP_DetentionDetailByAll")
                With Cmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = Cnn
                    .Parameters.AddWithValue("@ImportExport", ImportExport)
                    .Parameters.AddWithValue("@Date", dFrom.Date)
                    .Parameters.AddWithValue("@CnType", CnType)
                    .Parameters.AddWithValue("@Line", CurrentShippingLine)

                End With
                DA.SelectCommand = Cmd
                DA.Fill(ds)

                'ds = StoredProcedures.SP_DetentionDetailByAll((ImportExport, dFrom.Date, CnType, "LSL")
                DtnTable = ds.Tables(0)
            Else
                TableBySql("SP_DetentionDetailIDCnType '" & DetentionID.ToString & "' , '" & CnType & "'", DtnTable, lResult)
            End If

            Cnn.Close()

            Totaldays = DateDiff(DateInterval.Day, dFrom, dTo) + 1
            If DtnTable.Rows.Count > 0 Then
                If nFrreDaysNoDiscount > 0 Then
                    FreeDays = nFrreDaysNoDiscount
                Else
                    FreeDays = Long.Parse(DtnTable.Rows(0).Item("DayTo").ToString)
                End If
                OriginFreedays = FreeDays
                For Each dr In DtnTable.Rows
                    Select Case CnSize
                        Case "20"
                            Amount = Long.Parse(dr("Amount20").ToString)
                        Case "40"
                            Amount = Long.Parse(dr("Amount40").ToString)
                        Case "45"
                            Amount = Long.Parse(dr("Amount45").ToString)
                    End Select

                    If Totaldays > 0 Then
                        If Totaldays > (Long.Parse(dr("DayTo").ToString) - Long.Parse(dr("DayFrom").ToString) + 1) Then
                            TotalAmt += ((Long.Parse(dr("DayTo").ToString) - Long.Parse(dr("DayFrom").ToString)) + 1) * Amount
                            Totaldays -= ((Long.Parse(dr("DayTo").ToString) - Long.Parse(dr("DayFrom").ToString)) + 1)
                            If Totaldays < 1 Then
                                Totaldays = 0
                            End If
                        Else
                            TotalAmt += (Totaldays * Amount)
                            Totaldays = 0
                            Exit For
                        End If
                    End If
                Next
                Msg = ""
            Else
                Msg = "No Valid Rate For CnType " & CnType
            End If

            If IsChaildBL = True Then
                TotalAmt = 0
            End If
            If TotalAmt < 1 Then
                TotalAmt = 0
            End If

            If TotalAmt > 0 Then

                If Table.Rows.Count > 0 Then
                    If Long.Parse(Table.Rows(0).Item("dFreeDays").ToString) > 0 Then
                        FreeDays = Long.Parse(Table.Rows(0).Item("dFreeDays").ToString)
                        Totaldays = Long.Parse(Table.Rows(0).Item("dFreeDays").ToString)
                        For Each dr In DtnTable.Rows
                            Select Case CnSize
                                Case "20"
                                    Amount = Long.Parse(dr("Amount20").ToString)
                                Case "40"
                                    Amount = Long.Parse(dr("Amount40").ToString)
                                Case "45"
                                    Amount = Long.Parse(dr("Amount45").ToString)
                            End Select
                            If Totaldays > 0 Then
                                If Totaldays > (Long.Parse(dr("DayTo").ToString) - Long.Parse(dr("DayFrom").ToString) + 1) Then
                                    AmountDiscount += ((Long.Parse(dr("DayTo").ToString) - Long.Parse(dr("DayFrom").ToString)) + 1) * Amount
                                    Totaldays -= ((Long.Parse(dr("DayTo").ToString) - Long.Parse(dr("DayFrom").ToString)) + 1)
                                    If Totaldays < 1 Then
                                        Totaldays = 0
                                    End If
                                Else
                                    AmountDiscount += (Totaldays * Amount)
                                    Totaldays = 0
                                    Exit For
                                End If
                            End If
                        Next
                    End If

                    If AmountDiscount > 0 Then
                        If NullToValue(Table.Rows(0).Item("IsFDaysAsDiscount"), True) = False Then
                            TotalAmt -= AmountDiscount
                            AmountDiscount = 0
                            If TotalAmt < 1 Then
                                TotalAmt = 0
                            End If
                        End If
                    End If

                    If AmountDiscount > TotalAmt Then
                        AmountDiscount = TotalAmt
                    End If

                    Try
                        AmountDiscount += (Long.Parse(Table.Rows(0).Item("dAmount").ToString) / TotalCntrs)
                    Catch ex As Exception
                        'Msg += " " & Left(ex.ToString, 100)
                    End Try

                    If Not IsDBNull(Table.Rows(0).Item("dPercent")) Then
                        If Long.Parse(Table.Rows(0).Item("dPercent").ToString) > 0 Then
                            Try
                                AmountDiscount += Long.Parse((TotalAmt * Long.Parse(Table.Rows(0).Item("dPercent").ToString)) / 100)
                            Catch ex As Exception
                                'Msg += " " & Left(ex.ToString, 100)
                            End Try
                        End If
                    End If
                End If
            End If

            Totaldays = DateDiff(DateInterval.Day, dFrom, dTo) + 1

            detentionNet = TotalAmt - AmountDiscount

            dr = ResultTable.NewRow
            dr("CntrNo") = CntrNo
            dr("FreeDays") = FreeDays
            dr("TotalDays") = Totaldays
            If LCLCount = 0 Then
                LCLCount = 1
            End If
            If Not lIsChaildBL = True Then
                If LCLCount > 1 And WGTPercent <> 0 Then
                    dr("Detention") = Int((TotalAmt * WGTPercent) / 100) '  Int(TotalAmt / LCLCount)
                    dr("Discount") = Int((AmountDiscount * WGTPercent) / 100)   ' Int(AmountDiscount / LCLCount)
                    dr("DiscountCntr") = Int((AmountDiscount * WGTPercent) / 100)   ' Int(AmountDiscount / LCLCount)
                    dr("DetentionNet") = Int((detentionNet * WGTPercent) / 100)  ' Int(detentionNet / LCLCount)
                Else
                    dr("Detention") = Int(TotalAmt / LCLCount)
                    dr("Discount") = Int(AmountDiscount / LCLCount)
                    dr("DiscountCntr") = Int(AmountDiscount / LCLCount)
                    dr("DetentionNet") = Int(detentionNet / LCLCount)
                End If
            Else
                dr("Detention") = 0
                dr("Discount") = 0
                dr("DiscountCntr") = 0
                dr("DetentionNet") = 0
            End If
            dr("Message") = Msg
            If Table.Rows.Count > 0 Then
                If NullToValue(Table.Rows(0).Item("IsFDaysAsDiscount"), True) = True Then
                    dr("OriginFreedays") = OriginFreedays
                Else
                    If NullToValue(Table.Rows(0).Item("dFreeDays"), 0) > 0 Then
                        dr("OriginFreedays") = nFrreDaysNoDiscount
                    Else
                        dr("OriginFreedays") = OriginFreedays
                    End If
                End If
            Else
                dr("OriginFreedays") = OriginFreedays
            End If
            TotalDetantion += Int((TotalAmt * WGTPercent) / 100) '   Int(TotalAmt / LCLCount)
            TotalDiscount += Int((AmountDiscount * WGTPercent) / 100)  ' Int(AmountDiscount / LCLCount)
            ResultTable.Rows.Add(dr)
            Return ResultTable
        Else
            ds = StoredProcedures.SP_DetentionDetailByAll(ImportExport, dFrom.Date, CnType, CurrentShippingLine)
            DtnTable = ds.Tables(0)
            Totaldays = DateDiff(DateInterval.Day, dFrom, dTo) + 1

            If DtnTable.Rows.Count > 0 Then
                FreeDays = Long.Parse(DtnTable.Rows(0).Item("DayTo").ToString)
                If nFrreDaysNoDiscount > 0 Then
                    Totaldays -= (nFrreDaysNoDiscount - FreeDays)
                End If
                OriginFreedays = FreeDays
                For Each dr In DtnTable.Rows
                    Select Case CnSize
                        Case "20"
                            Amount = Long.Parse(dr("Amount20").ToString)
                        Case "40"
                            Amount = Long.Parse(dr("Amount40").ToString)
                        Case "45"
                            Amount = Long.Parse(dr("Amount45").ToString)
                    End Select

                    If Totaldays > 0 Then
                        If Totaldays > (Long.Parse(dr("DayTo").ToString) - Long.Parse(dr("DayFrom").ToString) + 1) Then
                            TotalAmt += ((Long.Parse(dr("DayTo").ToString) - Long.Parse(dr("DayFrom").ToString)) + 1) * Amount
                            Totaldays -= ((Long.Parse(dr("DayTo").ToString) - Long.Parse(dr("DayFrom").ToString)) + 1)
                            If Totaldays < 1 Then
                                Totaldays = 0
                            End If
                        Else
                            TotalAmt += (Totaldays * Amount)
                            Totaldays = 0
                            Exit For
                        End If
                    End If
                Next
                Msg = ""
            Else
                Msg = "No Valid Rate For CnType " & CnType
            End If

            If TotalAmt < 1 Then
                TotalAmt = 0
            End If

            If TotalAmt > 0 Then

                If Table.Rows.Count > 0 Then
                    If Long.Parse(Table.Rows(0).Item("dFreeDays").ToString) > 0 Then

                        FreeDays = Long.Parse(Table.Rows(0).Item("dFreeDays").ToString)
                        ' Totaldays = DateDiff(DateInterval.Day, dFrom, dTo) + 1
                        Totaldays -= (Table.Rows(0).Item("dFreeDays") - DtnTable.Rows(0).Item("DayTo"))
                        For Each dr In DtnTable.Rows
                            Select Case CnSize
                                Case "20"
                                    Amount = Long.Parse(dr("Amount20").ToString)
                                Case "40"
                                    Amount = Long.Parse(dr("Amount40").ToString)
                                Case "45"
                                    Amount = Long.Parse(dr("Amount45").ToString)
                            End Select
                            If Totaldays > 0 Then
                                If Totaldays > (Long.Parse(dr("DayTo").ToString) - Long.Parse(dr("DayFrom").ToString) + 1) Then
                                    AmountDiscount += ((Long.Parse(dr("DayTo").ToString) - Long.Parse(dr("DayFrom").ToString)) + 1) * Amount
                                    Totaldays -= ((Long.Parse(dr("DayTo").ToString) - Long.Parse(dr("DayFrom").ToString)) + 1)
                                    If Totaldays < 1 Then
                                        Totaldays = 0
                                    End If
                                Else
                                    AmountDiscount += (Totaldays * Amount)
                                    Totaldays = 0
                                    Exit For
                                End If
                            End If
                        Next
                        If AmountDiscount = 0 Then
                            AmountDiscount = TotalAmt
                        End If
                    End If

                    If AmountDiscount > 0 Then
                        Try
                            DummyBoolean = Boolean.Parse(Table.Rows(0).Item("IsFDaysAsDiscount").ToString)

                        Catch ex As Exception
                            DummyBoolean = False
                        End Try
                        If DummyBoolean = True Then
                            '       AmountDiscount = TotalAmt - AmountDiscount
                        Else
                            '    TotalAmt = (TotalAmt - AmountDiscount)
                            AmountDiscount = 0
                            If TotalAmt < 1 Then
                                TotalAmt = 0
                            End If
                        End If
                    End If

                    If AmountDiscount > TotalAmt Then
                        AmountDiscount = TotalAmt
                    End If

                    Try
                        AmountDiscount += (Long.Parse(Table.Rows(0).Item("dAmount").ToString) / TotalCntrs)
                    Catch ex As Exception
                        'Msg += " " & Left(ex.ToString, 100)
                    End Try

                    If Not IsDBNull(Table.Rows(0).Item("dPercent")) Then
                        If Long.Parse(Table.Rows(0).Item("dPercent").ToString) > 0 Then
                            Try
                                AmountDiscount += Long.Parse((TotalAmt * Long.Parse(Table.Rows(0).Item("dPercent").ToString)) / 100)
                            Catch ex As Exception
                                'Msg += " " & Left(ex.ToString, 100)
                            End Try
                        End If
                    End If
                End If
            End If


            Totaldays = DateDiff(DateInterval.Day, dFrom, dTo) + 1

            detentionNet = TotalAmt - AmountDiscount

            dr = ResultTable.NewRow
            dr("CntrNo") = CntrNo
            dr("FreeDays") = FreeDays
            dr("TotalDays") = Totaldays

            If Not lIsChaildBL Then
                If LCLCount > 0 And WGTPercent <> 0 Then
                    dr("Detention") = Int((TotalAmt * WGTPercent) / 100) '  Int(TotalAmt / LCLCount)
                    dr("Discount") = Int((AmountDiscount * WGTPercent) / 100)   ' Int(AmountDiscount / LCLCount)
                    dr("DiscountCntr") = Int((AmountDiscount * WGTPercent) / 100)   ' Int(AmountDiscount / LCLCount)
                    dr("DetentionNet") = Int((detentionNet * WGTPercent) / 100)  ' Int(detentionNet / LCLCount)
                Else
                    dr("Detention") = Int(TotalAmt / LCLCount)
                    dr("Discount") = Int(AmountDiscount / LCLCount)
                    dr("DiscountCntr") = Int(AmountDiscount / LCLCount)
                    dr("DetentionNet") = Int(detentionNet / LCLCount)
                End If
            Else
                dr("Detention") = 0
                dr("Discount") = 0
                dr("DiscountCntr") = 0
                dr("DetentionNet") = 0
            End If

            'dr("Detention") = Int(TotalAmt / LCLCount)  ' Int(TotalAmt / LCLCount)
            'dr("Discount") = Int((AmountDiscount * WGTPercent) / 100) ' Int(AmountDiscount / LCLCount)
            'dr("DetentionNet") = Int((detentionNet * WGTPercent) / 100) ' Int(detentionNet / LCLCount)
            dr("Message") = Msg
            If Table.Rows.Count > 0 Then
                If NullToValue(Table.Rows(0).Item("IsFDaysAsDiscount"), True) = True Then
                    dr("OriginFreedays") = OriginFreedays
                Else
                    dr("OriginFreedays") = nFrreDaysNoDiscount
                End If
            Else
                dr("OriginFreedays") = OriginFreedays
            End If

            TotalDetantion += Int((TotalAmt * WGTPercent) / 100)  ' Int(TotalAmt / LCLCount)
            TotalDiscount += Int(AmountDiscount * WGTPercent / 100) ' Int(AmountDiscount / LCLCount)
            ResultTable.Rows.Add(dr)
            Return ResultTable

        End If

    End Function

    Private Sub SetBlMasterChild(ByVal BLID As String)

        Dim Tb As New System.Data.DataTable
        Dim lResult As Boolean
        Dim BLNo As String
        Dim Line As String

        TableBySql("Select Line , BLNO , isnull(FrtCoverdBlNo,'') as Coverd From Tb_InwardBls where ID = '" & BLID.ToString & "'", Tb, lResult)

        If Tb.Rows.Count > 0 Then
            Line = Tb.Rows(0).Item("Line")
            BLNo = Tb.Rows(0).Item("BLNO")
            If Tb.Rows(0).Item("Coverd") = "" Then
                IsChaildBL = False
            Else
                IsChaildBL = True
            End If
        End If

        Tb = New System.Data.DataTable
        TableBySql("Select BLNO , isnull(FrtCoverdBlNo,'') as Coverd From Tb_InwardBls where FrtCoverdBlNo = '" & BLNo & "' and Line = '" & Line & "'", Tb, lResult)
        If Tb.Rows.Count > 0 Then
            lIsMasterBL = True
        Else
            lIsMasterBL = False
        End If


    End Sub

    'End New

End Class
