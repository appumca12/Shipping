Imports ShippingBiz
Imports OrmLib
Imports System.Data.SqlClient

Public Class FrmTAPDetentionChrg
    Private ItemLevel As String = "412"
    Dim exist As Boolean
    Private FrmStaus As FormStatus
    Private Dm As ShippingBiz.DataManager
    Public dtLockDetails As New System.Data.DataTable
    Public dtLockDetailsBL As New System.Data.DataTable

    Private Sub btnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFind.Click
        Dim sSql As String
        Dim sSql2 As String
        Dim IResult As Boolean
        Dim dtLockDetails As New System.Data.DataTable
        Dim dtLockDetailsBL As New System.Data.DataTable
       
        If Me.txtBLNumber.Text = "" Then
            MsgBoxGeneral("Please Fill BL No !", "Error")
            Exit Sub
        End If

        sSql = "select Id, BLno from TB_Inwardbls where BLNo = '" & Me.txtBLNumber.Text.ToString() & "'"
        TableBySql(sSql, dtLockDetails, IResult)

        If dtLockDetails.Rows.Count = 0 Then
            MsgBoxGeneral("Invalid BL No !", "Error")
            Exit Sub
        Else
            sSql2 = "select Id, Remarks, CreatedDate, ModifiedDate from TB_TAPDetention where BLNo = '" & Me.txtBLNumber.Text.ToString() & "'"
            TableBySql(sSql2, dtLockDetailsBL, IResult)
            If dtLockDetailsBL.Rows.Count = 0 Then
                MsgBoxGeneral("Now TAP Entry Found. Please Add New TAP Remark Entry!")
                exist = False
            Else
                exist = True
                txtRemarks.Text = dtLockDetailsBL.Rows(0).Item("Remarks").ToString()
                lblCreatedOn.Text = dtLockDetailsBL.Rows(0).Item("CreatedDate").ToString()
                lblModifiedon.Text = dtLockDetailsBL.Rows(0).Item("ModifiedDate").ToString()
            End If

        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim Cmd As New SqlCommand
        Dim DA1 As New SqlDataAdapter
        Dim Cnn As New SqlConnection(My.Settings.DSN)
        Dim sSql As String
        Dim TB1 As New System.Data.DataTable
        Dim lResult As Boolean

        If Me.txtBLNumber.Text = "" Then
            MsgBoxGeneral("Please Fill BL No !", "Error")
            Exit Sub
        End If

        If exist = False Then
            Cmd = New SqlCommand("SP_TAPDetention_Insert")
            Cnn = New SqlConnection(My.Settings.DSN)
            Cnn.Open()
            Cmd.CommandTimeout = 2000
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Parameters.AddWithValue("@ID", Guid.NewGuid)
            Cmd.Parameters.AddWithValue("@BLNo", Me.txtBLNumber.Text.ToString())
            Cmd.Parameters.AddWithValue("@Remarks", Me.txtRemarks.Text.ToString())
            Cmd.Parameters.AddWithValue("@CreatedBy", CurrentUser.ID.ToString())
            Cmd.Parameters.AddWithValue("@CreatedDate", Now())
            Cmd.Connection = Cnn
            Cmd.ExecuteNonQuery()
            MsgBoxSaveSuccessful()

        Else
            Cmd = New SqlCommand("SP_TAPDetention_Update")
            Cnn = New SqlConnection(My.Settings.DSN)
            Cnn.Open()
            Cmd.CommandTimeout = 2000
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Parameters.AddWithValue("@BLNo", Me.txtBLNumber.Text.ToString())
            Cmd.Parameters.AddWithValue("@Remarks", Me.txtRemarks.Text.ToString())
            Cmd.Parameters.AddWithValue("@ModifiedBy", CurrentUser.ID.ToString())
            Cmd.Parameters.AddWithValue("@ModifiedDate", Now())
            Cmd.Connection = Cnn
            Cmd.ExecuteNonQuery()
            MsgBoxSaveSuccessful()
        End If
        txtBLNumber.Text = ""
        txtRemarks.Text = ""
        lblCreatedOn.Text = ""
        lblModifiedon.Text = ""
    End Sub

    Private Sub FrmTAPDetentionChrg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dm = New ShippingBiz.DataManager(My.Settings.DSN)
        ''Me.GeneralForms.InitControl("Client Account Status", ItemLevel)
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        txtBLNumber.Text = ""
        txtRemarks.Text = ""
        lblCreatedOn.Text = ""
        lblModifiedon.Text = ""

    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim sSql2 As String

        Dim IResult As Boolean
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim Cnn As New SqlConnection(My.Settings.DSN)

        If Me.txtBLNumber.Text = "" Then
            MsgBoxGeneral("Please Fill BL No !", "Error")
            Exit Sub
        End If

        sSql2 = "select Id, Remarks, CreatedDate, ModifiedDate from TB_TAPDetention where BLNo = '" & Me.txtBLNumber.Text.ToString() & "'"
        TableBySql(sSql2, dtLockDetailsBL, IResult)
        If dtLockDetailsBL.Rows.Count > 0 Then
            Cmd.CommandType = System.Data.CommandType.Text
            Cmd.Connection = Cnn
            Cmd.CommandText = "DELETE FROM TB_TAPDetention WHERE ID = '" & dtLockDetailsBL.Rows(0).Item("id").ToString() & "'"
            Cnn.Open()
            Cmd.ExecuteNonQuery()
            MsgBoxGeneral("TAP Entry Deleted!")
            btnReset_Click(sender, e)
        End If
    End Sub
End Class