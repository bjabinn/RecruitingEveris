using Recruiting.Application.Base;
using Recruiting.Application.Candidaturas.ViewModel;
namespace Recruiting.Application.Candidaturas.Messages
{
    public class EditCandidaturaResponse : ApplicationResponseBase
    {
        public CandidaturaRowViewModel candidatura { get; set; }
    }
}
