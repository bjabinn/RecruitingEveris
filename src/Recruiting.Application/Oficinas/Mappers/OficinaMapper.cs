using Recruiting.Application.Oficinas.ViewModels;
using Recruiting.Business.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Recruiting.Application.Oficinas.Mappers
{
    public static class OficinaMapper
    {
        #region Mappers

        public static IEnumerable<OficinaViewModel> ConvertToDatosOficinaViewModel(this IEnumerable<Oficina> oficinaList)
        {
            var oficinaViewModelList = new List<OficinaViewModel>();

            if (oficinaList == null || !oficinaList.Any()) return oficinaViewModelList;

            oficinaViewModelList = oficinaList.Select(x => x.ConvertToOficinaViewModel()).ToList();
            
            return oficinaViewModelList;
        }

        #region Private Methods

        private static OficinaViewModel ConvertToOficinaViewModel(this Oficina oficina)
        {
            return new OficinaViewModel()
            {
                OficinaId = oficina.OficinaId,
                Nombre = oficina.Nombre,     
                Centro = oficina.Centro                        
            };
        }

        #endregion

        #endregion
    }
}
