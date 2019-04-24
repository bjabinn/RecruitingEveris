using System;

namespace Recruiting.Application.PersonasLibres.ViewModels
{
    [Serializable]
    public class EmpleadoFenixRowViewModel
    {
        public int NroEmpleado { get; set; }

        public string Nombre { get; set; }

        public string Apellidos { get; set; }

        public string Categoria { get; set; }

        public string Linea { get; set; }

        public string Celda { get; set; }

        public int? TipoTecnologiaId { get; set; }

        public bool IsActivo { get; set; }

        public string Centro { get; set; }

    }
}
