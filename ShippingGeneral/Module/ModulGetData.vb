Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports System.Text
Imports Microsoft.SqlServer
Imports Microsoft.SqlServer.Server

Module ModulGetData

    Public Sub DetentionListByEADate(ByVal Line As String, _
                                     ByVal dFrom As DateTime, _
                                     ByVal dTo As DateTime, _
                                     ByRef ResultTable As DataTable, _
                                     ByRef Ans As Boolean)

        Dim Table As New DataTable
        Dim adapter As New SqlDataAdapter
        Dim Command As SqlCommand
        Dim dr As DataRow
        Dim sSql As String
        Dim DPC As New ClDetentionPerCntr
        Dim Temp As DataTable
        Dim connection As New SqlConnection(My.Settings.DSN)
        Dim Rows As Long

        sSql = "SP_DetentionListByEA "
        Command = New SqlCommand(sSql, connection)
        Command.CommandText = "SP_DetentionListByEA"
        Command.CommandType = CommandType.StoredProcedure
        Command.Parameters.AddWithValue("@ImportExport", "I")
        Command.Parameters.AddWithValue("@dFrom", dFrom.Date)
        Command.Parameters.AddWithValue("@dTo", dTo.Date)
        Command.Parameters.AddWithValue("@Line", CurrentShippingLine)

        adapter = New SqlDataAdapter(Command)
        connection.Open()
        Try
            Rows = adapter.Fill(Table)
        Catch ex As Exception
            Ans = False
            connection.Close()
            Exit Sub
        End Try

        Command = New SqlCommand(sSql, connection)
        Command.Parameters.Add("@ImportExport", SqlDbType.VarChar, 1)
        Command.Parameters.Add("@Line", SqlDbType.VarChar, 3)
        Command.Parameters.Add("@CnSize", SqlDbType.VarChar, 2)
        Command.Parameters.Add("@CnType", SqlDbType.VarChar, 2)
        Command.Parameters.Add("@dFrom", SqlDbType.SmallDateTime)
        Command.Parameters.Add("@dTo", SqlDbType.SmallDateTime)
        Command.Parameters.Add("@BLID", SqlDbType.Char, 36)
        adapter = New SqlDataAdapter(Command)
        Command.Connection = connection

        For Each dr In Table.Rows

            If IsDBNull(dr("DF")) Then
                dr("DF") = DateAdd(DateInterval.Day, -300, Now())
                dr.RowError = "DF Date Not valid !"
            End If

            Temp = DPC.DetentionPerCntr("I", dr("CnSize"), dr("Cntype"), dr("DF"), dr("EA"), NullToValue(dr("BLID"), Guid.NewGuid.ToString), Int16.Parse(dr("LcLCount").ToString), 0)
            If Temp.Rows.Count > 0 Then
                With Temp.Rows(0)
                    dr("FreeDays") = .Item("FreeDays")
                    dr("Days") = .Item("TotalDays")
                    dr("ChgDays") = .Item("TotalDays") - .Item("FreeDays")
                    dr("Detention") = .Item("Detention")
                    dr("Discount") = .Item("Discount")
                    dr("Balance") = .Item("DetentionNet")
                    If dr("ChgDays") < 1 Then
                        dr("ChgDays") = 0
                    End If
                    If .Item("Message") <> "" Then
                        dr.RowError = dr.RowError & " " & .Item("Message")
                    End If
                End With
            End If

        Next
        Table.AcceptChanges()
        ResultTable = Table.Copy
        Ans = True
        connection.Close()

    End Sub

    Public Sub DetentionListByConfirmDate(ByVal ImportExport As InOut, _
                                        ByVal Line As String, _
                                        ByVal dFrom As DateTime, _
                                        ByVal dTo As DateTime, _
                                        ByRef ResultTable As DataTable, _
                                        ByRef Ans As Boolean)

        Dim Table As New DataTable
        Dim adapter As New SqlDataAdapter
        Dim Command As SqlCommand
        Dim dr As DataRow
        Dim sSql As String
        Dim DPC As New ClDetentionPerCntr
        Dim Temp As DataTable
        Dim connection As New SqlConnection(My.Settings.DSN)
        Dim Rows As Long
        Dim Drs() As DataRow
        Dim StorBL As String
        Dim TB As DataTable
        Dim lResult As Boolean
        Dim nTotal As Double
        Dim iDrs() As DataRow
        Dim iDr As DataRow

        dFrom = dFrom.Date
        dTo = dTo.Date
        dTo = DateAdd(DateInterval.Hour, 23, dTo)
        dTo = DateAdd(DateInterval.Minute, 58, dTo)


        sSql = "SP_DetentionListConfirmDate "
        Command = New SqlCommand(sSql, connection)
        Command.CommandText = sSql
        Command.CommandType = CommandType.StoredProcedure
        Command.Parameters.AddWithValue("@ImportExport", IIf(ImportExport = InOut.InWard, "I", "E"))
        Command.Parameters.AddWithValue("@dFrom", dFrom)
        Command.Parameters.AddWithValue("@dTo", dTo)
        Command.Parameters.AddWithValue("@Line", CurrentShippingLine)

        adapter = New SqlDataAdapter(Command)
        connection.Open()
        Try
            Rows = adapter.Fill(Table)
        Catch ex As Exception
            Ans = False
            connection.Close()
            Exit Sub
        End Try

        Command = New SqlCommand(sSql, connection)
        Command.Parameters.Add("@ImportExport", SqlDbType.VarChar, 1)
        Command.Parameters.Add("@Line", SqlDbType.VarChar, 3)
        Command.Parameters.Add("@CnSize", SqlDbType.VarChar, 2)
        Command.Parameters.Add("@CnType", SqlDbType.VarChar, 2)
        Command.Parameters.Add("@dFrom", SqlDbType.SmallDateTime)
        Command.Parameters.Add("@dTo", SqlDbType.SmallDateTime)
        Command.Parameters.Add("@BLID", SqlDbType.Char, 36)
        adapter = New SqlDataAdapter(Command)
        Command.Connection = connection


        Table.Columns.Add("PaidInBBI", System.Type.GetType("System.Double"))
        Table.Columns.Add("PaidInShipping", System.Type.GetType("System.Double"))
        For Each dr In Table.Rows

            If IsDBNull(dr("DF")) Or IsDBNull(dr("EA")) Then
                dr.RowError = "Please Check DF Date & MA Date"
            Else
                Temp = DPC.DetentionPerCntr(IIf(ImportExport = InOut.InWard, "I", "E"), dr("CnSize"), dr("Cntype"), dr("DF"), dr("EA"), dr("BLID").ToString, Int16.Parse(dr("LclCount").ToString), dr("WGTPercent"))
                If Temp.Rows.Count > 0 Then
                    With Temp.Rows(0)
                        dr("FreeDays") = .Item("FreeDays")
                        dr("Days") = .Item("TotalDays")
                        dr("ChgDays") = .Item("TotalDays") - .Item("FreeDays")
                        dr("Detention") = .Item("Detention")
                        dr("Discount") = .Item("Discount")
                        dr("Balance") = .Item("DetentionNet")
                        If dr("ChgDays") < 1 Then
                            dr("ChgDays") = 0
                        End If
                        If .Item("Message") <> "" Then
                            dr.RowError = .Item("Message")
                        End If
                     
                    End With
                End If

            End If
 
        Next

        Drs = Table.Select("", "BlNo , CntrNo")
        StorBL = ""
    
        For Each dr In Table.Rows
            If StorBL <> dr("BlNo") Then
                StorBL = dr("BLNO")
                sSql = "select dbo.FC_InwardTotalChargByBIChgCurrency('" & dr("BLID").ToString & "' , 'DETN' , 'IRR') Paid , " & _
                "dbo.FC_InwardTotalChargByBIChgCurrency('" & dr("BLID").ToString & "' , 'DETN-A' , 'IRR') FirstPaid"
                TableBySql(sSql, TB, lResult)
                If TB.Rows.Count > 0 Then
                    dr("PaidInShipping") = NullToValue(TB.Rows(0).Item("Paid"), 0) + NullToValue(TB.Rows(0).Item("FirstPaid"), 0)
                End If
            End If
        Next

        Drs = Table.Select("PaidInShipping > 0", "BlNo")
        For Each dr In Drs
            nTotal = 0
            iDrs = Table.Select("BLNO = '" & dr("BLNO") & "'")
            For Each iDr In iDrs
                nTotal += NullToValue(iDr("Detention"), 0)
            Next
            If nTotal <> NullToValue(dr("PaidInShipping"), 0) Then
                dr.RowError = "Check Balance"
            End If
        Next



        Table.AcceptChanges()
        ResultTable = Table.Copy
        Ans = True
        connection.Close()

    End Sub

    'For Export Detention Report
    Public Sub DetentionListByConfirmDateExport(ByVal ImportExport As InOut, _
                                        ByVal Line As String, _
                                        ByVal dFrom As DateTime, _
                                        ByVal dTo As DateTime, _
                                        ByRef ResultTable As DataTable, _
                                        ByRef Ans As Boolean)

        Dim Table As New DataTable
        Dim adapter As New SqlDataAdapter
        Dim Command As SqlCommand
        Dim dr As DataRow
        Dim sSql As String
        Dim DPC As New ClDetentionPerCntr
        Dim Temp As DataTable
        Dim connection As New SqlConnection(My.Settings.DSN)
        Dim Rows As Long
        Dim Drs() As DataRow
        Dim StorBL As String
        Dim TB As DataTable
        Dim lResult As Boolean
        Dim nTotal As Double
        Dim iDrs() As DataRow
        Dim iDr As DataRow

        dFrom = dFrom.Date
        dTo = dTo.Date
        dTo = DateAdd(DateInterval.Hour, 23, dTo)
        dTo = DateAdd(DateInterval.Minute, 58, dTo)


        sSql = "SP_DetentionListConfirmDateExport"
        Command = New SqlCommand(sSql, connection)
        Command.CommandText = sSql
        Command.CommandType = CommandType.StoredProcedure
        Command.Parameters.AddWithValue("@ImportExport", IIf(ImportExport = InOut.InWard, "I", "E"))
        Command.Parameters.AddWithValue("@dFrom", dFrom)
        Command.Parameters.AddWithValue("@dTo", dTo)
        Command.Parameters.AddWithValue("@Line", CurrentShippingLine)

        adapter = New SqlDataAdapter(Command)
        connection.Open()
        Try
            Rows = adapter.Fill(Table)
        Catch ex As Exception
            Ans = False
            connection.Close()
            Exit Sub
        End Try

        Command = New SqlCommand(sSql, connection)
        Command.Parameters.Add("@ImportExport", SqlDbType.VarChar, 1)
        Command.Parameters.Add("@Line", SqlDbType.VarChar, 3)
        Command.Parameters.Add("@CnSize", SqlDbType.VarChar, 2)
        Command.Parameters.Add("@CnType", SqlDbType.VarChar, 2)
        Command.Parameters.Add("@dFrom", SqlDbType.SmallDateTime)
        Command.Parameters.Add("@dTo", SqlDbType.SmallDateTime)
        Command.Parameters.Add("@BLID", SqlDbType.Char, 36)
        adapter = New SqlDataAdapter(Command)
        Command.Connection = connection


        Table.Columns.Add("PaidInBBI", System.Type.GetType("System.Double"))
        Table.Columns.Add("PaidInShipping", System.Type.GetType("System.Double"))
        For Each dr In Table.Rows

            If IsDBNull(dr("DF")) Or IsDBNull(dr("EA")) Then
                dr.RowError = "Please Check DF Date & MA Date"
            Else
                ' Changed from DPC.DetentionPerCntr - DetentionPerCntrExport
                Temp = DPC.DetentionPerCntrExport(IIf(ImportExport = InOut.InWard, "I", "E"), dr("CnSize"), dr("Cntype"), dr("DF"), dr("EA"), dr("BLID").ToString, Int16.Parse(dr("LclCount").ToString), dr("WGTPercent"))
                If Temp.Rows.Count > 0 Then
                    With Temp.Rows(0)
                        dr("FreeDays") = .Item("FreeDays")
                        dr("Days") = .Item("TotalDays")
                        dr("ChgDays") = .Item("TotalDays") - .Item("FreeDays")
                        dr("Detention") = .Item("Detention")
                        dr("Discount") = .Item("Discount")
                        dr("Balance") = .Item("DetentionNet")
                        If dr("ChgDays") < 1 Then
                            dr("ChgDays") = 0
                        End If
                        If .Item("Message") <> "" Then
                            dr.RowError = .Item("Message")
                        End If

                    End With
                End If

            End If

        Next

        Drs = Table.Select("", "BlNo , CntrNo")
        StorBL = ""

        For Each dr In Table.Rows
            If StorBL <> dr("BlNo") Then
                StorBL = dr("BLNO")
                sSql = "select dbo.FC_InwardTotalChargByBIChgCurrency('" & dr("BLID").ToString & "' , 'DETN' , 'IRR') Paid , " & _
                "dbo.FC_InwardTotalChargByBIChgCurrency('" & dr("BLID").ToString & "' , 'DETN-A' , 'IRR') FirstPaid"
                TableBySql(sSql, TB, lResult)
                If TB.Rows.Count > 0 Then
                    dr("PaidInShipping") = NullToValue(TB.Rows(0).Item("Paid"), 0) + NullToValue(TB.Rows(0).Item("FirstPaid"), 0)
                End If
            End If
        Next

        Drs = Table.Select("PaidInShipping > 0", "BlNo")
        For Each dr In Drs
            nTotal = 0
            iDrs = Table.Select("BLNO = '" & dr("BLNO") & "'")
            For Each iDr In iDrs
                nTotal += NullToValue(iDr("Detention"), 0)
            Next
            If nTotal <> NullToValue(dr("PaidInShipping"), 0) Then
                dr.RowError = "Check Balance"
            End If
        Next



        Table.AcceptChanges()
        ResultTable = Table.Copy
        Ans = True
        connection.Close()

    End Sub
    Public Sub GenerateDs(ByRef Ds As DataSet, ByVal Cmd As SqlCommand, ByRef Ans As Boolean)

        Dim Cnn As New SqlConnection(My.Settings.DSN)
        Dim Adp As New SqlDataAdapter
        Ds = New DataSet
        Try
            Cnn.Open()
            Cmd.Connection = Cnn
            Adp = New SqlDataAdapter(Cmd)
            Adp.Fill(Ds)
            Ans = True
        Catch ex As Exception
            Ans = False
        End Try
        Cnn.Close()

    End Sub
    Public Function GetMeaningCode(ByVal GroupCode As String, ByVal Code As String) As String

        Dim adapter As New SqlDataAdapter
        Dim connection As New SqlConnection(My.Settings.DSN)
        Dim sSql As String = "Select dbo.FC_GetMeaningWithGroupStdCode ('" & GroupCode & "' , '" & Code & "')"
        Dim Command As SqlCommand
        Dim Table As New DataTable
        Dim rows As Long
        Dim Ans As String = "Not Found !"


        Command = New SqlCommand(sSql, connection)
        Command.CommandType = CommandType.Text
        adapter = New SqlDataAdapter(Command)
        connection.Open()
        Try
            rows = adapter.Fill(Table)
            If rows > 0 Then
                Ans = NullToValue(Table.Rows(0).Item(0), "")
            End If
        Catch ex As Exception
        End Try
        connection.Close()
        Return Ans

    End Function

    Public Function GetMeaningFCode(ByVal GroupCode As String, ByVal Code As String) As String

        Dim adapter As New SqlDataAdapter
        Dim connection As New SqlConnection(My.Settings.DSN)
        Dim sSql As String = "Select dbo.FC_GetMeaningFWithGroupStdCode ('" & GroupCode & "' , '" & Code & "')"
        Dim Command As SqlCommand
        Dim Table As New DataTable
        Dim rows As Long
        Dim Ans As String = "Not Found !"


        Command = New SqlCommand(sSql, connection)
        Command.CommandType = CommandType.Text
        adapter = New SqlDataAdapter(Command)
        connection.Open()
        Try
            rows = adapter.Fill(Table)
            If rows > 0 Then
                Ans = NullToValue(Table.Rows(0).Item(0), "")
            End If
        Catch ex As Exception
        End Try
        connection.Close()
        Return Ans

    End Function

    Public Function GetPortNameByCode(ByVal PortCode As String) As String

        Dim Table As New DataTable
        Dim adapter As New SqlDataAdapter
        Dim Command As SqlCommand
        Dim sSql As String
        Dim connection As New SqlConnection(My.Settings.DSN)
        Dim Ans As String

        sSql = "Select * From Tb_Ports Where PortCode = '" & PortCode & "'"
        Command = New SqlCommand(sSql, connection)
        Command.CommandText = sSql
        Command.CommandType = CommandType.Text
        adapter = New SqlDataAdapter(Command)
        connection.Open()
        Try
            adapter.Fill(Table)
            Ans = NullToValue(Table.Rows(0).Item("PortName"), "")
        Catch ex As Exception
            Ans = ""
        End Try
        connection.Close()
        Return Ans


    End Function

    Public Function GetInwardTotalPKGS(ByVal BLID As Guid) As String

        Dim sSql As String = "SELECT SUM(NoOFPkgs) AS Total, dbo.FC_GetMeaningWithGroupStdCode('PG', PackageType) AS PKGS  , PackageType " & _
                              "FROM dbo.TB_InwardCntrs " & _
                              "WHERE     (BLID = '" & BLID.ToString.ToString & "') " & _
                              "GROUP BY PackageType"


        Dim Table As New DataTable
        Dim adapter As New SqlDataAdapter
        Dim Command As SqlCommand
        Dim dr As DataRow
        Dim connection As New SqlConnection(My.Settings.DSN)
        Dim Ans As String = ""

        Command = New SqlCommand(sSql, connection)
        Command.CommandText = sSql
        Command.CommandType = CommandType.Text
        adapter = New SqlDataAdapter(Command)
        connection.Open()
        Try
            adapter.Fill(Table)
            For Each dr In Table.Rows
                Ans += dr("Total") & "X" & NullToValue(dr("PKGS"), dr("PackageType")) & vbCrLf
            Next
        Catch ex As Exception
            Ans = ""
        Finally
            connection.Close()
        End Try

        Return Ans


    End Function

    Public Function GetOutwardTotalPKGS(ByVal BLID As Guid) As String

        Dim sSql As String = "SELECT SUM(NoOFPkgs) AS Total, dbo.FC_GetMeaningWithGroupStdCode('PG', PackageType) AS PKGS  , PackageType " & _
                              "FROM dbo.TB_OutwardCntrs " & _
                              "WHERE     (BLID = '" & BLID.ToString.ToString & "') " & _
                              "GROUP BY PackageType"


        Dim Table As New DataTable
        Dim adapter As New SqlDataAdapter
        Dim Command As SqlCommand
        Dim dr As DataRow
        Dim Temp As DataTable
        Dim connection As New SqlConnection(My.Settings.DSN)
        Dim Ans As String = ""

        Command = New SqlCommand(sSql, connection)
        Command.CommandText = sSql
        Command.CommandType = CommandType.Text
        adapter = New SqlDataAdapter(Command)
        connection.Open()
        Try
            adapter.Fill(Table)
            For Each dr In Table.Rows
                Ans += dr("Total") & "X" & NullToValue(dr("PKGS"), dr("PackageType")) & vbCrLf
            Next
        Catch ex As Exception
            Ans = ""
        Finally
            connection.Close()
        End Try

        Return Ans


    End Function

    Public Function GetInwardTotalCntrs(ByVal BLID As Guid) As String

        Dim sSql As String = "Select dbo.FC_TotalInwardCntrsByBLID ('" & BLID.ToString & "')"

        Dim Table As New DataTable
        Dim adapter As New SqlDataAdapter
        Dim Command As SqlCommand
        Dim dr As DataRow
        Dim connection As New SqlConnection(My.Settings.DSN)
        Dim Ans As String = ""

        Command = New SqlCommand(sSql, connection)
        Command.CommandText = sSql
        Command.CommandType = CommandType.Text
        adapter = New SqlDataAdapter(Command)
        connection.Open()

        Try
            adapter.Fill(Table)
            For Each dr In Table.Rows
                Ans = dr(0)
            Next
        Catch ex As Exception
            Ans = ""
        Finally
            connection.Close()
        End Try

        Ans = Replace(Ans, vbCr, vbCrLf)
        Return Ans

    End Function


    Public Function GetOutwardTotalCntrs(ByVal BLID As Guid) As String

        Dim sSql As String = "Select dbo.FC_TotalOutwardCntrsByBLID ('" & BLID.ToString & "')"

        Dim Table As New DataTable
        Dim adapter As New SqlDataAdapter
        Dim Command As SqlCommand
        Dim dr As DataRow
        Dim connection As New SqlConnection(My.Settings.DSN)
        Dim Ans As String = ""

        Command = New SqlCommand(sSql, connection)
        Command.CommandText = sSql
        Command.CommandType = CommandType.Text
        adapter = New SqlDataAdapter(Command)
        connection.Open()

        Try
            adapter.Fill(Table)
            For Each dr In Table.Rows
                Ans = dr(0)
            Next
        Catch ex As Exception
            Ans = ""
        Finally
            connection.Close()
        End Try

        Ans = Replace(Ans, vbCr, vbCrLf)
        Return Ans

    End Function

End Module
