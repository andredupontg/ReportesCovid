using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DtoContacto : DtoB
    {
        public int IdContacto { get; set; }
        public string NombreCompleto { get; set; }
        public int IN_Tipodoc { get; set; }
        public string Numdoc { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public bool EnvioCredencial { get; set; }
        public DateTime FechaEnvioCredencial { get; set; }
        public int UsuarioCreacionId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int UsuarioModificacionId { get; set; }
        public DateTime FechaModificacion { get; set; }
        public bool IB_Estado { get; set; }
        public int PacienteId { get; set; }
        //datos Extra
        public string NuevaCredencial { get; set; }
        public int IN_Tipodoc_Paciente { get; set; }
        public string Numdoc_Paciente { get; set; }
    }
}
