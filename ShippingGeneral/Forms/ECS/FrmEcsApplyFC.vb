Imports OrmLib
Imports ShippingBiz
Imports Infragistics.Win.UltraWinGrid
Imports System.Data.SqlClient


Public Class FrmEcsApplyFC

    Private TB As DataTable
    Private DM As DataManager
    Dim LogDataSet As New DataSet

    Private Sub FrmEcsApplyFC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim ACodes As New ArrayList
        Dim Col As Infragistics.Win.UltraWinGrid.UltraGridColumn

        TB = New DataTable
        TB.Columns.Add(New DataColumn("ID", System.Type.GetType("System.Guid")))
        TB.Columns.Add(New DataColumn("CntrNo"))
        TB.Columns.Add(New DataColumn("CnSize"))
        TB.Columns.Add(New DataColumn("CnType"))
        TB.Columns.Add(New DataColumn("FE"))
        TB.Columns.Add(New DataColumn("CurrentStatus"))
        TB.Columns.Add(New DataColumn("CurrentDate", System.Type.GetType("System.DateTime")))
        TB.Columns.Add(New DataColumn("Direction"))
        TB.Columns.Add(New DataColumn("Dir"))
        TB.Columns.Add(New DataColumn("GateInDate", System.Type.GetType("System.DateTime")))
        TB.Columns.Add(New DataColumn("GateOut", System.Type.GetType("System.DateTime")))
        TB.Columns.Add(New DataColumn("LetterNo"))
        TB.Columns.Add(New DataColumn("Select", System.Type.GetType("System.Boolean")))
        TB.Columns.Add(New DataColumn("NextCode"))

      
        With Me.DropDownType
            .DataSource = GetCodeList("CT")
            .DisplayMember = "StdCode"
            .ValueMember = "StdCode"
            For Each Col In .DisplayLayout.Bands(0).Columns
                Col.Hidden = True
            Next
            .DisplayLayout.Bands(0).Columns("StdCode").Hidden = False
        End With

        Me.GridData.DataSource = TB
        With Me.GridData.DisplayLayout.Bands(0)
            .Columns("CnType").Style _
                               = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate
            .Columns("CnType").ValueList = Me.DropDownType
        End With

        Me.Depot.InitControl("DP", UserComboCode.ShowCoumn.Meaning)
    End Sub

    Private Sub MenuItem_CustomDeSelectAll() Handles MenuItem.CustomDeSelectAll
        Dim dr As DataRow
        For Each dr In TB.Rows
            dr("Select") = False
        Next
    End Sub

    Private Sub MenuItem_CustomPickupClick() Handles MenuItem.CustomPickupClick

        Dim Cmd As SqlCommand
        Dim Cnn As SqlConnection
        Dim DA As SqlDataAdapter
        Dim Temp As New DataTable
        Dim Dr As DataRow
        Dim NewDr As DataRow
        Dim Ecs As TB_EcsContainersCollection
        Dim Codes As TB_CODECollection
        Dim SelCode As TB_CODECollection
        If Me.dFrom.DateValue Is Nothing Then
            Exit Sub
        End If

        If Me.dTo.DateValue Is Nothing Then
            Exit Sub
        End If

        Cmd = New SqlCommand("SP_ListOfCntrsDOByDate")
        Cmd.CommandType = CommandType.StoredProcedure
        Cnn = New SqlConnection(My.Settings.DSN)
        Cmd.Parameters.AddWithValue("@DFrom", Me.dFrom.GnrlDate.Value)
        Cmd.Parameters.AddWithValue("@DTo", Me.dTo.GnrlDate.Value)
        Cnn.Open()
        Cmd.Connection = Cnn
        DA = New SqlDataAdapter
        DA.SelectCommand = Cmd
        DA.Fill(Temp)

        If Temp.Rows.Count = 0 Then
            MsgBox("No Data !")
            Exit Sub
        End If

        For Each Dr In Temp.Rows
            NewDr = TB.NewRow
            NewDr("CntrNo") = Dr("CntrNo")
            NewDr("GateOut") = Dr("DoDate")
            NewDr("Dir") = "Out"
            NewDr("Direction") = "Gate Out Full"
            NewDr("FE") = "Empty"
            NewDr("CnSize") = Dr("CnSize")
            NewDr("CnType") = Dr("CnType")
            TB.Rows.Add(NewDr)
        Next

        DM = New DataManager(My.Settings.DSN)
        For Each Dr In TB.Rows
            DM.QueryCriteria.Clear()
            DM.QueryCriteria.And(JoinPath.TB_EcsContainers.Columns.CntrNo, Dr("CntrNo"), MatchType.Exact)
            DM.QueryCriteria.And(JoinPath.TB_EcsContainers.Columns.LastStatus, "ZZ", MatchType.Not)
            Ecs = DM.GetTB_EcsContainersCollection
            Ecs = Ecs.SortByLastStatusDate(SortDirection.Descending)
            If Ecs.Count > 0 Then
                Dr("ID") = Ecs(0).ID
                Dr("CurrentStatus") = Ecs(0).LastStatus
                Dr("CnSize") = Ecs(0).CnSize
                Dr("CnType") = Ecs(0).CnType
                Dr("CurrentDate") = DateTime.Parse(Ecs(0).LastStatusDate)
            Else
                Dr("ID") = Guid.Empty
                Dr.RowError = "No Data in E.C.S !"
            End If
        Next

        DM = New DataManager(My.Settings.DSN)
        DM.QueryCriteria.And(JoinPath.TB_CODE.Columns.GroupCode, "ES", MatchType.Exact)
        Codes = DM.GetTB_CODECollection

        For Each Dr In TB.Rows
            If Dr.RowError = "" Then
                SelCode = Codes.FilterBySTDCode(Dr("CurrentStatus"))
                If SelCode.Count > 0 Then
                    Dr("NextCode") = SelCode(0).NextCode
                End If
            End If
        Next

        Me.GridData.DataSource = TB
        ValidateGrid()

        With Me.GridData.DisplayLayout.Bands(0)
            .Columns("GateInDate").Format = "dd/MM/yyy HH:mm"
            .Columns("GateOut").Format = "dd/MM/yyy HH:mm"
            .Columns("CurrentDate").Format = "dd/MM/yyy HH:mm"
            .Columns("FE").Hidden = True
            .Columns("ID").Hidden = True
            .Columns("Dir").Hidden = True
            .Columns("NextCode").Hidden = True
        End With


    End Sub

    Private Sub MenuItem_CustomSaveClick() Handles MenuItem.CustomSaveClick
        Dim Drs() As DataRow
        Dim Dr As DataRow
        Dim Mstr As TB_EcsContainers
        Dim NewDr As DataRow
        Dim MOV As TB_EcsMoves

        Dim Ans As Boolean = True

        Me.GridData.UpdateData()
        Drs = TB.Select("Select = true")
        DM = New DataManager(My.Settings.DSN)


        For Each Dr In Drs

            DM.QueryCriteria.Clear()
            DM.QueryCriteria.And(JoinPath.TB_EcsContainers.Columns.ID, Dr("ID"), MatchType.Exact)
            Mstr = DM.GetTB_EcsContainers
            If Not Mstr Is Nothing Then
                Mstr.LastDepot = Me.Depot.Code
                Mstr.LastStatus = "FU"
                Mstr.LastStatusDate = Date.Parse(Dr("GateOut"))
            End If
            MOV = DM.NewTB_EcsMoves(Mstr)
            MOV.ID = Guid.NewGuid
            MOV.CntrID = Mstr.ID
            MOV.Depot = Me.Depot.Code
            If Mstr.SOC = "Y" Then
                MOV.Status = "FS"
            Else
                MOV.Status = "FU"
            End If
            MOV.StatusDate = Date.Parse(Dr("GateOut"))
            MOV.StatusDateToLine = Date.Parse(Dr("GateOut"))
            MOV.Remarks = Me.Remarks.TextValue

            Try
                LogDataSet = DM.DataSet.Copy
                '' DM.CommitAll()
                GenerateLog(LogDataSet)
                Dr.Delete()
                Ans = True
            Catch ex As Exception
                Dr.RowError = ex.ToString
                Ans = False
            End Try

        Next

        TB.AcceptChanges()

        If Ans = False Then
            MsgBoxSaveFailed()
        Else
            MsgBoxSaveSuccessful()
        End If

        TB.Clear()
        TB.AcceptChanges()

    End Sub

    Private Sub MenuItem_CustomSelectAll() Handles MenuItem.CustomSelectAll
        Dim Dr As DataRow

        For Each Dr In TB.Rows
            If Dr.RowError = "" Then
                Dr("Select") = True
            Else
                Dr("Select") = False
            End If
        Next
     
    End Sub

    Private Sub GridData_BeforeCellUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeCellUpdateEventArgs) Handles GridData.BeforeCellUpdate
        Dim Drs() As DataRow
        If Not ((Me.GridData.ActiveCell.Column.Header.Caption = "Select") Or (Me.GridData.ActiveCell.Column.Header.Caption = "CnType")) Then
            e.Cancel = True
        End If

        Drs = TB.Select("ID = '" & GridData.ActiveRow.Cells("ID").Value.ToString & "'")
        If Drs.Length > 0 Then
            If Drs(0).RowError <> "" Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub GridData_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles GridData.InitializeLayout
        e.Layout.Override.SupportDataErrorInfo = SupportDataErrorInfo.RowsAndCells
        e.Layout.Override.DataErrorCellAppearance.ForeColor = Color.Red
        e.Layout.Override.DataErrorRowAppearance.BackColor = Color.LightYellow
        e.Layout.Override.DataErrorRowSelectorAppearance.BackColor = Color.Green
        e.Layout.Override.RowSelectorWidth = 32
    End Sub
    Private Sub ValidateGrid()

        Dim Dr As DataRow

        For Each Dr In TB.Rows
            If Dr("ID").ToString <> Guid.Empty.ToString Then
                If InStr(Dr("NextCode"), "FC") = 0 Then
                    Dr.RowError = "Status Sequence Wrong !"
                Else
                    Dr.RowError = ""
                End If
            End If
            Dr("Select") = False
        Next

        For Each Dr In TB.Rows
            If Dr.RowError = "" Then
                If Dr("CurrentDate") > Dr("GateOut") Then
                    Dr.RowError = "Date Sequence Wrong !"
                End If
            End If
        Next

    End Sub

    Private Sub MenuItem_CustomToExcelClick() Handles MenuItem.CustomToExcelClick
        If Me.GridData.Rows.Count > 0 Then
            SaveGridToExcel(Me.GridData)
        End If
    End Sub

    
   
End Class