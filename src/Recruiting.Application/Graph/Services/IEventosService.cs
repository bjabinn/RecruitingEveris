using Recruiting.Application.Graph.ViewModels;

namespace Recruiting.Application.Graph.Services
{
    public interface IEventosService
    {
        #region QueryRequest

        void EnviarCitas(EventoRowViewModel eventoParaEnviar);

        #endregion
    }
}
