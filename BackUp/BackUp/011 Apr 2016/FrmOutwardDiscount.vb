Imports OrmLib
Imports ShippingBiz

Public Class FrmOutwardDiscount
    Implements IFGeneral
    Private FrmStatus As FormStatus = FormStatus.NoAction
    'Private ItemLevel As String = "305"
    Private ItemLevel As String = "309"
    Private dm As DataManager
    Private BLDoc As TB_OutwardBLS
    Private BLDscnt As TB_OutwardDiscount

    Private Sub LockStatus(ByVal Status As Boolean) Implements IFGeneral.LockStatus
        General.LockControls(Me, Status)

    End Sub

    Private Sub SendDataToClass() Implements IFGeneral.SendDataToClass

        If FrmStatus = FormStatus.NewRecord Then
            BLDscnt = dm.NewTB_OutwardDiscount(BLDoc)
            BLDscnt.ID = Guid.NewGuid
        End If

        BLDscnt.dFreeDays = Int32.Parse(Me.dFreeDays.GnrlNum.Value.ToString)
        BLDscnt.dPercent = Int32.Parse(Me.dPercent.GnrlNum.Value.ToString)
        BLDscnt.dAmount = Int64.Parse(Me.dAmount.GnrlNum.Value.ToString)
        BLDscnt.IsFDaysAsDiscount = Me.IsFDaysAsDiscount.Checked

    End Sub

    Private Sub Populate() Implements IFGeneral.Populate

        Me.dFreeDays.GnrlNum.Value = Int16.Parse(NullToValue(BLDscnt.dFreeDays, 0).ToString)
        Me.dPercent.GnrlNum.Value = Int16.Parse(NullToValue(BLDscnt.dPercent, 0).ToString)
        Me.dAmount.GnrlNum.Value = Int64.Parse(NullToValue(BLDscnt.dAmount, 0).ToString)
        If BLDscnt.IsFDaysAsDiscount.IsNull = True Then
            Me.IsFDaysAsDiscount.Checked = False
        Else
            Me.IsFDaysAsDiscount.Checked = BLDscnt.IsFDaysAsDiscount

        End If

    End Sub

    'For ILS Shortcuts: Changed from Private Sub GeneralForms_CustomFindClick() Handles GeneralForms.CustomFindClick to GeneralForms_CustomFindClick(ByVal sender As Object, ByVal formId As Integer)
    Public Sub GeneralForms_CustomFindClick(ByVal sender As Object, ByVal formId As Integer)

        If (Me.GeneralForms.getItemLevel(Me.GeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts  

            FrmStatus = FormStatus.NoAction


            If dm Is Nothing Then
                dm = New DataManager(My.Settings.DSN)
            End If

            If Me.BLNO.GeneralTxt.Text = "" Then
                MsgBoxGeneral("Please Fill BL No", "Error")
                Exit Sub
            End If

            dm.QueryCriteria.Clear()
            dm.QueryCriteria.And(JoinPath.TB_OutwardBLS.Columns.Line, CurrentShippingLine, MatchType.Exact)
            dm.QueryCriteria.And(JoinPath.TB_OutwardBLS.Columns.BlNo, Me.BLNO.GeneralTxt.Text, MatchType.Exact)
            BLDoc = dm.GetTB_OutwardBLS
            If BLDoc Is Nothing Then
                MsgBoxGeneral("Invalid B/L No", "Error")
                Exit Sub
            End If

            dm.QueryCriteria.Clear()
            dm.QueryCriteria.And(JoinPath.TB_OutwardDiscount.Columns.BLID, BLDoc.ID, MatchType.Exact)
            BLDscnt = dm.GetTB_OutwardDiscount
            If BLDscnt Is Nothing Then
                MsgBoxGeneral("No Discount Data", "Error")
                FrmStatus = FormStatus.NoAction
            Else
                Populate()
                FrmStatus = FormStatus.HasData

            End If
            General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)
            LockStatus(False)
        End If
    End Sub

    'For ILS Shortcuts: Changed from Private Sub GeneralForms_CustomNewClick() Handles GeneralForms.CustomNewClick
    Public Sub GeneralForms_CustomNewClick(ByVal sender As Object, ByVal formId As Integer)

        If (Me.GeneralForms.getItemLevel(Me.GeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts
            Me.BLNO.Focus()
            Dim Dumm As String = Me.BLNO.TextValue
            If dm Is Nothing Then
                dm = New DataManager(My.Settings.DSN)
            End If
            dm.QueryCriteria.Clear()
            ClearControl(Me)
            Me.BLNO.TextValue = Dumm
            LockStatus(True)
            FrmStatus = FormStatus.NewRecord
            General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FormStatus.NewRecord)
        End If

    End Sub

    'For ILS Shortcuts Changed from Private Sub GeneralForms_CustomEditClick() Handles GeneralForms.CustomEditClick
    Public Sub GeneralForms_CustomEditClick(ByVal sender As Object, ByVal formId As Integer)

        If (Me.GeneralForms.getItemLevel(Me.GeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts

            LockStatus(True)
            FrmStatus = FormStatus.EditRecord
            General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FormStatus.EditRecord)
        End If

    End Sub

    'For ILS Shortcuts: Changed from Private Sub GeneralForms_CustomSaveClick() Handles GeneralForms.CustomSaveClick
    Public Sub GeneralForms_CustomSaveClick(ByVal sender As Object, ByVal formId As Integer)

        If (Me.GeneralForms.getItemLevel(Me.GeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts

            Dim LogDataSet As New DataSet

            Me.dAmount.GnrlNum.Value = NullToValue(Me.dAmount.GnrlNum.Value, 0)
            Me.dPercent.GnrlNum.Value = NullToValue(Me.dPercent.GnrlNum.Value, 0)

            If Me.dFreeDays.GnrlNum.Value + Me.dPercent.GnrlNum.Value + Me.dAmount.GnrlNum.Value = 0 Then
                MsgBoxGeneral("Please Fill On Of Fields !", "Validate")
                Exit Sub
            End If

            If MsgBoxUpdate() = Windows.Forms.DialogResult.Yes Then
                Try
                    SendDataToClass()
                    LogDataSet = dm.DataSet.Copy
                    dm.CommitAll()
                    GenerateLog(LogDataSet)
                    MsgBoxSaveSuccessful()
                    FrmStatus = FormStatus.NoAction
                    LockStatus(False)
                    General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FormStatus.NoAction)
                Catch ex As Exception
                    MsgBoxSaveFailed()
                    MsgBox(dm.LastCommitText)
                    MsgBox(ex.ToString)
                End Try
            End If
        End If

    End Sub

    'For ILS Shortcuts Changed from Private Sub GeneralForms_CustomDeleteClick() Handles GeneralForms.CustomDeleteClick
    Public Sub GeneralForms_CustomDeleteClick(ByVal sender As Object, ByVal formId As Integer)

        If (Me.GeneralForms.getItemLevel(Me.GeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts

            Dim LogDataSet As New DataSet
            If MsgBoxDelete() <> Windows.Forms.DialogResult.Yes Then
                Exit Sub
            End If

            If General.MsgBoxDelete = Windows.Forms.DialogResult.Yes Then
                BLDscnt.Delete()
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

    End Sub

    Private Sub GeneralForms_CustomHomeClick() Handles GeneralForms.CustomHomeClick
        Me.Close()
    End Sub

    Private Sub FrmOutwardDiscount_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        FrmStatus = FormStatus.NoAction

        Me.dFreeDays.InitControl(3, 0)
        Me.dPercent.InitControl(2, 0)
        Me.dAmount.InitControl(10, 0)

        LockStatus(False)

        Me.GeneralForms.InitControl("Discount Data", ItemLevel)


        General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)

        Me.BLNO.Enabled = True
        Me.BLNO.GeneralTxt.Enabled = True

    End Sub

End Class