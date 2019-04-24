using Recruiting.Application.Roles.ViewModels;
using Recruiting.Application.Usuarios.ViewModels;
using Recruiting.Business.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Recruiting.Application.Roles.Mappers
{
    public static class RolMapper
    {
        #region Mappers

        public static CreateEditRolViewModel ConvertToCreateEditRolViewModel(this Rol rol)
        {
            var rolRowViewModel = new CreateEditRolViewModel()
            {
                Descripcion = rol.Descripcion,
                Nombre = rol.Nombre,
                RolId = rol.RolId,
                PermisoRol = rol.PermisoRol.Select(x => x.ConvertToPermisoRolViewModel()).ToList(),
                UsuarioRol = rol.UsuarioRol.Select(x => x.ConvertToUsuarioRolViewModel()).ToList(),
                Activo = rol.IsActivo
            };

            return rolRowViewModel;
        }

        public static IEnumerable<RolRowViewModel> ConvertToRolViewModel(this IEnumerable<Rol> rolList)
        {
            var rolViewModelList = new List<RolRowViewModel>();

            if (rolList == null)
            {
                return rolViewModelList;
            }

            rolViewModelList = rolList.Select(x => x.ConvertToRolViewModel()).ToList();

            return rolViewModelList;
        }

        public static void UpdateRol(this Rol rol, CreateEditRolViewModel createEditRolViewModel)
        {
            rol.RolId = createEditRolViewModel.RolId;
            rol.Nombre = createEditRolViewModel.Nombre;
            rol.Descripcion = createEditRolViewModel.Descripcion;
            rol.PermisoRol = createEditRolViewModel.PermisoRol.Where(y => y.ContienePermiso).Select(x => x.ConvertToPermisoRolViewModel()).ToList();
            rol.IsActivo = true;
        }

        public static string GetPropertiePath(string name)
        {
            string attributeName = null;

            switch (name)
            {
                case "Nombre":
                    attributeName = "Nombre";
                    break;
                default:
                    attributeName = "RolId";
                 break;
            }
            return attributeName;
        }

        #endregion

        #region Private Methods

        private static RolRowViewModel ConvertToRolViewModel(this Rol rol)
        {
            var rolViewModel = new RolRowViewModel()
            {
                RolId = rol.RolId,
                Nombre = rol.Nombre,
                Descripcion = rol.Descripcion,
                Permisos = rol.PermisoRol.Select(x => x.ConvertToPermisoRolViewModel()).ToList()
            };

            return rolViewModel;
        }

        private static PermisoRolViewModel ConvertToPermisoRolViewModel(this PermisoRol permisoRol)
        {
            var permisoRolViewModel = new PermisoRolViewModel()
            {
                RolId = permisoRol.RolId,
                PermisoNombre = permisoRol.Permiso.Nombre,
                PermisoId = permisoRol.PermisoId,
                ContienePermiso = true
            };

            return permisoRolViewModel;
        }

        private static UsuarioRolViewModel ConvertToUsuarioRolViewModel(this UsuarioRol usuarioRol)
        {
            var usuarioRolViewModel = new UsuarioRolViewModel()
            {
                ContieneRol = true,
                RolId = usuarioRol.RolId,
                RolNombre = usuarioRol.Rol.Nombre,
                UsuarioId = usuarioRol.UsuarioId
            };

            return usuarioRolViewModel;
        }

        private static PermisoRol ConvertToPermisoRolViewModel(this PermisoRolViewModel permisoRolViewModel)
        {
            var permisoRol = new PermisoRol()
            {
                PermisoId = permisoRolViewModel.PermisoId,
                RolId = permisoRolViewModel.RolId
            };

            return permisoRol;
        }

        #endregion
    }
}
