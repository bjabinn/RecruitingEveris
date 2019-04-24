using Recruiting.Application.Base;
using Recruiting.Application.Candidaturas.ViewModel;

namespace Recruiting.Application.Candidaturas.Messages
{
    public class GetCentroCandidaturaResponse : ApplicationResponseBase 
    {
        public string NombreCentro { get; set; }
        public int CentroId { get; set; }
    }
}
