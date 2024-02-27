Imports System.IO
Imports DevExpress.XtraEditors
Public Class INICIO
    Private Sub TileItem2_ItemClick(sender As Object, e As TileItemEventArgs) Handles TileItem2.ItemClick
        If Not datosCargados Then Exit Sub
        If Permisos.Contains("CL") Then
            CLIENTES.Show()
        Else
            MsgBox("No tiene permisos para ingresar a esta sección.", vbOKOnly + vbExclamation, "Advertencia")
        End If
    End Sub
    Private Sub TileItem1_ItemClick(sender As Object, e As TileItemEventArgs) Handles TileItem1.ItemClick
        If Not datosCargados Then Exit Sub
        If Permisos.Contains("ST") Then
            STOCK.Show()
        Else
            MsgBox("No tiene permisos para ingresar a esta sección.", vbOKOnly + vbExclamation, "Advertencia")
        End If
    End Sub
    Private Sub TileItem3_ItemClick(sender As Object, e As TileItemEventArgs) Handles TileItem3.ItemClick
        If Not datosCargados Then Exit Sub
        If Permisos.Contains("VE") Then
            VENTAS.Show()
        Else
            MsgBox("No tiene permisos para ingresar a esta sección.", vbOKOnly + vbExclamation, "Advertencia")
        End If
    End Sub
    Private Sub INICIO_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TileControl1.Text = "Bienvenido, " & Usuario
        If Permisos.Contains("AC") Then
            TileItem8.Visible = True
        Else
            TileItem8.Visible = False
        End If
        If File.Exists(rutaConfig) Then
            Dim configData1 = File.ReadAllText(rutaConfig)
            Dim desencriptado = AES_Decrypt(configData1, "wq3289")
            Dim fieldValues = desencriptado.Split(";")
            nombreEmpresa = fieldValues(0)
            domicilioEmpresa = fieldValues(1)
            localidadEmpresa = fieldValues(2)
            provEmpresa = fieldValues(3)
            cpostalEmpresa = fieldValues(4)
            monotributoEmpresa = fieldValues(5)
            telEmpresa = fieldValues(6)
            cuitEmpresa = fieldValues(7)
            iniActividad = fieldValues(8)
            caiEmpresa = fieldValues(9)
            vtoCaiEmpresa = fieldValues(10)
            ivaMonotributo = fieldValues(11)
            'CajaAbierta = fieldValues(12)
            datosCargados = True
        Else
            MsgBox("BIENVENIDO AL SISTEMA DE GESTIÓN DE VENTAS. Por favor, entre a EMPRESA y configure los datos requeridos.", vbOKOnly)
            datosCargados = False
        End If
    End Sub
    Private Sub INICIO_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()
    End Sub
    Private Sub TileItem5_ItemClick(sender As Object, e As TileItemEventArgs) Handles TileItem5.ItemClick
        If Not datosCargados Then Exit Sub
        If Permisos.Contains("CA") Then
            CAJA.Show()
        Else
            MsgBox("No tiene permisos para ingresar a esta sección.", vbOKOnly + vbExclamation, "Advertencia")
        End If
    End Sub
    Private Sub TileItem6_ItemClick(sender As Object, e As TileItemEventArgs) Handles TileItem6.ItemClick
        If Permisos.Contains("AJ") Then
            USUARIOS.Show()
        Else
            MsgBox("No tiene permisos para ingresar a esta sección.", vbOKOnly + vbExclamation, "Advertencia")
        End If
    End Sub
    Private Sub TileItem7_ItemClick(sender As Object, e As TileItemEventArgs) Handles TileItem7.ItemClick
        If Permisos.Contains("AJ") Then
            DATOS.Show()
        Else
            MsgBox("No tiene permisos para ingresar a esta sección.", vbOKOnly + vbExclamation, "Advertencia")
        End If
    End Sub
    Private Sub TileItem4_ItemClick(sender As Object, e As TileItemEventArgs) Handles TileItem4.ItemClick
        If Permisos.Contains("VE") Then
            LISTAPRECIOS.Show()
        Else
            MsgBox("No tiene permisos para ingresar a esta sección.", vbOKOnly + vbExclamation, "Advertencia")
        End If
    End Sub
    Private Sub TileItem9_ItemClick(sender As Object, e As TileItemEventArgs) Handles TileItem9.ItemClick
        LoginForm1.Show()
    End Sub
    Private Sub TileItem8_ItemClick(sender As Object, e As TileItemEventArgs) Handles TileItem8.ItemClick
        If Permisos.Contains("AC") Then
            ACTIVAR.Show()
        Else
            MsgBox("No tiene permisos para ingresar a esta sección.", vbOKOnly + vbExclamation, "Advertencia")
        End If
    End Sub
End Class