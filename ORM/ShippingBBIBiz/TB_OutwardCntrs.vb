Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_OutwardCntrs : Inherits ShippingBiz.TB_OutwardCntrsOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_OutwardCntrsCollection : Inherits ShippingBiz.TB_OutwardCntrsCollectionOrmTemplate

    End Class

End Namespace