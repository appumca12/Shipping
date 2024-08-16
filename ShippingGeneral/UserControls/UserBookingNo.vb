Imports ShippingBiz
Imports OrmLib


Public Class UserBookingNo
    Public Event bookingchanged()
    Private Docs As DataTable
    Private Dm As DataManager
    Private Sub CmbBooking_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbBooking.SelectionChanged

        Dim Dv As DataView
        Dv = New DataView(Docs, "ID = '" & CmbBooking.Value.ToString & "'", "", DataViewRowState.CurrentRows)
        If Dv.Count > 0 Then
            Me.TxtClient.Text = NullToValue(Dv.Item(0).Item("Client"), "")
            Me.CmbBooking.Text = NullToValue(Dv.Item(0).Item("BookingNo"), "")
        End If
        RaiseEvent bookingchanged()

    End Sub

    Public Sub InitControl()

        Dm = New DataManager(My.Settings.DSN)
        Dim DS As New DataSet

        '  Dim Sql As String
        '   Sql = "Select ID , BookingNo , (Select Top 1 lName from Tb_Clients Where ID = TB_Booking.ClientID) as Client From TB_Booking Order By BookingNo"

        DS = StoredProcedures.SP_GetBookingList()
        Docs = DS.Tables(0)

        With Me.CmbBooking
            .DataSource = Docs
            .DisplayMember = "BookingNo"
            .ValueMember = "ID"
        End With

    End Sub

    Public Property BookingID() As Guid

        Get
            If Me.CmbBooking.Text <> "" Then
                Return CmbBooking.Value
            Else
                Return Guid.Empty
            End If
        End Get

        Set(ByVal value As Guid)
            If value = Guid.Empty Then
                CmbBooking.Value = value
                CmbBooking.Text = ""
                TxtClient.Text = ""
            Else
                setDocument(value)
                CmbBooking.Value = value
            End If

        End Set

    End Property


    Private Sub setDocument(ByVal Value As Guid)

        Dim Dv As DataView
        Dv = New DataView(Docs, "ID = '" & Value.ToString & "'", "", DataViewRowState.CurrentRows)
        If Dv.Count = 0 Then
            Me.CmbBooking.Text = ""
        Else
            Me.CmbBooking.Text = Dv.Item(0).Item("BookingNo")
            Me.TxtClient.Text = NullToValue(Dv.Item(0).Item("Client"), "")
        End If


    End Sub

    Public ReadOnly Property ClientName() As String
        Get
            Return Me.TxtClient.Text
        End Get
    End Property

    Public ReadOnly Property BookingNo() As String
        Get
            If Me.CmbBooking.Text <> "" Then
                Return CmbBooking.Text
            Else
                Return ""
            End If
        End Get
    End Property
End Class
