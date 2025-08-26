Imports System.Data.SqlClient

Public Class Repository
    Private ReadOnly connectionString As String = ConfigurationManager.ConnectionStrings("Login").ConnectionString
    Public Function CargarAsignaciones() As DataTable
        Try
            ' Consulta directa sin JOIN, porque ya guardas los nombres directamente
            Dim query As String = "
            SELECT TOP (1000) 
                   IdAsignacion,
                   NombreProfesor,
                   NombreCurso,
                   Turno
            FROM AsignacionCursos
            ORDER BY IdAsignacion DESC
        "

            Dim dt As New DataTable()
            Using connection As New SqlConnection(connectionString)
                Using command As New SqlCommand(query, connection)
                    connection.Open()
                    Using reader As SqlDataReader = command.ExecuteReader()
                        dt.Load(reader)
                    End Using
                End Using
            End Using

            Return dt
        Catch ex As Exception
            Throw New Exception("Error al cargar las asignaciones de cursos: " & ex.Message)
        End Try
    End Function

    Public Function CreateAsignacion(asignacion As Asignacion) As String
        ' Crea una nueva asignación en la base de datos y devuelve un mensaje de éxito o error
        Try
            Dim query As String = "
            INSERT INTO AsignacionCursos (NombreProfesor, NombreCurso, Turno) 
            VALUES (@NombreProfesor, @NombreCurso, @Turno);
            SELECT SCOPE_IDENTITY();
        "

            Using connection As New SqlConnection(connectionString)
                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@NombreProfesor", asignacion.NombreProfesor)
                    command.Parameters.AddWithValue("@NombreCurso", asignacion.NombreCurso)
                    command.Parameters.AddWithValue("@Turno", asignacion.Turno)

                    connection.Open()
                    Dim newId As Integer = Convert.ToInt32(command.ExecuteScalar())
                    Return "Asignación creada con éxito. ID: " & newId
                End Using
            End Using
        Catch ex As Exception
            Return "Error al crear la asignación: " & ex.Message
        End Try
    End Function

    Public Function EliminarAsignacion(id As Integer) As String
        ' Elimina una asignación de curso por su ID y devuelve un mensaje de éxito o error
        Try
            Dim query As String = "DELETE FROM AsignacionCursos WHERE IdAsignacion = @IdAsignacion"

            Using connection As New SqlConnection(connectionString)
                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@IdAsignacion", id)
                    connection.Open()
                    Dim rowsAffected As Integer = command.ExecuteNonQuery()
                    If rowsAffected > 0 Then
                        Return "Asignación eliminada con éxito."
                    Else
                        Return "No se encontró la asignación con el ID especificado."
                    End If
                End Using
            End Using
        Catch ex As Exception
            Return "Error al eliminar la asignación: " & ex.Message
        End Try
    End Function

    Public Function UpdateAsignacion(id As Integer, asignacion As Asignacion) As String
        ' Actualiza una asignación de curso existente en la base de datos por su ID
        Try
            Dim query As String = "
            UPDATE AsignacionCursos
            SET NombreProfesor = @NombreProfesor,
                NombreCurso = @NombreCurso,
                Turno = @Turno
            WHERE IdAsignacion = @IdAsignacion
        "

            Using connection As New SqlConnection(connectionString)
                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@IdAsignacion", id)
                    command.Parameters.AddWithValue("@NombreProfesor", asignacion.NombreProfesor)
                    command.Parameters.AddWithValue("@NombreCurso", asignacion.NombreCurso)
                    command.Parameters.AddWithValue("@Turno", asignacion.Turno)

                    connection.Open()
                    Dim rowsAffected As Integer = command.ExecuteNonQuery()
                    If rowsAffected > 0 Then
                        Return "Asignación actualizada con éxito."
                    Else
                        Return "No se encontró la asignación con el ID especificado."
                    End If
                End Using
            End Using
        Catch ex As Exception
            Return "Error al actualizar la asignación: " & ex.Message
        End Try
    End Function


End Class
