using System;

namespace Recruiting.Application.Becarios.ViewModels
{
    [Serializable]
    public class BecarioRowViewModel
    {
        public int BecarioId { get; set; }
        public string BecarioNombre { get; set; }
        public int CandidatoId { get; set; }
        public int TipoBecarioId { get; set; }
        public string TipoBecario { get; set; }
        public int EstadoBecarioId { get; set; }
        public string EstadoBecario { get; set; }
        public int? TipoDecisionFinalId { get; set; }
        public string TipoDecisionFinal { get; set; }
        public string CentroProcedencia { get; set; }
        public string Convocatoria { get; set; }
        public string Proyecto { get; set; }
        public string Cliente { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public string FechaFinReal { get; set; }
        public bool? ExisteCandidatura { get; set; }
        public string NivelIdioma { get; set; }
    }
}
