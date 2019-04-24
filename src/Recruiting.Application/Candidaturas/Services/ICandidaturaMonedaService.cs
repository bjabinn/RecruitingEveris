using Recruiting.Application.Candidaturas.Messages;

namespace Recruiting.Application.Candidaturas.Services
{
    public interface ICandidaturaMonedaService
    {
        GetMonedaByCentroIdResponse GetMonedaByCentroId(int centroId);
    }
}
