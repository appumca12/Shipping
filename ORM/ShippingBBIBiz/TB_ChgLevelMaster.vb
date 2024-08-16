Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_ChgLevelMaster : Inherits ShippingBiz.TB_ChgLevelMasterOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_ChgLevelMasterCollection : Inherits ShippingBiz.TB_ChgLevelMasterCollectionOrmTemplate

    End Class

End Namespace