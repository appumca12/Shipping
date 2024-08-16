Imports OrmLib
Imports ShippingBiz
Imports Infragistics.Win.UltraWinGrid

Public Class FrmInquery

    Implements IFGeneral
    Private ItemLevel As String = "007"
    Private dm As DataManager
    Private Inquery As TB_Inquery
    Private InqueryDetail As TB_InqueryDetailsCollection
    Private FrmStatus As FormStatus = FormStatus.NoAction
    Private Ds As DataSet
    Private InqueryID As Guid


    Private Sub FrmInquery_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim TB As DataTable
        Dim DPCnSize As UltraDropDown
        Dim DPCnType As UltraDropDown
        Me.GeneralForms.InitControl("Inquery", ItemLevel)
        Me.InqueryDate.InitControl(False, False)
        Me.InqueryValidity.InitControl(False, False)
        Me.PrincipalReference.SetLength(25)
        Me.Client.InitControl()
        FrmStatus = FormStatus.NoAction
        General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)
        Me.LableClient.BackColor = My.Settings.MainColor


        TB = New DataTable("TB_Inquery")
        With TB
            .Columns.Add(New DataColumn("ID", System.Type.GetType("System.Guid")))
            .Columns.Add(New DataColumn("ClientID", System.Type.GetType("System.Guid")))
            .Columns.Add(New DataColumn("InqueryDate", System.Type.GetType("System.DateTime")))
            .Columns.Add(New DataColumn("InqueryValidity", System.Type.GetType("System.DateTime")))
            .Columns.Add(New DataColumn("PrincipalReference"))
            .Columns.Add(New DataColumn("POL"))
            .Columns.Add(New DataColumn("POD"))
        End With

        Ds = New DataSet
        Ds.Tables.Add(TB)

        TB = New DataTable("TB_InqueryDetails")
        With TB
            .Columns.Add(New DataColumn("ID", System.Type.GetType("System.Guid")))
            .Columns.Add(New DataColumn("MasterID", System.Type.GetType("System.Guid")))
            .Columns.Add(New DataColumn("CnSize"))
            .Columns.Add(New DataColumn("CnType"))
            .Columns.Add(New DataColumn("IsDG", System.Type.GetType("System.Boolean")))
            .Columns.Add(New DataColumn("Amount", System.Type.GetType("System.Double")))
        End With
        Ds.Tables.Add(TB)
        Me.GridDetail.DataSource = Ds.Tables(1)

        DPCnSize = New UltraDropDown
        With DPCnSize
            .DataSource = GetCodeList("CS")
            .DisplayMember = "STDCode"
            .ValueMember = "STDCode"
            .DisplayLayout.Bands(0).Columns("STDCode").Hidden = True
            With GridDetail.DisplayLayout.Bands(0)
                .Columns("CnSize").Style _
                                      = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate
                .Columns("CnSize").ValueList = DPCnSize
            End With
            For Each Col In .DisplayLayout.Bands(0).Columns
                Col.Hidden = True
            Next
            .DisplayLayout.Bands(0).Columns("StdCode").Hidden = False
        End With

        DPCnType = New UltraDropDown
        With DPCnType
            .DataSource = GetCodeList("CT")
            .DisplayMember = "STDCode"
            .ValueMember = "STDCode"
            .DisplayLayout.Bands(0).Columns("STDCode").Hidden = True
            With GridDetail.DisplayLayout.Bands(0)
                .Columns("CnType").Style _
                                      = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate
                .Columns("CnType").ValueList = DPCnType
            End With
            For Each Col In .DisplayLayout.Bands(0).Columns
                Col.Hidden = True
            Next
            .DisplayLayout.Bands(0).Columns("StdCode").Hidden = False
        End With

        GridDetail.DisplayLayout.Bands(0).Columns("Amount").MaskInput = "{LOC}nnn,nnn.nn"
        GridDetail.DisplayLayout.Bands(0).Columns("Amount").MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals
        GridNumSeperator(Me.GridDetail)

    End Sub

    Private Sub Populate() Implements IFGeneral.Populate

    End Sub

    Private Sub SendDataToClass() Implements IFGeneral.SendDataToClass


        Dim nI As Byte
        Dim Changes As DataSet = Ds.GetChanges
        Dim Tb As DataTable
        Dim Dr As DataRow
        Dim Dv As DataView
        Dim DC As DataColumn


        dm = New DataManager(My.Settings.DSN)

        dm.QueryCriteria.Clear()
        dm.QueryCriteria.And(JoinPath.TB_Inquery.Columns.ID, InqueryID, MatchType.Exact)
        dm.GetTB_Inquery()

        dm.QueryCriteria.Clear()
        dm.QueryCriteria.And(JoinPath.TB_InqueryDetails.Columns.MasterID, InqueryID, MatchType.Exact)
        dm.GetTB_InqueryDetailsCollection()


        Tb = dm.DataSet.Tables("TB_Inquery")
        If Tb.Rows.Count = 0 Then
            Dr = Tb.NewRow
            Dr("ID") = InqueryID
            Dr("InqueryDate") = Me.InqueryDate.DateValue
            Dr("InqueryValidity") = Me.InqueryValidity.DateValue
            Dr("POL") = Me.POL.PortCode
            Dr("POD") = Me.POD.PortCode
            Dr("PrincipalReference") = Me.PrincipalReference.TextValue
            Dr("ClinetID") = Me.Client.ClientID
            Tb.Rows.Add(Dr)
        Else
            Dr = Tb.Rows(0)
            Dr("InqueryDate") = Me.InqueryDate.DateValue
            Dr("InqueryValidity") = Me.InqueryValidity.DateValue
            Dr("POL") = Me.POL.PortCode
            Dr("POD") = Me.POD.PortCode
            Dr("PrincipalReference") = Me.PrincipalReference.TextValue
        End If

        If Not Changes Is Nothing Then
            Tb = Changes.Tables("TB_InqueryDetails")
            For Each Dr In Tb.Rows
                Select Case Dr.RowState
                    Case DataRowState.Added
                        Dr("ID") = Guid.NewGuid
                        Dr("MasterID") = InqueryID
                        dm.DataSet.Tables(Tb.TableName).ImportRow(Dr)
                    Case DataRowState.Deleted
                        Dv = New DataView(dm.DataSet.Tables(Tb.TableName), "ID = '" & Dr(0, DataRowVersion.Original).ToString & "'", "", DataViewRowState.CurrentRows)
                        If Dv.Count > 0 Then
                            Dv.Item(0).Delete()
                        End If
                    Case DataRowState.Modified
                        Dv = New DataView(dm.DataSet.Tables(Tb.TableName), "ID = '" & Dr.Item("ID").ToString & "'", "", DataViewRowState.CurrentRows)
                        If Dv.Count > 0 Then
                            For Each DC In Tb.Columns
                                Dv.Item(0).Item(DC.ColumnName) = Dr.Item(DC.ColumnName)
                            Next
                        End If
                End Select
            Next
        End If

    End Sub

    Private Sub LockStatus(ByVal Status As Boolean) Implements IFGeneral.LockStatus
        General.LockControls(Me, Status)
        Me.Client.Enabled = True
    End Sub

    'For ILS Shortcuts: Changed from Private Sub GeneralForms_CustomFindClick() Handles GeneralForms.CustomFindClick to GeneralForms_CustomFindClick(ByVal sender As Object, ByVal formId As Integer)
    Public Sub GeneralForms_CustomFindClick(ByVal sender As Object, ByVal formId As Integer)

        If (Me.GeneralForms.getItemLevel(Me.GeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts  

            dm = New DataManager(My.Settings.DSN)
            dm.QueryCriteria.And(JoinPath.TB_Inquery.Columns.ClinetID, Me.Client.ClientID, MatchType.Exact)
            dm.GetTB_InqueryCollection()

            Me.GridList.DataSource = dm.DataSet.Tables("TB_Inquery")
            GridNumSeperator(Me.GridList)

            If dm.DataSet.Tables("TB_Inquery").Rows.Count = 0 Then
                FrmStatus = FormStatus.NoAction
            Else
                FrmStatus = FormStatus.HasData
            End If

            General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)

            '     LockStatus(False)
        End If

    End Sub

    'For ILS Shortcuts: Changed from Private Sub GeneralForms_CustomNewClick() Handles GeneralForms.CustomNewClick
    Public Sub GeneralForms_CustomNewClick(ByVal sender As Object, ByVal formId As Integer)

        If (Me.GeneralForms.getItemLevel(Me.GeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts

            InqueryID = Guid.NewGuid

            dm = New DataManager(My.Settings.DSN)
            Ds.Tables(0).Clear()
            Ds.Tables(1).Clear()
            Ds.AcceptChanges()

            ClearControl(Me)
            General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)
            FrmStatus = FormStatus.NewRecord
        End If

    End Sub

    'For ILS Shortcuts Changed from Private Sub GeneralForms_CustomEditClick() Handles GeneralForms.CustomEditClick
    Public Sub GeneralForms_CustomEditClick(ByVal sender As Object, ByVal formId As Integer)

        If (Me.GeneralForms.getItemLevel(Me.GeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts

            Dim Drs() As DataRow

            InqueryID = Me.GridList.ActiveRow.Cells("ID").Value
            Drs = dm.DataSet.Tables("TB_Inquery").Select("ID = '" & Me.GridList.ActiveRow.Cells("ID").Text & "'")

            Ds.Clear()
            Ds.Tables(0).ImportRow(Drs(0))

            Me.InqueryDate.DateValue = Drs(0).Item("InqueryDate")
            Me.InqueryValidity.DateValue = Drs(0).Item("InqueryValidity")
            Me.POL.PortCode = Drs(0).Item("POL")
            Me.POD.PortCode = Drs(0).Item("POD")
            Me.PrincipalReference.TextValue = Drs(0).Item("PrincipalReference")
            Me.UltraTabControl1.Tabs(1).Selected = True

            FrmStatus = FormStatus.EditRecord
            General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)

            dm.QueryCriteria.Clear()
            dm.QueryCriteria.And(JoinPath.TB_InqueryDetails.Columns.MasterID, InqueryID, MatchType.Exact)
            dm.GetTB_InqueryDetailsCollection()

            For Each dr As DataRow In dm.DataSet.Tables("TB_InqueryDetails").Rows
                Ds.Tables(1).ImportRow(dr)
            Next

            Me.GridDetail.DataSource = Ds.Tables(1)

            GridNumSeperator(Me.GridDetail)
        End If

    End Sub

    'For ILS Shortcuts: Changed from Private Sub GeneralForms_CustomSaveClick() Handles GeneralForms.CustomSaveClick
    Public Sub GeneralForms_CustomSaveClick(ByVal sender As Object, ByVal formId As Integer)
        If (Me.GeneralForms.getItemLevel(Me.GeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts

            Dim LogDataSet As New DataSet
            If ValidateForm() = False Then
                Exit Sub
            End If
            Me.GridDetail.UpdateData()
            If MsgBoxUpdate() = Windows.Forms.DialogResult.Yes Then
                Try
                    SendDataToClass()
                    LogDataSet = dm.DataSet.Copy
                    dm.CommitAll()
                    GenerateLog(LogDataSet)
                    MsgBoxSaveSuccessful()
                    Ds.AcceptChanges()
                    GeneralForms_CustomFindClick(sender, formId)
                Catch ex As Exception
                    MsgBoxDeleteFailed()
                    MsgBox(ex.ToString)
                End Try
            End If
        End If

    End Sub

    Private Function ValidateForm() As Boolean

        Dim Ans As Boolean = True
        Dim nI As Byte
        Dim aList As New ArrayList

        FormErrorProvider.Clear()

        If Me.PrincipalReference.TextValue = "" Then
            aList.Add(Me.PrincipalReference)
        End If

        If Me.InqueryDate.GnrlDate.Value Is Nothing Then
            aList.Add(Me.InqueryDate)
        End If

        If Me.InqueryValidity.GnrlDate.Value Is Nothing Then
            aList.Add(Me.InqueryValidity)
        End If

        If Me.POL.PortCode = "" Then
            aList.Add(Me.POL)
        End If

        If Me.POD.PortCode = "" Then
            aList.Add(Me.POD)
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


End Class