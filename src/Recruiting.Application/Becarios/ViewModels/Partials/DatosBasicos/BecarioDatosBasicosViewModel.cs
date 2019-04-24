using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Recruiting.Application.Becarios.ViewModels
{
    [Serializable]
    public class BecarioDatosBasicosViewModel
    {
        public int? BecarioId { get; set; }
        public int CandidatoId { get; set; }
        public int TipoBecarioId { get; set; }
        public string TipoBecario { get; set; }        
        public int EstadoBecarioId { get; set; }
        public string NombreCandidato { get; set; }
        public string NombreCentroProcedencia { get; set; }
        public int? CentroProcedenciaId { get; set; }
        public bool SubidoCv { get; set; }
        public string NombreCV { get; set; }
        public byte[] CV { get; set; }
        public string UrlCV { get; set; }
        public string NombreConvocatoria { get; set; }
        public int? ConvocatoriaId { get; set; }
        public int? OrigenCvId { get; set; }
        public string OrigenCvNombre { get; set; }
        public int? FuenteReclutamientoId { get; set; }
        public string FuenteReclutamientoNombre { get; set; }


        public IEnumerable<SelectListItem> TipoBecarioList { get; set; }
        public IEnumerable<SelectListItem> TipoIdentificacionList { get; set; }
        public IEnumerable<SelectListItem> OrigenCvList { get; set; }
        public IEnumerable<SelectListItem> FuenteReclutamientoList { get; set; }
        public List<string> ListEmailReferenciados { get; set; }
        public string Access { get; set; }
    }
}
