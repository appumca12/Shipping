Imports System.Data.SqlClient
Imports OrmLib
Imports ShippingBiz
Imports Infragistics.Win

Public Class UserBlsFinancial
    Enum InwardOutward
        Inward
        Outward
    End Enum
    Private InOut As InwardOutward
    Private BLDR As DataRow
    Private Voyage As TB_Voyage
    Private Sof As TB_SOF
    Private TbResult As DataTable

    Private DETN As CLDetention

    Public Sub InitControl()

        TbResult = New DataTable
        With TbResult
            .Columns.Add(New DataColumn("Seq", System.Type.GetType("System.Int32")))
            .Columns.Add(New DataColumn("ChargesCode"))
            .Columns.Add(New DataColumn("Type"))
            .Columns.Add(New DataColumn("Currency"))
            .Columns.Add(New DataColumn("Description"))
            .Columns.Add(New DataColumn("Due", System.Type.GetType("System.Double")))
            .Columns.Add(New DataColumn("Paid", System.Type.GetType("System.Double")))
            .Columns.Add(New DataColumn("Balance", System.Type.GetType("System.Double")))
        End With

        Me.GridData.DataSource = TbResult
        With Me.GridData.DisplayLayout.Bands(0)
            .Columns("Seq").Hidden = True
            .Columns("ChargesCode").Hidden = True
            .Columns("Type").SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Ascending
            .Columns("Seq").SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Ascending
            .Columns("Currency").SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Ascending
            .Columns(1).MergedCellEvaluationType = Infragistics.Win.UltraWinGrid.MergedCellEvaluationType.MergeSameText
            .Columns(2).MergedCellEvaluationType = Infragistics.Win.UltraWinGrid.MergedCellEvaluationType.MergeSameText
            .Columns(2).Width = 98
            .Columns(3).Width = 66
            .Columns(4).Width = 340
            .Columns(5).Width = 100
            .Columns(6).Width = 100
            .Columns(7).Width = 14
        End With

    End Sub
    Public Sub SetDocument(ByVal InOut As InwardOutward, ByVal BLDR As DataRow, ByVal Voy As TB_Voyage, ByVal Sof As TB_SOF, ByVal DTN As CLDetention)

        Me.Voyage = Voy
        Me.BLDR = BLDR
        Me.Sof = Sof
        DETN = DTN

        Me.InOut = InOut
        If TbResult Is Nothing Then
            TbResult = New DataTable
            With TbResult
                .Columns.Add(New DataColumn("Seq", System.Type.GetType("System.Int32")))
                .Columns.Add(New DataColumn("ChargesCode"))
                .Columns.Add(New DataColumn("Type"))
                .Columns.Add(New DataColumn("Currency"))
                .Columns.Add(New DataColumn("Description"))
                .Columns.Add(New DataColumn("Due", System.Type.GetType("System.Double")))
                .Columns.Add(New DataColumn("Paid", System.Type.GetType("System.Double")))
                .Columns.Add(New DataColumn("Balance", System.Type.GetType("System.Double")))
            End With
        Else
            TbResult.Clear()
            TbResult.AcceptChanges()
        End If
 
        If InOut = InwardOutward.Inward Then
            GenInwardDocument()
        Else
            GenOutwardDocument()
        End If

    End Sub

    Private Sub GenInwardDocument()

        Dim Arval As New CLArrivalNotice
        Dim Dr As DataRow
        Dim NewDr As DataRow
        Dim DTN As New CLDetention
        Dim sSql As String
        Dim TB As New DataTable
        Dim lResult As Boolean
        Dim Drs() As DataRow
        Dim Drs2 As DataRow

        Dim TBTotal As DataTable
        TBTotal = TbResult.Copy

        If Not Sof Is Nothing Then

            Arval.GenArrivalNotice(BLDR, Sof.Berthed, Voyage, True)

            For Each Dr In Arval.GetTBDetails.Select("ChargeItem <> 'TAX'")

                NewDr = TbResult.NewRow
                NewDr("Description") = Dr("Meaning")
                NewDr("Seq") = Dr("Seq")
                NewDr("ChargesCode") = Dr("ChargeItem")
                If Dr("ChargeItem") = "THC" Then
                    NewDr("Currency") = "IRR"
                Else
                    NewDr("Currency") = Dr("CurCode")
                End If
                NewDr("Due") = Dr("DepositAmount") + Dr("ConditionalAmount") + Dr("MandatoryAmount")
                If Dr("IsDeposit") = True Then
                    NewDr("Type") = "Deposit"
                Else
                    NewDr("Type") = "Cashable"
                End If
                TbResult.Rows.Add(NewDr)
            Next

            NewDr = TbResult.NewRow
            NewDr("Seq") = 60
            NewDr("ChargesCode") = "DETN"
            NewDr("Description") = "DETENTION"
            NewDr("Currency") = "IRR"
            NewDr("Due") = DETN.TotalAmount
            NewDr("Type") = "Cashable"
            NewDr("Paid") = (DETN.Paid + DETN.FirstPaid)
            TbResult.Rows.Add(NewDr)

            If DETN.TotalDamageCost > 0 Then
                NewDr = TbResult.NewRow
                NewDr("Seq") = 70
                NewDr("ChargesCode") = "DMCT"
                NewDr("Description") = "DAMAGE COST"
                NewDr("Currency") = "IRR"
                NewDr("Due") = DETN.TotalDamageCost
                NewDr("Paid") = DETN.PaidDamage
                NewDr("Type") = "Cashable"
                NewDr("Paid") = 0
                TbResult.Rows.Add(NewDr)
            End If

            If DETN.TotalDamageCostUsd > 0 Then
                NewDr = TbResult.NewRow
                NewDr("Seq") = 70
                NewDr("ChargesCode") = "DMCT"
                NewDr("Description") = "DAMAGE COST"
                NewDr("Currency") = "USD"
                NewDr("Due") = DETN.TotalDamageCostUsd
                NewDr("Paid") = DETN.PaidDamageUsd
                NewDr("Type") = "Cashable"
                NewDr("Paid") = 0
                TbResult.Rows.Add(NewDr)
            End If

            sSql = "Select * From TB_Invoice I , TB_InvoiceDetails D Where I.ID = D.InvoiceID and Status = '3' and BLID = '" & BLDR("ID").ToString & "'"
            TableBySql(sSql, TB, lResult)

            For Each Dr In TB.Rows
                If Dr("ChargesCode") = "TOLL" Then
                    Dr("ChargesCode") = "TAX"
                End If
            Next
            TB.AcceptChanges()

            For Each Dr In TbResult.Rows
                If Not (Dr("ChargesCode") = "DMCT" Or Dr("ChargesCode") = "DETN") Then
                    Drs = TB.Select("ChargesCode = '" & Dr("ChargesCode") & "'")
                    If Drs.Length > 0 Then
                        For Each dr2 In Drs
                            Dr("Paid") = NullToValue(Dr("Paid"), 0) + dr2("IrrAmount")
                        Next
                    End If
                End If
            Next

            For Each Dr In TbResult.Rows
                Drs = TBTotal.Select("Description = 'TOTAL' and Currency = '" & Dr("Currency") & "' and Type = '" & Dr("Type") & "'")
                If Drs.Length > 0 Then
                    Drs(0).Item("Due") = Drs(0).Item("Due") + Dr("Due")
                    Drs(0).Item("Paid") = NullToValue(Drs(0).Item("Paid"), 0) + NullToValue(Dr("Paid"), 0)
                Else
                    NewDr = TBTotal.NewRow
                    NewDr("Description") = "TOTAL"
                    NewDr("Seq") = 100
                    NewDr("Currency") = "IRR"
                    NewDr("Paid") = Dr("Paid")
                    NewDr("Due") = Dr("Due")
                    NewDr("Type") = Dr("Type")
                    TBTotal.Rows.Add(NewDr)
                End If
            Next

            For Each Dr In TBTotal.Rows
                Dr("Balance") = Dr("Due") - NullToValue(Dr("Paid"), 0)
            Next

            For Each Dr In TBTotal.Rows
                TbResult.ImportRow(Dr)
            Next

            For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In GridData.Rows
                If row.Cells("Description").Value = "TOTAL" Then
                    row.Appearance.BackColor = Color.Navy
                    row.Appearance.ForeColor = Color.White
                    row.Appearance.FontData.Bold = DefaultableBoolean.True
                Else
                    row.Appearance.BackColor = Color.Cyan
                End If
            Next
        Else
            TbResult.Clear()
        End If

        Me.GridData.DataSource = TbResult
        With Me.GridData.DisplayLayout.Bands(0)
            .Columns("Seq").Hidden = True
            .Columns("ChargesCode").Hidden = True
            .Columns("Type").SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Ascending
            .Columns("Seq").SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Ascending
            .Columns("Currency").SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Ascending
            .Columns(1).MergedCellEvaluationType = Infragistics.Win.UltraWinGrid.MergedCellEvaluationType.MergeSameText
            .Columns(2).MergedCellEvaluationType = Infragistics.Win.UltraWinGrid.MergedCellEvaluationType.MergeSameText
            .Columns(2).Width = 98
            .Columns(3).Width = 66
            .Columns(4).Width = 340
            .Columns(5).Width = 100
            .Columns(6).Width = 100
            .Columns(7).Width = 14
        End With

        GridNumSeperator(Me.GridData)

    End Sub

    Private Sub GenOutwardDocument()

    End Sub

  
    Private Sub GridData_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles GridData.InitializeLayout
        Me.GridData.DisplayLayout.Override.MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always
    End Sub

    Public Property MyGridData() As Object
        Get
            Return GridData
        End Get
        Set(ByVal value As Object)
            GridData = MyGridData
        End Set
    End Property


   

End Class
