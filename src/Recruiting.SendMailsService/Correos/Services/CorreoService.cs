using Recruiting.SendMailsService.Correos.Messages;
using Recruiting.SendMailsService.Correos.ViewModels;
using Recruiting.Business.Entities;
using Recruiting.Business.Repositories;
using System;
using System.Linq;
using Recruiting.SendMailsService.Correos.Mappers;

namespace Recruiting.SendMailsService.Correos.Services
{
    public class CorreoService : ICorreoService
    {
        #region Constants
       
        #endregion
        #region Fields

        private ICorreoRepository _correoRepository;
        private ICandidaturaRepository _candidaturaRepository;
    
        
        #endregion

        #region Constructor

        public CorreoService(ICorreoRepository correoRepository, ICandidaturaRepository candidaturaRepository)
        {
            _correoRepository =correoRepository;
            _candidaturaRepository = candidaturaRepository;
           
        }

        #endregion

        #region ICorreoService

        #region QueryRequest

        public GetCorreosPendientesEnvioResponse GetCorreosPendientesEnvio()
        {
            var response = new GetCorreosPendientesEnvioResponse();
            try
            {
                var correos = _correoRepository.GetByCriteria(x => x.Enviado == false && x.IsActivo==true);

                response.Correos = CorreoMapper.ConvertToCorreoRowViewModel(correos);
                response.IsValid = true;
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;

        }

        public GetCorreoByCandidaturaPlantillaResponse GetCorreoByCandidaturaPlantilla(int CandidaturaId, int PlantillaId, int? subEntrevistaId, string tipoAviso)
        {
            var response = new GetCorreoByCandidaturaPlantillaResponse();
            try
            {
                IQueryable<Correo> correos;

                if (subEntrevistaId == null)
                {
                    correos = _correoRepository.GetByCriteria(x => x.CandidaturaId == CandidaturaId && x.PlantillaId == PlantillaId && x.SubEntrevistaId == null);
                }
                else
                {
                    correos = _correoRepository.GetByCriteria(x => x.CandidaturaId == CandidaturaId && x.PlantillaId == PlantillaId && x.SubEntrevistaId == subEntrevistaId);
                }
                
                if (correos.Any(x => x.TipoAviso == null))
                {
                    response.Correos = CorreoMapper.ConvertToCorreoRowViewModel(correos);
                    response.TotalElementos = response.Correos.Count();
                    response.IsValid = true;
                }
                else
                {
                    response.Correos = CorreoMapper.ConvertToCorreoRowViewModel(correos.Where(x => x.TipoAviso == tipoAviso));
                    response.TotalElementos = response.Correos.Count();
                    response.IsValid = true;
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


        public SaveCorreoResponse SaveCorreo(CorreoRowViewModel correoViewModel, int usuarioAplicacion)
        {
            var response = new SaveCorreoResponse();

            try
            {
                if (correoViewModel.CorreoId == 0)
                {
                    var newCorreo = Save(correoViewModel, usuarioAplicacion);
                    if (newCorreo != null)
                    {
                        response.IsValid = true;
                        response.CorreoId = newCorreo.CorreoId;
                    }
                    else
                    {
                        response.IsValid = false;
                        response.ErrorMessage = "Error to save Correo";
                    }
                }
                else
                {
                    if (Update(correoViewModel,usuarioAplicacion) > 0)
                    {
                        response.IsValid = true;
                        response.CorreoId = (int)correoViewModel.CorreoId;
                    }
                    else
                    {
                        response.IsValid = false;
                        response.ErrorMessage = "Error to update Correo";
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

        private Correo Save(CorreoRowViewModel createEditCorreoViewModel, int usuarioAplicacion)
        {
            var correo = new Correo();

            correo.UpdateCorreo(createEditCorreoViewModel,usuarioAplicacion);

            var newCorreo = _correoRepository.Create(correo);

            return newCorreo;
        }

        private int Update(CorreoRowViewModel createEditCorreoViewModel, int usuarioAplicacion)
        {
            var correo = _correoRepository.GetOne(x => x.CorreoId == createEditCorreoViewModel.CorreoId);

            correo.UpdateCorreo(createEditCorreoViewModel,usuarioAplicacion);

            return _correoRepository.Update(correo);

        }

      


        #endregion





    }
}
