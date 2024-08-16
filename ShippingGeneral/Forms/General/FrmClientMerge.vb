Imports OrmLib
Imports ShippingBiz
Imports Infragistics.Win.UltraWinGrid

Public Class FrmClientMerge
    'For ILS Shortcuts  
    Private ItemLevel = "306"
    'For ILS Shortcuts  
    Private Sub TextSearch_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles TextSearch.KeyDown

        If e.KeyValue = 13 Then
            ButtonPickupClientMergeText_Click(sender, e)
        End If

    End Sub


    Public Sub ButtonPickupClientMergeText_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Handles ButtonPickupClientMerge.Click

        Dim sSql As String = ""
        Dim lResult As Boolean
        Dim TB As New DataTable
        Dim DR
        Me.TextSearch.Focus()
        If Me.TextSearch.TextValue = "" Then
            MsgBox("Please Fill Text Serach ")
            Exit Sub
        End If

        sSql = "Select * From Tb_Clients Where lName Like '%" & Me.TextSearch.TextValue & "%'"

        TableBySql(sSql, TB, lResult)
        TB.Columns.Add(New DataColumn("Select", System.Type.GetType("System.Boolean")))
        For Each DR In TB.Rows
            DR("Select") = False
        Next

        TB.AcceptChanges()



        Me.GridResult.DataSource = TB
        GridNumSeperator(GridResult)
        Me.GridResult.DisplayLayout.Bands(0).Columns("SElect").Header.VisiblePosition = 1


    End Sub
    'For ILS Shortcuts changed from Private Sub ButtonPickup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPickup.Click
    Public Sub ButtonPickupClientMerge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPickupClientMerge.Click

        Dim sSql As String = ""
        Dim lResult As Boolean
        Dim TB As New DataTable
        Dim DR

        If Me.TextSearch.TextValue = "" Then
            MsgBox("Please Fill Text Serach ")
            Exit Sub
        End If

        sSql = "Select * From Tb_Clients Where lName Like '%" & Me.TextSearch.TextValue & "%'"

        TableBySql(sSql, TB, lResult)
        TB.Columns.Add(New DataColumn("Select", System.Type.GetType("System.Boolean")))
        For Each DR In TB.Rows
            DR("Select") = False
        Next

        TB.AcceptChanges()



        Me.GridResult.DataSource = TB
        GridNumSeperator(GridResult)
        Me.GridResult.DisplayLayout.Bands(0).Columns("SElect").Header.VisiblePosition = 1


    End Sub

    Private Sub FrmClientMerge_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.TextSearch.SetLength(100)


    End Sub

    Private Sub ButtonSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSave.Click

        Dim InBls As TB_InwardBLSCollection
        Dim OutBls As TB_OutwardBLSCollection
        Dim Bookings As TB_BookingCollection
        Dim Damage As TB_DamageCollection
        Dim R As UltraGridRow
        Dim Dm As New DataManager(My.Settings.DSN)
        Dim LogDataSet As DataSet
        Dim Dr As DataRow
        Dim aList As New ArrayList
        Dim lHaveRecord As Boolean = False

        If Me.GridResult.Rows.Count = 0 Then
            Exit Sub
        End If

        If Me.Client.ClientID.ToString = Guid.Empty.ToString Then
            MsgBox("No Valid Client For Merge !")
            Exit Sub
        End If

        Me.GridResult.UpdateData()

        For Each R In GridResult.Rows
            If R.Cells("Select").Value = True Then
                If R.Cells("ID").Value <> Me.Client.ClientID Then
                    Dm.QueryCriteria.Clear()
                    Dm.QueryCriteria.And(JoinPath.TB_InwardBLS.Columns.ClientID, R.Cells("ID").Value, MatchType.Exact)
                    Dm.GetTB_InwardBLSCollection()

                    Dm.QueryCriteria.Clear()
                    Dm.QueryCriteria.And(JoinPath.TB_OutwardBLS.Columns.ClientID, R.Cells("ID").Value, MatchType.Exact)
                    Dm.GetTB_OutwardBLSCollection()

                    Dm.QueryCriteria.Clear()
                    Dm.QueryCriteria.And(JoinPath.TB_Booking.Columns.ClientID, R.Cells("ID").Value, MatchType.Exact)
                    Dm.GetTB_BookingCollection()

                    Dm.QueryCriteria.Clear()
                    Dm.QueryCriteria.And(JoinPath.TB_Damage.Columns.InvoiceTo, R.Cells("ID").Value, MatchType.Exact)
                    Dm.GetTB_DamageCollection()

                    aList.Add(R.Cells("ID").Value.ToString)
                    lHaveRecord = True
                End If

            End If
        Next

        For Each s As String In aList
            Dm.QueryCriteria.Clear()
            Dm.QueryCriteria.And(JoinPath.TB_Clients.Columns.ID, s, MatchType.Exact)
            Dm.GetTB_Clients()
        Next

        If lHaveRecord = False Then
            MsgBox("No Any Data Select For Merge !")
            Exit Sub
        End If

        For Each Dr In Dm.DataSet.Tables("TB_InwardBLS").Rows
            Dr("ClientID") = Me.Client.ClientID
        Next

        For Each Dr In Dm.DataSet.Tables("TB_OutwardBLS").Rows
            Dr("ClientID") = Me.Client.ClientID
        Next

        For Each Dr In Dm.DataSet.Tables("TB_Booking").Rows
            Dr("ClientID") = Me.Client.ClientID
        Next

        For Each Dr In Dm.DataSet.Tables("TB_Damage").Rows
            Dr("InvoiceTo") = Me.Client.ClientID
        Next

        For Each Dr In Dm.DataSet.Tables("TB_Clients").Rows
            Dr.Delete()
        Next


        Try
            LogDataSet = Dm.DataSet.Copy
            Dm.CommitAll()
            GenerateLog(LogDataSet)
            MsgBoxSaveSuccessful()
            'For ILS Shortcuts
            ButtonPickupClientMergeText_Click(Me, New System.EventArgs)
        Catch ex As Exception
            MsgBoxDeleteFailed()
            MsgBoxGeneral(ex.ToString, "Error")
        End Try

    End Sub
End Class