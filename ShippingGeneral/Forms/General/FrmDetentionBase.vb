Imports OrmLib
Imports ShippingBiz
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinEditors
Imports System.Data.SqlClient
Imports System.IO


Public Class FrmDetentionBase
    Implements IFGeneral

    Private ItemLevel As String = "407"
    Private MasterID As Guid
    Private FrmStatus As FormStatus = FormStatus.NoAction
    Private Dm As DataManager
    Private formlocalId As Integer 'For ILS Shortcuts  
    Private formId As String 'For ILS Shortcuts  

    Private Sub FrmDetentionBase_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim Col As Infragistics.Win.UltraWinGrid.UltraGridColumn
        Dim Tb As DataTable
        Dim Dr As DataRow
        Dim Lines As TB_LinesCollection

        Dim aCode As New ArrayList
        Dim aMeaning As New ArrayList

        Me.GeneralForms.InitControl("Detention Base", "407")

        With Me.DropDownType
            .DataSource = GetCodeList("CT")
            .DisplayMember = "StdCode"
            .ValueMember = "StdCode"
            For Each Col In .DisplayLayout.Bands(0).Columns
                Col.Hidden = True
            Next
            .DisplayLayout.Bands(0).Columns("StdCode").Hidden = False
        End With

        Tb = GetCodeList("1+")
        Dr = Tb.NewRow
        Dr("ID") = Guid.NewGuid
        Dr("StdCode") = "I"
        Dr("Meaning") = "Import"
        Tb.Rows.Add(Dr)

        Dr = Tb.NewRow
        Dr("ID") = Guid.NewGuid
        Dr("StdCode") = "E"
        Dr("Meaning") = "Export"
        Tb.Rows.Add(Dr)

        'External transit
        Dr = Tb.NewRow
        Dr("ID") = Guid.NewGuid
        Dr("StdCode") = "ET"
        Dr("Meaning") = "External transit"
        Tb.Rows.Add(Dr)

        aCode.Add("I")
        aCode.Add("E")
        aCode.Add("ET") 'External transit

        aMeaning.Add("Import")
        aMeaning.Add("Export")
        aMeaning.Add("External transit") 'External transit

        Me.ImpExp.InitControl(aCode, aMeaning, UserComboCode.ShowCoumn.Meaning)

        With Me.DropDownImpExp
            .DataSource = Tb
            .DisplayMember = "Meaning"
            .ValueMember = "StdCode"
            For Each Col In .DisplayLayout.Bands(0).Columns
                Col.Hidden = True
            Next
            .DisplayLayout.Bands(0).Columns("StdCode").Hidden = False
        End With

        With Me.GridMaster.DisplayLayout.Bands(0)
            .Columns("ImpExp").Style _
                               = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate
            .Columns("ImpExp").ValueList = Me.DropDownImpExp
            .Columns("ID").Hidden = True
        End With

        With Me.GridDetail.DisplayLayout.Bands(0)
            .Columns("CnType").Style _
                               = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate
            .Columns("CnType").ValueList = Me.DropDownType
            .Columns("ID").Hidden = True
            .Columns("BaseID").Hidden = True
        End With

        Me.Applydate.InitControl(False, False)
        Me.Validity.InitControl(False, False)
        Me.Remarks.SetLength(100)

        formId = Me.GeneralForms.getItemLevel(Me.GeneralForms.UserTabSelected)  'For ILS Shortcuts  
        formlocalId = Convert.ToInt32(formId) 'For ILS Shortcuts  

        'For ILS Shortcuts changed from GeneralForms_CustomFindClick() 
        Call GeneralForms_CustomFindClick(sender, formlocalId)
 
        Me.GroupBox.Appearance.BackColor = My.Settings.MainColor
        ChangeControlColor(Me.GroupBox, Me.UltraLabel1.GetType.ToString, My.Settings.MainColor, My.Settings.LableForeColor)
        Me.TabControl.BackColor = My.Settings.MainColor
        Me.TabControl.Appearance.BackColor = My.Settings.MainColor

        Me.Top = 0
        Me.Left = 0

        With Me.DropDownBase
            .DataSource = GetCodeList("YN")
            .DisplayMember = "Meaning"
            .ValueMember = "StdCode"
            For Each Col In .DisplayLayout.Bands(0).Columns
                Col.Hidden = True
            Next
            .DisplayLayout.Bands(0).Columns("StdCode").Hidden = False
            .DisplayLayout.Bands(0).Columns("Meaning").Hidden = False
        End With
        With Me.GridMaster.DisplayLayout.Bands(0)
            .Columns("IsBase").Style _
                                 = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate
            .Columns("IsBase").ValueList = Me.DropDownBase
            .Columns("Tax").Hidden = True
            .Columns("Toll").Hidden = True
            .Columns("Clause").Hidden = True
            .Columns("fClause").Hidden = True
        End With

        Me.IsBase.InitControl("YN", UserComboCode.ShowCoumn.Meaning)
        Me.Currency.InitControl("CU", UserComboCode.ShowCoumn.StdCode)

        With Me.GeneralForms.CustomToolbar.Toolbars(0)
            Dim CustomButton As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Clause")
            CustomButton.SharedProps.Caption = "Insert Clause"
            CustomButton.SharedProps.DisplayStyle = UltraWinToolbars.ToolDisplayStyle.ImageAndText
            CustomButton.SharedProps.AppearancesSmall.Appearance.Image = My.Resources.documents_24
            Me.GeneralForms.CustomToolbar.Tools.Add(CustomButton)
            Me.GeneralForms.CustomToolbar.Toolbars(0).Tools.AddTool("Clause")
        End With

        Dm = New DataManager(My.Settings.DSN)
        Dm.QueryCriteria.And(JoinPath.TB_Lines.Columns.LineCode, "", MatchType.Not)
        Lines = Dm.GetTB_LinesCollection()

        Me.Line.CustomDatasource = Dm.DataSet.Tables("TB_Lines")


        Me.Line.CustomDisplayMember = "LineCode"
        Me.Line.CustomValueMember = "LineCode"


    End Sub

    Private Sub SendDataToClass() Implements IFGeneral.SendDataToClass

        Dim nI As Byte
        Dim Changes As DataSet = FormDataSet.GetChanges
        Dim aTables() As String = {"TB_DetentionBase", "TB_DetentionBaseDetails"}
        Dim DS As New DataSet
        Dim Tb As DataTable
        Dim Dr As DataRow
        Dim Dv As DataView
        Dim DC As DataColumn


        Dm = New DataManager(My.Settings.DSN)

        DS = StoredProcedures.SP_DetentionAllByID(MasterID.ToString)
        Dm.PopulateObjectsFromDataSet(DS, aTables)

        For nI = 0 To aTables.Length - 1
            Dm.DataSet.Tables(aTables(nI)).Merge(DS.Tables(nI))
        Next

        Tb = Dm.DataSet.Tables("TB_DetentionBase")
        If Tb.Rows.Count = 0 Then
            Dr = Tb.NewRow
            Dr("ID") = MasterID
            Dr("Applydate") = Me.Applydate.GnrlDate.Value
            Dr("Validity") = Me.Validity.GnrlDate.Value
            Dr("Remarks") = Me.Remarks.TextValue
            Dr("ImpExp") = Me.ImpExp.Code
            Dr("IsBase") = Me.IsBase.Code
            Dr("Currency") = Me.Currency.Code
            Dr("Clause") = Me.Clause.TextValue
            Dr("fClause") = Me.FClause.TextValue
            Dr("Line") = Me.Line.CustomValue
            Tb.Rows.Add(Dr)
        Else
            Dr = Tb.Rows(0)
            Dr("Applydate") = Me.Applydate.GnrlDate.Value
            Dr("Validity") = Me.Validity.GnrlDate.Value
            Dr("Remarks") = Me.Remarks.TextValue
            Dr("ImpExp") = Me.ImpExp.Code
            Dr("IsBase") = Me.IsBase.Code
            Dr("Currency") = Me.Currency.Code
            Dr("Clause") = Me.Clause.TextValue
            Dr("fClause") = Me.FClause.TextValue
            Dr("Line") = Me.Line.CustomValue
        End If

        If Not Changes Is Nothing Then
            Tb = Changes.Tables("TB_DetentionBaseDetails")
            For Each Dr In Tb.Rows
                Select Case Dr.RowState
                    Case DataRowState.Added
                        Dm.DataSet.Tables(Tb.TableName).ImportRow(Dr)
                    Case DataRowState.Deleted
                        Dv = New DataView(Dm.DataSet.Tables(Tb.TableName), "ID = '" & Dr(0, DataRowVersion.Original).ToString & "'", "", DataViewRowState.CurrentRows)
                        If Dv.Count > 0 Then
                            Dv.Item(0).Delete()
                        End If
                    Case DataRowState.Modified
                        Dv = New DataView(Dm.DataSet.Tables(Tb.TableName), "ID = '" & Dr.Item("ID").ToString & "'", "", DataViewRowState.CurrentRows)
                        If Dv.Count > 0 Then
                            For Each DC In Tb.Columns
                                Dv.Item(0).Item(DC.ColumnName) = Dr.Item(DC.ColumnName)
                            Next
                        End If
                End Select
            Next
        End If

    End Sub

    Private Sub Populate() Implements IFGeneral.Populate

        MasterID = Me.GridMaster.ActiveRow.Cells("ID").Value
        Me.ImpExp.Code = GridMaster.ActiveRow.Cells("ImpExp").Value
        Me.Validity.GnrlDate.Value = GridMaster.ActiveRow.Cells("Validity").Value
        Me.Applydate.GnrlDate.Value = GridMaster.ActiveRow.Cells("Applydate").Value
        Me.Remarks.TextValue = GridMaster.ActiveRow.Cells("Remarks").Text

        Me.IsBase.Code = NullToValue(Me.GridMaster.ActiveRow.Cells("IsBase").Value, "Y")
        Me.Currency.Code = NullToValue(Me.GridMaster.ActiveRow.Cells("Currency").Value, "IRR")

        Me.Clause.TextValue = NullToValue(GridMaster.ActiveRow.Cells("Clause").Value, "")
        Me.FClause.TextValue = NullToValue(GridMaster.ActiveRow.Cells("FClause").Value, "")
        Me.Line.ComboGnrl.Text = NullToValue(GridMaster.ActiveRow.Cells("Line").Value, "")


        Dm = New DataManager(My.Settings.DSN)
        Dm.QueryCriteria.And(JoinPath.TB_DetentionBaseDetails.Columns.BaseID, MasterID.ToString, MatchType.Exact)
        Dm.GetTB_DetentionBaseDetailsCollection()

        Me.FormDataSet.Tables(1).Clear()
        Me.FormDataSet.Tables(1).Merge(Dm.DataSet.Tables("TB_DetentionBaseDetails"))
        Me.FormDataSet.AcceptChanges()
        Me.GridMaster.Enabled = False

    End Sub

    Private Sub LockStatus(ByVal Status As Boolean) Implements IFGeneral.LockStatus
        General.LockControls(Me, Status)
        Me.GridMaster.Enabled = True
    End Sub

    'For ILS Shortcuts: Changed from Private Sub GeneralForms_CustomFindClick() Handles GeneralForms.CustomFindClick to GeneralForms_CustomFindClick(ByVal sender As Object, ByVal formId As Integer)
    Public Sub GeneralForms_CustomFindClick(ByVal sender As Object, ByVal formId As Integer)

        If (Me.GeneralForms.getItemLevel(Me.GeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts  

            Dm = New DataManager(My.Settings.DSN)

            Dm.GetTB_DetentionBaseCollection.SortByApplyDate(SortDirection.Descending)
            Me.FormDataSet.Tables(0).Clear()
            Me.FormDataSet.Tables(0).Merge(Dm.DataSet.Tables("TB_DetentionBase"))

            If Me.GridMaster.Rows.Count = 0 Then
                FrmStatus = FormStatus.NoAction
            Else
                FrmStatus = FormStatus.HasData
            End If

            MasterID = Nothing

            Me.ImpExp.Code = ""
            Me.Applydate.GnrlDate.Value = DBNull.Value
            Me.Validity.GnrlDate.Value = DBNull.Value
            Me.Remarks.TextValue = ""
            Me.FormDataSet.Tables("TB_DetentionBaseDetails").Clear()

            FrmStatus = FormStatus.HasData
            General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)
            LockStatus(False)

            Me.GridMaster.Enabled = True
        End If

    End Sub

    'For ILS Shortcuts: Changed from Private Sub GeneralForms_CustomNewClick() Handles GeneralForms.CustomNewClick
    Public Sub GeneralForms_CustomNewClick(ByVal sender As Object, ByVal formId As Integer)

        If (Me.GeneralForms.getItemLevel(Me.GeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts

            Me.ImpExp.Code = ""
            Me.Validity.GnrlDate.Value = DBNull.Value
            Me.Applydate.GnrlDate.Value = DBNull.Value
            Me.Remarks.TextValue = ""
            Me.FormDataSet.Tables("TB_DetentionBaseDetails").Clear()

            MasterID = Guid.NewGuid
            FrmStatus = FormStatus.NewRecord
            General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)
            LockStatus(True)
            Me.GridMaster.Enabled = False
        End If

    End Sub

    'For ILS Shortcuts Changed from Private Sub GeneralForms_CustomEditClick() Handles GeneralForms.CustomEditClick
    Public Sub GeneralForms_CustomEditClick(ByVal sender As Object, ByVal formId As Integer)

        If (Me.GeneralForms.getItemLevel(Me.GeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts

            If Me.GridMaster.Rows.Count = 0 Then
                Exit Sub
            End If
            Populate()
            FrmStatus = FormStatus.EditRecord
            General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)
            LockStatus(True)
            Me.GridMaster.Enabled = False
            With Me.GridDetail.DisplayLayout.Bands(0)
                .Columns("CnType").SortIndicator = SortIndicator.Ascending
                .Columns("DayFrom").SortIndicator = SortIndicator.Ascending
            End With
        End If

    End Sub

    'For ILS Shortcuts: Changed from Private Sub GeneralForms_CustomSaveClick() Handles GeneralForms.CustomSaveClick
    Public Sub GeneralForms_CustomSaveClick(ByVal sender As Object, ByVal formId As Integer)
        If (Me.GeneralForms.getItemLevel(Me.GeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts
            Dim LogDataSet As New DataSet
            If ValidateForm() = False Then
                Exit Sub
            End If
            If MsgBoxUpdate() = Windows.Forms.DialogResult.Yes Then
                Try
                    SendDataToClass()
                    LogDataSet = Dm.DataSet.Copy
                    Dm.CommitAll()
                    GenerateLog(LogDataSet)
                    MsgBoxSaveSuccessful()
                    FormDataSet.AcceptChanges()
                    GeneralForms_CustomFindClick(sender, formId)
                Catch ex As Exception
                    MsgBoxDeleteFailed()
                    MsgBox(ex.ToString)
                End Try
            End If
        End If

    End Sub

    'For ILS Shortcuts Changed from Private Sub GeneralForms_CustomDeleteClick() Handles GeneralForms.CustomDeleteClick
    Public Sub GeneralForms_CustomDeleteClick(ByVal sender As Object, ByVal formId As Integer)

        If (Me.GeneralForms.getItemLevel(Me.GeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts
            Dim LogDataSet As New DataSet
            Dim nI As Byte
            Dim aTables() As String = {"TB_DetentionBase", "TB_DetentionBaseDetails"}
            Dim DS As New DataSet
            Dim Tb As DataTable
            Dim Dr As DataRow


            Dm = New DataManager(My.Settings.DSN)

            DS = StoredProcedures.SP_DetentionAllByID(MasterID.ToString)
            Dm.PopulateObjectsFromDataSet(DS, aTables)

            For nI = 0 To aTables.Length - 1
                Dm.DataSet.Tables(aTables(nI)).Merge(DS.Tables(nI))
            Next

            Tb = Dm.DataSet.Tables("TB_DetentionBase")
            If Tb.Rows.Count > 0 Then
                If MsgBoxDelete() = Windows.Forms.DialogResult.Yes Then
                    Try
                        Tb.Rows(0).Delete()
                        Tb = Dm.DataSet.Tables("TB_DetentionBaseDetails")
                        For Each Dr In Tb.Rows
                            Dr.Delete()
                        Next
                        LogDataSet = Dm.DataSet.Copy
                        Dm.CommitAll()
                        GenerateLog(LogDataSet)
                        MsgBoxDeleteSuccessful()
                        GeneralForms_CustomFindClick(sender, formId)
                    Catch ex As Exception
                        MsgBoxDeleteFailed()
                    End Try
                End If
            End If
        End If

    End Sub

    'For ILS Shortcuts: Changed from Private Sub GeneralForms_CustomOthers() Handles GeneralForms.CustomOthers
    Public Sub GeneralForms_CustomOthers(ByVal sender As Object, ByVal formId As Integer)

        If (Me.GeneralForms.getItemLevel(Me.GeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts

            'Dim frm As New FrmDetentionClause(GridMaster.ActiveRow.Cells("ID").Value)
            'frm.Show()
        End If

    End Sub

    Private Sub GeneralForms_CustomHomeClick() Handles GeneralForms.CustomHomeClick
        Me.Close()
    End Sub

    Private Sub GridMaster_BeforeRowUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CancelableRowEventArgs) Handles GridMaster.BeforeRowUpdate
        If IsDBNull(GridMaster.ActiveRow.Cells("ID")) = True Then
            MasterID = Guid.NewGuid
            GridMaster.ActiveRow.Cells("ID").Value = MasterID
        End If
    End Sub

    Private Sub GridDetail_BeforeRowUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CancelableRowEventArgs) Handles GridDetail.BeforeRowUpdate
        If IsDBNull((GridDetail.ActiveRow.Cells("ID")).Value) = True Then
            GridDetail.ActiveRow.Cells("ID").Value = Guid.NewGuid
            GridDetail.ActiveRow.Cells("BaseID").Value = MasterID
        End If
    End Sub

    Private Function ValidateForm() As Boolean

        Dim Ans As Boolean = True
        Dim nI As Byte
        Dim aList As New ArrayList

        FormErrorProvider.Clear()

        If ImpExp.Code = "" Then
            aList.Add(Me.ImpExp)
        End If

        If Me.Validity.GnrlDate.Value Is Nothing Then
            aList.Add(Me.Validity)
        End If

        If Me.Applydate.GnrlDate.Value Is Nothing Then
            aList.Add(Me.Applydate)
        End If

        If aList.Count > 0 Then
            For nI = 0 To aList.Count - 1
                FormErrorProvider.SetError(aList(nI), "Data Requird")
            Next
            MsgBoxValidateFaild()
            Ans = False
        End If

        Return Ans

    End Function

    Private Function IsSaveClause(ByVal FleName As String) As Boolean

        Dim Cmd As New SqlCommand
        Dim Cnn As New SqlConnection(My.Settings.DSN)
        Dim iresult As Int16
        Dim TB As New DataTable
        Dim DA As New SqlClient.SqlDataAdapter

        Dim lResult As Boolean
        Dim Dr As DataRow

        Dim Obj() As Byte = GetFileInByts(FleName)

        TB = New DataTable("Settings")

        Cnn.Open()
        Cmd = New SqlCommand()
        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.Connection = Cnn
        Cmd.CommandType = CommandType.Text
        Cmd.CommandText = "Select * From  TB_DetentionClause Where  ID = '" & Me.GridMaster.ActiveRow.Cells("ID").Value.ToString & "'"
        DA.SelectCommand = Cmd
        TB = New DataTable
        DA.Fill(TB)

        If TB.Rows.Count = 0 Then
            Cmd.CommandText = "INSERT INTO TB_DetentionClause(ID, DetentionBaseID , FooterClause ) values(@ID , @DetentionBaseID, @FooterClause)"
            Cmd.Parameters.Add("@ID", SqlDbType.VarChar, 36)
            Cmd.Parameters.Add("@DetentionBaseID", SqlDbType.VarChar, 36)
            Cmd.Parameters.Add("@FooterClause", SqlDbType.Image, Obj.Length)
            Cmd.Parameters("@ID").Value = System.Guid.NewGuid.ToString
            Cmd.Parameters("@DetentionBaseID").Value = Me.GridMaster.ActiveRow.Cells("ID").Value.ToString
            Cmd.Parameters("@FooterClause").Value = Obj
        Else
            Cmd.CommandText = "Update TB_DetentionClause set FooterClause = @FooterClause Where ID = @ID"
            Cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier, 36)
            Cmd.Parameters.Add("@DetentionBaseID", SqlDbType.VarChar, 36)
            Cmd.Parameters.Add("@FooterClause", SqlDbType.Image, Obj.Length)
            Cmd.Parameters("@ID").Value = TB.Rows(0).Item("ID")
            Cmd.Parameters("@FooterClause").Value = Obj
        End If

        Try
            iresult = Cmd.ExecuteNonQuery()
            lResult = True
        Catch ex As Exception
            lResult = False
            MsgBox(ex.ToString)
        Finally
            Cnn.Close()
        End Try

        Return lResult
    End Function

End Class