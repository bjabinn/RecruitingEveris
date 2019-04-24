using Recruiting.Application.BitacorasBecarios.Enums;
using Recruiting.Application.BitacorasBecarios.ViewModels;
using Recruiting.Business.Entities;
using Recruiting.Infra.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace Recruiting.Application.BitacorasBecarios.Mappers
{
    public static class BitacoraBecarioMapper
    {
        #region Mapper
        public static IEnumerable<BitacoraBecariosRowViewModel> ConvertToBitacoraBecarioRowViewModel(this IEnumerable<BitacoraBecario> BitacoraList)
        {
            var BitacoraBecarioRowViewModelList = new List<BitacoraBecariosRowViewModel>();

            if (BitacoraList == null) return BitacoraBecarioRowViewModelList;

            BitacoraBecarioRowViewModelList = BitacoraList.Select(x => x.ConvertToBitacoraBecarioRowViewModel()).ToList();

            return BitacoraBecarioRowViewModelList;
        }


       
        public static string GetPropertiePath(string name)
        {
            string attributeName = null;

            switch (name)
            {
                case "BitacoraId":
                  attributeName = "BitacoraId";
                    break;
                case "BecarioId":
                    attributeName = "BecarioId";
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

        private static BitacoraBecariosRowViewModel ConvertToBitacoraBecarioRowViewModel(this BitacoraBecario bitacora)
        {
            var ofertRowViewModel = new BitacoraBecariosRowViewModel()
            {                
                BitacoraId = bitacora.BitacoraId,
                BecarioId = bitacora.BecarioId,
                MensajeSistema = bitacora.MensajeSistema,
                Usuario = bitacora.Usuario.Nombre,
                FechaCreacion = bitacora.Created,
                Centro = bitacora.Usuario.Centro == null ? "N/A" : bitacora.Usuario.Centro.Nombre
            };
            if (bitacora.TipoBitacora.HasValue)
            {
                var enumValue = (TipoBitacoraBecarioEnum)bitacora.TipoBitacora.Value;
                ofertRowViewModel.TipoCambio = enumValue.GetDescription();
            }

            return ofertRowViewModel;
        }

        

        #endregion

        #endregion
    }
}
