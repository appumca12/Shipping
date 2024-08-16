Imports OrmLib
Imports ShippingBiz
Public Class FrmBookingMerge

    Private TB As New DataTable
    Private TBCns As New DataTable
    Private DM As DataManager
    Private BKOrigin As TB_Booking
    Private BKDest As TB_Booking
    Private IsComperd As Boolean
    Private EcsOrigin As TB_EcsContainersCollection
    Private EcsDest As TB_EcsContainersCollection

    Private Sub InitData()

        TB = New DataTable
        TB.Columns.Add(New DataColumn("Message"))
        TB.Columns.Add(New DataColumn("OriginBooking"))
        TB.Columns.Add(New DataColumn("DestinationBooking"))


        TBCns = New DataTable
        TBCns.Columns.Add(New DataColumn("ID", System.Type.GetType("System.Guid")))
        TBCns.Columns.Add(New DataColumn("Select", System.Type.GetType("System.Boolean")))
        TBCns.Columns.Add(New DataColumn("CntrNo"))
        TBCns.Columns.Add(New DataColumn("CnSize"))
        TBCns.Columns.Add(New DataColumn("CnType"))

    End Sub

    Private Sub ButtonCompare_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCompare.Click
 

        Dim n20Origin As Int16
        Dim n40Origin As Int16

        Dim n20Dest As Int16
        Dim n40Dest As Int16

        Dim Dr As DataRow

        TB.Clear()
        TB.AcceptChanges()

        TBCns.Clear()
        TBCns.AcceptChanges()

        If Me.BookingFrom.BookingID = Guid.Empty Then
            Exit Sub
        End If

        If Me.BookingTo.BookingID = Guid.Empty Then
            Exit Sub
        End If


        DM = New DataManager(My.Settings.DSN)
        DM.QueryCriteria.And(JoinPath.TB_Booking.Columns.ID, Me.BookingFrom.BookingID, MatchType.Exact)
        BKOrigin = DM.GetTB_Booking

        DM.QueryCriteria.Clear()
        DM.QueryCriteria.And(JoinPath.TB_Booking.Columns.ID, Me.BookingTo.BookingID, MatchType.Exact)
        BKDest = DM.GetTB_Booking

        DM.QueryCriteria.Clear()
        DM.QueryCriteria.And(JoinPath.TB_EcsContainers.Columns.BookingID, BKOrigin.ID, MatchType.Exact)
        EcsOrigin = DM.GetTB_EcsContainersCollection

        For Each Ecs As TB_EcsContainers In EcsOrigin
            Dr = TBCns.NewRow
            Dr("ID") = Ecs.ID
            Dr("CntrNo") = Ecs.CntrNo
            Dr("CnSize") = Ecs.CnSize
            Dr("CnType") = Ecs.CnType
            Dr("Select") = False
            TBCns.Rows.Add(Dr)
        Next

        DM.QueryCriteria.Clear()
        DM.QueryCriteria.And(JoinPath.TB_EcsContainers.Columns.BookingID, BKDest.ID, MatchType.Exact)
        EcsDest = DM.GetTB_EcsContainersCollection

        If BKOrigin.ClientID <> BKDest.ClientID Then
            AddToTb("Clients Are Deferent", Me.BookingFrom.ClientName, Me.BookingTo.ClientName)
        End If

        If Me.BKOrigin.POL <> BKDest.POL Then
            AddToTb("POL Are Deferent", BKOrigin.POL, BKDest.POL)
        End If

        If Me.BKOrigin.POD <> BKDest.POD Then
            AddToTb("POD Are Deferent", BKOrigin.POD, BKDest.POD)
        End If

        n20Origin = 0
        n40Origin = 0

        n20Dest = 0
        n40Dest = 0

        For Each Ecs As TB_EcsContainers In EcsOrigin
            If Ecs.CnSize = "20" Then
                n20Origin += 1
            Else
                n40Origin += 1
            End If
        Next


        For Each Ecs As TB_EcsContainers In EcsDest
            If Ecs.CnSize = "20" Then
                n20Dest += 1
            Else
                n40Dest += 1
            End If
        Next
        AddToTb("Total Assigned 20'", n20Origin.ToString, n20Dest.ToString)
        AddToTb("Total Assigned 40'", n40Origin.ToString, n40Dest.ToString)
        GridNumSeperator(Me.GridCns)

        IsComperd = True

    End Sub

    Private Sub FrmBookingMerge_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.BookingFrom.InitControl()
        Me.BookingTo.InitControl()
        InitData()
        Me.GridResult.DataSource = TB
        Me.GridCns.DataSource = TBCns

    End Sub
 
    Private Sub BookingFrom_bookingchanged() Handles BookingFrom.bookingchanged
        IsComperd = False
    End Sub

    Private Sub BookingTo_bookingchanged() Handles BookingTo.bookingchanged
        IsComperd = False
    End Sub

    Private Sub AddToTb(ByVal Message As String, ByVal OrgValue As String, ByVal DestValue As String)

        Dim dr As DataRow
        dr = TB.NewRow
        dr("Message") = Message
        dr("OriginBooking") = OrgValue
        dr("DestinationBooking") = DestValue
        TB.Rows.Add(dr)

    End Sub


    Private Sub ButtonSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSave.Click

        Dim LogDataSet As DataSet
        Dim Drs() As DataRow
        Dim Dr As DataRow
        Dim EcsDrs() As DataRow


        If IsComperd = False Then
            MsgBox("Compre First !")
            Exit Sub
        End If

        If Me.BookingFrom.BookingID = Guid.Empty Then
            Exit Sub
        End If

        If Me.BookingTo.BookingID = Guid.Empty Then
            Exit Sub
        End If

        Me.GridCns.UpdateData()

        Drs = TBCns.Select("Select = True")

        If Drs.Length = 0 Then
            MsgBox("No Any Selection !")
            Exit Sub
        End If

        If MsgBoxUpdate() = Windows.Forms.DialogResult.Yes Then
            Try
                For Each Dr In Drs
                    EcsDrs = DM.DataSet.Tables("TB_EcsContainers").Select("ID = '" & Dr("ID").ToString & "'")
                    If EcsDrs.Length > 0 Then
                        EcsDrs(0).Item("BookingID") = BKDest.ID
                    End If
                Next
                LogDataSet = DM.DataSet.Copy
                DM.CommitAll()
                GenerateLog(LogDataSet)
                MsgBoxSaveSuccessful()
                Call ButtonCompare_Click(Me, New System.EventArgs)
            Catch ex As Exception
                MsgBoxSaveFailed()
                MsgBox(ex.ToString)
            End Try
        End If

    End Sub

    Private Sub ButtonSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSelect.Click
        For Each dr As DataRow In TBCns.Rows
            dr("Select") = True
        Next
    End Sub

    Private Sub ButtonRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRemove.Click
        For Each dr As DataRow In TBCns.Rows
            dr("Select") = False
        Next
    End Sub
End Class