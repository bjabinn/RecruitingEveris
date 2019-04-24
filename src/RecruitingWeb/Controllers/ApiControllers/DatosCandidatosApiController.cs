using Recruiting.Application.Candidatos.Services;
using Recruiting.Application.Candidaturas.Services;
using Recruiting.Application.Candidaturas.ViewModel;
using Recruiting.Business.Repositories;
using Recruiting.Data.EntityFramework.Repositories;
using RecruitingWeb.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Http;

namespace RecruitingWeb.Controllers
{
    public class DatosCandidatosApiController : ApiController
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
        public DatosCandidatosApiController()
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
        public DatosCandidatoApiModel Post(DatosCandidatoConsultaApiModel model)
        {
            DatosCandidatoApiModel datosCandidato = new DatosCandidatoApiModel();

            try
            {               

                if(ValidateUser(model))
                {
                    var candidato = _candidatoService.CheckCandidatoEnRecruiting(model.Nombre, model.Email, model.Telefono, model.NIF);
                    if(candidato.IsValid)
                    {
                        if(candidato.ExistenteEnRecruiting)
                        {
                            var datosBasicosCandidato = _candidatoService.GetCandidatoById((int)candidato.CandidatoId);
                            datosCandidato.ExistenteRecruiting = true;
                            datosCandidato.Nombre = datosBasicosCandidato.CandidatoViewModel.Nombres;
                            datosCandidato.Apellidos = datosBasicosCandidato.CandidatoViewModel.Apellidos;
                            datosCandidato.Titulacion = datosBasicosCandidato.CandidatoViewModel.Titulacion;

                            var candidaturas = _candidaturaService.GetCandidaturasByIdCandidato((int)candidato.CandidatoId);

                            if(candidaturas.CandidaturasViewModel != null && candidaturas.CandidaturasViewModel.Count() != 0)
                            {
                                datosCandidato.NumCandidaturas = candidaturas.CandidaturasViewModel.Count();
                                datosCandidato = MapearDatosCandidatura(datosCandidato, candidaturas.CandidaturasViewModel);
                            }
                            else
                            {
                                datosCandidato.NumCandidaturas = 0;
                            }
                        }
                        else
                        {
                            datosCandidato.ExistenteRecruiting = candidato.ExistenteEnRecruiting;
                        }
                    }

                    return datosCandidato;
                }
                
            }
            catch (Exception exception)
            {
                return datosCandidato;
            }

            return datosCandidato;
        }

