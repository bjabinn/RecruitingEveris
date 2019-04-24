using Recruiting.Application.Candidaturas.Enums;
using Recruiting.SendMailsService.Correos.Messages;
using Recruiting.SendMailsService.Correos.ViewModels;
using Recruiting.Business.BaseClasses.DataTable;

namespace Recruiting.SendMailsService.Correos.Services
{
    public interface ICorreoPlantillaVariableService
    {
        #region QueryRequest
        GetValorDefectoNombreVariablePlantillaCorreoResponse GetValorDefectoNombreVariablePlantillaCorreo(int PlantillaId, string nombreVariablePlantillaCorreo);
        
        #endregion



        #region ActionRequest

        #endregion
    }
}
