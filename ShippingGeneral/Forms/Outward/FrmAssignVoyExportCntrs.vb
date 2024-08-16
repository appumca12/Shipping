Imports OrmLib
Imports ShippingBiz
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports Infragistics.Win.UltraWinGrid


Public Class FrmAssignVoyExportCntrs

    Private Sub FrmAssicnVoyExportCntrs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Vessel.InitControl(Me.BackColor)
        Me.Voyage.InitControl(Me.BackColor, Me.Vessel)

        Me.POT.InitControl(Me.BackColor)
        Me.FPOD.InitControl(Me.BackColor)

        Me.GridAssigned.DisplayLayout.Bands(0).Columns("ID").Hidden = True
        Me.GridReady.DisplayLayout.Bands(0).Columns("ID").Hidden = True
        Me.GridReady.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Me.GridAssigned.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns


    End Sub

    Private Sub MenuItem_CustomPickupClick() Handles MenuItem.CustomPickupClick

        setDocument()

    End Sub
    Private Sub setDocument()

        Dim ds As DataSet
        Dim Dr As DataRow
        Dim Dm As DataManager
        Dim Prm As SqlClient.SqlParameter
        Dim arrayParams As New ArrayList

        Me.DataSetForm.Tables("Assigned").Clear()
        Me.DataSetForm.Tables("Ready").Clear()

        ds = StoredProcedures.SP_LoadedFullCntrs(CurrentShippingLine, Me.Voyage.VoyageID.ToString)
        For Each Dr In ds.Tables(0).Rows
            Me.DataSetForm.Tables("Assigned").ImportRow(Dr)
        Next

        ds = StoredProcedures.SP_ReadyFullCntrsForLoad(CurrentShippingLine)
        For Each Dr In ds.Tables(0).Rows
            Me.DataSetForm.Tables("Ready").ImportRow(Dr)
        Next

        Dm = New DataManager(My.Settings.DSN)
        Prm = New SqlClient.SqlParameter("Line", SqlDbType.VarChar, 10, ParameterDirection.Input)
        Prm.Value = CurrentShippingLine
        arrayParams.Add(Prm)
        ds = Dm.ExecuteProcedure("SP_ReadyEmptyCntrsForLoad", CType(arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))
        For Each Dr In ds.Tables(0).Rows
            Me.DataSetForm.Tables("Ready").ImportRow(Dr)
        Next

    End Sub

    Private Sub MenuItem_CustomPrintClick() Handles MenuItem.CustomPrintClick

        Dim rpt As PCLRptExpLoadList
        Dim Frm As FrmGeneralReportShow
        Dim Ds As New DataSet
        '     Dim PH As New CLPrintHdr

        Dim sSql As String
        Dim Tb As New DataTable
        Dim lResult As Boolean

        Dim Dr As DataRow
        Dim TempTB As New DataTable
        Dim Drs() As DataRow
        Dim CntrNo As String = ""
        Dim Seq As Byte
        Dim DataDr() As DataRow
        Dim ChgDr As DataRow
        Dim TTLGW As Double
        Dim TargetDr() As DataRow
        Dim nDr As DataRow

        If Me.Voyage.VoyageID.ToString Is Nothing Then
            MsgBoxGeneral("No Valid Voyage !", "Data Requird")
            Exit Sub
        End If

        Me.GridAssigned.UpdateData()
        With TempTB
            .Columns.Add(New DataColumn("CntrNo", System.Type.GetType("System.String")))
            .Columns.Add(New DataColumn("GW", System.Type.GetType("System.Double")))
        End With

        sSql = "SP_LoadListFullByVoyageID '" & Me.Voyage.VoyageID.ToString & "'"
        TableBySql(sSql, Tb, lResult)

        DataDr = Me.DataSetForm.Tables("Assigned").Select("Select = false")

        For Each Dr In DataDr
            Drs = Tb.Select("CntrNo = '" & Dr("CntrNo") & "'")
            For Each nDr In Drs
                nDr.Delete()
            Next
        Next

        Tb.Columns.Add(New DataColumn("Count", System.Type.GetType("System.Int16")))
        Drs = Tb.Select("", "CntrNo")
        For Each Dr In Drs
            If CntrNo <> Dr("CntrNo") Then
                Seq = 0
            End If
            CntrNo = Dr("CntrNo")
            Seq += 1
            Dr("Count") = Seq

        Next
        Drs = Tb.Select("Count= 2", "CntrNo")

        For Each Dr In Drs
            TTLGW = 0
            DataDr = Tb.Select("CntrNo = '" & Dr("CntrNo") & "'")
            For Each ChgDr In DataDr
                TTLGW += NullToValue(ChgDr("GW"), 0)
            Next
            TargetDr = Tb.Select("CntrNo = '" & Dr("CntrNo") & "' and Count = 1")
            TargetDr(0).Item("GW") = TTLGW
        Next

        Drs = Tb.Select("Count > 1")
        For Each Dr In Drs
            Dr.Delete()
        Next
        Tb.AcceptChanges()

        For Each Dr In Tb.Rows
            If Dr("Status") = "EMPTY" Then
                Dr("GOODS") = "EMPTY CONTAINER"
            End If
            If NullToValue(Dr("TW"), 0) = 0 Then
                If Dr("CnSize") = "20" Then
                    Dr("TW") = 2200
                Else
                    Dr("TW") = 4500
                End If
            End If
            Dr("POT") = GetPortNameByCode(NullToValue(Dr("POT"), ""))

        Next

        If lResult = True Then
            Frm = New FrmGeneralReportShow
            rpt = New PCLRptExpLoadList
            'rpt.Subreports("RptHedaerLogo.rpt").SetDataSource(PH.ImageTable)
            rpt.SetDataSource(Tb)
            Frm.ReportViewer.ReportSource = rpt
            Frm.Text = "Load List"
            Frm.Show()
        End If

    End Sub

    Private Sub MenuItem_CustomSaveClick() Handles MenuItem.CustomSaveClick

        Dim Drs() As DataRow
        Dim Dr As DataRow
        Dim Dm As DataManager
        Dim Ecs As TB_EcsContainers
        Dim LogDataset As New DataSet

        GridReady.UpdateData()

        Drs = DataSetForm.Tables("Ready").Select("Select = true")
        If Drs.Length = 0 Then
            MsgBoxGeneral("No any Selected Containers !", "Data Requird")
            Exit Sub
        End If

        If MsgBoxUpdate() = Windows.Forms.DialogResult.Yes Then

            Dm = New DataManager(My.Settings.DSN)
            For Each Dr In Drs
                Dm.QueryCriteria.Clear()
                Dm.QueryCriteria.And(JoinPath.TB_EcsContainers.Columns.ID, Dr("ID"), MatchType.Exact)
                Ecs = Dm.GetTB_EcsContainers()
                If Not Ecs Is Nothing Then
                    Ecs.OutVoyageID = Me.Voyage.VoyageID
                    Ecs.ReturnTo = Dr("POT")
                    Ecs.Destination = Dr("FPOD")
                End If
            Next
            LogDataset = Dm.DataSet.Copy
            Try
                Dm.CommitAll()
                GenerateLog(LogDataset)
                MsgBoxSaveSuccessful()
            Catch ex As Exception
                MsgBoxSaveFailed()
            End Try

        End If

    End Sub


    Private Sub GridAssigned_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles GridAssigned.InitializeLayout
        e.Layout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.Default
        e.Layout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
    End Sub

    Private Sub GridReady_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles GridReady.InitializeLayout
        e.Layout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.Default
        e.Layout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
    End Sub
     Private Sub MenuItem_CustomToExcelClick() Handles MenuItem.CustomToExcelClick
 
        If Me.TabControl.SelectedTab.Index = 1 Then

            Me.GridReady.UpdateData()

            If Me.GridReady.Rows.Count > 0 Then
                Me.GridReady.DisplayLayout.Bands(0).Header.Caption = "List Of Ready Continer(s) For Loading"
                Me.GridReady.DisplayLayout.Bands(0).HeaderVisible = True
                SaveGridToExcel(Me.GridReady)
                Me.GridReady.DisplayLayout.Bands(0).Header.Caption = ""
                Me.GridReady.DisplayLayout.Bands(0).HeaderVisible = False
            End If
        Else
            If Me.GridAssigned.Rows.Count > 0 Then
                Me.GridAssigned.DisplayLayout.Bands(0).Header.Caption = "List Of Continer(s) Assigned For Loading For Vessel:" & Me.Vessel.VesselName & " VoyageNo:" & Me.Voyage.CmbVoyage.Text
                Me.GridAssigned.DisplayLayout.Bands(0).HeaderVisible = True
                SaveGridToExcel(Me.GridAssigned)
                Me.GridAssigned.DisplayLayout.Bands(0).Header.Caption = ""
                Me.GridAssigned.DisplayLayout.Bands(0).HeaderVisible = False
            End If

        End If




    End Sub

    Private Sub MenuItem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class