Imports System.Data.SqlClient
Imports OrmLib
Imports ShippingBiz
Imports Infragistics.Win.UltraWinGrid

Public Class FrmGroupInvoice
    Private TBBls As New DataTable
    Private DS As DataSet
    Private ArvlDs As DataSet
    'For ILS Shortcuts  
    Private Sub TexBLNO_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles TexBLNO.KeyDown

        If e.KeyValue = 13 Then
            ButtonPickp_Click(sender, e)
        End If

    End Sub
    Private Sub ButtonPickp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPickp.Click

        Dim lResult As Boolean
        Dim GRow As Infragistics.Win.UltraWinGrid.UltraGridRow

        If Me.TexBLNO.Text = "" Then
            Exit Sub
        End If

        DataSetBySql("SP_ListOfBlsByMasterBL '" & Me.TexBLNO.Text & "'", DS, lResult)
        TBBls = DS.Tables(0)

        Me.GridBls.DataSource = TBBls
        Me.GridCntrs.DataSource = DS.Tables(2)

        GridNumSeperator(Me.GridBls)


        For Each GRow In GridBls.Rows
            If GRow.Cells("Total Confirm").Value > 0 Then
                GRow.Cells("BLNO").Appearance.BackColor = Color.Red
            ElseIf GRow.Cells("Total Issue").Value > 0 Then
                GRow.Cells("BLNO").Appearance.BackColor = Color.Yellow
            Else
                GRow.Cells("BLNO").Appearance.BackColor = Color.White
            End If
        Next


    End Sub

    Private Sub ButtonChecking_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonChecking.Click


        Dim ARVL As New CLArrivalNotice
        Dim DTN As New CLDetention

        Dim Dr As DataRow
        Dim Drs() As DataRow
        Dim DrBls() As DataRow

        Dim Voy As TB_Voyage
        Dim SOF As TB_SOF
        Dim DrBl As DataRow
        Dim DM As New DataManager(My.Settings.DSN)
        Dim RL As DataRelation
        Dim pCol As DataColumn
        Dim cCol As DataColumn
        Dim NewDr As DataRow

        ArvlDs = New DataSet

        Me.GridBls.UpdateData()
        Drs = TBBls.Select("Select = true", "")

        If Drs.Length = 0 Then
            MsgBox("No Any Selection !")
            Exit Sub
        End If

        For Each Dr In Drs
            DrBls = DS.Tables(1).Select("BLNO = '" & Dr("BLNO") & "'")
            DrBl = DrBls(0)

            DM.QueryCriteria.Clear()
            DM.QueryCriteria.And(JoinPath.TB_Voyage.Columns.ID, DrBl("VoyageID"), MatchType.Exact)
            Voy = DM.GetTB_Voyage

            DM.QueryCriteria.Clear()
            DM.QueryCriteria.And(JoinPath.TB_SOF.Columns.VoyageID, DrBl("VoyageID"), MatchType.Exact)
            DM.QueryCriteria.And(JoinPath.TB_SOF.Columns.Port, DrBl("Pod"), MatchType.Exact)
            SOF = DM.GetTB_SOF

            If SOF.Berthed.IsNull Then
                ARVL.GenArrivalNotice(DrBls(0), Now.Date, Voy)
            Else
                ARVL.GenArrivalNotice(DrBls(0), SOF.Berthed, Voy)
            End If

            DTN = New CLDetention
            DTN.CalDetention(DrBl("BLNO"), DrBl("ID"), False)

            If DTN.Balance > 0 Then
                NewDr = ARVL.GetTBDetails.NewRow
                NewDr("BLNO") = DrBl("BLNO")
                NewDr("MandatoryAmount") = DTN.Balance
                NewDr("ChargeItem") = "DETN-A"
                NewDr("Seq") = 10
                NewDr("Curcode") = "IRR"
                NewDr("MeaningF") = "علی الحساب حق توقف"
                ARVL.GetTBDetails.Rows.Add(NewDr)
            End If

        Next

        ARVL.GetTBDetails.AcceptChanges()
        For Each Dr In ARVL.GetTBDetails.Rows
            If Dr("IsDeposit") = True Then
                Dr.Delete()
            End If
        Next

        ARVL.GetTBDetails.AcceptChanges()
        For Each Dr In ARVL.GetTBDetails.Rows
            If Dr("MandatoryAmount") = 0 Then
                Dr.Delete()
            End If
        Next
        ARVL.GetTBDetails.AcceptChanges()



        ArvlDs = New DataSet

        With ArvlDs
            .Tables.Add(ARVL.Master)
            .Tables.Add(ARVL.GetTBDetails)
        End With

        pCol = ArvlDs.Tables(0).Columns("BLNO")
        cCol = ArvlDs.Tables(1).Columns("BLNO")
        RL = New DataRelation("BlS", pCol, cCol)
        ArvlDs.Relations.Add(RL)

        Me.GridInvoices.DataSource = ArvlDs
        Me.GridError.DataSource = ARVL.GetTbError
 
    End Sub

    Private Sub ButtonALL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonALL.Click
        For Each dr As DataRow In TBBls.Rows
            dr("Select") = True
        Next
        TBBls.AcceptChanges()
        Me.GridBls.DataSource = TBBls
    End Sub

    Private Sub ButtonDeSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDeSelect.Click
        For Each dr As DataRow In TBBls.Rows
            dr("Select") = False
        Next
        Me.GridBls.DataSource = TBBls
    End Sub

    Private Sub ButtonGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGenerate.Click

        Dim DR As DataRow
        Dim Drs() As DataRow
        Dim NewDr As DataRow
        Dim InvID As Guid
        Dim LogDataset As DataSet
        Dim TTLIrr As Double
        Dim CalBase As New CLCalculationBase
        Dim DM = New DataManager(My.Settings.DSN)
        Dim nSeq As Integer

        If Me.GridError.Rows.Count > 0 Then
            MsgBox("Please Check Errors in Error Tab First !")
            Exit Sub
        End If

        If Me.GridInvoices.Rows.Count = 0 Then
            MsgBox("No any Invoice For Save !")
            Exit Sub
        End If

        For Each DR In ArvlDs.Tables(0).Rows
            nSeq = 0
            InvID = Guid.NewGuid
            NewDr = DM.DataSet.Tables("TB_Invoice").NewRow()
            NewDr("ID") = InvID
            NewDr("BlID") = TBBls.Select("BLNO = '" & DR("BLNO") & "'")(0).Item("BlID")
            NewDr("IssueTime") = Format(Now, "Short Date")
            NewDr("IssueBy") = CurrentUser.UserCode
            NewDr("Status") = 2
            NewDr("Description") = TBBls.Select("BLNO = '" & DR("BLNO") & "'")(0).Item("ClientFName")
            DM.DataSet.Tables("TB_Invoice").Rows.Add(NewDr)

            CalBase.GetTaxDutyInward(TBBls.Select("BLNO = '" & DR("BLNO") & "'")(0).Item("BlID"), True)

            For Each Item As DataRow In ArvlDs.Tables(1).Select("BLNO = '" & DR("BLNO") & "' and ChargeItem <> 'TAX'", "Seq")
                nSeq += 1
                NewDr = DM.DataSet.Tables("TB_InvoiceDetails").NewRow
                NewDr("ID") = System.Guid.NewGuid
                NewDr("InvoiceID") = InvID
                NewDr("ChargesCode") = Item("ChargeItem")
                NewDr("Seq") = nSeq ' Item("Seq")
                NewDr("Amount") = Item("ActualAmount")
                NewDr("IrrAmount") = Item("MandatoryAmount")
                NewDr("Currency") = Item("CurCode")
                NewDr("Remarks") = Item("MeaningF")
                DM.DataSet.Tables("TB_InvoiceDetails").Rows.Add(NewDr)
            Next
            TTLIrr = 0
            For Each Item As DataRow In ArvlDs.Tables(1).Select("BLNO = '" & DR("BLNO") & "'", "")
                If Not (Item("ChargeItem") = "TAX" Or Item("ChargeItem") = "DETN-A") Then
                    TTLIrr += Item("MandatoryAmount")
                End If
            Next

            If calculationBase.IsTaxDutyJoin = True Then

                nSeq += 1
                NewDr = DM.DataSet.Tables("TB_InvoiceDetails").NewRow
                NewDr("Seq") = 98
                NewDr("ID") = Guid.NewGuid
                NewDr("InvoiceID") = InvID
                NewDr("ChargesCode") = "TAX"
                NewDr("IRRAmount") = Int((TTLIrr * (CalBase.Tax + CalBase.Duty)) / 100).ToString
                NewDr("Amount") = Int((TTLIrr * (CalBase.Tax + CalBase.Duty)) / 100).ToString
                NewDr("Remarks") = (CalBase.Tax + CalBase.Duty).ToString & "%" & " بابت مالیات و عوارض ارزش افزوده "
                NewDr("Currency") = "IRR"
                DM.DataSet.Tables("TB_InvoiceDetails").Rows.Add(NewDr)

            Else

                nSeq += 1
                NewDr = DM.DataSet.Tables("TB_InvoiceDetails").NewRow
                NewDr("Seq") = nSeq
                NewDr("ID") = Guid.NewGuid
                NewDr("InvoiceID") = InvID
                NewDr("IRRAmount") = Int((TTLIrr * (CalBase.Tax)) / 100).ToString
                NewDr("Amount") = Int((TTLIrr * (CalBase.Tax)) / 100).ToString
                NewDr("ChargesCode") = "TAX"
                NewDr("Remarks") = (CalBase.Tax).ToString & "%" & " بابت مالیات و عوارض ارزش افزوده "
                NewDr("Currency") = "IRR"
                DM.DataSet.Tables("TB_InvoiceDetails").Rows.Add(NewDr)

                nSeq += 1
                NewDr = DM.DataSet.Tables("TB_InvoiceDetails").NewRow
                NewDr("Seq") = nSeq
                NewDr("ID") = Guid.NewGuid
                NewDr("InvoiceID") = InvID
                NewDr("ChargesCode") = "TOLL"
                NewDr("IRRAmount") = Int((TTLIrr * (CalBase.Duty)) / 100).ToString
                NewDr("Amount") = Int((TTLIrr * (CalBase.Duty)) / 100).ToString
                NewDr("Remarks") = (CalBase.Duty).ToString & "%" & " بابت مالیات و عوارض ارزش افزوده "
                NewDr("Currency") = "IRR"
                DM.DataSet.Tables("TB_InvoiceDetails").Rows.Add(NewDr)

            End If


        Next

        Try
            LogDataSet = DM.DataSet.Copy
            DM.CommitAll()
            GenerateLog(LogDataSet)
            MsgBoxSaveSuccessful()
        Catch ex As Exception
            MsgBoxSaveFailed()
            MsgBox(ex.ToString)
        End Try


    End Sub

    Private Sub GridBls_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles GridBls.InitializeLayout
        e.Layout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
    End Sub

    Private Sub GridInvoices_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles GridInvoices.InitializeLayout
        e.Layout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
    End Sub

    Private Sub GridCntrs_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles GridCntrs.InitializeLayout
        e.Layout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
    End Sub
End Class