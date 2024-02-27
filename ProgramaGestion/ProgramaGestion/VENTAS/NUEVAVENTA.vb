Imports DevExpress.Xpo
Imports DevExpress.Xpo.DB
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports ProgramaGestion.BDArtLimpieza
Public Class NUEVAVENTA
    Public Session1 As Session = XpoHelper.GetNewSession()
    Private Sub NUEVAVENTA_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            XpCollection1.Session = Session1
            XpCollection2.Session = Session1
            XpCollection3.Session = Session1
            XpCollection1.CriteriaString = "idVenta = 0"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub NUEVAVENTA_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            XpCollection1.Reload()
            If GridView1.RowCount > 0 Then
                If MsgBox("Operación incompleta, ¿Desea descartar la venta?", vbYesNo + vbQuestion, "Atención") = vbYes Then
                    For i As Integer = 0 To GridView1.RowCount - 1
                        Session1.ExecuteNonQuery("UPDATE Articulos SET Stock = Stock + " & GridView1.GetRowCellValue(i, colCantidad) & " WHERE idArticulo = " & ObtenerCodigo(GridView1.GetRowCellValue(i, colArticulo)))
                    Next
                    Session1.ExecuteNonQuery("DELETE FROM DetalleVentas WHERE idVenta = 0")
                    Me.Dispose()
                Else
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Finalizar()
        Dim importe As Decimal = 0
        Dim cantidad As Integer = 0
        If LookUpEdit2.EditValue <> Nothing Then
            Try
                Dim resultSet As SelectedData = Session1.ExecuteQuery("SELECT CUIT,Domicilio,Localidad,Telefono,Mail FROM Clientes WHERE idCliente = " & LookUpEdit2.EditValue) 'ObtenerCliente(LookUpEdit2.Text))
                NombreCliente = LookUpEdit2.Text
                cuitCliente = resultSet.ResultSet(0).Rows(0).Values(0)
                Domicilio = resultSet.ResultSet(0).Rows(0).Values(1)
                Localidad = resultSet.ResultSet(0).Rows(0).Values(2)
                TelCliente = resultSet.ResultSet(0).Rows(0).Values(3)
                Nota = resultSet.ResultSet(0).Rows(0).Values(4)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            MsgBox("Debe seleccionar un cliente.", vbOKOnly + vbExclamation, "Atención")
            Exit Sub
        End If
        If ComboBoxEdit1.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar un tipo de factura.", vbOKOnly + vbExclamation, "Atención")
            Exit Sub
        End If
        If GridView1.RowCount = Nothing Then
            MsgBox("No hay artículos cargados.", vbOKOnly + vbExclamation, "Atención")
            Exit Sub
        End If
        For i As Integer = 0 To GridView1.RowCount - 1
            importe += GridView1.GetRowCellValue(i, colPrecioTot)
            cantidad += GridView1.GetRowCellValue(i, colCantidad)
        Next
        TotalImporte = importe
        TotalCantidad = cantidad
        idCli = LookUpEdit2.Text
        PAGO.Show()
        Limpiar()
    End Sub
    Private Sub Limpiar()
        LookUpEdit1.Text = ""
        SpinEdit1.Value = 0
        TextEdit1.Text = ""
        TextEdit2.Text = ""
        TextEdit3.Text = ""
        Try
            XpCollection1.Reload()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Agregar()
        If LookUpEdit1.EditValue = Nothing Then
            MsgBox("Debe seleccionar un artículo para cargar.", vbOKOnly + vbExclamation, "Atención")
            Exit Sub
        End If
        Try
            Session1.ExecuteNonQuery("UPDATE Articulos SET Stock = Stock - " & SpinEdit1.Value & " WHERE idArticulo = " & LookUpEdit1.EditValue) ' ObtenerCodigo(LookUpEdit1.Text))
            Dim venta = New DetalleVentas(Session1)
            With venta
                .idVenta = 0
                .Articulo = LookUpEdit1.Text
                .Cantidad = SpinEdit1.Value
                .PrecioUni = TextEdit2.Text
                .PrecioTot = TextEdit3.Text
                .Save()
            End With
            Limpiar()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Borrar()
        If GridView1.RowCount < 1 Then Exit Sub
        Try
            If MsgBox("¿Desea eliminar el artículo?", vbYesNo + vbQuestion, "Atención") = vbYes Then
                Session1.ExecuteNonQuery("DELETE FROM DetalleVentas WHERE idDetalle = " & GridView1.GetFocusedRowCellValue(colidDetalle))
                Session1.ExecuteNonQuery("UPDATE Articulos SET Stock = Stock + " & GridView1.GetFocusedRowCellValue(colCantidad) & " WHERE idArticulo = " & ObtenerCodigo(GridView1.GetFocusedRowCellValue(colArticulo)))
                Limpiar()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub GridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView1.KeyDown
        If e.KeyCode = Keys.Delete Then
            Borrar()
        End If
    End Sub
    Private Function ObtenerCodigo(nombre As String) As Integer
        Try
            Dim resultSet As SelectedData = Session1.ExecuteQuery("SELECT idArticulo FROM Articulos WHERE Descripcion = '" & nombre & "'")
            Return resultSet.ResultSet(0).Rows(0).Values(0)
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If TextEdit1.Text = 0 Then
            MsgBox("No puede agregar un producto sin stock.", vbOKOnly + vbExclamation, "Atencion")
            Exit Sub
        End If
        If CInt(TextEdit1.Text) < SpinEdit1.Value Then
            MsgBox("STOCK INSUFICIENTE.", vbOKOnly + vbExclamation, "Atencion")
            Exit Sub
        End If
        Agregar()
    End Sub
    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Borrar()
    End Sub
    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        Remito = CheckEdit1.Checked
        TipoFactura = ComboBoxEdit1.SelectedText
        opTipoFactura = ComboBoxEdit1.SelectedIndex
        Finalizar()
    End Sub
    Private Sub LookUpEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles LookUpEdit1.EditValueChanged
        Try
            Dim resultSet As SelectedData = Session1.ExecuteQuery("SELECT Stock, PrecioUni FROM Articulos WHERE idArticulo = " & ObtenerCodigo(LookUpEdit1.Text))
            TextEdit1.Text = CInt(resultSet.ResultSet(0).Rows(0).Values(0))
            TextEdit2.Text = CDec(resultSet.ResultSet(0).Rows(0).Values(1))
            If CInt(resultSet.ResultSet(0).Rows(0).Values(0)) > 0 Then
                SpinEdit1.Value = 1
            Else
                SpinEdit1.Value = 0
            End If
            TextEdit3.Text = CDec(resultSet.ResultSet(0).Rows(0).Values(1))
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub SpinEdit1_ValueChanged(sender As Object, e As EventArgs) Handles SpinEdit1.ValueChanged
        If CInt(TextEdit1.Text) < SpinEdit1.Value Then
            MsgBox("STOCK INSUFICIENTE.", vbOKOnly + vbExclamation, "Atencion")
            Exit Sub
        End If
        TextEdit3.Text = TextEdit2.Text * SpinEdit1.Value
    End Sub
    Private Sub GridView3_ShowingPopupEditForm(sender As Object, e As ShowingPopupEditFormEventArgs) Handles GridView3.ShowingPopupEditForm
        e.EditForm.StartPosition = FormStartPosition.CenterParent
        e.EditForm.Text = "Agregar nuevo artículo"
    End Sub
    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        GridControl3.Visible = True
        GridView3.AddNewRow()
        GridView3.ShowEditForm()
        Try
            XpCollection2.Reload()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        GridControl3.Visible = False
    End Sub
    Private Sub GridView3_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles GridView3.ValidateRow
        '    If GridView3.GetRowCellValue(GridView3.FocusedRowHandle, colDescripcion) = Nothing Then
        '        MsgBox("Debe ingresar un nombre de artículo.", vbOKOnly + vbExclamation, "Advertencia")
        '        GridView1.CancelUpdateCurrentRow()
        '    End If
        '    If GridView3.GetRowCellValue(GridView3.FocusedRowHandle, colStock) = 0 Then
        '        MsgBox("Debe ingresar un valor de stock.", vbOKOnly + vbExclamation, "Advertencia")
        '        GridView1.CancelUpdateCurrentRow()
        '    End If
        '    If GridView3.GetRowCellValue(GridView3.FocusedRowHandle, colPrecioUni1) = 0 Then
        '        MsgBox("Debe ingresar un precio unitario.", vbOKOnly + vbExclamation, "Advertencia")
        '        GridView1.CancelUpdateCurrentRow()
        '    End If
    End Sub
    Private Sub ComboBoxEdit1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxEdit1.SelectedIndexChanged
        If ComboBoxEdit1.SelectedIndex = 0 Then
            LabelControl8.Text = "( A )"
        ElseIf ComboBoxEdit1.SelectedIndex = 1 Then
            LabelControl8.Text = "( B )"
        ElseIf ComboBoxEdit1.SelectedIndex = 2 Then
            LabelControl8.Text = "( C )"
        End If
    End Sub
    Private Sub NUEVAVENTA_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        LiberarMemoria()
    End Sub
End Class