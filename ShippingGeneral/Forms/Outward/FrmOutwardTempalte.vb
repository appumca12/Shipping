Imports System.Data.SqlClient
Imports System.IO
Imports Aspose.Words
Imports Aspose.Words.Fields
Imports Aspose.Words.Reporting

Public Class FrmOutwardTempalte

    Private TBData As DataTable
    Private BLID As String
    Private Line As String

    Public Sub New(ByRef TB As DataTable, ByVal Line As String)


        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Dim Dr As DataRow
        Dim Cmd As SqlCommand
        Dim Cnn As SqlConnection
        Dim DA As New SqlDataAdapter
        Dim temp As New DataTable
        Dim SR As StreamWriter
        Dim Ds As New DataSet
        Dim Dt As Date

        Me.Line = Line
        Dr = TB.Rows(0)
        Cmd = New SqlCommand("Select * From TB_OutwardBlsTemplate Where BLID = '" & Dr("BLID").ToString & "'")
        Cnn = New SqlConnection(My.Settings.DSN)
        Cmd.Connection = Cnn
        Cmd.CommandType = CommandType.Text
        DA.SelectCommand = Cmd
        DA.Fill(temp)
        Me.TBData = TB
        If temp.Rows.Count > 0 Then
            If MsgBox("You have already old one, Do you want continue with old one ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                SR = New StreamWriter("c:\tmp\xml.xml")
                SR.Write(temp.Rows(0).Item("XML"))
                SR.Flush()
                SR.Close()
                TBData.Clear()
                Ds = New DataSet
                Ds.ReadXml("c:\tmp\XML.XML")
                Me.TBData = Ds.Tables(0)
            End If
        Else
            Me.TBData = TB
        End If
      
        Dr = TBData.Rows(0)
        BLID = Dr("BLID")
        Me.Shipper.Text = NullToValue(Dr("Shipper"), "")
        Me.Cnee.Text = NullToValue(Dr("Cnee"), "")
        Me.Notifyparty.Text = NullToValue(Dr("Notify1"), "")
        Me.POL.Text = NullToValue(Dr("POL"), "")
        Me.POD.Text = NullToValue(Dr("POD"), "")
        Me.Agent.Text = NullToValue(Dr("Agent"), "")
        Me.Cntrs.Text = NullToValue(Dr("Cntrs"), "")
        Me.BLNO.Text = NullToValue(Dr("BLNO"), "")
        Me.POR.Text = NullToValue(Dr("POR"), "")
        Me.Pkgs.Text = NullToValue(Dr("Pkgs"), "")
        Me.Goods.Text = NullToValue(Dr("Goods"), "")
        Me.GW.Text = NullToValue(Dr("GW"), "0")
        Me.NET.Text = NullToValue(Dr("Net"), "0")
        Me.CBM.Text = NullToValue(Dr("CBM"), "0")
        Me.FPOD.Text = NullToValue(Dr("FPOD"), "")
        Me.Vessel.Text = Dr("Vessel")
        Me.Voyage.Text = Dr("Voyage")
        Me.Terms.Text = NullToValue(Dr("Terms"), "")
        Me.TGW.Text = NullToValue(Dr("TGW"), "0")
        Me.TNET.Text = NullToValue(Dr("TNET"), "0")
        Me.TCBM.Text = NullToValue(Dr("TCBM"), "0")
        Me.NoOfBls.Text = NullToValue(Dr("NoOfBls"), "")

        Try
            TBData.Columns.Add(New DataColumn("OnBoardDate"))
        Catch ex As Exception

        End Try
 
        Try
            Dt = Dr("OnBoardDate")
            Me.OnBoardDate.Text = Dt.Day & "." & Dt.Month & "." & Dt.Year
        Catch ex As Exception
            Me.OnBoardDate.Text = Dr("OnBoardDate").ToString

        End Try
 
        Try
            Dt = Dr("IssueDate")
            Me.IssueDate.Text = Dt.Day & "." & Dt.Month & "." & Dt.Year
        Catch ex As Exception

        End Try

        Try
            Me.Notify2.Text = NullToValue(Dr("Notify2"), "")
            Me.IssuePlace.Text = NullToValue(Dr("IssuePlace"), "")
        Catch ex As Exception

        End Try
        Me.TPKGS.Text = Dr("TPKGS")
        Dim lResult As Boolean
        TableBySql("Select ID , ObjectName from TB_ObjectsUser Where ObjectLine = '" & CurrentShippingLine & "' and ObjectGroup = 'BL'", Tb, lResult)
        With Me.ComboList.ComboGnrl
            .DataSource = Tb
            .SelectedItem = "ID"
            .DisplayMember = "ObjectName"
        End With
    End Sub
    Private Sub ButtonForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonForm.Click

        Dim Frm As New FrmGeneralReportShow
        Dim Rpt As CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim FleName As String

        FleName = Line & "-BL-IMAGE"
        RetriveObject(FleName, "C:\Temp\Image.jpg")

        Try
            TBData.Columns.Add(New DataColumn("Image", System.Type.GetType("System.Byte[]")))
        Catch ex As Exception

        End Try

        TBData.Rows(0).Item("Image") = GetImageData("C:\Temp\Image.jpg")

        FleName = Line & "-BL-FORM"
        Rpt = New CrystalDecisions.CrystalReports.Engine.ReportDocument 'RptTasa
        RetriveObject(FleName, "C:\Temp\RPT.rpt")
        Rpt.Load("C:\Temp\RPT.rpt")
        Rpt.SetDataSource(TBData)
        Frm.ReportViewer.ReportSource = Rpt
        Frm.Show()

        'Dim Rpt As OOCLBL
        'Dim Frm As New FrmGeneralReportShow
        'Rpt = New OOCLBL
        'FillData()
        'Rpt.SetDataSource(TBData)
        'Frm.ReportViewer.ReportSource = Rpt
        'Frm.Show()
    End Sub

    Private Sub ButtonBlank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBlank.Click

        Dim Frm As New FrmGeneralReportShow
        Dim Rpt2 As CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim FleName As String

        FillData()

        Rpt2 = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        FleName = Line & "-BL-BLANK"
        RetriveObject(FleName, "C:\Temp\RPT.rpt")
        Rpt2.Load("C:\Temp\RPT.rpt")
        Rpt2.SetDataSource(TBData)
        Frm.ReportViewer.ReportSource = Rpt2

        Frm.Show()

    End Sub
    Private Sub FillData()

        Dim Dr As DataRow
        Dr = TBData.Rows(0)
        Dr("Shipper") = Me.Shipper.Text
        Dr("Cnee") = Me.Cnee.Text
        Dr("Notify1") = Me.Notifyparty.Text
        Dr("POL") = Me.POL.Text
        Dr("POD") = Me.POD.Text
        Dr("Agent") = Me.Agent.Text
        Dr("Cntrs") = Me.Cntrs.Text
        Dr("BLNO") = Me.BLNO.Text
        Dr("POR") = Me.POR.Text
        Dr("Pkgs") = Me.Pkgs.Text
        Dr("Goods") = Me.Goods.Text
        Dr("GW") = Me.GW.Text
        Dr("Net") = Me.NET.Text
        Dr("CBM") = Me.CBM.Text
        Dr("FPOD") = Me.FPOD.Text
        Dr("Voyage") = Me.Voyage.Text
        Dr("Vessel") = Me.Vessel.Text
        Dr("Terms") = Me.Terms.Text
        Dr("TGW") = Me.TGW.Text
        Dr("TNET") = Me.TNET.Text
        Dr("TCBM") = Me.TCBM.Text
        Dr("NoOfBls") = Me.NoOfBls.Text
        Dr("Notify2") = Me.Notify2.Text
        Dr("TPKGS") = Me.TPKGS.Text

        Try
            If Me.OnBoardDate.Text <> "" Then
                Dr("OnBoardDate") = Me.OnBoardDate.Text
                Dr("IssueDate") = Me.IssueDate.Text
                Dr("IssuePlace") = Me.IssuePlace.Text
            End If
        Catch ex As Exception

        End Try
       
    End Sub
    Private Sub MenuItem_CustomSaveClick() Handles MenuItem.CustomSaveClick

        Dim sr As New MemoryStream
        Dim s As String
        Dim SS As StreamReader
        Dim Cmd As New SqlCommand
        Dim Cnn As New SqlConnection(My.Settings.DSN)
        Cnn.Open()
        FillData()
        TBData.AcceptChanges()
        Cmd = New SqlCommand("SP_OutwardTempalteUpdate")
        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.Connection = Cnn
        TBData.WriteXml(sr)
        sr.Position = 0
        SS = New StreamReader(sr)
        s = SS.ReadToEnd
        Cmd.Parameters.AddWithValue("@BLID", BLID.ToString)
        Cmd.Parameters.AddWithValue("@XML", s)
        Try
            Cmd.ExecuteNonQuery()
            MsgBoxSaveSuccessful()
        Catch ex As Exception
            MsgBoxSaveFailed()
            MsgBox(ex.ToString)
        End Try

    End Sub
    Private Function GetImageData(ByVal fileName As String) As Byte()

        'Method to load an image from disk and return it as a bytestream

        Dim fs As System.IO.FileStream = _
 New System.IO.FileStream(fileName, _
                System.IO.FileMode.Open, System.IO.FileAccess.Read)
        Dim br As System.IO.BinaryReader = New System.IO.BinaryReader(fs)

        Return (br.ReadBytes(Convert.ToInt32(br.BaseStream.Length)))

    End Function
    
   Private Sub PrintBySelection_Click(sender As System.Object, e As System.EventArgs) Handles PrintBySelection.Click

        Dim Doc As Document
        Dim FleName As String
        Dim Tb As DataTable
        Dim Cmd As New SqlCommand
        Dim Cnn As New SqlConnection(My.Settings.DSN)
        Dim barrImg As Byte()
        Dim strfn As String
        Dim fs As FileStream

        If Me.ComboList.ComboGnrl.Text = "" Then
            MsgBox("No Any Selection !")
            Exit Sub
        End If

        FleName = "c:\Temp\TEMP"
        Cmd = New SqlCommand("select ObjectContent from TB_ObjectsUser where ObjectLine = '" & CurrentShippingLine & "' and ObjectGroup = 'BL' and Objectname = '" & Me.ComboList.ComboGnrl.Text & "'", Cnn)
        If Cnn.State = ConnectionState.Closed Then
            Cnn.Open()
        End If

        barrImg = Cmd.ExecuteScalar

        If Not barrImg Is Nothing Then
            strfn = FleName
            If IO.File.Exists(FleName) Then
                IO.File.Delete(FleName)
            End If
            fs = New FileStream(strfn, FileMode.CreateNew, FileAccess.Write)
            fs.Write(barrImg, 0, barrImg.Length)
            fs.Flush()
            fs.Close()
        End If

        Doc = New Document("C:\Temp\Temp")

        FleName = "c:\Temp\" & Me.BLNO.Text & ".docx"
        Doc.MailMerge.Execute(TBData)
        Doc.Save(FleName)
        Process.Start(FleName)


    End Sub

End Class