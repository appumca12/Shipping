Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_Account : Inherits ShippingBiz.TB_AccountOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_AccountCollection : Inherits ShippingBiz.TB_AccountCollectionOrmTemplate

    End Class

End Namespace