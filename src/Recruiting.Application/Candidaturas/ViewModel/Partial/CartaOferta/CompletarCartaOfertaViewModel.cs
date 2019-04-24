using System;

namespace Recruiting.Application.Candidaturas.ViewModel
{
    [Serializable]
    public class CompletarCartaOfertaViewModel
    {
        public EntregaCartaOfertaViewModel EntregaCartaOfertaViewModel { get; set; }
        public CompletarCartaOferta CompletarCartaOferta { get; set; }
        public int? necesidadAAbrir { get; set; }

        public int? AccessEtapa { get; set; }
        public string NombreCandidato { get; set; }
    }
}
