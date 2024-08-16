Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_AUTDummyLog : Inherits ShippingBiz.TB_AUTDummyLogOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_AUTDummyLogCollection : Inherits ShippingBiz.TB_AUTDummyLogCollectionOrmTemplate

    End Class

End Namespace