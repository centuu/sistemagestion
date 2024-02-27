Imports System.Drawing.Printing
Public Class DETALLE
    Private Sub XrLabel2_BeforePrint(sender As Object, e As PrintEventArgs) Handles XrLabel2.BeforePrint
        If nroRemitoAsoc > 0 Then
            XrLabel2.Text = nroRemitoAsoc.ToString
        Else
            XrLabel2.Text = ""
        End If
    End Sub
    Private Sub XrLabel4_BeforePrint(sender As Object, e As PrintEventArgs) Handles XrLabel4.BeforePrint
        XrLabel4.Text = TipoFactura
    End Sub
    Private Sub XrLabel16_BeforePrint(sender As Object, e As PrintEventArgs) Handles XrLabel16.BeforePrint
        XrLabel16.Text = NombreCliente
    End Sub
    Private Sub XrLabel19_BeforePrint(sender As Object, e As PrintEventArgs) Handles XrLabel19.BeforePrint
        XrLabel19.Text = cuitCliente
    End Sub
    Private Sub XrLabel17_BeforePrint(sender As Object, e As PrintEventArgs) Handles XrLabel17.BeforePrint
        XrLabel17.Text = Domicilio
    End Sub
    Private Sub XrLabel25_BeforePrint(sender As Object, e As PrintEventArgs) Handles XrLabel25.BeforePrint
        XrLabel25.Text = Localidad
    End Sub
    Private Sub XrLabel27_BeforePrint(sender As Object, e As PrintEventArgs) Handles XrLabel27.BeforePrint
        XrLabel27.Text = TelCliente
    End Sub
    Private Sub XrLabel30_BeforePrint(sender As Object, e As PrintEventArgs) Handles XrLabel30.BeforePrint
        XrLabel30.Text = MedPag
    End Sub
End Class