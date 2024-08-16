Imports OrmLib
Imports ShippingBiz

Public Class CLBookingCost
    Private TB As DataTable
    Private lInvoiceInIrr As Boolean
    Private CalBase As New CLCalculationBase

    Public Sub CallBookingFreight(ByVal Bl As TB_OutwardBLS, ByVal Dpt As CLDeparturCost)

        Dim ds As New DataSet
        Dim Cns As TB_OutwardCntrsCollection
        Dim Cn As TB_OutwardCntrs
        Dim Bk As DataTable
        Dim aCntrs As New ArrayList
        Dim Frm As New FrmRaiseError
        Dim Dr As DataRow
        Dim TR As DataRow
        Dim Trs() As DataRow
        Dim Voy As TB_Voyage
        Dim DummyAmt As Double
        Dim lNew As Boolean
        Dim Dm As DataManager
        Dim Tax As Double
        Dim Toll As Double

        Dm = New DataManager(My.Settings.DSN)
        ds = StoredProcedures.SP_GetBookingFreight(Bl.ID.ToString)
        Bk = ds.Tables(0)
        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_OutwardCntrs.Columns.BLID, Bl.ID, MatchType.Exact)
        Cns = Dm.GetTB_OutwardCntrsCollection

        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_Voyage.Columns.ID, Bl.VoyageID, MatchType.Exact)
        Voy = Dm.GetTB_Voyage
        If Bk.Rows.Count > 0 Then
            lInvoiceInIrr = NullToValue(Bk.Rows(0).Item("InvoiceInIrr"), True)
        End If
        For Each Dr In Bk.Rows
            If Mid(UCase(NullToValue(Dr("Payebleat"), "IR")), 1, 2) = "IR" Then
                For Each Cn In Cns
                    If Cn.CnSize = Dr("CnSize") And Cn.CnType = Dr("CnType") Then
                        lNew = False
                        Trs = TB.Select("ChargesCode = '" & Dr("ChargesCode") & "'")
                        If Trs.Length = 0 Then
                            TR = TB.NewRow
                            TR("ChargesCode") = Dr("ChargesCode")
                            TR("Amount") = 0
                            TR("Currency") = Dr("Currency")
                            TR("IRRAmount") = 0
                            lNew = True
                        Else
                            TR = Trs(0)
                        End If
                        TR("Amount") += Dr("QTShipper")
                        If Dr("Currency") <> "IRR" Then
                            DummyAmt = Double.Parse(Dr("QTShipper")) * Dpt.GetExchangeFRT(Dr("Currency")) '  Double.Parse(Voy.ExchangeFrt)
                            TR("IRRAmount") += DummyAmt
                        Else
                            TR("IRRAmount") += Dr("QTShipper")
                        End If
                        If lNew = True Then
                            CalBase.GetTaxDutyDyDate(Now.Date, Dr("ChargesCode"))
                            ' GetTaxTollPercent(Dr("ChargesCode"), Now, Bl.POL, "E", Tax, Toll)
                            TR("Tax") = CalBase.Tax
                            TR("Toll") = CalBase.Duty
                            TB.Rows.Add(TR)
                        End If
                    End If
                Next
            End If
        Next

    End Sub
    Public Sub New()
        TB = New DataTable("Temp")
        TB.Columns.Add(New DataColumn("ChargesCode", System.Type.GetType("System.String")))
        TB.Columns.Add(New DataColumn("Amount", System.Type.GetType("System.Double")))
        TB.Columns.Add(New DataColumn("IrrAmount", System.Type.GetType("System.Double")))
        TB.Columns.Add(New DataColumn("Currency", System.Type.GetType("System.String")))
        TB.Columns.Add(New DataColumn("Tax", System.Type.GetType("System.Double")))
        TB.Columns.Add(New DataColumn("Toll", System.Type.GetType("System.Double")))
    End Sub

    Public ReadOnly Property TBBooking() As DataTable
        Get
            Return TB
        End Get
    End Property

    Public ReadOnly Property InvoiceInIrr() As Boolean
        Get
            Return lInvoiceInIrr
        End Get
    End Property



End Class
