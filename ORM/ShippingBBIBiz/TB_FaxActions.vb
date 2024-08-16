Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_FaxActions : Inherits ShippingBiz.TB_FaxActionsOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_FaxActionsCollection : Inherits ShippingBiz.TB_FaxActionsCollectionOrmTemplate

    End Class

End Namespace