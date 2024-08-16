
Public Class UserDetentionByDay
    Public Event CustomClick()

    Private Sub Detention_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detention.Click
        RaiseEvent CustomClick()
    End Sub
    Public ReadOnly Property ExtraDays()
        Get
            Return Me.UltraNumericEditor1.Value
        End Get
    End Property
End Class
