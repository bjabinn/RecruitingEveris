using System;

namespace Recruiting.Application.BitacorasBecarios.ViewModels
{
    [Serializable]
    public class DatosComparativaBitacoraBecarioViewModel
    {  
        public int BecarioId { get; set; }

        public int? EstadoAnteriorId { get; set; }

        public int? EstadoNuevoId { get; set; }
    }
}
