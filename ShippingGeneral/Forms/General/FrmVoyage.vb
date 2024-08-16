Imports OrmLib
Imports shippingBIZ

Public Class FrmVoyage

    Implements IFGeneral
    Private ItemLevel As String = "400"
    Private dm As DataManager
    Private VoyageData As TB_Voyage
    Private Vesseldata As TB_Vessels
    Private SofData As TB_SOFCollection
    Private FrmStatus As FormStatus = FormStatus.NoAction
    Private Ds As DataSet

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub FrmVoyage_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim TB As New DataTable("SOF")

        LockStatus(False)
        Me.Vessel.Enabled = True
        Me.VoyageNo.GeneralText.Enabled = True

        Me.Top = 0
        Me.Left = 0
        Me.GeneralForms.InitControl("VOYAGE DATA", ItemLevel)

        Me.Vessel.InitControl(My.Settings.MainColor)

        With VoyageNo
            .SetLength(15)
            .AutoComplete = True
            .AutoCompleteTableName = "TB_Voyage"
            .AutoCompleteColumnName = "VoyageNo"
        End With
 

        Me.Service.InitControl("SV", UserComboCode.ShowCoumn.StdCode)
        Me.Carrier.InitControl("CR", UserComboCode.ShowCoumn.StdCode)
        Me.StartDate.InitControl(False, False)
        Me.ExchangeFrt.InitControl(6, 2)
        Me.ExchangeThc.InitControl(6, 2)
        Me.VoyageAccount.SetLength(25)
        Me.TFCCode.SetLength(15)
        Me.GroupBox.Appearance.BackColor = My.Settings.MainColor
        ChangeControlColor(Me.GroupBox, UltraLabel1.GetType.ToString, My.Settings.MainColor, My.Settings.LableForeColor)

        FrmStatus = FormStatus.NoAction
        General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)

        Ds = New DataSet
        With TB
            TB.Columns.Add(New DataColumn("ID", System.Type.GetType("System.Guid")))
            TB.Columns.Add(New DataColumn("VoyageID", System.Type.GetType("System.Guid")))
            TB.Columns.Add(New DataColumn("Port", System.Type.GetType("System.String")))
            Ds.Tables.Add(TB)
        End With

    End Sub

    Private Sub LockStatus(ByVal Status As Boolean) Implements IFGeneral.LockStatus
        General.LockControls(Me, Status)
        Me.Vessel.CmbVessel.Enabled = True

    End Sub

    Private Sub SendDataToClass() Implements IFGeneral.SendDataToClass

        If FrmStatus = FormStatus.NewRecord Then
            VoyageData = dm.NewTB_Voyage(Me.VoyageNo.TextValue, "", Now, Vesseldata)
            VoyageData.ID = System.Guid.NewGuid
            VoyageData.VoyageNo = Me.VoyageNo.TextValue
            If Me.Service.Code <> "" Then
                VoyageData.Service = Me.Service.Code
            Else
                VoyageData.Service = ""
            End If
            VoyageData.Carrier = Me.Carrier.Code
            VoyageData.ExchangeFrt = Double.Parse(Me.ExchangeFrt.GnrlNum.Value)
            VoyageData.ExchangeThc = Double.Parse(Me.ExchangeThc.GnrlNum.Value)
            VoyageData.VoyageAccount = Me.VoyageAccount.TextValue
            VoyageData.StartDate = Me.StartDate.DateValue
            VoyageData.TFCCode = Me.TFCCode.TextValue

        Else
            VoyageData.VoyageNo = Me.VoyageNo.TextValue
            VoyageData.Service = Me.Service.Code
            VoyageData.Carrier = Me.Carrier.Code
            VoyageData.StartDate = Me.StartDate.DateValue
            VoyageData.ExchangeFrt = Double.Parse(Me.ExchangeFrt.GnrlNum.Value)
            VoyageData.ExchangeThc = Double.Parse(Me.ExchangeThc.GnrlNum.Value)
            VoyageData.VoyageAccount = Me.VoyageAccount.TextValue
            VoyageData.TFCCode = Me.TFCCode.TextValue
        End If

        'SofData = VoyageData.TB_SOFs

        'If SofData.Count = 0 Then
        '    Sof = dm.NewTB_SOF(Me.Port.PortCode, VoyageData)
        '    Sof.VoyageID = VoyageData.ID
        '    VoyageData.TB_SOFs.Add(Sof)
        'End If

        'With VoyageData.TB_SOFs(0)

        '    .Port = Me.Port.PortCode
        '    .Arrival = IIf(Me.Arrival.DateValue Is Nothing, SqlTypes.SqlDateTime.Null, Me.Arrival.GetSqlDateTime)
        '    .Pilot = IIf(Me.Pilot.DateValue Is Nothing, SqlTypes.SqlDateTime.Null, Me.Pilot.GetSqlDateTime)
        '    .ETA = IIf(Me.ETA.DateValue Is Nothing, SqlTypes.SqlDateTime.Null, Me.ETA.GetSqlDateTime)
        '    .Berthed = IIf(Me.Berthed.DateValue Is Nothing, SqlTypes.SqlDateTime.Null, Me.Berthed.GetSqlDateTime)
        '    .Jetty = Int16.Parse(Me.Jetty.GnrlNum.Value)
        '    .FreePraGrnt = IIf(Me.FreePraGrnt.DateValue Is Nothing, SqlTypes.SqlDateTime.Null, Me.FreePraGrnt.GetSqlDateTime)
        '    .CustomInspect = IIf(Me.CustomInspect.DateValue Is Nothing, SqlTypes.SqlDateTime.Null, Me.CustomInspect.GetSqlDateTime)
        '    .GangOnBoard = IIf(Me.GangOnBoard.DateValue Is Nothing, SqlTypes.SqlDateTime.Null, Me.GangOnBoard.GetSqlDateTime)
        '    .DschCmnc = IIf(Me.DschCmnc.DateValue Is Nothing, SqlTypes.SqlDateTime.Null, Me.DschCmnc.GetSqlDateTime)
        '    .DschCmpl = IIf(Me.DschCmpl.DateValue Is Nothing, SqlTypes.SqlDateTime.Null, Me.DschCmpl.GetSqlDateTime)
        '    .LoadCmnc = IIf(Me.LoadCmnc.DateValue Is Nothing, SqlTypes.SqlDateTime.Null, Me.LoadCmnc.GetSqlDateTime)
        '    .LoadCmpl = IIf(Me.LoadCmpl.DateValue Is Nothing, SqlTypes.SqlDateTime.Null, Me.LoadCmpl.GetSqlDateTime)
        '    .DocOnBoard = IIf(Me.DocOnBoard.DateValue Is Nothing, SqlTypes.SqlDateTime.Null, Me.DocOnBoard.GetSqlDateTime)
        '    .PClear = IIf(Me.PClear.DateValue Is Nothing, SqlTypes.SqlDateTime.Null, Me.PClear.GetSqlDateTime)
        '    .Unberthed = IIf(Me.Unberthed.DateValue Is Nothing, SqlTypes.SqlDateTime.Null, Me.Unberthed.GetSqlDateTime)
        '    .Sailed = IIf(Me.Sailed.DateValue Is Nothing, SqlTypes.SqlDateTime.Null, Me.Sailed.GetSqlDateTime)
        '    .NextPort = Me.NextPort.PortCode

        '    .IFOArrival = SqlTypes.SqlDouble.Parse(Me.IFOArrival.GnrlNum.Value)
        '    .MDOArrival = SqlTypes.SqlDouble.Parse(Me.MDOArrival.GnrlNum.Value)
        '    .FWaterArrival = SqlTypes.SqlDouble.Parse(Me.MDOArrival.GnrlNum.Value)

        '    .IFOSup = SqlTypes.SqlDouble.Parse(Me.IFOSup.GnrlNum.Value)
        '    .MDOSup = SqlTypes.SqlDouble.Parse(Me.MDOSup.GnrlNum.Value)
        '    .FWaterSup = SqlTypes.SqlDouble.Parse(Me.FWaterSup.GnrlNum.Value)

        '    .IFODep = SqlTypes.SqlDouble.Parse(Me.IFODep.GnrlNum.Value)
        '    .MDOSup = SqlTypes.SqlDouble.Parse(Me.MDOSup.GnrlNum.Value)
        '    .FWaterDep = SqlTypes.SqlDouble.Parse(Me.FWaterDep.GnrlNum.Value)

        'End With

    End Sub

    Private Sub Populate() Implements IFGeneral.Populate

        Dim Dr As DataRow
        Dim NewDr As DataRow

        Me.Service.Code = VoyageData.Service
        Me.Carrier.Code = VoyageData.Carrier
        Me.StartDate.DateValue = VoyageData.StartDate
        Me.ExchangeFrt.GnrlNum.Value = Double.Parse(VoyageData.ExchangeFrt)
        Me.ExchangeThc.GnrlNum.Value = Double.Parse(VoyageData.ExchangeThc)
        Me.VoyageAccount.TextValue = NullToValue(VoyageData.VoyageAccount, "")
        Me.TFCCode.TextValue = NullToValue(VoyageData.TFCCode, "")

        Me.Ds.Tables("SOF").Clear()
        For Each Dr In dm.DataSet.Tables("TB_SOF").Rows
            If Dr.RowState <> DataRowState.Deleted Then
                NewDr = Ds.Tables("SOF").NewRow
                NewDr("Port") = GetPortNameByCode(Dr("Port"))
                NewDr("ID") = Dr("ID")
                NewDr("VoyageID") = Dr("VoyageID")
                Me.Ds.Tables("SOF").Rows.Add(NewDr)
            End If
        Next
        Me.GridSof.DataSource = Ds.Tables("SOF")
        Me.GridSof.DisplayLayout.Bands(0).Columns("ID").Hidden = True
        Me.GridSof.DisplayLayout.Bands(0).Columns("VoyageID").Hidden = True
        Me.GridSof.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn


    End Sub

    'For ILS Shortcuts: Changed from Private Sub GeneralForms_CustomFindClick() Handles GeneralForms.CustomFindClick to GeneralForms_CustomFindClick(ByVal sender As Object, ByVal formId As Integer)
    Public Sub GeneralForms_CustomFindClick(ByVal sender As Object, ByVal formId As Integer)

        If (Me.GeneralForms.getItemLevel(Me.GeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts  

            Dim DummyVoy As String
            Dim DummyID As Guid


            FrmStatus = FormStatus.NoAction

            '    Me.SOFGroup.Enabled = False


            dm = New DataManager(My.Settings.DSN)
            Me.Ds.Tables("SOF").Clear()
            If Me.Vessel.VesselID.ToString = "" Or Me.Vessel.VesselID = System.Guid.Empty Then
                MsgBoxGeneral("Please Fill Vessel Code & Voyage No !", "Error")
                Exit Sub
            End If

            If Me.VoyageNo.TextValue = "" Then
                MsgBoxGeneral("Please Fill Vessel Code & Voyage No !", "Error")
                Exit Sub
            End If
            dm.QueryCriteria.Clear()
            dm.QueryCriteria.And(JoinPath.TB_Vessels.Columns.ID, Me.Vessel.VesselID, MatchType.Exact)

            Vesseldata = dm.GetTB_Vessels()
            If Vesseldata Is Nothing Then
                MsgBoxGeneral("Invalid Vessel Code !", "Vessel")
            End If

            dm.QueryCriteria.Clear()
            dm.QueryCriteria.And(JoinPath.TB_Voyage.Columns.VesselID, Vesseldata.ID, MatchType.Exact)
            dm.QueryCriteria.And(JoinPath.TB_Voyage.Columns.VoyageNo, Me.VoyageNo.TextValue, MatchType.Exact)
            VoyageData = dm.GetTB_Voyage(FetchPath.TB_Voyage.TB_SOF)

            If Not VoyageData Is Nothing Then
                If Not VoyageData.TB_SOFs Is Nothing Then
                    SofData = VoyageData.TB_SOFs
                End If
            End If
            If VoyageData Is Nothing Then
                MsgBoxGeneral("Invalid Voyage No !", "Voyage")
                DummyID = Me.Vessel.VesselID
                DummyVoy = Me.VoyageNo.TextValue
                ClearControl(Me)
                Me.Vessel.VesselID = DummyID
                Me.VoyageNo.TextValue = DummyVoy
                FrmStatus = FormStatus.NoAction
            Else
                Populate()
                FrmStatus = FormStatus.HasData
            End If

            FrmStatus = FormStatus.HasData
            General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)

            LockStatus(False)
            Me.Vessel.Enabled = True
            Me.VoyageNo.GeneralText.Enabled = True
        End If

    End Sub

    'For ILS Shortcuts: Changed from Private Sub GeneralForms_CustomNewClick() Handles GeneralForms.CustomNewClick
    Public Sub GeneralForms_CustomNewClick(ByVal sender As Object, ByVal formId As Integer)

        If (Me.GeneralForms.getItemLevel(Me.GeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts
            If dm Is Nothing Then
                dm = New DataManager(My.Settings.DSN)
            End If
            dm.QueryCriteria.Clear()
            ClearControl(Me)
            LockStatus(True)

            FrmStatus = FormStatus.NewRecord
            General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FormStatus.NewRecord)
        End If

    End Sub


    'For ILS Shortcuts: Changed from Private Sub GeneralForms_CustomSaveClick() Handles GeneralForms.CustomSaveClick
    Public Sub GeneralForms_CustomSaveClick(ByVal sender As Object, ByVal formId As Integer)
        If (Me.GeneralForms.getItemLevel(Me.GeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts
            Dim LogDataSet As New DataSet

            If ValidateForm() = False Then
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
    'For ILS Shortcuts Changed from Private Sub GeneralForms_CustomEditClick() Handles GeneralForms.CustomEditClick
    Public Sub GeneralForms_CustomEditClick(ByVal sender As Object, ByVal formId As Integer)

        If (Me.GeneralForms.getItemLevel(Me.GeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts

            LockStatus(True)

            FrmStatus = FormStatus.EditRecord
            General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FormStatus.EditRecord)
        End If

    End Sub

    'For ILS Shortcuts Changed from Private Sub GeneralForms_CustomDeleteClick() Handles GeneralForms.CustomDeleteClick
    Public Sub GeneralForms_CustomDeleteClick(ByVal sender As Object, ByVal formId As Integer)

        If (Me.GeneralForms.getItemLevel(Me.GeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts

            Dim LogDataSet As New DataSet

            If ValidateForm() = False Then
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

    Private Sub GeneralForms_CustomHomeClick() Handles GeneralForms.CustomHomeClick
        Me.Close()
    End Sub

    Private Function ValidateForm() As Boolean

        If Me.Vessel.VesselID.ToString = "" Or Me.Vessel.VesselID = Guid.Empty Then
            MsgBoxGeneral("Please Fill Vessel Code & Voyage No !", "Error")
            Return False
        End If

        dm.QueryCriteria.Clear()
        dm.QueryCriteria.And(JoinPath.TB_Vessels.Columns.ID, Me.Vessel.VesselID, MatchType.Exact)
        Vesseldata = dm.GetTB_Vessels()

        If Vesseldata Is Nothing Then
            MsgBoxGeneral("Invalid Vessel Code !", "Vessel")
            Return False
        End If

        'dm.QueryCriteria.Clear()
        'dm.QueryCriteria.And(JoinPath.TB_Voyage.Columns.VesselID, Vesseldata.ID, MatchType.Exact)
        'dm.QueryCriteria.And(JoinPath.TB_Voyage.Columns.VoyageNo, Me.VoyageNo.TextValue, MatchType.Exact)
        'VoyageData = dm.GetTB_Voyage(FetchPath.TB_Voyage.TB_SOF)

        If VoyageData Is Nothing Then
            FrmStatus = FormStatus.NewRecord
        Else
            FrmStatus = FormStatus.HasData
        End If

        Return True

    End Function

    Private Sub ButtonSofNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSofNew.Click
        Dim Dr As DataRow
        Dim NewDr As DataRow

        If IsNothing(VoyageData) Then
            Exit Sub
        End If
        Dim Frm As New FrmSof(FrmSof.FormStatus.NewSof, dm.DataSet.Tables("TB_SOF"), VoyageData.ID, Guid.Empty)
        Frm.ShowDialog()
        Me.Ds.Tables("SOF").Clear()
        For Each Dr In dm.DataSet.Tables("TB_SOF").Rows
            If Dr.RowState <> DataRowState.Deleted Then
                NewDr = Ds.Tables("SOF").NewRow
                NewDr("Port") = GetPortNameByCode(Dr("Port"))
                NewDr("ID") = Dr("ID")
                NewDr("VoyageID") = Dr("VoyageID")
                Me.Ds.Tables("SOF").Rows.Add(NewDr)
            End If
        Next

    End Sub

    Private Sub ButtonSofEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSofEdit.Click

        Dim Dr As DataRow
        Dim NewDr As DataRow
        Dim Frm As FrmSof
        If Me.GridSof.Rows.Count = 0 Then
            Exit Sub
        End If
        Frm = New FrmSof(FrmSof.FormStatus.EditSoft, dm.DataSet.Tables("TB_SOF"), VoyageData.ID, Me.GridSof.ActiveRow.Cells("ID").Value)

        Frm.ShowDialog()
        Me.Ds.Tables("SOF").Clear()
        For Each Dr In dm.DataSet.Tables("TB_SOF").Rows
            If Dr.RowState <> DataRowState.Deleted Then
                NewDr = Ds.Tables("SOF").NewRow
                NewDr("Port") = GetPortNameByCode(Dr("Port"))
                NewDr("ID") = Dr("ID")
                NewDr("VoyageID") = Dr("VoyageID")
                Me.Ds.Tables("SOF").Rows.Add(NewDr)
            End If
        Next

    End Sub

    Private Sub ButtonDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDelete.Click

        Dim Drs() As DataRow
        Dim Dr As DataRow
        Dim ID As Guid
        Dim Newdr As DataRow

        If Me.GridSof.Rows.Count = 0 Then
            Exit Sub
        End If

        ID = Me.GridSof.ActiveRow.Cells("ID").Value
        Drs = dm.DataSet.Tables("TB_SOF").Select("ID = '" & ID.ToString & "'")
        If Drs.Length > 0 Then
            Drs(0).Delete()
        End If

        Me.Ds.Tables("SOF").Clear()
        For Each Dr In dm.DataSet.Tables("TB_SOF").Rows
            If Dr.RowState <> DataRowState.Deleted Then
                Newdr = Ds.Tables("SOF").NewRow
                Newdr("Port") = GetPortNameByCode(Dr("Port"))
                Newdr("ID") = Dr("ID")
                Newdr("VoyageID") = Dr("VoyageID")
                Me.Ds.Tables("SOF").Rows.Add(Newdr)
            End If
        Next

    End Sub

    Private Sub Vessel_CustomVesselChanged() Handles Vessel.CustomVesselChanged
        Me.VoyageNo.AutoCompleteExtraWhere = "VesselID = '" & Me.Vessel.VesselID.ToString & "'"
    End Sub

End Class