Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_Deposits : Inherits ShippingBiz.TB_DepositsOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_DepositsCollection : Inherits ShippingBiz.TB_DepositsCollectionOrmTemplate

    End Class

End Namespace