Public Class ClGenerateInvoiceOfficial

    Private TB As DataTable

    Public Sub New()

        TB = New DataTable
     
        TB.Columns.Add(New DataColumn("CoName"))
        TB.Columns.Add(New DataColumn("InvoiceNo"))
        TB.Columns.Add(New DataColumn("InvoiceDate"))
        TB.Columns.Add(New DataColumn("OurEconomicCode"))
        TB.Columns.Add(New DataColumn("OurRegestrationNo"))
        TB.Columns.Add(New DataColumn("OurPOBOX"))
        TB.Columns.Add(New DataColumn("OurAddress"))
        TB.Columns.Add(New DataColumn("OurTEL"))
        TB.Columns.Add(New DataColumn("Name"))
        TB.Columns.Add(New DataColumn("EconomicCode"))
        TB.Columns.Add(New DataColumn("RegestrationNo"))
        TB.Columns.Add(New DataColumn("POBOX"))
        TB.Columns.Add(New DataColumn("Address"))
        TB.Columns.Add(New DataColumn("TEL"))
        TB.Columns.Add(New DataColumn("BLNO"))
        TB.Columns.Add(New DataColumn("VesselVoyage"))
        TB.Columns.Add(New DataColumn("Cntrs"))
        TB.Columns.Add(New DataColumn("Seq", System.Type.GetType("System.Int16")))
        TB.Columns.Add(New DataColumn("Code"))
        TB.Columns.Add(New DataColumn("Drscription"))
        TB.Columns.Add(New DataColumn("Qty", System.Type.GetType("System.Int64")))
        TB.Columns.Add(New DataColumn("Unit", System.Type.GetType("System.Int64")))
        TB.Columns.Add(New DataColumn("UnitPrice", System.Type.GetType("System.Int64")))
        TB.Columns.Add(New DataColumn("TotalAmount", System.Type.GetType("System.Int64")))
        TB.Columns.Add(New DataColumn("Discount", System.Type.GetType("System.Int64")))
        TB.Columns.Add(New DataColumn("AfterDiscount", System.Type.GetType("System.Int64")))
        TB.Columns.Add(New DataColumn("Tax", System.Type.GetType("System.Int64")))
        TB.Columns.Add(New DataColumn("Net", System.Type.GetType("System.Int64")))
        TB.Columns.Add(New DataColumn("ConfirmBy", System.Type.GetType("System.String")))
        TB.Columns.Add(New DataColumn("JobNumber", System.Type.GetType("System.String")))

    End Sub

    Public Sub InformMastrData(ByVal CoName As String, _
                            ByVal InvoiceNo As String, _
                            ByVal InvoiceDate As String, _
                            ByVal OurEconomicCode As String, _
                            ByVal OurRegestrationNo As String, _
                            ByVal OurPOBOX As String, _
                            ByVal OurAddress As String, _
                            ByVal OurTEL As String, _
                            ByVal Name As String, _
                            ByVal EconomicCode As String, _
                            ByVal RegestrationNo As String, _
                            ByVal POBOX As String, _
                            ByVal Address As String, _
                            ByVal Tel As String, _
                            ByVal BlNo As String, _
                            ByVal VesselVoyage As String, _
                            ByVal Cntrs As String, _
                            ByVal ConfirmBy As String, _
                            ByRef JobNumber As String)

        Dim TBx As New DataTable
        Dim sSql As String = "select * from tb_Users where usercode = '" & ConfirmBy & "'"
        Dim lResult As Boolean

        TableBySql(sSql, TBx, lResult)
        Try
            If lResult = True Then
                ConfirmBy = TBx.Rows(0).Item("UserLastName")
            End If
        Catch ex As Exception

        End Try

        TB.Columns("CoName").DefaultValue = CurrentCompany.CompanyFName 'coName
        TB.Columns("InvoiceNo").DefaultValue = InvoiceNo
        TB.Columns("InvoiceDate").DefaultValue = ToPersianDate(InvoiceDate)
        TB.Columns("OurEconomicCode").DefaultValue = OurEconomicCode
        TB.Columns("OurRegestrationNo").DefaultValue = OurRegestrationNo
        TB.Columns("OurPOBOX").DefaultValue = OurPOBOX
        TB.Columns("OurAddress").DefaultValue = OurAddress
        TB.Columns("OurTEL").DefaultValue = OurTEL
        TB.Columns("Name").DefaultValue = Name
        TB.Columns("EconomicCode").DefaultValue = EconomicCode
        TB.Columns("RegestrationNo").DefaultValue = RegestrationNo
        TB.Columns("POBOX").DefaultValue = POBOX
        TB.Columns("Address").DefaultValue = Address
        TB.Columns("TEL").DefaultValue = Tel
        TB.Columns("BLNO").DefaultValue = BlNo
        TB.Columns("VesselVoyage").DefaultValue = VesselVoyage
        TB.Columns("Cntrs").DefaultValue = Cntrs
        TB.Columns("ConfirmBy").DefaultValue = ConfirmBy
        TB.Columns("JobNumber").DefaultValue = JobNumber


    End Sub

    Public Sub AddInvoiceRow(ByVal Code As String, _
                              ByVal Description As String, _
                              ByVal Qty As Int64, _
                              ByVal Unit As String, _
                              ByVal UnitPrice As Int64, _
                              ByVal TotalAmount As Int64, _
                              ByVal Discount As Int64, _
                              ByVal AfterDiscount As Int64, _
                              ByVal Tax As Int64, _
                              ByVal Net As Int64)
        Dim Dr As DataRow = TB.NewRow

        Dr("Seq") = TB.Rows.Count + 1
        Dr("Code") = Code
        Dr("Drscription") = Description
        Dr("Qty") = Qty
        Dr("Unit") = Unit
        Dr("UnitPrice") = UnitPrice
        Dr("TotalAmount") = TotalAmount
        Dr("Discount") = Discount
        Dr("AfterDiscount") = AfterDiscount
        Dr("Tax") = Tax
        Dr("Net") = Net
        TB.Rows.Add(Dr)

    End Sub
    Public Sub AddNegativeInvoiceRow(ByVal Seq As Integer, _
                                 ByVal Description As String, _
                                 ByVal TotalAmount As Int64)

        Dim Dr As DataRow = TB.NewRow

        Dr("Seq") = Seq
        Dr("Description") = Description
        Dr("TotalAmount") = TotalAmount * -1
        Dr("Discount") = 0
        Dr("Tax") = 0
        Dr("IsNegative") = True
        TB.Rows.Add(Dr)

    End Sub
    Public Sub ShowReport()

        Dim Report As New RptInvoiceOfficial
        Dim Frm As New FrmGeneralReportShow
        Dim NewRow As DataRow

        'Do While TB.Rows.Count < 7
        '    NewRow = TB.NewRow
        '    NewRow("Seq") = TB.Rows.Count + 1
        '    TB.Rows.Add(NewRow)
        'Loop

        Report.SetDataSource(TB)
        Frm.ReportViewer.ReportSource = Report
        Frm.Show()

    End Sub


End Class
