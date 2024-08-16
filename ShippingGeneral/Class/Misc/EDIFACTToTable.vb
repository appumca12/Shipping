Public Class EDIFACTToTable
    Public Enum EDIProcessStatus
        Succses
        NoEDIMessage
        FileNotFound
    End Enum

    Private FileName As String
    Private TBSegments As DataTable
    Private status As EDIProcessStatus
    Private aSegments() As String
    Private delimiters() As Char = {"+", ":"}

    Public Sub New(ByVal FileName As String)
        Me.FileName = FileName
        ProcessFile()
        ProcessSegments()
    End Sub

    Private Sub ProcessFile()

        Dim LN As Long
        Dim sFile As String
        Dim nI As Int32 = 0
        Dim Dr As DataRow

        TBSegments = New DataTable
        TBSegments.Columns.Add(New DataColumn("Seq", System.Type.GetType("System.Int32")))
        TBSegments.Columns.Add(New DataColumn("Segment"))

        If Dir(FileName) = "" Then
            status = EDIProcessStatus.FileNotFound
            Exit Sub
        End If

        FileOpen(1, FileName, OpenMode.Input)
        LN = LOF(1)
        sFile = InputString(1, LN)
        sFile = Replace(sFile, Chr(13), " ")
        sFile = Replace(sFile, Chr(10), " ")
        aSegments = Split(sFile, "'")
        FileClose(1)

        For nI = 0 To aSegments.Length - 1
            Dr = TBSegments.NewRow
            Dr("Seq") = nI
            Dr("Segment") = Trim(aSegments(nI))
            TBSegments.Rows.Add(Dr)
        Next

    End Sub

    Private Sub ProcessSegments()

        Dim Segment As String

        TBSegments = New DataTable
        TBSegments.Columns.Add(New DataColumn("Seq", System.Type.GetType("System.Int32")))

        For Each Segment In aSegments
            ParseSegment(Segment)
        Next
    End Sub
    Private Sub ParseSegment(ByVal Segment As String)

        Dim strTemp() As String
        Dim Field As String
        Dim I As Int32
        Dim Row As Long = TBSegments.Rows.Count + 1
        Dim Dr As DataRow

        strTemp = Segment.Split(delimiters)
        If strTemp.Length + 1 > TBSegments.Columns.Count Then
            For I = 0 To strTemp.Length
                Try
                    Field = "Field" & Format(I, "00")
                    TBSegments.Columns.Add(New DataColumn(Field))
                Catch ex As Exception
                End Try
            Next
        End If
        Dr = TBSegments.NewRow
        Dr("Seq") = Format(Row, "00")

        For I = 0 To strTemp.Length - 1
            Field = "field" & Format(I, "00")
            Dr(Field) = Trim(strTemp(I))
        Next

        TBSegments.Rows.Add(Dr)

    End Sub
    Public ReadOnly Property ProcessStatus() As EDIProcessStatus
        Get
            Return status
        End Get
    End Property

    Public ReadOnly Property Count() As Long
        Get
            Return aSegments.Length
        End Get
    End Property

    Public ReadOnly Property Segments() As DataTable
        Get
            Return TBSegments
        End Get
    End Property

End Class
