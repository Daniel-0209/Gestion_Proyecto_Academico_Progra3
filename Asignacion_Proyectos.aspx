<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Asignacion_Proyectos.aspx.vb" Inherits="Gestion_Proyecto_Academico_Progra3.Asignacion_Proyectos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="LblMensaje" runat="server" ForeColor="Green"></asp:Label>

<div class="form-group">
    <label>Título:</label>
    <asp:TextBox ID="TxtTitulo" runat="server" CssClass="form-control"></asp:TextBox>
</div>

<div class="form-group">
    <label>Descripción:</label>
    <asp:TextBox ID="TxtDescripcion" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3"></asp:TextBox>
</div>

<div class="form-group">
    <label>Fecha Inicio:</label>
    <asp:TextBox ID="TxtFechaInicio" runat="server" CssClass="form-control"></asp:TextBox>
</div>

<div class="form-group">
    <label>Fecha Fin:</label>
    <asp:TextBox ID="TxtFechaFin" runat="server" CssClass="form-control"></asp:TextBox>
</div>

<div class="form-group">
    <label>Profesor:</label>
    <asp:DropDownList ID="ddlProfesores" runat="server" CssClass="form-control">
        <asp:ListItem Text="-- Seleccione Profesor --" Value="" />
    </asp:DropDownList>
</div>

<div class="form-group">
    <label>Curso:</label>
    <asp:DropDownList ID="ddlCursos" runat="server" CssClass="form-control">
        <asp:ListItem Text="-- Seleccione Curso --" Value="" />
    </asp:DropDownList>
</div>

<asp:HiddenField ID="IDProyecto" runat="server" />

<div class="form-group">
    <asp:Button ID="btnGuardarProyecto" runat="server" Text="Guardar Proyecto" CssClass="btn btn-primary" OnClick="btnGuardarProyecto_Click" />
</div>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="IdProyecto" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="IdProyecto" HeaderText="IdProyecto" InsertVisible="False" ReadOnly="True" SortExpression="IdProyecto" />
            <asp:BoundField DataField="Titulo" HeaderText="Titulo" SortExpression="Titulo" />
            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
            <asp:BoundField DataField="FechaInicio" HeaderText="FechaInicio" SortExpression="FechaInicio" />
            <asp:BoundField DataField="FechaFin" HeaderText="FechaFin" SortExpression="FechaFin" />
            <asp:BoundField DataField="NombreProfesor" HeaderText="NombreProfesor" ReadOnly="True" SortExpression="NombreProfesor" />
        </Columns>
    </asp:GridView>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Gestion_Proyectos_AcademicosConnectionString3 %>" SelectCommand=" SELECT 
        p.IdProyecto, 
        p.Titulo, 
        p.Descripcion, 
        p.FechaInicio, 
        p.FechaFin,
        u.Nombre + ' ' + u.Apellido1 + ' ' + u.Apellido2 AS NombreProfesor
    FROM Proyectos p
    LEFT JOIN Usuarios u ON p.IdUsuarioCreador = u.IdUsuario
    ORDER BY p.IdProyecto DESC;"></asp:SqlDataSource>

</asp:Content>
