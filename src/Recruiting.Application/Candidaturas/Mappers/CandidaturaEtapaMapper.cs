using Recruiting.Application.Candidaturas.ViewModel;
using Recruiting.Business.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Recruiting.Application.Candidaturas.Mappers
{
    public static class CandidaturaEtapaMapper
    {
        #region Mappers

        public static IEnumerable<CandidaturaEtapaRowViewModel> ConvertToCandidaturaEtapaViewModel(this IEnumerable<TipoEtapaCandidatura> etapaCandidaturaList)
        {
            var candidaturaEtapaRowViewModelList = new List<CandidaturaEtapaRowViewModel>();

            if (etapaCandidaturaList == null)
            {
                return candidaturaEtapaRowViewModelList;
            }

            candidaturaEtapaRowViewModelList = etapaCandidaturaList.Select(x => x.ConvertToCandidaturaEtapaRowViewModel()).ToList();

            return candidaturaEtapaRowViewModelList;
        }

        #endregion

        #region Private Methods

        private static CandidaturaEtapaRowViewModel ConvertToCandidaturaEtapaRowViewModel(this TipoEtapaCandidatura etapaCandidatura)
        {
            var etapaCandidaturaRowViewModel = new CandidaturaEtapaRowViewModel()
            {
                EtapaCandidatura = etapaCandidatura.EtapaCandidatura,
                EtapaCandidaturaId = etapaCandidatura.TipoEtapaCandidaturaId,
                Orden = etapaCandidatura.Orden
            };

            return etapaCandidaturaRowViewModel;
        }

        #endregion
    }
}
