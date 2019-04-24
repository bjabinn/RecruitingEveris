using System;

namespace Recruiting.Application.Dashboard.ViewModels
{
    [Serializable]
    public class BecariosPendienteEntrevistaViewModel
    {
        public int BecarioId { get; set; }
        public string Candidato { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string CentroProcedencia { get; set; }
    }
}
