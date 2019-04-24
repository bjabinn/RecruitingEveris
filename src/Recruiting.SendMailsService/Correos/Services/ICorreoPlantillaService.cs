using Recruiting.SendMailsService.Correos.Messages;

namespace Recruiting.SendMailsService.Correos.Services
{
    public interface ICorreoPlantillaService
    {
        #region QueryRequest
        GetPlantillaIdByNombrePlantillaResponse GetPlantillaIdByNombrePlantilla(string NombrePlantillaCorreo, int CentroId, int? OficinaId = null);
        GetPlantillaCorreoByIdResponse GetPlantillaCorreoById(int PlantillaId);

        GetPlantillaCorreoByPlantillaIdResponse GetPlantillaCorreoByPlantillaId(int plantillaId);
        GetPlantillaCorreoByNombreCentroIdResponse GetPlantillaCorreoByNombreCentroId(string NombrePlantillaCorreo, int? CentroId);
        #endregion



        #region ActionRequest

        #endregion
    }
}
