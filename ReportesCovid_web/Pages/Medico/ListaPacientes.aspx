﻿<%@ Page Title="Essalud - Pacientes" Language="C#" MasterPageFile="~/MasterPages/Web_Usuarios.Master" AutoEventWireup="true" CodeBehind="ListaPacientes.aspx.cs" Inherits="ReportesCovid_web.Pages.Medico.ListaPacientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <style>
        .Pager span {
            border-top-left-radius: .2rem;
            border-bottom-left-radius: .2rem;
            z-index: 3;
            color: #fff;
            background-color: #0d6efd;
            border-color: #0d6efd;
            text-align: center;
            display: inline-block;
            padding: .25rem .5rem;
            font-size: .875rem;
            margin-right: 3px;
            line-height: 150%;
            border: 1px solid #dee2e6;
            transition: color .15s ease-in-out,background-color .15s ease-in-out,border-color .15s ease-in-out,box-shadow .15s ease-in-out;
            text-decoration: none;
            position: relative;
            display: block;
        }

        .Pager a {
            border-top-left-radius: .2rem;
            border-bottom-left-radius: .2rem;
            z-index: 3;
            color: #0d6efd;
            background-color: #fff;
            border-color: #0d6efd;
            text-align: center;
            display: inline-block;
            padding: .25rem .5rem;
            font-size: .875rem;
            margin-right: 3px;
            line-height: 150%;
            border: 1px solid #dee2e6;
            transition: color .15s ease-in-out,background-color .15s ease-in-out,border-color .15s ease-in-out,box-shadow .15s ease-in-out;
            text-decoration: none;
            position: relative;
            display: block;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContentTitle" runat="server">
    <h3>Lista Pacientes</h3>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="app-content content">
        <div class="content-overlay"></div>
        <div class="content-wrapper">
            <div class="content-header row">
            </div>
            <div class="content-body">
                <section class="users-list-wrapper">
                    <div class="users-list-filter px-1">
                        <div class="container border rounded">
                            <div class="row py-2">
                                <div class="col-12 col-sm-6 col-lg-3">
                                    <label for="txtBuscar">Criterio</label>
                                    <asp:TextBox runat="server" ID="txtBuscar" CssClass="form-control me-2" type="search" placeholder="Buscar" aria-label="buscar"></asp:TextBox>
                                </div>
                                <div class="col-12 col-sm-6 col-lg-3">
                                    <label for="ddlEstadoPaciente">Estado</label>
                                    <asp:DropDownList runat="server" ID="ddlEstadoPaciente" class="form-select">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-12 col-sm-6 col-lg-3 d-flex align-items-end">
                                    <asp:LinkButton runat="server" ID="btnBuscar" CssClass="btn btn-outline-success end" Text="Buscar" OnClick="btnBuscar_Click"></asp:LinkButton>
                                </div>
                            </div>
                            <div class="row mb-2">
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="users-list-table">
                        <div class="card">
                            <div class="card-body">
                                <!-- datatable start -->
                                <div class="table-responsive mx-5">
                                    <div class="table table-striped table-sm table-primary">
                                        <asp:GridView runat="server" ID="gvPacientes" AutoGenerateColumns="False" AllowPaging="True"
                                            CssClass="table" PageSize="5" OnRowCommand="gvPacientes_RowCommand" OnPageIndexChanging="gvPacientes_PageIndexChanging"
                                            EmptyDataText="No se encontraron datos." GridLines="None">
                                            <columns>
                                                <asp:TemplateField Visible="false">
                                                    <%--<HeaderStyle Width="11%" />--%>
                                                    <headertemplate>Código Paciente</headertemplate>
                                                    <itemtemplate>
                                                        <asp:Label ID="lblIdPaciente" runat="server" Text='<% #Bind("IdPaciente")%>' />
                                                    </itemtemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField>
                                                    <%--<HeaderStyle Width="3%" />--%>
                                                    <headertemplate>Nombres</headertemplate>
                                                    <itemtemplate>
                                                        <asp:Label ID="lblNombres" runat="server" Text='<% #Bind("Nombres")%>' />
                                                    </itemtemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField>
                                                    <%--      <HeaderStyle Width="3%" />--%>
                                                    <headertemplate>Apellidos</headertemplate>
                                                    <itemtemplate>
                                                        <asp:Label ID="lblApellidos" runat="server" Text='<% #Bind("Apellidos")%>' />
                                                    </itemtemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField>
                                                    <%--<HeaderStyle Width="3%" />--%>
                                                    <headertemplate>Tipo Documento</headertemplate>
                                                    <itemtemplate>
                                                        <asp:Label ID="lblTipoDocumento" runat="server" Text='<% #Bind("NombreTipodoc")%>' />
                                                    </itemtemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField>
                                                    <%--<HeaderStyle Width="3%" />--%>
                                                    <headertemplate>Numero Documento</headertemplate>
                                                    <itemtemplate>
                                                        <asp:Label ID="lblNumDocumento" runat="server" Text='<% #Bind("Numdoc")%>' />
                                                    </itemtemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField>
                                                    <%--<HeaderStyle Width="3%" />--%>
                                                    <headertemplate>Tipo Seguro</headertemplate>
                                                    <itemtemplate>
                                                        <asp:Label ID="lblTipoSeguro" runat="server" Text='<% #Bind("NombreTipoSeguro")%>' />
                                                    </itemtemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField>
                                                    <%--<HeaderStyle Width="3%" />--%>
                                                    <headertemplate>Estado Paciente</headertemplate>
                                                    <itemtemplate>
                                                        <asp:Label ID="lblEstadoPaciente" runat="server" Text='<% #Bind("NombreEstadoPaciente")%>' />
                                                    </itemtemplate>
                                                </asp:TemplateField>


                                                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                                    <headerstyle width="7.5%" />
                                                    <headertemplate>Generar Reporte</headertemplate>
                                                    <itemtemplate>
                                                        <asp:LinkButton runat="server" ID="lnkGenerar" CommandName="Generar" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'><i class="bx bx-bar-chart-square"></i>Generar Reporte </asp:LinkButton>
                                                    </itemtemplate>
                                                </asp:TemplateField>

                                            </columns>
                                            <pagerstyle cssclass="Pager" />
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </section>
                <!-- users list ends -->

                <br />
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Foot" runat="server">
</asp:Content>