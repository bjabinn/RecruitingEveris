using System;

namespace Recruiting.Application.Necesidades.ViewModel.Partial.DatosBasicos
{
    [Serializable]
    public class NecesidadDatosBasicos
    {
        public int?  NecesidadId{ get; set; }
        public string Proyecto { get; set; }
        public string Tecnologia{ get; set; }
        public string Estado { get; set; }
        public string Perfil { get; set; }
        public string Prevision { get; set; }
        public DateTime? SolicitadoEntre { get; set; }
        public DateTime? SolicitadoHasta { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public bool? AsignadaCorrectamente { get; set; }
    }
}
