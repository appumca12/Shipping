Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_OutwardBlsNames : Inherits ShippingBiz.TB_OutwardBlsNamesOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_OutwardBlsNamesCollection : Inherits ShippingBiz.TB_OutwardBlsNamesCollectionOrmTemplate

    End Class

End Namespace