Public Class Asignacion
    Private _idAsignacion As Integer
    Private _nombreCurso As String
    Private _nombreProfesor As String
    Private _turno As String

    Public Property IdAsignacion As Integer
        Get
            Return _idAsignacion
        End Get
        Set(value As Integer)
            _idAsignacion = value
        End Set
    End Property

    Public Property NombreCurso As String
        Get
            Return _nombreCurso
        End Get
        Set(value As String)
            _nombreCurso = value
        End Set
    End Property

    Public Property NombreProfesor As String
        Get
            Return _nombreProfesor
        End Get
        Set(value As String)
            _nombreProfesor = value
        End Set
    End Property

    Public Property Turno As String
        Get
            Return _turno
        End Get
        Set(value As String)
            _turno = value
        End Set
    End Property
    ' constructor con parametos
    Public Sub New(id As Integer, nombreCurso As String, Nombre As String, turno As String)
        Me.IdAsignacion = id
        Me.NombreCurso = nombreCurso
        Me.NombreProfesor = Nombre
        Me.Turno = turno
    End Sub
    ' constructor sin parametros
    Public Sub New()
    End Sub

End Class
