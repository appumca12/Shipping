Imports System.Windows.Forms
Imports OrmLib
Imports ShippingBiz
Imports Infragistics.Win.UltraWinGrid

Public Class FrmBookingCntrs
    Private dm As DataManager
    Private BLID As Guid
    Private Cntrs As New DataTable
    Private Tb As New DataTable
    Private FAns As Boolean
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

        Dim Dr As DataRow
        Dim NewDr As DataRow

        If ValidateForm() = True Then
            If MsgBoxUpdate() = Windows.Forms.DialogResult.Yes Then
                For Each Dr In Tb.Rows
                    If Dr("Sel") = True Then
                        NewDr = Cntrs.NewRow
                        NewDr("ID") = Guid.NewGuid
                        NewDr("BLID") = BLID
                        NewDr("CntrNo") = Dr("CntrNo")
                        NewDr("CnSize") = Dr("CnSize")
                        NewDr("CnType") = Dr("CnType")
                        If NullToValue(Dr("LastStatus"), "") = "EL" Or NullToValue(Dr("LastStatus"), "") = "MB" Then
                            NewDr("FLE") = "E"
                        Else
                            NewDr("FLE") = "F"
                        End If
                        NewDr("SOC") = "N"
                        NewDr("GW") = NullToValue(Dr("GW"), 0) 'Me.GW.GnrlNum.Value
                        NewDr("Net") = NullToValue(Dr("GW"), 0) ' Me.NW.GnrlNum.Value
                        NewDr("CBM") = 0
                        NewDr("NoOfPkgs") = NullToValue(Dr("NoOfPkgs"), 0)
                        NewDr("PackageType") = NullToValue(Dr("PackageType"), "OK")
                        NewDr("SealNo") = NullToValue(Dr("SealNo"), "")
                        If NullToValue(Dr("TW"), 0) = 0 Then
                            NewDr("TW") = IIf(NullToValue(Dr("CnSize"), "20") = "20", 2200, 4500)
                        Else
                            NewDr("TW") = Dr("TW")
                        End If
                        Cntrs.Rows.Add(NewDr)
                    End If
                Next
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()
            End If
        End If

    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Public Sub New(ByVal BLID As Guid, ByVal BookingID As Guid, ByRef Cntrs As DataTable)


        Dim Ds As New DataSet
        Dim Dr As DataRow
        Dim Dv As DataView

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        dm = New DataManager(My.Settings.DSN)
        Ds = StoredProcedures.SP_EcsContainersByBookingID(CurrentShippingLine, BookingID.ToString)

        If Ds.Tables.Count = 0 Then
            MsgBox("No any Data !")
            FAns = False
        Else
            Tb = Ds.Tables(0)
            For Each Dr In Tb.Rows
                Dv = New DataView(Cntrs, "CntrNo = '" & Dr("CntrNo") & "'", "", DataViewRowState.CurrentRows)
                If Dv.Count > 0 Then
                    Dr.Delete()
                End If
            Next
            Tb.AcceptChanges()
            Me.GridCntrs.DataSource = Ds.Tables(0)
            Me.BLID = BLID
            Me.Cntrs = Cntrs
            FAns = True
        End If


    End Sub

    Private Sub FrmBookingCntrs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Me.GW.InitControl(5, 2)
        'Me.CBM.InitControl(5, 2)
        'Me.NW.InitControl(5, 2)
        'Me.NoOfPkgs.InitControl(10, 0)
        'Me.PackageType.InitControl("PG", UserComboCode.ShowCoumn.Meaning)

    End Sub
    Private Function ValidateForm() As Boolean

        Dim Ans As Boolean = True
        Dim nI As Byte
        Dim aList As New ArrayList

        Me.GridCntrs.UpdateData()

        Return True

    End Function
    Private Sub ButtonSelect_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSelect.Click
        For Each R As UltraGridRow In Me.GridCntrs.Rows
            R.Cells("Sel").Value = True
        Next
        GridCntrs.UpdateData()

    End Sub

    Private Sub ButtonDeselect_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDeselect.Click

        For Each R As UltraGridRow In Me.GridCntrs.Rows
            R.Cells("Sel").Value = False
        Next
        GridCntrs.UpdateData()
    End Sub
    Public ReadOnly Property FormAns() As Boolean

        Get
            Return FAns
        End Get
    End Property


End Class
