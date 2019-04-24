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
using System.Resources;
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
using Recruiting.Application.Usuarios.ViewModels;

namespace Recruiting.SendMailsService
{
    public class SendMailsPlaningBatchService : ISendMailsPlaningBatchService
    {

        #region Constants

        #endregion

        #region Fields

        private ICandidaturaService _candidaturaService;
        private ICandidatoService _candidatoService;
        private IMaestroService _maestroService;
        private IMaestroRepository _maestroRepository;
        private IUsuarioService _usuarioService;

        private readonly ICorreoService _correoService;
        private readonly ICorreoRepository _correoRepository;

        private readonly ICorreoPlantillaService _correoPlantillaService;
        private readonly ICorreoPlantillaRepository _correoPlantillaRepository;

        private readonly ICorreoPlantillaVariableService _correoPlantillaVariableService;
        private readonly ICorreoPlantillaVariableRepository _correoPlantillaVariableRepository;


        private readonly IBitacoraService _bitacoraService;
        //se obtiene el diccionario con la configuacion del servidor de correos del webconfig
        NameValueCollection _DiccConfiguracionServidorCorreo;

        private readonly IEntrevistaRepository _entrevistaRepository;
        private readonly ICentroRepository _centroRepository;

        //private const string Url_Candidaturas_Completar_Primera_Entrevista = "https:// recruitingcenters.its.everis.com/Candidaturas/CompletarPrimeraEntrevista/";
        //private const string Url_Candidaturas_Completar_Segunda_Entrevista = "https:// recruitingcenters.its.everis.com/Candidaturas/CompletarSegundaEntrevista/";
        private const string Url_Candidaturas_Completar_Primera_Entrevista = "http://7.128.80.33:92/Candidaturas/CompletarPrimeraEntrevista/";
        private const string Url_Candidaturas_Completar_Segunda_Entrevista = "http://7.128.80.33:92/Candidaturas/CompletarSegundaEntrevista/";

        #endregion

        #region Properties

        #endregion

        #region Constructors


        public SendMailsPlaningBatchService(ICandidaturaRepository candidaturaRepository, ICandidaturaService candidaturaService, ICandidatoService candidatoService,
                  IMaestroService maestroService, IBitacoraRepository bitacoraRepository,
                  ITipoDecisionRepository tipoDecisionRepository, ITipoEtapaCandidaturaRepository tipoEtapaCandidaturaRepository,
                  ITipoEstadoCandidaturaRepository tipoEstadoCandidaturaRepository, IUsuarioService usuarioService = null)
        {
            _maestroRepository = new MaestroRepository();
            _maestroService = maestroService;
            _candidaturaService = candidaturaService;
            _candidatoService = candidatoService;
            if (usuarioService != null)
            {
                _usuarioService = usuarioService;
            }


            //para lo del correo
            _correoRepository = new CorreoRepository();
            _correoPlantillaRepository = new CorreoPlantillaRepository();
            _correoPlantillaVariableRepository = new CorreoPlantillaVariableRepository();
            _correoService = new CorreoService(_correoRepository, candidaturaRepository);
            _correoPlantillaService = new CorreoPlantillaService(_correoPlantillaRepository);
            _correoPlantillaVariableService = new CorreoPlantillaVariableService(_correoPlantillaVariableRepository);

            _bitacoraService = new BitacoraService(bitacoraRepository, candidaturaRepository, tipoDecisionRepository,
                tipoEtapaCandidaturaRepository, tipoEstadoCandidaturaRepository, _maestroRepository);

            _entrevistaRepository = new EntrevistaRepository();
            _centroRepository = new CentroRepository();
        }



        #endregion

