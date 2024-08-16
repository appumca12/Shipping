Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_RecivedItems : Inherits ShippingBiz.TB_RecivedItemsOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_RecivedItemsCollection : Inherits ShippingBiz.TB_RecivedItemsCollectionOrmTemplate

    End Class

End Namespace