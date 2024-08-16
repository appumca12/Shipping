Imports OrmLib
Imports ShippingBiz
Imports Infragistics.Shared
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinEditors
Imports System.Data.SqlClient

Public Class FrmAccGnrlReport

    Private customColumnChooserDialog As CustomColumnChooser = Nothing
    ' git to rubi
    Private Sub FrmAccGnrlReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.DateFrom.InitControl(False, False)
        Me.DateTo.InitControl(False, False)
        Me.FVoyage.InitControl(Me.BackColor, Me.FVessel)
        Me.FVessel.InitControl(Me.BackColor)
        Me.DateFrom.GnrlDate.Value = Now
        Me.DateTo.GnrlDate.Value = Now
        Me.Clients.InitControl()

        For Each Ctrl As Control In LayoutPanel.Controls
            Ctrl.Visible = False
        Next

        Me.FromLabel.Visible = True
        Me.ToLabel.Visible = True
        Me.DateFrom.Visible = True
        Me.DateTo.Visible = True


    End Sub

    Private Sub ShowDcr()

        Dim Rpt As New RptDCR
        Dim Ds As New DataSet
        Dim Invs As New DataTable
        Dim TbResult As New DataTable
        Dim PH As New CLPrintHdr

        Me.Cursor = Cursors.WaitCursor
        Ds = StoredProcedures.SP_RptCDR(Me.DateFrom.GnrlDate.Value, Me.DateTo.GnrlDate.Value)
        Me.GridResult.DataSource = TbResult
        ' Rpt.Subreports(0).SetDataSource(PH.ImageTable)
        Rpt.SetDataSource(Ds.Tables(0))
        Rpt.SetParameterValue("dFrom", Format(Me.DateFrom.GnrlDate.Value, "dd/MM/yyyy"))
        Rpt.SetParameterValue("dTo", Format(Me.DateTo.GnrlDate.Value, "dd/MM/yyyy"))
        Me.ReportViewer.ReportSource = Rpt
        Me.UltraTabControl1.Tabs(0).Selected = True
        Me.Cursor = Cursors.Default


        'Dim aChgs As New ArrayList
        'Dim aUsers As New ArrayList
        'Dim dr As DataRow

        'Dim TB As New DataTable("Detail")
        'Dim TbCurrency As New DataTable("Currency")
        'Dim TbUsesr As New DataTable("Usesr")

        'Dim Fld As String
        'Dim Drs() As DataRow
        'Dim NewRow As DataRow
        'Dim DmDrs() As DataRow
        'Dim DsDcr As New DataSet
        'Dim Rl As DataRelation
        'Dim PCol As DataColumn
        'Dim cCol As DataColumn

        'Dim PCols(2) As DataColumn
        'Dim cCols(2) As DataColumn

        'TB.Columns.Add(New DataColumn("InvoiceNo"))
        'TB.Columns.Add(New DataColumn("BLNO"))
        'TB.Columns.Add(New DataColumn("Client"))
        'TB.Columns.Add(New DataColumn("UserName"))
        'TB.Columns.Add(New DataColumn("Currency"))

        'TbUsesr.Columns.Add(New DataColumn("UserName"))

        'TbCurrency.Columns.Add(New DataColumn("UserName"))
        'TbCurrency.Columns.Add(New DataColumn("Currency"))

        'Drs = Ds.Tables(0).Select("", "ChargesCode")



        'For Each dr In Drs

        '    If aChgs.IndexOf(dr("ChargesCode")) = -1 Then
        '        aChgs.Add(dr("ChargesCode"))
        '        TB.Columns.Add(New DataColumn("Client"))
        '        Fld = dr("ChargesCode")
        '        TB.Columns.Add(New DataColumn(Fld, System.Type.GetType("System.Double")))
        '    End If

        '    If aUsers.IndexOf(dr("ConfirmBy")) = -1 Then
        '        NewRow = TbUsesr.NewRow
        '        NewRow("UserName") = dr("ConfirmBy")
        '        TbUsesr.Rows.Add(NewRow)
        '    End If
        '    DmDrs = TbCurrency.Select("UserName = '" & dr("ConfirmBy") & "' and Currency = '" & dr("Currency") & "'")
        '    If DmDrs.Length = 0 Then
        '        NewRow = TbCurrency.NewRow
        '        NewRow("UserName") = dr("ConfirmBy")
        '        NewRow("Currency") = dr("Currency")
        '        TbCurrency.Rows.Add(NewRow)
        '    End If
        'Next

        'For Each dr In Ds.Tables(0).Rows
        '    Drs = TB.Select("InvoiceNo = '" & dr("InvoiceNo") & "' and UserName = '" & dr("ConfirmBy") & "' and Currency = '" & dr("Currency") & "'")
        '    If Drs.Length = 0 Then
        '        Fld = dr("ChargesCode")
        '        NewRow = TB.NewRow
        '        NewRow("InvoiceNo") = dr("InvoiceNo")
        '        NewRow("BlNo") = dr("BlNo")
        '        NewRow("Client") = dr("Client")
        '        NewRow(Fld) = dr("ShowAmount")
        '        NewRow("UserName") = dr("ConfirmBy")
        '        NewRow("UserName") = dr("Currency")
        '        TB.Rows.Add(NewRow)
        '    End If
        'Next

        'Ds.Tables.Add(TbUsesr)
        'Ds.Tables.Add(TbCurrency)
        'Ds.Tables.Add(TB)


        'PCol = TbUsesr.Columns("UserName")
        'cCol = TbCurrency.Columns("UserName")

        'Rl = New DataRelation("Users", PCol, cCol)
        'DsDcr.Relations.Add(Rl)


        'PCols(0) = TbCurrency.Columns("UserName")
        'PCols(1) = TbCurrency.Columns("Currency")

        'cCols(0) = TB.Columns("UserName")
        'cCols(1) = TB.Columns("Currency")


        'Rl = New DataRelation("Users", PCols, cCols)
        'DsDcr.Relations.Add(Rl)


    End Sub

    Private Sub ExplorerBar_GroupClick(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinExplorerBar.GroupEventArgs) Handles ExplorerBar.GroupClick

        For Each Ctrl As Control In LayoutPanel.Controls
            Ctrl.Visible = False
        Next
        Select Case ExplorerBar.SelectedGroup.Key
            Case "ByDate"
                Me.FromLabel.Visible = True
                Me.ToLabel.Visible = True
                Me.DateFrom.Visible = True
                Me.DateTo.Visible = True
            Case "ByVoyage"
                Me.VslVoyLable.Visible = True
                Me.FVoyage.Visible = True
                Me.FVessel.Visible = True
            Case "ByClient"
                Me.ClientLabel.Visible = True
                Me.Clients.Visible = True
        End Select


    End Sub
    Private Sub ExplorerBar_ItemClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinExplorerBar.ItemEventArgs) Handles ExplorerBar.ItemClick

        Select Case e.Item.Key
            Case "DCR"
                ShowDcr()
            Case "Detention List (Containe Wise)"
                ShowdetentionList()
            Case "Recived Items"
                ShowRecivedItems()
            Case "Detention By Confirm Date"
                ShowdetentionListByConfirm(InOut.InWard)
            Case " Exp Detention By Confirm Date"
                ShowdetentionListByConfirm(InOut.OutWard)
            Case "Statistics"
                ShowClientStatus()
            Case "No Invoice Setel"
                ShowNoInvoiceSetel()
            Case "No D.O. Taken"
                ShowNoDoTaken()
            Case "Over Due"
                showOverDue()
            Case "VoyageSummary"
                GenVoyageSummary()
            Case "Statistics With Containers"
                ShowClientStatusWithCntrs()
            Case "FreightSummary"
                ShowFreightSummary()
            Case "No Invoice Setel (Cntr)"
                ShowNoInvoiceSetelCntr()
            Case "No D.O. Taken (Cntr)"
                ShowNoDoTakenCntr()
            Case "Over Due (Cntr)"
                showOverDueCntr()
            Case "ChargesDetails"
                GenChargesInDetails()
            Case "DCRGrid"
                ShowDcrGrid()
            Case "CompareTHC"
                ShowTHCComapre()
            Case "CollectList"
                CollectListByDate()
            Case "VoyageSumExp"
                ShowFreightSummaryOutward()
            Case "Outward THC List"
                ShowTHCList()
            Case "Inward THC List"
                ShowInTHCList()
            Case "ALL (Cntr)"
                ShowStatusAllCntr()
            Case "DemurrageControl"
                DemurrageControl()
            Case "TopClient"
                TopClientByLineDate()
            Case "SeasonReport"
                SeasonReport()
            Case "OFT RecivedItems"
                OFTRecivedItems()
            Case "TotalDeposit"
                TotalDeposit()
            Case "TopClientSummery"
                TopClientSummery()
            Case "EXPStatistics"
                ShowClientEXPStatus()
            Case "Deposit Details"
                ShowDepositDetails()
        End Select

    End Sub

    Private Sub ShowdetentionList()

        Dim Tb As New DataTable
        Dim lResult As Boolean
        Dim Err As New DataTable
        Dim Frm As FrmRaiseError
        Dim Col As DataColumn
        Me.GridResult.DataSource = Nothing
        Me.Cursor = Cursors.WaitCursor
        ModulGetData.DetentionListByEADate(CurrentShippingLine, Me.DateFrom.DateValue, Me.DateTo.DateValue, Tb, lResult)
        Me.Cursor = Cursors.Default
        If Err.Rows.Count > 0 Then
            MsgBox("Some Containers Have Error !" & vbCr & "Plesae Check List Of Errors ", MsgBoxStyle.Critical)
            Frm = New FrmRaiseError(Err)
        End If

        If lResult = True Then
            Tb.Columns.Remove(Tb.Columns("BLID"))
            Me.GridResult.DataSource = Tb.Copy
            With Me.GridResult.DisplayLayout.Bands(0)
                .HeaderVisible = True
                .Header.Activated = True
                .Header.Caption = "Detention List By MA Date:" & Format(Me.DateFrom.DateValue, "Short date") & "  To:" & Format(Me.DateTo.DateValue, "Short date")
                .Header.Appearance.BackColor = Color.Maroon
                .Header.Appearance.ForeColor = Color.Yellow
                .Header.Appearance.FontData.Name = "Verdana"
                .Header.Appearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.True
                .Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                .Header.Appearance.FontData.SizeInPoints = 8
            End With
            Me.UltraTabControl1.Tabs(1).Selected = True
            GridNumSeperator(Me.GridResult)
        End If
        Me.UltraTabControl1.Tabs(1).Selected = True

    End Sub
    Private Sub GridResult_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles GridResult.InitializeLayout
        e.Layout.Override.SupportDataErrorInfo = SupportDataErrorInfo.RowsAndCells
        e.Layout.Override.DataErrorCellAppearance.ForeColor = Color.Red
        e.Layout.Override.DataErrorRowAppearance.BackColor = Color.LightYellow
        e.Layout.Override.DataErrorRowSelectorAppearance.BackColor = Color.Green
        e.Layout.Override.RowSelectorWidth = 32
    End Sub

    Private Sub ButtonExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExcel.Click

        SaveGridToExcel(Me.GridResult)

    End Sub

    Private Sub ShowRecivedItems()

        Dim Ds As New DataSet

        Try
            Me.Cursor = Cursors.WaitCursor
            Ds = StoredProcedures.InvoiceRecivedListByDateCharge(Me.DateFrom.DateValue, Me.DateTo.DateValue)
            Me.GridResult.DataSource = Ds.Tables(0).Copy
            Me.UltraTabControl1.Tabs(1).Selected = True
            With Me.GridResult.DisplayLayout.Bands(0)
                .HeaderVisible = True
                .Header.Activated = True
                .Header.Caption = "Received Items From:" & Format(Me.DateFrom.DateValue, "Short date") & "  To:" & Format(Me.DateTo.DateValue, "Short date")
                .Header.Appearance.BackColor = Color.Maroon
                .Header.Appearance.ForeColor = Color.Yellow
                .Header.Appearance.FontData.Name = "Verdana"
                .Header.Appearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.True
                .Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                .Header.Appearance.FontData.SizeInPoints = 8
            End With
            Me.UltraTabControl1.Tabs(1).Selected = True
            GridNumSeperator(Me.GridResult)
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBoxGeneral(ex.ToString, "Error !")
        End Try
        Me.Cursor = Cursors.Default
        Me.UltraTabControl1.Tabs(1).Selected = True

    End Sub

    Private Sub ShowdetentionListByConfirm(ByVal ImportExport As InOut)

        Dim Tb As New DataTable
        Dim lResult As Boolean
        Dim Err As New DataTable
        Dim Frm As FrmRaiseError
        Me.GridResult.DataSource = Nothing

        Me.Cursor = Cursors.WaitCursor
        ModulGetData.DetentionListByConfirmDate(ImportExport, CurrentShippingLine, Me.DateFrom.DateValue, Me.DateTo.DateValue, Tb, lResult)
        Me.Cursor = Cursors.Default

        If Err.Rows.Count > 0 Then
            MsgBox("Some Containers Have Error !" & vbCr & "Plesae Check List Of Errors ", MsgBoxStyle.Critical)
            Frm = New FrmRaiseError(Err)
        End If

        If lResult = True Then

            Try
                Tb.Columns.Remove(Tb.Columns("BLID"))
                Tb.Columns.Remove(Tb.Columns("CnSize"))
            Catch ex As Exception

            End Try
          
            Me.GridResult.DataSource = Tb.Copy
            With Me.GridResult.DisplayLayout.Bands(0)
                .HeaderVisible = True
                .Header.Activated = True
                If ImportExport = InOut.InWard Then
                    .Header.Caption = "Detention List By Received Amount From:" & Format(Me.DateFrom.DateValue, "Short date") & "  To:" & Format(Me.DateTo.DateValue, "Short date") & " (Inward)"
                Else
                    .Header.Caption = "Detention List By Received Amount From:" & Format(Me.DateFrom.DateValue, "Short date") & "  To:" & Format(Me.DateTo.DateValue, "Short date") & " (Outward)"
                    .Columns("EA").Header.Caption = "FL Date"
                    .Columns("DF").Header.Caption = "ES Date"
                End If
                .Header.Appearance.BackColor = Color.Maroon
                .Header.Appearance.ForeColor = Color.Yellow
                .Header.Appearance.FontData.Name = "Verdana"
                .Header.Appearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.True
                .Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                .Header.Appearance.FontData.SizeInPoints = 8
            End With
            Me.UltraTabControl1.Tabs(1).Selected = True
            GridNumSeperator(Me.GridResult)
        Else
            MsgBox("No Data !")
        End If


    End Sub


    Private Sub ShowClientStatus()

        Dim sSql As String
        Dim Table As New DataTable
        Dim adapter As New SqlDataAdapter
        Dim Cnn As New SqlConnection(My.Settings.DSN)
        Dim Cmd As New SqlCommand
        Dim Rows() As DataRow
        Dim Dr As DataRow
        Dim Detn As CLDetention
        Dim Ds As DataSet


        Dim CalBase As New CLCalculationBase
         If Me.Clients.Text = "" Then
            MsgBox("No valid Client !")
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor
        sSql = "exec SP_InwardCleintStatus @ClientID "
        Cmd = New SqlCommand(sSql, Cnn)
        Cmd.Parameters.AddWithValue("@ClientID", Me.Clients.ClientID)
        Cmd.CommandTimeout = 3000
        adapter = New SqlDataAdapter(Cmd)

        'Try
        If Cnn.State = ConnectionState.Closed Then
            Cnn.Open()
        End If

        adapter.Fill(Table)

        If Table.Rows.Count > 0 Then
            For Each Dr In Table.Rows
                InwardCntrsCount(Dr("ID"), Dr("TotalCntrs"))
            Next
            '          Rows = Table.Select("Setelment is null")
            For Each Dr In Table.Rows
                Detn = New CLDetention
                Ds = Detn.CalDetention(Dr("BLNO"), Dr("ID"), False)
                'Detn.GenerateImportDetention(Dr("ID"), False)
                Dr("IsReturnBack") = Detn.IsCntrsReturnBack
                Dr("Discount") = Detn.TotalDiscount
                Dr("Detention") = Detn.TotalAmount



                If Detn.IsCalculateByError = True Then
                    Dr.RowError = "Calculate Wrong !"
                End If
            Next

            Table.Columns.Add(New DataColumn("Balance", System.Type.GetType("System.Double")))
            Table.Columns.Add(New DataColumn("TTL Detention", System.Type.GetType("System.Double")))


            For Each Dr In Table.Rows
                Dr("TaxBase") = NullToValue(Dr("TaxBase"), 0)
                Dr("Detention") = Dr("Detention") - Dr("Discount")
                If Dr("IsReturnBack") = True Then
                    Dr("TTL Detention") = Dr("Detention") + (Dr("Detention") * Dr("TaxBase")) / 100
                Else : Dr("TTL Detention") = NullToValue(Dr("Detention"), 0)
                End If

                If Dr("IsReturnBack") = False Or Dr("Paid") = 0 Then
                    Dr("FirstPaid") = NullToValue(Dr("FirstPaid"), 0)
                    Dr("Paid") = 0
                ElseIf Dr("Paid") + ((Dr("Paid") * Dr("TaxBase")) / 100) <> Dr("TTL Detention") Then
                    Dr("Paid") = NullToValue(Dr("Paid"), 0) + ((Dr("Paid") * Dr("TaxBase")) / 100) + ((Dr("FirstPaid") * Dr("TaxBase")) / 100)
                Else
                    Dr("Paid") += (Dr("Paid") * Dr("TaxBase")) / 100
                End If


                'If Dr("IsReturnBack") = True Then 'NullToValue(Dr("FirstPaid"), 0) > 0 Or NullToValue(Dr("Paid"), 0) > 0 Then

                ' ' by appu on 18-01-2016
                'If Dr("IsReturnBack") = False Then
                '    Dr("Balance") = NullToValue(Dr("TTL Detention"), 0)
                'ElseIf NullToValue(Dr("Deposit"), 0) - NullToValue(Dr("ReturnBackAmount"), 0) = Dr("Paid") Then
                '    Dr("Balance") = NullToValue(Dr("TTL Detention"), 0) - (NullToValue(Dr("FirstPaid"), 0) + NullToValue(Dr("Paid"), 0))
                'Else
                '    Dr("Balance") = NullToValue(Dr("TTL Detention"), 0) - (NullToValue(Dr("FirstPaid"), 0) + NullToValue(Dr("Paid"), 0)) - ((NullToValue(Dr("Deposit"), 0) - NullToValue(Dr("ReturnBackAmount"), 0)) - NullToValue(Dr("PaidDeposit"), 0)) '+ IIf(NullToValue(0 < Dr("ReturnBackAmount"), 0) < NullToValue(Dr("Deposit"), 0), NullToValue(Dr("Deposit"), 0) - NullToValue(Dr("ReturnBackAmount"), 0), NullToValue(Dr("Paid"), 0)))
                'End If
                'End comment
                ' New code by appu
                If Dr("IsReturnBack") = False Then
                    Dr("Balance") = Convert.ToInt32(NullToValue(Dr("TTL Detention"), 0))
                ElseIf NullToValue(Dr("Deposit"), 0) - NullToValue(Dr("ReturnBackAmount"), 0) = Dr("Paid") Then
                    Dr("Balance") = Convert.ToInt32(NullToValue(Dr("TTL Detention"), 0) - (NullToValue(Dr("FirstPaid"), 0) + NullToValue(Dr("Paid"), 0)))
                Else
                    Dr("Balance") = Convert.ToInt32(NullToValue(Dr("TTL Detention"), 0) - (NullToValue(Dr("FirstPaid"), 0) + NullToValue(Dr("Paid"), 0)) - ((NullToValue(Dr("Deposit"), 0) - NullToValue(Dr("ReturnBackAmount"), 0)) - NullToValue(Dr("PaidDeposit"), 0))) '+ IIf(NullToValue(0 < Dr("ReturnBackAmount"), 0) < NullToValue(Dr("Deposit"), 0), NullToValue(Dr("Deposit"), 0) - NullToValue(Dr("ReturnBackAmount"), 0), NullToValue(Dr("Paid"), 0)))
                End If
                'End
            Next
        End If

        Me.GridResult.DataSource = Table.Copy

        For Each Row As UltraGridRow In GridResult.Rows
            Select Case Row.Cells("Balance").Value
                Case Is > 0
                    Row.Appearance.BackColor = Color.Yellow
                Case Is < 0
                    Row.Appearance.BackColor = Color.YellowGreen
            End Select
        Next

        Me.UltraTabControl1.Tabs(1).Selected = True
        With Me.GridResult.DisplayLayout.Bands(0)
            .HeaderVisible = True
            .Header.Activated = True
            .Header.Caption = "Client Statistics For:" & Me.Clients.Text
            .Header.Appearance.BackColor = Color.Maroon
            .Header.Appearance.ForeColor = Color.Yellow
            .Header.Appearance.FontData.Name = "Verdana"
            .Header.Appearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.True
            .Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
            .Header.Appearance.FontData.SizeInPoints = 8
            .Columns("TotalCntrs").CellMultiLine = DefaultableBoolean.True
        End With
        GridNumSeperator(Me.GridResult)
        Me.Cursor = Cursors.Default

    End Sub
    Private Sub ShowClientStatusWithCntrs()

        Dim sSql As String
        Dim Table As New DataTable
        Dim adapter As New SqlDataAdapter
        Dim Cnn As New SqlConnection(My.Settings.DSN)
        Dim Cmd As New SqlCommand
        Dim Rows() As DataRow
        Dim Dr As DataRow
        Dim NewDr As DataRow
        Dim Detn As CLDetention
        Dim Ds As DataSet
        Dim TBCns As DataTable
        Dim TbResult As New DataTable("Result")
        Dim R As DataRow

        If Me.Clients.Text = "" Then
            MsgBox("No valid Client !")
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor
        sSql = "exec SP_InwardCleintStatus @ClientID "
        Cmd = New SqlCommand(sSql, Cnn)
        Cmd.Parameters.AddWithValue("@ClientID", Me.Clients.ClientID)
        adapter = New SqlDataAdapter(Cmd)

        Try
            If Cnn.State = ConnectionState.Closed Then
                Cnn.Open()
            End If

            adapter.Fill(Table)
            If Table.Rows.Count > 0 Then
                For Each Dr In Table.Rows
                    InwardCntrsCount(Dr("ID"), Dr("TotalCntrs"))
                Next
                '         Rows = Table.Select("Setelment is null")
                For Each Dr In Table.Rows

                    Detn = New CLDetention
                    Ds = Detn.CalDetention(Dr("BLNO"), Dr("ID"), False)
                    'Detn.GenerateImportDetention(Dr("ID"), False)
                    Dr("IsReturnBack") = Detn.IsCntrsReturnBack
                    Dr("Detention") = Detn.TotalAmount
                    If Detn.IsCalculateByError = True Then
                        Dr.RowError = "Calculate Wrong !"
                    End If
                    Try
                        If TBCns Is Nothing Then
                            TBCns = Ds.Tables(1).Copy
                        Else
                            TBCns.Merge(Ds.Tables(1).Copy)
                        End If
                    Catch ex As Exception

                    End Try
                Next
            End If

            TbResult.Columns.Add(New DataColumn("BLNO"))
            TbResult.Columns.Add(New DataColumn("CntrNo"))
            TbResult.Columns.Add(New DataColumn("Voyage"))
            TbResult.Columns.Add(New DataColumn("Vessel"))
            TbResult.Columns.Add(New DataColumn("CnSize"))
            TbResult.Columns.Add(New DataColumn("CnType"))
            TbResult.Columns.Add(New DataColumn("SOC"))
            TbResult.Columns.Add(New DataColumn("DF", System.Type.GetType("System.DateTime")))
            TbResult.Columns.Add(New DataColumn("EA", System.Type.GetType("System.DateTime")))
            TbResult.Columns.Add(New DataColumn("Days", System.Type.GetType("System.Int16")))
            TbResult.Columns.Add(New DataColumn("FreeDays", System.Type.GetType("System.Int64")))
            TbResult.Columns.Add(New DataColumn("Discount", System.Type.GetType("System.Int64")))
            TbResult.Columns.Add(New DataColumn("Detention", System.Type.GetType("System.Int64")))
            TbResult.Columns.Add(New DataColumn("Setelment", System.Type.GetType("System.DateTime")))
            TbResult.Columns.Add(New DataColumn("LCLCount", System.Type.GetType("System.Int16")))

            Table.TableName = "Master"
            TBCns.TableName = "Cntrs"

            For Each Dr In Table.Rows
                Rows = TBCns.Select("ID = '" & Dr("ID").ToString & "'")
                For Each R In Rows
                    NewDr = TbResult.NewRow
                    NewDr("BLNO") = Dr("BLNO")
                    NewDr("CntrNo") = R("CntrNo")
                    NewDr("Voyage") = Dr("Voyage")
                    NewDr("Vessel") = Dr("Vessel")
                    NewDr("CnSize") = R("CnSize")
                    NewDr("CnType") = R("CnType")
                    NewDr("SOC") = R("SOC")
                    NewDr("DF") = R("DF")
                    NewDr("EA") = R("EA")
                    NewDr("Days") = R("Days")
                    NewDr("FreeDays") = R("FreeDays")
                    NewDr("Discount") = R("DiscountCntr")
                    NewDr("LCLCount") = R("LCLCount")
                    NewDr("Detention") = R("Detention")
                    NewDr("Setelment") = Dr("Setelment")
                    TbResult.Rows.Add(NewDr)
                Next
            Next

            TbResult.AcceptChanges()
            Me.GridResult.DataSource = TbResult

            Me.UltraTabControl1.Tabs(1).Selected = True

            With Me.GridResult.DisplayLayout.Bands(0)

                .HeaderVisible = True
                .Header.Activated = True
                .Header.Caption = "Client Statistics With Containers For:" & Me.Clients.Text
                .Header.Appearance.BackColor = Color.Maroon
                .Header.Appearance.ForeColor = Color.Yellow
                .Header.Appearance.FontData.Name = "Verdana"
                .Header.Appearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.True
                .Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                .Header.Appearance.FontData.SizeInPoints = 8
            End With

            With Me.GridResult
                .DisplayLayout.Bands(0).Layout.Override.MergedCellStyle = MergedCellStyle.OnlyWhenSorted
                .DisplayLayout.Bands(0).Layout.Override.MergedCellContentArea = MergedCellContentArea.VirtualRect
                .DisplayLayout.Bands(0).Layout.Override.HeaderClickAction = HeaderClickAction.SortMulti
                .DisplayLayout.Bands(0).Layout.Override.MergedCellAppearance.BackColor = Color.LightYellow
                .DisplayLayout.Bands(0).SortedColumns.Add("BLNO", True)
                .DisplayLayout.Bands(0).SortedColumns.Add("CNTRNO", False)
                .DisplayLayout.Bands(0).SortedColumns.Add("Vessel", True)
                .DisplayLayout.Bands(0).SortedColumns.Add("Voyage", True)

                .DisplayLayout.Bands(0).Columns("BLNO").MergedCellStyle = MergedCellStyle.Always
                .DisplayLayout.Bands(0).Columns("Vessel").MergedCellStyle = MergedCellStyle.Always
                .DisplayLayout.Bands(0).Columns("Voyage").MergedCellStyle = MergedCellStyle.Always

                .DisplayLayout.Bands(0).Columns("BLNo").CellAppearance.TextVAlign = VAlign.Middle
                .DisplayLayout.Bands(0).Columns("Vessel").CellAppearance.TextVAlign = VAlign.Middle
                .DisplayLayout.Bands(0).Columns("Voyage").CellAppearance.TextVAlign = VAlign.Middle


            End With

            GridNumSeperator(Me.GridResult)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Me.UltraTabControl1.Tabs(1).Selected = True
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub ShowNoInvoiceSetel()

        Dim ds As New DataSet
        Dim Dr As DataRow
        Dim Rows() As DataRow
        Dim Row As DataRow
        Dim DPC As ClDetentionPerCntr
        Dim Temp As DataTable
        Dim Cmd As New SqlClient.SqlCommand
        Dim Cnn As New SqlClient.SqlConnection(My.Settings.DSN)
        Dim DA As New SqlDataAdapter
        Dim Title As String = "List of No Seteld B/LS"

        Cnn.Open()
        Cmd.CommandText = "SP_DetentionGnrlReport"
        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.CommandTimeout = 150
        Cmd.Parameters.AddWithValue("@Line", CurrentShippingLine)
        Cmd.Connection = Cnn

        'If Boolean.Parse(CurrentUser.IsDocAdmin) = True Or Boolean.Parse(CurrentUser.IsEcsAdmin) = True Then
        '    If MsgBox("Do You Want To Get Report Base On To line Data ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
        '        Cmd.CommandText = "SP_DetentionGnrlReportForLine"
        '        Title = "List of No Seteld B/LS [For Line]"
        '    End If
        'End If

        Me.Cursor = Cursors.WaitCursor
        DA.SelectCommand = Cmd
        DA.Fill(ds)

        Rows = ds.Tables(0).Select("FirstEA is null or DoAmount = 0")
        For Each Row In Rows
            Row.Delete()
        Next

        ds.AcceptChanges()
 

        For Each Dr In ds.Tables(0).Rows


            Rows = ds.Tables(1).Select("ID = '" & Dr("ID").ToString & "'")
            DPC = New ClDetentionPerCntr
            For Each Row In Rows
                If IsDBNull(Row("DF")) Or IsDBNull(Row("EA")) Then
                    Dr.RowError = "Please Check FV Date & MA Date"
                Else
                    Temp = DPC.DetentionPerCntr("I", Row("CnSize"), Row("Cntype"), Row("DF"), Row("EA"), Row("ID").ToString, Int16.Parse(Row("LCLCount").ToString), Row("WGTPercent"))
                End If
            Next
            Dr("Detention") = DPC.GetTotaldetention
            Dr("Discount") = DPC.GetTotalDiscount
            Dr("Balance") = DPC.GetTotaldetention - (DPC.GetTotalDiscount + NullToValue(Dr("FirstPaid"), 0))

        Next

        Me.GridResult.DataSource = ds.Tables(0)
        With Me.GridResult.DisplayLayout.Bands(0)
            .Columns("ID").Hidden = True
            .Columns("DoAmount").Hidden = True
            .Columns("FirstEa").Hidden = True
        End With

        With Me.GridResult.DisplayLayout.Bands(0)
            .HeaderVisible = True
            .Header.Activated = True
            .Header.Caption = Title
            .Header.Appearance.BackColor = Color.Maroon
            .Header.Appearance.ForeColor = Color.Yellow
            .Header.Appearance.FontData.Name = "Verdana"
            .Header.Appearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.True
            .Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
            .Header.Appearance.FontData.SizeInPoints = 8
            '.Columns("DF").Header.Caption = "FV"
            '.Columns("EA").Header.Caption = "MA"

        End With

        GridNumSeperator(Me.GridResult)
        Me.Cursor = Cursors.Default
        Me.UltraTabControl1.Tabs(1).Selected = True

    End Sub

    Private Sub showOverDue()

        Dim ds As New DataSet
        Dim Dr As DataRow
        Dim Rows() As DataRow
        Dim Row As DataRow
        Dim DPC As ClDetentionPerCntr
        Dim Temp As DataTable
        Dim Title As String = "Over due B/LS"


        Dim Cmd As New SqlClient.SqlCommand
        Dim Cnn As New SqlClient.SqlConnection(My.Settings.DSN)
        Dim DA As New SqlDataAdapter

        Cnn.Open()
        Cmd.CommandText = "SP_DetentionGnrlReport"
        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.CommandTimeout = 150
        Cmd.Parameters.AddWithValue("@Line", CurrentShippingLine)
        Cmd.Connection = Cnn

        If Boolean.Parse(CurrentUser.IsDocAdmin) = True Or Boolean.Parse(CurrentUser.IsEcsAdmin) = True Then
            If MsgBox("Do You Want To Get Report Base On To line Data ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Cmd.CommandText = "SP_DetentionGnrlReportForLine"
                Title = "Over due B/LS [For Line]"
            End If
        End If

        Me.Cursor = Cursors.WaitCursor
        DA.SelectCommand = Cmd
        DA.Fill(ds)

        Rows = ds.Tables(0).Select("(not FirstEA is null) or DoAmount = 0")
        For Each Row In Rows
            Row.Delete()
        Next
        ds.AcceptChanges()

        For Each Dr In ds.Tables(0).Rows
            Rows = ds.Tables(1).Select("ID = '" & Dr("ID").ToString & "'")
            DPC = New ClDetentionPerCntr
            For Each Row In Rows
                If IsDBNull(Row("DF")) Or IsDBNull(Row("EA")) Then
                    Dr.RowError = "Please Check FV Date & MA Date"
                Else
                    Temp = DPC.DetentionPerCntr("I", Row("CnSize"), Row("Cntype"), Row("DF"), Row("EA"), Row("ID").ToString, Int16.Parse(Row("LCLCount").ToString), Row("WgtPercent"))
                End If
            Next
            Dr("Detention") = DPC.GetTotaldetention
            Dr("Discount") = DPC.GetTotalDiscount
            Dr("Balance") = DPC.GetTotaldetention - DPC.GetTotalDiscount
        Next

        Me.GridResult.DataSource = ds.Tables(0)
        With Me.GridResult.DisplayLayout.Bands(0)
            .Columns("ID").Hidden = True
            .Columns("DoAmount").Hidden = True
            .Columns("FirstEa").Hidden = True
        End With

        With Me.GridResult.DisplayLayout.Bands(0)
            .HeaderVisible = True
            .Header.Activated = True
            .Header.Caption = "Over due B/LS"
            .Header.Appearance.BackColor = Color.Maroon
            .Header.Appearance.ForeColor = Color.Yellow
            .Header.Appearance.FontData.Name = "Verdana"
            .Header.Appearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.True
            .Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
            .Header.Appearance.FontData.SizeInPoints = 8
        End With

        GridNumSeperator(Me.GridResult)
        Me.Cursor = Cursors.Default
        Me.UltraTabControl1.Tabs(1).Selected = True


    End Sub

    Private Sub ShowNoDoTaken()

        Dim ds As New DataSet
        Dim Dr As DataRow
        Dim Rows() As DataRow
        Dim Row As DataRow
        Dim DPC As ClDetentionPerCntr
        Dim Temp As DataTable
        Dim Title As String = "No D.O. Taken B/LS"

        Dim Cmd As New SqlClient.SqlCommand
        Dim Cnn As New SqlClient.SqlConnection(My.Settings.DSN)
        Dim DA As New SqlDataAdapter

        Cnn.Open()
        Cmd.CommandText = "SP_DetentionGnrlReport"
        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.CommandTimeout = 150
        Cmd.Parameters.AddWithValue("@Line", CurrentShippingLine)
        Cmd.Connection = Cnn

        If Boolean.Parse(CurrentUser.IsDocAdmin) = True Or Boolean.Parse(CurrentUser.IsEcsAdmin) = True Then
            If MsgBox("Do You Want To Get Report Base On To line Data ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Cmd.CommandText = "SP_DetentionGnrlReportForLine"
                Title = "No D.O. Taken B/LS [For Line]"
            End If
        End If

        Me.Cursor = Cursors.WaitCursor
        DA.SelectCommand = Cmd
        DA.Fill(ds)

        Rows = ds.Tables(0).Select("DoAmount > 0")
        For Each Row In Rows
            Row.Delete()
        Next

        ds.AcceptChanges()
        For Each Dr In ds.Tables(0).Rows
            Rows = ds.Tables(1).Select("ID = '" & Dr("ID").ToString & "'")
            DPC = New ClDetentionPerCntr
            For Each Row In Rows
                If IsDBNull(Row("DF")) Or IsDBNull(Row("EA")) Then
                    Dr.RowError = "Please Check FV Date & MA Date"
                Else
                    Temp = DPC.DetentionPerCntr("I", Row("CnSize"), Row("Cntype"), Row("DF"), Row("EA"), Row("ID").ToString, Int16.Parse(Row("LCLCount").ToString), Row("WgtPercent"))
                End If
            Next
            Dr("Detention") = DPC.GetTotaldetention
            Dr("Discount") = DPC.GetTotalDiscount
            Dr("Balance") = DPC.GetTotaldetention - DPC.GetTotalDiscount
        Next

        Me.GridResult.DataSource = ds.Tables(0)
        With Me.GridResult.DisplayLayout.Bands(0)
            .Columns("ID").Hidden = True
            .Columns("DoAmount").Hidden = True
            .Columns("FirstEa").Hidden = True

        End With
        With Me.GridResult.DisplayLayout.Bands(0)
            .HeaderVisible = True
            .Header.Activated = True
            .Header.Caption = Title
            .Header.Appearance.BackColor = Color.Maroon
            .Header.Appearance.ForeColor = Color.Yellow
            .Header.Appearance.FontData.Name = "Verdana"
            .Header.Appearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.True
            .Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
            .Header.Appearance.FontData.SizeInPoints = 8
        End With
        GridNumSeperator(Me.GridResult)
        Me.Cursor = Cursors.Default
        Me.UltraTabControl1.Tabs(1).Selected = True

    End Sub
    Private Sub GenVoyageSummary()

        Dim Ds As New DataSet
        Dim Dm As New DataManager(My.Settings.DSN)


        If Me.DateFrom.DateValue Is Nothing Then
            Me.DateFrom.DateValue = Now
        End If

        If Me.DateTo.DateValue Is Nothing Then
            Me.DateTo.DateValue = Now
        End If

        Me.Cursor = Cursors.WaitCursor
        Ds = StoredProcedures.SP_VoyageListByDate(Me.DateFrom.DateValue, Me.DateTo.DateValue)
        Me.Cursor = Cursors.Default
        If Ds.Tables(0).Rows.Count = 0 Then
            MsgBox("No any data !")
        Else
            Me.GridResult.DataSource = Ds.Tables(0).Copy
            With Me.GridResult.DisplayLayout.Bands(0)
                .HeaderVisible = True
                .Header.Activated = True
                .Header.Caption = "Voyage List From:" & Me.DateFrom.DateValue.ToString & "  To:" & Me.DateTo.DateValue.ToString
                .Header.Appearance.BackColor = Color.Maroon
                .Header.Appearance.ForeColor = Color.Yellow
                .Header.Appearance.FontData.Name = "Verdana"
                .Header.Appearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.True
                .Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                .Header.Appearance.FontData.SizeInPoints = 8
            End With
        End If
        Me.UltraTabControl1.Tabs(1).Selected = True

    End Sub

    Private Sub ShowDepositDetails()

        Dim Ds As New DataSet
        Dim Dm As New DataManager(My.Settings.DSN)
        Dim Cnn As New SqlConnection(My.Settings.DSN)
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim dfrom As DateTime
        Dim dto As DateTime

        If Me.DateFrom.DateValue Is Nothing Then
            Me.DateFrom.DateValue = Now
        End If

        If Me.DateTo.DateValue Is Nothing Then
            Me.DateTo.DateValue = Now
        End If

      
        '
        dfrom = Me.DateTo.DateValue
        dto = Me.DateTo.DateValue
        Me.Cursor = Cursors.WaitCursor
        Cnn.Open()
        '
        With Cmd
            .CommandText = "SP_Account"
            .CommandType = CommandType.StoredProcedure
            .Connection = Cnn
            .Parameters.AddWithValue("@dFrom", dfrom)
            .Parameters.AddWithValue("@dTo", dto)

        End With

        DA.SelectCommand = Cmd
        DA.Fill(Ds)
        ''Ds = StoredProcedures.SP_Account(Me.DateFrom.DateValue, Me.DateTo.DateValue)
        Me.Cursor = Cursors.Default
        If Ds.Tables(0).Rows.Count = 0 Then
            MsgBox("No any data !")
        Else
            Me.GridResult.DataSource = Ds.Tables(0).Copy
            With Me.GridResult.DisplayLayout.Bands(0)
                .HeaderVisible = True
                .Header.Activated = True
                .Header.Caption = "Deposit Details From:" & Me.DateFrom.DateValue.ToString & "  To:" & Me.DateTo.DateValue.ToString
                .Header.Appearance.BackColor = Color.Maroon
                .Header.Appearance.ForeColor = Color.Yellow
                .Header.Appearance.FontData.Name = "Verdana"
                .Header.Appearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.True
                .Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                .Header.Appearance.FontData.SizeInPoints = 8
            End With

        End If
        GridNumSeperator(Me.GridResult)
        Me.UltraTabControl1.Tabs(1).Selected = True

    End Sub
    Private Sub ButtonPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPrint.Click
        If Nothing Is Me.customColumnChooserDialog OrElse Me.customColumnChooserDialog.IsDisposed Then
            Me.customColumnChooserDialog = New CustomColumnChooser()
            Me.customColumnChooserDialog.Owner = Me
            Me.customColumnChooserDialog.Grid = Me.GridResult
        End If

        Me.customColumnChooserDialog.Show()
    End Sub
    Private Sub ShowFreightSummary()

        Dim Ds As DataSet
        Dim Prm As SqlClient.SqlParameter
        Dim arrayParams As New ArrayList
        Dim DD As Date
        Dim Dm As New DataManager(My.Settings.DSN)
        Dim TB As New DataTable
        Dim DA As New SqlDataAdapter
        Dim Cmd As New SqlCommand
        Dim Cnn As New SqlConnection

        Me.Cursor = Cursors.WaitCursor
        Cnn.ConnectionString = My.Settings.DSN
        Cnn.Open()
        Cmd.Connection = Cnn
        DD = Me.DateFrom.GnrlDate.Value
        Cmd.Parameters.AddWithValue("@DFrom", DD.Date)

        DD = Me.DateTo.GnrlDate.Value
        Cmd.Parameters.AddWithValue("@DTo", DD.Date)

        DD = Me.DateTo.GnrlDate.Value
        Cmd.Parameters.AddWithValue("@Line",CurrentShippingLine)

        Cmd.CommandText = "SP_InwardVoyageAccountByArrival"
        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.CommandTimeout = 5000
        DA = New SqlDataAdapter(Cmd)
        DA.Fill(TB)

        If TB.Rows.Count = 0 Then
            MsgBox("No any data !")
            Exit Sub
        Else
            Me.GridResult.DataSource = TB
            GridNumSeperator(Me.GridResult)
            With Me.GridResult.DisplayLayout.Bands(0)
                .HeaderVisible = True
                .Header.Activated = True
                .Header.Caption = "Freight Summary From " & Me.DateFrom.DateValue.ToString & "  To:" & Me.DateTo.DateValue.ToString & " (Arrival Date)"
                .Header.Appearance.BackColor = Color.Maroon
                .Header.Appearance.ForeColor = Color.Yellow
                .Header.Appearance.FontData.Name = "Verdana"
                .Header.Appearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.True
                .Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                .Header.Appearance.FontData.SizeInPoints = 8
            End With
        End If
        Me.Cursor = Cursors.Default
        Me.UltraTabControl1.Tabs(1).Selected = True
    End Sub

    Private Sub ShowFreightSummaryOutward()

        Dim Ds As DataSet
        Dim Prm As SqlClient.SqlParameter
        Dim arrayParams As New ArrayList
        Dim DD As Date
        Dim Dm As New DataManager(My.Settings.DSN)
        Dim TB As New DataTable
        Dim DA As New SqlDataAdapter
        Dim Cmd As New SqlCommand
        Dim Cnn As New SqlConnection

        Me.Cursor = Cursors.WaitCursor
        Cnn.ConnectionString = My.Settings.DSN
        Cnn.Open()
        Cmd.Connection = Cnn
        DD = Me.DateFrom.GnrlDate.Value
        Cmd.Parameters.AddWithValue("@DFrom", DD.Date)

        DD = Me.DateTo.GnrlDate.Value
        Cmd.Parameters.AddWithValue("@DTo", DD.Date)

        DD = Me.DateTo.GnrlDate.Value
        Cmd.Parameters.AddWithValue("@Line", CurrentShippingLine)

        Cmd.CommandText = "SP_OutwardVoyageAccountBySailed"
        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.CommandTimeout = 5000
        DA = New SqlDataAdapter(Cmd)
        DA.Fill(TB)

        If TB.Rows.Count = 0 Then
            MsgBox("No any data !")
            Exit Sub
        Else
            Me.GridResult.DataSource = TB
            GridNumSeperator(Me.GridResult)
            With Me.GridResult.DisplayLayout.Bands(0)
                .HeaderVisible = True
                .Header.Activated = True
                .Header.Caption = "Freight Summary From " & Me.DateFrom.DateValue.ToString & "  To:" & Me.DateTo.DateValue.ToString & " (Sailed Date)"
                .Header.Appearance.BackColor = Color.Maroon
                .Header.Appearance.ForeColor = Color.Yellow
                .Header.Appearance.FontData.Name = "Verdana"
                .Header.Appearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.True
                .Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                .Header.Appearance.FontData.SizeInPoints = 8
            End With
        End If
        Me.Cursor = Cursors.Default
        Me.UltraTabControl1.Tabs(1).Selected = True
    End Sub
    Private Sub ShowNoInvoiceSetelCntr()

        Dim ds As New DataSet
        Dim Dr As DataRow
        Dim Rows() As DataRow
        Dim Row As DataRow
        Dim DPC As ClDetentionPerCntr
        Dim Temp As DataTable
        Dim DTNdrs() As DataRow
        Dim TbResult As New DataTable
        Dim Title As String = "List of No Seteld (Container Wise) Normal"

        Dim Cmd As New SqlClient.SqlCommand
        Dim Cnn As New SqlClient.SqlConnection(My.Settings.DSN)
        Dim DA As New SqlDataAdapter

        Cnn.Open()
        Cmd.CommandText = "SP_DetentionGnrlReport"
        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.CommandTimeout = 5000
        Cmd.Parameters.AddWithValue("@Line", CurrentShippingLine)
        Cmd.Connection = Cnn

        If Boolean.Parse(CurrentUser.IsDocAdmin) = True Or Boolean.Parse(CurrentUser.IsEcsAdmin) = True Then
            If MsgBox("Do You Want To Get Report Base On To line Data ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Cmd.CommandText = "SP_DetentionGnrlReportForLine"
                Title = "List of No Seteld (Container Wise) [For line]"
            End If
        End If
        Me.Cursor = Cursors.WaitCursor
        DA.SelectCommand = Cmd
        DA.Fill(ds)


        Rows = ds.Tables(0).Select("FirstEA is null or DoAmount = 0")
        For Each Row In Rows
            Row.Delete()
        Next
        ds.AcceptChanges()

        ds.Tables(1).Columns.Add(New DataColumn("BLNO"))
        ds.Tables(1).Columns.Add(New DataColumn("FreeDays", System.Type.GetType("System.Int64")))
        ds.Tables(1).Columns.Add(New DataColumn("Discount", System.Type.GetType("System.Int64")))
        ds.Tables(1).Columns.Add(New DataColumn("Detention", System.Type.GetType("System.Int64")))
        ds.Tables(1).Columns.Add(New DataColumn("Vessel"))
        ds.Tables(1).Columns.Add(New DataColumn("Voyage"))
        ds.Tables(1).Columns.Add(New DataColumn("Client"))
        ds.Tables(1).Columns.Add(New DataColumn("TotalDays", System.Type.GetType("System.Int64")))

        For Each Dr In ds.Tables(0).Rows

            Rows = ds.Tables(1).Select("ID = '" & Dr("ID").ToString & "'")
            DPC = New ClDetentionPerCntr
            For Each Row In Rows
                If IsDBNull(Row("DF")) Or IsDBNull(Row("EA")) Then
                    Dr.RowError = "Please Check FV Date & MA Date"
                Else
                    Temp = DPC.DetentionPerCntr("I", Row("CnSize"), Row("Cntype"), Row("DF"), Row("EA"), _
                    Row("ID").ToString, Int16.Parse(Row("LCLCount").ToString), Row("WGTPercent"), Row("Cntrno"))
                End If
                DTNdrs = DPC.CntrsTB.Select("CntrNo = '" & Row.Item("CntrNo") & "'")
                If DTNdrs.Length > 0 Then
                    Row.Item("BLNO") = Dr("BLNO")
                    Row.Item("FreeDays") = DTNdrs(0).Item("FreeDays")
                    Row.Item("Discount") = DTNdrs(0).Item("Discount")
                    Row.Item("Detention") = DTNdrs(0).Item("Detention")
                    Row.Item("TotalDays") = DTNdrs(0).Item("Totaldays")
                    Row.Item("Vessel") = Dr("Vessel")
                    Row.Item("Voyage") = Dr("Voyage")
                    Row.Item("Client") = Dr("Client")

                End If
            Next
            'Dr("Detention") = DPC.GetTotaldetention
            'Dr("Discount") = DPC.GetTotalDiscount
            'Dr("Balance") = DPC.GetTotaldetention - (DPC.GetTotalDiscount + NullToValue(Dr("FirstPaid"), 0))
        Next

        '  TbResult.Columns.Add(New DataColumn("Line"))
        TbResult.Columns.Add(New DataColumn("BLNO"))
        TbResult.Columns.Add(New DataColumn("CntrNo"))
        TbResult.Columns.Add(New DataColumn("Voyage"))
        TbResult.Columns.Add(New DataColumn("Vessel"))
        TbResult.Columns.Add(New DataColumn("CnSize"))
        TbResult.Columns.Add(New DataColumn("CnType"))
        '  TbResult.Columns.Add(New DataColumn("SOC"))
        TbResult.Columns.Add(New DataColumn("DF", System.Type.GetType("System.DateTime")))
        TbResult.Columns.Add(New DataColumn("EA", System.Type.GetType("System.DateTime")))
        TbResult.Columns.Add(New DataColumn("TotalDays", System.Type.GetType("System.Int16")))
        TbResult.Columns.Add(New DataColumn("FreeDays", System.Type.GetType("System.Int64")))
        TbResult.Columns.Add(New DataColumn("Discount", System.Type.GetType("System.Int64")))
        TbResult.Columns.Add(New DataColumn("Detention", System.Type.GetType("System.Int64")))
        TbResult.Columns.Add(New DataColumn("LCLCount", System.Type.GetType("System.Int16")))
        TbResult.Columns.Add(New DataColumn("Client"))


        'Id , discharge , LastEA , FirstEA , DoAmount , FirstPaid , Balance , ID 
        Try
            ds.Tables(1).Columns.Remove("ID")
            ds.Tables(1).Columns.Remove("VoyageID")
            ds.Tables(1).Columns.Remove("WGTPercent")
            ds.Tables(1).Columns.Remove("SOC")
        Catch ex As Exception

        End Try

        Try
            TbResult.Columns.Add(New DataColumn("DamageCost", System.Type.GetType("System.Double")))

        Catch ex As Exception
        End Try


        Try
            TbResult.Columns.Add(New DataColumn("Line"))

        Catch ex As Exception
        End Try


        Try
            TbResult.Columns.Add(New DataColumn("POL"))
            TbResult.Columns.Add(New DataColumn("POD"))

        Catch ex As Exception
        End Try

        For Each Row In ds.Tables(1).Rows
            Dr = TbResult.NewRow
            For Each col As DataColumn In ds.Tables(1).Columns

                Dr.Item(col.ColumnName) = Row.Item(col.ColumnName)
            Next
            TbResult.Rows.Add(Dr)
        Next

        Me.GridResult.DataSource = TbResult

        With Me.GridResult.DisplayLayout.Bands(0)
            .HeaderVisible = True
            .Header.Activated = True
            .Header.Caption = Title
            .Header.Appearance.BackColor = Color.Maroon
            .Header.Appearance.ForeColor = Color.Yellow
            .Header.Appearance.FontData.Name = "Verdana"
            .Header.Appearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.True
            .Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
            .Header.Appearance.FontData.SizeInPoints = 8
            .Columns("DF").Header.Caption = "FV"
            .Columns("EA").Header.Caption = "MA"
        End With

        GridNumSeperator(Me.GridResult)
        Me.Cursor = Cursors.Default
        Me.UltraTabControl1.Tabs(1).Selected = True

    End Sub

    Private Sub showOverDueCntr()

        Dim ds As New DataSet
        Dim Dr As DataRow
        Dim Rows() As DataRow
        Dim Row As DataRow
        Dim DPC As ClDetentionPerCntr
        Dim Temp As DataTable
        Dim Title As String = "Over due B/LS (Container Wise)"
        Dim DTNdrs() As DataRow
        Dim TbResult As New DataTable

        Dim Cmd As New SqlClient.SqlCommand
        Dim Cnn As New SqlClient.SqlConnection(My.Settings.DSN)
        Dim DA As New SqlDataAdapter

        Cnn.Open()
        Cmd.CommandText = "SP_DetentionGnrlReport"
        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.CommandTimeout = 5000
        Cmd.Parameters.AddWithValue("@Line", CurrentShippingLine)
        Cmd.Connection = Cnn

        If Boolean.Parse(CurrentUser.IsDocAdmin) = True Or Boolean.Parse(CurrentUser.IsEcsAdmin) = True Then
            If MsgBox("Do You Want To Get Report Base On To line Data ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Cmd.CommandText = "SP_DetentionGnrlReportForLine"
                Title = "Over due B/LS (Container Wise) [For Line]"
            End If
        End If

        Me.Cursor = Cursors.WaitCursor
        DA.SelectCommand = Cmd
        DA.Fill(ds)

        Rows = ds.Tables(0).Select("(not FirstEa is null) or DoAmount = 0")
        For Each Row In Rows
            Row.Delete()
        Next
        ds.AcceptChanges()

        ds.Tables(1).Columns.Add(New DataColumn("BLNO"))
        ds.Tables(1).Columns.Add(New DataColumn("FreeDays", System.Type.GetType("System.Int64")))
        ds.Tables(1).Columns.Add(New DataColumn("Discount", System.Type.GetType("System.Int64")))
        ds.Tables(1).Columns.Add(New DataColumn("Detention", System.Type.GetType("System.Int64")))
        ds.Tables(1).Columns.Add(New DataColumn("Vessel"))
        ds.Tables(1).Columns.Add(New DataColumn("Voyage"))
        ds.Tables(1).Columns.Add(New DataColumn("Client"))
        ds.Tables(1).Columns.Add(New DataColumn("TotalDays", System.Type.GetType("System.Int64")))

        For Each Dr In ds.Tables(0).Rows
            Rows = ds.Tables(1).Select("ID = '" & Dr("ID").ToString & "'")
            DPC = New ClDetentionPerCntr
            For Each Row In Rows
                Temp = DPC.DetentionPerCntr("I", Row("CnSize"), Row("Cntype"), NullToValue(Row("DF"), Now), NullToValue(Row("EA"), Now), Row("ID").ToString, Int16.Parse(Row("LCLCount").ToString), Row("WgtPercent"), Row("CntrNo"))
                DTNdrs = DPC.CntrsTB.Select("CntrNo = '" & Row.Item("CntrNo") & "'")
                If DTNdrs.Length > 0 Then
                    Row.Item("BLNO") = Dr("BLNO")
                    Row.Item("FreeDays") = DTNdrs(0).Item("FreeDays")
                    Row.Item("Discount") = DTNdrs(0).Item("Discount")
                    Row.Item("Detention") = DTNdrs(0).Item("Detention")
                    Row.Item("TotalDays") = DTNdrs(0).Item("Totaldays")
                    Row.Item("Vessel") = Dr("Vessel")
                    Row.Item("Voyage") = Dr("Voyage")
                    Row.Item("Client") = Dr("Client")

                End If
            Next
            'Dr("Detention") = DPC.GetTotaldetention
            'Dr("Discount") = DPC.GetTotalDiscount
            'Dr("Balance") = DPC.GetTotaldetention - DPC.GetTotalDiscount
        Next

        TbResult.Columns.Add(New DataColumn("BLNO"))
        TbResult.Columns.Add(New DataColumn("CntrNo"))
        TbResult.Columns.Add(New DataColumn("Voyage"))
        TbResult.Columns.Add(New DataColumn("Vessel"))
        TbResult.Columns.Add(New DataColumn("CnSize"))
        TbResult.Columns.Add(New DataColumn("CnType"))
        '  TbResult.Columns.Add(New DataColumn("SOC"))
        TbResult.Columns.Add(New DataColumn("DF", System.Type.GetType("System.DateTime")))
        TbResult.Columns.Add(New DataColumn("EA", System.Type.GetType("System.DateTime")))
        TbResult.Columns.Add(New DataColumn("TotalDays", System.Type.GetType("System.Int16")))
        TbResult.Columns.Add(New DataColumn("FreeDays", System.Type.GetType("System.Int64")))
        TbResult.Columns.Add(New DataColumn("Discount", System.Type.GetType("System.Int64")))
        TbResult.Columns.Add(New DataColumn("Detention", System.Type.GetType("System.Int64")))
        TbResult.Columns.Add(New DataColumn("LCLCount", System.Type.GetType("System.Int16")))
        TbResult.Columns.Add(New DataColumn("Client"))
        TbResult.Columns.Add(New DataColumn("POL"))
        TbResult.Columns.Add(New DataColumn("POD"))
        TbResult.Columns.Add(New DataColumn("LINE"))
        TbResult.Columns.Add(New DataColumn("DamageCost", System.Type.GetType("System.Double")))

        'Id , discharge , LastEA , FirstEA , DoAmount , FirstPaid , Balance , ID 
        ds.Tables(1).Columns.Remove("ID")
        ds.Tables(1).Columns.Remove("VoyageID")
        ds.Tables(1).Columns.Remove("WGTPercent")
        ' ds.Tables(1).Columns.Remove("SOC")

        For Each Row In ds.Tables(1).Rows
            Dr = TbResult.NewRow
            For Each col As DataColumn In ds.Tables(1).Columns
                Try
                    Dr.Item(col.ColumnName) = Row.Item(col.ColumnName)
                Catch ex As Exception

                End Try

            Next
            TbResult.Rows.Add(Dr)
        Next

        Me.GridResult.DataSource = TbResult

        With Me.GridResult.DisplayLayout.Bands(0)
            .HeaderVisible = True
            .Header.Activated = True
            .Header.Caption = Title
            .Header.Appearance.BackColor = Color.Maroon
            .Header.Appearance.ForeColor = Color.Yellow
            .Header.Appearance.FontData.Name = "Verdana"
            .Header.Appearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.True
            .Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
            .Header.Appearance.FontData.SizeInPoints = 8
        End With

        GridNumSeperator(Me.GridResult)
        Me.Cursor = Cursors.Default
        Me.UltraTabControl1.Tabs(1).Selected = True


    End Sub

    Private Sub ShowNoDoTakenCntr()

        Dim ds As New DataSet
        Dim Dr As DataRow
        Dim Rows() As DataRow
        Dim Row As DataRow
        Dim DPC As ClDetentionPerCntr
        Dim Temp As DataTable
        Dim Title As String = "No D.O. Taken B/LS (Container Wise)"
        Dim DTNdrs() As DataRow
        Dim TbResult As New DataTable


        Dim Cmd As New SqlClient.SqlCommand
        Dim Cnn As New SqlClient.SqlConnection(My.Settings.DSN)
        Dim DA As New SqlDataAdapter

        Cnn.Open()
        Cmd.CommandText = "SP_DetentionGnrlReport"
        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.CommandTimeout = 5000
        Cmd.Parameters.AddWithValue("@Line", CurrentShippingLine)
        Cmd.Connection = Cnn

        If Boolean.Parse(CurrentUser.IsDocAdmin) = True Or Boolean.Parse(CurrentUser.IsEcsAdmin) = True Then
            If MsgBox("Do You Want To Get Report Base On To Line Data ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Cmd.CommandText = "SP_DetentionGnrlReportForLine"
                Title = "No D.O. Taken B/LS (Container Wise) [For Line]"
            End If
        End If
        Me.Cursor = Cursors.WaitCursor
        DA.SelectCommand = Cmd
        DA.Fill(ds)

        Rows = ds.Tables(0).Select("DoAmount > 0")
        For Each Row In Rows
            Row.Delete()
        Next
        ds.AcceptChanges()
        ds.Tables(1).Columns.Add(New DataColumn("BLNO"))
        ds.Tables(1).Columns.Add(New DataColumn("FreeDays", System.Type.GetType("System.Int64")))
        ds.Tables(1).Columns.Add(New DataColumn("Discount", System.Type.GetType("System.Int64")))
        ds.Tables(1).Columns.Add(New DataColumn("Detention", System.Type.GetType("System.Int64")))
        ds.Tables(1).Columns.Add(New DataColumn("Vessel"))
        ds.Tables(1).Columns.Add(New DataColumn("Voyage"))
        ds.Tables(1).Columns.Add(New DataColumn("Client"))
        ds.Tables(1).Columns.Add(New DataColumn("TotalDays", System.Type.GetType("System.Int64")))

        For Each Dr In ds.Tables(0).Rows
            Rows = ds.Tables(1).Select("ID = '" & Dr("ID").ToString & "'")
            DPC = New ClDetentionPerCntr
            For Each Row In Rows
                Temp = DPC.DetentionPerCntr("I", Row("CnSize"), Row("Cntype"), NullToValue(Row("DF"), Now), NullToValue(Row("EA"), Now), Row("ID").ToString, Int16.Parse(Row("LCLCount").ToString), Row("WgtPercent"), Row("CntrNo"))
                DTNdrs = DPC.CntrsTB.Select("CntrNo = '" & Row.Item("CntrNo") & "'")
                If DTNdrs.Length > 0 Then
                    Row.Item("BLNO") = Dr("BLNO")
                    Row.Item("FreeDays") = DTNdrs(0).Item("FreeDays")
                    Row.Item("Discount") = DTNdrs(0).Item("Discount")
                    Row.Item("Detention") = DTNdrs(0).Item("Detention")
                    Row.Item("TotalDays") = DTNdrs(0).Item("Totaldays")
                    Row.Item("Vessel") = Dr("Vessel")
                    Row.Item("Voyage") = Dr("Voyage")
                    Row.Item("Client") = Dr("Client")
                End If
            Next
        Next

        TbResult.Columns.Add(New DataColumn("BLNO"))
        TbResult.Columns.Add(New DataColumn("CntrNo"))
        TbResult.Columns.Add(New DataColumn("Voyage"))
        TbResult.Columns.Add(New DataColumn("Vessel"))
        TbResult.Columns.Add(New DataColumn("CnSize"))
        TbResult.Columns.Add(New DataColumn("CnType"))
        '  TbResult.Columns.Add(New DataColumn("SOC"))
        TbResult.Columns.Add(New DataColumn("FV", System.Type.GetType("System.DateTime")))
        TbResult.Columns.Add(New DataColumn("MA", System.Type.GetType("System.DateTime")))
        TbResult.Columns.Add(New DataColumn("TotalDays", System.Type.GetType("System.Int16")))
        TbResult.Columns.Add(New DataColumn("FreeDays", System.Type.GetType("System.Int64")))
        TbResult.Columns.Add(New DataColumn("Discount", System.Type.GetType("System.Int64")))
        TbResult.Columns.Add(New DataColumn("Detention", System.Type.GetType("System.Int64")))
        TbResult.Columns.Add(New DataColumn("LCLCount", System.Type.GetType("System.Int16")))
        TbResult.Columns.Add(New DataColumn("Client"))

        ds.Tables(1).Columns.Remove("ID")
        ds.Tables(1).Columns.Remove("VoyageID")
        ds.Tables(1).Columns.Remove("WGTPercent")

        For Each Row In ds.Tables(1).Rows
            Dr = TbResult.NewRow
            For Each col As DataColumn In ds.Tables(1).Columns
                Try
                    Dr.Item(col.ColumnName) = Row.Item(col.ColumnName)
                Catch ex As Exception

                End Try

            Next
            TbResult.Rows.Add(Dr)
        Next

        Me.GridResult.DataSource = TbResult

        With Me.GridResult.DisplayLayout.Bands(0)
            .HeaderVisible = True
            .Header.Activated = True
            .Header.Caption = Title
            .Header.Appearance.BackColor = Color.Maroon
            .Header.Appearance.ForeColor = Color.Yellow
            .Header.Appearance.FontData.Name = "Verdana"
            .Header.Appearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.True
            .Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
            .Header.Appearance.FontData.SizeInPoints = 8
        End With

        GridNumSeperator(Me.GridResult)
        Me.Cursor = Cursors.Default
        Me.UltraTabControl1.Tabs(1).Selected = True

    End Sub

    Private Sub GenChargesInDetails()

        Dim Ds As New DataSet
        Dim DD As Date
        Dim DA As New SqlDataAdapter
        Dim Cmd As New SqlCommand
        Dim Cnn As New SqlConnection
        Dim Drs() As DataRow
        Dim Dr As DataRow
        Dim DummyTB As New DataTable
        Dim CRT As String
        Dim CP As String
        Dim NewDr As DataRow
        Dim ColName As String

        Me.Cursor = Cursors.WaitCursor
        Cnn.ConnectionString = My.Settings.DSN
        Cnn.Open()
        Cmd.Connection = Cnn

        DD = Me.DateFrom.GnrlDate.Value
        Cmd.Parameters.AddWithValue("@DFrom", DD.Date)

        DD = Me.DateTo.GnrlDate.Value
        Cmd.Parameters.AddWithValue("@DTo", DD.Date)

        Cmd.CommandText = "SP_InwardListOfChargesByDate"
        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.CommandTimeout = 5000
        DA = New SqlDataAdapter(Cmd)
        DA.Fill(Ds)

        DummyTB.Columns.Add(New DataColumn("ChargesCode"))
        DummyTB.Columns.Add(New DataColumn("Currency"))
        DummyTB.Columns.Add(New DataColumn("CP"))

        For Each Dr In Ds.Tables(1).Rows
            If Dr("Terms") = "C" Then ''Or Dr("PayAt").ToString.Substring(1, 2) = "IR"
                CP = "C"
            Else
                CP = "P"
            End If
            CRT = "ChargesCode = '" & Dr("ChargesCode") & "' and Currency = '" & Dr("Currency") & "' and CP = '" & CP & "'"
            Drs = DummyTB.Select(CRT)
            If Drs.Length = 0 Then
                NewDr = DummyTB.NewRow
                NewDr("ChargesCode") = Dr("ChargesCode")
                NewDr("Currency") = Dr("Currency")
                NewDr("CP") = CP
                DummyTB.Rows.Add(NewDr)
            End If
        Next

        For Each Dr In DummyTB.Rows

            ColName = Dr("ChargesCode") & "_" & Dr("Currency") & "_" & Dr("CP")
            Ds.Tables(0).Columns.Add(New DataColumn(ColName, System.Type.GetType("System.Double")))
        Next

        For Each Dr In Ds.Tables(0).Rows
            Drs = Ds.Tables(1).Select("BLID = '" & Dr("ID").ToString & "'")
            For Each MyDr As DataRow In Drs
                If MyDr("Terms") = "C" Or MyDr("PayAt").ToString.Substring(1, 2) = "IR" Then
                    CP = "C"
                Else
                    CP = "P"
                End If
                ColName = MyDr("ChargesCode") & "_" & MyDr("Currency") & "_" & CP
                If NullToValue(Dr(ColName), 0) = 0 Then
                    Dr(ColName) = 0
                End If
                Dr(ColName) += NullToValue(MyDr("Amount"), 0)
            Next
        Next

        Me.GridResult.DataSource = Ds.Tables(0)
        Me.Cursor = Cursors.Default
        GridNumSeperator(Me.GridResult)
        GridNumSeperator(Me.GridResult)
        With Me.GridResult.DisplayLayout.Bands(0)
            .HeaderVisible = True
            .Header.Activated = True
            .Header.Caption = "Charges Summary From " & Me.DateFrom.DateValue.ToString & "  To:" & Me.DateTo.DateValue.ToString & " (Arrival Date)"
            .Header.Appearance.BackColor = Color.Maroon
            .Header.Appearance.ForeColor = Color.Yellow
            .Header.Appearance.FontData.Name = "Verdana"
            .Header.Appearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.True
            .Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
            .Header.Appearance.FontData.SizeInPoints = 8
        End With
        Me.UltraTabControl1.Tabs(1).Selected = True

    End Sub

    Private Sub ShowDcrGrid()

        Dim Ds As New DataSet
        Dim aChgs As New ArrayList
        Dim aUsers As New ArrayList
        Dim dr As DataRow

        Dim TB As New DataTable("Detail")
        Dim TbCurrency As New DataTable("Currency")
        Dim TbUsesr As New DataTable("Usesr")

        Dim Fld As String
        Dim Drs() As DataRow
        Dim NewRow As DataRow
        Dim DmDrs() As DataRow
        Dim DsDcr As New DataSet
        Dim Rl As DataRelation
        Dim PCol As DataColumn
        Dim cCol As DataColumn

        Dim PCols(1) As DataColumn
        Dim cCols(1) As DataColumn

        Dim nI As Byte

        Me.GridResult.DataSource = Nothing
        Me.Cursor = Cursors.WaitCursor
        Ds = StoredProcedures.SP_RptCDR(Me.DateFrom.GnrlDate.Value, Me.DateTo.GnrlDate.Value)
        Me.Cursor = Cursors.Default

        TB.Columns.Add(New DataColumn("InvoiceNo"))
        TB.Columns.Add(New DataColumn("BLNO"))
        TB.Columns.Add(New DataColumn("Client"))
        TB.Columns.Add(New DataColumn("UserName"))
        TB.Columns.Add(New DataColumn("Currency"))

        TbUsesr.Columns.Add(New DataColumn("UserName"))

        TbCurrency.Columns.Add(New DataColumn("UserName"))
        TbCurrency.Columns.Add(New DataColumn("Currency"))

        Drs = Ds.Tables(0).Select("", "ChargesCode")

        For Each dr In Drs

            If aChgs.IndexOf(dr("ChargesCode")) = -1 Then
                aChgs.Add(dr("ChargesCode"))
                Fld = dr("ChargesCode")
                TB.Columns.Add(New DataColumn(Fld, System.Type.GetType("System.Double")))
            End If

            If aUsers.IndexOf(dr("ConfirmBy")) = -1 Then
                aUsers.Add(dr("ConfirmBy"))
                NewRow = TbUsesr.NewRow
                NewRow("UserName") = dr("ConfirmBy")
                TbUsesr.Rows.Add(NewRow)
            End If
            DmDrs = TbCurrency.Select("UserName = '" & NullToValue(dr("ConfirmBy"), "???") & "' and Currency = '" & NullToValue(dr("Currency"), "???") & "'")
            If DmDrs.Length = 0 Then
                NewRow = TbCurrency.NewRow
                NewRow("UserName") = dr("ConfirmBy")
                NewRow("Currency") = dr("Currency")
                TbCurrency.Rows.Add(NewRow)
            End If
        Next

        For Each dr In Ds.Tables(0).Rows
            Drs = TB.Select("InvoiceNo = '" & dr("InvoiceNo") & "' and UserName = '" & dr("ConfirmBy") & "' and Currency = '" & dr("Currency") & "'")
            Fld = dr("ChargesCode")
            If Drs.Length = 0 Then
                NewRow = TB.NewRow
                NewRow("InvoiceNo") = dr("InvoiceNo")
                NewRow("BlNo") = dr("BlNo")
                NewRow("Client") = dr("lName")
                NewRow(Fld) = dr("ShowAmount")
                NewRow("UserName") = dr("ConfirmBy")
                NewRow("Currency") = dr("Currency")
                TB.Rows.Add(NewRow)
            Else
                Drs(0).Item(Fld) = dr("ShowAmount")
            End If
        Next

        DsDcr.Tables.Add(TbUsesr)
        DsDcr.Tables.Add(TbCurrency)
        DsDcr.Tables.Add(TB)
        PCol = TbUsesr.Columns("UserName")
        cCol = TbCurrency.Columns("UserName")

        Rl = New DataRelation("Users", PCol, cCol)
        DsDcr.Relations.Add(Rl)
        PCols(0) = TbCurrency.Columns("UserName")
        PCols(1) = TbCurrency.Columns("Currency")

        cCols(0) = TB.Columns("UserName")
        cCols(1) = TB.Columns("Currency")

        Rl = New DataRelation("Currency", PCols, cCols)
        Try
            DsDcr.Relations.Add(Rl)
        Catch ex As Exception
        End Try

        Me.GridResult.DataSource = DsDcr
        If aChgs.Count <> 0 Then
            With Me.GridResult.DisplayLayout
                .Bands(1).Columns("UserName").Hidden = True
                .Bands(2).Columns("UserName").Hidden = True
                .Bands(2).Columns("Currency").Hidden = True
                With .Bands(2)
                    For nI = 0 To aChgs.Count - 1
                        .Summaries.Add(aChgs.Item(nI), SummaryType.Sum, .Columns(aChgs.Item(nI)))
                    Next
                End With
            End With
            GridNumSeperator(Me.GridResult)
            With Me.GridResult.DisplayLayout.Bands(0)
                .HeaderVisible = True
                .Header.Activated = True
                .Header.Caption = "D.C.R. From " & Me.DateFrom.DateValue.ToString & "  To:" & Me.DateTo.DateValue.ToString
                .Header.Appearance.BackColor = Color.Maroon
                .Header.Appearance.ForeColor = Color.Yellow
                .Header.Appearance.FontData.Name = "Verdana"
                .Header.Appearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.True
                .Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                .Header.Appearance.FontData.SizeInPoints = 8
            End With
            Me.UltraTabControl1.Tabs(1).Selected = True
        End If


    End Sub

    Private Sub ShowTHCComapre()

        Dim dm As New DataManager(My.Settings.DSN)
        Dim Sof As DataTable
        Dim Voy As TB_Voyage
        Dim aList As New ArrayList
        Dim Dr As DataRow
        Dim Drs() As DataRow
        Dim Arvl As CLArrivalNotice
        Dim ThcData() As DataRow
        Dim ThcMNF() As DataRow

        Dim NewRow As DataRow

        Dim Tb As DataTable
        Tb = New DataTable

        Me.Cursor = Cursors.WaitCursor

        Try

            With Tb.Columns
                .Add(New DataColumn("BlNo"))
                .Add(New DataColumn("Vessel"))
                .Add(New DataColumn("VoyageNo"))
                .Add(New DataColumn("NoOfCntrs"))
                .Add(New DataColumn("THC", System.Type.GetType("System.Double")))
                .Add(New DataColumn("MNF THC", System.Type.GetType("System.Double")))

            End With


            dm.QueryCriteria.Clear()
            dm.QueryCriteria.And(JoinPath.TB_SOF.Columns.Arrival, Me.DateFrom.GnrlDate.Value, MatchType.GreaterOrEqual)
            dm.QueryCriteria.And(JoinPath.TB_SOF.Columns.Arrival, Me.DateTo.GnrlDate.Value, MatchType.LesserOrEqual)
            dm.GetTB_SOFCollection()
            Sof = dm.DataSet.Tables("TB_Sof")

            If Sof.Rows.Count = 0 Then
                MsgBoxGeneral("No any data to process !")
                Me.Cursor = Cursors.WaitCursor
                Exit Sub
            End If

            For Each Dr In Sof.Rows
                If aList.IndexOf(Dr("ID")) = -1 Then
                    aList.Add(Dr("ID"))
                End If
            Next


            For Each item As Object In aList
                dm = New DataManager(My.Settings.DSN)
                Drs = Sof.Select("ID = '" & item.ToString & "'")
                If Drs.Length > 0 Then

                    dm.QueryCriteria.Clear()
                    dm.QueryCriteria.And(JoinPath.TB_Voyage.Columns.ID, Drs(0).Item("VoyageID"), MatchType.Exact)
                    Voy = dm.GetTB_Voyage

                    dm.QueryCriteria.Clear()
                    dm.QueryCriteria.And(JoinPath.TB_Voyage.Columns.ID, dm.DataSet.Tables("TB_Voyage").Rows(0).Item("VesselID"), MatchType.Exact)
                    dm.GetTB_VesselsCollection()


                    dm.QueryCriteria.Clear()
                    dm.QueryCriteria.And(JoinPath.TB_InwardBLS.Columns.VoyageID, Drs(0).Item("VoyageID"), MatchType.Exact)
                    dm.GetTB_InwardBLSCollection()



                    For Each Dr In dm.DataSet.Tables("TB_InwardBls").Rows
                        dm.QueryCriteria.Clear()
                        dm.QueryCriteria.And(JoinPath.TB_InwardCharges.Columns.BLID, Dr("ID"), MatchType.Exact)
                        dm.QueryCriteria.And(JoinPath.TB_InwardCharges.Columns.ChargesCode, "THD", MatchType.Exact)
                        dm.GetTB_InwardChargesCollection()

                        Arvl = New CLArrivalNotice
                        Arvl.GenArrivalNotice(Dr, Drs(0).Item("Berthed"), Voy, True)
                        ThcData = Arvl.GetTBDetails.Select("ChargeItem = 'THC'")
                        NewRow = Tb.NewRow
                        NewRow("BlNo") = Dr("BLNO")
                        NewRow("Vessel") = dm.DataSet.Tables("TB_Vessels").Rows(0).Item("VesselName")
                        NewRow("VoyageNo") = dm.DataSet.Tables("TB_Voyage").Rows(0).Item("VoyageNo")
                        NewRow("THC") = ThcData(0).Item("ActualAmount")
                        ThcMNF = dm.DataSet.Tables("TB_InwardCharges").Select("BLID = '" & Dr("ID").ToString & "'")
                        For Each R As DataRow In ThcMNF
                            NewRow("MNF THC") = NullToValue(NewRow("MNF THC"), 0) + R("Amount")
                        Next
                        NewRow("NoOfCntrs") = Arvl.Master.Rows(0).Item("TotalContainers")


                        Tb.Rows.Add(NewRow)
                    Next
                End If
            Next
            Me.GridResult.DataSource = Tb
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Me.UltraTabControl1.Tabs(1).Selected = True
        Me.Cursor = Cursors.Default

    End Sub
    Private Sub CollectListByDate()

        Dim Cmd As New SqlCommand("SP_CollectListByDate")
        Dim Cnn As New SqlConnection(My.Settings.DSN)
        Dim DA As New SqlDataAdapter
        Dim Tb As New DataTable
        Me.Cursor = Cursors.WaitCursor
        With Cmd
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Parameters.AddWithValue("@dFrom", Me.DateFrom.GnrlDate.Value)
            Cmd.Parameters.AddWithValue("@dTo", Me.DateTo.GnrlDate.Value)
            Cmd.Parameters.AddWithValue("@Line", CurrentShippingLine)
            Cmd.Connection = Cnn
        End With
        DA.SelectCommand = Cmd
        DA.Fill(Tb)
        Me.GridResult.DataSource = Tb
        Me.UltraTabControl1.Tabs(1).Selected = True
        Me.Cursor = Cursors.Default

    End Sub
     Private Sub ShowTHCList()
 
        Dim Ds As New DataSet
         Dim arrayParams As New ArrayList
        Dim DD As Date
        Dim Dm As New DataManager(My.Settings.DSN)
        Dim TB As New DataTable
        Dim DA As New SqlDataAdapter
        Dim Cmd As New SqlCommand()
        Dim Cnn As New SqlConnection
        Dim SOF As TB_SOF
        Dim DTN As CLDetention
        Dim Bls As New DataTable
        Dim Drs() As DataRow
        Dim NewDr As DataRow
        Dim CnDrs() As DataRow
        Dim CnDr As DataRow
        Dim DsDetn As DataSet

        Cnn.ConnectionString = My.Settings.DSN
        Cnn.Open()

        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_SOF.Columns.VoyageID, Me.FVoyage.VoyageID, MatchType.Exact)
        SOF = Dm.GetTB_SOF

        If SOF Is Nothing Then
            MsgBox("No SOF Data For This Voyage !")
            Exit Sub
        End If

        If IsDBNull(SOF.DschCmnc) Then
            MsgBox("Discharge Commence Is Empty !")
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor

        With Cmd
            .CommandText = "SP_OutwardTHCByVoyageID"
            .Connection = Cnn
            .Parameters.AddWithValue("@VoyageID", Me.FVoyage.VoyageID)
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 400
        End With

        DA = New SqlDataAdapter(Cmd)
        DA.Fill(Ds)

        For Each dr As DataRow In Ds.Tables(0).Rows
            If dr("Line") <> CurrentShippingLine Then
                dr.Delete()
            End If
        Next


        TB = Ds.Tables(0)

        'For Each dr In TB
        '    TB.ImportRow(dr)
        'Next

        'Bls = New DataTable
        'Bls.Columns.Add(New DataColumn("Line"))
        'Bls.Columns.Add(New DataColumn("BLNO"))
        'Bls.Columns.Add(New DataColumn("BLID", System.Type.GetType("System.Guid")))

        'TB.Columns.Add(New DataColumn("Detention", System.Type.GetType("System.Double")))

        TB.AcceptChanges()

        'For Each dr In TB.Rows
        '    If Not IsDBNull(dr("BLID")) Then
        '        Drs = Bls.Select("Line = '" & dr("Line") & "' and BLNo = '" & dr("BLNO") & "'")
        '        If Drs.Count = 0 Then
        '            NewDr = Bls.NewRow
        '            NewDr("Line") = dr("Line")
        '            NewDr("BLNO") = dr("BLNO")
        '            NewDr("BLID") = dr("BLID")
        '            Bls.Rows.Add(NewDr)
        '        End If
        '    End If
        'Next

        'For Each dr In Bls.Rows
        '    DTN = New CLDetention
        '    DsDetn = DTN.CalExpDetention(dr("BLNO"), dr("BLID"), False)
        '    For Each CnDr In DsDetn.Tables(1).Rows
        '        CnDrs = TB.Select("CntrNo = '" & CnDr("CntrNo") & "'")
        '        If CnDrs.Length > 0 Then
        '            CnDrs(0).Item("Detention") = CnDr("Detention")
        '        End If
        '    Next
        ' Next

        If TB.Rows.Count = 0 Then
            MsgBox("No any data !")
            Me.GridResult.DataSource = TB
            Me.Cursor = Cursors.Default
            Exit Sub
        Else
            Me.GridResult.DataSource = TB
            GridNumSeperator(Me.GridResult)
            With Me.GridResult.DisplayLayout.Bands(0)
                .HeaderVisible = True
                .Header.Activated = True
                .Header.Caption = "OutWard THC LIST " & Me.FVoyage.VesselName & " " & Me.FVoyage.CmbVoyage.Text
                .Header.Appearance.BackColor = Color.Maroon
                .Header.Appearance.ForeColor = Color.Yellow
                .Header.Appearance.FontData.Name = "Verdana"
                .Header.Appearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.True
                .Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                .Header.Appearance.FontData.SizeInPoints = 8
            End With
        End If
        Me.Cursor = Cursors.Default
        Me.UltraTabControl1.Tabs(1).Selected = True

    End Sub

    Private Sub ShowInTHCList()

        Dim Ds As New DataSet
        Dim arrayParams As New ArrayList
        Dim DD As Date
        Dim Dm As New DataManager(My.Settings.DSN)
        Dim TB As New DataTable
        Dim DA As New SqlDataAdapter
        Dim Cmd As New SqlCommand()
        Dim Cnn As New SqlConnection
        Dim SOF As TB_SOF
        Dim DTN As CLDetention
        Dim Bls As New DataTable
        Dim Drs() As DataRow
        Dim NewDr As DataRow
        Dim CnDrs() As DataRow
        Dim CnDr As DataRow
        Dim DsDetn As DataSet

        Cnn.ConnectionString = My.Settings.DSN
        Cnn.Open()

        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_SOF.Columns.VoyageID, Me.FVoyage.VoyageID, MatchType.Exact)
        SOF = Dm.GetTB_SOF

        If SOF Is Nothing Then
            MsgBox("No SOF Data For This Voyage !")
            Exit Sub
        End If

        If IsDBNull(SOF.DschCmnc) Then
            MsgBox("Discharge Commence Is Empty !")
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor

        With Cmd
            .CommandText = "SP_InwardTHCByVoyageID"
            .Connection = Cnn
            .Parameters.AddWithValue("@VoyageID", Me.FVoyage.VoyageID)
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 400
        End With

        DA = New SqlDataAdapter(Cmd)
        DA.Fill(Ds)

        For Each dr As DataRow In Ds.Tables(0).Rows
            If dr("Line") <> CurrentShippingLine Then
                dr.Delete()
            End If
        Next


        TB = Ds.Tables(0)

        TB.AcceptChanges()

        If TB.Rows.Count = 0 Then
            MsgBox("No any data !")
            Me.GridResult.DataSource = TB
            Me.Cursor = Cursors.Default
            Exit Sub
        Else
            Me.GridResult.DataSource = TB
            GridNumSeperator(Me.GridResult)
            With Me.GridResult.DisplayLayout.Bands(0)
                .HeaderVisible = True
                .Header.Activated = True
                .Header.Caption = "Inward THC LIST " & Me.FVoyage.VesselName & " " & Me.FVoyage.CmbVoyage.Text
                .Header.Appearance.BackColor = Color.Maroon
                .Header.Appearance.ForeColor = Color.Yellow
                .Header.Appearance.FontData.Name = "Verdana"
                .Header.Appearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.True
                .Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                .Header.Appearance.FontData.SizeInPoints = 8
            End With
        End If
        Me.Cursor = Cursors.Default
        Me.UltraTabControl1.Tabs(1).Selected = True

    End Sub

    Private Sub ShowStatusAllCntr()

        Dim ds As New DataSet
        Dim Dr As DataRow
        Dim Rows() As DataRow
        Dim Row As DataRow
        Dim DPC As ClDetentionPerCntr
        Dim Temp As DataTable
        Dim Title As String = "ALL Status (Container Wise)"
        Dim DTNdrs() As DataRow
        Dim TbResult As New DataTable

        Dim Cmd As New SqlClient.SqlCommand
        Dim Cnn As New SqlClient.SqlConnection(My.Settings.DSN)
        Dim DA As New SqlDataAdapter

        Cnn.Open()
        Cmd.CommandText = "SP_DetentionGnrlReportForLine"
        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.CommandTimeout = 5000
        Cmd.Parameters.AddWithValue("@Line", CurrentShippingLine)
        Cmd.Parameters.AddWithValue("@Type", 0)
        Cmd.Connection = Cnn

        Cmd.Connection = Cnn

        'If Boolean.Parse(CurrentUser.IsDocAdmin) = True Or Boolean.Parse(CurrentUser.IsEcsAdmin) = True Then
        '    If MsgBox("Do You Want To Get Report Base On To line Data ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
        '        Cmd.CommandText = "SP_DetentionGnrlReportForLine"
        '        Title = "ALL Status (Container Wise) [For Line]"
        '    End If
        'End If

        Me.Cursor = Cursors.WaitCursor
        DA.SelectCommand = Cmd
        DA.Fill(ds)

        'Rows = ds.Tables(0).Select("(not FirstEa is null) or DoAmount = 0")
        'For Each Row In Rows
        '    Row.Delete()
        'Next
        ds.AcceptChanges()

        ds.Tables(1).Columns.Add(New DataColumn("BLNO"))
        ds.Tables(1).Columns.Add(New DataColumn("FreeDays", System.Type.GetType("System.Int64")))
        ds.Tables(1).Columns.Add(New DataColumn("Discount", System.Type.GetType("System.Int64")))
        ds.Tables(1).Columns.Add(New DataColumn("Detention", System.Type.GetType("System.Int64")))
        ds.Tables(1).Columns.Add(New DataColumn("Vessel"))
        ds.Tables(1).Columns.Add(New DataColumn("Voyage"))
        ds.Tables(1).Columns.Add(New DataColumn("Client"))
        ds.Tables(1).Columns.Add(New DataColumn("TotalDays", System.Type.GetType("System.Int64")))

        For Each Dr In ds.Tables(0).Rows
            Rows = ds.Tables(1).Select("ID = '" & Dr("ID").ToString & "'")
            DPC = New ClDetentionPerCntr
            For Each Row In Rows
                Temp = DPC.DetentionPerCntr("I", Row("CnSize"), Row("Cntype"), NullToValue(Row("DF"), Now), NullToValue(Row("EA"), Now), Row("ID").ToString, Int16.Parse(Row("LCLCount").ToString), Row("WgtPercent"), Row("CntrNo"))
                DTNdrs = DPC.CntrsTB.Select("CntrNo = '" & Row.Item("CntrNo") & "'")
                If DTNdrs.Length > 0 Then
                    Row.Item("BLNO") = Dr("BLNO")
                    Row.Item("FreeDays") = DTNdrs(0).Item("FreeDays")
                    Row.Item("Discount") = DTNdrs(0).Item("Discount")
                    Row.Item("Detention") = DTNdrs(0).Item("Detention")
                    Row.Item("TotalDays") = DTNdrs(0).Item("Totaldays")
                    Row.Item("Vessel") = Dr("Vessel")
                    Row.Item("Voyage") = Dr("Voyage")
                    Row.Item("Client") = Dr("Client")
                Else
                    Beep()
                End If
            Next

            'Dr("Detention") = DPC.GetTotaldetention
            'Dr("Discount") = DPC.GetTotalDiscount
            'Dr("Balance") = DPC.GetTotaldetention - DPC.GetTotalDiscount
        Next


        TbResult.Columns.Add(New DataColumn("BLNO"))
        TbResult.Columns.Add(New DataColumn("CntrNo"))
        TbResult.Columns.Add(New DataColumn("Voyage"))
        TbResult.Columns.Add(New DataColumn("Vessel"))
        TbResult.Columns.Add(New DataColumn("CnSize"))
        TbResult.Columns.Add(New DataColumn("CnType"))
        '  TbResult.Columns.Add(New DataColumn("SOC"))
        TbResult.Columns.Add(New DataColumn("DF", System.Type.GetType("System.DateTime")))
        TbResult.Columns.Add(New DataColumn("EA", System.Type.GetType("System.DateTime")))
        TbResult.Columns.Add(New DataColumn("TotalDays", System.Type.GetType("System.Int16")))
        TbResult.Columns.Add(New DataColumn("FreeDays", System.Type.GetType("System.Int64")))
        TbResult.Columns.Add(New DataColumn("Discount", System.Type.GetType("System.Int64")))
        TbResult.Columns.Add(New DataColumn("Detention", System.Type.GetType("System.Int64")))
        TbResult.Columns.Add(New DataColumn("LCLCount", System.Type.GetType("System.Int16")))
        TbResult.Columns.Add(New DataColumn("Client"))
        TbResult.Columns.Add(New DataColumn("POL"))
        TbResult.Columns.Add(New DataColumn("POD"))
        TbResult.Columns.Add(New DataColumn("LINE"))
        TbResult.Columns.Add(New DataColumn("DamageCost", System.Type.GetType("System.Double")))
        TbResult.Columns.Add(New DataColumn("InvoiceNo", System.Type.GetType("System.String")))

        'Id , discharge , LastEA , FirstEA , DoAmount , FirstPaid , Balance , ID 
        ds.Tables(1).Columns.Remove("ID")
        ds.Tables(1).Columns.Remove("VoyageID")
        ds.Tables(1).Columns.Remove("WGTPercent")
        ' ds.Tables(1).Columns.Remove("SOC")


        For Each Row In ds.Tables(1).Rows
            Dr = TbResult.NewRow
            For Each col As DataColumn In ds.Tables(1).Columns
                Dr.Item(col.ColumnName) = Row.Item(col.ColumnName)
            Next
            TbResult.Rows.Add(Dr)
        Next

        For Each Dr In ds.Tables(1).Rows
            Rows = ds.Tables(0).Select("BLNO = '" & Dr("BLNO") & "'")
            If Rows.Length > 0 Then
                Dr("InvoiceNo") = Rows(0).Item("InvoiceNo")
            End If
        Next

        Me.GridResult.DataSource = ds.Tables(1) ' TbResult

        With Me.GridResult.DisplayLayout.Bands(0)
            .HeaderVisible = True
            .Header.Activated = True
            .Header.Caption = Title
            .Header.Appearance.BackColor = Color.Maroon
            .Header.Appearance.ForeColor = Color.Yellow
            .Header.Appearance.FontData.Name = "Verdana"
            .Header.Appearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.True
            .Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
            .Header.Appearance.FontData.SizeInPoints = 8
        End With

        GridNumSeperator(Me.GridResult)
        Me.Cursor = Cursors.Default
        Me.UltraTabControl1.Tabs(1).Selected = True

    End Sub

    Private Sub DemurrageControl()

        Dim Cmd As SqlCommand
        Dim Cnn As SqlConnection
        Dim DS As New DataSet
        Dim DA As New SqlDataAdapter
        Dim TB As New DataTable
        Dim Detn As New CLDetention
        Dim CalBase As New CLCalculationBase
        Dim Tax As Double



        Me.Cursor = Cursors.WaitCursor
        Cmd = New SqlCommand("SP_DemurrageControlByIssueTime")
        Cnn = New SqlConnection(My.Settings.DSN)
        Cnn.Open()
        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.Parameters.AddWithValue("@Line", CurrentShippingLine)
        Cmd.Parameters.AddWithValue("@dFrom", Me.DateFrom.GnrlDate.Value)
        Cmd.Parameters.AddWithValue("@dTO", Me.DateTo.GnrlDate.Value)
        Cmd.Connection = Cnn
        DA.SelectCommand = Cmd
        DA.Fill(TB)


        Me.Cursor = Cursors.Default

        For Each Dr In TB.Rows
            DS = Detn.CalDetention(Dr("BLNO"), Dr("ID"), False)
            CalBase.GetTaxDutyInward(Dr("ID"), "DETN")

            If NullToValue(Dr("ConfirmTime"), Now) >= "2013-12-01" And NullToValue(Dr("ConfirmTime"), Now) <= "2014-03-17" Then
                Tax = 0
            Else
                Tax = CalBase.Tax + CalBase.Duty
            End If
            Dr("Paid") = Detn.Paid + (Detn.Paid * Tax / 100) + Detn.FirstPaid
            Dr("TTLDetention") = Detn.TotalAmount - Detn.TotalDiscount
            Dr("TTLDetention") += Dr("TTLDetention") * Tax / 100
            'If NullToValue(Dr("TTLDetention"), 0) - (Detn.Paid + Detn.TotalDiscount + Detn.FirstPaid) = NullToValue(Dr("Cash Deposit"), 0) Then
            If Dr("AllContainerReturnBack") = "YES" And Dr("Paid") <> Dr("TTLDetention") Then
                Dr("Outstanding Amount") = Detn.Balance + Detn.TaxAmount
            Else
                Dr("Outstanding Amount") = Detn.Balance
            End If
            'NullToValue(Dr("TTLDetention"), 0) - (Dr("Paid") + Detn.FirstPaid) - NullToValue(Dr("Cash Deposit"), 0)
        Next


        Me.GridResult.DataSource = TB
        GridNumSeperator(Me.GridResult)

        With Me.GridResult.DisplayLayout.Bands(0)
            .HeaderVisible = True
            .Header.Activated = True
            .Header.Caption = "Demurrage Control From: " & Format(Me.DateFrom.GnrlDate.Value, "short date") & " To:" & Format(Me.DateTo.GnrlDate.Value.ToString, "short date")
            .Header.Appearance.BackColor = Color.Maroon
            .Header.Appearance.ForeColor = Color.Yellow
            .Header.Appearance.FontData.Name = "Verdana"
            .Header.Appearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.True
            .Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
            .Header.Appearance.FontData.SizeInPoints = 8
        End With

        Me.Cursor = Cursors.Default
        Me.UltraTabControl1.Tabs(1).Selected = True

    End Sub

    Private Sub TopClientByLineDate()

        Dim Cmd As New SqlCommand("SP_TopClientByLineDate")
        Dim Cnn As New SqlConnection(My.Settings.DSN)
        Dim DA As New SqlDataAdapter
        Dim Tb As New DataTable
        Me.Cursor = Cursors.WaitCursor
        With Cmd
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Parameters.AddWithValue("@dFrom", Me.DateFrom.GnrlDate.Value)
            Cmd.Parameters.AddWithValue("@dTo", Me.DateTo.GnrlDate.Value)
            Cmd.Parameters.AddWithValue("@Line", CurrentShippingLine)
            Cmd.Connection = Cnn
        End With
        DA.SelectCommand = Cmd
        DA.Fill(Tb)
        Me.GridResult.DataSource = Tb
        Me.UltraTabControl1.Tabs(1).Selected = True
        Me.Cursor = Cursors.Default

        Me.GridResult.DataSource = Tb
        GridNumSeperator(Me.GridResult)

        With Me.GridResult.DisplayLayout.Bands(0)
            .HeaderVisible = True
            .Header.Activated = True
            .Header.Caption = "Top Client From: " & Format(Me.DateFrom.GnrlDate.Value, "short date") & " To:" & Format(Me.DateTo.GnrlDate.Value.ToString, "short date")
            .Header.Appearance.BackColor = Color.Maroon
            .Header.Appearance.ForeColor = Color.Yellow
            .Header.Appearance.FontData.Name = "Verdana"
            .Header.Appearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.True
            .Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
            .Header.Appearance.FontData.SizeInPoints = 8
        End With

        Me.Cursor = Cursors.Default
        Me.UltraTabControl1.Tabs(1).Selected = True



    End Sub

    Private Sub SeasonReport()

        Dim Cmd As New SqlCommand("SP_SeasonReportByDateLine")
        Dim Cnn As New SqlConnection(My.Settings.DSN)
        Dim DA As New SqlDataAdapter
        Dim Tb As New DataTable
        Me.Cursor = Cursors.WaitCursor
        With Cmd
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Parameters.AddWithValue("@dFrom", Me.DateFrom.GnrlDate.Value)
            Cmd.Parameters.AddWithValue("@dTo", Me.DateTo.GnrlDate.Value)
            Cmd.Parameters.AddWithValue("@Line", CurrentShippingLine)
            Cmd.Connection = Cnn
        End With
        DA.SelectCommand = Cmd
        DA.Fill(Tb)
        Me.GridResult.DataSource = Tb
        Me.UltraTabControl1.Tabs(1).Selected = True
        Me.Cursor = Cursors.Default

        Me.GridResult.DataSource = Tb
        GridNumSeperator(Me.GridResult)

        With Me.GridResult.DisplayLayout.Bands(0)
            .HeaderVisible = True
            .Header.Activated = True
            .Header.Caption = "Season Report: " & Format(Me.DateFrom.GnrlDate.Value, "short date") & " To:" & Format(Me.DateTo.GnrlDate.Value.ToString, "short date")
            .Header.Appearance.BackColor = Color.Maroon
            .Header.Appearance.ForeColor = Color.Yellow
            .Header.Appearance.FontData.Name = "Verdana"
            .Header.Appearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.True
            .Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
            .Header.Appearance.FontData.SizeInPoints = 8
        End With

        Me.Cursor = Cursors.Default
        Me.UltraTabControl1.Tabs(1).Selected = True

    End Sub
    Private Sub OFTRecivedItems()

        Dim Cmd As New SqlCommand("SP_RecivedItemsOFTbyConfirmTime")
        Dim Cnn As New SqlConnection(My.Settings.DSN)
        Dim DA As New SqlDataAdapter
        Dim Tb As New DataTable
        Me.Cursor = Cursors.WaitCursor
        With Cmd
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Parameters.AddWithValue("@dFrom", Me.DateFrom.GnrlDate.Value)
            Cmd.Parameters.AddWithValue("@dTo", Me.DateTo.GnrlDate.Value)
            Cmd.Parameters.AddWithValue("@Line", CurrentShippingLine)
            Cmd.Connection = Cnn
        End With
        DA.SelectCommand = Cmd
        DA.Fill(Tb)
        Me.GridResult.DataSource = Tb
        Me.UltraTabControl1.Tabs(1).Selected = True
        Me.Cursor = Cursors.Default

        Me.GridResult.DataSource = Tb
        GridNumSeperator(Me.GridResult)

        With Me.GridResult.DisplayLayout.Bands(0)
            .HeaderVisible = True
            .Header.Activated = True
            .Header.Caption = "OFT RecivedItems: " & Format(Me.DateFrom.GnrlDate.Value, "short date") & " To:" & Format(Me.DateTo.GnrlDate.Value.ToString, "short date")
            .Header.Appearance.BackColor = Color.Maroon
            .Header.Appearance.ForeColor = Color.Yellow
            .Header.Appearance.FontData.Name = "Verdana"
            .Header.Appearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.True
            .Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
            .Header.Appearance.FontData.SizeInPoints = 8
        End With

        Me.Cursor = Cursors.Default
        Me.UltraTabControl1.Tabs(1).Selected = True

    End Sub

    Private Sub TotalDeposit()

        Dim Cmd As SqlCommand
        Dim Cnn As SqlConnection
        Dim DS As New DataSet
        Dim DA As New SqlDataAdapter
        Dim TB As New DataTable
        Dim Detn As New CLDetention
        Dim CalBase As New CLCalculationBase
        Dim Tax As Double



        Me.Cursor = Cursors.WaitCursor
        Cmd = New SqlCommand("SP_TotalDetentionDepositBYClientID")
        Cnn = New SqlConnection(My.Settings.DSN)
        Cnn.Open()
        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.CommandTimeout = 5000
        Cmd.Parameters.AddWithValue("@Clnt", Me.Clients.ClientID)
        Cmd.Parameters.AddWithValue("@Line", CurrentShippingLine)
        Cmd.Connection = Cnn
        DA.SelectCommand = Cmd
        DA.Fill(TB)


        Me.Cursor = Cursors.Default

        For Each Dr In TB.Rows
            DS = Detn.CalDetention(Dr("BLNO"), Dr("ID"), False)
            CalBase.GetTaxDutyInward(Dr("ID"), "DETN")

            Dr("Detention") = Detn.TotalAmount - Detn.TotalDiscount
        Next


        Me.GridResult.DataSource = TB
        GridNumSeperator(Me.GridResult)

        With Me.GridResult.DisplayLayout.Bands(0)
            .HeaderVisible = True
            .Header.Activated = True
            .Header.Caption = "Total Deposit: " & Format(Me.Clients.ClientName)
            .Header.Appearance.BackColor = Color.Maroon
            .Header.Appearance.ForeColor = Color.Yellow
            .Header.Appearance.FontData.Name = "Verdana"
            .Header.Appearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.True
            .Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
            .Header.Appearance.FontData.SizeInPoints = 8
        End With

        Me.Cursor = Cursors.Default
        Me.UltraTabControl1.Tabs(1).Selected = True


    End Sub
    Private Sub TopClientSummery()

        Dim Cmd As New SqlCommand("SP_TopClientSummery")
        Dim Cnn As New SqlConnection(My.Settings.DSN)
        Dim DA As New SqlDataAdapter
        Dim Tb As New DataTable
        Me.Cursor = Cursors.WaitCursor
        With Cmd
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Parameters.AddWithValue("@dFrom", Me.DateFrom.GnrlDate.Value)
            Cmd.Parameters.AddWithValue("@dTo", Me.DateTo.GnrlDate.Value)
            Cmd.Parameters.AddWithValue("@Line", CurrentShippingLine)
            Cmd.Connection = Cnn
        End With
        DA.SelectCommand = Cmd
        DA.Fill(Tb)
        Me.GridResult.DataSource = Tb
        Me.UltraTabControl1.Tabs(1).Selected = True
        Me.Cursor = Cursors.Default

        Me.GridResult.DataSource = Tb
        GridNumSeperator(Me.GridResult)

        With Me.GridResult.DisplayLayout.Bands(0)
            .HeaderVisible = True
            .Header.Activated = True
            .Header.Caption = "Top Client Summery From: " & Format(Me.DateFrom.GnrlDate.Value, "short date") & " To:" & Format(Me.DateTo.GnrlDate.Value.ToString, "short date")
            .Header.Appearance.BackColor = Color.Maroon
            .Header.Appearance.ForeColor = Color.Yellow
            .Header.Appearance.FontData.Name = "Verdana"
            .Header.Appearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.True
            .Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
            .Header.Appearance.FontData.SizeInPoints = 8
        End With

        Me.Cursor = Cursors.Default
        Me.UltraTabControl1.Tabs(1).Selected = True

    End Sub
    Private Sub ShowClientEXPStatus()

        Dim Cmd As New SqlCommand("SP_OutwardCleintStatus")
        Dim Cnn As New SqlConnection(My.Settings.DSN)
        Dim DA As New SqlDataAdapter
        Dim Tb As New DataTable
        Me.Cursor = Cursors.WaitCursor
        With Cmd
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Parameters.AddWithValue("@ClientID", Me.Clients.ClientID)
            Cmd.Connection = Cnn
        End With
        DA.SelectCommand = Cmd
        DA.Fill(Tb)
        Me.GridResult.DataSource = Tb
        Me.UltraTabControl1.Tabs(1).Selected = True
        Me.Cursor = Cursors.Default

        Me.GridResult.DataSource = Tb
        GridNumSeperator(Me.GridResult)

        With Me.GridResult.DisplayLayout.Bands(0)
            .HeaderVisible = True
            .Header.Activated = True
            .Header.Caption = "Client EXP-Statistics For:" & Me.Clients.Text
            .Header.Appearance.BackColor = Color.Maroon
            .Header.Appearance.ForeColor = Color.Yellow
            .Header.Appearance.FontData.Name = "Verdana"
            .Header.Appearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.True
            .Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
            .Header.Appearance.FontData.SizeInPoints = 8
        End With

        Me.Cursor = Cursors.Default
        Me.UltraTabControl1.Tabs(1).Selected = True

    End Sub

End Class

