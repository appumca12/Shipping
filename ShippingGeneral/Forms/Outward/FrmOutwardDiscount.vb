Imports OrmLib
Imports ShippingBiz
Imports System.Data.SqlClient

Public Class FrmOutwardDiscount
    Implements IFGeneral
    Private FrmStatus As FormStatus = FormStatus.NoAction
    'Private ItemLevel As String = "305"
    Private ItemLevel As String = "309"
    Private dm As DataManager
    Private BLDoc As TB_OutwardBLS
    Private BLDscnt As TB_OutwardDiscount
    Dim isNewClicked As Boolean = False
    Dim firsttime As String
    Dim isEdit As String

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
        isNewClicked = False

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
                firsttime = "y"
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
        isNewClicked = True 'For Shortcuts in Application 
        isEdit = "N" 'For Shortcuts in Application 
        Dim Dumm As String = Me.BLNO.TextValue
        If (Me.GeneralForms.getItemLevel(Me.GeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts
            'Me.BLNO.Focus()
            'Dim Dumm As String = Me.BLNO.TextValue
            If dm Is Nothing Then
                dm = New DataManager(My.Settings.DSN)
            End If
            dm.QueryCriteria.Clear()
            ClearControl(Me)
            Me.BLNO.TextValue = Dumm


            dm.QueryCriteria.Clear()
            dm.QueryCriteria.And(JoinPath.TB_OutwardBLS.Columns.Line, CurrentShippingLine, MatchType.Exact)
            dm.QueryCriteria.And(JoinPath.TB_OutwardBLS.Columns.BlNo, Me.BLNO.GeneralTxt.Text, MatchType.Exact)
            BLDoc = dm.GetTB_OutwardBLS


            If Not Me.BLNO.TextValue = "" Then
                If BLDoc Is Nothing Then
                    MsgBoxGeneral("Invalid B/L No", "Error")
                    Exit Sub
                End If
            End If

            'dm.QueryCriteria.Clear()
            'dm.QueryCriteria.And(JoinPath.TB_OutwardDiscount.Columns.BLID, BLDoc.ID, MatchType.Exact)
            'BLDscnt = dm.GetTB_OutwardDiscount
            'If Not BLDscnt Is Nothing Then
            '    MsgBoxGeneral("Duplicate records not allowed.", "Error")
            '    Exit Sub
            'End If

            LockStatus(True)
            FrmStatus = FormStatus.NewRecord
            General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FormStatus.NewRecord)

            If firsttime = "n" Then 'For Shortcuts in Application 
                dm.QueryCriteria.Clear()
                ClearControl(Me)
                Me.BLNO.Enabled = True
                Me.BLNO.GeneralTxt.Enabled = True
                Me.BLNO.Focus()
            End If 'For Shortcuts in Application End
            If isNewClicked = True Then
                If Not Me.BLNO.TextValue = "" Then
                    Dim TB1 As New System.Data.DataTable
                    Dim lResult As Boolean
                    Dim sSql As String = "select POLFreeDays from TB_Booking  where exists(select bookingid from tb_outwardbls where  TB_Booking.id = tb_outwardbls.bookingid  and tb_outwardbls.blno = '" & Me.BLNO.TextValue.Trim() & "')"
                    TableBySql(sSql, TB1, lResult)
                    Try
                        If lResult = True Then
                            Me.dFreeDays.GnrlNum.Value = Convert.ToInt32(TB1.Rows(0).Item("POLFreeDays").ToString())
                        End If
                    Catch ex As Exception

                    End Try

                End If
            End If
        End If

    End Sub

    'For ILS Shortcuts Changed from Private Sub GeneralForms_CustomEditClick() Handles GeneralForms.CustomEditClick
    Public Sub GeneralForms_CustomEditClick(ByVal sender As Object, ByVal formId As Integer)

        If (Me.GeneralForms.getItemLevel(Me.GeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts
            LockStatus(True)
            FrmStatus = FormStatus.EditRecord
            General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FormStatus.EditRecord)
            isEdit = "Y" 'For Shortcuts in Application End
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
                    'For Shortcuts in Application
                    dm.QueryCriteria.Clear()
                    dm.QueryCriteria.And(JoinPath.TB_InwardBLS.Columns.Line, CurrentShippingLine, MatchType.Exact)
                    dm.QueryCriteria.And(JoinPath.TB_InwardBLS.Columns.BlNo, Me.BLNO.GeneralTxt.Text, MatchType.Exact)
                    BLDoc = dm.GetTB_OutwardBLS
                    If BLDoc Is Nothing Then
                        MsgBoxGeneral("invalid b/l no", "error")
                        Exit Sub
                    End If
                    If isNewClicked = True Then
                        Dim TB2 As New System.Data.DataTable
                        Dim lResult2 As Boolean
                        Dim sSql2 As String = "select blid from TB_OutwardDiscount where blid = (select id from tb_outwardbls where blno = '" & Me.BLNO.TextValue.Trim() & "')"
                        TableBySql(sSql2, TB2, lResult2)

                        If TB2.Rows.Count > 0 Then
                            MsgBoxGeneral("Discount Already Exist for this BL", "error")
                            Exit Sub
                        End If
                    End If

                    Dim Cmd As New SqlCommand
                    Dim DA As New SqlDataAdapter
                    Dim Cnn As New SqlConnection(My.Settings.DSN)
                    Dim DS As New DataSet
                    Dim PCol(0) As DataColumn
                    Dim cCol(0) As DataColumn
                    Cnn.Open()

                    With Cmd
                        .CommandText = "SP_DuplicateFreeDays"
                        .CommandType = CommandType.StoredProcedure
                        .Connection = Cnn
                        .Parameters.AddWithValue("@Line", CurrentShippingLine)
                        .Parameters.AddWithValue("@BLno", Me.BLNO.GeneralTxt.Text)
                    End With

                    DA.SelectCommand = Cmd
                    DA.Fill(DS)

                    dm.QueryCriteria.Clear()
                    dm.QueryCriteria.And(JoinPath.TB_InwardDiscount.Columns.BLID, BLDoc.ID, MatchType.Exact)
                    BLDscnt = dm.GetTB_OutwardDiscount

                    If (DS.Tables(0).Rows.Count > 0) Then
                        Dim TB1 As New System.Data.DataTable
                        Dim lResult As Boolean
                        Dim sSql As String = "SELECT * FROM TB_OutwardDiscount where BLID ='" & DS.Tables(0).Rows(0)(0).ToString() & "'"
                        TableBySql(sSql, TB1, lResult)

                        'If TB1.Rows.Count > 1 Then
                        '    MsgBoxGeneral("Duplicate exists hence can not save.", "Error")
                        '    Exit Sub
                        'ElseIf TB1.Rows.Count = 1 And isEdit = "N" Then
                        '    MsgBoxGeneral("Duplicate records not allowed.", "Error")
                        '    Exit Sub
                        'End If

                    End If

                    isNewClicked = False
                    'For Shortcuts in Application End
                    SendDataToClass()
                    LogDataSet = dm.DataSet.Copy
                    dm.CommitAll()
                    GenerateLog(LogDataSet)
                    MsgBoxSaveSuccessful()
                    FrmStatus = FormStatus.NoAction
                    LockStatus(False)
                    General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FormStatus.NoAction)
                    firsttime = "n" 'For Shortcuts in Application
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
        firsttime = "y" 'For Shortcuts in Application 
    End Sub

    Private Sub BLNO_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles BLNO.Leave

        If isNewClicked = True Then
            If Not Me.BLNO.TextValue = "" Then
                Dim TB1 As New System.Data.DataTable
                Dim lResult As Boolean
                Dim sSql As String = "select POLFreeDays from TB_Booking  where exists(select bookingid from tb_outwardbls where  TB_Booking.id = tb_outwardbls.bookingid  and tb_outwardbls.blno = '" & Me.BLNO.TextValue.Trim() & "')"
                TableBySql(sSql, TB1, lResult)

                TableBySql(sSql, TB1, lResult)
                Try
                    If lResult = True Then
                        Me.dFreeDays.GnrlNum.Value = Convert.ToInt32(TB1.Rows(0).Item("POLFreeDays").ToString())
                    End If
                Catch ex As Exception

                End Try

            End If
        End If
    End Sub

End Class