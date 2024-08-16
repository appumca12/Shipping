Imports ShippingBiz
Imports OrmLib
Public Class FrmCluses

    Private ItemLevel As String = "410"
    Private FrmStatus As FormStatus
    Private dm As DataManager
    Private MainData As TB_CodeMasterCollection
    Private Clause As TB_Cluses
    Private Clauses As TB_ClusesCollection
    Private ID As Guid
    Private formlocalId As Integer 'For ILS Shortcuts  
    Private formId As String 'For ILS Shortcuts  

    Private Sub FrmCluses_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.GeneralForms.InitControl("Cluses", ItemLevel)
        Me.Top = 0
        Me.Left = 0
        Me.Description.SetLength(50)

        FrmStatus = FormStatus.NoAction
        General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)

        Me.CluseGroup.InitControl("CL", UserComboCode.ShowCoumn.Meaning)

        formId = UserGeneralForms.getItemLevel(UserGeneralForms.UserTabSelected)  'For ILS Shortcuts  
        formlocalId = Convert.ToInt32(formId) 'For ILS Shortcuts  

        'For ILS Shortcuts changed from GeneralForms_CustomFindClick() 
        GeneralForms_CustomFindClick(sender, formlocalId)
        Me.GroupBox.Appearance.BackColor = My.Settings.MainColor


        dm = New DataManager(My.Settings.DSN)

        dm.QueryCriteria.Clear()
        Clauses = dm.GetTB_ClusesCollection

        With Me.GridCluses
            .DataSource = dm.DataSet.Tables("TB_Cluses")
            With .DisplayLayout.Bands(0)
                .Columns("ID").Hidden = True
                .Columns("CluseGroup").Hidden = False
                .Columns("Description").Hidden = False
                .Columns("Detail").Hidden = False
            End With
            .DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        End With


        If dm.DataSet.Tables("TB_Cluses").Rows.Count > 0 Then
            FrmStatus = FormStatus.HasData
            General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)
        Else
            FrmStatus = FormStatus.NoAction
            General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)
        End If


    End Sub

    'For ILS Shortcuts: Changed from Private Sub GeneralForms_CustomFindClick() Handles GeneralForms.CustomFindClick to GeneralForms_CustomFindClick(ByVal sender As Object, ByVal formId As Integer)
    Public Sub GeneralForms_CustomFindClick(ByVal sender As Object, ByVal formId As Integer)

        If (UserGeneralForms.getItemLevel(UserGeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts 
            If Me.GridCluses.Rows.Count > 0 Then
                FrmStatus = FormStatus.HasData
                General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)
            End If
        End If

    End Sub

    'For ILS Shortcuts: Changed from Private Sub GeneralForms_CustomNewClick() Handles GeneralForms.CustomNewClick
    Public Sub GeneralForms_CustomNewClick(ByVal sender As Object, ByVal formId As Integer)

        If (UserGeneralForms.getItemLevel(UserGeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts


            ClearControl(Me)
            Me.Description.Focus()
            ID = System.Guid.NewGuid
            FrmStatus = FormStatus.NewRecord
            General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)
        End If

    End Sub

    'For ILS Shortcuts Changed from Private Sub GeneralForms_CustomEditClick() Handles GeneralForms.CustomEditClick
    Public Sub GeneralForms_CustomEditClick(ByVal sender As Object, ByVal formId As Integer)

        If (UserGeneralForms.getItemLevel(UserGeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts
            With Me.GridCluses.DisplayLayout.ActiveRow
                ID = .Cells("ID").Value
                Me.CluseGroup.Code = .Cells("CluseGroup").Value
                Me.Description.TextValue = .Cells("Description").Value
                Me.Detail.TextValue = .Cells("Detail").Value
                FrmStatus = FormStatus.EditRecord
                General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)

            End With
        End If

    End Sub

    'For ILS Shortcuts: Changed from Private Sub GeneralForms_CustomSaveClick() Handles GeneralForms.CustomSaveClick
    Public Sub GeneralForms_CustomSaveClick(ByVal sender As Object, ByVal formId As Integer)

        If (UserGeneralForms.getItemLevel(UserGeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts

            Dim Dr As DataRow
            Dim LogDataSet As New DataSet
            Dim DV As DataView

            If ValidateData() = False Then
                Exit Sub
            End If

            If MsgBoxUpdate() <> Windows.Forms.DialogResult.Yes Then
                Exit Sub
            End If

            Try

                DV = New DataView(dm.DataSet.Tables("TB_Cluses"), "ID = '" & ID.ToString & "'", "", DataViewRowState.CurrentRows)
                If DV.Count = 0 Then
                    Dr = dm.DataSet.Tables("TB_Cluses").NewRow
                    Dr("ID") = ID
                    Dr("CluseGroup") = Me.CluseGroup.Code
                    Dr("Description") = Me.Description.TextValue
                    Dr("Detail") = Me.Detail.TextValue
                    dm.DataSet.Tables("TB_Cluses").Rows.Add(Dr)
                Else
                    DV.Item(0).Item("CluseGroup") = Me.CluseGroup.Code
                    DV.Item(0).Item("Description") = Me.Description.TextValue
                    DV.Item(0).Item("Detail") = Me.Detail.TextValue
                End If
                LogDataSet = dm.DataSet.Copy
                dm.CommitAll()
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

        If (UserGeneralForms.getItemLevel(UserGeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts

            Dim LogDataSet As New DataSet
            Dim DV As DataView

            If MsgBoxDelete() <> Windows.Forms.DialogResult.Yes Then
                Exit Sub
            End If

            DV = New DataView(dm.DataSet.Tables("TB_Cluses"), "ID = '" & ID.ToString & "'", "", DataViewRowState.CurrentRows)

            If DV.Count > 0 Then
                If General.MsgBoxDelete = Windows.Forms.DialogResult.Yes Then
                    DV.Item(0).Delete()
                    Try
                        LogDataSet = dm.DataSet.Copy
                        dm.CommitAll()
                        GenerateLog(LogDataSet)
                        MsgBoxDeleteSuccessful()
                        FrmStatus = FormStatus.NoAction
                        General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)
                    Catch ex As Exception
                        MsgBoxDeleteFailed()
                        MsgBoxGeneral(ex.ToString, "Error")
                    End Try
                End If
            End If
        End If

    End Sub

    Private Function ValidateData() As Boolean

        Dim Ans As Boolean = True

        If Me.Description.TextValue = "" Or Me.CluseGroup.Code = "" Or Me.Detail.TextValue = "" Then
            MsgBoxValidateFaild()
            Ans = False
        End If

        Return Ans

    End Function

    Private Sub GroupBox_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles GroupBox.Paint
        DrawTransParentLabel(Me.Label2, e)
        DrawTransParentLabel(Me.Label3, e)
        DrawTransParentLabel(Me.Label1, e)
    End Sub

End Class