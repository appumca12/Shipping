Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_InwardDiscount : Inherits ShippingBiz.TB_InwardDiscountOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_InwardDiscountCollection : Inherits ShippingBiz.TB_InwardDiscountCollectionOrmTemplate

    End Class

End Namespace