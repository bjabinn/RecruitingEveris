using Recruiting.Application.Candidatos.Services;
using Recruiting.Application.Candidaturas.Enums;
using Recruiting.Application.Candidaturas.Services;
using Recruiting.Application.Candidaturas.ViewModel;
using Recruiting.Application.Helpers;
using Recruiting.Application.Maestros.Services;
using Recruiting.Business.Entities;
using Recruiting.Business.Repositories;
using Recruiting.Data.EntityFramework.Repositories;
using Recruiting.SendMailsService.Correos.Mappers;
using Recruiting.SendMailsService.Correos.Services;
using Recruiting.SendMailsService.Correos.ViewModels;
using Recruiting.SendMailsService.Enums;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;

using System.Net.Mail;
using System.Text;
using System.Collections;
using Recruiting.Application.Bitacoras.Services;
using Recruiting.SendMailsService.Correos.Messages;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using System.Net.Mime;
using Recruiting.Application.Usuarios.Services;
using Recruiting.Application.Maestros.Enums;
using System.Configuration;
using Recruiting.Application.Graph.ViewModels;
using Recruiting.Application.Candidatos.Enums;
using Recruiting.Application.Candidatos.ViewModels;
using System.Linq;
using Recruiting.Application.Becarios.Services;

namespace Recruiting.SendMailsService
{
    public class SendMailsBecarioService : ISendMailsBecarioService
    {

        #region Constants

        #endregion

        #region Fields

        private IBecarioService _becarioService;
        private ICandidatoService _candidatoService;
        private IMaestroService _maestroService;
        private IMaestroRepository _maestroRepository;

        private readonly ICorreoService _correoService;
        private readonly ICorreoRepository _correoRepository;

        private readonly ICorreoBecarioService _correoBecarioService;
        private readonly ICorreoBecarioRepository _correoBecarioRepository;

        private readonly ICorreoPlantillaService _correoPlantillaService;
        private readonly ICorreoPlantillaRepository _correoPlantillaRepository;

        private readonly ICorreoPlantillaVariableService _correoPlantillaVariableService;
        private readonly ICorreoPlantillaVariableRepository _correoPlantillaVariableRepository;


        private readonly IBitacoraService _bitacoraService;
        //se obtiene el diccionario con la configuacion del servidor de correos del webconfig
        NameValueCollection _DiccConfiguracionServidorCorreo;


        #endregion

        #region Properties

        #endregion

        #region Constructors


        public SendMailsBecarioService(IBecarioService becarioService, ICandidaturaRepository candidaturaRepository, ICandidatoService candidatoService,
                  IMaestroService maestroService)
        {
            _becarioService = becarioService;
            _maestroRepository = new MaestroRepository();
            _maestroService = maestroService;
            _candidatoService = candidatoService;

            //para lo del correo
            _correoRepository = new CorreoRepository();
            _correoBecarioRepository = new CorreoBecarioRepository();
            _correoPlantillaRepository = new CorreoPlantillaRepository();
            _correoPlantillaVariableRepository = new CorreoPlantillaVariableRepository();
            _correoService = new CorreoService(_correoRepository, candidaturaRepository);
            _correoBecarioService = new CorreoBecarioService(_correoBecarioRepository);
            _correoPlantillaService = new CorreoPlantillaService(_correoPlantillaRepository);
            _correoPlantillaVariableService = new CorreoPlantillaVariableService(_correoPlantillaVariableRepository);
        }



