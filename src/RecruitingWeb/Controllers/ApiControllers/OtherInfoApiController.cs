using Recruiting.Application.Candidatos.Services;
using Recruiting.Application.Candidaturas.Services;
using Recruiting.Business.Repositories;
using Recruiting.Data.EntityFramework.Repositories;
using RecruitingWeb.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Http;

namespace RecruitingWeb.Controllers
{
    public class OtherInfoApiController : ApiController
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
        public OtherInfoApiController()
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
        public OtherInfoModel Post(OtherInfoModel model)
        {    
            try
            {
                List<OtherInfoRowModel> ListaCalculada = new List<OtherInfoRowModel>();

                if(ValidateUser(model))
                {
                    foreach(var otherInfo in model.OtherInfoList)
                    {
                        var otherInfoCalculated = CalculateOtherInfoFlags(otherInfo);
                        ListaCalculada.Add(otherInfoCalculated);
                    }

                    model.OtherInfoList = ListaCalculada;
                    return model;
                }
                
            }
            catch (Exception exception)
            {
                return null;
            }
            return model;
        }

        private bool ValidateUser(OtherInfoModel model)
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

        private OtherInfoRowModel CalculateOtherInfoFlags(OtherInfoRowModel model)
        {            
            var responseExistenteRecruiting = _candidatoService.CheckCandidatoEnRecruiting(model.Nombre, model.Email, model.Telefono, model.NIF);
            if(responseExistenteRecruiting.IsValid)
            {
                if(!responseExistenteRecruiting.ExistenteEnRecruiting)
                {
                    model.Visualizable = true;
                }
                else
                {
                    model.ExistenteRecruiting = responseExistenteRecruiting.ExistenteEnRecruiting;
                    var responseEnProcesoRecruiting = _candidaturaService.CheckEnProceso((int)responseExistenteRecruiting.CandidatoId);
                    if(responseEnProcesoRecruiting.IsValid)
                    {
                        if(responseEnProcesoRecruiting.EnProceso)
                        {
                            model.EnProceso = responseEnProcesoRecruiting.EnProceso;
                            model.Contratado = responseEnProcesoRecruiting.Contratado;
                            model.Visualizable = false;
                        }
                        else
                        {
                            var responseDescarteSeisMeses = _candidaturaService.CheckDescarteMenosSeisMeses((int)responseExistenteRecruiting.CandidatoId);
                            if(responseDescarteSeisMeses.IsValid)
                            {
                                if(!responseDescarteSeisMeses.DescarteMenosSeisMeses)
                                {
                                    model.Visualizable = true;
                                }
                                else
                                {
                                    model.DescarteRenunciaMenosSeisMeses = responseDescarteSeisMeses.DescarteMenosSeisMeses;
                                    var responseNoMotivadoCambioEmpresaResponse = _candidaturaService.CheckNoMotivadoCambioEmpresa((int)responseExistenteRecruiting.CandidatoId);
                                    if(responseNoMotivadoCambioEmpresaResponse.IsValid)
                                    {
                                        if(responseNoMotivadoCambioEmpresaResponse.NoMotivadoCambioEmpresa)
                                        {
                                            model.NoMotivadoCambioEmpresa = responseNoMotivadoCambioEmpresaResponse.NoMotivadoCambioEmpresa;
                                            model.Visualizable = true;
                                        }
                                        else
                                        {
                                            model.Visualizable = false;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return model;
        }
    }
}