Imports OrmLib
Imports ShippingBiz

Public Class UserBlsGoods

    Public Sub SetDocument(ByVal Dr As DataRow)

        Me.TTLCBM.GnrlNum.Value = IIf(IsDBNull(Dr("TTLCBM")), 0, Dr("TTLCBM"))
        Me.TTLNET.GnrlNum.Value = IIf(IsDBNull(Dr("TTLNET")), 0, Dr("TTLNET"))
        Me.TTLPKGS.GnrlNum.Value = IIf(IsDBNull(Dr("TTLPKGS")), 0, Dr("TTLPKGS"))
        Me.TTW.GnrlNum.Value = IIf(IsDBNull(Dr("TTW")), 0, Dr("TTW"))
        Me.TGW.GnrlNum.Value = IIf(IsDBNull(Dr("TGW")), 0, Dr("TGW"))
        Me.MainCom.TextValue = IIf(IsDBNull(Dr("MainCom")), "", Dr("MainCom"))
        Me.Goods.TextValue = IIf(IsDBNull(Dr("Goods")), "", Dr("Goods"))
        Me.Marks.TextValue = IIf(IsDBNull(Dr("Marks")), "", Dr("Marks"))

    End Sub

    Public Sub getDocument(ByRef Dr As DataRow)

        If Dr.RowState <> DataRowState.Deleted Then
            If Changed = True Then
                Dr("TTLCBM") = Me.TTLCBM.GnrlNum.Value
                Dr("TTLNET") = Me.TTLNET.GnrlNum.Value
                Dr("TTLPKGS") = Me.TTLPKGS.GnrlNum.Value
                Dr("TGW") = Me.TGW.GnrlNum.Value
                Dr("TTW") = Me.TTW.GnrlNum.Value
                Dr("MainCom") = Me.MainCom.TextValue
                Dr("Goods") = Me.Goods.TextValue
                Dr("Marks") = Me.Marks.TextValue
            End If
        End If

    End Sub

    Public ReadOnly Property Changed() As Boolean
        Get
            If Me.TTLCBM.Changed Or Me.TTLNET.Changed Or _
               Me.TTLPKGS.Changed Or Me.TGW.Changed Or _
               Me.MainCom.Changed Or Me.Goods.Changed Or _
               Me.Marks.Changed Then
                Return True
            Else
                Return False
            End If
        End Get
    End Property

    Public Sub InitControl()
        Me.TTLCBM.InitControl(7, 2)
        Me.TTLNET.InitControl(7, 2)
        Me.TTLPKGS.InitControl(7, 0)
        Me.TTW.InitControl(7, 0)
        Me.TGW.InitControl(7, 2)
    End Sub

    Public Sub Checking(ByRef TB As DataTable, ByVal CnsTB As DataTable)

        If Me.TTLCBM.GnrlNum.Value = 0 Then
            AddRowToErrorTable(TB, "Goods", "C.B.M. Is Zero !", ErrMsgtype.Warning)
        End If


       
        If GetSummaryFromDatatable(Infragistics.Win.UltraWinGrid.SummaryType.Count, CnsTB, "GW", "") = 0 Then

            If Me.TGW.GnrlNum.Value = 0 Then
                AddRowToErrorTable(TB, "Goods", "Gross Weight Is Zero !", ErrMsgtype.Err)
            End If


            If Me.TTW.GnrlNum.Value = 0 Then
                AddRowToErrorTable(TB, "Goods", "Tare Weight Is Zero !", ErrMsgtype.Err)
            End If

            If Me.TTLNET.GnrlNum.Value = 0 Then
                AddRowToErrorTable(TB, "Goods", "NET Weight Is Zero !", ErrMsgtype.Warning)
            End If

            If Me.TTLPKGS.GnrlNum.Value = 0 Then
                AddRowToErrorTable(TB, "Goods", "Total Packages Is Zero !", ErrMsgtype.Err)
            End If
        End If

        'If Trim(Me.MainCom.TextValue) = "" Then
        '    AddRowToErrorTable(TB, "Goods", "Main Commedity Is Blank !", ErrMsgtype.Err)
        'End If

        If Trim(Me.Goods.TextValue) = "" Then
            AddRowToErrorTable(TB, "Goods", "Description Of Goods Is Blank !", ErrMsgtype.Err)
        End If

        If Trim(Me.Marks.TextValue) = "" Then
            AddRowToErrorTable(TB, "Goods", "Marks & No. Is Blank !", ErrMsgtype.Warning)
        End If

    End Sub

    Private Sub Goods_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Goods.Enter
        'If Me.Goods.TextValue = "" Then
        '    Me.Goods.TextValue = "SHIPPER'S LOAD, STOW, COUNT AND SEALED " & vbCrLf & "SAID TO CONTAIN "
        'End If
    End Sub

    Private Sub Goods_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Goods.Load

    End Sub
End Class
