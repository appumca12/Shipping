Imports OrmLib
Imports ShippingBiz
Public Class FrmLines

    Implements IFGeneral
    Private ItemLevel = "703"
    Private FrmStatus As FormStatus = FormStatus.NoAction
    Private LinesID As Guid
    Private Dm As DataManager
    Private Document As TB_Lines

    Private Sub LockStatus(ByVal Status As Boolean) Implements IFGeneral.LockStatus
        General.LockControls(Me, Status)
      
    End Sub

    Private Sub Populate() Implements IFGeneral.Populate

        With Document
            Me.Address.TextValue = NullToValue(.Address, "")
            Me.Country.Code = NullToValue(.Country, "")
            Me.EDICode.TextValue = NullToValue(.EDICode, "")
            Me.LineCode.TextValue = NullToValue(.LineCode, "")
            Me.LineName.TextValue = NullToValue(.LineName, "")

        End With

    End Sub

    Private Sub SendDataToClass() Implements IFGeneral.SendDataToClass

        With Document
            .Address = Me.Address.TextValue
            .Country = Me.Country.Code
            .EDICode = Me.EDICode.TextValue
            .LineCode = Me.LineCode.TextValue
            .LineName = Me.LineName.TextValue
        End With

    End Sub

    Private Sub FrmLines_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.GeneralForms.InitControl("LINES INFORMATION", ItemLevel)
        FrmStatus = FormStatus.NoAction
        General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)
        LockStatus(False)
        Me.SearchCode.GeneralText.Enabled = True
        Dm = New DataManager(My.Settings.DSN)
        Me.Country.InitControl("CY", UserComboCode.ShowCoumn.Meaning)


    End Sub

    'For ILS Shortcuts: Changed from Private Sub GeneralForms_CustomFindClick() Handles GeneralForms.CustomFindClick to GeneralForms_CustomFindClick(ByVal sender As Object, ByVal formId As Integer)
    Public Sub GeneralForms_CustomFindClick(ByVal sender As Object, ByVal formId As Integer)

        If (UserGeneralForms.getItemLevel(UserGeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts  

            Dim Dummy As String = Me.SearchCode.TextValue
            ClearControl(Me)
            Me.SearchCode.TextValue = Dummy
            If Dummy = "" Then
                Exit Sub
            End If
            Dm.QueryCriteria.Clear()
            Dm.QueryCriteria.And(JoinPath.TB_Lines.Columns.LineCode, Dummy, MatchType.Exact)
            Document = Dm.GetTB_Lines
            If Document Is Nothing Then
                MsgBoxGeneral("No Valid Line !")
                FrmStatus = FormStatus.NoAction
                Exit Sub
            Else
                Populate()
                FrmStatus = FormStatus.HasData
            End If

            General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)
            LockStatus(False)
            Me.SearchCode.GeneralText.Enabled = True
        End If

    End Sub

    'For ILS Shortcuts: Changed from Private Sub GeneralForms_CustomNewClick() Handles GeneralForms.CustomNewClick
    Public Sub GeneralForms_CustomNewClick(ByVal sender As Object, ByVal formId As Integer)

        If (Me.GeneralForms.getItemLevel(Me.GeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts

            ClearControl(Me)
            Me.LineCode.Focus()
            Dm = New DataManager(My.Settings.DSN)
            FrmStatus = FormStatus.NewRecord
            LinesID = System.Guid.NewGuid
            General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)
            LockStatus(True)

        End If

    End Sub

    'For ILS Shortcuts Changed from Private Sub GeneralForms_CustomEditClick() Handles GeneralForms.CustomEditClick
    Public Sub GeneralForms_CustomEditClick(ByVal sender As Object, ByVal formId As Integer)

        If (UserGeneralForms.getItemLevel(UserGeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts
            FrmStatus = FormStatus.EditRecord
            General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)
            LockStatus(True)
        End If

    End Sub

    'For ILS Shortcuts Changed from Private Sub GeneralForms_CustomSaveClick() Handles GeneralForms.CustomSaveClick
    Public Sub GeneralForms_CustomSaveClick(ByVal sender As Object, ByVal formId As Integer)

        If (UserGeneralForms.getItemLevel(UserGeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts

            Dim LogDataSet As New DataSet
            If ValidateForm() = True Then
                If MsgBoxUpdate() = Windows.Forms.DialogResult.Yes Then
                    If FrmStatus = FormStatus.NewRecord Then
                        Dm = New DataManager(My.Settings.DSN)
                        Document = Dm.NewTB_Lines(Me.LineCode.TextValue, Me.LineName.TextValue, Me.EDICode.TextValue)
                        Document.ID = LinesID
                    End If
                    SendDataToClass()
                    Try
                        LogDataSet = Dm.DataSet.Copy
                        Dm.CommitAll()
                        GenerateLog(LogDataSet)
                        MsgBoxSaveSuccessful()
                    Catch ex As Exception
                        MsgBoxSaveFailed()
                    End Try
                End If
            End If
        End If

    End Sub

    'For ILS Shortcuts Changed from Private Sub GeneralForms_CustomDeleteClick() Handles GeneralForms.CustomDeleteClick
    Public Sub GeneralForms_CustomDeleteClick(ByVal sender As Object, ByVal formId As Integer)

        If (Me.GeneralForms.getItemLevel(Me.GeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts

            Dim LogDataSet As New DataSet

            If Not Document Is Nothing Then
                If MsgBoxDelete() = Windows.Forms.DialogResult.Yes Then

                    Try
                        Document.Delete()
                        LogDataSet = Dm.DataSet.Copy
                        Dm.CommitAll()
                        GenerateLog(LogDataSet)
                        ClearControl(Me)
                        FrmStatus = FormStatus.NoAction
                        General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)
                        LockStatus(False)
                        Me.SearchCode.GeneralText.Enabled = True
                        MsgBoxDeleteSuccessful()
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

        FormErrorProvider.Clear()

        If Me.LineName.TextValue = "" Then
            aList.Add(Me.LineName)
        End If

        If Me.LineCode.TextValue = "" Then
            aList.Add(Me.LineCode)
        End If

        If Me.EDICode.TextValue = "" Then
            aList.Add(Me.EDICode)
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