Imports System.Data.SqlClient
Imports ShippingBiz
Imports OrmLib
Public Class FrmSendDocument
    Private DM As DataManager
    Private DocumentType As String
    Private DS As DataSet
    Private FinalDs As DataSet
  
    Private Sub ButtonPickup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPickup.Click

        Select Case Me.ComboActivity.Text

            Case "No DO Taken"
                DocumentType = "ND"
                ShowInward("1")
            Case "Over Due"
                DocumentType = "OD"
                ShowInward("2")
            Case "No Setel"
                DocumentType = "NS"
                ShowInward("3")
        End Select

    End Sub

    Private Sub ShowInward(ByVal DocType As String)

        Dim Dr As DataRow
        Dim Rows() As DataRow
        Dim Row As DataRow
        Dim DPC As ClDetentionPerCntr
        Dim Temp As DataTable
        Dim Title As String = Me.ComboActivity.Text

        Dim Cmd As New SqlClient.SqlCommand
        Dim Cnn As New SqlClient.SqlConnection(My.Settings.DSN)
        Dim DA As New SqlDataAdapter

        Dim Col As DataColumn
        Dim Child As DataColumn
        Dim Rel As DataRelation

        Cnn.Open()
        Cmd.CommandText = "SP_DetentionGnrlReport"
        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.CommandTimeout = 150
        Cmd.Parameters.AddWithValue("@Line", CurrentShippingLine)
        Cmd.Parameters.AddWithValue("@Type", DocType)
        Cmd.Connection = Cnn

        If Boolean.Parse(CurrentUser.IsDocAdmin) = True Or Boolean.Parse(CurrentUser.IsEcsAdmin) = True Then
            If MsgBox("Do You Want To Get Report Base On To line Data ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Cmd.CommandText = "SP_DetentionGnrlReportForLine"
                Title = "No D.O. Taken B/LS [For Line]"
            End If
        End If
        DS = New DataSet
        Me.Cursor = Cursors.WaitCursor
        DA.SelectCommand = Cmd
        DA.Fill(ds)

        For Each Dr In ds.Tables(0).Rows
            Rows = ds.Tables(1).Select("ID = '" & Dr("ID").ToString & "'")
            DPC = New ClDetentionPerCntr
            For Each Row In Rows
                If IsDBNull(Row("DF")) Or IsDBNull(Row("EA")) Then
                    Dr.RowError = "Please Check DF Date & MA Date"
                Else
                    Temp = DPC.DetentionPerCntr("I", Row("CnSize"), Row("Cntype"), Row("DF"), Row("EA"), Row("ID").ToString, Int16.Parse(Row("LCLCount").ToString), Row("WgtPercent"))
                End If
            Next
            Dr("Detention") = DPC.GetTotaldetention
            Dr("Discount") = DPC.GetTotalDiscount
            Dr("Balance") = DPC.GetTotaldetention - DPC.GetTotalDiscount
        Next

        FinalDs = New DataSet
        With FinalDs
            .Tables.Add(DS.Tables(0).Copy)
            .Tables.Add(DS.Tables(2).Copy)
            Col = .Tables(0).Columns("ID")
            Child = .Tables(1).Columns("DocumentID")
            Rel = New DataRelation("Rel", Col, Child)
            FinalDs.Relations.Add(Rel)
            .Tables(0).Columns.Add(New DataColumn("TotalDocs"))
            .Tables(0).Columns.Add(New DataColumn("LastDocs"))
            .Tables(0).Columns.Add(New DataColumn("SentTime"))
            For Each Dr In .Tables(0).Rows
                Rows = .Tables(1).Select("DocumentID = '" & Dr("ID").ToString & "'", "CreateTime Desc")
                If Rows.Length > 0 Then
                    Dr("TotalDocs") = Rows.Length
                    Dr("LastDocs") = Rows(0).Item("JobCode")
                    Dr("SentTime") = Rows(0).Item("CreateTime")
                End If
            Next
        End With

        Me.GridResult.DataSource = FinalDs
        With Me.GridResult.DisplayLayout.Bands(0)
            .Columns("ID").Hidden = True
            .Columns("DoAmount").Hidden = True
            .Columns("FirstEa").Hidden = True

        End With
        With Me.GridResult.DisplayLayout.Bands(0)
            .HeaderVisible = True
            .Header.Activated = True
            .Header.Caption = Title
            .Header.Appearance.BackColor = Color.Maroon
            .Header.Appearance.ForeColor = Color.Yellow
            .Header.Appearance.FontData.Name = "Verdana"
            .Header.Appearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.True
            .Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
            .Header.Appearance.FontData.SizeInPoints = 8
        End With
        GridNumSeperator(Me.GridResult)
        Me.Cursor = Cursors.Default


    End Sub
    Private Sub ButtonSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSave.Click


        Dim Dr As DataRow
        If Me.GridResult.Rows.Count = 0 Then
            Exit Sub
        End If

        If MsgBoxUpdate() = Windows.Forms.DialogResult.Yes Then

            Dim Job As TB_AUTJobLogs
            Dim Dtl As TB_AUTJobLogsDetail
            Dim ID As Guid = Guid.NewGuid
            DM = New DataManager(My.Settings.DSN)
            Job = DM.NewTB_AUTJobLogs(DocumentType, CurrentUser.UserCode, Now, "", "")
            Job.ID = ID
            Dtl = DM.NewTB_AUTJobLogsDetail(Guid.NewGuid, Me.GridResult.ActiveRow.Cells("ID").Value, "", "S", Now, Job)
            DM.CommitAll()


            Dr = FinalDs.Tables(1).NewRow
            Dr("DocumentID") = Dtl.DocumentID
            Dr("JobCode") = DocumentType
            Dr("CreateTime") = Now()
            FinalDs.Tables(1).Rows.Add(Dr)

            With Me.GridResult.ActiveRow
                .Cells("TotalDocs").Value = 1
                .Cells("LastDocs").Value = DocumentType
                .Cells("SentTime").Value = Job.JobCode
                Me.GridResult.Update()
            End With


        End If

    End Sub

    Private Sub ComboActivity_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboActivity.TextChanged

        If Not DS Is Nothing Then
            For Each tb As DataTable In DS.Tables
                tb.Clear()
            Next
            DS.AcceptChanges()
        End If
        SetComboPrint()

    End Sub

    Private Sub SetComboPrint()


        Dim Items As New Collection
        Me.ComboPrint.Items.Clear()



        Select Case Me.ComboActivity.Text

            Case "No DO Taken", "Over Due", "No Settel"
                Me.ComboPrint.Items.Add("1st Notice")
                Me.ComboPrint.Items.Add("2nd Notice")


        End Select







    End Sub
End Class