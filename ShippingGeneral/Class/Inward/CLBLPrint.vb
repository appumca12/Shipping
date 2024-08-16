Imports OrmLib
Imports ShippingBiz

Public Class CLBLPrint

    Private Dm As DataManager
    Private Bls As TB_InwardBLS
    Private Cns As TB_InwardCntrsCollection
    Private Names As TB_InwardBlsNames
    Private goods As TB_InwardBlsGoods
    Private Memo As CLMemo
    Public Sub GenerateBLData(ByVal BlNo As String)

        '    Dim nI As Byte
        '    Dim Cn As TB_InwardCntrs
        '    Dim Dr As DataRow
        '    Dim aKey(0) As String
        '    Dim aKeyMnf(1) As String
        '    Dim Counter As Long
        '    Dim nCntrPkgs As Long
        '    Dim sCntrPkgs As String = ""
        '    Dim aTables() As String = {"TB_InwardBls", "Tb_InwardBlsNames", "TB_InwardBlsGoods", "TB_InwardCharges", "Tb_InwardCntrs", "TB_InwardCnsImco", "TB_InwardCnsTemprature", "TB_InwardCnsPkgs"}
        '    Dim Ds As DataSet

        '    Dm = New DataManager(My.Settings.DSN)
        '    Ds = StoredProcedures.SP_InwardAllDataByLineBlNo(CurrentShippingLine, BLNo)
        '    Dm.PopulateObjectsFromDataSet(Ds, aTables)

        '    For nI = 0 To aTables.Length - 1
        '        Dm.DataSet.Tables(aTables(nI)).Merge(Ds.Tables(nI))
        '    Next

        '    Bls = Nothing
        '    Cns = Nothing
        '    Names = Nothing
        '    Goods = Nothing

        '    If Dm.GetTB_InwardBLSCollectionFromDataSet.Count > 0 Then
        '        Bls = Dm.GetTB_InwardBLSCollectionFromDataSet(0)
        '        Cns = Dm.GetTB_InwardCntrsCollectionFromDataSet
        '        If Dm.GetTB_InwardBlsNamesCollectionFromDataSet.Count > 0 Then
        '            Names = Dm.GetTB_InwardBlsNamesCollectionFromDataSet(0)
        '        End If
        '        If Dm.GetTB_InwardBlsGoodsCollectionFromDataSet.Count > 0 Then
        '            Goods = Dm.GetTB_InwardBlsGoodsCollectionFromDataSet(0)
        '        End If
        '    End If
        '    Memo = New CLMemo
        '    If Not Names Is Nothing Then
        '        Memo.ColInit(CLMemo.MemoTypes.Cnee, Names.Cnee, 30)
        '        Memo.ColInit(CLMemo.MemoTypes.Notify1, Names.Notify1, 30)
        '        Memo.ColInit(CLMemo.MemoTypes.Shipper, Names.Shipper, 30)
        '    End If

        '    If Not Goods Is Nothing Then
        '        Memo.ColInit(CLMemo.MemoTypes.Goods, Goods.Goods, 45)
        '        Memo.ColInit(CLMemo.MemoTypes.Marks, Goods.Marks, 17)
        '    End If

        '    Counter = 0

        '    If Not Memo.Shpr Is Nothing Then
        '        For nI = 1 To Memo.Shpr.Count
        '            If Len(Trim(Memo.Shpr.Item(nI))) > 0 Then
        '                Counter = Counter + 1
        '                Dr = TempMnf.NewRow
        '                Dr("BlNo") = Bls.BlNo
        '                Dr("Seq") = Format(Counter, "0000")
        '                If nI <= Memo.Shpr.Count Then
        '                    Dr("Col1") = "(SH)"
        '                    Dr("Col2") = Memo.Shpr.Item(nI)
        '                End If
        '                TempMnf.Rows.Add(Dr)
        '            End If

        '        Next
        '    End If

        '    If Not Memo.Cnee Is Nothing Then
        '        For nI = 1 To Memo.Cnee.Count
        '            If Len(Trim(Memo.Cnee.Item(nI))) > 0 Then
        '                Counter = Counter + 1
        '                Dr = TempMnf.NewRow
        '                Dr("BlNo") = Bls.BlNo
        '                Dr("Seq") = Format(Counter, "0000")
        '                Dr("Col1") = "(CO)"
        '                Dr("Col2") = Memo.Cnee.Item(nI)
        '                TempMnf.Rows.Add(Dr)
        '            End If
        '        Next
        '    End If

        '    If Not Memo.Ntfy1 Is Nothing Then
        '        For nI = 1 To Memo.Ntfy1.Count
        '            If Len(Trim(Memo.Ntfy1.Item(nI))) > 0 Then
        '                Counter = Counter + 1
        '                Dr = TempMnf.NewRow
        '                Dr("BlNo") = Bls.BlNo
        '                Dr("Seq") = Format(Counter, "0000")
        '                Dr("Col1") = "(NF)"
        '                Dr("Col2") = Memo.Ntfy1.Item(nI)
        '                TempMnf.Rows.Add(Dr)
        '            End If
        '        Next
        '    End If

        '    If Not Memo.GOOD Is Nothing Then
        '        For nI = 1 To Memo.GOOD.Count
        '            aKeyMnf(0) = Bls.BlNo
        '            aKeyMnf(1) = Format(nI, "0000")
        '            Dr = TempMnf.Rows.Find(aKeyMnf)
        '            If (Dr Is Nothing) Then
        '                Dr = TempMnf.NewRow
        '                Dr("BlNo") = Bls.BlNo
        '                Dr("Seq") = Format(nI, "0000")
        '                Dr("Col5") = Memo.GOOD.Item(nI)
        '                TempMnf.Rows.Add(Dr)
        '            Else
        '                Dr("Col5") = Memo.GOOD.Item(nI)
        '            End If
        '        Next
        '    End If

        '    If Not Memo.Mark Is Nothing Then
        '        For nI = 1 To Memo.Mark.Count
        '            aKeyMnf(0) = Bls.BlNo
        '            aKeyMnf(1) = Format(nI, "0000")
        '            Dr = TempMnf.Rows.Find(aKeyMnf)
        '            If (Dr Is Nothing) Then
        '                Dr = TempMnf.NewRow
        '                Dr("BlNo") = Bls.BlNo
        '                Dr("Seq") = Format(nI, "0000")
        '                Dr("Col4") = Memo.Mark.Item(nI)
        '                TempMnf.Rows.Add(Dr)
        '            Else
        '                Dr("Col4") = Memo.Mark.Item(nI)
        '            End If
        '        Next
        '    End If

        '    aKeyMnf(0) = Bls.BlNo
        '    aKeyMnf(1) = Format(1, "0000")
        '    Dr = TempMnf.Rows.Find(aKeyMnf)
        '    If (Dr Is Nothing) Then
        '        Dr = TempMnf.NewRow
        '        Dr("BlNo") = Bls.BlNo
        '        Dr("Seq") = Format(1, "0000")
        '        Dr("Col3") = Bls.BlNo
        '        Dr("Col6") = "(TW)"
        '        If Not Goods Is Nothing Then
        '            Dr("Col7") = Format(NullToValue(Goods.TTW, 0), "standard")
        '        End If
        '    Else
        '        Dr("Col3") = Bls.BlNo
        '        Dr("Col6") = "(TW)"
        '        Dr("Col7") = Format(Double.Parse(Goods.TTW), "standard")
        '    End If


        '    aKeyMnf(0) = Bls.BlNo
        '    aKeyMnf(1) = Format(2, "0000")
        '    Dr = TempMnf.Rows.Find(aKeyMnf)
        '    If (Dr Is Nothing) Then
        '        Dr = TempMnf.NewRow
        '        Dr("BlNo") = Bls.BlNo
        '        Dr("Seq") = Format(2, "0000")
        '        Dr("Col6") = "(GW)"
        '        If Not Memo.GOOD Is Nothing Then
        '            Dr("Col7") = Format(Double.Parse(Goods.TGW), "standard")
        '        End If
        '    Else
        '        Dr("Col6") = "(GW)"
        '        Dr("Col7") = Format(Double.Parse(Goods.TGW), "standard")
        '    End If

        '    For Each Cn In Cns
        '        Dr = TempCns.NewRow
        '        Dr("BlNo") = Bls.BlNo
        '        Dr("CntrNo") = Cn.CntrNo
        '        Dr("CnSize") = Cn.CnSize
        '        Dr("CnType") = Cn.CnType
        '        Dr("SealNo") = Cn.SealNo
        '        Dr("SVC") = Cn.FLE
        '        Dr("GW") = Format(Double.Parse(Cn.GW), "standard")
        '        Dr("TW") = Format(Double.Parse(Cn.TW), "standard")
        '        Dr("TTLWGT") = Format(Double.Parse(Cn.GW + Cn.TW), "standard")
        '        nCntrPkgs = 0
        '        '       VbDecodes.InCntrTotalPkgs(Cn.ID, sCntrPkgs, nCntrPkgs)
        '        Dr("Pkgs") = nCntrPkgs
        '        TempCns.Rows.Add(Dr)
        '        aKey(0) = Cn.CntrNo
        '        Dr = TempUnique.Rows.Find(aKey)
        '        If (Dr Is Nothing) Then
        '            Dr = TempUnique.NewRow
        '            Dr("CntrNo") = Cn.CntrNo
        '            TempUnique.Rows.Add(Dr)
        '            Dr = TempTTL.NewRow
        '            Dr("CntrNo") = Cn.CntrNo
        '            Dr("CnSize") = Cn.CnSize
        '            Dr("CnType") = Cn.CnType
        '            Dr("FE") = IIf(Cn.FLE = "F" Or Cn.FLE = "L", "Full", "Empty")
        '            Dr("Weight") = Double.Parse(Cn.TW + Cn.GW)
        '            TempTTL.Rows.Add(Dr)
        '        Else
        '            aKey(0) = Cn.CntrNo
        '            Dr = TempTTL.Rows.Find(aKey)
        '            If Not (Dr Is Nothing) Then
        '                Dr("Weight") = Dr("Weight") + Double.Parse(Cn.GW)
        '            End If
        '        End If
        '    Next

        '    If TBChg Is Nothing Then
        '        TBChg = Ds.Tables("TB_InwardCharges")
        '    Else
        '        TBChg.Merge(Ds.Tables("TB_InwardCharges"))
        '    End If

    End Sub

    Private Sub InitTemp()




    End Sub



End Class