        #endregion
        public StringBuilder EnviarEmailBecario(NameValueCollection DiccEstadoBecarioPlantillaCorreo, NameValueCollection DiccConfiguracionServidorCorreo, int usuarioAplicacion)
        {
            _DiccConfiguracionServidorCorreo = DiccConfiguracionServidorCorreo;

            int CentroId = 0;
            int tipoMedioContactoEmail = GetTipoMedioContactoEmail();
            StringBuilder resultadoEnvio = new StringBuilder();

            var IteradorEstadosEmails = DiccEstadoBecarioPlantillaCorreo.AllKeys.GetEnumerator();
            var response = _becarioService.GetBecariosEstadoDescartado();

            while (IteradorEstadosEmails.MoveNext())
            {
                if (response.IsValid)
                {
                    foreach (var becario in response.BecarioRowViewModel)
                    {
                        CentroId = _becarioService.GetCentroBecario(becario.BecarioId).CentroId;
                        var responsePlantilla = _correoPlantillaService.GetPlantillaIdByNombrePlantilla(DiccEstadoBecarioPlantillaCorreo[IteradorEstadosEmails.Current.ToString()], CentroId);

                        if (responsePlantilla.IsValid)
                        {
                            if (!ExisteCorreo(becario.BecarioId, responsePlantilla.PlantillaId))
                            {
                                var responseEmailBecario = _becarioService.GetEmailBecario(becario.BecarioId, tipoMedioContactoEmail);
                                var responseAsunto = _correoPlantillaVariableService.GetValorDefectoNombreVariablePlantillaCorreo(responsePlantilla.PlantillaId, NombresVariablesPlantillaCorreoEnum.Asunto.ToString());
                                var responseRemitente = _correoPlantillaVariableService.GetValorDefectoNombreVariablePlantillaCorreo(responsePlantilla.PlantillaId, NombresVariablesPlantillaCorreoEnum.Remitente.ToString());

                                if (responseEmailBecario.IsValid && responseAsunto.IsValid && responseRemitente.IsValid)
                                {
                                    CorreoBecario correoBecario = new CorreoBecario()
                                    {
                                        PlantillaId = responsePlantilla.PlantillaId,
                                        Enviado = false,
                                        BecarioId = becario.BecarioId,
                                        Asunto = responseAsunto.VarlorDefecto,
                                        Remitente = responseRemitente.VarlorDefecto,
                                        Destinatarios = responseEmailBecario.EmailBecario,
                                        TipoAviso = null,
                                        IsActivo = true
                                    };

                                    var model = CorreoBecarioMapper.ConvertToCorreoBecarioRowViewModel(correoBecario);
                                    var responseSave = _correoBecarioService.SaveCorreo(model, usuarioAplicacion);
                                }
                            }
                        }
                    }
                }
            }
            resultadoEnvio = resultadoEnvio.Append(ExecuteSendMailsEstadosCandidatura(DiccEstadoBecarioPlantillaCorreo, usuarioAplicacion));
            return resultadoEnvio;
        }

        public GetPlantillaCorreoByNombreCentroIdResponse GetPlantillaCorreoByNombreCentroId(string NombrePlantillaCorreo, int CentroId)
        {
            return _correoPlantillaService.GetPlantillaCorreoByNombreCentroId(NombrePlantillaCorreo, CentroId);
        }

        public GetPlantillaCorreoByPlantillaIdResponse GetPlantillaCorreoByPlantillaId(int plantillaId)
        {
            return _correoPlantillaService.GetPlantillaCorreoByPlantillaId(plantillaId);
        }

        public GetValorDefectoNombreVariablePlantillaCorreoResponse GetValorDefectoNombreVariablePlantillaCorreo(int PlantillaId, string nombreVariablePlantillaCorreo)
        {
            return _correoPlantillaVariableService.GetValorDefectoNombreVariablePlantillaCorreo(PlantillaId, nombreVariablePlantillaCorreo);
        }


        #region Metodos Privados

