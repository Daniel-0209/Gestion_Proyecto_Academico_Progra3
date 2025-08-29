<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Login.aspx.vb" Inherits="Gestion_Proyecto_Academico_Progra3.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
    body {
        background-color: #f0f4f8;
        font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
    }

    .center-page {
        display: flex;
        justify-content: center;
        align-items: center;
        height: 90vh;
    }

    .card {
        border-radius: 12px;
        border: none;
        padding: 30px 20px;
        background-color: #ffffff;
        box-shadow: 0 8px 20px rgba(0, 0, 0, 0.15);
        text-align: center;
    }

    .form-signin h1 {
        color: #003366;
        margin-bottom: 25px;
        font-weight: bold;
    }

    .form-floating label {
        color: #003366;
    }

    .form-control:focus {
        border-color: #003366;
        box-shadow: 0 0 0 0.2rem rgba(0, 51, 102, 0.25);
    }

    .btn-primary {
        background-color: #003366;
        border-color: #003366;
        font-weight: bold;
        transition: background-color 0.3s, border-color 0.3s;
    }

    .btn-primary:hover {
        background-color: #002244;
        border-color: #002244;
    }

    .form-check-label {
        color: #003366;
    }

    a {
        display: inline-block;
        margin-top: 15px;
        color: #003366;
        text-decoration: none;
        font-weight: 500;
    }

    a:hover {
        color: #ffcc00;
        text-decoration: underline;
    }

    .alert-danger {
        margin-top: 15px;
        font-size: 0.9rem;
    }
</style>

     <div class="center-page">
     <div class="card shadow-lg p-4" style="max-width: 400px; width: 100%;">
         <div class="d-flex align-items-center py-4 bg-body-tertiary">
             <main class="form-signin w-100 m-auto">
                 <h1 class="h3 mb-3 fw-normal">Iniciar Sesion</h1>

                 <div class="form-floating">
                     <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="SingleLine" placeholder="Email"></asp:TextBox>
                     <label for="MainContent_txtEmail">Email </label>
                 </div>

                 <div class="form-floating">
                     <asp:TextBox ID="txtPass" runat="server" CssClass="form-control" TextMode="Password" placeholder="Password"></asp:TextBox>
                     <label for="MainContent_txtPass">Contraseña</label>
                 </div>

                 <div class="form-check text-start my-3">
                     <input class="form-check-input" type="checkbox" value="remember-me" id="flexCheckDefault">
                     <label class="form-check-label" for="flexCheckDefault">
                         Recordar
                     </label>
                 </div>
                 <asp:Button CssClass="btn btn-primary w-100 py-2" ID="btnLogin" runat="server" Text="Acceder" OnClick="btnLogin_Click" />
             </main>
         </div>
         <asp:Label ID="lblError" runat="server" Text="" CssClass="alert alert-danger" Visible="false"></asp:Label>

     </div>
 </div>
</asp:Content>
