using Recruiting.Application.Candidatos.Messages;
using Recruiting.Application.Candidatos.Services;
using Recruiting.Application.Candidatos.ViewModels;
using Recruiting.Application.Candidaturas.Enums;
using Recruiting.Application.Candidaturas.Messages;
using Recruiting.Application.Candidaturas.Services;
using Recruiting.Application.Candidaturas.ViewModel;
using Recruiting.Business.Repositories;
using Recruiting.Data.EntityFramework.Repositories;
using RecruitingWeb.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace RecruitingWeb.Controllers
{
    public class OtherInfoContactarApiController : ApiController
    {
        #region Fields 


        private readonly ICandidatoRepository _candidatoRepository;
        private readonly ICandidatoIdiomaRepository _candidatoIdiomaRepository;
        private readonly ICandidatoExperienciaRepository _candidatoExperienciaRepository;
        private readonly ICandidatoContactoRepository _candidatoContactoRepository;
        private readonly ICandidaturaRepository _candidaturaRepository;
        private readonly IBecarioRepository _becarioRepository;

        private readonly IEntrevistaRepository _entrevistaRepository;
        private readonly ICartaOfertaRepository _cartaOfertaRepository;
        private readonly IRelacionEtapaRepository _relacionEtapaRepository;
        private readonly IRelacionVistaEtapaRepository _relacionVistaEtapaRepository;
        private readonly IBitacoraRepository _bitacoraRepository;
        private readonly ITipoDecisionRepository _tipoDecisionRepository;
        private readonly ITipoEtapaCandidaturaRepository _tipoEtapaCandidaturaRepository;
        private readonly ITipoEstadoCandidaturaRepository _tipoEstadoCandidaturaRepository;
        private readonly INecesidadRepository _necesidadRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ISubEntrevistaRepository _subEntrevistaRepository;


        private readonly ICandidatoService _candidatoService;
        private readonly ICandidaturaService _candidaturaService;




        #endregion

        #region Construct
        public OtherInfoContactarApiController()
        {
            _candidatoRepository = new CandidatoRepository();
            _candidatoIdiomaRepository = new CandidatoIdiomaRepository();
            _candidatoExperienciaRepository = new CandidatoExperienciaRepository();
            _candidatoContactoRepository = new CandidatoContactoRepository();
            _candidaturaRepository = new CandidaturaRepository();
            _becarioRepository = new BecarioRepository();
            _entrevistaRepository = new EntrevistaRepository();
            _cartaOfertaRepository = new CartaOfertaRepository();
            _relacionEtapaRepository = new RelacionEtapaRepository();
            _relacionVistaEtapaRepository = new RelacionVistaEtapaRepository();
            _bitacoraRepository = new BitacoraRepository();
            _tipoDecisionRepository = new TipoDecisionRepository();
            _tipoEtapaCandidaturaRepository = new TipoEtapaCandidaturaRepository();
            _tipoEstadoCandidaturaRepository = new TipoEstadoCandidaturaRepository();
            _necesidadRepository = new NecesidadRepository();
            _usuarioRepository = new UsuarioRepository();
            _subEntrevistaRepository = new SubEntrevistaRepository();

            _candidatoService = new CandidatoService(_candidatoRepository, _candidatoIdiomaRepository,
                                                    _candidatoExperienciaRepository, _candidatoContactoRepository,
                                                    _candidaturaRepository, _becarioRepository);
            _candidaturaService = new CandidaturaService(_candidaturaRepository, _entrevistaRepository,
                                                         _cartaOfertaRepository, _relacionEtapaRepository,
                                                         _relacionVistaEtapaRepository, _bitacoraRepository,
                                                         _tipoDecisionRepository, _tipoEtapaCandidaturaRepository,
                                                         _tipoEstadoCandidaturaRepository, _necesidadRepository,
                                                         _usuarioRepository, _subEntrevistaRepository);


        }
        #endregion


        // POST: OtherInfoApi
        public ContactarCandidatoResponse Post(ContactarCandidatoModel model)
        {
            var response = new ContactarCandidatoResponse();

            try
            {

                if (ValidateUser(model))
                {                  

                    response = ContactarCandidato(model);


     
                }
                return response;

            }
            catch (Exception exception)
            {

                return response;
            }
        }

        private bool ValidateUser(ContactarCandidatoModel model)
        {
            var appSettings = ConfigurationManager.AppSettings;
            if (model.UserName == appSettings.Get("userNameOtherInfo") && model.Password == appSettings.Get("passwordOtherInfo"))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private ContactarCandidatoResponse ContactarCandidato(ContactarCandidatoModel model)
        {
            var response = new ContactarCandidatoResponse();

            var candidatoGuardar = new CandidatoOtherInfoViewModel()
            {
                Nombre = model.Nombre,
                Apellidos = model.Apellidos,
                NIF = model.NIF,
                Telefono = model.Telefono,
                Email = model.Email,
                TitulacionId = model.TitulacionId,
                UsuarioCreacionOtherInfo = model.UsuarioCreacionOtherInfo                
            };

            var responseCheckExistenteRecruiting = _candidatoService.CheckCandidatoEnRecruiting(model.Nombre + " " + model.Apellidos, model.Email, model.Telefono, model.NIF);
            if (responseCheckExistenteRecruiting.IsValid)
            {                
                if (responseCheckExistenteRecruiting.ExistenteEnRecruiting)
                {
                    candidatoGuardar.CandidatoId = responseCheckExistenteRecruiting.CandidatoId;
                    var responseUpdateCandidato = _candidatoService.UpdateCandidatoOtherInfo(candidatoGuardar);
                    if (responseUpdateCandidato.IsValid)
                    {
                        var responseCrearCandidatura = CheckAndCreateCandidatura(model, responseUpdateCandidato.CandidatoId);
                        response.IsValid = responseCrearCandidatura.IsValid;
                        response.ErrorMessage = responseCrearCandidatura.ErrorMessage;
                    }
                }
                else
                {
                    var responseCreateCandidato = _candidatoService.CreateCandidatoOtherInfo(candidatoGuardar);
                    if (responseCreateCandidato.IsValid)
                    {
                        var responseCrearCandidatura = CheckAndCreateCandidatura(model, responseCreateCandidato.CandidatoId);
                        response.IsValid = responseCrearCandidatura.IsValid;
                        response.ErrorMessage = responseCrearCandidatura.ErrorMessage;
                    }
                }
            }

            return response;
       
        }

        private CrearCandidaturaOtherInfoResponse CheckAndCreateCandidatura(ContactarCandidatoModel model, int candidatoId)
        {
            var response = new CrearCandidaturaOtherInfoResponse();
            var responseEnProceso = _candidaturaService.CheckEnProceso(candidatoId);

            DatosCandidaturaOtherInfoViewModel datosCandidaturaOtherInfo = new DatosCandidaturaOtherInfoViewModel()
            {
                CandidatoId = candidatoId,
                CategoriaId = model.CategoriaId,
                TecnologiaId = model.TecnologiaId,
                ModuloId = model.ModuloId,
                OrigenCvId = (int)OrigenCvEnum.BusquedaActiva,
                FuenteReclutamientoId = (int)FuenteReclutamientoEnum.Infojobs,
                UsuarioCreacionOtherInfo = model.UsuarioCreacionOtherInfo
            };

            if(responseEnProceso.IsValid)
            {
                if(responseEnProceso.EnProceso)
                {
                    response.IsValid = false;
                    response.ErrorMessage = "Ya existe una candidatura en proceso";
                }
                else
                {
                    var responseCreateCandidatura = _candidaturaService.CrearCandidaturaOtherInfo(datosCandidaturaOtherInfo);
                    if (responseCreateCandidatura.IsValid)
                    {
                        response.IsValid = true;
                    }
                    else
                    {
                        response.IsValid = false;
                        response.ErrorMessage = responseCreateCandidatura.ErrorMessage;
                    }
                }
            }
            else
            {
                response.IsValid = false;
                response.ErrorMessage = responseEnProceso.ErrorMessage;
            }

            return response;
        }


    }
}