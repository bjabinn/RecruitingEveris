using Recruiting.Application.Permisos.Messages;

namespace Recruiting.Application.Permisos.Services
{
    public interface IPermisoService
    {
        #region Query Request

        GetPermisosResponse GetPermisos();

        #endregion
    }
}
