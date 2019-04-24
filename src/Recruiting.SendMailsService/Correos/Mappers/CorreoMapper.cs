using Recruiting.Application.Helpers;
using Recruiting.SendMailsService.Correos.ViewModels;
using Recruiting.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recruiting.SendMailsService.Correos.Mappers
{
    public static class CorreoMapper
    {
        #region Mapper
      


        public static IEnumerable<CorreoRowViewModel> ConvertToCorreoRowViewModel(this IEnumerable<Correo> CorreoList)
        {
            var CorreoRowViewModelList = new List<CorreoRowViewModel>();

            if (CorreoList == null) return CorreoRowViewModelList;

            CorreoRowViewModelList = CorreoList.Select(x => x.ConvertToCorreoRowViewModel()).ToList();

            return CorreoRowViewModelList;
        }

        public static CorreoRowViewModel ConvertToCorreoRowViewModel(this Correo Correo)
        {
            var ofertRowViewModel = new CorreoRowViewModel()
            {
                CorreoId = Correo.CorreoId,
                Asunto = Correo.Asunto,
                Destinatarios = Correo.Destinatarios,
                PlantillaId = Correo.PlantillaId,
                Remitente = Correo.Remitente,
                Enviado = Correo.Enviado,
                CandidaturaId = Correo.CandidaturaId.Value,
                FechaEnvio = Correo.FechaEnvio,
                Activo = Correo.IsActivo,
                SubEntrevistaId = Correo.SubEntrevistaId,
                TipoAviso = Correo.TipoAviso
            };

            return ofertRowViewModel;
        }
        #region Private Methods


        public static void UpdateCorreo(this Correo correo, CorreoRowViewModel createEditCorreoViewModel,int usuarioAplicacion)
        {
            if (createEditCorreoViewModel.CorreoId >0)
            {
                correo.CorreoId = (int)createEditCorreoViewModel.CorreoId;

                correo.ModifiedBy = usuarioAplicacion;
                correo.Modified = DateTime.Now; 
            }
            else
            {
                correo.CreatedBy = usuarioAplicacion;
                correo.Created = DateTime.Now;
            }
            correo.Asunto = createEditCorreoViewModel.Asunto;
            if (createEditCorreoViewModel.CandidaturaId > 0) {
               correo.CandidaturaId = createEditCorreoViewModel.CandidaturaId;
            }
            
            correo.Enviado = createEditCorreoViewModel.Enviado;
            if (createEditCorreoViewModel.FechaEnvio != null) {
                correo.FechaEnvio = createEditCorreoViewModel.FechaEnvio;
            }
            correo.PlantillaId = createEditCorreoViewModel.PlantillaId;
            correo.Remitente= createEditCorreoViewModel.Remitente;
            correo.Destinatarios = createEditCorreoViewModel.Destinatarios;
            correo.IsActivo = createEditCorreoViewModel.Activo;
            if (createEditCorreoViewModel.SubEntrevistaId != null)
            {
                correo.SubEntrevistaId = createEditCorreoViewModel.SubEntrevistaId.Value;
            }
            correo.TipoAviso = createEditCorreoViewModel.TipoAviso;

        }

       

        #endregion

        #endregion
    }
}