        private SchedulerExecutionResultEnum SendEmail(string remitenteCorreo, string destinatarioCorreo, string asuntoCorreo, string Body)
        {
            try
            {
                if (_DiccConfiguracionServidorCorreo == null)
                {
                    _DiccConfiguracionServidorCorreo = (System.Collections.Specialized.NameValueCollection)ConfigurationManager.GetSection("DiccConfiguracionServidorCorreo");
                }
                MailMessage msg = new MailMessage();
                msg.To.Add(destinatarioCorreo);
                msg.From = new MailAddress(remitenteCorreo);
                msg.Subject = asuntoCorreo;
                msg.Bcc.Add(remitenteCorreo);
                msg.Body = Body;
                msg.SubjectEncoding = System.Text.Encoding.UTF8;
                msg.BodyEncoding = System.Text.Encoding.UTF8;
                msg.IsBodyHtml = true;    //Se va a enviar un correo con contenido html

                SmtpClient client = new SmtpClient();
                client.DeliveryMethod = SmtpDeliveryMethod.Network;

                client.Port = Convert.ToInt16(_DiccConfiguracionServidorCorreo["Port"]); // 25; 
                client.Host = _DiccConfiguracionServidorCorreo["Host"];                  //"10.108.22.43"; 
                client.UseDefaultCredentials = Convert.ToBoolean(_DiccConfiguracionServidorCorreo["UseDefaultCredentials"]);//true;


                string directorioBase = string.Empty;
                if (HttpContext.Current != null)
                {
                    directorioBase = string.Concat(HttpContext.Current.Server.MapPath("~/Content/images/"));
                }
                else
                {
                    directorioBase = string.Concat(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), "\\Content\\images\\");
                    directorioBase = directorioBase.Replace("file:", "").Remove(0, 1);
                }

                var imagenLogo = _DiccConfiguracionServidorCorreo["imagenLogo"];
                var inlineLogo = new LinkedResource(string.Concat(directorioBase, imagenLogo));
                inlineLogo.ContentId = Guid.NewGuid().ToString();

                var imagenFirma = _DiccConfiguracionServidorCorreo["imagenFirma"];
                var inlineFirma = new LinkedResource(string.Concat(directorioBase, imagenFirma));
                inlineFirma.ContentId = Guid.NewGuid().ToString();

                string rutaImagenLogo = string.Concat(directorioBase, imagenLogo);
                string rutaImagenFirma = string.Concat(directorioBase, imagenFirma);

                string htmlBody = Body.ToString().Replace(rutaImagenLogo, "cid:" + inlineLogo.ContentId);
                htmlBody = htmlBody.Replace(rutaImagenFirma, "cid:" + inlineFirma.ContentId);

                AlternateView alternateView = AlternateView.CreateAlternateViewFromString(htmlBody, null, MediaTypeNames.Text.Html);
                alternateView.LinkedResources.Add(inlineLogo);
                alternateView.LinkedResources.Add(inlineFirma);
                msg.AlternateViews.Add(alternateView);



                if (client.UseDefaultCredentials == false)
                {
                    client.Credentials = new System.Net.NetworkCredential(_DiccConfiguracionServidorCorreo["NetworkCredential_User"], _DiccConfiguracionServidorCorreo["NetworkCredential_Password"]);
                }
                client.EnableSsl = Convert.ToBoolean(_DiccConfiguracionServidorCorreo["EnableSsl"]);//false;

                client.Send(msg);
            }
            catch (Exception)
            {
                return SchedulerExecutionResultEnum.Enviado_Error;
            }
            return SchedulerExecutionResultEnum.Enviado_OK;
        }

        //private SchedulerExecutionResultEnum SendEmailMeeting(string remitenteCorreo, List<string> destinatariosCorreo, string asuntoCorreo, string Body, byte[] attachment, string NombreCVAttachment)
        //{
        //    try
        //    {
        //        if (_DiccConfiguracionServidorCorreo == null)
        //        {
        //            _DiccConfiguracionServidorCorreo = (System.Collections.Specialized.NameValueCollection)ConfigurationManager.GetSection("DiccConfiguracionServidorCorreo");
        //        }
        //        MailMessage msg = new MailMessage();
        //        foreach (var destinatario in destinatariosCorreo)
        //        {
        //            msg.To.Add(destinatario);
        //        }
        //        msg.From = new MailAddress(remitenteCorreo);
        //        msg.Subject = asuntoCorreo;
        //        msg.Bcc.Add(remitenteCorreo);
        //        msg.Body = Body;
        //        msg.SubjectEncoding = System.Text.Encoding.UTF8;
        //        msg.BodyEncoding = System.Text.Encoding.UTF8;
        //        msg.IsBodyHtml = true;    //Se va a enviar un correo con contenido html
        //        if (attachment != null && NombreCVAttachment != null)
        //        {
        //            msg.Attachments.Add(new Attachment(new MemoryStream(attachment), NombreCVAttachment));
        //        }

        //        SmtpClient client = new SmtpClient();
        //        client.DeliveryMethod = SmtpDeliveryMethod.Network;

        //        client.Port = Convert.ToInt16(_DiccConfiguracionServidorCorreo["Port"]); // 25; 
        //        client.Host = _DiccConfiguracionServidorCorreo["Host"];                  //"10.108.22.43"; 
        //        client.UseDefaultCredentials = Convert.ToBoolean(_DiccConfiguracionServidorCorreo["UseDefaultCredentials"]);//true;

