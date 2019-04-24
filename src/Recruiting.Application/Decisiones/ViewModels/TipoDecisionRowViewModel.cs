using System;

namespace Recruiting.Application.Decisiones.ViewModels
{
    [Serializable]
    public class TipoDecisionRowViewModel
    {
        public int TipoDecisionId { get; set; }

        public string Decision { get; set; }

        public int TipoEtapaCandidaturaId { get; set; }
    }
}
