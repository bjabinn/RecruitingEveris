using Recruiting.Application.Base;

namespace Recruiting.Application.Candidaturas.Messages
{
    public class GetDatosByCandidatoIdResponse : ApplicationResponseBase
    {
        public int NumCandidaturas { get; set; }
        public string NivelIngles { get; set; }
    }
}
