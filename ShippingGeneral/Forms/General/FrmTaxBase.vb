Imports OrmLib
Imports ShippingBiz
Imports System.Data.SqlClient
Imports System.IO
Imports System.Xml

Public Class FrmTaxBase
    Implements IFGeneral
    Private ItemLevel As String = "412"
    Private MasterID As Guid
    Private FrmStatus As FormStatus = FormStatus.NoAction
    Private Dm As DataManager
    Private TB As New DataTable
    Private TBTax As TB_TaxBase
    Private TBTaxs As TB_TaxBaseCollection
    Private TbDetails As DataTable
    Private ID As Guid
    Private Temp As DataTable
    Private MS As MemoryStream

    Private Sub FrmTaxBase_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.GeneralForms.InitControl("Tax Base", ItemLevel)
        'Me.ChargesCode.InitControl("CG", UserComboCode.ShowCoumn.Meaning)
        'Me.Port.InitControl(Me.UltraGroupBox1.BackColor)
        Me.ApplyDate.InitControl(False, False)
        Me.Validity.InitControl(False, False)
        Me.tax.InitControl(2, 2)
        Me.Toll.InitControl(2, 2)
        FrmStatus = FormStatus.NoAction
        General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)
        LockStatus(False)
        TbDetails = New DataTable
        With TbDetails
            .Columns.Add(New DataColumn("ChargesCode"))
            .Columns.Add(New DataColumn("IsTax", System.Type.GetType("System.Boolean")))
            .Columns.Add(New DataColumn("IsDuty", System.Type.GetType("System.Boolean")))
        End With
 
    End Sub

    Public Sub LockStatus(ByVal Status As Boolean) Implements IFGeneral.LockStatus
        '       General.LockControls(Me, Status)
    End Sub

    Public Sub Populate() Implements IFGeneral.Populate

        Dim xTb As New DataTable
        Dim xTbNew As New DataTable
        Dim xTbTemp As New DataTable
        Dim lResult As Boolean
        Dim lResult2 As Boolean
        Dim Dr As DataRow
        Dim nDr As DataRow
        Dim mXml As New XmlDataDocument


        Me.ApplyDate.DateValue = TBTax.ApplyDate
        Me.Validity.DateValue = TBTax.validity
        Me.tax.GnrlNum.Value = Double.Parse(TBTax.Tax)
        Me.Toll.GnrlNum.Value = Double.Parse(TBTax.TOLL)


        TbDetails.Clear()
        TbDetails.AcceptChanges()
        TableBySql("Select Charges From Tb_TaxBase Where ID = '" & TBTax.ID.ToString & "'", xTb, lResult)

        If lResult = True Then
            Try
                '            TbDetails = XmlToTable(xTb.Rows(0).Item(0))
                mXml.LoadXml(xTb.Rows(0).Item(0).ToString)
                For Each node As XmlNode In mXml.SelectNodes("DocumentElement/Charges")
                    Dr = TbDetails.NewRow

                    Dr("ChargesCode") = node.ChildNodes(0).FirstChild.Value
                    Dr("IsTax") = Boolean.Parse(node.ChildNodes(1).FirstChild.Value)
                    Dr("IsDuty") = Boolean.Parse(node.ChildNodes(2).FirstChild.Value)
 
                    TbDetails.Rows.Add(Dr)
                Next


            Catch ex As Exception

            End Try

        End If

        
        TableBySql("Select * From Tb_CODE Where GroupCode = 'CG'", xTbNew, lResult2)

        
        If xTbNew.Rows.Count <> 0 And TbDetails.Rows.Count <> 0 Then
            If xTbNew.Rows.Count > TbDetails.Rows.Count Then
                For Each DrNew In xTbNew.Rows
                    Dim foundRow() As DataRow
                    foundRow = TbDetails.Select("Chargescode='" & DrNew("StdCode") & "'")
                    If foundRow.Length = 0 Then
                        nDr = TbDetails.NewRow
                        nDr("ChargesCode") = DrNew("StdCode")
                        nDr("IsTax") = True
                        nDr("IsDuty") = True
                        TbDetails.Rows.Add(nDr)
                    End If

                Next
            End If
        End If

        TbDetails.AcceptChanges()

        If TbDetails.Rows.Count = 0 Then
            Dm.QueryCriteria.Clear()
            Dm.QueryCriteria.And(JoinPath.TB_CODE.Columns.GroupCode, "CG", MatchType.Exact)
            Dm.GetTB_CODECollection()
            For Each Dr In Dm.DataSet.Tables("TB_Code").Rows
                nDr = TbDetails.NewRow
                nDr("ChargesCode") = Dr("StdCode")
                nDr("IsTax") = True
                nDr("IsDuty") = True
                TbDetails.Rows.Add(nDr)
            Next
        End If
        Me.GridDetails.DataSource = TbDetails


    End Sub


    Public Sub SendDataToClass() Implements IFGeneral.SendDataToClass

    End Sub

    'For ILS Shortcuts: Changed from Private Sub GeneralForms_CustomFindClick() Handles GeneralForms.CustomFindClick to GeneralForms_CustomFindClick(ByVal sender As Object, ByVal formId As Integer)
    Public Sub GeneralForms_CustomFindClick(ByVal sender As Object, ByVal formId As Integer)
        If (UserGeneralForms.getItemLevel(UserGeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts  

            Dm = New DataManager(My.Settings.DSN)

            InitGrid()

            Dm.QueryCriteria.And(JoinPath.TB_TaxBase.Columns.ChargesCode, "X", MatchType.Not)
            TBTaxs = Dm.GetTB_TaxBaseCollection
            FrmStatus = FormStatus.NoAction

            If Not TBTaxs Is Nothing Then
                If TBTaxs.Count > 0 Then
                    FrmStatus = FormStatus.HasData
                End If
            End If
            InitGrid()
        End If
    End Sub

    'For ILS Shortcuts: Changed from Private Sub GeneralForms_CustomNewClick() Handles GeneralForms.CustomNewClick
    Public Sub GeneralForms_CustomNewClick(ByVal sender As Object, ByVal formId As Integer)
        If (UserGeneralForms.getItemLevel(UserGeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts
            Dm = New DataManager(My.Settings.DSN)
            FrmStatus = FormStatus.NewRecord
            General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)
            ClearContainer(Me)
            Me.TabControl.Tabs(1).Selected = True
        End If
    End Sub

    'For ILS Shortcuts Changed from Private Sub GeneralForms_CustomEditClick() Handles GeneralForms.CustomEditClick
    Public Sub GeneralForms_CustomEditClick(ByVal sender As Object, ByVal formId As Integer)
        If (UserGeneralForms.getItemLevel(UserGeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts

            ClearControl(Me)

            If FrmStatus = FormStatus.HasData Then
                Dm.QueryCriteria.Clear()
                Dm.QueryCriteria.And(JoinPath.TB_TaxBase.Columns.ID, ID, MatchType.Exact)
                TBTax = Dm.GetTB_TaxBase
                If Not TBTax Is Nothing Then
                    FrmStatus = FormStatus.EditRecord
                    Populate()
                End If
            End If
            Me.TabControl.Tabs(1).Selected = True
            General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)
        End If
    End Sub

    'For ILS Shortcuts: Changed from Private Sub GeneralForms_CustomSaveClick() Handles GeneralForms.CustomSaveClick
    Public Sub GeneralForms_CustomSaveClick(ByVal sender As Object, ByVal formId As Integer)
        If (UserGeneralForms.getItemLevel(UserGeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts

            Dim Dr As DataRow
            Dim LogDataSet As New DataSet
            Dim sXml As String

            Dim Cmd As New SqlCommand
            Dim Cnn As New SqlConnection(My.Settings.DSN)
            Dim SR As StreamReader

            MS = New MemoryStream

            TbDetails.TableName = "Charges"
            TbDetails.AcceptChanges()
            TbDetails.WriteXml(MS)
            MS.Flush()
            MS.Position = 0

            SR = New StreamReader(MS)
            sXml = SR.ReadToEnd


            If ValidateForm() = False Then
                Exit Sub
            End If

            If MsgBox("Do You Want To Update This Record ?", MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then
                Exit Sub
            End If
            Dm = New DataManager(My.Settings.DSN)
            If FrmStatus = FormStatus.NewRecord Then
                Dr = Dm.DataSet.Tables("TB_TaxBase").NewRow
                ID = Guid.NewGuid
                Dr("ID") = Guid.NewGuid
                Dr("ChargesCode") = "*" ' Me.ChargesCode.Code
                Dr("ApplyDate") = Me.ApplyDate.DateValue
                Dr("Validity") = Me.Validity.DateValue
                Dr("Tax") = Me.tax.GnrlNum.Value
                Dr("Toll") = Me.Toll.GnrlNum.Value
                Dr("Port") = "*" ' Me.Port.TextPort.TextValue
                Dm.DataSet.Tables("TB_TaxBase").Rows.Add(Dr)
            Else
                Dm.QueryCriteria.Clear()
                Dm.QueryCriteria.And(JoinPath.TB_TaxBase.Columns.ID, ID, MatchType.Exact)
                TBTax = Dm.GetTB_TaxBase
                If Not TBTax Is Nothing Then
                    Dr = Dm.DataSet.Tables("TB_TaxBase").Rows(0)
                    Dr("ApplyDate") = Me.ApplyDate.DateValue
                    Dr("Validity") = Me.Validity.DateValue
                    Dr("Tax") = Me.tax.GnrlNum.Value
                    Dr("Toll") = Me.Toll.GnrlNum.Value
                    Dr("Port") = "*" ' Me.Port.TextPort.TextValue
                    Dr("ChargesCode") = "*"
                End If
            End If

            Try
                LogDataSet = Dm.DataSet.Copy
                Dm.CommitAll()

                Cnn.Open()
                Cmd = New SqlCommand
                With Cmd
                    .CommandText = "Update TB_TaxBase Set Charges = @Charges where ID = @ID"
                    .CommandType = CommandType.Text
                    .Connection = Cnn
                    .Parameters.AddWithValue("@Charges", sXml)
                    .Parameters.AddWithValue("@ID", ID.ToString)
                    .CommandTimeout = 2000
                End With
                Cmd.ExecuteNonQuery()

                GenerateLog(LogDataSet)
                MsgBoxSaveSuccessful()
                FrmStatus = FormStatus.NoAction
                General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)
                Call GeneralForms_CustomFindClick(sender, formId)
            Catch ex As Exception
                General.MsgBoxSaveFailed()
                MessageBox.Show(ex.ToString)
            End Try
        End If
    End Sub

    'For ILS Shortcuts Changed from Private Sub GeneralForms_CustomDeleteClick() Handles GeneralForms.CustomDeleteClick
    Public Sub GeneralForms_CustomDeleteClick(ByVal sender As Object, ByVal formId As Integer)
        If (UserGeneralForms.getItemLevel(UserGeneralForms.UserTabSelected) = Convert.ToInt32(ItemLevel)) Then 'For ILS Shortcuts

            Dim LogDataset As New DataSet

            If Me.FrmStatus = FormStatus.EditRecord Then

                Dm = New DataManager(My.Settings.DSN)
                Dm.QueryCriteria.And(JoinPath.TB_TaxBase.Columns.ID, ID, MatchType.Exact)
                TBTax = Dm.GetTB_TaxBase

                If Not TBTax Is Nothing Then
                    If MsgBoxDelete() = Windows.Forms.DialogResult.Yes Then
                        Dm.DataSet.Tables("TB_TaxBase").Rows(0).Delete()
                        Try
                            LogDataset = Dm.DataSet.Copy
                            Dm.CommitAll()
                            GenerateLog(LogDataset)
                            MsgBoxDeleteSuccessful()
                            FrmStatus = FormStatus.NoAction
                            General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)
                            Call GeneralForms_CustomFindClick(sender, formId)
                        Catch ex As Exception
                            General.MsgBoxDeleteFailed()
                            MessageBox.Show(ex.ToString)
                        End Try

                    End If
                End If
            End If
        End If
    End Sub

    Private Sub InitGrid()

        Me.GridData.DataSource = Dm.DataSet.Tables("TB_TaxBase")

        With Me.GridData.DisplayLayout.Bands(0)
            .Columns("Port").Hidden = True
            .Columns("ChargesCode").Hidden = True
        End With
        GridNumSeperator(Me.GridData)
    End Sub

    Private Function ValidateForm() As Boolean

        'If Me.ChargesCode.Code = "" Then
        '    MsgBox("No Valid Code !", MsgBoxStyle.Critical)
        '    Return False
        'End If

        'If Me.Port.IsValidPort = False Then
        '    If Me.Port.TextPort.TextValue <> "*" Then
        '        MsgBox("Invalid Port Code !", MsgBoxStyle.Critical)
        '        Return False
        '    End If
        'End If

        If CDate(Me.Validity.DateValue) < CDate(Me.ApplyDate.DateValue) Then
            MsgBox("Check Date Values !", MsgBoxStyle.Critical)
            Return False
        End If

        If Me.tax.GnrlNum.Value + Me.Toll.GnrlNum.Value = 0 Then
            MsgBox("Please Check Tax & Toll Value", MsgBoxStyle.Critical)
            Return False
        End If
        Return True
    End Function

    Private Sub GridData_AfterRowActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridData.AfterRowActivate

        Dim DummyValue As String
        If Me.GridData.Rows.Count > 0 Then
            Try
                ID = Me.GridData.ActiveRow.Cells("ID").Value
            Catch ex As Exception
                ID = Guid.Empty
            End Try
        End If
        DummyValue = "*" ' Me.ChargesCode.Code
        ClearControl(Me)
        '      Me.ChargesCode.Code = DummyValue
        Dm.QueryCriteria.Clear()
        Dm.QueryCriteria.And(JoinPath.TB_TaxBase.Columns.ID, ID, MatchType.Exact)
        TBTax = Dm.GetTB_TaxBase
        FrmStatus = FormStatus.NoAction
        If Not TBTax Is Nothing Then
            FrmStatus = FormStatus.HasData
        Else
            FrmStatus = FormStatus.NoAction
        End If
        General.GnrlFormKeyStatusChange(Me.GeneralForms.CustomToolbar, FrmStatus)
    End Sub

    Private Sub GridData_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles GridData.InitializeLayout

    End Sub
End Class