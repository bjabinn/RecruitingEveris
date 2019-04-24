using System;

namespace Recruiting.Application.Necesidades.ViewModels
{
    [Serializable]
    public class NecesidadRowViewModel
    {
        public int NecesidadId { get; set; }

        public string Cliente { get; set; }

        public string Nombre { get; set; }

        public string Proyecto { get; set; }

        public string Tecnologia { get; set; }

        public string Perfil { get; set; }

        public string Estado { get; set; }

        public string TipoPrevisionId{ get; set; }

        public DateTime FechaSolicitud { get; set; }

        public DateTime FechaCompromiso { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime FechaModificacion { get; set; }

        public DateTime? FechaCierre { get; set; }

        public string Centro { get; set; }

        public string PersonaAsignada { get; set; }

        public int? PersonaAsignadaId { get; set; }

        public int? PersonaAsignadaNroEmpleado { get; set; }

        public string Modulo { get; set; }

        public string TipoContratacion { get; set; }

        public string AsignadaCorrectamente { get; set; }
    }
}
