Imports System.Data.SqlClient
Imports Gestion_Proyecto_Academico_Progra3.Helpers


Public Class Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Protected Function VerificarUsuario(usuario As Usuario) As Boolean
        Try
            Dim helper As New DatabaseHelper()
            Dim email As String = txtEmail.Text
            Dim wrapper As New Simple3Des("claveclavecita")
            Dim pass As String = wrapper.EncryptData(usuario.Pass)

            Dim parametros As New List(Of SqlParameter) From {
            New SqlParameter("@Email", usuario.Email),
            New SqlParameter("@Password", pass)
        }

            ' Ajustar SELECT para coincidir con los atributos de tu clase Usuario
            Dim query As String = "SELECT [IdUsuario], [Nombre], [Apellido1], [Apellido2], [Email], [IdRol]
                               FROM Usuarios 
                               WHERE Email = @Email AND Contrasena = @Password;"

            ' Ejecutar la consulta
            Dim dataTable As DataTable = helper.ExecuteQuery(query, parametros)

            ' Verificar si se encontró el usuario
            If dataTable.Rows.Count > 0 Then
                ' Convertir DataTable en objeto Usuario usando tu función
                usuario = usuario.dtToUsuario(dataTable)

                ' Guardar en sesión
                Session.Add("IdUsuario", usuario.IdUsuario.ToString())
                Session.Add("Nombre", usuario.Nombre)
                Session.Add("Apellido1", usuario.Apellido1)
                Session.Add("Apellido2", usuario.Apellido2)
                Session.Add("Email", usuario.Email)
                Session.Add("IdRol", usuario.RolId)
                Session.Add("User", usuario)
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            ' Podrías loguear el error aquí
            Return False
        End Try
    End Function


    Protected Sub btnLogin_Click(sender As Object, e As EventArgs)

        ' Obtener los valores de los campos de entrada
        Dim usuario As New Usuario() With {
            .Email = txtEmail.Text.Trim(),
            .Pass = txtPass.Text
        }

        ' Validar el usuario
        If VerificarUsuario(usuario) Then
            ' Obtener el RoleId de la sesión y convertir a Integer
            Dim roleId As Integer = Convert.ToInt32(Session("IdRol"))

            ' Redirigir según el rol
            If roleId = 1 Then
                Response.Redirect("Estudiante.aspx")       ' Estudiante
            ElseIf roleId = 2 Then
                Response.Redirect("Profesor.aspx")      ' Profesor
            ElseIf roleId = 3 Then
                Response.Redirect("Coordinador.aspx") ' Coordinador
            Else
                ' Rol desconocido
                lblError.Text = "Rol de usuario no reconocido."
                lblError.Visible = True
            End If
        Else
            ' Usuario o contraseña incorrectos
            lblError.Text = "Correo electrónico o contraseña inválidos."
            lblError.Visible = True
        End If
    End Sub
End Class




''''''para acordarme, tengo que hacer el registo para crear los usuarios y luego ya con eso hago el login