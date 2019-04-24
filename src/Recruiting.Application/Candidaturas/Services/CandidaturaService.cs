using Recruiting.Application.Bitacoras.Enums;
using Recruiting.Application.Bitacoras.Services;
using Recruiting.Application.Candidatos.Mappers;
using Recruiting.Application.Candidaturas.Enums;
using Recruiting.Application.Candidaturas.Mappers;
using Recruiting.Application.Candidaturas.Messages;
using Recruiting.Application.Candidaturas.ViewModel;
using Recruiting.Application.Helpers;
using Recruiting.Application.Maestros.Enums;
using Recruiting.Application.Necesidades.Messages;
using Recruiting.Application.Necesidades.Services;
using Recruiting.Application.Usuarios.Services;
using Recruiting.Application.Maestros.Enums;
using Recruiting.Business.BaseClasses.DataTable;
using Recruiting.Business.Entities;
using Recruiting.Business.Helpers;
using Recruiting.Business.Repositories;
using Recruiting.Business.Services.WorkflowCandidatura;
using Recruiting.Data.EntityFramework.Repositories;
using Recruiting.Infra.Caching;
using Recruiting.Infra.Caching.Contracts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;


namespace Recruiting.Application.Candidaturas.Services
{
    public class CandidaturaService : ICandidaturaService
    {
        #region Constants
        public const string CandidaturaFiltroSessionKey = "CandidaturaFiltroSessionKey";
        public const string SeparatorBar = "\\";
        public const string RutaScripts = @"C:\Scripts";
        public const string RutaScriptsEntrevistas = @"C:\Scripts\updateNumeroDeEntrevistas.sql";
        public const int SalarioPropuestoBecario = 12600;
        #endregion

        #region Fields

        private readonly ICandidaturaRepository _candidaturaRepository;
        private readonly IMaestroRepository _maestroRepository;
        private readonly IEntrevistaRepository _entrevistaRepository;
        private readonly ICartaOfertaRepository _cartaOfertaRepository;
        private readonly IRelacionEtapaRepository _relacionEtapaRepository;
        private readonly IRelacionVistaEtapaRepository _relacionVistaEtapaRepository;
        private readonly IWorkflowCandidaturaService _workflowCandidaturaService;
        private readonly ICacheStorageService _cacheStorageService;

        private readonly IBitacoraService _bitacoraService;
        private readonly IBitacoraRepository _bitacoraRepository;
        private readonly ITipoDecisionRepository _tipoDecisionRepository;
        private readonly ITipoEtapaCandidaturaRepository _tipoEtapaCandidaturaRepository;
        private readonly ITipoEstadoCandidaturaRepository _tipoEstadoCandidaturaRepository;

        private readonly IUsuarioService _usuarioService;
        private readonly IUsuarioRepository _usuarioRepository;

        private readonly INecesidadRepository _necesidadRepository;
        private readonly INecesidadService _necesidadService;

        private readonly ISubEntrevistaRepository _subentrevistaRepository;
        private readonly IBecarioRepository _becarioRepository;
        private readonly ICandidatoRepository _candidatoRepository;
        private readonly ICandidatoIdiomaRepository _candidatoIdiomaRepository;
        private readonly ICandidatoExperienciaRepository _candidatoExperienciaRepository;

        #endregion

        #region Constructor

        public CandidaturaService(ICandidaturaRepository candidaturaRepository,
            IEntrevistaRepository entrevistaRepository, ICartaOfertaRepository cartaOfertaRepository,
            IRelacionEtapaRepository relacionEtapaRepository, IRelacionVistaEtapaRepository relacionVistaEtapaRepository,
            IBitacoraRepository bitacoraRepository, ITipoDecisionRepository tipoDecisionRepository,
            ITipoEtapaCandidaturaRepository tipoEtapaCandidaturaRepository, ITipoEstadoCandidaturaRepository tipoEstadoCandidaturaRepository,
            INecesidadRepository necesidadRepository, IUsuarioRepository usuarioRepository, ISubEntrevistaRepository subentrevistaRepository)
        {
            _maestroRepository = new MaestroRepository();
            _candidaturaRepository = candidaturaRepository;
            _entrevistaRepository = entrevistaRepository;
            _cartaOfertaRepository = cartaOfertaRepository;
            _relacionEtapaRepository = relacionEtapaRepository;
            _relacionVistaEtapaRepository = relacionVistaEtapaRepository;
            _tipoDecisionRepository = tipoDecisionRepository;

            _bitacoraRepository = bitacoraRepository;
            _tipoEtapaCandidaturaRepository = tipoEtapaCandidaturaRepository;
            _tipoEstadoCandidaturaRepository = tipoEstadoCandidaturaRepository;
            _bitacoraService = new BitacoraService(bitacoraRepository, candidaturaRepository, tipoDecisionRepository,
            _tipoEtapaCandidaturaRepository, _tipoEstadoCandidaturaRepository, _maestroRepository);
            _usuarioRepository = usuarioRepository;
            _usuarioService = new UsuarioService(usuarioRepository);

            _necesidadRepository = necesidadRepository;
            _necesidadService = new NecesidadService(_necesidadRepository);
            _workflowCandidaturaService = new WorkflowCandidaturaService(_relacionEtapaRepository, _relacionVistaEtapaRepository);
            _cacheStorageService = new SessionCacheStorageService();

            _subentrevistaRepository = subentrevistaRepository;
            _becarioRepository = new BecarioRepository();
            _candidatoRepository = new CandidatoRepository();
            _candidatoIdiomaRepository = new CandidatoIdiomaRepository();
            _candidatoExperienciaRepository = new CandidatoExperienciaRepository();
        }

        #endregion

        #region ICandidaturaService

        #region QueryRequest

