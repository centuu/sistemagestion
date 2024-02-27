Imports DevExpress.Xpo
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraBars
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.Xpo.DB

Public Class CAJA
    Public Session1 As Session = XpoHelper.GetNewSession()
    Public egreso As Boolean = False
    Public SaldoInicial As Boolean = True
    Private Sub CAJA_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SplashScreenManager2.ShowWaitForm()
        Try
            If CajaAbierta Then
                BarButtonItem4.Enabled = False
                BarButtonItem6.Enabled = True
                BarButtonItem5.Enabled = True
                BarButtonItem8.Enabled = True
                BarButtonItem9.Enabled = True
                BarButtonItem12.Enabled = True
                BarButtonItem13.Enabled = True
                SaldoInicial = False
            Else
                BarButtonItem4.Enabled = True
                BarButtonItem6.Enabled = False
                BarButtonItem5.Enabled = False
                BarButtonItem8.Enabled = False
                BarButtonItem9.Enabled = False
                BarButtonItem12.Enabled = False
                BarButtonItem13.Enabled = False
                SaldoInicial = True
            End If
            BarEditItem1.EditValue = 0
            XpCollection1.Session = Session1
            XpCollection1.CriteriaString = "Apertura LIKE '" & Now.Day & "/" & Now.Month & "/" & Now.Year & "%' AND Cierre = '0'"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        SplashScreenManager2.CloseWaitForm()
    End Sub
    Private Sub GridView1_ShowingPopupEditForm(sender As Object, e As ShowingPopupEditFormEventArgs) Handles GridView1.ShowingPopupEditForm
        e.EditForm.StartPosition = FormStartPosition.CenterParent
        If egreso Then
            e.EditForm.Text = "Egreso"
        Else
            e.EditForm.Text = "Ingreso"
        End If
    End Sub
    Private Sub BarButtonItem5_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem5.ItemClick
        egreso = False
        AgregarRegistro()
    End Sub
    Private Sub BarButtonItem8_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem8.ItemClick
        egreso = True
        AgregarRegistro()
    End Sub
    Private Sub AgregarRegistro()
        GridView1.AddNewRow()
        GridView1.ShowEditForm()
    End Sub
    Private Sub BarButtonItem4_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem4.ItemClick
        If MsgBox("¿Desea abrir la caja?", vbYesNo + vbQuestion, "Caja") = vbYes Then
            Try
                CajaAbierta = True
                BarButtonItem4.Enabled = False
                BarButtonItem6.Enabled = True
                BarButtonItem5.Enabled = True
                BarButtonItem8.Enabled = True
                BarButtonItem9.Enabled = True
                BarButtonItem12.Enabled = True
                BarButtonItem13.Enabled = True
                XpCollection1.CriteriaString = "Apertura LIKE '%" & Now.Day & "/" & Now.Month & "/" & Now.Year & "%' And Cierre = '0'"
                XpCollection1.Reload()
                AgregarRegistro()
                SaldoInicial = False
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
    Private Sub BarButtonItem6_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem6.ItemClick
        Dim imp As Decimal = 0
        If MsgBox("¿Desea cerrar la caja?", vbYesNo + vbQuestion, "Caja") = vbYes Then
            Try
                CajaAbierta = False
                BarButtonItem4.Enabled = True
                BarButtonItem6.Enabled = False
                BarButtonItem5.Enabled = False
                BarButtonItem8.Enabled = False
                BarButtonItem9.Enabled = False
                BarButtonItem12.Enabled = False
                BarButtonItem13.Enabled = False
                For i As Integer = 0 To GridView1.RowCount - 1
                    imp += GridView1.GetRowCellValue(i, colValor)
                Next
                Session1.ExecuteNonQuery("INSERT INTO Remesa(Monto, Fecha) VALUES(" & imp.ToString().Replace(",", ".") & ", '" & Now.Day & "/" & Now.Month & "/" & Now.Year & "')")
                Session1.ExecuteNonQuery("UPDATE Caja SET Cierre = '" & Now.Day & "/" & Now.Month & "/" & Now.Year & "' WHERE Cierre = '0'")
                XpCollection1.Reload()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
    Private Sub BarButtonItem11_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem11.ItemClick
        SplashScreenManager2.ShowWaitForm()
        Try
            XpCollection1.CriteriaString = ""
            XpCollection1.Reload()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        SplashScreenManager2.CloseWaitForm()
    End Sub
    Private Sub BarButtonItem9_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem9.ItemClick
        SplashScreenManager2.ShowWaitForm()
        Try
            XpCollection1.CriteriaString = "Apertura LIKE '%" & Now.Day & "/" & Now.Month & "/" & Now.Year & "%' And Cierre = '0'"
            XpCollection1.Reload()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        SplashScreenManager2.CloseWaitForm()
    End Sub
    Private Sub BarButtonItem10_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem10.ItemClick
        SplashScreenManager2.ShowWaitForm()
        Try
            If BarEditItem2.EditValue <> Nothing Then
                XpCollection1.CriteriaString = "Apertura LIKE '%" & BarEditItem2.EditValue & "%'"
            End If
            If BarEditItem3.EditValue <> Nothing Then
                XpCollection1.CriteriaString = "Apertura LIKE '%" & ObtenerMes(BarEditItem3.EditValue) & "/" & Now.Year & "%'"
            End If
            XpCollection1.Reload()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        SplashScreenManager2.CloseWaitForm()
    End Sub
    Private Sub GridView1_EditFormPrepared(sender As Object, e As EditFormPreparedEventArgs) Handles GridView1.EditFormPrepared
        e.BindableControls.Item(colApertura).Enabled = False
        e.BindableControls.Item(colCierre).Enabled = False
    End Sub
    Private Sub CAJA_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        LiberarMemoria()
    End Sub
    Private Sub GridView1_InitNewRow(sender As Object, e As InitNewRowEventArgs) Handles GridView1.InitNewRow
        If SaldoInicial Then
            Try
                GridView1.SetFocusedRowCellValue(colTipo, "SALDO INICIAL")
                Dim id As Integer = Session1.ExecuteScalar("SELECT MAX(idRemesa) FROM Remesa")
                Dim resultSet As SelectedData = Session1.ExecuteQuery("SELECT Monto FROM Remesa WHERE idRemesa = " & id)
                GridView1.SetFocusedRowCellValue(colValor, resultSet.ResultSet(0).Rows(0).Values(0))
            Catch ex As Exception
                GridView1.SetFocusedRowCellValue(colValor, 0)
            End Try
        Else
            If egreso Then
                GridView1.SetFocusedRowCellValue(colTipo, "EGRESO")
            Else
                GridView1.SetFocusedRowCellValue(colTipo, "INGRESO")
            End If
        End If
        GridView1.SetFocusedRowCellValue(colApertura, Now.Day & "/" & Now.Month & "/" & Now.Year)
        GridView1.SetFocusedRowCellValue(colCierre, "0")
    End Sub
    Private Sub BarEditItem3_EditValueChanged(sender As Object, e As EventArgs) Handles BarEditItem3.EditValueChanged
        BarEditItem2.EditValue = Nothing
    End Sub
    Private Sub BarEditItem2_EditValueChanged(sender As Object, e As EventArgs) Handles BarEditItem2.EditValueChanged
        BarEditItem3.EditValue = Nothing
    End Sub
    Private Sub BarButtonItem12_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem12.ItemClick
        nroOperacion = GridView1.GetFocusedRowCellValue(colidVenta)
        DEVOLUCION.Show()
    End Sub
    Private Sub GridView1_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles GridView1.ValidateRow
        If egreso Then
            Dim egImp = GridView1.GetFocusedRowCellValue(colValor)
            GridView1.SetFocusedRowCellValue(colValor, egImp * -1)
        End If
    End Sub
End Class