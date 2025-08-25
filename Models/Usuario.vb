Public Class Usuario
    Public Property IdUsuario As Integer
    Public Property Nombre As String
    Public Property Apellido1 As String
    Public Property Apellido2 As String
    Public Property Email As String
    Public Property Pass As String
    Public Property RolId As Integer
    'constructor con parametos
    Public Sub New(id As Integer, nombre As String, apellido1 As String, apellido2 As String, email As String, pass As String, roleId As Integer)
        Me.IdUsuario = id
        Me.Nombre = nombre
        Me.Apellido1 = apellido1
        Me.Apellido2 = apellido2
        Me.Email = email
        Me.Pass = pass
        Me.RolId = roleId
    End Sub
    'constructor sin parametros
    Public Sub New()
    End Sub

    ' Método para validar el usuario (ejemplo simple)
    Public Function Validar() As Boolean
        Return Not String.IsNullOrEmpty(Email) AndAlso Not String.IsNullOrEmpty(Pass)
    End Function

    ' Método para convertir un DataTable en un objeto Usuario
    Public Function dtToUsuario(dataTable As DataTable) As Usuario
        If dataTable IsNot Nothing AndAlso dataTable.Rows.Count > 0 Then
            Dim row As DataRow = dataTable.Rows(0)
            Dim roleId As Integer = If(IsDBNull(row("IdRol")), 1, Convert.ToInt32(row("IdRol")))
            Return New Usuario() With {
                .IdUsuario = Convert.ToInt32(row("IdUsuario")),
                .Nombre = Convert.ToString(row("Nombre")),
                .Apellido1 = Convert.ToString(row("Apellido1")),
                .Apellido2 = Convert.ToString(row("Apellido2")),
                .Email = Convert.ToString(row("Email")),
                .RolId = roleId
            }
        End If
        Return Nothing
    End Function

End Class
