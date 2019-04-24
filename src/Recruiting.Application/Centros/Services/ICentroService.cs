using Recruiting.Application.Centros.Messages;

namespace Recruiting.Application.Centros.Services
{
    public interface ICentroService
    {
        #region QueryRequest

        GetCentrosResponse GetCentros();
        GetTokenIdByCentroIdResponse GetTokenIdByCentroId(int centroId);
       
        #endregion
    }
}
