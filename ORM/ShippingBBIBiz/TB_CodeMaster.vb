Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_CodeMaster : Inherits ShippingBiz.TB_CodeMasterOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_CodeMasterCollection : Inherits ShippingBiz.TB_CodeMasterCollectionOrmTemplate

    End Class

End Namespace