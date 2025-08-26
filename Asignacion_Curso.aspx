<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Asignacion_Curso.aspx.vb" Inherits="Gestion_Proyecto_Academico_Progra3.Asignacion_Curso" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:HiddenField ID="IDAsignacion" runat="server" />
    <h2>Asignación de Cursos</h2>

    <div>
        <label>Profesor:</label>
        <asp:DropDownList ID="ddlProfesores" runat="server" CssClass="form-control">
            <asp:ListItem Text="-- Elegir Profesor: --" Value="" />
        </asp:DropDownList>

    </div>

    <div>
        <label>Curso:</label>
        <asp:DropDownList ID="ddlCursos" runat="server" CssClass="form-control">
            <asp:ListItem Text="-- Elegir Curso: --" Value="" />
        </asp:DropDownList>
    </div>

    <div>
        <label>Turno:</label>
        <asp:DropDownList ID="ddlTurnos" runat="server" CssClass="form-control">
            <asp:ListItem Text="-- Seleccione Turno --" Value="" />
            <asp:ListItem Text="Tarde" Value="Tarde" />
            <asp:ListItem Text="Noche" Value="Noche" />
        </asp:DropDownList>
         <asp:RequiredFieldValidator ID="rfvTurno" runat="server"
        ControlToValidate="ddlTurnos"
        InitialValue=""
        ErrorMessage="Debe seleccionar un turno."
        CssClass="text-danger"
        Display="Dynamic" />
    </div>

    <asp:Button ID="btnAsignar" runat="server" Text="Asignar Curso" CssClass="btn btn-primary" OnClick="btnAsignar_Click" />
    <asp:Label ID="LblMensaje" runat="server" Text=""></asp:Label>


    <asp:GridView ID="grvAsignacion" runat="server"
        OnSelectedIndexChanged="grvAsignacion_SelectedIndexChanged"
        OnRowDeleting="grvAsignacion_RowDeleting"
        DataSourceID="SqlDataSource1" AutoGenerateColumns="False" DataKeyNames="IdAsignacion">
        <Columns>
            <asp:CommandField ShowSelectButton="true" />
            <asp:BoundField DataField="IdAsignacion" HeaderText="IdAsignacion" InsertVisible="False" ReadOnly="True" SortExpression="IdAsignacion" />
            <asp:BoundField DataField="NombreProfesor" HeaderText="NombreProfesor" SortExpression="NombreProfesor" />
            <asp:BoundField DataField="NombreCurso" HeaderText="NombreCurso" SortExpression="NombreCurso" />
            <asp:BoundField DataField="Turno" HeaderText="Turno" SortExpression="Turno" />
            <asp:CommandField ShowDeleteButton="true" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Gestion_Proyectos_AcademicosConnectionString3 %>"
        SelectCommand="SELECT * FROM [AsignacionCursos]"></asp:SqlDataSource>
</asp:Content>
