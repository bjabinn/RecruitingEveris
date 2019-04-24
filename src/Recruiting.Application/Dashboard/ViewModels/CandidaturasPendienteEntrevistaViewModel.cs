using System;

namespace Recruiting.Application.Dashboard.ViewModels
{
    [Serializable]
    public class CandidaturasPendienteEntrevistaOCartaOfertaViewModel
    {
        public int CandidaturaId { get; set; }
        public string Candidato { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string Centro { get; set; }
    }
}
