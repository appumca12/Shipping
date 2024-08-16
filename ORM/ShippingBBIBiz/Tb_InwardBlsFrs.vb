Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class Tb_InwardBlsFrs : Inherits ShippingBiz.Tb_InwardBlsFrsOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class Tb_InwardBlsFrsCollection : Inherits ShippingBiz.Tb_InwardBlsFrsCollectionOrmTemplate

    End Class

End Namespace