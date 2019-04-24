using Recruiting.Application.Base;
using Recruiting.Application.Candidaturas.ViewModel;

namespace Recruiting.Application.Candidaturas.Messages
{
    public class CheckEnProcesoResponse : ApplicationResponseBase 
    {
        public bool EnProceso { get; set; }
        public bool Contratado { get; set; }
    }
}
