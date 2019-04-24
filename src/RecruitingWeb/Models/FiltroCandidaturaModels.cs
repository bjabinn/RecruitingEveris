using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace RecruitingWeb.Models
{
    public class FiltroCandidaturaModels
    {
        public int[] EstadoCandidaturaId { get; set; }
        public int[] EtapaCandidaturaId { get; set; }
        public int? PerfilId { get; set; }
        public int? EntrevistadorId { get; set; }
        public string EntrevistadorName { get; set; }
        public string Oferta { get; set; }
        public int? OfertaId { get; set; }
        public int? OrigenCvId { get; set; }
        public int? FuenteReclutamiento { get; set; }
        public string NombreCandidato { get; set; }
        public string ApellidosCandidato { get; set; }
        public int? Referencia{ get; set; }
        public int? TipoTecnologiaId { get; set; }
        public DateTime? AgendadaEntre { get; set; }
        public DateTime? AgendadaHasta { get; set; }

        public int? EntrevistasDesde { get; set; }
        public int? EntrevistasHasta { get; set; }

        public int? CentroIdUsuario { get; set; }

        public string Idioma { get; set; }
        public string NivelIdioma { get; set; }

        public string Buscar { get; set; }
        public int? ModuloId { get; set; }

        public string CandidaturaOferta { get; set; }
        public int? CandidaturaOfertaId { get; set; }
        public string UbicacionCandidato { get; set; }
        public DateTime? AnioExperiencia { get; set; }

        public string SortColumn { get; set; }
        public Recruiting.Business.BaseClasses.DataTable.DataTableSortDirectionEnum SortOrder { get; set; }

        public IEnumerable<SelectListItem> EstadoList { get; set; }
        public IEnumerable<SelectListItem> EtapaList { get; set; }
        public IEnumerable<SelectListItem> CategoriaList { get; set; }
        public IEnumerable<SelectListItem> TecnologiaList { get; set; }
        public IEnumerable<SelectListItem> OrigenCvList { get; set; }
        public IEnumerable<SelectListItem> IdiomaList { get; set; }
        public IEnumerable<SelectListItem> NivelIdiomaList { get; set; }
        public IEnumerable<SelectListItem> ModuloList { get; set; }
        public string CentroIdUsuarioLogueado { get; set; }
        public IEnumerable<SelectListItem> CentroList { get; set; }
        public IEnumerable<SelectListItem> MotivoRenunciaList { get; set; }
        public IEnumerable<SelectListItem> MotivoDescarteList { get; set; }
        public int? Pagina { get; set; }

        public string Keyword { get; set; }
    }
}