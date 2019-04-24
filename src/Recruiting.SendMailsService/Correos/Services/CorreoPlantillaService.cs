using Recruiting.Business.Repositories;
using System;
using Recruiting.SendMailsService.Correos.Messages;
using Recruiting.SendMailsService.Correos.Mappers;

namespace Recruiting.SendMailsService.Correos.Services
{
    public class CorreoPlantillaService : ICorreoPlantillaService
    {
        #region Constants
        
        #endregion
        #region Fields

        private ICorreoPlantillaRepository _correoPlantillaRepository;
       
        
        #endregion

        #region Constructor

        public CorreoPlantillaService(ICorreoPlantillaRepository correoPlantillaRepository)
        {
            _correoPlantillaRepository = correoPlantillaRepository;
            
        }

        #endregion

        public GetPlantillaCorreoByNombreCentroIdResponse GetPlantillaCorreoByNombreCentroId(string NombrePlantillaCorreo, int? CentroId)
        {

            var response = new GetPlantillaCorreoByNombreCentroIdResponse();

            try
            {
                var plantillaCorreo = _correoPlantillaRepository.GetOne(x => x.NombrePlantilla.ToUpper() == NombrePlantillaCorreo.ToUpper() && x.CentroId.Value == CentroId && x.IsActivo == true);
                if (plantillaCorreo != null)
                {
                    response.correoPlantilla = plantillaCorreo.ConvertToCorreoPlantillaRowViewModel();
                    response.IsValid = true;
                }
                else
                {
                    response.ErrorMessage = "Plantilla " + NombrePlantillaCorreo + " del centro " + CentroId + " no encontrada";
                    response.IsValid = false;
                }
              
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

        public GetPlantillaCorreoByPlantillaIdResponse GetPlantillaCorreoByPlantillaId(int plantillaId)
        {

            var response = new GetPlantillaCorreoByPlantillaIdResponse();

            try
            {
                var plantillaCorreo = _correoPlantillaRepository.GetOne(x => x.PlantillaId == plantillaId);
                if (plantillaCorreo != null)
                {
                    response.correoPlantilla = plantillaCorreo.ConvertToCorreoPlantillaRowViewModel();
                    response.IsValid = true;
                }
                else
                {
                    response.ErrorMessage = "Plantilla no encontrada";
                    response.IsValid = false;
                }

            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

        public GetPlantillaIdByNombrePlantillaResponse GetPlantillaIdByNombrePlantilla(string NombrePlantillaCorreo, int CentroId, int? OficinaId = null)
        {
            
            var response = new GetPlantillaIdByNombrePlantillaResponse();

            try
            {
                var plantilla = _correoPlantillaRepository.GetOne(x => x.NombrePlantilla.ToUpper() == NombrePlantillaCorreo.ToUpper() && x.CentroId == CentroId && x.OficinaId == OficinaId && x.IsActivo == true);
                if (plantilla == null)
                {
                    plantilla = _correoPlantillaRepository.GetOne(x => x.NombrePlantilla.ToUpper() == NombrePlantillaCorreo.ToUpper() && x.CentroId == CentroId && x.IsActivo == true);
                }
                response.PlantillaId = plantilla.PlantillaId;
             
                response.IsValid = true;
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }


        public GetPlantillaCorreoByIdResponse GetPlantillaCorreoById(int PlantillaId)
        {
            var response = new GetPlantillaCorreoByIdResponse();
           
            try
            {
                var plantilla =_correoPlantillaRepository.GetOne(x => x.PlantillaId == PlantillaId);
                response.correoPlantilla =CorreoPlantillaMapper.ConvertToCorreoPlantillaRowViewModel(plantilla);
                
                response.IsValid = true;
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }
        #region ICorreoService

        #region QueryRequest



        #endregion




        #endregion

        #region Private Methods





        #endregion










    }
}
