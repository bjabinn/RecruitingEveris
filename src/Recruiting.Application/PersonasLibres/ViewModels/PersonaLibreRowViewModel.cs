using System;

namespace Recruiting.Application.PersonasLibres.ViewModels
{
    [Serializable]
    public class PersonaLibreRowViewModel
    {

        public int? PersonaLibreId { get; set; }

        public int NroEmpleado { get; set; }

        public string Nombre { get; set; }

        public string Apellidos { get; set; }

        public string Categoria { get; set; }

        public string Linea { get; set; }

        public string Celda { get; set; }

        public DateTime FechaLiberacion { get; set; }

        public int? NecesidadId { get; set; }

        public string Comentario { get; set; }

        public int? TipoTecnologiaId { get; set; }

        public int? NivelIdiomaId { get; set; }

        public bool IsActivo { get; set; }

        public bool SinNecesidadAsignada { get; set; }

        public bool isChecked { get; set; }

        public string Centro { get; set; }

        public string NivelIdioma { get; set; }
    }
}
