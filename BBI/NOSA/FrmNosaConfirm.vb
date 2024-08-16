Imports Infragistics.Win.UltraWinGrid
Imports System.Data.SqlClient
Public Class FrmNosaConfirm

    Private Sub ButtonUpdateBL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonUpdateBL.Click

        Dim Row As UltraGridRow
        Dim Tb As New DataTable
        Dim Dr As DataRow
        Dim drs() As DataRow
        Dim Cmd As New SqlCommand
        Dim Cnn As New SqlConnection
        Dim Trn As SqlTransaction
        Dim sSql As String

        Tb.Columns.Add(New DataColumn("BLNO"))

        For Each Row In GridData.Rows
            drs = Tb.Select("BLNO = '" & Row.Cells("ODesc").Value.ToString & "'")
            If drs.Length = 0 Then
                Dr = Tb.NewRow
                Dr("BLNO") = Row.Cells("ODesc").Value.ToString
                Tb.Rows.Add(Dr)
            End If
        Next

        Cnn = New SqlConnection(My.Settings.DSN)
        Cnn.Open()
        Trn = Cnn.BeginTransaction()

        sSql = "update tb_InwardBls set FinalaizeDate = @FinalizeDate where BlNo = @BLNO and FinalizeDate Is Null"

        With Cmd
            .CommandText = "SP_InwardUpdateFinalize"
            .CommandType = CommandType.StoredProcedure
            .Connection = Cnn
            .Parameters.Add("@FinalizeDate", SqlDbType.SmallDateTime)
            .Parameters.Add("@BLNO", SqlDbType.VarChar, 25)
            .Transaction = Trn
        End With

        For Each Dr In Tb.Rows
            With Cmd
                .Connection = Cnn
                .Parameters("@FinalizeDate").Value = Now.Date
                .Parameters("@BLNO").Value = Dr("BLNO")
                .ExecuteNonQuery()
            End With
        Next

        Try
            Trn.Commit()
            MsgBoxSaveSuccessful()
        Catch ex As Exception
            MsgBoxSaveFailed()
            MsgBox(ex.ToString)
        Finally
            Trn.Dispose()
        End Try


    End Sub


    Private Sub ButtonGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGenerate.Click

        Dim CLGen As New CLNOSAVocher
        Dim DLG As New SaveFileDialog
        Dim sResult As String = ""
        Dim lResult As Boolean

        DLG.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*"
        DLG.ShowDialog()
        If DLG.FileName <> "" Then
            CLGen.GenerateConfirmVocher(Me.DateGenerate.Value, sResult)
            Dim SW As New IO.StreamWriter(DLG.FileName)
            SW.Write(sResult)
            SW.Flush()
            SW.Close()
        End If
    End Sub

    Private Sub ButtonFinal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFinal.Click

        Dim CLGen As New CLNOSAVocher
        Dim DLG As New SaveFileDialog
        Dim sResult As String = ""
        Dim lResult As Boolean
        Dim Ds As New DataSet

        DLG.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*"
        DLG.ShowDialog()
        If DLG.FileName <> "" Then
            CLGen.GenerateNOSAClose(sResult, Me.ReGenerate.Value, "N")
            Dim SW As New IO.StreamWriter(DLG.FileName)
            SW.Write(sResult)
            SW.Flush()
            SW.Close()
            Try
                Ds.ReadXml(DLG.FileName)
                Me.GridData.DataSource = Ds
            Catch ex As Exception

            End Try


        End If
    End Sub

    
    Private Sub ButtonVchExp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonVchExp.Click

        Dim CLGen As New CLNOSAVocher
        Dim DLG As New SaveFileDialog
        Dim sResult As String = ""
        Dim lResult As Boolean

        DLG.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*"
        DLG.ShowDialog()
        If DLG.FileName <> "" Then
            CLGen.GenerateConfirmVocherExp(DateGenerate.Value, sResult)
            Dim SW As New IO.StreamWriter(DLG.FileName)
            SW.Write(sResult)
            SW.Flush()
            SW.Close()
        End If
    End Sub

    Private Sub ButtonReGen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonReGen.Click

        Dim CLGen As New CLNOSAVocher
        Dim DLG As New SaveFileDialog
        Dim sResult As String = ""
        Dim lResult As Boolean
        Dim Ds As New DataSet

        DLG.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*"
        DLG.ShowDialog()
        If DLG.FileName <> "" Then
            CLGen.GenerateNOSAClose(sResult, Me.ReGenerate.DateTime.Date, "Y")
            Dim SW As New IO.StreamWriter(DLG.FileName)
            SW.Write(sResult)
            SW.Flush()
            SW.Close()
            Ds.ReadXml(DLG.FileName)
            Me.GridData.DataSource = Ds
        End If

    End Sub

    Private Sub ButtonDBDetn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDBDetn.Click


        Dim CLGen As New CLNOSAVocher
        Dim DLG As New SaveFileDialog
        Dim sResult As String = ""
        Dim lResult As Boolean
        Dim Ds As New DataSet

        DLG.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*"
        DLG.ShowDialog()
        If DLG.FileName <> "" Then
            CLGen.GenNosaDetentinDebit(sResult, DateGenerate.Value)
            Dim SW As New IO.StreamWriter(DLG.FileName)
            SW.Write(sResult)
            SW.Flush()
            SW.Close()
            MsgBox("Generate Successful")
        End If


    End Sub
End Class