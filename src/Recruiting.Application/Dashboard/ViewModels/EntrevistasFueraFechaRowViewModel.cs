using System;

namespace Recruiting.Application.Dashboard.ViewModels
{
    [Serializable]
    public class EntrevistasFueraFechaRowViewModel
    {
        public int CandidaturaId { get; set; }
        public string Perfil { get; set; }
        public int EntrevistaId { get; set; }
        public string Candidato { get; set; }
        public string Entrevistador { get; set; }
        public int? EntrevistadorId { get; set; }
        public DateTime Agendada { get; set; }
        public string Centro { get; set; }
        public string TipoSubEntrevista { get; set; }
        public int? DiasDeRetraso { get; set; }
        public string Tecnologia { get; set; }
    }
}
