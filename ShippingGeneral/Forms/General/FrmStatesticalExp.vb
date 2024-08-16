Imports System.Data
Imports System.Data.SqlClient
Imports Infragistics.Shared
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinEditors

Public Class FrmStatesticalExp

    Private Sub MenuItem_CustomPickupClick() Handles MenuItem.CustomPickupClick

        Dim sSql As String
        Dim Command As SqlCommand
        Dim connection As New SqlConnection(My.Settings.DSN)
        Dim adapter As New SqlDataAdapter
        Dim Ds As New DataSet
        Dim Txt As String

        sSql = "SP_OutwardStatestical "
        Command = New SqlCommand(sSql, connection)
        Command.CommandText = sSql
        Command.CommandType = CommandType.StoredProcedure
        Command.Parameters.AddWithValue("@ddFrom", Me.dFrom.DTOS)
        Command.Parameters.AddWithValue("@ddTo", Me.dTo.DTOS)
        Command.Parameters.AddWithValue("@Line", CurrentShippingLine)

        adapter = New SqlDataAdapter(Command)
        connection.Open()
        Try
            adapter.Fill(Ds)
            Ds.AcceptChanges()

        Catch ex As Exception
            connection.Close()
            MsgBox(ex.ToString, MsgBoxStyle.Critical)
            Exit Sub
        End Try

        RowToColumnFreeDays(Ds.Tables(0))
        RowToColumnVoyage(Ds.Tables(1))
        RowToColumnPorts(Ds.Tables(2))
        Me.GridClients.DataSource = Ds.Tables(3)
        Me.GridDetails.DataSource = Ds.Tables(4)

        Txt = "List By POL From " & Format(Me.dFrom.DateValue, "Short date") & "  To:" & Format(Me.dTo.DateValue, "Short date")
        ReformatGrid(GridPorts, Txt)

        Txt = "List By Free Days From " & Format(Me.dFrom.DateValue, "Short date") & "  To:" & Format(Me.dTo.DateValue, "Short date")
        ReformatGrid(GridDetention, Txt)

        Txt = "List By Vessel/Voyage From " & Format(Me.dFrom.DateValue, "Short date") & "  To:" & Format(Me.dTo.DateValue, "Short date")
        ReformatGrid(GridVoyage, Txt)

        Txt = "List By Clients From " & Format(Me.dFrom.DateValue, "Short date") & "  To:" & Format(Me.dTo.DateValue, "Short date")
        ReformatGrid(GridClients, Txt)

        Txt = "List By B/L Details From " & Format(Me.dFrom.DateValue, "Short date") & "  To:" & Format(Me.dTo.DateValue, "Short date")
        ReformatGrid(GridClients, Txt)

        GridDetails.DisplayLayout.Bands(0).GroupHeadersVisible = True

    End Sub

    Private Sub DateFrom_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dFrom.Load
        Me.dTo.InitControl(False, False)
        Me.dFrom.InitControl(False, False)
    End Sub
    Private Sub RowToColumnFreeDays(ByVal TB As DataTable)

        Dim Tmp As New DataTable
        Dim aDays As New ArrayList
        Dim aSize As New ArrayList
        Dim aType As New ArrayList
        Dim aFld As New ArrayList
        Dim Dr As DataRow
        Dim sSize As String
        Dim sType As String
        Dim sDay As String
        Dim FldName As String
        Dim FldCaption As String
        Dim NewDr As DataRow
        Dim Col As DataColumn
        Dim Fld As String

        For Each Dr In TB.Rows

            If aDays.IndexOf(NullToValue(Dr("FreeDays"), 0)) = -1 Then
                aDays.Add(NullToValue(Dr("FreeDays"), 0))
            End If

            If aSize.IndexOf(NullToValue(Dr("CnSize"), 0)) = -1 Then
                aSize.Add(NullToValue(Dr("CnSize"), 0))
            End If

            If aType.IndexOf(NullToValue(Dr("CnType"), 0)) = -1 Then
                aType.Add(NullToValue(Dr("CnType"), 0))
            End If

        Next

        aDays.Sort()
        aSize.Sort()
        aType.Sort()

        For Each sDay In aDays
            For Each sSize In aSize
                For Each sType In aType
                    FldName = sDay & sSize & sType
                    FldCaption = "(" & sDay & ") " & sSize & " " & sType
                    Tmp.Columns.Add(New DataColumn(FldName, System.Type.GetType("System.Int32")))
                    Tmp.Columns(FldName).DefaultValue = 0
                    Tmp.Columns(FldName).Caption = FldCaption
                Next
            Next
        Next

        NewDr = Tmp.NewRow

        For Each Dr In TB.Rows
            FldName = NullToValue(Dr("FreeDays"), 0) & Dr("CnSize") & Dr("CnType")
            NewDr(FldName) = Dr("TotalCntrs")
            If Dr("TotalCntrs") = 0 Then
                aFld.Add(FldName)
            End If
        Next
        Tmp.Rows.Add(NewDr)
        Tmp.AcceptChanges()

        Dr = Tmp.Rows(0)
        For Each Col In Tmp.Columns
            If Dr(Col.ColumnName) = 0 Then
                aFld.Add(Col.ColumnName)
            End If
        Next

        For Each Fld In aFld
            Tmp.Columns.Remove(Fld)
        Next

        Me.GridDetention.DataSource = Tmp

    End Sub

    Private Sub RowToColumnVoyage(ByVal TB As DataTable)

        Dim Tmp As New DataTable
        Dim aFE As New ArrayList
        Dim aSize As New ArrayList
        Dim aType As New ArrayList
        Dim aFld As New ArrayList
        Dim Dr As DataRow
        Dim sSize As String
        Dim sType As String
        Dim sFE As String
        Dim FldName As String
        Dim FldCaption As String
        Dim NewDr As DataRow
        Dim Col As DataColumn
        Dim Fld As String
        Dim Drs() As DataRow
        Dim sSql As String

        For Each Dr In TB.Rows
            If aFE.IndexOf(NullToValue(Dr("FE"), 0)) = -1 Then
                aFE.Add(NullToValue(Dr("FE"), 0))
            End If
            If aSize.IndexOf(NullToValue(Dr("CnSize"), 0)) = -1 Then
                aSize.Add(NullToValue(Dr("CnSize"), 0))
            End If
            If aType.IndexOf(NullToValue(Dr("CnType"), 0)) = -1 Then
                aType.Add(NullToValue(Dr("CnType"), 0))
            End If
        Next

        aFE.Sort()
        aSize.Sort()
        aType.Sort()

        Tmp.Columns.Add(New DataColumn("Vessel"))
        Tmp.Columns.Add(New DataColumn("VoyageNo"))
        Tmp.Columns.Add(New DataColumn("Sailed", System.Type.GetType("System.DateTime")))
        Tmp.Columns.Add(New DataColumn("BLS", System.Type.GetType("System.Int32")))
        Tmp.Columns.Add(New DataColumn("POL"))

        For Each sFE In aFE
            For Each sSize In aSize
                For Each sType In aType
                    FldName = sFE & sSize & sType
                    FldCaption = "(" & sFE & ") " & sSize & " " & sType
                    Tmp.Columns.Add(New DataColumn(FldName, System.Type.GetType("System.Int32")))
                    '               Tmp.Columns(FldName).DefaultValue = 0
                    Tmp.Columns(FldName).Caption = FldCaption
                Next
            Next
        Next

        For Each Dr In TB.Rows
            Drs = Tmp.Select("Vessel = '" & Dr("Vessel") & "' and VoyageNo = '" & Dr("VoyageNo") & "'")
            If Drs.Length = 0 Then
                NewDr = Tmp.NewRow
                NewDr("Vessel") = Dr("Vessel")
                NewDr("VoyageNo") = Dr("VoyageNo")
                NewDr("Sailed") = Dr("Sailed")
                NewDr("Bls") = Dr("Total Bls")
                NewDr("POL") = Dr("POL")
                Tmp.Rows.Add(NewDr)
                Drs = Tmp.Select("Vessel = '" & Dr("Vessel") & "' and VoyageNo = '" & Dr("VoyageNo") & "'")
                NewDr = Drs(0)
            Else
                NewDr = Drs(0)
            End If
            FldName = Dr("FE") & Dr("CnSize") & Dr("CnType")
            NewDr(FldName) = Dr("TotalCntrs")

        Next

        Tmp.AcceptChanges()

        If Tmp.Rows.Count > 0 Then
            Dr = Tmp.Rows(0)

            For Each Col In Tmp.Columns
                Fld = Col.ColumnName
                Try
                    sSql = Fld & " > 0"
                    Drs = Tmp.Select(Fld)
                    If Drs.Length = 0 Then
                        aFld.Add(Fld)
                    End If
                Catch ex As Exception
                End Try
            Next

            For Each Fld In aFld
                Tmp.Columns.Remove(Fld)
            Next
        End If
        Me.GridVoyage.DataSource = Tmp


    End Sub


    Private Sub RowToColumnPorts(ByVal TB As DataTable)

        Dim Tmp As New DataTable
        Dim aFE As New ArrayList
        Dim aSize As New ArrayList
        Dim aType As New ArrayList
        Dim aFld As New ArrayList
        Dim Dr As DataRow
        Dim sSize As String
        Dim sType As String
        Dim sFE As String
        Dim FldName As String
        Dim FldCaption As String
        Dim NewDr As DataRow
        Dim Col As DataColumn
        Dim Fld As String
        Dim Drs() As DataRow
        Dim sSql As String

        For Each Dr In TB.Rows
            If aFE.IndexOf(NullToValue(Dr("FE"), 0)) = -1 Then
                aFE.Add(NullToValue(Dr("FE"), 0))
            End If
            If aSize.IndexOf(NullToValue(Dr("CnSize"), 0)) = -1 Then
                aSize.Add(NullToValue(Dr("CnSize"), 0))
            End If
            If aType.IndexOf(NullToValue(Dr("CnType"), 0)) = -1 Then
                aType.Add(NullToValue(Dr("CnType"), 0))
            End If
        Next

        aFE.Sort()
        aSize.Sort()
        aType.Sort()

        Tmp.Columns.Add(New DataColumn("POL"))

        For Each sFE In aFE
            For Each sSize In aSize
                For Each sType In aType
                    FldName = sFE & sSize & sType
                    FldCaption = "(" & sFE & ") " & sSize & " " & sType
                    Tmp.Columns.Add(New DataColumn(FldName, System.Type.GetType("System.Int32")))
                    '               Tmp.Columns(FldName).DefaultValue = 0
                    Tmp.Columns(FldName).Caption = FldCaption
                Next
            Next
        Next

        Tmp.Columns.Add(New DataColumn("TotalTeu", System.Type.GetType("System.Int32")))

        For Each Dr In TB.Rows
            Drs = Tmp.Select("POL = '" & Dr("POL") & "'")
            If Drs.Length = 0 Then
                NewDr = Tmp.NewRow
                NewDr("POL") = Dr("POL")
                Tmp.Rows.Add(NewDr)
                Drs = Tmp.Select("POL = '" & Dr("POL") & "'")
                NewDr = Drs(0)
            Else
                NewDr = Drs(0)
            End If
            FldName = Dr("FE") & Dr("CnSize") & Dr("CnType")
            NewDr(FldName) = Dr("TotalCntrs")
            If Dr("CnSize") = "20" Then
                NewDr("Totalteu") = NullToValue(NewDr("Totalteu"), 0) + Dr("TotalCntrs")
            Else
                NewDr("Totalteu") = NullToValue(NewDr("Totalteu"), 0) + (Dr("TotalCntrs") * 2)
            End If

        Next

        Tmp.AcceptChanges()
        If Tmp.Rows.Count > 0 Then
            Dr = Tmp.Rows(0)

            For Each Col In Tmp.Columns
                Fld = Col.ColumnName
                Try
                    sSql = Fld & " > 0"
                    Drs = Tmp.Select(Fld)
                    If Drs.Length = 0 Then
                        aFld.Add(Fld)
                    End If
                Catch ex As Exception
                End Try
            Next

            For Each Fld In aFld
                Tmp.Columns.Remove(Fld)
            Next
        End If
        Me.GridPorts.DataSource = Tmp


    End Sub

    Private Sub MenuItem_CustomToExcelClick() Handles MenuItem.CustomToExcelClick

        Dim Grid As UltraGrid

        Try

            If Me.GridPorts.Rows.Count > 0 Then
                Select Case Me.TabControl.SelectedTab.Key
                    Case "Ports"
                        Grid = GridPorts
                    Case "Detention"
                        Grid = GridDetention
                    Case "Voyage"
                        Grid = GridVoyage
                    Case "Clients"
                        Grid = GridClients
                    Case "B/L Details"
                        Grid = GridDetails
                End Select
                SaveGridToExcel(Grid)
            End If

        Catch ex As Exception

        End Try


    End Sub

    Private Sub ReformatGrid(ByVal Grid, ByVal Title)

        With Grid.DisplayLayout.Bands(0)
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


    End Sub


 
    Private Sub MenuItem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem.Load

    End Sub
End Class