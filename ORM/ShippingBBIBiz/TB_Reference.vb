Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_Reference : Inherits ShippingBiz.TB_ReferenceOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_ReferenceCollection : Inherits ShippingBiz.TB_ReferenceCollectionOrmTemplate

    End Class

End Namespace