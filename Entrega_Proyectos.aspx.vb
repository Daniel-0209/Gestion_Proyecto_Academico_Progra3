Imports System.Data.SqlClient
Imports Gestion_Proyecto_Academico_Progra3.Helpers

Public Class Entrega_Proyectos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarCursos()
        End If
    End Sub
    Private Sub CargarCursos()
        Dim helper As New DatabaseHelper()
        ' Trae IdCurso y NombreCurso de la tabla Cursos
        ddlCurso.DataSource = helper.ExecuteQuery("SELECT NombreCurso FROM Proyectos")
        ddlCurso.DataTextField = "NombreCurso"
        ddlCurso.DataValueField = "NombreCurso"
        ddlCurso.DataBind()
        ddlCurso.Items.Insert(0, New ListItem("-- Seleccione un curso --", "0"))
    End Sub
    Private Sub CargarProyectosPorCurso(nombreCurso)
        Dim helper As New DatabaseHelper()
        ddlProyecto.DataSource = helper.ExecuteQuery("SELECT IdProyecto, Titulo FROM Proyectos WHERE NombreCurso = '" & nombreCurso.Replace("'", "''") & "'")
        ddlProyecto.DataTextField = "Titulo"
        ddlProyecto.DataValueField = "Titulo"
        ddlProyecto.DataBind()
        ddlProyecto.Items.Insert(0, New ListItem("-- Seleccione un proyecto --", "0"))
    End Sub

    Public Sub limpiar()
        txtFecha.Text = ""
        txtNombreEstudiante.Text = ""
    End Sub

    Protected Sub btnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click
        If fuArchivo.HasFile _
       AndAlso ddlCurso.SelectedValue <> "0" _
       AndAlso ddlProyecto.SelectedValue <> "0" _
       AndAlso Not String.IsNullOrWhiteSpace(txtNombreEstudiante.Text) Then

            Dim ruta As String = Server.MapPath("~/uploads/entregas/")
            If Not IO.Directory.Exists(ruta) Then IO.Directory.CreateDirectory(ruta)
            Dim nombreArchivo As String = IO.Path.GetFileName(fuArchivo.FileName)
            fuArchivo.SaveAs(ruta & nombreArchivo)

            Dim entrega As New Entrega With {
            .Proyecto = ddlProyecto.SelectedItem.Text,
            .NombreCurso = ddlCurso.SelectedItem.Text,
            .NombreEstudiante = txtNombreEstudiante.Text,
            .FechaEntrega = DateTime.Now,
            .Archivo = "uploads/entregas/" & nombreArchivo
        }

            Dim repo As New Repository()
            Dim mensaje As String = repo.CreateEntrega(entrega)
            ScriptManager.RegisterStartupScript(
                Me, Me.GetType(),
                "Mensajtos",
                "Swal.fire('Proyecto Enviado Correctamente.');",
                True)
        Else
            ScriptManager.RegisterStartupScript(
                Me, Me.GetType(),
                "Mensajtos",
                "Swal.fire('Error al Enviar.');",
                True)

        End If
        limpiar()
    End Sub
    Protected Sub ddlCurso_SelectedIndexChanged(sender As Object, e As EventArgs)
        If ddlCurso.SelectedValue <> "0" Then
            CargarProyectosPorCurso(ddlCurso.SelectedValue)
        Else
            ddlProyecto.Items.Clear()
        End If
    End Sub
End Class