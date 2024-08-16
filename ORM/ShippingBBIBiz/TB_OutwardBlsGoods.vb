Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_OutwardBlsGoods : Inherits ShippingBiz.TB_OutwardBlsGoodsOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_OutwardBlsGoodsCollection : Inherits ShippingBiz.TB_OutwardBlsGoodsCollectionOrmTemplate

    End Class

End Namespace