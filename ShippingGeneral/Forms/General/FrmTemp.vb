Imports System.Windows.Forms

Public Class FrmTemp

    Dim Dr As DataRow
    Dim CntrID As Guid
    Dim TB As DataTable
    Dim Cntrs As DataTable
    Dim Master As UserBlsCntrs
    Dim Master2 As UserBlsCntrsPkg

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal CntrID As Guid, ByRef TB As DataTable, ByVal Cntrs As DataTable, ByRef CntrMaster As UserBlsCntrs)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Me.TB = TB
        Me.CntrID = CntrID
        Me.Cntrs = Cntrs
        Me.TemperatureBase.InitControl("TP", UserComboCode.ShowCoumn.Meaning)
        'Me.TempMin.InitControl(5, 2)
        'Me.TempMax.InitControl(5, 2)
        Me.Master = CntrMaster
        SetDocument()

    End Sub
    Public Sub New(ByVal CntrID As Guid, ByRef TB As DataTable, ByVal Cntrs As DataTable, ByRef CntrMaster As UserBlsCntrsPkg)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Me.TB = TB
        Me.CntrID = CntrID
        Me.Cntrs = Cntrs
        Me.TemperatureBase.InitControl("TP", UserComboCode.ShowCoumn.Meaning)
        'Me.TempMin.InitControl(5, 2)
        'Me.TempMax.InitControl(5, 2)
        Me.Master2 = CntrMaster
        SetDocument()

    End Sub
    Private Sub GetDocument(ByVal ToAll As Boolean)

        Dim Dv As DataView
        Dim Dr As DataRow
        Dim CnDr As DataRow
        Dim nCount As Long = 0

        If ToAll = False Then
            If Not TB Is Nothing Then
                Dv = New DataView(TB, "CntrID = '" & CntrID.ToString & "'", "", DataViewRowState.CurrentRows)
                nCount = Dv.Count
            End If
            If nCount = 0 Then
                Dr = TB.NewRow
                Dr("ID") = Guid.NewGuid
                Dr("CntrID") = CntrID
                Dr("TemperatureBase") = Me.TemperatureBase.Code
                Dr("TempMax") = Me.TempMax.Value
                Dr("TempMin") = Me.TempMin.Value
                TB.Rows.Add(Dr)
            Else
                Dv.Item(0).Item("TemperatureBase") = Me.TemperatureBase.Code
                Dv.Item(0).Item("TempMax") = Me.TempMax.Value
                Dv.Item(0).Item("TempMin") = Me.TempMin.Value
            End If
        Else
            For Each CnDr In Cntrs.Rows
                Dv = New DataView(TB, "CntrID = '" & CnDr("Id").ToString & "'", "", DataViewRowState.CurrentRows)
                If Dv.Count = 0 Then
                    Dr = TB.NewRow
                    Dr("ID") = Guid.NewGuid
                    Dr("CntrID") = CnDr("ID")
                    Dr("TemperatureBase") = Me.TemperatureBase.Code
                    Dr("TempMax") = Me.TempMax.Value
                    Dr("TempMin") = Me.TempMin.Value
                    TB.Rows.Add(Dr)
                Else
                    Dv.Item(0).Item("TemperatureBase") = Me.TemperatureBase.Code
                    Dv.Item(0).Item("TempMax") = Me.TempMax.Value
                    Dv.Item(0).Item("TempMin") = Me.TempMin.Value
                End If

            Next
        End If

    End Sub

    Private Sub SetDocument()

        Dim Dv As DataView
        If Not TB Is Nothing Then
            Dv = New DataView(TB, "CntrID = '" & CntrID.ToString & "'", "", DataViewRowState.CurrentRows)

            If Dv.Count > 0 Then
                Me.TemperatureBase.Code = IIf(IsDBNull(Dv.Item(0).Item("TemperatureBase")) = True, "", Dv.Item(0).Item("TemperatureBase"))
                Me.TempMax.Value = IIf(IsDBNull(Dv.Item(0).Item("TempMax")) = True, "", Dv.Item(0).Item("TempMax"))
                Me.TempMin.Value = IIf(IsDBNull(Dv.Item(0).Item("TempMin")) = True, "", Dv.Item(0).Item("TempMin"))
            
            End If
        End If
    End Sub

    Private Function Checking() As Boolean
        If Me.TempMin.Value = 0 Or Me.TempMax.Value = 0 Or TemperatureBase.Code = "" Then
            MsgBoxValidateFaild()
            Return False
        Else
            Return True
        End If
    End Function
    Private Sub DeleteDoc(ByVal DelAll As Boolean)

        Dim Dr As DataRow
        Dim Dv As DataView
        If DelAll Then
            For Each Dr In TB.Rows
                Dr.Delete()
            Next
        Else
            Dv = New DataView(TB, "CntrID = '" & CntrID.ToString & "'", "", DataViewRowState.CurrentRows)
            If Dv.Count > 0 Then
                Dv.Item(0).Delete()
            End If
        End If

    End Sub

    Private Sub ToolbarsManager_ToolClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinToolbars.ToolClickEventArgs) Handles ToolbarsManager.ToolClick

        Select Case e.Tool.Key

            Case "Apply"
                If Checking() = True Then
                    If MsgBoxUpdate() = Windows.Forms.DialogResult.Yes Then
                        GetDocument(False)
                        Master.Colorized()
                        Me.Close()
                    End If
                End If
                Me.Close()

            Case "To All"
                If Checking() = True Then
                    If MsgBoxUpdate() = Windows.Forms.DialogResult.Yes Then
                        GetDocument(True)
                        Master.Colorized()
                        Me.Close()
                    End If
                End If

            Case "Delete"
                DeleteDoc(False)
                Master.Colorized()
                Me.Close()

            Case "Delete All"
                DeleteDoc(True)
                Master.Colorized()
                Me.Close()

            Case "Return"
                Master.Colorized()
                Me.Close()

        End Select

    End Sub


End Class

