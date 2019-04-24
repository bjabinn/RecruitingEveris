using Recruiting.Application.Candidaturas.ViewModel;
using Recruiting.Business.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Recruiting.Application.Candidaturas.Mappers
{
    public static class CandidaturaEstadoMapper
    {
        #region Mappers

        public static IEnumerable<CandidaturaEstadoRowViewModel> ConvertToCandidaturaEstadoViewModel(this IEnumerable<TipoEstadoCandidatura> estadoCandidaturaList)
        {
            var candidaturaEstadoRowViewModelList = new List<CandidaturaEstadoRowViewModel>();

            if (estadoCandidaturaList == null)
            {
                return candidaturaEstadoRowViewModelList;
            }

            candidaturaEstadoRowViewModelList = estadoCandidaturaList.Select(x => x.ConvertToCandidaturaEstadoRowViewModel()).ToList();

            return candidaturaEstadoRowViewModelList;
        }

        #endregion

        #region Private Methods

        private static CandidaturaEstadoRowViewModel ConvertToCandidaturaEstadoRowViewModel(this TipoEstadoCandidatura estadoCandidatura)
        {
            var estadoCandidaturaRowViewModel = new CandidaturaEstadoRowViewModel()
            {
                EstadoCandidatura = estadoCandidatura.EstadoCandidatura,
                EstadoCandidaturaId = estadoCandidatura.TipoEstadoCandidaturaId,
                Orden = estadoCandidatura.Orden
            };

            return estadoCandidaturaRowViewModel;
        }

        #endregion
    }
}
