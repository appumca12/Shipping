Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class Tb_OutwardBlsFrs : Inherits ShippingBiz.Tb_OutwardBlsFrsOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class Tb_OutwardBlsFrsCollection : Inherits ShippingBiz.Tb_OutwardBlsFrsCollectionOrmTemplate

    End Class

End Namespace