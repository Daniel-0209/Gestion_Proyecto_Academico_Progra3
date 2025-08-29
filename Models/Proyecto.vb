Public Class Proyecto
    Public Property IdProyecto As Integer
    Public Property Titulo As String
    Public Property Descripcion As String
    Public Property FechaInicio As DateTime
    Public Property FechaFin As DateTime
    Public Property NombreProfesor As String
    Public Property NombreCurso As String

    'construtor con parametros


    'constructor sin parametros
    Public Sub New()
    End Sub

    Public Sub New(idProyecto As Integer, titulo As String, descripcion As String, fechaInicio As Date, fechaFin As Date, nombreProfesor As String, nombreCurso As String)
        Me.IdProyecto = idProyecto
        Me.Titulo = titulo
        Me.Descripcion = descripcion
        Me.FechaInicio = fechaInicio
        Me.FechaFin = fechaFin
        Me.NombreProfesor = nombreProfesor
        Me.NombreCurso = nombreCurso
    End Sub
End Class
