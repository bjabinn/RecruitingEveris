using Recruiting.Application.Ofertas.Messages;
using Recruiting.Application.Ofertas.ViewModels;
using Recruiting.Business.BaseClasses.DataTable;

namespace Recruiting.Application.Ofertas.Services
{
    public interface IOfertaService
    {
        #region QueryRequest
        GetOfertasResponse GetOfertas();
        GetOfertasResponse GetOfertas(DataTableRequest request);
        GetOfertasExportToExcelResponse GetOfertasExportToExcel(DataTableRequest request);
        GetOfertaByIdResponse GetOfertaById(int ofertaId);
        GetOfertasResponse GetOfertasByCentroUsuarioId(int CentroUsuarioId);
        #endregion
        GetOfertasByNameAndCentroResponse GetOfertasByNameAndCentro(string textSearch, int? centroId);
        GetOfertasNombreIdResponse GetOfertasNombreId(int? centroId = null);
        #region ActionRequest
        SaveOfertaResponse SaveOferta(CreateEditOfertaViewModel ofertaViewModel);
        DeleteOfertaResponse DeleteOferta(int ofertaId);
        #endregion
    }
}
