Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_ChgLevelDetails : Inherits ShippingBiz.TB_ChgLevelDetailsOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_ChgLevelDetailsCollection : Inherits ShippingBiz.TB_ChgLevelDetailsCollectionOrmTemplate

    End Class

End Namespace