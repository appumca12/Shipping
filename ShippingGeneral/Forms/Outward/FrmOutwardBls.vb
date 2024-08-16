Imports OrmLib
Imports ShippingBiz
Imports System.Data.SqlClient
Public Class FrmOutwardBls

    Private dm As DataManager
    Private FrmStatus As FormStatus
    Private BL As TB_OutwardBLSCollection
    Private BLID As Guid
    Private ItemLevel As String = "100"
    Private formlocalId As Integer 'For ILS Shortcuts  
    Private formId As String 'For ILS Shortcuts  
    Private Sub FrmOutwardBls_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Cursor = Cursors.WaitCursor
        Me.GeneralForms.InitControl("Outward B/LS", ItemLevel)
        Me.BLSData.InitControl(UserBLS.InwardOutward.Outward, My.Settings.MainColor)
        Me.BlsGoods.InitControl()
        Me.BlsCharges.InitControl()
        Me.BLMisc.InitControl()
        Me.BlsComments.InitControl(UserBlsComments.InwardOutward.Outward)
        Me.Top = 0
        Me.Left = 0
        BlsCntrs.InitControl(UserBlsCntrs.InwardOutward.Outward)
        FrmStatus = FormStatus.NoAction
        ChangeStatus(FrmStatus)
        ChangeLocked()
        Me.Cursor = Cursors.Default
        Me.BookingNo.InitControl()
        General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)
        Me.GeneralForms.AddCustomTools("Chgs From Booking", "ImpChgs", My.Resources.add_24)

    End Sub

    'For ILS Shortcuts: Changed from Private Sub GeneralForms_CustomFindClick() Handles GeneralForms.CustomFindClick to GeneralForms_CustomFindClick(ByVal sender As Object, ByVal formId As Integer)
    Public Sub GeneralForms_CustomFindClick(ByVal sender As Object, ByVal formId As Integer)
        If (Me.GeneralForms.getItemLevel(Me.GeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts  

            Dim DummyBl As String = Me.BLNO.TextValue
            Dim aTables() As String = {"TB_OutwardBls", "Tb_OutwardBlsNames", "TB_OutwardBlsGoods", "TB_OutwardCharges", "Tb_OutwardCntrs", "TB_OutwardCnsImco", "TB_OutwardCnsTemprature", "TB_OutwardCnsPkgs", "TB_OutwardCntrsCharges", "TB_OutwardBlsComments"}
            Dim Dr As DataRow
            Dim nI As Byte
            Dim nTab As Byte


            nTab = Me.BlsDetailTab.SelectedTab.Index
            Me.BlsDetailTab.Tabs(0).Selected = True
            LockStatus(True)

            ClearControl(Me)
            Me.BLNO.TextValue = DummyBl

            FrmStatus = FormStatus.NoAction

            'If Me.BLNO.TextValue = "" Then
            '    MsgBoxGeneral("Please Fill B/L No", "B/L No Requird")
            '    Exit Sub
            'End If

            dm = New DataManager(My.Settings.DSN)

            Dim ds As DataSet = StoredProcedures.SP_OutwardAllDataByLineBlNo(CurrentShippingLine, Me.BLNO.TextValue)
            dm.PopulateObjectsFromDataSet(ds, aTables)

            For nI = 0 To aTables.Length - 1
                dm.DataSet.Tables(aTables(nI)).Merge(ds.Tables(nI))
            Next

            If dm.DataSet.Tables("TB_OutwardBls").Rows.Count = 0 Then
                MsgBoxGeneral("No Valid B/L No !", "Information")
                ChangeStatus(FormStatus.NoAction)
                ChangeLocked()
                Me.BookingNo.BookingID = Nothing
                Me.TFCCode.TextValue = ""
                Me.BarCode.TextValue = ""
                Me.BarCode2.TextValue = ""
                Me.BarCode3.TextValue = ""
                BLID = Guid.NewGuid
                General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FormStatus.NoAction)
            Else
                FrmStatus = FormStatus.HasData
                ChangeLocked()
                BLID = dm.DataSet.Tables("TB_Outwardbls").Rows(0).Item("ID")
                ChangeStatus(FormStatus.HasData)
                Me.BLSData.SetDocument(dm.DataSet.Tables("TB_OutwardBls").Rows(0))
                Me.BookingNo.BookingID = BLSData.BookingID
                Me.TFCCode.TextValue = NullToValue(dm.DataSet.Tables("TB_OutwardBls").Rows(0).Item("TFCCODE"), "")
                Me.BarCode.TextValue = NullToValue(dm.DataSet.Tables("TB_OutwardBls").Rows(0).Item("Barcode"), "")
                Me.BarCode2.TextValue = NullToValue(dm.DataSet.Tables("TB_OutwardBls").Rows(0).Item("Barcode2"), "")
                Me.BarCode3.TextValue = NullToValue(dm.DataSet.Tables("TB_OutwardBls").Rows(0).Item("Barcode3"), "")
                If dm.DataSet.Tables("TB_OutwardBlsNames").Rows.Count = 0 Then
                    Dr = dm.DataSet.Tables("TB_OutwardBlsNames").NewRow
                    Dr("ID") = System.Guid.NewGuid
                    Dr("BLID") = BLID
                    dm.DataSet.Tables("TB_OutwardBlsNames").Rows.Add(Dr)
                End If

                If dm.DataSet.Tables("TB_OutwardBlsGoods").Rows.Count = 0 Then
                    Dr = dm.DataSet.Tables("TB_OutwardBlsGoods").NewRow
                    Dr("ID") = System.Guid.NewGuid
                    Dr("BLID") = BLID
                    dm.DataSet.Tables("TB_OutwardBlsGoods").Rows.Add(Dr)
                End If

                Me.BlsNames.SetDocument(dm.DataSet.Tables("TB_OutwardBlsNames").Rows(0))
                Me.BlsGoods.SetDocument(dm.DataSet.Tables("TB_OutwardBlsGoods").Rows(0))
                Me.BLMisc.SetDocument(dm.DataSet.Tables("TB_Outwardbls").Rows(0))
                General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FormStatus.HasData)

            End If

            Me.BlsCntrs.SetDocument(BLID, dm.DataSet)
            Me.BlsCharges.SetDocument(BLID, dm.DataSet.Tables("TB_OutwardCharges"), UserBlsCharges.InwardOutward.Outward)
            Me.BlsCntrs.BookingID = Me.BookingNo.BookingID
            Me.BlsComments.SetDocument(BLID, dm.DataSet.Tables("TB_OutwardBlsComments"))
            Me.BlsDetailTab.Tabs(nTab).Selected = True
        End If

    End Sub

    'For ILS Shortcuts: Changed from Private Sub GeneralForms_CustomNewClick() Handles GeneralForms.CustomNewClick
    Public Sub GeneralForms_CustomNewClick(ByVal sender As Object, ByVal formId As Integer)
        If (Me.GeneralForms.getItemLevel(Me.GeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts
            Me.BLNO.Focus()
            Dim dummyBl As String = Me.BLNO.TextValue
            dm = New DataManager(My.Settings.DSN)
            FrmStatus = FormStatus.NewRecord
            BLID = Guid.NewGuid
            ChangeStatus(FrmStatus)
            ChangeLocked()
            ClearControl(Me)
            BlsCntrs.SetDocument(BLID, dm.DataSet)

            BlsCharges.SetDocument(BLID, dm.DataSet.Tables("TB_OutwardCharges"), UserBlsCharges.InwardOutward.Outward)
            Me.BLNO.TextValue = dummyBl
        End If

    End Sub

    'For ILS Shortcuts Changed from Private Sub GeneralForms_CustomEditClick() Handles GeneralForms.CustomEditClick
    Public Sub GeneralForms_CustomEditClick(ByVal sender As Object, ByVal formId As Integer)

        If (Me.GeneralForms.getItemLevel(Me.GeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts
            FrmStatus = FormStatus.EditRecord
            ChangeStatus(FrmStatus)
            ChangeLocked()
        End If

    End Sub

    'For ILS Shortcuts: Changed from Private Sub GeneralForms_CustomSaveClick() Handles GeneralForms.CustomSaveClick
    Public Sub GeneralForms_CustomSaveClick(ByVal sender As Object, ByVal formId As Integer)
        If (Me.GeneralForms.getItemLevel(Me.GeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts

            Dim LogDataSet As New DataSet
            Dim Dr As DataRow
            Dim Bl As DataRow
            Dim Tb As DataTable
            Dim nErrCount As Byte = 0
            Dim DsTemp As New DataSet
            Dim TbName As String
            Dim Dv As DataView
            Dim cLen As Byte
            Dim DC As DataColumn
            Dim Seq As Long
            Dim isNew As Boolean

            CheckTotal()

            Me.BLSData.BookingID = Me.BookingNo.BookingID
            Me.BLSData.Checking(Tb)
            Me.BlsGoods.Checking(Tb, Me.BlsCntrs.GridCntrs.DataSource.tables(0).copy)
            Me.BlsCntrs.Checking(Tb)
            Me.BlsCharges.Checking(Tb)

            If Not Tb Is Nothing Then
                nErrCount = RaiseError(Tb)
                If nErrCount > 0 Then
                    MsgBoxValidateFaild()
                    Exit Sub
                End If
                If MsgBox("Do You Want Continue With Warnings ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    Exit Sub
                End If
            End If

            If MsgBoxUpdate() = Windows.Forms.DialogResult.Yes Then

                With dm.DataSet.Tables("TB_OutwardBls")
                    If .Rows.Count = 0 Then
                        isNew = True
                        Bl = .NewRow
                        'Me.BarCode.TextValue = 'GetNewbarCodeSeq()
                        'Bl("BarCode") = Me.BarCode.TextValue
                        If CurrentShippingLine = "WHL" Or CurrentShippingLine = "WAN" Then
                            Seq = GenExportBLNo()
                            Bl("BLNO") = "054" & Mid(Now.Year.ToString, 4, 1) & Seq.ToString  ' Me.BLNO.TextValue
                        Else
                            Bl("BLNO") = Me.BLNO.TextValue
                        End If
                        'Bl("BLNO") = "0" & Seq.ToString
                        Me.BLNO.TextValue = Bl("BLNO")
                        Bl("ID") = BLID
                        .Rows.Add(Bl)
                    End If
                    'Bl("Barcode") = Me.BarCode.TextValue
                    BLSData.GetDocument(.Rows(0), Me.BLNO.TextValue)
                    BLMisc.GetDocument(.Rows(0))
                    dm.DataSet.Tables("TB_OutwardBls").Rows(0).Item("TFCCode") = Me.TFCCode.TextValue
                    dm.DataSet.Tables("TB_OutwardBls").Rows(0).Item("BarCode") = Me.BarCode.TextValue
                    dm.DataSet.Tables("TB_OutwardBls").Rows(0).Item("BarCode2") = Me.BarCode2.TextValue
                    dm.DataSet.Tables("TB_OutwardBls").Rows(0).Item("BarCode3") = Me.BarCode3.TextValue
                End With

                DsTemp = Me.BlsCntrs.GetCntrsChanges

                If Not DsTemp Is Nothing Then
                    For Each Tb In DsTemp.Tables
                        TbName = "TB_Outward" & Tb.TableName
                        For Each Dr In Tb.Rows
                            Select Case Dr.RowState
                                Case DataRowState.Added
                                    dm.DataSet.Tables(TbName).ImportRow(Dr)
                                Case DataRowState.Deleted
                                    Dv = New DataView(dm.DataSet.Tables(TbName), "ID = '" & Dr(0, DataRowVersion.Original).ToString & "'", "", DataViewRowState.CurrentRows)
                                    If Dv.Count > 0 Then
                                        Dv.Item(0).Delete()
                                    End If
                                Case DataRowState.Modified
                                    Dv = New DataView(dm.DataSet.Tables(TbName), "ID = '" & Dr.Item("ID").ToString & "'", "", DataViewRowState.CurrentRows)
                                    If Dv.Count > 0 Then
                                        cLen = Dr.ItemArray.Length
                                        For Each DC In Tb.Columns
                                            Dv.Item(0).Item(DC.ColumnName) = Dr.Item(DC.ColumnName)
                                        Next
                                    End If
                            End Select
                        Next
                    Next
                End If

                Me.BlsCntrs.AcceptCntrsChanges()
                Me.BlsComments.GetDocument(dm.DataSet.Tables("TB_OutwardBlsComments"))

                With dm.DataSet.Tables("TB_OutwardBlsNames")
                    If .Rows.Count = 0 Then
                        Dr = .NewRow
                        Dr("ID") = Guid.NewGuid
                        Dr("BLID") = BLID
                    Else
                        Dr = .Rows(0)
                    End If
                    Me.BlsNames.getDocument(Dr)

                    If dm.DataSet.Tables("TB_OutwardBlsNames").Rows.Count = 0 Then
                        dm.DataSet.Tables("TB_OutwardBlsNames").Rows.Add(Dr)
                    End If

                End With

                With dm.DataSet.Tables("TB_OutwardBlsGoods")
                    If .Rows.Count = 0 Then
                        Dr = .NewRow
                        Dr("ID") = Guid.NewGuid
                        Dr("BLID") = BLID
                    Else
                        Dr = .Rows(0)
                    End If
                    Me.BlsGoods.getDocument(Dr)
                    If dm.DataSet.Tables("TB_OutwardBlsGoods").Rows.Count = 0 Then
                        dm.DataSet.Tables("TB_OutwardBlsGoods").Rows.Add(Dr)
                    End If
                End With

                Me.BlsCharges.GetDocument(dm.DataSet.Tables("TB_OutwardCharges"))

                Try
                    LogDataSet = dm.DataSet.Copy
                    dm.CommitAll()
                    GenerateLog(LogDataSet)
                    MsgBoxSaveSuccessful()
                    FrmStatus = FormStatus.HasData
                    ChangeStatus(FrmStatus)
                    Me.BlsCharges.ChrgesTable.AcceptChanges()
                Catch ex As Exception
                    If isNew = True Then
                        If CurrentShippingLine = "WHL" Or CurrentShippingLine = "WHA" Then
                            RollBackExportBLNo(Seq)
                            Me.BLNO.TextValue = ""
                        End If
                        Me.BLNO.TextValue = ""
                    End If
                    MsgBoxSaveFailed()
                    MsgBoxGeneral(ex.ToString, "Error On Save B/L !")
                End Try
            End If

        End If

    End Sub

    'For ILS Shortcuts Changed from Private Sub GeneralForms_CustomDeleteClick() Handles GeneralForms.CustomDeleteClick
    Public Sub GeneralForms_CustomDeleteClick(ByVal sender As Object, ByVal formId As Integer)
        If (Me.GeneralForms.getItemLevel(Me.GeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts

            Dim LogDataSet As DataSet

            If dm.DataSet.Tables("TB_OutwardBls").Rows.Count > 0 Then
                If MsgBoxDelete() = Windows.Forms.DialogResult.Yes Then
                    Try
                        dm.DataSet.Tables("TB_OutwardBls").Rows(0).Delete()
                        LogDataSet = dm.DataSet.Copy
                        dm.CommitAll()
                        GenerateLog(LogDataSet)
                        MsgBoxDeleteSuccessful()
                        Me.BlsDetailTab.Tabs(0).Selected = True
                        LockStatus(True)
                        ClearControl(Me)
                        FrmStatus = FormStatus.NoAction
                        General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)
                    Catch ex As Exception
                        MsgBoxDeleteFailed()
                        MsgBox(ex.ToString)
                    End Try
                End If
            End If
        End If

    End Sub

    'For ILS Shortcuts: Changed from Private Sub GeneralForms_CustomHistory() Handles GeneralForms.CustomHistory
    Public Sub GeneralForms_CustomHistory(ByVal sender As Object, ByVal formId As Integer)
        If (Me.GeneralForms.getItemLevel(Me.GeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts

            Dim Frm As FrmLogViewByID
            Dim aTable As New ArrayList

            If Me.BLNO.TextValue = "" Then
                Exit Sub
            End If

            If Me.FrmStatus = FormStatus.NewRecord Then
                Exit Sub
            End If

            aTable.Add("Tb_OutwardBlsNames")
            aTable.Add("TB_OutwardBlsGoods")
            aTable.Add("TB_OutwardCharges")
            aTable.Add("Tb_OutwardCntrs")
            Frm = New FrmLogViewByID(BLNO.TextValue, BLID, "TB_OutwardBls", aTable, "BLID")
            '   Frm = New FrmLogViewByID(Me.BLID, Me.BLNO.TextValue)
            Frm.ShowDialog()
        End If
    End Sub

    'For ILS Shortcuts: Changed from Private Sub GeneralForms_CustomOthers() Handles GeneralForms.CustomOthers
    Public Sub GeneralForms_CustomOthers(ByVal sender As Object, ByVal formId As Integer)

        If (Me.GeneralForms.getItemLevel(Me.GeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts
            If GeneralForms.KeySelect = "ImpChgs" Then
                ImportCharges()
            End If
        End If

    End Sub

    Private Sub GeneralForms_CustomHomeClick() Handles GeneralForms.CustomHomeClick
        Me.Close()
    End Sub

    'For ILS Shortcuts: Changed from Private Sub GeneralForms_CustomPrintClick() Handles GeneralForms.CustomPrintClick
    Public Sub GeneralForms_CustomPrintClick(ByVal sender As Object, ByVal formId As Integer)

        If (Me.GeneralForms.getItemLevel(Me.GeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts
            Dim TB As New DataTable
            Dim Frm As FrmDialogPrint = New FrmDialogPrint(FrmDialogPrint.InwardOutward.Outward, Me.BLNO.TextValue, TB)
            Frm.Show()
        End If

    End Sub

    Private Sub ChangeLocked()

        Select Case FrmStatus
            Case FormStatus.EditRecord
                LockStatus(True)
            Case FormStatus.HasData
                LockStatus(False)
            Case FormStatus.NewRecord
                LockStatus(True)
            Case FormStatus.NoAction
                LockStatus(False)
        End Select

    End Sub

    Private Sub GeneralForms_CustomNavigateFirstClick() Handles GeneralForms.CustomNavigateFirstClick
        Navigate(NavigateType.FirstRecord)
    End Sub

    Private Sub GeneralForms_CustomNavigateLastClick() Handles GeneralForms.CustomNavigateLastClick
        Navigate(NavigateType.LastRecord)
    End Sub

    Private Sub GeneralForms_CustomNavigateNextClick() Handles GeneralForms.CustomNavigateNextClick
        Navigate(NavigateType.NextRecord)
    End Sub

    Private Sub GeneralForms_CustomNavigatePrivClick() Handles GeneralForms.CustomNavigatePrivClick
        Navigate(NavigateType.PreviousRecord)
    End Sub

    Private Sub ChangeStatus(ByVal Status As FormStatus)
        FrmStatus = Status
        General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)
    End Sub

    Private Sub LockStatus(ByVal Status As Boolean)

        LockControls(Me, Status)
        Me.BLNO.GeneralText.Enabled = True
        'Me.BLSData.Enabled = Status
        'Me.BlsCharges.Enabled = Status
        'Me.BlsGoods.Enabled = Status
        'Me.BlsCntrs.Enabled = Status
        'Me.BlsNames.Enabled = Status

    End Sub

    Private Sub BookingNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles BookingNo.Leave
        Dim Bk As TB_Booking
        Me.BlsCntrs.BookingID = Me.BookingNo.BookingID

        dm.QueryCriteria.Clear()
        dm.QueryCriteria.And(JoinPath.TB_Booking.Columns.ID, Me.BookingNo.BookingID, MatchType.Exact)
        Bk = dm.GetTB_Booking

        Me.BLSData.SetBookingData(Bk)


    End Sub

    Private Sub CheckTotal()

        Dim nTTW As Long = 0
        Dim nTGW As Double = 0
        Dim nTNW As Double = 0

        Dim NPkgs As Long = 0
        Dim nNwgt As Double = 0

        Dim R As Infragistics.Win.UltraWinGrid.UltraGridRow
        With Me.BlsCntrs.GridCntrs
            For Each R In .Rows
                nTTW += NullToValue(R.Cells("TW").Value, 0)
                nTGW += NullToValue(R.Cells("GW").Value, 0)
                nTNW += NullToValue(R.Cells("NET").Value, 0)
                NPkgs += NullToValue(R.Cells("NoOFPkgs").Value, 0)
            Next
        End With

        If NullToValue(Me.BlsGoods.TGW.GnrlNum.Value, 0) <> nTTW Or _
            NullToValue(Me.BlsGoods.TGW.GnrlNum.Value, 0) <> nTTW Or _
            NullToValue(Me.BlsGoods.TTLNET.GnrlNum.Value, 0) <> nTNW Or _
            NullToValue(Me.BlsGoods.TTW.GnrlNum.Value, 0) <> nTTW Or _
            NullToValue(Me.BlsGoods.TTLPKGS.GnrlNum.Value, 0) <> NPkgs Then
            If MsgBox("do you want weighs come equal with containers ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Me.BlsGoods.TGW.GnrlNum.Value = nTTW
                Me.BlsGoods.TGW.GnrlNum.Value = nTGW
                Me.BlsGoods.TTLNET.GnrlNum.Value = nTNW
                Me.BlsGoods.TTW.GnrlNum.Value = nTTW
                Me.BlsGoods.TTLPKGS.GnrlNum.Value = NPkgs
            End If
        End If

    End Sub

    Private Sub Navigate(ByVal NavType As NavigateType)

        Dim Ds As New DataSet
        Dim Prm As SqlClient.SqlParameter
        Dim arrayParams As New ArrayList

        Prm = New SqlClient.SqlParameter("Line", SqlDbType.VarChar, 10, ParameterDirection.Input)
        Prm.Value = CurrentShippingLine
        arrayParams.Add(Prm)

        Prm = New SqlClient.SqlParameter("BLNO", SqlDbType.Char, 36, ParameterDirection.Input)
        Prm.Value = Me.BLNO.TextValue
        arrayParams.Add(Prm)

        dm = New DataManager(My.Settings.DSN)

        dm.QueryCriteria.Clear()
        dm.QueryCriteria.And(JoinPath.TB_InwardBLS.Columns.Line, CurrentShippingLine, MatchType.Exact)

        Prm = New SqlClient.SqlParameter("Direction", SqlDbType.Char, 1, ParameterDirection.Input)
        Select Case NavType
            Case NavigateType.FirstRecord
                Prm.Value = "F"
            Case NavigateType.LastRecord
                Prm.Value = "L"
            Case NavigateType.NextRecord
                Prm.Value = "N"
            Case NavigateType.PreviousRecord
                Prm.Value = "P"
        End Select

        arrayParams.Add(Prm)
        Ds = dm.ExecuteProcedure("SP_OutwardBlsNavigate", CType(arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))

        formId = Me.GeneralForms.getItemLevel(Me.GeneralForms.UserTabSelected)  'For ILS Shortcuts  
        formlocalId = Convert.ToInt32(formId) 'For ILS Shortcuts  

        Try
            Me.BLNO.TextValue = Ds.Tables(0).Rows(0).Item("BLNO")
            Call GeneralForms_CustomFindClick(Me.BLNO, formlocalId)
            Call BookingNo_Leave(Me, New EventArgs)
        Catch ex As Exception
        End Try


    End Sub

    Private Sub BLSData_ClickBLPrint() Handles BLSData.ClickBLPrint

        Me.BLPrint.Init(UserBLPrint.InwardOutward.Outward, Me.BLNO.TextValue)
        Me.BLPrint.ComboList.Enabled = True

        PopupControl.Show()

        'Dim Frm As FrmDialogPrint = New FrmDialogPrint(FrmDialogPrint.InwardOutward.Outward, Me.BLNO.TextValue)
        'Frm.ShowDialog()
    End Sub

    Private Sub BLSData_ClickFMNFPrint() Handles BLSData.ClickFMNFPrint

        Dim mnf As New CLOutwardManifest
        mnf.GenrateMnf(CurrentShippingLine, Me.BLNO.TextValue)
        mnf.ShowReport("N")

    End Sub

    Private Sub BLSData_ClieckCMNFPrint() Handles BLSData.ClieckCMNFPrint

        Dim mnf As New CLOutwardManifest
        mnf.GenrateMnf(CurrentShippingLine, Me.BLNO.TextValue)
        mnf.ShowReport("Y")

    End Sub

    Private Sub ImportCharges()

        Dim sSql As String
        Dim TB As New DataTable
        Dim lResult As Boolean
        Dim Dr As DataRow
        Dim Drs() As DataRow
        Dim NewDr As DataRow

        If Me.BlsCntrs.CntrsDS.Tables(0).Rows.Count > 0 Then
            sSql = "Select * From Tb_Booking BK , TB_BookingDetails DT where BK.ID = DT.BookingID and BK.ID = '" & Me.BookingNo.BookingID.ToString & "'"
            TableBySql(sSql, TB, lResult)
            For Each Dr In TB.Rows
                If Dr("BaseOn") = "C" Then
                    Drs = Me.BlsCntrs.CntrsDS.Tables(0).Select("CnType = '" & Dr("CnType") & "' and CnSize = '" & Dr("CnSize") & "'", "")
                    For Each nDr In Drs
                        NewDr = Me.BlsCntrs.CntrsDS.Tables("CntrsCharges").NewRow
                        NewDr("CntrID") = nDr("ID")
                        NewDr("ChargesCode") = Dr("ChargeItem")
                        NewDr("Currency") = Dr("CurCode")
                        NewDr("UnitRate") = Dr("QTShipper")
                        NewDr("MEARate") = Dr("QTShipper")
                        NewDr("WGTrate") = 0
                        NewDr("FromPlace") = IIf(Dr("Payebleat") = "IRBND", "POL", "POD")
                        NewDr("ToPlace") = "POD"
                        NewDr("MinRate") = 0
                        If (Dr("Payebleat") = Dr("POL")) Then
                            NewDr("Terms") = "P"
                        ElseIf (Dr("Payebleat") = Dr("POD")) Then
                            NewDr("Terms") = "C"
                        Else
                            NewDr("Terms") = Dr("Terms")
                        End If

                        ''NewDr("Terms") = IIf(Dr("Payebleat") = "IRBND", Dr("Terms"), "P")
                        NewDr("RealAmount") = Dr("QTCarrier")
                        Me.BlsCntrs.CntrsDS.Tables("CntrsCharges").Rows.Add(NewDr)
                    Next
                End If
            Next

        End If


    End Sub

    Private Function GetNewbarCodeSeq() As String
        Dim TB As New DataTable
        Dim lResult As Boolean
        TableBySql("SP_GetLastBarCode", TB, lResult)
        Return TB.Rows(0).Item(0)
    End Function

    Private Sub BookingView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BookingView.Click

        FrmBooking.SrchBooking.TextValue = Me.BookingNo.BookingNo
        FrmBooking.ShowDialog()
        FrmBooking.Close()
    End Sub
End Class