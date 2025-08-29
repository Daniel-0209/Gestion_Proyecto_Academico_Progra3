<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="InfoCursos.aspx.vb" Inherits="Gestion_Proyecto_Academico_Progra3.InfoCursos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>📚 Mis Cursos Matriculados</h2>
       <style>
        .curso-card {
            display: inline-block;
            width: 250px;
            margin: 15px;
            padding: 20px;
            border-radius: 12px;
            background: linear-gradient(135deg, #4facfe, #00f2fe);
            color: white;
            font-size: 18px;
            font-weight: bold;
            text-align: center;
            box-shadow: 0 6px 12px rgba(0,0,0,0.2);
            transition: transform 0.2s ease, box-shadow 0.2s ease;
        }
        .curso-card:hover {
            transform: scale(1.08);
            box-shadow: 0 10px 20px rgba(0,0,0,0.3);
            cursor: pointer;
        }
    </style>

    <h2 style="color:#333; text-align:center;">📚 Mis Cursos Matriculados</h2>
    <br />

    <div style="display:flex; justify-content:center; flex-wrap:wrap;">
        <asp:Label ID="lblCurso1" runat="server" CssClass="curso-card" Text="Programación 3"></asp:Label>
        <asp:Label ID="lblCurso2" runat="server" CssClass="curso-card" Text="Bases de Datos 1"></asp:Label>
        <asp:Label ID="lblCurso3" runat="server" CssClass="curso-card" Text="Programación a Internet"></asp:Label>
        <asp:Label ID="lblCurso4" runat="server" CssClass="curso-card" Text="Telemática 1"></asp:Label>
    </div>
</asp:Content>
