Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_ExpRecivedItems : Inherits ShippingBiz.TB_ExpRecivedItemsOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_ExpRecivedItemsCollection : Inherits ShippingBiz.TB_ExpRecivedItemsCollectionOrmTemplate

    End Class

End Namespace