Public Class UserNavigate

    Public Event NextRecClick()
    Public Event LastRecClick()
    Public Event PrivRecClick()
    Public Event FirstRecClick()

    Private Sub FirstRec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FirstRec.Click
        RaiseEvent FirstRecClick()
    End Sub

    Private Sub PrivRec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrivRec.Click
        RaiseEvent PrivRecClick()
    End Sub

    Private Sub NextRec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NextRec.Click
        RaiseEvent NextRecClick()
    End Sub

    Private Sub LastRec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LastRec.Click
        RaiseEvent LastRecClick()
    End Sub

   
End Class
