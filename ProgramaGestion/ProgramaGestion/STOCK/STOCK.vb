Imports DevExpress.Xpo
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraBars
Imports DevExpress.XtraGrid.Views.Base
Public Class STOCK
    Public Session1 As Session = XpoHelper.GetNewSession()
    Public editar As Boolean
    Private Sub GridView1_ShowingPopupEditForm(sender As Object, e As ShowingPopupEditFormEventArgs) Handles GridView1.ShowingPopupEditForm
        e.EditForm.StartPosition = FormStartPosition.CenterParent
        If editar Then
            e.EditForm.Text = "Editar"
        Else
            e.EditForm.Text = "Agregar"
        End If
    End Sub
    Private Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick
        editar = True
    End Sub
    Private Sub GridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView1.KeyDown
        If e.KeyCode = Keys.Enter Then
            editar = True
        ElseIf e.KeyCode = Keys.Delete Then
            BorrarRegistro()
        ElseIf e.KeyCode = Keys.Insert Then
            AgregarRegistro()
        End If
    End Sub
    Private Sub BorrarRegistro()
        Try
            If MsgBox("¿Desea eliminar el artículo?", vbYesNo + vbQuestion, "Eliminar") = vbYes Then
                SplashScreenManager1.ShowWaitForm()
                Session1.ExecuteNonQuery("DELETE FROM Articulos WHERE idArticulo = " & GridView1.GetFocusedRowCellValue(colidArticulo))
                XpCollection1.Reload()
                SplashScreenManager1.CloseWaitForm()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub AgregarRegistro()
        editar = False
        GridView1.AddNewRow()
        GridView1.ShowEditForm()
    End Sub
    Private Sub ARTICULOS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SplashScreenManager1.ShowWaitForm()
        Try
            XpCollection1.Session = Session1
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        SplashScreenManager1.CloseWaitForm()
    End Sub
    Private Sub BarButtonItem1_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        AgregarRegistro()
    End Sub
    Private Sub BarButtonItem2_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        editar = True
        GridView1.ShowEditForm()
    End Sub
    Private Sub BarButtonItem3_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        BorrarRegistro()
    End Sub
    Private Sub BarButtonItem4_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem4.ItemClick
        Dim folder As New FolderBrowserDialog
        If folder.ShowDialog = DialogResult.OK Then
            GridControl1.ExportToXlsx(folder.SelectedPath & "\Stock" & Now.Day & "-" & Now.Month & "-" & Now.Year & ".xlsx")
            MsgBox("Stock guardado.", vbOKOnly + vbInformation, "Hecho")
        End If
    End Sub
    Private Sub BarButtonItem5_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem5.ItemClick
        GridControl1.ShowRibbonPrintPreview()
    End Sub
    Private Sub BarButtonItem6_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem6.ItemClick
        GridControl1.PrintDialog()
    End Sub
    Private Sub GridView1_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles GridView1.ValidateRow
        If GridView1.GetFocusedRowCellValue(colDescripcion) = Nothing Then
            MsgBox("Debe ingresar un nombre de artículo.", vbOKOnly + vbExclamation, "Advertencia")
            GridView1.CancelUpdateCurrentRow()
        End If
        'If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, colStock) = 0 Then
        '    MsgBox("Debe ingresar un valor de stock.", vbOKOnly + vbExclamation, "Advertencia")
        '    GridView1.CancelUpdateCurrentRow()
        'End If
    End Sub
    Private Sub ARTICULOS_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        LiberarMemoria()
    End Sub
End Class