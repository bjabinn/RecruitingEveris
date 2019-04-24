using Recruiting.Application.Helpers;
using Recruiting.SendMailsService.Correos.ViewModels;
using Recruiting.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Recruiting.Application.Candidaturas.Enums;
using Recruiting.Application.Candidatos.Services;
using Recruiting.Business.Repositories;
using System.Web;
using Recruiting.Application.Candidatos.ViewModels;

namespace Recruiting.SendMailsService.Correos.Mappers
{
    public static class CorreoPlantillaVariableMapper
    {
        #region Mapper
           

        public static CorreoPlantillaVariableRowViewModel ConvertToCorreoPlantillaVariableRowViewModel(this CorreoPlantillaVariable correoPlantillaVariable, 
            string asunto, string remitente, string nombreCandidato, string ImagenFirma,string logoCabecera, 
            string lineaTituloPie, string lineaDireccion,string lineaProvincia,string lineaTelefono, string lineaEmail,string lineaWeb,
            string nombreEntrevistador="", DateTime? fechaEntrevista=null, string tipoEntrevista="",int candidaturaId=0,string urlRecruiting="", string MensajeSistema = "", string candidato = "")
        {
            var correoPlantillaVariableRowViewModel = new CorreoPlantillaVariableRowViewModel()
            {
                Asunto = asunto,
                Remitente = remitente,
                NombreCandidato =nombreCandidato,
                NombreEntrevistador=nombreEntrevistador,
                FechaEntrevista=fechaEntrevista,
                TipoEntrevista=tipoEntrevista,
                CandidaturaId=candidaturaId,
                LineaTituloPie = lineaTituloPie,
                LineaDireccion= lineaDireccion,
                LineaProvincia= lineaProvincia,
                LineaTelefono= lineaTelefono,
                LineaEmail= lineaEmail,
                LineaWeb= lineaWeb,
                UrlRecruiting=urlRecruiting,
                MensajeSistema = MensajeSistema,
                Candidato = candidato
            };
            if (fechaEntrevista.HasValue)
            {
               
                correoPlantillaVariableRowViewModel.SoloFecha = fechaEntrevista.Value.Date.ToShortDateString();
                correoPlantillaVariableRowViewModel.SoloHora = fechaEntrevista.Value.TimeOfDay;
            }
            if (HttpContext.Current != null) {
                correoPlantillaVariableRowViewModel.imagenFirma = string.Concat(HttpContext.Current.Server.MapPath("~/Content/images/"), ImagenFirma);
                correoPlantillaVariableRowViewModel.LogoCabecera = string.Concat(HttpContext.Current.Server.MapPath("~/Content/images/"), logoCabecera);
            }
            else {
                correoPlantillaVariableRowViewModel.imagenFirma = string.Concat(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), "\\Content\\images\\", ImagenFirma);
                correoPlantillaVariableRowViewModel.imagenFirma = correoPlantillaVariableRowViewModel.imagenFirma.Replace("file:", "").Remove(0, 1);

               correoPlantillaVariableRowViewModel.LogoCabecera = string.Concat(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), "\\Content\\images\\", logoCabecera);
                correoPlantillaVariableRowViewModel.LogoCabecera = correoPlantillaVariableRowViewModel.LogoCabecera.Replace("file:", "").Remove(0, 1);
            }
 


            return correoPlantillaVariableRowViewModel;
        }
        
        #region Private Methods



        #endregion

        #endregion
    }
}
