Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_PermitDetails : Inherits ShippingBiz.TB_PermitDetailsOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_PermitDetailsCollection : Inherits ShippingBiz.TB_PermitDetailsCollectionOrmTemplate

    End Class

End Namespace