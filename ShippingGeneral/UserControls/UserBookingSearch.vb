Imports System.Data.SqlClient

Public Class UserBookingSearch
    Private BookingControl As UserBookingNo
    Private Sub ButtonSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSearch.Click

        If Me.TextClient.TextValue = "" And Me.TextBooking.TextValue = "" Then
            MsgBox("No Any Selection !")
        Else
            InitData()
        End If

    End Sub

    Private Sub InitData()

        Dim sSql As String
        Dim Where As String = ""
        Dim TB As New DataTable
        Dim lResult As Boolean

        sSql = "SELECT  TB_Clients.lName AS [Client Name], " & _
               " TB_Booking.BookingNo, " & _
               " TB_Booking.POD, " & _
               " TB_Booking.ID AS BookingID " & _
               " FROM    TB_Clients INNER JOIN " & _
               "         TB_Booking ON TB_Clients.ID = TB_Booking.ClientID " & _
               " Where   "

        Me.TextBooking.TextValue = Replace(Me.TextBooking.TextValue, "%", " ")
        Me.TextBooking.TextValue = Replace(Me.TextBooking.TextValue, "'", " ")

        Me.TextClient.TextValue = Replace(Me.TextClient.TextValue, "%", " ")
        Me.TextClient.TextValue = Replace(Me.TextClient.TextValue, "'", " ")

        If Trim(Me.TextClient.TextValue) <> "" Then
            Where = " lName Like '%" & Me.TextClient.TextValue & "%'"
        End If

        If Trim(Me.TextBooking.TextValue) <> "" Then
            If Where <> "" Then
                Where &= " and "
            End If
            Where &= " BookingNo Like '%" & Me.TextBooking.TextValue & "%'"
        End If
        sSql &= Where
        TableBySql(sSql, TB, lResult)

        Me.GridData.DataSource = TB
        GridNumSeperator(Me.GridData)

    End Sub

    Public Sub InitControl(ByVal Ctrl As UserBookingNo)

        Me.BookingControl = Ctrl

    End Sub

    Private Sub ButtonSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSelect.Click

        If Me.GridData.Rows.Count > 0 Then
            BookingControl.BookingID = GridData.ActiveRow.Cells("BookingID").Value
        End If

    End Sub

End Class
