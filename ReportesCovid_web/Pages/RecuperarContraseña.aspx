﻿<%@ Page Title="Restaurar" Language="C#" MasterPageFile="~/MasterPages/Inicial.Master" AutoEventWireup="true" CodeBehind="RecuperarContraseña.aspx.cs" Inherits="ReportesCovid_web.Pages.RestaurarContraseña" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="PageContentTitle" runat="server">
</asp:Content>--%>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="app-content content m-lg-5">
        <h1 class="text-center">Restaurar Contraseña</h1>
        <div class="content-overlay m-5"></div>
        <div class="content-wrapper">
            <div class="content-header row">
            </div>
            <div class="content-body">
                <!-- users edit start -->
                <section class="users-edit">
                    <div class="card">
                        <div class="card-body">

                            <div class="ade show" id="contacto" aria-labelledby="contacto-tab">
                                <div class="row g-3 my-4">

                                    <div class="col-md-6">
                                        <label for="txtUsuario" class="form-label">Usuario</label>
                                        <asp:TextBox type="text" class="form-control" ID="txtUsuario" name="tUsuario" runat="server" required="true"></asp:TextBox>
                                        <div class="invalid-feedback">
                                            Debe rellenar este campo
                                        </div>
                                    </div>

                                    <div class="col-md-6">
                                        <label for="ddlTipoDocumento" class="form-label">Tipo Documento</label>
                                        <asp:DropDownList runat="server" ID="ddlTipoDoc" class="form-select" required="true">
                                        </asp:DropDownList>
                                        <div class="invalid-feedback">
                                            Debe seleccionar un Tipo de documento valido.
                                        </div>
                                    </div>

                                    <div class="col-md-6">
                                        <label for="txtNumdoc" class="form-label">Número de Documento</label>
                                        <asp:TextBox type="text" class="form-control" ID="txtNumDoc" onkeypress="return solonumerosydecimales(event);" name="tNumDocContacto" MaxLength="10" runat="server" required="true"></asp:TextBox>
                                        <div class="invalid-feedback">
                                            Debe llenar este cambo.
                                        </div>
                                    </div>


                                    <div class="col-md-6">
                                        <label for="txtCorreo" class="form-label">Correo</label>
                                        <div class="input-group has-validation">
                                            <span class="input-group-text" id="inputGroupPrepend">@</span>
                                            <asp:TextBox type="email" CssClass="form-control" ID="txtCorreoContacto" runat="server" aria-describedby="inputGroupPrepend" required="true"></asp:TextBox>
                                            <div class="invalid-feedback">
                                                Debe ingresar un correo valido.
                                            </div>
                                        </div>
                                    </div>

                                </div>

                            </div>
                            <div class="col-12 d-flex flex-sm-row flex-column justify-content-end mt-1">

                                <%--<asp:Button runat="server" ID="btnRegistrarPaciente" CssClass="btn btn-primary glow" Text="Registrar Paciente" OnClick="btnRegistrarPaciente_Click"></asp:Button>--%>
                                <asp:Button runat="server" ID="btnRestaurar" CssClass="btn btn-primary glow" Text="Restaurar"></asp:Button>

                                <%-- FALTA FUNCIONAMIENTO DE BOTON --%>
                            </div>


                        </div>
                    </div>
                </section>
                <!-- users edit ends -->

            </div>
        </div>
    </div>
</asp:Content>

<%--<asp:Content ID="Content4" ContentPlaceHolderID="Foot" runat="server">
    <script>
        (function () {
            'use strict'

            // Fetch all the forms we want to apply custom Bootstrap validation styles to
            var forms = document.querySelectorAll('.needs-validation')

            // Loop over them and prevent submission
            Array.prototype.slice.call(forms)
                .forEach(function (form) {
                    form.addEventListener('submit', function (event) {
                        if (!form.checkValidity()) {
                            event.preventDefault()
                            event.stopPropagation()
                        }

                        form.classList.add('was-validated')
                    }, false)
                })
        })()

        jQuery(function () {
            jQuery('#MyTab a').on('click', function () {
                $(this).tab('show');
            });
        })

    </script>
</asp:Content>--%>
