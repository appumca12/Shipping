Imports OrmLib
Imports ShippingBiz
Imports System.Data.SqlClient
Imports Infragistics.Win.UltraWinGrid
Public Class FrmReleaseLetter
    Private DS As DataSet
    Private Sub FrmReleaseLetter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DateFrom.InitControl(False, False)
        Me.Dateto.InitControl(False, False)
        Me.MenuItem.ButtonPrint.Visible = False
    End Sub
    Private Sub SetDocument()

        Dim DA As New SqlDataAdapter
        Dim Cmd As New SqlCommand("SP_ReleasePendingList")
        Dim Cnn As New SqlConnection(My.Settings.DSN)
        Dim Col As Infragistics.Win.UltraWinGrid.UltraGridColumn
        Dim RL As DataRelation
        Dim PCol As DataColumn
        Dim cCol As DataColumn
        Dim Drs() As DataRow
        Dim Bks() As DataRow
        Dim Bk As DataRow
        Dim dr As DataRow
        If Me.DateFrom.GnrlDate.Value Is Nothing Or Me.Dateto.GnrlDate.Value Is Nothing Then
            Exit Sub
        End If

        DS = New DataSet
        With Cmd
            .Connection = Cnn
            .CommandType = CommandType.StoredProcedure
            .Parameters.AddWithValue("@dFrom", Me.DateFrom.GnrlDate.Value)
            .Parameters.AddWithValue("@dTo", Me.Dateto.GnrlDate.Value)
            .Parameters.AddWithValue("@BaseOnIssue", IIf(Me.RadioByIssue.Checked = True, "Y", "N"))
        End With
        DA.SelectCommand = Cmd
        DA.Fill(DS)

        DS.Tables(0).TableName = "Booking"
        DS.Tables(1).TableName = "Release"
        DS.Tables(2).TableName = "Cntrs"



        PCol = DS.Tables(0).Columns("ID")
        cCol = DS.Tables(1).Columns("BookingID")
        RL = New DataRelation("BkToRls", PCol, cCol)
        DS.Relations.Add(RL)


        PCol = DS.Tables(1).Columns("ID")
        cCol = DS.Tables(2).Columns("ReleaseID")
        RL = New DataRelation("RlsToCntrs", PCol, cCol)
        DS.Relations.Add(RL)

        Drs = DS.Tables(1).Select("Reference is null")
        For Each dr In Drs
            Bks = DS.Tables(0).Select("ID = '" & dr("BookingID").ToString & "'")
            For Each Bk In Bks
                Bk.RowError = "Request"
            Next
        Next

        Me.GridRelease.DataSource = DS
        For Each Bnd As UltraGridBand In GridRelease.DisplayLayout.Bands
            For Each Col In Bnd.Columns
                If Col.DataType.ToString = "System.Guid" Then
                    Col.Hidden = True
                End If
            Next
        Next

    End Sub

    Private Sub MenuItem_CustomCancelClick() Handles MenuItem.CustomCancelClick

        If Me.GridRelease.Rows.Count = 0 Then
            Exit Sub
        End If

        If NullToValue(Me.GridRelease.ActiveRow.Cells("IssueOffice").Value.ToString, "") <> "" Then
            MsgBox("Release letter already issued !")
            Exit Sub
        End If

        Dim Cmd As New SqlCommand("Delete from TB_BookingRelease Where ID = '" & Me.GridRelease.ActiveRow.Cells("ID").Value.ToString & "'")
        Dim Cnn As New SqlConnection(My.Settings.DSN)
        Dim DA As New SqlDataAdapter
        Dim TB As New DataTable
        Try
            Cnn.Open()
            With Cmd
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = Cnn
            End With
            Cmd.ExecuteNonQuery()
            MsgBox("Cancel OK")
            SetDocument()
        Catch ex As Exception
            MsgBox("Confim Failes ", MsgBoxStyle.Critical)
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub MenuItem_CustomConfirmClick() Handles MenuItem.CustomConfirmClick

        If Me.GridRelease.ActiveRow.Band.Key = "BkToRls" Then
            If NullToValue(Me.GridRelease.ActiveRow.Cells("Reference").Value, "") = "" Then
                updateRelease()
            End If
        End If
    End Sub
    Private Sub MenuItem_CustomRefreshClick() Handles MenuItem.CustomRefreshClick
        SetDocument()
    End Sub

    Private Sub GridRelease_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles GridRelease.InitializeLayout
        e.Layout.Override.SupportDataErrorInfo = SupportDataErrorInfo.RowsAndCells
        e.Layout.Override.DataErrorCellAppearance.ForeColor = Color.Red
        e.Layout.Override.DataErrorRowAppearance.BackColor = Color.LightYellow
        e.Layout.Override.DataErrorRowSelectorAppearance.BackColor = Color.Green
        e.Layout.Override.RowSelectorWidth = 32
    End Sub
    Private Sub updateRelease()

        Dim Cmd As New SqlCommand("SP_AssignNewReleaseSeq")
        Dim Cnn As New SqlConnection(My.Settings.DSN)
        Dim DA As New SqlDataAdapter
        Dim TB As New DataTable
        Try
            With Cmd
                Cmd.CommandType = CommandType.StoredProcedure
                Cmd.Connection = Cnn
                Cmd.Parameters.AddWithValue("@ReleaseID", Me.GridRelease.ActiveRow.Cells("ID").Value.ToString)
                Cmd.Parameters.AddWithValue("@Office", My.Settings.Office)
            End With
            DA.SelectCommand = Cmd
            DA.Fill(TB)
            MsgBox("Confimed under reference " & TB.Rows(0).Item(0))
            SetDocument()
        Catch ex As Exception
            MsgBox("Confim Faild ", MsgBoxStyle.Critical)
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub MenuItem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem.Load

    End Sub
End Class