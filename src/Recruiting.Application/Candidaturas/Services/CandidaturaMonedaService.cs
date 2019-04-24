using Recruiting.Application.Candidaturas.Messages;
using Recruiting.Business.Repositories;
using System;

namespace Recruiting.Application.Candidaturas.Services
{
    public class CandidaturaMonedaService : ICandidaturaMonedaService
    {
        #region Fields

        private readonly IMonedasDeCentroRepository _monedasDeCentroRepository;

        #endregion

        #region Constructor

        public CandidaturaMonedaService(IMonedasDeCentroRepository monedasDeCentroRepository)
        {
            _monedasDeCentroRepository = monedasDeCentroRepository;
        }

        #endregion

        #region ICandidaturaEstadoService Methods

        public GetMonedaByCentroIdResponse GetMonedaByCentroId (int centroId)
        {
            var response = new GetMonedaByCentroIdResponse();
            try
            {
                var moneda = _monedasDeCentroRepository.GetOne(x => x.CentroId == centroId);
                if (moneda != null)
                {
                    response.Moneda = moneda.Moneda;
                    response.IsValid = true;
                }
                else
                {
                    response.IsValid = false;
                    response.Moneda = "default";
                }
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
