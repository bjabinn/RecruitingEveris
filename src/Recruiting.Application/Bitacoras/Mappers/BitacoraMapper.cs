using Recruiting.Application.Bitacoras.Enums;
using Recruiting.Application.Bitacoras.ViewModels;
using Recruiting.Business.Entities;
using Recruiting.Infra.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace Recruiting.Application.Bitacoras.Mappers
{
    public static class BitacoraMapper
    {
        #region Mapper
        public static IEnumerable<BitacoraRowViewModel> ConvertToBitacoraRowViewModel(this IEnumerable<Bitacora> BitacoraList)
        {
            var BitacoraRowViewModelList = new List<BitacoraRowViewModel>();

            if (BitacoraList == null) return BitacoraRowViewModelList;

            BitacoraRowViewModelList = BitacoraList.Select(x => x.ConvertToBitacoraRowViewModel()).ToList();

            return BitacoraRowViewModelList;
        }

        public static IEnumerable<BitacoraCorreoViewModel> ConvertToBitacoraCorreoViewModel(this IEnumerable<Bitacora> BitacoraCorreoList)
        {
            var BitacoraCorreoViewModelList = new List<BitacoraCorreoViewModel>();

            if (BitacoraCorreoList == null) return BitacoraCorreoViewModelList;

            BitacoraCorreoViewModelList = BitacoraCorreoList.Select(x => x.ConvertToBitacoraCorreoViewModel()).ToList();

            return BitacoraCorreoViewModelList;
        }



        public static string GetPropertiePath(string name)
        {
            string attributeName = null;

            switch (name)
            {
                case "BitacoraId":
                  attributeName = "BitacoraId";
                    break;
                case "CandidaturaId":
                    attributeName = "CandidaturaId";
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

        private static BitacoraRowViewModel ConvertToBitacoraRowViewModel(this Bitacora bitacora)
        {
            var ofertRowViewModel = new BitacoraRowViewModel()
            {
                BitacoraId = bitacora.BitacoraId,
                CandidaturaId = bitacora.CandidaturaId,
                MensajeSistema = bitacora.MensajeSistema,
                Usuario = bitacora.Usuario == null ? null : bitacora.Usuario.Nombre,
                FechaCreacion = bitacora.Created,
                Centro = bitacora.Usuario.Centro == null ? "N/A" : bitacora.Usuario.Centro.Nombre
                
            };
            if (bitacora.TipoBitacora.HasValue)
            {
                var enumValue = (TipoBitacoraEnum)bitacora.TipoBitacora.Value;
                ofertRowViewModel.TipoCambio = enumValue.GetDescription();
            }

            return ofertRowViewModel;
        }

        private static BitacoraCorreoViewModel ConvertToBitacoraCorreoViewModel(this Bitacora bitacora)
        {
            var ofertViewModel = new BitacoraCorreoViewModel()
            {
                BitacoraId = bitacora.BitacoraId,
                CandidaturaId = bitacora.CandidaturaId,
                MensajeSistema = bitacora.MensajeSistema,
                Usuario = bitacora.CreatedBy,
                FechaCreacion = bitacora.Created,
                EstadoAnterior = bitacora.EstadoAnteriorId ,
                EstadoNuevo = bitacora.EstadoNuevoId,
                EtapaAnterior = bitacora.EtapaAnteriorId,
                EtapaNueva = bitacora.EtapaNuevaId

            };
            if (bitacora.TipoBitacora.HasValue)
            {
                var enumValue = (TipoBitacoraEnum)bitacora.TipoBitacora.Value;
                ofertViewModel.TipoCambio = enumValue.GetDescription();
            }

            return ofertViewModel;
        }



        #endregion

        #endregion
    }
}
