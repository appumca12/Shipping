Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_AccessLevel : Inherits ShippingBiz.TB_AccessLevelOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_AccessLevelCollection : Inherits ShippingBiz.TB_AccessLevelCollectionOrmTemplate

    End Class

End Namespace