Imports System.Windows.Forms
Imports OrmLib
Imports ShippingBiz


Public Class FrmDOPrint

    Private BL As TB_InwardBLS
    Private Names As TB_InwardBlsNames
    Private dm As DataManager
    Private St As TB_InwardStatus
    Private IsReprint As Boolean

    Private Sub FrmDOPrint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.DoDate.InitControl(False, False)
        'Me.DoOffice.InitControl("OF", UserComboCode.ShowCoumn.Meaning, "Y")
        Me.DoOffice.InitControl("OF", UserComboCode.ShowCoumn.Meaning)

        dm = New DataManager(My.Settings.DSN)
        dm.QueryCriteria.And(JoinPath.TB_InwardBlsNames.Columns.BLID, BL.ID, MatchType.Exact)
        Names = dm.GetTB_InwardBlsNames

        If Not Names Is Nothing Then
            Me.LabelCnee.Text = Names.Cnee
            Me.LabelNotify1.Text = Names.Notify1
            Me.LabelNotify2.Text = Names.Notify2
            Me.LabelShortCnee.Text = Names.Messers
        End If

        dm = New DataManager(My.Settings.DSN)
        dm.QueryCriteria.And(JoinPath.TB_InwardStatus.Columns.BLID, BL.ID, MatchType.Exact)
        St = dm.GetTB_InwardStatus

        If Not St Is Nothing Then
            DoOffice.Code = St.DoOffice
            If Mid(St.DoDate.ToString, 1, 10) = "01/01/1900" Then
                DoDate.DateValue = Now
            Else
                DoDate.DateValue = St.DoDate
            End If
            If NullToValue(St.DoOffice, "") <> "" And Boolean.Parse(CurrentUser.IsDocAdmin) = False Then
                Me.MenuItem.ShowSave = False
                Me.DoOffice.Enabled = False
                Me.DoDate.Enabled = False
            End If
        Else
            DoDate.GnrlDate.Value = Now
            DoOffice.Code = My.Settings.Office
        End If

        Me.RadioShortCnee.Checked = True
 
    End Sub

    Public Sub New(ByVal BL As TB_InwardBLS, ByVal IsReprint As Boolean)

        InitializeComponent()
        Me.BL = BL
        Me.IsReprint = IsReprint

    End Sub

    Private Sub MenuItem_CustomPrintClick() Handles MenuItem.CustomPrintClick

        Dim Rpt As New RptDO
        Dim Frm As New FrmGeneralReportShow
        Dim Tb As DataTable
        Dim Dr As DataRow
        Dim GoodsList As New ArrayList
        Dim CntrsList As New ArrayList
        Dim sDummy As String
        Dim Ds As New DataSet
        Dim Mem As New CLMemo
        Dim nJ, nI As Long
        Dim Dv As DataView
        Dim Cmd As New SqlClient.SqlCommand
        Dim Ans As Boolean
        Dim IsTIP As Boolean = False
        Dim DsCns As DataSet
        Dim DsImco As DataSet
        Dim TTLPkgs As Long
        Dim BlRow As DataRow
        Dim SCnee As String = ""
        Dim LogDataSet As New DataSet
        Dim AlsoSave As Boolean
        Dim Port As TB_Ports
        Dim Validity As String
        Dim Cns As TB_InwardCntrsCollection
        Dim Ecs As TB_EcsContainers
        Dim Mov As TB_EcsMoves
        Dim Cn As TB_InwardCntrs


        If Me.DoOffice.Code = "" Then
            MsgBox("No Office Assigned !")
            Exit Sub
        End If

        Cmd.CommandText = "Select dbo.FC_IsPaidTIPCharge('" & BL.ID.ToString & "')"
        Cmd.CommandType = CommandType.Text
        GenerateDs(Ds, Cmd, Ans)
        If Ans = True Then
            If Not Ds.Tables(0) Is Nothing Then
                IsTIP = NullToValue(Ds.Tables(0).Rows(0).Item(0), False)
            End If
        End If

        Tb = New DataTable
        Tb.Columns.Add(New DataColumn("BlNo", System.Type.GetType("System.String")))
        Tb.Columns.Add(New DataColumn("Vessel", System.Type.GetType("System.String")))
        Tb.Columns.Add(New DataColumn("Voyage", System.Type.GetType("System.String")))
        Tb.Columns.Add(New DataColumn("Arrival", System.Type.GetType("System.DateTime")))
        Tb.Columns.Add(New DataColumn("Cnee", System.Type.GetType("System.String")))
        Tb.Columns.Add(New DataColumn("FPOD", System.Type.GetType("System.String")))
        Tb.Columns.Add(New DataColumn("Seq", System.Type.GetType("System.Int16")))
        Tb.Columns.Add(New DataColumn("Cntrs", System.Type.GetType("System.String")))
        Tb.Columns.Add(New DataColumn("SealNo", System.Type.GetType("System.String")))
        Tb.Columns.Add(New DataColumn("Goods", System.Type.GetType("System.String")))
        Tb.Columns.Add(New DataColumn("Tw", System.Type.GetType("System.Int32")))
        Tb.Columns.Add(New DataColumn("GW", System.Type.GetType("System.Double")))

        DsImco = StoredProcedures.SP_GetInwardImcoByBLID(BL.ID.ToString)
        DsCns = StoredProcedures.SP_InwardCnsList(BL.ID.ToString)
        Ds = StoredProcedures.SP_PrintInwardBls(CurrentShippingLine, BL.BlNo, "Y", "Y")

        BlRow = Ds.Tables(0).Rows(0)

        dm.QueryCriteria.Clear()
        If NullToValue(BlRow("POD"), "") <> "" Then
            dm.QueryCriteria.And(JoinPath.TB_Ports.Columns.PortName, BlRow("POD"), MatchType.Exact)
        Else
            dm.QueryCriteria.And(JoinPath.TB_Ports.Columns.PortName, BlRow("FPOD"), MatchType.Exact)
        End If

        Port = dm.GetTB_Ports
        BlRow("POD") = Port.FPortName

        sDummy = ""
        If Not DsImco Is Nothing Then
            If DsImco.Tables(0).Rows.Count > 0 Then
                sDummy = "UN NO." & DsImco.Tables(0).Rows(0).Item("UNNO") & vbCrLf & _
                         "IMDG" & DsImco.Tables(0).Rows(0).Item("IMDGCode") & vbCrLf
            End If
            sDummy += vbCrLf
        End If

        sDummy += GetInwardTotalCntrs(BL.ID)
        Mem.GetFree(sDummy, GoodsList, 20)
        For nI = 0 To GoodsList.Count - 1
            nJ += 1
            Dr = Tb.NewRow
            Dr("BLNO") = BlRow("BLNO")
            Dr("Cnee") = BlRow("Cnee")
            Dr("Arrival") = BlRow("Arrival")
            Dr("FPOD") = BlRow("POD")
            Dr("Vessel") = BlRow("Vessel")
            Dr("Voyage") = BlRow("Voyage")
            Dr("Cntrs") = GoodsList(nI)
            Dr("Seq") = nJ
            Tb.Rows.Add(Dr)
        Next

        GoodsList = New ArrayList
        Mem = New CLMemo
        Mem.GetFree(Ds.Tables(0).Rows(0).Item("Goods"), GoodsList, 40)

        For nI = 0 To GoodsList.Count - 1
            Dv = New DataView(Tb, "Seq = " & nI + 1, "", DataViewRowState.CurrentRows)
            If Dv.Count = 0 Then
                nJ += 1
                Dr = Tb.NewRow
                Dr("BLNO") = BlRow("BLNO")
                Dr("Cnee") = BlRow("Cnee")
                Dr("Arrival") = BlRow("Arrival")
                Dr("FPOD") = BlRow("POD")
                Dr("Vessel") = BlRow("Vessel")
                Dr("Voyage") = BlRow("Voyage")
                Dr("Goods") = GoodsList(nI)
                Dr("Seq") = nJ
                Tb.Rows.Add(Dr)
            Else
                Dv.Item(0).Item("Goods") = GoodsList(nI)
            End If
        Next

        nJ += 1
        Dr = Tb.NewRow
        Dr("Seq") = nJ
        Tb.Rows.Add(Dr)

        For Each OldDr As DataRow In DsCns.Tables(0).Rows
            nJ += 1
            Dr = Tb.NewRow
            Dr("BLNO") = BlRow("BLNO")
            Dr("Cnee") = BlRow("Cnee")
            Dr("Arrival") = BlRow("Arrival")
            Dr("FPOD") = BlRow("POD")
            Dr("Vessel") = BlRow("Vessel")
            Dr("Voyage") = BlRow("Voyage")
            Dr("Seq") = nJ
            Dr("Cntrs") = OldDr("Cntrs")
            Dr("SealNo") = OldDr("SealNo")
            Dr("Goods") = OldDr("Goods")
            Dr("TW") = OldDr("TW")
            Dr("GW") = OldDr("GW")
            Tb.Rows.Add(Dr)
        Next

        GoodsList = New ArrayList
        Mem = New CLMemo
        sDummy = GetInwardTotalPKGS(BL.ID)
        Mem.GetFree(sDummy, GoodsList, 20)

        For nI = 0 To GoodsList.Count - 1
            TTLPkgs += Val(GoodsList(nI))
        Next
        nJ += 1
        Dr = Tb.NewRow
        Dr("Goods") = "Total Packages:" & TTLPkgs.ToString
        Dr("Seq") = nJ
        Tb.Rows.Add(Dr)

        If RadioCnee.Checked = True Then
            SCnee = LabelCnee.Text
        ElseIf RadioNotify1.Checked = True Then
            SCnee = LabelNotify1.Text
        ElseIf RadioNotify2.Checked = True Then
            SCnee = LabelNotify2.Text
        ElseIf RadioShortCnee.Checked = True Then
            SCnee = LabelShortCnee.Text
        End If

        If SCnee <> "" Then
            For Each Dr In Tb.Rows
                Dr("Cnee") = SCnee
            Next
        End If


        If IsTIP = True And Me.ShowTIP.Checked = True Then
            Rpt.Section5.ReportObjects("TextTIP").ObjectFormat.EnableSuppress = False
            Rpt.Section5.ReportObjects("TIPCrash").ObjectFormat.EnableSuppress = True
        Else
            Rpt.Section5.ReportObjects("TextTIP").ObjectFormat.EnableSuppress = True
            Rpt.Section5.ReportObjects("TIPCrash").ObjectFormat.EnableSuppress = False
        End If

        For Each Dr In Tb.Rows
            If Not IsDBNull(Dr("Goods")) Then
                Dr("Goods") = Replace(Dr("Goods") & "", vbCrLf, " ")
                Dr("Goods") = Replace(Dr("Goods") & "", vbLf, " ")
            End If
        Next

        If IsReprint = True Then
            If MsgBox("Do You Want To Save Date Also ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                AlsoSave = True
            Else
                AlsoSave = False
            End If
        Else
            AlsoSave = True
        End If

        If AlsoSave = True Then
            dm = New DataManager(My.Settings.DSN)
            dm.QueryCriteria.And(JoinPath.TB_InwardStatus.Columns.BLID, BL.ID, MatchType.Exact)
            St = dm.GetTB_InwardStatus
            If St Is Nothing Then
                Dr = dm.DataSet.Tables("TB_InwardStatus").NewRow
                Dr("ID") = System.Guid.NewGuid
                Dr("BLID") = BL.ID
                Dr("DoDate") = Me.DoDate.DateValue
                Dr("DoOffice") = Me.DoOffice.Code
                dm.DataSet.Tables("TB_InwardStatus").Rows.Add(Dr)

            Else
                If NullToValue(St.DoOffice, "") = "" Or Boolean.Parse(CurrentUser.IsDocAdmin) = True Then
                    St.DoDate = Me.DoDate.DateValue
                    St.DoOffice = Me.DoOffice.Code
                End If
            End If

            'If NullToValue(BL.IssueFU, False).ToString = "True" Or NullToValue(BL.IssueFU, False).ToString = "Null" Then
            '    dm.QueryCriteria.Clear()
            '    dm.QueryCriteria.And(JoinPath.TB_InwardCntrs.Columns.BLID, BL.ID)
            '    Cns = dm.GetTB_InwardCntrsCollection
            '    For Each Cn In Cns
            '        dm.QueryCriteria.Clear()
            '        dm.QueryCriteria.And(JoinPath.TB_EcsContainers.Columns.CntrNo, Cn.CntrNo, MatchType.Exact)
            '        dm.QueryCriteria.And(JoinPath.TB_EcsContainers.Columns.InVoyageID, BL.VoyageID, MatchType.Exact)
            '        Ecs = dm.GetTB_EcsContainers
            '        If Not Ecs Is Nothing Then
            '            If Ecs.LastStatus = "FV" Or Ecs.LastStatus = "CV" Or Ecs.LastStatus = "TV" Then
            '                Ecs.LastStatus = IIf(Ecs.SOC = "Y", "FS", "FU")
            '                Ecs.LastStatusDate = Now()
            '                dm.QueryCriteria.Clear()
            '                Mov = dm.NewTB_EcsMoves(Ecs)
            '                Mov.Status = "FU"
            '                Mov.StatusDate = Now()
            '                Mov.StatusDateToLine = Now()
            '                Mov.Remarks = "Added at D.O. Time"
            '                Mov.IsReported = False
            '                Mov.Depot = Ecs.LastDepot

            '            End If
            'End If
            'Next
            'End If
            LogDataSet = dm.DataSet.Copy
            dm.CommitAll()
            GenerateLog(LogDataSet)
        End If

        Tb.AcceptChanges()
        Validity = ToPersianDate(DateAdd(DateInterval.Day, 15, Now))
        Rpt.SetDataSource(Tb)
        Rpt.SetParameterValue(0, Validity)
        Rpt.SetParameterValue(1, CurrentShippingLine & "-" & Ds.Tables(0).Rows(0).Item("Reference"))
        Frm.ReportViewer.ReportSource = Rpt
        Frm.Show()

    End Sub

    Private Sub MenuItem_CustomSaveClick() Handles MenuItem.CustomSaveClick

        Dim aError As New ArrayList
        Dim nI As Byte
        Dim LogDataSet As New DataSet
        Dim Dr As DataRow
        Dim Cns As TB_InwardCntrsCollection
        Dim Ecs As TB_EcsContainers
        Dim Mov As TB_EcsMoves
        Dim Cn As TB_InwardCntrs
        Dim IssueFU As Boolean

        FormErrorProvider.Clear()

        If Me.DoOffice.Code = "" Then
            aError.Add(Me.DoOffice)
        End If

        If Me.DoDate.GnrlDate.Value Is Nothing Then
            aError.Add(Me.DoDate)
        End If

        If aError.Count > 0 Then
            If aError.Count > 0 Then
                For nI = 0 To aError.Count - 1
                    FormErrorProvider.SetError(aError(nI), "Data Requird")
                Next
                MsgBoxValidateFaild()
                Return
            End If
        End If

        dm = New DataManager(My.Settings.DSN)
        dm.QueryCriteria.And(JoinPath.TB_InwardStatus.Columns.BLID, BL.ID, MatchType.Exact)
        St = dm.GetTB_InwardStatus
        If St Is Nothing Then
            Dr = dm.DataSet.Tables("TB_InwardStatus").NewRow
            Dr("ID") = System.Guid.NewGuid
            Dr("BLID") = BL.ID
            Dr("DoDate") = Me.DoDate.DateValue
            Dr("DoOffice") = Me.DoOffice.Code
            dm.DataSet.Tables("TB_InwardStatus").Rows.Add(Dr)
        Else
            St.DoDate = Me.DoDate.DateValue
            St.DoOffice = Me.DoOffice.Code
        End If
        
        if BL.IssueFU  = true then
            IssueFU = NullToValue(Boolean.Parse(BL.IssueFU), True)
        end if 

        If IssueFU = True Then
            dm.QueryCriteria.Clear()
            dm.QueryCriteria.And(JoinPath.TB_InwardCntrs.Columns.BLID, BL.ID)
            Cns = dm.GetTB_InwardCntrsCollection
            For Each Cn In Cns
                dm.QueryCriteria.Clear()
                dm.QueryCriteria.And(JoinPath.TB_EcsContainers.Columns.CntrNo, Cn.CntrNo, MatchType.Exact)
                dm.QueryCriteria.And(JoinPath.TB_EcsContainers.Columns.InVoyageID, BL.VoyageID, MatchType.Exact)
                Ecs = dm.GetTB_EcsContainers
                If Not Ecs Is Nothing Then
                    If Ecs.LastStatus = "FV" Or Ecs.LastStatus = "CV" Or Ecs.LastStatus = "TV" Then
                        Ecs.LastStatus = IIf(Ecs.SOC = "Y", "FS", "FU")
                        Ecs.LastStatusDate = Now()
                        dm.QueryCriteria.Clear()
                        Mov = dm.NewTB_EcsMoves(Ecs)
                        Mov.Status = "FU"
                        Mov.StatusDate = Now()
                        Mov.StatusDateToLine = Now()
                        Mov.Remarks = "Added at D.O. Time"
                        Mov.IsReported = False
                        Mov.Depot = Ecs.LastDepot
                    End If
                End If
            Next
        End If

        Try
            LogDataSet = dm.DataSet.Copy
            dm.CommitAll()
            GenerateLog(LogDataSet)
            MsgBoxSaveSuccessful()
        Catch ex As Exception
            MsgBoxSaveFailed()
        End Try

    End Sub

   
    Private Sub MenuItem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem.Load

    End Sub
End Class
