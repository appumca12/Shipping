Imports OrmLib
Imports ShippingBiz
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinEditors
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports System.IO
Imports System.Text

Public Class FrmBlPrintDef

    Private Sub ButtonRetrieve_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRetrieve.Click
        Dim Cmd As New SqlCommand
        Dim Cnn As New SqlConnection(My.Settings.DSN)
        Dim DA As New SqlClient.SqlDataAdapter
        Dim lResult As Boolean
        Dim TB As New DataTable
        Dim Dlg As New SaveFileDialog
        Dim barrImg As Byte()
        Dim strfn As String
        Dim fs As FileStream
        Dim FleName As String
        Dim ID As String
        Dim Drs() As DataRow

        TableBySql("Select * From TB_ObjectsUser Where ID = '" & Me.ComboList.ComboGnrl.SelectedItem(0).ToString & "'", TB, lResult)
        If TB.Rows.Count > 0 Then
            ID = TB.Rows(0).Item("ID").ToString
            Me.ObjectName.TextValue = TB.Rows(0).Item("ObjectName")
            Me.ObjectRemarks.TextValue = TB.Rows(0).Item("ObjectRemarks")
            Dlg.ShowDialog()

            If Dlg.FileName <> "" Then
                FleName = Dlg.FileName
                Cmd = New SqlCommand("select ObjectContent from TB_ObjectsUser where ID = '" & ID & "'", Cnn)
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

                Try
                    TB = New DataTable
                    TableBySql("select ObjectContentXML from TB_ObjectsUser where ID = '" & ID & "'", TB, lResult)
                    TB = XmlToTable(TB.Rows(0).Item("ObjectContentXML").ToString)
                    Drs = TB.Select("Name = 'BodyLines'")
                    If Drs.Length > 0 Then
                        Me.BodyLines.CtrlValue = Drs(0).Item("Value")
                    End If
                Catch ex As Exception
                    Me.BodyLines.CtrlValue = 15
                End Try


            End If
        End If
    End Sub

    Private Sub ButtonSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSave.Click
        Dim Dlg As New OpenFileDialog
        If Me.ObjectName.TextValue = "" Then
            MsgBox("Please Fill Name !")
            Return
        End If

        Dlg.ShowDialog()

        If Dlg.FileName = "" Then
            Exit Sub
        End If

        If IsSave(Dlg.FileName) = True Then
            MsgBoxSaveSuccessful()
        Else
            MsgBoxSaveFailed()
        End If
    End Sub

    Private Sub FrmBlPrintDef_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ObjectRemarks.GeneralText.Multiline = True
        RefreshCombo()
    End Sub

    Private Function IsSave(ByVal FleName As String) As Boolean

        Dim Cmd As New SqlCommand
        Dim Cnn As New SqlConnection(My.Settings.DSN)
        Dim iresult As Int16
        Dim TB As New DataTable
        Dim DA As New SqlClient.SqlDataAdapter

        Dim lResult As Boolean
        Dim Dr As DataRow

        Dim Obj() As Byte = GetFileInByts(FleName)

        TB = New DataTable("Settings")
        TB.Columns.Add("Name")
        TB.Columns.Add("Value")

        Dr = TB.NewRow
        Dr("Name") = "BodyLines"
        Dr("Value") = Me.BodyLines.CtrlValue.ToString
        TB.Rows.Add(Dr)

        Dim Z As New StringWriter()
        TB.WriteXml(Z, XmlWriteMode.WriteSchema)

        Cnn.Open()
        Cmd = New SqlCommand()
        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.Connection = Cnn
        Cmd.CommandType = CommandType.Text
        Cmd.CommandText = "Select * From  TB_ObjectsUser Where  ObjectName = '" & Me.ObjectName.TextValue & "' and ObjectGroup = 'BL' and ObjectLine= '" & CurrentShippingLine & "'"
        DA.SelectCommand = Cmd
        TB = New DataTable
        DA.Fill(TB)

        If TB.Rows.Count = 0 Then
            Cmd.CommandText = "INSERT INTO TB_ObjectsUser(ID, ObjectLine , ObjectGroup , ObjectName , ObjectRemarks , ObjectContent, ObjectContentXML) values(@ID , @ObjectLine, @ObjectGroup ,  @ObjectName , @ObjectRemarks , @ObjectContent , @ObjectContentXML)"
            Cmd.Parameters.Add("@ID", SqlDbType.VarChar, 36)
            Cmd.Parameters.Add("@ObjectLine", SqlDbType.VarChar, 10)
            Cmd.Parameters.Add("@ObjectGroup", SqlDbType.VarChar, 10)
            Cmd.Parameters.Add("@ObjectName", SqlDbType.VarChar, 50)
            Cmd.Parameters.Add("@ObjectRemarks", SqlDbType.NVarChar, 255)
            Cmd.Parameters.Add("@ObjectContent", SqlDbType.Image, Obj.Length)
            Cmd.Parameters.Add("@ObjectContentXML", SqlDbType.Xml)
            Cmd.Parameters("@ID").Value = System.Guid.NewGuid.ToString
            Cmd.Parameters("@ObjectLine").Value = CurrentShippingLine
            Cmd.Parameters("@ObjectGroup").Value = "BL"
            Cmd.Parameters("@ObjectName").Value = Me.ObjectName.TextValue
            Cmd.Parameters("@ObjectRemarks").Value = Me.ObjectRemarks.TextValue
            Cmd.Parameters("@ObjectContentXML").Value = Z.ToString
            Cmd.Parameters("@ObjectContent").Value = Obj
        Else
            Cmd.CommandText = "Update TB_ObjectsUser set ObjectContent = @ObjectContent , ObjectName = @ObjectName , ObjectRemarks  = @ObjectRemarks , ObjectContentXML = @ObjectContentXML  Where ID = @ID"
            Cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier, 36)
            Cmd.Parameters.Add("@ObjectName", SqlDbType.VarChar, 50)
            Cmd.Parameters.Add("@ObjectRemarks", SqlDbType.NVarChar, 255)
            Cmd.Parameters.Add("@ObjectContent", SqlDbType.Image, Obj.Length)
            'Cmd.Parameters.Add("@ObjectContentXML", SqlDbType.Xml)
            Cmd.Parameters("@ID").Value = TB.Rows(0).Item("ID")
            Cmd.Parameters("@ObjectName").Value = Me.ObjectName.TextValue
            Cmd.Parameters("@ObjectRemarks").Value = Me.ObjectRemarks.TextValue
            Cmd.Parameters("@ObjectContent").Value = Obj
            Cmd.Parameters.AddWithValue("@ObjectContentXML", Z.ToString)
        End If

        Try
            iresult = Cmd.ExecuteNonQuery()
            lResult = True
        Catch ex As Exception
            lResult = False
            MsgBox(ex.ToString)
        Finally
            Cnn.Close()
        End Try

        RefreshCombo()
        Return lResult
    End Function

    Private Sub RefreshCombo()
        Dim Tb As New DataTable
        Dim lResult As Boolean
        TableBySql("Select ID , ObjectName from TB_ObjectsUser Where ObjectLine = '" & CurrentShippingLine & "' and ObjectGroup = 'BL'", Tb, lResult)
        With Me.ComboList.ComboGnrl
            .DataSource = Tb
            .SelectedItem = "ID"
            .DisplayMember = "ObjectName"
        End With

    End Sub
End Class