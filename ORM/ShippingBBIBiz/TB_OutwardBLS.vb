Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_OutwardBLS : Inherits ShippingBiz.TB_OutwardBLSOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_OutwardBLSCollection : Inherits ShippingBiz.TB_OutwardBLSCollectionOrmTemplate

    End Class

End Namespace