Imports DevExpress.Xpo
Imports DevExpress.Xpo.DB
Public Class LoginForm1
    Public Session1 As Session = XpoHelper.GetNewSession()
    Private Sub OK_Click(sender As Object, e As EventArgs) Handles OK.Click
        If UsernameTextBox.Text = "Administrador" And PasswordTextBox.Text = "moadxi4M" Then
            Usuario = UsernameTextBox.Text
            Permisos = "AJCLCAVESTUSAC"
        Else
            Dim existe = Session1.ExecuteScalar("SELECT COUNT(*) FROM Usuarios WHERE Nombre = '" & UsernameTextBox.Text & "'")
            If existe > 0 Then
                Dim resultSet As SelectedData = Session1.ExecuteQuery("SELECT Clave, Permisos FROM Usuarios WHERE Nombre = '" & UsernameTextBox.Text & "'")
                If PasswordTextBox.Text = resultSet.ResultSet(0).Rows(0).Values(0) Then
                    Usuario = UsernameTextBox.Text
                    Permisos = resultSet.ResultSet(0).Rows(0).Values(1)
                Else
                    MsgBox("CLAVE INCORRECTA.", vbOKOnly + vbExclamation, "Error")
                    Exit Sub
                End If
            Else
                MsgBox("USUARIO INEXISTENTE.", vbOKOnly + vbExclamation, "Error")
                Exit Sub
            End If
        End If
        UsernameTextBox.Text = ""
        PasswordTextBox.Text = ""
        Me.Hide()
        INICIO.Show()
    End Sub
    Private Sub Cancel_Click(sender As Object, e As EventArgs) Handles Cancel.Click
        Me.Hide()
    End Sub
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        CAMBIARCLAVE.Show()
    End Sub
End Class
