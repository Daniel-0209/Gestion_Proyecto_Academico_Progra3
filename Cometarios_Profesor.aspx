<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Cometarios_Profesor.aspx.vb" Inherits="Gestion_Proyecto_Academico_Progra3.Cometarios_Profesor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:GridView ID="GridView1" runat="server" 
        DataSourceID="SqlDataSource1" 
        AutoGenerateColumns="False"
        CssClass="table table-hover"
        HeaderStyle-CssClass="table-header"
        RowStyle-CssClass="table-row"
        AlternatingRowStyle-CssClass="table-alt-row">

        <Columns>
            <asp:BoundField DataField="Mensaje" HeaderText="Mensaje" SortExpression="Mensaje" />
            <asp:BoundField DataField="FechaEnvio" HeaderText="FechaEnvio" SortExpression="FechaEnvio" />
        </Columns>

    </asp:GridView>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:Gestion_Proyectos_AcademicosConnectionString6 %>" 
        ProviderName="<%$ ConnectionStrings:Gestion_Proyectos_AcademicosConnectionString6.ProviderName %>" 
        SelectCommand="SELECT Mensaje, FechaEnvio FROM Comentarios WHERE Destinatario IN ('Profesor','Ambos')">
    </asp:SqlDataSource>

</asp:Content>