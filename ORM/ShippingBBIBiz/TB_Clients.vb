Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_Clients : Inherits ShippingBiz.TB_ClientsOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_ClientsCollection : Inherits ShippingBiz.TB_ClientsCollectionOrmTemplate

    End Class

End Namespace