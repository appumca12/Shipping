Imports ShippingBiz
Imports OrmLib
Public Class FrmReferences

    Private ItemLevel As String = "403"
    Private FrmStatus As FormStatus
    Private dm As DataManager
    Private MainData As TB_CodeMasterCollection
    Dim Codes As TB_CODECollection
    Private Refrences As TB_CODECollection
    Private ID As Guid
    Private formlocalId As Integer 'For ILS Shortcuts  
    Private formId As String 'For ILS Shortcuts  
    Private Sub FrmReferences_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.GeneralForms.InitControl("Refrences", ItemLevel)
        Me.Top = 0
        Me.Left = 0
        '     Me.UltraLabel1.BackColor = My.Settings.MainColor
        Me.StdCode.SetLength(10)

        FrmStatus = FormStatus.NoAction
        General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)

        FillCombo()

        formId = Me.GeneralForms.getItemLevel(Me.GeneralForms.UserTabSelected)  'For ILS Shortcuts  
        formlocalId = Convert.ToInt32(formId) 'For ILS Shortcuts  


        Me.CmbMain.Value = "CG"
        'For ILS Shortcuts changed from GeneralForms_CustomFindClick() 
        GeneralForms_CustomFindClick(sender, formlocalId)

        Me.GroupBox.Appearance.BackColor = My.Settings.MainColor
        'ChangeControlColor(Me.GroupBox, Me.UltraLabel1.GetType.ToString, My.Settings.MainColor, My.Settings.LableForeColor)

    End Sub

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub FillCombo()

        If dm Is Nothing Then
            dm = New DataManager(My.Settings.DSN)
        End If

        dm.QueryCriteria.Clear()
        dm.GetTB_CodeMasterCollection()

        With Me.CmbMain
            .DataSource = dm.DataSet.Tables("TB_CodeMaster").Copy
            .Refresh()
            With .DisplayLayout.Bands(0)
                .Columns("ID").Hidden = True
                .Columns("GroupCode").Hidden = True
                .Columns("IsSystemCode").Hidden = True
            End With
            .DropDownWidth = .Width
        End With

    End Sub

    'For ILS Shortcuts: Changed from Private Sub GeneralForms_CustomFindClick() Handles GeneralForms.CustomFindClick to GeneralForms_CustomFindClick(ByVal sender As Object, ByVal formId As Integer)
    Public Sub GeneralForms_CustomFindClick(ByVal sender As Object, ByVal formId As Integer)

        If (Me.GeneralForms.getItemLevel(Me.GeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts 

            dm = New DataManager(My.Settings.DSN)

            dm.QueryCriteria.Clear()
            dm.QueryCriteria.And(JoinPath.TB_CODE.Columns.GroupCode, Me.CmbMain.Value, MatchType.Exact)
            Codes = dm.GetTB_CODECollection

            With Me.GridCodes
                .DataSource = dm.DataSet.Tables("TB_Code")
                With .DisplayLayout.Bands(0)
                    .Columns("ID").Hidden = True
                    .Columns("GroupCode").Hidden = True
                    .Columns("NextCode").Hidden = True
                    .Columns("IsEditeble").Hidden = True
                End With
                .DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
            End With


            If dm.DataSet.Tables("TB_Code").Rows.Count > 0 Then
                FrmStatus = FormStatus.HasData
                General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)
            Else
                FrmStatus = FormStatus.NoAction
                General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)
            End If
        End If

    End Sub

    'For ILS Shortcuts: Changed from Private Sub GeneralForms_CustomNewClick() Handles GeneralForms.CustomNewClick
    Public Sub GeneralForms_CustomNewClick(ByVal sender As Object, ByVal formId As Integer)

        If (UserGeneralForms.getItemLevel(UserGeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts

            Dim Dummy As String = Me.CmbMain.Text

            ClearControl(Me)
            Me.CmbMain.Text = Dummy

            ID = System.Guid.NewGuid
            FrmStatus = FormStatus.NewRecord
            General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)
        End If

    End Sub

    'For ILS Shortcuts Changed from Private Sub GeneralForms_CustomEditClick() Handles GeneralForms.CustomEditClick
    Public Sub GeneralForms_CustomEditClick(ByVal sender As Object, ByVal formId As Integer)

        If (Me.GeneralForms.getItemLevel(Me.GeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts

            With Me.GridCodes.DisplayLayout.ActiveRow

                If NullToValue(.Cells("IsEditeble").Value, True) = True Then
                    ID = .Cells("ID").Value
                    Me.StdCode.TextValue = .Cells("StdCode").Value
                    Me.Meaning.TextValue = .Cells("Meaning").Value
                    Me.MeaningF.TextValue = IIf(IsDBNull(.Cells("MeaningF").Value), "", .Cells("MeaningF").Value)
                    FrmStatus = FormStatus.EditRecord
                    General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)
                Else
                    General.MsgBoxGeneral("This Code Is Not Editeble !")
                End If
            End With
        End If

    End Sub

    'For ILS Shortcuts Changed from Private Sub GeneralForms_CustomSaveClick() Handles GeneralForms.CustomSaveClick
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
                DV = New DataView(dm.DataSet.Tables("TB_Code"), "ID = '" & ID.ToString & "'", "", DataViewRowState.CurrentRows)
                If DV.Count = 0 Then
                    Dr = dm.DataSet.Tables("TB_Code").NewRow
                    Dr("ID") = ID
                    Dr("StdCode") = Me.StdCode.TextValue
                    Dr("Meaning") = Me.Meaning.TextValue
                    Dr("MeaningF") = Me.MeaningF.TextValue
                    Dr("GroupCode") = Me.CmbMain.Value
                    Dr("IsEditeble") = True
                    dm.DataSet.Tables("TB_Code").Rows.Add(Dr)
                Else
                    DV.Item(0).Item("StdCode") = Me.StdCode.TextValue
                    DV.Item(0).Item("Meaning") = Me.Meaning.TextValue
                    DV.Item(0).Item("MeaningF") = Me.MeaningF.TextValue
                    DV.Item(0).Item("IsEditeble") = True
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

            DV = New DataView(dm.DataSet.Tables("TB_Code"), "ID = '" & ID.ToString & "'", "", DataViewRowState.CurrentRows)

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

    Private Sub GeneralForms_CustomHomeClick() Handles GeneralForms.CustomHomeClick

        Dim LogDataSet As New DataSet
        Dim DL As DialogResult

        If dm.DataSet.GetChanges Is Nothing Then
            Me.Close()
        Else
            DL = General.MsgBoxQutiWithSave()
            Select Case DL
                Case Windows.Forms.DialogResult.Yes
                    LogDataSet = dm.DataSet.Copy
                    dm.CommitAll()
                    GenerateLog(LogDataSet)
                    Me.Close()
                Case Windows.Forms.DialogResult.No
                    Me.Close()
            End Select
        End If

    End Sub

    Private Function ValidateData() As Boolean

        Dim Ans As Boolean = True

        If Me.StdCode.TextValue = "" Or Me.Meaning.TextValue = "" Then
            MsgBoxValidateFaild()
            Ans = False
        End If

        Return Ans



    End Function

    Private Sub UltraGroupBox2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles UltraGroupBox2.Paint
        DrawTransParentLabel(Me.Label1, e)
    End Sub

    Private Sub GeneralForms_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub GroupBox_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles GroupBox.Paint
        DrawTransParentLabel(Me.Label2, e)
        DrawTransParentLabel(Me.Label3, e)
        DrawTransParentLabel(Me.Label4, e)
    End Sub
End Class