        //        if (client.UseDefaultCredentials == false)
        //        {
        //            client.Credentials = new System.Net.NetworkCredential(_DiccConfiguracionServidorCorreo["NetworkCredential_User"], _DiccConfiguracionServidorCorreo["NetworkCredential_Password"]);
        //        }
        //        client.EnableSsl = Convert.ToBoolean(_DiccConfiguracionServidorCorreo["EnableSsl"]);//false;

        //        client.Send(msg);
        //    }
        //    catch (Exception)
        //    {
        //        return SchedulerExecutionResultEnum.Enviado_Error;
        //    }
        //    return SchedulerExecutionResultEnum.Enviado_OK;
        //}

        private int GetTipoMedioContactoEmail()
        {
            var responseTipoMedioContacto = _maestroService.GetTipoMedioContactoEmail((int)MasterDataTypeEnum.TipoMedioContacto, "email");
            if (responseTipoMedioContacto.IsValid)
            {
                return responseTipoMedioContacto.idMaestroTipoMedioContactoEmail;
            }
            else
            {
                return 0;
            }
        }

        private bool ExisteCorreo(int BecarioId, int PlantillaId, string tipoAviso = null)
        {
            bool existeCorreo = false;

            var response = _correoBecarioService.GetCorreoByBecarioPlantilla(BecarioId, PlantillaId);
            if (response.IsValid)
            {
                return response.TotalElementos > 0;
            }
            return existeCorreo;

        }

        private StringBuilder ExecuteSendMailsEstadosCandidatura(NameValueCollection DiccEstadoCandidaturaPlantillaCorreo, int usuarioAplicacion)
        {
            var responseCorreos = _correoBecarioService.GetCorreosPendientesEnvio();
            var resultadoEjecucion = new StringBuilder();

            if (responseCorreos.IsValid)
            {
                foreach (var correo in responseCorreos.Correos)
                {
                    var response = _correoPlantillaService.GetPlantillaCorreoById(correo.PlantillaId);
                    if (response.IsValid)
                    {
                        ///para cada candidatura creo un correo de su tipo de plantilla que le corresponda
                        var responseEmailBecario = correo.Destinatarios;
                        var responseImagenCabecera = _correoPlantillaVariableService.GetValorDefectoNombreVariablePlantillaCorreo(correo.PlantillaId, NombresVariablesPlantillaCorreoEnum.LogoCabecera.ToString());
                        var responseImagenFirma = _correoPlantillaVariableService.GetValorDefectoNombreVariablePlantillaCorreo(correo.PlantillaId, NombresVariablesPlantillaCorreoEnum.imagenFirma.ToString());
                        var Becario = _becarioService.GetBecarioById(correo.BecarioId).BecarioViewModel;
                        string nombreCandidato = Becario.BecarioDatosBasicos.NombreCandidato;
                        CorreoPlantillaVariable cpv = new CorreoPlantillaVariable()
                        {
                            PlantillaId = correo.PlantillaId,
                        };

                        CorreoPlantillaVariableRowViewModel cr = null;
                        string lineaTituloPie = _correoPlantillaVariableService.GetValorDefectoNombreVariablePlantillaCorreo(correo.PlantillaId, "LineaTituloPie").VarlorDefecto;
                        string lineaDireccion = _correoPlantillaVariableService.GetValorDefectoNombreVariablePlantillaCorreo(correo.PlantillaId, "LineaDireccion").VarlorDefecto;
                        string lineaProvincia = _correoPlantillaVariableService.GetValorDefectoNombreVariablePlantillaCorreo(correo.PlantillaId, "LineaProvincia").VarlorDefecto;
                        string lineaTelefono = _correoPlantillaVariableService.GetValorDefectoNombreVariablePlantillaCorreo(correo.PlantillaId, "LineaTelefono").VarlorDefecto;
                        string lineaEmail = _correoPlantillaVariableService.GetValorDefectoNombreVariablePlantillaCorreo(correo.PlantillaId, "LineaEmail").VarlorDefecto;
                        string lineaWeb = _correoPlantillaVariableService.GetValorDefectoNombreVariablePlantillaCorreo(correo.PlantillaId, "LineaWeb").VarlorDefecto;

                        cr = CorreoPlantillaVariableMapper.ConvertToCorreoPlantillaVariableRowViewModel(cpv, correo.Asunto, correo.Remitente, nombreCandidato,
                                responseImagenFirma.VarlorDefecto, responseImagenCabecera.VarlorDefecto, lineaTituloPie, lineaDireccion, lineaProvincia, lineaTelefono,
                               lineaEmail, lineaWeb);

                        string body = GetBodyMail(response.correoPlantilla.TextoPlantilla, cr);

                        //se crea el correo en si y se envia
                        if (SendEmail(correo.Remitente, correo.Destinatarios, correo.Asunto, body) == SchedulerExecutionResultEnum.Enviado_OK)
                        {
                            //se crea el mensaje para guaradarlo en el log
                            resultadoEjecucion.AppendLine(DateTime.Now.ToString() + ":Enviado correo OK a destinatario " + correo.Destinatarios);


                            //se actualiza a enviado=true y fecha Envio
                            correo.Enviado = true;
                            correo.FechaEnvio = ModifiableEntityHelper.GetCurrentDate();
                            _correoBecarioService.SaveCorreo(correo, usuarioAplicacion);

                            //se crea la bitacora indicando que se ha realizado el envio de email PENDIENTE
                            //var bitacoraResponse = _bitacoraService.GenerateBitacoraCorreo(correo.CandidaturaId, "Envio de correo realizado con exito.");

                            //response.IsValid = response.IsValid && bitacoraResponse.IsValid;
                            //if (!string.IsNullOrWhiteSpace(bitacoraResponse.ErrorMessage))
                            //{
                            //    response.ErrorMessage = bitacoraResponse.ErrorMessage;
                            //}
                        }
                        else
                        {
                            //se crea el mensaje para guaradarlo en el log
                            resultadoEjecucion.AppendLine(DateTime.Now.ToString() + ":ERROR al enviar correo a destinatario " + correo.Destinatarios);
                        }

                    }
                    else
                    {
                        //se crea el mensaje para guaradarlo en el log
                        resultadoEjecucion.AppendLine(DateTime.Now.ToString() + ":Error al obtener la plantilla " + response.correoPlantilla.NombrePlantilla);
                    }
                }
            }
            else
            {
                resultadoEjecucion.AppendLine(DateTime.Now.ToString() + ":Error al obtener los correos pendientes");
            }

            return resultadoEjecucion;
        }

