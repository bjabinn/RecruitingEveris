using Recruiting.Application.Base;
using Recruiting.Application.Candidaturas.ViewModel;

namespace Recruiting.Application.Candidaturas.Messages
{
    public class GetCandidaturaByIdResponse : ApplicationResponseBase 
    {
        public CandidaturaViewModel CandidaturaViewModel { get; set; }
    }
}
