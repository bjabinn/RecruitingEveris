using Recruiting.Application.Becarios.Messages;
using Recruiting.Business.BaseClasses.DataTable;

namespace Recruiting.Application.Becarios.Services
{
    public interface IBecarioCentroService
    {
        GetCentrosByNombreCentroResponse GetCentrosByNombreCentro(string textSearch);
        GetCentrosResponse GetCentros(DataTableRequest request);
        SaveCentroResponse SaveCentro(int idCentro, string centro, string ciudad, string pais);
        SearchCentroByNombreCiudadPaisResponse SearchCentroByNombreCiudadPais(string nombre, string ciudad, string pais);        
        RemoveCentroResponse RemoveCentro(int centroId);
        SearchCentroUsadoResponse SearchCentroUsado(int centroId); 
    }
}
