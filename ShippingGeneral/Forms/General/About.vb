'Imports System.Data.Odbc
'Imports Npgsql

Public Class About

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub About_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim connString As String = "Host=192.168.1.100:5432;Username=postgres;Password=paragon;Database=MBK_Live"
        'Dim connString As String = "Server=192.168.1.100;Port=5432;Database=MBK_Live;User Id=postgres;Password=paragon;"

        'Dim conn As NpgsqlConnection = New NpgsqlConnection(connString)

        'Dim sql As String = "SELECT * FROM general_ledger limit 10"
        'Dim cmd As NpgsqlCommand = New NpgsqlCommand(sql, conn)

        'conn.Open()

        'Dim reader As NpgsqlDataReader = cmd.ExecuteReader()

        '' Process the data
        'While reader.Read()
        '    ' Process each row of data here
        'End While

        '' Close the reader when done
        'reader.Close()
        'conn.Close()
    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub
End Class