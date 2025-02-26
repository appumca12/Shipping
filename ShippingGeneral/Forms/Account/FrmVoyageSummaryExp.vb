Imports OrmLib
Imports ShippingBiz
Imports Infragistics.Shared
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinEditors
Imports System.Data.SqlClient
Public Class FrmVoyageSummaryExp

    Private DM As DataManager
    Private Sof As TB_SOF
    Private TBMaster As DataTable
    Private Voy As TB_Voyage
    Private Sub FrmAccGnrlReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Voyage.InitControl(Me.BackColor, Me.Vessel)
        Me.Vessel.InitControl(Me.BackColor)

    End Sub

    Private Sub GridResult_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs)
        e.Layout.Override.SupportDataErrorInfo = SupportDataErrorInfo.RowsAndCells
        e.Layout.Override.DataErrorCellAppearance.ForeColor = Color.Red
        e.Layout.Override.DataErrorRowAppearance.BackColor = Color.LightYellow
        e.Layout.Override.DataErrorRowSelectorAppearance.BackColor = Color.Green
        e.Layout.Override.RowSelectorWidth = 32
    End Sub

    Private Sub ButtonExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        SaveGridToExcel(Me.GridFrieght)

    End Sub
    Private Sub GetVoyageSummary()

      

    End Sub

    Private Sub MenuItem_CustomPickupClick() Handles MenuItem.CustomPickupClick

        Dim Ds As DataSet
        Dim Prm As SqlClient.SqlParameter
        Dim arrayParams As New ArrayList

        If Me.Voyage.VoyageID.ToString = "" Then
            Exit Sub
        End If

        Prm = New SqlClient.SqlParameter("VoyageID", SqlDbType.Char, 36, ParameterDirection.Input)
        Prm.Value = Me.Voyage.VoyageID.ToString
        arrayParams.Add(Prm)

        DM = New DataManager(My.Settings.DSN)
        Ds = DM.ExecuteProcedure("SP_OutwardVoyageAccount", CType(arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
        TBMaster = Ds.Tables(0)
        If Ds.Tables(0).Rows.Count = 0 Then
            MsgBox("No any data !")
            Exit Sub
        Else
            DM.QueryCriteria.Clear()
            DM.QueryCriteria.And(JoinPath.TB_SOF.Columns.VoyageID, Me.Voyage.VoyageID, MatchType.Exact)
            Sof = DM.GetTB_SOF
            Me.GridFrieght.DataSource = TBMaster
            GridNumSeperator(Me.GridFrieght)
            With Me.GridFrieght.DisplayLayout.Bands(0)
                .HeaderVisible = True
                .Header.Activated = True
                .Header.Caption = "Freight Summary For " & Me.Vessel.VesselName & " " & Me.Voyage.CmbVoyage.Text & " Arrival " & Sof.Arrival.ToString
                .Header.Appearance.BackColor = Color.Maroon
                .Header.Appearance.ForeColor = Color.Yellow
                .Header.Appearance.FontData.Name = "Verdana"
                .Header.Appearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.True
                .Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                .Header.Appearance.FontData.SizeInPoints = 8
            End With
        End If
        DM.QueryCriteria.Clear()
        DM.QueryCriteria.And(JoinPath.TB_Voyage.Columns.ID, Voyage.VoyageID, MatchType.Exact)
        Voy = DM.GetTB_Voyage
        GenerateTable()


    End Sub

    Private Sub GenerateTable()

        Dim Ds As DataSet
        Dim Dr As DataRow
        Dim Drs() As DataRow
        Dim TBLocal As DataTable
        Dim NewDr As DataRow
        Dim nI As Byte
        Dim Dpt As CLDeparturCost = New CLDeparturCost
        ' Dpt.GenDeparturCost(DM.DataSet.Tables("TB_OutWardBls").Rows(0), Sof.Sailed, Voy)

        Dim R As DataRow
        Dim Invoices As TB_ExpInvoiceCollection
        Dim Invoice As TB_ExpInvoice
        Dim InvDetails As TB_ExpInvoiceDetailsCollection
        Dim InvDetail As TB_ExpInvoiceDetails
        Dim BLRows() As DataRow

        Ds = StoredProcedures.SP_ChgLevelAllByDate(Sof.Sailed)


        TBLocal = New DataTable
        For nI = 0 To 11
            TBLocal.Columns.Add(New DataColumn(TBMaster.Columns(nI).ColumnName, TBMaster.Columns(nI).DataType))
        Next

        TBLocal.Columns.Add(New DataColumn("DoDate", System.Type.GetType("System.DateTime")))
        TBLocal.Columns.Add(New DataColumn("Received at", System.Type.GetType("System.String")))

        Drs = Ds.Tables(0).Select("IsDeposit = false", "Seq")

        For Each Dr In Drs
            Try
                If Dr("ImportExport") <> "I" Then
                    TBLocal.Columns.Add(New DataColumn(Dr("ChargeItem"), System.Type.GetType("System.Int64")))
                End If
            Catch ex As Exception
            End Try
        Next

        Me.GridLocal.DataSource = TBLocal
        For Each Dr In TBMaster.Rows
            NewDr = TBLocal.NewRow
            For nI = 0 To 11
                NewDr(nI) = Dr(nI)
            Next
            TBLocal.Rows.Add(NewDr)
        Next
        GridNumSeperator(Me.GridLocal)
        With Me.GridLocal.DisplayLayout.Bands(0)
            .HeaderVisible = True
            .Header.Activated = True
            .Header.Caption = "Local Charges For " & Me.Vessel.VesselName & " " & Me.Voyage.CmbVoyage.Text & " Arrival " & Sof.Arrival.ToString
            .Header.Appearance.BackColor = Color.Maroon
            .Header.Appearance.ForeColor = Color.Yellow
            .Header.Appearance.FontData.Name = "Verdana"
            .Header.Appearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.True
            .Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
            .Header.Appearance.FontData.SizeInPoints = 8
        End With
        For Each Dr In TBLocal.Rows
            DM.QueryCriteria.Clear()
            DM.QueryCriteria.And(JoinPath.TB_Invoice.Columns.BLID, Dr("ID"), MatchType.Exact)
            DM.QueryCriteria.And(JoinPath.TB_Invoice.Columns.Status, "3", MatchType.Exact)
            DM.GetTB_Invoice()
            Invoices = DM.GetTB_ExpInvoiceCollection
            Invoices = Invoices.SortByConfirmTime(SortDirection.Ascending)
            If Invoices.Count > 0 Then
                Dr("Received at") = Invoices(0).ConfirmOffice
                DM.QueryCriteria.Clear()
                DM.QueryCriteria.And(JoinPath.TB_InwardStatus.Columns.BLID, Dr("ID"), MatchType.Exact)
                For Each Invoice In Invoices
                    DM.QueryCriteria.Clear()
                    DM.QueryCriteria.And(JoinPath.TB_InvoiceDetails.Columns.InvoiceID, Invoice.ID, MatchType.Exact)
                    InvDetails = DM.GetTB_ExpInvoiceDetailsCollection
                    For Each InvDetail In InvDetails
                        Try
                            Dr(InvDetail.ChargesCode) = Double.Parse(InvDetail.IRRAmount.ToString)
                        Catch ex As Exception
                            TBLocal.Columns.Add(New DataColumn(InvDetail.ChargesCode, System.Type.GetType("System.Int64")))
                            Dr(InvDetail.ChargesCode) = Double.Parse(InvDetail.IRRAmount.ToString)
                        End Try
                    Next
                Next
            Else
                DM.QueryCriteria.Clear()
                DM.QueryCriteria.And(JoinPath.TB_OutwardBLS.Columns.ID, Dr("ID"), MatchType.Exact)
                DM.GetTB_OutwardBLS()
                BLRows = DM.DataSet.Tables("TB_OutwardBls").Select("ID = '" & Dr("ID").ToString & "'")
                Dpt.GenDeparturCost(BLRows(0), Sof.Sailed, Voy)
                Drs = Dpt.GetTBDetails.Select("BLNO = '" & Dr("BLNO") & "' and IsDeposit = false")
                For Each R In Drs
                    Dr(R("ChargeItem")) = R("MandatoryAmount") + R("ConditionalAmount")
                Next
                Drs = Dpt.GetTbError.Select("BLNO = '" & Dr("BLNO") & "'")
                For Each R In Drs
                    Dr.RowError = Dr.RowError & " " & R("ErrMsg")
                Next
            End If
        Next

    End Sub

    Private Sub GridLocal_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles GridLocal.InitializeLayout
        e.Layout.Override.SupportDataErrorInfo = SupportDataErrorInfo.RowsAndCells
        e.Layout.Override.DataErrorCellAppearance.ForeColor = Color.Red
        e.Layout.Override.DataErrorRowAppearance.BackColor = Color.LightYellow
        e.Layout.Override.DataErrorRowSelectorAppearance.BackColor = Color.Green
        e.Layout.Override.RowSelectorWidth = 32
    End Sub

    Private Sub UltraContainers_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles UltraContainers.InitializeLayout
        e.Layout.Override.SupportDataErrorInfo = SupportDataErrorInfo.RowsAndCells
        e.Layout.Override.DataErrorCellAppearance.ForeColor = Color.Red
        e.Layout.Override.DataErrorRowAppearance.BackColor = Color.LightYellow
        e.Layout.Override.DataErrorRowSelectorAppearance.BackColor = Color.Green
        e.Layout.Override.RowSelectorWidth = 32
    End Sub

    Private Sub GridFrieght_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles GridFrieght.InitializeLayout
        e.Layout.Override.SupportDataErrorInfo = SupportDataErrorInfo.RowsAndCells
        e.Layout.Override.DataErrorCellAppearance.ForeColor = Color.Red
        e.Layout.Override.DataErrorRowAppearance.BackColor = Color.LightYellow
        e.Layout.Override.DataErrorRowSelectorAppearance.BackColor = Color.Green
        e.Layout.Override.RowSelectorWidth = 32
    End Sub

    Private Sub MenuItem_CustomSaveClick() Handles MenuItem.CustomSaveClick



    End Sub

    Private Sub MenuItem_CustomToExcelClick() Handles MenuItem.CustomToExcelClick
        Select Case Me.TABS.SelectedTab.Text
            Case "Freight Summary"
                SaveGridToExcel(Me.GridFrieght)
            Case "Local Charges Summary"
                SaveGridToExcel(Me.GridLocal)
            Case Else

        End Select
    End Sub
End Class