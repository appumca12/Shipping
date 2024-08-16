Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_Voyage : Inherits ShippingBiz.TB_VoyageOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_VoyageCollection : Inherits ShippingBiz.TB_VoyageCollectionOrmTemplate

    End Class

End Namespace