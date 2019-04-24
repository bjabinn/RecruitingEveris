
using Recruiting.Application.Becarios.ViewModels;
using Recruiting.Business.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Recruiting.Application.Becarios.Mappers
{
    public static class BecarioCentroMapper
    {
        #region Mappers

        public static string GetPropertiePath(string name)
        {
            string attributeName = null;

            switch (name)
            {
                case "CentroId":
                    attributeName = "CentroId";
                    break;
                case "Centro":
                    attributeName = "Centro";
                    break;
                case "Ciudad":
                    attributeName = "Ciudad";
                    break;
                case "Pais":
                    attributeName = "Pais";
                    break;               
            }

            return attributeName;
        }




        public static IEnumerable<CentroProcedenciaRowViewModel> ConvertToCentroViewModel(this IEnumerable<BecarioCentroProcedencia> centroList)
        {
            var centroRowViewModelList = new List<CentroProcedenciaRowViewModel>();

            var response = (centroList == null) 
                ? centroRowViewModelList 
                : centroList.Select(x => x.ConvertToCentroRowViewModel()).ToList();

            return response;
        }

    

    

        #endregion

        #region Private Methods
        private static CentroProcedenciaRowViewModel ConvertToCentroRowViewModel(this BecarioCentroProcedencia centro)
        {
            var centroRowViewModel = new CentroProcedenciaRowViewModel()
            {
               CentroId = centro.BecarioCentroProcedenciaId,
               Centro = centro.Centro,
               Ciudad = centro.Ciudad,
               Pais = centro.Pais
            };

            return centroRowViewModel;
        }

      

     
        #endregion
    }
}
