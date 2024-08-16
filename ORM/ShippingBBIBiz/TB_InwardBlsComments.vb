Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_InwardBlsComments : Inherits ShippingBiz.TB_InwardBlsCommentsOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_InwardBlsCommentsCollection : Inherits ShippingBiz.TB_InwardBlsCommentsCollectionOrmTemplate

    End Class

End Namespace