Public Class UserInfo


    Private BLID As Guid
    Private OldMailRlsd As Boolean
    Public Sub InitControl()
        Me.MailReleaseRem.SetLength(50)
        Me.FrtCoverdBLNo.SetLength(20)
        Me.LCNO.SetLength(20)
        Me.ClientID.InitControl()
    End Sub
    Public Sub SetDocument(ByVal BID As Guid, ByVal Dr As DataRow)

        BLID = BID

        Me.MailRelease.Checked = IIf(IsDBNull(Dr("MailRelease")), False, Dr("MailRelease"))
        Me.MailReleaseRem.TextValue = IIf(IsDBNull(Dr("MailReleaseRem")), "", Dr("MailReleaseRem"))
        Me.FrtCoverdBLNo.TextValue = IIf(IsDBNull(Dr("FrtCoverdBLNo")), "", Dr("FrtCoverdBLNo"))
        Me.LCNO.TextValue = IIf(IsDBNull(Dr("LCNO")), "", Dr("LCNO"))
        Me.ClientID.ClientID = IIf(IsDBNull(Dr("ClientID")), Guid.Empty, Dr("ClientID"))
        OldMailRlsd = Me.MailRelease.Checked

    End Sub

    Public Sub GetDocument(ByRef Dr As DataRow)
        If Changed Then
            Dr("MailRelease") = Me.MailRelease
            Dr("MailReleaseRem") = Me.MailReleaseRem.TextValue
            Dr("FrtCoverdBLNo") = Me.FrtCoverdBLNo.TextValue
            Dr("LCNO") = Me.LCNO.TextValue
            Dr("ClientID") = IIf(Me.ClientID.ClientID = Guid.Empty, DBNull.Value, Me.ClientID.ClientID)
        End If
    End Sub

    Public ReadOnly Property Changed() As Boolean
        Get
            If Me.MailReleaseRem.Changed Or Me.LCNO.Changed Or _
               Me.FrtCoverdBLNo.Changed Or OldMailRlsd <> Me.MailRelease.Checked Then
                Return True
            Else
                Return False
            End If
        End Get
    End Property



    Private Sub UserInfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
