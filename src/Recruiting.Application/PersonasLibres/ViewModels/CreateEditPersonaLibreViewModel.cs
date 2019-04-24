using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Recruiting.Application.PersonasLibres.ViewModels
{
    [Serializable]
    public class CreateEditPersonaLibreViewModel
    {

        public int? PersonaLibreId { get; set; }

        public string NroEmpleado { get; set; }

        public string Nombre { get; set; }

        public string Apellidos { get; set; }

        public string Categoria { get; set; }

        public string Linea { get; set; }

        public string Celda { get; set; }

        public DateTime FechaLiberacion { get; set; }

        public int? NecesidadId { get; set; }

        public string Comentario { get; set; }

        public int? TipoTecnologiaId { get; set; }

        public string TipoTecnologiaNombre { get; set; }

        public bool IsActivo { get; set; }

        public bool SinNecesidadAsignada { get; set; }

        public string Centro { get; set; }

        public bool Activo { get; set; }

        public int? IdiomaId { get; set; }

        public int? NivelIdiomaId { get; set; }

        public string NivelIdioma { get; set; }

        public IEnumerable<SelectListItem> TecnologiaList { get; set; }

        public IEnumerable<SelectListItem> NivelIdiomaList { get; set; }

    }
}
