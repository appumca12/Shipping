Imports ShippingBiz
Imports OrmLib

Public Class FrmInwardGenaralListDate

    Private TB As DataTable
    Private Sub FrmInwardGenaralList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.dFrom.InitControl(False, False)
        Me.DTo.InitControl(False, False)
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
            Case "Print"
                PrintProc()

        End Select

    End Sub

    Private Sub SetDocument()

        Dim sSql As String
        Dim dm As New DataManager(My.Settings.DSN)
        Dim Ds As New DataSet
        'sSql = "SP_InwardBlsGenralListByVoyageID '" & CurrentShippingLine & "' , '" & Me.Voyage.VoyageID.ToString & "'"
        'Ds = StoredProcedures.SP_InwardBlsGenralListByVoyageID(CurrentShippingLine, Me.Voyage.VoyageID.ToString)
        'PopulateGrid(Ds.Tables(0), "")


    End Sub

    Private Sub PopulateGrid(ByVal TempTb As DataTable, ByVal Header As String)

        Dim Col As DataColumn

        TB = New DataTable
        TB = TempTb.Copy

        With Me.GridResult
            .DisplayLayout.ResetBands()
            .DataSource = Tb
        End With

        For Each Col In Tb.Columns
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

        'If Me.GridResult Is Nothing Then
        '    Exit Sub
        'End If

        'If Me.GridResult.Rows.Count = 0 Then
        '    Exit Sub
        'End If

        Select Case e.Item.Text
            Case "Voyage List"
                GenVoyageList()
            Case "General List By DSCH"
                GenGnrlByDSCH()
                'Case "Manifest Cover Page"
                '    GenMangCoverPage()
                'Case "Freight Manifest"
                '    GenManifest("N")
                'Case "B/L Print"
                '    GenerateBL()
                'Case "Containers List"
                '    Me.ExplorerBar.Groups.Item("Document ").Enabled = False
                '    GenContainersList()

        End Select

    End Sub

    Private Sub GenVoyageList()

        Dim Ds As New DataSet
        Dim Dm As New DataManager(My.Settings.DSN)


        If Me.dFrom.DateValue Is Nothing Then
            Me.dFrom.DateValue = Now
        End If

        If Me.DTo.DateValue Is Nothing Then
            Me.DTo.DateValue = Now
        End If

        Ds = StoredProcedures.SP_VoyageListByDate(Me.dFrom.DateValue, Me.DTo.DateValue)
        If Ds.Tables(0).Rows.Count = 0 Then
            MsgBox("No any data !")
        Else
            Me.GridResult.DataSource = Ds.Tables(0).Copy
            With Me.GridResult.DisplayLayout.Bands(0)
                .HeaderVisible = True
                .Header.Activated = True
                .Header.Caption = "Voyage List From:" & Me.dFrom.DateValue.ToString & "  To:" & Me.DTo.DateValue.ToString
                .Header.Appearance.BackColor = Color.Maroon
                .Header.Appearance.ForeColor = Color.Yellow
                .Header.Appearance.FontData.Name = "Verdana"
                .Header.Appearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.True
                .Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                .Header.Appearance.FontData.SizeInPoints = 8
            End With
        End If

    End Sub

    Private Sub PrintProc()

        Me.GridPrintDocument.Print()

    End Sub

    Private Sub GenGnrlByDSCH()

        Dim Ds As New DataSet
        Dim Dm As New DataManager(My.Settings.DSN)


        If Me.dFrom.DateValue Is Nothing Then
            Me.dFrom.DateValue = Now
        End If

        If Me.DTo.DateValue Is Nothing Then
            Me.DTo.DateValue = Now
        End If

        Ds = StoredProcedures.SP_InwardGeneralListByDschCmpl(Me.dFrom.DateValue, Me.DTo.DateValue, CurrentShippingLine)
        If Ds.Tables(0).Rows.Count = 0 Then
            MsgBox("No any data !")
        Else
            Me.GridResult.DataSource = Ds.Tables(0).Copy
            With Me.GridResult.DisplayLayout.Bands(0)
                .HeaderVisible = True
                .Header.Activated = True
                .Header.Caption = "List Of Container By DSCH Date From:" & Me.dFrom.DateValue.ToString & "  To:" & Me.DTo.DateValue.ToString
                .Header.Appearance.BackColor = Color.Maroon
                .Header.Appearance.ForeColor = Color.Yellow
                .Header.Appearance.FontData.Name = "Verdana"
                .Header.Appearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.True
                .Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                .Header.Appearance.FontData.SizeInPoints = 8
            End With
        End If



    End Sub

End Class