        private bool ValidateUser(DatosCandidatoConsultaApiModel model)
        {
            var appSettings = ConfigurationManager.AppSettings;
            if (model.UserName == appSettings.Get("userNameDatosCandidatoApi") && model.Password == appSettings.Get("passwordDatosCandidatoApi"))
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        private DatosCandidatoApiModel MapearDatosCandidatura(DatosCandidatoApiModel datosCandidato, IEnumerable<CandidaturaViewModel> candidaturaList)
        {
            var nuevaLista = new List<DatosCandidaturaApiModel>();

            foreach (var candidatura in candidaturaList)
            {
                DatosCandidaturaApiModel nuevaCandidatura = new DatosCandidaturaApiModel()
                {
                    Estado = candidatura.CandidaturaDatosBasicosViewModel.DatosBasicos.EstadoCandidatura,
                    Etapa = candidatura.CandidaturaDatosBasicosViewModel.DatosBasicos.EtapaCandidatura,
                    Categoria = candidatura.CandidaturaDatosBasicosViewModel.DatosBasicos.CategoriaNombre,
                    Observaciones = candidatura.FiltroCVViewModel == null ? String.Empty : candidatura.FiltroCVViewModel.MotivosObservaciones,
                    ComentariosRenunciaDescarte = candidatura.ComentariosRenunciaDescarte,
                    FechaUltimoContacto = GetFechaUltimoContacto(candidatura),
                    PersonaUltimoContacto = GetPersonaUltimoContacto(candidatura),
                    FechaEntradaCv = candidatura.CandidaturaDatosBasicosViewModel.DatosBasicos.FechaCreacion

                };

                nuevaLista.Add(nuevaCandidatura);
            }

            datosCandidato.Candidaturas = nuevaLista;

            return datosCandidato;
        }

        public DateTime? GetFechaUltimoContacto(CandidaturaViewModel candidatura)
        {
            DateTime fechaUltimoContacto;

            if(candidatura.CompletarCartaOfertaViewModel != null && candidatura.CompletarCartaOfertaViewModel.EntregaCartaOfertaViewModel != null
                && candidatura.CompletarCartaOfertaViewModel.EntregaCartaOfertaViewModel.AgendarCartaOfertaViewModel != null
                && candidatura.CompletarCartaOfertaViewModel.EntregaCartaOfertaViewModel.AgendarCartaOfertaViewModel.AgendarCartaOferta != null
                && candidatura.CompletarCartaOfertaViewModel.EntregaCartaOfertaViewModel.AgendarCartaOfertaViewModel.AgendarCartaOferta.FechaAgendarCarta != null
                && candidatura.CompletarCartaOfertaViewModel.EntregaCartaOfertaViewModel.AgendarCartaOfertaViewModel.AgendarCartaOferta.FechaAgendarCarta < DateTime.Now)
            {
                fechaUltimoContacto = (DateTime)candidatura.CompletarCartaOfertaViewModel.EntregaCartaOfertaViewModel.AgendarCartaOfertaViewModel.AgendarCartaOferta.FechaAgendarCarta;
                return fechaUltimoContacto;
            }

            if(candidatura.SegundaEntrevistaViewModel != null && candidatura.SegundaEntrevistaViewModel.AgendarSegundaEntrevista != null
                && candidatura.SegundaEntrevistaViewModel.AgendarSegundaEntrevista.AgendarSegundaEntrevista != null 
                && candidatura.SegundaEntrevistaViewModel.AgendarSegundaEntrevista.AgendarSegundaEntrevista.FechaEntrevista != null
                && candidatura.SegundaEntrevistaViewModel.AgendarSegundaEntrevista.AgendarSegundaEntrevista.FechaEntrevista < DateTime.Now)
            {
                fechaUltimoContacto = (DateTime)candidatura.SegundaEntrevistaViewModel.AgendarSegundaEntrevista.AgendarSegundaEntrevista.FechaEntrevista;
                return fechaUltimoContacto;
            }
            if(candidatura.PrimeraEntrevistaViewModel != null && candidatura.PrimeraEntrevistaViewModel.AgendarPrimeraEntrevista != null
                && candidatura.PrimeraEntrevistaViewModel.AgendarPrimeraEntrevista.AgendarPrimeraEntrevista != null
                && candidatura.PrimeraEntrevistaViewModel.AgendarPrimeraEntrevista.AgendarPrimeraEntrevista.FechaEntrevista != null
                && candidatura.PrimeraEntrevistaViewModel.AgendarPrimeraEntrevista.AgendarPrimeraEntrevista.FechaEntrevista < DateTime.Now)
            {
                fechaUltimoContacto = (DateTime)candidatura.PrimeraEntrevistaViewModel.AgendarPrimeraEntrevista.AgendarPrimeraEntrevista.FechaEntrevista;
                return fechaUltimoContacto;
            }

            return null;
        }

        public string GetPersonaUltimoContacto(CandidaturaViewModel candidatura)
        {
            string personaUltimoContacto;

            if (candidatura.CompletarCartaOfertaViewModel != null && candidatura.CompletarCartaOfertaViewModel.EntregaCartaOfertaViewModel != null
                && candidatura.CompletarCartaOfertaViewModel.EntregaCartaOfertaViewModel.AgendarCartaOfertaViewModel != null
                && candidatura.CompletarCartaOfertaViewModel.EntregaCartaOfertaViewModel.AgendarCartaOfertaViewModel.AgendarCartaOferta != null
                && candidatura.CompletarCartaOfertaViewModel.EntregaCartaOfertaViewModel.AgendarCartaOfertaViewModel.AgendarCartaOferta.EntrevistadorName != null)
            {
                personaUltimoContacto = candidatura.CompletarCartaOfertaViewModel.EntregaCartaOfertaViewModel.AgendarCartaOfertaViewModel.AgendarCartaOferta.EntrevistadorName;
                return personaUltimoContacto;
            }

            if (candidatura.SegundaEntrevistaViewModel != null && candidatura.SegundaEntrevistaViewModel.AgendarSegundaEntrevista != null
                && candidatura.SegundaEntrevistaViewModel.AgendarSegundaEntrevista.AgendarSegundaEntrevista != null
                && candidatura.SegundaEntrevistaViewModel.AgendarSegundaEntrevista.AgendarSegundaEntrevista.EntrevistadorName != null)
                
            {
                personaUltimoContacto = candidatura.SegundaEntrevistaViewModel.AgendarSegundaEntrevista.AgendarSegundaEntrevista.EntrevistadorName;
                return personaUltimoContacto;
            }
            if (candidatura.PrimeraEntrevistaViewModel != null && candidatura.PrimeraEntrevistaViewModel.AgendarPrimeraEntrevista != null
                && candidatura.PrimeraEntrevistaViewModel.AgendarPrimeraEntrevista.AgendarPrimeraEntrevista != null
                && candidatura.PrimeraEntrevistaViewModel.AgendarPrimeraEntrevista.AgendarPrimeraEntrevista.EntrevistadorName != null)
            {
                personaUltimoContacto = candidatura.PrimeraEntrevistaViewModel.AgendarPrimeraEntrevista.AgendarPrimeraEntrevista.EntrevistadorName;
                return personaUltimoContacto;
            }

            return null;
        }


    }
}