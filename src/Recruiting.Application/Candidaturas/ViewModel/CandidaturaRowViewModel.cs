using System;

namespace Recruiting.Application.Candidaturas.ViewModel
{
    [Serializable]
	public class CandidaturaRowViewModel
	{
		public int CandidaturaId { get; set; }
        public int OfertaId { get; set; }
        public string Oferta { get; set; }
        public int? OrigenCvId { get; set; }
        public string OrigenCv { get; set; }
        public int? FuenteReclutamientoId { get; set; }
        public string FuenteReclutamiento { get; set; }
        public int CandidatoId { get; set; }
		public string Estado { get; set; }
		public string Etapa { get; set; }
		public string Candidato { get; set; }
		public string Entrevistador { get; set; }
        public string Filtrador { get; set; }
        public int? EntrevistadorId { get; set; }
        public int? FiltradorId { get; set; }
        public DateTime Agendada { get; set; }
		public string Perfil { get; set; }
		public int EstadoId { get; set; }
		public int EtapaId { get; set; }
		public int? TipoTecnologiaId { get; set; }
		public string TipoTecnologia { get; set; }
        public bool CVAvailable { get; set; }
        public string Centro { get; set; }
        public bool GeneradoCartaOferta { get; set; }
        public bool PuedeRetroceder { get; set; }
        public string Modulo { get; set; }
        public string SubEntrevistadoresString { get; set; }
        public int NumeroDeEntrevistas { get; set; }
        public string EmailsSeguimiento { get; set; }
        public string PersonaCreacion { get; set; }
        public string NivelIdioma { get; set; }
        public string UbicacionCandidato { get; set; }
    }
}
