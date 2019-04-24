using Recruiting.Application.Candidatos.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace RecruitingWeb.Models
{
    public class FiltroCandidatoModels
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int? TipoTitulacionId { get; set; }
        public int? TipoIdentificacionId { get; set; }
        public string NumeroIdentificacion { get; set; }
        public int? CentroIdUsuario { get; set; }
        public string Buscar { get; set; }
        public int? TipoTecnologiaId { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public int? CentroEducativoId { get; set; }
        public string CentroEducativoName { get; set; }
        public string AnioRegresado { get; set; }
        public string NivelIdioma { get; set; }
        public List<CreateEditRowIdiomaCandidatoViewModel> IdiomaCandidatoViewModel { get; set; }

        //Dropdowns

        public IEnumerable<SelectListItem> TipoIdentificacionList { get; set; }
        public IEnumerable<SelectListItem> TipoTecnologiaList { get; set; }
        public IEnumerable<SelectListItem> TitulacionList { get; set; }
        public IEnumerable<SelectListItem> CentroList { get; set; }
        public IEnumerable<SelectListItem> Centro { get; set; }
        public IEnumerable<SelectListItem> IdiomaList { get; set; }
        public IEnumerable<SelectListItem> NivelIdiomaList { get; set; }
        public int? Pagina { get; set; }



    }
}