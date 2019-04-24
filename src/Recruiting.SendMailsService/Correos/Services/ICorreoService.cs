using Recruiting.SendMailsService.Correos.Messages;
using Recruiting.SendMailsService.Correos.ViewModels;

namespace Recruiting.SendMailsService.Correos.Services
{
    public interface ICorreoService
    {
        #region QueryRequest
        GetCorreosPendientesEnvioResponse GetCorreosPendientesEnvio();
        GetCorreoByCandidaturaPlantillaResponse GetCorreoByCandidaturaPlantilla(int CandidaturaId, int PlantillaId, int? subEntrevistaId, string tipoAviso);
        #endregion



        #region ActionRequest
        SaveCorreoResponse SaveCorreo(CorreoRowViewModel correoViewModel, int usuarioAplicacion);

        #endregion
    }
}
