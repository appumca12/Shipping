Imports ShippingBiz
Imports OrmLib
Imports System.Data.SqlClient

Public Class FrmEcsBank
    Private ItemLevel As String = "200"
    Private FrmStaus As FormStatus
    Private Dm As ShippingBiz.DataManager
    Private Vesseldata As TB_Vessels
    Dim IsNew As Boolean
    Dim IsEdit As Boolean
    Dim DTEcsBank As DataTable

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

        Me.ContainerNo.GeneralText.Text = ""
        'Me.CntrSize.GnrlNum.Value = 0
        'Me.CntrType.GeneralText.Text = ""
        Me.TareWeight.GnrlNum.Value = 0
        Me.MaxGW.GnrlNum.Value = 0
        Me.Payload.GnrlNum.Value = 0

        FrmStaus = FormStatus.HasData
        General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FormStatus.NoAction)

    End Sub

    Private Sub SendDataToClass()

        Dim Cmd As New SqlCommand
        Dim DA1 As New SqlDataAdapter
        Dim Cnn As New SqlConnection(My.Settings.DSN)
        Dim sSql As String
        Dim TB1 As New System.Data.DataTable
        Dim lResult As Boolean

        If FrmStaus = FormStatus.NewRecord Then

            sSql = "Select CntrNo from TB_ECSBank where CntrNo = '" & Me.ContainerNo.TextValue.ToString() & "'"
            TableBySql(sSql, TB1, lResult)

            If TB1.Rows.Count = 0 Then
                Cmd = New SqlCommand("SP_ECSBank_Insert")
                Cnn = New SqlConnection(My.Settings.DSN)
                Cnn.Open()
                Cmd.CommandTimeout = 2000
                Cmd.CommandType = CommandType.StoredProcedure
                Cmd.Parameters.AddWithValue("@ID", Guid.NewGuid)
                Cmd.Parameters.AddWithValue("@CntrNo", Me.ContainerNo.TextValue.ToString())
                Cmd.Parameters.AddWithValue("@CntrSize", Me.CntrSize.Code)
                Cmd.Parameters.AddWithValue("@CntrType", Me.CntrType.Code)
                Cmd.Parameters.AddWithValue("@TW", Me.TareWeight.GnrlNum.Value)
                Cmd.Parameters.AddWithValue("@MaxGW", Me.MaxGW.GnrlNum.Value)
                Cmd.Parameters.AddWithValue("@Payload", Me.Payload.GnrlNum.Value)
                Cmd.Parameters.AddWithValue("@Created_Date", Now())
                Cmd.Parameters.AddWithValue("@Modified_Date", Now())
                Cmd.Parameters.AddWithValue("@CreatedBy", CurrentUser.ID.ToString())


                Cmd.Connection = Cnn
                Cmd.ExecuteNonQuery()
                MsgBoxSaveSuccessful()
            Else
                MessageBox.Show("Container Alread Exist!")
            End If
        Else
            Cmd = New SqlCommand("SP_ECSBank_Update")
            Cnn = New SqlConnection(My.Settings.DSN)
            Cnn.Open()
            Cmd.CommandTimeout = 2000
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Parameters.AddWithValue("@ID", DTEcsBank.Rows(0).Item("ID"))
            Cmd.Parameters.AddWithValue("@CntrNo", Me.ContainerNo.TextValue.ToString())
            Cmd.Parameters.AddWithValue("@CntrSize", Me.CntrSize.Code)
            Cmd.Parameters.AddWithValue("@CntrType", Me.CntrType.Code)
            Cmd.Parameters.AddWithValue("@TW", Me.TareWeight.GnrlNum.Value)
            Cmd.Parameters.AddWithValue("@MaxGW", Me.MaxGW.GnrlNum.Value)
            Cmd.Parameters.AddWithValue("@Payload", Me.Payload.GnrlNum.Value)
            Cmd.Parameters.AddWithValue("@Modified_Date", Now())
            Cmd.Parameters.AddWithValue("@CreatedBy", CurrentUser.ID.ToString())

            Cmd.Connection = Cnn
            Cmd.ExecuteNonQuery()
            MsgBoxSaveSuccessful()
        End If

    End Sub

    Private Sub LockStatus(ByVal Status As Boolean)

        Me.ContainerNo.Enabled = True
        Me.CntrSize.Enabled = Status
        Me.CntrType.Enabled = Status
        Me.TareWeight.GnrlNum.Enabled = Status
        Me.MaxGW.GnrlNum.Enabled = Status
        Me.Payload.GnrlNum.Enabled = Status

    End Sub

    Private Function VesselValidate() As Boolean

        Dim Ans As Boolean = False

    End Function

    Private Sub FrmEcsBank_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        Dm = New ShippingBiz.DataManager(My.Settings.DSN)
        Me.GeneralForms.InitControl("ECS Bank", ItemLevel)
       
        Me.TareWeight.InitControl(6, 0)
        Me.MaxGW.InitControl(6, 0)
        Me.Payload.InitControl(6, 0)
        'Me.CntrSize.InitControl(6, 0)
        Me.ContainerNo.GeneralTxt.CharacterCasing = CharacterCasing.Upper
        'Me.CntrType.GeneralTxt.CharacterCasing = CharacterCasing.Upper
        Me.CntrType.InitControl("CT", UserComboCode.ShowCoumn.StdCode)
        Me.CntrSize.InitControl("CS", UserComboCode.ShowCoumn.StdCode)
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



    'For ILS Shortcuts: Changed from Private Sub GeneralForms_CustomFindClick() Handles GeneralForms.CustomFindClick to GeneralForms_CustomFindClick(ByVal sender As Object, ByVal formId As Integer)
    Public Sub GeneralForms_CustomFindClick(ByVal sender As Object, ByVal formId As Integer)

        LockStatus(False)
        Dim sSql As String
        Dim IResult As Boolean

        If Me.ContainerNo.GeneralText.Text = "" Then
            MsgBoxGeneral("Please Fill Container No !", "Error")
            Exit Sub
        End If


        sSql = "Select * from TB_ECSBank where cntrno = '" & Me.ContainerNo.TextValue.ToString() & "'"
        TableBySql(sSql, DTEcsBank, IResult)

        If DTEcsBank.Rows.Count > 0 Then
            Me.ContainerNo.TextValue = DTEcsBank.Rows(0).Item("CntrNo").ToString()
            Me.CntrSize.Code = System.Double.Parse(DTEcsBank.Rows(0).Item("CntrSize").ToString())
            Me.CntrType.Code = DTEcsBank.Rows(0).Item("CntrType").ToString()
            Me.TareWeight.GnrlNum.Value = System.Double.Parse(DTEcsBank.Rows(0).Item("TW").ToString())
            Me.MaxGW.GnrlNum.Value = System.Double.Parse(DTEcsBank.Rows(0).Item("MaxGW").ToString())
            Me.Payload.GnrlNum.Value = System.Double.Parse(IIf(DTEcsBank.Rows(0).Item("Payload").ToString() = "", 0, DTEcsBank.Rows(0).Item("Payload").ToString()))
            Me.ModifiedDate.TextValue = DTEcsBank.Rows(0).Item("Modified_date").ToString()
            Me.CreatedDate.TextValue = DTEcsBank.Rows(0).Item("Created_date").ToString()
            LockStatus(False)

            General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FormStatus.HasData)
        Else
            MsgBoxGeneral("Invalid Container No !", "Error")
            LockStatus(True)
        End If
    End Sub

    'For ILS Shortcuts: Changed from Private Sub GeneralForms_CustomNewClick() Handles GeneralForms.CustomNewClick
    Public Sub GeneralForms_CustomNewClick(ByVal sender As Object, ByVal formId As Integer)

        'If (Me.GeneralForms.getItemLevel(Me.GeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts

        ClearControl(Me)
        LockStatus(True)
        Me.ContainerNo.GeneralText.Text = ""
        FrmStaus = FormStatus.NewRecord
        General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FormStatus.NewRecord)

        'End If


    End Sub

    'For ILS Shortcuts Changed from Private Sub GeneralForms_CustomEditClick() Handles GeneralForms.CustomEditClick
    Public Sub GeneralForms_CustomEditClick(ByVal sender As Object, ByVal formId As Integer)

       
        LockStatus(True)
        FrmStaus = FormStatus.EditRecord
        General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FormStatus.EditRecord)


    End Sub

    'For ILS Shortcuts: Changed from Private Sub GeneralForms_CustomSaveClick() Handles GeneralForms.CustomSaveClick
    Public Sub GeneralForms_CustomSaveClick(ByVal sender As Object, ByVal formId As Integer)

       
        Dim LogDataSet As New DataSet
        If Me.CntrSize.Code Is Nothing Or Me.CntrSize.Code = "" Then
            MsgBox("Please Select Cntr Size!")
            Exit Sub
        End If

        If Me.CntrType.Code Is Nothing Or Me.CntrType.Code = "" Then
            MsgBox("Please Select Cntr Type!")
            Exit Sub
        End If


        If 1 = 2 Then
            'If CheckDigit(Me.ContainerNo.TextValue.ToString()) = False Then
            MsgBox("Check Digit Failed! Please check Cntr No.")
        Else
            If MsgBoxUpdate() = Windows.Forms.DialogResult.Yes Then
                Try
                    SendDataToClass()
                    LogDataSet = Dm.DataSet.Copy
                    'Dm.CommitAll()
                    'GenerateLog(LogDataSet)

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