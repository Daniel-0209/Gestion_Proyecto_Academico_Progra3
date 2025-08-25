<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Registro.aspx.vb" Inherits="Gestion_Proyecto_Academico_Progra3.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
       <div class="card shadow-lg p-4" style="max-width: 400px; width: 100%;">
        <div class="card-body">
            <h2 class="h4 mb-3 text-center">Create an Account</h2>

            <div class="form-floating">
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" TextMode="SingleLine" placeholder="Name"></asp:TextBox>
                <label for="MainContent_txtNombre">Nombre</label>
            </div>

           <div class="form-floating">
               <asp:TextBox ID="txtApellido1" runat="server" CssClass="form-control" TextMode="SingleLine" placeholder="Name"></asp:TextBox>
               <label for="MainContent_txtApellido1">Primer Apellido</label>
           </div>

           <div class="form-floating">
               <asp:TextBox ID="txtApellido2" runat="server" CssClass="form-control" TextMode="SingleLine" placeholder="Name"></asp:TextBox>
               <label for="MainContent_txtApellido2">Segundo Apellido</label>
           </div>

            <div class="form-floating">
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" placeholder="Email"></asp:TextBox>
                <label for="MainContent_txtEmail">Email address</label>
            </div>

            <div class="form-floating">
                <asp:TextBox ID="txtPass" runat="server" CssClass="form-control" TextMode="Password" placeholder="Password"></asp:TextBox>
                <label for="MainContent_txtPass">Password</label>
            </div>

           <div class="form-floating">
               <asp:DropDownList ID="ddlRol" runat="server" CssClass="form-control">
                   <asp:ListItem Value="1">Estudiante</asp:ListItem>
                   <asp:ListItem Value="2">Profesor</asp:ListItem>
                   <asp:ListItem Value="3">Coordinador</asp:ListItem>
               </asp:DropDownList>
               <label for="ddlRol">Rol Asignado</label>
           </div>

           <asp:Button CssClass="btn btn-primary w-100 py-2" ID="btnRegistrar" runat="server" Text="Registrarse" OnClick="btnRegistrar_Click" />
        </div>

        <a href="Login.aspx">¿Ya estas registrado?</a>
    </div>
    <asp:Label ID="lblError" runat="server" Text="" CssClass="error"></asp:Label>
</asp:Content>
