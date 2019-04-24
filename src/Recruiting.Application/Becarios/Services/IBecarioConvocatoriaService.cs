using Recruiting.Application.Becarios.Messages;
using Recruiting.Business.BaseClasses.DataTable;

namespace Recruiting.Application.Becarios.Services
{
    public interface IBecarioConvocatoriaService
    {
        SaveConvocatoriaResponse SaveConvocatoria(int idConvocatoria, string nombreConvocatoria, int centroId);
        GetConvocatoriasResponse GetConvocatorias(DataTableRequest request);
        
        RemoveConvocatoriaResponse RemoveConvocatoria(int convocatoriaId);
        SearchConvocatoriaByNombreCentroIdResponse SearchConvocatoriaByNombreCentroId(string nombreConvocatoria, int centroId);
        SearchConvocatoriaUsadaResponse SearchConvocatoriaUsada(int convocatoriaId);
        GetConvocatoriasByNombreResponse GetConvocatoriasByNombre(string textSearch, int? centroId);
    }
}
