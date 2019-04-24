using Recruiting.Application.Becarios.Mappers;
using Recruiting.Application.Becarios.Messages;
using Recruiting.Business.Repositories;
using System;

namespace Recruiting.Application.Becarios.Services
{
    public class BecarioEstadoService : IBecarioEstadoService
    {
        #region Fields

        private readonly ITipoEstadoBecarioRepository _becarioEstadoRepository;

        #endregion

        #region Constructor

        public BecarioEstadoService(ITipoEstadoBecarioRepository becarioEstadoRepository)
        {
            _becarioEstadoRepository = becarioEstadoRepository;
        }

        #endregion

        #region IBecarioEstadoService Methods

        public GetEstadosBecariosResponse GetEstadosBecarios()
        {
            var response = new GetEstadosBecariosResponse();

            try
            {
               response.BecarioEstadoViewModel = BecarioEstadoMapper.ConvertToBecarioEstadoViewModel(_becarioEstadoRepository.GetByCriteria(x => x.IsActivo));
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
