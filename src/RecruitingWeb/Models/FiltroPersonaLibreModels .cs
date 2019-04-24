using System.Collections.Generic;
using System.Web.Mvc;

namespace RecruitingWeb.Models
{
    public class FiltroPersonaLibreModels
    {
        public FiltroPersonaLibreModels()
        {
            ListasModalNecesidades = new ListasModalNecesidadesViewModel();
        }

        public int? NumeroEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Categoria { get; set; }
        public int TipoTecnologiaId { get; set; }
        public string Linea { get; set; }
        public string Celda { get; set; }
        public string FechaLiberacion { get; set; }
        public int? NecesidadId { get; set; }        
        public int? EstadoPersonaLibreId { get; set; }
        public string Centro { get; set; }
        public int? CentroIdUsuario { get; set; }
        public string Buscar { get; set; }
        public string SinNecesidadAsignada { get; set; }
        public string NivelIdioma { get; set; }
        public IEnumerable<SelectListItem> NivelIdiomaList { get; set; }
        public IEnumerable<SelectListItem> TecnologiaList { get; set; }
        public IEnumerable<SelectListItem> CentroList { get; set; }
        public string CentroIdUsuarioLogueado { get; set; }
        public int? Pagina { get; set; }

        public string SortColumn { get; set; }
        public Recruiting.Business.BaseClasses.DataTable.DataTableSortDirectionEnum SortOrder { get; set; }

        public ListasModalNecesidadesViewModel ListasModalNecesidades { get; set; }
    }
}