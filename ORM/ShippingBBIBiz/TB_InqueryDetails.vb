Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_InqueryDetails : Inherits ShippingBiz.TB_InqueryDetailsOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_InqueryDetailsCollection : Inherits ShippingBiz.TB_InqueryDetailsCollectionOrmTemplate

    End Class

End Namespace