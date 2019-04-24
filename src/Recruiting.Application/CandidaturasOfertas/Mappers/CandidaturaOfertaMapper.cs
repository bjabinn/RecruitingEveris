
using Recruiting.Application.CandidaturasOfertas.ViewModels;
using Recruiting.Business.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Recruiting.Application.CandidaturasOfertas.Mappers
{
    public static class CandidaturaOfertaMapper
    {
        #region Mappers

        public static string GetPropertiePath(string name)
        {
            string attributeName = null;

            switch (name)
            {              
                case "NombreOferta":
                    attributeName = "NombreOferta";
                    break;                         
            }

            return attributeName;
        }




        public static IEnumerable<OfertaRowViewModel> ConvertToOfertaViewModel(this IEnumerable<CandidaturaOferta> ofertaList)
        {
            var convocatoriaRowViewModelList = new List<OfertaRowViewModel>();
           
            var response = (ofertaList == null) 
                ? convocatoriaRowViewModelList 
                : ofertaList.Select(x => x.ConvertToOfertaRowViewModel()).ToList();

            return response;
        }

    

    

        #endregion

        #region Private Methods
        private static OfertaRowViewModel ConvertToOfertaRowViewModel(this CandidaturaOferta oferta)
        {
            var ofertaRowViewModel = new OfertaRowViewModel()
            {
               OfertaId = oferta.CandidaturaOfertaId,
               NombreOferta = oferta.NombreOferta              
            };

            return ofertaRowViewModel;
        }

      

     
        #endregion
    }
}
