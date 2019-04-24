using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace RecruitingWeb.Models
{
    public class FiltroNecesidadesModels
    {
 
        public int? ClienteId { get; set; }
        public int? ProyectoId { get; set; }
        public int? TipoTecnologiaId { get; set; }
        public int? TipoPrevisionId { get; set; }
        public string Estado { get; set; }
        public string Perfil { get; set; }
        public DateTime? FechaEntre { get; set; }
        public DateTime? FechaHasta { get; set; }

        public int? CentroIdUsuario { get; set; }
        public bool? MisNecesidades { get; set; }
        public bool? NecesidadIdioma { get; set; }

        public string Buscar { get; set; }

        public DateTime? FechaCierreEntre { get; set; }
        public DateTime? FechaCierreHasta { get; set; }
        public int? IdNecesidad { get; set; }
        public int? TipoContratacionId { get; set; }
        public bool? AsignadoCorrectamente { get; set; }

        public string SortColumn { get; set; }
        public Recruiting.Business.BaseClasses.DataTable.DataTableSortDirectionEnum SortOrder { get; set; }

        public IEnumerable<SelectListItem> PerfilList { get; set; }
        public IEnumerable<SelectListItem> EstadoList { get; set; }
        public IEnumerable<SelectListItem> PrevisionList { get; set; }
        public IEnumerable<SelectListItem> TecnologiaList { get; set; }
        public IEnumerable<SelectListItem> ContratacionList { get; set; }
        public IEnumerable<SelectListItem> CentroList { get; set; }
        public IEnumerable<SelectListItem> ClienteList { get; set; }
        public IEnumerable<SelectListItem> ProyectoList { get; set; }
        public string CentroIdUsuarioLogueado { get; set; }
        public int? Pagina { get; set; }
    }
}