Imports OrmLib
Imports ShippingBiz

Public Class FrmSalesActivity

    Private Dm As DataManager
    Private Sub FrmSalesActivity_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim Tb As DataTable
        Dim Users As New TB_UsersCollection

        Dm = New DataManager(My.Settings.DSN)
        Me.DateFrom.InitControl(False, False)
        Me.DateTo.InitControl(False, False)
        If CurrentUser.IsSalesAdmin = True Then
            Users = Dm.GetTB_UsersCollection()
            Tb = Dm.DataSet.Tables("TB_Users").Copy
            Me.SalesMan.ComboGnrl.Enabled = True
        Else
            Dm.QueryCriteria.Clear()
            Dm.QueryCriteria.And(JoinPath.TB_Users.Columns.ID, CurrentUser.ID, MatchType.Exact)
            Dm.GetTB_Users()
            Tb = Dm.DataSet.Tables("TB_Users").Copy
            Me.SalesMan.ComboGnrl.Enabled = False
        End If
        Me.SalesMan.CustomDatasource = Tb
        Me.SalesMan.CustomValueMember = "ID"
        Me.SalesMan.CustomDisplayMember = "UserAccount"

        Me.DateFrom.GnrlDate.Value = DateAdd(DateInterval.Day, -30, Now.Date())
        Me.DateTo.GnrlDate.Value = Now.Date()

    End Sub

    Private Sub MenuItem_CustomPickupClick() Handles MenuItem.CustomPickupClick
        Dim ds As DataSet
        ds = StoredProcedures.SP_SalesActivity(Me.SalesMan.ComboGnrl.SelectedItem(0).ToString, Me.DateFrom.GnrlDate.DateTime.Date, Me.DateTo.GnrlDate.DateTime.Date)
        Me.GridResult.DataSource = ds.Tables(0)
        With Me.GridResult.DisplayLayout.Bands(0)
            .HeaderVisible = True
            .Header.Activated = True
            .Header.Caption = "Sales Activity From:" & Format(Me.DateFrom.DateValue, "Short date") & "  To:" & Format(Me.DateTo.DateValue, "Short date") & " For " & Me.SalesMan.ComboGnrl.Text
            .Header.Appearance.BackColor = Color.Maroon
            .Header.Appearance.ForeColor = Color.Yellow
            .Header.Appearance.FontData.Name = "Verdana"
            .Header.Appearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.True
            .Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
            .Header.Appearance.FontData.SizeInPoints = 8
        End With
        GridNumSeperator(Me.GridResult)

    End Sub

    Private Sub MenuItem_CustomToExcelClick() Handles MenuItem.CustomToExcelClick

        If Me.GridResult.Rows.Count = 0 Then
            Exit Sub
        End If
        SaveGridToExcel(Me.GridResult)

    End Sub

  
End Class