using Recruiting.Application.Candidaturas.Messages;

namespace Recruiting.Application.Candidaturas.Services
{
    public interface ICandidaturaEtapaService
    {
        #region QueryRequest

        GetEtapasCandidaturaResponse GetEtapasCandidatura();

        GetOrdenByEtapaCandidaturaResponse GetOrdenByEtapaCandidatura(int etapaId);
       
        #endregion
    }
}
