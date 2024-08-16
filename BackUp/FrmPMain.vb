Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports OrmLib
Imports ShippingBiz
Imports Infragistics.Win


Public Class FrmPMain
    'For ILS Shortcuts
    Friend Function UltraTabbedMdiManager_TabSelected(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinTabbedMdi.MdiTabEventArgs) Handles TabbedMdiManager.TabSelected
        Dim userGeneralForms As New UserGeneralForms()
        userGeneralForms.InitControlBatchUpdate(e.Tab.Form.Name)
        Return e.Tab.Form.Name
    End Function

    Private Sub FrmPMain_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If MessageBox.Show("ARE YOU SURE FOR QUIT?", "ILS", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            Application.Exit()
        Else
            e.Cancel = True
        End If
    End Sub

    

    Private Sub FrmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim Dm As New DataManager(My.Settings.DSN)
        Dim Ans As Boolean
        Dim Cos As TB_CompanyCollection
        Dim Frm As New FrmLogon
        Dim GP As New UltraWinExplorerBar.UltraExplorerBarGroup("Custom")
        Dim CMs As TB_CustomMenuCollection
        Dim Cm As TB_CustomMenu
        Dim IT As UltraWinExplorerBar.UltraExplorerBarItem
        Dim Cnn As SqlClient.SqlConnection
        Cos = Dm.GetTB_CompanyCollection()
        Me.CompanyLogo.Text = Cos(0).CompanyName & " : " & My.Settings.Office

        Frm.ShowDialog()
        Ans = Frm.Ans
        Frm.Close()

        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_CustomMenu.Columns.MenuItem, ".", MatchType.GreaterOrEqual)
        CMs = Dm.GetTB_CustomMenuCollection

        For Each Cm In CMs
            GP = Me.ExplorerBar.Groups(Mid(Cm.MenuGroup, 4))
            IT = GP.Items(0).Clone
            IT.Text = Cm.MenuItem
            IT.Key = Cm.FormName
            IT.Visible = True
            GP.Items.Add(IT)
        Next

        If Ans = False Then
            Me.Close()
        Else
            Me.Top = 1
            Me.Left = 1
            Me.WindowState = FormWindowState.Maximized
            OpenSelectLines()
            ApplyAccessLevel()
            Me.TabbedMdiManager.MdiParent = Me
        End If

        Cnn = New SqlClient.SqlConnection
        Cnn.ConnectionString = My.Settings.DSN
        DatabaseName = Cnn.Database

        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_CalculationBase.Columns.IsTaxDutyJoin, False, MatchType.IsNotNull)
        calculationBase = Dm.GetTB_CalculationBase

    End Sub

    Private Sub ExplorerBar_ItemClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinExplorerBar.ItemEventArgs) Handles ExplorerBar.ItemClick

        Select Case e.Item.Key
            Case "VESSEL"
                OpenChaild(FrmVessels)
            Case "PORTS"
                OpenChaild(FrmPorts)
            Case "VOYAGE"
                OpenChaild(FrmVoyage)
            Case "CODEING"
                OpenChaild(FrmReferences)
            Case "CLIENTS"
                OpenChaild(FrmClients)
            Case "BL DATA"
                OpenChaild(FrmInwardBls)
            Case "E.C.S."
                OpenChaild(FrmEcs)
            Case "Import Data From Inward"
                OpenChaild(FrmEcsImport)
            Case "Booking Data"
                OpenChaild(FrmBooking)
            Case "USERS"
                OpenChaild(FrmUsers)
            Case "Charges Base"
                OpenChaild(FrmBLCharges)
            Case "General List"
                OpenChaild(FrmInwardGenaralList)
            Case "Ecs General Reports"
                OpenChaild(FrmEcsReports)
            Case "DetentionBase"
                OpenChaild(FrmDetentionBase)
            Case "InvoiceInward"
                OpenChaild(FrmInwardInvoice)
            Case "InvTrc"
                OpenChaild(FrmInvoiceTrace)
            Case "AccGeneralReports"
                OpenChaild(FrmAccGnrlReport)
            Case "EDI"
                OpenChaild(FrmEDI)
            Case "DesignBL"
                OpenChaild(FrmBlPrintDef)
            Case "BookingTrace"
                OpenChaild(FrmBookingTrace)
            Case "CompanyInfo"
                OpenChaild(FrmCompany)
            Case "Lines"
                OpenChaild(FrmLines)
            Case "Agents"
                OpenChaild(FrmAgents)
            Case "Outward BL DATA"
                OpenChaild(FrmOutwardBls)
            Case "OutwardGeneral List"
                OpenChaild(FrmOutwardGenaralList)
            Case "Discont Data"
                OpenChaild(FrmInwardDiscount)
            Case "InvoiceOutward"
                OpenChaild(FrmOutwardInvoice)
            Case "Permits"
                OpenChaild(FrmPermits)
            Case "General List By Date"
                OpenChaild(FrmInwardGenaralListDate)
            Case "General List By Date Outward"
                OpenChaild(FrmoutwardGenaralListDate)
            Case "Update Batch"
                OpenChaild(FrmEcsBatch)
            Case "InwardSearch"
                OpenChaild(FrmInwardSearch)
            Case "Assign Voyage For Containers"
                OpenChaild(FrmAssignVoyExportCntrs)
            Case "Users Log"
                OpenChaild(FrmLogView)
            Case "Permit Tools"
                OpenChaild(FrmPermitTools)
            Case "T.S. Mapping"
                OpenChaild(FrmWHLMapping)
            Case "T.S. XML"
                OpenChaild(FrmGenXML)
            Case "Search Outward"
                OpenChaild(FrmOutwardSearch)
            Case "Cluses"
                OpenChaild(FrmCluses)
            Case "Setelment"
                OpenChaild(FrmSetelment)
            Case "InvoiceEdit"
                OpenChaild(FrmInvoiceEdit)
            Case "VoyageSummary"
                OpenChaild(FrmVoyageSummary)
            Case "ExpDiscountData"
                OpenChaild(FrmOutwardDiscount)
            Case "Sales Activity"
                OpenChaild(FrmSalesActivity)
            Case "Voyage Summary Outward"
                OpenChaild(FrmVoyageSummaryExp)
            Case "Statestical"
                OpenChaild(FrmStatestical)
            Case "Activity"
                OpenChaild(FrmActivity)
            Case "GenerateVocher"
                OpenChaild(FrmNosaGenerateVC)
            Case "AccountTitle"
                OpenChaild(FrmAccountTitle)
            Case "ApplyCODECO"
                OpenChaild(FrmEcsCodecoApply)
            Case "ReleaseLetter"
                OpenChaild(FrmReleaseLetter)
            Case "Apply D.O. As FC"
                OpenChaild(FrmEcsApplyFC)
            Case "StatesticalExp"
                OpenChaild(FrmStatesticalExp)
            Case "ExchangeRate"
                OpenChaild(FrmExchange)
            Case "TaxBase"
                OpenChaild(FrmTaxBase)
            Case "Sending Documents"
                OpenChaild(FrmSendDocument)
            Case "CustomReportItems"
                OpenChaild(FrmCustomReportItem)
            Case "CalculationBase"
                OpenChaild(FrmCalculationBase)
            Case "MergeCopyInward"
                OpenChaild(FrmBLTools)
            Case "WHLInwardMapping"
                OpenChaild(FrmWHLMapping)
            Case "WHLReports"
                OpenChaild(FrmEcsWHLReports)
            Case "WHLOutwardMapping"
                OpenChaild(FrmWHlMappingOutward)
            Case "RateInquery"
                OpenChaild(FrmInquery)
            Case "InqueryChecking"
                OpenChaild(FrmInqueryCheckList)
            Case "BLTools"
                OpenChaild(FrmBLToolsOutward)
            Case "BarcodeScannedOutwardBls"
                OpenChaild(FrmBarcodeIssuedBls)
            Case "NOSA Account Title EXP"
                OpenChaild(FrmNosaAccountExp)
            Case "NOSA Account Title"
                OpenChaild(FrmNosaAccount)
            Case "GroupInvoice"
                OpenChaild(FrmGroupInvoice)
            Case "GroupRecived"
                OpenChaild(FrmGroupRcvd)
            Case "NOSAConfirm"
                OpenChaild(FrmNosaConfirm)
            Case "Merge Client"
                OpenChaild(FrmClientMerge)
            Case "MergeBooking"
                OpenChaild(FrmBookingMerge)
            Case "ImportShipmentDetails"
                OpenChaild(FrmECSImportShipmentDetails)
            Case "ImportShipmentDetailsDO"
                OpenChaild(FrmECSImportShipmentDetailsDO)
            Case "DetentionOutstandingSummary"
                OpenChaild(FrmDetentionOutStandingSummary)
            Case "ExportDetentionReport"
                OpenChaild(FrmExportDetentionReport)
            Case "DuplicateFreeDays"
                OpenChaild(FrmDuplicateFreeDays)
            Case "InwardDuplicateFreeDays"
                OpenChaild(FrmInwardDuplicateFreeDays)
            Case "Release"
                OpenChaild(About)
            Case "ECSBANK"
                OpenChaild(FrmEcsBank)
            Case "ECSIMPORT"
                OpenChaild(FrmEcsBankImport)
            Case "Client Account Status"
                OpenChaild(FrmClientStatusLock)
            Case "Agent Account Status"
                OpenChaild(FrmAgentStatusLock)
            Case "MAMovements"
                OpenChaild(FrmMAMovement)
            Case "Inward Package Details"
                OpenChaild(FrmInwardPackageDetails)
            Case "Remove D/O"
                OpenChaild(FrmDODelete)
            Case "Charge Wise Report"
                OpenChaild(frmChargewiseReport)
            Case "Guarantee Cheques Report"
                OpenChaild(FrmGuaranteedCheque)
            Case "Location Wise Report"
                OpenChaild(FrmLocationWiseReport)
            Case "TAP Detention Entry"
                OpenChaild(FrmTAPDetentionChrg)
            Case Else
                OpenChaild(DynamicallyLoadedObject(e.Item.Key))
        End Select

    End Sub

    Private Sub OpenVesselForm()

        Dim Frm As FrmVessels
        Frm = New FrmVessels
        Frm.MdiParent = Me
        Frm.Show()

    End Sub

    Private Sub OpenPorts()

        Dim Frm As FrmPorts
        Frm = New FrmPorts
        Frm.MdiParent = Me
        Frm.Show()

    End Sub

    Private Sub OpenPortsForm()

        Dim Frm As FrmPorts
        Frm = New FrmPorts
        Frm.MdiParent = Me
        Frm.Show()

    End Sub

    Private Function CloseChild(ByVal FrmName As String) As Boolean

        If Not Me.ActiveMdiChild Is Nothing Then
            If Me.ActiveMdiChild.Name = FrmName Then
                Return False
            Else
                Me.ActiveMdiChild.Close()
                Return True
            End If
        Else
            Return True
        End If

    End Function

    Private Sub CloseForm(ByVal Frm As Form)

        Frm = Nothing
        Me.ExplorerBar.ActiveItem.Active = False

    End Sub

    Private Sub FrmMain_MdiChildActivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.MdiChildActivate

        If Me.ActiveMdiChild IsNot Nothing Then
        Else
            If Not Me.ExplorerBar.ActiveItem Is Nothing Then
                Me.ExplorerBar.ActiveItem.Active = False
            End If
        End If

    End Sub

    Private Sub OpenChaild(ByVal Frm As Form)

        Dim L As Long = Me.ExplorerBar.Right
        Dim R As Long = Me.CompanyLogo.Bottom
        Dim nI As Byte
        Dim lFound As Boolean = False

        If Me.MdiChildren.Length > 0 Then
            For nI = 0 To Me.MdiChildren.Length - 1
                If Me.MdiChildren(nI).Name = Frm.Name Then
                    Me.MdiChildren(nI).Select()
                    lFound = True
                End If
            Next
        End If

        If lFound = False Then
            Frm.MdiParent = Me
            Frm.Show()
        End If

    End Sub

    Private Sub OpenChaild(ByVal Frm As Form, ByVal Obj As Object)

        If CloseChild(Frm.Name) = True Then
            Frm.MdiParent = Me
            Frm.Show()
        End If

    End Sub

    Private Sub OpenForm(ByVal Frm As Form)

        If CloseChild(Frm.Name) = True Then
            Frm.Show()
        End If

    End Sub

    Private Sub ToolbarsRight_ToolClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinToolbars.ToolClickEventArgs) Handles ToolbarsRight.ToolClick
        Select Case e.Tool.Key

            Case "Ports"
                OpenSearchPort()
            Case "Clients"
                OpenSearchClients()
            Case "ChangeLine"
                OpenSelectLines()
            Case "About"
                FRmAboutBox.ShowDialog()
        End Select

    End Sub

    Private Sub OpenSearchPort()

        Dim Frm As New FrmPortDialog
        Frm.ShowDialog()

    End Sub

    Private Sub OpenSearchClients()

        Dim Frm As New FrmClientDialog
        Frm.ShowDialog()

    End Sub

    Private Sub OpenSelectLines()
        Dim Frm As New FrmChangeLineDialog
        Frm.ShowDialog()
        Me.LblLine.Text = "Current Line : " & CurrentShippingLine

    End Sub

    Private Sub ApplyAccessLevel()

        Dim Dm As New DataManager(My.Settings.DSN)
        Dim DS As DataSet
        Dim Dr As DataRow
        Dim nItem As Long
        Dim SubItem As Integer
        Dim UAccess As TB_AccessLevelCollection
        Dim UA As New TB_AccessLevelCollection

        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_MenuItems.Columns.ItemLevel, "", MatchType.GreaterOrEqual)
        Dm.GetTB_MenuItemsCollection()
        DS = New DataSet
        DS.Tables.Add(Dm.DataSet.Tables("Tb_MenuItems").Copy)
        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_AccessLevel.Columns.UserID, CurrentUser.ID, MatchType.Exact)
        UAccess = Dm.GetTB_AccessLevelCollection
        DS.AcceptChanges()

        For Each Dr In DS.Tables(0).Rows

            If Len(Trim(Dr("ItemLevel"))) = 1 Then
                nItem = Val(Trim(Dr("ItemLevel")))
                UA = UAccess.FilterByMenuItemID(Dr("ID"), CompareType.Exact)
                If Not UA Is Nothing Then
                    If UA.Count > 0 Then
                        If UA(0).Accessble = True Then
                            Me.ExplorerBar.Groups(Byte.Parse(nItem.ToString)).Enabled = True
                        Else
                            Me.ExplorerBar.Groups(Byte.Parse(nItem.ToString)).Enabled = False
                        End If
                    End If
                End If
            ElseIf Len(Trim(Dr("ItemLevel"))) = 3 Then
                UA = UAccess.FilterByMenuItemID(Dr("ID"), CompareType.Exact)
                If Not UA Is Nothing Then
                    nItem = Val(Mid(Trim(Dr("ItemLevel")), 1, 1))
                    SubItem = Val(Mid(Trim(Dr("ItemLevel")), 2))

                    If UA.Count > 0 Then
                        If UA(0).Accessble = True Then
                            Me.ExplorerBar.Groups(Byte.Parse(nItem.ToString)).Items(SubItem).Visible = True
                        Else
                            Me.ExplorerBar.Groups(Byte.Parse(nItem.ToString)).Items(SubItem).Visible = False
                        End If
                    End If
                End If
            End If
        Next

    End Sub

    Private Function DynamicallyLoadedObject(ByVal objectName As String, Optional ByVal args() As Object = Nothing) As Form

        Dim returnObj As Object = Nothing
        Dim Type As Type = Assembly.GetExecutingAssembly().GetType("Shipping." & objectName)

        If Type IsNot Nothing Then
            returnObj = Activator.CreateInstance(Type, args)
        End If

        Return returnObj
    End Function

End Class
