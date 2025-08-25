Public Class Comentario
    Public Property IdComentario As Integer
    Public Property Proyecto As Proyecto
    Public Property Usuario As Usuario
    Public Property Texto As String
    Public Property FechaComentario As DateTime
    'constructor con parametros
    Public Sub New(idComentario As Integer, proyecto As Proyecto, usuario As Usuario, texto As String, fechaComentario As DateTime)
        Me.IdComentario = idComentario
        Me.Proyecto = proyecto
        Me.Usuario = usuario
        Me.Texto = texto
        Me.FechaComentario = fechaComentario
    End Sub
    'constructor sin parametros
    Public Sub New()
    End Sub
End Class
