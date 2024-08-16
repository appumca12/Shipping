Imports ShippingBiz
Imports OrmLib
Imports System.Data.SqlClient

Public Class FrmAgentStatusLock
    Private ItemLevel As String = "412"
    Dim exist As Boolean
    Private FrmStaus As FormStatus
    Private Dm As ShippingBiz.DataManager
    Private Sub btnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFind.Click
        Dim sSql As String
        Dim sSql2 As String
        Dim IResult As Boolean
        Dim dtLockDetails As New System.Data.DataTable
        Dim dtLockDetailsBL As New System.Data.DataTable
        btnStatusLock.Text = ""
        lblAcStatus.Text = ""
        lblClient.Text = ""
        If Me.txtBLNumber.Text = "" Then
            MsgBoxGeneral("Please Fill BL No !", "Error")
            Exit Sub
        End If

        sSql = "select Id, BLNo, LockStatus, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, (select top 1 lName from TB_Clients where id = (select top 1 agentid from tb_inwardbls where blno = TB_LockStatusagent.BLNO)) as Client_Name from TB_LockStatusagent where BLNo = '" & Me.txtBLNumber.Text.ToString() & "'"
        TableBySql(sSql, dtLockDetails, IResult)

        If dtLockDetails.Rows.Count = 0 Then
            sSql2 = "select AgentId, (select top 1 lName from TB_Clients where id =  AgentId) as Client_Name, (select top 1 AccountStatus from TB_Clients where id =  AgentId) as Ac_Status from TB_InwardBLS where BlNo = '" & Me.txtBLNumber.Text.ToString() & "'"
            TableBySql(sSql2, dtLockDetailsBL, IResult)

            If Not dtLockDetailsBL.Rows.Count = 0 Then
                If dtLockDetailsBL.Rows(0).Item("Ac_Status").ToString() = "B" Then
                    lblAcStatus.Text = "Bad Account"
                Else
                    MessageBox.Show("Agent Account is not a Bad Account", "Shipping ILS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                lblClient.Text = dtLockDetailsBL.Rows(0).Item("Client_Name").ToString()
                btnStatusLock.Text = "Unlock"
                btnStatusLock.Enabled = True
                exist = False
            Else
                MessageBox.Show("Invalid BL.", "Shipping ILS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Else
            exist = True
            lblAcStatus.Text = "Bad Account"
            lblClient.Text = dtLockDetails.Rows(0).Item("Client_Name").ToString()
            If dtLockDetails.Rows(0).Item("LockStatus").ToString() = "U" Then
                btnStatusLock.Text = "Lock"
            Else
                btnStatusLock.Text = "UnLock"
            End If
            btnStatusLock.Enabled = True
        End If
    End Sub

    Private Sub btnStatusLock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStatusLock.Click
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
            Cmd = New SqlCommand("SP_LockStatusAgent_Insert")
            Cnn = New SqlConnection(My.Settings.DSN)
            Cnn.Open()
            Cmd.CommandTimeout = 2000
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Parameters.AddWithValue("@ID", Guid.NewGuid)
            Cmd.Parameters.AddWithValue("@BLNo", Me.txtBLNumber.Text.ToString())
            If btnStatusLock.Text = "Lock" Then
                Cmd.Parameters.AddWithValue("@LockStatus", "L")
            Else
                Cmd.Parameters.AddWithValue("@LockStatus", "U")
            End If
            Cmd.Parameters.AddWithValue("@CreatedBy", CurrentUser.ID.ToString())
            Cmd.Parameters.AddWithValue("@CreatedDate", Now())
            Cmd.Connection = Cnn
            Cmd.ExecuteNonQuery()
            MsgBoxSaveSuccessful()

        Else
            Cmd = New SqlCommand("SP_LockStatusAgent_Update")
            Cnn = New SqlConnection(My.Settings.DSN)
            Cnn.Open()
            Cmd.CommandTimeout = 2000
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Parameters.AddWithValue("@BLNo", Me.txtBLNumber.Text.ToString())
            If btnStatusLock.Text = "Lock" Then
                Cmd.Parameters.AddWithValue("@LockStatus", "L")
            Else
                Cmd.Parameters.AddWithValue("@LockStatus", "U")
            End If
            Cmd.Parameters.AddWithValue("@ModifiedBy", CurrentUser.ID.ToString())
            Cmd.Parameters.AddWithValue("@ModifiedDate", Now())
            Cmd.Connection = Cnn
            Cmd.ExecuteNonQuery()
            MsgBoxSaveSuccessful()
        End If
        txtBLNumber.Text = ""
        btnStatusLock.Text = ""
        lblAcStatus.Text = ""
        lblClient.Text = ""
        btnStatusLock.Enabled = False
    End Sub

    Private Sub FrmAgentStatusLock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dm = New ShippingBiz.DataManager(My.Settings.DSN)
        ''Me.GeneralForms.InitControl("Client Account Status", ItemLevel)
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        txtBLNumber.Text = ""
        btnStatusLock.Text = ""
        lblAcStatus.Text = ""
        lblClient.Text = ""
        btnStatusLock.Enabled = False
    End Sub
End Class