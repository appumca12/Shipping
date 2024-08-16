Imports ShippingBiz
Imports OrmLib
Imports System.Data.SqlClient
Imports System.IO

Public Class UserInwardBlsBookingNo
    Public Event blNochanged()
    Private Docs As DataTable
    Private Dm As DataManager
    Private Sub CmbBlNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbBlNo.SelectionChanged

        Dim Dv As DataView
        If Not Dv Is Nothing Then
            Dv = New DataView(Docs, "ID = '" & CmbBlNo.Value.ToString & "'", "", DataViewRowState.CurrentRows)
            If Dv.Count > 0 Then
                'Me.TxtClient.Text = NullToValue(Dv.Item(0).Item("ID").ToString(), "")
                Me.CmbBlNo.Text = NullToValue(Dv.Item(0).Item("BlNo").ToString(), "")
            End If
            RaiseEvent blNochanged()
        End If
    End Sub

    Public Sub InitControl()
        'ByVal dFrom As Date, ByVal dTo As Date
        Dm = New DataManager(My.Settings.DSN)
        Dim DS As New DataSet
        Dim conCurrent As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim Cnn As New SqlConnection(My.Settings.DSN)
        Dim PCol(0) As DataColumn
        Dim cCol(0) As DataColumn


        Cnn.Open()
        '
        With Cmd
            .CommandText = "SP_GetIntwardBlsBookingNos"
            .CommandType = CommandType.StoredProcedure
            .Connection = Cnn
            .Parameters.AddWithValue("@Line", CurrentShippingLine)
        End With

        DA.SelectCommand = Cmd
        DA.Fill(DS)

        Docs = DS.Tables(0)

        With Me.CmbBlNo
            .DataSource = Docs
            .DisplayMember = "BlNo"
            .ValueMember = "ID"
        End With

    End Sub

    Public Property BlId() As Guid

        Get
            If Me.CmbBlNo.Text <> "" Then
                Return CmbBlNo.Value
            Else
                Return Guid.Empty
            End If
        End Get

        Set(ByVal value As Guid)
            If value = Guid.Empty Then
                CmbBlNo.Value = value
                CmbBlNo.Text = ""
                TxtClient.Text = ""
            Else
                setDocument(value)
                CmbBlNo.Value = value
            End If

        End Set

    End Property


    Private Sub setDocument(ByVal Value As Guid)

        Dim Dv As DataView
        Dv = New DataView(Docs, "ID = '" & Value.ToString & "'", "", DataViewRowState.CurrentRows)
        If Dv.Count = 0 Then
            Me.CmbBlNo.Text = ""
        Else
            Me.CmbBlNo.Text = Dv.Item(0).Item("BlNo")
            'Me.TxtClient.Text = NullToValue(Dv.Item(0).Item("ID"), "")
        End If


    End Sub

    'Public ReadOnly Property ClientName() As String
    '    Get
    '        Return Me.TxtClient.Text
    '    End Get
    'End Property

    Public ReadOnly Property BlNo() As String
        Get
            If Me.CmbBlNo.Text <> "" Then
                Return CmbBlNo.Text
            Else
                Return ""
            End If
        End Get
    End Property
End Class
