using Recruiting.Application.Roles.Messages;
using Recruiting.Application.Roles.ViewModels;
using Recruiting.Business.BaseClasses.DataTable;

namespace Recruiting.Application.Roles.Services
{
    public interface IRolService
    {
        #region Query Request

        GetRolesResponse GetRoles();
        GetRolesResponse GetRoles(DataTableRequest request);
        GetRolByIdResponse GetRolById(int rolId);
        SaveRolResponse SaveRol(CreateEditRolViewModel rolViewModel);
        DeleteRolResponse DeleteRol(int rolId);

        #endregion
    }
}
