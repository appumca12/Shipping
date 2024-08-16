Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_autoLog : Inherits ShippingBiz.TB_autoLogOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_autoLogCollection : Inherits ShippingBiz.TB_autoLogCollectionOrmTemplate

    End Class

End Namespace