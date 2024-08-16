Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_LogDetails : Inherits ShippingBiz.TB_LogDetailsOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_LogDetailsCollection : Inherits ShippingBiz.TB_LogDetailsCollectionOrmTemplate

    End Class

End Namespace