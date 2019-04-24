using System;

namespace Recruiting.Application.Becarios.ViewModels
{
	[Serializable]
	public class BecarioRowExportToExcelViewModel
    {
        
		public int BecarioId { get; set; }
        public string NombreBecario { get; set; }       
        public int CandidatoId { get; set;}       
        public string TipoBecario { get; set; }
		public string TipoBecarioEstado { get; set; }
        public string TipoDecisionFinal { get; set; }
        public string CentroProcedencia { get; set; }
        public string Convocatoria { get; set; }        
        public string Proyecto { get; set; }
        public string Cliente { get; set; }
        public string NivelIngles { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public DateTime? FechaFinReal { get; set; }
    }
}
