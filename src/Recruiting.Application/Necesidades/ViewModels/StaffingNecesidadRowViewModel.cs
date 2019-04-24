using System;

namespace Recruiting.Application.Necesidades.ViewModels
{
    [Serializable]
    public class StaffingNecesidadRowViewModel
    {
        public int NecesidadId { get; set; }     

        public string Cliente { get; set; }

        public string Proyecto { get; set; }

        public string TipoContratacion { get; set; }

        public int? TipoContratacionId { get; set; }

        public DateTime? FechaCompromiso { get; set; }

        public string Perfil { get; set; }

        public int? PerfilId { get; set; }

        public int? TecnologiaId { get; set; }

        public string PersonaAsignada { get; set; }    

        public int? PersonaAsignadaId { get; set; }        
        
        public int? TipoPersonaId { get; set; }

        public int? Prioridad { get; set; }

        public string ObservacionesStaffing { get; set; }



    }
}
