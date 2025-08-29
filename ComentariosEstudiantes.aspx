<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ComentariosEstudiantes.aspx.vb" Inherits="Gestion_Proyecto_Academico_Progra3.ComentariosEstudiantes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server"> 
    <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" AutoGenerateColumns="False"  CssClass="table table-hover"
        HeaderStyle-CssClass="table-header" 
        RowStyle-CssClass="table-row" 
        AlternatingRowStyle-CssClass="table-alt-row">
        <Columns>
            <asp:BoundField DataField="Mensaje" HeaderText="Mensaje" SortExpression="Mensaje" />
            <asp:BoundField DataField="FechaEnvio" HeaderText="FechaEnvio" SortExpression="FechaEnvio" />
        </Columns>
</asp:GridView>

<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Gestion_Proyectos_AcademicosConnectionString5 %>" SelectCommand="SELECT Mensaje, FechaEnvio FROM Comentarios WHERE Destinatario IN ('Estudiante','Ambos')"></asp:SqlDataSource>
</asp:Content>
