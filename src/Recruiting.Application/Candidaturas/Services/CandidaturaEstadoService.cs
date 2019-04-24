using Recruiting.Application.Candidaturas.Mappers;
using Recruiting.Application.Candidaturas.Messages;
using Recruiting.Business.Repositories;
using System;

namespace Recruiting.Application.Candidaturas.Services
{
    public class CandidaturaEstadoService : ICandidaturaEstadoService
    {
        #region Fields

        private readonly ICandidaturaEstadoRepository _candidaturaEstadoRepository;

        #endregion

        #region Constructor

        public CandidaturaEstadoService(ICandidaturaEstadoRepository candidaturaEstadoRepository)
        {
            _candidaturaEstadoRepository = candidaturaEstadoRepository;
        }

        #endregion

        #region ICandidaturaEstadoService Methods

        public GetEstadosCandidaturaResponse GetEstadosCandidatura()
        {
            var response = new GetEstadosCandidaturaResponse();

            try
            {
                response.CandidaturaEstadosViewModel = CandidaturaEstadoMapper.ConvertToCandidaturaEstadoViewModel(_candidaturaEstadoRepository.GetByCriteria(x => x.IsActivo));
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
