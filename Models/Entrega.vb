Public Class Entrega
    Public Property IdEntrega As Integer
    Public Property Proyecto As String
    Public Property Usuario As String
    Public Property FechaEntrega As Date
    Public Property Archivo As String
    Public Property EstadoEntrega As String
    'constructor con parametros
    Public Sub New(idEntrega As Integer, proyecto As String, usuario As String, fechaEntrega As Date, archivo As String, estadoEntrega As String)
        Me.IdEntrega = idEntrega
        Me.Proyecto = proyecto
        Me.Usuario = usuario
        Me.FechaEntrega = fechaEntrega
        Me.Archivo = archivo
        Me.EstadoEntrega = estadoEntrega
    End Sub
    'constructor sin parametros
    Public Sub New()
    End Sub

End Class
