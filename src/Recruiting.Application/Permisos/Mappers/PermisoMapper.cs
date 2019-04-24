using Recruiting.Application.Permisos.ViewModels;
using Recruiting.Business.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Recruiting.Application.Permisos.Mappers
{
    public static class PermisoMapper
    {
        #region Mappers

        public static PermisoViewModel ConvertToPermisoViewModel(this Permiso permiso)
        {
            var permisoRowViewModel = new PermisoViewModel()
            {
                PermisoId = permiso.PermisoId,
                Nombre = permiso.Nombre,
                Descripcion = permiso.Descripcion
            };

            return permisoRowViewModel;
        }

        public static IEnumerable<PermisoViewModel> ConvertToPermisosViewModel(this IEnumerable<Permiso> permisoList)
        {
            var permisoViewModelList = new List<PermisoViewModel>();

            if (permisoList == null)
            {
                return permisoViewModelList;
            }

            permisoViewModelList = permisoList.Select(x => x.ConvertToPermisoViewModel()).ToList();

            return permisoViewModelList;
        }

        public static string GetPropertiePath(string name)
        {
            string attributeName = null;

            switch (name)
            {
                case "Nombre":
                    attributeName = "Nombre";
                    break;
                case "Descripcion":
                    attributeName = "Descripcion";
                    break;
                default:
                    attributeName = "PermisoId";
                 break;
            }
            return attributeName;
        }

        #endregion

        #region Private Methods

        #endregion
    }
}
