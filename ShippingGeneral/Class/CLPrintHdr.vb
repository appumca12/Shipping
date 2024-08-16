Imports System.Data.SqlClient
Imports System.IO
Imports CrystalDecisions.CrystalReports
Imports OrmLib
Imports ShippingBiz

Public Class CLPrintHdr

    Public Function ImageTable() As DataTable

        Dim Co As TB_Company
        Dim Dm As New DataManager(My.Settings.DSN)
        Dim data As New DataTable
        Dim row As DataRow
        Dim ImageFile As String

        Co = Dm.GetTB_Company
        '  ImageFile = RetriveImage()

        data.TableName = "Images"
        data.Columns.Add("Name", System.Type.GetType("System.String"))
        data.Columns.Add("Address", System.Type.GetType("System.String"))
        data.Columns.Add("Tel", System.Type.GetType("System.String"))
        data.Columns.Add("Fax", System.Type.GetType("System.String"))
        data.Columns.Add("Logo", System.Type.GetType("System.Byte[]"))
        data.Columns.Add("FName", System.Type.GetType("System.String"))
        data.Columns.Add("FAddress", System.Type.GetType("System.String"))
        data.Columns.Add("FTel", System.Type.GetType("System.String"))
        data.Columns.Add("FFax", System.Type.GetType("System.String"))

        'Dim fs As New FileStream(ImageFile, FileMode.Open)
        'Dim br As New BinaryReader(fs)
        row = data.NewRow()
        row("Name") = Co.CompanyName
        row("Address") = Co.CompanyAddress
        row("Tel") = Co.Tel
        row("fax") = Co.Fax
        row("FName") = Co.CompanyFName
        row("FAddress") = Co.CompantFAddress
        row("FTel") = Co.CompanyFTel
        row("Ffax") = Co.CompanyFFax
        '        row("Logo") = br.ReadBytes(br.BaseStream.Length)
        'data.Rows.Add(row)
        'br = Nothing
        'fs.Close()
        'fs = Nothing
        'Kill(ImageFile)
        Return data

    End Function

    Private Function RetriveImage() As String

        Dim Cmd As SqlCommand
        Dim Cnn As New SqlConnection
        Cnn.ConnectionString = My.Settings.DSN
        Dim barrImg As Byte()
        Dim strfn As String = ""
        Dim fs As FileStream

        Try
            Cmd = New SqlCommand("select ObjectContent from TB_Objects where ObjectName = 'Logo'", Cnn)
            Cnn.Open()
            barrImg = Cmd.ExecuteScalar
            If Not System.IO.Directory.Exists("c:\temp") Then
                System.IO.Directory.CreateDirectory("c:\temp")
            End If

            strfn = "c:\temp\" & Convert.ToString(DateTime.Now.ToFileTime()) & ".jpg"
            fs = New FileStream(strfn, FileMode.CreateNew, FileAccess.Write)
            fs.Write(barrImg, 0, barrImg.Length)
            fs.Flush()
            fs.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Cnn.Close()
        End Try
        '   strfn = "c:\test.jpg"
        Return strfn
    End Function






End Class