        public string GetBodyMail(string TextoPlantilla, CorreoPlantillaVariableRowViewModel correoPlantillaVariables)
        {

            string[] parrafosBody = TextoPlantilla.Split('|');
            string parrafoTexto = string.Empty;
            string parrafoParametros = string.Empty;
            string[] nombresParametros = null;
            List<string> datos = new List<string>();
            string valor = string.Empty;
            var documentoHTML = new StringBuilder();



            foreach (string parrafo in parrafosBody)
            {
                if (parrafo != string.Empty)
                {
                    //sustituimos los parametros que tenga
                    if (parrafo.IndexOf('~') > 0)
                    {
                        parrafoTexto = parrafo.Substring(0, parrafo.IndexOf('~'));
                        parrafoParametros = parrafo.Substring(parrafo.IndexOf('~') + 1);
                    }
                    else
                    {
                        parrafoTexto = parrafo;
                        parrafoParametros = string.Empty;
                    }

                    if (parrafoParametros != string.Empty)
                    {
                        nombresParametros = parrafoParametros.Split('~');

                        foreach (string nombreParametro in nombresParametros)
                        {
                            var propiedad2 = correoPlantillaVariables.GetType().GetProperty(nombreParametro);
                            if (propiedad2 != null)
                            {
                                valor = propiedad2.GetValue(correoPlantillaVariables) != null ? propiedad2.GetValue(correoPlantillaVariables).ToString() : string.Empty;
                            }
                            else
                            {
                                valor = "Valor del parametro no encontrado en el modelo";
                            }
                            datos.Add(valor);
                        }
                    }

                    parrafoTexto = string.Format(parrafoTexto, datos.ToArray());
                    documentoHTML.AppendLine(parrafoTexto);
                    datos.Clear();
                }
            }

            return documentoHTML.ToString();


        }

        #endregion
    }
}
