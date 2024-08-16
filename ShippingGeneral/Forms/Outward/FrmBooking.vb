Imports OrmLib
Imports ShippingBiz
Imports Infragistics.Shared
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinEditors
Imports Aspose.Words
Imports Aspose.Words.Fields
Imports Aspose.Words.Reporting

Public Class FrmBooking

    Implements IFGeneral
    Private ItemLevel = "600"
    Private FrmStatus As FormStatus = FormStatus.NoAction
    Private BookingID As Guid
    Private Booking As TB_Booking
    Private Dm As DataManager
    Public TB As DataTable
    Private formlocalId As Integer 'For ILS Shortcuts  
    Private blTxtBox As System.Windows.Forms.TextBox 'For ILS Shortcuts
    Dim Shortcut As Boolean

    Private Sub FrmBooking_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.GeneralForms.InitControl("BOOKING INFORMATION", ItemLevel)
        Dim Col As Infragistics.Win.UltraWinGrid.UltraGridColumn
        Dim Codes As New TB_CODECollection

        Me.Left = 0
        Me.Top = 0

        Me.BookingNo.SetLength(25)
        Me.BookingDate.InitControl(False, True)

        Me.ClientID.InitControl(Me.GroupBoxBooking.Appearance.BackColor)
        Me.ClientRepID.InitControl(Me.GroupBoxBooking.Appearance.BackColor)
        Me.Validity.InitControl(False, True)
        Me.Depot.InitControl("DP", UserComboCode.ShowCoumn.Meaning)
        Me.POL.InitControl(Me.GroupBoxBooking.Appearance.BackColor)

        Me.POT.InitControl(Me.GroupBoxBooking.Appearance.BackColor)
        Me.POD.InitControl(Me.GroupBoxBooking.Appearance.BackColor)
        Me.FPOD.InitControl(Me.GroupBoxBooking.Appearance.BackColor)

        Me.POLFreeDays.InitControl(3, 0)
        Me.PODFreeDays.InitControl(3, 0)
        Me.Goods.SetLength(100)
        Me.PrincipalReference.SetLength(20)
        Me.PrincipalConfirm.InitControl(False, False)
        Me.Salesman.SetLength(10)
        Me.Status.InitControl("BS", UserComboCode.ShowCoumn.Meaning)
        Me.Terms.InitControl("CP", UserComboCode.ShowCoumn.Meaning)
        Me.PackageType.InitControl("PG", UserComboCode.ShowCoumn.Meaning)
        Me.Payer.SetLength(200)

        Me.SrchStatus.InitControl("BS", UserComboCode.ShowCoumn.Meaning)
        Me.SrchClients.InitControl(Me.Ultarbox.Appearance.BackColor)


        Me.GridDetail.DataSource = Me.DataSetForm.Tables(0)
        With Me.GridDetail
            .DisplayLayout.Bands(0).Columns("ID").Hidden = True
            .DisplayLayout.Bands(0).Columns("BookingID").Hidden = True
            .DisplayLayout.Bands(0).Columns("TotalCntrs").MaskInput = "{LOC}n,nnn"
            .DisplayLayout.Bands(0).Columns("QTShipper").MaskInput = "{LOC}nn,nnn,nnn.nn"
            .DisplayLayout.Bands(0).Columns("QTCarrier").MaskInput = "{LOC}nn,nnn,nnn.nn"
            .DisplayLayout.Bands(0).Columns("SlotRate").MaskInput = "{LOC}nn,nnn,nnn.nn"
        End With

        With Me.DropDownSize
            .DataSource = GetCodeList("CS")
            .DisplayMember = "StdCode"
            .ValueMember = "StdCode"
            For Each Col In .DisplayLayout.Bands(0).Columns
                Col.Hidden = True
            Next
            .DisplayLayout.Bands(0).Columns("StdCode").Hidden = False
        End With

        With Me.DropDownType
            .DataSource = GetCodeList("CT")
            .DisplayMember = "StdCode"
            .ValueMember = "StdCode"
            For Each Col In .DisplayLayout.Bands(0).Columns
                Col.Hidden = True
            Next
            .DisplayLayout.Bands(0).Columns("StdCode").Hidden = False
        End With

        With Me.DropDownCharge
            .DataSource = GetCodeList("CG")
            .DisplayMember = "StdCode"
            .ValueMember = "StdCode"
            For Each Col In .DisplayLayout.Bands(0).Columns
                Col.Hidden = True
            Next
            .DisplayLayout.Bands(0).Columns("StdCode").Hidden = False
        End With

        With Me.DropDownCurrency
            .DataSource = GetCodeList("CU")
            .DisplayMember = "StdCode"
            .ValueMember = "StdCode"
            For Each Col In .DisplayLayout.Bands(0).Columns
                Col.Hidden = True
            Next
            .DisplayLayout.Bands(0).Columns("StdCode").Hidden = False
        End With

        With Me.DropDownBaseOn
            .DataSource = GetCodeList("BO")
            .DisplayMember = "Meaning"
            .ValueMember = "StdCode"
            For Each Col In .DisplayLayout.Bands(0).Columns
                Col.Hidden = True
            Next
            .DisplayLayout.Bands(0).Columns("Meaning").Hidden = False
        End With


        With Me.GridDetail.DisplayLayout.Bands(0)
            .Columns("CnType").Style _
                               = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate
            .Columns("CnType").ValueList = Me.DropDownType

            .Columns("CnSize").Style _
                                         = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate
            .Columns("CnSize").ValueList = Me.DropDownSize

            .Columns("ChargeItem").Style _
                                         = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate
            .Columns("ChargeItem").ValueList = Me.DropDownCharge

            .Columns("BaseOn").Style _
                                                     = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate
            .Columns("BaseOn").ValueList = Me.DropDownBaseOn

            .Columns("CurCode").Style _
                                                                = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate
            .Columns("CurCode").ValueList = Me.DropDownCurrency

            .Columns("PayebleAt").CharacterCasing = CharacterCasing.Upper
        End With

        Dm = New DataManager(My.Settings.DSN)
        Dm.QueryCriteria.Clear()
        Dm.GetTB_LinesCollection()


        'For Each Dr In Dm.DataSet.Tables("TB_Lines").Rows

        '    Code = Dm.NewTB_CODE
        '    Code.ID = System.Guid.Empty
        '    Code.STDCode = Dr("LineCode")
        '    Code.MEANING = Dr("LineName")
        '    Codes.Add(Code)
        'Next

        Line.InitControl("CR", UserComboCode.ShowCoumn.Meaning)

        Me.IMDG.InitControl("HZ", UserComboCode.ShowCoumn.Meaning)
        Me.PackingGroup.InitControl("PZ", UserComboCode.ShowCoumn.Meaning)
        Me.PageNumber.InitControl(5, 0)
        Me.UnNo.SetLength(10)

        Me.SwitchBLIn.InitControl(Me.GroupBoxBooking.Appearance.BackColor)
        Me.SOC.InitControl("YN", UserComboCode.ShowCoumn.Meaning)

        Me.ExceptedMtyPickup.InitControl(False, False)
        Me.BLToBeUsed.SetLength(10)

        FrmStatus = FormStatus.NoAction
        General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)

        LockStatus(False)

        Dim button1 As New Infragistics.Win.UltraWinToolbars.ButtonTool("button1")
        button1.SharedProps.AppearancesSmall.Appearance.Image = My.Resources.Word_icon
        button1.SharedProps.Caption = "Memo"
        button1.Key = "Memo"
        button1.SharedProps.DisplayStyle = UltraWinToolbars.ToolDisplayStyle.ImageAndText

      
        Me.GeneralForms.CustomToolbar.Tools.Add(button1)
        Me.GeneralForms.CustomToolbar.Tools("Memo").SharedProps.Visible = True
        Me.GeneralForms.CustomToolbar.Toolbars(0).Tools.AddTool("memo")


        Dim button2 As New Infragistics.Win.UltraWinToolbars.ButtonTool("button2")
        button2.SharedProps.AppearancesSmall.Appearance.Image = My.Resources.Word_icon
        button2.SharedProps.Caption = "Firm"
        button2.Key = "Firm"
        button2.SharedProps.DisplayStyle = UltraWinToolbars.ToolDisplayStyle.ImageAndText


        Me.GeneralForms.CustomToolbar.Tools.Add(button2)
        Me.GeneralForms.CustomToolbar.Tools("Firm").SharedProps.Visible = True
        Me.GeneralForms.CustomToolbar.Toolbars(0).Tools.AddTool("Firm")

        Dim button3 As New Infragistics.Win.UltraWinToolbars.ButtonTool("button3")
        button3.SharedProps.AppearancesSmall.Appearance.Image = My.Resources.MSExcel2424
        button3.SharedProps.Caption = "Export"
        button3.Key = "Export"
        button3.SharedProps.DisplayStyle = UltraWinToolbars.ToolDisplayStyle.ImageAndText


        Me.GeneralForms.CustomToolbar.Tools.Add(button3)
        Me.GeneralForms.CustomToolbar.Tools("Export").SharedProps.Visible = True
        Me.GeneralForms.CustomToolbar.Toolbars(0).Tools.AddTool("Export")


        InitTemp()

        If Not Me.SrchBooking.TextValue = "" Then
            Shortcut = True
            GeneralForms_CustomFindClick("sender", 600)
            GeneralForms_CustomEditClick("sender", 600)
            Shortcut = False
        End If

    End Sub

    Private Sub LockStatus(ByVal Status As Boolean) Implements IFGeneral.LockStatus

        General.LockControls(Me, Status)
        Me.SrchBooking.GeneralTxt.Enabled = True
        Me.BookingNo.GeneralText.Enabled = False
        Me.Salesman.GeneralText.Enabled = False
        Me.Status.ComboCode.Enabled = False
        Me.SrchClients.Enabled = True
        Me.SrchStatus.ComboCode.Enabled = True
        Me.GridResult.Enabled = True

    End Sub

    Private Sub SendDataToClass() Implements IFGeneral.SendDataToClass

        Dim Dr As DataRow
        Dim Tb As DataTable
        Dim DV As DataView
        Dim DC As DataColumn
        Dim TempDr As DataRow
        Dim aTables() As String = {"TB_Booking", "TB_BookingDetails"}
        Dim DS As New DataSet
        Dim nI As Byte
        Dim sSql As String
        Dim TbRef As New DataTable
        Dim lresult As Boolean
        Dim SeqTab As New DataTable

        Dim Cmd As New SqlClient.SqlCommand
        Dim DA As New SqlClient.SqlDataAdapter
        Dim DsRef As New DataSet
        Dim Cnn As New SqlClient.SqlConnection

        Dim Seq As TB_Seq
        Dim SeqRow As DataRow

        If Dm Is Nothing Then
            Dm = New DataManager(My.Settings.DSN)
            DS = StoredProcedures.SP_BookingAllByNo("X?X")
            Me.DataSetForm.Tables("TB_BookingDetails").Clear()
            Dm.PopulateObjectsFromDataSet(DS, aTables)
            For nI = 0 To aTables.Length - 1
                Dm.DataSet.Tables(aTables(nI)).Merge(DS.Tables(nI))
            Next
        End If

        If FrmStatus = FormStatus.NewRecord Then
            sSql = " exec SP_GETNewBookingNo '" & CurrentUser.UserCode & "'" + ", '" & CurrentShippingLine & "'"
            TableBySql(sSql, SeqTab, lresult)

            If CurrentShippingLine = "FWD" Then
                Me.BookingNo.TextValue = "FW" + SeqTab.Rows(0).Item(0)
            ElseIf CurrentShippingLine = "OTLO" Then
                Me.BookingNo.TextValue = "OTL" + SeqTab.Rows(0).Item(0)
            ElseIf CurrentShippingLine = "ABLE" Then
                Me.BookingNo.TextValue = "ABL" + SeqTab.Rows(0).Item(0)
            ElseIf CurrentShippingLine = "LEX" Then
                Me.BookingNo.TextValue = "LEX" + SeqTab.Rows(0).Item(0)
            ElseIf CurrentShippingLine = "AXL" Then
                Me.BookingNo.TextValue = "AXL" + SeqTab.Rows(0).Item(0)
            ElseIf CurrentShippingLine = "PEAK" Then
                Me.BookingNo.TextValue = "PEK" + SeqTab.Rows(0).Item(0)
            ElseIf CurrentShippingLine = "SUM" Then
                Me.BookingNo.TextValue = "SUM" + SeqTab.Rows(0).Item(0)
            ElseIf CurrentShippingLine = "RUS" Then
                Me.BookingNo.TextValue = "RUS" + SeqTab.Rows(0).Item(0)
            ElseIf CurrentShippingLine = "ECM" Then
                Me.BookingNo.TextValue = "ECM" + SeqTab.Rows(0).Item(0)
            ElseIf CurrentShippingLine = "SJL" Then
                Me.BookingNo.TextValue = "SJL" + SeqTab.Rows(0).Item(0)
            ElseIf CurrentShippingLine = "SELIN" Then
                Me.BookingNo.TextValue = "SEL" + SeqTab.Rows(0).Item(0)
            ElseIf CurrentShippingLine = "FCS" Then
                Me.BookingNo.TextValue = "FCS" + SeqTab.Rows(0).Item(0)
            ElseIf CurrentShippingLine = "LSL" Then
                Me.BookingNo.TextValue = "LSL" + SeqTab.Rows(0).Item(0)
            ElseIf CurrentShippingLine = "SAG" Then
                Me.BookingNo.TextValue = "SAG" + SeqTab.Rows(0).Item(0)
            Else
                Me.BookingNo.TextValue = SeqTab.Rows(0).Item(0)
            End If
            Dm.DataSet.Tables("TB_Booking").Clear()
            Dr = Dm.DataSet.Tables("TB_Booking").NewRow
         Else
            Dr = Dm.DataSet.Tables("TB_Booking").Rows(0)
        End If

        Dr("BookingNo") = Me.BookingNo.TextValue
        Dr("BookingDate") = Me.BookingDate.DateValue
        Dr("Line") = Me.Line.Code
        Dr("ClientID") = Me.ClientID.ClientID
        Dr("ClientRepID") = Me.ClientRepID.ClientID
        Dr("Validity") = Me.Validity.DateValue
        Dr("POL") = Me.POL.PortCode
        Dr("POT") = Me.POT.PortCode
        Dr("POD") = Me.POD.PortCode
        Dr("FPOD") = Me.FPOD.PortCode
        Dr("Depot") = Me.Depot.Code
        Dr("POLFreeDays") = Me.POLFreeDays.GnrlNum.Value
        Dr("PODFreeDays") = Me.PODFreeDays.GnrlNum.Value
        Dr("Goods") = Me.Goods.TextValue
        Dr("PrincipalReference") = Me.PrincipalReference.TextValue
        Dr("PrincipalConfirm") = IIf(Me.PrincipalConfirm.DateValue = Nothing, DBNull.Value, Me.PrincipalConfirm.DateValue)
        If FrmStatus = FormStatus.NewRecord Then
            Dr("Salesman") = CurrentUser.ID
        End If
        Dr("Status") = Me.Status.Code
        Dr("Terms") = Me.Terms.Code
        Dr("Remarks") = Me.Remarks.TextValue
        Dr("InvoiceInIrr") = Me.InvoiceInIrr.Checked
        Dr("Payer") = Me.Payer.TextValue

        Dr("BLToBeUsed") = Me.BLToBeUsed.TextValue
        If Not Me.ExceptedMtyPickup.DateValue Is Nothing Then
            Dr("ExceptedMtyPickup") = Me.ExceptedMtyPickup.DateValue
        End If

        Dr("SOC") = Me.SOC.Code
        Dr("UNNO") = Me.UnNo.TextValue
        Dr("IMDGCode") = Me.IMDG.Code
        Dr("PakingGroup") = Me.PackingGroup.Code
        Dr("PageNumber") = Me.PageNumber.CtrlValue
        Dr("SwitchBLIn") = Me.SwitchBLIn.PortCode
        Dr("PackageType") = Me.PackageType.Code

        If FrmStatus = FormStatus.NewRecord Then
            Dm.DataSet.Tables("TB_Booking").Rows.Add(Dr)
        End If

        Tb = Me.DataSetForm.Tables("TB_BookingDetails").GetChanges
        If Not Tb Is Nothing Then
            For Each TempDr In Tb.Rows
                Select Case TempDr.RowState
                    Case DataRowState.Added
                        TempDr.Item("ID") = Guid.NewGuid
                        Dm.DataSet.Tables("TB_BookingDetails").ImportRow(TempDr)
                    Case DataRowState.Deleted
                        DV = New DataView(Dm.DataSet.Tables("TB_BookingDetails"), "ID = '" & TempDr(0, DataRowVersion.Original).ToString & "'", "", DataViewRowState.CurrentRows)
                        If DV.Count > 0 Then
                            DV.Item(0).Delete()
                        End If
                    Case DataRowState.Modified
                        DV = New DataView(Dm.DataSet.Tables("TB_BookingDetails"), "ID = '" & TempDr.Item("ID").ToString & "'", "", DataViewRowState.CurrentRows)
                        If DV.Count > 0 Then
                            For Each DC In Tb.Columns
                                DV.Item(0).Item(DC.ColumnName) = TempDr.Item(DC.ColumnName)
                            Next
                        End If
                End Select
            Next
        End If

    End Sub

    Private Sub Populate() Implements IFGeneral.Populate


        Dim Dr As DataRow = Dm.DataSet.Tables("TB_Booking").Rows(0)

        BookingID = Dr("ID")

        Me.BookingNo.TextValue = IIf(IsDBNull(Dr("BookingNo")), "", Dr("BookingNo"))
        Me.BookingDate.DateValue = IIf(IsDBNull(Dr("BookingDate")), "", Dr("BookingDate"))
        Me.Line.Code = IIf(IsDBNull(Dr("Line")), "", Dr("Line"))

        Me.ClientID.ClientID = IIf(IsDBNull(Dr("ClientID")), Guid.Empty, Dr("ClientID"))
        Me.ClientRepID.ClientID = IIf(IsDBNull(Dr("ClientRepID")), Guid.Empty, Dr("ClientRepID"))
        Me.Validity.DateValue = IIf(IsDBNull(Dr("Validity")), "", Dr("Validity"))
        Me.POL.PortCode = IIf(IsDBNull(Dr("POL")), "", Dr("POL"))
        Me.POT.PortCode = IIf(IsDBNull(Dr("POT")), "", Dr("POT"))
        Me.POD.PortCode = IIf(IsDBNull(Dr("POD")), "", Dr("POD"))
        Me.FPOD.PortCode = IIf(IsDBNull(Dr("FPOD")), "", Dr("FPOD"))
        Me.Depot.Code = IIf(IsDBNull(Dr("Depot")), "", Dr("Depot"))

        Me.POLFreeDays.GnrlNum.Value = IIf(IsDBNull(Dr("POLFreeDays")), "", Dr("POLFreeDays"))
        Me.PODFreeDays.GnrlNum.Value = IIf(IsDBNull(Dr("PODFreeDays")), 0, Dr("PODFreeDays"))
        Me.Goods.TextValue = IIf(IsDBNull(Dr("Goods")), "", Dr("Goods"))
        Me.PrincipalReference.TextValue = IIf(IsDBNull(Dr("PrincipalReference")), "", Dr("PrincipalReference"))
        Me.PrincipalConfirm.DateValue = IIf(IsDBNull(Dr("PrincipalConfirm")), "", Dr("PrincipalConfirm"))
        '      Me.Salesman.TextValue = IIf(IsDBNull(Dr("Salesman")), CurrentUser.ID.ToString, Dr("Salesman"))
        Me.Status.Code = IIf(IsDBNull(Dr("Status")), "", Dr("Status"))

        Me.Terms.Code = IIf(IsDBNull(Dr("Terms")), "", Dr("Terms"))
        Me.Remarks.TextValue = IIf(IsDBNull(Dr("Remarks")), "", Dr("Remarks"))
        Me.InvoiceInIrr.Checked = IIf(IsDBNull(Dr("InvoiceInIrr")), False, Dr("InvoiceInIrr"))


        Me.BLToBeUsed.TextValue = IIf(IsDBNull(Dr("BLToBeUsed")), "", Dr("BLToBeUsed"))
        Me.ExceptedMtyPickup.DateValue = IIf(IsDBNull(Dr("ExceptedMtyPickup")), "", Dr("ExceptedMtyPickup"))
        Me.SOC.Code = IIf(IsDBNull(Dr("SOC")), "", Dr("SOC"))
        Me.UnNo.TextValue = IIf(IsDBNull(Dr("UNNO")), "", Dr("UNNO"))
        Me.IMDG.Code = IIf(IsDBNull(Dr("IMDGCode")), "", Dr("IMDGCode"))
        Me.PackingGroup.Code = IIf(IsDBNull(Dr("PakingGroup")), "", Dr("PakingGroup"))
        Me.PageNumber.CtrlValue = IIf(IsDBNull(Dr("PageNumber")), 0, Dr("PageNumber"))
        Me.SwitchBLIn.PortCode = IIf(IsDBNull(Dr("SwitchBLIn")), "", Dr("SwitchBLIn"))
        Me.PackageType.Code = IIf(IsDBNull(Dr("PackageType")), "", Dr("PackageType"))
        Me.Payer.TextValue = IIf(IsDBNull(Dr("Payer")), "", Dr("Payer"))

    End Sub

    Private Sub SetDocument()

        Dim ID As String
        Dim sDummy As String = ""
        Dim aTables() As String = {"TB_Booking", "TB_BookingDetails"}
        Dim DS As New DataSet
        Dim nI As Byte

        If Me.GridResult.Rows.Count = 0 Then
            Exit Sub
        End If
        ' ClearControl(Me)
        Me.DataSetForm.Tables("TB_BookingDetails").Clear()
        If Me.GridResult.ActiveRow Is Nothing Then
            Me.GridResult.Rows(0).Selected = True
            Me.GridResult.Rows(0).Activated = True
        End If

        ID = Me.GridResult.ActiveRow.Cells("ID").Value.ToString
        Dm = New DataManager(My.Settings.DSN)
        DS = StoredProcedures.SP_BookingAllBookingID(ID)
        Dm.PopulateObjectsFromDataSet(DS, aTables)

        For nI = 0 To aTables.Length - 1
            Dm.DataSet.Tables(aTables(nI)).Merge(DS.Tables(nI).Copy)
        Next

        Me.DataSetForm.Tables("TB_BookingDetails").Merge(Dm.DataSet.Tables("TB_BookingDetails"))

        If DS.Tables(0).Rows.Count = 0 Then
            MsgBoxGeneral("No Valid Booking !", "Search Result")
            FrmStatus = FormStatus.NoAction
        Else
            Populate()
            FrmStatus = FormStatus.HasData
        End If

        Me.GridDetail.DataSource = Me.DataSetForm.Tables("TB_BookingDetails")
        General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)
        LockStatus(False)

        Me.GridAssignCntrs.DataSource = Nothing
        DS = StoredProcedures.SP_AssignedBookingCntrs(ID)
        If DS.Tables.Count <> 0 Then
            Me.GridAssignCntrs.DataSource = DS.Tables(0)
        End If
        Me.DataSetForm.Tables("TB_BookingDetails").AcceptChanges()

    End Sub
    
    Private Function ValidateForm() As Boolean

        Dim Ans As Boolean = True
        Dim nI As Byte
        Dim aList As New ArrayList
        Dim Dr As DataRow
        Dim CheckDetail As Boolean

        FormErrorProvider.Clear()

        If Me.BookingDate.DateValue Is Nothing Then
            aList.Add(Me.BookingDate)
        End If

        If Me.Line.Code = "" Then
            aList.Add(Me.Line)
        End If

        If Me.ClientID.ClientID.ToString = "" Or Me.ClientID.ClientID.ToString = Guid.Empty.ToString Then
            aList.Add(Me.ClientID)
        End If

        If Me.POL.PortCode = "" Then
            aList.Add(Me.POL)
        End If

        If Me.POD.PortCode = "" Then
            aList.Add(Me.POD)
        End If

        If Me.FPOD.PortCode = "" Then
            aList.Add(Me.FPOD)
        End If

        If Validity.DateValue Is Nothing Then
            aList.Add(Me.Validity)
        End If

        If Depot.Code = "" Then
            aList.Add(Me.Depot)
        End If

        If Me.POLFreeDays.GnrlNum.Value = 0 Then
            aList.Add(Me.POLFreeDays)
        End If

        'If Me.PODFreeDays.GnrlNum.Value = 0 Then
        '    aList.Add(Me.PODFreeDays)
        'End If

        If Me.Goods.TextValue = "" Then
            aList.Add(Me.Goods)
        End If

        If Me.Terms.Code = "" Then
            aList.Add(Me.Terms)
        End If

        Me.GridDetail.UpdateData()
        For Each Dr In Me.DataSetForm.Tables("TB_BookingDetails").Rows
            If Dr.RowState <> DataRowState.Deleted Then
                Dr.RowError = ""
                If NullToValue(Dr("ChargeItem"), "") = "" Then
                    Dr.RowError = "No Valid Charge Item !"
                End If
                If NullToValue(Dr("Cnsize"), "") = "" Then
                    Dr.RowError += " No Valid Container Size !"
                End If

                If NullToValue(Dr("CnType"), "") = "" Then
                    Dr.RowError += " No Valid Container Type !"
                End If

                'If NullToValue(Dr("QtShipper"), 0) + NullToValue(Dr("QtCarrier"), 0) = 0 Then
                '    Dr.RowError += " QT. Shipper or  QT. Carrier Should be fill !"
                'End If

                'If NullToValue(Dr("QtCarrier"), 0) = 0 Then
                '    Dr.RowError += " QT. Carrier No Valid !"
                'End If

                If NullToValue(Dr("TotalCntrs"), 0) = 0 Then
                    Dr.RowError += " Total Containers is Blank !"
                End If

                If GetPortNameByCode(NullToValue(Dr("PayebleAt"), "")) = "" Then
                    Dr.RowError += " Payeble at is wrong !"
                End If

                If NullToValue(Dr("BaseOn"), "") = "" Then
                    Dr.RowError += " Base On is Wrong !"
                End If

                If NullToValue(Dr("CurCode"), "") = "" Then
                    Dr.RowError += " Currency is Wrong !"
                End If


                If Dr.RowError <> "" Then
                    CheckDetail = True
                End If
            End If
        Next

        If CheckDetail = True Then
            aList.Add(Me.GridDetail)
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

    Private Sub GridDetail_BeforeRowUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CancelableRowEventArgs) Handles GridDetail.BeforeRowUpdate

        If GridDetail.ActiveRow.Cells("ID").Value.ToString = "" Then
            GridDetail.ActiveRow.Cells("ID").Value = System.Guid.NewGuid
            GridDetail.ActiveRow.Cells("BookingID").Value = BookingID
        End If

    End Sub

    Private Function GetNewBookingNo() As String

        Dim Ds As DataSet
        Ds = StoredProcedures.SP_GETNewBookingNo(CurrentUser.UserCode)
        Return Ds.Tables(0).Rows(0).Item(0)

    End Function

    Public Sub InitTemp()

        Dim Col As Infragistics.Win.UltraWinGrid.UltraGridColumn
        TB = New DataTable
        TB.TableName = "Result"
        TB.Columns.Add(New DataColumn("ID", System.Type.GetType("System.Guid")))
        TB.Columns.Add(New DataColumn("Seq", System.Type.GetType("System.String")))
        TB.Columns.Add(New DataColumn("BookingNo", System.Type.GetType("System.String")))
        TB.Columns.Add(New DataColumn("BookingDate", System.Type.GetType("System.DateTime")))
        TB.Columns.Add(New DataColumn("Validity", System.Type.GetType("System.DateTime")))
        TB.Columns.Add(New DataColumn("Status", System.Type.GetType("System.String")))
        TB.Columns.Add(New DataColumn("Client", System.Type.GetType("System.String")))
        TB.Columns.Add(New DataColumn("ClientID", System.Type.GetType("System.Guid")))
        Me.GridResult.DataSource = TB

        With Me.GridResult.DisplayLayout.Bands(0)

            .Columns("ID").Hidden = True
            .Columns("ClientID").Hidden = True

            With Me.DropDownInvoiceStatus
                .DataSource = GetCodeList("BS")
                .DisplayMember = "Meaning"
                .ValueMember = "StdCode"
                For Each Col In .DisplayLayout.Bands(0).Columns
                    Col.Hidden = True
                Next
                .DisplayLayout.Bands(0).Columns("Meaning").Hidden = False
            End With

            With Me.GridResult.DisplayLayout.Bands(0)
                .Columns("Status").Style _
                                   = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate
                .Columns("Status").ValueList = Me.DropDownInvoiceStatus
            End With

        End With

    End Sub

    Private Sub GridDetail_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles GridDetail.InitializeLayout
        e.Layout.Override.SupportDataErrorInfo = SupportDataErrorInfo.RowsAndCells
        e.Layout.Override.DataErrorCellAppearance.ForeColor = Color.Red
        e.Layout.Override.DataErrorRowAppearance.BackColor = Color.LightYellow
        e.Layout.Override.DataErrorRowSelectorAppearance.BackColor = Color.Green
        e.Layout.Override.RowSelectorWidth = 32
    End Sub

    Private Sub GenerateMemo()

        Dim TB As New DataTable
        Dim lResult As Boolean
        Dim ID As String
        Dim Bk As String

        Dim FleName As String
        Dim doc As Document
        Dim aValue() As String
        Dim aField() As String




        If Me.SrchBooking.TextValue = "" And Me.GridResult.Rows.Count = 0 Then
            MsgBox("Nothing For Print !")
            Exit Sub
        End If

        If Me.SrchBooking.TextValue = "" Then
            If Me.GridResult.ActiveRow Is Nothing Then
                MsgBox("Plesae select a Booking !")
                Exit Sub
            End If
            Bk = Me.GridResult.ActiveRow.Cells("Bookingno").Text
        Else
            Bk = Me.SrchBooking.TextValue
        End If

        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_Booking.Columns.BookingNo, Bk, MatchType.Exact)
        Booking = Dm.GetTB_Booking

        If Booking Is Nothing Then
            MsgBox("No Valid Booking !")
            Exit Sub
        End If

        TableBySql("SP_BookingMemo '" & Booking.ID.ToString & "'", TB, lResult)

        FleName = "BookingMemo"
        RetriveObject(FleName, "C:\Temp\Temp")
        DOC = New Document("C:\Temp\Temp")
        TableToArray(TB, aField, aValue)
        DOC.MailMerge.Execute(aField, aValue)
        doc.Save("c:\Temp\" & Booking.BookingNo & ".doc")
        Process.Start("c:\Temp\" & Booking.BookingNo & ".doc")
 
    End Sub

    Private Sub GenerateFirm()

        Dim TB As New DataTable
        Dim lResult As Boolean
        Dim ID As String
        Dim Bk As String

        Dim FleName As String
        Dim doc As Document
        Dim aValue() As String
        Dim aField() As String




        If Me.SrchBooking.TextValue = "" And Me.GridResult.Rows.Count = 0 Then
            MsgBox("Nothing For Print !")
            Exit Sub
        End If

        If Me.SrchBooking.TextValue = "" Then
            If Me.GridResult.ActiveRow Is Nothing Then
                MsgBox("Plesae select a Booking !")
                Exit Sub
            End If
            Bk = Me.GridResult.ActiveRow.Cells("Bookingno").Text
        Else
            Bk = Me.SrchBooking.TextValue
        End If

        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_Booking.Columns.BookingNo, Bk, MatchType.Exact)
        Booking = Dm.GetTB_Booking

        If Booking Is Nothing Then
            MsgBox("No Valid Booking !")
            Exit Sub
        End If

        TableBySql("SP_BookingFirm '" & Booking.ID.ToString & "'", TB, lResult)

        FleName = "BookingFirm"
        RetriveObject(FleName, "C:\Temp\Temp")
        doc = New Document("C:\Temp\Temp")
        TableToArray(TB, aField, aValue)
        doc.MailMerge.Execute(aField, aValue)
        doc.Save("c:\Temp\" & Booking.BookingNo & "Firm.doc")
        Process.Start("c:\Temp\" & Booking.BookingNo & "Firm.doc")

    End Sub

    'Private Sub GeneralForms_CustomFindClick() Handles GeneralForms.CustomFindClick
    Public Sub GeneralForms_CustomFindClick(ByVal sender As Object, ByVal formId As Integer)
        If (Me.GeneralForms.getItemLevel(Me.GeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel) Or Shortcut = True) Then 'For ILS Shortcuts  
            'formlocalId = formId
            'If (sender.ToString().Contains("Text")) Then
            '    blTxtBox = DirectCast(sender, System.Windows.Forms.TextBox)
            '    Me.BLNO.TextValue = blTxtBox.Text
            'End If
            'For ILS Shortcuts End

            Dim ds As New DataSet
            Dim sSrchBooking As String
            Dim sSrchStatus As String
            Dim sClientID As Guid

            Dim Cmd As New SqlClient.SqlCommand
            Dim DA As New SqlClient.SqlDataAdapter
            Dim Cnn As New SqlClient.SqlConnection(My.Settings.DSN)


            sSrchBooking = Me.SrchBooking.TextValue
            sSrchStatus = Me.SrchStatus.Code

            If Trim((Replace(Me.SrchClients.Text, "(ALL)", ""))) <> "" Then
                sClientID = Me.SrchClients.ClientID
            Else
                sClientID = System.Guid.Empty
            End If

            ClearControl(Me)

            Me.SrchBooking.TextValue = sSrchBooking
            Me.SrchStatus.Code = sSrchStatus
            If sClientID <> Guid.Empty Then
                Me.SrchClients.ClientID = sClientID
            End If

            Cnn.Open()
            With Cmd
                .CommandText = "SP_BookingSrch"
                .CommandType = CommandType.StoredProcedure
                .Connection = Cnn
                .Parameters.AddWithValue("@BookingNo", Me.SrchBooking.TextValue)
                .Parameters.AddWithValue("@Status", Me.SrchStatus.Code)
                .Parameters.AddWithValue("@ClientID", IIf(Me.SrchClients.Text = "", "(ALL)", Me.SrchClients.ClientID.ToString))
                .Parameters.AddWithValue("@SalesMan", IIf(CurrentUser.IsSalesAdmin = True Or CurrentUser.BookingViewer = True, "", CurrentUser.ID.ToString))
                .Parameters.AddWithValue("@Line", CurrentShippingLine)
            End With


            'ds = StoredProcedures.SP_BookingSrch(Me.SrchBooking.TextValue, _
            '                                     Me.SrchStatus.Code, _
            '                                     IIf(Me.SrchClients.Text = "", "(ALL)", Me.SrchClients.ClientID.ToString), _
            '                                     IIf(CurrentUser.IsSalesAdmin = True Or CurrentUser.BookingViewer = True, "", CurrentUser.ID.ToString), CurrentShippingLine)


            DA.SelectCommand = Cmd
            DA.Fill(ds)
            TB.Clear()
            TB.Merge(ds.Tables(0).Copy)

            Try
                TB.Columns.Remove("SalesMan")
            Catch ex As Exception
            End Try

            If ds.Tables(0).Rows.Count = 0 Then
                MsgBoxGeneral("No Valid Booking !", "Search Result")
                FrmStatus = FormStatus.NoAction
            Else
                FrmStatus = FormStatus.HasData
            End If

            General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)
            LockStatus(False)
            Me.TabBooking.Tabs(0).Selected = True
            Me.GridDetail.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            Me.GridAssignCntrs.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            Me.GridResult.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

            Me.GridResult.DisplayLayout.Bands(0).Columns("BookingNo").Width = 200
        End If

    End Sub
    Private Sub GenerateExcel() 


        Me.GridAssignCntrs.UpdateData()

        If Me.GridAssignCntrs.Rows.Count > 0 Then

            SaveGridToExcel(Me.GridAssignCntrs)

        End If



    End Sub

    'Private Sub GeneralForms_CustomNewClick() Handles GeneralForms.CustomNewClick
    Public Sub GeneralForms_CustomNewClick(ByVal sender As Object, ByVal formId As Integer)

        If (Me.GeneralForms.getItemLevel(Me.GeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts

            Dm = New DataManager(My.Settings.DSN)
            ClearControl(Me)
            DataSetForm.Tables("TB_BookingDetails").Clear()
            DataSetForm.AcceptChanges()
            FrmStatus = FormStatus.NewRecord
            BookingID = System.Guid.NewGuid
            General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)
            Me.BookingNo.Focus()
            '  Me.BookingNo.TextValue = GetNewBookingNo()
            LockStatus(True)
            Me.Status.Code = "R"
            Me.Salesman.GeneralText.Text = CurrentUser.ID.ToString '   Mid(Me.BookingNo.TextValue, 1, 2)
            Me.TabBooking.Tabs(1).Selected = True
        End If

    End Sub

    'For ILS Shortcuts Changed from Private Sub GeneralForms_CustomEditClick() Handles GeneralForms.CustomEditClick
    Public Sub GeneralForms_CustomEditClick(ByVal sender As Object, ByVal formId As Integer)

        If (Me.GeneralForms.getItemLevel(Me.GeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel) Or Shortcut = True) Then 'For ILS Shortcuts

            SetDocument()
            FrmStatus = FormStatus.EditRecord
            General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)
            LockStatus(True)
            Me.TabBooking.Tabs(1).Selected = True
            Me.GridDetail.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            Me.GridAssignCntrs.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            Me.GridResult.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

        End If

    End Sub

    'For ILS Shortcuts: Changed from Private Sub GeneralForms_CustomSaveClick() Handles GeneralForms.CustomSaveClick
    Public Sub GeneralForms_CustomSaveClick(ByVal sender As Object, ByVal formId As Integer)

        If (Me.GeneralForms.getItemLevel(Me.GeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts

            Dim logDs As DataSet

            If Me.Status.Code = "R" Or CurrentUser.IsSalesAdmin = True Then
                If ValidateForm() Then
                    If MsgBoxUpdate() = Windows.Forms.DialogResult.Yes Then
                        SendDataToClass()
                        Try
                            logDs = Dm.DataSet.Copy
                            Dm.CommitAll()
                            GenerateLog(logDs)
                            MsgBoxSaveSuccessful()
                            FrmStatus = FormStatus.EditRecord
                            General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)
                            LockStatus(False)
                        Catch ex As Exception
                            MsgBoxSaveFailed()
                            MsgBox(ex.ToString)
                        End Try
                    End If
                End If
            Else
                MsgBox("Not Allowed !", MsgBoxStyle.Critical)
            End If
        End If
    End Sub

    'For ILS Shortcuts Changed from Private Sub GeneralForms_CustomDeleteClick() Handles GeneralForms.CustomDeleteClick
    Public Sub GeneralForms_CustomDeleteClick(ByVal sender As Object, ByVal formId As Integer)

        If (Me.GeneralForms.getItemLevel(Me.GeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts

            Dim Dr As DataRow
            Dim Logds As DataSet

            If Me.Status.Code = "R" Then
                If MsgBoxDelete() = Windows.Forms.DialogResult.Yes Then
                    Try
                        For Each Dr In Dm.DataSet.Tables("TB_BookingDetails").Rows
                            Dr.Delete()
                        Next
                        Dm.DataSet.Tables("TB_Booking").Rows(0).Delete()
                        Logds = Dm.DataSet.Copy
                        Dm.CommitAll()
                        GenerateLog(Logds)
                        MsgBoxDeleteSuccessful()
                        ClearControl(Me)
                        Me.DataSetForm.Tables("TB_BookingDetails").Clear()
                        FrmStatus = FormStatus.NoAction
                        LockStatus(False)

                    Catch ex As Exception
                        MsgBoxDeleteFailed()
                        MsgBox(ex.ToString)
                    End Try
                End If
            Else
                MsgBox("Not Allowed !", MsgBoxStyle.Critical)
            End If
        End If

    End Sub

    'For ILS Shortcuts: Changed from Private Sub GeneralForms_CustomOthers() Handles GeneralForms.CustomOthers
    Public Sub GeneralForms_CustomOthers(ByVal sender As Object, ByVal formId As Integer)

        If (Me.GeneralForms.getItemLevel(Me.GeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts

            If GeneralForms.KeySelect = "Memo" Then
                GenerateMemo()
            ElseIf GeneralForms.KeySelect = "Firm" Then
                GenerateFirm()
            ElseIf GeneralForms.KeySelect = "Export" Then
                GenerateExcel()
            End If

        End If

    End Sub

    Private Sub GeneralForms_CustomHomeClick() Handles GeneralForms.CustomHomeClick
        Me.Close()
    End Sub

    'For ILS Shortcuts: Changed from Private Sub GeneralForms_CustomPrintClick() Handles GeneralForms.CustomPrintClick
    Public Sub GeneralForms_CustomPrintClick(ByVal sender As Object, ByVal formId As Integer)
        If (Me.GeneralForms.getItemLevel(Me.GeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts
            Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            Dim Frm As FrmGeneralReportShow
            Dim subreportObject As CrystalDecisions.CrystalReports.Engine.SubreportObject
            Dim SUBA As CrystalDecisions.CrystalReports.Engine.ReportDocument
            Dim subreportName As String
            Dim PH As New CLPrintHdr
            Dim Usr As TB_Users
            Dim Ans As Boolean
            Dim Ds As DataSet
            Dim Mstr As DataTable
            Dim Detl As DataTable
            Dim ID As String
            Dim Bk As String

            If Me.SrchBooking.TextValue = "" And Me.GridResult.Rows.Count = 0 Then
                MsgBox("Nothing For Print !")
                Exit Sub
            End If

            If Me.SrchBooking.TextValue = "" Then
                If Me.GridResult.ActiveRow Is Nothing Then
                    MsgBox("Plesae select a Booking !")
                    Exit Sub
                End If
                Bk = Me.GridResult.ActiveRow.Cells("Bookingno").Text
            Else
                Bk = Me.SrchBooking.TextValue
            End If

            Dm.QueryCriteria.Clear()
            Dm.QueryCriteria.And(JoinPath.TB_Booking.Columns.BookingNo, Bk, MatchType.Exact)
            Booking = Dm.GetTB_Booking
            If Booking Is Nothing Then
                MsgBox("No Valid Booking !")
                Exit Sub
            End If

            Ds = New DataSet
            Ds = StoredProcedures.SP_GetBookingViewByID(Booking.ID.ToString)
            Mstr = Ds.Tables(0)
            Mstr.Rows(0).Item("Terms") = IIf(Mstr.Rows(0).Item("Terms") = "C", "COLLECT", "PREPAID")


            Ds = New DataSet
            Ds = StoredProcedures.SP_GetBookingDetailViewByBookingID(Mstr.Rows(0).Item("id").ToString)
            Detl = Ds.Tables(0)


            'Ans = RetriveObject("Booking", "c:\Booking.rpt")
            'If Ans = True Then
            '    Report.Load("c:\Booking.rpt")
            'Else
            '   
            'End If
            Report = New RptBooking

            'Try
            '    Report.Subreports("RptFooter.rpt").SetDataSource(GetReportFooterData)
            'Catch ex As Exception
            'End Try

            Dm.QueryCriteria.Clear()
            Dm.QueryCriteria.And(JoinPath.TB_Users.Columns.ID, Booking.SalesMan, MatchType.Exact)
            Usr = Dm.GetTB_Users

            Frm = New FrmGeneralReportShow
            'Report.Subreports("RptHedaerLogo.rpt").SetDataSource(PH.ImageTable)
            '  Report.Subreports(1).SetDataSource(PH.ImageTable)

            Report.SetDataSource(Mstr)

            'subreportObject = Report.ReportDefinition.ReportObjects.Item("Subreport2")
            'subreportName = subreportObject.SubreportName
            'SUBA = Report.OpenSubreport(subreportName)
            'SUBA.SetDataSource(Detl)
            'If Not Usr Is Nothing Then
            '    Report.SetParameterValue(0, Usr.UserFirstName & " " & Usr.UserLastName)
            'Else
            '    Report.SetParameterValue(0, " ")
            'End If

            If Detl.Rows.Count > 0 Then
                Report.SetParameterValue(0, Detl.Rows(0).Item("TotalCntrs"))
                Report.SetParameterValue(1, Detl.Rows(0).Item("CnSize") + "'")
                Report.SetParameterValue(2, Detl.Rows(0).Item("CnType"))
            Else
                Report.SetParameterValue(0, "")
                Report.SetParameterValue(1, "")
                Report.SetParameterValue(2, "")
            End If

            Frm.ReportViewer.ReportSource = Report
            Frm.Show()
        End If

    End Sub

    Public Sub chkTip_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkTip.CheckedChanged
        Dim ndr As DataRow
        If chkTip.Checked = True Then
            ndr = Me.DataSetForm.Tables("TB_BookingDetails").NewRow
            ndr("ChargeItem") = "TIP"
            ndr("QTShipper") = 250000
            ndr("QTCarrier") = 250000
            ndr("CurCode") = "IRR"
            Me.DataSetForm.Tables("TB_BookingDetails").Rows.Add(ndr)
            Me.DataSetForm.Tables("TB_BookingDetails").AcceptChanges()
        End If
    End Sub
End Class