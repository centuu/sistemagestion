Imports DevExpress.Xpo
Imports DevExpress.Xpo.DB
Imports DevExpress.XtraReports.UI
Imports System.IO
Public Class PAGO
    Public Session1 As Session = XpoHelper.GetNewSession()
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        GroupControl1.Visible = True
        GroupControl2.Visible = False
        GroupControl3.Visible = False
    End Sub
    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        GroupControl1.Visible = False
        GroupControl2.Visible = True
        GroupControl3.Visible = False
    End Sub
    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        Finalizar()
    End Sub
    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        Finalizar()
    End Sub
    Private Sub TextEdit2_EditValueChanged(sender As Object, e As EventArgs) Handles TextEdit2.EditValueChanged
        Try
            TextEdit3.Text = (CDec(TextEdit2.Text) - CDec(TextEdit1.Text))
            If TextEdit3.Text.Contains("-") Then
                TextEdit3.ForeColor = Color.DarkRed
            Else
                TextEdit3.ForeColor = Color.DarkGreen
            End If
        Catch ex As Exception
            TextEdit3.Text = "0"
            TextEdit3.ForeColor = Color.Black
        End Try
    End Sub
    Private Sub Finalizar()
        Try
            Dim Rec As String = TextEdit6.Text & "%"
            Dim ReportMASTER As New XtraReport()
            Dim ReportMASTER2 As New XtraReport()
            Dim ReportMASTER3 As New XtraReport()
            Dim ReportMASTER4 As New XtraReport()
            Dim ReportMASTER5 As New XtraReport()
            Dim ReportMASTER5D As New XtraReport()
            Dim ReportMASTER2D As New XtraReport()
            Dim report1 As New FACTURAC()
            Dim report2 As New REMITOR()
            Dim report3 As New FACTURAA()
            Dim report4 As New FACTURAB()
            Dim report5 As New REMITOX()
            Dim report5D As New REMITOX()
            Dim report2D As New REMITOR()
            Dim i As Integer = 1
            Dim ValorP As Decimal
            Dim Camb As Decimal = 0
            Dim Obs As String = ""
            Dim aux As Decimal = TotalImporte
            DevVenta = False
            If GroupControl1.Visible Then
                If TextEdit2.Text = "" Then
                    MsgBox("Debe ingresar un monto.", vbOKOnly + vbExclamation, "error")
                    Exit Sub
                End If
                ValorP = TextEdit2.Text
                Camb = TextEdit3.Text
                Obs = TextBox2.Text
                If CheckEdit1.Checked Then
                    TotalImporte = 0
                    MedPag = "CUENTA CORRIENTE"
                    ValorP = 0
                    Camb = 0
                Else
                    MedPag = "CONTADO"
                End If
            ElseIf GroupControl2.Visible Then
                MedPag = "TARJETA DEBITO/CREDITO"
                Obs = TextBox1.Text
                ValorP = TextEdit5.Text
            ElseIf GroupControl3.Visible Then
                MedPag = "CHEQUE"
                Obs = TextBox3.Text
                ValorP = TextEdit13.Text
            End If
            If Remito Then
                Dim iPath = Application.StartupPath & "\Remitos"
                Directory.CreateDirectory(iPath)
                nroRemito = i
                Dim iPath2 = "\Remito_Nro-" & i & ".xlsx"
                While File.Exists(iPath & iPath2)
                    i += 1
                    iPath2 = "\Remito_Nro-" & i & ".xlsx"
                End While
                nroRemitoAsoc = i
            Else
                i = 0
                nroRemitoAsoc = 0
            End If
            If MsgBox("¿Finalizar venta?", vbYesNo + vbQuestion, "Atención") = vbYes Then
                SplashScreenManager1.ShowWaitForm()
                Session1.ExecuteNonQuery("INSERT INTO Ventas(Fecha,Cantidad,ImporteTotal,ValorPago,Cambio,MedioPago,Recargo,Observacion,TipoFactura,Remito,Cliente,Usuario,NotaCredito) VALUES('" & Now.Day & "/" & Now.Month & "/" & Now.Year & "'," & TotalCantidad & "," & TotalImporte.ToString.Replace(",", ".") & "," & ValorP.ToString.Replace(",", ".") & "," & Camb.ToString.Replace(",", ".") & ",'" & MedPag & "','" & Rec & "','" & Obs & "','" & TipoFactura & "'," & i & ",'" & idCli & "','" & Usuario & "', 0)")
                Dim idV = Session1.ExecuteScalar("SELECT MAX(idVenta) FROM Ventas")
                If MedPag = "TARJETA DEBITO/CREDITO" Then
                    NumeroTarjeta = "XXXX-XXXX-XXXX-" & TextEdit7.Text
                    TipoTarjeta = TextEdit16.Text
                    Session1.ExecuteNonQuery("INSERT INTO DetallePago(idVenta,MedioPago,Banco,TipoTarjeta,NroTarjeta,FechaVto,Titular,TipoCheque,FechaEmision,FechaCobro) VALUES(" & idV & ",'" & MedPag & "','" & TextEdit10.Text & "','" & TextEdit16.Text & "','" & NumeroTarjeta & "','" & TextEdit8.Text & "','" & TextEdit9.Text & "','','','')")
                ElseIf MedPag = "CHEQUE" Then
                    Session1.ExecuteNonQuery("INSERT INTO DetallePago(idVenta,MedioPago,Banco,TipoTarjeta,NroTarjeta,FechaVto,Titular,TipoCheque,FechaEmision,FechaCobro) VALUES(" & idV & ",'" & MedPag & "','" & TextEdit11.Text & "','','','','" & TextEdit12.Text & "','" & TextEdit14.Text & "','" & DateEdit1.Text & "','" & DateEdit2.Text & "')")
                End If
                If MedPag = "CUENTA CORRIENTE" Then
                    Session1.ExecuteNonQuery("INSERT INTO Caja(Apertura,Cierre,Tipo,Valor,idVenta,Observacion) VALUES('" & Now.Day & "/" & Now.Month & "/" & Now.Year & "','0','CUENTA CORRIENTE',0," & idV & ",'" & Obs & "')")
                Else
                    Session1.ExecuteNonQuery("INSERT INTO Caja(Apertura,Cierre,Tipo,Valor,idVenta,Observacion) VALUES('" & Now.Day & "/" & Now.Month & "/" & Now.Year & "','0','INGRESO'," & TotalImporte.ToString.Replace(",", ".") & "," & idV & ",'" & Obs & "')")
                End If
                Session1.ExecuteNonQuery("UPDATE DetalleVentas SET idVenta = " & idV & " WHERE idVenta = 0")
                ' FACTURAS
                TotalImporte = aux
                'Dim resultSet As SelectedData = Session1.ExecuteQuery("SELECT CASE WHEN [idVenta] BETWEEN 1 AND 9 THEN LEFT('0000000'+CONVERT(VARCHAR(7),[idVenta]), 8) ELSE LEFT('000000'+CONVERT(VARCHAR(6),[idVenta]), 8) END FROM Ventas WHERE idVenta = " & idV)
                'nroFactura &= resultSet.ResultSet(0).Rows(0).Values(0)
                Dim aux2 As String = ""
                If idV < 10 Then
                    aux2 = "0000000" & idV
                ElseIf idV >= 10 And idV < 100 Then
                    aux2 = "000000" & idV
                ElseIf idV >= 100 And idV < 1000 Then
                    aux2 = "00000" & idV
                ElseIf idV >= 1000 And idV < 10000 Then
                    aux2 = "0000" & idV
                ElseIf idV >= 10000 And idV < 100000 Then
                    aux2 = "000" & idV
                ElseIf idV >= 100000 And idV < 1000000 Then
                    aux2 = "00" & idV
                ElseIf idV >= 1000000 And idV < 10000000 Then
                    aux2 = "0" & idV
                ElseIf idV >= 10000000 And idV < 100000000 Then
                    aux2 = idV
                End If
                nroFactura &= aux2
                If opTipoFactura = 0 Then
                    ' FACTURA A
                    Directory.CreateDirectory(Application.StartupPath & "\Facturas\A")
                    report3.RequestParameters = False
                    report3.Parameters.Item("idVenta").Value = idV
                    report3.CreateDocument()
                    ReportMASTER3.Pages.AddRange(report3.Pages)
                    report3.ExportToXlsx(Application.StartupPath & "\Facturas\A\Factura_Nro-" & idV & ".xlsx")
                ElseIf opTipoFactura = 1 Then
                    ' FACTURA B
                    Directory.CreateDirectory(Application.StartupPath & "\Facturas\B")
                    report4.RequestParameters = False
                    report4.Parameters.Item("idVenta").Value = idV
                    report4.CreateDocument()
                    ReportMASTER4.Pages.AddRange(report4.Pages)
                    report4.ExportToXlsx(Application.StartupPath & "\Facturas\B\Factura_Nro-" & idV & ".xlsx")
                ElseIf opTipoFactura = 2 Then
                    ' FACTURA C
                    Directory.CreateDirectory(Application.StartupPath & "\Facturas\C")
                    report1.RequestParameters = False
                    report1.Parameters.Item("idVenta").Value = idV
                    report1.CreateDocument()
                    ReportMASTER.Pages.AddRange(report1.Pages)
                    report1.ExportToXlsx(Application.StartupPath & "\Facturas\C\Factura_Nro-" & idV & ".xlsx")
                End If
                If Remito Then
                    ' REMITO
                    If i < 10 Then
                        nroRemito = "0001 - 0000000" & i
                    ElseIf i >= 10 And i < 100 Then
                        nroRemito = "0001 - 000000" & i
                    ElseIf i >= 100 And i < 1000 Then
                        nroRemito = "0001 - 00000" & i
                    ElseIf i >= 1000 And i < 10000 Then
                        nroRemito = "0001 - 0000" & i
                    ElseIf i >= 10000 And i < 100000 Then
                        nroRemito = "0001 - 000" & i
                    ElseIf i >= 100000 And i < 1000000 Then
                        nroRemito = "0001 - 00" & i
                    ElseIf i >= 1000000 And i < 10000000 Then
                        nroRemito = "0001 - 0" & i
                    ElseIf i >= 10000000 And i < 100000000 Then
                        nroRemito = "0001 - " & i
                    End If
                    If opTipoFactura = 0 Then
                        TipoRemito = "ORIGINAL"
                        report2.RequestParameters = False
                        report2.Parameters.Item("idVenta").Value = idV
                        report2.CreateDocument()
                        ReportMASTER2.Pages.AddRange(report2.Pages)
                        report2.ExportToXlsx(Application.StartupPath & "\Remitos\Remito_Nro-" & i & ".xlsx")
                        TipoRemito = "DUPLICADO"
                        report2D.RequestParameters = False
                        report2D.Parameters.Item("idVenta").Value = idV
                        report2D.CreateDocument()
                        ReportMASTER2D.Pages.AddRange(report2D.Pages)
                        report2D.ExportToXlsx(Application.StartupPath & "\Remitos\Remito_Nro-" & i & "-D.xlsx")
                    Else
                        TipoRemito = "ORIGINAL"
                        report5.RequestParameters = False
                        report5.Parameters.Item("idVenta").Value = idV
                        report5.CreateDocument()
                        ReportMASTER5.Pages.AddRange(report5.Pages)
                        report5.ExportToXlsx(Application.StartupPath & "\Remitos\Remito_Nro-" & i & ".xlsx")
                        TipoRemito = "DUPLICADO"
                        report5D.RequestParameters = False
                        report5D.Parameters.Item("idVenta").Value = idV
                        report5D.CreateDocument()
                        ReportMASTER5D.Pages.AddRange(report5D.Pages)
                        report5D.ExportToXlsx(Application.StartupPath & "\Remitos\Remito_Nro-" & i & "-D.xlsx")
                    End If
                End If
                SplashScreenManager1.CloseWaitForm()
            Else
                Exit Sub
            End If
            If MsgBox("¿Desea imprimir la factura?", vbYesNo + vbQuestion, "VENTA FINALIZADA") = vbYes Then
                If opTipoFactura = 0 Then
                    ' FACTURA A
                    Using printTool As New ReportPrintTool(ReportMASTER3)
                        printTool.Report.ShowRibbonPreviewDialog()
                    End Using
                ElseIf opTipoFactura = 1 Then
                    ' FACTURA B
                    Using printTool As New ReportPrintTool(ReportMASTER4)
                        printTool.Report.ShowRibbonPreviewDialog()
                    End Using
                ElseIf opTipoFactura = 2 Then
                    ' FACTURA C
                    Using printTool As New ReportPrintTool(ReportMASTER)
                        printTool.Report.ShowRibbonPreviewDialog()
                    End Using
                End If
            End If
            If Remito Then
                If MsgBox("¿Desea imprimir el remito asociado?", vbYesNo + vbQuestion, "REMITO") = vbYes Then
                    If opTipoFactura = 0 Then
                        Using printTool As New ReportPrintTool(ReportMASTER2)
                            printTool.Report.ShowRibbonPreviewDialog()
                        End Using
                    Else
                        Using printTool As New ReportPrintTool(ReportMASTER5)
                            printTool.Report.ShowRibbonPreviewDialog()
                        End Using
                    End If
                End If
            End If
            TotalCantidad = 0
            TotalImporte = 0
            nroFactura = "0001 - "
            NUEVAVENTA.Dispose()
            Me.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub MEDIOPAGO_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If Not GroupControl1.Visible Or Not GroupControl2.Visible Then Exit Sub
        If e.KeyCode = Keys.Enter Then
            Finalizar()
        End If
    End Sub
    Private Sub PAGO_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextEdit1.Text = TotalImporte
        TextEdit4.Text = TotalImporte
        TextEdit13.Text = TotalImporte
        TextEdit6.Text = "0"
        TextEdit2.Text = "0"
    End Sub
    Private Sub TextEdit6_TextChanged(sender As Object, e As EventArgs) Handles TextEdit6.TextChanged
        Try
            TextEdit5.Text = ((TextEdit6.Text / 100) * TextEdit4.Text) + TextEdit4.Text
        Catch ex As Exception
            TextEdit5.Text = "0"
        End Try
    End Sub
    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        If CheckEdit2.Checked Then
            TextEdit2.Text = SpinEdit2.Value * Dolar()
        Else
            TextEdit2.Text = TextEdit1.Text
        End If
    End Sub
    Private Sub CheckEdit1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEdit1.CheckedChanged
        If CheckEdit1.Checked Then
            SpinEdit1.Visible = True
            LabelControl8.Visible = True
            SpinEdit1.Value = 1
            TextEdit1.Text = "0"
            TextEdit2.Text = "0"
            TextEdit3.Text = "0"
        Else
            SpinEdit1.Visible = False
            LabelControl8.Visible = False
            TextEdit1.Text = TotalImporte
            TextBox2.Text = ""
        End If
    End Sub
    Private Sub SpinEdit1_ValueChanged(sender As Object, e As EventArgs) Handles SpinEdit1.ValueChanged
        If SpinEdit1.Value = 0 Then
            Exit Sub
        ElseIf SpinEdit1.Value = 1 Then
            TextBox2.Text = "CTA. CORRIENTE A " & SpinEdit1.Value & " DÍA"
        Else
            TextBox2.Text = "CTA. CORRIENTE A " & SpinEdit1.Value & " DÍAS"
        End If
        TextBox2.Text &= " POR $" & TotalImporte
    End Sub
    Private Sub SimpleButton7_Click(sender As Object, e As EventArgs) Handles SimpleButton7.Click
        Finalizar()
    End Sub
    Private Sub SimpleButton6_Click(sender As Object, e As EventArgs) Handles SimpleButton6.Click
        GroupControl1.Visible = False
        GroupControl2.Visible = False
        GroupControl3.Visible = True
    End Sub
    Private Sub CheckEdit2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEdit2.CheckedChanged
        If CheckEdit2.Checked Then
            SpinEdit2.Visible = True
            LabelControl21.Visible = True
            LabelControl22.Visible = True
            LabelControl22.Text = "$" & Dolar()
        Else
            SpinEdit2.Visible = False
            LabelControl21.Visible = False
            LabelControl22.Visible = False
            TextBox2.Text = ""
        End If
    End Sub
    Private Sub SpinEdit2_ValueChanged(sender As Object, e As EventArgs) Handles SpinEdit2.ValueChanged
        TextBox2.Text = "PAGÓ CON DÓLARES: U$D" & SpinEdit2.Value
        TextEdit2.Text = SpinEdit2.Value * Dolar()
    End Sub
End Class