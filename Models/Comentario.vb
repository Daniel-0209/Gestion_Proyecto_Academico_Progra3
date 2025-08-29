Public Class Comentario
    Public Property IdComentario As Integer
    Public Property Mensaje As String
    Public Property FechaEnvio As DateTime
    Public Property Destinatario As String

    ' Constructor con parámetros
    Public Sub New(idComentario As Integer, mensaje As String, fechaEnvio As DateTime, destinatario As String)
        Me.IdComentario = idComentario
        Me.Mensaje = mensaje
        Me.FechaEnvio = fechaEnvio
        Me.Destinatario = destinatario
    End Sub

    ' Constructor sin parámetros
    Public Sub New()
    End Sub
End Class