        public GetCandidaturasResponse GetCandidaturas(DataTableRequest request)
        {
            var response = new GetCandidaturasResponse();

            try
            {

                var query = FilterString(request.CustomFilters);
                var filtered = query.ApplyColumnSettings(request, CandidaturaMapper.GetPropertiePath);

                var candidaturasIds = filtered.Select(x => x.CandidaturaId).ToList();
                var bitacorasRevertiblesGrouped = _bitacoraRepository.GetByCriteria(x => candidaturasIds.Contains(x.CandidaturaId) && x.TipoBitacora.HasValue && x.Revertible.HasValue && x.Revertible.Value).GroupBy(x => x.CandidaturaId);
                var bitacorasRevertibles = bitacorasRevertiblesGrouped.ToDictionary(x => x.Key, x => x.ToList());

                response.CandidaturaViewModel = filtered.ConvertToCandidaturaRowViewModel(bitacorasRevertibles);
                response.TotalElementos = query.Count();

                response.IsValid = true;
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        //Exportar las candidaturas a excel
        public GetCandidaturasExportToExcelResponse GetCandidaturasExportToExcel(DataTableRequest request)
        {
            var response = new GetCandidaturasExportToExcelResponse();

            try
            {
                var query = FilterString(request.CustomFilters);
                query = query.Where(x => (x.EstadoCandidaturaId != (int)TipoEstadoCandidaturaEnum.Renuncia) || (x.EstadoCandidaturaId == (int)TipoEstadoCandidaturaEnum.Renuncia && x.MotivoRenunciaDescarteId != null));
                var filtered = query.ApplyColumnSettings(request, CandidaturaMapper.GetPropertiePath);

                response.CandidaturaExportToExcelViewModel = filtered.ConvertToCandidaturaRowExportToExcelViewModel();
                response.TotalElementos = query.Count();
                response.IsValid = true;

            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }
        //obtiene una candidatura pasandole su id
        public GetCandidaturaByIdResponse GetCandidaturaById(int candidaturaId)
        {
            var candidato = GetCandidatoByCandidatura(candidaturaId).CreateEditCandidatoViewModel;
            var response = new GetCandidaturaByIdResponse();
            response.CandidaturaViewModel = new CandidaturaViewModel();

            try
            {
                var candidatura = _candidaturaRepository.GetOne(x => x.CandidaturaId == candidaturaId);

                response.CandidaturaViewModel = CandidaturaMapper.ConvertToCandidaturaViewModel(candidatura);

                
                if (candidato.IdiomaCandidatoViewModel != null) {
                    
                    foreach (Recruiting.Application.Candidatos.ViewModels.CreateEditRowIdiomaCandidatoViewModel i in candidato.IdiomaCandidatoViewModel) {
                        var idioma = new CreateEditRowIdiomaCandidaturaViewModel();

                        idioma.CandidatoId = i.CandidatoId;
                        idioma.IdiomaId = i.IdiomaId;
                        idioma.NivelIdiomaId = i.NivelIdiomaId;
                        idioma.Idioma = i.Idioma;
                        idioma.NivelIdioma = i.NivelIdioma;
                        response.CandidaturaViewModel.CandidaturaDatosBasicosViewModel.DatosBasicos.IdiomaCandidatoViewModel.Add(idioma);
                    }
                }

                if (candidato.ExpCandidatoViewModel != null) {
                    foreach (Recruiting.Application.Candidatos.ViewModels.CreateEditRowExperienciaCandidatoViewModel e in candidato.ExpCandidatoViewModel) {
                        var exp = new ViewModels.CreateEditRowExperienciaCandidatoViewModel();

                        exp.CandidatoId = e.CandidatoId;
                        exp.Experiencia = e.Experiencia;
                        exp.CandidatoExperienciaId = e.CandidatoExperienciaId;
                        exp.TipoTecnologia = e.TipoTecnologia;
                        exp.TipoTecnologiaId = e.TipoTecnologiaId;
                        exp.NivelTecnologia = e.NivelTecnologia;
                        exp.NivelTecnologiaId = e.NivelTecnologiaId;
                        exp.Experiencia = e.Experiencia;

                        response.CandidaturaViewModel.CandidaturaDatosBasicosViewModel.DatosBasicos.ExpCandidatoViewModel.Add(exp);
                    }
                }

                response.IsValid = true;
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public GetEmailEntrevistadorResponse GetEmailEntrevistador(int entrevistadorId, int tipoMedioContactoEmail)
        {
            var response = new GetEmailEntrevistadorResponse();

            try
            {
                var email = _usuarioRepository.GetOne(x => x.UsuarioId == entrevistadorId && x.IsActivo).Email;
                 
                if (email != null)
                {
                    response.IsValid = true;
                    response.EmailEntrevistador = email;
                }
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }


        public GetCandidaturaToGeneratePDFbyIdResponse GetCandidaturaToGeneratePDFbyId(int candidaturaId,
            string nombreEntregaCarta, string cargoEntregaCarta, string telefono, string telefonoContratacion, string mailTo, string atencionTelefonica, string ayudaComedor, string fax)
        {
            var response = new GetCandidaturaToGeneratePDFbyIdResponse();
            response.CartaOfertaPdfViewModel = new CartaOfertaPdfViewModel();

            try
            {
                var candidatura = _candidaturaRepository.GetOne(x => x.CandidaturaId == candidaturaId);

                response.CartaOfertaPdfViewModel = CandidaturaCartaOfertaMapper.ConvertToCartaOfertaPdfViewModel(candidatura,
                  nombreEntregaCarta, cargoEntregaCarta, telefono, telefonoContratacion, mailTo, atencionTelefonica, ayudaComedor, fax);
                response.IsValid = true;
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public GetCandidaturaToGeneratePDFbyIdResponse GetCandidaturaToGeneratePDFbyIdIndex(int candidaturaId,
            string nombreEntregaCarta, string cargoEntregaCarta, string telefono, string mailTo, string atencionTelefonica, string ayudaComedor, string fax)
        {
            var response = new GetCandidaturaToGeneratePDFbyIdResponse();
            response.CartaOfertaPdfViewModel = new CartaOfertaPdfViewModel();

            try
            {
                var candidatura = _candidaturaRepository.GetOne(x => x.CandidaturaId == candidaturaId);

                response.CartaOfertaPdfViewModel = CandidaturaCartaOfertaMapper.ConvertToCartaOfertaPdfIndexViewModel(candidatura,
                  nombreEntregaCarta, cargoEntregaCarta, telefono, mailTo, atencionTelefonica, ayudaComedor, fax);
                response.IsValid = true;
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public GetCandidatoByCandidaturaResponse GetCandidatoByCandidatura(int candidaturaId)
        {
            var response = new GetCandidatoByCandidaturaResponse();

            try
            {
                var candidatura = _candidaturaRepository.GetOne(x => x.CandidaturaId == candidaturaId);

                response.CreateEditCandidatoViewModel = CandidatoMapper.ConvertToCreateEditCandidatoViewModel(candidatura.Candidato);
                response.IsValid = true;
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public GetFiltradoCVCandidaturaResponse GetFiltradoCVCandidatura(int candidaturaId)
        {
            var response = new GetFiltradoCVCandidaturaResponse();

            try
            {
                response.CandidaturaFiltradoCvViewModel = _candidaturaRepository.GetOne(x => x.CandidaturaId == candidaturaId).ConvertToCandidaturaViewModel().FiltroCVViewModel;
                response.IsValid = true;
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public GetSchedulePrimeraEntrevistaResponse GetSchedulePrimeraEntrevista(int candidaturaId)
        {
            var response = new GetSchedulePrimeraEntrevistaResponse();

            try
            {
                response.AgendarPrimeraEntrevistaViewModel = _candidaturaRepository.GetOne(x => x.CandidaturaId == candidaturaId).ConvertToPrimeraEntrevistaViewModel().AgendarPrimeraEntrevista;
                response.AgendarPrimeraEntrevistaViewModel.SubEntrevistaList = new List<SubEntrevistaViewModel>();

                var getSubEntrevistasResponse = GetListaSubEntrevistas(candidaturaId, 1);
                if (getSubEntrevistasResponse.IsValid)
                {
                    response.AgendarPrimeraEntrevistaViewModel.SubEntrevistaList = getSubEntrevistasResponse.ListaSubEntrevistas;
                    response.IsValid = true;
                }
                else
                {
                    response.IsValid = false;
                }
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public GetPrimeraEntrevistaResponse GetPrimeraEntrevista(int candidaturaId)
        {
            var response = new GetPrimeraEntrevistaResponse();

            try
            {
                response.CompletarPrimeraEntrevistaViewModel = _candidaturaRepository.GetOne(x => x.CandidaturaId == candidaturaId).ConvertToCandidaturaViewModel().PrimeraEntrevistaViewModel;
                response.IsValid = true;
                response.CompletarPrimeraEntrevistaViewModel.AgendarPrimeraEntrevista.SubEntrevistaList = new List<SubEntrevistaViewModel>();
                var getSubEntrevistasResponse = GetListaSubEntrevistas(candidaturaId, 1);
                if (getSubEntrevistasResponse.IsValid)
                {
                    response.CompletarPrimeraEntrevistaViewModel.AgendarPrimeraEntrevista.SubEntrevistaList = getSubEntrevistasResponse.ListaSubEntrevistas;
                    response.IsValid = true;
                }
                else
                {
                    response.IsValid = false;
                }
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public GetScheduleSegundaEntrevistaResponse GetScheduleSegundaEntrevista(int candidaturaId)
        {
            var response = new GetScheduleSegundaEntrevistaResponse();

            try
            {
                response.AgendarSegundaEntrevistaViewModel = _candidaturaRepository.GetOne(x => x.CandidaturaId == candidaturaId).ConvertToSegundaEntrevistaViewModel().AgendarSegundaEntrevista;
                response.IsValid = true;
                response.AgendarSegundaEntrevistaViewModel.SubEntrevistaList = new List<SubEntrevistaViewModel>();
                var getSubEntrevistasResponse = GetListaSubEntrevistas(candidaturaId, 2);
                if (getSubEntrevistasResponse.IsValid)
                {
                    response.AgendarSegundaEntrevistaViewModel.SubEntrevistaList = getSubEntrevistasResponse.ListaSubEntrevistas;
                    response.IsValid = true;
                }
                else
                {
                    response.IsValid = false;
                }
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public GetSegundaEntrevistaResponse GetSegundaEntrevista(int candidaturaId)
        {
            var response = new GetSegundaEntrevistaResponse();

            try
            {

                response.CompletarSegundaEntrevistaViewModel = _candidaturaRepository.GetOne(x => x.CandidaturaId == candidaturaId).ConvertToCandidaturaViewModel().SegundaEntrevistaViewModel;
                response.IsValid = true;
                response.CompletarSegundaEntrevistaViewModel.AgendarSegundaEntrevista.SubEntrevistaList = new List<SubEntrevistaViewModel>();
                var getSubEntrevistasResponse = GetListaSubEntrevistas(candidaturaId, 2);
                if (getSubEntrevistasResponse.IsValid)
                {
                    response.CompletarSegundaEntrevistaViewModel.AgendarSegundaEntrevista.SubEntrevistaList = getSubEntrevistasResponse.ListaSubEntrevistas;
                    response.IsValid = true;
                }
                else
                {
                    response.IsValid = false;
                }
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public GetScheduleCartaOfertaResponse GetScheduleCartaOferta(int candidaturaId)
        {
            var response = new GetScheduleCartaOfertaResponse();

            try
            {
                response.AgendarCartaOfertaViewModel = _candidaturaRepository.GetOne(x => x.CandidaturaId == candidaturaId)
                    .ConvertToCompletarCartaOfertaViewModel().EntregaCartaOfertaViewModel.AgendarCartaOfertaViewModel;
                response.IsValid = true;
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public GetCartaOfertaResponse GetCartaOferta(int candidaturaId)
        {
            var response = new GetCartaOfertaResponse();

            try
            {
                response.CompletarCartaOfertaViewModel = _candidaturaRepository.GetOne(x => x.CandidaturaId == candidaturaId)
                    .ConvertToCompletarCartaOfertaViewModel();
                response.IsValid = true;

            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public GetCentroCandidaturaResponse GetCentroCandidatura(int candidaturaId)
        {
            var response = new GetCentroCandidaturaResponse();

            try
            {
                var usuario = _candidaturaRepository.GetOne(x => x.CandidaturaId == candidaturaId).Usuario;
                if (usuario.Centro != null)
                {
                    response.NombreCentro = usuario.Centro.Nombre.Replace(System.Environment.NewLine, "");
                    response.CentroId = usuario.Centro.CentroId;
                }
                else
                {
                    response.NombreCentro = string.Empty;
                }

                response.IsValid = true;

            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public ExecuteCandidaturaResponse ExecuteCandidatura(int candidaturaId, bool saltarSegundaEntrevista)
        {
            var response = new ExecuteCandidaturaResponse() { IsValid = true };

            try
            {
                var candidatura = _candidaturaRepository.GetOne(x => x.CandidaturaId == candidaturaId);

                //se guardan los estados iniciales de la candidatura antes de ejecutar la candidatura
                int estadoCandidaturaInicial = candidatura.EstadoCandidaturaId;
                int etapaCandidaturaInicial = candidatura.EtapaCandidaturaId;

                if (!saltarSegundaEntrevista)
                {
                    response.VistaAMostrar = _workflowCandidaturaService.GetVista(candidatura.EtapaCandidaturaId, candidatura.EstadoCandidaturaId);

                    if (!string.IsNullOrWhiteSpace(response.VistaAMostrar))
                    {
                        return response;
                    }

                    var tipoDecisionId = GetDecisionByCandidaturaEtapaId(candidatura.EtapaCandidaturaId, candidatura.EstadoCandidaturaId, false);
                    var dto = _workflowCandidaturaService.Execute(candidatura.EtapaCandidaturaId, tipoDecisionId);

                    if (!dto.IsValid || !dto.EstadoFinId.HasValue || !dto.EtapaFinId.HasValue)
                    {
                        response.IsValid = false;
                        response.ErrorMessage = "Error to execute Candidatura";
                        return response;
                    }
                    candidatura.EtapaCandidaturaId = (int)dto.EtapaFinId;
                    candidatura.EstadoCandidaturaId = (int)dto.EstadoFinId;

                    if (_candidaturaRepository.Update(candidatura) <= 0)
                    {
                        response.IsValid = false;
                        response.ErrorMessage = "Error to execute Candidatura";
                        return response;
                    }

                    //se crea la bitacora aqui porque si lo sacamos fuiera del if no tenemos vision sobre el dto
                    var bitacoraResponse = _bitacoraService.GenerateBitacoraCambioEstadoCandidatura(
                        candidaturaId, estadoCandidaturaInicial, dto.EstadoFinId.Value,
                        etapaCandidaturaInicial, dto.EtapaFinId.Value, tipoDecisionId);

                    response.IsValid = bitacoraResponse.IsValid;
                    response.ErrorMessage = bitacoraResponse.ErrorMessage;

                }
                else
                {
                    candidatura.EtapaCandidaturaId = (int)TipoEtapaCandidaturaEnum.PendienteDecisionCartaOferta;
                    candidatura.EstadoCandidaturaId = (int)TipoEstadoCandidaturaEnum.CartaOferta;

                    if (_candidaturaRepository.Update(candidatura) <= 0)
                    {
                        response.IsValid = false;
                        response.ErrorMessage = "Error to execute Candidatura";
                        return response;
                    }

                    //se crea la bitacora saltando
                    var bitacoraResponse = _bitacoraService.GenerateBitacoraCambioEstadoCandidatura(
                        candidaturaId, estadoCandidaturaInicial, (int)TipoEstadoCandidaturaEnum.CartaOferta,
                        etapaCandidaturaInicial, (int)TipoEtapaCandidaturaEnum.PendienteDecisionCartaOferta, (int)TipoDecisionEnum.SIN_DECISION_IRCARTAOFERTA);

                    response.IsValid = bitacoraResponse.IsValid;
                    response.ErrorMessage = bitacoraResponse.ErrorMessage;
                }



            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public ExistAnyCVBlobInDBResponse ExistAnyCVBlobInDB()
        {
            var response = new ExistAnyCVBlobInDBResponse();
            try
            {


                var result = _candidaturaRepository.CountByCriteria(x => x.CV != null);
                if (result > 0)
                {
                    response.exists = true;
                    response.IsValid = true;
                }
                else
                {
                    response.exists = false;
                    response.IsValid = true;
                }
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

        public EstoyEnCandidaturaEstadoPendienteEntrevistaDosResponse EstoyEnCandidaturaEstadoPendienteEntrevistaDos(int candidaturaId)
        {
            var response = new EstoyEnCandidaturaEstadoPendienteEntrevistaDosResponse();
            try
            {
                var respose = _candidaturaRepository.GetOne(x => x.CandidaturaId == candidaturaId);
                if (respose.EtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.PendienteDecisionSegundaEntrevista)
                {
                    response.estoy = true;
                    response.IsValid = true;
                }
                else
                {
                    response.estoy = false;
                    response.IsValid = true;
                }
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;

        }

        public TieneSubEntrevistasSinCompletarResponse TieneSubEntrevistasSinCompletar(int candidaturaId, int tipoEntrevistaId)
        {
            var response = new TieneSubEntrevistasSinCompletarResponse();
            try
            {
                response.IsValid = true;
                response.TieneSubentrevistas = false;
                var subentrevistas = GetListaSubEntrevistas(candidaturaId, tipoEntrevistaId);
                foreach (var subentrevista in subentrevistas.ListaSubEntrevistas)
                {
                    if (subentrevista.SubEntrevistaId != null && subentrevista.SubEntrevistaId > 0 && (!subentrevista.Completada || !subentrevista.SuperaSubEntrevista))
                    {
                        response.TieneSubentrevistas = true;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

        public GetListaSubEntrevistasResponse GetListaSubEntrevistas(int candidaturaId, int tipoEntrevista)
        {
            int nSubEntrevistas = Convert.ToInt16(ConfigurationManager.AppSettings["numeroMaximoSubEntrevistas"].ToString());
            var response = new GetListaSubEntrevistasResponse();
            response.ListaSubEntrevistas = new List<SubEntrevistaViewModel>();
            try
            {
                var entrevistaAsignada = _entrevistaRepository.GetOne(x => x.CandidaturaId == candidaturaId
                                                                      && x.IsActivo && x.TipoEntrevistaId == tipoEntrevista);
                if (entrevistaAsignada != null)
                {
                    var subEntrevistas = _subentrevistaRepository.GetByCriteria(x => x.IsActivo && x.EntrevistaId == entrevistaAsignada.EntrevistaId).ToList();
                    foreach (SubEntrevista subEntrevista in subEntrevistas)
                    {
                        var subEntrevistaViewModel = CandidaturaSubEntrevistaMapper.ConvertToSubEntrevistaViewModel(subEntrevista);
                        response.ListaSubEntrevistas.Add(subEntrevistaViewModel);
                    }
                    var numeroDeSubEntrevistas = response.ListaSubEntrevistas.Count;
                    if (numeroDeSubEntrevistas < nSubEntrevistas)
                    {
                        for (var i = 1; i <= nSubEntrevistas - numeroDeSubEntrevistas; i++)
                        {
                            var subEntrevistaVacia = new SubEntrevistaViewModel();
                            response.ListaSubEntrevistas.Add(subEntrevistaVacia);
                        }
                    }
                    response.IsValid = true;
                }
                else
                {
                    for (var i = 1; i <= nSubEntrevistas; i++)
                    {
                        var subEntrevistaVacia = new SubEntrevistaViewModel();
                        response.ListaSubEntrevistas.Add(subEntrevistaVacia);
                        response.IsValid = true;
                    }
                }
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

        public GetListaSubEntrevistasByEntrevistaIdResponse GetListaSubEntrevistasByEntrevistaId(int entrevistaId)
        {
            var response = new GetListaSubEntrevistasByEntrevistaIdResponse();
            response.subEntrevistalistViewModel = new SubEntrevistaListViewModel();
            response.subEntrevistalistViewModel.SubEntrevistaList = new List<SubEntrevistaViewModel>();
            int nSubEntrevistas = Convert.ToInt16(ConfigurationManager.AppSettings["numeroMaximoSubEntrevistas"].ToString());
            try
            {
                response.IsValid = false;
                var entrevista = _entrevistaRepository.GetOne(x => x.EntrevistaId == entrevistaId);
                if (entrevista != null)
                {
                    var listaSubEntrevistas = entrevista.SubEntrevista.Where(y => y.IsActivo).Select(x => CandidaturaSubEntrevistaMapper.ConvertToSubEntrevistaViewModel(x)).ToList();
                    var numeroDeSubEntrevistas = listaSubEntrevistas.Count;
                    if (numeroDeSubEntrevistas < nSubEntrevistas)
                    {
                        for (var i = 1; i <= nSubEntrevistas - numeroDeSubEntrevistas; i++)
                        {
                            var subEntrevistaVacia = new SubEntrevistaViewModel();
                            listaSubEntrevistas.Add(subEntrevistaVacia);
                        }
                    }
                    response.subEntrevistalistViewModel.SubEntrevistaList = listaSubEntrevistas;
                    response.subEntrevistalistViewModel.TipoEntrevista = entrevista.TipoEntrevistaId;
                    response.subEntrevistalistViewModel.Moneda = entrevista.Candidatura.Moneda;
                    response.IsValid = true;
                    response.candidaturaId = entrevista.CandidaturaId;
                }
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

        public GetMonedaCandidaturaResponse GetMonedaCandidatura(int candidaturaId)
        {
            var response = new GetMonedaCandidaturaResponse();

            try
            {
                var candidatura = _candidaturaRepository.GetOne(x => x.CandidaturaId == candidaturaId);
                response.Moneda = candidatura.Moneda;
                response.IsValid = true;
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public TieneAvisoConLaMismaFechaSubEntrevistaResponse TieneAvisoConLaMismaFechaSubEntrevista(DateTime[] fechas, int candidaturaId, int tipoEntrevista)
        {
            var response = new TieneAvisoConLaMismaFechaSubEntrevistaResponse();
            try
            {
                var candidatura = _candidaturaRepository.GetOne(x => x.CandidaturaId == candidaturaId);
                foreach (var entrevista in candidatura.Entrevistas)
                {
                    if (entrevista.TipoEntrevistaId == tipoEntrevista)
                    {
                        if (entrevista.AvisarAlCandidato && fechas.Any(x => x.Date == entrevista.FechaEntrevista.Date))
                        {
                            response.IsValid = true;
                            response.Tiene = true;
                            return response;
                        }
                        foreach (var subEntrevista in entrevista.SubEntrevista)
                        {
                            if (fechas.Any(x => (x.Date == subEntrevista.FechaEntrevista.Date)) && subEntrevista.IsActivo && subEntrevista.AvisarAlCandidato)
                            {
                                response.IsValid = true;
                                response.Tiene = true;
                                return response;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }
            response.IsValid = true;
            response.Tiene = false;
            return response;
        }

        #endregion

        #region ChangeStateRequest

        public PauseCandidaturaResponse PauseCandidatura(int candidaturaId, DateTime? fechaContactoStandBy = null)
        {
            var response = new PauseCandidaturaResponse();

            try
            {
                var candidatura = _candidaturaRepository.GetOne(x => x.CandidaturaId == candidaturaId);

                if (candidatura != null)
                {
                    //se guardan los estados iniciales de la candidatura antes de pausar la candidatura
                    int estadoCandidaturaInicial = candidatura.EstadoCandidaturaId;
                    int etapaCandidaturaInicial = candidatura.EtapaCandidaturaId;

                    var tipoDecisionId = GetDecisionByCandidaturaEtapaId(etapaCandidaturaInicial, estadoCandidaturaInicial, true);

                    var dto = _workflowCandidaturaService.Execute(etapaCandidaturaInicial, tipoDecisionId);

                    if (dto.IsValid)
                    {
                        candidatura.EtapaCandidaturaId = (int)dto.EtapaFinId;
                        candidatura.EstadoCandidaturaId = (int)dto.EstadoFinId;
                        candidatura.FechaContactoStandBy = fechaContactoStandBy;

                        if (_candidaturaRepository.Update(candidatura) > 0)
                        {
                            var bitacoraResponse = _bitacoraService.GenerateBitacoraPausarReanudar(candidaturaId, true);

                            response.IsValid = bitacoraResponse.IsValid;
                            response.ErrorMessage = bitacoraResponse.ErrorMessage;
                        }
                        else
                        {
                            response.IsValid = false;
                            response.ErrorMessage = "Error to pause Candidatura";
                        }
                    }
                    else
                    {
                        response.IsValid = false;
                        response.ErrorMessage = "Error to pause Candidatura";
                    }
                }
                else
                {
                    response.IsValid = false;
                    response.ErrorMessage = "Error to pause Candidatura";
                }

            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public ResumeCandidaturaResponse ResumeCandidatura(int candidaturaId)
        {
            var response = new ResumeCandidaturaResponse();

            try
            {
                var candidatura = _candidaturaRepository.GetOne(x => x.CandidaturaId == candidaturaId);

                if (candidatura != null)
                {
                    //se guardan los estados iniciales de la candidatura antes de pausar la candidatura
                    int estadoCandidaturaInicial = candidatura.EstadoCandidaturaId;
                    int etapaCandidaturaInicial = candidatura.EtapaCandidaturaId;

                    var tipoDecisionId = GetDecisionByCandidaturaEtapaId(etapaCandidaturaInicial, estadoCandidaturaInicial, true);

                    var dto = _workflowCandidaturaService.Execute(etapaCandidaturaInicial, tipoDecisionId);

                    if (dto.IsValid)
                    {
                        candidatura.EtapaCandidaturaId = (int)dto.EtapaFinId;
                        candidatura.EstadoCandidaturaId = (int)dto.EstadoFinId;
                        candidatura.FechaContactoStandBy = null;

                        if (_candidaturaRepository.Update(candidatura) > 0)
                        {
                            var bitacoraResponse = _bitacoraService.GenerateBitacoraPausarReanudar(candidaturaId, false);

                            response.IsValid = bitacoraResponse.IsValid;
                            response.ErrorMessage = bitacoraResponse.ErrorMessage;
                        }
                        else
                        {
                            response.IsValid = false;
                            response.ErrorMessage = "Error to resume Candidatura";
                        }
                    }
                    else
                    {
                        response.IsValid = false;
                        response.ErrorMessage = "Error to resume Candidatura";
                    }
                }

            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public RevokeCandidaturaResponse RevokeCandidatura(int candidaturaId, int TipoRenunciaDescarte, string ComentariosRenunciaDescarte = null)
        {
            var response = new RevokeCandidaturaResponse();

            try
            {
                var candidatura = _candidaturaRepository.GetOne(x => x.CandidaturaId == candidaturaId);

                int estadoCandidaturaInicial = candidatura.EstadoCandidaturaId;
                int etapaCandidaturaInicial = candidatura.EtapaCandidaturaId;

                candidatura.MotivoRenunciaDescarteId = TipoRenunciaDescarte;
                candidatura.EstadoCandidaturaId = (int)TipoEstadoCandidaturaEnum.Renuncia;
                candidatura.ComentariosRenunciaDescarte = ComentariosRenunciaDescarte;

                if (_candidaturaRepository.Update(candidatura) > 0)
                {
                    var responseVitacora = _bitacoraService.GenerateBitacoraRenunciaCandidatura(
                        candidaturaId: candidatura.CandidaturaId,
                        estadoAnteriorId: estadoCandidaturaInicial,
                        estadoNuevoId: candidatura.EstadoCandidaturaId,
                        etapaAnteriorId: etapaCandidaturaInicial,
                        motivoRenunciaId: candidatura.MotivoRenunciaDescarteId.Value);

                    response.IsValid = responseVitacora.IsValid;
                    response.ErrorMessage = responseVitacora.ErrorMessage;
                    CheckAndOpenNecesidades(candidatura.CandidaturaId, candidatura.CandidatoId);
                }
                else
                {
                    response.IsValid = false;
                    response.ErrorMessage = "Error to revoke Candidatura";
                }
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public DiscardCandidaturaResponse DiscardCandidatura(int candidaturaId, int TipoRenunciaDescarte, string ComentariosRenunciaDescarte = null)
        {
            var response = new DiscardCandidaturaResponse();

            try
            {
                var candidatura = _candidaturaRepository.GetOne(x => x.CandidaturaId == candidaturaId);

                int estadoCandidaturaInicial = candidatura.EstadoCandidaturaId;
                int etapaCandidaturaInicial = candidatura.EtapaCandidaturaId;

                if ((candidatura.EstadoCandidaturaId == (int)TipoEstadoCandidaturaEnum.CartaOferta && candidatura.EtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.AgendarCartaOferta)
                    || (candidatura.EstadoCandidaturaId == (int)TipoEstadoCandidaturaEnum.Entrevista && candidatura.EtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.FiltradoTelefonico)
                    || (candidatura.EstadoCandidaturaId == (int)TipoEstadoCandidaturaEnum.Entrevista && candidatura.EtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.AgendarEntrevistas)
                    || (candidatura.EstadoCandidaturaId == (int)TipoEstadoCandidaturaEnum.SegundaEntrevista && candidatura.EtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.AgendarSegundaEntrevista))
                {
                    candidatura.NotificarDescarte = false;
                }

                candidatura.EstadoCandidaturaId = (int)TipoEstadoCandidaturaEnum.Descartado;

                candidatura.ComentariosRenunciaDescarte = ComentariosRenunciaDescarte;
                candidatura.MotivoRenunciaDescarteId = TipoRenunciaDescarte;
                
                if (_candidaturaRepository.Update(candidatura) > 0)
                {
                    var responseVitacora = _bitacoraService.GenerateBitacoraDescarteCandidatura(
                        candidaturaId: candidatura.CandidaturaId,
                        estadoAnteriorId: estadoCandidaturaInicial,
                        estadoNuevoId: candidatura.EstadoCandidaturaId,
                        etapaAnteriorId: etapaCandidaturaInicial,
                        motivoDescarteId: candidatura.MotivoRenunciaDescarteId.Value);

                    response.IsValid = responseVitacora.IsValid;
                    response.ErrorMessage = responseVitacora.ErrorMessage;
                    CheckAndOpenNecesidades(candidatura.CandidaturaId, candidatura.CandidatoId);
                }
                else
                {
                    response.IsValid = false;
                    response.ErrorMessage = "Error to revoke Candidatura";
                }
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public SaveEmailSeguirCandidaturaResponse SaveEmailSeguirCandidatura(int id, string email)
        {
            var response = new SaveEmailSeguirCandidaturaResponse();

            try
            {
                var candidatura = _candidaturaRepository.GetOne(x => x.CandidaturaId == id && x.IsActivo);
                candidatura.EmailsSeguimiento = candidatura.EmailsSeguimiento + email + ";";
                _candidaturaRepository.Update(candidatura);
                response.IsValid = true;
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;

        }

        public DeleteEmailSeguirCandidaturaResponse DeleteEmailSeguirCandidatura(int id, string email)
        {
            var response = new DeleteEmailSeguirCandidaturaResponse();

            try
            {
                var candidatura = _candidaturaRepository.GetOne(x => x.CandidaturaId == id && x.IsActivo);
                candidatura.EmailsSeguimiento = candidatura.EmailsSeguimiento.Replace(email + ';', "");
                _candidaturaRepository.Update(candidatura);
                response.IsValid = true;
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;

        }

        public void CheckAndOpenNecesidades(int candidaturaId, int candidatoId)
        {
            var response = _necesidadService.GetNecesidadByCandidaturaIdAndCandidatoId(candidaturaId, candidatoId);
            if (response.IsValid)
            {
                var responseNecesidadAbrir = _necesidadService.GetNecesidadById(response.necesidadId);
                if (responseNecesidadAbrir.IsValid)
                {
                    var necesidad = _necesidadRepository.GetOne(x => x.IsActivo && x.NecesidadId == responseNecesidadAbrir.NecesidadViewModel.NecesidadId);
                    if (necesidad != null)
                    {
                        necesidad.EstadoNecesidadId = (int)EstadoNecesidadEnum.Abierta;
                        necesidad.PersonaAsignada = null;
                        necesidad.PersonaAsignadaId = null;
                        necesidad.CandidaturaId = null;
                        _necesidadRepository.Update(necesidad);
                    }
                }
            }
        }

        public RecontactarCandidaturaResponse RecontactarCandidaturaActual(CandidaturaViewModel candidaturaViewModel)
        {
            var response = new RecontactarCandidaturaResponse();
            if (candidaturaViewModel.CandidaturaDatosBasicosViewModel != null)
            {
                var candidatura = _candidaturaRepository.GetOne(x => x.CandidaturaId == candidaturaViewModel.CandidaturaId);
                var estadoCandidaturaInicial = candidaturaViewModel.CandidaturaDatosBasicosViewModel.DatosBasicos.EstadoCandidaturaId;
                var etapaCandidaturaInicial = candidaturaViewModel.CandidaturaDatosBasicosViewModel.DatosBasicos.EtapaCandidaturaId;
                candidatura.EstadoCandidaturaId = (int)TipoEstadoCandidaturaEnum.Recontactado;
                if (_candidaturaRepository.Update(candidatura) > 0)
                {
                    response.IsValid = true;
                    var bitacoraResponse = _bitacoraService.GenerateBitacoraCambioEstadoCandidatura(candidatura.CandidaturaId, estadoCandidaturaInicial, (int)TipoEstadoCandidaturaEnum.Recontactado,
                        etapaCandidaturaInicial, etapaCandidaturaInicial);

                    response.IsValid = bitacoraResponse.IsValid;
                    response.ErrorMessage = bitacoraResponse.ErrorMessage;
                    CheckAndOpenNecesidades(candidatura.CandidaturaId, candidatura.CandidatoId);
                }
                else
                {
                    response.IsValid = false;
                }
            }
            return response;
        }

        public CrearCandidaturaRecontactadaResponse CrearCandidaturaRecontactada(CandidaturaViewModel candidaturaViewModel)
        {
            var response = new CrearCandidaturaRecontactadaResponse();
            Candidatura candidatura = new Candidatura();

            try
            {
                candidaturaViewModel.CandidaturaDatosBasicosViewModel.DatosBasicos.CandidaturaId = null;
                candidatura.UpdateCandidatura(candidaturaViewModel.CandidaturaDatosBasicosViewModel);
                //Se añade que se ha recontactado al campo observaciones
                candidatura.FiltradoCV = true;
                candidatura.DescartarFuturasCandidaturas = false;
                candidatura.Observaciones = "Candidatura Generada Automáticamente al Recontactar";
                candidatura.EstadoCandidaturaId = (int)TipoEstadoCandidaturaEnum.Entrevista;
                candidatura.EtapaCandidaturaId = (int)TipoEtapaCandidaturaEnum.FiltradoTelefonico;

                _candidaturaRepository.Create(candidatura);

              
                var candidaturaRecontactada = _candidaturaRepository.GetOne(x => x.IsActivo && x.CandidatoId == candidaturaViewModel.CandidaturaDatosBasicosViewModel.DatosBasicos.CandidatoId &&
                                                                x.EstadoCandidaturaId == (int)TipoEstadoCandidaturaEnum.Entrevista &&
                                                                x.EtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.FiltradoTelefonico);

                if (candidaturaRecontactada != null)
                {
                    var responseCandidaturaRecontactada = DownloadCV((int)candidaturaViewModel.CandidaturaId);
                    if (responseCandidaturaRecontactada.NombreCV != null)
                    {
                        var rutaReal = System.IO.Path.Combine(responseCandidaturaRecontactada.UrlCV, responseCandidaturaRecontactada.CandidaturaId.ToString());
                        byte[] CVParsed = System.IO.File.ReadAllBytes(rutaReal + SeparatorBar + responseCandidaturaRecontactada.NombreCV);

                        UploadCV(CVParsed, candidatura.CandidaturaId, responseCandidaturaRecontactada.NombreCV);
                    }
                }
                


                response.IsValid = true;
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public RevertirCandidaturaRecontactadaResponse RevertirCandidaturaRecontactada(CandidaturaViewModel candidaturaViewModel)
        {
            var response = new RevertirCandidaturaRecontactadaResponse();
            if (candidaturaViewModel.CandidaturaDatosBasicosViewModel != null)
            {
                var candidatura = _candidaturaRepository.GetOne(x => x.CandidaturaId == candidaturaViewModel.CandidaturaId);
                var estadoCandidaturaInicial = candidaturaViewModel.CandidaturaDatosBasicosViewModel.DatosBasicos.EstadoCandidaturaId;
                var etapaCandidaturaInicial = candidaturaViewModel.CandidaturaDatosBasicosViewModel.DatosBasicos.EtapaCandidaturaId;
                candidatura.EstadoCandidaturaId = (int)TipoEstadoCandidaturaEnum.StandBy;
                if (_candidaturaRepository.Update(candidatura) > 0)
                {
                    response.IsValid = true;
                    var bitacoraResponse = _bitacoraService.GenerateBitacoraCambioEstadoCandidatura(candidatura.CandidaturaId, estadoCandidaturaInicial, (int)TipoEstadoCandidaturaEnum.Recontactado,
                        etapaCandidaturaInicial, etapaCandidaturaInicial);

                    response.IsValid = bitacoraResponse.IsValid;
                    response.ErrorMessage = bitacoraResponse.ErrorMessage;
                }
                else
                {
                    response.IsValid = false;
                }
            }
            return response;
        }


        public ReschedulePrimeraEntrevistaResponse ReschedulePrimeraEntrevista(int candidaturaId)
        {
            var response = new ReschedulePrimeraEntrevistaResponse();

            try
            {
                var candidatura = _candidaturaRepository.GetOne(x => x.CandidaturaId == candidaturaId);
                var dto = _workflowCandidaturaService.Execute(
                    candidatura.EtapaCandidaturaId,
                    (int)TipoDecisionEnum.SIN_DECISION_REAGENDAR1);

                if (dto.IsValid)
                {
                    candidatura.EtapaCandidaturaId = (int)dto.EtapaFinId;
                    candidatura.EstadoCandidaturaId = (int)dto.EstadoFinId;
                    if (_candidaturaRepository.Update(candidatura) > 0)
                    {
                        response.IsValid = true;
                    }
                    else
                    {
                        response.IsValid = false;
                        response.ErrorMessage = "Error to reschedule Primera Entrevista";
                    }
                }
                else
                {
                    response.IsValid = false;
                    response.ErrorMessage = "Error to reschedule Primera Entrevista";
                }
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public RescheduleSegundaEntrevistaResponse RescheduleSegundaEntrevista(int candidaturaId)
        {
            var response = new RescheduleSegundaEntrevistaResponse();

            try
            {
                var candidatura = _candidaturaRepository.GetOne(x => x.CandidaturaId == candidaturaId);
                var dto = _workflowCandidaturaService.Execute(
                    candidatura.EtapaCandidaturaId,
                    (int)TipoDecisionEnum.SIN_DECISION_REAGENDAR2);

                if (dto.IsValid)
                {
                    candidatura.EtapaCandidaturaId = (int)dto.EtapaFinId;
                    candidatura.EstadoCandidaturaId = (int)dto.EstadoFinId;
                    if (_candidaturaRepository.Update(candidatura) > 0)
                    {
                        response.IsValid = true;
                    }
                    else
                    {
                        response.IsValid = false;
                        response.ErrorMessage = "Error to reschedule Segunda Entrevista";
                    }
                }
                else
                {
                    response.IsValid = false;
                    response.ErrorMessage = "Error to reschedule Segunda Entrevista";
                }
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public RescheduleCartaOfertaResponse RescheduleCartaOferta(int candidaturaId)
        {
            var response = new RescheduleCartaOfertaResponse();

            try
            {
                var candidatura = _candidaturaRepository.GetOne(x => x.CandidaturaId == candidaturaId);
                var dto = _workflowCandidaturaService.Execute(
                    candidatura.EtapaCandidaturaId,
                    (int)TipoDecisionEnum.SIN_DECISION_CARTAOFERTA);

                if (dto.IsValid)
                {
                    candidatura.EtapaCandidaturaId = (int)dto.EtapaFinId;
                    candidatura.EstadoCandidaturaId = (int)dto.EstadoFinId;
                    if (_candidaturaRepository.Update(candidatura) > 0)
                    {
                        response.IsValid = true;
                    }
                    else
                    {
                        response.IsValid = false;
                        response.ErrorMessage = "Error to reschedule Carta Oferta";
                    }
                }
                else
                {
                    response.IsValid = false;
                    response.ErrorMessage = "Error to reschedule Carta Oferta";
                }
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }


        public BacktrackCandidaturaResponse BacktrackCandidatura(int candidaturaId)
        {
            var response = new BacktrackCandidaturaResponse();

            try
            {
                var bitacorasRevertibles = _bitacoraRepository.GetByCriteria(x => x.CandidaturaId == candidaturaId && x.TipoBitacora.HasValue && x.Revertible.HasValue && x.Revertible.Value);

                bitacorasRevertibles = bitacorasRevertibles.OrderByDescending(x => x.BitacoraId);
                var bitacoraARevertir = bitacorasRevertibles.FirstOrDefault();

                if (bitacoraARevertir != null)
                {
                    var candidatura = _candidaturaRepository.GetOne(x => x.CandidaturaId == candidaturaId);

                    if (candidatura != null)
                    {
                        var tipoBitacora = (TipoBitacoraEnum)bitacoraARevertir.TipoBitacora.Value;

                        if (tipoBitacora == TipoBitacoraEnum.Renuncia)
                        {
                            candidatura.MotivoRenunciaDescarteId = null;                 
                            
                        }

                        if (candidatura.CartaOfertas.Any())
                            candidatura.CartaOfertas.ElementAt(0).Acepta = null;
                        else {
                            if(candidatura.Entrevistas.Any())
                            {
                                if (candidatura.Entrevistas.Count > 1)
                                    candidatura.Entrevistas.ElementAt(1).SinDecision = true;
                                else
                                    candidatura.Entrevistas.ElementAt(0).SinDecision = true;
                            }
                        }

                        if (bitacoraARevertir.EstadoAnteriorId.HasValue)
                        {
                            candidatura.EstadoCandidaturaId = bitacoraARevertir.EstadoAnteriorId.Value;
                        }
                        if (bitacoraARevertir.EtapaAnteriorId.HasValue)
                        {
                            candidatura.EtapaCandidaturaId = bitacoraARevertir.EtapaAnteriorId.Value;
                            if (bitacoraARevertir.EtapaAnteriorId == (int)TipoEtapaCandidaturaEnum.FeedbackCartaOferta)
                            {
                                //abrir necesidad
                                int? necesidadId = candidatura.CartaOfertas.FirstOrDefault().NecesidadId;
                                if (necesidadId.HasValue)
                                {
                                    _necesidadService.AbrirNecesidad(necesidadId.Value);
                                    var necesidad = _necesidadService.GetNecesidadById(necesidadId.Value);
                                    if (necesidad.IsValid && necesidad.NecesidadViewModel.GrupoNecesidad.HasValue)
                                    {
                                        var _grupoNecesidadRepository = new GrupoNecesidadRepository();
                                        var _grupoNecesidadService = new GrupoNecesidadService(_grupoNecesidadRepository, _necesidadRepository);
                                        _grupoNecesidadService.CheckGrupoCerrado(necesidad.NecesidadViewModel.GrupoNecesidad.Value);
                                    }
                                }
                            }
                        }

                        _candidaturaRepository.Update(candidatura);

                        bitacoraARevertir.Revertible = false;
                        _bitacoraRepository.Update(bitacoraARevertir);

                        _bitacoraService.GenerateBitacoraRetroceder(candidatura.CandidaturaId, bitacoraARevertir.BitacoraId);
                        response.IsValid = true;
                    }
                }
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

        #endregion

        #region ActionRequest


        public EditCandidaturaResponse SaveEditCandidatura(CandidaturaViewModel viewModel,
            string nombreEntregaCarta, string cargoEntregaCarta, string telefono, string telefonoContratacion, string mailTo, string atencionTelefonica, string ayudaComedor, string fax, string textoCartaOfertaPDF)
        {
            var response = new EditCandidaturaResponse();
            try
            {
                int idNecesidadPrevia = 0;
                var candidatura = _candidaturaRepository.GetOne(x => x.CandidaturaId == viewModel.CandidaturaId);
                //comprobamos si tenemos que actualizar la nueva necesidad
                var co = candidatura.CartaOfertas.FirstOrDefault();
                if (co != null)
                {
                    idNecesidadPrevia = co.NecesidadId.HasValue ? co.NecesidadId.Value : 0;
                }
                if (co != null && co.Necesidad != null && viewModel.CompletarCartaOfertaViewModel != null && viewModel.CompletarCartaOfertaViewModel.CompletarCartaOferta != null &&
                    viewModel.CompletarCartaOfertaViewModel.CompletarCartaOferta.AsignadaCorrectamente != co.Necesidad.AsignadaCorrectamente)
                {
                    var necesidadNueva = _necesidadRepository.GetOne(x => x.IsActivo && x.NecesidadId == viewModel.CompletarCartaOfertaViewModel.CompletarCartaOferta.NecesidadId);
                    if (necesidadNueva != null)
                    {
                        necesidadNueva.AsignadaCorrectamente = viewModel.CompletarCartaOfertaViewModel.CompletarCartaOferta.AsignadaCorrectamente;
                        _necesidadRepository.Update(necesidadNueva);
                    }
                }

                if (viewModel.CandidaturaDatosBasicosViewModel.DatosBasicos.IdiomaCandidatoViewModel == null) {
                    viewModel.CandidaturaDatosBasicosViewModel.DatosBasicos.IdiomaCandidatoViewModel = new List<CreateEditRowIdiomaCandidaturaViewModel>();
                }

                if (viewModel.CandidaturaDatosBasicosViewModel.DatosBasicos.ExpCandidatoViewModel == null)
                {
                    viewModel.CandidaturaDatosBasicosViewModel.DatosBasicos.ExpCandidatoViewModel = new List<ViewModels.CreateEditRowExperienciaCandidatoViewModel>();
                }

                //mappear
                candidatura.UpdateCandidaturaModoEdit(viewModel);
                //guardamos los idiomas y la experiencia IT
     
                var candidato = _candidatoRepository.GetOne(x => x.CandidatoId == viewModel.CandidaturaDatosBasicosViewModel.DatosBasicos.CandidatoId);
                var candidatoExperienciaToRemove = GetCandidatoExperienciasToRemove(candidato, viewModel.CandidaturaDatosBasicosViewModel);
                var candidatoIdiomaToRemove = GetCandidatoIdiomasToRemove(candidato, viewModel.CandidaturaDatosBasicosViewModel);

                candidato.UpdateCandidato(viewModel.CandidaturaDatosBasicosViewModel);

                _candidatoRepository.Update(candidato);

                foreach (var idioma in candidatoIdiomaToRemove)
                {
                    _candidatoIdiomaRepository.Delete(x => x.CandidatoIdiomasId == idioma);
                }

                foreach (var experiencia in candidatoExperienciaToRemove)
                {
                    _candidatoExperienciaRepository.Delete(x => x.CandidatoExperienciaId == experiencia);
                }

                //guardar
                if (_candidaturaRepository.Update(candidatura) > 0)
                {
                    if (candidatura.EtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.EntregaCartaOferta
                        || candidatura.EtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.FeedbackCartaOferta
                           || candidatura.EtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.Fin)
                    {
                        byte[] cartaOfertaGenerada = PdfHelper.GenerarCartaOfertaForCartaOfertaPdfViewModel("Carta Oferta", "Everis",
                        CandidaturaCartaOfertaMapper.ConvertToCartaOfertaPdfViewModel(candidatura, nombreEntregaCarta, cargoEntregaCarta, telefono, telefonoContratacion, mailTo, atencionTelefonica, ayudaComedor, fax), textoCartaOfertaPDF);

                        if (cartaOfertaGenerada.Length > 0)
                        {
                            UploadCartaOfertaGeneradaResponse responseCO = UploadCartaOfertaGenerada(cartaOfertaGenerada, candidatura.CandidaturaId);
                            if (!responseCO.IsValid)
                            {
                                response.IsValid = false;
                                response.ErrorMessage = responseCO.ErrorMessage;
                            }
                        }
                        else
                        {
                            response.ErrorMessage = "Carta oferta NO GENERADA!!!";
                        }

                        //ademas si la necesidad ha cambiado se que pone la necesidad anterior abierta y se le quita la fecha de cierre que tenga
                        //la nueva debe estar en estado Cerrada, con la Fecha de cierre igual a la fecha de incorporación.
                        SaveNecesidadResponse responseAbrirNecesidad = null;
                        SaveNecesidadResponse responseCerrarNecesidad = null;

                        if ((idNecesidadPrevia != 0) && (viewModel.CompletarCartaOfertaViewModel.CompletarCartaOferta != null) && (idNecesidadPrevia != viewModel.CompletarCartaOfertaViewModel.CompletarCartaOferta.NecesidadId))
                        {
                            responseAbrirNecesidad = _necesidadService.AbrirNecesidad(idNecesidadPrevia);
                        }

                        if ((responseAbrirNecesidad != null) &&
                            responseAbrirNecesidad.IsValid &&
                            viewModel.CompletarCartaOfertaViewModel.CompletarCartaOferta.NecesidadId.HasValue)
                        {
                            responseCerrarNecesidad = _necesidadService.CerrarNecesidad(viewModel.CompletarCartaOfertaViewModel.CompletarCartaOferta.NecesidadId.Value,
                                            viewModel.CompletarCartaOfertaViewModel.CompletarCartaOferta.FechaIncorporacion.Value);

                            response.IsValid = true;
                        }

                        if (responseAbrirNecesidad != null && !responseAbrirNecesidad.IsValid)
                        {
                            response.IsValid = false;
                            response.ErrorMessage = responseAbrirNecesidad.ErrorMessage;
                        }
                        if (responseCerrarNecesidad != null && !responseCerrarNecesidad.IsValid)
                        {
                            response.IsValid = false;
                            response.ErrorMessage = responseCerrarNecesidad.ErrorMessage;
                        }
                    }

                    //se le crea la bitacora para guardar que se ha editado
                    var bitacoraResponse = _bitacoraService.GenerateBitacoraEdicionCandidatura(candidatura.CandidaturaId);

                    response.IsValid = bitacoraResponse.IsValid;
                    response.ErrorMessage = bitacoraResponse.ErrorMessage;
                }
                else
                {
                    response.IsValid = false;
                    response.ErrorMessage = "Error to update Candidatura";
                }

            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public SaveCandidaturaResponse SaveCandidatura(CandidaturaDatosBasicosViewModel candidaturaDatosBasicosViewModel, bool changeEtapa)
        {
            var response = new SaveCandidaturaResponse() { IsValid = true };

            try
            {
                var candidatura = new Candidatura();
                

                if (candidaturaDatosBasicosViewModel.DatosBasicos.CandidaturaId.HasValue)
                {
                    candidatura = _candidaturaRepository.GetOne(x => x.CandidaturaId == candidaturaDatosBasicosViewModel.DatosBasicos.CandidaturaId.Value);
                }

                if (candidaturaDatosBasicosViewModel.DatosBasicos.IdiomaCandidatoViewModel == null)
                {
                    candidaturaDatosBasicosViewModel.DatosBasicos.IdiomaCandidatoViewModel = new List<CreateEditRowIdiomaCandidaturaViewModel>();
                }

                if (candidaturaDatosBasicosViewModel.DatosBasicos.ExpCandidatoViewModel == null)
                {
                    candidaturaDatosBasicosViewModel.DatosBasicos.ExpCandidatoViewModel = new List<ViewModels.CreateEditRowExperienciaCandidatoViewModel>();
                }


                var candidato = _candidatoRepository.GetOne(x => x.CandidatoId == candidaturaDatosBasicosViewModel.DatosBasicos.CandidatoId);
                var candidatoExperienciaToRemove = GetCandidatoExperienciasToRemove(candidato, candidaturaDatosBasicosViewModel);
                var candidatoIdiomaToRemove = GetCandidatoIdiomasToRemove(candidato, candidaturaDatosBasicosViewModel);

                candidato.UpdateCandidato(candidaturaDatosBasicosViewModel);

                _candidatoRepository.Update(candidato);

                foreach (var idioma in candidatoIdiomaToRemove)
                {
                    _candidatoIdiomaRepository.Delete(x => x.CandidatoIdiomasId == idioma);
                }

                foreach (var experiencia in candidatoExperienciaToRemove)
                {
                    _candidatoExperienciaRepository.Delete(x => x.CandidatoExperienciaId == experiencia);
                }



                candidatura.UpdateCandidatura(candidaturaDatosBasicosViewModel);
                if (candidatura.CandidaturaId > 0)
                {
                    _candidaturaRepository.Update(candidatura);
                }
                else
                {
                    candidatura.NumeroDeEntrevistas = 0;
                    candidatura = _candidaturaRepository.Create(candidatura);
                    candidatura.UrlCV = candidaturaDatosBasicosViewModel.DatosBasicos.UrlCV;
                    _bitacoraService.GenerateBitacoraCreateCandidatura(candidatura.CandidaturaId);
                }


                response.CandidaturaId = candidatura.CandidaturaId;
                response.NombreCV = candidatura.NombreCV;
                response.UbicacionCandidato = candidatura.UbicacionCandidato;
                response.AnioExperiencia = candidatura.AniosExperiencia;

                if (changeEtapa && (!ChangeEtapa(candidatura.CandidaturaId, (int)TipoDecisionEnum.SIN_DECISION_INICIO)))
                {
                        response.IsValid = false;
                        response.ErrorMessage = "Error to change state Candidatura";
                }
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public DownloadCVResponse DownloadCV(int candidaturaId)
        {
            CandidatoCandidaturaHelper relacionCandidaturaCandidato = new CandidatoCandidaturaHelper();

            return relacionCandidaturaCandidato.GetCVCandidaturaByCandidaturaId(_candidaturaRepository, candidaturaId);
        }

        public DownloadCartaGeneradaResponse DownloadCartaOfertaGenerada(int cartaOfertaId)
        {
            DownloadCartaGeneradaResponse cartaOfertaGenerada = PdfHelper.GetCartaOfertaGeneradaByCartaOfertaId(_cartaOfertaRepository, cartaOfertaId);
            return cartaOfertaGenerada;
        }

        public AsignToOfertaResponse AsignToOferta(int ofertaId, int candidaturaId)
        {
            var response = new AsignToOfertaResponse();

            try
            {
                var candidatura = _candidaturaRepository.GetOne(x => x.CandidaturaId == candidaturaId);
                candidatura.OfertaId = ofertaId;

                if (_candidaturaRepository.Update(candidatura) > 0)
                {
                    response.IsValid = true;
                }
                else
                {
                    response.IsValid = false;
                    response.ErrorMessage = "Error to asign Oferta to Candidatura";
                }
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public RemoveOfertaResponse RemoveOferta(int ofertaId, int candidaturaId)
        {
            var response = new RemoveOfertaResponse();

            try
            {
                var candidatura = _candidaturaRepository.GetOne(x => x.CandidaturaId == candidaturaId);
                candidatura.OfertaId = null;

                if (_candidaturaRepository.Update(candidatura) > 0)
                {
                    response.IsValid = true;
                }
                else
                {
                    response.IsValid = false;
                    response.ErrorMessage = "Error to remove Oferta to Candidatura";
                }
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public SaveFiltradoCVCandidaturaResponse SaveFiltradoCVCandidatura(CandidaturaFiltradoCvViewModel filtradoCVViewModel, bool changeEtapa)
        {
            var response = new SaveFiltradoCVCandidaturaResponse();

            try
            {
                var candidatura = _candidaturaRepository.GetOne(x => x.CandidaturaId == filtradoCVViewModel.CandidaturaId);
                candidatura.UpdateCandidatura(filtradoCVViewModel);
                if (_candidaturaRepository.Update(candidatura) > 0)
                {
                    if (changeEtapa)
                    {
                        var decision = filtradoCVViewModel.Filtrado ? (int)TipoDecisionEnum.SUPERA_FILTRADO : (int)TipoDecisionEnum.NO_SUPERA_FILTRADO;
                        if (ChangeEtapa(filtradoCVViewModel.CandidaturaId, decision))
                        {
                            response.IsValid = true;

                        }
                        else
                        {
                            response.IsValid = false;
                        }
                    }
                    else
                    {
                        response.IsValid = true;
                    }
                }
                else
                {
                    response.IsValid = false;
                    response.ErrorMessage = "Error to update Candidatura";
                }

            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public SaveSchedulePrimeraEntrevistaResponse SaveSchedulePrimeraEntrevista(AgendarPrimeraEntrevistaViewModel agendarViewModel, bool changeEtapa)
        {
            var response = new SaveSchedulePrimeraEntrevistaResponse();

            try
            {
                var candidatura = _candidaturaRepository.GetOne(x => x.CandidaturaId == agendarViewModel.AgendarPrimeraEntrevista.CandidaturaId);
                if (candidatura.Entrevistas != null)
                {
                    if (!candidatura.Entrevistas.Any(x => x.TipoEntrevistaId == (int)TipoEntrevistaEnum.PrimeraEntrevista))
                    {
                        response = InsertSchedulePrimeraEntrevista(agendarViewModel, changeEtapa);
                    }

                    else
                    {
                        response = UpdateSchedulePrimeraEntrevista(agendarViewModel, changeEtapa);
                    }
                }
                else
                {
                    response = InsertSchedulePrimeraEntrevista(agendarViewModel, changeEtapa);
                }
                response.IsValid = true;
                if (response.EntrevistaId > 0)
                {
                    var responseSaveSubentrevistas = SaveSubEntrevistas(agendarViewModel.SubEntrevistaList, response.EntrevistaId);
                    if (!responseSaveSubentrevistas.IsValid)
                    {
                        response.IsValid = false;
                        response.ErrorMessage = "error saving SubEntrevistas";
                    }
                }
            }
            catch (Exception ex)
            {
                response.IsValid = false; 
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public SavePrimeraEntrevistaResponse SavePrimeraEntrevista(PrimeraEntrevistaViewModel completarPrimeraEntrevistaViewModel, bool changeEtapa)
        {
            var response = new SavePrimeraEntrevistaResponse();

            try
            {
                var candidatura = _candidaturaRepository.GetOne(x => x.CandidaturaId == completarPrimeraEntrevistaViewModel.AgendarPrimeraEntrevista.AgendarPrimeraEntrevista.CandidaturaId);
                if (candidatura.Entrevistas != null)
                {
                    if (candidatura.Entrevistas.Any(x => x.TipoEntrevistaId == (int)TipoEntrevistaEnum.PrimeraEntrevista))
                    {
                        var entrevista = candidatura.Entrevistas.Single(x => x.TipoEntrevistaId == (int)TipoEntrevistaEnum.PrimeraEntrevista);
                        candidatura.UpdateCandidatura(completarPrimeraEntrevistaViewModel, entrevista.EntrevistaId);

                        if (_candidaturaRepository.Update(candidatura) > 0)
                        {
                            if (changeEtapa)
                            {
                                var decision = 0;

                                if (completarPrimeraEntrevistaViewModel.ResultadoPrimeraEntrevista.SuperaEntrevistaId == (int)TipoDecisionEnum.SUPERA_PRIMERA_ENTREVISTA)
                                {
                                   decision = (int)TipoDecisionEnum.SUPERA_PRIMERA_ENTREVISTA;
                                }
                                if (completarPrimeraEntrevistaViewModel.ResultadoPrimeraEntrevista.SuperaEntrevistaId == (int)TipoDecisionEnum.NO_SUPERA_PRIMERA_ENTREVISTA)
                                {
                                    decision = (int)TipoDecisionEnum.NO_SUPERA_PRIMERA_ENTREVISTA;
                                }
                                if (completarPrimeraEntrevistaViewModel.ResultadoPrimeraEntrevista.SuperaEntrevistaId == (int)TipoDecisionEnum.SIN_DECIDIR_PRIMERA_ENTREVISTA)
                                {
                                    decision = (int)TipoDecisionEnum.SIN_DECIDIR_PRIMERA_ENTREVISTA;
                                }

                                if (ChangeEtapa(candidatura.CandidaturaId, decision))
                                {
                                    response.IsValid = true;
                                }
                                else
                                {
                                    response.IsValid = false;
                                    response.ErrorMessage = "Error to change state Candidatura";
                                }
                            }
                            else
                            {
                                response.IsValid = true;
                            }
                        }
                        else
                        {
                            response.IsValid = false;
                            response.ErrorMessage = "Error to update Primera Entrevista";
                        }
                    }
                    else
                    {
                        response.IsValid = false;
                        response.ErrorMessage = "Primera entrevista not found";
                    }
                }
                else
                {
                    response.IsValid = false;
                    response.ErrorMessage = "Primera entrevista not found";
                }
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public SaveScheduleSegundaEntrevistaResponse SaveScheduleSegundaEntrevista(AgendarSegundaEntrevistaViewModel agendarViewModel, bool changeEtapa)
        {
            var response = new SaveScheduleSegundaEntrevistaResponse();

            try
            {
                var candidatura = _candidaturaRepository.GetOne(x => x.CandidaturaId == agendarViewModel.AgendarSegundaEntrevista.CandidaturaId);
                if (candidatura.Entrevistas != null)
                {
                    if (!candidatura.Entrevistas.Any(x => x.TipoEntrevistaId == (int)TipoEntrevistaEnum.SegundaEntrevista))
                    {
                        response = InsertScheduleSegundaEntrevista(agendarViewModel, changeEtapa);
                    }
                    else
                    {
                        response = UpdateScheduleSegundaEntrevista(agendarViewModel, changeEtapa);
                    }
                }
                else
                {
                    response = InsertScheduleSegundaEntrevista(agendarViewModel, changeEtapa);
                }
                response.IsValid = true;
                if (response.EntrevistaId > 0)
                {
                    var responseSaveSubentrevistas = SaveSubEntrevistas(agendarViewModel.SubEntrevistaList, response.EntrevistaId);
                    if (!responseSaveSubentrevistas.IsValid)
                    {
                        response.IsValid = false;
                        response.ErrorMessage = "error saving SubEntrevistas";
                    }
                }
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public SaveSegundaEntrevistaResponse SaveSegundaEntrevista(SegundaEntrevistaViewModel completarSegundaEntrevistaViewModel, bool changeEtapa)
        {
            var response = new SaveSegundaEntrevistaResponse();

            try
            {
                var candidatura = _candidaturaRepository.GetOne(x => x.CandidaturaId == completarSegundaEntrevistaViewModel.AgendarSegundaEntrevista.AgendarSegundaEntrevista.CandidaturaId);
                if (candidatura.Entrevistas != null)
                {
                    if (candidatura.Entrevistas.Any(x => x.TipoEntrevistaId == (int)TipoEntrevistaEnum.SegundaEntrevista))
                    {
                        var entrevista = candidatura.Entrevistas.Single(x => x.TipoEntrevistaId == (int)TipoEntrevistaEnum.SegundaEntrevista);
                        candidatura.UpdateCandidatura(completarSegundaEntrevistaViewModel, entrevista.EntrevistaId);

                        if (_candidaturaRepository.Update(candidatura) > 0)
                        {
                            if (changeEtapa)
                            {
                                var decision = 0;

                                if(completarSegundaEntrevistaViewModel.ResultadoSegundaEntrevista.SuperaEntrevista2Id == (int)TipoDecisionEnum.SUPERA_SEGUNDA_ENTREVISTA)
                                {
                                    decision = (int)TipoDecisionEnum.SUPERA_SEGUNDA_ENTREVISTA;
                                }

                                if (completarSegundaEntrevistaViewModel.ResultadoSegundaEntrevista.SuperaEntrevista2Id == (int)TipoDecisionEnum.NO_SUPERA_SEGUNDA_ENTREVISTA)
                                {
                                    decision = (int)TipoDecisionEnum.NO_SUPERA_SEGUNDA_ENTREVISTA;
                                }

                                if (completarSegundaEntrevistaViewModel.ResultadoSegundaEntrevista.SuperaEntrevista2Id == (int)TipoDecisionEnum.SIN_DECIDIR_SEGUNDA_ENTREVISTA)
                                {
                                    decision = (int)TipoDecisionEnum.SIN_DECIDIR_SEGUNDA_ENTREVISTA;
                                }

                                if (ChangeEtapa(candidatura.CandidaturaId, decision))
                                {
                                    response.IsValid = true;
                                }
                                else
                                {
                                    response.IsValid = false;
                                    response.ErrorMessage = "Error to change state Candidatura";
                                }
                            }
                            else
                            {
                                response.IsValid = true;
                            }
                        }
                        else
                        {
                            response.IsValid = false;
                            response.ErrorMessage = "Error to update Segunda Entrevista";
                        }
                    }
                    else
                    {
                        response.IsValid = false;
                        response.ErrorMessage = "Segunda entrevista not found";
                    }
                }
                else
                {
                    response.IsValid = false;
                    response.ErrorMessage = "Segunda entrevista not found";
                }
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public SaveScheduleCartaOfertaResponse SaveScheduleCartaOferta(AgendarCartaOfertaViewModel agendarCartaOfertaViewModel, bool changeEtapa)
        {
            var response = new SaveScheduleCartaOfertaResponse();

            try
            {
                var candidatura = _candidaturaRepository.GetOne(x => x.CandidaturaId == agendarCartaOfertaViewModel.AgendarCartaOferta.CandidaturaId);
                if (candidatura.CartaOfertas == null || candidatura.CartaOfertas.Count == 0)
                {
                    response = InsertScheduleCartaOferta(agendarCartaOfertaViewModel, changeEtapa);
                }
                else
                {
                    response = UpdateScheduleCartaOferta(agendarCartaOfertaViewModel, changeEtapa);
                }
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public SaveCartaOfertaResponse SaveCartaOferta(EntregaCartaOfertaViewModel entregaCartaOfertaViewModel, bool changeEtapa)
        {
            var response = new SaveCartaOfertaResponse();

            try
            {
                var cartaOferta = _cartaOfertaRepository.GetOne(x => x.CandidaturaId == entregaCartaOfertaViewModel.AgendarCartaOfertaViewModel.AgendarCartaOferta.CandidaturaId);
                if (cartaOferta != null)
                {
                    cartaOferta.UpdateCartaOferta(entregaCartaOfertaViewModel, cartaOferta.CartaOfertaId);
                    if (_cartaOfertaRepository.Update(cartaOferta) > 0)
                    {
                        if (changeEtapa)
                        {
                            if (ChangeEtapa(
                                entregaCartaOfertaViewModel.AgendarCartaOfertaViewModel.AgendarCartaOferta.CandidaturaId,
                                (int)TipoDecisionEnum.SIN_DECISION_CO))
                            {
                                response.IsValid = true;
                            }
                            else
                            {
                                response.IsValid = false;
                                response.ErrorMessage = "Error to change state Candidatura";
                            }
                        }
                        else
                        {
                            response.IsValid = true;
                        }
                    }
                    else
                    {
                        response.IsValid = false;
                        response.ErrorMessage = "Error to update Carta Oferta";
                    }
                }
                else
                {
                    response.IsValid = false;
                    response.ErrorMessage = "Carta Oferta not found";
                }
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public SaveCartaOfertaAndNecesidadResponse SaveCartaOfertaAndNecesidad(CompletarCartaOfertaViewModel completarCartaOfertaViewModel, bool changeEtapa)
        {
            var response = new SaveCartaOfertaAndNecesidadResponse();

            try
            {
                var cartaOferta = _cartaOfertaRepository.GetOne(x => x.CandidaturaId == completarCartaOfertaViewModel.EntregaCartaOfertaViewModel.AgendarCartaOfertaViewModel.AgendarCartaOferta.CandidaturaId);
                if (cartaOferta != null)
                {
                    var necesidadOriginal = _necesidadRepository.GetOne(x => x.NecesidadId == cartaOferta.NecesidadId);
                    var necesidadNueva = _necesidadRepository.GetOne(x => x.NecesidadId == completarCartaOfertaViewModel.CompletarCartaOferta.NecesidadId);

                    cartaOferta.UpdateCartaOferta(completarCartaOfertaViewModel, cartaOferta.CartaOfertaId, necesidadOriginal, necesidadNueva);
                    if (_cartaOfertaRepository.Update(cartaOferta) > 0)
                    {
                        var candidatura = _candidaturaRepository.GetOne(x => x.CandidaturaId == completarCartaOfertaViewModel.EntregaCartaOfertaViewModel.AgendarCartaOfertaViewModel.AgendarCartaOferta.CandidaturaId);
                        if(candidatura != null)
                        {
                            candidatura.SalarioActual = completarCartaOfertaViewModel.EntregaCartaOfertaViewModel.EntregaCartaOferta.SalarioActual;
                            candidatura.SalarioDeseado = completarCartaOfertaViewModel.EntregaCartaOfertaViewModel.EntregaCartaOferta.SalarioDeseado;
                            candidatura.SalarioPropuesto = completarCartaOfertaViewModel.EntregaCartaOfertaViewModel.EntregaCartaOferta.SalarioPropuesto;
                            _candidaturaRepository.Update(candidatura);
                        }

                        if (changeEtapa)
                        {
                            var decision = 0;

                            if (completarCartaOfertaViewModel.CompletarCartaOferta.SuperaCartaOferta == (int)TipoDecisionEnum.ACEPTA_CARTA_OFERTA)
                            {
                                decision = (int)TipoDecisionEnum.ACEPTA_CARTA_OFERTA;
                            }
                            if (completarCartaOfertaViewModel.CompletarCartaOferta.SuperaCartaOferta == (int)TipoDecisionEnum.NO_ACEPTA_CARTA_OFERTA)
                            {
                                decision = (int)TipoDecisionEnum.NO_ACEPTA_CARTA_OFERTA;
                            }
                            if (completarCartaOfertaViewModel.CompletarCartaOferta.SuperaCartaOferta == (int)TipoDecisionEnum.SIN_DECISION_CARTAOFERTA)
                            {
                                decision = (int)TipoDecisionEnum.SIN_DECISION_CARTAOFERTA;
                            }

                            if (ChangeEtapa(completarCartaOfertaViewModel.EntregaCartaOfertaViewModel.AgendarCartaOfertaViewModel.AgendarCartaOferta.CandidaturaId, decision))
                            {
                                response.IsValid = true;
                            }
                            else
                            {
                                response.IsValid = false;
                                response.ErrorMessage = "Error to change state Candidatura";
                            }
                        }
                        else
                        {
                            response.IsValid = true;
                        }
                    }
                    else
                    {
                        response.IsValid = false;
                        response.ErrorMessage = "Error to update Carta Oferta";
                    }
                }
                else
                {
                    response.IsValid = false;
                    response.ErrorMessage = "Carta Oferta not found";
                }
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        //subir tu curriculum
        public UploadCVResponse UploadCV(byte[] curriculum, int candidaturaId, string nombreCv)
        {
            var response = new UploadCVResponse();
            try
            {
                var candidatura = _candidaturaRepository.GetOne(x => x.CandidaturaId == candidaturaId); //nos traemos la candidatura tal y como está en la BD
                if (candidatura != null)
                {
                    var ruta = ConfigurationManager.AppSettings["rutaCV"].ToString(); //cogemos la ruta que hayamos definido en el Web.Config
                    var candidaturaIdString = candidatura.CandidaturaId.ToString(); // pasamos a string la candidaturaId
                    if (!System.IO.Directory.Exists(ruta))//si no existe la ruta del Web.Config
                    {
                        System.IO.Directory.CreateDirectory(ruta); //la creamos
                    }
                    var rutaPosible = System.IO.Path.Combine(ruta, candidaturaIdString); //definimos un subdirectorio dentro de nuestra ruta que sea la candidaturaId
                    if (candidatura.NombreCV != null && System.IO.Directory.Exists(rutaPosible)) //si nuestra antigua candidatura tiene algun curriculum subido y la ruta existe
                    {
                        var rutaExistente = System.IO.Path.Combine(ruta, candidaturaIdString, candidatura.NombreCV); // definimos la ruta hasta el nombre del curriculum anterior
                        if (System.IO.File.Exists(rutaExistente)) // comprobamos si este archivo existe por si hubiera habido anteriormente un fallo a mitad del procedimiento y se hubiese creado la carpeta pero no el archivo
                        {
                            System.IO.File.Delete(rutaExistente); // borramos el curriculum antiguo
                        }
                    }
                    var rutaNuevoFichero = System.IO.Path.Combine(rutaPosible, nombreCv); // ahora definimos la ruta con el nombre del fichero de nuestro nuevo cv
                    System.IO.Directory.CreateDirectory(rutaPosible); // creamos el subdirectorio con el nombre de candidaturaId (si ya existia no hara nada)
                    using (System.IO.FileStream fs = System.IO.File.Create(rutaNuevoFichero)) // creamos un file stream para crear nuestro nuevo fichero
                    {
                        foreach (byte i in curriculum)
                        {
                            fs.WriteByte(i); //recorremos byte a byte nuestro curriculum enviado y lo escribimos en la ruta especificada
                        }
                    }
                    candidatura.CV = null; // Eliminar cuando el curriculum se almacene por ruta en BD
                    candidatura.NombreCV = nombreCv;
                    candidatura.UrlCV = ruta;
                    _candidaturaRepository.Update(candidatura);
                    response.IsValid = true;
                }
                else
                {
                    response.IsValid = false;
                    response.ErrorMessage = "Failed to access the candidature";
                }
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        
        //subir carta oferta

        public UploadCartaOfertaGeneradaResponse UploadCartaOfertaGenerada(byte[] cartaOfertaGenerada, int CandidaturaId)
        {
            var response = new UploadCartaOfertaGeneradaResponse();

            try
            {
                var cartaOferta = _cartaOfertaRepository.GetOne(x => x.CandidaturaId == CandidaturaId);
                if (cartaOferta != null)
                {
                    cartaOferta.CartaOfertaGenerada = cartaOfertaGenerada;

                    _cartaOfertaRepository.Update(cartaOferta);
                    response.IsValid = true;
                }
                else
                {
                    response.IsValid = false;
                    response.ErrorMessage = "Failed to access the charter offer";
                }
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public RemoveCandidaturaResponse RemoveCandidatura(int candidaturaId)
        {
            var response = new RemoveCandidaturaResponse();
            try
            {
                var candidatura = _candidaturaRepository.GetOne(x => x.CandidaturaId == candidaturaId);
                //cambiamos el activo a =0(borrado lógico)
                candidatura.IsActivo = false;
                if (_candidaturaRepository.Update(candidatura) > 0)
                {
                    CheckAndOpenNecesidades(candidatura.CandidaturaId, candidatura.CandidatoId);
                    response.IsValid = true;
                }
                else
                {
                    response.IsValid = false;
                    response.ErrorMessage = "Error deleting Candidatura";
                }
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public GetFiltroEnSesionResponse GetFiltroEnSesion()
        {
            return new GetFiltroEnSesionResponse
            {
                IsValid = true,
                Filtro = _cacheStorageService.Get<CandidaturaFiltroViewModel>(CandidaturaFiltroSessionKey) ?? new CandidaturaFiltroViewModel()
            };
        }

        public VuelcaCVsEnRutaLocalYActualizaBdResponse VuelcaCVsEnRutaLocalYActualizaBd()
        {
            VuelcaCVsEnRutaLocalYActualizaBdResponse response = new VuelcaCVsEnRutaLocalYActualizaBdResponse();
            var index = 0;
            var stepSize = 10;
            try
            {
                var total = _candidaturaRepository.CountAll();

                for (index = 0; index < total; index += stepSize)
                {
                    var listaCandidaturas = from c
                                           in _candidaturaRepository.GetByStepsOrdered("CandidaturaId", index, stepSize).ToList()
                                            select c.CandidaturaId;
                    foreach (var candidaturaId in listaCandidaturas)
                    {
                        var candidatura = _candidaturaRepository.GetOne(x => x.CandidaturaId == candidaturaId);
                        if (candidatura.CV != null && candidatura.UrlCV == null && candidatura.NombreCV != null)
                        {
                            var file = candidatura.CV;
                            candidatura.CV = null; //borro lo que haya en la BD del fichero de curriculum
                            var candidaturaIdString = candidatura.CandidaturaId.ToString();
                            var ruta = ConfigurationManager.AppSettings["rutaCV"].ToString();
                            if (!System.IO.Directory.Exists(ruta))
                            {
                                System.IO.Directory.CreateDirectory(ruta);
                            }
                            var rutaPosible = System.IO.Path.Combine(ruta, candidaturaIdString);
                            System.IO.Directory.CreateDirectory(rutaPosible);
                            if (candidatura.NombreCV != null && System.IO.Directory.Exists(rutaPosible))
                            {
                                var rutaExistente = System.IO.Path.Combine(ruta, candidaturaIdString, candidatura.NombreCV);
                                System.IO.File.Delete(rutaExistente);
                            }
                            var rutaNuevoFichero = System.IO.Path.Combine(rutaPosible, candidatura.NombreCV);
                            using (System.IO.FileStream fs = System.IO.File.Create(rutaNuevoFichero))
                            {
                                foreach (byte b in file)
                                {
                                    fs.WriteByte(b);
                                }
                            }
                            candidatura.UrlCV = ruta;
                            _candidaturaRepository.Update(candidatura);
                        }
                        else if (candidatura.CV != null && candidatura.UrlCV != null)
                        {
                            candidatura.CV = null;
                            _candidaturaRepository.Update(candidatura);
                        }
                    }
                }






                response.IsValid = true;
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }
            return response;


        }

        public UpdateSubEntrevistasResponse UpdateSubEntrevistas(SubEntrevistaListViewModel SubEntrevistas)
        {
            var response = new UpdateSubEntrevistasResponse();
            try
            {
                response.IsValid = false;
                if (SubEntrevistas.Editar)
                {
                    foreach (var subEntrevistaViewModel in SubEntrevistas.SubEntrevistaList)
                    {
                        var subEntrevistaActual = _subentrevistaRepository.GetOne(x => x.SubEntrevistaId == subEntrevistaViewModel.SubEntrevistaId && x.IsActivo);
                        if (subEntrevistaActual != null)
                        {
                            subEntrevistaActual.UpdateSubEntrevistas(subEntrevistaViewModel);
                            _subentrevistaRepository.Update(subEntrevistaActual);
                        }
                    }
                    response.IsValid = true;
                }
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

        public AddSubEntrevistaFromModalResponse AddSubEntrevistaFromModal(SubEntrevistaModalViewModel subEntrevistaFromModal, int tipoEntrevista)
        {
            var response = new AddSubEntrevistaFromModalResponse();
            try
            {
                var nSubEntrevistas = Convert.ToInt16(ConfigurationManager.AppSettings["numeroMaximoSubEntrevistas"].ToString());
                var listaSubEntrevistas = GetListaSubEntrevistas(subEntrevistaFromModal.CandidaturaIdModal, tipoEntrevista);
                if (listaSubEntrevistas.ListaSubEntrevistas.Count(x => x.SubEntrevistaId != null) >= nSubEntrevistas)
                {
                    response.IsValid = false;
                    response.ErrorMessage = "Maximo de subentrevistas alcanzado";
                }
                else
                {
                    var entrevistaDeLaQueVengo = _entrevistaRepository.GetOne(x => x.CandidaturaId == subEntrevistaFromModal.CandidaturaIdModal
                                                                                && x.TipoEntrevistaId == tipoEntrevista);
                    if (entrevistaDeLaQueVengo != null)
                    {
                        SubEntrevista subEntrevistaToCreate = CandidaturaSubEntrevistaMapper.ConvertSubEntrevistaModalViewModelToSubEntrevistaToCreate(subEntrevistaFromModal, entrevistaDeLaQueVengo);
                        _subentrevistaRepository.Create(subEntrevistaToCreate);
                        response.IsValid = true;
                    }
                    else
                    {
                        response.IsValid = false;
                    }
                }
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

        public UpdateNumeroDeEntrevistasResponse UpdateNumeroDeEntrevistas()
        {
            var response = new UpdateNumeroDeEntrevistasResponse();
            try
            {
                if (!Directory.Exists(RutaScripts))
                {
                    Directory.CreateDirectory(RutaScripts);
                }
                var candidaturas = _candidaturaRepository.GetAll().Where(x => x.IsActivo && x.NumeroDeEntrevistas == null).ToList();
                TextWriter sw = new StreamWriter(RutaScriptsEntrevistas);
                foreach (var candidatura in candidaturas)
                {
                    SaveNumeroDeEntrevistasMigracion(candidatura, sw);
                }
                sw.Close();

            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }



        public SaveNumeroDeEntrevistasResponse SaveNumeroDeEntrevistas(int candidaturaId)
        {
            var response = new SaveNumeroDeEntrevistasResponse();
            try
            {
                var candidatura = _candidaturaRepository.GetOne(x => x.CandidaturaId == candidaturaId);
                var entrevistas = _entrevistaRepository.GetByCriteria(x => x.IsActivo && x.CandidaturaId == candidaturaId).ToList();
                var contadorNumeroEntrevistas = 0;


                foreach (var entrevista in entrevistas)
                {
                    if (entrevista.IsActivo)
                    {
                        contadorNumeroEntrevistas++;
                        var subEntrevistas = _subentrevistaRepository.GetByCriteria(x => x.IsActivo && x.EntrevistaId == entrevista.EntrevistaId).ToList();
                        contadorNumeroEntrevistas += subEntrevistas.Count();
                    }
                }

                candidatura.NumeroDeEntrevistas = contadorNumeroEntrevistas;

                if (_candidaturaRepository.Update(candidatura) > 0)
                {
                    response.IsValid = true;
                }
                else
                {
                    response.IsValid = false;
                    response.ErrorMessage = "Error updating Candidatura";
                }
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public CrearCandidaturaBecarioResponse CrearCandidaturaBecario(DatosBecarioCrearViewModel becarioCrear)
        {
            var response = new CrearCandidaturaBecarioResponse();

            try
            {
                var becario = _becarioRepository.GetOne(x => x.BecarioId == becarioCrear.IdBecarioCrear && x.IsActivo);

                var candidaturaCreada = new Candidatura()
                {
                    CandidatoId = becario.CandidatoId,
                    CategoriaId = (int)TipoPerfilCandidaturaEnum.Junior,
                    SalarioPropuesto = SalarioPropuestoBecario,
                    EstadoCandidaturaId = (int)TipoEstadoCandidaturaEnum.CartaOferta,
                    EtapaCandidaturaId = (int)TipoEtapaCandidaturaEnum.AgendarCartaOferta,
                    FiltradoCV = true,
                    DescartarFuturasCandidaturas = false,
                    NecesidadIdioma = false,
                    DisponibilidadViajes = false,
                    CambioResidencia = false,
                    CreatedBy = ModifiableEntityHelper.GetCurrentUser(),
                    Created = ModifiableEntityHelper.GetCurrentDate(),
                    NombreCV = becario.NombreCV,
                    TipoTecnologiaId = becarioCrear.TecnologiaId,
                    OrigenCvId = becarioCrear.OrigenCvId,
                    FuenteReclutamientoId = becarioCrear.FuenteReclutamientoId,
                    IsActivo = true
                };
                _candidaturaRepository.Create(candidaturaCreada);
                response.IsValid = true;
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public CheckEnProcesoResponse CheckEnProceso(int candidatoId)
        {
            var response = new CheckEnProcesoResponse();

            try
            {
                var candidaturaEnProceso = _candidaturaRepository.Find(x => x.IsActivo && x.CandidatoId == candidatoId &&                                                                        
                                                                       x.EstadoCandidaturaId != (int)TipoEstadoCandidaturaEnum.Recontactado &&
                                                                       x.EstadoCandidaturaId != (int)TipoEstadoCandidaturaEnum.RechazaOferta &&
                                                                       x.EstadoCandidaturaId != (int)TipoEstadoCandidaturaEnum.Descartado &&
                                                                       x.EstadoCandidaturaId != (int)TipoEstadoCandidaturaEnum.Renuncia);
                if(candidaturaEnProceso == null)
                {
                    response.IsValid = true;
                    response.EnProceso = false;
                    response.Contratado = false;
                }
                else
                {
                    if(candidaturaEnProceso.EstadoCandidaturaId == (int)TipoEstadoCandidaturaEnum.Contratado)
                    {
                        response.Contratado = true;
                    }
                    else
                    {
                        response.Contratado = false;
                    }
                    response.IsValid = true;
                    response.EnProceso = true;
                }
            }
            catch (Exception ex)
            {

                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public CheckDescarteMenosSeisMesesResponse CheckDescarteMenosSeisMeses(int candidatoId)
        {
            var response = new CheckDescarteMenosSeisMesesResponse();

            try
            {
                var haceSeisMeses = (DateTime.Now).AddMonths(-6);
                var candidaturaDescarteMenosSeisMeses = _candidaturaRepository.GetByCriteria(x => x.IsActivo && x.CandidatoId == candidatoId &&                                                                        
                                                                       (x.EstadoCandidaturaId == (int)TipoEstadoCandidaturaEnum.RechazaOferta ||
                                                                       x.EstadoCandidaturaId == (int)TipoEstadoCandidaturaEnum.Descartado ||
                                                                       x.EstadoCandidaturaId == (int)TipoEstadoCandidaturaEnum.Renuncia)).ToList();

                if (candidaturaDescarteMenosSeisMeses != null)
                {
                    foreach(var candidatura in candidaturaDescarteMenosSeisMeses)
                    {
                        var bitacora = _bitacoraRepository.Find(x => x.CandidaturaId == candidatura.CandidaturaId &&
                                                                                  candidatura.Created >= haceSeisMeses &&
                                                                                  (x.EstadoNuevoId == (int)TipoEstadoCandidaturaEnum.RechazaOferta ||
                                                                                  x.EstadoNuevoId == (int)TipoEstadoCandidaturaEnum.Descartado ||
                                                                                  x.EstadoNuevoId == (int)TipoEstadoCandidaturaEnum.Renuncia));
                        if(bitacora != null)
                        {
                            response.DescarteMenosSeisMeses = true;
                        }
                    }
                }
                response.IsValid = true;
            }
            catch (Exception ex)
            {

                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public CheckNoMotivadoCambioEmpresaResponse CheckNoMotivadoCambioEmpresa(int candidatoId)
        {
            var response = new CheckNoMotivadoCambioEmpresaResponse();

            try
            {
                var haceSeisMeses = (DateTime.Now).AddMonths(-6);
                var candidaturaNoMotivadoCambioEmpresa = _candidaturaRepository.GetByCriteria(x => x.IsActivo && x.CandidatoId == candidatoId &&
                                                                       x.EstadoCandidaturaId == (int)TipoEstadoCandidaturaEnum.Renuncia
                                                                       && x.MotivoRenunciaDescarteId == 1193).ToList(); //No motivado cambio empresa
                if (candidaturaNoMotivadoCambioEmpresa != null)
                {
                    foreach (var candidatura in candidaturaNoMotivadoCambioEmpresa)
                    {
                        var bitacora = _bitacoraRepository.Find(x => x.CandidaturaId == candidatura.CandidaturaId &&
                                                                                  candidatura.Created >= haceSeisMeses &&
                                                                                  x.EstadoNuevoId == (int)TipoEstadoCandidaturaEnum.Renuncia);
                        if (bitacora != null)
                        {
                            response.NoMotivadoCambioEmpresa = true;
                        }
                    }
                }
                response.IsValid = true;
            }
            catch (Exception ex)
            {

                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public CrearCandidaturaOtherInfoResponse CrearCandidaturaOtherInfo(DatosCandidaturaOtherInfoViewModel model)
        {
            var response = new CrearCandidaturaOtherInfoResponse();
            try
            {
                var candidatura = new Candidatura()
                {
                    CandidatoId = model.CandidatoId,
                    CreatedBy = model.UsuarioCreacionOtherInfo,
                    Created = DateTime.Now,
                    CategoriaId = model.CategoriaId,
                    TipoTecnologiaId = model.TecnologiaId,
                    ModuloId = model.ModuloId,
                    OrigenCvId = model.OrigenCvId,
                    FuenteReclutamientoId = model.FuenteReclutamientoId,
                    FiltradoCV = false,
                    IsActivo = true,
                    EstadoCandidaturaId = (int)TipoEstadoCandidaturaEnum.FiltradoPeople,
                    EtapaCandidaturaId = (int)TipoEtapaCandidaturaEnum.FiltradoTecnico,
                    DescartarFuturasCandidaturas = false,
                    DisponibilidadViajes = false,
                    CambioResidencia = false,
                    NecesidadIdioma = false,
                    NotificarDescarte = true

                };

                _candidaturaRepository.Create(candidatura);
                var usuarioCreacion = _usuarioRepository.GetOne(x => x.UsuarioId == candidatura.CreatedBy).Nombre;
                _bitacoraService.GenerateBitacoraCrearCandidaturaOtherInfo(candidatura.CandidaturaId, usuarioCreacion);
                response.IsValid = true;

            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;


            }

            return response;
        }

        public GetCandidaturasByNombreEstadoCandidaturaResponse GetCandidaturasByNombreEstadoCandidatura(string NombreEstadoCandidatura)
        {
            var response = new GetCandidaturasByNombreEstadoCandidaturaResponse();
            try
            {
                var candidaturas = _candidaturaRepository.GetByCriteria(x => x.EstadoCandidatura.EstadoCandidatura == NombreEstadoCandidatura && x.IsActivo);

                response.CandidaturasViewModel = CandidaturaMapper.ConvertToCandidaturaViewModel(candidaturas);

                response.IsValid = true;
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public bool CheckCandidaturasAbiertas(int candidatoId)
        {
            var query = _candidaturaRepository.Find(x => x.IsActivo && x.CandidatoId == candidatoId &&
                                                    x.EstadoCandidaturaId != (int)TipoEstadoCandidaturaEnum.Contratado
                                                    && x.EstadoCandidaturaId != (int)TipoEstadoCandidaturaEnum.Descartado
                                                    && x.EstadoCandidaturaId != (int)TipoEstadoCandidaturaEnum.RechazaOferta
                                                    && x.EstadoCandidaturaId != (int)TipoEstadoCandidaturaEnum.Renuncia
                                                    && x.EstadoCandidaturaId != (int)TipoEstadoCandidaturaEnum.Recontactado);

            if (query != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public GetCartaOfertaIdByCandidaturaIdResponse GetCartaOfertaIdByCandidaturaId(int candidaturaId)
        {
            var response = new GetCartaOfertaIdByCandidaturaIdResponse();

            try
            {
                var candidatura = _candidaturaRepository.GetOne(x => x.CandidaturaId == candidaturaId);
                if (candidatura != null)
                {
                    response.CartaOfertaId = candidatura.CartaOfertas != null ? candidatura.CartaOfertas.FirstOrDefault().CartaOfertaId : 0;
                    response.IsValid = true;
                }


            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }


        public GetCandidaturasByIdCandidatoResponse GetCandidaturasByIdCandidato(int candidatoId)
        {
            var response = new GetCandidaturasByIdCandidatoResponse();
            try
            {
                var candidaturas = _candidaturaRepository.GetByCriteria(x => x.CandidatoId == candidatoId && x.IsActivo);

                response.CandidaturasViewModel = CandidaturaMapper.ConvertToCandidaturaViewModel(candidaturas);

                response.IsValid = true;
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        #endregion

        #endregion

        #region Private Methods
        private SaveSchedulePrimeraEntrevistaResponse InsertSchedulePrimeraEntrevista(AgendarPrimeraEntrevistaViewModel agendarPrimeraEntrevistaViewModel, bool changeEtapa)
        {
            var response = new SaveSchedulePrimeraEntrevistaResponse();

            var entrevista = new Entrevista();


            entrevista.UpdateCandidaturaPrimeraEntrevista(agendarPrimeraEntrevistaViewModel, null);


            var newEntrevista = _entrevistaRepository.Create(entrevista);
            if (newEntrevista != null)
            {
                if (changeEtapa)
                {
                    if (ChangeEtapa(newEntrevista.CandidaturaId, (int)TipoDecisionEnum.SIN_DECISION_AGENDAR1))
                    {

                        response.IsValid = true;
                        response.CandidaturaId = newEntrevista.CandidaturaId;

                    }
                    else
                    {
                        response.IsValid = false;
                        response.ErrorMessage = "Error to change state Candidatura";
                    }
                    var entrevistaRecienGuardada = _entrevistaRepository.GetOne(x => x.CandidaturaId == agendarPrimeraEntrevistaViewModel.AgendarPrimeraEntrevista.CandidaturaId
                                                                                 && x.TipoEntrevistaId == 1 && x.IsActivo);
                    response.EntrevistaId = entrevistaRecienGuardada.EntrevistaId;
                }
                else
                {
                    response.IsValid = true;
                    response.CandidaturaId = newEntrevista.CandidaturaId;
                    response.EntrevistaId = newEntrevista.EntrevistaId;
                }
            }
            else
            {
                response.IsValid = false;
                response.ErrorMessage = "Error to save Agendar Primera Entrevista";
            }


            return response;

        }

        private List<int> GetCandidatoIdiomasToRemove(Candidato candidato, CandidaturaDatosBasicosViewModel createEditCandidatoViewModel)
        {
            var listCandidatoIdiomaToRemove = new List<int>();

            //obtener los idiomas a eliminar
            if (candidato.CandidatoIdiomas != null)
            {
                foreach (var idioma in candidato.CandidatoIdiomas.ToList())
                {
                    if (!createEditCandidatoViewModel.DatosBasicos.IdiomaCandidatoViewModel.Any(x => x.CandidatoIdiomasId == idioma.CandidatoIdiomasId))
                    {
                        listCandidatoIdiomaToRemove.Add(idioma.CandidatoIdiomasId);
                    }
                }
            }

            return listCandidatoIdiomaToRemove;
        }

        private List<int> GetCandidatoExperienciasToRemove(Candidato candidato, CandidaturaDatosBasicosViewModel createEditCandidatoViewModel)
        {
            var listCandidatoExperienciaToRemove = new List<int>();

            if (candidato.CandidatoExperiencias != null)
            {
                foreach (var experiencia in candidato.CandidatoExperiencias.ToList())
                {
                    if (!createEditCandidatoViewModel.DatosBasicos.ExpCandidatoViewModel.Any(x => x.CandidatoExperienciaId == experiencia.CandidatoExperienciaId))
                    {
                        listCandidatoExperienciaToRemove.Add(experiencia.CandidatoExperienciaId);
                    }
                }
            }

            return listCandidatoExperienciaToRemove;
        }

        private SaveSchedulePrimeraEntrevistaResponse UpdateSchedulePrimeraEntrevista(AgendarPrimeraEntrevistaViewModel agendarPrimeraEntrevistaViewModel, bool changeEtapa)
        {
            var response = new SaveSchedulePrimeraEntrevistaResponse();

            var entrevista = _entrevistaRepository.GetOne(x => x.CandidaturaId == agendarPrimeraEntrevistaViewModel.AgendarPrimeraEntrevista.CandidaturaId &&
                x.TipoEntrevistaId == (int)TipoEntrevistaEnum.PrimeraEntrevista);

            entrevista.UpdateCandidaturaPrimeraEntrevista(agendarPrimeraEntrevistaViewModel, entrevista.EntrevistaId);


            if (_entrevistaRepository.Update(entrevista) > 0)
            {
                if (changeEtapa)
                {
                    if (ChangeEtapa(entrevista.CandidaturaId, (int)TipoDecisionEnum.SIN_DECISION_AGENDAR1))
                    {

                        response.IsValid = true;
                        response.CandidaturaId = entrevista.CandidaturaId;
                        response.EntrevistaId = entrevista.EntrevistaId;

                    }
                    else
                    {
                        response.IsValid = false;
                        response.ErrorMessage = "Error to change state Candidatura";
                    }
                }
                else
                {
                    response.IsValid = true;
                    response.CandidaturaId = entrevista.CandidaturaId;
                    response.EntrevistaId = entrevista.EntrevistaId;
                }
            }
            else
            {
                response.IsValid = false;
                response.ErrorMessage = "Error to update Agendar Primera Entrevista";
            }

            return response;

        }

        private SaveScheduleSegundaEntrevistaResponse InsertScheduleSegundaEntrevista(AgendarSegundaEntrevistaViewModel agendarSegundaEntrevistaViewModel, bool changeEtapa)
        {
            var response = new SaveScheduleSegundaEntrevistaResponse();

            var entrevista = new Entrevista();


            entrevista.UpdateCandidaturaSegundaEntrevista(agendarSegundaEntrevistaViewModel, null);


            var newEntrevista = _entrevistaRepository.Create(entrevista);

            if (newEntrevista != null)
            {
                if (changeEtapa)
                {
                    if (ChangeEtapa(agendarSegundaEntrevistaViewModel.AgendarSegundaEntrevista.CandidaturaId, (int)TipoDecisionEnum.SIN_DECISION_AGENDAR2))
                    {
                        response.IsValid = true;
                        response.CandidaturaId = newEntrevista.CandidaturaId;
                        response.EntrevistaId = newEntrevista.EntrevistaId;
                    }
                    else
                    {
                        response.IsValid = false;
                        response.ErrorMessage = "Error to change state Candidatura";
                    }
                    var entrevistaRecienGuardada = _entrevistaRepository.GetOne(x => x.CandidaturaId == agendarSegundaEntrevistaViewModel.AgendarSegundaEntrevista.CandidaturaId
                                                                                 && x.TipoEntrevistaId == 2 && x.IsActivo);
                    response.EntrevistaId = entrevistaRecienGuardada.EntrevistaId;
                }
                else
                {
                    response.IsValid = true;
                    response.CandidaturaId = newEntrevista.CandidaturaId;
                    response.EntrevistaId = newEntrevista.EntrevistaId;
                }
            }
            else
            {
                response.IsValid = false;
                response.ErrorMessage = "Error to save Agendar Segunda Entrevista";
            }




            return response;
        }

        private SaveScheduleSegundaEntrevistaResponse UpdateScheduleSegundaEntrevista(AgendarSegundaEntrevistaViewModel agendarSegundaEntrevistaViewModel, bool changeEtapa)
        {
            var response = new SaveScheduleSegundaEntrevistaResponse();

            var entrevista = _entrevistaRepository.GetOne(x => x.CandidaturaId == agendarSegundaEntrevistaViewModel.AgendarSegundaEntrevista.CandidaturaId &&
                x.TipoEntrevistaId == (int)TipoEntrevistaEnum.SegundaEntrevista);

            entrevista.UpdateCandidaturaSegundaEntrevista(agendarSegundaEntrevistaViewModel, entrevista.EntrevistaId);

            if (_entrevistaRepository.Update(entrevista) > 0)
            {
                if (changeEtapa)
                {
                    if (ChangeEtapa(agendarSegundaEntrevistaViewModel.AgendarSegundaEntrevista.CandidaturaId, (int)TipoDecisionEnum.SIN_DECISION_AGENDAR2))
                    {

                        response.IsValid = true;
                        response.CandidaturaId = entrevista.CandidaturaId;
                        response.EntrevistaId = entrevista.EntrevistaId;
                    }
                    else
                    {
                        response.IsValid = false;
                        response.ErrorMessage = "Error to change state Candidatura";
                    }
                }
                else
                {
                    response.IsValid = true;
                    response.CandidaturaId = entrevista.CandidaturaId;
                    response.EntrevistaId = entrevista.EntrevistaId;
                }
            }
            else
            {
                response.IsValid = false;
                response.ErrorMessage = "Error to update Agendar Segunda Entrevista";
            }

            return response;
        }

        private SaveScheduleCartaOfertaResponse InsertScheduleCartaOferta(AgendarCartaOfertaViewModel agendarCartaOfertaViewModel, bool changeEtapa)
        {
            var response = new SaveScheduleCartaOfertaResponse();

            var cartaOferta = new CartaOferta();


            cartaOferta.UpdateCartaOferta(agendarCartaOfertaViewModel, null);

            var newCartaOferta = _cartaOfertaRepository.Create(cartaOferta);

            if (newCartaOferta != null)
            {
                if (changeEtapa)
                {
                    if (ChangeEtapa(agendarCartaOfertaViewModel.AgendarCartaOferta.CandidaturaId, (int)TipoDecisionEnum.SIN_DECISION_AGENDARCO))
                    {

                        response.IsValid = true;
                        response.CandidaturaId = newCartaOferta.CandidaturaId;
                        response.CartaOfertaId = newCartaOferta.CartaOfertaId;


                    }
                    else
                    {
                        response.IsValid = false;
                        response.ErrorMessage = "Error to change state Candidatura";
                    }
                }
                else
                {
                    response.IsValid = true;
                    response.CandidaturaId = newCartaOferta.CandidaturaId;
                    response.CartaOfertaId = newCartaOferta.CartaOfertaId;
                }
            }
            else
            {
                response.IsValid = false;
                response.ErrorMessage = "Error to save Agendar Carta Oferta";
            }





            return response;
        }

        private SaveScheduleCartaOfertaResponse UpdateScheduleCartaOferta(AgendarCartaOfertaViewModel agendarCartaOfertaViewModel, bool changeEtapa)
        {
            var response = new SaveScheduleCartaOfertaResponse();

            var cartaOferta = _cartaOfertaRepository.GetOne(x => x.CandidaturaId == agendarCartaOfertaViewModel.AgendarCartaOferta.CandidaturaId);


            cartaOferta.UpdateCartaOferta(agendarCartaOfertaViewModel, cartaOferta.CartaOfertaId);

            if (_cartaOfertaRepository.Update(cartaOferta) > 0)
            {
                if (changeEtapa)
                {
                    if (ChangeEtapa(agendarCartaOfertaViewModel.AgendarCartaOferta.CandidaturaId, (int)TipoDecisionEnum.SIN_DECISION_AGENDARCO))
                    {


                        response.IsValid = true;
                        response.CandidaturaId = cartaOferta.CandidaturaId;
                        response.CartaOfertaId = cartaOferta.CartaOfertaId;

                    }
                    else
                    {
                        response.IsValid = false;
                        response.ErrorMessage = "Error to change state Candidatura";
                    }
                }
                else
                {
                    response.IsValid = true;
                    response.CandidaturaId = cartaOferta.CandidaturaId;
                    response.CartaOfertaId = cartaOferta.CartaOfertaId;
                }
            }
            else
            {
                response.IsValid = false;
                response.ErrorMessage = "Error to update Agendar Carta Oferta";
            }

            return response;
        }



        private bool ChangeEtapa(int candidaturaId, int? tipoDecisionId)
        {
            var success = true;

            try
            {
                var candidatura = _candidaturaRepository.GetOne(x => x.CandidaturaId == candidaturaId);

                if (candidatura == null)
                {
                    return false;
                }

                //se guardan los estados iniciales de la candidatura antes de cambiar de etapa
                int estadoCandidaturaInicial = candidatura.EstadoCandidaturaId;
                int estapaCandidaturaInicial = candidatura.EtapaCandidaturaId;

                var canExcecute = _workflowCandidaturaService.IsExecutable(estapaCandidaturaInicial, tipoDecisionId, estadoCandidaturaInicial);
                if (!canExcecute)
                {
                    return false;
                }

                var dto = _workflowCandidaturaService.Execute(candidatura.EtapaCandidaturaId, tipoDecisionId);
                if (!dto.IsValid || !dto.EstadoFinId.HasValue || !dto.EtapaFinId.HasValue)
                {
                    return false;
                }

                candidatura.EtapaCandidaturaId = dto.EtapaFinId.Value;
                candidatura.EstadoCandidaturaId = dto.EstadoFinId.Value;

                _candidaturaRepository.Update(candidatura);

                if (candidatura.EstadoCandidaturaId == (int)TipoEstadoCandidaturaEnum.Descartado || candidatura.EstadoCandidaturaId == (int)TipoEstadoCandidaturaEnum.RechazaOferta)
                {
                    CheckAndOpenNecesidades(candidatura.CandidaturaId, candidatura.CandidatoId);
                }

                //se crea la bitacora
                success = _bitacoraService
                    .GenerateBitacoraCambioEstadoCandidatura(candidaturaId, estadoCandidaturaInicial, dto.EstadoFinId.Value,
                                                            estapaCandidaturaInicial, dto.EtapaFinId.Value, tipoDecisionId).IsValid;
            }
            catch (Exception)
            {
                success = false;
            }

            return success;
        }
        public class TableJoinResult
        {
            public Candidatura Candidatura { get; set; }
            public CartaOferta CartaOferta { get; set; }
        }

        private IQueryable<Candidatura> FilterString(IDictionary<string, string> customFilter)
        {

            var query = _candidaturaRepository.GetAll();         
            var querycartaoferta = _cartaOfertaRepository.GetAll();
            var queryentrevista = _entrevistaRepository.GetAll();
            var querysubentrevista = _subentrevistaRepository.GetAll();        

            query = query.Where(x => x.IsActivo);

            if (customFilter.ContainsKey("Estado[]") && (customFilter["Estado[]"] != string.Empty))
            {
                    var ids = customFilter["Estado[]"].Split(',').Select(x => int.Parse(x.Trim()));
                    if (ids.Contains((int)TipoEstadoCandidaturaEnum.Entrevista))
                    {
                        var idsList = ids.ToList();
                        idsList.Add((int)TipoEstadoCandidaturaEnum.SegundaEntrevista);
                        ids = idsList.AsEnumerable();
                    }
                query = query.Where(x => ids.Contains(x.EstadoCandidaturaId));
            
            }

            if (customFilter.ContainsKey("Estado") && (customFilter["Estado"] != string.Empty))
            {
                    var ids = customFilter["Estado"].Split(',').Select(x => int.Parse(x.Trim()));
                    if (ids.Contains((int)TipoEstadoCandidaturaEnum.Entrevista))
                    {
                        var idsList = ids.ToList();
                        idsList.Add((int)TipoEstadoCandidaturaEnum.SegundaEntrevista);
                        ids = idsList.AsEnumerable();
                    }
                query = query.Where(x => ids.Contains(x.EstadoCandidaturaId));
            }

            if (customFilter.ContainsKey("OrigenCv") && (customFilter["OrigenCv"] != string.Empty))
            {
                    var origenCv = Convert.ToInt32(customFilter["OrigenCv"]);
                query = query.Where(x => x.OrigenCvId == origenCv);
            }

            if (customFilter.ContainsKey("OfertaId") && (customFilter["OfertaId"] != string.Empty))
            {
                    var oferta = Convert.ToInt32(customFilter["OfertaId"]);
                query = query.Where(x => x.OfertaId == oferta);
            }

            if (customFilter.ContainsKey("Etapa[]") && (customFilter["Etapa[]"] != string.Empty))
            {
                    var ids = customFilter["Etapa[]"].Split(',').Select(x => int.Parse(x.Trim()));
                query = query.Where(x => ids.Contains(x.EtapaCandidaturaId));
            }

            if (customFilter.ContainsKey("Etapa") && (customFilter["Etapa"] != string.Empty))
            {
                    var ids = customFilter["Etapa"].Split(',').Select(x => int.Parse(x.Trim()));
                query = query.Where(x => ids.Contains(x.EtapaCandidaturaId));
            }

            if (customFilter.ContainsKey("Perfil") && (customFilter["Perfil"] != string.Empty))
            {
                    var categoriaId = Convert.ToInt32(customFilter["Perfil"]);
                query = query.Where(x => x.CategoriaId == categoriaId);
            }

            if (customFilter.ContainsKey("Candidato") && (customFilter["Candidato"] != string.Empty))
            {
                    var candidato = customFilter["Candidato"];                   
                    var candidatoPalabras = candidato.Split(' ');
                    foreach (string palabra in candidatoPalabras)
                    {
                        if (palabra != "")
                        {
                        query = query.Where(x => (x.Candidato.Nombre + " " + x.Candidato.Apellidos).Contains(palabra.Trim()));
                        }
                    }
            }

            if (customFilter.ContainsKey("CandidaturaId") && (customFilter["CandidaturaId"] != string.Empty))
            {
                    var candidaturaId = Convert.ToInt32(customFilter["CandidaturaId"]);
                query = query.Where(x => x.CandidaturaId == candidaturaId);
            }

            if (customFilter.ContainsKey("Entrevistador") && (customFilter["Entrevistador"] != string.Empty))
            {
                    var entrevistadorId = Convert.ToInt32(customFilter["Entrevistador"]);
                query = query.Where(x => (x.Entrevistas.Any(t => t.EntrevistadorId == entrevistadorId)) ||
                                            ((x.FiltradorId == entrevistadorId) &&
                                            x.EtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.FiltradoTecnico)
                                            || x.Entrevistas.Any(y => y.SubEntrevista.Any(z => z.EntrevistadorId == entrevistadorId)));
            }

            if (customFilter.ContainsKey("AgendadaDesde") && (customFilter["AgendadaDesde"] != string.Empty))
            {
                    var fechaEntrevista = Convert.ToDateTime(customFilter["AgendadaDesde"]);
                query = query.Where(x => x.Entrevistas.Any(t => t.FechaEntrevista >= fechaEntrevista)
                                        || x.Entrevistas.Any(y => y.SubEntrevista.Any(z => z.FechaEntrevista >= fechaEntrevista)));
            }

            if (customFilter.ContainsKey("AgendadaHasta") && (customFilter["AgendadaHasta"] != string.Empty))
            {
                    var fechaEntrevista = Convert.ToDateTime(customFilter["AgendadaHasta"]);
                query = query.Where(x => x.Entrevistas.Any(t => t.FechaEntrevista <= fechaEntrevista)
                                       || x.Entrevistas.Any(y => y.SubEntrevista.Any(z => z.FechaEntrevista <= fechaEntrevista)));
            }

            if (customFilter.ContainsKey("TipoTecnologiaId") && (customFilter["TipoTecnologiaId"] != string.Empty))
            {
                    var TipoTecnologiaId = Convert.ToInt32(customFilter["TipoTecnologiaId"]);
                query = query.Where(x => x.TipoTecnologiaId == TipoTecnologiaId);
            }
            if (customFilter.ContainsKey("UbicacionCandidato") && customFilter["UbicacionCandidato"] != string.Empty)
            {
                var nombre = customFilter["UbicacionCandidato"];
                query = query.Where(x => x.UbicacionCandidato.Contains(nombre));
            }
            if (customFilter.ContainsKey("AnioExperiencia") && customFilter["AnioExperiencia"] != string.Empty)
            {
                var AnioExperiencia = Convert.ToDateTime(customFilter["AnioExperiencia"]);
                query = query.Where(x => x.AniosExperiencia <= AnioExperiencia);
            }
            if (customFilter.ContainsKey("Keyword") && (customFilter["Keyword"] != string.Empty))
            {
                var nombre = customFilter["Keyword"];
       
               var query1 = query.Where(x => x.Observaciones.Contains(nombre));
               var query2 = query.Where(x => x.DatosCurriculo.Contains(nombre));
               var query3 = querycartaoferta.Where(x => x.Observaciones.Contains(nombre));
               var query4 =  querysubentrevista.Where(x => x.Observaciones.Contains(nombre));
               var query5 = queryentrevista.Where(x => x.Observaciones.Contains(nombre));

               var cartaofertaids = query3.Select(x => x.CandidaturaId).ToArray();
               var entrevistaids = query5.Select(x => x.CandidaturaId).ToArray();
               var candidaturaid = query1.Select(x => x.CandidaturaId).ToArray();
               var curriculumid = query2.Select(x => x.CandidaturaId).ToArray();
               var subentrevista = query4.Select(x => x.EntrevistaId).ToList();
               var subentrevista1 = queryentrevista.Where(x => subentrevista.Contains(x.EntrevistaId)).ToArray();
               var subentrevista2 = subentrevista1.Select(x => x.CandidaturaId).ToArray();

                var ids = cartaofertaids.Union(entrevistaids).Union(candidaturaid).Union(curriculumid).Union(subentrevista2);
              

                query = query.Where(x => ids.Contains(x.CandidaturaId));
               
            }


            //filtros por idioma y nivel mínimo
            bool idioma = customFilter.ContainsKey("Idioma");
            bool nivel = customFilter.ContainsKey("NivelIdioma");
            if (idioma || nivel)
            {
                //por idioma y por nivel mínimo
                if (idioma && nivel && customFilter["NivelIdioma"] != string.Empty && customFilter["Idioma"] != string.Empty)
                {
                    var Idioma = Convert.ToInt32(customFilter["Idioma"]);
                    var NivelIdioma = Convert.ToInt32(customFilter["NivelIdioma"]);
                    query = query.Where(x => x.Candidato.CandidatoIdiomas.Any(y => y.NivelIdiomaId >= NivelIdioma && y.IdiomaId == Idioma));
                }
                //solo por nivel mínimo de idioma
                else if (customFilter["NivelIdioma"] != string.Empty)
                {
                    var NivelIdioma = Convert.ToInt32(customFilter["NivelIdioma"]);
                    query = query.Where(x => x.Candidato.CandidatoIdiomas.Any(y => y.NivelIdiomaId >= NivelIdioma));
                }
                //solo por idioma
                else if (customFilter["Idioma"] != string.Empty)
                {
                    var Idioma = Convert.ToInt32(customFilter["Idioma"]);
                    query = query.Where(x => x.Candidato.CandidatoIdiomas.Any(y => y.IdiomaId == Idioma));
                }
            }

            //se filtra por el centro del usuario logado salvo cuando hay un Centro de busqueda que buscaria los del centro en cuestion (CentroSearch)
            if (customFilter.ContainsKey("CentroUsuarioId") && (customFilter["CentroUsuarioId"] != string.Empty || customFilter.ContainsKey("CentroSearch")))
            {
                if (customFilter.ContainsKey("CentroSearch"))
                {
                    if (customFilter["CentroSearch"] != string.Empty)
                    {
                        var CentroUsuarioId = Convert.ToInt32(customFilter["CentroSearch"]);
                        query = query.Where(x => x.Usuario.Centro.CentroId == CentroUsuarioId);
                    }
                    else
                    {
                        if (customFilter["CentroUsuarioId"] != string.Empty)
                        {
                            var CentroUsuarioId = Convert.ToInt32(customFilter["CentroUsuarioId"]);
                            query = query.Where(x => x.Usuario.Centro.CentroId == CentroUsuarioId);
                        }
                    }
                }
                else
                {
                    var CentroUsuarioId = Convert.ToInt32(customFilter["CentroUsuarioId"]);
                    query = query.Where(x => x.Usuario.Centro.CentroId == CentroUsuarioId);
                }
            }

            if (customFilter.ContainsKey("CentroSearch") && !customFilter.ContainsKey("CentroUsuarioId") && (customFilter["CentroSearch"] != string.Empty))
            {
                var CentroUsuarioId = Convert.ToInt32(customFilter["CentroSearch"]);
                query = query.Where(x => x.Usuario.Centro.CentroId == CentroUsuarioId);
            }

            if (customFilter.ContainsKey("ModuloId") && (customFilter["ModuloId"] != string.Empty))
            {
                var ModuloId = Convert.ToInt32(customFilter["ModuloId"]);
                if (ModuloId != (int)TipoModuloEnum.ABAP)
                {
                    query = query.Where(x => x.TipoModulo.MaestroId == ModuloId);

                }
                else
                {
                    var listaPerfilesExcluir = new List<int>();
                    listaPerfilesExcluir.Add((int)TipoPerfilCandidaturaEnum.FunctionalExpertSpecialist);
                    listaPerfilesExcluir.Add((int)TipoPerfilCandidaturaEnum.FunctionalLeaderSpecialist);
                    listaPerfilesExcluir.Add((int)TipoPerfilCandidaturaEnum.FunctionalSeniorSpecialist);
                    listaPerfilesExcluir.Add((int)TipoPerfilCandidaturaEnum.FunctionalSpecialist);

                    query = query.Where(x => !listaPerfilesExcluir.Contains(x.CategoriaId.Value));
                }

            }
            if (customFilter.ContainsKey("CandidaturaOferta") && (customFilter["CandidaturaOferta"] != string.Empty))
            {
                var OfertaId = Convert.ToInt32(customFilter["CandidaturaOferta"]);
                query = query.Where(x => x.CandidaturaOfertaId == OfertaId);
            }



            return query;
        }

        private int GetDecisionByCandidaturaEtapaId(int candidaturaEtapaId, int candidaturaEstadoId, bool pausar)
        {
            int decision = -1;


            switch (candidaturaEtapaId)
            {

                case (int)TipoEtapaCandidaturaEnum.AgendarEntrevistas:
                    decision = GetDecisionByCandidaturaEstadoId(candidaturaEstadoId, candidaturaEtapaId);
                    break;
                case (int)TipoEtapaCandidaturaEnum.AgendarSegundaEntrevista:
                    decision = GetDecisionByCandidaturaEstadoId(candidaturaEstadoId, candidaturaEtapaId);
                    break;
                case (int)TipoEtapaCandidaturaEnum.AgendarCartaOferta:
                    decision = GetDecisionByCandidaturaEstadoId(candidaturaEstadoId, candidaturaEtapaId);
                    break;

                case (int)TipoEtapaCandidaturaEnum.FiltradoTelefonico:
                    if (!pausar) // si tiene que avanzar
                    {
                        decision = (int)TipoDecisionEnum.SIN_DECISION_IRAGENDAR1; // DECISION QUE PERMITE AVANZAR EN LA CANDIDATURA
                    }
                    else if (candidaturaEstadoId == (int)TipoEstadoCandidaturaEnum.Entrevista) // si tiene que pausar
                    {
                        decision = GetDecisionByCandidaturaEstadoId(candidaturaEstadoId, candidaturaEtapaId);
                    }
                    else if (candidaturaEstadoId == (int)TipoEstadoCandidaturaEnum.StandBy) // si tiene que reanudar
                    {
                        decision = (int)TipoDecisionEnum.REANUDAR_EN_FILTRADO_TELEFONICO;
                    }
                    break;
                case (int)TipoEtapaCandidaturaEnum.PendienteDecisionSegundaEntrevista:
                    if(pausar)
                    {
                        decision = GetDecisionByCandidaturaEstadoId(candidaturaEstadoId, candidaturaEtapaId);
                    }
                    else
                    {
                        decision = (int)TipoDecisionEnum.SIN_DECISION_IRAGENDAR2;
                    }
                    break;
                case (int)TipoEtapaCandidaturaEnum.PendienteDecisionCartaOferta:
                    if (pausar)
                    {
                        decision = GetDecisionByCandidaturaEstadoId(candidaturaEstadoId, candidaturaEtapaId);
                    }
                    else
                    {
                        decision = (int)TipoDecisionEnum.SIN_DECISION_IRCARTAOFERTA;
                    }
                    break;
                default:
                    break;
            }

            return decision;
        }

        private int GetDecisionByCandidaturaEstadoId(int candidaturaEstadoId, int candidaturaEtapaId)
        {
            int decision = -1;

            switch (candidaturaEstadoId)
            {
                case (int)TipoEstadoCandidaturaEnum.Entrevista:
                    decision = (int)TipoDecisionEnum.PAUSAR_EN_FILTRADO_TELEFONICO;
                    if (candidaturaEtapaId == (int)TipoEtapaCandidaturaEnum.AgendarEntrevistas)
                    {
                        decision = (int)TipoDecisionEnum.PAUSAR_PRIMERA_ENTREVISTA_UNIFICADO;
                    }
                    break;
                case (int)TipoEstadoCandidaturaEnum.AntiguoCVenBBDD:
                    decision = (int)TipoDecisionEnum.REANUDAR_FILTRADO_CV_BBDD;
                    break;
                case (int)TipoEstadoCandidaturaEnum.SegundaEntrevista:
                    decision = (int)TipoDecisionEnum.PAUSAR_SEGUNDA_ENTREVISTA_UNIFICADO;
                    break;
                case (int)TipoEstadoCandidaturaEnum.BacklogEntrevista:
                    decision = (int)TipoDecisionEnum.REANUDAR_COMPLETAR_PRIMERA_ENTREVISTA;
                    break;
                case (int)TipoEstadoCandidaturaEnum.CartaOferta:
                    decision = (int)TipoDecisionEnum.PAUSAR_COMPLETAR_SEGUNDA_ENTREVISTA;
                    break;
                case (int)TipoEstadoCandidaturaEnum.StandBy:
                    decision = (int)TipoDecisionEnum.REANUDAR_COMPLETAR_SEGUNDA_ENTREVISTA;
                    if (candidaturaEtapaId == (int)TipoEtapaCandidaturaEnum.AgendarEntrevistas)
                    {
                        decision = (int)TipoDecisionEnum.REANUDAR_PRIMERA_ENTREVISTA_UNIFICADO;
                    }
                    else if (candidaturaEtapaId == (int)TipoEtapaCandidaturaEnum.AgendarSegundaEntrevista)
                    {
                        decision = (int)TipoDecisionEnum.REANUDAR_SEGUNDA_ENTREVISTA_UNIFICADO;
                    }
                    else if (candidaturaEtapaId == (int)TipoEtapaCandidaturaEnum.PendienteDecisionSegundaEntrevista)
                    {
                        decision = (int)TipoDecisionEnum.REANUDAR_SEGUNDA_ENTREVISTA_UNIFICADO;
                    }
                    else if (candidaturaEtapaId == (int)TipoEtapaCandidaturaEnum.PendienteDecisionCartaOferta)
                    {
                        decision = (int)TipoDecisionEnum.REANUDAR_SEGUNDA_ENTREVISTA_UNIFICADO;
                    }
                    break;
                default:
                    break;
            }

            return decision;
        }                        
     
        private SaveSubEntrevistasResponse SaveSubEntrevistas(List<SubEntrevistaViewModel> SubEntrevistasAGuardar, int EntrevistaIdAsociada)
        {
            var response = new SaveSubEntrevistasResponse();
            try
            {
                var subentrevistasExistentes = _subentrevistaRepository.GetByCriteria(x => x.EntrevistaId == EntrevistaIdAsociada && x.IsActivo).ToList();
                var entrevistaPrincipal = _entrevistaRepository.GetOne(x => x.EntrevistaId == EntrevistaIdAsociada);

                if (entrevistaPrincipal.Candidatura == null) //Hace falta si estas creando la entrevista a la vez que las subentrevistas la primera vez porque la entrevista principal aún no se ha terminado de crear aparentemente y no te traes el modelo de candidatura
                {
                    var candidatura = _candidaturaRepository.GetOne(x => x.CandidaturaId == entrevistaPrincipal.CandidaturaId);
                    entrevistaPrincipal.Candidatura = candidatura;
                }

                foreach (SubEntrevista subEntrevistaVieja in subentrevistasExistentes) //borro las que haya quitado
                {
                    if (!SubEntrevistasAGuardar.Exists(x => x.SubEntrevistaId == subEntrevistaVieja.SubEntrevistaId && x.EntrevistadorId != null))
                    {
                        subEntrevistaVieja.IsActivo = false;
                        _subentrevistaRepository.Update(subEntrevistaVieja);
                    }
                    else
                    {
                        var subEntrevistaNueva = SubEntrevistasAGuardar.Find(x => x.SubEntrevistaId == subEntrevistaVieja.SubEntrevistaId && x.EntrevistadorId != null);
                        subEntrevistaVieja.UpdateSubentrevistaAlCrear(subEntrevistaNueva);
                        _subentrevistaRepository.Update(subEntrevistaVieja);
                        SubEntrevistasAGuardar.Remove(subEntrevistaNueva);
                    }
                }

                foreach (SubEntrevistaViewModel subEntrevistaViewModel in SubEntrevistasAGuardar)
                {
                    if (subEntrevistaViewModel != null && subEntrevistaViewModel.EntrevistadorName != "" && subEntrevistaViewModel.EntrevistadorName != null)
                    {
                        subEntrevistaViewModel.EntrevistaId = EntrevistaIdAsociada;
                        subEntrevistaViewModel.CategoriaId = entrevistaPrincipal.Candidatura.CategoriaId;
                        subEntrevistaViewModel.SalarioDeseado = entrevistaPrincipal.Candidatura.SalarioDeseado;
                        subEntrevistaViewModel.IncorporacionId = entrevistaPrincipal.Candidatura.IncorporacionId;
                        subEntrevistaViewModel.DisponibilidadViajes = entrevistaPrincipal.Candidatura.DisponibilidadViajes;
                        subEntrevistaViewModel.CambioResidencia = entrevistaPrincipal.Candidatura.CambioResidencia;
                        SubEntrevista subEntrevistaAGuardar = CandidaturaSubEntrevistaMapper.ConvertSubEntrevistaViewModelToSubEntrevistaToCreate(subEntrevistaViewModel);
                        _subentrevistaRepository.Create(subEntrevistaAGuardar);
                    }
                }
                response.IsValid = true;
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

        private void SaveNumeroDeEntrevistasMigracion(Candidatura candidatura, TextWriter sw)
        {
            var response = new SaveNumeroDeEntrevistasResponse();
            try
            {
                var contadorNumeroEntrevistas = 0;

                foreach (var entrevista in candidatura.Entrevistas.Where(x => x.IsActivo))
                {
                    contadorNumeroEntrevistas++;
                    var subEntrevistas = entrevista.SubEntrevista.Where(x => x.IsActivo).ToList();
                    contadorNumeroEntrevistas += subEntrevistas.Count;
                }

                candidatura.NumeroDeEntrevistas = contadorNumeroEntrevistas;


                sw.WriteLine("Update " + "Candidatura" +
                            " set NumeroDeEntrevistas = " + contadorNumeroEntrevistas +
                            " where CandidaturaId = " + candidatura.CandidaturaId + ";" + "\t");

            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }
        }

     


        #endregion
    }
}
