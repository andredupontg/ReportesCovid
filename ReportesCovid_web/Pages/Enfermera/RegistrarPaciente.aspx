﻿<%@ Page Language="C#" MasterPageFile="~/MasterPages/Usuario.Master" AutoEventWireup="true" CodeBehind="RegistrarPaciente.aspx.cs" Inherits="ReportesCovid_web.Pages.Enfermera.RegistrarPaciente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
    </script>


    <div class="container m-auto mt-4 shadow p-3 mb-5 bg-body rounded">
        <main>
            <div>
                <h4 class="mb-3">Nuevo Paciente</h4>
                <div>
                    <%--                    <div class="row g-3 my-4">
                        <div class="col-sm-6">
                            <label for="txtnombre" class="form-label">Nombres</label>
                            <asp:TextBox type="text" class="form-control" ID="txtnombre" name="tNombres" runat="server"></asp:TextBox>
                            <%--                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtnombre" ValidationGroup="Add" CssClass="invalid-feedback" ErrorMessage=" Valid first name is required.">
                                    </asp:RequiredFieldValidator>
                        </div>
                        <div class="col-sm-6">
                            <label for="txtApellidos" class="form-label">Apellidos</label>
                            <asp:TextBox type="text" class="form-control" ID="txtApellidos" name="tApellidos" runat="server"></asp:TextBox>
                                                         <asp:RequiredFieldValidator runat="server" ControlToValidate="txtApellidos" ValidationGroup="Add" CssClass="invalid-feedback">
                                Valid first name is required.
                                    </asp:RequiredFieldValidator>
                        </div>

                
                        <div class="col-sm-6">
                            <label for="ddlTipoDocumento" class="form-label">Tipo Documento</label>
                            <asp:DropDownList runat="server" ID="ddlTipoDocumento" class="form-control">
                            </asp:DropDownList>
                        </div>
                     

                        <div class="col-6">
                            <label for="dni" class="form-label">Número de Documento</label>
                            <asp:TextBox type="text" class="form-control" ID="txtNumdoc" name="tDoc" runat="server"></asp:TextBox>
                                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNumdoc" ValidationGroup="Add" CssClass="invalid-feedback">
                                Valid first name is required.
                                    </asp:RequiredFieldValidator>
                        </div>

                    
                        <div class="col-sm-6">
                            <label for="TipoSeguro" class="form-label">Tipo Seguro</label>
                            <asp:DropDownList runat="server" ID="ddlTipoSeguro" class="form-control">
                            </asp:DropDownList>
                        </div>

                        <div class="col-sm-6">
                            <label for="EstadoPaciente" class="form-label">Estado Paciente</label>
                            <asp:DropDownList runat="server" ID="ddlEstadoPaciente" class="form-control">
                            </asp:DropDownList>

                        </div>
                   

                        <div class="col-6">
                            <label for="validationCustomUsername" class="form-label">Username</label>
                            <div class="input-group has-validation">
                                <span class="input-group-text" id="inputGroupPrepend">@</span>
                                <input type="text" class="form-control" id="validationCustomUsername" aria-describedby="inputGroupPrepend" required>
                                <div class="invalid-feedback">
                                    Please choose a username.
                                </div>

                                                                 <label for="emailResponsable" class="form-label">Correo de Responsable</label>
                                    <span class="input-group-text" id="inputGroupPrepend">@</span>
                                    <asp:TextBox type="text" class="form-control" ID="txtCorreo" name="email" runat="server"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2"
                                        ControlToValidate="txtCorreo"
                                        ValidationExpression="[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,}$"
                                        Display="Dynamic"
                                        ErrorMessage="email@ejemplo.com"
                                        EnableClientScript="true"
                                        CssClass="invalid-feedback"
                                        runat="server" ValidationGroup="Add" ForeColor="Red" />
                            </div>
                        </div>
                        <div class="col-6">

                            <label for="telefonoResponsable" class="form-label">Telefono de Responsable</label>
                            <asp:TextBox type="text" class="form-control" ID="txtTelefonoResponsable" name="tTelefonoResponsable" runat="server"></asp:TextBox>
                                                             <asp:RequiredFieldValidator runat="server" ControlToValidate="txtTelefonoResponsable" ValidationGroup="Add" CssClass="invalid-feedback">
                                Valid first name is required.
                                    </asp:RequiredFieldValidator>
                        </div>
                        <div class="col-6">
                            <label for="NombreApellidoResposable" class="form-label">Nombre y Apellido de Responsable</label>
                            <asp:TextBox type="text" class="form-control" ID="txtNombreApellidoResposable" name="tNombreApellidoResposable" runat="server"></asp:TextBox>
                                                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNombreApellidoResposable" ValidationGroup="Add" CssClass="invalid-feedback">
                                Valid first name is required.
                                    </asp:RequiredFieldValidator>
                        </div>

                        <div class="card-body m-5 position-relative">
                            <asp:Button runat="server" ID="btnregistrar" CssClass=" w-50 btn btn-primary glow mb-2 position-absolute top-100 start-50 translate-middle" Text="Crear Paciente y Enviar Credencial"></asp:Button>
                            <asp:Button runat="server" class="w-50 btn btn-secondary my-5 position-absolute top-100 start-50 translate-middle" type="submit" Text="Cargar CSV"></asp:Button>
                        </div>
                    </div>--%>
                    <div class="row g-3 my-4">
                        <div class="col-md-6">
                            <label for="txtNombres" class="form-label">Nombres</label>
                            <asp:TextBox type="text" class="form-control" ID="txtNombres" runat="server" required="true"></asp:TextBox>
                            <div class="invalid-feedback">
                                Debe llenar este cambo.
                            </div>
                        </div>
                        <div class="col-md-6">
                            <label for="tApellidos" class="form-label">Apellidos</label>
                            <asp:TextBox type="text" class="form-control" ID="txtApellidos" runat="server" required="true"></asp:TextBox>
                            <div class="invalid-feedback">
                                Debe llenar este cambo.
                            </div>
                        </div>

                        <div class="col-md-6">
                            <label for="ddlTipoDocumento" class="form-label">Tipo Documento</label>
                            <asp:DropDownList runat="server" ID="ddlTipoDocumento" class="form-select" required="true">
                            </asp:DropDownList>
                            <div class="invalid-feedback">
                                Debe seleccionar un Tipo de documento valido.
                            </div>
                        </div>

                        <div class="col-md-6">
                            <label for="txtNumdoc" class="form-label">Número de Documento</label>
                            <asp:TextBox type="text" class="form-control" ID="txtNumdoc" onkeypress="return solonumerosydecimales(event);" name="tDoc" runat="server" required="true"></asp:TextBox>
                            <div class="invalid-feedback">
                                Debe llenar este cambo.
                            </div>
                        </div>

                        <div class="col-md-6">
                            <label for="ddlTipoSeguro" class="form-label">Tipo Seguro</label>
                            <asp:DropDownList runat="server" ID="ddlTipoSeguro" class="form-select" required="true">
                            </asp:DropDownList>
                            <div class="invalid-feedback">
                                Debe seleccionar un Tipo de seguro valido.
                            </div>
                        </div>
                        <div class="col-md-6">
                            <label for="ddlEstadoPaciente" class="form-label">Estado Paciente</label>
                            <asp:DropDownList runat="server" ID="ddlEstadoPaciente" class="form-select" required="true">
                            </asp:DropDownList>
                            <div class="invalid-feedback">
                                Debe seleccionar un Estado de paciente valido.
                            </div>
                        </div>

                        <div class="col-md-6">
                            <label for="txtCorreo" class="form-label">Correo</label>
                            <div class="input-group has-validation">
                                <span class="input-group-text" id="inputGroupPrepend">@</span>
                                <asp:TextBox type="email" CssClass="form-control" ID="txtCorreo" runat="server" aria-describedby="inputGroupPrepend" required="true"></asp:TextBox>
                                <div class="invalid-feedback">
                                    Debe ingresar un correo valido.
                                </div>
                            </div>
                        </div>

                        <div class="col-md-6">
                            <label for="txtTelefonoResponsable" class="form-label">Telefono de Responsable</label>
                            <asp:TextBox type="text" class="form-control" ID="txtTelefonoResponsable" onkeypress ="return solonumerosydecimales(event);" runat="server" required="true" MaxLength="9"></asp:TextBox>
                            <div class="invalid-feedback">
                                Debe llenar este cambo.
                            </div>
                        </div>


                        <div class="col-md-6">
                            <label for="txtTelefonoResponsable" class="form-label">Nombre y Apellido de Responsable</label>
                            <asp:TextBox type="text" class="form-control" ID="txtNombreApellidoResposable" runat="server" required="true"></asp:TextBox>
                            <div class="invalid-feedback">
                                Debe llenar este cambo.
                            </div>
                        </div>

                        <div class="col-12">
                            <asp:Button runat="server" CssClass="btn btn-primary" Text="Registrar Paciente"></asp:Button>
                        </div>

                    </div>
                </div>
            </div>
        </main>
    </div>
</asp:Content>
