Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_Inquery : Inherits ShippingBiz.TB_InqueryOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_InqueryCollection : Inherits ShippingBiz.TB_InqueryCollectionOrmTemplate

    End Class

End Namespace