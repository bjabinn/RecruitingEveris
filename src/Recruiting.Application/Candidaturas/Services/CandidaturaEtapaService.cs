using Recruiting.Application.Candidaturas.Mappers;
using Recruiting.Application.Candidaturas.Messages;
using Recruiting.Business.Repositories;
using System;

namespace Recruiting.Application.Candidaturas.Services
{
    public class CandidaturaEtapaService : ICandidaturaEtapaService
    {
        #region Fields

        private readonly ICandidaturaEtapaRepository _candidaturaEtapaRepository;
        private readonly ITipoEtapaCandidaturaRepository _tipoEtapaCandidaturaRepository;

        #endregion

        #region Constructor

        public CandidaturaEtapaService(ICandidaturaEtapaRepository candidaturaEtapaRepository, ITipoEtapaCandidaturaRepository tipoEtapaCandidaturaRepository)
        {
            _candidaturaEtapaRepository = candidaturaEtapaRepository;
            _tipoEtapaCandidaturaRepository = tipoEtapaCandidaturaRepository;
        }
        #endregion

        #region  ICandidaturaEtapaService Methods

        public GetEtapasCandidaturaResponse GetEtapasCandidatura()
        {
            var response = new GetEtapasCandidaturaResponse();

            try
            {
                response.CandidaturaEtapasViewModel = CandidaturaEtapaMapper.ConvertToCandidaturaEtapaViewModel(_candidaturaEtapaRepository.GetByCriteria(x => x.IsActivo));
                response.IsValid = true;
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;

        }

        public GetOrdenByEtapaCandidaturaResponse GetOrdenByEtapaCandidatura(int etapaId)
        {
            var response = new GetOrdenByEtapaCandidaturaResponse();
            try
            {
                var etapa = _tipoEtapaCandidaturaRepository.GetOne(x => x.TipoEtapaCandidaturaId == etapaId);
                response.IsValid = true;
                response.orden = etapa.Orden;
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
