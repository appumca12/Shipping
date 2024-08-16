Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_NOSPaymentTyps : Inherits ShippingBiz.TB_NOSPaymentTypsOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_NOSPaymentTypsCollection : Inherits ShippingBiz.TB_NOSPaymentTypsCollectionOrmTemplate

    End Class

End Namespace