using Recruiting.Application.Necesidades.Messages;
using Recruiting.Application.Necesidades.ViewModels;
using Recruiting.Business.BaseClasses.DataTable;

namespace Recruiting.Application.Necesidades.Services
{
    public interface IGrupoNecesidadService
    {
        #region Query requests
       
        SaveGrupoNecesidadResponse SaveGrupoNecesidad(CreateEditSoloGrupoNecesidadViewModel viewModel, int? centro);
        GetGrupoNecesidadByIdResponse GetGrupoNecesidadById(int grupoId);
        GetGruposNecesidadesResponse GetGruposNecesidades(DataTableRequest request);
        DeleteGrupoNecesidadResponse DeleteGrupoNecesidad(int grupoId);
        GetNecesidadesGrupoExportToExcellResponse GetNecesidadesGrupoExportToExcel(DataTableRequest request);
        SearchGrupoNecesidadByNombreResponse SearchGrupoNecesidadByNombre (string nombreGrupo);

        #endregion

        #region Action requests

        CheckGrupoCerradoResponse CheckGrupoCerrado(int grupoId);

        #endregion
    }
}
