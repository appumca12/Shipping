Imports OrmLib
Imports ShippingBiz
Imports System.Data.SqlClient
Imports System.IO

Public Class FrmCustomReportItem
    Private DM As DataManager
    Private TbReports As DataTable
    Private FleName As String = ""
    Private Sub FrmCustomReportItem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim Reps As TB_ReportCustomFieldsCollection
        Dim DR As DataRow
        Dim Drs() As DataRow
        Dim nDr As DataRow

        DM = New DataManager(My.Settings.DSN)
        Reps = DM.GetTB_ReportCustomFieldsCollection()

        TbReports = New DataTable

        With TbReports
            .Columns.Add(New DataColumn("ReportFriendlyName"))
        End With

        For Each DR In DM.DataSet.Tables("TB_ReportCustomFields").Rows
            Drs = TbReports.Select("ReportFriendlyName = '" & DR("ReportFrindlyName") & "'", "")
            If Drs.Length = 0 Then
                nDr = TbReports.NewRow
                nDr("ReportFriendlyName") = DR("ReportFrindlyName")
                TbReports.Rows.Add(nDr)
            End If
        Next

        Me.Reports.DataSource = TbReports


    End Sub

    Private Sub Reports_AfterRowActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Reports.AfterRowActivate

        Dim drs() As DataRow
        Dim RN As String = Reports.DisplayLayout.ActiveRow.Cells("ReportFriendlyName").Value.ToString
        Dim DR As DataRow
        Dim nDr As DataRow
        drs = DM.DataSet.Tables("TB_ReportCustomFields").Select("ReportFrindlyName = '" & RN & "'", "")

        Dim TB As New DataTable

        TB.Columns.Add(New DataColumn("ID", System.Type.GetType("System.Guid")))
        TB.Columns.Add(New DataColumn("Name", System.Type.GetType("System.String")))
        For Each DR In drs
            nDr = TB.NewRow
            nDr("ID") = DR("ID")
            nDr("Name") = DR("FieldFriendlyName")
            TB.Rows.Add(nDr)

        Next




        Me.ReportItems.DataSource = TB

        With Me.ReportItems.DisplayLayout.Bands(0)
            .Columns("ID").Hidden = True

        End With



    End Sub


    Private Sub StripButtonOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StripButtonOpen.Click

        Dim Dlg As New OpenFileDialog

        Dlg.Filter = "Rich Text Format Files (*.rtf)|*.rtf"
        Dlg.ShowDialog()
        FleName = Dlg.FileName
        If FleName = "" Then
            Exit Sub
        End If
        Me.Content.LoadFile(FleName)

    End Sub


    Private Sub SaveImage()

        Dim ID As String
        Dim Cmd As SqlCommand
        Dim iresult As Int16
        Dim TB As New DataTable
        Dim DA As New SqlClient.SqlDataAdapter
        Dim Cnn As New SqlConnection(My.Settings.DSN)

        Dim fs As New FileStream(FleName, FileMode.Open)
        Dim barrImg(fs.Length) As Byte

        Cnn.Open()
        ID = ReportItems.ActiveRow.Cells("ID").Value.ToString
        fs.Read(barrImg, 0, fs.Length)

        Cmd = New SqlCommand()
        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.Connection = Cnn
        Cmd.CommandType = CommandType.Text
        Cmd.CommandText = "update TB_ReportCustomFields set Datacontent = @Content where ID = @ID "
        Cmd.Parameters.AddWithValue("@ID", ID)
        Cmd.Parameters.AddWithValue("@Content", barrImg)

        Try
            iresult = Cmd.ExecuteNonQuery()
            MsgBoxSaveSuccessful()
        Catch ex As Exception
            MsgBoxSaveFailed()
        Finally
            Cnn.Close()
        End Try
        fs.Close()

    End Sub

    Private Sub RetriveImage()

        Dim Cmd As SqlCommand
        Dim barrImg As Byte()
        Dim strfn As String
        Dim fs As FileStream
        Dim FleName As String
        Dim ID As String = ReportItems.ActiveRow.Cells("ID").Value.ToString
        Dim Cnn As New SqlConnection(My.Settings.DSN)
        Cnn.Open()

        FleName = "c:\tmp\temp.rtf"

        If Not IO.Directory.Exists("c:\tmp") Then
            IO.Directory.CreateDirectory("c:\tmp")
        End If

        If IO.File.Exists(FleName) Then
            IO.File.Delete(FleName)
        End If
        Me.Content.Text = ""
        Try
            Cmd = New SqlCommand("select Datacontent from TB_ReportCustomFields where ID = @ID ", Cnn)
            Cmd.Parameters.AddWithValue("@ID", ID)
            barrImg = Cmd.ExecuteScalar
            strfn = FleName
            If IO.File.Exists(FleName) Then
                IO.File.Delete(FleName)
            End If
            fs = New FileStream(strfn, FileMode.CreateNew, FileAccess.Write)
            fs.Write(barrImg, 0, barrImg.Length)
            fs.Flush()
            fs.Close()
            Me.Content.LoadFile(FleName)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Cnn.Close()
        End Try


    End Sub


    Private Sub StripButtonSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StripButtonSave.Click
        SaveImage()
    End Sub

    Private Sub ReportItems_AfterRowActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportItems.AfterRowActivate
        RetriveImage()
    End Sub


End Class