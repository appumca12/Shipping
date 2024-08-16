Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_ExchangeDetails : Inherits ShippingBiz.TB_ExchangeDetailsOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_ExchangeDetailsCollection : Inherits ShippingBiz.TB_ExchangeDetailsCollectionOrmTemplate

    End Class

End Namespace