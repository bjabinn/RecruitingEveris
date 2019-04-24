using Recruiting.Application.Helpers;
using Recruiting.SendMailsService.Correos.ViewModels;
using Recruiting.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recruiting.SendMailsService.Correos.Mappers
{
    public static class CorreoBecarioMapper
    {
        #region Mapper
      


        public static IEnumerable<CorreoBecarioRowViewModel> ConvertToCorreoBecarioRowViewModel(this IEnumerable<CorreoBecario> CorreoList)
        {
            var CorreoBecarioRowViewModelList = new List<CorreoBecarioRowViewModel>();

            if (CorreoList == null) return CorreoBecarioRowViewModelList;

            CorreoBecarioRowViewModelList = CorreoList.Select(x => x.ConvertToCorreoBecarioRowViewModel()).ToList();

            return CorreoBecarioRowViewModelList;
        }

        public static CorreoBecarioRowViewModel ConvertToCorreoBecarioRowViewModel(this CorreoBecario Correo)
        {
            var CorreoRowViewModel = new CorreoBecarioRowViewModel()
            {
                CorreoId = Correo.CorreoBecarioId,
                BecarioId = Correo.BecarioId,
                Asunto = Correo.Asunto,
                Destinatarios = Correo.Destinatarios,
                PlantillaId = Correo.PlantillaId,
                Remitente = Correo.Remitente,
                Enviado = Correo.Enviado,
                FechaEnvio = Correo.FechaEnvio,
                Activo = Correo.IsActivo,
                TipoAviso = Correo.TipoAviso
            };

            return CorreoRowViewModel;
        }
        #region Private Methods


        public static void UpdateCorreo(this CorreoBecario correo, CorreoBecarioRowViewModel createEditCorreoViewModel,int usuarioAplicacion)
        {
            if (createEditCorreoViewModel.CorreoId >0)
            {
                correo.CorreoBecarioId = (int)createEditCorreoViewModel.CorreoId;

                correo.ModifiedBy = usuarioAplicacion;
                correo.Modified = DateTime.Now; 
            }
            else
            {
                correo.CreatedBy = usuarioAplicacion;
                correo.Created = DateTime.Now;
            }
            correo.Asunto = createEditCorreoViewModel.Asunto;
            if (createEditCorreoViewModel.BecarioId > 0) {
               correo.BecarioId = createEditCorreoViewModel.BecarioId;
            }
            
            correo.Enviado = createEditCorreoViewModel.Enviado;
            if (createEditCorreoViewModel.FechaEnvio != null) {
                correo.FechaEnvio = createEditCorreoViewModel.FechaEnvio;
            }
            correo.PlantillaId = createEditCorreoViewModel.PlantillaId;
            correo.Remitente= createEditCorreoViewModel.Remitente;
            correo.Destinatarios = createEditCorreoViewModel.Destinatarios;
            correo.IsActivo = createEditCorreoViewModel.Activo;
            correo.TipoAviso = createEditCorreoViewModel.TipoAviso;

        }

       

        #endregion

        #endregion
    }
}
