Imports Infragistics.Win
Imports Infragistics.Shared
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinEditors


Module GridTools
   
    Public Sub GridNumSeperator(ByVal Grid As UltraGrid)

        Dim Col As UltraGridColumn
        Dim bnd As UltraGridBand

        For Each bnd In Grid.DisplayLayout.Bands
            For Each Col In bnd.Columns
                Select Case Col.DataType.ToString
                    Case "System.Double"
                        Col.Format = "###,###.00"
                        Col.CellAppearance.TextHAlign = HAlign.Right
                    Case "System.Int32"
                        Col.Format = "###,###"
                        Col.CellAppearance.TextHAlign = HAlign.Right
                    Case "System.Int16"
                        Col.Format = "###,###"
                        Col.CellAppearance.TextHAlign = HAlign.Right
                    Case "System.Int64"
                        Col.Format = "###,###"
                        Col.CellAppearance.TextHAlign = HAlign.Right
                    Case "System.Guid"
                        Col.Hidden = True
                    Case Else
                        Debug.Print(Col.DataType.ToString())
                End Select
            Next
        Next
        Grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ExtendLastColumn
    End Sub

  


End Module
