using Recruiting.SendMailsService.Correos.Messages;
using Recruiting.SendMailsService.Correos.ViewModels;
using Recruiting.Business.Entities;
using Recruiting.Business.Repositories;
using System;
using System.Linq;
using Recruiting.SendMailsService.Correos.Mappers;

namespace Recruiting.SendMailsService.Correos.Services
{
    public class CorreoBecarioService : ICorreoBecarioService
    {
        #region Constants
       
        #endregion
        #region Fields

        private ICorreoBecarioRepository _correoBecarioRepository;
    
        
        #endregion

        #region Constructor

        public CorreoBecarioService(ICorreoBecarioRepository correoBecarioRepository)
        {
            _correoBecarioRepository = correoBecarioRepository;
           
        }

        #endregion

        #region ICorreoService

        #region QueryRequest

        public GetCorreosBecarioPendientesEnvioResponse GetCorreosPendientesEnvio()
        {
            var response = new GetCorreosBecarioPendientesEnvioResponse();
            try
            {
                var correos = _correoBecarioRepository.GetByCriteria(x => x.Enviado == false && x.IsActivo==true);

                response.Correos = CorreoBecarioMapper.ConvertToCorreoBecarioRowViewModel(correos);
                response.IsValid = true;
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;

        }

        public GetCorreoByBecarioPlantillaResponse GetCorreoByBecarioPlantilla(int BecarioId, int PlantillaId)
        {
            var response = new GetCorreoByBecarioPlantillaResponse();
            try
            {
                IQueryable<CorreoBecario> correos;
                
                correos = _correoBecarioRepository.GetByCriteria(x => x.BecarioId == BecarioId && x.PlantillaId == PlantillaId);
    
                response.Correos = CorreoBecarioMapper.ConvertToCorreoBecarioRowViewModel(correos);
                response.TotalElementos = response.Correos.Count();
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


        public SaveCorreoResponse SaveCorreo(CorreoBecarioRowViewModel correoBecarioViewModel, int usuarioAplicacion)
        {
            var response = new SaveCorreoResponse();

            try
            {
                if (correoBecarioViewModel.CorreoId == 0)
                {
                    var newCorreo = Save(correoBecarioViewModel, usuarioAplicacion);
                    if (newCorreo != null)
                    {
                        response.IsValid = true;
                        response.CorreoId = newCorreo.CorreoBecarioId;
                    }
                    else
                    {
                        response.IsValid = false;
                        response.ErrorMessage = "Error to save CorreoBecario";
                    }
                }
                else
                {
                    if (Update(correoBecarioViewModel,usuarioAplicacion) > 0)
                    {
                        response.IsValid = true;
                        response.CorreoId = (int)correoBecarioViewModel.CorreoId;
                    }
                    else
                    {
                        response.IsValid = false;
                        response.ErrorMessage = "Error to update CorreoBecario";
                    }
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

        #region Private Methods

        private CorreoBecario Save(CorreoBecarioRowViewModel createEditCorreoViewModel, int usuarioAplicacion)
        {
            var correo = new CorreoBecario();

            correo.UpdateCorreo(createEditCorreoViewModel,usuarioAplicacion);

            var newCorreo = _correoBecarioRepository.Create(correo);

            return newCorreo;
        }

        private int Update(CorreoBecarioRowViewModel createEditCorreoViewModel, int usuarioAplicacion)
        {
            var correo = _correoBecarioRepository.GetOne(x => x.CorreoBecarioId == createEditCorreoViewModel.CorreoId);

            correo.UpdateCorreo(createEditCorreoViewModel,usuarioAplicacion);

            return _correoBecarioRepository.Update(correo);

        }

      


        #endregion





    }
}
