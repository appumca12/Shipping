Imports OrmLib
Imports ShippingBiz
Imports Infragistics.Win.UltraWinGrid
Imports System.Data.SqlClient

Public Class FrmEcsCodecoApply

    Private TB As DataTable
    Private DM As DataManager
    Dim LogDataSet As New DataSet
    Private Sub FrmEcsCodecoApply_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim ACodes As New ArrayList
        Dim Col As Infragistics.Win.UltraWinGrid.UltraGridColumn

        TB = New DataTable
        TB.Columns.Add(New DataColumn("ID", System.Type.GetType("System.Guid")))
        TB.Columns.Add(New DataColumn("CntrNo"))
        TB.Columns.Add(New DataColumn("CnSize"))
        TB.Columns.Add(New DataColumn("CnType"))
        TB.Columns.Add(New DataColumn("FE"))
        TB.Columns.Add(New DataColumn("CurrentStatus"))
        TB.Columns.Add(New DataColumn("D/O")) 'Delivery order column (D/O)
        TB.Columns.Add(New DataColumn("CurrentDate", System.Type.GetType("System.DateTime")))
        TB.Columns.Add(New DataColumn("Direction"))
        TB.Columns.Add(New DataColumn("Dir"))
        TB.Columns.Add(New DataColumn("GateInDate", System.Type.GetType("System.DateTime")))
        TB.Columns.Add(New DataColumn("GateOut", System.Type.GetType("System.DateTime")))
        TB.Columns.Add(New DataColumn("Depot"))
        TB.Columns.Add(New DataColumn("BookingNo"))
        TB.Columns.Add(New DataColumn("LetterNo"))
        TB.Columns.Add(New DataColumn("Select", System.Type.GetType("System.Boolean")))
        TB.Columns.Add(New DataColumn("NextCode"))



        ACodes.Add("MS") ' ES
        ACodes.Add("EL") ' ES
        ACodes.Add("FL") ' 
        ACodes.Add("ST") ' To Vessel 'OE
        ACodes.Add("MA") ' EA
        ACodes.Add("MR")
        ACodes.Add("MB")
        ACodes.Add("FB")
        ACodes.Add("FU")
        ACodes.Add("FS")
        ACodes.Add("DM")
        ACodes.Add("OK")
        ACodes.Add("RE")
        ACodes.Add("RO")
        ACodes.Add("RD")
        ACodes.Add("MI")
        ACodes.Add("CT")
        ACodes.Add("HD") 'FV MOVEMENT AFTER MA - CROSS STUFF CNTR TEMU9259338
        ACodes.Add("DO")
        'Insert into TB_Code (GroupCode,STDCode,NextCode,MEANING,IsEditeble) values ('ES','CT','FV,FU,CV,MA','Cross Stuff',1) run at back end


        Me.Status.InitControl("ES", ACodes, UserComboCode.ShowCoumn.StdCode)

        Me.Depot.InitControl("DP", UserComboCode.ShowCoumn.Meaning)
        Me.BookingID.InitControl()
        Me.ReturnTo.InitControl(Me.BackColor)
        Me.Destination.InitControl(Me.BackColor)
        Me.OutVessel.InitControl(Me.BackColor)
        Me.OutVoyage.InitControl(Me.BackColor, Me.OutVessel)
        Me.EcsDate.InitControl(True, False)

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

        MenuItem.ShowAdditional = True
        MenuItem.CustomSetAdditonalItem("Import From Excel", My.Resources.tdx_excel2424)


    End Sub

    Private Sub MenuItem_CustomAdditional() Handles MenuItem.CustomAdditional
        Me.EcsCntrsInsert.IntData(Me.EcsDate.DateValue)
        Me.PopupControl.Show()
    End Sub

    Private Sub MenuItem_CustomDeSelectAll() Handles MenuItem.CustomDeSelectAll
        Dim dr As DataRow
        For Each dr In TB.Rows
            dr("Select") = False
        Next
    End Sub
    Private Sub UserMenuItem1_CustomOpenFileClick() Handles MenuItem.CustomOpenFileClick

        '     ImportFromXml()
        ImportFromCodeco()

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

    Private Sub GridData_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles GridData.InitializeLayout
        e.Layout.Override.SupportDataErrorInfo = SupportDataErrorInfo.RowsAndCells
        e.Layout.Override.DataErrorCellAppearance.ForeColor = Color.Red
        e.Layout.Override.DataErrorRowAppearance.BackColor = Color.LightYellow
        e.Layout.Override.DataErrorRowSelectorAppearance.BackColor = Color.Green
        e.Layout.Override.RowSelectorWidth = 32
    End Sub


    Private Sub Status_CustomValueChanged() Handles Status.CustomValueChanged

        Me.CheckBooking.Checked = False
        Me.CheckReturnBy.Checked = False
        Me.CheckDestination.Checked = False
        Me.CheckReturnTo.Checked = False

        Select Case Status.Code
            Case "FU"
                Me.BookingID.Visible = False
                Me.CheckBooking.Visible = False
                Me.CheckReturnBy.Visible = False
                Me.CheckDestination.Visible = False
                Me.CheckReturnTo.Visible = False
                Me.ReturnTo.Visible = False
                Me.Destination.Visible = False
                Me.OutVessel.Visible = False
                Me.OutVoyage.Visible = False
                Me.LabelBooking.Visible = False
                Me.LabelDestination.Visible = False
                Me.LabelReturnTo.Visible = False
                Me.LabelReturnBy.Visible = False
            Case "MS"
                Me.BookingID.Visible = True
                Me.ReturnTo.Visible = False
                Me.Destination.Visible = False
                Me.OutVessel.Visible = False
                Me.OutVoyage.Visible = False
                Me.CheckBooking.Visible = True
                Me.CheckReturnBy.Visible = False
                Me.CheckDestination.Visible = False
                Me.CheckReturnTo.Visible = False
                Me.LabelBooking.Visible = True
                Me.LabelDestination.Visible = True
                Me.LabelReturnTo.Visible = False
                Me.LabelReturnBy.Visible = False
                Me.LabelBooking.Visible = True
                Me.LabelDestination.Visible = False
                Me.LabelReturnTo.Visible = False
                Me.LabelReturnBy.Visible = False

                Me.CheckBooking.Visible = True
                Me.CheckReturnBy.Visible = False
                Me.CheckDestination.Visible = False
                Me.CheckReturnTo.Visible = False

            Case "ST" Or "EL"
                Me.BookingID.Visible = False
                Me.CheckBooking.Visible = False
                Me.CheckReturnBy.Visible = True
                Me.CheckDestination.Visible = True
                Me.CheckReturnTo.Visible = True
                Me.ReturnTo.Visible = True
                Me.Destination.Visible = True
                Me.OutVessel.Visible = True
                Me.OutVoyage.Visible = True
                Me.LabelBooking.Visible = False
                Me.LabelDestination.Visible = True
                Me.LabelReturnTo.Visible = True
                Me.LabelReturnBy.Visible = True

            Case "MA"
                Me.BookingID.Visible = False
                Me.CheckBooking.Visible = False
                Me.CheckReturnBy.Visible = False
                Me.CheckDestination.Visible = False
                Me.CheckReturnTo.Visible = False
                Me.ReturnTo.Visible = False
                Me.Destination.Visible = False
                Me.OutVessel.Visible = False
                Me.OutVoyage.Visible = False
                Me.LabelBooking.Visible = False
                Me.LabelDestination.Visible = False
                Me.LabelReturnTo.Visible = False
                Me.LabelReturnBy.Visible = False

        End Select
        ValidateGrid()

    End Sub

    Private Sub ValidateGrid()

        Dim Dr As DataRow

        For Each Dr In TB.Rows
            If Dr("ID").ToString <> Guid.Empty.ToString Then
                If InStr(NullToValue(Dr("NextCode"), 0), Status.Code) = 0 Then
                    Dr.RowError = "Status Sequence Wrong !"
                End If
            End If
            Dr("Select") = False
        Next

        For Each Dr In TB.Rows
            If Dr.RowError = "" Then
                If Dr("Dir") = "In" Then
                    If Dr("CurrentDate") > Dr("GateInDate") Then
                        Dr.RowError = "Date Sequence Wrong !"
                    End If
                Else
                    If Dr("CurrentDate") > Me.EcsDate.DateValue Then ' Dr("GateOut") Then
                        Dr.RowError = "Date Sequence Wrong !"
                    End If
                End If
            End If
        Next

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

            Dm.QueryCriteria.Clear()
            Dm.QueryCriteria.And(JoinPath.TB_EcsContainers.Columns.ID, Dr("ID"), MatchType.Exact)
            Mstr = Dm.GetTB_EcsContainers
            If Not Mstr Is Nothing Then

                If CheckBooking.Checked = True Then
                    Mstr.BookingID = Me.BookingID.BookingID
                End If
                If CheckReturnTo.Checked = True Then
                    Mstr.ReturnTo = Me.ReturnTo.PortCode
                End If
                If CheckDestination.Checked = True Then
                    Mstr.Destination = Me.Destination.PortCode
                End If

                If Me.CheckReturnBy.Checked = True Then
                    Mstr.OutVoyageID = Me.OutVoyage.VoyageID
                End If


                Mstr.LastDepot = Me.Depot.Code
                Mstr.LastStatus = Me.Status.Code
                If Me.Status.Code <> "ES" Then
                    If Dr("Dir") = "In" Then
                        Mstr.LastStatusDate = Date.Parse(Dr("GateIndate"))
                    Else
                        Mstr.LastStatusDate = Date.Parse(Dr("GateOut"))
                    End If
                Else
                    Mstr.LastStatusDate = Date.Parse(Me.EcsDate.GnrlDate.Value)
                End If
                MOV = DM.NewTB_EcsMoves(Mstr)
                MOV.ID = Guid.NewGuid
                MOV.CntrID = Mstr.ID
                MOV.Depot = Me.Depot.Code
                MOV.Status = Me.Status.Code
                If Me.Status.Code <> "ES" Then
                    If Dr("Dir") = "In" Then
                        MOV.StatusDate = Date.Parse(Dr("GateInDate"))
                        MOV.StatusDateToLine = Date.Parse(Dr("GateInDate"))
                    Else
                        MOV.StatusDate = Date.Parse(Dr("GateOut"))
                        MOV.StatusDateToLine = Date.Parse(Dr("GateOut"))
                    End If
                Else
                    MOV.StatusDate = Date.Parse(Me.EcsDate.GnrlDate.Value)
                    MOV.StatusDateToLine = Date.Parse(Me.EcsDate.GnrlDate.Value)
                End If
                MOV.Remarks = Me.Remarks.TextValue

                Try
                    LogDataSet = DM.DataSet.Copy
                    DM.CommitAll()
                    GenerateLog(LogDataSet)
                    Dr.Delete()
                    Ans = True
                Catch ex As Exception
                    Dr.RowError = ex.ToString
                    Ans = False
                End Try
            Else
                AddAsNewRecord(Dr)

            End If
        Next

        TB.AcceptChanges()

        If Ans = False Then
            MsgBoxSaveFailed()
        Else
            MsgBoxSaveSuccessful()
        End If

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

    Private Sub MenuItem_CustomToExcelClick() Handles MenuItem.CustomToExcelClick
        If TB.Rows.Count > 0 Then
            SaveGridToExcel(Me.GridData)
        End If
    End Sub

    Private Sub ImportFromCodeco()

        Dim Dialog As New OpenFileDialog
        Dim EDI As EDIFACTToTable
        Dim Drs() As DataRow
        Dim Dr As DataRow
        Dim NewDr As DataRow
        Dim Dm As DataManager
        Dim Ecs As TB_EcsContainersCollection
        Dim BGM As String
        Dim Codes As TB_CODECollection
        Dim SelCode As TB_CODECollection

        TB.Clear()
        TB.AcceptChanges()

        Dialog.Filter = "EDI Files (*.EDI)|*.EDI|EDI files (*.EDI)|*.EDI|All files (*.*)|*.*"
        Dialog.ShowDialog()

        If Dialog.FileName <> "" Then
            EDI = New EDIFACTToTable(Dialog.FileName)
            If EDI.ProcessStatus <> EDIFACTToTable.EDIProcessStatus.Succses Then
                MsgBox("No Valid File !")
                Exit Sub
            End If
        Else
            Exit Sub
        End If

        Drs = EDI.Segments.Select("", "Seq")
        For Each Dr In Drs

            Select Case Dr("Field00")
                Case "BGM"
                    BGM = Dr("Field01")
                Case "EQD"
                    NewDr = TB.NewRow
                    NewDr("CntrNo") = Dr("Field02")
                    If BGM = "34" Then
                        NewDr("Direction") = "Gate In " & IIf(Dr("Field08") = "5", "Full", "Empty")
                        NewDr("Dir") = "In"
                    Else
                        NewDr("Direction") = "Gate Out " & IIf(Dr("Field08") = "5", "Full", "Empty")
                        NewDr("Dir") = "Out"
                    End If
                    If Dr("Field08") = "5" Then
                        NewDr("FE") = "Full"
                    Else
                        NewDr("FE") = "Empty"
                    End If
                Case "DTM"
                    If NewDr("Dir") = "Out" Then ' Dr("Field01") = "7" Then
                        NewDr("GateOut") = DateTime.ParseExact(Dr("Field02"), "yyyyMMddHHmm", Nothing)
                        TB.Rows.Add(NewDr)
                    ElseIf NewDr("Dir") = "In" Then ' Dr("Field01") = "132" Then
                        NewDr("GateInDate") = DateTime.ParseExact(Dr("Field02"), "yyyyMMddHHmm", Nothing)
                        TB.Rows.Add(NewDr)
                    End If
            End Select

        Next

        Dm = New DataManager(My.Settings.DSN)

        For Each Dr In TB.Rows
            Dm.QueryCriteria.Clear()
            Dm.QueryCriteria.And(JoinPath.TB_EcsContainers.Columns.CntrNo, Dr("CntrNo"), MatchType.Exact)
            Ecs = Dm.GetTB_EcsContainersCollection
            Ecs = Ecs.SortByLastStatusDate(SortDirection.Descending)
            If Ecs.Count > 0 Then
                Dr("ID") = Ecs(0).ID
                Dr("CurrentStatus") = Ecs(0).LastStatus
                Dr("CnSize") = Ecs(0).CnSize
                Dr("CnType") = Ecs(0).CnType
                Dr("CurrentDate") = DateTime.Parse(Ecs(0).LastStatusDate)
            Else
                Dr("ID") = Guid.Empty
                Dr("CnSize") = Dr("CnSize")
                Dr("CnType") = Dr("CnType")
                Dr.RowError = "No Data in E.C.S !"
            End If
        Next

        For Each Dr In TB.Rows
            If Dr.RowError = "" Then
                If Dr("Dir") = "In" Then
                    If Dr("CurrentDate") > Dr("GateInDate") Then
                        Dr.RowError = "Date Sequence Wrong !"
                    End If
                Else
                    If Dr("CurrentDate") > Dr("GateOut") Then
                        Dr.RowError = "Date Sequence Wrong !"
                    End If
                End If
            End If
        Next

        Dm = New DataManager(My.Settings.DSN)
        Dm.QueryCriteria.And(JoinPath.TB_CODE.Columns.GroupCode, "ES", MatchType.Exact)
        Codes = Dm.GetTB_CODECollection

        For Each Dr In TB.Rows
            If Dr.RowError = "" Then
                SelCode = Codes.FilterBySTDCode(Dr("CurrentStatus"))
                Drs = Dm.DataSet.Tables("TB_Code").Select("GroupCode = 'ES' and StdCode = '" & Dr("CurrentStatus") & "'")
                If Drs.Length > 0 Then
                    Dr("NextCode") = Drs(0).Item("NextCode")
                Else
                    Beep()
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

    Private Sub ImportFromXml()

        Dim Dialog As New OpenFileDialog
        Dim DS As New DataSet
        Dim Drs() As DataRow
        Dim Dr As DataRow
        Dim NewDr As DataRow
        Dim Dm As DataManager
        Dim Ecs As TB_EcsContainersCollection
        Dim BGM As String
        Dim Codes As TB_CODECollection
        Dim SelCode As TB_CODECollection
        Dim InOut As String

        TB.Clear()

        Dialog.Filter = "XML Files (*.XML)|*.XML|All files (*.*)|*.*"
        Dialog.ShowDialog()
        If Dialog.FileName <> "" Then
            Try
                DS.ReadXml(Dialog.FileName)
            Catch ex As Exception
                MsgBox("Problem In XML File")
                MsgBox(ex.ToString)
                Exit Sub
            End Try
        Else
            Exit Sub
        End If

        '  Me.Header.TextValue = DS.Tables(0).TableName
        Select Case DS.Tables(0).TableName
            Case "Az_GetDeliverToConsigneeContainers"
                InOut = "Out"
            Case "GetArrivalContainers"
                InOut = "In"
            Case "Az_GetInventoryContainers"
                InOut = "In"
            Case DS.Tables(0).TableName
                MsgBox("No XML identify")
                Exit Sub
        End Select

        For Each Dr In DS.Tables(0).Rows
            NewDr = TB.NewRow
            NewDr("CntrNo") = Replace(Dr("Container"), "-", "")
            NewDr("CntrNo") = Replace(NewDr("CntrNo"), " ", "")
            If InOut = "In" Then
                NewDr("GateIndate") = Dr("ArrivalDate")
                NewDr("Direction") = "Gate In Empty"
                NewDr("Dir") = "In"
                NewDr("FE") = "Empty"
                NewDr("CnSize") = Mid(Dr("ContainerSizeName"), 1, 2)
                NewDr("CnType") = Dr("ContainerTypeName")
                TB.Rows.Add(NewDr)
            Else
                NewDr("GateOut") = Dr("ArrivalDate")
                NewDr("Dir") = "Out"
                If Val(Dr("ExitTypeCode")) = 2 Then
                    NewDr("Direction") = "Gate Out Full"
                    NewDr("FE") = "Full"
                    NewDr("CnSize") = Mid(Dr("ContainerSizeName"), 1, 2)
                    NewDr("CnType") = Dr("ContainerTypeName")
                Else
                    NewDr("Direction") = "Gate Out Empty"
                    NewDr("LetterNo") = Dr("AcceptanceLetterNo")
                    NewDr("FE") = "Empty"
                    NewDr("CnSize") = Mid(Dr("ContainerSizeName"), 1, 2)
                    NewDr("CnType") = Dr("ContainerTypeName")
                End If
                TB.Rows.Add(NewDr)
            End If
        Next

        Dm = New DataManager(My.Settings.DSN)
        For Each Dr In TB.Rows
            Dm.QueryCriteria.Clear()
            Dm.QueryCriteria.And(JoinPath.TB_EcsContainers.Columns.CntrNo, Dr("CntrNo"), MatchType.Exact)
            Ecs = Dm.GetTB_EcsContainersCollection
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

        Dm = New DataManager(My.Settings.DSN)
        Dm.QueryCriteria.And(JoinPath.TB_CODE.Columns.GroupCode, "ES", MatchType.Exact)
        Codes = Dm.GetTB_CODECollection

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


    Private Function AddAsNewRecord(ByVal DR As DataRow) As Boolean

        Dim EcsCntr As DataRow
        Dim EcsMove As DataRow
        Dim EcsID As Guid
        Dim InVoyage As New Guid("852796c6-07ad-de11-8af6-002481e363f6")
        Dim Ans As Boolean
        EcsCntr = DM.DataSet.Tables("TB_EcsContainers").NewRow
        EcsID = Guid.NewGuid
        EcsCntr("Line") = "OOCL"
        EcsCntr("DischargeTo") = "IRBND"
        EcsCntr("LastDepot") = "TW"
        EcsCntr("LastStatus") = "EA"
        EcsCntr("LastStatusDate") = Date.Parse(DR("GateInDate"))
        EcsCntr("ID") = EcsID
        EcsCntr("CnSize") = DR("CnSize")
        EcsCntr("CnType") = DR("CnType")
        EcsCntr("CntrNo") = DR("CntrNo")
        EcsCntr("InVoyageID") = InVoyage
        EcsCntr("InStatus") = "F"
        EcsCntr("SOC") = "N"
        DM.DataSet.Tables("TB_EcsContainers").Rows.Add(EcsCntr)
        EcsMove = DM.DataSet.Tables("TB_EcsMoves").NewRow
        EcsMove("CntrID") = EcsID
        EcsMove("Status") = "EA"
        EcsMove("StatusDate") = Date.Parse(DR("GateInDate"))
        EcsMove("StatusDateToLine") = Date.Parse(DR("GateInDate"))
        EcsMove("Depot") = "TW"
        EcsMove("Remarks") = "Import by XML File !"
        DM.DataSet.Tables("TB_Ecsmoves").Rows.Add(EcsMove)
        Try
            LogDataSet = DM.DataSet.Copy
            DM.CommitAll()
            GenerateLog(LogDataSet)
            DR.Delete()
            Ans = True
        Catch ex As Exception
            MsgBox(ex.ToString)
            Ans = False
        End Try

    End Function

    Private Sub EcsCntrsInsert_ClickAccepte() Handles EcsCntrsInsert.ClickAccepte

        Dim Dr As DataRow
        Dim NewDr As DataRow
        Dim Ecs As TB_EcsContainersCollection
        Dim Codes As TB_CODECollection
        Dim SelCode As TB_CODECollection
        Dim Drs() As DataRow
        Dim CntrNo As String

        TB.Clear()
        TB.AcceptChanges()

        For Each Dr In EcsCntrsInsert.TBCntrs.Rows
            NewDr = TB.NewRow

            CntrNo = Replace(Dr("CntrNo") & "", " ", "")
            CntrNo = Replace(CntrNo, "-", "")
            CntrNo = Replace(CntrNo, "_", "")

            NewDr("CntrNo") = CntrNo
            NewDr("Depot") = Me.Depot.Code
            NewDr("BookingNo") = Me.BookingID.BookingNo
            If Trim(CntrNo).Length > 0 Then
                If EcsCntrsInsert.AsGateIn = True Then
                    NewDr("Direction") = "Gate In " & IIf(EcsCntrsInsert.IsFull = True, "Full", "Empty")
                    NewDr("Dir") = "In"
                Else
                    NewDr("Direction") = "Gate Out " & IIf(EcsCntrsInsert.IsFull = True, "Full", "Empty")
                    NewDr("Dir") = "Out"
                End If

                If EcsCntrsInsert.IsFull = True Then
                    NewDr("FE") = "Full"
                Else
                    NewDr("FE") = "Empty"
                End If

                If NewDr("Dir") = "Out" Then
                    NewDr("GateOut") = Dr("EventDate")
                    TB.Rows.Add(NewDr)
                ElseIf NewDr("Dir") = "In" Then
                    NewDr("GateInDate") = Dr("EventDate")
                    TB.Rows.Add(NewDr)
                End If
            End If
        Next

        DM = New DataManager(My.Settings.DSN)

        For Each Dr In TB.Rows
            DM.QueryCriteria.Clear()
            DM.QueryCriteria.And(JoinPath.TB_EcsContainers.Columns.CntrNo, Dr("CntrNo"), MatchType.Exact)
            Ecs = DM.GetTB_EcsContainersCollection
            Ecs = Ecs.SortByLastStatusDate(SortDirection.Descending)
            If Ecs.Count > 0 Then
                Dr("ID") = Ecs(0).ID
                Dr("CurrentStatus") = Ecs(0).LastStatus
                Dr("CnSize") = Ecs(0).CnSize
                Dr("CnType") = Ecs(0).CnType
                Dr("CurrentDate") = DateTime.Parse(Ecs(0).LastStatusDate)

                'To add values to the D/O column
                If Me.Status.Code = "MA" Or Me.Status.Code = "DM" Then
                    Dr("D/O") = GetDeliveryOrderAsStringYorN(Ecs(0).CntrNo, Ecs(0).InVoyageID)
                End If
                'End D/O
            Else
                Dr("ID") = Guid.Empty
                Dr("CnSize") = Dr("CnSize")
                Dr("CnType") = Dr("CnType")
                Dr.RowError = "No Data in E.C.S !"
            End If
        Next

        For Each Dr In TB.Rows
            If Dr.RowError = "" Then
                If Dr("Dir") = "In" Then
                    If Dr("CurrentDate") > Dr("GateInDate") Then
                        Dr.RowError = "Date Sequence Wrong !"
                    End If
                Else
                    If Dr("CurrentDate") > Dr("GateOut") Then
                        Dr.RowError = "Date Sequence Wrong !"
                    End If
                End If
            End If
        Next

        DM = New DataManager(My.Settings.DSN)
        DM.QueryCriteria.And(JoinPath.TB_CODE.Columns.GroupCode, "ES", MatchType.Exact)
        Codes = DM.GetTB_CODECollection

        For Each Dr In TB.Rows
            If Dr.RowError = "" Then
                SelCode = Codes.FilterBySTDCode(Dr("CurrentStatus"))
                Drs = DM.DataSet.Tables("TB_Code").Select("GroupCode = 'ES' and StdCode = '" & Dr("CurrentStatus") & "'")
                If Drs.Length > 0 Then
                    Dr("NextCode") = Drs(0).Item("NextCode")
                Else
                    Beep()
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


        Me.Remarks.Focus()

    End Sub

    Private Sub EcsCntrsInsert_ClickCancel() Handles EcsCntrsInsert.ClickCancel
        Me.Remarks.Focus()
    End Sub

    Private Function GetDeliveryOrderAsStringYorN(ByVal containerNo As String, ByVal inVoyageId As Guid) As String
        Dim result As String

        Dim Cmd As New SqlCommand("SP_GetDeliveryOrderStatus")
        Dim Cnn As New SqlConnection(My.Settings.DSN)
        Dim DA As New SqlDataAdapter
        Dim Tb As New DataTable
        Me.Cursor = Cursors.WaitCursor
        With Cmd
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Parameters.AddWithValue("@VoyageID", inVoyageId.ToString())
            Cmd.Parameters.AddWithValue("@CntrNo", containerNo)
            Cmd.Connection = Cnn
            Cmd.CommandTimeout = 5000
        End With
        DA.SelectCommand = Cmd
        DA.Fill(Tb)

        'Main concept
        If Tb.Rows.Count > 0 Then
            If Tb.Rows(0)(0).ToString = "Y" Then
                result = "Y"
            Else
                result = "N"
            End If
        End If

        Return result
    End Function

End Class