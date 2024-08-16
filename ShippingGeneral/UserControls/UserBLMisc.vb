Imports OrmLib
Imports ShippingBiz

Public Class UserBLMisc
    Private Discount As TB_InwardDiscount
    Private DM As DataManager
    Public Sub InitControl()

        Me.TxtMBL.SetLength(50)
        Me.TxtFwdAgent.SetLength(50)
        Me.TxtFwdLine.SetLength(50)
        Me.CmbStatus.InitControl("BT", UserComboCode.ShowCoumn.Meaning)
        If CurrentUser.IsDocAdmin = True Then
            CmbStatus.Enabled = True
        Else
            CmbStatus.Enabled = False
        End If
        Me.TxtFrtCoverdBlNo.SetLength(20)


        Me.dFreeDays.InitControl(2, 0)

        dm = New DataManager(My.Settings.DSN)
        dm.QueryCriteria.Clear()
        dm.QueryCriteria.And(JoinPath.TB_DetentionBase.Columns.ImpExp, "I", MatchType.Exact)
        dm.QueryCriteria.And(JoinPath.TB_DetentionBase.Columns.IsBase, "N", MatchType.Exact)
        dm.GetTB_DetentionBaseCollection()

        With DetnID
            .DataSource = dm.DataSet.Tables("TB_DetentionBase").Copy
            For Each Col In .DisplayLayout.Bands(0).Columns
                Col.Hidden = True
            Next
            .DisplayLayout.Bands(0).Columns("Remarks").Hidden = False
            .DisplayMember = "Remarks"
            .ValueMember = "ID"
            .DisplayLayout.Bands(0).Columns("Remarks").Width = Me.DetnID.Width
        End With
 
    End Sub

    Public Sub SetDocument(ByVal Dr As DataRow)

        Me.TxtMBL.GeneralTxt.Text = NullToValue(Dr("MBL"), "")
        Me.TxtFwdAgent.GeneralTxt.Text = NullToValue(Dr("FwAgent"), "")
        Me.TxtFwdLine.GeneralTxt.Text = NullToValue(Dr("FwdLine"), "")
        Me.TxtFrtCoverdBlNo.GeneralTxt.Text = NullToValue(Dr("FrtCoverdBlNo"), "")
        Me.CmbStatus.Code = NullToValue(Dr("Status"), "")
        Me.BarCode.TextValue = NullToValue(Dr("BarCode"), "")

        If UserBLS.InwardOutward.Inward = True Then
            Me.HSCode.TextValue = NullToValue(Dr("HSCode"), "")
        End If
        If CurrentUser.IsDocAdmin = True Then
            CmbStatus.Enabled = True
        Else
            CmbStatus.Enabled = False
        End If

    End Sub

    Public Sub SetDocument(ByVal Dr As DataRow, ByVal Dscnt As TB_InwardDiscount)

        Me.TxtMBL.GeneralTxt.Text = NullToValue(Dr("MBL"), "")
        Me.TxtFwdAgent.GeneralTxt.Text = NullToValue(Dr("FwAgent"), "")
        Me.TxtFwdLine.GeneralTxt.Text = NullToValue(Dr("FwdLine"), "")
        Me.TxtFrtCoverdBlNo.GeneralTxt.Text = NullToValue(Dr("FrtCoverdBlNo"), "")
        Me.CmbStatus.Code = NullToValue(Dr("Status"), "")
        Me.BarCode.TextValue = NullToValue(Dr("BarCode"), "")
        Me.HSCode.TextValue = NullToValue(Dr("HSCode"), "")
        If CurrentUser.IsDocAdmin = True Then
            CmbStatus.Enabled = True
        Else
            CmbStatus.Enabled = False
        End If

        Me.IsFDaysAsDiscount.Checked = False
        Me.DetnID.Value = Nothing
        Me.dFreeDays.GnrlNum.Value = 0

        Me.dFreeDays.GnrlNum.Value = Int16.Parse(NullToValue(Dscnt.dFreeDays, 0).ToString)

        If Dscnt.IsFDaysAsDiscount.IsNull = True Then
            Me.IsFDaysAsDiscount.Checked = False
        Else
            Me.IsFDaysAsDiscount.Checked = Dscnt.IsFDaysAsDiscount
        End If

        Try
            Me.DetnID.Value = Dscnt.DetentionID
        Catch ex As Exception
            Me.DetnID.Value = Nothing
        End Try
 
    End Sub


    Public Sub GetDocument(ByRef Dr As DataRow)

        Dr("MBL") = Me.TxtMBL.GeneralTxt.Text
        Dr("FwAgent") = Me.TxtFwdAgent.GeneralTxt.Text
        Dr("FwdLine") = Me.TxtFwdLine.GeneralTxt.Text
        Dr("FrtCoverdBlNo") = Me.TxtFrtCoverdBlNo.GeneralTxt.Text
        If UserBLS.InwardOutward.Inward = True Then
            Dr("HSCode") = Me.HSCode.TextValue
        End If
        'If CurrentUser.IsDocAdmin = True Then
        '    Dr("Status") = Me.CmbStatus.Code
        'End If

    End Sub

    Public Property MBL() As String
        Get
            Return TxtMBL.GeneralTxt.Text
        End Get
        Set(ByVal value As String)
            TxtMBL.GeneralTxt.Text = value
        End Set
    End Property

    Public Property FwdLine() As String
        Get
            Return TxtFwdLine.GeneralTxt.Text
        End Get
        Set(ByVal value As String)
            TxtFwdLine.GeneralTxt.Text = value
        End Set
    End Property

    Public Property FwdAgent() As String
        Get
            Return TxtFwdAgent.GeneralTxt.Text
        End Get
        Set(ByVal value As String)
            TxtFwdAgent.GeneralTxt.Text = value
        End Set
    End Property

    Public Property Status() As String
        Get
            Return CmbStatus.Code
        End Get
        Set(ByVal value As String)
            Me.CmbStatus.Code = value
        End Set
    End Property

    Public Property FrtCoverdBlNo() As String
        Get
            Return Me.TxtFrtCoverdBlNo.TextValue
        End Get
        Set(ByVal value As String)
            Me.TxtFrtCoverdBlNo.TextValue = value
        End Set
    End Property

    Public Sub Checking(ByRef TB As DataTable)
        If Me.TxtFrtCoverdBlNo.TextValue <> "" Then
            Dim xTb As New DataTable
            Dim lResult As Boolean
            TableBySql("Select * From Tb_InwardBls Where Line = '" & CurrentShippingLine & "' and BlNo = '" & Me.TxtFrtCoverdBlNo.TextValue & "'", xTb, lResult)
            If xTb.Rows.Count = 0 Then
                AddRowToErrorTable(TB, "B/L Misc Data", "Master B/L No Is Wrong !", ErrMsgtype.Err)
            End If
        End If

    End Sub

    Public Property FreeDays() As Integer
        Get
            Return Me.dFreeDays.GnrlNum.Value
        End Get
        Set(ByVal value As Integer)
            Me.dFreeDays.GnrlNum.Value = value
        End Set
    End Property

    Public Property DetentionID() As Guid
        Get
            Return Me.DetnID.Value
        End Get
        Set(ByVal value As Guid)
            Me.DetnID.Value = value
        End Set
    End Property

    Public Property FreeDaysAsDiscount() As Boolean
        Get
            Return Me.IsFDaysAsDiscount.Checked
        End Get
        Set(ByVal value As Boolean)
            Me.IsFDaysAsDiscount.Checked = value
        End Set
    End Property
End Class
