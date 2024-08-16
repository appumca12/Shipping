Module IsoCntr

    Public Function IsoToType(ByVal TxtDef As String) As String

        Dim TxtStr As String

        If TxtDef = "2200" Or TxtDef = "2210" Or TxtDef = "22G1" Then
            TxtStr = "20SD"
        ElseIf TxtDef = "4300" Or TxtDef = "4310" Or TxtDef = "42G1" Or TxtDef = "4200" Then
            TxtStr = "40SD"
        ElseIf TxtDef = "25G1" Then
            TxtStr = "20SH"
        ElseIf TxtDef = "4500" Or TxtDef = "4510" Or TxtDef = "45G1" Then
            TxtStr = "40SH"
        ElseIf TxtDef = "L5G1" Then
            TxtStr = "45SH"
        ElseIf TxtDef = "2230" Or TxtDef = "2232" Then
            TxtStr = "20RS"
        ElseIf TxtDef = "4332" Or TxtDef = "4232" Or TxtDef = "4230" Then
            TxtStr = "40RS"
        ElseIf TxtDef = "25R1" Then
            TxtStr = "20RH"
        ElseIf TxtDef = "4532" Or TxtDef = "45R1" Or TxtDef = "4530" Then
            TxtStr = "40RH"
        ElseIf TxtDef = "L5R1" Then
            TxtStr = "45RH"
        ElseIf TxtDef = "2250" Or TxtDef = "2251" Or TxtDef = "22UT" Then
            TxtStr = "20FO"
        ElseIf TxtDef = "4350" Or TxtDef = "4351" Or TxtDef = "42UT" Then
            TxtStr = "40FO"
        ElseIf TxtDef = "2650" Or TxtDef = "2651" Then
            TxtStr = "20HO"
        ElseIf TxtDef = "4650" Or TxtDef = "4651" Then
            TxtStr = "40HO"
        ElseIf TxtDef = "2264" Or TxtDef = "22P1" Then
            TxtStr = "20FC"
        ElseIf TxtDef = "4364" Or TxtDef = "42P1" Then
            TxtStr = "40FC"
        ElseIf TxtDef = "2960" Or TxtDef = "2961" Then
            TxtStr = "20PF"
        ElseIf TxtDef = "4960" Or TxtDef = "4961" Then
            TxtStr = "40PF"
        ElseIf TxtDef = "2270" Or TxtDef = "2271" Or TxtDef = "22TD" Then
            TxtStr = "20TK"
        ElseIf TxtDef = "4370" Or TxtDef = "4371" Or TxtDef = "42TD" Then
            TxtStr = "40TK"
        ElseIf TxtDef = "2280" Or TxtDef = "2281" Then
            TxtStr = "20BK"
        ElseIf TxtDef = "4380" Or TxtDef = "4381" Then
            TxtStr = "40BK"
        ElseIf TxtDef = "22R1" Then
            TxtStr = "20RS"
        ElseIf TxtDef = "42R1" Then
            TxtStr = "40RS"
        ElseIf Mid(TxtDef, 1, 2) = "20" Or Mid(TxtDef, 1, 2) = "40" Then
            Return TxtDef
        ElseIf Mid(TxtDef, 1, 1) = "2" Then
            TxtStr = "20SD"
        Else
            TxtStr = "40SD"
        End If

        Return TxtStr

    End Function
  
    Function TypeToIso(ByVal TxtDef As String)

        Dim TxtStr As String

        If TxtDef = "20SD" Then

            TxtStr = "2210"

        ElseIf TxtDef = "40SD" Then

            TxtStr = "4310"

        ElseIf TxtDef = "40SH" Then

            TxtStr = "4510"

        ElseIf TxtDef = "40HG" Then

            TxtStr = "4510"

        ElseIf TxtDef = "20RS" Then

            TxtStr = "2232"

        ElseIf TxtDef = "40RS" Then

            TxtStr = "4332"

        ElseIf TxtDef = "40RH" Then

            TxtStr = "4532"

        ElseIf TxtDef = "20FO" Then

            TxtStr = "2250"

        ElseIf TxtDef = "40FO" Then

            TxtStr = "4350"

        ElseIf TxtDef = "20HO" Then

            TxtStr = "2650"

        ElseIf TxtDef = "40HO" Then

            TxtStr = "4650"

        ElseIf TxtDef = "20FC" Then

            TxtStr = "2264"

        ElseIf TxtDef = "40FC" Then

            TxtStr = "4364"

        ElseIf TxtDef = "20PF" Then

            TxtStr = "2960"

        ElseIf TxtDef = "40PF" Then

            TxtStr = "4960"

        ElseIf TxtDef = "30SD" Then

            TxtStr = "3210"

        ElseIf TxtDef = "3SH" Then

            TxtStr = "3510"

        ElseIf TxtDef = "45SH" Or TxtDef = "45SH" Or TxtDef = "45SH" Then

            TxtStr = "9510"

        ElseIf TxtDef = "20TK" Then

            TxtStr = "2270"

        ElseIf TxtDef = "40TK" Then

            TxtStr = "4370"

        ElseIf TxtDef = "20BK" Then

            TxtStr = "2280"

        ElseIf TxtDef = "40BK" Then

            TxtStr = "4380"

        ElseIf TxtDef = "20VT" Then

            TxtStr = "2210"

        ElseIf TxtDef = "4VT" Then

            TxtStr = "4310"

        ElseIf TxtDef = "INS" Then

            TxtStr = "2699"

        ElseIf Mid(TxtDef, 1, 1) = "2" Then

            TxtStr = "2210"

        Else

            TxtStr = "4310"

        End If

        Return TxtStr

    End Function
    Function GetCnCode(ByVal sSize As String, ByVal sType As String) As String

        Dim Ans As String

        Select Case sType
            Case "H"
                Ans = "SH"
            Case "R"
                Ans = "RS"
            Case "T"
                Ans = "TK"
            Case "F"
                Ans = "FC"
            Case "O"
                Ans = "FO"
            Case Else
                Ans = "SD"
        End Select

        Return TypeToIso(sSize & Ans)

    End Function
    Public Function CnType(ByVal sIsoCode As String) As String

        Dim sCode As String
        Dim sResult As String

        sCode = Right(IsoToType(sIsoCode), 2)
        Select Case sCode
            Case "SH"
                sResult = "HI-CUBE"
            Case "RS"
                sResult = "REEFER"
            Case "RH"
                sResult = "REEFER"
            Case "TK"
                sResult = "TANK"
            Case "FC"
                sResult = "FLAT RACK"
            Case "FO"
                sResult = "OPEN TOP"
            Case Else
                sResult = "DRY"
        End Select

        Return sResult

    End Function



End Module
