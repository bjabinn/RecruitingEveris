using Recruiting.Application.Decisiones.Mappers;
using Recruiting.Application.Decisiones.Messages;
using Recruiting.Business.Repositories;
using System;

namespace Recruiting.Application.Decisiones.Services
{
    public class TipoDecisionService : ITipoDecisionService
    {
        #region Fields

        readonly ITipoDecisionRepository _tipoDecisionRepository;

        #endregion

        #region Contructors

        public TipoDecisionService(ITipoDecisionRepository tipoDecisionRepository)
        {
            _tipoDecisionRepository = tipoDecisionRepository;
        }

        #endregion

        #region ITipoDecisionService Methods

        public GetTipoDecisionListByEtapaIdResponse GetDecisionesByEtapaId(int etapaId)
        {
            var response = new GetTipoDecisionListByEtapaIdResponse();

            try
            {
                var tipoDecisionViewModelList = _tipoDecisionRepository.GetByCriteria(x => x.TipoEtapaCandidaturaId == etapaId);

                response.TipoDecisionViewModel = tipoDecisionViewModelList.ConvertToTipoDecisionViewModel();
                response.IsValid = true;
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        #endregion
    }
}
