using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTO;
using CTR;
using System.Web.Security;

namespace ReportesCovid_web.Pages.Contacto
{
    public partial class VisualizarCredencial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DtoPaciente userPaciente = (DtoPaciente)Session["PacienteContacto"];
                if (userPaciente != null)
                {
                    FirstLoad();
                }
                else
                {
                    Response.Redirect("logOutContacto");
                }
            }
        }
        public void FirstLoad()
        {
            CargarDatosPaciente();
            CargarTipoTraslado();
            CargarReporteMedico();

        }
        private void CargarTipoTraslado()
        {
            try
            {
                ClassResultV cr = new CtrTablaVarios().Usp_TablaVarios_SelectAll(new DtoTablaVarios
                {
                    TipoAtributo = "IN_TipoTraslado",
                    EntidadTabla = "PacienteHistorial"
                });
                if (!cr.HuboError)
                {
                    List<DtoTablaVarios> list = cr.List.Cast<DtoTablaVarios>().ToList();
                    ddlTipoTraslado.DataTextField = "Descripcion";
                    ddlTipoTraslado.DataValueField = "Valor";
                    ddlTipoTraslado.DataSource = list;
                    ddlTipoTraslado.DataBind();

                    ListItem firstLista = new ListItem(" ", "");
                    firstLista.Attributes.Add("disabled", "disabled");
                    firstLista.Attributes.Add("Selected", "True");
                    ddlTipoTraslado.Items.Insert(0, firstLista);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Pop", @"Swal.fire('Error!', '" + "No se pudieron cargar Tipo Traslado." + "', 'error');", true);
            }
        }

        private void CargarDatosPaciente()
        {
            try
            {
                DtoPaciente userPaciente = (DtoPaciente)Session["PacienteContacto"];

                txtNombres.Text = userPaciente.Nombres;
                txtApellidos.Text = userPaciente.Apellidos;
                txtNumdoc.Text = userPaciente.NombreTipodoc + "-" + userPaciente.Numdoc.ToString();
                txtEstadoPaciente.Text = userPaciente.NombreEstadoPaciente;
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void CargarReporteMedico()
        {
            try
            {
                DtoPaciente userPaciente = (DtoPaciente)Session["PacienteContacto"];
                DtoPacienteHistorial dtoPH = new CtrPacienteHistoria().Usp_PacienteHistorial_SelectOne(new DtoPacienteHistorial
                {
                    PacienteId = userPaciente.IdPaciente
                });
                if (!dtoPH.HuboError)
                {

                    txtFechaCreacion.Text = dtoPH.FechaCreacion.ToString();
                    txtTemperatura.Text = dtoPH.Temperatura;
                    txtFrecuencia.Text = dtoPH.FrecuenciaCardiaca;
                    txtPresion.Text = dtoPH.PresionArterial;
                    txtSaturacion.Text = dtoPH.Saturacion;
                    txtPronostico.Text = dtoPH.Pronostico;
                    txtRequerimiento.Text = dtoPH.Requerimiento;
                    txtEvolucion.Text = dtoPH.Evolucion;

                    cbTraslado.Checked = dtoPH.IB_Traslado;
                    if (dtoPH.IB_Traslado)
                    {
                        lblTraslado.CssClass = "badge rounded-pill bg-danger";
                        lblTraslado.Text = "Requiere Traslado!";

                        txtFechaTraslado.Text = dtoPH.FechaSolicitudTraslado.ToString("dd/MM/yyyy");
                        ddlTipoTraslado.SelectedValue = dtoPH.IN_TipoTraslado.ToString();
                        txtComentario.Text = dtoPH.DescTraslado;
                    }

                    DtoUsuario dtoUser = new CtrUsuario().Usp_Usuario_SelectOne(new DtoUsuario
                    {
                        IdUsuario = dtoPH.UsuarioCreacionId
                    });
                    if (!dtoUser.HuboError)
                    {
                        txtMedico.Text = dtoUser.PrimerNombre + " " + dtoUser.SegundoNombre + " " + dtoUser.ApellidoPaterno + " " + dtoUser.ApellidoMaterno;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}