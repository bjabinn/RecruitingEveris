using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace RecruitingWeb.Models
{
    public class FiltroFunnelModels
    {
        public DateTime? FechaInicio { get; set; }

        public DateTime? FechaFin { get; set; }

        public int? TipoTecnologiaId { get; set; }

        public int? TipoCategoriaId { get; set; }

        public int? CentroIdUsuario { get; set; }

        public string CandidaturaOferta { get; set; }

        public int? CandidaturaOfertaId { get; set; }

        public IEnumerable<SelectListItem> TipoCategoriaList { get; set; }
        public IEnumerable<SelectListItem> TipoTecnologiaList { get; set; }
        public IEnumerable<SelectListItem> CentroList { get; set; }
        public string CentroIdUsuarioLogueado { get; set; }


    }
}