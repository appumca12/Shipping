Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_InwardBLS : Inherits ShippingBiz.TB_InwardBLSOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_InwardBLSCollection : Inherits ShippingBiz.TB_InwardBLSCollectionOrmTemplate

    End Class

End Namespace