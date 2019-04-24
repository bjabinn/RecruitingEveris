using System;

namespace Recruiting.Application.Candidaturas.ViewModel
{
    [Serializable]
    public class CandidaturaEtapaRowViewModel
    {
        public int EtapaCandidaturaId { get; set; }
        public string EtapaCandidatura { get; set; }
        public int? Orden { get; set; }
    }
}
