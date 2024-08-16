Public Class CLMemo
    Public Enum MemoTypes
        Shipper = 0
        Cnee = 1
        Notify1 = 2
        Notify2 = 3
        Goods = 4
        Marks = 5
    End Enum
    Private mNtfy1 As Collection
    Private mNtfy2 As Collection
    Private mGood As Collection
    Private mCnee As Collection
    Private mShpr As Collection
    Private mMark As Collection
    Private mCol As Collection
    Private nNtfyCount As Long
    Private nGoodCount As Long
    Private nCneeCount As Long
    Private nShprCount As Long
    Private nMarkCount As Long
    Private nPkgsCount As Long
    Private nMaxCol As Long
    Public Sub ColInit(ByVal Col As MemoTypes, ByVal sCol As String, ByVal nLen As Long)

        Col = UCase(Col)
        Select Case Col
            Case MemoTypes.Notify1
                mNtfy1 = New Collection
                mCol = mNtfy1
            Case MemoTypes.Notify2
                mNtfy2 = New Collection
                mCol = mNtfy2
            Case MemoTypes.Goods
                mGood = New Collection
                mCol = mGood
            Case MemoTypes.Cnee
                mCnee = New Collection
                mCol = mCnee
            Case MemoTypes.Shipper
                mShpr = New Collection
                mCol = mShpr
            Case MemoTypes.Marks
                mMark = New Collection
                mCol = mMark
        End Select

        FillmCol(sCol, nLen)
        If nMaxCol < mCol.Count Then
            nMaxCol = mCol.Count
        End If
    End Sub
    Public Sub FillmCol(ByVal sCol As String, ByVal nLen As Long)

        Dim nI As Long
        Dim Ch As String
        Dim nStr As Long
        Dim nLastSpace As Long
        Dim sResult As String = ""
        Dim mKey As Long

        nStr = Len(sCol)
        For nI = 1 To nStr
            Ch = Mid(sCol, nI, 1)
            If Asc(Ch) = 13 Or Asc(Ch) = 236 Then
                AddLines(mKey, sResult)
                sResult = ""
                nLastSpace = 0
                nI = nI + 1
            Else
                If Asc(Ch) <> 10 Then
                    If Len(sResult) >= nLen Then
                        If Ch = " " Then
                            AddLines(mKey, sResult)
                            sResult = ""
                            nLastSpace = 0
                        Else
                            If nLastSpace > 0 Then
                                mKey = mKey + 1
                                mCol.Add(Trim(Left(sResult, nLastSpace)), "#" + Format(mKey, "000000"))
                                sResult = Mid(sResult, nLastSpace)
                                nLastSpace = 0
                            Else
                                AddLines(mKey, sResult)
                                sResult = ""
                                nLastSpace = 0
                            End If
                        End If
                    End If
                End If
                If Len(sResult) = 0 And Ch = " " Then
                Else
                    sResult = sResult + Ch
                    If Ch = " " Then
                        nLastSpace = Len(sResult)
                    End If
                End If
            End If
        Next nI

        If Len(sResult) > 0 Then
            AddLines(mKey, sResult)
            sResult = ""
            nLastSpace = 0
        End If
    End Sub
    Public Sub GetFree(ByVal ValueToSplit As String, ByRef AList As ArrayList, ByVal nLen As Long)

        Dim nI As Long
        Dim Ch As String
        Dim nStr As Long
        Dim nLastSpace As Long
        Dim sResult As String = ""
        Dim mKey As Long
        Dim sCol As String
        sCol = ValueToSplit


        nStr = Len(sCol)
        For nI = 1 To nStr
            Ch = Mid(sCol, nI, 1)
            If Asc(Ch) = 13 Or Asc(Ch) = 236 Then
                sResult = sResult & " "
                AList.Add(Trim(Replace(sResult, Chr(10), "")))
                sResult = ""
                nLastSpace = 0
            Else
                If Asc(Ch) <> 10 Then
                    If Len(sResult) >= nLen Then
                        If Ch = " " Then
                            AList.Add(Trim(Replace(sResult, Chr(10), "")))
                            sResult = ""
                            nLastSpace = 0
                        Else
                            If nLastSpace > 0 Then
                                mKey = mKey + 1
                                AList.Add(Trim(Left(sResult, nLastSpace)))
                                sResult = Mid(sResult, nLastSpace)
                                nLastSpace = 0
                            Else
                                AList.Add(Trim(Replace(sResult, Chr(10), "")))
                                sResult = ""
                                nLastSpace = 0
                            End If
                        End If
                    End If
                End If
                If Len(sResult) = 0 And Ch = " " Then
                Else
                    sResult = sResult + Ch
                    If Ch = " " Then
                        nLastSpace = Len(sResult)
                    End If
                End If
            End If
        Next nI

        If Len(sResult) > 0 Then
            AList.Add(Trim(Replace(sResult, Chr(10), "")))
            sResult = ""
            nLastSpace = 0
        End If


    End Sub

    Private Sub AddLines(ByRef mKey As Long, ByVal sResult As String)
        mKey = mKey + 1
        mCol.Add(Trim(LTrim(sResult)), "#" + Format(mKey, "000000"))
    End Sub
    Public Sub AddOutSide(ByVal Col As MemoTypes, ByVal sItem As String)

        Select Case Col
            Case MemoTypes.Notify1
                mNtfy1.Add(Trim(LTrim(sItem)), "#" + Format(mNtfy1.Count + 1, "000000"))
                If nMaxCol < mNtfy1.Count Then
                    nMaxCol = mNtfy1.Count
                End If
            Case MemoTypes.Notify2
                mNtfy2.Add(Trim(LTrim(sItem)), "#" + Format(mNtfy2.Count + 1, "000000"))
                If nMaxCol < mNtfy2.Count Then
                    nMaxCol = mNtfy2.Count
                End If
            Case MemoTypes.Goods
                mGood.Add(Trim(LTrim(sItem)), "#" + Format(mGood.Count + 1, "000000"))
                If nMaxCol < mGood.Count Then
                    nMaxCol = mGood.Count
                End If
            Case MemoTypes.Cnee
                mCnee.Add(Trim(LTrim(sItem)), "#" + Format(mCnee.Count + 1, "000000"))
                If nMaxCol < mCnee.Count Then
                    nMaxCol = mCnee.Count
                End If
            Case MemoTypes.Shipper
                mShpr.Add(Trim(LTrim(sItem)), "#" + Format(mShpr.Count + 1, "000000"))
                If nMaxCol < mShpr.Count Then
                    nMaxCol = mShpr.Count
                End If
            Case MemoTypes.Marks
                mMark.Add(Trim(LTrim(sItem)), "#" + Format(mMark.Count + 1, "000000"))
                If nMaxCol < mMark.Count Then
                    nMaxCol = mMark.Count
                End If
        End Select

    End Sub
    Public Sub InsertItem(ByVal Col As MemoTypes, ByVal sItem As String, ByVal nItem As Long)

        Dim mCol As New Collection
        Dim nI As Long
        Dim aCol() As String
        Dim nLen As Long
        Dim nJ As Long

        Select Case Col
            Case MemoTypes.Notify1
                mCol = mNtfy1
            Case MemoTypes.Notify2
                mCol = mNtfy2
            Case MemoTypes.Goods
                mCol = mGood
            Case MemoTypes.Cnee
                mCol = mCnee
            Case MemoTypes.Shipper
                mCol = mShpr
            Case MemoTypes.Marks
                mCol = mMark
        End Select


        nLen = mCol.Count

        If nLen >= nItem Then
            nI = nLen + 1
        Else
            nI = nItem
        End If

        ReDim aCol(nI)

        For nI = 1 To UBound(aCol)
            If nI = nItem Then
                aCol(nI) = sItem
            Else
                nJ = nJ + 1
                If nJ <= nLen Then
                    aCol(nI) = mCol.Item(nJ)
                Else
                    aCol(nI) = " "
                End If
            End If
        Next nI

        For nI = nLen To 1 Step -1
            mCol.Remove(Str(nI))
        Next nI

        For nI = 1 To UBound(aCol)
            mCol.Add(aCol(nI), "#" + Format(nI, "000000"))
        Next nI

        If nMaxCol < mCol.Count Then
            nMaxCol = mCol.Count
        End If

        mCol = Nothing

    End Sub
    Public ReadOnly Property Ntfy1() As Collection
        Get
            Return mNtfy1
        End Get
    End Property
    Public ReadOnly Property Ntfy2() As Collection
        Get
            Return mNtfy2
        End Get
    End Property
    Public ReadOnly Property GOOD() As Collection
        Get
            Return mGood
        End Get
    End Property
    Public ReadOnly Property Cnee() As Collection
        Get
            Return mCnee
        End Get
    End Property
    Public ReadOnly Property Shpr() As Collection
        Get
            Return mShpr
        End Get
    End Property
    Public ReadOnly Property Mark() As Collection
        Get
            Return mMark
        End Get
    End Property
    Public ReadOnly Property MaxCol() As Long
        Get
            Return nMaxCol
        End Get
    End Property


End Class
