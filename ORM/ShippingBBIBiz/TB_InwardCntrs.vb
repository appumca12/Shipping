Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_InwardCntrs : Inherits ShippingBiz.TB_InwardCntrsOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_InwardCntrsCollection : Inherits ShippingBiz.TB_InwardCntrsCollectionOrmTemplate

    End Class

End Namespace