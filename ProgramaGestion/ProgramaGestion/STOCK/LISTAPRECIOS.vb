Imports DevExpress.Xpo
Imports DevExpress.XtraBars
Imports DevExpress.XtraGrid.Views.Grid
Public Class LISTAPRECIOS
    Public Session1 As Session = XpoHelper.GetNewSession()
    Private Sub LISTAPRECIOS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            XpCollection1.Session = Session1
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub BarButtonItem4_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem4.ItemClick
        Try
            XpCollection1.Reload()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub GridView1_ShowingPopupEditForm(sender As Object, e As ShowingPopupEditFormEventArgs) Handles GridView1.ShowingPopupEditForm
        e.EditForm.StartPosition = FormStartPosition.CenterParent
    End Sub
    Private Sub BarButtonItem5_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem5.ItemClick
        If BarEditItem1.EditValue Is Nothing Then
            MsgBox("Debe ingresar un porcentaje para aplicar.", vbOKOnly + vbExclamation, "Ajuste")
            Exit Sub
        End If
        Try
            If MsgBox("¿Desea aplicar el " & BarEditItem1.EditValue & "% al precio?", vbYesNo + vbQuestion, "Ajuste") = vbYes Then
                For i As Integer = 0 To GridView1.RowCount - 1
                    Dim Por As Decimal = ((BarEditItem1.EditValue / 100) * GridView1.GetRowCellValue(i, colPrecioUni)) + GridView1.GetRowCellValue(i, colPrecioUni)
                    GridView1.SetRowCellValue(i, colPrecioUni, Por)
                Next
            End If
            BarEditItem1.EditValue = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub LISTAPRECIOS_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        LiberarMemoria()
    End Sub
    Private Sub BarButtonItem1_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        Dim folder As New FolderBrowserDialog
        If folder.ShowDialog = DialogResult.OK Then
            GridControl1.ExportToXlsx(folder.SelectedPath & "\ListaPrecios" & Now.Day & "-" & Now.Month & "-" & Now.Year & ".xlsx")
            MsgBox("Lista de precios guardada.", vbOKOnly + vbInformation, "Hecho")
        End If
    End Sub
    Private Sub BarButtonItem2_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        GridControl1.ShowRibbonPrintPreview()
    End Sub
    Private Sub BarButtonItem3_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        GridControl1.PrintDialog()
    End Sub
End Class