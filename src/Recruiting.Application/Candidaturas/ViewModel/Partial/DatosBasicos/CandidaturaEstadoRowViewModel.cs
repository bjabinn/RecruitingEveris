using System;

namespace Recruiting.Application.Candidaturas.ViewModel
{
    [Serializable]
    public class CandidaturaEstadoRowViewModel
    {
        public int EstadoCandidaturaId { get; set; }
        public string EstadoCandidatura { get; set; }

        public int? Orden { get; set; }
    }
}
