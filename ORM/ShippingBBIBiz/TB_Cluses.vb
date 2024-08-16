Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_Cluses : Inherits ShippingBiz.TB_ClusesOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_ClusesCollection : Inherits ShippingBiz.TB_ClusesCollectionOrmTemplate

    End Class

End Namespace