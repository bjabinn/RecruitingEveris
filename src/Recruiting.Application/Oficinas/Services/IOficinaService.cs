using Recruiting.Application.Oficinas.Messages;

namespace Recruiting.Application.Oficinas.Services
{
    public interface IOficinaService
    {
        #region QueryRequest

        GetOficinasResponse GetOficinas();
        GetOficinasResponse GetOficinasByCentro(int centroId);

        #endregion
    }
}
