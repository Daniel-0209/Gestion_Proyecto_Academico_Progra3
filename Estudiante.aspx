<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Estudiante.aspx.vb" Inherits="Gestion_Proyecto_Academico_Progra3.Estudiante" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <!-- Menú de navegación -->
 <asp:Menu ID="MenuCoordinador" runat="server" Orientation="Horizontal">
     <Items>
         <asp:MenuItem Text="Inicio" NavigateUrl="~/Profesor.aspx" />
         <asp:MenuItem Text="Asignación De Proyectos" NavigateUrl="~/Asignacion_Proyectos.aspx" />
         <asp:MenuItem Text="Reportes" NavigateUrl="~/Reportes.aspx" />
     </Items>
 </asp:Menu>
</asp:Content>
