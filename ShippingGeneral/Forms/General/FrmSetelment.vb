Imports OrmLib
Imports ShippingBiz

Public Class FrmSetelment

    Private ItemLevel As String = "302"
    Private FrmStatus As FormStatus
    Private dm As DataManager
    Private InwradStatus As TB_InwardStatus
    Private BL As TB_InwardBLS
    Private ID As Guid
    Private Sub FrmSetelment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.GeneralForms.InitControl("Setelment", ItemLevel)
        Me.Left = 0
        Me.Top = 1

        Me.Label1.BackColor = My.Settings.MainColor
        Me.Label2.BackColor = My.Settings.MainColor
        Me.Label3.BackColor = My.Settings.MainColor
        Me.Label4.BackColor = My.Settings.MainColor
        Me.Label5.BackColor = My.Settings.MainColor

        Me.Detention.InitControl(12, 0)
        Me.Discount.InitControl(12, 0)
        Me.InvoiceToCarrier.InitControl(12, 0)
        Me.InvoiceToClient.InitControl(12, 0)
        Me.SetelmetDate.InitControl(False, False)
        FrmStatus = FormStatus.NoAction

        General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)

        LockStatus(False)

        ChangeControlColor(Me.GroupBox, Me.Label1.GetType.ToString, My.Settings.MainColor, My.Settings.LableForeColor)
        Me.GroupBox.Appearance.BackColor = My.Settings.MainColor
        Me.GroupBox.Appearance.BackColor2 = My.Settings.MainColor2


    End Sub

    Private Sub LockStatus(ByVal Status As Boolean)

        Me.SetelmetDate.Enabled = Status
        Me.Detention.Enabled = Status
        Me.Discount.Enabled = Status
        Me.InvoiceToClient.Enabled = Status
        Me.InvoiceToCarrier.Enabled = Status
       

    End Sub

    Private Sub GroupBox_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles GroupBox.Paint
        Dim Ctl As Control
        For Each Ctl In GroupBox.Controls
            If TypeOf Ctl Is Windows.Forms.Label Then
                DrawTransParentLabel(Ctl, e)
            End If
        Next
    End Sub

    'Private Sub GeneralForms_CustomFindClick() Handles GeneralForms.CustomFindClick
    Public Sub GeneralForms_CustomFindClick(ByVal sender As Object, ByVal formId As Integer)

        If (Me.GeneralForms.getItemLevel(Me.GeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts 

            Dim sDummy As String = Me.BLNO.TextValue
            Dim Dr As DataRow
            Dim Invs As TB_InvoiceCollection
            Dim Inv As TB_Invoice
            Dim Dtls As TB_InvoiceDetailsCollection

            LBLInvoice.Text = ""
            LBLIssue.Text = ""

            ClearControl(Me)
            Me.BLNO.TextValue = sDummy

            dm = New DataManager(My.Settings.DSN)
            dm.QueryCriteria.Clear()
            dm.QueryCriteria.And(JoinPath.TB_InwardBLS.Columns.Line, CurrentShippingLine, MatchType.Partial)
            dm.QueryCriteria.And(JoinPath.TB_InwardBLS.Columns.BlNo, Me.BLNO.TextValue, MatchType.Partial)
            BL = dm.GetTB_InwardBLS
            If BL Is Nothing Then
                MsgBox("No Valid B/L !")
                Exit Sub
            End If
            dm.QueryCriteria.Clear()
            dm.QueryCriteria.And(JoinPath.TB_Invoice.Columns.BLID, BL.ID, MatchType.Exact)
            dm.QueryCriteria.And(JoinPath.TB_Invoice.Columns.Status, "3", MatchType.Exact)
            Invs = dm.GetTB_InvoiceCollection
            For Each Inv In Invs
                dm.QueryCriteria.Clear()
                dm.QueryCriteria.And(JoinPath.TB_InvoiceDetails.Columns.InvoiceID, Inv.ID, MatchType.Exact)
                dm.QueryCriteria.And(JoinPath.TB_InvoiceDetails.Columns.ChargesCode, "DETN", MatchType.Exact)
                Dtls = dm.GetTB_InvoiceDetailsCollection
                If Dtls.Count > 0 Then
                    LBLInvoice.Text = Format(Inv.ConfirmTime.ToString, "Short Date")
                    LBLIssue.Text = Format(Inv.IssueTime.ToString, "Short Date")
                End If
            Next


            dm.QueryCriteria.Clear()
            dm.QueryCriteria.And(JoinPath.TB_InwardStatus.Columns.BLID, BL.ID, MatchType.Exact)
            InwradStatus = dm.GetTB_InwardStatus

            If InwradStatus Is Nothing Then
                FrmStatus = FormStatus.NoAction
                ID = Guid.NewGuid
                Me.LBLDO.Text = ""
                MsgBox("Settlement Not Found  !")

            Else
                Dr = dm.DataSet.Tables("TB_InwardStatus").Rows(0)
                ID = Dr("ID")
                Me.Discount.GnrlNum.Value = Dr("Discont")
                Me.Detention.GnrlNum.Value = Dr("Detention")
                Me.SetelmetDate.GnrlDate.Value = Dr("SetelmentDate")
                Me.InvoiceToClient.GnrlNum.Value = Dr("InvoiceToClinet")
                Me.InvoiceToCarrier.GnrlNum.Value = Dr("ReportToCarrier")
                Me.LBLDO.Text = Format(NullToValue(Dr("DoDate"), ""), "short date")
                FrmStatus = FormStatus.HasData
            End If

            Me.Refresh()
            General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)
            LockStatus(False)
        End If

    End Sub

    'For ILS Shortcuts: Changed from Private Sub GeneralForms_CustomNewClick() Handles GeneralForms.CustomNewClick
    Public Sub GeneralForms_CustomNewClick(ByVal sender As Object, ByVal formId As Integer)

        If (Me.GeneralForms.getItemLevel(Me.GeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts


            Dim sDummy As String = Me.BLNO.TextValue
            ClearControl(Me)
            Me.BLNO.Focus()
            Me.BLNO.TextValue = sDummy

            dm.QueryCriteria.Clear()
            dm.QueryCriteria.And(JoinPath.TB_InwardBLS.Columns.Line, CurrentShippingLine, MatchType.Partial)
            dm.QueryCriteria.And(JoinPath.TB_InwardBLS.Columns.BlNo, Me.BLNO.TextValue, MatchType.Partial)
            BL = dm.GetTB_InwardBLS

            If BL Is Nothing Then
                MsgBox("No Valid B/L !")
                Exit Sub
            End If

            Me.ID = System.Guid.NewGuid
            FrmStatus = FormStatus.NewRecord

            General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)
            LockStatus(True)
        End If

    End Sub

    'For ILS Shortcuts Changed from Private Sub GeneralForms_CustomEditClick() Handles GeneralForms.CustomEditClick
    Public Sub GeneralForms_CustomEditClick(ByVal sender As Object, ByVal formId As Integer)

        If (Me.GeneralForms.getItemLevel(Me.GeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts
            FrmStatus = FormStatus.EditRecord
            General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)
            LockStatus(True)
        End If

    End Sub

    'For ILS Shortcuts: Changed from Private Sub GeneralForms_CustomSaveClick() Handles GeneralForms.CustomSaveClick
    Public Sub GeneralForms_CustomSaveClick(ByVal sender As Object, ByVal formId As Integer)

        If (Me.GeneralForms.getItemLevel(Me.GeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts

            Dim Dr As DataRow
            Dim LogDataSet As New DataSet
            Dim Dv As DataView
            'If ValidateData() = False Then
            '    Exit Sub
            'End If

            If MsgBoxUpdate() <> Windows.Forms.DialogResult.Yes Then
                Exit Sub
            End If

            If dm Is Nothing Then
                dm = New DataManager(My.Settings.DSN)
            End If

            Try
                Dv = New DataView(dm.DataSet.Tables("TB_InwardStatus"), "ID = '" & ID.ToString & "'", "", DataViewRowState.CurrentRows)
                If Dv.Count = 0 Then
                    Dr = dm.DataSet.Tables("TB_InwardStatus").NewRow
                    Dr("ID") = ID
                    Dr("BLID") = BL.ID
                    Dr("Discont") = Me.Discount.GnrlNum.Value
                    Dr("Detention") = Me.Detention.GnrlNum.Value
                    Dr("SetelmentDate") = Me.SetelmetDate.GnrlDate.Value
                    Dr("InvoiceToClinet") = Me.InvoiceToClient.GnrlNum.Value
                    Dr("ReportToCarrier") = Me.InvoiceToCarrier.GnrlNum.Value
                    dm.DataSet.Tables("TB_InwardStatus").Rows.Add(Dr)
                Else
                    Dv.Item(0).Item("Discont") = Me.Discount.GnrlNum.Value
                    Dv.Item(0).Item("Detention") = Me.Detention.GnrlNum.Value
                    If Me.SetelmetDate.GnrlDate.Value Is Nothing Then
                        Dv.Item(0).Item("SetelmentDate") = DBNull.Value
                    Else
                        Dv.Item(0).Item("SetelmentDate") = Me.SetelmetDate.GnrlDate.Value
                    End If
                    Dv.Item(0).Item("InvoiceToClinet") = Me.InvoiceToClient.GnrlNum.Value
                    Dv.Item(0).Item("ReportToCarrier") = Me.InvoiceToCarrier.GnrlNum.Value
                End If
                LogDataSet = dm.DataSet.Copy
                dm.CommitAll()
                GenerateLog(LogDataSet)
                MsgBoxSaveSuccessful()
                GeneralForms_CustomFindClick(sender, formId)
                LockStatus(False)
            Catch ex As Exception
                General.MsgBoxSaveFailed()
                MessageBox.Show(ex.ToString)
            End Try
        End If

    End Sub

    Private Sub ButtonDTN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDTN.Click

        If BL Is Nothing Then
            Exit Sub
        End If

        ShowDetention(False)
    End Sub

    Private Sub ShowDetention(ByVal ForLine As Boolean)

        Dim Sum As CLInwardBlsSummary
        Dim Dtn As New CLDetention
        Dim BLID As Guid
        Dim ds As New DataSet
        Dim Report As RptInwardDetention
        Dim Frm As New FrmGeneralReportShow
        Dim PH As New CLPrintHdr
        Dim Dscnt As TB_InwardDiscount
        Dim sDscnt As String = ""
        Dim Col As DataColumn
        Dim Clnt As TB_Clients

        If BL.BlNo <> Me.BLNO.TextValue Then
            dm = New DataManager(My.Settings.DSN)
            dm.QueryCriteria.Clear()
            dm.QueryCriteria.And(JoinPath.TB_InwardBLS.Columns.Line, CurrentShippingLine, MatchType.Exact)
            dm.QueryCriteria.And(JoinPath.TB_InwardBLS.Columns.BlNo, Me.BLNO.TextValue, MatchType.Exact)
            BL = dm.GetTB_InwardBLS
            If BL Is Nothing Then
                MsgBox("No Valid B/L !")
                Exit Sub
            End If
        End If

        ds = StoredProcedures.SP_InwardBlsByLineBlNo(CurrentShippingLine, Me.BLNO.TextValue)

        If ds.Tables(0).Rows.Count = 0 Then
            MsgBoxGeneral("No valid B/L No ?", "Data Requird")
            Exit Sub
        End If
        Sum = New CLInwardBlsSummary(ds.Tables(0).Rows(0).Item("Id"))

        BLID = ds.Tables(0).Rows(0).Item("ID")

        If ForLine = True Then
            Dtn.GenerateImportDetention(BLID, True)
            ds = Dtn.CalDetention(Me.BLNO.TextValue, BLID, True)
        Else
            Dtn.GenerateImportDetention(BLID, False)
            ds = Dtn.CalDetention(Me.BLNO.TextValue, BLID, False)
        End If

        dm.QueryCriteria.Clear()
        dm.QueryCriteria.And(JoinPath.TB_InwardDiscount.Columns.BLID, BLID, MatchType.Exact)
        Dscnt = dm.GetTB_InwardDiscount()
        If Not Dscnt Is Nothing Then
            If Dscnt.dFreeDays > 0 And Dscnt.IsFDaysAsDiscount = True Then
                sDscnt = "Free Days is " & Dscnt.dFreeDays.ToString
            End If
            If Dscnt.dAmount > 0 Then
                sDscnt += IIf(sDscnt = "", "", vbCrLf) & " Amount is " & Format(Double.Parse(Dscnt.dAmount), "#,###")
            End If
            If Dscnt.dPercent > 0 Then
                sDscnt += IIf(sDscnt = "", "", vbCrLf) & " Persent is " & Dscnt.dPercent.ToString
            End If
            sDscnt = IIf(sDscnt <> "", "DISCOUNT DETAILS :", "") & sDscnt
        End If
        dm.QueryCriteria.Clear()
        dm.QueryCriteria.And(JoinPath.TB_Clients.Columns.ID, BL.ClientID, MatchType.Exact)
        Clnt = dm.GetTB_Clients

        Report = New RptInwardDetention

        Col = New DataColumn("dscnt", System.Type.GetType("System.String"))
        Col.DefaultValue = sDscnt
        ds.Tables(1).Columns.Add(Col)

        Col = New DataColumn("TEL", System.Type.GetType("System.String"))
        Col.DefaultValue = ""
        ds.Tables(0).Columns.Add(Col)

        Col = New DataColumn("FAX", System.Type.GetType("System.String"))
        Col.DefaultValue = ""
        ds.Tables(0).Columns.Add(Col)

        Col = New DataColumn("EMAIL", System.Type.GetType("System.String"))
        Col.DefaultValue = ""
        ds.Tables(0).Columns.Add(Col)


        Col = New DataColumn("Reference", System.Type.GetType("System.Int32"))
        Col.DefaultValue = 0
        ds.Tables(0).Columns.Add(Col)

        For Each dr As DataRow In ds.Tables(1).Rows
            dr("Dscnt") = sDscnt
        Next

        ds.Tables(0).Rows(0).Item("Reference") = Int32.Parse(BL.Reference.ToString)
        If Not Clnt Is Nothing Then
            ds.Tables(0).Rows(0).Item("TEL") = Clnt.TEL
            ds.Tables(0).Rows(0).Item("Fax") = Clnt.Fax
            ds.Tables(0).Rows(0).Item("EMail") = Clnt.Email
        End If

        Col = New DataColumn("Paid", System.Type.GetType("System.Int64"))
        Col.DefaultValue = 0
        ds.Tables(1).Columns.Add(Col)
        For Each dr As DataRow In ds.Tables(1).Rows
            dr("Paid") = ds.Tables(0).Rows(0).Item("Paid")
        Next

        ds.AcceptChanges()

        Report.SetDataSource(ds.Tables(0))
        Report.Subreports("RptInwardDetentionSub").SetDataSource(ds.Tables(1))
        Report.Subreports("RptHedaerLogo.rpt").SetDataSource(PH.ImageTable)

        Frm.ReportViewer.ReportSource = Report
        Frm.Show()


    End Sub

    Private Sub ButtonDTNLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDTNLine.Click

        If BL Is Nothing Then
            Exit Sub
        End If
        ShowDetention(True)

    End Sub


End Class