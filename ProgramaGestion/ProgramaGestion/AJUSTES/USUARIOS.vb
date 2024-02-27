Imports DevExpress.Xpo
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraBars
Imports DevExpress.Xpo.DB
Public Class USUARIOS
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
            If GridView1.RowCount < 1 Then Exit Sub
            If MsgBox("¿Desea eliminar el usuario?", vbYesNo + vbQuestion, "Eliminar") = vbYes Then
                SplashScreenManager1.ShowWaitForm()
                Session1.ExecuteNonQuery("DELETE FROM Usuarios WHERE idUsuario = " & GridView1.GetFocusedRowCellValue(colidUsuario))
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
    Private Sub USUARIOS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
    Private Sub BarButtonItem3_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        BorrarRegistro()
    End Sub
    Private Sub BarButtonItem2_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        editar = True
        GridView1.ShowEditForm()
    End Sub
    Private Sub USUARIOS_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        LiberarMemoria()
    End Sub
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim vpermisos = ""
        If CheckedComboBoxEdit1.Text.Contains("AJUSTES") Then
            vpermisos &= "AJ"
        End If
        If CheckedComboBoxEdit1.Text.Contains("CLIENTES") Then
            vpermisos &= "CL"
        End If
        If CheckedComboBoxEdit1.Text.Contains("VENTAS") Then
            vpermisos &= "VE"
        End If
        If CheckedComboBoxEdit1.Text.Contains("CAJA") Then
            vpermisos &= "CA"
        End If
        If CheckedComboBoxEdit1.Text.Contains("STOCK") Then
            vpermisos &= "ST"
        End If
        GridView1.SetFocusedRowCellValue(colPermisos, vpermisos)
        MsgBox("Permisos otorgados.", vbOKOnly + vbInformation, "Hecho")
        DockPanel1.Visible = False
    End Sub
    Private Sub BarButtonItem5_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem5.ItemClick
        If GridView1.RowCount < 1 Then Exit Sub
        Try
            Dim resultSet As SelectedData = Session1.ExecuteQuery("SELECT Permisos FROM Usuarios WHERE idUsuario = " & GridView1.GetFocusedRowCellValue(colidUsuario))
            Dim vpermisos As String = resultSet.ResultSet(0).Rows(0).Values(0)
            If vpermisos <> Nothing Then
                If vpermisos.Contains("AJ") Then
                    CheckedComboBoxEdit1.Properties.Items(0).CheckState = CheckState.Checked
                End If
                If vpermisos.Contains("CL") Then
                    CheckedComboBoxEdit1.Properties.Items(3).CheckState = CheckState.Checked
                End If
                If vpermisos.Contains("CA") Then
                    CheckedComboBoxEdit1.Properties.Items(2).CheckState = CheckState.Checked
                End If
                If vpermisos.Contains("VE") Then
                    CheckedComboBoxEdit1.Properties.Items(4).CheckState = CheckState.Checked
                End If
                If vpermisos.Contains("ST") Then
                    CheckedComboBoxEdit1.Properties.Items(1).CheckState = CheckState.Checked
                End If
            End If
            DockPanel1.Visible = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class