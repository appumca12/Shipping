Imports OrmLib
Imports Shippingbiz

Module WHLGeneral

    Public Function PortNameByCode(ByVal DM As DataManager, ByVal PortCode As String) As String

        Dim Ports As TB_Ports
        If DM Is Nothing Then
            DM = New DataManager(My.Settings.DSN)
        End If
        DM.QueryCriteria.Clear()
        DM.QueryCriteria.And(JoinPath.TB_Ports.Columns.PortCode, PortCode, MatchType.Exact)
        Ports = DM.GetTB_Ports
        If Ports Is Nothing Then
            Return "?"
        Else
            Return Ports.PortName
        End If


    End Function

    Public Function TWByCnSizeCnTypeHight(ByVal CnSize As String, ByVal CnType As String, ByVal Hight As String) As String

        Dim TB As New DataTable
        Dim lResult As Boolean
        Dim sSQl As String

        TableBySql("Select * from tb_IsoType where WHLSize = '" & CnSize & "' and WHLType = '" & _
                   CnType & "' and WHLHeight = '" & Hight & "'", TB, lResult)

        If TB.Rows.Count = 0 Then
            If CnSize = "20" Then
                Return "2200"
            Else
                Return "4200"
            End If
        Else
            Return TB.Rows(0).Item("TareWeight").ToString
        End If

    End Function

 End Module
