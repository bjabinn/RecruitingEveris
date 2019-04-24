using Recruiting.Application.Centros.Mappers;
using Recruiting.Application.Centros.Messages;
using Recruiting.Business.Repositories;
using System;
using System.Linq;

namespace Recruiting.Application.Centros.Services
{
    public class CentroService : ICentroService
    {
        #region Fields

        private readonly ICentroRepository _centroRepository;

        #endregion

        #region Constructors

        public CentroService(ICentroRepository centroRepository)
        {
            _centroRepository = centroRepository;
        }

        #endregion

        #region ICentroService

        public GetCentrosResponse GetCentros()
        {
            var response = new GetCentrosResponse();

            try
            {
                var centroList = _centroRepository
                                  .GetByCriteria(x => x.IsActivo)
                                  .OrderBy(p => p.Nombre)
                                  .ToList();

                var listaDeCentroViewModel = centroList.ConvertToDatosCentroViewModel();

                var selectList = new System.Web.Mvc.SelectList(listaDeCentroViewModel, "CentroId", "Nombre");

                response.ListaCentrosIdNombre = selectList;

                response.IsValid = true;
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public GetTokenIdByCentroIdResponse GetTokenIdByCentroId(int centroId)
        {
            GetTokenIdByCentroIdResponse response = new GetTokenIdByCentroIdResponse();

            try
            {
               var centro =  _centroRepository.GetOne(x => x.CentroId == centroId);
               response.tokenId = centro.CuentaTokenId == null ? 0 : (int)centro.CuentaTokenId;
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

        #region Private Methods


        #endregion
    }
}
