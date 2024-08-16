Imports Microsoft.Office.Interop
Imports OrmLib
Imports ShippingBiz
Imports Infragistics.Shared
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinEditors
Imports System.Text.RegularExpressions
Imports System.Net.Mail
Imports System.Configuration
Imports System.IO
Imports System.Data.SqlClient
Imports System.Net
Imports System.Security.Cryptography.X509Certificates
Imports System.Net.Security

Public Class MailUser

    Private Sub BtnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSend.Click
        'Try
        Dim sSql As String
        Dim TB1 As New System.Data.DataTable
        Dim lResult As Boolean
        Dim mail As New MailMessage()
        Dim MailFile As String
        Dim Cmd As New SqlCommand
        Dim DA1 As New SqlDataAdapter
        Dim Cnn As New SqlConnection(My.Settings.DSN)

        Dim path As String = Directory.GetParent(Directory.GetCurrentDirectory()).ToString()
        MailFile = path + "\DemurageReport.xlsx"

        'Dim SmtpServer As New SmtpClient("smtp.gmail.com")
        'mail.From = New MailAddress("smappubca@gmail.com")
        'SmtpServer.Credentials = New System.Net.NetworkCredential("smappubca@gmail.com", "B@r@thi89")
        'SmtpServer.EnableSsl = True
        'SmtpServer.Port = 587 ' SMTP Email Server port

        Dim SmtpServer As New SmtpClient(System.Configuration.ConfigurationSettings.AppSettings("SmtpClient").ToString())
        mail.From = New MailAddress(System.Configuration.ConfigurationSettings.AppSettings("MailAddress").ToString())
        SmtpServer.Port = Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings("port").ToString()) ' SMTP Email Server port
        SmtpServer.Credentials = New System.Net.NetworkCredential(System.Configuration.ConfigurationSettings.AppSettings("MailAddress").ToString(), System.Configuration.ConfigurationSettings.AppSettings("password").ToString())
        SmtpServer.EnableSsl = True
        SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network
        SmtpServer.UseDefaultCredentials = True
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls

        Dim attachment As System.Net.Mail.Attachment
        attachment = New System.Net.Mail.Attachment(MailFile)
        mail.Attachments.Add(attachment)
        Dim Tocount As Integer
        Tocount = 0
        For Each dr As DataGridViewRow In DataGridView1.Rows

            If dr.Cells("checkBoxColumn").Value = True Then
                Tocount += 1
            End If
        Next
        If Tocount <= 5 Then
            Dim ToId As String
            Try

                For Each dr As DataGridViewRow In DataGridView1.Rows

                    If dr.Cells("checkBoxColumn").Value = True Then

                        ToId = dr.Cells("EmailOffice").Value.ToString()
                        mail.[To].Add(dr.Cells("EmailOffice").Value.ToString())
                        'mail.[To].Add("appumca12@gmail.com")
                        mail.[CC].Add(System.Configuration.ConfigurationSettings.AppSettings("CC").ToString())
                        mail.[Bcc].Add(System.Configuration.ConfigurationSettings.AppSettings("BCC").ToString())
                        mail.Subject = "BL - All Containers Returned from " + lblFrom.Text + " to " + lblTo.Text
                        mail.Body = "Dear " + dr.Cells("UserFirstName").Value.ToString() + " " + dr.Cells("UserLastName").Value.ToString() + "," + vbNewLine + vbNewLine + "PFA Demurrage BL List" + vbNewLine + vbNewLine + "Regards," + vbNewLine + "IT Support"


                        ServicePointManager.ServerCertificateValidationCallback = New System.Net.Security.RemoteCertificateValidationCallback(AddressOf customCertValidation)
                        SmtpServer.Send(mail)

                        Cmd = New SqlCommand("SP_MailLog_Insert")
                        Cnn = New SqlConnection(My.Settings.DSN)
                        Cnn.Open()
                        Cmd.CommandTimeout = 2000
                        Cmd.CommandType = CommandType.StoredProcedure
                        Cmd.Parameters.AddWithValue("@ID", Guid.NewGuid)
                        Cmd.Parameters.AddWithValue("@ActionUser", CurrentUser.UserCode)
                        Cmd.Parameters.AddWithValue("@ActionType", "Send Mail")
                        Cmd.Parameters.AddWithValue("@From_id", System.Configuration.ConfigurationSettings.AppSettings("MailAddress").ToString())
                        Cmd.Parameters.AddWithValue("@To_id", dr.Cells("EmailOffice").Value.ToString())
                        Cmd.Parameters.AddWithValue("@Sent_On", Now())
                        Cmd.Parameters.AddWithValue("@Module_Name", "Accounts-Demurage Control Report")
                        Cmd.Parameters.AddWithValue("@Action_Status", "Sent")
                        Cmd.Parameters.AddWithValue("@Comments", " ")
                        Cmd.Connection = Cnn
                        Cmd.ExecuteNonQuery()
                    End If
                Next
            Catch ex As Exception
                Cmd = New SqlCommand("SP_MailLog_Insert")
                Cnn = New SqlConnection(My.Settings.DSN)
                Cnn.Open()
                Cmd.CommandTimeout = 2000
                Cmd.CommandType = CommandType.StoredProcedure
                Cmd.Parameters.AddWithValue("@ID", Guid.NewGuid)
                Cmd.Parameters.AddWithValue("@ActionUser", CurrentUser.UserCode)
                Cmd.Parameters.AddWithValue("@ActionType", "Send Mail")
                Cmd.Parameters.AddWithValue("@From_id", System.Configuration.ConfigurationSettings.AppSettings("MailAddress").ToString())
                Cmd.Parameters.AddWithValue("@To_id", ToId)
                Cmd.Parameters.AddWithValue("@Sent_On", Now())
                Cmd.Parameters.AddWithValue("@Module_Name", "Accounts-Demurage Control Report")
                Cmd.Parameters.AddWithValue("@Action_Status", "Failure")
                Cmd.Parameters.AddWithValue("@Comments", ex.Message.ToString())
                Cmd.Connection = Cnn
                Cmd.ExecuteNonQuery()
                MessageBox.Show("Mail Sent Failure! " + ex.Message.ToString())
                Exit Sub
            End Try
            MessageBox.Show("Mail Sent Sucessfully!")

            Me.Close()
        Else
            MessageBox.Show("Allow to Send maximum of 5 Users!")
            Exit Sub
        End If
        'Catch e As Exception
        '    MessageBox.Show("Sending Mail Failure!")
        'End Try


    End Sub
    Private Shared Function customCertValidation(ByVal sender As Object, _
                                                ByVal cert As X509Certificate, _
                                                ByVal chain As X509Chain, _
                                                ByVal errors As SslPolicyErrors) As Boolean

        Return True

    End Function
    Private Sub MailUser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim sSql As String
        Dim TB1 As New System.Data.DataTable
        Dim lResult As Boolean
        sSql = "Select UserFirstName, UserLastName, EmailOffice from [TB_Users] where id <> '1469808A-5398-44D9-A265-B13E0B114DBD' and EmailOffice is Not Null and EmailOffice <> '' order by UserFirstName"
        TableBySql(sSql, TB1, lResult)
        Me.DataGridView1.DataSource = TB1

        Dim checkBoxColumn As New DataGridViewCheckBoxColumn()
        checkBoxColumn.HeaderText = ""
        checkBoxColumn.Width = 30
        checkBoxColumn.Name = "checkBoxColumn"
        DataGridView1.Columns.Insert(0, checkBoxColumn)
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub
End Class