<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="Gestion_Proyecto_Academico_Progra3._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main class="container mt-5">
        <div class="text-center mb-5">
            <h1 class="display-4 fw-bold text-primary">Universidad Central</h1>
            <p class="lead text-secondary">Formando profesionales con excelencia académica y compromiso social</p>
        </div>

        <div class="row text-center">
            <section class="col-md-4 mb-4">
                <div class="card shadow-lg border-0 h-100">
                    <div class="card-body">
                        <h3 class="card-title text-primary">Carreras Universitarias</h3>
                        <p class="card-text text-muted">
                            Descubra la amplia oferta académica de la Universidad Central.
                        </p>
                        <a class="btn btn-primary" href="https://universidadcentral.co.cr/estudiantes-regulares/">Ingrese aquí &raquo;</a>
                    </div>
                </div>
            </section>
            <section class="col-md-4 mb-4">
                <div class="card shadow-lg border-0 h-100">
                    <div class="card-body">
                        <h3 class="card-title text-primary">Reseña Histórica</h3>
                        <p class="card-text text-muted">
                            Conozca la trayectoria y los logros de nuestra institución.
                        </p>
                        <a class="btn btn-primary" href="https://universidadcentral.co.cr/estudiantes-regulares/">Ingrese aquí &raquo;</a>
                    </div>
                </div>
            </section>
            <section class="col-md-4 mb-4">
                <div class="card shadow-lg border-0 h-100">
                    <div class="card-body">
                        <h3 class="card-title text-primary">Inversión</h3>
                        <p class="card-text text-muted">
                            Conozca los costos, beneficios y servicios que ofrecemos.
                        </p>
                        <a class="btn btn-primary" href="https://universidadcentral.co.cr/estudiantes-regulares/">Ingrese aquí &raquo;</a>
                    </div>
                </div>
            </section>
        </div>
    </main>

</asp:Content>
