<%@ Page Title="Coordinador" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Coordinador.aspx.vb" Inherits="Gestion_Proyecto_Academico_Progra3.Coordinador" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="coordinador-container d-flex">
        <nav class="menu-vertical p-3 me-4 rounded shadow-sm">
            <h3 class="text-white mb-3">Panel Coordinador</h3>
            <a href="Asignacion_Proyectos.aspx">Asignar Proyectos</a>
            <a href="Cometarios_Profesor.aspx">Anuncios</a>
        </nav>

        <div class="contenido-principal p-4 flex-grow-1 bg-light rounded shadow-sm">
            <h2>Bienvenido al panel del coordinador</h2>
            <p>Aquí puede gestionar usuarios, asignar cursos y consultar reportes importantes.</p>
        </div>
    </div>

    <style>
        .coordinador-container {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
        }
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
        .contenido-principal h2 {
            color: #003366;
            margin-bottom: 20px;
        }
    </style>
</asp:Content>