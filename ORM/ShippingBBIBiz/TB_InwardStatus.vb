Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_InwardStatus : Inherits ShippingBiz.TB_InwardStatusOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_InwardStatusCollection : Inherits ShippingBiz.TB_InwardStatusCollectionOrmTemplate

    End Class

End Namespace