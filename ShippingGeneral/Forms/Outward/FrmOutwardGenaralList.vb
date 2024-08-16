Imports ShippingBiz
Imports OrmLib
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports Infragistics.Win.UltraWinGrid
Public Class FrmOutwardGenaralList

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
                SetDocument()
            Case "SelAll"
                ChangeSel(True)
            Case "RemoveAll"
                ChangeSel(False)
        End Select

    End Sub

    Private Sub SetDocument()

        Dim dm As New DataManager(My.Settings.DSN)
        Dim Ds As New DataSet

        Ds = StoredProcedures.SP_outwardBlsGenralListByVoyageID(CurrentShippingLine, Me.Voyage.VoyageID.ToString)
        PopulateGrid(Ds.Tables(0), "")
        'Me.GridResult.DisplayLayout.Bands(0).Columns("ID").Hidden = True

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

        If Me.GridResult.Rows.Count = 0 Then
            Exit Sub
        End If

        Select Case e.Item.Text
            Case "Manifest"
                GenManifest("Y")
            Case "Manifest Cover Page"
                GenMangCoverPage()
            Case "Freight Manifest"
                GenManifest("N")
            Case "B/L Print"
                GenerateBL()
            Case "Containers list"
                GenContainersList()
            Case "T.D.R."
                GenTDR()

        End Select

    End Sub

    Private Sub GenManifest(ByVal IsCargo As String)

        Dim Mnf As New CLOutwardManifest
        Mnf.GenrateMnf(Me.GridResult.DataSource, Me.Voyage.GetDocument)
        Mnf.ShowReport(IsCargo)

    End Sub

    Private Sub GenMangCoverPage()

        Dim Mnf As New CLOutwardManifest
        If Me.GridResult.Rows.Count > 0 Then
            Mnf.MnfCover(Me.Voyage.GetDocument, Me.Voyage.VesselName)
        End If

    End Sub

    Private Sub GenerateBL()
        Dim Frm As FrmDialogPrint
        If Me.GridResult.Rows.Count = 0 Then
            Frm = New FrmDialogPrint(FrmDialogPrint.InwardOutward.Outward, "")
        Else
            Frm = New FrmDialogPrint(FrmDialogPrint.InwardOutward.Outward, Me.GridResult.ActiveRow.Cells("BLNO").Value.ToString, GridResult)
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

        sSql = "SP_OutwardCntrsListByVoyageID '" & CurrentShippingLine & "' , '" & Me.Voyage.VoyageID.ToString & "'"
        Ds = StoredProcedures.SP_OutwardCntrsListByVoyageID(CurrentShippingLine, Me.Voyage.VoyageID.ToString)

        Pcol = Ds.Tables(0).Columns("CntrNo")
        CCol = Ds.Tables(1).Columns("CntrNo")

        RL = New DataRelation("Cntrs", Pcol, CCol)
        Ds.Relations.Add(RL)

        PopulateGrid(Ds, "Containers List")

        Me.GridResult.DisplayLayout.Bands(0).Columns("ID").Hidden = True
        Me.GridResult.DisplayLayout.Bands(1).Columns("ID").Hidden = True

    End Sub


    Private Sub GenTDR()

        Dim dm As New DataManager(My.Settings.DSN)
        Dim Prm As SqlClient.SqlParameter
        Dim arrayParams As New ArrayList
        Dim Dr As DataRow
        Dim Drs() As DataRow
        Dim DS As New DataSet
        Dim nI As Int16
        Dim X As TB_OutwardBlsNames

        Prm = New SqlClient.SqlParameter("VoyageID", SqlDbType.Char, 36, ParameterDirection.Input)
        Prm.Value = Me.Voyage.VoyageID.ToString
        arrayParams.Add(Prm)

        DS = dm.ExecuteProcedure("SP_TDR", CType(arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
        Drs = DS.Tables(0).Select("", "CntrNo")
        'For Each Dr In Drs
        '    nI += 1
        '    Dr("Seq") = nI
        'Next
        Me.GridResult.DataSource = DS.Tables(0)

        With Me.GridResult.DisplayLayout.Bands(0)
            .Columns("Seq").Hidden = True
            .HeaderVisible = True
            .Header.Activated = True
            .Header.Caption = "(T.D.R.) Voyage " & Me.Voyage.VesselName & Me.Voyage.CmbVoyage.Text
            .Header.Appearance.BackColor = Color.Maroon
            .Header.Appearance.ForeColor = Color.Yellow
            .Header.Appearance.FontData.Name = "Verdana"
            .Header.Appearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.True
            .Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
            .Header.Appearance.FontData.SizeInPoints = 8

        End With
        GridTools.GridNumSeperator(Me.GridResult)


    End Sub


    Private Sub GridResult_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles GridResult.InitializeLayout
        e.Layout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex

    End Sub

   
End Class