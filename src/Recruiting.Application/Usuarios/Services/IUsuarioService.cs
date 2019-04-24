using Recruiting.Application.Usuarios.Messages;
using Recruiting.Application.Usuarios.ViewModels;
using Recruiting.Business.BaseClasses.DataTable;

namespace Recruiting.Application.Usuarios.Services
{
    public interface IUsuarioService
    {
        #region Query Request

        GetUsuariosResponse GetUsuarios();
        GetUsuariosResponse GetUsuarios(DataTableRequest request);
        GetUsuarioByIdResponse GetUsuarioById(int usuarioId);
        GetUsuarioByUserNameResponse GetUsuarioByUserName(string userName);
        SearchUserNameUsadoResponse SearchUserNameUsado(int idUsuario, string userName);
        SaveUsuarioResponse SaveUsuario(CreateEditUsuarioViewModel usuarioViewModel);
        DeleteUsuarioResponse DeleteUsuario(int usuarioId);
        GetUsuarioRolPermisoResponse GetUsuarioRolPermisoByUserName(string userName);
        GetUsuarioByEmailResponse GetUsuarioByEmail(string email);
        GetUsuariosResponse GetUsuariosByCentroUsuarioId(int CentroUsuarioId);

        GetUsuariosByNombreUsuarioResponse GetUsuariosByNombreUsuario(string textSearch);

        GetUsuariosEntrevistadoresByNombreUsuarioYCentroResponse GetUsuariosEntrevistadoresByNombreUsuarioYCentro(string textSearch);
        #endregion
    }
}
