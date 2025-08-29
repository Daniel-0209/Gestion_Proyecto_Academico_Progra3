Imports System.Data.SqlClient

Public Class Repository
    Private ReadOnly connectionString As String = ConfigurationManager.ConnectionStrings("Login").ConnectionString
    Public Function CargarAsignaciones() As DataTable
        Try
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

    Public Function CargarProyectos() As DataTable
        Dim dt As New DataTable()
        Try
            Dim query As String = "SELECT * FROM Proyectos ORDER BY IdProyecto"
            Using connection As New SqlConnection(connectionString)
                Using command As New SqlCommand(query, connection)
                    Using adapter As New SqlDataAdapter(command)
                        adapter.Fill(dt)
                    End Using
                End Using
            End Using
        Catch ex As Exception
        End Try
        Return dt
    End Function

    Public Function CreateProyecto(proy As Proyecto) As String
        Try
            Dim query As String = "
            INSERT INTO Proyectos (Titulo, Descripcion, FechaInicio, FechaFin, NombreProfesor, NombreCurso)
            VALUES (@Titulo, @Descripcion, @FechaInicio, @FechaFin, @NombreProfesor, @NombreCurso);
            SELECT SCOPE_IDENTITY();
        "
            Using connection As New SqlConnection(connectionString)
                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@Titulo", proy.Titulo)
                    command.Parameters.AddWithValue("@Descripcion", proy.Descripcion)
                    command.Parameters.AddWithValue("@FechaInicio", proy.FechaInicio)
                    command.Parameters.AddWithValue("@FechaFin", proy.FechaFin)
                    command.Parameters.AddWithValue("@NombreProfesor", proy.NombreProfesor)
                    command.Parameters.AddWithValue("@NombreCurso", proy.NombreCurso)
                    connection.Open()
                    Dim newId As Integer = Convert.ToInt32(command.ExecuteScalar())
                    Return "Proyecto creado con éxito. ID: " & newId
                End Using
            End Using
        Catch ex As Exception
            Return "Error al crear proyecto: " & ex.Message
        End Try
    End Function

    Public Function UpdateProyecto(idProyecto As Integer, proy As Proyecto) As String
        Try
            Dim query As String = "
            UPDATE Proyectos
            SET Titulo = @Titulo,
                Descripcion = @Descripcion,
                FechaInicio = @FechaInicio,
                FechaFin = @FechaFin,
                NombreProfesor = @NombreProfesor,
                NombreCurso = @NombreCurso
            WHERE IdProyecto = @IdProyecto
        "
            Using connection As New SqlConnection(connectionString)
                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@Titulo", proy.Titulo)
                    command.Parameters.AddWithValue("@Descripcion", proy.Descripcion)
                    command.Parameters.AddWithValue("@FechaInicio", proy.FechaInicio)
                    command.Parameters.AddWithValue("@FechaFin", proy.FechaFin)
                    command.Parameters.AddWithValue("@NombreProfesor", proy.NombreProfesor)
                    command.Parameters.AddWithValue("@NombreCurso", proy.NombreCurso)
                    command.Parameters.AddWithValue("@IdProyecto", proy.IdProyecto)
                    connection.Open()
                    command.ExecuteNonQuery()
                    Return "Proyecto actualizado correctamente."
                End Using
            End Using
        Catch ex As Exception
            Return "Error al actualizar proyecto: " & ex.Message
        End Try
    End Function

    Public Function EliminarProyecto(idProyecto As Integer) As String
        Try
            Dim query As String = "DELETE FROM Proyectos WHERE IdProyecto = @IdProyecto"
            Using connection As New SqlConnection(connectionString)
                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@IdProyecto", idProyecto)
                    connection.Open()
                    command.ExecuteNonQuery()
                    Return "Proyecto eliminado correctamente."
                End Using
            End Using
        Catch ex As Exception
            Return "Error al eliminar proyecto: " & ex.Message
        End Try
    End Function

    Public Function CreateEntrega(ent As Entrega) As String
        Try
            Dim query As String = "
                INSERT INTO Entregas (Proyecto, NombreCurso, NombreEstudiante, FechaEntrega, Archivo)
                VALUES (@Proyecto, @NombreCurso, @NombreEstudiante, @FechaEntrega, @Archivo);
                SELECT SCOPE_IDENTITY();
            "

            Using connection As New SqlConnection(connectionString)
                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@Proyecto", ent.Proyecto)
                    command.Parameters.AddWithValue("@NombreCurso", ent.NombreCurso)
                    command.Parameters.AddWithValue("@NombreEstudiante", ent.NombreEstudiante)
                    command.Parameters.AddWithValue("@FechaEntrega", ent.FechaEntrega)
                    command.Parameters.AddWithValue("@Archivo", ent.Archivo)

                    connection.Open()
                    Dim newId As Integer = Convert.ToInt32(command.ExecuteScalar())
                    Return "Entrega subida con éxito. ID: " & newId
                End Using
            End Using
        Catch ex As Exception
            Return "Error al subir entrega: " & ex.Message
        End Try
    End Function

    Public Function CreateComentario(com As Comentario) As String
        Try
            Using connection As New SqlConnection(connectionString)
                Dim query As String = "INSERT INTO Comentarios (Mensaje, Destinatario, FechaEnvio) VALUES (@Mensaje, @Destinatario, @FechaEnvio)"
                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@Mensaje", com.Mensaje)
                    command.Parameters.AddWithValue("@Destinatario", com.Destinatario)
                    command.Parameters.AddWithValue("@FechaEnvio", com.FechaEnvio)
                    connection.Open()
                    command.ExecuteNonQuery()
                End Using
            End Using
            Return "Comentario enviado correctamente."
        Catch ex As Exception
            Return "Error al enviar comentario: " & ex.Message
        End Try
    End Function

    Public Function EliminarComentario(id As Integer) As String
        Try
            Dim query As String = "DELETE FROM Comentarios WHERE IdComentario = @IdComentario"

            Using connection As New SqlConnection(connectionString)
                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@IdComentario", id)

                    connection.Open()
                    Dim rowsAffected As Integer = command.ExecuteNonQuery()
                    If rowsAffected > 0 Then
                        Return "Comentario eliminado con éxito."
                    Else
                        Return "No se encontró el comentario con el ID especificado."
                    End If
                End Using
            End Using
        Catch ex As Exception
            Return "Error al eliminar comentario: " & ex.Message
        End Try
    End Function
    Public Function ActualizarComentario(id As Integer, com As Comentario) As String
        Try
            Dim query As String = "UPDATE Comentarios SET Mensaje=@Mensaje, Destinatario=@Destinatario, FechaEnvio=@FechaEnvio WHERE IdComentario=@IdComentario"

            Using connection As New SqlConnection(connectionString)
                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@IdComentario", id)
                    command.Parameters.AddWithValue("@Mensaje", com.Mensaje)
                    command.Parameters.AddWithValue("@Destinatario", com.Destinatario)
                    command.Parameters.AddWithValue("@FechaEnvio", com.FechaEnvio)

                    connection.Open()
                    Dim rowsAffected As Integer = command.ExecuteNonQuery()
                    If rowsAffected > 0 Then
                        Return "Comentario actualizado con éxito."
                    Else
                        Return "No se encontró el comentario con el ID especificado."
                    End If
                End Using
            End Using
        Catch ex As Exception
            Return "Error al actualizar comentario: " & ex.Message
        End Try
    End Function
    Public Function CargarComentarios() As DataTable
        Try
            Dim dt As New DataTable()
            Dim query As String = "SELECT IdComentario, Mensaje, Destinatario, FechaEnvio FROM Comentarios ORDER BY FechaEnvio DESC"

            Using connection As New SqlConnection(connectionString)
                Using command As New SqlCommand(query, connection)
                    Using adapter As New SqlDataAdapter(command)
                        adapter.Fill(dt)
                    End Using
                End Using
            End Using

            Return dt
        Catch ex As Exception
            Throw New Exception("Error al cargar comentarios: " & ex.Message)
        End Try
    End Function

End Class














