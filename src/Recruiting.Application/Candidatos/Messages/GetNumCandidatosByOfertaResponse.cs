using Recruiting.Application.Base;

namespace Recruiting.Application.Candidatos.Messages
{
    public class GetNumCandidatosByOfertaResponse : ApplicationResponseBase
    {
        public int NumCandidatos { get; set; }
    }
}
