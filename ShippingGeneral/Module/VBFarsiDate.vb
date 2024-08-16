Imports System.Globalization

Module VBFarsiDate

    Function ChangeToMiladi(ByVal DateParam)
        Dim M As Byte
        Dim D As Byte
        Dim Y As Long

        DateParam = Trim(DateParam)
        Y = CInt(Left(DateParam, InStr(DateParam, "/") - 1))
        M = CInt(Mid(DateParam, InStr(DateParam, "/") + 1, InStrRev(DateParam, "/") - InStr(DateParam, "/") - 1))
        D = CInt(Mid(DateParam, InStrRev(DateParam, "/") + 1))
        If Y < 1300 Then Y = Y + 1300
        Miladi(Y, M, D)
        Return CStr(DateSerial(Y, M, D))
    End Function

    Sub Miladi(ByVal Y As Long, ByVal M As Byte, ByVal D As Byte)
        '******************* Leap year
        If Y = 1378 Then
            If M = 12 And D = 10 Then
                Y = 2000 : M = 2 : D = 29 : Exit Sub
            End If
            If M = 12 And D > 10 Then
                D = D - 1
            End If
        ElseIf Y = 1379 Then
            D = D - 1
            If D = 0 Then
                M = M - 1
                If M > 0 And M < 7 Then D = 31
                If M > 6 Then D = 30
                If M = 0 Then
                    D = 29
                    M = 12
                    Y = Y - 1
                End If
            End If
        End If
        '*******************
        If M < 10 Or (M = 10 And D < 11) Then
            Y = Y + 621
        Else
            Y = Y + 622
        End If
        Select Case M
            Case 1
                If D < 12 Then
                    M = 3 : D = D + 20
                Else
                    M = 4 : D = D - 11
                End If
            Case 2
                If D < 11 Then
                    M = 4 : D = D + 20
                Else
                    M = 5 : D = D - 10
                End If
            Case 3
                If D < 11 Then
                    M = 5 : D = D + 21
                Else
                    M = 6 : D = D - 10
                End If
            Case 4
                If D < 10 Then
                    M = 6 : D = D + 21
                Else
                    M = 7 : D = D - 9
                End If
            Case 5, 6, 8
                If D < 10 Then
                    M = M + 2 : D = D + 22
                Else
                    M = M + 3 : D = D - 9
                End If
            Case 7
                If D < 9 Then
                    M = 9 : D = D + 22
                Else
                    M = 10 : D = D - 8
                End If
            Case 9
                If D < 10 Then
                    M = 11 : D = D + 21
                Else
                    M = 12 : D = D - 9
                End If
            Case 10
                If D < 11 Then
                    M = 12 : D = D + 21
                Else
                    M = 1 : D = D - 10
                End If
            Case 11
                If D < 12 Then
                    M = 1 : D = D + 20
                Else
                    M = 2 : D = D - 11
                End If
            Case 12
                If D < 10 Then
                    M = 2 : D = D + 19
                Else
                    M = 3 : D = D - 9
                End If
        End Select
    End Sub

    Function ChangeToShamsi(ByVal DateParam As String)
        Dim M As Byte
        Dim D As Byte
        Dim Y As Long
        D = CInt(Left(DateParam, InStr(DateParam, "/") - 1))
        M = CInt(Mid(DateParam, InStr(DateParam, "/") + 1, InStrRev(DateParam, "/") - InStr(DateParam, "/") - 1))
        Y = CInt(Mid(DateParam, InStrRev(DateParam, "/") + 1))
        If Y = 0 Then Y = 2000
        If Y < 1000 Then Y = Y + 1900
        Shamsi(Y, M, D)
        Return Trim(Y) & "/" & IIf(Len(Trim(M)) = 1, "0", "") & Trim(M) & "/" & IIf(Len(Trim(D)) = 1, "0", "") & Trim(D)
    End Function

    Sub Shamsi(ByRef Y As Long, ByRef M As Byte, ByRef D As Byte)
        '******************* Leap year
        Dim Temp As Date
        If Y = 2000 Or Y = 2004 Or Y = 2008 Or Y = 2012 Or Y = 2016 Then
            If M > 2 Then
                Temp = DateSerial(Y, M, D)
                Temp = DateAdd(DateInterval.Day, 1, Temp)
                Y = Year(Temp)
                M = Month(Temp)
                D = Format(Temp, "dd")
            End If
        End If
        '*******************
        If M < 3 Or (M = 3 And D < 21) Then
            Y = Y - 622
        Else
            Y = Y - 621
        End If
        Select Case M
            Case 1
                If D < 21 Then
                    M = 10 : D = D + 10
                Else
                    M = 11 : D = D - 20
                End If
            Case 2
                If D < 20 Then
                    M = 11 : D = D + 11
                Else
                    M = 12 : D = D - 19
                End If
            Case 3
                If D < 21 Then
                    M = 12 : D = D + 9
                Else
                    M = 1 : D = D - 20
                End If
            Case 4
                If D < 21 Then
                    M = 1 : D = D + 11
                Else
                    M = 2 : D = D - 20
                End If
            Case 5, 6
                If D < 22 Then
                    M = M - 3 : D = D + 10
                Else
                    M = M - 2 : D = D - 21
                End If
            Case 7, 8, 9
                If D < 23 Then
                    M = M - 3 : D = D + 9
                Else
                    M = M - 2 : D = D - 22
                End If
            Case 10
                If D < 23 Then
                    M = 7 : D = D + 8
                Else
                    M = 8 : D = D - 22
                End If
            Case 11, 12
                If D < 22 Then
                    M = M - 3 : D = D + 9
                Else
                    M = M - 2 : D = D - 21
                End If
        End Select
    End Sub


    Public Function ToPersianDate(ByVal DT As Date) As String

        Dim result As String = ""
        Dim PadChar As Char = Char.Parse("0")

        If Not IsDBNull(DT) Then
            Dim objPersianCalendar As PersianCalendar = New PersianCalendar
            Dim year As Integer = objPersianCalendar.GetYear(DT)
            Dim month As Integer = objPersianCalendar.GetMonth(DT)
            Dim day As Integer = objPersianCalendar.GetDayOfMonth(DT)
            result = year.ToString.PadLeft(4, PadChar) + "/" + _
                    month.ToString().PadLeft(2, PadChar) + "/" + _
                    day.ToString().PadLeft(2, PadChar)
        End If

        Return New String(result)

    End Function


End Module
