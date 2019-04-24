using Recruiting.Application.CandidaturasOfertas.Messages;
using Recruiting.Business.BaseClasses.DataTable;

namespace Recruiting.Application.CandidaturasOfertas.Services
{
    public interface ICandidaturaOfertaService
    {
        SaveOfertaResponse SaveOferta(int idOferta, string nombreOferta, int centroId);
        GetOfertasResponse GetOfertas(DataTableRequest request);
        
        RemoveOfertaResponse RemoveOferta(int ofertaId);
        SearchOfertaByNombreCentroIdResponse SearchOfertaByNombreCentroId(string nombreOferta, int centroId);
        SearchOfertaUsadaResponse SearchOfertaUsada(int ofertaId);
        GetOfertasByNombreResponse GetOfertasByNombre(string textSearch, int? centroId);
    }
}
