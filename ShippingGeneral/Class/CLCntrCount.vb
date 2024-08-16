Public Class CLCntrCount


    Private TbResult As DataTable
    Public Sub New()
        TbResult = New DataTable

        With TbResult
            .TableName = "TBResult"
            .Columns.Add(New DataColumn("CnType", System.Type.GetType("System.String")))
            .Columns.Add(New DataColumn("CnSize", System.Type.GetType("System.String")))
            .Columns.Add(New DataColumn("FE", System.Type.GetType("System.String")))
            .Columns.Add(New DataColumn("Total", System.Type.GetType("System.Int32")))
        End With
    End Sub

    Public Sub Add(ByVal CnType As String, ByVal CnSize As String, ByVal FE As String)

        Dim Dr() As DataRow
        Dim NewDr As DataRow
        Dr = TbResult.Select("CnType = '" & CnType & "' and CnSize = '" & CnSize & "' and Fe = '" & FE & "'")
        If Dr.Length = 0 Then
            NewDr = TbResult.NewRow
            NewDr("CnType") = CnType
            NewDr("CnSize") = CnSize
            NewDr("FE") = FE
            NewDr("Total") = 1
            TbResult.Rows.Add(NewDr)
        Else
            Dr(0).Item("Total") += 1
        End If

    End Sub
    Public Function GetInString() As String

        Dim Dr As DataRow
        Dim sResult As String = ""

        For Each Dr In TbResult.Rows
            sResult += IIf(sResult = "", "", vbCrLf) & Dr("Total").ToString & "X" & Dr("CnSize") & " " & Dr("CnType") & " " & IIf(Dr("FE") = "E", "Empty", IIf(Dr("FE") = "L", "LCL", "Full"))
        Next

        Return sResult

    End Function


End Class
