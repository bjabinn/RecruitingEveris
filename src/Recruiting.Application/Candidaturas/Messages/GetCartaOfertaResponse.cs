using Recruiting.Application.Base;
using Recruiting.Application.Candidaturas.ViewModel;

namespace Recruiting.Application.Candidaturas.Messages
{
    public class GetCartaOfertaResponse : ApplicationResponseBase
    {
        public CompletarCartaOfertaViewModel CompletarCartaOfertaViewModel { get; set; }
    }
}
