using System;

namespace Recruiting.Application.PersonasLibres.ViewModels
{
    [Serializable]
    public class PersonaLibreRowExportToExcelViewModel
    {

        public int NroEmpleado { get; set; }

        public string Nombre { get; set; }

        public string Apellidos { get; set; }

        public string Categoria { get; set; }

        public string Linea { get; set; }

        public string Celda { get; set; }

        public string FechaLiberacion { get; set; }

        public int? NecesidadId { get; set; }
        public int? TipoTecnologiaId { get; set; }
        public string Comentario { get; set; }

        public string Centro { get; set; }
        public string NivelIngles { get; set; }
    }
}
