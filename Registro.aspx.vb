Imports System.Data.SqlClient
Imports Gestion_Proyecto_Academico_Progra3.Helpers
Imports Microsoft.Ajax.Utilities

Public Class Registro
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Protected Function RegistrarUsuario(usuario As Usuario) As Boolean
        Dim helper As New DatabaseHelper()
        Dim sql As String = "INSERT INTO Usuarios (Nombre, Apellido1, Apellido2, Email, Contrasena, IdRol) VALUES (@Nombre, @Apellido1, @Apellido2, @Email, @Password, @IdRol)"

        Dim parameters As New List(Of SqlParameter) From {
            New SqlParameter("@Nombre", usuario.Nombre),
            New SqlParameter("@Apellido1", usuario.Apellido1),
            New SqlParameter("@Apellido2", usuario.Apellido2),
            New SqlParameter("@Email", usuario.Email),
            New SqlParameter("@Password", usuario.Pass),
            New SqlParameter("@IdRol", usuario.RolId)
        }
        Return helper.ExecuteNonQuery(sql, parameters)
    End Function
    Protected Sub btnRegistrar_Click(sender As Object, e As EventArgs)
        ' Obtener los valores de los campos
        Dim nombre As String = txtNombre.Text
        Dim apellido1 As String = txtApellido1.Text
        Dim apellido2 As String = txtApellido2.Text
        Dim email As String = txtEmail.Text
        Dim pass As String = txtPass.Text
        Dim rol As String = ddlRol.SelectedValue
        ' Validar que los campos no estén vacíos
        If nombre.IsNullOrWhiteSpace Or apellido1.IsNullOrWhiteSpace Or apellido2.IsNullOrWhiteSpace Or email.IsNullOrWhiteSpace Or pass.IsNullOrWhiteSpace Then
            lblError.Text = "Todos los campos son requeridos"
            Exit Sub
        End If
        ' Encriptar la contraseña
        Dim wrapper As New Simple3Des("claveclavecita")
        Dim password As String = wrapper.EncryptData(pass)
        ' Crear el objeto Usuario y registrar
        Dim Usuario As New Usuario() With {
            .Nombre = txtNombre.Text,
            .Apellido1 = txtApellido1.Text,
            .Apellido2 = txtApellido2.Text,
            .Email = txtEmail.Text,
            .Pass = password,
            .RolId = rol
        }

        If RegistrarUsuario(Usuario) Then
            ' Redirigir al login o a la página de inicio

            ScriptManager.RegisterStartupScript(
                Me, Me.GetType(),
                "Confirmar Registro",
                "Swal.fire('Usuario Registrado').then((result) => {
                    if (result.isConfirmed) {
                        window.location.href = 'Login.aspx';
                    }
                });",
                True)

        Else
            ScriptManager.RegisterStartupScript(
                Me, Me.GetType(),
                "Error Registro",
                "Swal.fire('Error al registrar el usuario. Inténtalo de nuevo.');",
                True)
            lblError.Text = "Error al registrar el usuario. Inténtalo de nuevo."
            lblError.Visible = True
        End If
    End Sub
End Class