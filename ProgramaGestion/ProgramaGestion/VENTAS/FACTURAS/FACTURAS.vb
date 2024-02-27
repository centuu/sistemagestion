Public Class FACTURAS
    Private Sub RECIBOS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SplashScreenManager1.ShowWaitForm()
        SpreadsheetControl1.LoadDocument(rec)
        SplashScreenManager1.CloseWaitForm()
    End Sub
End Class