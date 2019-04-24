using Recruiting.Application.Base;

namespace Recruiting.Application.Candidaturas.Messages
{
    public class TieneSubEntrevistasSinCompletarResponse : ApplicationResponseBase
    {
        public bool TieneSubentrevistas { get; set; }
    }
}
