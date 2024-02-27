Imports DevExpress.Xpo
Imports DevExpress.Xpo.DB
Public Class CAMBIARCLAVE
    Public Session1 As Session = XpoHelper.GetNewSession()
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Try
            Session1.ExecuteNonQuery("UPDATE Usuarios SET Clave = '" & TextBox2.Text & "' WHERE idUsuario = " & ObtenerUsuario(TextEdit1.Text))
            MsgBox("Contraseña actualizada.", vbOKOnly + vbInformation, "Hecho")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Me.Dispose()
    End Sub
    Private Function ObtenerUsuario(nombre As String) As Integer
        Try
            Dim resultSet As SelectedData = Session1.ExecuteQuery("SELECT idUsuario FROM Usuarios WHERE Nombre = '" & nombre & "'")
            Return resultSet.ResultSet(0).Rows(0).Values(0)
        Catch ex As Exception
            Return 0
        End Try
    End Function
End Class