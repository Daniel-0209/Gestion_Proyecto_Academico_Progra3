<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Coordinador.aspx.vb" Inherits="Gestion_Proyecto_Academico_Progra3.Coordinador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Panel del Coordinador</h2>

    <!-- Menú de navegación -->
    <asp:Menu ID="MenuCoordinador" runat="server" Orientation="Horizontal">
        <Items>
            <asp:MenuItem Text="Inicio" NavigateUrl="~/Coordinador.aspx" />
            <asp:MenuItem Text="Registro De Usuarios" NavigateUrl="~/Registro.aspx" />
            <asp:MenuItem Text="Asignación De Cursos" NavigateUrl="~/Asignacion_Curso.aspx" />
            <asp:MenuItem Text="Reportes" NavigateUrl="~/Reportes.aspx" />
        </Items>
    </asp:Menu>

</asp:Content>
