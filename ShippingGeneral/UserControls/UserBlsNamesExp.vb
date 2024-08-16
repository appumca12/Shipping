Imports OrmLib
Imports ShippingBiz

Public Class UserBlsNamesExp

    Public Sub SetDocument(ByVal Dr As DataRow)

        Me.Shipper.TextValue = IIf(IsDBNull(Dr("Shipper")), "", Dr("Shipper"))
        Me.Cnee.TextValue = IIf(IsDBNull(Dr("Cnee")), "", Dr("Cnee"))
        Me.Notify1.TextValue = IIf(IsDBNull(Dr("Notify1")), "", Dr("Notify1"))
        Me.Notify2.TextValue = IIf(IsDBNull(Dr("Notify2")), "", Dr("Notify2"))
        Me.Messers.TextValue = IIf(IsDBNull(Dr("Messers")), "", Dr("Messers"))
        '        Me.Forwarder.TextValue = IIf(IsDBNull(Dr("Forwarder")), "", Dr("Forwarder"))


    End Sub

    Public Sub getDocument(ByRef Dr As DataRow)

        With Dr
            Dr("Shipper") = Me.Shipper.TextValue
            Dr("Cnee") = Me.Cnee.TextValue
            Dr("Notify1") = Me.Notify1.TextValue
            Dr("Notify2") = Me.Notify2.TextValue
            Dr("Messers") = Me.Messers.TextValue
            '           Dr("Forwarder") = Me.Forwarder.TextValue
        End With

    End Sub

    Public ReadOnly Property Changed() As Boolean
        Get
            If Me.Shipper.Changed Or Me.Cnee.Changed Or Me.Notify1.Changed Or Me.Notify2.Changed Or Me.Messers.Changed Or Me.Forwarder.Changed Then
                Return True
            Else
                Return False
            End If
        End Get
    End Property


    Private Sub Shipper_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Shipper.Load

    End Sub
End Class
