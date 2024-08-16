Imports System.Configuration
Imports OrmLib

Namespace ShippingBiz
    Public Class Config

        Private Sub New()
        End Sub

        Public Shared Property Dsn() As String
            Get
                SyncLock GetType(Config)
                    Return ConfigurationSettings.AppSettings.Item("dsn")
                End SyncLock
            End Get
            Set(ByVal Value As String)

            End Set
        End Property

    End Class
End Namespace