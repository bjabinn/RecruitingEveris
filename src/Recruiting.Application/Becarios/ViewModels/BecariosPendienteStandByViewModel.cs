using System;

namespace Recruiting.Application.Dashboard.ViewModels
{
    [Serializable]
    public class BecariosPendientesStandByViewModel
    {
        public int BecarioId { get; set; }
        public string Candidato { get; set; }
        public DateTime FechaContactoStandBy { get; set; }
        public string CentroProcedencia { get; set; }
        public string FechaMostrar { get; set; }
        public int? DiasDeRetraso { get; set; }
    }
}