        public StringBuilder EnviarEmail(NameValueCollection DiccEstadoCandidaturaPlantillaCorreo, NameValueCollection DiccConfiguracionServidorCorreo, int usuarioAplicacion)
        {
            _DiccConfiguracionServidorCorreo = DiccConfiguracionServidorCorreo;

            int Centroid = 0;
            int tipoMedioContactoEmail = GetTipoMedioContactoEmail();
            StringBuilder resultadoEnvio = new StringBuilder();

            var IteradorEstadosEmails = DiccEstadoCandidaturaPlantillaCorreo.AllKeys.GetEnumerator();
            while (IteradorEstadosEmails.MoveNext())
            {
                var response = _candidaturaService.GetCandidaturasByNombreEstadoCandidatura(IteradorEstadosEmails.Current.ToString());
                if (response.IsValid)
                {
                    foreach (var candidatura in response.CandidaturasViewModel)
                    {
                      

                        //Eliminamos las candidaturas descartadas en etapa de filtrado
                        if ((candidatura.CandidaturaDatosBasicosViewModel.DatosBasicos.EtapaCandidaturaId != (int)TipoEtapaCandidaturaEnum.FiltradoTelefonico) &&
                            (candidatura.CandidaturaDatosBasicosViewModel.DatosBasicos.EtapaCandidaturaId != (int)TipoEtapaCandidaturaEnum.FiltradoTecnico)
                            && !(IteradorEstadosEmails.Current.ToString() == "Stand-by" && candidatura.CandidaturaDatosBasicosViewModel.DatosBasicos.EtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.AgendarEntrevistas)

                            )
                        {
                            //Eliminamos las candidaturas descartadas en StandBy
                            if (!(candidatura.CandidaturaDatosBasicosViewModel.DatosBasicos.EstadoCandidaturaId == (int)TipoEstadoCandidaturaEnum.Descartado && (candidatura.CandidaturaDatosBasicosViewModel.DatosBasicos.EtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.AgendarEntrevistas
                            || candidatura.CandidaturaDatosBasicosViewModel.DatosBasicos.EtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.AgendarSegundaEntrevista || candidatura.CandidaturaDatosBasicosViewModel.DatosBasicos.EtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.AgendarCartaOferta)))
                            {
                                //Eliminamos las candidaturas descartadas con el campo de notificar en false
                                if (!(candidatura.CandidaturaDatosBasicosViewModel.DatosBasicos.EstadoCandidaturaId == (int)TipoEstadoCandidaturaEnum.Descartado && candidatura.PrimeraEntrevistaViewModel.ResultadoPrimeraEntrevista != null && candidatura.PrimeraEntrevistaViewModel.ResultadoPrimeraEntrevista.NotificarDescarte == false))
                                {

                                    //para cada candidatura creo un correo de su tipo de plantilla que le corresponda segun su centro
                                    Centroid = _candidaturaService.GetCentroCandidatura(candidatura.CandidaturaId.Value).CentroId;
                                    var responsePlantilla = _correoPlantillaService.GetPlantillaIdByNombrePlantilla(DiccEstadoCandidaturaPlantillaCorreo[IteradorEstadosEmails.Current.ToString()], Centroid);
                                    if (responsePlantilla.IsValid)
                                    {

                                        //se comprueba que no existe ya un correo (enviado o no para esa candidatura en el mismo estado para no andar reenviaando correos
                                        if (!ExisteCorreo(candidatura.CandidaturaId.Value, responsePlantilla.PlantillaId, tipoAviso: "Descarte/StandBy"))
                                        {
                                            var responseEmailCandidato = _candidatoService.GetEmailCandidato(candidatura.CandidaturaDatosBasicosViewModel.DatosBasicos.CandidatoId, tipoMedioContactoEmail);
                                            var responseAsunto = _correoPlantillaVariableService.GetValorDefectoNombreVariablePlantillaCorreo(responsePlantilla.PlantillaId, NombresVariablesPlantillaCorreoEnum.Asunto.ToString());
                                            var responseRemitente = _correoPlantillaVariableService.GetValorDefectoNombreVariablePlantillaCorreo(responsePlantilla.PlantillaId, NombresVariablesPlantillaCorreoEnum.Remitente.ToString());

                                            if (responseEmailCandidato.IsValid && responseAsunto.IsValid && responseRemitente.IsValid)
                                            {
                                                Correo correo = new Correo()
                                                {
                                                    PlantillaId = responsePlantilla.PlantillaId,
                                                    Enviado = false,
                                                    CandidaturaId = candidatura.CandidaturaId,
                                                    Asunto = responseAsunto.VarlorDefecto,
                                                    Remitente = responseRemitente.VarlorDefecto,
                                                    Destinatarios = responseEmailCandidato.EmailCandidato,
                                                    TipoAviso = "Descarte/StandBy",
                                                    IsActivo = true
                                                };

                                                var model = CorreoMapper.ConvertToCorreoRowViewModel(correo);
                                                var responseSave = _correoService.SaveCorreo(model, usuarioAplicacion);

                                                //se crea una bitacora indicando que se ha programado el envio de email
                                                var bitacoraResponse = _bitacoraService.GenerateBitacoraCorreo(candidatura.CandidaturaId.Value, "Programado envio de correo.");

                                                response.IsValid = response.IsValid && bitacoraResponse.IsValid;
                                                if (!string.IsNullOrWhiteSpace(bitacoraResponse.ErrorMessage))
                                                {
                                                    response.ErrorMessage = bitacoraResponse.ErrorMessage;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    resultadoEnvio.AppendLine(DateTime.Now.ToString() + ":No se ha obtenenido la plantilla " + DiccEstadoCandidaturaPlantillaCorreo[IteradorEstadosEmails.Current.ToString()] + " para el centro " + Centroid.ToString());
                }

            }
            //por ultimo se envian los email
            resultadoEnvio = resultadoEnvio.Append(ExecuteSendMailsEstadosCandidatura(DiccEstadoCandidaturaPlantillaCorreo, usuarioAplicacion));
            return resultadoEnvio;
        }




        public StringBuilder EnviarEmailFinalizarFeedbacks(NameValueCollection DiccionarioFinalizarFeedback, NameValueCollection DiccConfiguracionServidorCorreo, UsuarioRolPermisoViewModel usuarioAplicacion) {
            _DiccConfiguracionServidorCorreo = DiccConfiguracionServidorCorreo;

            int CentroId = 0;
            int tipoMedioContactoEmail = GetTipoMedioContactoEmail();
            StringBuilder resultadoEnvio = new StringBuilder();

            var IteradorEstadosEmails = DiccionarioFinalizarFeedback.AllKeys.GetEnumerator();
            var pastWeek = DateTime.Today.AddDays(-7);
            var pastMonths = DateTime.Today.AddDays(-60);


            var ListEntrevistas = _entrevistaRepository.GetByCriteria(x => x.Candidatura.IsActivo &&
                                      //(!(usuarioAplicacion.CentroIdUsuario.HasValue) || x.Candidatura.Usuario.CentroId == usuarioAplicacion.CentroIdUsuario.Value) &&
                                      x.Candidatura.EstadoCandidaturaId == (int)TipoEstadoCandidaturaEnum.Entrevista &&
                                      x.Candidatura.EtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.FeedbackPrimeraEntrevista &&
                                      x.TipoEntrevistaId == (int)TipoEntrevistaEnum.PrimeraEntrevista &&
                                      x.FechaEntrevista < pastWeek && x.FechaEntrevista > pastMonths).ToList();

            var ListSubEntrevistas = _entrevistaRepository.GetByCriteria(x => x.Candidatura.IsActivo &&
                                       //(!(usuarioAplicacion.CentroIdUsuario.HasValue) || x.Candidatura.Usuario.CentroId == usuarioAplicacion.CentroIdUsuario.Value) &&
                                      x.Candidatura.EstadoCandidaturaId == (int)TipoEstadoCandidaturaEnum.SegundaEntrevista &&
                                      x.Candidatura.EtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.FeedbackSegundaEntrevista &&
                                      x.TipoEntrevistaId == (int)TipoEntrevistaEnum.SegundaEntrevista &&
                                      x.FechaEntrevista < pastWeek && x.FechaEntrevista > pastMonths).ToList();

            
            while (IteradorEstadosEmails.MoveNext())
            {
                
                foreach (var entrevista in ListEntrevistas)
                {
                    //CentroId = entrevista.Usuario.CentroId.Value;
                    CentroId = _usuarioService.GetUsuarioById(entrevista.EntrevistadorId.Value).UsuarioViewModel.CentroIdUsuario.Value;
                    var responsePlantilla = _correoPlantillaService.GetPlantillaIdByNombrePlantilla(DiccionarioFinalizarFeedback[IteradorEstadosEmails.Current.ToString()], CentroId);

                    if (responsePlantilla.IsValid)
                    {
                        if (!ExisteCorreo2(entrevista.CandidaturaId, responsePlantilla.PlantillaId))
                        {
                            var responseEmailEntrevistador = _candidaturaService.GetEmailEntrevistador(entrevista.EntrevistadorId.Value, tipoMedioContactoEmail);
                            var responseAsunto = _correoPlantillaVariableService.GetValorDefectoNombreVariablePlantillaCorreo(responsePlantilla.PlantillaId, NombresVariablesPlantillaCorreoEnum.Asunto.ToString());
                            var responseRemitente = _correoPlantillaVariableService.GetValorDefectoNombreVariablePlantillaCorreo(responsePlantilla.PlantillaId, NombresVariablesPlantillaCorreoEnum.Remitente.ToString());

                            //responseRemitente.VarlorDefecto = "diego.alberto.silguero@everis.com";
                            //responseEmailEntrevistador.EmailEntrevistador = "diego.garcia.alves.st@everis.com";
                            //responseEmailEntrevistador.EmailEntrevistador = "dgarcalv@gmail.com";

                            if (responseEmailEntrevistador.IsValid && responseAsunto.IsValid && responseRemitente.IsValid)
                            {

                                Correo correo = new Correo()
                                {
                                    PlantillaId = responsePlantilla.PlantillaId,
                                    Enviado = false,
                                    CandidaturaId = entrevista.CandidaturaId,
                                    Asunto = responseAsunto.VarlorDefecto,
                                    Remitente = responseRemitente.VarlorDefecto,
                                    TipoAviso = null,
                                    Destinatarios = responseEmailEntrevistador.EmailEntrevistador,
                                    IsActivo = true
                                };

                                var model = CorreoMapper.ConvertToCorreoRowViewModel(correo);
                                var responseSave = _correoService.SaveCorreo(model, usuarioAplicacion.UsuarioId);
                            }
                        }
                    }
                }

                foreach (var entrevista in ListSubEntrevistas)
                {
                    //CentroId = entrevista.Usuario.CentroId.Value;
                    CentroId = _usuarioService.GetUsuarioById(entrevista.EntrevistadorId.Value).UsuarioViewModel.CentroIdUsuario.Value;
                    var responsePlantilla = _correoPlantillaService.GetPlantillaIdByNombrePlantilla(DiccionarioFinalizarFeedback[IteradorEstadosEmails.Current.ToString()], CentroId);

                    if (responsePlantilla.IsValid)
                    {
                        if (!ExisteCorreo2(entrevista.CandidaturaId, responsePlantilla.PlantillaId))
                        {
                            var responseEmailEntrevistador = _candidaturaService.GetEmailEntrevistador(entrevista.EntrevistadorId.Value, tipoMedioContactoEmail);
                            var responseAsunto = _correoPlantillaVariableService.GetValorDefectoNombreVariablePlantillaCorreo(responsePlantilla.PlantillaId, NombresVariablesPlantillaCorreoEnum.Asunto.ToString());
                            var responseRemitente = _correoPlantillaVariableService.GetValorDefectoNombreVariablePlantillaCorreo(responsePlantilla.PlantillaId, NombresVariablesPlantillaCorreoEnum.Remitente.ToString());

                            //responseRemitente.VarlorDefecto = "diego.alberto.silguero@everis.com";
                            //responseEmailEntrevistador.EmailEntrevistador = "diego.garcia.alves.st@everis.com";
                            //responseEmailEntrevistador.EmailEntrevistador = "dgarcalv@gmail.com";

                            if (responseEmailEntrevistador.IsValid && responseAsunto.IsValid && responseRemitente.IsValid)
                            {

                                Correo correo = new Correo()
                                {
                                    PlantillaId = responsePlantilla.PlantillaId,
                                    Enviado = false,
                                    CandidaturaId = entrevista.CandidaturaId,
                                    Asunto = responseAsunto.VarlorDefecto,
                                    Remitente = responseRemitente.VarlorDefecto,
                                    TipoAviso = null,
                                    Destinatarios = responseEmailEntrevistador.EmailEntrevistador,
                                    IsActivo = true
                                };

                                var model = CorreoMapper.ConvertToCorreoRowViewModel(correo);
                                var responseSave = _correoService.SaveCorreo(model, usuarioAplicacion.UsuarioId);
                            }
                        }
                    }
                }
                
            }

            
            resultadoEnvio = resultadoEnvio.Append(ExecuteSendMailsRecordatorioFeedback(DiccionarioFinalizarFeedback, usuarioAplicacion.UsuarioId));
            return resultadoEnvio;

        }





        public StringBuilder EnviarAvisosEntrevistas(NameValueCollection DiccAvisoEntrevistaProgramada, NameValueCollection DiccConfiguracionServidorCorreo, int Notificaciones_DiasAntesEntrevista,
            int usuarioAplicacion, string urlRecruiting)
        {
            _DiccConfiguracionServidorCorreo = DiccConfiguracionServidorCorreo;
            int Centroid = 0;

            StringBuilder resultadoEnvio = new StringBuilder();

            int tipoMedioContactoEmail = GetTipoMedioContactoEmail();
            string[] nombresPlantilla = new string[] { "Entrevistador", "Candidato" };

            var IteradorAvisosEntrevistasEmails = DiccAvisoEntrevistaProgramada.AllKeys.GetEnumerator();
            while (IteradorAvisosEntrevistasEmails.MoveNext())
            {
                var response = _candidaturaService.GetCandidaturasByNombreEstadoCandidatura(IteradorAvisosEntrevistasEmails.Current.ToString());
                if (response.IsValid)
                {
                    foreach (var candidatura in response.CandidaturasViewModel)
                    {
                        if ((candidatura.PrimeraEntrevistaViewModel.AgendarPrimeraEntrevista != null && candidatura.PrimeraEntrevistaViewModel.AgendarPrimeraEntrevista.SubEntrevistaList != null
                            && candidatura.CandidaturaDatosBasicosViewModel.DatosBasicos.EtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.FeedbackPrimeraEntrevista) ||
                            (candidatura.SegundaEntrevistaViewModel.AgendarSegundaEntrevista != null && candidatura.SegundaEntrevistaViewModel.AgendarSegundaEntrevista.SubEntrevistaList != null
                            && candidatura.CandidaturaDatosBasicosViewModel.DatosBasicos.EtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.FeedbackSegundaEntrevista))
                        {
                            if ((candidatura.PrimeraEntrevistaViewModel.AgendarPrimeraEntrevista != null && candidatura.PrimeraEntrevistaViewModel.AgendarPrimeraEntrevista.SubEntrevistaList.Exists(x => x.SubEntrevistaId != null)) ||
                                (candidatura.SegundaEntrevistaViewModel.AgendarSegundaEntrevista != null && candidatura.SegundaEntrevistaViewModel.AgendarSegundaEntrevista.SubEntrevistaList.Exists(x => x.SubEntrevistaId != null)))
                            {
                                EnviaEmailsSubEntrevistadores(candidatura, Notificaciones_DiasAntesEntrevista, usuarioAplicacion);
                            }
                        }
                        //para cada candidatura creo un correo de su tipo de plantilla que le corresponda (tanto para el entrevistador como para el candidato
                        for (int i = 0; i <= 1; i++)
                        {
                            Centroid = _candidaturaService.GetCentroCandidatura(candidatura.CandidaturaId.Value).CentroId;
                            int? OficinaId = null;
                            string tipoAviso = IteradorAvisosEntrevistasEmails.Current.ToString();

                            if (IteradorAvisosEntrevistasEmails.Current.ToString() == "Entrevista")
                            {
                                OficinaId = (candidatura.PrimeraEntrevistaViewModel.AgendarPrimeraEntrevista != null) ? candidatura.PrimeraEntrevistaViewModel.AgendarPrimeraEntrevista.AgendarPrimeraEntrevista.OficinaId : null;
                            }
                            else if (IteradorAvisosEntrevistasEmails.Current.ToString() == "Entrevista Complementaria")
                            {
                                OficinaId = (candidatura.SegundaEntrevistaViewModel.AgendarSegundaEntrevista != null) ? candidatura.SegundaEntrevistaViewModel.AgendarSegundaEntrevista.AgendarSegundaEntrevista.OficinaId : null;
                            }
                            else if (IteradorAvisosEntrevistasEmails.Current.ToString() == "Carta Oferta")
                            {
                                OficinaId = (candidatura.CompletarCartaOfertaViewModel.EntregaCartaOfertaViewModel != null) ? candidatura.CompletarCartaOfertaViewModel.EntregaCartaOfertaViewModel.AgendarCartaOfertaViewModel.AgendarCartaOferta.OficinaId : null;
                            }

                            var responsePlantilla = _correoPlantillaService.GetPlantillaIdByNombrePlantilla(DiccAvisoEntrevistaProgramada[IteradorAvisosEntrevistasEmails.Current.ToString()] + nombresPlantilla[i], Centroid, OficinaId);

                            bool avisarAlCandidato = true;

                            if (candidatura.PrimeraEntrevistaViewModel.AgendarPrimeraEntrevista != null
                                && candidatura.PrimeraEntrevistaViewModel.AgendarPrimeraEntrevista.AgendarPrimeraEntrevista.AvisarAlCandidato == false
                                && IteradorAvisosEntrevistasEmails.Current.ToString() == "Entrevista")
                            {
                                avisarAlCandidato = false;
                            }
                            if (candidatura.SegundaEntrevistaViewModel.AgendarSegundaEntrevista != null
                            && candidatura.SegundaEntrevistaViewModel.AgendarSegundaEntrevista.AgendarSegundaEntrevista.AvisarAlCandidato == false
                            && IteradorAvisosEntrevistasEmails.Current.ToString() == "Entrevista Complementaria")
                            {
                                avisarAlCandidato = false;
                            }

                            if (responsePlantilla.IsValid && !(i == 1 && !avisarAlCandidato))
                            {
                                //se comprueba que no existe ya un correo (enviado o no para esa candidatura en el mismo estado para no andar reenviaando correos
                                if (!ExisteCorreo(candidatura.CandidaturaId.Value, responsePlantilla.PlantillaId, tipoAviso: tipoAviso))
                                {
                                    var responseEmailCandidato = _candidatoService.GetEmailCandidato(candidatura.CandidaturaDatosBasicosViewModel.DatosBasicos.CandidatoId, tipoMedioContactoEmail);
                                    var responseAsunto = _correoPlantillaVariableService.GetValorDefectoNombreVariablePlantillaCorreo(responsePlantilla.PlantillaId, NombresVariablesPlantillaCorreoEnum.Asunto.ToString());
                                    var responseRemitente = _correoPlantillaVariableService.GetValorDefectoNombreVariablePlantillaCorreo(responsePlantilla.PlantillaId, NombresVariablesPlantillaCorreoEnum.Remitente.ToString());


                                    if (responseEmailCandidato.IsValid && responseAsunto.IsValid && responseRemitente.IsValid && responseRemitente.VarlorDefecto != "" && responseEmailCandidato.EmailCandidato != "")
                                    {
                                        Correo correo = new Correo()
                                        {
                                            PlantillaId = responsePlantilla.PlantillaId,
                                            Enviado = false,
                                            CandidaturaId = candidatura.CandidaturaId,
                                            Asunto = responseAsunto.VarlorDefecto,
                                            Remitente = responseRemitente.VarlorDefecto,
                                            TipoAviso = tipoAviso,
                                            IsActivo = true
                                        };

                                        if (i == 1)
                                        { //el destinatario es el candidato
                                            correo.Destinatarios = responseEmailCandidato.EmailCandidato;
                                        }
                                        else
                                        { //el destinatario es el entrevistador

                                            if (candidatura.CandidaturaDatosBasicosViewModel.DatosBasicos.EtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.FeedbackPrimeraEntrevista)
                                            {
                                                if (candidatura.PrimeraEntrevistaViewModel != null)
                                                {
                                                    correo.Destinatarios = _usuarioService.GetUsuarioById((int)candidatura.PrimeraEntrevistaViewModel.AgendarPrimeraEntrevista.AgendarPrimeraEntrevista.EntrevistadorId).UsuarioViewModel.Email;
                                                }
                                            }
                                            else if (candidatura.CandidaturaDatosBasicosViewModel.DatosBasicos.EtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.FeedbackSegundaEntrevista)
                                            {
                                                if (candidatura.SegundaEntrevistaViewModel != null)
                                                {
                                                    correo.Destinatarios = _usuarioService.GetUsuarioById((int)candidatura.SegundaEntrevistaViewModel.AgendarSegundaEntrevista.AgendarSegundaEntrevista.EntrevistadorId).UsuarioViewModel.Email;
                                                }
                                            }
                                            else if (candidatura.CandidaturaDatosBasicosViewModel.DatosBasicos.EtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.FeedbackCartaOferta)
                                            {
                                                if (candidatura.CompletarCartaOfertaViewModel != null)
                                                {
                                                    correo.Destinatarios = _usuarioService.GetUsuarioById((int)candidatura.CompletarCartaOfertaViewModel.EntregaCartaOfertaViewModel.AgendarCartaOfertaViewModel.AgendarCartaOferta.EntrevistadorId).UsuarioViewModel.Email;
                                                }
                                            }

                                        }


                                        //antes de crear el correo se comprueba si la fecha de la entrevista esta dentro del rango donde se tiene que avisar
                                        if (SaveNotification(candidatura, Notificaciones_DiasAntesEntrevista))
                                        {
                                            var model = CorreoMapper.ConvertToCorreoRowViewModel(correo);
                                            var responseSave = _correoService.SaveCorreo(model, usuarioAplicacion);

                                            //se crea una bitacora indicando que se ha programado el envio de email
                                            var bitacoraResponse = _bitacoraService.GenerateBitacoraCorreo(candidatura.CandidaturaId.Value, "Programado envio de correo.");

                                            response.IsValid = response.IsValid && bitacoraResponse.IsValid;
                                            if (!string.IsNullOrWhiteSpace(bitacoraResponse.ErrorMessage))
                                            {
                                                response.ErrorMessage = bitacoraResponse.ErrorMessage;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    resultadoEnvio.AppendLine(DateTime.Now.ToString() + ":No se ha obtenenido la plantilla " + DiccAvisoEntrevistaProgramada[IteradorAvisosEntrevistasEmails.Current.ToString()] + " para el centro " + Centroid.ToString());
                }
            }
            //por ultimo se envian los email pasando el diccionario con los datos para la firma del centro correspondiente a la 
            resultadoEnvio = resultadoEnvio.Append(ExecuteSendMailsAvisosEntrevistas(DiccAvisoEntrevistaProgramada, usuarioAplicacion, urlRecruiting));
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

        private SchedulerExecutionResultEnum SendEmailMeeting(string remitenteCorreo, List<string> destinatariosCorreo, string asuntoCorreo, string Body, byte[] attachment, string NombreCVAttachment)
        {
            try
            {
                if (_DiccConfiguracionServidorCorreo == null)
                {
                    _DiccConfiguracionServidorCorreo = (System.Collections.Specialized.NameValueCollection)ConfigurationManager.GetSection("DiccConfiguracionServidorCorreo");
                }
                MailMessage msg = new MailMessage();
                foreach (var destinatario in destinatariosCorreo)
                {
                    msg.To.Add(destinatario);
                }
                msg.From = new MailAddress(remitenteCorreo);
                msg.Subject = asuntoCorreo;
                msg.Bcc.Add(remitenteCorreo);
                msg.Body = Body;
                msg.SubjectEncoding = System.Text.Encoding.UTF8;
                msg.BodyEncoding = System.Text.Encoding.UTF8;
                msg.IsBodyHtml = true;    //Se va a enviar un correo con contenido html
                if(attachment != null && NombreCVAttachment != null)
                {
                    msg.Attachments.Add(new Attachment(new MemoryStream(attachment), NombreCVAttachment));
                }

                SmtpClient client = new SmtpClient();
                client.DeliveryMethod = SmtpDeliveryMethod.Network;

                client.Port = Convert.ToInt16(_DiccConfiguracionServidorCorreo["Port"]); // 25; 
                client.Host = _DiccConfiguracionServidorCorreo["Host"];                  //"10.108.22.43"; 
                client.UseDefaultCredentials = Convert.ToBoolean(_DiccConfiguracionServidorCorreo["UseDefaultCredentials"]);//true;

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

        public EnviarNotificacionesCandidaturasResponse EnviarNotificacionesCandidaturas(int candidaturaId, int candidatoId, string destinatario, string asunto, string mensajeNotificacion, int? centro)
        {
            var response = new EnviarNotificacionesCandidaturasResponse();

            var plantilla = _correoPlantillaService.GetPlantillaCorreoByNombreCentroId(asunto, centro);
            if (!plantilla.IsValid)
            {
                plantilla = _correoPlantillaService.GetPlantillaCorreoByNombreCentroId(asunto, null);
            }
           
            CorreoPlantillaVariable cpv = new CorreoPlantillaVariable()
            {
                PlantillaId = plantilla.correoPlantilla.PlantillaId,
            };
            var responseRemitente = _correoPlantillaVariableService.GetValorDefectoNombreVariablePlantillaCorreo(plantilla.correoPlantilla.PlantillaId, NombresVariablesPlantillaCorreoEnum.Remitente.ToString());
            var responseImagenCabecera = _correoPlantillaVariableService.GetValorDefectoNombreVariablePlantillaCorreo(plantilla.correoPlantilla.PlantillaId, NombresVariablesPlantillaCorreoEnum.LogoCabecera.ToString());
            var responseAsunto = _correoPlantillaVariableService.GetValorDefectoNombreVariablePlantillaCorreo(plantilla.correoPlantilla.PlantillaId, NombresVariablesPlantillaCorreoEnum.Asunto.ToString());                
            var responseImagenFirma = _correoPlantillaVariableService.GetValorDefectoNombreVariablePlantillaCorreo(plantilla.correoPlantilla.PlantillaId, NombresVariablesPlantillaCorreoEnum.imagenFirma.ToString());                
            var candidato = _candidatoService.GetCandidatoById(candidatoId);
            var nombreCandidato = candidato.CandidatoViewModel.Nombres + " " + candidato.CandidatoViewModel.Apellidos;
            var asuntoCompleto = responseAsunto.VarlorDefecto + " Candidatura " + candidaturaId + " Candidato " + nombreCandidato;
            var cr = CorreoPlantillaVariableMapper.ConvertToCorreoPlantillaVariableRowViewModel(cpv, responseAsunto.VarlorDefecto, responseRemitente.VarlorDefecto, "", responseImagenFirma.VarlorDefecto, responseImagenCabecera.VarlorDefecto, "", "", "", "", "", "", "", null, "", candidaturaId, "", mensajeNotificacion, nombreCandidato);
            string body = GetBodyMail(plantilla.correoPlantilla.TextoPlantilla, cr);
            SendEmail(responseRemitente.VarlorDefecto, destinatario, asuntoCompleto, body);
            response.IsValid = true;           



            return response;
        }

        public GetTextoFormateadoMeetingResponse EnviarNotificacionesCandidaturasMeeting(SendMeetingViewModel model, CreateEditCandidatoViewModel candidato, string asunto, List<string> dest, string from, byte[] CV, string NombreCV)
        {
            var response = new GetTextoFormateadoMeetingResponse();

            var plantillaCorreoDatos = _correoPlantillaService.GetPlantillaIdByNombrePlantilla("MeetingDatos", model.CentroId, model.OficinaId);
            if (!plantillaCorreoDatos.IsValid)
            {
                response.IsValid = false;
                response.ErrorMessage = "No se ha encontrado la plantilla para enviar la meeting";               
            }
            var correoDatos = _correoPlantillaService.GetPlantillaCorreoById(plantillaCorreoDatos.PlantillaId);
            if (!correoDatos.IsValid)
            {
                response.IsValid = false;
                response.ErrorMessage = "No se ha encontrado la plantilla para enviar la meeting";                
            }

            var test = correoDatos.correoPlantilla.TextoPlantilla;

            var variables = JoinVariablesMeeting(model, candidato);

            var body = GetBodyMailMeetingDatos(test, variables);

            if (SendEmailMeeting(from, dest, asunto, body, CV, NombreCV) == SchedulerExecutionResultEnum.Enviado_OK)
            {
                response.IsValid = true;
            }
            else
            {
                response.IsValid = false;
                response.ErrorMessage = "No se ha podido enviar el mensaje";
            }
            return response;
        }

        private VariablesMeetingViewModel JoinVariablesMeeting(SendMeetingViewModel model, CreateEditCandidatoViewModel candidato)
        {
            var response = new VariablesMeetingViewModel();
            ICandidatoContactoRepository _candidatoContactoRepository = new CandidatoContactoRepository();

            response.NombreEntrevistador = model.Entrevistador;
            response.Sala = model.EmailSala;
            response.Fecha = model.Fecha.ToString();

            response.NombreCandidato = string.Concat(candidato.Nombres, " ", candidato.Apellidos);

            if (_candidatoContactoRepository.GetByCriteria(x => x.IsActivo && x.CandidatoId == candidato.CandidatoId && x.TipoMedioContactoId == (int)TipoContactoEnum.Email).Any())
            {
                response.EmailCandidato = _candidatoContactoRepository.GetOne(x => x.IsActivo && x.CandidatoId == candidato.CandidatoId && x.TipoMedioContactoId == (int)TipoContactoEnum.Email).Contacto;
            }
            if(_candidatoContactoRepository.GetByCriteria(x => x.IsActivo && x.CandidatoId == candidato.CandidatoId && x.TipoMedioContactoId == (int)TipoContactoEnum.Telefono).Any())
            {
                response.TelefonoCandidato = _candidatoContactoRepository.GetOne(x => x.IsActivo && x.CandidatoId == candidato.CandidatoId && x.TipoMedioContactoId == (int)TipoContactoEnum.Telefono).Contacto;
            }
            response.MensajeSubEntrevistas = model.MensajeSubEntrevistas;

            return response;
        }

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

        private bool ExisteCorreo(int CandidaturaId, int PlantillaId, int? SubEntrevistaId = null, string tipoAviso = null)
        {
            bool existeCorreo = false;

            var response = _correoService.GetCorreoByCandidaturaPlantilla(CandidaturaId, PlantillaId, SubEntrevistaId, tipoAviso);
            if (response.IsValid)
            {
                return response.TotalElementos > 0;
            }
            return existeCorreo;

        }

        private bool ExisteCorreo2(int CandidaturaId, int PlantillaId, int? SubEntrevistaId = null, string tipoAviso = null)
        {
            bool existeCorreo = false;

            var response = _correoService.GetCorreoByCandidaturaPlantilla(CandidaturaId, PlantillaId, SubEntrevistaId, tipoAviso);
            if (response.IsValid)
            {
                foreach(var correo in response.Correos)
                {
                    if (!correo.Enviado)
                        existeCorreo = true;
                }
            }
            return existeCorreo;

        }


        private StringBuilder ExecuteSendMailsEstadosCandidatura(NameValueCollection DiccEstadoCandidaturaPlantillaCorreo, int usuarioAplicacion)
        {
            var responseCorreos = _correoService.GetCorreosPendientesEnvio();
            var resultadoEjecucion = new StringBuilder();

            if (responseCorreos.IsValid)
            {
                foreach (var correo in responseCorreos.Correos)
                {
                    var response = _correoPlantillaService.GetPlantillaCorreoById(correo.PlantillaId);
                    if (response.IsValid)
                    {
                        //si la plantilla del correo es de aviso de entrevista para el candidato o el entrevistador
                        if (ContienePlantilla(DiccEstadoCandidaturaPlantillaCorreo, response.correoPlantilla.NombrePlantilla) ||
                            ContienePlantilla(DiccEstadoCandidaturaPlantillaCorreo, response.correoPlantilla.NombrePlantilla))
                        {

                            ///para cada candidatura creo un correo de su tipo de plantilla que le corresponda
                            var responseEmailCandidato = correo.Destinatarios;
                            var responseImagenCabecera = _correoPlantillaVariableService.GetValorDefectoNombreVariablePlantillaCorreo(correo.PlantillaId, NombresVariablesPlantillaCorreoEnum.LogoCabecera.ToString());
                            var responseImagenFirma = _correoPlantillaVariableService.GetValorDefectoNombreVariablePlantillaCorreo(correo.PlantillaId, NombresVariablesPlantillaCorreoEnum.imagenFirma.ToString());
                            var Candidato = _candidaturaService.GetCandidatoByCandidatura(correo.CandidaturaId).CreateEditCandidatoViewModel;
                            string nombreCandidato = string.Concat(Candidato.Nombres, " ", Candidato.Apellidos);
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
                                _correoService.SaveCorreo(correo, usuarioAplicacion);

                                //se crea la bitacora indicando que se ha realizado el envio de email
                                var bitacoraResponse = _bitacoraService.GenerateBitacoraCorreo(correo.CandidaturaId, "Envio de correo realizado con exito.");

                                response.IsValid = response.IsValid && bitacoraResponse.IsValid;
                                if (!string.IsNullOrWhiteSpace(bitacoraResponse.ErrorMessage))
                                {
                                    response.ErrorMessage = bitacoraResponse.ErrorMessage;
                                }
                            }
                            else
                            {
                                //se crea el mensaje para guaradarlo en el log
                                resultadoEjecucion.AppendLine(DateTime.Now.ToString() + ":ERROR al enviar correo a destinatario " + correo.Destinatarios);
                            }
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


        private StringBuilder ExecuteSendMailsRecordatorioFeedback(NameValueCollection DiccEstadoCandidaturaPlantillaCorreo, int usuarioAplicacion)
        {
            var responseCorreos = _correoService.GetCorreosPendientesEnvio();
            var resultadoEjecucion = new StringBuilder();

            if (responseCorreos.IsValid)
            {
                foreach (var correo in responseCorreos.Correos)
                {
                    var response = _correoPlantillaService.GetPlantillaCorreoById(correo.PlantillaId);
                    if (response.IsValid)
                    {
                        //si la plantilla del correo es de aviso de entrevista para el candidato o el entrevistador
                        if (ContienePlantilla(DiccEstadoCandidaturaPlantillaCorreo, response.correoPlantilla.NombrePlantilla) ||
                            ContienePlantilla(DiccEstadoCandidaturaPlantillaCorreo, response.correoPlantilla.NombrePlantilla))
                        {

                            ///para cada candidatura creo un correo de su tipo de plantilla que le corresponda
                            var responseEmailCandidato = correo.Destinatarios;
                            var responseImagenCabecera = _correoPlantillaVariableService.GetValorDefectoNombreVariablePlantillaCorreo(correo.PlantillaId, NombresVariablesPlantillaCorreoEnum.LogoCabecera.ToString());
                            var responseImagenFirma = _correoPlantillaVariableService.GetValorDefectoNombreVariablePlantillaCorreo(correo.PlantillaId, NombresVariablesPlantillaCorreoEnum.imagenFirma.ToString());
                            var candidatura = _candidaturaService.GetCandidaturaById(correo.CandidaturaId);
                            var Candidato = _candidaturaService.GetCandidatoByCandidatura(correo.CandidaturaId).CreateEditCandidatoViewModel;
                            var entrevistas = _entrevistaRepository.GetByCriteria(x => x.CandidaturaId == candidatura.CandidaturaViewModel.CandidaturaId);

                            string nombreCandidato = string.Concat(Candidato.Nombres, " ", Candidato.Apellidos);
                            string nombreEntrevistador = _usuarioService.GetUsuarioByEmail(correo.Destinatarios).UsuarioViewModel.Usuario;
                            string urlRecruiting = ""; //
                            string tipoEntrevista = "";


                            var fechaEntrevista = new DateTime();
                            

                            foreach (var e in entrevistas) {
                                fechaEntrevista = e.FechaEntrevista;
                                tipoEntrevista = e.TipoEntrevistaId == 1 ? "entrevista" : "entrevista complementaria";
                                urlRecruiting = e.TipoEntrevistaId == 1 ? Url_Candidaturas_Completar_Primera_Entrevista + e.CandidaturaId  
                                                                        : Url_Candidaturas_Completar_Segunda_Entrevista + e.CandidaturaId;
                            }

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
                                   lineaEmail, lineaWeb, nombreEntrevistador, fechaEntrevista, tipoEntrevista, correo.CandidaturaId, urlRecruiting, null,nombreCandidato);

                            string body = GetBodyMail(response.correoPlantilla.TextoPlantilla, cr);

                            //se crea el correo en si y se envia
                            if (SendEmail(correo.Remitente, correo.Destinatarios, correo.Asunto, body) == SchedulerExecutionResultEnum.Enviado_OK)
                            {
                                //se crea el mensaje para guaradarlo en el log
                                resultadoEjecucion.AppendLine(DateTime.Now.ToString() + ":Enviado correo OK a destinatario " + correo.Destinatarios);


                                //se actualiza a enviado=true y fecha Envio
                                correo.Enviado = true;
                                correo.FechaEnvio = ModifiableEntityHelper.GetCurrentDate();
                                _correoService.SaveCorreo(correo, usuarioAplicacion);

                                //se crea la bitacora indicando que se ha realizado el envio de email
                                var bitacoraResponse = _bitacoraService.GenerateBitacoraCorreo(correo.CandidaturaId, "Envio de correo realizado con exito.");

                                response.IsValid = response.IsValid && bitacoraResponse.IsValid;
                                if (!string.IsNullOrWhiteSpace(bitacoraResponse.ErrorMessage))
                                {
                                    response.ErrorMessage = bitacoraResponse.ErrorMessage;
                                }
                            }
                            else
                            {
                                //se crea el mensaje para guaradarlo en el log
                                resultadoEjecucion.AppendLine(DateTime.Now.ToString() + ":ERROR al enviar correo a destinatario " + correo.Destinatarios);
                            }
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

        public string GetBodyMailMeetingDatos(string TextoPlantilla, VariablesMeetingViewModel model)
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
                            var propiedad2 = model.GetType().GetProperty(nombreParametro);
                            if (propiedad2 != null)
                            {
                                valor = propiedad2.GetValue(model) != null ? propiedad2.GetValue(model).ToString() : string.Empty;
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

        private bool ContienePlantilla(NameValueCollection DiccPlantillas, string nombrePlantilla)
        {
            bool encontrado = false;
            var iteradorDiccionario = DiccPlantillas.AllKeys.GetEnumerator();
            while (iteradorDiccionario.MoveNext() && !encontrado)
            {
                encontrado = DiccPlantillas[iteradorDiccionario.Current.ToString()] == nombrePlantilla;
            }
            return encontrado;
        }

        private StringBuilder ExecuteSendMailsAvisosEntrevistas(NameValueCollection DiccAvisoEntrevistaProgramada, int usuarioAplicacion, string urlRecruiting)
        {
            var resultadoEjecucion = new StringBuilder();
            var responseCorreos = _correoService.GetCorreosPendientesEnvio();

            if (responseCorreos.IsValid)
            {
                foreach (var correo in responseCorreos.Correos)
                {
                    var response = _correoPlantillaService.GetPlantillaCorreoById(correo.PlantillaId);
                    if (response.IsValid)
                    {
                        //si la plantilla del correo es de aviso de entrevista para el candidato o el entrevistador
                        if (ContienePlantilla(DiccAvisoEntrevistaProgramada, response.correoPlantilla.NombrePlantilla.Replace("Entrevistador", "")) ||
                            ContienePlantilla(DiccAvisoEntrevistaProgramada, response.correoPlantilla.NombrePlantilla.Replace("Candidato", "")))
                        {
                            ////para cada candidatura creo un correo de su tipo de plantilla que le corresponda
                            var responseEmailCandidato = correo.Destinatarios;
                            var responseImagenCabecera = _correoPlantillaVariableService.GetValorDefectoNombreVariablePlantillaCorreo(correo.PlantillaId, NombresVariablesPlantillaCorreoEnum.LogoCabecera.ToString());
                            var responseImagenFirma = _correoPlantillaVariableService.GetValorDefectoNombreVariablePlantillaCorreo(correo.PlantillaId, NombresVariablesPlantillaCorreoEnum.imagenFirma.ToString());
                            var Candidato = _candidaturaService.GetCandidatoByCandidatura(correo.CandidaturaId).CreateEditCandidatoViewModel;
                            string nombreCandidato = string.Concat(Candidato.Nombres, " ", Candidato.Apellidos);
                            CorreoPlantillaVariable cpv = new CorreoPlantillaVariable()
                            {
                                PlantillaId = correo.PlantillaId,
                            };

                            var candidatura = _candidaturaService.GetCandidaturaById(correo.CandidaturaId);
                            if (candidatura.IsValid)
                            {
                                CorreoPlantillaVariableRowViewModel cr = null;

                                string lineaTituloPie = _correoPlantillaVariableService.GetValorDefectoNombreVariablePlantillaCorreo(correo.PlantillaId, "LineaTituloPie").VarlorDefecto;
                                string lineaDireccion = _correoPlantillaVariableService.GetValorDefectoNombreVariablePlantillaCorreo(correo.PlantillaId, "LineaDireccion").VarlorDefecto;
                                string lineaProvincia = _correoPlantillaVariableService.GetValorDefectoNombreVariablePlantillaCorreo(correo.PlantillaId, "LineaProvincia").VarlorDefecto;
                                string lineaTelefono = _correoPlantillaVariableService.GetValorDefectoNombreVariablePlantillaCorreo(correo.PlantillaId, "LineaTelefono").VarlorDefecto;
                                string lineaEmail = _correoPlantillaVariableService.GetValorDefectoNombreVariablePlantillaCorreo(correo.PlantillaId, "LineaEmail").VarlorDefecto;
                                string lineaWeb = _correoPlantillaVariableService.GetValorDefectoNombreVariablePlantillaCorreo(correo.PlantillaId, "LineaWeb").VarlorDefecto;


                                if (candidatura.CandidaturaViewModel.CandidaturaDatosBasicosViewModel.DatosBasicos.EtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.FeedbackPrimeraEntrevista)
                                {
                                    if (candidatura.CandidaturaViewModel.PrimeraEntrevistaViewModel != null)
                                    {
                                        if (correo.SubEntrevistaId != null)
                                        {
                                            string tipoSubentrevista = "";
                                            var subEntrevista = _candidaturaService.GetListaSubEntrevistas(candidatura.CandidaturaViewModel.CandidaturaId.Value, 1).ListaSubEntrevistas.Find(x => x.SubEntrevistaId == correo.SubEntrevistaId);

                                            if(subEntrevista != null)
                                            {
                                                switch (subEntrevista.TipoSubEntrevistaId)
                                                {
                                                    case (int)TipoSubEntrevistaEnum.Competencial:
                                                        tipoSubentrevista = "SubEntrevista Competencial";
                                                        break;
                                                    case (int)TipoSubEntrevistaEnum.Tecnica:
                                                        tipoSubentrevista = "SubEntrevista Tecnica";
                                                        break;
                                                    case (int)TipoSubEntrevistaEnum.Gerente:
                                                        tipoSubentrevista = "SubEntrevista Gerente";
                                                        break;
                                                    case (int)TipoSubEntrevistaEnum.Idioma:
                                                        tipoSubentrevista = "Prueba Idiomas";
                                                        break;
                                                    default:
                                                        tipoSubentrevista = (subEntrevista.TipoSubEntrevistaId != null) ? "Tipo no registrado en la base de datos" : "error";
                                                        break;
                                                }
                                                cr = CorreoPlantillaVariableMapper.ConvertToCorreoPlantillaVariableRowViewModel(cpv, correo.Asunto, correo.Remitente,
                                                         nombreCandidato, responseImagenFirma.VarlorDefecto, responseImagenCabecera.VarlorDefecto,
                                                         lineaTituloPie, lineaDireccion, lineaProvincia, lineaTelefono, lineaEmail, lineaWeb,
                                                          subEntrevista.EntrevistadorName,
                                                          subEntrevista.FechaSubEntrevista,
                                                         tipoSubentrevista, candidatura.CandidaturaViewModel.CandidaturaId.Value, urlRecruiting);
                                            }                                          
                                        }
                                        else
                                        {
                                            cr = CorreoPlantillaVariableMapper.ConvertToCorreoPlantillaVariableRowViewModel(cpv, correo.Asunto, correo.Remitente,
                                             nombreCandidato, responseImagenFirma.VarlorDefecto, responseImagenCabecera.VarlorDefecto,
                                             lineaTituloPie, lineaDireccion, lineaProvincia, lineaTelefono, lineaEmail, lineaWeb,
                                              candidatura.CandidaturaViewModel.PrimeraEntrevistaViewModel.AgendarPrimeraEntrevista.AgendarPrimeraEntrevista.EntrevistadorName,
                                              candidatura.CandidaturaViewModel.PrimeraEntrevistaViewModel.AgendarPrimeraEntrevista.AgendarPrimeraEntrevista.FechaEntrevista,
                                             "Entrevista Principal", candidatura.CandidaturaViewModel.CandidaturaId.Value, urlRecruiting);
                                        }
                                    }
                                }
                                else if (candidatura.CandidaturaViewModel.CandidaturaDatosBasicosViewModel.DatosBasicos.EtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.FeedbackSegundaEntrevista)
                                {
                                    if (candidatura.CandidaturaViewModel.SegundaEntrevistaViewModel != null)
                                    {
                                        if (correo.SubEntrevistaId != null)
                                        {
                                            string tipoSubentrevista = "";
                                            var subEntrevista = _candidaturaService.GetListaSubEntrevistas(candidatura.CandidaturaViewModel.CandidaturaId.Value, 2).ListaSubEntrevistas.Find(x => x.SubEntrevistaId == correo.SubEntrevistaId);

                                            if(subEntrevista != null)
                                            {
                                                switch (subEntrevista.TipoSubEntrevistaId)
                                                {
                                                    case (int)TipoSubEntrevistaEnum.Competencial:
                                                        tipoSubentrevista = "SubEntrevista Competencial";
                                                        break;
                                                    case (int)TipoSubEntrevistaEnum.Tecnica:
                                                        tipoSubentrevista = "SubEntrevista Tecnica";
                                                        break;
                                                    case (int)TipoSubEntrevistaEnum.Gerente:
                                                        tipoSubentrevista = "SubEntrevista Gerente";
                                                        break;
                                                    case (int)TipoSubEntrevistaEnum.Idioma:
                                                        tipoSubentrevista = "Prueba Idiomas";
                                                        break;
                                                    default:
                                                        tipoSubentrevista = (subEntrevista.TipoSubEntrevistaId != null) ? "Tipo no registrado en la base de datos" : "error";
                                                        break;
                                                }

                                                cr = CorreoPlantillaVariableMapper.ConvertToCorreoPlantillaVariableRowViewModel(cpv, correo.Asunto, correo.Remitente,
                                                     nombreCandidato, responseImagenFirma.VarlorDefecto, responseImagenCabecera.VarlorDefecto,
                                                     lineaTituloPie, lineaDireccion, lineaProvincia, lineaTelefono, lineaEmail, lineaWeb,
                                                      subEntrevista.EntrevistadorName,
                                                      subEntrevista.FechaSubEntrevista,
                                                     tipoSubentrevista, candidatura.CandidaturaViewModel.CandidaturaId.Value, urlRecruiting);
                                            }                                            
                                            
                                        }
                                        else
                                        {
                                            cr = CorreoPlantillaVariableMapper.ConvertToCorreoPlantillaVariableRowViewModel(cpv, correo.Asunto, correo.Remitente,
                                             nombreCandidato, responseImagenFirma.VarlorDefecto, responseImagenCabecera.VarlorDefecto,
                                              lineaTituloPie, lineaDireccion, lineaProvincia, lineaTelefono, lineaEmail, lineaWeb,
                                             candidatura.CandidaturaViewModel.SegundaEntrevistaViewModel.AgendarSegundaEntrevista.AgendarSegundaEntrevista.EntrevistadorName,
                                             candidatura.CandidaturaViewModel.SegundaEntrevistaViewModel.AgendarSegundaEntrevista.AgendarSegundaEntrevista.FechaEntrevista,
                                              "Entrevista Complementaria", candidatura.CandidaturaViewModel.CandidaturaId.Value, urlRecruiting);
                                        }
                                    }
                                }
                                else if (candidatura.CandidaturaViewModel.CandidaturaDatosBasicosViewModel.DatosBasicos.EtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.FeedbackCartaOferta)
                                {
                                    if (candidatura.CandidaturaViewModel.CompletarCartaOfertaViewModel.EntregaCartaOfertaViewModel != null)
                                    {
                                        cr = CorreoPlantillaVariableMapper.ConvertToCorreoPlantillaVariableRowViewModel(cpv, correo.Asunto, correo.Remitente,
                                             nombreCandidato, responseImagenFirma.VarlorDefecto, responseImagenCabecera.VarlorDefecto,
                                             lineaTituloPie, lineaDireccion, lineaProvincia, lineaTelefono, lineaEmail, lineaWeb,
                                             candidatura.CandidaturaViewModel.CompletarCartaOfertaViewModel.EntregaCartaOfertaViewModel.AgendarCartaOfertaViewModel.AgendarCartaOferta.EntrevistadorName,
                                             candidatura.CandidaturaViewModel.CompletarCartaOfertaViewModel.EntregaCartaOfertaViewModel.AgendarCartaOfertaViewModel.AgendarCartaOferta.FechaAgendarCarta,
                                              "Entrega Carta Oferta", candidatura.CandidaturaViewModel.CandidaturaId.Value, urlRecruiting);
                                    }
                                }

                                if (cr != null)
                                {
                                    string body = GetBodyMail(response.correoPlantilla.TextoPlantilla, cr);

                                    //se crea el correo en si y se envia
                                    if (SendEmail(correo.Remitente, correo.Destinatarios, correo.Asunto, body) == SchedulerExecutionResultEnum.Enviado_OK)
                                    {
                                        //se crea el mensaje para guaradarlo en el log
                                        resultadoEjecucion.AppendLine(DateTime.Now.ToString() + ":Enviado correo OK a destinatario " + correo.Destinatarios);
                                        //se actualiza a enviado=true y fecha Envio
                                        correo.Enviado = true;
                                        correo.FechaEnvio = ModifiableEntityHelper.GetCurrentDate();
                                        _correoService.SaveCorreo(correo, usuarioAplicacion);
                                    }
                                    else
                                    {
                                        //se crea el mensaje para guaradarlo en el log
                                        resultadoEjecucion.AppendLine(DateTime.Now.ToString() + ":ERROR al enviar correo a destinatario " + correo.Destinatarios);
                                    }
                                }
                            }

                        }
                    }
                    else
                    {
                        //se crea el mensaje para guaradarlo en el log
                        resultadoEjecucion.AppendLine("Error al obtener la plantilla " + response.correoPlantilla.NombrePlantilla);
                    }
                }
            }
            else
            {
                //se crea el mensaje para guaradarlo en el log
                resultadoEjecucion.AppendLine("Error al obtener los correos pendientes de envío");
            }
            return resultadoEjecucion;
        }

        private bool SaveNotification(CandidaturaViewModel candidatura, int diasAviso)
        {

            if (candidatura.CandidaturaDatosBasicosViewModel.DatosBasicos.EtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.FeedbackPrimeraEntrevista)
            {
                if (candidatura.PrimeraEntrevistaViewModel != null)
                {
                    if (candidatura.PrimeraEntrevistaViewModel.AgendarPrimeraEntrevista.AgendarPrimeraEntrevista.FechaEntrevista.HasValue)
                    {
                        return candidatura.PrimeraEntrevistaViewModel.AgendarPrimeraEntrevista.AgendarPrimeraEntrevista.FechaEntrevista.Value.Date.Subtract(System.DateTime.Now.Date).Days == diasAviso;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else if (candidatura.CandidaturaDatosBasicosViewModel.DatosBasicos.EtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.FeedbackSegundaEntrevista)
            {
                if (candidatura.SegundaEntrevistaViewModel != null)
                {
                    if (candidatura.SegundaEntrevistaViewModel.AgendarSegundaEntrevista.AgendarSegundaEntrevista.FechaEntrevista.HasValue)
                    {
                        return candidatura.SegundaEntrevistaViewModel.AgendarSegundaEntrevista.AgendarSegundaEntrevista.FechaEntrevista.Value.Date.Subtract(System.DateTime.Now.Date).Days == diasAviso;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else if (candidatura.CandidaturaDatosBasicosViewModel.DatosBasicos.EtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.FeedbackCartaOferta)
            {
                if (candidatura.CompletarCartaOfertaViewModel.EntregaCartaOfertaViewModel.AgendarCartaOfertaViewModel != null)
                {
                    if (candidatura.CompletarCartaOfertaViewModel.EntregaCartaOfertaViewModel.AgendarCartaOfertaViewModel.AgendarCartaOferta.FechaAgendarCarta.HasValue)
                    {
                        return candidatura.CompletarCartaOfertaViewModel.EntregaCartaOfertaViewModel.AgendarCartaOfertaViewModel.AgendarCartaOferta.FechaAgendarCarta.Value.Date.Subtract(System.DateTime.Now.Date).Days == diasAviso;
                    }
                    else
                    {
                        return false;
                    }

                }
            }

            return false;



        }

        private bool SaveNotification(SubEntrevistaViewModel subEntrevista, int diasAviso)
        {

            if (subEntrevista.SubEntrevistaId != null && !subEntrevista.Completada)
            {
                return subEntrevista.FechaSubEntrevista.Value.Date.Subtract(System.DateTime.Now.Date).Days == diasAviso;
            }

            return false;
        }

        private void EnviaEmailsSubEntrevistadores(CandidaturaViewModel candidatura, int Notificaciones_DiasAntesEntrevista, int usuarioAplicacion)
        {
            int tipoMedioContactoEmail = GetTipoMedioContactoEmail();
            string tipoAviso = "SubEntrevista";

            var Centroid = _candidaturaService.GetCentroCandidatura(candidatura.CandidaturaId.Value).CentroId;

            int? OficinaId = candidatura.PrimeraEntrevistaViewModel.AgendarPrimeraEntrevista.AgendarPrimeraEntrevista.OficinaId;

            var responsePlantilla = _correoPlantillaService.GetPlantillaIdByNombrePlantilla("AvisoEntrevistaEntrevistador", Centroid, OficinaId);
            var responsePlantillaCandidato = _correoPlantillaService.GetPlantillaIdByNombrePlantilla("AvisoEntrevistaCandidato", Centroid, OficinaId);

            if (responsePlantilla.IsValid || responsePlantillaCandidato.IsValid)
            {
                var listaSubEntrevistas = new List<SubEntrevistaViewModel>();
                if (candidatura.CandidaturaDatosBasicosViewModel.DatosBasicos.EtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.FeedbackPrimeraEntrevista)
                {
                    listaSubEntrevistas = candidatura.PrimeraEntrevistaViewModel.AgendarPrimeraEntrevista.SubEntrevistaList;
                }
                else if (candidatura.CandidaturaDatosBasicosViewModel.DatosBasicos.EtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.FeedbackSegundaEntrevista)
                {
                    listaSubEntrevistas = candidatura.SegundaEntrevistaViewModel.AgendarSegundaEntrevista.SubEntrevistaList;
                }
                foreach (var subEntrevista in listaSubEntrevistas)
                {
                    if (responsePlantilla.IsValid)
                    {
                        //se comprueba que no existe ya un correo de la subentrevista.
                        if (!ExisteCorreo(candidatura.CandidaturaId.Value, responsePlantilla.PlantillaId, subEntrevista.SubEntrevistaId, tipoAviso) && subEntrevista.SubEntrevistaId != null)
                        { //enviamos en este if los correos a los entrevistadores

                            var responseAsunto = _correoPlantillaVariableService.GetValorDefectoNombreVariablePlantillaCorreo(responsePlantilla.PlantillaId, NombresVariablesPlantillaCorreoEnum.Asunto.ToString());
                            var responseRemitente = _correoPlantillaVariableService.GetValorDefectoNombreVariablePlantillaCorreo(responsePlantilla.PlantillaId, NombresVariablesPlantillaCorreoEnum.Remitente.ToString());

                            if (responseAsunto.IsValid && responseRemitente.IsValid && responseRemitente.VarlorDefecto != "")
                            {
                                Correo correo = new Correo()
                                {
                                    PlantillaId = responsePlantilla.PlantillaId,
                                    Enviado = false,
                                    CandidaturaId = candidatura.CandidaturaId,
                                    Asunto = responseAsunto.VarlorDefecto,
                                    Remitente = responseRemitente.VarlorDefecto,
                                    IsActivo = true,
                                    TipoAviso = tipoAviso,
                                    SubEntrevistaId = subEntrevista.SubEntrevistaId
                                };

                                if (candidatura.CandidaturaDatosBasicosViewModel.DatosBasicos.EtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.FeedbackPrimeraEntrevista)
                                {
                                    if (candidatura.PrimeraEntrevistaViewModel != null)
                                    {
                                        correo.Destinatarios = _usuarioService.GetUsuarioById(subEntrevista.EntrevistadorId.Value).UsuarioViewModel.Email;
                                    }
                                }
                                if (candidatura.CandidaturaDatosBasicosViewModel.DatosBasicos.EtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.FeedbackSegundaEntrevista)
                                {
                                    if (candidatura.SegundaEntrevistaViewModel != null)
                                    {
                                        correo.Destinatarios = _usuarioService.GetUsuarioById(subEntrevista.EntrevistadorId.Value).UsuarioViewModel.Email;
                                    }
                                }

                                //antes de crear el correo se comprueba si la fecha de la entrevista esta dentro del rango donde se tiene que avisar
                                if (SaveNotification(subEntrevista, Notificaciones_DiasAntesEntrevista))
                                {
                                    var model = CorreoMapper.ConvertToCorreoRowViewModel(correo);
                                    var responseSave = _correoService.SaveCorreo(model, usuarioAplicacion);

                                    //se crea una bitacora indicando que se ha programado el envio de email
                                    var bitacoraResponse = _bitacoraService.GenerateBitacoraCorreo(candidatura.CandidaturaId.Value, "Programado envio de correo.");
                                }
                            }
                        }
                    }
                    if (responsePlantillaCandidato.IsValid) //mandar correo al candidato de la subentrevista
                    {
                        if (!ExisteCorreo(candidatura.CandidaturaId.Value, responsePlantillaCandidato.PlantillaId, subEntrevista.SubEntrevistaId, tipoAviso) && subEntrevista.SubEntrevistaId != null)
                        {
                            var responseEmailCandidato = _candidatoService.GetEmailCandidato(candidatura.CandidaturaDatosBasicosViewModel.DatosBasicos.CandidatoId, tipoMedioContactoEmail);
                            var responseAsunto = _correoPlantillaVariableService.GetValorDefectoNombreVariablePlantillaCorreo(responsePlantillaCandidato.PlantillaId, NombresVariablesPlantillaCorreoEnum.Asunto.ToString());
                            var responseRemitente = _correoPlantillaVariableService.GetValorDefectoNombreVariablePlantillaCorreo(responsePlantillaCandidato.PlantillaId, NombresVariablesPlantillaCorreoEnum.Remitente.ToString());

                            if (responseEmailCandidato.IsValid && responseAsunto.IsValid && responseRemitente.IsValid && responseRemitente.VarlorDefecto != "" && responseEmailCandidato.EmailCandidato != ""
                                && subEntrevista.AvisarAlCandidato)
                            {
                                Correo correo = new Correo()
                                {
                                    PlantillaId = responsePlantillaCandidato.PlantillaId,
                                    Enviado = false,
                                    CandidaturaId = candidatura.CandidaturaId,
                                    Asunto = responseAsunto.VarlorDefecto,
                                    Remitente = responseRemitente.VarlorDefecto,
                                    IsActivo = true,
                                    SubEntrevistaId = subEntrevista.SubEntrevistaId,
                                    Destinatarios = responseEmailCandidato.EmailCandidato,
                                    TipoAviso = tipoAviso
                                };
                                if (SaveNotification(subEntrevista, Notificaciones_DiasAntesEntrevista))
                                {
                                    var model = CorreoMapper.ConvertToCorreoRowViewModel(correo);
                                    var responseSave = _correoService.SaveCorreo(model, usuarioAplicacion);

                                    //se crea una bitacora indicando que se ha programado el envio de email
                                    var bitacoraResponse = _bitacoraService.GenerateBitacoraCorreo(candidatura.CandidaturaId.Value, "Programado envio de correo.");
                                }
                            }
                        }
                    }
                }
            }
        }

        #endregion
    }
}
