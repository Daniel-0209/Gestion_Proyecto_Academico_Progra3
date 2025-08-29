Public Class Entrega
    Public Property IdEntrega As Integer
    Public Property Proyecto As String
    Public Property NombreCurso As String
    Public Property NombreEstudiante As String
    Public Property FechaEntrega As Date
    Public Property Archivo As String

    'constructor con parametros

    'constructor sin parametros
    Public Sub New()
    End Sub

    Public Sub New(idEntrega As Integer, proyecto As String, nombreCurso As String, nombreEstudiante As String, fechaEntrega As Date, archivo As String)
        Me.IdEntrega = idEntrega
        Me.Proyecto = proyecto
        Me.NombreCurso = nombreCurso
        Me.NombreEstudiante = nombreEstudiante
        Me.FechaEntrega = fechaEntrega
        Me.Archivo = archivo
    End Sub
End Class
