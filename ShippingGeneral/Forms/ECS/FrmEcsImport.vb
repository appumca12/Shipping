Imports OrmLib
Imports ShippingBiz
Imports System.Data.SqlClient
Imports System.Data.SqlTypes

Public Class FrmEcsImport

    Private Dm As DataManager
    Private Sub Vessel_CustomVesselChanged() Handles Vessel.CustomVesselChanged
        Me.DataSetForm.Tables("ListOfCntrs").Clear()
        Me.Voyage.FillVoyage(Vessel.VesselID)
    End Sub

    Private Sub FrmEcsImport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Vessel.InitControl(Me.GroupBox.Appearance.BackColor)
        Me.Voyage.InitControl(Me.GroupBox.Appearance.BackColor)
        Me.Depot.InitControl("DP", UserComboCode.ShowCoumn.Meaning)
        Me.DschCmpl.InitControl(True, False)
        Me.ToLine.InitControl(True, False)
        GridContainers.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns

        Me.FillPanel.BackColor = My.Settings.MainColor
        ChangeControlColor(Me, UltraLabel1.GetType.ToString, My.Settings.MainColor, My.Settings.LableForeColor)
        '     Me.Toolbars.Toolbars("FormCaption").Settings.Appearance.BackColor = My.Settings.MainColor
        '    Me.Toolbars.Toolbars("FormCaption").Settings.Appearance.BackColor2 = My.Settings.MainColor2
        Me.Text = "Import E.C.S. Data"



    End Sub

    Private Sub SetDocument()

        Dim Prm As SqlClient.SqlParameter
        Dim arrayParams As New ArrayList
        Dim Dr As DataRow
        Dim Drs() As DataRow

        Dim DS As New DataSet
        Dim R As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim Cnn As New SqlConnection(My.Settings.DSN)
        Me.DataSetForm.Tables("ListOfCntrs").Clear()

        If ValidateData() = False Then
            Exit Sub
        End If

        If Me.Voyage.VoyageID.ToString = "" Then
            MsgBoxGeneral("No Valid Voyage !", "Error")
            Exit Sub
        End If

        Dm = New DataManager(My.Settings.DSN)

        Prm = New SqlClient.SqlParameter("Line", SqlDbType.VarChar, 10, ParameterDirection.Input)
        Prm.Value = CurrentShippingLine
        arrayParams.Add(Prm)

        Prm = New SqlClient.SqlParameter("VoyageID", SqlDbType.Char, 36, ParameterDirection.Input)
        Prm.Value = Me.Voyage.VoyageID.ToString
        arrayParams.Add(Prm)
 
        ' Ds = Dm.ExecuteProcedure("SP_EcsImportDataGetList", CType(arrayParams.ToArray(GetType(SqlParameter)), SqlParameter()))


        Cmd = New SqlCommand("SP_EcsImportDataGetList")
        Cnn = New SqlConnection(My.Settings.DSN)
        Cnn.Open()
        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.Parameters.AddWithValue("@Line", CurrentShippingLine)
        Cmd.Parameters.AddWithValue("@VoyageID", Me.Voyage.VoyageID.ToString)

        Cmd.Connection = Cnn
        DA.SelectCommand = Cmd
        Cmd.CommandTimeout = 5000
        DA.Fill(Ds)

        If Ds.Tables(0).Rows.Count = 0 Then
            MsgBoxGeneral("No Any Containers !", "Error")
            Exit Sub
        End If

        Me.DataSetForm.Tables("ListOfCntrs").Clear()
        Me.DataSetForm.Tables("ListOfCntrs").Merge(Ds.Tables(0))

        For Each Dr In Me.DataSetForm.Tables("ListOfCntrs").Rows
            Dr("DschCmpl") = Me.DschCmpl.GnrlDate.Value
            Dr("ToLine") = Me.ToLine.GnrlDate.Value
        Next

        For Each R In GridContainers.Rows
            Select Case Trim(R.Cells("CurrentStatus").Value)
                Case "Ready For Import"
                    R.Appearance.ForeColor = Color.Black
                Case "Exists Under Other Voyage"
                    R.Appearance.ForeColor = Color.Magenta
                Case "Already Exist Under This Voyage"
                    R.Appearance.ForeColor = Color.Red
            End Select
        Next

        Drs = Me.DataSetForm.Tables("ListOfCntrs").Select("CnSize = '20'")
        Me.Lbl20.Text = "TOTAL 20':" & Drs.Length.ToString

        Drs = Me.DataSetForm.Tables("ListOfCntrs").Select("CnSize = '40'")
        Me.Lbl40.Text = "TOTAL 40':" & Drs.Length.ToString

        Drs = Me.DataSetForm.Tables("ListOfCntrs").Select("CnSize = '45'")
        Me.Lbl45.Text = "TOTAL 45':" & Drs.Length.ToString




    End Sub

    Private Function IsValid() As Boolean

        Dim GR As Infragistics.Win.UltraWinGrid.UltraGridRow

        If Me.GridContainers.Rows.Count = 0 Then
            MsgBoxGeneral("No Any Container !", "Error")
            Return False
        End If

        For Each GR In GridContainers.Rows
            If GR.Cells("DschCmpl").ToString = "" Then
                MsgBoxGeneral("Some Container's Discharge Date Is Empty !", "Error")
                Return False
            End If
        Next
        Return True

    End Function

    Private Sub SaveDocument()

        Dim GR As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim Moves As DataTable
        Dim Ecs As DataTable
        Dim Dr As DataRow
        Dim ID As Guid
        Dim LogDataSet As New DataSet
        Dim Drs() As DataRow
        Dim Status As String

        Dm = New DataManager(My.Settings.DSN)
        Ecs = Dm.DataSet.Tables("TB_EcsContainers")
        Moves = Dm.DataSet.Tables("TB_EcsMoves")

        For Each GR In GridContainers.Rows

            If Trim(GR.Cells("CurrentStatus").Value) = "Ready For Import" And GR.Cells("Sel").Value = True Then
                Dr = Ecs.NewRow
                ID = Guid.NewGuid
                Dr("ID") = ID
                Dr("InVoyageID") = Me.Voyage.VoyageID
                Dr("Line") = CurrentShippingLine
                Dr("CntrNo") = GR.Cells("CntrNo").Value
                Dr("CnSize") = GR.Cells("CnSize").Value
                Dr("CnType") = GR.Cells("CnType").Value
                Dr("DischargeTo") = GR.Cells("POD").Value
                Dr("InStatus") = Mid(GR.Cells("FLE").Value, 1, 1)
                Dr("LastDepot") = Me.Depot.Code
                Dr("LastStatusDate") = GR.Cells("DschCmpl").Value

                If GR.Cells("SOC").Value = "Y" Then
                    If GR.Cells("FLE").Text = "FULL" Then
                        Status = "TV"
                    Else
                        Status = "MD"
                    End If
                Else
                    If GR.Cells("FLE").Text = "FULL" Then
                        If GR.Cells("LclCount").Value = 1 Then
                            Status = "FV"
                        Else
                            Status = "CV"
                        End If
                    Else
                        Status = "MA"
                    End If
                End If
                Dr("LastStatus") = Status
                Dr("IsTerminate") = 0
                Dr("SOC") = GR.Cells("SOC").Value
                Ecs.Rows.Add(Dr)
                Dr = Moves.NewRow
                Dr("ID") = Guid.NewGuid
                Dr("CntrID") = ID
                Dr("Status") = Status
                Dr("StatusDate") = GR.Cells("DschCmpl").Value
                Dr("StatusDateToLine") = GR.Cells("ToLine").Value
                Dr("Depot") = Me.Depot.Code
                Dr("Remarks") = "Imported"
                Moves.Rows.Add(Dr)
            End If
        Next

        Try
            LogDataSet = Dm.DataSet.Copy
            Dm.CommitAll()
            GenerateLog(LogDataSet)
            MsgBoxSaveSuccessful()
        Catch ex As Exception
            MsgBoxSaveFailed()
        End Try

        SetDocument()

    End Sub

    Private Function ValidateData() As Boolean

        Dim Ans As Boolean = True
        Dim PrivStatus As String = ""
        Dim aList As New ArrayList
        Dim aError As New ArrayList
        Dim nI As Long

        FormErrorProvider.Clear()

        If Me.ToLine.GnrlDate.Value Is Nothing Then
            aError.Add(Me.ToLine)
        End If

        If Me.DschCmpl.GnrlDate.Value Is Nothing Then
            aError.Add(Me.DschCmpl)
        End If

        If Me.Depot.Code = "" Then
            aError.Add(Me.Depot.Code)
        End If

        If Me.Voyage.VoyageID.ToString = "" Or Me.Voyage.VoyageID = Guid.Empty Then
            aError.Add(Me.Voyage)
        End If

        If aError.Count > 0 Then
            If aError.Count > 0 Then
                For nI = 0 To aError.Count - 1
                    Try
                        FormErrorProvider.SetError(aError(nI), "Data Requird")
                    Catch ex As Exception
                    End Try

                Next
                MsgBoxValidateFaild()
                Return False
            End If
        Else
            Return True
        End If

    End Function

    Private Sub ButtonSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSave.Click
        If IsValid() Then
            If MsgBoxUpdate() = Windows.Forms.DialogResult.Yes Then
                SaveDocument()
            End If
        End If
    End Sub

    Private Sub ButtonFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFind.Click
        SetDocument()
    End Sub
End Class