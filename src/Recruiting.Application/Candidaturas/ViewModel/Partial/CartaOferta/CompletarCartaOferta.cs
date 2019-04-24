using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Recruiting.Application.Candidaturas.ViewModel
{
    [Serializable]
    public class CompletarCartaOferta
    {
        public int? SuperaCartaOferta { get; set; }
        public int? MotivoRechazoId { get; set; }
        public string MotivoRechazoNombre { get; set; }
        public int? NecesidadId { get; set; }
        public DateTime? FechaIncorporacion { get; set; }
        public string NecesidadNombre { get; set; }
        public bool? AsignadaCorrectamente { get; set; }

        public string AccessCompletar { get; set; }
        public IEnumerable<SelectListItem> MotivoRechazoCartaOfertaList { get; set; }
        public IEnumerable<SelectListItem> OficinaList { get; set; }
        public IEnumerable<SelectListItem> SectorList { get; set; }
        public IEnumerable<SelectListItem> ClienteList { get; set; }
        public IEnumerable<SelectListItem> ProyectoList { get; set; }
        public IEnumerable<SelectListItem> TecnologiaList { get; set; }
        public IEnumerable<SelectListItem> ServicioList { get; set; }
        public IEnumerable<SelectListItem> CategoriaList { get; set; }
        public IEnumerable<SelectListItem> DuracionList { get; set; }
        public IEnumerable<SelectListItem> ContratacionList { get; set; }
        public IEnumerable<SelectListItem> PrevisionList { get; set; }
        public IEnumerable<SelectListItem> ModuloList { get; set; }
    }
}
