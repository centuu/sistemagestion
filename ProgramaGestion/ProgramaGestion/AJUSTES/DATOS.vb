Imports System.IO
Public Class DATOS
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim configdata1 = TextEdit1.Text & ";" & TextEdit2.Text & ";" & TextEdit3.Text & ";" & TextEdit4.Text & ";" & TextEdit5.Text & ";" & TextEdit6.Text & ";" & TextEdit7.Text & ";" & TextEdit8.Text & ";" & DateEdit1.Text & ";" & TextEdit9.Text & ";" & DateEdit2.Text & ";" & CheckEdit1.Checked '& ";" & CajaAbierta
        Dim encriptado = AES_Encrypt(configdata1, "wq3289")
        If File.Exists(rutaConfig) Then
            Kill(rutaConfig)
        End If
        File.WriteAllText(rutaConfig, encriptado)
        MsgBox("Datos cargados correctamente.", vbOKOnly + vbInformation, "Hecho")
        configdata1 = File.ReadAllText(rutaConfig)
        Dim desencriptado = AES_Decrypt(configdata1, "wq3289")
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
        Me.Dispose()
    End Sub
    Private Sub AJUSTES_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If File.Exists(rutaConfig) Then
            Dim configData1 = File.ReadAllText(rutaConfig)
            Dim desencriptado = AES_Decrypt(configData1, "wq3289")
            Dim fieldValues = desencriptado.Split(";")
            TextEdit1.Text = fieldValues(0)
            TextEdit2.Text = fieldValues(1)
            TextEdit3.Text = fieldValues(2)
            TextEdit4.Text = fieldValues(3)
            TextEdit5.Text = fieldValues(4)
            TextEdit6.Text = fieldValues(5)
            TextEdit7.Text = fieldValues(6)
            TextEdit8.Text = fieldValues(7)
            DateEdit1.Text = fieldValues(8)
            TextEdit9.Text = fieldValues(9)
            DateEdit2.Text = fieldValues(10)
            CheckEdit1.Checked = fieldValues(11)
        End If
    End Sub
End Class