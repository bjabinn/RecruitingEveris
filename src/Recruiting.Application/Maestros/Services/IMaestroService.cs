using Recruiting.Application.Maestros.Messages;

namespace Recruiting.Application.Maestros.Services
{
    public interface IMaestroService
    {
        #region QueryRequest

        GetMaestroListByTipoIdResponse GetDatosMaestroByTipoId(params int[] tipoMaestroId);
        GetTipoMedioContactoEmailResponse GetTipoMedioContactoEmail(int tipoMaestroId, string nombreMaestroEmail);
        #endregion
    }
}
