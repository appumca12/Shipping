Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_Agents : Inherits ShippingBiz.TB_AgentsOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_AgentsCollection : Inherits ShippingBiz.TB_AgentsCollectionOrmTemplate

    End Class

End Namespace