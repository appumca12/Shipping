Imports OrmLib
Imports ShippingBiz
Imports Infragistics.Win.UltraWinGrid
Public Class FrmExchange
    Implements IFGeneral
    Private ItemLevel As String = "411"
    Private MasterID As Guid
    Private FrmStatus As FormStatus = FormStatus.NoAction
    Private Dm As DataManager
    Private TB As New DataTable
    Private Exchange As TB_Exchange
    Private ExchangeDetails As TB_ExchangeDetailsCollection
    Private ID As Guid

    Private Sub FrmExchange_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim col As UltraGridColumn

        FrmStatus = FormStatus.NoAction
        General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)
        LockStatus(False)
        Dm = New DataManager(My.Settings.DSN)

        With Me.DropDownCurrency
            .DataSource = GetCodeList("CU")
            .DisplayMember = "STDCode"
            .ValueMember = "StdCode"
            For Each Col In .DisplayLayout.Bands(0).Columns
                Col.Hidden = True
            Next
            .DisplayLayout.Bands(0).Columns("StdCode").Hidden = False
        End With

        With Me.GridData
            .DataSource = Dm.DataSet.Tables("TB_ExchangeDetails")
        End With

        With Me.GridData.DisplayLayout.Bands(0)
            .Columns("ID").Hidden = True
            .Columns("MasterID").Hidden = True
            .Columns("CurCode").Style _
                               = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate
            .Columns("CurCode").ValueList = Me.DropDownCurrency
        End With
        TB = Dm.DataSet.Tables("TB_ExchangeDetails").Copy
        Me.GeneralForms.InitControl("Daily Echange Rate", ItemLevel)
        Me.GridData.DataSource = TB

    End Sub

    Public Sub LockStatus(ByVal Status As Boolean) Implements IFGeneral.LockStatus

    End Sub

    Public Sub Populate() Implements IFGeneral.Populate

    End Sub

    Public Sub SendDataToClass() Implements IFGeneral.SendDataToClass

    End Sub

    'Private Sub FrmExchange_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
    '    Dim Ctl As Control
    '    For Each Ctl In GroupBox.Controls
    '        If TypeOf Ctl Is Windows.Forms.Label Then
    '            DrawTransParentLabel(Ctl, e)
    '        End If
    '    Next
    'End Sub

    'For ILS Shortcuts: Changed from Private Sub GeneralForms_CustomFindClick() Handles GeneralForms.CustomFindClick to GeneralForms_CustomFindClick(ByVal sender As Object, ByVal formId As Integer)

    Public Sub GeneralForms_CustomFindClick(ByVal sender As Object, ByVal formId As Integer)
        If (Me.GeneralForms.getItemLevel(Me.GeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts  
            'formlocalId = formId
            'If (sender.ToString().Contains("Text")) Then
            '    blTxtBox = DirectCast(sender, System.Windows.Forms.TextBox)
            '    Me.BLNO.TextValue = blTxtBox.Text
            'End If

            Dm = New DataManager(My.Settings.DSN)
            Dm.QueryCriteria.Clear()
            Dm.QueryCriteria.And(JoinPath.TB_Exchange.Columns.ExchangeDate, Me.ExchangeDate.GnrlDate.Value, MatchType.Exact)
            Exchange = Dm.GetTB_Exchange()
            Dm.QueryCriteria.Clear()

            If Not Exchange Is Nothing Then
                FrmStatus = FormStatus.HasData
                ID = Exchange.ID
                Dm.QueryCriteria.Clear()
                Dm.QueryCriteria.And(JoinPath.TB_ExchangeDetails.Columns.MasterID, Exchange.ID, MatchType.Exact)
                ExchangeDetails = Dm.GetTB_ExchangeDetailsCollection
                If Dm.DataSet.Tables("TB_ExchangeDetails").Rows.Count > 0 Then
                    General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)
                Else
                    General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)
                End If
            Else
                FrmStatus = FormStatus.NoAction
                General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)
                MsgBox("No Exchange Data !")
                ID = Guid.NewGuid
            End If

            TB = Dm.DataSet.Tables("TB_ExchangeDetails").Copy
            With Me.GridData
                .DataSource = TB
                With .DisplayLayout.Bands(0)
                    .Columns("ID").Hidden = True
                    .Columns("MasterID").Hidden = True
                End With
                .DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
            End With
        End If

    End Sub

    'For ILS Shortcuts: Changed from Private Sub GeneralForms_CustomNewClick() Handles GeneralForms.CustomNewClick
    Public Sub GeneralForms_CustomNewClick(ByVal sender As Object, ByVal formId As Integer)

        If (Me.GeneralForms.getItemLevel(Me.GeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts

            Dm = New DataManager(My.Settings.DSN)
            FrmStatus = FormStatus.NewRecord
            ID = Guid.NewGuid
            General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)
        End If

    End Sub

    'For ILS Shortcuts Changed from Private Sub GeneralForms_CustomEditClick() Handles GeneralForms.CustomEditClick
    Public Sub GeneralForms_CustomEditClick(ByVal sender As Object, ByVal formId As Integer)

        If (Me.GeneralForms.getItemLevel(Me.GeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts
            FrmStatus = FormStatus.EditRecord
            General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)
        End If

    End Sub

    'For ILS Shortcuts: Changed from Private Sub GeneralForms_CustomSaveClick() Handles GeneralForms.CustomSaveClick
    Public Sub GeneralForms_CustomSaveClick(ByVal sender As Object, ByVal formId As Integer)

        If (Me.GeneralForms.getItemLevel(Me.GeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts

            Dim LogDataSet As New DataSet
            Dim Dr As DataRow
            Dim ChgTb As DataTable
            Dim Dv As DataView
            Dim DC As DataColumn

            If ValidateData() = False Then
                Exit Sub
            End If

            If MsgBoxUpdate() <> Windows.Forms.DialogResult.Yes Then
                Exit Sub
            End If

            If FrmStatus = FormStatus.NewRecord Then
                Dr = Dm.DataSet.Tables("TB_Exchange").NewRow
                Dr("ExchangeDate") = Me.ExchangeDate.GnrlDate.Value
                Dr("ID") = ID
                Dm.DataSet.Tables("TB_Exchange").Rows.Add(Dr)
            Else
                ID = Exchange.ID
            End If

            Me.GridData.UpdateData()
            ChgTb = TB.GetChanges

            If Not ChgTb Is Nothing Then
                For Each Dr In ChgTb.Rows
                    Select Case Dr.RowState
                        Case DataRowState.Added
                            Dr("MasterID") = ID
                            Dm.DataSet.Tables("TB_ExchangeDetails").ImportRow(Dr)
                        Case DataRowState.Deleted
                            Dv = New DataView(Dm.DataSet.Tables("TB_ExchangeDetails"), "ID = '" & Dr(0, DataRowVersion.Original).ToString & "'", "", DataViewRowState.CurrentRows)
                            If Dv.Count > 0 Then
                                Dv.Item(0).Delete()
                            End If
                        Case DataRowState.Modified
                            Dv = New DataView(Dm.DataSet.Tables("TB_ExchangeDetails"), "ID = '" & Dr.Item("ID").ToString & "'", "", DataViewRowState.CurrentRows)
                            If Dv.Count > 0 Then
                                For Each DC In TB.Columns
                                    Dv.Item(0).Item(DC.ColumnName) = Dr.Item(DC.ColumnName)
                                Next
                            End If
                    End Select
                Next
            End If

            Try
                LogDataSet = Dm.DataSet.Copy
                Dm.CommitAll()
                GenerateLog(LogDataSet)
                MsgBoxSaveSuccessful()
                FrmStatus = FormStatus.NoAction
                General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)
            Catch ex As Exception
                General.MsgBoxSaveFailed()
                MessageBox.Show(ex.ToString)
            End Try
        End If

    End Sub

    'For ILS Shortcuts Changed from Private Sub GeneralForms_CustomDeleteClick() Handles GeneralForms.CustomDeleteClick
    Public Sub GeneralForms_CustomDeleteClick(ByVal sender As Object, ByVal formId As Integer)

        If (Me.GeneralForms.getItemLevel(Me.GeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts

            Dim LogDataset As DataSet

            If MsgBoxDelete() = Windows.Forms.DialogResult.Yes Then
                Try
                    Exchange.Delete()
                    LogDataset = Dm.DataSet.Copy
                    Dm.CommitAll()
                    GenerateLog(LogDataset)
                    MsgBoxDeleteSuccessful()
                    FrmStatus = FormStatus.NoAction
                    General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)
                Catch ex As Exception
                    MsgBoxDeleteFailed()
                    MsgBoxGeneral(ex.ToString, "Error")
                End Try
            End If
        End If

    End Sub

    Private Function ValidateData() As Boolean
        Return True
    End Function

    Private Sub GridData_BeforeRowUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CancelableRowEventArgs) Handles GridData.BeforeRowUpdate
        If IsDBNull(Me.GridData.ActiveRow.Cells("ID").Value) Then
            Me.GridData.ActiveRow.Cells("ID").Value = Guid.NewGuid
            Me.GridData.ActiveRow.Cells("MasterID").Value = ID
        End If
    End Sub

End Class