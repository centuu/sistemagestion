Imports System.Drawing.Printing
Public Class FACTURAC
    Private Sub XrLabel2_BeforePrint(sender As Object, e As PrintEventArgs) Handles XrLabel2.BeforePrint
        XrLabel2.Text = "TOTAL $" & TotalImporte.ToString("N2")
    End Sub
    Private Sub XrLabel11_BeforePrint(sender As Object, e As PrintEventArgs) Handles XrLabel11.BeforePrint
        XrLabel11.Text = nroFactura
    End Sub
    Private Sub XrLabel22_BeforePrint(sender As Object, e As PrintEventArgs) Handles XrLabel22.BeforePrint
        XrLabel22.Text = Now.Day & "/" & Now.Month & "/" & Now.Year
    End Sub
    Private Sub XrLabel1_BeforePrint(sender As Object, e As PrintEventArgs) Handles XrLabel1.BeforePrint
        XrLabel1.Text = nombreEmpresa
    End Sub
    Private Sub XrLabel5_BeforePrint(sender As Object, e As PrintEventArgs) Handles XrLabel5.BeforePrint
        XrLabel5.Text = domicilioEmpresa
    End Sub
    Private Sub XrLabel6_BeforePrint(sender As Object, e As PrintEventArgs) Handles XrLabel6.BeforePrint
        XrLabel6.Text = "(" & cpostalEmpresa & ") " & localidadEmpresa & " - " & provEmpresa
    End Sub
    Private Sub XrLabel31_BeforePrint(sender As Object, e As PrintEventArgs) Handles XrLabel31.BeforePrint
        XrLabel31.Text = monotributoEmpresa
    End Sub
    Private Sub XrLabel20_BeforePrint(sender As Object, e As PrintEventArgs) Handles XrLabel20.BeforePrint
        XrLabel20.Text = cuitEmpresa
    End Sub
    Private Sub XrLabel21_BeforePrint(sender As Object, e As PrintEventArgs) Handles XrLabel21.BeforePrint
        XrLabel21.Text = cuitEmpresa
    End Sub
    Private Sub XrLabel8_BeforePrint(sender As Object, e As PrintEventArgs) Handles XrLabel8.BeforePrint
        XrLabel8.Text = "Inicio de Actividades: " & iniActividad
    End Sub
    Private Sub XrLabel9_BeforePrint(sender As Object, e As PrintEventArgs) Handles XrLabel9.BeforePrint
        XrLabel9.Text = "C.A.I. " & caiEmpresa
    End Sub
    Private Sub XrLabel10_BeforePrint(sender As Object, e As PrintEventArgs) Handles XrLabel10.BeforePrint
        XrLabel10.Text = "Fecha Vto. " & vtoCaiEmpresa
    End Sub
    Private Sub XrLabel4_BeforePrint(sender As Object, e As PrintEventArgs) Handles XrLabel4.BeforePrint
        XrLabel4.Text = "Tel.: " & telEmpresa
    End Sub
    Private Sub XrLabel14_BeforePrint(sender As Object, e As PrintEventArgs) Handles XrLabel14.BeforePrint
        If MedPag = "TARJETA DEBITO/CREDITO" Then
            XrLabel14.Text = "NUMERO TARJETA: " & NumeroTarjeta & " TIPO: " & TipoTarjeta
        Else
            XrLabel14.Text = ""
        End If
    End Sub
    Private Sub XrLabel17_BeforePrint(sender As Object, e As PrintEventArgs) Handles XrLabel17.BeforePrint
        If DevVenta Then
            XrLabel17.Text = "NOTA DE CREDITO"
        Else
            XrLabel17.Text = ""
        End If
    End Sub

    Private Sub XrLabel15_BeforePrint(sender As Object, e As PrintEventArgs) Handles XrLabel15.BeforePrint
        If Nota <> Nothing Then
            XrLabel15.Text = "NOTA: " & Nota
        Else
            XrLabel15.Text = ""
        End If
    End Sub
End Class