using Recruiting.Application.PersonasLibres.Messages;
using Recruiting.Business.BaseClasses.DataTable;

namespace Recruiting.Application.PersonasLibres.Services
{
    public interface IEmpleadoFenixService
    {
        #region Query requests
        GetEmpleadosFenixResponse GetEmpleadosFenix(DataTableRequest request, int centroId);
        GetListEmpleadosFenixCategoriaLineaCeldaResponse GetListEmpleadosFenixCategoriaLineaCelda(int centroId);
        UpdateCategoriaLineaCeldaInRecruitingDbResponse UpdateCategoriaLineaCeldaInRecruitingDb(int centroId);
        #endregion
    }
}