using System;

namespace Recruiting.Application.Candidaturas.ViewModel

{
    [Serializable]
    public class EntregaCartaOfertaViewModel
    {
        public AgendarCartaOfertaViewModel AgendarCartaOfertaViewModel {get;set;}
        public EntregaCartaOferta EntregaCartaOferta { get; set; }
    }
}
