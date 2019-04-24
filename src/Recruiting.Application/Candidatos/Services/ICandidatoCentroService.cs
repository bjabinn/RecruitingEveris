using Recruiting.Application.Candidatos.Messages;
using Recruiting.Business.BaseClasses.DataTable;

namespace Recruiting.Application.Candidatos.Services
{
    public interface ICandidatoCentroService
    {


        #region Action requests
        GetCentrosEducativosResponse GetCentros(DataTableRequest request);
        SaveCentroResponse SaveCentro(int idCentro, string centro, string ciudad, string pais);
        RemoveCentroResponse RemoveCentro(int centroId);
        SearchCentroUsadoResponse SearchCentroUsado(int centroId);
        SearchCentroByNombreCiudadPaisResponse SearchCentroByNombreCiudadPais(string nombre, string ciudad, string pais);
        GetCentrosByNombreCentroEducativoResponse GetCentrosByNombreCentro(string textSearch);
        #region Candidato




        #endregion

        #endregion
    }
}