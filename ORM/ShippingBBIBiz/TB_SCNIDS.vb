Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_SCNIDS : Inherits ShippingBiz.TB_SCNIDSOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_SCNIDSCollection : Inherits ShippingBiz.TB_SCNIDSCollectionOrmTemplate

    End Class

End Namespace