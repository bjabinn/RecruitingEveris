using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Recruiting.Application.Candidatos.ViewModels
{
    [Serializable]
    public class CreateEditCandidatoViewModel
    {

        public int? CandidatoId { get; set; }

        public string Nombres { get; set; }

        public string Apellidos { get; set; }

        public DateTime? FechaNacimiento { get; set; }

        public int? TipoIdentificacionId { get; set; }

        public string TipoIdentificacion { get; set; }

        public string NumeroIdentificacion { get; set; }

        public int TitulacionId { get; set; }

        public string Titulacion { get; set; }

        public string DetalleTitulacion { get; set; }

        public bool CambioResidencia { get; set; }

        public bool DisponibilidadViaje { get; set; }

        public int EstadoCandidatoId { get; set; }

        public string Direccion { get; set; }

        public string AnioRegresado { get; set; }

        public string NombreCentroEducativo { get; set; }

        public int? CandidatoCentroEducativoId { get; set; }

        public string Access { get; set; }

        public List<CreateEditRowContactoCandidatoViewModel> ContactCandidatoViewModel { get; set; }

        public List<CreateEditRowExperienciaCandidatoViewModel> ExpCandidatoViewModel { get; set; }

        public List<CreateEditRowIdiomaCandidatoViewModel> IdiomaCandidatoViewModel { get; set; }

        public bool Activo { get; set; }

        public IEnumerable<SelectListItem> TipoIdentificacionList { get; set; }
        public IEnumerable<SelectListItem> TipoContactoList { get; set; }
        public IEnumerable<SelectListItem> TipoTecnologiaList { get; set; }
        public IEnumerable<SelectListItem> NivelExpList { get; set; }
        public IEnumerable<SelectListItem> ExperienciaList { get; set; }
        public IEnumerable<SelectListItem> IdiomaList { get; set; }
        public IEnumerable<SelectListItem> NivelIdiomaList { get; set; }
        public IEnumerable<SelectListItem> TitulacionList { get; set; }
    }
}
