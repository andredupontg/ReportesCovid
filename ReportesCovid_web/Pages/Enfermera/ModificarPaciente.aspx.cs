﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTO;
using CTR;
using System.Web.Security;
namespace ReportesCovid_web.Pages.Enfermera
{
    public partial class ModificarPaciente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DtoUsuario user = (DtoUsuario)Session["UsuarioLogin"];
                if (user != null && user.IN_Rol == 2)
                {
                    FirstLoad();
                }
                else
                {
                    Session.RemoveAll();
                    Response.Redirect("logIn");
                }
            }
        }

        public void FirstLoad()
        {
            CargarTipoDocumento();
            CargarTipoSeguro();
            CargarEstadosPaciente();

            LlenarDetalle();
        }
        private void CargarTipoDocumento()
        {
            try
            {
                ClassResultV cr = new CtrTablaVarios().Usp_TablaVarios_Select(new DtoTablaVarios
                {
                    TipoAtributo = "IN_Tipodoc",
                    EntidadTabla = "Paciente"
                });
                if (!cr.HuboError)
                {
                    List<DtoTablaVarios> list = cr.List.Cast<DtoTablaVarios>().ToList();
                    //Paciente
                    ddlTipoDocumento.DataTextField = "Descripcion";
                    ddlTipoDocumento.DataValueField = "Valor";
                    ddlTipoDocumento.DataSource = list;
                    ddlTipoDocumento.DataBind();
                    //Contacto
                    ddlTipoDocContacto.DataTextField = "Descripcion";
                    ddlTipoDocContacto.DataValueField = "Valor";
                    ddlTipoDocContacto.DataSource = list;
                    ddlTipoDocContacto.DataBind();

                    //"<asp:ListItem Selected="True" disabled Value="" Text="Choose..."></asp:ListItem>"
                    ListItem firstLista = new ListItem("[Seleccionar]", "");
                    firstLista.Attributes.Add("disabled", "disabled");
                    firstLista.Attributes.Add("Selected", "True");
                    ddlTipoDocumento.Items.Insert(0, firstLista);
                    ddlTipoDocContacto.Items.Insert(0, firstLista);

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Pop", @"Swal.fire('Error!', '" + "No se pudieron cargar TipoDocumento." + "', 'error');", true);
            }
        }
        private void CargarTipoSeguro()
        {
            try
            {
                ClassResultV cr = new CtrTablaVarios().Usp_TablaVarios_Select(new DtoTablaVarios
                {
                    TipoAtributo = "IN_TipoSeguro",
                    EntidadTabla = "Paciente"
                });
                if (!cr.HuboError)
                {
                    List<DtoTablaVarios> list = cr.List.Cast<DtoTablaVarios>().ToList();
                    ddlTipoSeguro.DataTextField = "Descripcion";
                    ddlTipoSeguro.DataValueField = "Valor";
                    ddlTipoSeguro.DataSource = list;
                    ddlTipoSeguro.DataBind();
                    //"<asp:ListItem Selected="True" disabled Value="" Text="Choose..."></asp:ListItem>"
                    ListItem firstLista = new ListItem("[Seleccionar]", "");
                    firstLista.Attributes.Add("disabled", "disabled");
                    firstLista.Attributes.Add("Selected", "True");
                    ddlTipoSeguro.Items.Insert(0, firstLista);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Pop", @"Swal.fire('Error!', '" + "No se pudieron cargar TipoSeguro." + "', 'error');", true);
            }
        }
        private void CargarEstadosPaciente()
        {
            try
            {
                ClassResultV cr = new CtrTablaVarios().Usp_TablaVarios_Select(new DtoTablaVarios
                {
                    TipoAtributo = "IN_EstadoPaciente",
                    EntidadTabla = "Paciente"
                });
                if (!cr.HuboError)
                {
                    List<DtoTablaVarios> list = cr.List.Cast<DtoTablaVarios>().ToList();
                    ddlEstadoPaciente.DataTextField = "Descripcion";
                    ddlEstadoPaciente.DataValueField = "Valor";
                    ddlEstadoPaciente.DataSource = list;
                    ddlEstadoPaciente.DataBind();
                    //"<asp:ListItem Selected="True" disabled Value="" Text="Choose..."></asp:ListItem>"
                    ListItem firstLista = new ListItem("[Seleccionar]", "");
                    firstLista.Attributes.Add("disabled", "disabled");
                    firstLista.Attributes.Add("Selected", "True");
                    ddlEstadoPaciente.Items.Insert(0, firstLista);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Pop", @"Swal.fire('Error!', '" + "No se pudieron cargar TipoSeguro." + "', 'error');", true);
            }
        }

        private void LlenarDetalle()
        {

            DtoPaciente dtop = new CtrPaciente().Usp_Contacto_SelectOne(new DtoPaciente
            {
                IdPaciente = Convert.ToInt32(Request.QueryString["idPaciente"])
            });
            if (!dtop.HuboError)
            {
                txtNombres.Text = dtop.Nombres;
                txtApellidos.Text = dtop.Apellidos;
                ddlTipoDocumento.SelectedValue = dtop.IN_Tipodoc.ToString();
                txtNumdoc.Text = dtop.Numdoc.ToString();
                ddlTipoSeguro.SelectedValue = dtop.IN_TipoSeguro.ToString();
                ddlEstadoPaciente.SelectedValue = dtop.IN_EstadoPaciente.ToString();

                DtoContacto dtoC = new CtrContacto().Usp_Contacto_SelectOne(new DtoContacto
                {
                    PacienteId = Convert.ToInt32(Request.QueryString["idPaciente"])
                });
                if (!dtoC.HuboError)
                {
                    txtNombreApellidoContacto.Text = dtoC.NombreCompleto;
                    ddlTipoDocContacto.Text = dtoC.IN_Tipodoc.ToString();
                    txtNumDocContacto.Text = dtoC.Numdoc;
                    txtCorreoContacto.Text = dtoC.Email;
                    txtTelefonoContacto.Text = dtoC.Telefono;
                }
            }
        }
    }
}