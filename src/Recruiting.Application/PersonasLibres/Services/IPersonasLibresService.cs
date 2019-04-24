using Recruiting.Application.PersonasLibres.Messages;
using Recruiting.Application.PersonasLibres.ViewModels;
using Recruiting.Business.BaseClasses.DataTable;

namespace Recruiting.Application.PersonasLibres.Services
{
    public interface IPersonasLibresService
    {
        #region Query requests
        GetPersonasLibresResponse GetPersonasLibres(DataTableRequest request);
        GetPersonasLibresExportToExcelResponse GetPersonasLibresExportToExcel(DataTableRequest request);
        GetPersonaLibreByIdResponse GetPersonaLibreById(int PersonaLibreId);
        SearchPersonaLibreByNumeroEmpleadoResponse SearchPersonaLibreByNumeroEmpleado(string numeroEmpleado);
        GetPersonasLibresResponse GetPersonasLibresByCentroUsuarioId(int CentroUsuarioId);
        SearchPersonaLibreByNombreYApellidosResponse SearchPersonaLibreByNombreYApellidos(string nombre, string apellidos);

        #endregion

        #region Action requests

        UpdatePersonaLibreResponse UpdatePersonaLibre(CreateEditPersonaLibreViewModel createEditPersonaLibreViewModel);

        #region PersonaLibre

        SavePersonaLibreResponse SavePersonasLibres (PersonasLibresToCreateViewModel personasAGuardar);
        DeletePersonaLibreResponse DeletePersonaLibre(int PersonaLibreId);
        UpdatePersonaLibreByNecesidadIdAndPersonaLibreIdResponse UpdatePersonaLibreByNecesidadIdAndPersonaLibreId(int necesidadId, int personaLibreId);
        GetListCategoriaLineaCeldaResponse GetListCategoriaLineaCelda();

        LiberatePersonaLibreResponse LiberatePersonaLibre(int personaLibreId, int personaLibreNroEmpleado, int necesidadId);
        #endregion

        #endregion
    }
}