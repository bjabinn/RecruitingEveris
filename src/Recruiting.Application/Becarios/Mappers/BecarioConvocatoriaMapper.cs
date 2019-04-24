
using Recruiting.Application.Becarios.ViewModels;
using Recruiting.Business.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Recruiting.Application.Becarios.Mappers
{
    public static class BecarioConvocatoriaMapper
    {
        #region Mappers

        public static string GetPropertiePath(string name)
        {
            string attributeName = null;

            switch (name)
            {              
                case "NombreConvocatoria":
                    attributeName = "NombreConvocatoria";
                    break;                         
            }

            return attributeName;
        }




        public static IEnumerable<ConvocatoriaRowViewModel> ConvertToConvocatoriaViewModel(this IEnumerable<BecarioConvocatoria> convocatoriaList)
        {
            var convocatoriaRowViewModelList = new List<ConvocatoriaRowViewModel>();

            var response = (convocatoriaList == null) 
                ? convocatoriaRowViewModelList 
                : convocatoriaList.Select(x => x.ConvertToConvocatoriaRowViewModel()).ToList();

            return response;
        }

    

    

        #endregion

        #region Private Methods
        private static ConvocatoriaRowViewModel ConvertToConvocatoriaRowViewModel(this BecarioConvocatoria convocatoria)
        {
            var centroRowViewModel = new ConvocatoriaRowViewModel()
            {
               ConvocatoriaId = convocatoria.BecarioConvocatoriaId,
               NombreConvocatoria = convocatoria.NombreConvocatoria              
            };

            return centroRowViewModel;
        }

      

     
        #endregion
    }
}
