Imports ShippingBiz
Imports OrmLib
Imports System.Data.SqlClient
Imports Infragistics.Shared
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinEditors
Public Class FrmEcsBatch

    Private Dm As DataManager
    Private TB As DataTable
    Private Sub Status_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Depot.Load

        TB = New DataTable
        Dim Col As DataColumn

        Me.FromStatus.InitControl("ES", UserComboCode.ShowCoumn.StdCode)
        Me.ToStatus.InitControl("ES", UserComboCode.ShowCoumn.StdCode)
        Me.Depot.InitControl("DP", UserComboCode.ShowCoumn.Meaning)
        Me.StatusDate.InitControl(True, False)
        Me.StatusDateToLine.InitControl(True, False)
        Me.BookingID.InitControl()
        Me.ReturnTo.InitControl(Me.BackColor)
        Me.Destination.InitControl(Me.BackColor)

        Tb.TableName = "EcsList"
        Col = New DataColumn

        Tb.Columns.Add(New DataColumn("ID", System.Type.GetType("System.Guid")))
        Tb.Columns.Add(New DataColumn("CntrNo", System.Type.GetType("System.String")))
        TB.Columns.Add(New DataColumn("CnSize", System.Type.GetType("System.String")))
        TB.Columns.Add(New DataColumn("Cntype", System.Type.GetType("System.String")))
        TB.Columns.Add(New DataColumn("BLNO", System.Type.GetType("System.String")))
        TB.Columns.Add(New DataColumn("SOC", System.Type.GetType("System.String")))
        Tb.Columns.Add(New DataColumn("LastStatus", System.Type.GetType("System.String")))
        TB.Columns.Add(New DataColumn("LastStatusDate", System.Type.GetType("System.DateTime")))
        TB.Columns.Add(New DataColumn("BookingNo", System.Type.GetType("System.String")))
        TB.Columns.Add(New DataColumn("Outward BLNO", System.Type.GetType("System.String")))
        TB.Columns.Add(New DataColumn("Select", System.Type.GetType("System.Boolean")))

        Me.GridResult.DataSource = TB
        Me.GridResult.DisplayLayout.Bands(0).Columns("ID").Hidden = True
        Me.OutVessel.InitControl(Me.BackColor)
        Me.OutVoyage.InitControl(Me.BackColor, Me.OutVessel)

    End Sub

    Private Sub MenuItem_CustomDeSelectAll() Handles MenuItem.CustomDeSelectAll

        For Each row As UltraGridRow In Me.GridResult.Rows

            row.Cells("Select").Value = False

        Next

        Me.GridResult.UpdateData()

    End Sub

    Private Sub MenuItem_CustomPickupClick() Handles MenuItem.CustomPickupClick

        Try
            TB.Clear()
        Catch ex As Exception
        End Try

        If Me.FromStatus.Code = "" Then
            MsgBoxGeneral("No Valid Status !", "Data Requard")
            Exit Sub
        End If

        SetDocument()

    End Sub
    Private Sub SetDocument()

        Dim Prm As SqlClient.SqlParameter
        Dim arrayParams As New ArrayList
        Dim ds As DataSet
        Dim Dr As DataRow


        Dm = New DataManager(My.Settings.DSN & ";" & "Connection Timeout=120")
        TB.Clear()

        Prm = New SqlClient.SqlParameter("Line", SqlDbType.VarChar, 10, ParameterDirection.Input)
        Prm.Value = CurrentShippingLine
        arrayParams.Add(Prm)

        Prm = New SqlClient.SqlParameter("Status", SqlDbType.Char, 36, ParameterDirection.Input)
        Prm.Value = Me.FromStatus.Code
        arrayParams.Add(Prm)

        ds = Dm.ExecuteProcedure("SP_EcsCntrsByLastStatus", CType(arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))

        If Ds.Tables(0).Rows.Count = 0 Then
            MsgBoxGeneral("No Any Containers !", "Error")
            Exit Sub
        End If
        TB.Merge(ds.Tables(0).Copy)

        For Each Dr In TB.Rows
            Dr.Item("Select") = False
        Next
        TB.AcceptChanges()

    End Sub

    Private Sub DataSetFromXml()

        Dim Dc As DataColumn
        Dim myDS As DataSet = New DataSet
        myDS.ReadXml("c:\tmp\FullGateOutReport.xml")

        For Each Dc In myDS.Tables(0).Columns
            Debug.Print(Dc.ColumnName)
        Next
        Debug.Print(myDS.Tables(0).Rows(0).Item("Container"))

    End Sub

    Private Sub GridResult_AfterRowFilterChanged(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.AfterRowFilterChangedEventArgs) Handles GridResult.AfterRowFilterChanged

        Dim Dr As DataRow
        For Each Dr In TB.Rows
            Dr.Item("Select") = False
        Next
        TB.AcceptChanges()

    End Sub

    Private Function ValidateForm() As Boolean

        Dim Ans As Boolean = True
        Dim Dv As DataView
        Dim AList As New ArrayList
        Dim aError As New ArrayList
        Dim nI As Long
        Dim Dr As DataRow
        Dim Code As TB_CODE

        FormErrorProvider.Clear()
        For Each Dr In TB.Rows
            Dr.RowError = ""
        Next

        Me.GridResult.UpdateData()
        Dv = New DataView(TB, "Select = true", "", DataViewRowState.CurrentRows)

        If Dv.Count = 0 Then
            MsgBoxGeneral("No any Selection", "Data Requird")
            Exit Function
        End If

        If Me.CheckDetail.Checked = False And Me.CheckMaster.Checked = False Then
            MsgBoxGeneral("No Update Selection", "Data Requird")
            Exit Function
        End If



        If CheckDetail.Checked = True Then
            If Me.StatusDate.GnrlDate.Value Is Nothing Then
                aError.Add(Me.StatusDate)
            Else
                If Me.StatusDate.GnrlDate.Value.ToString = "" Then
                    aError.Add(Me.StatusDate)
                End If
            End If
            If Me.ToStatus.Code = "" Then
                aError.Add(Me.ToStatus)
            Else
                Dm.QueryCriteria.Clear()
                Dm.QueryCriteria.And(JoinPath.TB_CODE.Columns.GroupCode, "ES", MatchType.Exact)
                Dm.QueryCriteria.And(JoinPath.TB_CODE.Columns.STDCode, Me.FromStatus.Code, MatchType.Exact)
                Code = Dm.GetTB_CODE
                If Code Is Nothing Then
                    aError.Add(Me.ToStatus)
                Else
                    If InStr(1, Code.NextCode, Me.ToStatus.Code) = 0 Then
                        aError.Add(Me.ToStatus)
                    End If
                End If
            End If

            If Me.StatusDateToLine.GnrlDate.Value Is Nothing Then
                aError.Add(Me.StatusDateToLine)
            Else
                If Me.StatusDateToLine.GnrlDate.Value.ToString = "" Then
                    aError.Add(Me.StatusDateToLine)
                End If

            End If
            If Me.Depot.Code = "" Then
                aError.Add(Me.Depot)
            End If
        End If

        If aError.Count > 0 Then
            Ans = False
            If aError.Count > 0 Then
                For nI = 0 To aError.Count - 1
                    FormErrorProvider.SetError(aError(nI), "Data Requird")
                Next
            End If

        End If

        If CheckDetail.Checked = True Then
            For Each Dr In TB.Rows
                If Dr("Select") = True Then
                    If Val(Format(Dr.Item("LastStatusDate"), "yyyyMMddHHmm")) > Val(Me.StatusDate.DTOS) Then
                        Dr.RowError = "Date Sequence Error !"
                        Ans = False
                    End If
                End If
            Next
        End If

        If Ans = False Then
            MsgBoxValidateFaild()
        End If

        Return Ans

    End Function

    Private Sub MenuItem_CustomSaveClick() Handles MenuItem.CustomSaveClick

        If ValidateForm() Then
            If MsgBoxUpdate() = Windows.Forms.DialogResult.Yes Then
                SaveDocument()
            End If
        End If

    End Sub

    Private Sub GridResult_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles GridResult.InitializeLayout
        e.Layout.Override.SupportDataErrorInfo = SupportDataErrorInfo.RowsAndCells
        e.Layout.Override.DataErrorCellAppearance.ForeColor = Color.Red
        e.Layout.Override.DataErrorRowAppearance.BackColor = Color.LightYellow
        e.Layout.Override.DataErrorRowSelectorAppearance.BackColor = Color.Green
        e.Layout.Override.RowSelectorWidth = 32

        e.Layout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.Default
        e.Layout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
    End Sub

    Private Sub SaveDocument()

        Dim Mstr As TB_EcsContainers
        Dim Mov As TB_EcsMoves
        Dim Dr As DataRow
        Dim Ans As Boolean = True
        Dim Drs() As DataRow
        Dim LogDataSet As New DataSet


        Dm = New DataManager(My.Settings.DSN)
        TB.AcceptChanges()
        Drs = TB.Select("Select = True")

        For Each Dr In Drs
            If Dr("Select") = True Then
                dm.QueryCriteria.Clear()
                Dm.QueryCriteria.And(JoinPath.TB_EcsContainers.Columns.ID, Dr("ID"), MatchType.Exact)
                Mstr = Dm.GetTB_EcsContainers
                If Not Mstr Is Nothing Then
                    If Me.CheckMaster.Checked = True Then
                        If CheckBooking.Checked = True Then
                            Mstr.BookingID = Me.BookingID.BookingID
                        End If
                        If CheckReturnTo.Checked = True Then
                            Mstr.ReturnTo = Me.ReturnTo.PortCode
                        End If
                        If CheckDestination.Checked = True Then
                            Mstr.Destination = Me.Destination.PortCode
                        End If
                        If CheckDjwaz.Checked = True Then
                            Mstr.InDjwazNo = Me.InDjwazNo.TextValue
                        End If
                        If CheckPermitNo.Checked = True Then
                            Mstr.ExportPermit = Me.ExportPermit.TextValue
                        End If
                        If Me.CheckReturnBy.Checked = True Then
                            Mstr.OutVoyageID = Me.OutVoyage.VoyageID
                        End If
                    End If
                    If Me.CheckDetail.Checked = True Then
                        Mstr.LastDepot = Me.Depot.Code
                        Mstr.LastStatus = Me.ToStatus.Code
                        Mstr.LastStatusDate = Me.StatusDate.DateValue
                        Mov = Dm.NewTB_EcsMoves(Mstr)
                        Mov.ID = Guid.NewGuid
                        Mov.CntrID = Mstr.ID
                        Mov.Depot = Me.Depot.Code
                        Mov.Status = Me.ToStatus.Code
                        Mov.StatusDate = Me.StatusDate.DateValue
                        Mov.StatusDateToLine = Me.StatusDateToLine.DateValue
                        Mov.Remarks = Me.Remarks.TextValue
                    End If
                    Try
                        LogDataSet = Dm.DataSet.Copy
                        Dm.CommitAll()
                        GenerateLog(LogDataSet)
                        Dr.Delete()
                    Catch ex As Exception
                        Dr.RowError = ex.ToString
                        Ans = False
                    End Try
                End If
            End If
        Next

        TB.AcceptChanges()

        If Ans = False Then
            MsgBoxSaveFailed()
        Else
            MsgBoxSaveSuccessful()
            SetDocument()
        End If

    End Sub

   
    Private Sub MenuItem_CustomSelectAll() Handles MenuItem.CustomSelectAll

        For Each row As UltraGridRow In Me.GridResult.Rows
            If Not row.IsFilteredOut = True Then
                row.Cells("Select").Value = True
            End If
        Next

        Me.GridResult.UpdateData()
 
    End Sub
End Class