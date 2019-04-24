using System;

namespace Recruiting.Application.Candidaturas.ViewModel
{
    [Serializable]
	public class CandidaturaRowExportToExcelViewModel
    {
        
		public int CandidaturaId { get; set; }
        public string Oferta { get; set; }       
        public string FechaCreacion { get; set;}
        public string Estado { get; set; }
		public string Etapa { get; set; }
        public string Motivo { get; set; }
        public string Candidato { get; set; }
		public string Entrevistador { get; set; }
        public string Agendada { get; set; }
        public string Perfil { get; set; }
		public string TipoTecnologia { get; set; }
        public string OrigenCv { get; set; }
        public string Modulo { get; set; }
        public string Centro { get; set; }
        public string NivelIngles { get; set; }
        public int? NumeroDeEntrevistas { get; set; }
    }
}
