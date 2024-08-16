Imports ShippingBiz
Imports OrmLib
Imports System.Data.SqlClient


Public Class FrmInvoiceTrace

    Private Dm As DataManager
    Private Sub FrmInvoiceTrace_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Top = 0
        Me.Left = 0

        InitTemp()
        Me.DateFrom.InitControl(False, False)
        Me.DateTo.InitControl(False, False)
        Me.CmbStatus.InitControl("IS", UserComboCode.ShowCoumn.Meaning)

        With Me.GridImport
            .DisplayLayout.Bands(0).Columns("ID").Hidden = True
            .DisplayLayout.Bands(0).Columns("BLID").Hidden = True
            .DisplayLayout.Bands(0).Columns("Status").Hidden = True
        End With

        With Me.GridInvExport
            .DisplayLayout.Bands(0).Columns("ID").Hidden = True
            .DisplayLayout.Bands(0).Columns("BLID").Hidden = True
            .DisplayLayout.Bands(0).Columns("Status").Hidden = True
        End With

        Me.DateFrom.GnrlDate.Value = Now
        Me.DateTo.GnrlDate.Value = Now

        Me.CmbStatus.AddItemOutSide("ALL", "ALL", "")
        Me.CmbStatus.Code = "ALL"


    End Sub

    Private Sub CloseButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub
    Private Sub ButtonRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRefresh.Click

        Dim ds As New DataSet
        Dim Dr As DataRow
        Me.DataSetForm.Tables(0).Clear()
        Me.DataSetForm.Tables(1).Clear()

        Dim Cmd As New SqlCommand
        Dim Cnn As New SqlConnection(My.Settings.DSN)
        Dim DA As New SqlDataAdapter

        With Cmd
            .CommandText = "SP_InvoiceList"
            .CommandType = CommandType.StoredProcedure
            .Connection = Cnn
            .CommandTimeout = 5000
            .Parameters.AddWithValue("@DFrom", Date.Parse(Me.DateFrom.DateValue).Date)
            .Parameters.AddWithValue("@DTo", Date.Parse(DateTo.DateValue).Date)
            .Parameters.AddWithValue("@Status", Me.CmbStatus.Code)
            .Parameters.AddWithValue("@IsByIssueTime", IIf(Me.CheckIsIssueTime.Checked = True, "Y", "N"))
            .Parameters.AddWithValue("@Line", CurrentShippingLine)
        End With
        DA.SelectCommand = Cmd
        DA.Fill(ds)

        For Each Dr In ds.Tables(0).Rows
            Me.DataSetForm.Tables(0).ImportRow(Dr)

        Next

        For Each Dr In ds.Tables(1).Rows
            Me.DataSetForm.Tables(1).ImportRow(Dr)

        Next

        For Each Dr In ds.Tables(0).Rows
            Dr("Sel") = False
        Next

        For Each Dr In ds.Tables(1).Rows
            Dr("Sel") = False
        Next

        GridNumSeperator(Me.GridInvExport)
        GridNumSeperator(Me.GridImport)

    End Sub
    Private Sub ToClientButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToDocButton.Click


        Dim R As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim IO As InOut
        If TabControl.SelectedIndex = 0 Then
            If GridImport.Rows.Count > 0 Then
                R = GridImport.ActiveRow
                IO = InOut.InWard
            End If
        Else
            If GridInvExport.Rows.Count > 0 Then
                R = GridInvExport.ActiveRow
                IO = InOut.OutWard
            End If
        End If

        If R Is Nothing Then
            Exit Sub
        End If

        If Double.Parse(R.Cells("Status").Value) = InvoiceStatus.ToAccount Then
            If MsgBox("Are You Sure To Send Back Invoice ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                ChangeStatus(IO, InvoiceStatus.Issue, R)
            End If
        Else
            MsgBoxGeneral("Not Allow", "Validate Error")
            Exit Sub
        End If

    End Sub

    Private Sub InitTemp()

        Dim Tb As DataTable
        Tb = New DataTable("TB_Invoice")

        Tb.Columns.Add(New DataColumn("BLNO", System.Type.GetType("System.String")))
        Tb.Columns.Add(New DataColumn("ID", System.Type.GetType("System.Guid")))
        Tb.Columns.Add(New DataColumn("BLID", System.Type.GetType("System.Guid")))
        Tb.Columns.Add(New DataColumn("InvoiceNo", System.Type.GetType("System.String")))
        Tb.Columns.Add(New DataColumn("Description", System.Type.GetType("System.String")))
        Tb.Columns.Add(New DataColumn("IssueTime", System.Type.GetType("System.DateTime")))
        Tb.Columns.Add(New DataColumn("IssueBy", System.Type.GetType("System.String")))
        Tb.Columns.Add(New DataColumn("ConfirmTime", System.Type.GetType("System.DateTime")))
        Tb.Columns.Add(New DataColumn("ConfirmBy", System.Type.GetType("System.String")))
        Tb.Columns.Add(New DataColumn("Status", System.Type.GetType("System.String")))
        Tb.Columns.Add(New DataColumn("IssueOffice", System.Type.GetType("System.String")))
        Tb.Columns.Add(New DataColumn("IrrAmount", System.Type.GetType("System.Double")))
        Tb.Columns.Add(New DataColumn("UsdAmount", System.Type.GetType("System.Double")))
        Tb.Columns.Add(New DataColumn("InvStatus", System.Type.GetType("System.String")))
        Tb.Columns.Add(New DataColumn("Clients", System.Type.GetType("System.String")))
        Tb.Columns.Add(New DataColumn("TOTAL RCVD IRR", System.Type.GetType("System.Double")))
        Tb.Columns.Add(New DataColumn("TOTAL RCVD USD", System.Type.GetType("System.Double")))
        Tb.Columns.Add(New DataColumn("Sel", System.Type.GetType("System.Boolean")))


        Me.DataSetForm.Tables.Add(Tb)

        Tb = New DataTable("TB_ExpInvoice")
        Tb.Columns.Add(New DataColumn("BLNO", System.Type.GetType("System.String")))
        Tb.Columns.Add(New DataColumn("ID", System.Type.GetType("System.Guid")))
        Tb.Columns.Add(New DataColumn("BLID", System.Type.GetType("System.Guid")))
        Tb.Columns.Add(New DataColumn("InvoiceNo", System.Type.GetType("System.String")))
        Tb.Columns.Add(New DataColumn("Description", System.Type.GetType("System.String")))
        Tb.Columns.Add(New DataColumn("IssueTime", System.Type.GetType("System.DateTime")))
        Tb.Columns.Add(New DataColumn("IssueBy", System.Type.GetType("System.String")))
        Tb.Columns.Add(New DataColumn("ConfirmTime", System.Type.GetType("System.DateTime")))
        Tb.Columns.Add(New DataColumn("ConfirmBy", System.Type.GetType("System.String")))
        Tb.Columns.Add(New DataColumn("Status", System.Type.GetType("System.String")))
        Tb.Columns.Add(New DataColumn("IssueOffice", System.Type.GetType("System.String")))
        Tb.Columns.Add(New DataColumn("IrrAmount", System.Type.GetType("System.Double")))
        Tb.Columns.Add(New DataColumn("UsdAmount", System.Type.GetType("System.Double")))
        Tb.Columns.Add(New DataColumn("InvStatus", System.Type.GetType("System.String")))
        Tb.Columns.Add(New DataColumn("Clients", System.Type.GetType("System.String")))
        Tb.Columns.Add(New DataColumn("TOTAL RCVD IRR", System.Type.GetType("System.Double")))
        Tb.Columns.Add(New DataColumn("TOTAL RCVD USD", System.Type.GetType("System.Double")))
        Tb.Columns.Add(New DataColumn("Sel", System.Type.GetType("System.Boolean")))

        Me.DataSetForm.Tables.Add(Tb)


        Me.GridImport.DataSource = DataSetForm.Tables("TB_Invoice")
        Me.GridInvExport.DataSource = DataSetForm.Tables("TB_ExpInvoice")


    End Sub
    Private Sub ChangeStatus(ByVal IO As InOut, ByVal NewStatus As InvoiceStatus, ByVal R As Infragistics.Win.UltraWinGrid.UltraGridRow)

        Dim LogDataSet As New DataSet
        Dm = New DataManager(My.Settings.DSN)

        If IO = InOut.InWard Then
            Dm.QueryCriteria.And(JoinPath.TB_Invoice.Columns.ID, R.Cells("ID").Value, MatchType.Exact)
            Dm.GetTB_Invoice()
            If Dm.DataSet.Tables("TB_Invoice").Rows.Count = 0 Then
                Exit Sub
            End If
        End If

        If IO = InOut.OutWard Then
            Dm.QueryCriteria.And(JoinPath.TB_ExpInvoice.Columns.ID, R.Cells("ID").Value, MatchType.Exact)
            Dm.GetTB_ExpInvoice()

            If Dm.DataSet.Tables("TB_ExpInvoice").Rows.Count = 0 Then
                Exit Sub
            End If
        End If

        If IO = InOut.InWard Then

            Try
                If NewStatus = InvoiceStatus.Confirm And R.Cells("Status").Value <> InvoiceStatus.Confirm Then
                    Dm.DataSet.Tables("TB_Invoice").Rows(0).Item("InvoiceNo") = GetNewInvNo(IO)
                End If
                Dm.DataSet.Tables("TB_Invoice").Rows(0).Item("Status") = NewStatus.GetHashCode
                If NewStatus = InvoiceStatus.Confirm Then
                    Dm.DataSet.Tables("TB_Invoice").Rows(0).Item("ConfirmTime") = Today
                    Dm.DataSet.Tables("TB_Invoice").Rows(0).Item("ConfirmBy") = CurrentUser.UserCode
                    Dm.DataSet.Tables("TB_Invoice").Rows(0).Item("ConfirmOffice") = My.Settings.Office
                End If

                LogDataSet = Dm.DataSet.Copy
                Dm.CommitAll()
                GenerateLog(LogDataSet)
                'R.Cells("Status").Value = NewStatus.GetHashCode
                'R.Cells("InvStatus").Value = NewStatus
                ''MsgBoxSaveSuccessful()
                'Dim E As System.EventArgs
                'Call ButtonRefresh_Click(Me, E)
            Catch ex As Exception
                MsgBoxSaveFailed()
            End Try
        Else
            Try
                If NewStatus = InvoiceStatus.Confirm And R.Cells("Status").Value <> InvoiceStatus.Confirm Then
                    Dm.DataSet.Tables("TB_ExpInvoice").Rows(0).Item("InvoiceNo") = GetNewInvNo(IO)
                End If
                Dm.DataSet.Tables("TB_ExpInvoice").Rows(0).Item("Status") = NewStatus.GetHashCode
                If NewStatus = InvoiceStatus.Confirm Then
                    Dm.DataSet.Tables("TB_ExpInvoice").Rows(0).Item("ConfirmTime") = Today
                    Dm.DataSet.Tables("TB_ExpInvoice").Rows(0).Item("ConfirmBy") = CurrentUser.UserCode
                    Dm.DataSet.Tables("TB_ExpInvoice").Rows(0).Item("ConfirmOffice") = My.Settings.Office
                End If

                LogDataSet = Dm.DataSet.Copy
                Dm.CommitAll()
                GenerateLog(LogDataSet)
                'R.Cells("Status").Value = NewStatus.GetHashCode
                'R.Cells("InvStatus").Value = NewStatus

                'Dim E As System.EventArgs
                'Call ButtonRefresh_Click(Me, E)
            Catch ex As Exception
                MsgBoxSaveFailed()
            End Try

        End If

    End Sub

    Private Sub ConfirmButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfirmButton.Click

        Dim R As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim IO As InOut
        Dim E1 As System.EventArgs
        GridImport.UpdateData()
        GridInvExport.UpdateData()
        If MsgBox("Are You Sure To Confirm This Invoice ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            If TabControl.SelectedIndex = 0 Then
                For Each Dr In GridImport.Rows
                    If Dr.Cells("Sel").Value = True Then
                        R = Dr
                        IO = InOut.InWard
                        If R Is Nothing Then
                            Exit Sub
                        End If
                        If Double.Parse(R.Cells("Status").Value) = InvoiceStatus.ToAccount Then
                            ChangeStatus(IO, InvoiceStatus.Confirm, R)
                        End If
                        If Not Double.Parse(R.Cells("Status").Value) = InvoiceStatus.ToAccount Then
                            MsgBoxGeneral("Not Allow - Please check Status", "Validate Error")
                            Exit Sub
                        End If
                    End If
                Next
              
                'MsgBoxSaveSuccessful()

                Call ButtonRefresh_Click(Me, E1)
                MsgBoxSaveSuccessful()
            End If

            If Not TabControl.SelectedIndex = 0 Then
                For Each Dr In GridInvExport.Rows
                    If Dr.Cells("Sel").Value = True Then
                        R = Dr
                        IO = InOut.OutWard
                        If R Is Nothing Then
                            Exit Sub
                        End If
                        If Double.Parse(R.Cells("Status").Value) = InvoiceStatus.ToAccount Then
                            ChangeStatus(IO, InvoiceStatus.Confirm, R)
                        End If
                        If Not Double.Parse(R.Cells("Status").Value) = InvoiceStatus.ToAccount Then
                            MsgBoxGeneral("Not Allow - Please check Status", "Validate Error")
                            Exit Sub
                        End If
                    End If
                Next
                
                'MsgBoxSaveSuccessful()

                Call ButtonRefresh_Click(Me, E1)
                MsgBoxSaveSuccessful()
            End If
        End If

        'If TabControl.SelectedIndex = 0 Then
        '    If GridImport.Rows.Count > 0 Then
        '        R = GridImport.ActiveRow
        '        IO = InOut.InWard
        '    End If
        'Else
        '    If GridInvExport.Rows.Count > 0 Then
        '        R = GridInvExport.ActiveRow
        '        IO = InOut.OutWard
        '    End If
        'End If

        'If R Is Nothing Then
        '    Exit Sub
        'End If

        'If Double.Parse(R.Cells("Status").Value) = InvoiceStatus.ToAccount Then
        '    If MsgBox("Are You Sure To Confirm This Invoice ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
        '        ChangeStatus(IO, InvoiceStatus.Confirm, R)
        '    End If
        'Else
        '    MsgBoxGeneral("Not Allow", "Validate Error")
        '    Exit Sub
        'End If

    End Sub

    Private Sub CancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelButton.Click

        Dim R As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim IO As InOut
        If TabControl.SelectedIndex = 0 Then
            If GridImport.Rows.Count > 0 Then
                R = GridImport.ActiveRow
                IO = InOut.InWard
            End If
        Else
            If GridInvExport.Rows.Count > 0 Then
                R = GridInvExport.ActiveRow
                IO = InOut.OutWard
            End If
        End If

        If R Is Nothing Then
            Exit Sub
        End If

        If Double.Parse(NullToValue(R.Cells("Status").Value, 0)) = InvoiceStatus.Confirm Then
            If CurrentUser.IsAccountAdmin = True Then
                If MsgBox("Are You Sure To Cancel This Invoice ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    ChangeStatus(IO, InvoiceStatus.Cancel, R)
                End If
            Else
                MsgBoxGeneral("Not Allow", "Validate Error")
                Exit Sub
            End If
        Else
            MsgBoxGeneral("You Are Not Account Admin", "Validate Error")
        End If

    End Sub

    Private Sub PrintButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintButton.Click

        If Me.TabControl.SelectedTab.Name = "Import" Then
            If Me.GridImport.Rows.Count = 0 Then
                Exit Sub
            End If
            ShowInwardInvoice()
        Else
            If Me.GridInvExport.Rows.Count > 0 Then
                ShowOutwardinvoice()
            End If

        End If

    End Sub

    Private Sub ShowInwardInvoice()

        Dim Frm As New FrmGeneralReportShow
        Dim DS As New DataSet
        Dim Dv As DataView
        Dim nI As Long = 0
        Dim PH As New CLPrintHdr
        Dim Ans As Boolean
        Dim Report As CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim Drs() As DataRow
        Dim pValue As String
        Dim TB As New DataTable
        Dim lResult As Boolean
        Dim Account As String
        Dim R As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim DSFinal As DataSet


        Ans = RetriveObject(CurrentShippingLine & "_Invoice", "C:\INV")
        If Ans = True Then
            Report = New CrystalDecisions.CrystalReports.Engine.ReportDocument
            Report.Load("C:\INV")
        Else
            Report = New RptInvoice
        End If

        For Each R In GridImport.Selected.Rows

            DS = New DataSet

            DS = StoredProcedures.SP_RptInvoice(R.Cells("ID").Value.ToString)
            ' DS = StoredProcedures.SP_RptInvoice(GridImport.ActiveRow.Cells("ID").Value.ToString)

            If DS.Tables(0).Select("ChargesCode = 'OFT'").Length > 0 Then
                pValue = "Y"
            Else
                pValue = "N"
            End If

            TableBySql("Select AccountA From Tb_Clients CL , TB_InwardBls Bls , TB_Invoice Inv Where Cl.ID = Bls.ClientID and Inv.BLID = BLs.ID and Inv.ID = '" & GridImport.ActiveRow.Cells("ID").Value.ToString & "'", TB, lResult)
            If lResult = True Then
                If TB.Rows.Count > 0 Then
                    Account = TB.Rows(0).Item(0) & ""
                End If
            End If

            DS.Tables(0).Columns.Add(New DataColumn("CompanyAccount"))
            DS.Tables(0).Columns.Add(New DataColumn("Account"))
            DS.Tables(0).Columns.Add(New DataColumn("InvoiceID"))
            DS.Tables(0).Columns.Add(New DataColumn("ISOCE"))
            Dv = New DataView(DS.Tables(0), "", "Seq", DataViewRowState.CurrentRows)

            For Each dr As DataRowView In Dv
                nI += 1
                dr("Seq") = nI
                dr("FPrintTime") = ToPersianDate(Now.Date)
                If DS.Tables(1).Rows.Count = 0 Then
                    dr("CompanyAccount") = CurrentCompany.CompanyAccount
                End If
                dr("Account") = Account
                dr("InvoiceID") = GridImport.ActiveRow.Cells("ID").Value.ToString
                dr("ISOCE") = pValue
            Next

            If DSFinal Is Nothing Then
                DSFinal = DS.Copy
            Else
                For Each Dr In DS.Tables(0).Rows
                    DSFinal.Tables(0).ImportRow(Dr)
                Next

                For Each Dr In DS.Tables(1).Rows
                    DSFinal.Tables(1).ImportRow(Dr)
                Next
            End If
        Next

        'DS = StoredProcedures.SP_RptInvoice(Me.GridImport.ActiveRow.Cells("ID").Value.ToString)

        'If DS.Tables(0).Select("ChargesCode = 'OFT'").Length > 0 Then
        '    pValue = "Y"
        'Else
        '    pValue = "N"
        'End If

        'TableBySql("Select AccountA From Tb_Clients CL , TB_InwardBls Bls , TB_Invoice Inv Where Cl.ID = Bls.ClientID and Inv.BLID = BLs.ID and Inv.ID = '" & Me.GridImport.ActiveRow.Cells("ID").Value.ToString & "'", TB, lResult)
        'If lResult = True Then
        '    If TB.Rows.Count > 0 Then
        '        Account = TB.Rows(0).Item(0) & ""
        '    End If
        'End If

        'DS.Tables(0).Columns.Add(New DataColumn("CompanyAccount"))
        'DS.Tables(0).Columns.Add(New DataColumn("Account"))
        'Dv = New DataView(DS.Tables(0), "", "Seq", DataViewRowState.CurrentRows)

        'For Each dr As DataRowView In Dv
        '    nI += 1
        '    dr("Seq") = nI
        '    dr("FPrintTime") = ToPersianDate(Now.Date)
        '    If DS.Tables(1).Rows.Count = 0 Then
        '        dr("CompanyAccount") = CurrentCompany.CompanyAccount
        '    End If
        '    dr("Account") = Account
        'Next

        Report.SetDataSource(DSFinal.Tables(0))
        Report.Subreports("RptRecivedItems").SetDataSource(DSFinal.Tables(1))
        '      Report.SetParameterValue("ISOCE", pValue)

        Frm.ReportViewer.ReportSource = Report
        Frm.Show()

    End Sub

    Private Sub ShowOutwardinvoice()

        Dim Frm As New FrmGeneralReportShow
        Dim DS As New DataSet
        Dim Dv As DataView
        Dim nI As Long = 0
        Dim PH As New CLPrintHdr
        Dim Ans As Boolean
        Dim pValue As String
        Dim R As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim DSFinal As DataSet

        Dim Report As CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report = New RptInvoice
        Ans = RetriveObject(CurrentShippingLine & "_Invoice", "C:\INV")
        If Ans = True Then
            Report = New CrystalDecisions.CrystalReports.Engine.ReportDocument
            Report.Load("C:\INV")
        Else
            Ans = RetriveObject("_invoice", "C:\INV")
            If Ans = True Then
                Report = New CrystalDecisions.CrystalReports.Engine.ReportDocument
                Report.Load("C:\INV")
            End If
        End If
        ' For Each R In GridInvExport.Selected.Rows

        DS = New DataSet

        DS = StoredProcedures.SP_RptExpInvoice(GridInvExport.ActiveRow.Cells("ID").Value.ToString)
        Dv = New DataView(DS.Tables(0), "", "Seq", DataViewRowState.CurrentRows)

        If DS.Tables(0).Select("ChargesCode = 'OCE'").Length > 0 Then
            pValue = "Y"
        Else
            pValue = "N"
        End If

        DS.Tables(0).Columns.Add(New DataColumn("CompanyAccount"))
        DS.Tables(0).Columns.Add(New DataColumn("Account"))
        DS.Tables(0).Columns.Add(New DataColumn("InvoiceID"))
        DS.Tables(0).Columns.Add(New DataColumn("ISOCE"))

        For Each dr As DataRowView In Dv
            nI += 1
            dr("Seq") = nI
            dr("FPrintTime") = ToPersianDate(Now.Date)
            If DS.Tables(1).Rows.Count = 0 Then
                dr("CompanyAccount") = CurrentCompany.CompanyAccount
            End If
            dr("InvoiceID") = GridInvExport.ActiveRow.Cells("ID").Value.ToString
            dr("ISOCE") = pValue

        Next

        If DSFinal Is Nothing Then
            DSFinal = DS.Copy
        Else
            For Each Dr In DS.Tables(0).Rows
                DSFinal.Tables(0).ImportRow(Dr)
            Next

            For Each Dr In DS.Tables(1).Rows
                DSFinal.Tables(1).ImportRow(Dr)
            Next
        End If

        ' Next

        '     Report.Subreports(0).SetDataSource(PH.ImageTable)
        Report.SetDataSource(DSFinal.Tables(0))
        Report.Subreports("RptRecivedItems").SetDataSource(DSFinal.Tables(1))
        '  Report.SetParameterValue("ISOCE", pValue)

        Frm.ReportViewer.ReportSource = Report
        Frm.Show()
    End Sub

    Private Sub ButtonRecived_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRecived.Click

        Dim Frm As FrmRecivedItems
        Dim BLID As Guid
        Dim InvID As Guid

        If Me.TabControl.SelectedTab.Text = "Import Invoices" Then
            If Me.GridImport.Rows.Count > 0 Then
                BLID = GridImport.ActiveRow.Cells("BLID").Value
                InvID = GridImport.ActiveRow.Cells("ID").Value
                Frm = New FrmRecivedItems("I", BLID, InvID, NullToValue(GridImport.ActiveRow.Cells("IrrAmount").Value, 0), NullToValue(GridImport.ActiveRow.Cells("UsdAmount").Value, 0))
            End If
        Else
            BLID = GridInvExport.ActiveRow.Cells("BLID").Value
            InvID = GridInvExport.ActiveRow.Cells("ID").Value
            Frm = New FrmRecivedItems("E", BLID, InvID, NullToValue(GridInvExport.ActiveRow.Cells("IrrAmount").Value, 0), NullToValue(GridInvExport.ActiveRow.Cells("UsdAmount").Value, 0))
        End If

        Frm.Show()

    End Sub


    Private Sub ToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToExcel.Click
        If Me.TabControl.SelectedTab.Text = "Import Invoices" Then
            If Me.GridImport.Rows.Count = 0 Then
                MsgBoxGeneral("No Any Data For Export")
                Exit Sub
            End If
            SaveGridToExcel(Me.GridImport)
        Else
            If Me.GridInvExport.Rows.Count = 0 Then
                MsgBoxGeneral("No Any Data For Export")
                Exit Sub
            End If
            SaveGridToExcel(Me.GridInvExport)
        End If
    End Sub

    Private Sub ButtonDeposits_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDeposits.Click

        Dim frm As FrmDeposits

        If Me.GridImport.Rows.Count = 0 Then
            Exit Sub
        End If

        frm = New FrmDeposits(Me.GridImport.ActiveRow.Cells("BLID").Value)
        frm.Show()

    End Sub

    'Private Sub OfficialButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OfficialButton.Click

    '    Dim OInv As New ClGenerateInvoiceOfficial
    '    Dim DS As New DataSet
    '    Dim sSql As String
    '    Dim lResult As Boolean
    '    Dim ClntRow As DataRow
    '    Dim Drs() As DataRow
    '    Dim Dr As DataRow
    '    Dim sCntrs As String
    '    Dim DT As Date
    '    Dim Tax As Long
    '    Dim TB As New DataTable
    '    Dim DummyAmount As Double
    '    Dim lTax As Boolean = False
    '    Dim Calbase As CLCalculationBase = New CLCalculationBase

    '    If Me.TabControl.SelectedTab.Name = "Import" Then
    '        If Me.GridImport.Rows.Count = 0 Then
    '            Exit Sub
    '        End If
    '        sSql = "SP_InwardOfficialInv '" & Me.GridImport.ActiveRow.Cells("ID").Value.ToString & "'"
    '        DataSetBySql(sSql, DS, lResult)
    '        sCntrs = GetInwardTotalCntrs(Me.GridImport.ActiveRow.Cells("BLID").Value)
    '     Else
    '        If Me.GridInvExport.Rows.Count = 0 Then
    '            Exit Sub
    '        End If
    '        sSql = "SP_OutwardOfficialInv '" & Me.GridInvExport.ActiveRow.Cells("ID").Value.ToString & "'"
    '        DataSetBySql(sSql, DS, lResult)
    '        sCntrs = GetOutwardTotalCntrs(Me.GridInvExport.ActiveRow.Cells("BLID").Value)
    '     End If

    '    sCntrs = Replace(sCntrs, "CNTRS", "")
    '    sCntrs = Replace(sCntrs, "CNTR", "")

    '    OInv.InformMastrData(CurrentCompany.CompanyName, _
    '                         DS.Tables(1).Rows(0).Item("InvoiceNo"), _
    '                         DS.Tables(1).Rows(0).Item("ConfirmTime"), _
    '                         CurrentCompany.EconomicNo, _
    '                         CurrentCompany.RegestrationNo, _
    '                         CurrentCompany.POBOX, _
    '                         CurrentCompany.CompantFAddress, _
    '                         CurrentCompany.Tel, _
    '                         NullToValue(DS.Tables(3).Rows(0).Item("FName"), ""), _
    '                         NullToValue(DS.Tables(3).Rows(0).Item("EconomicNo"), ""), _
    '                         NullToValue(DS.Tables(3).Rows(0).Item("RegestrationNo"), ""), _
    '                         NullToValue(DS.Tables(3).Rows(0).Item("POBox"), ""), _
    '                         NullToValue(DS.Tables(3).Rows(0).Item("FAddress"), ""), _
    '                         NullToValue(DS.Tables(3).Rows(0).Item("Tel"), ""), _
    '                         DS.Tables(0).Rows(0).Item("BLNO"), _
    '                         DS.Tables(4).Rows(0).Item("VoyageNO") & " " & DS.Tables(4).Rows(0).Item("VesselName"), sCntrs, DS.Tables(1).Rows(0).Item("ConfirmBy").ToString, _
    '                         NullToValue(DS.Tables(0).Rows(0).Item("JobNumber"), ""))

    '    Drs = DS.Tables(2).Select("ChargesCode = 'TAX' or ChargesCode = 'TOLL'")
    '    If Drs.Length > 0 Then
    '        lTax = True
    '    Else
    '        lTax = False
    '    End If
    '    Drs = DS.Tables(2).Select("", "Seq")

    '    For Each Dr In Drs

    '        DummyAmount = 0
    '        If Dr("ChargesCode") = "DETN" Then
    '            If Me.TabControl.SelectedTab.Name = "Import" Then
    '                sSql = "select dbo.FC_InwardTotalChargByBIChgCurrency('" & Me.GridImport.ActiveRow.Cells("BLID").Value.ToString & "' , 'DETN-A' , 'IRR')"
    '            Else
    '                sSql = "select dbo.FC_OutwardTotalChargByBIChgCurrency('" & Me.GridInvExport.ActiveRow.Cells("BLID").Value.ToString & "' , 'DETN-A' , 'IRR')"
    '            End If
    '            TableBySql(sSql, TB, lResult)
    '            If TB.Rows.Count > 0 Then
    '                DummyAmount = NullToValue(TB.Rows(0).Item(0), 0)
    '            End If
    '        End If

    '        If Me.TabControl.SelectedTab.Name = "Import" Then
    '            Calbase.GetTaxDutyInward(Me.GridImport.ActiveRow.Cells("BLID").Value, Dr("ChargesCode"))
    '        Else
    '            Calbase.GetTaxDutyOutward(Me.GridInvExport.ActiveRow.Cells("BLID").Value, Dr("ChargesCode"))
    '        End If


    '        Tax = Calbase.Tax + Calbase.Duty


    '        'If Tax > 0 Then
    '        '    Tax = ((Dr("IRRAmount") + DummyAmount) * Tax) / 100
    '        'End If
    '        If Tax > 0 Then
    '            If Not Dr("IRRAmount") = 0 And Dr("Currency") = "IRR" Then
    '                Tax = ((Dr("IRRAmount") + DummyAmount) * Tax) / 100
    '            Else
    '                Tax = ((Dr("Amount") + DummyAmount) * Tax) / 100
    '            End If
    '        End If

    '        'Bypass tax incase of paid at another country
    '        If lTax = False Then
    '            Tax = 0
    '        End If
    '        'If Not (Dr("ChargesCode") = "TAX" Or Dr("ChargesCode") = "TOLL") And Tax <> 0 Then
    '        '    'If Not (Dr("ChargesCode") = "TAX" Or Dr("ChargesCode") = "TOLL") Then
    '        '    OInv.AddInvoiceRow(Dr("ChargesCode"), Dr("Remarks"), 1, 0, Dr("IRRAmount") + DummyAmount, Dr("IRRAmount") + DummyAmount, DummyAmount, Dr("IRRAmount"), Tax, Dr("IRRAmount") + Tax)
    '        'End If
    '        'modified for USD case- Appu

    '        If Not (Dr("ChargesCode") = "TAX" Or Dr("ChargesCode") = "TOLL") And Tax <> 0 Then
    '            'If Not (Dr("ChargesCode") = "TAX" Or Dr("ChargesCode") = "TOLL") Then
    '            If Dr("Currency") = "IRR" Then
    '                OInv.AddInvoiceRow(Dr("ChargesCode"), Dr("Remarks"), 1, 0, Dr("IRRAmount") + DummyAmount, Dr("IRRAmount") + DummyAmount, DummyAmount, Dr("IRRAmount"), Tax, Dr("IRRAmount") + Tax)
    '            Else
    '                If Dr("IRRAmount") = 0 Then
    '                    OInv.AddInvoiceRow(Dr("ChargesCode"), Dr("Remarks"), 1, 0, Dr("Amount") + DummyAmount, Dr("Amount") + DummyAmount, DummyAmount, Dr("Amount"), Tax, Dr("Amount") + Tax)
    '                Else
    '                    OInv.AddInvoiceRow(Dr("ChargesCode"), Dr("Remarks"), 1, 0, Dr("IRRAmount") + DummyAmount, Dr("IRRAmount") + DummyAmount, DummyAmount, Dr("IRRAmount"), Tax, Dr("IRRAmount") + Tax)
    '                End If
    '            End If
    '        End If
    '        'USD BASED EXPORT INVOICES IS NOT GENERATED
    '        'Above code has been modified as above

    '    Next

    '    OInv.ShowReport()

    'End Sub
    'Above method commented and modified the same as below for USD BASED EXPORT INVOICES IS NOT GENERATED by appu
    Private Sub OfficialButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OfficialButton.Click

        Dim OInv As New ClGenerateInvoiceOfficial
        Dim DS As New DataSet
        Dim sSql As String
        Dim lResult As Boolean
        Dim ClntRow As DataRow
        Dim Drs() As DataRow
        Dim Dr As DataRow
        Dim sCntrs As String
        Dim DT As Date
        Dim Tax As Long
        Dim TB As New DataTable
        Dim DummyAmount As Double
        Dim lTax As Boolean = False
        Dim Calbase As CLCalculationBase = New CLCalculationBase

        If Me.TabControl.SelectedTab.Name = "Import" Then
            If Me.GridImport.Rows.Count = 0 Then
                Exit Sub
            End If
            sSql = "SP_InwardOfficialInv '" & Me.GridImport.ActiveRow.Cells("ID").Value.ToString & "'"
            DataSetBySql(sSql, DS, lResult)
            sCntrs = GetInwardTotalCntrs(Me.GridImport.ActiveRow.Cells("BLID").Value)
        Else
            If Me.GridInvExport.Rows.Count = 0 Then
                Exit Sub
            End If
            sSql = "SP_OutwardOfficialInv '" & Me.GridInvExport.ActiveRow.Cells("ID").Value.ToString & "'"
            DataSetBySql(sSql, DS, lResult)
            sCntrs = GetOutwardTotalCntrs(Me.GridInvExport.ActiveRow.Cells("BLID").Value)
        End If

        sCntrs = Replace(sCntrs, "CNTRS", "")
        sCntrs = Replace(sCntrs, "CNTR", "")
        sCntrs = Replace(sCntrs, vbCrLf, " ")


        OInv.InformMastrData(CurrentCompany.CompanyName, _
                             DS.Tables(1).Rows(0).Item("InvoiceNo"), _
                             DS.Tables(1).Rows(0).Item("ConfirmTime"), _
                             CurrentCompany.EconomicNo, _
                             CurrentCompany.RegestrationNo, _
                             CurrentCompany.POBOX, _
                             CurrentCompany.CompantFAddress, _
                             CurrentCompany.Tel, _
                             NullToValue(DS.Tables(3).Rows(0).Item("FName"), ""), _
                             NullToValue(DS.Tables(3).Rows(0).Item("EconomicNo"), ""), _
                             NullToValue(DS.Tables(3).Rows(0).Item("RegestrationNo"), ""), _
                             NullToValue(DS.Tables(3).Rows(0).Item("POBox"), ""), _
                             NullToValue(DS.Tables(3).Rows(0).Item("FAddress"), ""), _
                             NullToValue(DS.Tables(3).Rows(0).Item("Tel"), ""), _
                             DS.Tables(0).Rows(0).Item("BLNO"), _
                             DS.Tables(4).Rows(0).Item("VoyageNO") & " " & DS.Tables(4).Rows(0).Item("VesselName"), sCntrs, DS.Tables(1).Rows(0).Item("ConfirmBy").ToString, _
                             NullToValue(DS.Tables(0).Rows(0).Item("JobNumber"), ""))

        Drs = DS.Tables(2).Select("ChargesCode = 'TAX' or ChargesCode = 'TOLL'")
        If Drs.Length > 0 Then
            lTax = True
        Else
            lTax = False
        End If
        '' for cntr count based THC 
        'sSql = "SELECT Count(CntrNo) as TotalCntrs , CnSize , Cntype FROM TB_InwardCntrs Where BLID = '" & Me.GridImport.ActiveRow.Cells("BLID").Value.ToString & "' Group By CnSize , CnType"
        'TableBySql(sSql, TB, lResult)

        '' end

        Drs = DS.Tables(2).Select("", "Seq")

        For Each Dr In Drs

            DummyAmount = 0
            If Dr("ChargesCode") = "DETN" Then
                If Me.TabControl.SelectedTab.Name = "Import" Then
                    sSql = "select dbo.FC_InwardTotalChargByBIChgCurrency('" & Me.GridImport.ActiveRow.Cells("BLID").Value.ToString & "' , 'DETN-A' , 'IRR')"
                Else
                    sSql = "select dbo.FC_OutwardTotalChargByBIChgCurrency('" & Me.GridInvExport.ActiveRow.Cells("BLID").Value.ToString & "' , 'DETN-A' , 'IRR')"
                End If
                TableBySql(sSql, TB, lResult)
                If TB.Rows.Count > 0 Then
                    DummyAmount = NullToValue(TB.Rows(0).Item(0), 0)
                End If
            End If

            If Me.TabControl.SelectedTab.Name = "Import" Then
                Calbase.GetTaxDutyInward(Me.GridImport.ActiveRow.Cells("BLID").Value, Dr("ChargesCode"))
            Else
                Calbase.GetTaxDutyOutward(Me.GridInvExport.ActiveRow.Cells("BLID").Value, Dr("ChargesCode"))
            End If


            Tax = Calbase.Tax + Calbase.Duty


            'If Tax > 0 Then
            '    Tax = ((Dr("IRRAmount") + DummyAmount) * Tax) / 100
            'End If
            If Tax > 0 Then
                If Not Dr("IRRAmount") = 0 And Dr("Currency") = "IRR" Then
                    Tax = ((Dr("IRRAmount") + DummyAmount) * Tax) / 100
                    'Below code Added for Demarage Charges
                ElseIf Not Dr("IRRAmount") = 0 And Not Dr("Currency") = "IRR" Then
                    Tax = ((Dr("IRRAmount") + DummyAmount) * Tax) / 100
                    'End of Demarage Charges'
                Else
                    Tax = ((Dr("Amount") + DummyAmount) * Tax) / 100
                End If
            End If

            'Bypass tax incase of paid at another country
            If lTax = False Then
                Tax = 0
            End If
            'If Not (Dr("ChargesCode") = "TAX" Or Dr("ChargesCode") = "TOLL") And Tax <> 0 Then
            '    'If Not (Dr("ChargesCode") = "TAX" Or Dr("ChargesCode") = "TOLL") Then
            '    OInv.AddInvoiceRow(Dr("ChargesCode"), Dr("Remarks"), 1, 0, Dr("IRRAmount") + DummyAmount, Dr("IRRAmount") + DummyAmount, DummyAmount, Dr("IRRAmount"), Tax, Dr("IRRAmount") + Tax)
            'End If
            'modified for USD case- Appu

           

            'If Not (Dr("ChargesCode") = "TAX" Or Dr("ChargesCode") = "TOLL") And Tax <> 0 Then
            'If Not (Dr("ChargesCode") = "TAX" Or Dr("ChargesCode") = "TOLL") Then
            '    If Not (Dr("ChargesCode") = "THC" Or Dr("ChargesCode") = "DROPW") Then
            '        If Dr("Currency") = "IRR" Then
            '            OInv.AddInvoiceRow(Dr("ChargesCode"), Dr("Remarks"), 1, 0, Dr("IRRAmount") + DummyAmount, Dr("IRRAmount") + DummyAmount, DummyAmount, Dr("IRRAmount"), Tax, Dr("IRRAmount") + Tax)
            '        Else
            '            If Dr("IRRAmount") = 0 Then
            '                OInv.AddInvoiceRow(Dr("ChargesCode"), Dr("Remarks"), 1, 0, Dr("Amount") + DummyAmount, Dr("Amount") + DummyAmount, DummyAmount, Dr("Amount"), Tax, Dr("Amount") + Tax)
            '            Else
            '                OInv.AddInvoiceRow(Dr("ChargesCode"), Dr("Remarks"), 1, 0, Dr("IRRAmount") + DummyAmount, Dr("IRRAmount") + DummyAmount, DummyAmount, Dr("IRRAmount"), Tax, Dr("IRRAmount") + Tax)
            '            End If
            '        End If
            '    Else
            '        If TB.Rows.Count > 0 Then
            '            For Each Dr1 In TB.Rows
            '                If Dr("Currency") = "IRR" Then
            '                    OInv.AddInvoiceRow(Dr("ChargesCode") & " - " & Dr1("CnSize") & Dr1("Cntype"), Dr("Remarks"), Dr1("TotalCntrs"), 0, (Dr("IRRAmount") + DummyAmount) / Dr1("TotalCntrs"), Dr("IRRAmount") + DummyAmount, DummyAmount, Dr("Amount"), Tax, Dr("IRRAmount") + Tax)
            '                Else
            '                    If Dr("IRRAmount") = 0 Then
            '                        OInv.AddInvoiceRow(Dr("ChargesCode") & " - " & Dr1("CnSize") & Dr1("Cntype"), Dr("Remarks"), Dr1("TotalCntrs"), 0, (Dr("Amount") + DummyAmount) / Dr1("TotalCntrs"), Dr("Amount") + DummyAmount, DummyAmount, Dr("Amount"), Tax, Dr("Amount") + Tax)
            '                    Else
            '                        OInv.AddInvoiceRow(Dr("ChargesCode") & " - " & Dr1("CnSize") & Dr1("Cntype"), Dr("Remarks"), Dr1("TotalCntrs"), 0, (Dr("IRRAmount") + DummyAmount) / Dr1("TotalCntrs"), Dr("IRRAmount") + DummyAmount, DummyAmount, Dr("Amount"), Tax, Dr("IRRAmount") + Tax)

            '                    End If
            '                End If
            '            Next
            '        End If

            '    End If
            'End If

            If Not (Dr("ChargesCode") = "TAX" Or Dr("ChargesCode") = "TOLL") Then
                If Not (Dr("ChargesCode") = "THC" Or Dr("ChargesCode") = "DROPW") Then
                    If Dr("Currency") = "IRR" Then
                        OInv.AddInvoiceRow(Dr("ChargesCode"), Dr("Remarks"), 1, 0, Dr("IRRAmount") + DummyAmount, Dr("IRRAmount") + DummyAmount, DummyAmount, Dr("IRRAmount"), Tax, Dr("IRRAmount") + Tax)
                    Else
                        If Dr("IRRAmount") = 0 Then
                            OInv.AddInvoiceRow(Dr("ChargesCode"), Dr("Remarks"), 1, 0, Dr("Amount") + DummyAmount, Dr("Amount") + DummyAmount, DummyAmount, Dr("Amount"), Tax, Dr("Amount") + Tax)
                        Else
                            OInv.AddInvoiceRow(Dr("ChargesCode"), Dr("Remarks"), 1, 0, Dr("IRRAmount") + DummyAmount, Dr("IRRAmount") + DummyAmount, DummyAmount, Dr("IRRAmount"), Tax, Dr("IRRAmount") + Tax)
                        End If
                    End If
                Else
                    If Dr("Currency") = "IRR" Then
                        OInv.AddInvoiceRow(Dr("ChargesCode"), Dr("Remarks"), 1, 0, Dr("IRRAmount") + DummyAmount, Dr("IRRAmount") + DummyAmount, DummyAmount, Dr("IRRAmount"), Tax, Dr("IRRAmount") + Tax)
                    Else
                        If Dr("IRRAmount") = 0 Then
                            OInv.AddInvoiceRow(Dr("ChargesCode"), Dr("Remarks"), 1, 0, Dr("Amount") + DummyAmount, Dr("Amount") + DummyAmount, DummyAmount, Dr("Amount"), Tax, Dr("Amount") + Tax)
                        Else
                            OInv.AddInvoiceRow(Dr("ChargesCode"), Dr("Remarks"), 1, 0, Dr("IRRAmount") + DummyAmount, Dr("IRRAmount") + DummyAmount, DummyAmount, Dr("IRRAmount"), Tax, Dr("IRRAmount") + Tax)
                        End If
                    End If
                End If
            End If
                'USD BASED EXPORT INVOICES IS NOT GENERATED
                'Above code has been modified as above

        Next

        OInv.ShowReport()

    End Sub

    Private Sub ButtonComments_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonComments.Click

        If Me.TabControl.SelectedTab.Name = "Import" Then
            If Me.GridImport.Rows.Count > 0 Then
                ShowInwardComments()
            End If
        Else
            If Me.GridInvExport.Rows.Count > 0 Then
                ShowOutwardComments()
            End If
        End If
    End Sub
    Private Sub ShowInwardComments()
        Dim Frm As New FrmComments(FrmComments.InwardOutward.Inward, Me.GridImport.ActiveRow.Cells("BLID").Value)
        Frm.SetDocument(Me.GridImport.ActiveRow.Cells("BLID").Value)
        Frm.Show()
    End Sub
    Private Sub ShowOutwardComments()
        Dim Frm As New FrmComments(FrmComments.InwardOutward.Outward, Me.GridInvExport.ActiveRow.Cells("BLID").Value)
        Frm.SetDocument(Me.GridImport.ActiveRow.Cells("BLID").Value)
        Frm.Show()
    End Sub

    'Private Sub GridImport_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles GridImport.InitializeLayout
    '    e.Layout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended
    'End Sub

    Private Sub FrmInvoiceTrace_ResizeEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeEnd

    End Sub
End Class