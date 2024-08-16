Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_Ports : Inherits ShippingBiz.TB_PortsOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_PortsCollection : Inherits ShippingBiz.TB_PortsCollectionOrmTemplate

    End Class

End Namespace