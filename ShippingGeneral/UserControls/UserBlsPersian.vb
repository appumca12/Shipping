Imports OrmLib
Imports ShippingBiz

Public Class UserBlsPersian

    Public Sub SetDocument(ByVal Dr As DataRow)

        Me.FCnee.TextValue = IIf(IsDBNull(Dr("FCnee")), 0, Dr("FCnee"))
        Me.FGoods.TextValue = IIf(IsDBNull(Dr("FGoods")), 0, Dr("FGoods"))
        Me.FPkgs.TextValue = IIf(IsDBNull(Dr("FPkgs")), 0, Dr("FPkgs"))

    End Sub

    Public Sub getDocument(ByRef Dr As DataRow)

        If Dr.RowState <> DataRowState.Deleted Then
            If Changed = True Then
                Dr("FCnee") = Me.FCnee.TextValue
                Dr("FGoods") = Me.FGoods.TextValue
                Dr("FPkgs") = Me.FPkgs.TextValue
            End If
        End If

    End Sub

    Public ReadOnly Property Changed() As Boolean
        Get
            If Me.FCnee.Changed Or Me.FGoods.Changed Or _
              Me.FPkgs.Changed  Then
                Return True
            Else
                Return False
            End If
        End Get
    End Property

    Public Sub InitControl()

        Me.GroupBox.Appearance.BackColor = My.Settings.MainColor
        Me.GroupBox.Appearance.BackColor2 = My.Settings.MainColor2

        Me.FCnee.TextValue = ""
        Me.FGoods.TextValue = ""
        Me.FPkgs.TextValue = ""
    End Sub

    Public Sub Checking(ByRef TB As DataTable, ByVal CnsTB As DataTable)

        'If Me.TTLCBM.GnrlNum.Value = 0 Then
        '    AddRowToErrorTable(TB, "Goods", "C.B.M. Is Zero !", ErrMsgtype.Warning)
        'End If

        'If GetSummaryFromDatatable(Infragistics.Win.UltraWinGrid.SummaryType.Count, CnsTB, "GW", "") = 0 Then

        '    If Me.TGW.GnrlNum.Value = 0 Then
        '        AddRowToErrorTable(TB, "Goods", "Gross Weight Is Zero !", ErrMsgtype.Err)
        '    End If


        '    If Me.TTW.GnrlNum.Value = 0 Then
        '        AddRowToErrorTable(TB, "Goods", "Tare Weight Is Zero !", ErrMsgtype.Err)
        '    End If

        '    If Me.TTLNET.GnrlNum.Value = 0 Then
        '        AddRowToErrorTable(TB, "Goods", "NET Weight Is Zero !", ErrMsgtype.Warning)
        '    End If

        '    If Me.TTLPKGS.GnrlNum.Value = 0 Then
        '        AddRowToErrorTable(TB, "Goods", "Total Packages Is Zero !", ErrMsgtype.Err)
        '    End If
        'End If

        'If Trim(Me.MainCom.TextValue) = "" Then
        '    AddRowToErrorTable(TB, "Goods", "Main Commedity Is Blank !", ErrMsgtype.Err)
        'End If

        'If Trim(Me.Goods.TextValue) = "" Then
        '    AddRowToErrorTable(TB, "Goods", "Description Of Goods Is Blank !", ErrMsgtype.Err)
        'End If

        'If Trim(Me.Marks.TextValue) = "" Then
        '    AddRowToErrorTable(TB, "Goods", "Marks & No. Is Blank !", ErrMsgtype.Warning)
        'End If

    End Sub

    Private Sub Goods_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
        'If Me.Goods.TextValue = "" Then
        '    Me.Goods.TextValue = "SHIPPER'S LOAD, STOW, COUNT AND SEALED " & vbCrLf & "SAID TO CONTAIN "
        'End If
    End Sub


End Class
