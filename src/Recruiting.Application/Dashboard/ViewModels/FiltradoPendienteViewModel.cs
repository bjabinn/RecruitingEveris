using System;

namespace Recruiting.Application.Dashboard.ViewModels
{
    [Serializable]
    public class FiltradoPendienteViewModel
    {
        public int CandidaturaId { get; set; }
        public string Candidato { get; set; }
        public string Entrevistador { get; set; }
        public string Perfil { get; set; }
        public string Tecnologia { get; set; }
        public int? EntrevistadorId { get; set; }
        public DateTime Creada { get; set; }
        public string Centro { get; set; }
        public bool CvAvailable { get; set; }
    }
}
