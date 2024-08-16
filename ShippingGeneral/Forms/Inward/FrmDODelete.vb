Imports ShippingBiz
Imports OrmLib
Imports System.Data.SqlClient

Public Class FrmDODelete
    Dim dtDODetails As New System.Data.DataTable
    Private ItemLevel As String = "412"
    Dim exist As Boolean
    Private FrmStaus As FormStatus
    Private Dm As ShippingBiz.DataManager
    Private Sub btnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFind.Click
        Dim sSql As String
        Dim sSql2 As String
        Dim IResult As Boolean

        Dim dtBLDetails As New System.Data.DataTable
        Dim dtLockDetailsBL As New System.Data.DataTable

        lblAcStatus.Text = ""
        lblClient.Text = ""
        If Me.txtBLNumber.Text = "" Then
            MsgBoxGeneral("Please Fill BL No !", "Error")
            Exit Sub
        End If

        sSql2 = "select Id from TB_Inwardbls where BLNO = '" & Me.txtBLNumber.Text.ToString() & "'"
        TableBySql(sSql2, dtBLDetails, IResult)

        If dtBLDetails.Rows.Count = 0 Then
            MessageBox.Show("Invalid BL.", "Shipping ILS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        sSql = "select Id, BLID, DOOffice, DODate from TB_InwardStatus where BLID = (select ID from tb_inwardbls where blno = '" & Me.txtBLNumber.Text.ToString() & "')"
        TableBySql(sSql, dtDODetails, IResult)

        If Not dtDODetails.Rows.Count = 0 Then
            lblClient.Text = dtDODetails.Rows(0).Item("DOOffice").ToString()
            lblAcStatus.Text = dtDODetails.Rows(0).Item("DODate").ToString()
            btnStatusLock.Enabled = True
        Else
            MessageBox.Show("No D/O Details Found!", "Shipping ILS", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnStatusLock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStatusLock.Click

        Dim Status As TB_InwardStatus

        If Me.txtBLNumber.Text = "" Then
            MsgBoxGeneral("Please Fill BL No !", "Error")
            Exit Sub
        End If

        If Not dtDODetails.Rows.Count = 0 Then
            If MsgBoxDelete() = Windows.Forms.DialogResult.Yes Then
                Try
                    Dm.QueryCriteria.Clear()
                    Dm.QueryCriteria.And(JoinPath.TB_InwardStatus.Columns.BLID, dtDODetails.Rows(0).Item("BLID"), MatchType.Exact)
                    Status = Dm.GetTB_InwardStatus
                    Status.Delete()
                    Dm.CommitAll()
                    MessageBox.Show("D/O Removed Successfully!", "Shipping ILS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtBLNumber.Text = ""
                    lblAcStatus.Text = ""
                    lblClient.Text = ""
                    btnStatusLock.Enabled = False
                Catch ex As Exception
                    MsgBoxDeleteFailed()
                    MsgBox(ex.ToString)
                End Try
            End If
        End If

    End Sub

    Private Sub FrmDODelete_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dm = New ShippingBiz.DataManager(My.Settings.DSN)
        btnStatusLock.Enabled = False
        ''Me.GeneralForms.InitControl("Client Account Status", ItemLevel)
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        txtBLNumber.Text = ""

        lblAcStatus.Text = ""
        lblClient.Text = ""
        btnStatusLock.Enabled = False
    End Sub
End Class