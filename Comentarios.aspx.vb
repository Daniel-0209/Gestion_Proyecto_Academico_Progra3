Public Class Comentarios
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarComentarios()
        End If
    End Sub

    Private Sub CargarComentarios()
        Dim repo As New Repository()
        grvComentarios.DataBind()
    End Sub
    Public Sub limpiar()
        txtComentario.Text = " "
        lblComentario.Text = ""
    End Sub

    Protected Sub btnEnviarComentario_Click(sender As Object, e As EventArgs)
        Dim repo As New Repository()
        Dim comentario As New Comentario With {
        .Mensaje = txtComentario.Text.Trim(),
        .Destinatario = ddlDestinatario.SelectedValue,
        .FechaEnvio = DateTime.Now
    }

        Dim resultado As String

        If String.IsNullOrWhiteSpace(IDComentario.Value) Then
            ' Crear nuevo comentario
            resultado = repo.CreateComentario(comentario)
            ScriptManager.RegisterStartupScript(
                Me, Me.GetType(),
                "Mensajtos",
                "Swal.fire('Proyecto Registrado Correctamente.');",
                True)
        Else
            ' Actualizar comentario existente
            comentario.IdComentario = Convert.ToInt32(IDComentario.Value)
            resultado = repo.ActualizarComentario(comentario.IdComentario, comentario)
            LblMensaje.Text = resultado
            ScriptManager.RegisterStartupScript(
                Me, Me.GetType(),
                "Mensajtos",
                "Swal.fire('Comentario Modificado Correctamente.');",
                True)
        End If
        limpiar()
        ddlDestinatario.SelectedIndex = 0
        CargarComentarios() ' Refresca GridView
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim id As Integer = Convert.ToInt32(grvComentarios.DataKeys(grvComentarios.SelectedIndex).Value)

        ' Carga los datos del comentario desde el Repository
        Dim repo As New Repository()
        Dim dt As DataTable = repo.CargarComentarios() ' Retorna todos los comentarios
        Dim row = dt.Select("IdComentario=" & id).FirstOrDefault()

        If row IsNot Nothing Then
            IDComentario.Value = row("IdComentario").ToString()

            ' Llena los campos del formulario
            txtComentario.Text = row("Mensaje").ToString()
            ddlDestinatario.SelectedValue = row("Destinatario").ToString()

        End If
    End Sub

    Protected Sub GridView1_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles grvComentarios.RowDeleting
        Dim idComentario As Integer = Convert.ToInt32(grvComentarios.DataKeys(e.RowIndex).Value)

        ' Llama al método del repository para eliminar
        Dim repo As New Repository()
        Dim resultado As String = repo.EliminarComentario(idComentario)
        LblMensaje.Text = resultado
        e.Cancel = True
        ScriptManager.RegisterStartupScript(
                Me, Me.GetType(),
                "Mensajtos",
                "Swal.fire('Comentario Eliminado Correctamente.');",
                True)
        limpiar()
        grvComentarios.DataBind()


    End Sub
End Class






