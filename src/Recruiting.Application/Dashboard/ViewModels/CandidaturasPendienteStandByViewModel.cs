using System;

namespace Recruiting.Application.Dashboard.ViewModels
{
    [Serializable]
    public class CandidaturasPendienteStandByViewModel
    {
        public int CandidaturaId { get; set; }
        public string Candidato { get; set; }
        public string Perfil { get; set; }
        public string Tecnologia { get; set; }
        public DateTime FechaContactoStandBy { get; set; }
        public string Centro { get; set; }
        public string FechaMostrar { get; set; }
        public int? DiasDeRetraso { get; set; }
    }
}
