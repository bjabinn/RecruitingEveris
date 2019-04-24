using Recruiting.SendMailsService.Correos.Messages;
using Recruiting.SendMailsService.Correos.ViewModels;

namespace Recruiting.SendMailsService.Correos.Services
{
    public interface ICorreoBecarioService
    {
        #region QueryRequest
        GetCorreosBecarioPendientesEnvioResponse GetCorreosPendientesEnvio();
        GetCorreoByBecarioPlantillaResponse GetCorreoByBecarioPlantilla(int BecarioId, int PlantillaId);
        #endregion



        #region ActionRequest
        SaveCorreoResponse SaveCorreo(CorreoBecarioRowViewModel correoBecarioViewModel, int usuarioAplicacion);

        #endregion
    }
}
