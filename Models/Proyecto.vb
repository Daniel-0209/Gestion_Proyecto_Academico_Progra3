Public Class Proyecto
    Public Property IdProyecto As Integer
    Public Property Titulo As String
    Public Property Descripcion As String
    Public Property FechaInicio As Date
    Public Property FechaFin As Date
    Public Property Estado As String
    Public Property Creador As String
    'constructor con parametros
    Public Sub New(idProyecto As Integer, titulo As String, descripcion As String, fechaInicio As Date, fechaFin As Date, estado As String, creador As String)
        Me.IdProyecto = idProyecto
        Me.Titulo = titulo
        Me.Descripcion = descripcion
        Me.FechaInicio = fechaInicio
        Me.FechaFin = fechaFin
        Me.Estado = estado
        Me.Creador = creador
    End Sub
    'constructor sin parametros
    Public Sub New()
    End Sub
End Class
