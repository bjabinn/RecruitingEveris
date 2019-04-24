using System;

namespace Recruiting.Application.BitacorasNecesidades.ViewModels
{
    [Serializable]
    public class DatosComparativaBitacoraViewModel
    {  
        public int NecesidadId { get; set; }

        public int? EstadoAnteriorId { get; set; }

        public int? EstadoNuevoId { get; set; }

        public int? PerfilAnteriorId { get; set; }

        public int? PerfilNuevoId { get; set; }

        public DateTime? FechaCompromisoAnterior { get; set; }

        public DateTime? FechaCompromisoNueva { get; set; }

        public DateTime? FechaSolicitudAnterior { get; set; }

        public DateTime? FechaSolicitudNueva { get; set; }

        public DateTime? FechaCierreAnterior { get; set; }

        public DateTime? FechaCierreNueva { get; set; }

        public string PersonaAsignadaAnterior { get; set; }

        public string PersonaAsignadaNueva { get; set; }
    }
}
