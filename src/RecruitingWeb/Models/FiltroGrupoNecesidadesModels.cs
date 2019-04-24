using System.Collections.Generic;
using System.Web.Mvc;

namespace RecruitingWeb.Models
{
    public class FiltroGrupoNecesidadesModels
    {
 
        public int? Cliente { get; set; }
        public int? Proyecto { get; set; }
        public bool? EstadoGrupoNecesidad { get; set; }
        public int? GrupoNecesidadId { get; set; }
        public string GrupoNecesidadNombre { get; set; }  
        public int? Centro { get; set; }

        public string SortColumn { get; set; }
        public Recruiting.Business.BaseClasses.DataTable.DataTableSortDirectionEnum SortOrder { get; set; }

        public IEnumerable<SelectListItem> ClienteList { get; set; }
        public IEnumerable<SelectListItem> ProyectoList { get; set; }
        public string CentroIdUsuarioLogueado { get; set; }
        public IEnumerable<SelectListItem> CentroList { get; set; }
    }
}