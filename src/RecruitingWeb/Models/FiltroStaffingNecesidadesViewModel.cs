using System.Collections.Generic;
using System.Web.Mvc;

namespace RecruitingWeb.Models
{
    public class FiltroStaffingNecesidadesViewModel
    {


        public int? TipoTecnologiaId { get; set; }
        public int? TipoPerfilId { get; set; }
        public int? CentroIdUsuario { get; set; }
        public int? EstadoStaffingNecesidadId { get; set; }
        public int? ProyectoId { get; set; }

        public IEnumerable<SelectListItem> TecnologiaList { get; set; }
        public IEnumerable<SelectListItem> CategoriaList { get; set; }
        public IEnumerable<SelectListItem> PerfilList { get; set; }
        public IEnumerable<SelectListItem> EstadoStaffingNecesidadList { get; set; }
        public IEnumerable<SelectListItem> ProyectoList { get; set; }
        public string CentroIdUsuarioLogueado { get; set; }
        public ModalEdicionNecesidadViewModel modalEdicionNecesidad { get; set;}
    }
}