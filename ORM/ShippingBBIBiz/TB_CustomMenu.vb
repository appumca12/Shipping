Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_CustomMenu : Inherits ShippingBiz.TB_CustomMenuOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_CustomMenuCollection : Inherits ShippingBiz.TB_CustomMenuCollectionOrmTemplate

    End Class

End Namespace