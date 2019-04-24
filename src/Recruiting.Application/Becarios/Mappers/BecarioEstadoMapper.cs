using Recruiting.Application.Becarios.ViewModels;
using Recruiting.Business.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Recruiting.Application.Becarios.Mappers
{
    public static class BecarioEstadoMapper
    {
        #region Mappers

        public static IEnumerable<BecarioEstadoRowViewModel> ConvertToBecarioEstadoViewModel(this IEnumerable<TipoEstadoBecario> estadoBecarioList)
        {
            var becarioEstadoRowViewModelList = new List<BecarioEstadoRowViewModel>();

            if (estadoBecarioList == null)
            {
                return becarioEstadoRowViewModelList;
            }

            becarioEstadoRowViewModelList = estadoBecarioList.Select(x => x.ConvertToBecarioEstadoRowViewModel()).ToList();

            return becarioEstadoRowViewModelList;
        }

        #endregion

        #region Private Methods

        private static BecarioEstadoRowViewModel ConvertToBecarioEstadoRowViewModel(this TipoEstadoBecario estadoBecario)
        {
            var estadoBecarioRowViewModel = new BecarioEstadoRowViewModel()
            {
                BecarioEstado = estadoBecario.EstadoBecario,
                BecarioEstadoId = estadoBecario.TipoEstadoBecarioId,
                Orden = estadoBecario.Orden
            };

            return estadoBecarioRowViewModel;
        }

        #endregion
    }
}
