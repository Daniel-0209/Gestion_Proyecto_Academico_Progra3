<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Comentarios.aspx.vb" Inherits="Gestion_Proyecto_Academico_Progra3.Comentarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:HiddenField ID="IDComentario" runat="server" />
    <div class="form-group">
        <asp:Label ID="lblComentario" runat="server" Text="Escribir anuncio:"></asp:Label>
        <asp:TextBox ID="txtComentario" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3"></asp:TextBox>
    </div>
    <asp:RequiredFieldValidator ID="valComentario" runat="server"
        ControlToValidate="txtComentario"
        ErrorMessage="* Este campo es obligatorio"
        CssClass="text-danger"
        Display="Dynamic" />
    <asp:Label ID="LblMensaje" runat="server" CssClass="text-success"></asp:Label>
    <div class="form-group">
        <asp:Label ID="lblDestinatario" runat="server" Text="Destinatario:"></asp:Label>
        <asp:DropDownList ID="ddlDestinatario" runat="server" CssClass="form-control">
            <asp:ListItem Text="Profesor" Value="Profesor"></asp:ListItem>
            <asp:ListItem Text="Estudiante" Value="Estudiante"></asp:ListItem>
            <asp:ListItem Text="Ambos" Value="Ambos"></asp:ListItem>
        </asp:DropDownList>
    </div>

    <asp:Button ID="btnEnviarComentario" runat="server" Text="Enviar" CssClass="btn btn-primary" OnClick="btnEnviarComentario_Click" />

    <asp:GridView ID="grvComentarios" runat="server"
        OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
        OnRowDeleting="GridView1_RowDeleting"
        DataSourceID="SqlDataSource1" AutoGenerateColumns="False" DataKeyNames="IdComentario" CssClass="table table-hover"
        HeaderStyle-CssClass="table-header"
        RowStyle-CssClass="table-row"
        AlternatingRowStyle-CssClass="table-alt-row">
        <Columns>
            <asp:CommandField ShowSelectButton="true" />
            <asp:BoundField DataField="IdComentario" HeaderText="IdComentario" InsertVisible="False" ReadOnly="True" SortExpression="IdComentario" />
            <asp:BoundField DataField="Mensaje" HeaderText="Mensaje" SortExpression="Mensaje" />
            <asp:BoundField DataField="FechaEnvio" HeaderText="FechaEnvio" SortExpression="FechaEnvio" />
            <asp:BoundField DataField="Destinatario" HeaderText="Destinatario" SortExpression="Destinatario" />
            <asp:CommandField ShowDeleteButton="true" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Gestion_Proyectos_AcademicosConnectionString4 %>" SelectCommand="SELECT * FROM [Comentarios]"></asp:SqlDataSource>
</asp:Content>
