using System;

namespace Recruiting.Application.Necesidades.ViewModels
{
    [Serializable]
    public class SaveStaffingNecesidadViewModel
    {
        public int NecesidadId { get; set; }          

        public int? PersonaAsignadaId { get; set; }        
        
        public int? TipoPersonaId { get; set; }
       



    }
}
