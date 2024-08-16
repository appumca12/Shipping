Imports OrmLib
Imports ShippingBiz
Public Class UserBLS

    Public Event ClieckCMNFPrint()
    Public Event ClickFMNFPrint()
    Public Event ClickBLPrint()
    Public Event ClickArrivalNotice()

    Private dm As DataManager
    Private BL As TB_InwardBLS
    Private IOStatus As InOut

    Private OutDocument As TB_OutwardBLS
    Private InDocument As TB_InwardBLS
    Private BookingDoc As TB_Booking
    Private BKID As Guid


    Enum InwardOutward
        Inward
        Outward
    End Enum

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub InitControl(ByVal InOut As InwardOutward, ByVal BColor As Color)


        Dim Ctl As Control
        Dim Lbl As Infragistics.Win.Misc.UltraLabel

        
        IOStatus = InOut
        Me.GroupBox.Appearance.BackColor = BColor

        For Each Ctl In GroupBox.Controls
            If TypeOf Ctl Is System.Windows.Forms.Label Then
                Ctl.BackColor = BColor
            ElseIf TypeOf Ctl Is Infragistics.Win.Misc.UltraLabel Then
                Lbl = Ctl
                Lbl.Appearance.BackColor = BColor
            End If
        Next

        Me.IssueDate.InitControl(False, False)
        Me.OnBoardDate.InitControl(False, False)

        Me.IssuePlace.InitControl(BColor)
        Me.POR.InitControl(BColor)
        Me.POL.InitControl(BColor)
        Me.POD.InitControl(BColor)
        Me.POT.InitControl(BColor)
        Me.FPOD.InitControl(BColor)

        Me.FVessel.InitControl(BColor)
        Me.FVoyage.InitControl(BColor, Me.FVessel)

        Me.MVessel.InitControl(BColor)
        Me.MVoyage.InitControl(BColor, Me.MVessel)

        Me.TermsOfPayment.InitControl("CP", UserComboCode.ShowCoumn.Meaning)
        Me.NoOfBls.InitControl(1, 0)

        Me.FCLType.InitControl("VT", UserComboCode.ShowCoumn.Meaning)
        Me.Service.InitControl("SV", UserComboCode.ShowCoumn.Meaning)

        Me.ClientID.InitControl(BColor)

        Me.MailReleaseRem.SetLength(50)
        Me.BlStatus.InitControl("ST", UserComboCode.ShowCoumn.Meaning)
        Me.Status.InitControl("BT", UserComboCode.ShowCoumn.Meaning)
        Me.Depot.InitControl("DP", UserComboCode.ShowCoumn.Meaning)

        Me.Remarks.SetLength(100)

        Me.ClientID.InitControl(BColor)

        If InOut = InwardOutward.Outward Then
            Me.ToolbarsManager.Toolbars(0).Tools("Arrival").SharedProps.Visible = False
        End If


    End Sub

    Public Sub SetDocument(ByVal Dr As DataRow)

        '   If IOStatus = InOut.InWard Then

        With Dr

            Me.IssueDate.DateValue = IIf(IsDBNull(.Item("IssueDate")), "", .Item("IssueDate"))
            Me.OnBoardDate.DateValue = IIf(IsDBNull(.Item("OnBoardDate")), "", .Item("OnBoardDate"))

            Me.IssuePlace.PortCode = IIf(IsDBNull(.Item("IssuePlace")), "", .Item("IssuePlace"))
            Me.POR.PortCode = IIf(IsDBNull(.Item("POR")), "", .Item("POR"))
            Me.POL.PortCode = IIf(IsDBNull(.Item("POL")), "", .Item("POL"))
            Me.POD.PortCode = IIf(IsDBNull(.Item("POD")), "", .Item("POD"))
            Me.POT.PortCode = IIf(IsDBNull(.Item("POT")), "", .Item("POT"))
            Me.FPOD.PortCode = IIf(IsDBNull(.Item("FPOD")), "", .Item("FPOD"))

            Me.FVoyage.VoyageID = IIf(IsDBNull(.Item("VoyageID")), System.Guid.NewGuid, .Item("VoyageID"))

            Me.MVoyage.VoyageID = IIf(IsDBNull(.Item("PreVoyageID")), System.Guid.NewGuid, .Item("PreVoyageID"))

            Me.TermsOfPayment.Code = IIf(IsDBNull(.Item("TermsOfPayment")), System.Guid.NewGuid.ToString, .Item("TermsOfPayment"))
            Me.NoOfBls.GnrlNum.Value = Double.Parse(NullToValue(.Item("NoOfBls"), 0))

            Me.FCLType.Code = IIf(IsDBNull(.Item("FCLType")), "", .Item("FCLType"))
            Me.Service.Code = IIf(IsDBNull(.Item("Service")), "", .Item("Service"))

            Me.Remarks.TextValue = IIf(IsDBNull(.Item("Remarks")), "", .Item("Remarks"))

            Me.ClientID.ClientID = IIf(IsDBNull(.Item("ClientID")), Guid.NewGuid, .Item("ClientID"))

            Me.AgentID.AgentID = IIf(IsDBNull(.Item("AgentID")), Guid.NewGuid, .Item("AgentID"))

            Me.MailRelease.Checked = IIf(IsDBNull(.Item("MailRelease")), False, .Item("MailRelease"))
            Me.MailReleaseRem.TextValue = IIf(IsDBNull(.Item("MailReleaseRem")), "", .Item("MailReleaseRem"))
            Me.BlStatus.Code = IIf(IsDBNull(.Item("BlStatus")), "", .Item("BlStatus"))
            Me.Status.Code = IIf(IsDBNull(.Item("Status")), "", .Item("Status"))
            Me.Refernce.Text = IIf(IsDBNull(.Item("Reference")), "", .Item("Reference"))
            BookingID = IIf(IsDBNull(.Item("BookingID")), Guid.Empty, .Item("BookingID"))
            Me.JobNumber.Text = IIf(IsDBNull(.Item("JobNumber")), "", .Item("JobNumber"))
            Me.Depot.Code = IIf(IsDBNull(.Item("Depot")), "", .Item("Depot"))
        End With

    End Sub

    Public Sub GetDocument(ByRef Dr As DataRow, ByVal BlNo As String)

        Dim Ref As String = ""
        Dim aFld() As String = {"Reference"}
        Dim lResult As Boolean


        With Dr

            .Item("BlNo") = BlNo
            .Item("Line") = CurrentShippingLine
            .Item("IssueDate") = IIf(IsDBNull(Me.IssueDate.DateValue) Or (Me.IssueDate.DateValue Is Nothing), DBNull.Value, Me.IssueDate.DateValue)
            .Item("OnBoardDate") = IIf(IsDBNull(Me.OnBoardDate.DateValue) Or (Me.OnBoardDate.DateValue Is Nothing), DBNull.Value, Me.OnBoardDate.DateValue)
            .Item("IssuePlace") = Me.IssuePlace.PortCode
            .Item("POR") = Me.POR.PortCode
            .Item("POL") = Me.POL.PortCode
            .Item("POD") = Me.POD.PortCode
            .Item("POT") = Me.POT.PortCode
            .Item("FPOD") = Me.FPOD.PortCode

            ' Me.FVessel
            .Item("VoyageID") = IIf(Me.FVoyage.VoyageID = Guid.Empty, DBNull.Value, Me.FVoyage.VoyageID)

            'Me.MVessel.InitControl()
            .Item("PreVoyageID") = IIf(Me.MVoyage.VoyageID = Guid.Empty, DBNull.Value, Me.MVoyage.VoyageID)

            .Item("TermsOfPayment") = Me.TermsOfPayment.Code
            .Item("NoOfBls") = Me.NoOfBls.GnrlNum.Value

            .Item("FCLType") = IIf(IsDBNull(Me.FCLType.Code) Or (Me.FCLType.Code Is Nothing), "", Me.FCLType.Code)
            .Item("Service") = IIf(IsDBNull(Me.Service.Code) Or (Me.Service.Code Is Nothing), "", Me.Service.Code)

            .Item("Remarks") = Me.Remarks.TextValue

            .Item("ClientID") = Me.ClientID.ClientID

            .Item("MailRelease") = Me.MailRelease.Checked
            .Item("MailReleaseRem") = Me.MailReleaseRem.TextValue
            .Item("BlStatus") = Me.BlStatus.Code
            .Item("Status") = Me.Status.Code

            If IsDBNull(.Item("Reference")) = True Then
                Ref = FieldsBySql("SP_GetLastInwardReference '" & CurrentShippingLine & "'", aFld, lResult).Item(0).ToString
                Ref += 1
                .Item("Reference") = Ref
                If IOStatus = InOut.InWard Then
                    .Item("JobNumber") = GenerateJobNumber("I")
                Else
                    .Item("JobNumber") = GenerateJobNumber("O")
                End If
             End If
            If BKID = Guid.Empty Then
                .Item("BookingID") = DBNull.Value
            Else
                .Item("BookingID") = BKID
            End If

            .Item("AgentID") = Me.AgentID.AgentID
            .Item("Depot") = Me.Depot.Code


        End With


    End Sub


     Public Sub Checking(ByRef TB As DataTable)

        If IsDBNull(Me.IssueDate.DateValue) Or (Me.IssueDate.DateValue Is Nothing) Then
            AddRowToErrorTable(TB, "B/L Basic Data", "Issue Date Is Blank !", ErrMsgtype.Warning)
        End If

        If IsDBNull(Me.OnBoardDate.DateValue) Or (Me.OnBoardDate.DateValue Is Nothing) Then
            AddRowToErrorTable(TB, "B/L Basic Data", "OnBoard Date Is Blank !", ErrMsgtype.Warning)
        End If

        If Me.IssuePlace.IsValidPort = False Then
            AddRowToErrorTable(TB, "B/L Basic Data", "Issue Place Is Wrong !", ErrMsgtype.Err)
        End If

        If Me.POR.IsValidPort = False Then
            AddRowToErrorTable(TB, "B/L Basic Data", "P.O.R. Is Wrong !", ErrMsgtype.Err)
        End If

        If Me.POL.IsValidPort = False Then
            AddRowToErrorTable(TB, "B/L Basic Data", "P.O.L. Is Wrong !", ErrMsgtype.Err)
        End If

        If Me.POT.IsValidPort = False Then
            AddRowToErrorTable(TB, "B/L Basic Data", "P.O.T. Is Wrong !", ErrMsgtype.Warning)
        End If

        If Me.FPOD.IsValidPort = False Then
            AddRowToErrorTable(TB, "B/L Basic Data", "F.POD Is Wrong !", ErrMsgtype.Err)
        End If

        If Me.FVoyage.VoyageID = Guid.Empty Then
            AddRowToErrorTable(TB, "B/L Basic Data", "Vessel Voyage Is Wrong !", ErrMsgtype.Err)
        End If

        If Me.MVoyage.VoyageID = Guid.Empty Then
            AddRowToErrorTable(TB, "B/L Basic Data", "M/Vessel Voyage Is Wrong !", ErrMsgtype.Warning)
        End If

        If Me.TermsOfPayment.Code = "" Then
            AddRowToErrorTable(TB, "B/L Basic Data", "Terms Of Payment Is Blank !", ErrMsgtype.Err)
        End If

        If Me.NoOfBls.GnrlNum.Value = 0 Then
            AddRowToErrorTable(TB, "B/L Basic Data", "No Of BL/s Is Zero !", ErrMsgtype.Warning)
        End If

        If IsDBNull(Me.FCLType.Code) Or (Me.FCLType.Code Is Nothing) Then
            AddRowToErrorTable(TB, "B/L Basic Data", "FCL/LCL Is Wrong !", ErrMsgtype.Err)
        End If

        If IsDBNull(Me.Service.Code) Or (Me.Service.Code Is Nothing) Then
            AddRowToErrorTable(TB, "B/L Basic Data", "Service Is Wrong !", ErrMsgtype.Err)
        End If

        If Me.ClientID.ClientID = Guid.Empty Or IsDBNull(Me.ClientID.ClientID) Then
            AddRowToErrorTable(TB, "B/L Basic Data", "Clients Is Wrong !", ErrMsgtype.Err)
        End If

        If Me.Status.Code = "" Then
            AddRowToErrorTable(TB, "B/L Status", "B/L Status Is Blank !", ErrMsgtype.Warning)
        End If

        If IOStatus = InOut.OutWard Then
            If Me.BKID = Guid.Empty Then
                AddRowToErrorTable(TB, "B/L Basic Data", "Invalid Booking No !", ErrMsgtype.Warning)
            End If
        End If

        If Me.BlStatus.Code = "" Then
            AddRowToErrorTable(TB, "B/L Basic Data", "Invalid Shipment Type !", ErrMsgtype.Err)
        End If
 
    End Sub
    Public Property BookingID() As Guid
        Get
            Return BKID
        End Get
        Set(ByVal value As Guid)
            BKID = value
        End Set
    End Property
    Public ReadOnly Property VoyageID() As Guid
        Get
            Return Me.FVoyage.VoyageID
        End Get
    End Property


    Private Sub ToolbarsManager_ToolClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinToolbars.ToolClickEventArgs) Handles ToolbarsManager.ToolClick

        Select Case e.Tool.Key
            Case "B/L"
                RaiseEvent ClickBLPrint()
            Case "C/M"
                RaiseEvent ClieckCMNFPrint()
            Case "F/M"
                RaiseEvent ClickFMNFPrint()
            Case "Arrival"
                RaiseEvent ClickArrivalNotice()
        End Select

    End Sub
 
    Public Sub SetBookingData(ByVal Booking As TB_Booking)


        If Not Booking Is Nothing Then
            With Booking
                Me.IssuePlace.PortCode = .POL
                Me.IssueDate.DateValue = Today
                Me.POR.PortCode = .POL
                Me.POL.PortCode = .POL
                Me.POD.PortCode = .POD
                Me.POT.PortCode = .POT
                Me.FPOD.PortCode = .FPOD
                Me.ClientID.ClientID = .ClientID
                Me.TermsOfPayment.Code = .Terms
                Me.POL.Enabled = False
                Me.POD.Enabled = False
                Me.POT.Enabled = False
                Me.FPOD.Enabled = False
                Me.ClientID.Enabled = False
                Me.TermsOfPayment.Enabled = False
            End With
        Else
            Me.POL.Enabled = True
            Me.POD.Enabled = True
            Me.POT.Enabled = True
            Me.FPOD.Enabled = True
            Me.ClientID.Enabled = True
            Me.TermsOfPayment.Enabled = True
        End If

    End Sub
    Private Sub MVoyage_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Leave
        Dim TB As New DataTable
        Dim sSql As String
        Dim lResult As Boolean
        sSql = "select top 1 Sailed from TB_SOF where VoyageID = '" & MVoyage.VoyageID.ToString & "'"
        TableBySql(sSql, TB, lResult)
        If TB.Rows.Count > 0 Then
            Me.OnBoardDate.DateValue = TB.Rows(0).Item(0).ToString
        End If

    End Sub


    Private Sub UserBLS_TabIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.TabIndexChanged
        Dim TB As New DataTable
        Dim sSql As String
        Dim lResult As Boolean
        sSql = "select top 1 Sailed from TB_SOF where VoyageID = '" & MVoyage.VoyageID.ToString & "'"
        TableBySql(sSql, TB, lResult)
        If TB.Rows.Count > 0 Then
            Me.OnBoardDate.DateValue = TB.Rows(0).Item(0).ToString
        End If

    End Sub
End Class
