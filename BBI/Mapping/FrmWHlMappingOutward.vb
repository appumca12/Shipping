Imports ShippingBiz
Imports OrmLib
Imports Infragistics.Win.UltraWinGrid

Public Class FrmWHlMappingOutward

    Private DM As DataManager
    Private Sub FrmWHlMappingOutward_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Vessel.InitControl(My.Settings.TextBackColor)
        Me.Voyage.InitControl(My.Settings.TextBackColor, Me.Vessel)
        Me.PayAt.ComboGnrl.Items.Clear()
        Me.PayAt.ComboGnrl.DisplayMember = "Key"
        Me.PayAt.ComboGnrl.ValueMember = "Value"
        Me.PayAt.ComboGnrl.Items.Insert(0, "Select...")
        Me.PayAt.ComboGnrl.Items.Insert(1, "IRTHR")
        Me.PayAt.ComboGnrl.Items.Insert(2, "IRBND")
        Me.PayAt.ComboGnrl.SelectedIndex = 2
        Me.PayAt.ComboGnrl.Sorted = True
    End Sub

    Private Sub MenuItem_CustomDeSelectAll() Handles MenuItem.CustomDeSelectAll

        Dim Row As UltraGridRow
        If Me.GridResult.Rows.Count > 0 Then
            For Each Row In Me.GridResult.Rows
                Row.Cells("Select").Value = False
            Next
            GridResult.UpdateData()
        End If
    End Sub

    Private Sub MenuItem_CustomPickupClick() Handles MenuItem.CustomPickupClick


        Dim NewDr As DataRow
        Dim BLS As TB_OutwardBLSCollection
        Dim BL As TB_OutwardBLS

        DM = New DataManager(My.Settings.DSN)
        DM.QueryCriteria.Clear()
        DM.QueryCriteria.And(JoinPath.TB_OutwardBLS.Columns.VoyageID, Me.Voyage.VoyageID, MatchType.Exact)
        BLS = DM.GetTB_OutwardBLSCollection()

        DsForm.Tables(0).Clear()
        DsForm.Tables(1).Clear()
        DsForm.AcceptChanges()


        If BLS Is Nothing Then
            MsgBox(" No Any B/L !")
            Exit Sub
        End If

        For Each BL In BLS
            NewDr = DsForm.Tables(0).NewRow
            NewDr("ID") = BL.ID
            NewDr("BLNO") = BL.BlNo
            NewDr("POL") = BL.POD
            NewDr("POD") = BL.POD
            NewDr("Select") = True
            DsForm.Tables(0).Rows.Add(NewDr)
        Next
 
    End Sub
     Private Sub MenuItem_CustomSaveClick() Handles MenuItem.CustomSaveClick

        Dim Dialog As New SaveFileDialog
        Dim Gen As WHLEDIGen
        Dim Voy As TB_Voyage

        'If PayAt.ComboGnrl.Text = "Select..." Then
        '    MsgBox("Please select Pay At office.")
        '    Exit Sub
        'End If

        DM.QueryCriteria.Clear()
        DM.QueryCriteria.And(JoinPath.TB_Voyage.Columns.ID, Me.Voyage.VoyageID, MatchType.Exact)
        Voy = DM.GetTB_Voyage


        Me.GridResult.UpdateData()

        If DsForm.Tables(0).Select("Select = true").Length = 0 Then
            MsgBox("No any B/L")
            Exit Sub
        End If

        Dialog.Filter = "EDI Files (*.dat)|*.dat|txt files (*.txt)|*.txt|All files (*.*)|*.*"
        Dialog.ShowDialog()

 
        If Dialog.FileName = "" Then
            Exit Sub
        End If
        Gen = New WHLEDIGen(Dialog.FileName)
        Gen.GenerateWHLFileByList(DsForm, Voy.TFCCode)
 

    End Sub


    Private Sub MenuItem_CustomSelectAll() Handles MenuItem.CustomSelectAll
        If Me.GridResult.Rows.Count > 0 Then
            For Each Row In Me.GridResult.Rows
                Row.Cells("Select").Value = True
            Next
            GridResult.UpdateData()
        End If

    End Sub
End Class