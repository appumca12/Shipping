Imports ShippingBiz
Imports OrmLib

Public Class FrmVessels
    Private ItemLevel As String = "401"
    Private FrmStaus As FormStatus
    Private Dm As ShippingBiz.DataManager
    Private Vesseldata As TB_Vessels

    Private Sub GeneralForms_CustomHomeClick() Handles GeneralForms.CustomHomeClick
        Me.Close()
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Public Sub New()

        InitializeComponent()

    End Sub

    Private Sub Populate()

        Me.VesselCode.GeneralText.Text = Vesseldata.VesselCode
        Me.IMONo.GeneralText.Text = Vesseldata.IMONo
        Me.VesselName.GeneralText.Text = Vesseldata.VesselName
        Me.DeadWeight.GnrlNum.Value = System.Double.Parse(Vesseldata.DeadWeight)
        Me.Capacity.GnrlNum.Value = System.Double.Parse(Vesseldata.Capacity)
        Me.GW.GnrlNum.Value = System.Double.Parse(Vesseldata.GW)
        Me.NET.GnrlNum.Value = System.Double.Parse(Vesseldata.NET)
        Me.CalLetter.GeneralText.Text = Vesseldata.CallLetter
        Me.BuiltDate.GnrlDate.Value = System.DateTime.Parse(Vesseldata.BuiltDate)
        Me.Nationality.Code = Vesseldata.Nationality
        Me.OfficeCalNo.GeneralText.Text = Vesseldata.OfficalNo
        Me.Speed.GnrlNum.Value = System.Double.Parse(Vesseldata.Speed)
        Me.VesselAccount.GeneralText.Text = NullToValue(Vesseldata.VesselAccount, "")
        Me.IMONo.GeneralText.Text = NullToValue(Vesseldata.IMONo, "")
        FrmStaus = FormStatus.HasData
        General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FormStatus.NoAction)

    End Sub

    Private Sub SendDataToClass()

        If FrmStaus = FormStatus.NewRecord Then
            Vesseldata = Dm.NewTB_Vessels(Me.VesselCode.TextValue, Me.VesselName.TextValue)
        End If

        With Vesseldata
            .VesselName = Me.VesselName.GeneralText.Text
            .BuiltDate = Me.BuiltDate.DateValue
            .CallLetter = Me.CalLetter.GeneralText.Text
            .Capacity = System.Int64.Parse(Me.Capacity.GnrlNum.Value)
            .DeadWeight = System.Double.Parse(Me.DeadWeight.GnrlNum.Value)
            .GW = System.Double.Parse(Me.GW.GnrlNum.Value)
            .Nationality = Me.Nationality.Code
            .NET = System.Double.Parse(Me.NET.GnrlNum.Value)
            .OfficalNo = Me.OfficeCalNo.GeneralText.Text
            .Speed = System.Double.Parse(Me.Speed.GnrlNum.Value)
            .VesselAccount = Me.VesselAccount.TextValue
            .IMONo = Me.IMONo.TextValue
        End With

    End Sub

    Private Sub LockStatus(ByVal Status As Boolean)

        Me.VesselName.Enabled = Status
        Me.DeadWeight.GnrlNum.Enabled = Status
        Me.Capacity.GnrlNum.Enabled = Status
        Me.GW.GnrlNum.Enabled = Status
        Me.NET.GnrlNum.Enabled = Status
        Me.CalLetter.Enabled = Status
        Me.Nationality.Enabled = Status
        Me.OfficeCalNo.Enabled = Status
        Me.BuiltDate.Enabled = Status
        Me.Speed.Enabled = Status
        Me.VesselAccount.Enabled = Status
        Me.IMONo.Enabled = Status

    End Sub

    Private Function VesselValidate() As Boolean

        Dim Ans As Boolean = False

    End Function

    Private Sub FrmVessels_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        Dm = New ShippingBiz.DataManager(My.Settings.DSN)
        Me.GeneralForms.InitControl("VESSEL DATA", ItemLevel)
        Me.VesselCode.SetLength(4)
        Me.VesselName.SetLength(30)
        Me.DeadWeight.InitControl(6, 2)
        Me.Capacity.InitControl(6, 0)
        Me.GW.InitControl(10, 2)
        Me.NET.InitControl(10, 2)
        Me.Speed.InitControl(3, 1)
        Me.OfficeCalNo.SetLength(10)
        Me.CalLetter.SetLength(10)
        Me.BuiltDate.InitControl(False, False)
        Me.Nationality.InitControl("CY", UserComboCode.ShowCoumn.Meaning)
        Me.VesselAccount.SetLength(25)
        Me.IMONo.SetLength(7)
        Me.Top = 0
        Me.Left = 0

        LockStatus(False)
        FrmStaus = FormStatus.NoAction
        General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FormStatus.NoAction)

        Me.BackColor = My.Settings.MainColor
        Me.GroupBox.Appearance.BackColor = My.Settings.MainColor

        For Each Ctl As Object In GroupBox.Controls
            Try
                If TypeOf Ctl Is Windows.Forms.TextBox Then
                    Ctl.backcolor = My.Settings.MainColor
                    Ctl.forecolor = My.Settings.LableForeColor
                End If
                If TypeOf Ctl Is Infragistics.Win.Misc.UltraLabel Then
                    Ctl.Appearance.backcolor = My.Settings.MainColor
                    Ctl.Appearance.ForeColor = My.Settings.LableForeColor
                End If
            Catch ex As Exception
            End Try
        Next
        Me.UltraGroupBox1.Appearance.BackColor = Color.Gainsboro

    End Sub

    Private Sub GeneralForms_CustomNavigateFirstClick() Handles GeneralForms.CustomNavigateFirstClick

        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_Vessels.Columns.VesselCode, "0000", MatchType.GreaterOrEqual)

        If Vesseldata Is Nothing Then
            ClearControl(Me)
            General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FormStatus.NoAction)
        Else
            LockStatus(False)
            Populate()
        End If

    End Sub

    Private Sub GeneralForms_CustomNavigateLastClick() Handles GeneralForms.CustomNavigateLastClick

        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_Vessels.Columns.VesselCode, "ZZZZ", MatchType.LesserOrEqual)
        Vesseldata = Dm.GetTB_Vessels

        If Vesseldata Is Nothing Then
            ClearControl(Me)
            General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FormStatus.NoAction)
        Else
            LockStatus(False)
            Populate()
        End If

    End Sub

    Private Sub GeneralForms_CustomNavigateNextClick() Handles GeneralForms.CustomNavigateNextClick
        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_Vessels.Columns.VesselCode, Me.VesselCode.GeneralText.Text, MatchType.Greater)
        Vesseldata = Dm.GetTB_Vessels
        Me.VesselCode.Focus()
        If Vesseldata Is Nothing Then
            ClearControl(Me)
            General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FormStatus.NoAction)
        Else
            LockStatus(False)
            Populate()
        End If

    End Sub

    Private Sub GeneralForms_CustomNavigatePrivClick() Handles GeneralForms.CustomNavigatePrivClick

        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_Vessels.Columns.VesselCode, Me.VesselCode.GeneralText.Text, MatchType.Lesser)
        Vesseldata = Dm.GetTB_Vessels

        If Vesseldata Is Nothing Then
            ClearControl(Me)
            General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FormStatus.NoAction)
        Else
            LockStatus(False)
            Populate()
        End If

    End Sub
 
    Private Sub UltraLabel12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraLabel12.Click

    End Sub

    'For ILS Shortcuts: Changed from Private Sub GeneralForms_CustomFindClick() Handles GeneralForms.CustomFindClick to GeneralForms_CustomFindClick(ByVal sender As Object, ByVal formId As Integer)
    Public Sub GeneralForms_CustomFindClick(ByVal sender As Object, ByVal formId As Integer)

        If (Me.GeneralForms.getItemLevel(Me.GeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts  
            LockStatus(False)

            If Me.VesselCode.GeneralText.Text = "" Then
                MsgBoxGeneral("Please Fill Vessel Code !", "Error")
                Exit Sub
            End If

            Dm.QueryCriteria.Clear()
            Dm.QueryCriteria.And(JoinPath.TB_Vessels.Columns.VesselCode, Me.VesselCode.GeneralText.Text, MatchType.Exact)
            Vesseldata = Dm.GetTB_Vessels

            If Vesseldata Is Nothing Then
                MsgBox("No Valid Vessel Code !")
                General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FormStatus.NoAction)
            Else
                LockStatus(False)
                Populate()
                General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FormStatus.HasData)
            End If
        End If

    End Sub

    'For ILS Shortcuts: Changed from Private Sub GeneralForms_CustomNewClick() Handles GeneralForms.CustomNewClick
    Public Sub GeneralForms_CustomNewClick(ByVal sender As Object, ByVal formId As Integer)

        If (Me.GeneralForms.getItemLevel(Me.GeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts

            ClearControl(Me)
            LockStatus(True)
            Me.VesselCode.GeneralText.Text = ""
            FrmStaus = FormStatus.NewRecord
            General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FormStatus.NewRecord)
        End If


    End Sub

    'For ILS Shortcuts Changed from Private Sub GeneralForms_CustomEditClick() Handles GeneralForms.CustomEditClick
    Public Sub GeneralForms_CustomEditClick(ByVal sender As Object, ByVal formId As Integer)

        If (Me.GeneralForms.getItemLevel(Me.GeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts

            LockStatus(True)
            FrmStaus = FormStatus.EditRecord
            General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FormStatus.EditRecord)
        End If

    End Sub

    'For ILS Shortcuts: Changed from Private Sub GeneralForms_CustomSaveClick() Handles GeneralForms.CustomSaveClick
    Public Sub GeneralForms_CustomSaveClick(ByVal sender As Object, ByVal formId As Integer)

        If (Me.GeneralForms.getItemLevel(Me.GeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts

            Dim LogDataSet As New DataSet

            If MsgBoxUpdate() = Windows.Forms.DialogResult.Yes Then
                Try
                    SendDataToClass()
                    LogDataSet = Dm.DataSet.Copy
                    Dm.CommitAll()
                    GenerateLog(LogDataSet)
                    MsgBoxSaveSuccessful()
                    FrmStaus = FormStatus.NoAction
                    LockStatus(False)
                    General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FormStatus.NoAction)
                Catch ex As Exception
                    MsgBoxSaveFailed()
                    MsgBox(ex.ToString)
                End Try
            End If
        End If

    End Sub

    'For ILS Shortcuts Changed from Private Sub GeneralForms_CustomDeleteClick() Handles GeneralForms.CustomDeleteClick
    Public Sub GeneralForms_CustomDeleteClick(ByVal sender As Object, ByVal formId As Integer)

        If (Me.GeneralForms.getItemLevel(Me.GeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts

            Dim LogDataSet As New DataSet

            If MsgBoxDelete() = Windows.Forms.DialogResult.Yes Then

                Try
                    Vesseldata.Delete()
                    LogDataSet = Dm.DataSet.Copy
                    Dm.CommitAll()
                    GenerateLog(LogDataSet)
                    MsgBoxDeleteSuccessful()
                    ClearControl(Me)
                    FrmStaus = FormStatus.NoAction
                Catch ex As Exception
                    MsgBoxDeleteFailed()
                End Try

            End If
        End If

    End Sub

End Class