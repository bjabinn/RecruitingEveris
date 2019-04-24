using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace RecruitingWeb.Models
{
    public class FiltroBecarioModels
    {
        public int? BecarioId { get; set; }
        public int? CandidatoId { get; set; }
        public string NombreBecario { get; set; }        
        public int? TipoBecarioId { get; set; }       
        public int[] TipoEstadoBecarioId { get; set; }
        public string BecarioCentroProcedencia { get; set; }
        public int? BecarioCentroProcedenciaId { get; set; }
        public string Buscar { get; set; }
        public int? ProyectoId { get; set; }
        public string Proyecto { get; set; }
        public int? ClienteId { get; set; }
        public string Cliente { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public DateTime? FechaFinReal { get; set; }
        public int? TipoDecisionFinalId { get; set; }
        public bool? GestionDocumentalCompleta { get; set; }
        public string BecarioConvocatoria { get; set; }
        public int? BecarioConvocatoriaId { get; set; }
        public int? CentroIdUsuario { get; set; }
        public string NivelIdioma { get; set; }

        public string SortColumn { get; set; }
        public Recruiting.Business.BaseClasses.DataTable.DataTableSortDirectionEnum SortOrder { get; set; }

        public IEnumerable<SelectListItem> TipoBecarioList { get; set; }
        public IEnumerable<SelectListItem> EstadoBecarioList { get; set; }
        public IEnumerable<SelectListItem> TipoDecisionFinalPracticas { get; set; }
        public IEnumerable<SelectListItem> TipoTecnologiaList { get; set; }
        public IEnumerable<SelectListItem> OrigenCvList { get; set; }
        public IEnumerable<SelectListItem> CentroList { get; set; }
        public IEnumerable<SelectListItem> ClienteList { get; set; }
        public IEnumerable<SelectListItem> ProyectoList { get; set; }
        public IEnumerable<SelectListItem> FuenteReclutamientoList { get; set; }
        public IEnumerable<SelectListItem> GestionDocumentalList { get; set; }
        public IEnumerable<SelectListItem> NivelIdiomaList { get; set; }
        public string CentroIdUsuarioLogueado { get; set; }
        public int? Pagina { get; set; }
    }
}