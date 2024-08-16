Imports System.Windows.Forms

Public Class FrmImco

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
        Me.IMDG.InitControl("HZ", UserComboCode.ShowCoumn.Meaning)
        Me.PackingGroup.InitControl("PZ", UserComboCode.ShowCoumn.Meaning)
        Me.PageNumber.InitControl(5, 0)
        Me.EMSNumber.SetLength(10)
        Me.UnNo.SetLength(10)
        Me.Master = CntrMaster
        Me.MarinePollutant.InitControl("YN", UserComboCode.ShowCoumn.Meaning)
        SetDocument()

    End Sub
    Public Sub New(ByVal CntrID As Guid, ByRef TB As DataTable, ByVal Cntrs As DataTable, ByRef CntrMaster As UserBlsCntrsPkg)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Me.TB = TB
        Me.CntrID = CntrID
        Me.Cntrs = Cntrs
        Me.IMDG.InitControl("HZ", UserComboCode.ShowCoumn.Meaning)
        Me.PackingGroup.InitControl("PZ", UserComboCode.ShowCoumn.Meaning)
        Me.PageNumber.InitControl(5, 0)
        Me.EMSNumber.SetLength(10)
        Me.UnNo.SetLength(10)
        Me.MarinePollutant.InitControl("YN", UserComboCode.ShowCoumn.Meaning)
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
                Dr("IMDGCode") = Me.IMDG.Code
                Dr("PakingGroup") = Me.PackingGroup.Code
                Dr("FlashPoint") = Me.FlashPoint.GnrlNum.Value
                Dr("EMSNumber") = Val(Me.EMSNumber.TextValue)
                Dr("PageNumber") = Me.PageNumber.GnrlNum.Value
                Dr("UNNO") = Me.UnNo.TextValue
                Dr("SubsidaryHazard") = Me.SubsidaryHazard.TextValue
                Dr("PSN") = Me.PSN.TextValue
                Dr("MarinePollutant") = Me.MarinePollutant.Code
                TB.Rows.Add(Dr)
            Else
                Dv.Item(0).Item("IMDGCode") = Me.IMDG.Code
                Dv.Item(0).Item("PakingGroup") = Me.PackingGroup.Code
                Dv.Item(0).Item("FlashPoint") = Me.FlashPoint.GnrlNum.Value
                Dv.Item(0).Item("EMSNumber") = Me.EMSNumber.TextValue
                Dv.Item(0).Item("PageNumber") = Me.PageNumber.GnrlNum.Value
                Dv.Item(0).Item("UNNO") = Me.UnNo.TextValue
                Dv.Item(0).Item("SubsidaryHazard") = Me.SubsidaryHazard.TextValue
                Dv.Item(0).Item("PSN") = Me.PSN.TextValue
                Dv.Item(0).Item("MarinePollutant") = Me.MarinePollutant.Code

            End If
        Else
            For Each CnDr In Cntrs.Rows
                Dv = New DataView(TB, "CntrID = '" & CnDr("Id").ToString & "'", "", DataViewRowState.CurrentRows)
                If Dv.Count = 0 Then
                    Dr = TB.NewRow
                    Dr("ID") = Guid.NewGuid
                    Dr("CntrID") = CnDr("ID")
                    Dr("IMDGCode") = Me.IMDG.Code
                    Dr("PakingGroup") = Me.PackingGroup.Code
                    Dr("FlashPoint") = Me.FlashPoint.GnrlNum.Value

                    Dr("EMSNumber") = Int32.Parse(Val(Me.EMSNumber.TextValue))
                    Dr("PageNumber") = Me.PageNumber.GnrlNum.Value
                    Dr("UNNO") = Me.UnNo.TextValue
                    Dr("SubsidaryHazard") = Me.SubsidaryHazard.TextValue
                    Dr("PSN") = Me.PSN.TextValue
                    Dr("MarinePollutant") = Me.MarinePollutant.Code
                    TB.Rows.Add(Dr)
                Else
                    Dv.Item(0).Item("IMDGCode") = Me.IMDG.Code
                    Dv.Item(0).Item("PakingGroup") = Me.PackingGroup.Code
                    Dv.Item(0).Item("FlashPoint") = Me.FlashPoint.GnrlNum.Value
                    Dv.Item(0).Item("EMSNumber") = Me.EMSNumber.TextValue
                    Dv.Item(0).Item("PageNumber") = Me.PageNumber.GnrlNum.Value
                    Dv.Item(0).Item("UNNO") = Me.UnNo.TextValue
                    Dv.Item(0).Item("SubsidaryHazard") = Me.SubsidaryHazard.TextValue
                    Dv.Item(0).Item("PSN") = Me.PSN.TextValue
                    Dv.Item(0).Item("MarinePollutant") = Me.MarinePollutant.Code
                End If

            Next
        End If

    End Sub

    Private Sub SetDocument()

        Dim Dv As DataView
        If Not TB Is Nothing Then
            Dv = New DataView(TB, "CntrID = '" & CntrID.ToString & "'", "", DataViewRowState.CurrentRows)

            If Dv.Count > 0 Then
                Me.IMDG.Code = IIf(IsDBNull(Dv.Item(0).Item("IMDGCode")) = True, "", Dv.Item(0).Item("IMDGCode"))
                Me.PackingGroup.Code = IIf(IsDBNull(Dv.Item(0).Item("PakingGroup")) = True, "", Dv.Item(0).Item("PakingGroup"))
                Me.FlashPoint.GnrlNum.Value = IIf(IsDBNull(Dv.Item(0).Item("FlashPoint")) = True, "", Dv.Item(0).Item("FlashPoint"))
                Me.EMSNumber.TextValue = IIf(IsDBNull(Dv.Item(0).Item("EMSNumber")) = True, "", Dv.Item(0).Item("EMSNumber"))
                Me.PageNumber.GnrlNum.Value = IIf(IsDBNull(Dv.Item(0).Item("PageNumber")) = True, "", Dv.Item(0).Item("PageNumber"))
                Me.UnNo.TextValue = IIf(IsDBNull(Dv.Item(0).Item("UNNO")) = True, "", Dv.Item(0).Item("UNNO"))
                Me.SubsidaryHazard.TextValue = IIf(IsDBNull(Dv.Item(0).Item("SubsidaryHazard")) = True, "", Dv.Item(0).Item("SubsidaryHazard"))
                Me.PSN.TextValue = IIf(IsDBNull(Dv.Item(0).Item("PSN")) = True, "", Dv.Item(0).Item("PSN"))
                Me.MarinePollutant.Code = IIf(IsDBNull(Dv.Item(0).Item("MarinePollutant")) = True, "", Dv.Item(0).Item("MarinePollutant"))

                ' Me.UnNo.TextValue = IIf(IsDBNull(Dv.Item(0).Item("UNNO")) = True, "", Dv.Item(0).Item("UNNO"))

            End If
        End If
    End Sub

    Private Function Checking() As Boolean
        If Me.IMDG.Code = "" Or Me.UnNo.TextValue = "" Then
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

    
    Private Sub FrmImco_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
       


    End Sub
End Class

