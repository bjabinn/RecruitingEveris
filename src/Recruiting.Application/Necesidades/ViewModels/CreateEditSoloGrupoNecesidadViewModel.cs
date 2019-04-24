using System;

namespace Recruiting.Application.Necesidades.ViewModels
{
    [Serializable]
    public class CreateEditSoloGrupoNecesidadViewModel
    {        
        public int? GrupoNecesidadId { get; set; }  
        public string NombreGrupo { get; set; }
        public string DescripcionGrupo { get; set; }
        public bool EstadoGrupo { get; set; }     

    }
}
