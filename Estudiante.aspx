<%@ Page Title="Estudiante" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Estudiante.aspx.vb" Inherits="Gestion_Proyecto_Academico_Progra3.Estudiante" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="coordinador-container d-flex">
        <!-- Menú Vertical -->
        <nav class="menu-vertical p-3 me-4 rounded shadow-sm">
            <h3 class="text-white mb-3">Panel Estudiante</h3>
            <a href="InfoCursos.aspx">Mis Cursos</a>
            <a href="Entrega_Proyectos.aspx">Entrgas De Proyectos</a>
            <a href="ComentariosEstudiantes.aspx">Anuncios</a>
        </nav>

        <!-- Contenido principal -->
        <div class="contenido-principal p-4 flex-grow-1 bg-light rounded shadow-sm">
            <h2>Bienvenido al campus del estudiante</h2>
            <p>Aquí puede gestionar proyectos, visualizar mis cursos y consultar anuncios importantes.</p>
        </div>
    </div>

    <style>
        .coordinador-container {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
        }

        /* Menú vertical */
        .menu-vertical {
            width: 220px;
            background-color: #003366;
            display: flex;
            flex-direction: column;
        }

        .menu-vertical h3 {
            color: #ffcc00;
            font-weight: bold;
        }

        .menu-vertical a {
            color: #ffffff;
            font-size: 1.2rem;
            margin-bottom: 10px;
            padding: 12px;
            border-radius: 6px;
            text-decoration: none;
            transition: background-color 0.3s, color 0.3s;
        }

        .menu-vertical a:hover {
            background-color: #ffcc00;
            color: #003366;
        }

        /* Contenido principal */
        .contenido-principal h2 {
            color: #003366;
            margin-bottom: 20px;
        }
    </style>
</asp:Content>