using System;

namespace Recruiting.Application.Dashboard.ViewModels
{
    [Serializable]
    public class AlertasAdministradorViewModel
    {
        public int UsuarioId { get; set; }
        public bool NecesidadesCreadasModificadas { get; set; }
        public bool PrimeraEntrevista { get; set; }       
        public bool SubEntrevistaPrimeraEntrevista { get; set; }
        public bool SegundaEntrevista { get; set; }
        public bool SubEntrevistaSegundaEntrevista { get; set; }
        public bool CartaOferta { get; set; }
        public bool CvPendienteFiltro { get; set; }
        public bool CandidaturaStandBy { get; set; }
        public bool BecarioStandBy { get; set; }
    }
}
