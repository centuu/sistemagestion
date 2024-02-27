Imports System.Threading
Imports DevExpress.Xpo
Imports DevExpress.Xpo.DB
Public NotInheritable Class XpoHelper
    Private Shared fDataLayer As IDataLayer
    Private Shared lockObject As New Object()
    Public Shared Function GetNewSession() As Session
        Return New Session(DataLayer)
    End Function
    Public Shared Function GetNewUnitOfWork() As UnitOfWork
        Return New UnitOfWork(DataLayer)
    End Function
    Public Shared Function GetDataLayer(autoCreationOption As AutoCreateOption) As IDataLayer
        Try
            Dim conn As String = MSSqlConnectionProvider.GetConnectionString("localhost\sqlexpress", "BDArtLimpieza")
            Return XpoDefault.GetDataLayer(conn, autoCreationOption)
        Catch ex As Exception
        End Try
#Disable Warning BC42105
    End Function
#Enable Warning BC42105
    Private Shared ReadOnly Property DataLayer() As IDataLayer
        Get
            If fDataLayer Is Nothing Then
                SyncLock lockObject
                    If Thread.VolatileRead(fDataLayer) Is Nothing Then
                        Thread.VolatileWrite(fDataLayer, GetDataLayer(NuevoLayer))
                    End If
                End SyncLock
            End If
            Return fDataLayer
        End Get
    End Property
End Class





