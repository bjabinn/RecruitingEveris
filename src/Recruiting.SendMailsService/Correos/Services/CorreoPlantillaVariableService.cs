using Recruiting.Business.Repositories;
using Recruiting.SendMailsService.Correos.Messages;
using System;

namespace Recruiting.SendMailsService.Correos.Services
{
    public class CorreoPlantillaVariableService : ICorreoPlantillaVariableService
    {
        #region Constants
        
        #endregion
        #region Fields

        private ICorreoPlantillaVariableRepository _correoPlantillaVariableRepository;
       
        
        #endregion

        #region Constructor

        public CorreoPlantillaVariableService(ICorreoPlantillaVariableRepository correoPlantillaVariableRepository)
        {
            _correoPlantillaVariableRepository = correoPlantillaVariableRepository;
            
        }

        #endregion

        public GetValorDefectoNombreVariablePlantillaCorreoResponse GetValorDefectoNombreVariablePlantillaCorreo(int PlantillaId, string nombreVariablePlantillaCorreo)
        {
            
            var response = new GetValorDefectoNombreVariablePlantillaCorreoResponse();

            try
            {
                var valor = _correoPlantillaVariableRepository.GetOne(x => x.PlantillaId == PlantillaId && x.NombreVariable.ToUpper() == nombreVariablePlantillaCorreo.ToString().ToUpper() && x.IsActivo == true);
                if (valor != null)
                {
                    response.VarlorDefecto = valor.ValorDefecto;
                }
                else
                {
                    response.VarlorDefecto = null;
                }
             
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
