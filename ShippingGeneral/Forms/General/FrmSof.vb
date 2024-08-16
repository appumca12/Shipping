Imports OrmLib
Imports ShippingBiz
Imports System.Data.SqlClient

Public Class FrmSof

    Public Enum FormStatus
        NewSof
        EditSoft
    End Enum

    Public Enum FormAns
        Confirm
        Cancel
    End Enum

    Private Status As FormStatus
    Private TBSOf As DataTable
    Private ID As Guid = Guid.Empty
    Private Drs() As DataRow
    Private VoyageID As Guid
    Private EdiCnn As New OleDb.OleDbConnection
    Dim sSql As String
    Dim IResult As Boolean
    Dim ClientTHCP As Integer
    Dim TBct As New DataTable
    Dim Cmd As SqlCommand
    Dim Cnn As New SqlConnection
    Private Sub FrmSof_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Port.InitControl(Me.SOFGroup.Appearance.BackColor)
        Me.ETA.InitControl(True, False)
        Me.Pilot.InitControl(True, False)
        Me.Arrival.InitControl(True, False)
        Me.Berthed.InitControl(True, False)
        Me.Jetty.InitControl(2, 0)
        Me.FreePraGrnt.InitControl(True, False)
        Me.CustomInspect.InitControl(True, False)
        Me.GangOnBoard.InitControl(True, False)
        Me.DschCmnc.InitControl(True, False)
        Me.DschCmpl.InitControl(True, False)
        Me.LoadCmnc.InitControl(True, False)
        Me.LoadCmpl.InitControl(True, False)
        Me.DocOnBoard.InitControl(True, False)
        Me.PClear.InitControl(True, False)
        Me.Unberthed.InitControl(True, False)
        Me.Sailed.InitControl(True, False)
        Me.NextPort.InitControl(My.Settings.MainColor)
        Me.ETANextPort.InitControl(True, False)

        Me.IFOArrival.InitControl(4, 2)
        Me.IFODep.InitControl(4, 2)
        Me.IFOSup.InitControl(4, 2)

        Me.MDOArrival.InitControl(4, 2)
        Me.MDODep.InitControl(4, 2)
        Me.MDOSup.InitControl(4, 2)

        Me.FWaterArrival.InitControl(4, 2)
        Me.FWaterDep.InitControl(4, 2)
        Me.FWaterSup.InitControl(4, 2)

        Me.DrftArvlAft.InitControl(4, 2)
        Me.DrftArvlFor.InitControl(4, 2)

        Me.DrftDepFor.InitControl(4, 2)
        Me.DrftDepAft.InitControl(4, 2)

        Me.SOFGroup.Appearance.BackColor = My.Settings.MainColor
        Me.RobGroup.Appearance.BackColor = My.Settings.MainColor
        Me.DrftGroup.Appearance.BackColor = My.Settings.MainColor
        Me.UltraTabControl1.Appearance.BackColor = My.Settings.MainColor
        Me.UltraTabControl1.BackColor = My.Settings.MainColor
        Me.GroupBoxRob.Appearance.BackColor = My.Settings.MainColor

        If Me.Status = FormStatus.EditSoft Then
            Drs = TBSOf.Select("ID = '" & ID.ToString & "'")
            SetDocument()
        End If


        ChangeControlColor(Me.SOFGroup, UltraLabel10.GetType.ToString, My.Settings.MainColor, My.Settings.LableForeColor)
        ChangeControlColor(Me.RobGroup, UltraLabel10.GetType.ToString, My.Settings.MainColor, My.Settings.LableForeColor)
        ChangeControlColor(Me.DrftGroup, UltraLabel10.GetType.ToString, My.Settings.MainColor, My.Settings.LableForeColor)
        ChangeControlColor(Me.DrftGroup, UltraLabel10.GetType.ToString, My.Settings.MainColor, My.Settings.LableForeColor)

    End Sub

    Public Sub New(ByVal Status As FormStatus, ByRef TBSOF As DataTable, ByVal VoyageID As Guid, ByVal ID As Guid)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.Status = Status
        Me.TBSOf = TBSOF
        Me.ID = ID
        Me.VoyageID = VoyageID

    End Sub

    Private Sub SetDocument()

        With Me

            .Port.PortCode = Drs(0).Item("Port")
            .Arrival.DateValue = IIf(IsDBNull(Drs(0).Item("Arrival")), "", Drs(0).Item("Arrival").ToString)
            .Pilot.DateValue = IIf(IsDBNull(Drs(0).Item("Pilot")), "", Drs(0).Item("Pilot").ToString)
            .ETA.DateValue = IIf(IsDBNull(Drs(0).Item("ETA")), "", Drs(0).Item("ETA").ToString)
            .Berthed.DateValue = IIf(IsDBNull(Drs(0).Item("Berthed")), "", Drs(0).Item("Berthed").ToString)
            .Jetty.CtrlValue = Double.Parse(NullToValue(Drs(0).Item("Jetty"), 0).ToString)

            .FreePraGrnt.DateValue = IIf(IsDBNull(Drs(0).Item("FreePraGrnt")), "", Drs(0).Item("FreePraGrnt").ToString)
            .CustomInspect.DateValue = IIf(IsDBNull(Drs(0).Item("CustomInspect")), "", Drs(0).Item("CustomInspect").ToString)
            .GangOnBoard.DateValue = IIf(IsDBNull(Drs(0).Item("GangOnBoard")), "", Drs(0).Item("GangOnBoard").ToString)
            .DschCmnc.DateValue = IIf(IsDBNull(Drs(0).Item("DschCmnc")), "", Drs(0).Item("DschCmnc").ToString)
            .DschCmpl.DateValue = IIf(IsDBNull(Drs(0).Item("DschCmpl")), "", Drs(0).Item("DschCmpl").ToString)
            .LoadCmnc.DateValue = IIf(IsDBNull(Drs(0).Item("LoadCmnc")), "", Drs(0).Item("LoadCmnc").ToString)
            .LoadCmpl.DateValue = IIf(IsDBNull(Drs(0).Item("LoadCmpl")), "", Drs(0).Item("LoadCmpl").ToString)
            .DocOnBoard.DateValue = IIf(IsDBNull(Drs(0).Item("DocOnBoard")), "", Drs(0).Item("DocOnBoard").ToString)
            .PClear.DateValue = IIf(IsDBNull(Drs(0).Item("PClear")), "", Drs(0).Item("PClear").ToString)
            .Unberthed.DateValue = IIf(IsDBNull(Drs(0).Item("Unberthed")), "", Drs(0).Item("Unberthed").ToString)
            .Sailed.DateValue = IIf(IsDBNull(Drs(0).Item("Sailed")), "", Drs(0).Item("Sailed").ToString)
            .NextPort.PortCode = NullToValue(Drs(0).Item("NextPort"), "")
            .ETANextPort.DateValue = IIf(IsDBNull(Drs(0).Item("ETANextPort")), "", Drs(0).Item("ETANextPort").ToString)

            Try
                .IFOArrival.GnrlNum.Value = IIf(IsDBNull(Drs(0).Item("IFOArrival")), 0, Double.Parse(Drs(0).Item("IFOArrival")))
                .MDOArrival.GnrlNum.Value = IIf(IsDBNull(Drs(0).Item("MDOArrival")), 0, Double.Parse(Drs(0).Item("MDOArrival")))
                .FWaterArrival.GnrlNum.Value = IIf(IsDBNull(Drs(0).Item("MDOArrival")), 0, Double.Parse(Drs(0).Item("MDOArrival")))

                .IFOSup.GnrlNum.Value = IIf(IsDBNull(Drs(0).Item("IFOSup")), 0, Double.Parse(Drs(0).Item("IFOSup")))
                .MDOSup.GnrlNum.Value = IIf(IsDBNull(Drs(0).Item("MDOSup")), 0, Double.Parse(Drs(0).Item("MDOSup")))
                .FWaterSup.GnrlNum.Value = IIf(IsDBNull(Drs(0).Item("FWaterSup")), 0, Double.Parse(Drs(0).Item("FWaterSup")))

                .IFODep.GnrlNum.Value = IIf(IsDBNull(Drs(0).Item("IFODep")), 0, Double.Parse(Drs(0).Item("IFODep")))
                .MDOSup.GnrlNum.Value = IIf(IsDBNull(Drs(0).Item("MDOSup")), 0, Double.Parse(Drs(0).Item("MDOSup")))
                .FWaterDep.GnrlNum.Value = IIf(IsDBNull(Drs(0).Item("FWaterDep")), 0, Double.Parse(Drs(0).Item("FWaterDep")))
            Catch ex As Exception

            End Try

            sSql = "select DjwazNo from TB_SOF_DJNo where sof_id = '" & Drs(0).Item("ID").ToString & "' and line = '" & CurrentShippingLine & "'"
            TableBySql(sSql, TBct, IResult)
            If TBct.Rows.Count > 0 Then

                .DjwazNo.TextValue = NullToValue(TBct.Rows(0).Item("DjwazNo"), "")

            End If



        End With

    End Sub

    Private Sub ConfirmDocument()

        Dim Dr As DataRow
        Dim sSql As String
        Dim lResult As Boolean
        Dim Cnn As New SqlConnection(My.Settings.DSN)
        If Me.Port.IsValidPort = False Then
            MsgBoxGeneral("Invalid Port !", "Error")
            Exit Sub
        End If

        If Status = FormStatus.NewSof Then
            Dr = TBSOf.NewRow
            Dr("ID") = Guid.NewGuid
            Dr("VoyageID") = VoyageID
        Else
            Dr = Drs(0)
        End If

        Dr("Port") = Me.Port.PortCode
        Dr("Arrival") = NotingToNull(Me.Arrival.DateValue)
        Dr("Pilot") = NotingToNull(Me.Pilot.DateValue)
        Dr("ETA") = NotingToNull(Me.ETA.DateValue)
        Dr("Berthed") = NotingToNull(Me.Berthed.DateValue)
        Dr("Jetty") = Int16.Parse(Me.Jetty.GnrlNum.Value)
        Dr("FreePraGrnt") = NotingToNull(Me.FreePraGrnt.DateValue)
        Dr("CustomInspect") = NotingToNull(Me.CustomInspect.DateValue)
        Dr("GangOnBoard") = NotingToNull(Me.GangOnBoard.DateValue)
        Dr("DschCmnc") = NotingToNull(Me.DschCmnc.DateValue)
        Dr("DschCmpl") = NotingToNull(Me.DschCmpl.DateValue)
        Dr("LoadCmnc") = NotingToNull(Me.LoadCmnc.DateValue)
        Dr("LoadCmpl") = NotingToNull(Me.LoadCmpl.DateValue)
        Dr("DocOnBoard") = NotingToNull(Me.DocOnBoard.DateValue)
        Dr("PClear") = NotingToNull(Me.PClear.DateValue)
        Dr("Unberthed") = NotingToNull(Me.Unberthed.DateValue)
        Dr("Sailed") = NotingToNull(Me.Sailed.DateValue)
        Dr("NextPort") = Me.NextPort.PortCode
        Dr("ETANextPort") = NotingToNull(Me.ETANextPort.DateValue)

        Dr("IFOArrival") = Double.Parse(Me.IFOArrival.GnrlNum.Value)
        Dr("MDOArrival") = Double.Parse(Me.MDOArrival.GnrlNum.Value)
        Dr("FWaterArrival") = Double.Parse(Me.MDOArrival.GnrlNum.Value)

        Dr("IFOSup") = Double.Parse(Me.IFOSup.GnrlNum.Value)
        Dr("MDOSup") = Double.Parse(Me.MDOSup.GnrlNum.Value)
        Dr("FWaterSup") = Double.Parse(Me.FWaterSup.GnrlNum.Value)

        Dr("IFODep") = Double.Parse(Me.IFODep.GnrlNum.Value)
        Dr("MDOSup") = Double.Parse(Me.MDOSup.GnrlNum.Value)
        Dr("FWaterDep") = Double.Parse(Me.FWaterDep.GnrlNum.Value)
        Dr("DjwazNo") = Me.DjwazNo.TextValue


        If Status = FormStatus.NewSof Then
            TBSOf.Rows.Add(Dr)
        End If

        Cnn.Open()
        Cmd = New SqlCommand()
        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.Connection = Cnn
        Cmd.CommandType = CommandType.Text

      

        If Status = FormStatus.NewSof Then
            Cmd.CommandText = "INSERT into TB_SOF_DJNo (id , SOF_ID , Line , DjwazNo) values(@ID , @SOF_ID, @Line ,  @DjwazNo)"
            Cmd.Parameters.Add("@ID", SqlDbType.VarChar, 36)
            Cmd.Parameters.Add("@SOF_ID", SqlDbType.VarChar, 36)
            Cmd.Parameters.Add("@Line", SqlDbType.VarChar, 10)
            Cmd.Parameters.Add("@DjwazNo", SqlDbType.VarChar, 150)

            Cmd.Parameters("@ID").Value = System.Guid.NewGuid.ToString
            Cmd.Parameters("@SOF_ID").Value = Dr("ID").ToString()
            Cmd.Parameters("@Line").Value = CurrentShippingLine
            Cmd.Parameters("@DjwazNo").Value = Me.DjwazNo.TextValue

        Else

            sSql = "select DjwazNo from TB_SOF_DJNo where sof_id = '" & Drs(0).Item("ID").ToString & "' and line = '" & CurrentShippingLine & "'"
            TableBySql(sSql, TBct, IResult)
            If TBct.Rows.Count > 0 Then

                sSql = "update TB_SOF_DJNo set DjwazNo = '" & Me.DjwazNo.TextValue & "' where sof_id = '" & Dr("ID").ToString() & "' and line = '" & CurrentShippingLine & "'"
                ExecuteSqlOnTcts(sSql)
            Else
                Cmd.CommandText = "INSERT into TB_SOF_DJNo (id , SOF_ID , Line , DjwazNo) values(@ID , @SOF_ID, @Line ,  @DjwazNo)"
                Cmd.Parameters.Add("@ID", SqlDbType.VarChar, 36)
                Cmd.Parameters.Add("@SOF_ID", SqlDbType.VarChar, 36)
                Cmd.Parameters.Add("@Line", SqlDbType.VarChar, 10)
                Cmd.Parameters.Add("@DjwazNo", SqlDbType.VarChar, 150)

                Cmd.Parameters("@ID").Value = System.Guid.NewGuid.ToString
                Cmd.Parameters("@SOF_ID").Value = Dr("ID").ToString()
                Cmd.Parameters("@Line").Value = CurrentShippingLine
                Cmd.Parameters("@DjwazNo").Value = Me.DjwazNo.TextValue
            End If
        End If

        Try
            IResult = Cmd.ExecuteNonQuery()
            lResult = True
        Catch ex As Exception
            lResult = False
            MsgBox(ex.ToString)
        Finally
            Cnn.Close()
        End Try
        Me.Close()

    End Sub
    Private Sub ExecuteSqlOnTcts(ByVal sSql As String)
     
        Cnn.ConnectionString = My.Settings.DSN

        If Cnn.State = ConnectionState.Closed Then

            Cnn.Open()
        End If
        Cmd.CommandType = CommandType.Text
        Cmd.CommandText = sSql
        Cmd.Connection = Cnn
        Cmd.ExecuteNonQuery()

    End Sub



    Private Sub ButtonCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancel.Click

        Me.Close()
    End Sub

    Private Sub ButtonApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonApply.Click
        ConfirmDocument()
        Me.Close()
    End Sub

    Private Function NotingToNull(ByVal Obj As Object) As Object

        If Obj Is Nothing Then
            Return DBNull.Value
        Else
            Return Obj
        End If

    End Function


    Private Sub UltraLabel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraLabel1.Click

    End Sub
End Class