Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class sysdiagrams : Inherits ShippingBiz.sysdiagramsOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class sysdiagramsCollection : Inherits ShippingBiz.sysdiagramsCollectionOrmTemplate

    End Class

End Namespace