Imports DevExpress.Xpo
Imports DevExpress.Xpo.DB
Imports DevExpress.XtraBars
Imports DevExpress.XtraGrid.Views.Grid
Public Class VENTAS
    Public Session1 As Session = XpoHelper.GetNewSession()
    Private Sub VENTAS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SplashScreenManager1.ShowWaitForm()
        Try
            If Not CajaAbierta Then
                RibbonPageGroup1.Visible = False
            Else
                RibbonPageGroup1.Visible = True
            End If
            XpCollection1.Session = Session1
            XpCollection1.CriteriaString = "Fecha LIKE '%" & Now.Day & "/" & Now.Month & "/" & Now.Year & "%'"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        SplashScreenManager1.CloseWaitForm()
    End Sub
    Private Sub BarButtonItem1_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        NUEVAVENTA.Show()
    End Sub
    Private Sub BarButtonItem2_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        SplashScreenManager1.ShowWaitForm()
        Try
            Dim resultData As SelectedData = Session1.ExecuteQuery("SELECT * FROM DetalleVentas WHERE IdVenta = " & GridView1.GetFocusedRowCellValue(colidVenta))
            XpDataView1.LoadData(resultData)
            DockPanel1.Visible = True
        Catch ex As Exception
            XpDataView1.LoadData(Nothing)
        End Try
        SplashScreenManager1.CloseWaitForm()
    End Sub
    Private Sub BarButtonItem4_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem4.ItemClick
        Dim folder As New FolderBrowserDialog
        If folder.ShowDialog = DialogResult.OK Then
            GridControl1.ExportToXlsx(folder.SelectedPath & "\Ventas_" & Now.Day & "-" & Now.Month & "-" & Now.Year & ".xlsx")
            MsgBox("Ventas guardadas.", vbOKOnly + vbInformation, "Hecho")
        End If
    End Sub
    Private Sub BarButtonItem5_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem5.ItemClick
        GridControl1.ShowRibbonPrintPreview()
    End Sub
    Private Sub BarButtonItem6_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem6.ItemClick
        GridControl1.PrintDialog()
    End Sub
    Private Sub BarButtonItem8_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem8.ItemClick
        SplashScreenManager1.ShowWaitForm()
        Try
            XpCollection1.CriteriaString = "Fecha LIKE '" & Now.Day & "/" & Now.Month & "/" & Now.Year & "%'"
            XpCollection1.Reload()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        SplashScreenManager1.CloseWaitForm()
    End Sub
    Private Sub BarButtonItem7_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem7.ItemClick
        If GridView1.GetFocusedRowCellValue(colObservacion).ToString.Contains("VENTA ANULADA") Then
            If GridView1.GetFocusedRowCellValue(colTipoFactura) = "RESPONSABLE INSCRIPTO" Then
                rec = Application.StartupPath & "\Facturas\Nota de Credito\A\Factura_Nro-" & GridView1.GetFocusedRowCellValue(colidVenta) & ".xlsx"
            ElseIf GridView1.GetFocusedRowCellValue(colTipoFactura) = "CONSUMIDOR FINAL" Then
                rec = Application.StartupPath & "\Facturas\Nota de Credito\B\Factura_Nro-" & GridView1.GetFocusedRowCellValue(colidVenta) & ".xlsx"
            ElseIf GridView1.GetFocusedRowCellValue(colTipoFactura) = "MONOTRIBUTISTA EXENTO" Then
                rec = Application.StartupPath & "\Facturas\Nota de Credito\C\Factura_Nro-" & GridView1.GetFocusedRowCellValue(colidVenta) & ".xlsx"
            End If
        Else
            If GridView1.GetFocusedRowCellValue(colTipoFactura) = "RESPONSABLE INSCRIPTO" Then
                rec = Application.StartupPath & "\Facturas\A\Factura_Nro-" & GridView1.GetFocusedRowCellValue(colidVenta) & ".xlsx"
            ElseIf GridView1.GetFocusedRowCellValue(colTipoFactura) = "CONSUMIDOR FINAL" Then
                rec = Application.StartupPath & "\Facturas\B\Factura_Nro-" & GridView1.GetFocusedRowCellValue(colidVenta) & ".xlsx"
            ElseIf GridView1.GetFocusedRowCellValue(colTipoFactura) = "MONOTRIBUTISTA EXENTO" Then
                rec = Application.StartupPath & "\Facturas\C\Factura_Nro-" & GridView1.GetFocusedRowCellValue(colidVenta) & ".xlsx"
            End If
        End If
        FACTURAS.Show()
    End Sub
    Private Sub GridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView1.KeyDown
        If e.KeyCode = Keys.Insert Then
            If Not CajaAbierta Then
                Exit Sub
            Else
                NUEVAVENTA.Show()
            End If
        End If
    End Sub
    Private Sub BarButtonItem9_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem9.ItemClick
        If GridView1.GetFocusedRowCellValue(colRemito) <> 0 Then
            DockPanel3.Visible = True
        End If
    End Sub
    Private Sub BarButtonItem14_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem14.ItemClick
        SplashScreenManager1.ShowWaitForm()
        Try
            If BarEditItem3.EditValue <> Nothing Then
                XpCollection1.CriteriaString = "Fecha LIKE '%" & BarEditItem3.EditValue & "%'"
            End If
            If BarEditItem4.EditValue <> Nothing Then
                XpCollection1.CriteriaString = "Fecha LIKE '%" & ObtenerMes(BarEditItem4.EditValue) & "/" & Now.Year & "%'"
            End If
            XpCollection1.Reload()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        SplashScreenManager1.CloseWaitForm()
    End Sub
    Private Sub BarButtonItem15_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem15.ItemClick
        SplashScreenManager1.ShowWaitForm()
        Try
            XpCollection1.CriteriaString = ""
            XpCollection1.Reload()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        SplashScreenManager1.CloseWaitForm()
    End Sub
    Private Sub VENTAS_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        LiberarMemoria()
    End Sub
    Private Sub BarButtonItem16_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem16.ItemClick
        SplashScreenManager1.ShowWaitForm()
        Try
            Dim resultData As SelectedData = Session1.ExecuteQuery("SELECT * FROM DetallePago WHERE IdVenta = " & GridView1.GetFocusedRowCellValue(colidVenta))
            XpDataView2.LoadData(resultData)
            DockPanel2.Visible = True
        Catch ex As Exception
            XpDataView2.LoadData(Nothing)
        End Try
        SplashScreenManager1.CloseWaitForm()
    End Sub
    Private Sub BarEditItem3_EditValueChanged(sender As Object, e As EventArgs) Handles BarEditItem3.EditValueChanged
        BarEditItem4.EditValue = Nothing
    End Sub
    Private Sub BarEditItem4_EditValueChanged(sender As Object, e As EventArgs) Handles BarEditItem4.EditValueChanged
        BarEditItem3.EditValue = Nothing
    End Sub
    Private Sub GridView1_ShowingPopupEditForm(sender As Object, e As ShowingPopupEditFormEventArgs) Handles GridView1.ShowingPopupEditForm
        e.EditForm.StartPosition = FormStartPosition.CenterParent
        e.EditForm.Text = "Editar"
    End Sub
    Private Sub GridView1_EditFormPrepared(sender As Object, e As EditFormPreparedEventArgs) Handles GridView1.EditFormPrepared
        e.BindableControls.Item(colidVenta).Enabled = False
        e.BindableControls.Item(colFecha).Enabled = False
        'e.BindableControls.Item(colUsuario).Enabled = False
    End Sub
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        rec = Application.StartupPath & "\Remitos\Remito_Nro-" & GridView1.GetFocusedRowCellValue(colRemito) & ".xlsx"
        FACTURAS.Show()
    End Sub
    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        rec = Application.StartupPath & "\Remitos\Remito_Nro-" & GridView1.GetFocusedRowCellValue(colRemito) & "-D.xlsx"
        FACTURAS.Show()
    End Sub
End Class