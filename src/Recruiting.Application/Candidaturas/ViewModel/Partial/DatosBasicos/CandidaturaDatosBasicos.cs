using Recruiting.Application.Candidaturas.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Recruiting.Application.Candidaturas.ViewModel
{
    [Serializable]
    public class CandidaturaDatosBasicos
    {
        public int? CandidaturaId { get; set; }
        public int CandidatoId { get; set; }
        public string DatosCv { get; set; }
        public int? OfertaId { get; set; }
        public string OfertaName { get; set; }
        public int? OrigenCvId { get; set; }
        public string OrigenCvNombre { get; set; }
        public int? FuenteReclutamientoId { get; set; }
        public string FuenteReclutamientoNombre { get; set; }
        public int? CategoriaId { get; set; }
        public string CategoriaNombre { get; set; }
        public bool SubidoCv { get; set; }
        public decimal? SalarioDeseado { get; set; }
        public string Nombre { get; set; }
        public string NombreCandidato { get; set; }
        public int EstadoCandidaturaId { get; set; }
        public string EstadoCandidatura { get; set; }
        public int EtapaCandidaturaId { get; set; }
        public string EtapaCandidatura { get; set; }
        public string NombreCV { get; set; }
        public byte[] CV { get; set; }
        public string UrlCV { get; set; }
        public int? TipoTecnologiaId { get; set; }
        public string TipoTecnologiaNombre { get; set; }
        public int? Modulo { get; set; }
        public string ModuloNombre { get; set; }
        public int? FiltradorId { get; set; }
        public string FiltradorNombre { get; set; }
        public string Moneda { get; set; }
        public int? NumeroDeEntrevistas { get; set; }
        public bool Activo { get; set; }
        public List<string> ListEmailReferenciados { get; set; }
        public int? CandidaturaOfertaId { get; set; }
        public string NombreOferta { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string UbicacionCandidato { get; set; }
        public DateTime? AnioExperiencia { get; set; }

        public List<CreateEditRowIdiomaCandidaturaViewModel> IdiomaCandidatoViewModel { get; set; }
        public List<CreateEditRowExperienciaCandidatoViewModel> ExpCandidatoViewModel { get; set; }
 
        public IEnumerable<SelectListItem> CategoriaList { get; set; }
        public IEnumerable<SelectListItem> TecnologiaList { get; set; }
        public IEnumerable<SelectListItem> OrigenCvList { get; set; }
        public IEnumerable<SelectListItem> FuenteReclutamientoList { get; set; }
        public IEnumerable<SelectListItem> ModuloList { get; set; }
        public IEnumerable<SelectListItem> TipoIdentificacionList { get; set; }
        public IEnumerable<SelectListItem> TipoTecnologiaList { get; set; }
        public IEnumerable<SelectListItem> NivelExpList { get; set; }
        public IEnumerable<SelectListItem> IdiomaList { get; set; }
        public IEnumerable<SelectListItem> NivelIdiomaList { get; set; }
        public IEnumerable<SelectListItem> ExperienciaList { get; set; }
        public string Access { get; set; }
    }
}
