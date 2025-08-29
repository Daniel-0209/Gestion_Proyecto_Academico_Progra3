Imports Gestion_Proyecto_Academico_Progra3.Helpers

Public Class Asignacion_Proyectos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarProfesores()
            CargarCursos()
        End If
    End Sub

    Private Sub CargarProfesores()
        Dim helper As New DatabaseHelper()
        ddlProfesores.DataSource = helper.ExecuteQuery("SELECT IdUsuario, Nombre + ' ' + Apellido1 + ' ' + Apellido2 AS NombreCompleto FROM Usuarios WHERE IdRol=2")
        ddlProfesores.DataTextField = "NombreCompleto"
        ddlProfesores.DataValueField = "IdUsuario"
        ddlProfesores.DataBind()
        ddlProfesores.Items.Insert(0, New ListItem("-- Seleccione Profesor --", ""))
    End Sub

    Private Sub CargarCursos()
        Dim helper As New DatabaseHelper()
        ddlCursos.DataSource = helper.ExecuteQuery("SELECT IdCurso, NombreCurso FROM Cursos")
        ddlCursos.DataTextField = "NombreCurso"
        ddlCursos.DataValueField = "IdCurso"
        ddlCursos.DataBind()
        ddlCursos.Items.Insert(0, New ListItem("-- Seleccione Curso --", ""))
    End Sub

    Protected Sub btnGuardarProyecto_Click(sender As Object, e As EventArgs)
        Dim dbHelper As New Repository()

        ' Verifica si es un proyecto nuevo o existente
        If String.IsNullOrWhiteSpace(IDProyecto.Value) Then
            ' Nuevo proyecto
            Dim proyecto As New Proyecto() With {
            .Titulo = TxtTitulo.Text.Trim(),
            .Descripcion = TxtDescripcion.Text.Trim(),
            .FechaInicio = If(String.IsNullOrWhiteSpace(TxtFechaInicio.Text), DateTime.MinValue, Convert.ToDateTime(TxtFechaInicio.Text)),
            .FechaFin = If(String.IsNullOrWhiteSpace(TxtFechaFin.Text), DateTime.MinValue, Convert.ToDateTime(TxtFechaFin.Text)),
            .NombreProfesor = ddlProfesores.SelectedItem.Text,
            .NombreCurso = ddlCursos.SelectedItem.Text
        }

            Dim resultado As String = dbHelper.CreateProyecto(proyecto)
            ScriptManager.RegisterStartupScript(
                Me, Me.GetType(),
                "Mensajtos",
                "Swal.fire('Proyecto Registrado Correctamente.');",
                True)
            LblMensaje.Text = resultado
            LimpiarFormulario()
            grvProyectos.DataBind()
        Else
            ' Actualizar proyecto existente
            Dim proyecto As New Proyecto() With {
            .IdProyecto = Convert.ToInt32(IDProyecto.Value),
            .Titulo = TxtTitulo.Text.Trim(),
            .Descripcion = TxtDescripcion.Text.Trim(),
            .FechaInicio = If(String.IsNullOrWhiteSpace(TxtFechaInicio.Text), DateTime.MinValue, Convert.ToDateTime(TxtFechaInicio.Text)),
            .FechaFin = If(String.IsNullOrWhiteSpace(TxtFechaFin.Text), DateTime.MinValue, Convert.ToDateTime(TxtFechaFin.Text)),
            .NombreProfesor = ddlProfesores.SelectedItem.Text,
            .NombreCurso = ddlCursos.SelectedItem.Text
        }

            Dim resultado As String = dbHelper.UpdateProyecto(proyecto.IdProyecto, proyecto)
            ScriptManager.RegisterStartupScript(
                Me, Me.GetType(),
                "Prueba",
                "Swal.fire('Proyecto Modificado Correctamente.');",
                True)
            LblMensaje.Text = resultado
            LimpiarFormulario()
            IDProyecto.Value = ""
            grvProyectos.DataBind()
        End If
    End Sub

    Protected Sub LimpiarFormulario()
        TxtTitulo.Text = ""
        TxtDescripcion.Text = ""
        TxtFechaInicio.Text = ""
        TxtFechaFin.Text = ""
        ddlProfesores.SelectedIndex = 0
        ddlCursos.SelectedIndex = 0

    End Sub

    Protected Sub grvProyectos_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim id As Integer = Convert.ToInt32(grvProyectos.SelectedDataKey.Value)

        ' Carga los datos del proyecto
        Dim dt As DataTable = New Repository().CargarProyectos()
        Dim row = dt.Select("IdProyecto=" & id).FirstOrDefault()

        If row IsNot Nothing Then
            IDProyecto.Value = row("IdProyecto").ToString()
            TxtTitulo.Text = row("Titulo").ToString()
            TxtDescripcion.Text = row("Descripcion").ToString()
            TxtFechaInicio.Text = CDate(row("FechaInicio")).ToString("yyyy-MM-dd")
            TxtFechaFin.Text = CDate(row("FechaFin")).ToString("yyyy-MM-dd")

            ' Selecciona el profesor por nombre
            Dim profesorNombre As String = row("NombreProfesor").ToString()
            If ddlProfesores.Items.FindByText(profesorNombre) IsNot Nothing Then
                ddlProfesores.SelectedValue = ddlProfesores.Items.FindByText(profesorNombre).Value
            Else
                ddlProfesores.SelectedIndex = 0
            End If

            ' Selecciona el curso por nombre
            Dim cursoNombre As String = row("NombreCurso").ToString()
            If ddlCursos.Items.FindByText(cursoNombre) IsNot Nothing Then
                ddlCursos.SelectedValue = ddlCursos.Items.FindByText(cursoNombre).Value
            Else
                ddlCursos.SelectedIndex = 0
            End If
        End If
    End Sub
    Protected Sub grvProyectos_RowDeleting1(sender As Object, e As GridViewDeleteEventArgs)
        Dim id As Integer = Convert.ToInt32(grvProyectos.DataKeys(e.RowIndex).Value)
        Dim resultado As String = New Repository().EliminarProyecto(id)
        LblMensaje.Text = resultado
        e.Cancel = True
        ScriptManager.RegisterStartupScript(
                Me, Me.GetType(),
                "Prueba",
                "Swal.fire('Proyecto Eliminado Correctamente.');",
                True)
        LimpiarFormulario()
        grvProyectos.DataBind()
    End Sub
End Class