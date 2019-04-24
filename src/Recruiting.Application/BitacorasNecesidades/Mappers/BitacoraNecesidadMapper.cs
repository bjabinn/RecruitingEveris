using Recruiting.Application.BitacorasNecesidades.Enums;
using Recruiting.Application.BitacorasNecesidades.ViewModels;
using Recruiting.Business.Entities;
using Recruiting.Infra.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace Recruiting.Application.BitacorasNecesidades.Mappers
{
    public static class BitacoraNecesidadMapper
    {
        #region Mapper
        public static IEnumerable<BitacoraNecesidadRowViewModel> ConvertToBitacoraNecesidadRowViewModel(this IEnumerable<BitacoraNecesidad> BitacoraList)
        {
            var BitacoraNecesidadRowViewModelList = new List<BitacoraNecesidadRowViewModel>();

            if (BitacoraList == null) return BitacoraNecesidadRowViewModelList;

            BitacoraNecesidadRowViewModelList = BitacoraList.Select(x => x.ConvertToBitacoraNecesidadRowViewModel()).ToList();

            return BitacoraNecesidadRowViewModelList;
        }


       
        public static string GetPropertiePath(string name)
        {
            string attributeName = null;

            switch (name)
            {
                case "BitacoraId":
                  attributeName = "BitacoraId";
                    break;
                case "NecesidadId":
                    attributeName = "NecesidadId";
                    break;
                case "MensajeSistema":
                    attributeName = "MensajeSistema";
                    break;
                case "TipoCambio":
                    attributeName = "TipoCambio";
                    break;  
                case "Centro":
                    attributeName = "Usuario.Centro.Nombre";
                    break;
                case "Usuario":
                    attributeName = "Usuario.Nombre";
                    break;
                case "FechaCreacion":
                    attributeName = "Created";
                    break;
            }
            return attributeName;
        }

        #region Private Methods

        private static BitacoraNecesidadRowViewModel ConvertToBitacoraNecesidadRowViewModel(this BitacoraNecesidad bitacora)
        {
            var ofertRowViewModel = new BitacoraNecesidadRowViewModel()
            {                
                BitacoraId = bitacora.BitacoraId,
                NecesidadId = bitacora.NecesidadId,
                MensajeSistema = bitacora.MensajeSistema,
                Usuario=bitacora.Usuario.Nombre,
                FechaCreacion=bitacora.Created,
                Centro = bitacora.Usuario.Centro == null ? "N/A" : bitacora.Usuario.Centro.Nombre
            };
            if (bitacora.TipoBitacora.HasValue)
            {
                var enumValue = (TipoBitacoraNecesidadEnum)bitacora.TipoBitacora.Value;
                ofertRowViewModel.TipoCambio = enumValue.GetDescription();
            }

            return ofertRowViewModel;
        }

        

        #endregion

        #endregion
    }
}
