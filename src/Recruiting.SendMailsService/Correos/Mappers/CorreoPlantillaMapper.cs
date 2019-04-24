using Recruiting.Application.Helpers;
using Recruiting.SendMailsService.Correos.ViewModels;
using Recruiting.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recruiting.SendMailsService.Correos.Mappers
{
    public static class CorreoPlantillaMapper
    {
        #region Mapper
       
        public static CorreoPlantillaRowViewModel ConvertToCorreoPlantillaRowViewModel(this CorreoPlantilla correoPlantilla)
        {
            var correoPlantillaRowViewModel = new CorreoPlantillaRowViewModel()
            {

                PlantillaId = correoPlantilla.PlantillaId,
                TextoPlantilla = correoPlantilla.TextoPlantilla,
                NombrePlantilla = correoPlantilla.NombrePlantilla,
                Activo = correoPlantilla.IsActivo,
                CandidatoId = correoPlantilla.Correos.Count > 0 ? correoPlantilla.Correos.FirstOrDefault().Candidatura.CandidatoId : 0
            };

            return correoPlantillaRowViewModel;
        }
        #region Private Methods
    
       

        #endregion

        #endregion
    }
}
