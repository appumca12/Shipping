Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_Country : Inherits ShippingBiz.TB_CountryOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_CountryCollection : Inherits ShippingBiz.TB_CountryCollectionOrmTemplate

    End Class

End Namespace