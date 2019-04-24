using Recruiting.Application.Base;
using Recruiting.Application.Candidaturas.ViewModel;

namespace Recruiting.Application.Candidaturas.Messages
{
    public class GetCandidaturaToGeneratePDFbyIdResponse : ApplicationResponseBase
    {
        public CartaOfertaPdfViewModel CartaOfertaPdfViewModel { get; set; }
    }
}
