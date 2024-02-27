Imports System.Security.Cryptography
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Net
Imports System.IO
Imports Newtonsoft.Json.Linq
Imports Newtonsoft.Json
Module Module1
    Public Declare Auto Function SetProcessWorkingSetSize Lib "kernel32.dll" (procHandle As IntPtr, min As Int32, max As Int32) As Boolean
    ' Principal
    Public rutaConfig As String = Application.StartupPath & "\config.ini"
    Public datosCargados As Boolean
    Public NuevoLayer As Integer = 0
    Public Usuario As String
    Public Permisos As String
    ' Caja
    Public CajaAbierta As Boolean = False
    Public nroOperacion As Integer = 0
    ' Factura
    Public Nota As String = ""
    Public TotalImporte As Decimal = 0
    Public TotalCantidad As Integer = 0
    Public rec As String = ""
    Public nroFactura As String = "0001 - "
    Public nroRemito As String = ""
    Public TipoFactura As String = ""
    Public idCli As String = ""
    Public NombreCliente As String = ""
    Public cuitCliente As String = ""
    Public TelCliente As String = ""
    Public Domicilio As String = ""
    Public Localidad As String = ""
    Public Remito As Boolean = False
    Public opTipoFactura As Integer = -1
    Public TipoRemito As String = ""
    Public MedPag As String = ""
    Public nroRemitoAsoc As Integer
    Public TipoTarjeta As String = ""
    Public NumeroTarjeta As String = ""
    Public DevVenta As Boolean = False
    Public nroNotaCredito As String = ""
    ' Datos Empresa
    Public nombreEmpresa As String
    Public domicilioEmpresa As String
    Public localidadEmpresa As String
    Public cpostalEmpresa As String
    Public provEmpresa As String
    Public monotributoEmpresa As String
    Public telEmpresa As String
    Public cuitEmpresa As String
    Public iniActividad As String
    Public caiEmpresa As String
    Public vtoCaiEmpresa As String
    Public ivaMonotributo As Boolean
    ' Seguridad
    Public Function AES_Decrypt(input As String, pass As String) As String
        Dim AES As New RijndaelManaged
        Dim Hash_AES As New MD5CryptoServiceProvider
        Try
            Dim hash(31) As Byte
            Dim temp As Byte() = Hash_AES.ComputeHash(ASCIIEncoding.ASCII.GetBytes(pass))
            Array.Copy(temp, 0, hash, 0, 16)
            Array.Copy(temp, 0, hash, 15, 16)
            AES.Key = hash
            AES.Mode = CipherMode.ECB
            Dim DESDecrypter As ICryptoTransform = AES.CreateDecryptor
            Dim Buffer As Byte() = Convert.FromBase64String(input)
            Return ASCIIEncoding.ASCII.GetString(DESDecrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function AES_Encrypt(input As String, pass As String) As String
        Dim AES As New RijndaelManaged
        Dim Hash_AES As New MD5CryptoServiceProvider
        Try
            Dim hash(31) As Byte
            Dim temp As Byte() = Hash_AES.ComputeHash(ASCIIEncoding.ASCII.GetBytes(pass))
            Array.Copy(temp, 0, hash, 0, 16)
            Array.Copy(temp, 0, hash, 15, 16)
            AES.Key = hash
            AES.Mode = CipherMode.ECB
            Dim DESEncrypter As ICryptoTransform = AES.CreateEncryptor
            Dim Buffer As Byte() = ASCIIEncoding.ASCII.GetBytes(input)
            Return Convert.ToBase64String(DESEncrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Sub LiberarMemoria()
        Try
            Dim memoria As Process = Process.GetCurrentProcess()
            SetProcessWorkingSetSize(memoria.Handle, -1, -1)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Function ValidarMail(sMail As String) As Boolean
        Return Regex.IsMatch(sMail, "^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$")
    End Function
    Public Function ValidarTelefono(sTel As String) As Boolean
        Return Regex.IsMatch(sTel, "^(?:(?:00)?549?)?0?(?:11|[2368]\d)(?:(?=\d{0,2}15)\d{2})??\d{8}$")
    End Function
    Public Function ValidarCuit(sCuit As String) As Boolean
        Return Regex.IsMatch(sCuit, "^\b(20|23|24|27|30|33|34)(\D)?[0-9]{8}(\D)?[0-9]$")
    End Function
    Public Function Dolar() As String
        Try
            'Dim Proxy2 As New WebProxy("127.0.0.1:8008", True)
            'Proxy2.Credentials = New NetworkCredential("user", "pass")
            Dim request As HttpWebRequest = DirectCast(WebRequest.Create("http://ws.geeklab.com.ar/dolar/get-dolar-json.php"), HttpWebRequest)
            'With request
            '    .Proxy = Proxy2
            'End With
            Dim response As HttpWebResponse = DirectCast(request.GetResponse(), HttpWebResponse)
            Dim reader As New StreamReader(response.GetResponseStream())
            Dim rawresp As String = reader.ReadToEnd()
            Dim myObject As JObject = JsonConvert.DeserializeObject(rawresp)
            Dim a As String = myObject.First.First
            a = a.Substring(0, a.Length)
            Return myObject.First.Last.ToString.Replace(".", ",")
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function ObtenerMes(mes As String) As Integer
        Dim valor = 0
        If mes = "ENERO" Then
            valor = 1
        ElseIf mes = "FEBRERO" Then
            valor = 2
        ElseIf mes = "MARZO" Then
            valor = 3
        ElseIf mes = "ABRIL" Then
            valor = 4
        ElseIf mes = "MAYO" Then
            valor = 5
        ElseIf mes = "JUNIO" Then
            valor = 6
        ElseIf mes = "JULIO" Then
            valor = 7
        ElseIf mes = "AGOSTO" Then
            valor = 8
        ElseIf mes = "SEPTIEMBRE" Then
            valor = 9
        ElseIf mes = "OCTUBRE" Then
            valor = 10
        ElseIf mes = "NOVIEMBRE" Then
            valor = 11
        ElseIf mes = "DICIEMBRE " Then
            valor = 12
        End If
        Return valor
    End Function
End Module