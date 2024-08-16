Imports System
Imports System.Data
Imports OrmLib

Namespace ShippingBiz

    <Serializable()> Public MustInherit Class Business : Inherits BusinessBase

        Protected Sub New(ByVal dataContext As DataManager)
            Me.DataContext = dataContext
            Me.DataSet = dataContext.DataSet
        End Sub


        Friend DataContext As DataManager
        Protected DataSet As DataSet
        Protected Relations As DataRelationCollection

        Friend Property row() As DataRow
            Get
                Return Me.dataRow
            End Get
            Set(ByVal Value As DataRow)
                Me.dataRow = Value
            End Set
        End Property

    End Class
End Namespace