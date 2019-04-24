using Recruiting.Application.Decisiones.ViewModels;
using Recruiting.Business.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Recruiting.Application.Decisiones.Mappers
{
    public static class TipoDecisionMapper
    {
        #region Mappers

        public static IEnumerable<TipoDecisionRowViewModel> ConvertToTipoDecisionViewModel(this IEnumerable<TipoDecision> tipoDecision)
        {
            var tipoDecisionRowViewModelList = new List<TipoDecisionRowViewModel>();

            if (tipoDecision == null) return tipoDecisionRowViewModelList;

            tipoDecisionRowViewModelList = tipoDecision.Select(x => x.ConvertToTipoDecisionRowViewModel()).ToList();

            return tipoDecisionRowViewModelList;
        }

        #region Private Methods

        private static TipoDecisionRowViewModel ConvertToTipoDecisionRowViewModel(this TipoDecision decision)
        {
            return new TipoDecisionRowViewModel()
            {
                Decision = decision.Decision,
                TipoDecisionId = decision.TipoDecisionId,
                TipoEtapaCandidaturaId = decision.TipoEtapaCandidaturaId,
            };
        }

        #endregion

        #endregion
    }
}
