Imports System
Imports Infragistics.Win
Imports OrmLib
Imports ShippingBiz
Imports Infragistics.Shared
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinEditors
Imports System.Data.SqlClient
Imports System.IO
Imports System.Text
Imports System.Reflection
Imports System.Runtime.InteropServices
Imports System.Diagnostics
' Sql2005 CnnString Data Source=TECRA\SQLEXPRESS;Initial Catalog=Shipping;Integrated Security=True
' Sql2000 CnnString Data Source=tecra;Initial Catalog=Shipping;Persist Security Info=True;User ID='sa';password='storm'
Public Enum EType
    TextType
    XMLType
End Enum
Public Enum NavigateType

    FirstRecord
    LastRecord
    NextRecord
    PreviousRecord

End Enum
Public Enum EDIContent
    InwardData
    Booking
End Enum
Module General
    Public CurrentShippingLine As String = ""
    Public CurrentUser As TB_Users
    Public TbConfig As New DataTable
    Public CurrentCompany As TB_Company
    Public DatabaseName As String
    Public calculationBase As TB_CalculationBase
    Public Enum LangType
        English
        Persian
    End Enum
    Public Enum FormStatus
        NoAction
        NewRecord
        EditRecord
        HasData
    End Enum
    Public Enum InOut
        InWard
        OutWard
    End Enum
    Public Enum ErrMsgtype
        Err
        Warning
    End Enum
    Public Enum InvoiceStatus
        Issue
        ToClient
        ToAccount
        Confirm
        Cancel
    End Enum
    Public Enum InwardOutward
        Inward
        Outward
    End Enum
    Public Sub Main()

        '    Dim Frm As New FrmLogon
        '    Frm.Show()

    End Sub
    Public Sub KeyboardLaguage(ByVal ChangeTo As LangType)

        Dim lang As InputLanguage
        Dim TxtLang As String

        If ChangeTo = LangType.English Then
            TxtLang = UCase("English")
        Else
            TxtLang = UCase("Persian")
        End If

        For Each lang In InputLanguage.InstalledInputLanguages
            If InStr(1, UCase(lang.Culture.EnglishName), TxtLang) > 0 Then
                InputLanguage.CurrentInputLanguage = lang
            End If
        Next lang

    End Sub
    Public Function MsgBoxDelete() As DialogResult
        Return MessageBox.Show("Are You Sure To Delete This Record ?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
    End Function
    Public Function MsgBoxUpdate() As DialogResult
        Return MessageBox.Show("Are You Sure To Update This Record ?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
    End Function
    Public Function MsgBoxSaveFailed() As DialogResult
        Return MessageBox.Show("Save Record Faild !", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Function
    Public Function MsgBoxSaveSuccessful() As DialogResult
        Return MessageBox.Show("Save Record Successful!", "Action Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Function
    Public Function MsgBoxDeleteSuccessful() As DialogResult
        Return MessageBox.Show("Delete Record Successful!", "Action Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Function
    Public Function MsgBoxDeleteFailed() As DialogResult
        Return MessageBox.Show("Delete Record Faild !", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Function
    Public Function MsgBoxGeneral(ByVal Msg As String, ByVal Title As String) As MessageBoxButtons
        Return MessageBox.Show(Msg, Title)
    End Function
    Public Function MsgBoxValidateFaild() As DialogResult
        Return MessageBox.Show("No Completed Data !", "Data Validate Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Function
    Public Function MsgBoxGeneral(ByVal Msg) As DialogResult
        Return MessageBox.Show(Msg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Function
    Public Function MsgBoxQutiWithSave() As DialogResult
        Return MessageBox.Show("Do You Want Save Changes Befor Quit ?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)
    End Function
    Public Function MsgBoxTempMinMax() As DialogResult
        Return MessageBox.Show("Temp Min and Max values are Empty. Do you want to Save?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)
    End Function
    Public Sub GnrlFormKeyStatusChange(ByRef ToolBar As Infragistics.Win.UltraWinToolbars.UltraToolbarsManager, ByVal Status As FormStatus)
        'Public Sub GnrlFormKeyStatusChange(ByVal Status As FormStatus)

        Select Case Status

            Case FormStatus.EditRecord

                If ToolBar.Tools.Item("Edit").SharedProps.Tag = "" Then
                    ToolBar.Tools.Item("Edit").SharedProps.Enabled = False
                End If

                If ToolBar.Tools.Item("Save").SharedProps.Tag = "" Then
                    ToolBar.Tools.Item("Save").SharedProps.Enabled = True
                End If

                If ToolBar.Tools.Item("Delete").SharedProps.Tag = "" Then
                    ToolBar.Tools.Item("Delete").SharedProps.Enabled = True
                Else
                    ToolBar.Tools.Item("Delete").SharedProps.Enabled = False
                End If

                If ToolBar.Tools.Item("New").SharedProps.Tag = "" Then
                    ToolBar.Tools.Item("New").SharedProps.Enabled = True
                End If

            Case FormStatus.HasData

                If ToolBar.Tools.Item("Edit").SharedProps.Tag = "" Then
                    ToolBar.Tools.Item("Edit").SharedProps.Enabled = True
                End If

                If ToolBar.Tools.Item("Save").SharedProps.Tag = "" Then
                    ToolBar.Tools.Item("Save").SharedProps.Enabled = False
                End If

                ToolBar.Tools.Item("Delete").SharedProps.Enabled = False

                If ToolBar.Tools.Item("New").SharedProps.Tag = "" Then
                    ToolBar.Tools.Item("New").SharedProps.Enabled = True
                End If

            Case FormStatus.NewRecord

                If ToolBar.Tools.Item("Edit").SharedProps.Tag = "" Then
                    ToolBar.Tools.Item("Edit").SharedProps.Enabled = False
                End If

                If ToolBar.Tools.Item("Save").SharedProps.Tag = "" Then
                    ToolBar.Tools.Item("Save").SharedProps.Enabled = True
                End If

                If ToolBar.Tools.Item("Delete").SharedProps.Tag = "" Then
                    ToolBar.Tools.Item("Delete").SharedProps.Enabled = False
                End If

                If ToolBar.Tools.Item("New").SharedProps.Tag = "" Then
                    ToolBar.Tools.Item("New").SharedProps.Enabled = False
                End If

            Case FormStatus.NoAction


                ToolBar.Tools.Item("Edit").SharedProps.Enabled = False
                ToolBar.Tools.Item("Save").SharedProps.Enabled = False
                ToolBar.Tools.Item("Delete").SharedProps.Enabled = False

                If ToolBar.Tools.Item("New").SharedProps.Tag = "" Then
                    ToolBar.Tools.Item("New").SharedProps.Enabled = True
                Else
                    ToolBar.Tools.Item("New").SharedProps.Enabled = False
                End If

        End Select

    End Sub
    Public Sub GnrlFormKeyStatusChange(ByRef ToolBar As ToolStrip, ByVal Status As FormStatus)

        Select Case Status

            Case FormStatus.EditRecord

                If ToolBar.Items("BTN" & "Edit").Tag = "" Then
                    ToolBar.Items("BTN" & "Edit").Enabled = False
                End If

                If ToolBar.Items("BTN" & "Save").Tag = "" Then
                    ToolBar.Items("BTN" & "Save").Enabled = True
                End If

                If ToolBar.Items("BTN" & "Delete").Tag = "" Then
                    ToolBar.Items("BTN" & "Delete").Enabled = True
                Else
                    ToolBar.Items("BTN" & "Delete").Enabled = False
                End If

                If ToolBar.Items("BTN" & "New").Tag = "" Then
                    ToolBar.Items("BTN" & "New").Enabled = True
                End If

            Case FormStatus.HasData

                If ToolBar.Items("BTN" & "Edit").Tag = "" Then
                    ToolBar.Items("BTN" & "Edit").Enabled = True
                End If

                If ToolBar.Items("BTN" & "Save").Tag = "" Then
                    ToolBar.Items("BTN" & "Save").Enabled = False
                End If

                ToolBar.Items("BTN" & "Delete").Enabled = False

                If ToolBar.Items("BTN" & "New").Tag = "" Then
                    ToolBar.Items("BTN" & "New").Enabled = True
                End If

            Case FormStatus.NewRecord

                If ToolBar.Items("BTN" & "Edit").Tag = "" Then
                    ToolBar.Items("BTN" & "Edit").Enabled = False
                End If

                If ToolBar.Items("BTN" & "Save").Tag = "" Then
                    ToolBar.Items("BTN" & "Save").Enabled = True
                End If

                If ToolBar.Items("BTN" & "Delete").Tag = "" Then
                    ToolBar.Items("BTN" & "Delete").Enabled = False
                End If

                If ToolBar.Items("BTN" & "New").Tag = "" Then
                    ToolBar.Items("BTN" & "New").Enabled = False
                End If

            Case FormStatus.NoAction

                ToolBar.Items("BTN" & "Edit").Enabled = False
                ToolBar.Items("BTN" & "Save").Enabled = False
                ToolBar.Items("BTN" & "Delete").Enabled = False

                If ToolBar.Items("BTN" & "New").Tag = "" Then
                    ToolBar.Items("BTN" & "New").Enabled = True
                Else
                    ToolBar.Items("BTN" & "New").Enabled = False
                End If

        End Select

    End Sub

    Public Sub ClearControl(ByVal Frm As Form)

        Dim Ctl As Object

        For Each Ctl In Frm.Controls

            If TypeOf Ctl Is System.Windows.Forms.TextBox Then Ctl.Text = ""
            If TypeOf Ctl Is System.Windows.Forms.ComboBox Then Ctl.Selectedindex = -1
            If TypeOf Ctl Is System.Windows.Forms.DateTimePicker Then Ctl.value = DBNull.Value
            If TypeOf Ctl Is System.Windows.Forms.CheckBox Then Ctl.checked = False
            If TypeOf Ctl Is System.Windows.Forms.RadioButton Then Ctl.checked = False
            If TypeOf Ctl Is System.Windows.Forms.ListBox Then Ctl.SelectedIndex = -1
            If TypeOf Ctl Is System.Windows.Forms.RichTextBox Then Ctl.Text = ""
            If TypeOf Ctl Is Infragistics.Win.UltraWinEditors.UltraDateTimeEditor Then Ctl.value = DBNull.Value


            If TypeOf Ctl Is System.Windows.Forms.UserControl Then
                ClearText(Ctl)
            End If

            If TypeOf Ctl Is Infragistics.Win.Misc.UltraGroupBox Then
                ClearText(Ctl)
            End If

            If TypeOf Ctl Is Infragistics.Win.UltraWinTabControl.UltraTabControl Then
                ClearText(Ctl)
            End If

            If TypeOf Ctl Is System.Windows.Forms.GroupBox Then
                ClearText(Ctl)
            End If

            If TypeOf Ctl Is System.Windows.Forms.TableLayoutPanel Then
                ClearText(Ctl)
            End If


        Next
    End Sub
    Private Sub ClearText(ByVal ControlContainer As Object)

        For Each Ctl As Object In ControlContainer.Controls
            Try
                If Not Ctl.Controls Is Nothing Then
                    ClearText(Ctl)
                    If TypeOf Ctl Is Windows.Forms.TextBox Then Ctl.text = ""
                    If TypeOf Ctl Is UltraWinGrid.UltraCombo Then Ctl.text = ""
                    If TypeOf Ctl Is UltraWinGrid.UltraCombo Then Ctl.text = ""
                    If TypeOf Ctl Is UltraWinEditors.UltraDateTimeEditor Then Ctl.text = ""
                    If TypeOf Ctl Is UltraWinEditors.UltraNumericEditor Then Ctl.value = 0
                    If TypeOf Ctl Is UltraWinEditors.UltraTextEditor Then Ctl.text = ""
                    If TypeOf Ctl Is UltraWinEditors.UltraTextEditor Then Ctl.text = ""
                    If TypeOf Ctl Is System.Windows.Forms.ComboBox Then Ctl.text = ""

                End If
            Catch ex As Exception

            End Try
        Next

    End Sub
    Public Sub ClearContainer(ByVal ControlContainer As Object)

        For Each Ctl As Object In ControlContainer.Controls
            Try
                If Not Ctl.Controls Is Nothing Then
                    ClearContainer(Ctl)
                    If TypeOf Ctl Is Windows.Forms.TextBox Then Ctl.text = ""
                    If TypeOf Ctl Is UltraWinGrid.UltraCombo Then Ctl.text = ""
                    If TypeOf Ctl Is UltraWinGrid.UltraCombo Then Ctl.text = ""
                    If TypeOf Ctl Is UltraWinEditors.UltraDateTimeEditor Then Ctl.text = ""
                    If TypeOf Ctl Is UltraWinEditors.UltraNumericEditor Then Ctl.value = 0
                    If TypeOf Ctl Is UltraWinEditors.UltraTextEditor Then Ctl.text = ""
                    If TypeOf Ctl Is UltraWinEditors.UltraTextEditor Then Ctl.text = ""
                    If TypeOf Ctl Is System.Windows.Forms.ComboBox Then Ctl.text = ""

                End If
            Catch ex As Exception

            End Try
        Next

    End Sub


    Public Sub ShowErrorForControl(ByVal EProvider As ErrorProvider, ByVal Ctrl As Control, ByVal ErrMsg As String)
        EProvider.SetError(Ctrl, ErrMsg)
    End Sub
    Public Function GetCodeList(ByVal GroupCode As String) As DataTable

        Dim dm As New DataManager(My.Settings.DSN)

        dm.QueryCriteria.And(JoinPath.TB_CODE.Columns.GroupCode, GroupCode, MatchType.Exact)
        dm.GetTB_CODECollection()
        Return dm.DataSet.Tables("TB_Code")

    End Function
    Public Sub TableBySql(ByVal sSql As String, ByRef TB As DataTable, ByRef lResult As Boolean)

        Dim ds As New DataSet
        Dim Da As New Data.SqlClient.SqlDataAdapter(sSql, My.Settings.DSN)
        Da.SelectCommand.CommandTimeout = 50000
        TB = New DataTable
        Da.Fill(ds, "Result")
        If ds.Tables("Result").Columns.Count > 0 Then
            lResult = True
            TB = ds.Tables("Result")
        Else
            lResult = False
            TB.Clear()
            TB = ds.Tables("Result")
        End If

    End Sub
    Public Sub DataSetBySql(ByVal sSql As String, ByRef DS As DataSet, ByRef lResult As Boolean)

        Dim Da As New Data.SqlClient.SqlDataAdapter(sSql, My.Settings.DSN)
        DS = New DataSet
        Da.Fill(DS)
        If DS.Tables(0).Columns.Count > 0 Then
            lResult = True
        Else
            lResult = False
        End If

    End Sub
    Public Function FieldsBySql(ByVal sSql As String, ByRef aFieldNames() As String, ByRef lResult As Boolean) As ArrayList

        Dim ds As New DataSet
        Dim Da As New Data.SqlClient.SqlDataAdapter(sSql, My.Settings.DSN)
        Dim Dr As DataRow
        Dim aList As New ArrayList
        Dim sFld As String
        Da.Fill(ds, "Result")
        If ds.Tables("Result").Rows.Count > 0 Then
            lResult = True
            Dr = ds.Tables("Result").Rows(0)
            For Each sFld In aFieldNames
                aList.Add(IIf(IsDBNull(Dr(sFld)), "", Dr(sFld)))
            Next
        Else
            aList.Add(0)
            lResult = False

        End If

        Return aList

    End Function
    Public Sub LockControls(ByVal Frm As Form, ByVal IsLock As Boolean)
        Dim Ctl As Object

        For Each Ctl In Frm.Controls

            If TypeOf Ctl Is System.Windows.Forms.TextBox Then Ctl.enabled = IsLock
            If TypeOf Ctl Is System.Windows.Forms.ComboBox Then Ctl.locked = IsLock
            If TypeOf Ctl Is System.Windows.Forms.DateTimePicker Then Ctl.enabled = IsLock
            If TypeOf Ctl Is System.Windows.Forms.CheckBox Then Ctl.enabled = IsLock
            If TypeOf Ctl Is System.Windows.Forms.RadioButton Then Ctl.enabled = IsLock
            If TypeOf Ctl Is System.Windows.Forms.ListBox Then Ctl.enabled = IsLock
            If TypeOf Ctl Is System.Windows.Forms.RichTextBox Then Ctl.enabled = IsLock
            If TypeOf Ctl Is System.Windows.Forms.UserControl Then
                LockControl(Ctl, IsLock)
            End If
            If TypeOf Ctl Is Infragistics.Win.Misc.UltraGroupBox Then
                LockControl(Ctl, IsLock)
            End If

            If TypeOf Ctl Is Infragistics.Win.UltraWinTabControl.UltraTabControl Then
                LockControl(Ctl, IsLock)
            End If

        Next

    End Sub
    Private Sub LockControl(ByVal ControlContainer As Object, ByVal IsLock As Boolean)
        For Each Ctl As Object In ControlContainer.Controls
            Try
                If Not Ctl.Controls Is Nothing Then
                    LockControl(Ctl, IsLock)
                    If TypeOf Ctl Is Windows.Forms.TextBox Then Ctl.enabled = IsLock
                    If TypeOf Ctl Is UltraWinGrid.UltraCombo Then Ctl.enabled = IsLock
                    If TypeOf Ctl Is UltraWinEditors.UltraDateTimeEditor Then Ctl.enabled = IsLock
                    If TypeOf Ctl Is UltraWinEditors.UltraNumericEditor Then Ctl.enabled = IsLock
                    If TypeOf Ctl Is UltraWinEditors.UltraTextEditor Then Ctl.locked = IsLock
                    If TypeOf Ctl Is System.Windows.Forms.ComboBox Then Ctl.enabled = IsLock
                    If TypeOf Ctl Is UltraWinGrid.UltraGrid Then
                        Ctl.enabled = IsLock
                    End If
                End If
            Catch ex As Exception
            End Try
        Next
    End Sub
    Public Sub AddRowToErrorTable(ByRef Tb As DataTable, ByVal Section As String, ByVal Msg As String, ByVal MsgType As ErrMsgtype)

        Dim Dr As DataRow

        If Tb Is Nothing Then
            Tb = New DataTable("Error")
            Tb.Columns.Add(New DataColumn("Section", System.Type.GetType("System.String")))
            Tb.Columns.Add(New DataColumn("Message", System.Type.GetType("System.String")))
            Tb.Columns.Add(New DataColumn("MsgType", System.Type.GetType("System.Int16")))
        End If

        Dr = Tb.NewRow
        Try
            Dr("Section") = Section
        Catch ex As Exception
            Tb.Columns.Add(New DataColumn("Section", System.Type.GetType("System.String")))
            Dr("Section") = Section
        End Try

        Try
            Dr("Message") = Msg
        Catch ex As Exception
            Tb.Columns.Add(New DataColumn("Message", System.Type.GetType("System.String")))
            Dr("Message") = Msg
        End Try

        Try
            Dr("MsgType") = MsgType
        Catch ex As Exception
            Tb.Columns.Add(New DataColumn("MsgType", System.Type.GetType("System.String")))
            Dr("MsgType") = MsgType
        End Try

        Tb.Rows.Add(Dr)

    End Sub
    Public Function RaiseError(ByVal Tb As DataTable) As Byte

        Dim nErrCount As Byte = 0
        Dim Frm As FrmRaiseError = New FrmRaiseError(Tb, nErrCount)
        Frm.ShowDialog()
        Frm = Nothing
        Return nErrCount

    End Function
    Public Sub SaveGridToExcel(ByVal Grid As Infragistics.Win.UltraWinGrid.UltraGrid)


        Dim Exporter As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter

        Dim SaveDialog As SaveFileDialog

        If Grid.Rows.Count = 0 Then
            Exit Sub
        End If
        'Dim S As String
        'For Each col As UltraGridColumn In Grid.DisplayLayout.Bands(0).Columns

        '    S = S & col.Key & vbCrLf
        'Next
        '  Grid.DisplayLayout.Bands(0).Hidden = True
        SaveDialog = New SaveFileDialog
        Exporter = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
        SaveDialog.Filter = "Excel Files (*.xls)|*.xls|All files (*.*)|*.*"
        SaveDialog.ShowDialog()
        If SaveDialog.FileName = "" Then
            Exit Sub
        End If

        Try
            Exporter.Export(Grid, SaveDialog.FileName)
            Process.Start(SaveDialog.FileName)
        Catch ex As Exception
            'MsgBox("Export to Excel Faild !", MsgBoxStyle.Critical)
        End Try

    End Sub
    ' For the case NEW REPORT CREATION REQUEST : "DETENTION OUTSTANDING SUMMARY"
    Public Sub InwardCntrsCountForDetentionOutstanding(ByVal BLID As Guid, ByRef ResultDividInLines As String)
        Dim sSql As String
        Dim TB As New DataTable
        Dim lResult As Boolean
        Dim Dr As DataRow
        Dim Ans As String = ""
        sSql = "SP_InwardCntrsCountForDetOutStanding '" & BLID.ToString & "'"
        TableBySql(sSql, TB, lResult)
        If lResult = True Then
            For Each Dr In TB.Rows
                Ans = Ans & IIf(Ans = "", "", vbCrLf) & Dr("Total") & " X " & Dr("Size") & " " & Dr("Type") & " " & Dr("FCL")
            Next
        End If
        ResultDividInLines = Ans
        TB.Dispose()

    End Sub
    Public Sub InwardCntrsCount(ByVal BLID As Guid, ByRef ResultDividInLines As String)
        Dim sSql As String
        Dim TB As New DataTable
        Dim lResult As Boolean
        Dim Dr As DataRow
        Dim Ans As String = ""
        sSql = "SP_InwardCntrsCount '" & BLID.ToString & "'"
        TableBySql(sSql, TB, lResult)
        If lResult = True Then
            For Each Dr In TB.Rows
                Ans = Ans & IIf(Ans = "", "", vbCrLf) & Dr("Total") & " X " & Dr("Size") & " " & Dr("Type") & " " & Dr("FCL")
            Next
        End If
        ResultDividInLines = Ans
        TB.Dispose()

    End Sub
    Public Sub OutwardCntrsCount(ByVal BLID As Guid, ByRef ResultDividInLines As String)
        Dim sSql As String
        Dim TB As New DataTable
        Dim lResult As Boolean
        Dim Dr As DataRow
        Dim Ans As String = ""
        sSql = "SP_OutwardCntrsCount '" & BLID.ToString & "'"
        TableBySql(sSql, TB, lResult)
        If lResult = True Then
            For Each Dr In TB.Rows
                Ans = Ans & IIf(Ans = "", "", vbCrLf) & Dr("Total") & " X " & Dr("Size") & " " & Dr("Type") & " " & Dr("FCL")
            Next
        End If
        ResultDividInLines = Ans
        TB.Dispose()

    End Sub
    Public Sub ChangeControlColor(ByVal ControlContainers As Object, ByVal Ctltype As String, ByVal BackColor As Color, ByVal Forecolor As Color)

        For Each Ctl As Object In ControlContainers.controls
            Try
                If Ctl.GetType.ToString = Ctltype.ToString Then
                    Ctl.backcolor = My.Settings.MainColor
                    Ctl.forecolor = My.Settings.LableForeColor
                    Ctl.Appearance.backcolor = My.Settings.MainColor
                    Ctl.Appearance.ForeColor = My.Settings.LableForeColor
                End If
            Catch ex As Exception
            End Try
        Next

    End Sub
    Public Function NullToValue(ByVal Value As Object, ByVal ChangeTo As Object) As Object

        If IsDBNull(Value) Or Value Is Nothing Then
            Return ChangeTo
        Else
            Return Value
        End If

    End Function
    Public Function GetNewInvNo(ByVal IO As InOut) As String

        Dim Ds As New DataSet
        Dim nI As Long
        Dim Office As String

        If Len(My.Settings.Office) > 3 Then
            Office = Mid(My.Settings.Office, 3, 1)
        Else
            Office = My.Settings.Office
        End If

        If IO = InOut.InWard Then
            Ds = StoredProcedures.SP_GetLastInwardInvoiceNo(Office)
            nI = Val(Ds.Tables(0).Rows(0).Item(0)) + 1
        Else
            Ds = StoredProcedures.SP_GetLastOutwardInvoiceNo(Office)
            nI = Val(Ds.Tables(0).Rows(0).Item(0)) + 1
        End If

        If Len(My.Settings.Office) > 3 Then
            Return Mid(My.Settings.Office, 3, 1) & Right(Format(Now, "yyyy"), 2) & IIf(Left(IO.ToString, 1) = "O", "E", "I") & "-" & Format(nI, "00000")
        Else
            Return Left(My.Settings.Office, 1) & Right(Format(Now, "yyyy"), 2) & IIf(Left(IO.ToString, 1) = "O", "E", "I") & "-" & Format(nI, "00000")
        End If

    End Function
    Public Sub DrawTransParentLabel(ByVal LBl As Label, ByVal e As System.Windows.Forms.PaintEventArgs)

        LBl.Visible = False
        e.Graphics.DrawString(LBl.Text, LBl.Font, New SolidBrush(LBl.ForeColor), LBl.Left, LBl.Top)

    End Sub
    Public Function GetUserConfigFilePath() As String
        Return "c:\Tmp\" & CurrentUser.UserCode & "Config.Xml"
    End Function
    Public Function GetUserConfigItem(ByVal key As String) As String

        Dim Dv As DataView
        Dim lShow As Boolean = False
        Dv = New DataView(TbConfig, "Key = '" & key & "'", "", DataViewRowState.CurrentRows)
        If Dv.Count = 0 Then
            Return ""
        Else
            Return Dv.Item(0).Item("Description")
        End If
    End Function
    Public Sub SyncDataTable(ByVal Origin As DataTable, ByVal Dest As DataTable, ByRef lResult As Boolean)

        Dim Tb As DataTable
        Dim Dr As DataRow
        Dim Dv As DataView
        Dim DC As DataColumn

        Try
            Tb = Origin
            If Not Tb Is Nothing Then
                For Each Dr In Tb.Rows
                    Select Case Dr.RowState
                        Case DataRowState.Added
                            Dest.ImportRow(Dr)
                        Case DataRowState.Deleted
                            Dv = New DataView(Dest, "ID = '" & Dr(0, DataRowVersion.Original).ToString & "'", "", DataViewRowState.CurrentRows)
                            If Dv.Count > 0 Then
                                Dv.Item(0).Delete()
                            End If
                        Case DataRowState.Modified
                            Dv = New DataView(Dest, "ID = '" & Dr.Item("ID").ToString & "'", "", DataViewRowState.CurrentRows)
                            If Dv.Count > 0 Then
                                For Each DC In Tb.Columns
                                    Dv.Item(0).Item(DC.ColumnName) = Dr.Item(DC.ColumnName)
                                Next
                            End If
                    End Select
                Next
            End If
            lResult = True
        Catch ex As Exception
            lResult = False
        End Try

    End Sub
    Public Function CheckDigit_suspend(ByVal Cntr As String) As Boolean

        Dim Str1 As String
        Dim Str2 As String
        Dim I As Integer
        Dim Sm As Double
        Dim ChkFnl As String
        Dim Lastno As String
        Dim j As Integer
        Dim Ans As Integer = 0
        Dim md As Double

        Str1 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"
        Str2 = "1013141516171819202123242526272829303132343536373800010203040506070809"

        For I = 1 To 10
            j = InStr(Str1, Mid(Cntr, I, 1))
            If j = 0 Then
                Return False
            Else
                Sm = Sm + Val(Mid(Str2, (j - 1) * 2 + 1, 2)) * (2 ^ (I - 1))
            End If
        Next I

        md = Sm Mod 11

        ChkFnl = Right(Str(md), 1)
        Lastno = Right(Cntr, 1)

        If Lastno <> ChkFnl Then
            Return False
        Else
            Return True
        End If

    End Function
    Public Function CheckDigit(ByVal Cntr As String) As Boolean

        '        Dim Str1 As String
        '        Dim Str2 As String
        '        Dim I As Integer
        '        Dim Sm As Double
        '        Dim ChkFnl As String
        '        Dim Lastno As String
        '        Dim j As Integer
        '        Dim Ans As Integer = 0
        '        Dim md As Double

        '        Str1 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"
        '        Str2 = "101
        '3141516171819202123242526272829303132343536373800010203040506070809"

        '        For I = 1 To 10
        '            j = InStr(Str1, Mid(Cntr, I, 1))
        '            If j = 0 Then
        '                Return False
        '            Else
        '                Sm = Sm + Val(Mid(Str2, (j - 1) * 2 + 1, 2)) * (2 ^ (I - 1))
        '            End If
        '        Next I

        '        md = Sm Mod 11

        '        ChkFnl = Right(Str(md), 1)
        '        Lastno = Right(Cntr, 1)

        '        If Lastno <> ChkFnl Then
        '            Return False
        '        Else
        '            Return True
        '        End If
        Return True
    End Function
    Public Sub GenerateLog(ByVal SaveDataset As DataSet)

        Dim Ds As DataSet = SaveDataset.GetChanges
        Dim Tb As DataTable
        Dim Dr As DataRow
        Dim Col As DataColumn
        Dim TbLog As New DataTable
        Dim Cnn As SqlConnection
        Dim lExcuteMaster As Boolean

        Dim CmdMaster As SqlCommand
        Dim CmdDetail As SqlCommand

        Cnn = New SqlConnection(My.Settings.DSN)
        Cnn.Open()

        CmdMaster = New SqlCommand
        With CmdMaster
            .CommandText = "SP_LogMasterIns"
            .CommandType = CommandType.StoredProcedure
            .Connection = Cnn
            With .Parameters
                .Add(New SqlParameter("@ID", SqlDbType.Char, 36))
                .Add(New SqlParameter("@TBName", SqlDbType.NVarChar, 50))
                .Add(New SqlParameter("@TableKey", SqlDbType.Char, 36))
                .Add(New SqlParameter("@ActionUser", SqlDbType.NVarChar, 10))
                .Add(New SqlParameter("@ActionType", SqlDbType.NVarChar, 10))
            End With
        End With

        CmdDetail = New SqlCommand
        With CmdDetail
            .CommandText = "SP_LogDetailsIns"
            .CommandType = CommandType.StoredProcedure
            .Connection = Cnn
            With .Parameters
                .Add(New SqlParameter("@ID", SqlDbType.Char, 36))
                .Add(New SqlParameter("@LogId", SqlDbType.Char, 36))
                .Add(New SqlParameter("@FieldName", SqlDbType.NVarChar, 50))
                .Add(New SqlParameter("@OldValue", SqlDbType.NVarChar, 2000))
                .Add(New SqlParameter("@NewValue", SqlDbType.NVarChar, 2000))
            End With
        End With

        Ds = SaveDataset.GetChanges
        If Not Ds Is Nothing Then

            For Each Tb In Ds.Tables

                For Each Dr In Tb.Rows

                    With CmdMaster
                        .Parameters("@ID").Value = System.Guid.NewGuid.ToString()
                        .Parameters("@TBName").Value = Tb.TableName
                        If Dr.RowState = DataRowState.Added Then
                            .Parameters("@TableKey").Value = Dr(0, DataRowVersion.Current).ToString()
                        Else
                            .Parameters("@TableKey").Value = Dr(0, DataRowVersion.Original).ToString()
                        End If
                        .Parameters("@ActionUser").Value = CurrentUser.UserCode
                        .Parameters("@ActionType").Value = Dr.RowState.ToString
                    End With
                    If Dr.RowState = DataRowState.Added Or Dr.RowState = DataRowState.Deleted Then
                        Try
                            CmdMaster.ExecuteNonQuery()
                        Catch ex As Exception
                            Beep()
                        End Try
                    End If

                    Select Case Dr.RowState

                        Case DataRowState.Added
                            For Each Col In Tb.Columns
                                With CmdDetail
                                    .Parameters("@ID").Value = System.Guid.NewGuid.ToString()
                                    .Parameters("@LogID").Value = CmdMaster.Parameters("@ID").Value
                                    .Parameters("@FieldName").Value = Col.ColumnName
                                    .Parameters("@OldValue").Value = ""
                                    .Parameters("@NewValue").Value = Dr(Col.ColumnName, DataRowVersion.Current).ToString()
                                End With
                                Try
                                    CmdDetail.ExecuteNonQuery()
                                Catch ex As Exception
                                    ex.ToString()
                                End Try
                            Next
                        Case DataRowState.Deleted
                            For Each Col In Tb.Columns
                                With CmdDetail
                                    .Parameters("@ID").Value = System.Guid.NewGuid.ToString()
                                    .Parameters("@LogID").Value = CmdMaster.Parameters("@ID").Value
                                    .Parameters("@FieldName").Value = Col.ColumnName
                                    .Parameters("@OldValue").Value = Dr(Col.ColumnName, DataRowVersion.Original).ToString()
                                    .Parameters("@NewValue").Value = ""
                                End With
                                Try
                                    CmdDetail.ExecuteNonQuery()
                                Catch ex As Exception
                                    MsgBox(ex.ToString)
                                End Try
                            Next
                        Case DataRowState.Modified
                            lExcuteMaster = False
                            For Each Col In Tb.Columns
                                If Dr(Col.ColumnName, DataRowVersion.Original).ToString() <> Dr(Col.ColumnName, DataRowVersion.Current).ToString() Then
                                    With CmdDetail
                                        .Parameters("@ID").Value = System.Guid.NewGuid.ToString()
                                        .Parameters("@LogID").Value = CmdMaster.Parameters("@ID").Value
                                        .Parameters("@FieldName").Value = Col.ColumnName
                                        .Parameters("@OldValue").Value = Dr(Col.ColumnName, DataRowVersion.Original).ToString()
                                        .Parameters("@NewValue").Value = Dr(Col.ColumnName, DataRowVersion.Current).ToString()
                                    End With
                                    Try
                                        If lExcuteMaster = False Then
                                            CmdMaster.ExecuteNonQuery()
                                            lExcuteMaster = True
                                        End If
                                        CmdDetail.ExecuteNonQuery()
                                    Catch ex As Exception
                                        Beep()
                                        MsgBox(ex.ToString)
                                    End Try
                                End If
                            Next
                    End Select
                Next
            Next

        End If

    End Sub
    Public Function RetriveObject(ByVal ObjectName As String, ByVal FleName As String) As Boolean

        Dim Cmd As SqlCommand
        Dim barrImg As Byte()
        Dim strfn As String
        Dim fs As FileStream
        Dim Cnn As New SqlConnection(My.Settings.DSN)
        Dim Ans As Boolean
        Try
            Cmd = New SqlCommand("select ObjectContent from TB_Objects where ObjectName = '" & ObjectName & "'", Cnn)
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
                'For ni As Int32 = 0 To barrImg.Length - 1
                '    fs.WriteByte(barrImg(ni))
                'Next
                fs.Write(barrImg, 0, barrImg.Length)
                fs.Flush()
                fs.Close()
                Ans = True
            Else
                Ans = False
            End If
        Catch ex As Exception
            '      MessageBox.Show(ex.Message)
            Ans = False
        Finally
            Cnn.Close()
        End Try

        Return Ans

    End Function
    Public Function GetSummaryFromDatatable(ByVal Type As SummaryType, ByVal TbTemp As DataTable, ByVal FieldToSum As String, ByVal RowFilter As String) As Double

        Dim Dv As DataView
        Dim sSort = FieldToSum
        Dim Ans As Double

        Try

            If Type = SummaryType.Maximum Then
                sSort += " Desc"
            End If

            Dv = New DataView(TbTemp, RowFilter, sSort, DataViewRowState.CurrentRows)
            If Dv.Count > 0 Then
                If Type = SummaryType.Count Then
                    Ans = Dv.Count
                Else
                    If Type = SummaryType.Maximum Or Type = SummaryType.Minimum Then
                        Ans = Dv.Item(0).Item(0)
                    Else
                        For Each d As DataRowView In Dv
                            Ans += NullToValue(d.Item(FieldToSum), 0)
                        Next
                    End If
                    If Type = SummaryType.Sum Then
                        Ans = Ans / Dv.Count
                    End If
                End If
            End If
        Catch ex As Exception

        End Try

        Return Ans

    End Function
    Public Function FixStringLen(ByVal sStr As String, ByVal nLen As Byte, ByVal RemoveLSpace As Boolean) As String

        sStr = RTrim(sStr)
        If RemoveLSpace = True Then
            sStr = LTrim(sStr)
        End If
        Dim SB As StringBuilder = New StringBuilder(sStr, nLen)
        Return SB.ToString

    End Function
    Public Function DynamicallyLoadedObject(ByVal objectName As String, Optional ByVal args() As Object = Nothing) As Form
        Dim returnObj As Object = Nothing
        Dim Type As Type = Assembly.GetExecutingAssembly().GetType("Shipping." & objectName)
        If Type IsNot Nothing Then
            returnObj = Activator.CreateInstance(Type, args)
        End If
        Return returnObj
    End Function
    Private Function RetriveObjectAsByte(ByVal ObjectName As String) As Byte()

        Dim Cmd As SqlCommand
        Dim Cnn As New SqlConnection
        Cnn.ConnectionString = My.Settings.DSN
        Dim barrImg As Byte() = Nothing

        Try
            Cmd = New SqlCommand("select ObjectContent from TB_Objects where ObjectName = '" & ObjectName & "'", Cnn)
            Cnn.Open()
            barrImg = Cmd.ExecuteScalar
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Cnn.Close()
        End Try

        Return barrImg

    End Function
    Function GetReportFooterData() As DataTable

        Dim Tb As New DataTable
        Dim ReturnValue As String = ""
        Dim Dr As DataRow
        Dim BT As Byte

        Tb.Columns.Add(New DataColumn("FooterContent"))
        RetriveObject("Footer", "c:\tmp\Footer")

        Try
            ' Create an instance of StreamReader to read from a file.
            Dim sr As StreamReader = New StreamReader("c:\tmp\Footer")
            Dim line As String
            ' Read and display the lines from the file until the end 
            ' of the file is reached.
            Do
                line = sr.ReadLine()
                ReturnValue &= line
            Loop Until line Is Nothing
            sr.Close()
        Catch E As Exception
            ' Let the user know what went wrong.
            MessageBox.Show("The file could not be read: " & E.Message)
        End Try

        Dr = Tb.NewRow
        Dr("FooterContent") = ReturnValue
        Tb.Rows.Add(Dr)
        Return Tb

    End Function
    Public Function GetTaxPercent(ByVal ChargeCode As String)

        Dim TB As New DataTable
        Dim lResult As Boolean
        Dim Ans As Byte
        Dim sSql = "Select isnull(NextCode,0) as Prc From TB_code Where GroupCode = 'CG' and STDCode = '" & ChargeCode & "'"

        TableBySql(sSql, TB, lResult)
        If lResult = False Then
            Ans = 0
        Else
            If TB.Rows.Count > 0 Then
                Ans = Val(TB.Rows(0).Item("Prc"))
            End If
        End If
        Return Ans

    End Function
    Public Sub GetTaxTollPercentx(ByVal ChargeCode As String, ByVal BaseDate As Date, ByVal Port As String, ByVal ImportExport As String, ByRef tax As Double, ByRef Toll As Double)

        Dim Cmd As New SqlCommand
        Dim Cnn As New SqlConnection(My.Settings.DSN)
        Dim Tb As New DataTable
        Dim DA As SqlDataAdapter

        Cmd = New SqlCommand("SP_GetTaxTollPercent")
        Cnn.Open()

        With Cmd
            .CommandType = CommandType.StoredProcedure
            .Connection = Cnn
            .Parameters.AddWithValue("@BaseDate", BaseDate)
            .Parameters.AddWithValue("@ImportExport", ImportExport)
            .Parameters.AddWithValue("@ChargesCode", ChargeCode)
            .Parameters.AddWithValue("@Port", Port)
        End With
        Cmd.Connection = Cnn
        DA = New SqlDataAdapter
        DA.SelectCommand = Cmd
        DA.Fill(Tb)
        If Tb.Rows.Count > 0 Then
            tax = Tb.Rows(0).Item("Tax")
            Toll = Tb.Rows(0).Item("Toll")
        End If

    End Sub
    Public Function GetImageInStr(ByVal ID As String) As String

        Dim Cmd As SqlCommand
        Dim barrImg As Byte()
        Dim strfn As String
        Dim fs As FileStream
        Dim FleName As String

        Dim Cnn As New SqlConnection(My.Settings.DSN)
        Dim s As String

        Cnn.Open()
        FleName = "c:\tmp\temp.rtf"

        If Not IO.Directory.Exists("c:\tmp") Then
            IO.Directory.CreateDirectory("c:\tmp")
        End If

        If IO.File.Exists(FleName) Then
            IO.File.Delete(FleName)
        End If
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

            Dim oFile As System.IO.File
            Dim oRead As System.IO.StreamReader

            oRead = oFile.OpenText(FleName)
            s = oRead.ReadToEnd
            oRead.Close()
        Catch ex As Exception

        Finally
            Cnn.Close()
        End Try
        Return s
    End Function
    Public Function GenerateJobNumber(ByVal IE As String)

        Dim Result As String = ""
        Dim sYear As String = ""
        Dim aItems() As String
        Dim year As String = Mid(Now.Year.ToString, 3, 2)
        Dim FYear As String = Mid(ToPersianDate(Now), 3, 2)
        Dim ValidSwitch As String = "LINE,IE,FY,LY,SEQ"
        Dim SSql As String
        Dim Tb As New DataTable
        Dim Seq As Long
        Dim lResult As Boolean

        SSql = "SP_GenerateNewSeq 'BL" & IE & "' , '*' "
        TableBySql(SSql, Tb, lResult)

        Seq = Tb.Rows(0).Item("Seq")

        aItems = Split(calculationBase.ReferenceFormula, "+")

        For Each Item As String In aItems

            If InStr(ValidSwitch, Item) = 0 Then
                Result += Item
            Else

                If Item = "LY" Then
                    Result += Mid(Now.Year.ToString, 3, 2)
                End If

                If Item = "FY" Then
                    Result += Mid(ToPersianDate(Now), 3, 2)

                End If

                If Item = "SEQ" Then
                    Result += Format(Seq, "0000")
                End If

                If Item = "LINE" Then
                    Result += CurrentShippingLine
                End If

                If Item = "IE" Then
                    Result += IE
                End If

            End If
        Next

        Return Result

    End Function
    Public Function ShowInvoiceSeq(ByVal Seq As Int32, ByVal IE As String, ByVal DT As Date)

        Dim Result As String = ""
        Dim sYear As String = ""
        Dim aItems() As String

        Dim year As String = Mid(Now.Year.ToString, 3, 2)
        Dim FYear As String = Mid(ToPersianDate(Now), 3, 2)

        Dim ValidSwitch As String = "LINE,IE,FY,LY,SEQ,OFFICE"

        Beep()

        aItems = Split(calculationBase.ReferenceFormula, "+")

        For Each Item As String In aItems

            If InStr(ValidSwitch, Item) = 0 Then
                Result += Item
            Else

                If Item = "LY" Then
                    Result += Mid(Now.Year.ToString, 3, 2)
                End If

                If Item = "FY" Then
                    Result += Mid(ToPersianDate(Now), 3, 2)

                End If

                If Item = "SEQ" Then
                    Result += Format(Seq, "000000")
                End If

                If Item = "LINE" Then
                    Result += CurrentShippingLine
                End If

                If Item = "IE" Then
                    Result += IE
                End If

                If Item = "OFFICE" Then
                    Result += My.Settings.Office
                End If

            End If

        Next

        Return Result

    End Function
    Public Sub TableToArray(ByVal TB As DataTable, ByRef aFields() As String, ByRef aValue() As String)

        Dim Len As Integer
        Dim nI As Integer = 0
        Len = TB.Columns.Count - 1

        ReDim aFields(Len)
        ReDim aValue(Len)

        For Each Col As DataColumn In TB.Columns
            aFields(nI) = UCase(Col.ColumnName)
            aValue(nI) = TB.Rows(0).Item(nI).ToString
            nI += 1
        Next

    End Sub
    Public Function GetFileInByts(ByVal filePath As String) As Byte()

        Dim stream As FileStream = New FileStream( _
           filePath, FileMode.Open, FileAccess.Read)
        Dim reader As BinaryReader = New BinaryReader(stream)

        Dim photo() As Byte = reader.ReadBytes(stream.Length)

        reader.Close()
        stream.Close()

        Return photo
    End Function
    Public Function XmlToTable(ByVal Xml As String) As DataTable

        Dim TB As New DataTable
        Dim ms As New MemoryStream
        Dim strText As String = Xml
        Dim enc As New UTF8Encoding
        Dim arrBytData() As Byte = enc.GetBytes(strText)
        Dim Ds As New DataSet
        TB = New DataTable
        ms.Write(arrBytData, 0, arrBytData.Length)
        ms.Position = 0
        TB.ReadXml(ms)
        ms.Close()
        ms = Nothing
        Return TB

    End Function
    Public Function GenerateRandomFileName(ByVal extension As String) As String
        Dim FileName As String
        FileName = Path.GetRandomFileName()
        FileName = Path.ChangeExtension(FileName, extension)
        FileName = Path.Combine(Path.GetTempPath(), FileName)
        Return FileName

    End Function
    Public Sub ExtractRecipiants(ByVal Dr As DataRow, _
                                  ByVal Clint As TB_Clients, _
                                  ByRef MailTo As String, _
                                  ByRef MailCC As String, _
                                  ByRef MailBCC As String)
        Dim aMailTo() As String
        Dim aMailCC() As String
        Dim aMailBCC() As String
        Dim s As String

        aMailTo = Split(NullToValue(Dr("MailTo"), ""), ";")
        aMailCC = Split(NullToValue(Dr("MailCC"), ""), ";")
        aMailBCC = Split(NullToValue(Dr("MailBCC"), ""), ";")

        For Each s In aMailTo
            If InStr(s, "@") = 0 Then
                Select Case s
                    Case "CLIENT"
                        MailTo &= IIf(MailTo = "", "", ";") & Clint.Email
                    Case "USER"
                        MailTo &= IIf(MailTo = "", "", ";") & CurrentUser.EmailOffice
                End Select
            Else
                MailTo &= IIf(MailTo = "", "", ";") & s
            End If
        Next

        For Each s In aMailCC
            If InStr(s, "@") = 0 Then
                Select Case s
                    Case "CLIENT"
                        MailCC &= IIf(MailCC = "", "", ";") & Clint.Email
                    Case "USER"
                        MailCC &= IIf(MailCC = "", "", ";") & CurrentUser.EmailOffice
                End Select
            Else
                MailCC &= IIf(MailCC = "", "", ";") & s
            End If
        Next

        For Each s In aMailBCC
            If InStr(s, "@") = 0 Then
                Select Case s
                    Case "CLIENT"
                        MailBCC &= IIf(MailBCC = "", "", ";") & Clint.Email
                    Case "USER"
                        MailBCC &= IIf(MailBCC = "", "", ";") & CurrentUser.EmailOffice
                End Select
            Else
                MailBCC &= IIf(MailBCC = "", "", ";") & s
            End If
        Next

    End Sub
    Public Function GenExportBLNo() As Long
        Dim TB As New DataTable
        Dim lResult As Boolean
        TableBySql("SP_GenerateWHLBLNO", TB, lResult)
        Return TB.Rows(0).Item(0)
    End Function
    Public Function RollBackExportBLNo(ByVal Seq As Long) As Boolean

        Dim Cnn As New SqlConnection(My.Settings.DSN)
        Dim Cmd As New SqlCommand("Update TB_Seq Set Seq = @Seq Where Seq = @Seq2 and Seqtype = 'BL'")

        Cnn.Open()

        With Cmd
            .CommandType = CommandType.Text
            .Connection = Cnn
            .Parameters.AddWithValue("@Seq", Seq - 1)
            .Parameters.AddWithValue("@Seq2", Seq)
        End With

        Try
            Cmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try

    End Function
    Public Function RestorObject(ByVal sSql As String, ByVal FileExtention As String, ByRef FleName As String) As Boolean

        Dim Cmd As New SqlCommand
        Dim Cnn As New SqlConnection(My.Settings.DSN)
        Dim barrImg As Byte()
        Dim strfn As String
        Dim fs As FileStream

        FleName = GenerateRandomFileName(FileExtention)
        Cmd = New SqlCommand(sSql, Cnn)

        If Cnn.State = ConnectionState.Closed Then
            Cnn.Open()
        End If

        Try
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
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function
    Public Function RestorXml(ByVal sSql As String, ByRef FleName As String) As Boolean

        Dim TB As New DataTable
        Dim lResult As Boolean
        Dim SR As IO.StreamWriter

        Try
            FleName = GenerateRandomFileName("xml")
            SR = New StreamWriter(FleName)
            TableBySql(sSql, TB, lResult)
            SR.Write(TB.Rows(0).Item(0))
            SR.Flush()
            SR.Close()
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function
    Public Function DTOS(ByVal DateOf As Date) As String

        Dim DD As String
        Dim MM As String
        Dim YY As String

        DateOf = DateOf.Date
        YY = DateOf.Year.ToString
        MM = DateOf.Month.ToString
        DD = DateOf.Day

        If Len(MM) = 1 Then
            MM = "0" & MM
        End If

        If Len(DD) = 1 Then
            DD = "0" & DD
        End If

        Return YY & MM + DD

    End Function
    'Public Function GenerateRandomFileName(ByVal extension As String, _
    '                                      Optional ByVal OnlyFileName As Boolean = False) As String
    '    Dim FileName As String
    '    FileName = Path.GetRandomFileName()
    '    FileName = Path.ChangeExtension(FileName, extension)
    '    If OnlyFileName = False Then
    '        FileName = Path.Combine(Path.GetTempPath(), FileName)
    '    End If
    '    Return FileName
    'End Function
    Function StripControlChars(ByVal source As String, Optional ByVal KeepCRLF As Boolean = True) As String
        'If (String.IsNullOrEmpty(source) = False) Then
        ' we use this to build the result
        Dim sb As New System.Text.StringBuilder(source.Length)

        Dim index As Int32
        For index = 0 To source.Length - 1
            If Not Char.IsControl(source, index) Then
                ' not a control char, so we can add to result
                sb.Append(source.Chars(index))
            ElseIf KeepCRLF AndAlso source.Substring(index, _
              2) = ControlChars.CrLf Then
                ' it is a CRLF, and the user asked to keep it
                sb.Append(source.Chars(index))
            End If
        Next
        Return sb.ToString()
        'End If
    End Function

End Module
