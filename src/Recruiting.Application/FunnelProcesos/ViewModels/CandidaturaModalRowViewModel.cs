﻿using System;

namespace Recruiting.Application.FunnelProcesos.ViewModels
{
    [Serializable]
	public class CandidaturaModalRowViewModel
    {
		public int CandidaturaId { get; set; }        
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
		public int? EntrevistadorId { get; set; }
        public int? FiltradorId { get; set; }
        public DateTime Agendada { get; set; }
		public string Perfil { get; set; }
		public int EstadoId { get; set; }
		public int EtapaId { get; set; }
		public int? TipoTecnologiaId { get; set; }
		public string TipoTecnologia { get; set; }        
        public string Centro { get; set; }       
        public string Modulo { get; set; }
        public string SubEntrevistadoresString { get; set; }
    }
}
