Imports ShippingBiz
Imports OrmLib
Imports Infragistics.Win.UltraWinGrid
Imports Aspose.Words
Imports Aspose.Words.Fields
Imports Aspose.Words.Reporting

Public Class FrmInwardGenaralList

    Private TB As DataTable
    Private Sub FrmInwardGenaralList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Vessel.InitControl(Me.BackColor)
        Me.Voyage.InitControl(Me.BackColor, Me.Vessel)
    End Sub

    Private Sub ToolbarsManager_ToolClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinToolbars.ToolClickEventArgs) Handles ToolbarsManager.ToolClick

        Select Case e.Tool.Key
            Case "To Excel"
                SaveGridToExcel(Me.GridResult)
            Case "Return"
                Me.Close()
            Case "Pickup"
                Me.ExplorerBar.Groups.Item("Document ").Enabled = True
                SetDocument()
            Case "SelAll"
                ChangeSel(True)
            Case "RemoveAll"
                ChangeSel(False)
        End Select

    End Sub

    Private Sub SetDocument()

        Dim sSql As String
        Dim dm As New DataManager(My.Settings.DSN)
        Dim Ds As New DataSet
        sSql = "SP_InwardBlsGenralListByVoyageID '" & CurrentShippingLine & "' , '" & Me.Voyage.VoyageID.ToString & "'"
        Ds = StoredProcedures.SP_InwardBlsGenralListByVoyageID(CurrentShippingLine, Me.Voyage.VoyageID.ToString)
        PopulateGrid(Ds.Tables(0), "")
        Me.GridResult.DisplayLayout.Bands(0).Columns("ID").Hidden = True

    End Sub

    Private Sub PopulateGrid(ByVal TempTb As DataTable, ByVal Header As String)

        Dim Col As DataColumn

        TB = New DataTable
        TB = TempTb.Copy

        With Me.GridResult
            .DisplayLayout.ResetBands()
            .DataSource = TB
        End With

        For Each Col In TB.Columns
            If Col.DataType.Name = "Decimal" Then
                GridResult.DisplayLayout.Bands(0).Columns(Col.ColumnName).Format = "#,###.00"
                GridResult.DisplayLayout.Bands(0).Columns(Col.ColumnName).Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Double
                GridResult.DisplayLayout.Bands(0).Columns(Col.ColumnName).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            End If
        Next

        With Me.GridResult
            .DisplayLayout.Bands(0).HeaderVisible = True
            .DisplayLayout.Bands(0).Header.Caption = Header
            .DisplayLayout.Bands(0).Columns("Select").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        End With

    End Sub
    Private Sub PopulateGrid(ByVal TempDS As DataSet, ByVal Header As String)

        Dim Col As DataColumn

        With Me.GridResult
            .DisplayLayout.ResetBands()
            .DataSource = TempDS.Copy
        End With

        For Each Col In TB.Columns
            If Col.DataType.Name = "Decimal" Then
                GridResult.DisplayLayout.Bands(0).Columns(Col.ColumnName).Format = "#,###.00"
                GridResult.DisplayLayout.Bands(0).Columns(Col.ColumnName).Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Double
                GridResult.DisplayLayout.Bands(0).Columns(Col.ColumnName).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            End If
        Next

        With Me.GridResult
            .DisplayLayout.Bands(0).HeaderVisible = True
            .DisplayLayout.Bands(0).Header.Caption = Header
            '    .DisplayLayout.Bands(0).Columns("Select").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        End With

    End Sub
    Private Sub GridResult_BeforeCellUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeCellUpdateEventArgs) Handles GridResult.BeforeCellUpdate
        If UCase(Me.GridResult.ActiveCell.Column.Header.Caption) <> "SELECT" Then
            e.Cancel = True
        End If
    End Sub

    Private Sub ChangeSel(ByVal lValue As Boolean)

        Dim Dr As DataRow

        If Not TB Is Nothing Then

            For Each Dr In TB.Rows
                Dr("Select") = lValue
            Next

        End If

    End Sub
    Private Sub ExplorerBar_ItemClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinExplorerBar.ItemEventArgs) Handles ExplorerBar.ItemClick

        If Me.GridResult Is Nothing Then
            Exit Sub
        End If
        If GridResult.Rows.Count = 0 Then
            Exit Sub
        End If

        Dim nSel As Long = TB.Select("Select = true").Length


        If Me.GridResult.Rows.Count = 0 Then
            Exit Sub
        End If

        Me.GridResult.UpdateData()

        Select Case e.Item.Text

            Case "Arrival Notice"
                If nSel = 0 Then
                    MsgBox("No Any Selection !")
                    Exit Sub
                End If
                GenArrivalNotice()
            Case "Manifest"
                If nSel = 0 Then
                    MsgBox("No Any Selection !")
                    Exit Sub
                End If
                GenManifest("Y")
            Case "Manifest Cover Page"
                GenMangCoverPage()
            Case "Freight Manifest"
                GenManifest("N")
            Case "B/L Print"
                GenerateBL()
            Case "Containers List"
                Me.ExplorerBar.Groups.Item("Document ").Enabled = False
                GenContainersList()
            Case "XML EDI"
                Me.ExplorerBar.Groups.Item("Document ").Enabled = False
                GenVoyageEDI(EType.XMLType)
            Case "Text EDI "
                Me.ExplorerBar.Groups.Item("Document ").Enabled = False
                GenVoyageEDI(EType.TextType)
            Case "Collect List"
                GenVoyageCollectList()
            Case "DG List"
                GenDgList()
        End Select

    End Sub

    Private Sub GenArrivalNotice()



        '  Dim Report As RptArrivalNotice = New RptArrivalNotice
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument

        Dim Frm As New FrmGeneralReportShow

        Dim Dm As DataManager
        Dim Arvl As New CLArrivalNotice
        Dim Voy As TB_Voyage
        Dim Sof As TB_SOF
        Dim TB As DataTable
        Dim Dr As DataRow
        Dim PH As New CLPrintHdr
        Dim Rel As DataRelation
        Dim PCol(0) As DataColumn
        Dim cCol(0) As DataColumn
        Dim RptItems As TB_ReportCustomFieldsCollection
        Dim RptItem As TB_ReportCustomFields
        Dim LN As TB_Lines


        Report = New RptArrivalNotice

        Dm = New DataManager(My.Settings.DSN)
        Dm.QueryCriteria.And(JoinPath.TB_Voyage.Columns.ID, Me.Voyage.VoyageID, MatchType.Exact)
        Voy = Dm.GetTB_Voyage

        If Not Voy Is Nothing Then

            Dm.QueryCriteria.Clear()
            Dm.QueryCriteria.And(JoinPath.TB_SOF.Columns.VoyageID, Me.Voyage.VoyageID, MatchType.Exact)
            Sof = Dm.GetTB_SOF
            If Sof Is Nothing Then
                MsgBoxGeneral("No SOF For This Voyage !", "Data Requird")
                Exit Sub
            Else
                If Sof.Arrival.IsNull Then
                    MsgBoxGeneral("Arrival date is not filled !", "Data Requird")
                    Exit Sub
                End If
            End If
        Else
            MsgBoxGeneral("Invalid Voyage !", "Data Requird")
            Exit Sub
        End If

        TB = Me.GridResult.DataSource

        For Each Dr In TB.Rows
            If Dr("Select") = 1 Then
                Arvl.GenArrivalNotice(Dr, CDate(Format(DateTime.Parse(Sof.DschCmpl), "Short Date")), Voy, True)
            End If
        Next

        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_ReportCustomFields.Columns.ReportName, "RptArrivalNotice", MatchType.Exact)
        RptItems = Dm.GetTB_ReportCustomFieldsCollection

        Report.SetDataSource(Arvl.Master)
        Report.Subreports("Details").SetDataSource(Arvl.Detail)
        Report.Subreports("SUBB").SetDataSource(Arvl.BLCharges)

        For Each RptItem In RptItems
            Report.SetParameterValue(RptItem.FieldName, GetImageInStr(RptItem.ID.ToString))
        Next

        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_Lines.Columns.LineCode, CurrentShippingLine, MatchType.Exact)
        LN = Dm.GetTB_Lines

        Report.SetParameterValue("ShippingLine", LN.LineName)

        Frm.ReportViewer.ReportSource = Report

        Frm.Text = "Arrival Notice"
        Frm.MaximizeBox = False
        Frm.Show()


    End Sub

    Private Sub GenManifest(ByVal IsCargo As String)

        Dim Mnf As New CLInwardManifest
        Mnf.GenrateMnf(Me.GridResult.DataSource, Me.Voyage.GetDocument)
        Mnf.ShowReport(IsCargo)


    End Sub

    Private Sub GenMangCoverPage()

        Dim Mnf As New CLInwardManifest
        If Me.GridResult.Rows.Count > 0 Then
            Mnf.MnfCover(Me.Voyage.GetDocument, Me.Voyage.VesselName)
        End If

    End Sub

    Private Sub GenerateBL()

        Dim Frm As FrmDialogPrint
        If Me.GridResult.Rows.Count = 0 Then
            Frm = New FrmDialogPrint(FrmDialogPrint.InwardOutward.Inward, "")
        Else
            Frm = New FrmDialogPrint(FrmDialogPrint.InwardOutward.Inward, Me.GridResult.ActiveRow.Cells("BLNO").Value.ToString, Me.GridResult)
        End If
        Frm.Show()
    End Sub

    Private Sub GenContainersList()

        Dim sSql As String
        Dim dm As New DataManager(My.Settings.DSN)
        Dim Ds As New DataSet
        Dim RL As DataRelation
        Dim Pcol As DataColumn
        Dim CCol As DataColumn
        sSql = "SP_InwardCntrsListByVoyageID '" & CurrentShippingLine & "' , '" & Me.Voyage.VoyageID.ToString & "'"
        Ds = StoredProcedures.SP_InwardCntrsListByVoyageID(CurrentShippingLine, Me.Voyage.VoyageID.ToString)

        Pcol = Ds.Tables(0).Columns("CntrNo")
        CCol = Ds.Tables(1).Columns("CntrNo")

        RL = New DataRelation("Cntrs", Pcol, CCol)
        Ds.Relations.Add(RL)

        PopulateGrid(Ds, "Containers List")

        Me.GridResult.DisplayLayout.Bands(0).Columns("ID").Hidden = True
        Me.GridResult.DisplayLayout.Bands(1).Columns("ID").Hidden = True

    End Sub

    Private Sub GenVoyageEDI(ByVal FileType As EType)

        Dim EDI As New EDICls
        Dim aBls As New ArrayList
        Dim Row As UltraGridRow
        Me.GridResult.Update()
        Me.GridResult.UpdateData()

        For Each Row In GridResult.Rows
            If Row.Cells("Select").Value = 1 Then
                aBls.Add(New String() {Row.Cells("Line").Value.ToString, Row.Cells("BLNO").Value.ToString})
            End If
        Next
        EDI.GenerateInwardData(FileType, aBls)

    End Sub


    Private Sub GenVoyageCollectList()

        Dim SQL As String
        Dim TB As DataTable
        Dim lResult As Boolean
        SQL = "SP_InwardCollectList '" & Me.Voyage.VoyageID.ToString & "'"
        TableBySql(SQL, TB, lResult)
        If lResult = False Then
            MsgBox("No Data !")
            Exit Sub
        End If
        Dim Frm As New FrmDialogShowGrid("Collect List ", "Collect List For " & Me.Vessel.VesselName & " " & Me.Voyage.CmbVoyage.Text, TB)
        Frm.ShowDialog()

    End Sub

    Private Sub GenDgList()


        Dim SQL As String
        Dim TB As DataTable
        Dim lResult As Boolean
        SQL = "SP_InwardDGListByVoyageID '" & Me.Voyage.VoyageID.ToString & "'"
        TableBySql(SQL, TB, lResult)
        If lResult = False Then
            MsgBox("No Data !")
            Exit Sub
        End If
        Me.GridResult.DataSource = TB

    End Sub

End Class