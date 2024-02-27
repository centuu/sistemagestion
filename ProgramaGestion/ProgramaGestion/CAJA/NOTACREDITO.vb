Imports System.IO
Imports DevExpress.Xpo
Imports DevExpress.Xpo.DB
Imports DevExpress.XtraReports.UI
Public Class DEVOLUCION
    Public Session1 As Session = XpoHelper.GetNewSession()
    Public dev As Boolean = False
    Private Sub TextEdit1_TextChanged(sender As Object, e As EventArgs) Handles TextEdit1.TextChanged
        Try
            If TextEdit1.Text <> Nothing Then
                Dim idV = TextEdit1.Text
                Dim resultSet As SelectedData = Session1.ExecuteQuery("SELECT Observacion FROM Ventas WHERE idVenta = " & idV)
                If resultSet.ResultSet(0).Rows(0).Values(0).ToString.Contains("VENTA ANULADA") Then
                    Exit Sub
                End If
                resultSet = Session1.ExecuteQuery("SELECT * FROM DetalleVentas WHERE idVenta = " & idV)
                XpDataView1.LoadData(resultSet)
                dev = True
            Else
                dev = False
            End If
        Catch ex As Exception
            dev = False
            XpDataView1.LoadData(Nothing)
        End Try
    End Sub
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If Not dev Then Exit Sub
        Dim total As Decimal = 0
        'Dim cant As Integer = 0
        Dim ReportMASTER As New XtraReport()
        Dim ReportMASTER1 As New XtraReport()
        Dim ReportMASTER3 As New XtraReport()
        Dim ReportMASTER4 As New XtraReport()
        Dim report As New NOTACREDITO()
        Dim report1 As New FACTURAC()
        Dim report3 As New FACTURAA()
        Dim report4 As New FACTURAB()
        Dim idV = TextEdit1.Text
        DevVenta = True
        Try
            If MsgBox("¿Desea anular la venta?", vbYesNo + vbQuestion, "Atención") = vbYes Then
                For i As Integer = 0 To GridView1.RowCount - 1
                    total += GridView1.GetRowCellValue(i, colPrecioTot)
                    'cant += GridView1.GetRowCellValue(i, colCantidad)
                    Session1.ExecuteNonQuery("UPDATE Articulos SET Stock = Stock + " & GridView1.GetRowCellValue(i, colCantidad) & " WHERE idArticulo = " & ObtenerCodigo(GridView1.GetRowCellValue(i, colArticulo)))
                Next
                ' Nota de Credito
                'Dim x As Integer = 1
                'Dim iPath = Application.StartupPath & "\NotasCredito"
                'Directory.CreateDirectory(iPath)
                'Dim iPath2 = "\Nota_Nro-" & x & ".xlsx"
                'While File.Exists(iPath & iPath2)
                '    x += 1
                '    iPath2 = "\Nota_Nro-" & x & ".xlsx"
                'End While
                Dim resultSet As SelectedData = Session1.ExecuteQuery("SELECT idVenta, TipoFactura,MedioPago FROM Ventas WHERE idVenta = " & idV)
                Session1.ExecuteNonQuery("INSERT INTO Caja(Apertura,Cierre,Tipo,Valor,idVenta,Observacion) VALUES('" & Now.Day & "/" & Now.Month & "/" & Now.Year & "','0','NOTA DE CREDITO'," & (total * -1).ToString.Replace(",", ".") & "," & idV & ", 'FACTURA Nº " & idV & "')")
                Session1.ExecuteNonQuery("UPDATE Ventas SET ImporteTotal = 0, Observacion = 'VENTA ANULADA: " & TextEdit2.Text & " VALOR: " & total.ToString.Replace(",", ".") & "' WHERE idVenta = " & idV)
                TipoFactura = resultSet.ResultSet(0).Rows(0).Values(1)
                TotalImporte = total
                MedPag = resultSet.ResultSet(0).Rows(0).Values(2)
                Dim aux As String = ""
                If idV < 10 Then
                    aux = "0000000" & idV
                ElseIf idV >= 10 And idV < 100 Then
                    aux = "000000" & idV
                ElseIf idV >= 100 And idV < 1000 Then
                    aux = "00000" & idV
                ElseIf idV >= 1000 And idV < 10000 Then
                    aux = "0000" & idV
                ElseIf idV >= 10000 And idV < 100000 Then
                    aux = "000" & idV
                ElseIf idV >= 100000 And idV < 1000000 Then
                    aux = "00" & idV
                ElseIf idV >= 1000000 And idV < 10000000 Then
                    aux = "0" & idV
                ElseIf idV >= 10000000 And idV < 100000000 Then
                    aux = idV
                End If
                nroFactura &= aux
                'nroFactura &= resultSet.ResultSet(0).Rows(0).Values(0)
                If MedPag = "TARJETA DEBITO/CREDITO" Then
                    resultSet = Session1.ExecuteQuery("SELECT NroTarjeta,TipoTarjeta FROM DetallePago WHERE idVenta = " & idV)
                    NumeroTarjeta = resultSet.ResultSet(0).Rows(0).Values(0)
                    TipoTarjeta = resultSet.ResultSet(0).Rows(0).Values(1)
                End If
                If TipoFactura = "RESPONSABLE INSCRIPTO" Then
                    ' FACTURA A
                    Directory.CreateDirectory(Application.StartupPath & "\Facturas\Nota de Credito\A")
                    report3.RequestParameters = False
                    report3.Parameters.Item("idVenta").Value = idV
                    report3.CreateDocument()
                    ReportMASTER3.Pages.AddRange(report3.Pages)
                    report3.ExportToXlsx(Application.StartupPath & "\Facturas\Nota de Credito\A\Factura_Nro-" & idV & ".xlsx")
                ElseIf TipoFactura = "CONSUMIDOR FINAL" Then
                    ' FACTURA B
                    Directory.CreateDirectory(Application.StartupPath & "\Facturas\Nota de Credito\B")
                    report4.RequestParameters = False
                    report4.Parameters.Item("idVenta").Value = idV
                    report4.CreateDocument()
                    ReportMASTER4.Pages.AddRange(report4.Pages)
                    report4.ExportToXlsx(Application.StartupPath & "\Facturas\Nota de Credito\B\Factura_Nro-" & idV & ".xlsx")
                ElseIf TipoFactura = "MONOTRIBUTISTA EXENTO" Then
                    ' FACTURA C
                    Directory.CreateDirectory(Application.StartupPath & "\Facturas\Nota de Credito\C")
                    report1.RequestParameters = False
                    report1.Parameters.Item("idVenta").Value = idV
                    report1.CreateDocument()
                    ReportMASTER.Pages.AddRange(report1.Pages)
                    report1.ExportToXlsx(Application.StartupPath & "\Facturas\Nota de Credito\C\Factura_Nro-" & idV & ".xlsx")
                End If
                'If x < 10 Then
                '    nroNotaCredito = "0001 - 0000000" & x
                'Else
                '    nroNotaCredito = "0001 - 000000" & x
                'End If
                'report.RequestParameters = False
                'report.Parameters.Item("idVenta").Value = idV
                'report.CreateDocument()
                'ReportMASTER1.Pages.AddRange(report.Pages)
                'report.ExportToXlsx(iPath & iPath2)
                If MsgBox("¿Desea imprimir la nota de credito?", vbYesNo + vbQuestion, "VENTA ANULADA") = vbYes Then
                    If TipoFactura = "RESPONSABLE INSCRIPTO" Then
                        ' FACTURA A
                        Using printTool As New ReportPrintTool(ReportMASTER3)
                            printTool.Report.ShowRibbonPreviewDialog()
                        End Using
                    ElseIf TipoFactura = "CONSUMIDOR FINAL" Then
                        ' FACTURA B
                        Using printTool As New ReportPrintTool(ReportMASTER4)
                            printTool.Report.ShowRibbonPreviewDialog()
                        End Using
                    ElseIf TipoFactura = "MONOTRIBUTISTA EXENTO" Then
                        ' FACTURA C
                        Using printTool As New ReportPrintTool(ReportMASTER)
                            printTool.Report.ShowRibbonPreviewDialog()
                        End Using
                    End If
                End If
                ' Nota de Credito
                'If MsgBox("¿Desea imprimir la nota de crédito?", vbYesNo + vbQuestion, "VENTA ANULADA") = vbYes Then
                '    Using printTool As New ReportPrintTool(ReportMASTER1)
                '        printTool.Report.ShowRibbonPreviewDialog()
                '    End Using
                'End If
                nroFactura = "0001 - "
                TotalImporte = 0
                XpDataView1.LoadData(Nothing)
                End If
        Catch ex As Exception
            XpDataView1.LoadData(Nothing)
        End Try
    End Sub
    Private Function ObtenerCodigo(nombre As String) As Integer
        Try
            Dim resultSet As SelectedData = Session1.ExecuteQuery("SELECT idArticulo FROM Articulos WHERE Descripcion = '" & nombre & "'")
            Return resultSet.ResultSet(0).Rows(0).Values(0)
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Private Sub DEVOLUCION_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextEdit1.Text = nroOperacion
        Try
            Dim idV = TextEdit1.Text
            Dim resultSet As SelectedData = Session1.ExecuteQuery("SELECT Observacion FROM Ventas WHERE idVenta = " & idV)
            If resultSet.ResultSet(0).Rows(0).Values(0).ToString.Contains("VENTA ANULADA") Then
                Me.Dispose()
            End If
            resultSet = Session1.ExecuteQuery("SELECT * FROM DetalleVentas WHERE idVenta = " & idV)
            XpDataView1.LoadData(resultSet)
        Catch ex As Exception
            XpDataView1.LoadData(Nothing)
        End Try
    End Sub
End Class