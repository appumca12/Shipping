Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_Damage : Inherits ShippingBiz.TB_DamageOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_DamageCollection : Inherits ShippingBiz.TB_DamageCollectionOrmTemplate

    End Class

End Namespace