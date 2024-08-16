Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports OrmLib

Namespace ShippingBiz

	Public Class TB_OutwardBlsComments : Inherits ShippingBiz.TB_OutwardBlsCommentsOrmTemplate

        Friend Sub New(ByVal dataContext As DataManager, ByVal dr As DataRow)
            MyBase.New(dataContext, dr)
            MyBase.row = dr
        End Sub

    End Class

    Public Class TB_OutwardBlsCommentsCollection : Inherits ShippingBiz.TB_OutwardBlsCommentsCollectionOrmTemplate

    End Class

End Namespace