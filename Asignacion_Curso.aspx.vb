Imports Gestion_Proyecto_Academico_Progra3.Helpers
Imports Microsoft.Ajax.Utilities

Public Class Asignacion_Curso
    Inherits System.Web.UI.Page
    Dim dbHelper As New DatabaseHelper()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim helper As New DatabaseHelper()

            ' Cargar profesores
            Dim dtProfesores As DataTable = helper.ExecuteQuery("
    SELECT IdUsuario, Nombre + ' ' + Apellido1 + ' ' + Apellido2 AS NombreProfesor
    FROM Usuarios
    WHERE IdRol = 2
")
            ddlProfesores.DataSource = dtProfesores
            ddlProfesores.DataTextField = "NombreProfesor"
            ddlProfesores.DataValueField = "IdUsuario"
            ddlProfesores.DataBind()

            ' Cargar cursos
            Dim dtCursos As DataTable = helper.ExecuteQuery("SELECT NombreCurso FROM Cursos")
            ddlCursos.DataSource = dtCursos
            ddlCursos.DataTextField = "NombreCurso"
            ddlCursos.DataValueField = "NombreCurso"
            ddlCursos.DataBind()
        End If
    End Sub

    Protected Sub CargarAsignatura()
        ' Carga los proveedores desde la base de datos y los muestra en el GridView.
        Dim Repositorio As New Repository()
        grvAsignacion.DataSource = Repositorio.CargarAsignaciones()
        grvAsignacion.DataBind()

    End Sub


    Protected Sub grvAsignacion_SelectedIndexChanged(sender As Object, e As EventArgs)
        ' Se ejecuta cuando se selecciona una asignación en el GridView
        Dim index As Integer = grvAsignacion.SelectedIndex
        If index >= 0 Then
            Dim row = grvAsignacion.Rows(index)

            ' Guardamos el Id de la asignación en un HiddenField
            IDAsignacion.Value = grvAsignacion.DataKeys(index).Value.ToString()

            ' Asignamos los valores de la fila a los controles
            ddlProfesores.SelectedItem.Text = row.Cells(2).Text 'NombreProfesor
            ddlCursos.SelectedItem.Text = row.Cells(3).Text     'NombreCurso
            ddlTurnos.SelectedValue = row.Cells(4).Text        'Turno
        End If
    End Sub

    Protected Sub grvAsignacion_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        ' Se ejecuta cuando se intenta eliminar una asignación del GridView
        Dim id As Integer = Convert.ToInt32(grvAsignacion.DataKeys(e.RowIndex).Value)

        Dim dbHelper As New Repository()
        Dim resultado As String = dbHelper.EliminarAsignacion(id)

        ' Mostrar mensaje
        LblMensaje.Text = resultado

        ' Cancelar la eliminación automática para control manual
        e.Cancel = True

        ' Recargar el GridView
        grvAsignacion.DataBind()
    End Sub

    Protected Sub LimpiarFormulario()
        ddlProfesores.ClearSelection()
        ddlCursos.ClearSelection()
        ddlTurnos.ClearSelection()

        ' Limpiar HiddenField
        IDAsignacion.Value = ""
    End Sub

    Protected Sub btnAsignar_Click(sender As Object, e As EventArgs)
        ' Guarda o actualiza una asignación según si el ID está vacío o no
        Dim asignacion As New Asignacion() With {
        .NombreProfesor = ddlProfesores.SelectedItem.Text,
        .NombreCurso = ddlCursos.SelectedItem.Text,
        .Turno = ddlTurnos.SelectedValue
    }

        Dim dbHelper As New Repository()
        Dim resultado As String = ""

        If String.IsNullOrWhiteSpace(IDAsignacion.Value) Then
            ' Inserta una nueva asignación
            resultado = dbHelper.CreateAsignacion(asignacion)
        Else
            ' Actualiza la asignación existente
            Dim id As Integer = Convert.ToInt32(IDAsignacion.Value)
            resultado = dbHelper.UpdateAsignacion(id, asignacion)
        End If

        ' Muestra mensaje y limpia formulario
        LblMensaje.Text = resultado
        LimpiarFormulario()
        IDAsignacion.Value = ""
        grvAsignacion.DataBind()
    End Sub
End Class