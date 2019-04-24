using Recruiting.Application.Maestros.ViewModels;
using Recruiting.Business.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Recruiting.Application.Maestros.Mappers
{
    public static class MaestroMapper
    {
        #region Mappers

        public static IEnumerable<MaestroRowViewModel> ConvertToDatosMaestroViewModel(this IEnumerable<Maestro> maestroList)
        {
            var maestroRowViewModelList = new List<MaestroRowViewModel>();

            if (maestroList == null || !maestroList.Any()) return maestroRowViewModelList;

            maestroRowViewModelList = maestroList.Select(x => x.ConvertToMaestroRowViewModel()).ToList();
            
            return maestroRowViewModelList;
        }

        #region Private Methods

        private static MaestroRowViewModel ConvertToMaestroRowViewModel(this Maestro maestro)
        {
            return new MaestroRowViewModel()
            {
                MaestroId = maestro.MaestroId,
                Nombre = maestro.Nombre,
                TipoMaestroId = maestro.TipoMaestroId,
                Activo = maestro.IsActivo,
                Orden = maestro.Orden
            };
        }

        #endregion

        #endregion
    }
}
