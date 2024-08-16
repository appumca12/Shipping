Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_Documets : Inherits ShippingBiz.TB_DocumetsOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_DocumetsCollection : Inherits ShippingBiz.TB_DocumetsCollectionOrmTemplate

    End Class

End Namespace