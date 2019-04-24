
using Recruiting.Application.Candidatos.ViewModels;
using Recruiting.Business.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Recruiting.Application.Candidatos.Mappers
{
    public static class CandidatoCentroMapper
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




        public static IEnumerable<CandidatoCentroEducativoRowViweModel> ConvertToCentroViewModel(this IEnumerable<CandidatoCentroEducativo> centroList)
        {
            var centroRowViewModelList = new List<CandidatoCentroEducativoRowViweModel>();

            var response = (centroList == null)
                ? centroRowViewModelList
                : centroList.Select(x => x.ConvertToCentroRowViewModel()).ToList();

            return response;
        }





        #endregion

        #region Private Methods
        private static CandidatoCentroEducativoRowViweModel ConvertToCentroRowViewModel(this CandidatoCentroEducativo centro)
        {
            var centroRowViewModel = new CandidatoCentroEducativoRowViweModel()
            {
                CentroId = centro.CandidatoCentroEducativoId,
                Centro = centro.Centro,
                Ciudad = centro.Ciudad,
                Pais = centro.Pais
            };

            return centroRowViewModel;
        }
    




        #endregion
    }
}
