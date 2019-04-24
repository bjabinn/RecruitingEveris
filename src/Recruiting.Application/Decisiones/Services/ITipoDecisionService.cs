using Recruiting.Application.Decisiones.Messages;

namespace Recruiting.Application.Decisiones.Services
{
    public interface ITipoDecisionService
    {
        #region QueryRequest

        GetTipoDecisionListByEtapaIdResponse GetDecisionesByEtapaId(int etapaId);

        #endregion
    }
}
