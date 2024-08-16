Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_TaxBase : Inherits ShippingBiz.TB_TaxBaseOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_TaxBaseCollection : Inherits ShippingBiz.TB_TaxBaseCollectionOrmTemplate

    End Class

End Namespace