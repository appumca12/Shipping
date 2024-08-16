Imports OrmLib
Imports ShippingBiz
Imports Infragistics.Win.UltraWinGrid

Public Class FrmPermits

    Implements IFGeneral
    Private ItemLevel = "102"
    Private FrmStatus As FormStatus = FormStatus.NoAction
    Private PermitID As Guid
    Private Dm As DataManager
    Private TB As DataTable
    Private Ds As DataSet
    Private Permit As TB_Permits
    Private PermitDetail As TB_PermitDetails
    Dim AddSuccess As Boolean = False
    Dim sucess As String
    Dim empty As String
    Public IsSeal As Boolean

    Private Sub Permits_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.GeneralForms.InitControl("PERMITS", ItemLevel)
        Dim Col As UltraGridColumn

        sucess = "Y"
        InitTemp()
        Me.Status.InitControl("ST", UserComboCode.ShowCoumn.Meaning)
        Me.Yard.InitControl("DP", UserComboCode.ShowCoumn.Meaning)
        Me.FPOD.InitControl(Me.GroupBox2.BackColor)
        Me.POT.InitControl(Me.GroupBox2.BackColor)

        Me.IMDGCode.InitControl("HZ", UserComboCode.ShowCoumn.Meaning)
        Me.PackingGroup.InitControl("PZ", UserComboCode.ShowCoumn.Meaning)
        Me.PageNumber.InitControl(5, 0)
        Me.EMSNumber.SetLength(10)
        Me.UnNo.SetLength(10)

        With Me.GridPermit.DisplayLayout.Bands(0)
            '.Columns("TempMin").MaskInput = "{LOC}nn.nn"
            '.Columns("TempMax").MaskInput = "{LOC}nn.nn"

            .Columns("CntrID").Hidden = True

            '.Columns("CntrSel").Style = ColumnStyle.Button
            '.Columns("CntrSel").CellButtonAppearance.Image = Me.ImageListForm.Images(0)
            '.Columns("CntrSel").CellAppearance.Image = Me.ImageListForm.Images(0)
            '.Columns("CntrSel").Width = 25

            With Me.DropDownPkgs
                .DataSource = GetCodeList("PG")
                .DisplayMember = "Meaning"
                .ValueMember = "StdCode"
                For Each Col In .DisplayLayout.Bands(0).Columns
                    Col.Hidden = True
                Next
                .DisplayLayout.Bands(0).Columns("StdCode").Hidden = False
                .DisplayLayout.Bands(0).Columns("Meaning").Hidden = False
            End With

            With Me.DropDownFLE
                .DataSource = GetCodeList("FL")
                .DisplayMember = "StdCode"
                .ValueMember = "StdCode"
                For Each Col In .DisplayLayout.Bands(0).Columns
                    Col.Hidden = True
                Next
                .DisplayLayout.Bands(0).Columns("Meaning").Hidden = False
            End With

            .Columns("PackageType").Style _
                               = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate
            .Columns("PackageType").ValueList = Me.DropDownPkgs

            .Columns("FLE").Style _
                            = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate
            .Columns("FLE").ValueList = Me.DropDownFLE
        End With

        With Me.GridCntrs
            .DisplayLayout.Bands(0).Columns("ID").Hidden = True
            .DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        End With

        FrmStatus = FormStatus.NoAction
        General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)
        LockStatus(False)

        RefreshAvilebleCntrs()

    End Sub

    Private Sub LockStatus(ByVal Status As Boolean) Implements IFGeneral.LockStatus
        General.LockControls(Me, Status)
        Me.SearchPermitNo.GeneralTxt.Enabled = True
    End Sub

    Private Sub SendDataToClass() Implements IFGeneral.SendDataToClass


        Dim aTable() As String = {"TB_Permits", "TB_PermitDetails"}
        Dim Dr As DataRow
        Dim Drs() As DataRow
        Dim Detail As DataTable = DataSetForm.Tables("Details").GetChanges
        Dim nDr As DataRow
        Dim nDrDuplicate As DataTable
        Dim DuplicateCheck() As DataRow
        'For Duplication avoid
        Dim QuerySql As String
        Dim QuerySqlPermit As String
        Dim QuerySqlDupPermit As String
        Dim ctrId As String
        Dim lResult As Boolean
        Dim TB As DataTable = New DataTable
        Dim TBL As DataTable = New DataTable
        Dim TBLPermit As DataTable = New DataTable
        Dim detailsRow As DataRow
        Dm = New DataManager(My.Settings.DSN)
        Dm.QueryCriteria.Clear()
        Dim AddNew As Boolean = False

        'If DataSetForm.Tables("Details").DataSet.HasChanges(DataRowState.Deleted) Then
        '    Detail = DataSetForm.Tables("Details").GetChanges
        'End If

        Ds = StoredProcedures.SP_PermitsAllByPermitNo(Me.SearchPermitNo.TextValue)

        Dm.PopulateObjectsFromDataSet(Ds, aTable)



        If Dm.DataSet.Tables("TB_Permits").Rows.Count = 0 Then
            AddNew = True
            Dr = Dm.DataSet.Tables("TB_Permits").NewRow
            Dr("ID") = PermitID
            Dr("PermitNo") = Me.PermitNo.TextValue
            Dr("PackingGroup") = Me.PackingGroup.Code
            Dr("PageNumber") = Int32.Parse(Me.PageNumber.CtrlValue)
            Dr("EMSNumber") = Int32.Parse(Val(Me.EMSNumber.TextValue))
            Dr("FlashPoint") = Double.Parse(Me.FlashPoint.GnrlNum.Value)
            Dr("UNNumber") = Me.UnNo.TextValue
            Dr("POT") = Me.POT.PortCode
            Dr("Status") = Me.Status.Code
            Dr("Goods") = Me.Goods.TextValue
            Dr("FPOD") = Me.FPOD.PortCode
            Dr("POT") = Me.POT.PortCode
            Dr("IMDGCode") = Me.IMDGCode.Code
            Dr("Depot") = Me.Yard.Code
            QuerySqlDupPermit = "Select * from TB_Permits Where  PermitNo = '" & Me.PermitNo.TextValue & "'"
            TableBySql(QuerySqlDupPermit, TBLPermit, lResult)
            If (TBLPermit.Rows.Count = 0) Then
                Dm.DataSet.Tables("TB_Permits").Rows.Add(Dr)
                AddSuccess = True
            Else
                MsgBoxGeneral("PermitNo already exists!", "Validate Failed")
                AddSuccess = False
                Exit Sub
            End If

        Else
            Dr = Dm.DataSet.Tables("TB_Permits").Rows(0)
            Dr("PermitNo") = Me.PermitNo.TextValue
            Dr("PackingGroup") = Me.PackingGroup.Code
            Dr("PageNumber") = Int32.Parse(Me.PageNumber.CtrlValue)
            Dr("EMSNumber") = Int32.Parse(Val(Me.EMSNumber.TextValue))
            Dr("FlashPoint") = Double.Parse(Me.FlashPoint.GnrlNum.Value)
            Dr("UNNumber") = Me.UnNo.TextValue
            Dr("POT") = Me.POT.PortCode
            Dr("Status") = Me.Status.Code
            Dr("Goods") = Me.Goods.TextValue
            Dr("FPOD") = Me.FPOD.PortCode
            Dr("POT") = Me.POT.PortCode
            Dr("IMDGCode") = Me.IMDGCode.Code
            Dr("Depot") = Me.Yard.Code
            ' added by appu
            AddSuccess = True
        End If

        If Not Detail Is Nothing Then
            empty = "N"
            If Not DataSetForm.Tables("Details").DataSet.HasChanges(DataRowState.Deleted) Then
                For Each Dr In Detail.Rows
                    If IsDBNull(Dr("TempMin")) Or IsDBNull(Dr("TempMax")) Then
                        empty = "Y"
                    End If
                Next
            End If
            If empty = "Y" Then

                If MsgBoxTempMinMax() = Windows.Forms.DialogResult.Yes Then

                    For Each Dr In Detail.Rows
                        Select Case Dr.RowState
                            Case DataRowState.Added
                                'Added by thenmozhi for  Multiple document for 1 CONTAINER
                                QuerySql = "Select CntrNo,ID from TB_EcsContainers Where  ID = '" & Dr("CntrID").ToString & "'"
                                TableBySql(QuerySql, TB, lResult)
                                If (TB.Rows.Count > 0) Then
                                    ctrId = TB.Rows(0).Item(1).ToString
                                    'End
                                    nDr = Dm.DataSet.Tables("TB_PermitDetails").NewRow
                                    nDr("ID") = Guid.NewGuid
                                    nDr("PermitID") = PermitID
                                    If (AddNew) Then
                                        nDr("CntrID") = ctrId ' Dr("CntrID")
                                    Else
                                        nDr("CntrID") = ctrId 'Dr("CntrID")
                                    End If
                                    nDr("GW") = Dr("GW")
                                    nDr("VGM") = Dr("VGM")
                                    nDr("FLE") = Dr("FLE")
                                    nDr("NoOfPkgs") = Dr("NoOfPkgs")
                                    nDr("PackageType") = Dr("PackageType")
                                    nDr("SealNo") = Dr("SealNo")
                                    If Not IsDBNull(Dr("TempMin")) Then
                                        nDr("TempMin") = Dr("TempMin")
                                    End If
                                    If Not IsDBNull(Dr("TempMax")) Then
                                        nDr("TempMax") = Dr("TempMax")
                                    End If
                                    'Added by thenmozhi for  Multiple document for 1 CONTAINER
                                    For Each detailsRow In TB.Rows
                                        QuerySqlPermit = "Select * from TB_PermitDetails Where  CntrID = '" & ctrId.ToUpper & "' and PermitID='" & PermitID.ToString.ToUpper() & "'"
                                        TableBySql(QuerySqlPermit, TBL, lResult)
                                        If (TBL.Rows.Count = 0) Then
                                            Dm.DataSet.Tables("TB_PermitDetails").Rows.Add(nDr)
                                            AddSuccess = True
                                        Else
                                            MsgBoxGeneral("Can not insert more documents for one container!", "Validate Failed")
                                            AddSuccess = False
                                            Exit Sub
                                        End If
                                    Next
                                End If
                                'End
                            Case DataRowState.Deleted
                                Drs = Dm.DataSet.Tables("TB_PermitDetails").Select("CntrID = '" & Dr(0, DataRowVersion.Original).ToString & "'", "")
                                If Drs.Length > 0 Then
                                    Drs(0).Delete()
                                End If
                            Case DataRowState.Modified
                                Drs = Dm.DataSet.Tables("TB_PermitDetails").Select("CntrID = '" & Dr("CntrID").ToString & "'")
                                If Drs.Length > 0 Then

                                    nDr = Drs(0)
                                    sucess = "Y"
                                    nDr("TempMin") = Dr("TempMin")
                                    nDr("TempMax") = Dr("TempMax")
                                    'If IsDBNull(Dr("TempMax")) Then
                                    '    nDr("TempMax") = Dr("TempMax")
                                    'End If
                                    nDr("GW") = Dr("GW")
                                    nDr("VGM") = Dr("VGM")
                                    nDr("NoOfPkgs") = Dr("NoOfPkgs")
                                    nDr("PackageType") = Dr("PackageType")
                                    nDr("SealNo") = Dr("SealNo")
                                    nDr("FLE") = Dr("FLE")

                                End If
                        End Select
                    Next
                Else
                    sucess = "N"

                End If
            End If
            If empty = "N" Then

                For Each Dr In Detail.Rows
                    Select Case Dr.RowState
                        Case DataRowState.Added
                            'Added by thenmozhi for  Multiple document for 1 CONTAINER
                            QuerySql = "Select CntrNo,ID from TB_EcsContainers Where  ID = '" & Dr("CntrID").ToString & "'"
                            TableBySql(QuerySql, TB, lResult)
                            If (TB.Rows.Count > 0) Then
                                ctrId = TB.Rows(0).Item(1).ToString
                                'End
                                nDr = Dm.DataSet.Tables("TB_PermitDetails").NewRow
                                nDr("ID") = Guid.NewGuid
                                nDr("PermitID") = PermitID
                                If (AddNew) Then
                                    nDr("CntrID") = ctrId ' Dr("CntrID")
                                Else
                                    nDr("CntrID") = ctrId 'Dr("CntrID")
                                End If
                                nDr("GW") = Dr("GW")
                                nDr("VGM") = Dr("VGM")
                                nDr("FLE") = Dr("FLE")
                                nDr("NoOfPkgs") = Dr("NoOfPkgs")
                                nDr("PackageType") = Dr("PackageType")
                                nDr("SealNo") = Dr("SealNo")
                                If Not IsDBNull(Dr("TempMin")) Then
                                    nDr("TempMin") = Dr("TempMin")
                                End If
                                If Not IsDBNull(Dr("TempMax")) Then
                                    nDr("TempMax") = Dr("TempMax")
                                End If
                                'Added by thenmozhi for  Multiple document for 1 CONTAINER
                                For Each detailsRow In TB.Rows
                                    QuerySqlPermit = "Select * from TB_PermitDetails Where  CntrID = '" & ctrId.ToUpper & "' and PermitID='" & PermitID.ToString.ToUpper() & "'"
                                    TableBySql(QuerySqlPermit, TBL, lResult)
                                    If (TBL.Rows.Count = 0) Then
                                        Dm.DataSet.Tables("TB_PermitDetails").Rows.Add(nDr)
                                        AddSuccess = True
                                        '' Exit For
                                    Else
                                        MsgBoxGeneral("Can not insert more documents for one container!", "Validate Failed")
                                        AddSuccess = False
                                        Exit Sub
                                    End If
                                Next
                            End If
                            'End
                        Case DataRowState.Deleted
                            Drs = Dm.DataSet.Tables("TB_PermitDetails").Select("CntrID = '" & Dr(0, DataRowVersion.Original).ToString & "'", "")
                            If Drs.Length > 0 Then
                                Drs(0).Delete()
                            End If
                        Case DataRowState.Modified
                            Drs = Dm.DataSet.Tables("TB_PermitDetails").Select("CntrID = '" & Dr("CntrID").ToString & "'")
                            If Drs.Length > 0 Then

                                nDr = Drs(0)
                                sucess = "Y"
                                nDr("TempMin") = Dr("TempMin")
                                nDr("TempMax") = Dr("TempMax")
                                'If IsDBNull(Dr("TempMax")) Then
                                '    nDr("TempMax") = Dr("TempMax")
                                'End If
                                nDr("GW") = Dr("GW")
                                nDr("VGM") = Dr("VGM")
                                nDr("NoOfPkgs") = Dr("NoOfPkgs")
                                nDr("PackageType") = Dr("PackageType")
                                nDr("SealNo") = Dr("SealNo")
                                nDr("FLE") = Dr("FLE")

                            End If
                    End Select
                Next
            End If

        End If

    End Sub

    Private Sub Populate() Implements IFGeneral.Populate

        Dim dr As DataRow
        Dim nDr As DataRow
        Me.DataSetForm.Tables("Details").Clear()

        With Ds.Tables(0).Rows(0)
            Me.PermitID = .Item("ID")
            Me.PermitNo.TextValue = .Item("PermitNo")
            Me.PackingGroup.Code = .Item("PackingGroup")
            Me.PageNumber.GnrlNum.Value = NullToValue(.Item("PackingGroup"), 0)
            Me.Status.Code = NullToValue(.Item("Status"), "")
            Me.Yard.Code = NullToValue(.Item("Depot"), "")
            Me.Goods.TextValue = NullToValue(.Item("Goods"), "")
            Me.FPOD.PortCode = NullToValue(.Item("FPOD"), "")
            Me.POT.PortCode = NullToValue(.Item("POT"), "")
            Me.EMSNumber.TextValue = NullToValue(.Item("EMSNumber"), "")
            Me.UnNo.TextValue = NullToValue(.Item("UnNumber"), "")
            Me.IMDGCode.Code = NullToValue(.Item("ImdgCode"), "")
            Me.FlashPoint.GnrlNum.Value = Double.Parse(NullToValue(.Item("FlashPoint"), 0))
        End With

        For Each dr In Ds.Tables(2).Rows
            nDr = Me.DataSetForm.Tables("Details").NewRow
            nDr("CntrID") = dr("ID")
            nDr("CntrNo") = dr("CntrNo")
            nDr("CnSize") = dr("CnSize")
            nDr("CnType") = dr("CnType")
            nDr("GW") = dr("GW")
            nDr("VGM") = dr("VGM")
            nDr("FLE") = dr("FLE")
            nDr("PackageType") = dr("PackageType")
            nDr("NoOfPkgs") = dr("NoOfPkgs")
            nDr("SealNo") = dr("SealNo")
            nDr("TempMin") = dr("TempMin")
            nDr("TempMax") = dr("TempMax")
            Me.DataSetForm.Tables("Details").Rows.Add(nDr)
        Next
        Me.DataSetForm.AcceptChanges()

    End Sub

    Private Sub InitTemp()

        'TB = New DataTable
        'TB.TableName = "TB_PermitDetails"

        'TB.Columns.Add(New DataColumn("ID", System.Type.GetType("System.Guid")))
        'TB.Columns.Add(New DataColumn("PermitID", System.Type.GetType("System.Guid")))
        'TB.Columns.Add(New DataColumn("CntrID", System.Type.GetType("System.Guid")))
        'TB.Columns.Add(New DataColumn("CntrNo", System.Type.GetType("System.String")))
        'TB.Columns.Add(New DataColumn("CnSize", System.Type.GetType("System.String")))
        'TB.Columns.Add(New DataColumn("CnType", System.Type.GetType("System.String")))
        'TB.Columns.Add(New DataColumn("FLE", System.Type.GetType("System.String")))
        'TB.Columns.Add(New DataColumn("GW", System.Type.GetType("System.Double")))
        'TB.Columns.Add(New DataColumn("PackageType", System.Type.GetType("System.String")))
        'TB.Columns.Add(New DataColumn("NoOFPkgs", System.Type.GetType("System.Int32")))
        'TB.Columns.Add(New DataColumn("SealNo", System.Type.GetType("System.String")))

        'For Each dCol In TB.Columns
        '    dCol.AllowDBNull = True
        'Next

        '  Me.GridPermit.DataSource = TB


    End Sub

    'For ILS Shortcuts: Changed from Private Sub GeneralForms_CustomFindClick() Handles GeneralForms.CustomFindClick to GeneralForms_CustomFindClick(ByVal sender As Object, ByVal formId As Integer)
    Public Sub GeneralForms_CustomFindClick(ByVal sender As Object, ByVal formId As Integer)

        If (Me.GeneralForms.getItemLevel(Me.GeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts  

            Dim StorPermit As String
            Dim aTable() As String = {"TB_Permits", "TB_PermitDetails"}

            Try
                Ds.Tables(0).Clear()
                Ds.Tables(1).Clear()
                Ds.AcceptChanges()
                Me.DataSetForm.Tables("Details").Clear()
                Me.DataSetForm.AcceptChanges()
            Catch ex As Exception

            End Try

            StorPermit = Me.SearchPermitNo.TextValue

            ClearControl(Me)

            Me.SearchPermitNo.TextValue = StorPermit
            If Dm Is Nothing Then
                Dm = New DataManager(My.Settings.DSN)
            End If
            Dm.QueryCriteria.Clear()
            Ds = StoredProcedures.SP_PermitsAllByPermitNo(Me.SearchPermitNo.TextValue)

            Dm.PopulateObjectsFromDataSet(Ds, aTable)
            If Ds.Tables(0).Rows.Count = 0 Then
                MsgBoxGeneral("No Valid Permit !", "Search Result")
                FrmStatus = FormStatus.NoAction
            Else
                FrmStatus = FormStatus.HasData
            End If
            If FrmStatus = FormStatus.HasData Then
                Populate()
            End If
            General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)
            LockStatus(False)
        End If

    End Sub

    'For ILS Shortcuts: Changed from Private Sub GeneralForms_CustomNewClick() Handles GeneralForms.CustomNewClick
    Public Sub GeneralForms_CustomNewClick(ByVal sender As Object, ByVal formId As Integer)

        If (Me.GeneralForms.getItemLevel(Me.GeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts

            Try
                Ds.Tables(0).Clear()
                Ds.Tables(1).Clear()
                Ds.AcceptChanges()
            Catch ex As Exception

            End Try
            PermitID = System.Guid.NewGuid
            FrmStatus = FormStatus.NewRecord
            General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)
            Me.DataSetForm.Tables("Details").Clear()
            ClearControl(Me)
            LockStatus(True)
        End If

    End Sub

    'For ILS Shortcuts Changed from Private Sub GeneralForms_CustomEditClick() Handles GeneralForms.CustomEditClick
    Public Sub GeneralForms_CustomEditClick(ByVal sender As Object, ByVal formId As Integer)

        If (Me.GeneralForms.getItemLevel(Me.GeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts
            FrmStatus = FormStatus.EditRecord
            General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)
            LockStatus(True)
        End If

    End Sub

    'For ILS Shortcuts: Changed from Private Sub GeneralForms_CustomSaveClick() Handles GeneralForms.CustomSaveClick
    Public Sub GeneralForms_CustomSaveClick(ByVal sender As Object, ByVal formId As Integer)

        If (Me.GeneralForms.getItemLevel(Me.GeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts

            Dim LogDataSet As New DataSet


            Me.GridPermit.UpdateData()

            If Not ValidateForm() Then
                Exit Sub
            End If

            If MsgBoxUpdate() = Windows.Forms.DialogResult.Yes Then
                Try
                    SendDataToClass()
                    If (AddSuccess) Then
                        LogDataSet = Dm.DataSet.Copy
                        Dm.CommitAll()
                        FrmStatus = FormStatus.HasData
                        GenerateLog(LogDataSet)
                        If sucess = "Y" Then
                            MsgBoxSaveSuccessful()
                        Else
                            Exit Sub
                        End If

                        DataSetForm.AcceptChanges()
                    End If
                Catch ex As Exception
                    MsgBoxSaveFailed()
                    MsgBox(ex.ToString)
                End Try
            End If
            General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)
        End If

    End Sub

    'For ILS Shortcuts Changed from Private Sub GeneralForms_CustomDeleteClick() Handles GeneralForms.CustomDeleteClick
    Public Sub GeneralForms_CustomDeleteClick(ByVal sender As Object, ByVal formId As Integer)

        If (Me.GeneralForms.getItemLevel(Me.GeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts

            Dim LogDataSet = New DataSet

            If FrmStatus = FormStatus.EditRecord Then

                If MsgBoxDelete() = Windows.Forms.DialogResult.Yes Then
                    Try

                        Dm.DataSet.Tables("TB_Permits").Rows(0).Delete()
                        LogDataSet = Dm.DataSet.Copy
                        Dm.CommitAll()
                        GenerateLog(LogDataSet)
                        MsgBoxDeleteSuccessful()
                        ClearControl(Me)
                        FrmStatus = FormStatus.NoAction
                        General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)
                        LockStatus(True)
                    Catch ex As Exception
                        MsgBoxDeleteFailed()
                    End Try
                End If
            End If
        End If

    End Sub

    Private Function ValidateForm() As Boolean

        Dim Ans As Boolean = True
        Dim nI As Byte
        Dim aList As New ArrayList
        Dim dr As DataRow

        FormErrorProvider.Clear()

        If Me.PermitNo.TextValue = "" Then
            aList.Add(Me.PermitNo)
        End If

        If Me.Goods.TextValue = "" Then
            aList.Add(Me.Goods)
        End If

        If Me.Status.Code = "" Then
            aList.Add(Me.Status)
        End If

        If Me.POT.PortCode = "" Then
            aList.Add(Me.POT)
        End If

        If Me.FPOD.PortCode = "" Then
            aList.Add(Me.FPOD)
        End If

        If aList.Count > 0 Then
            For nI = 0 To aList.Count - 1
                FormErrorProvider.SetError(aList(nI), "Data Requird")
            Next
            MsgBoxValidateFaild()
            Ans = False
        End If

        For Each dr In Me.DataSetForm.Tables("Details").Rows

            If dr.RowState <> DataRowState.Deleted Then
                dr.RowError = ""

                If NullToValue(dr("FLE"), "") = "" Then
                    dr.RowError = "Please Fill FLE"
                    Ans = False
                End If


                If NullToValue(dr("SealNo"), "") = "" Then
                    dr.RowError = "Please Fill FLE"
                    Ans = False
                End If

                If dr("FLE") <> "E" Then
                    If NullToValue(dr("GW"), 0) = 0 Or Trim(NullToValue(dr("PackageType"), "")) = "" Or Trim(NullToValue(dr("SealNo"), "")) = "" Then
                        dr.RowError = "Please Fill GW , No Of Pkgs , Package Type & Seal No "
                        Ans = False
                    End If
                End If
            End If
        Next

        Return Ans

    End Function

    Private Sub RefreshAvilebleCntrs()

        Dim TempDs As New DataSet
        Dim Dr As DataRow
        Dim NewDr As DataRow
        Dim Col As DataColumn
        Dim R As UltraGridRow

        TempDs = StoredProcedures.SP_ReadyCntrsForpermit(CurrentShippingLine)
        DataSetForm.Tables("Cntrs").Clear()
        DataSetForm.AcceptChanges()

        For Each Dr In TempDs.Tables(0).Rows
            NewDr = Me.DataSetForm.Tables("Cntrs").NewRow
            For Each Col In Dr.Table.Columns
                NewDr(Col.ColumnName) = Dr(Col.ColumnName)
            Next
            Me.DataSetForm.Tables("Cntrs").Rows.Add(NewDr)
        Next

        For Each R In GridCntrs.Rows
            If R.Cells("Status").Text = "As FCL" Then
                R.Appearance.BackColor = Color.White
                R.Appearance.ForeColor = Color.Black
            Else
                R.Appearance.BackColor = Color.Maroon
                R.Appearance.ForeColor = Color.Yellow
            End If
        Next

    End Sub

    Private Sub TabControl_ActiveTabChanged(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinTabControl.ActiveTabChangedEventArgs) Handles TabControl.ActiveTabChanged
        If TabControl.ActiveTab.Text = "Permit Details" Then
            AssignCntrs()
        Else
            RefreshAvilebleCntrs()
        End If
    End Sub

    Private Sub AssignCntrs()

        Dim DrSelect() As DataRow
        Dim dr As DataRow
        Dim CurrDr() As DataRow
        Dim ndr As DataRow

        DrSelect = DataSetForm.Tables("Cntrs").Select("Select = true")

        For Each dr In DrSelect
            CurrDr = Me.DataSetForm.Tables("Details").Select("CntrID = '" & dr("ID").ToString & "'")
            If CurrDr.Length = 0 Then
                ndr = Me.DataSetForm.Tables("Details").NewRow
                ndr("CntrID") = dr("ID")
                ndr("CntrNo") = dr("CntrNo")
                ndr("CnSize") = dr("CnSize")
                ndr("CnType") = dr("CnType")
                If dr("Status") = "As LCL" Then
                    ndr("FLE") = "L"
                Else
                    ndr("FLE") = "F"
                End If
                ndr("GW") = 0
                ndr("VGM") = 0
                ndr("PackageType") = "PKG"
                ndr("NoOfPkgs") = 0
                Me.DataSetForm.Tables("Details").Rows.Add(ndr)
            End If
        Next

    End Sub

    Private Sub GridPermit_BeforeExitEdit(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeExitEditModeEventArgs) Handles GridPermit.BeforeExitEditMode

        If GridPermit.ActiveCell.Column.Header.Caption = "SealNo" Then

            Dim Tb As New DataTable
            Dim ACtIndex As Integer
            Dim ActSeal As String
            GridPermit.UpdateData()
            ACtIndex = GridPermit.ActiveCell.Row.Index
            ActSeal = GridPermit.ActiveCell.Value.ToString()
            For Each GRow In GridPermit.Rows
                
                If Not GRow.Index = ACtIndex Then
                    If GRow.Cells("SealNo").Value.ToString() = ActSeal Then

                        MessageBox.Show(ActSeal + " Duplicate Seal No Not Allowed!")
                        GridPermit.ActiveCell.Value = ""

                        Exit Sub
                    End If
                End If
            Next
            CheckSealNew(GridPermit.ActiveCell.Text)
        End If

    End Sub
    Private Sub GridPermit_AfterCellUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles GridPermit.AfterCellUpdate

        If e.Cell.Column.Header.Caption = "SealNo" Then
            CheckSeal(e)
        End If
        If e.Cell.Column.Header.Caption = "GW" Then
            Dim Tb As New DataTable
            Dim lResult As Boolean
            Dim sSql As String
            Dim Drs() As DataRow
            sSql = "select payload from TB_ECSBank where CntrNo = '" & GridPermit.ActiveRow.Cells("CntrNo").Value & "'"

            TableBySql(sSql, TB, lResult)
            If TB.Rows.Count > 0 Then
                If Convert.ToDouble(e.Cell.Value) > Convert.ToDouble(Tb.Rows(0).Item("payload")) Then
                    MessageBox.Show("GW more than Payload. Please input valid GW", "Shipping")
                    GridPermit.ActiveCell.Value = 0
                End If
            End If
        End If
    End Sub

    Private Sub GridPermit_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles GridPermit.InitializeLayout

        e.Layout.Override.SupportDataErrorInfo = SupportDataErrorInfo.RowsAndCells
        e.Layout.Override.DataErrorCellAppearance.ForeColor = Color.Red
        e.Layout.Override.DataErrorRowAppearance.BackColor = Color.LightYellow
        e.Layout.Override.DataErrorRowSelectorAppearance.BackColor = Color.Green
        e.Layout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.Default
        e.Layout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex

    End Sub

    Private Sub GridCntrs_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles GridCntrs.InitializeLayout
        e.Layout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.Default
        e.Layout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex

    End Sub

    Private Sub CheckSeal(ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs)

        Dim Tb As New DataTable
        Dim lResult As Boolean
        Dim sSql As String
        Dim Drs() As DataRow
        Dim sPermit As String = ""

        Me.GridPermit.UpdateData()

        sSql = "select count(*) from tb_Permits pm , dbo.TB_PermitDetails pmd " & _
               "where pm.id = pmd.PermitID and permitno <> '" & Me.PermitNo.TextValue.ToString & "' and pmd.sealno = '" & e.Cell.Value.ToString & "'"

        TableBySql(sSql, Tb, lResult)
        If Tb.Rows.Count > 0 Then
            If Tb.Rows(0).Item(0) > 0 Then
                sSql = "select PermitNo from tb_Permits pm , dbo.TB_PermitDetails pmd " & _
                       "where pm.id = pmd.PermitID and permitno <> '" & Me.PermitNo.TextValue.ToString & "' and pmd.sealno = '" & e.Cell.Value.ToString & "'"
                Tb = New DataTable
                TableBySql(sSql, Tb, lResult)
                For Each dr As DataRow In Tb.Rows
                    sPermit &= dr(0) & " : "
                Next
                Drs = Me.DataSetForm.Tables("Details").Select("SealNo = '" & e.Cell.Value.ToString & "'")
                For Each dr As DataRow In Drs
                    If dr.RowState <> DataRowState.Deleted Then
                        dr.RowError = "Duplicate Seal No. in " & sPermit
                    End If
                Next
            End If
        End If

    End Sub
    Private Sub CheckSealNew(ByVal SealNo As String)

        Dim Tb As New DataTable
        Dim lResult As Boolean
        Dim sSql As String
        Dim Drs() As DataRow
        Dim sPermit As String = ""

        Me.GridPermit.UpdateData()

        sSql = "select count(*) from tb_Permits pm , dbo.TB_PermitDetails pmd " & _
               "where pm.id = pmd.PermitID and permitno <> '" & Me.PermitNo.TextValue.ToString & "' and pmd.sealno = '" & SealNo & "'"

        TableBySql(sSql, Tb, lResult)
        If Tb.Rows.Count > 0 Then
            If Tb.Rows(0).Item(0) > 0 Then
                sSql = "select PermitNo from tb_Permits pm , dbo.TB_PermitDetails pmd " & _
                       "where pm.id = pmd.PermitID and permitno <> '" & Me.PermitNo.TextValue.ToString & "' and pmd.sealno = '" & SealNo & "'"
                Tb = New DataTable
                TableBySql(sSql, Tb, lResult)
                For Each dr As DataRow In Tb.Rows
                    sPermit &= dr(0) & " : "
                Next
                Drs = Me.DataSetForm.Tables("Details").Select("SealNo = '" & SealNo & "'")
                For Each dr As DataRow In Drs
                    If dr.RowState <> DataRowState.Deleted Then
                        dr.RowError = "Duplicate Seal No. in " & sPermit
                        MessageBox.Show(SealNo + " Duplicate Seal No Not Allowed!")
                        GridPermit.ActiveCell.Value = ""
                    End If
                Next
            End If
        End If

    End Sub

End Class