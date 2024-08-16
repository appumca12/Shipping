Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_OutwardDiscount : Inherits ShippingBiz.TB_OutwardDiscountOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_OutwardDiscountCollection : Inherits ShippingBiz.TB_OutwardDiscountCollectionOrmTemplate

    End Class

End Namespace