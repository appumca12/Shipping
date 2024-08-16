Imports OrmLib
Imports ShippingBiz
Imports System.Data.SqlClient

Public Class FrmBookingReport

    Private Dm As DataManager
    Private Sub FrmBookingReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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

        Dim ds As New DataSet
        Dim Dr As DataRow


        Dim Cmd As New SqlCommand
        Dim Cnn As New SqlConnection(My.Settings.DSN)
        Dim DA As New SqlDataAdapter

        With Cmd
            .CommandText = "SP_BookingReport"
            .CommandType = CommandType.StoredProcedure
            .Connection = Cnn
            .CommandTimeout = 5000
            .Parameters.AddWithValue("@DFrom", Date.Parse(Me.DateFrom.DateValue).Date)
            .Parameters.AddWithValue("@DTo", Date.Parse(DateTo.DateValue).Date)
            .Parameters.AddWithValue("@Line", CurrentShippingLine)
            '.Parameters.AddWithValue("@office", Me.CmbStatus.Code)
        End With
        DA.SelectCommand = Cmd
        DA.Fill(ds)
        Me.GridResult.DataSource = ds.Tables(0)
        With Me.GridResult.DisplayLayout.Bands(0)
            .HeaderVisible = True
            .Header.Activated = True
            .Header.Caption = "Booking Details From:" & Format(Me.DateFrom.DateValue, "Short date") & "  To:" & Format(Me.DateTo.DateValue, "Short date")
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