using System;

namespace Recruiting.Application.Necesidades.ViewModels
{
    [Serializable]
    public class GrupoNecesidadesRowViewModel
    {        
        public int? GrupoNecesidadId { get; set; }  
        public string NombreGrupo { get; set; }       
        public string EstadoGrupo { get; set; } 
        public string NombreCliente { get; set; }
        public string NombreProyecto { get; set; }
        public int NecesidadesAsignadas { get; set; }
        public int NecesidadesAbiertas { get; set; }
        public int NecesidadesCerradas { get; set; }
        public int NecesidadesPreasignadas { get; set; }

    }
}
