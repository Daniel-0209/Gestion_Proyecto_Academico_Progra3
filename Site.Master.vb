Public Class SiteMaster
    Inherits MasterPage
    Protected autenticado As Boolean

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ' Por defecto ocultamos todo
            liEstudiante.Visible = False
            liProfesor.Visible = False
            liCoordinador.Visible = False
            liCerrarSesion.Visible = False

            If Session("Usuario") Is Nothing Then
                ' Usuario NO logueado
                liLogin.Visible = True
            Else
                ' Usuario logueado
                liLogin.Visible = False
                liCerrarSesion.Visible = True

                ' Mostramos opciones según rol
                Dim roleId As Integer = Convert.ToInt32(Session("IdRol"))

                If roleId = 1 Then
                    liEstudiante.Visible = True
                ElseIf roleId = 2 Then
                    liProfesor.Visible = True
                ElseIf roleId = 3 Then
                    liCoordinador.Visible = True
                End If
            End If
        End If
    End Sub

    Protected Sub btnCerrarSesion_Click(sender As Object, e As EventArgs)
        Session.Abandon()
        Session.Clear()
        Response.Redirect("Login.aspx")
    End Sub
End Class