Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_Company : Inherits ShippingBiz.TB_CompanyOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_CompanyCollection : Inherits ShippingBiz.TB_CompanyCollectionOrmTemplate

    End Class

End Namespace