using System;

namespace Recruiting.Application.Becarios.ViewModels
{
    [Serializable]
    public class BecarioObservacionViewModel
    {
        public int? ObservacionId { get; set; }
        public int BecarioId { get; set; }
        public int TipoPruebaId { get; set; }
        public string TipoPrueba { get; set; }
        public int TipoResultadoId { get; set; }
        public string TipoResultado { get; set; }
        public int? PersonaConvocatoriaId { get; set; }
        public string PersonaConvocatoriaNombre { get; set; }
        public DateTime? FechaConvocatoria { get; set; }
        public string Observacion { get; set; }

    }
}
