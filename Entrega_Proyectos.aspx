<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Entrega_Proyectos.aspx.vb" Inherits="Gestion_Proyecto_Academico_Progra3.Entrega_Proyectos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Subir Entrega</h2>

    <asp:Panel ID="pnlEntrega" runat="server" CssClass="form-container">
        <div class="form-group">
            <asp:Label ID="lblCurso" runat="server" Text="Curso: " AssociatedControlID="ddlCurso"></asp:Label>
            <asp:DropDownList ID="ddlCurso" runat="server" CssClass="form-control" AutoPostBack="true"
                OnSelectedIndexChanged="ddlCurso_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
        <div class="form-group">
            <asp:Label ID="lblProyecto" runat="server" Text="Proyecto: " AssociatedControlID="ddlProyecto"></asp:Label>
            <asp:DropDownList ID="ddlProyecto" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>

        <div class="form-group">
            <asp:Label ID="lblNombreEstudiante" runat="server" Text="Nombre del Estudiante:" AssociatedControlID="txtNombreEstudiante"></asp:Label>
            <asp:TextBox ID="txtNombreEstudiante" runat="server" CssClass="form-control" Placeholder="Ingrese su nombre"></asp:TextBox>
        </div>
        <asp:RequiredFieldValidator ID="valnom" runat="server"
            ControlToValidate="txtNombreEstudiante"
            ErrorMessage="* Este campo es obligatorio"
            CssClass="text-danger"
            Display="Dynamic" />

        <div class="form-group">
            <asp:Label ID="lblFecha" runat="server" Text="Fecha de Entrega: "></asp:Label>
            <asp:TextBox ID="txtFecha" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblArchivo" runat="server" Text="Archivo: " AssociatedControlID="fuArchivo"></asp:Label>
            <asp:FileUpload ID="fuArchivo" runat="server" CssClass="form-control" />
        </div>

        <div class="form-group">
            <asp:Button ID="btnEnviar" runat="server" Text="Enviar Entrega" CssClass="btn btn-primary" OnClick="btnEnviar_Click" />
        </div>
    </asp:Panel>

</asp:Content>
