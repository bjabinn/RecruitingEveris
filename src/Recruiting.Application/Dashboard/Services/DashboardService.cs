using Recruiting.Application.Becarios.Enums;
using Recruiting.Application.Candidaturas.Enums;
using Recruiting.Application.Dashboard.Enums;
using Recruiting.Application.Dashboard.Mappers;
using Recruiting.Application.Dashboard.Messages;
using Recruiting.Application.Dashboard.ViewModels;
using Recruiting.Application.Roles.Services;
using Recruiting.Business.Entities;
using Recruiting.Business.Repositories;
using Recruiting.Business.Services.WorkflowCandidatura;
using Recruiting.Data.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recruiting.Application.Dashboard.Services
{
    public class DashboardService : IDashboardService
    {
        #region Constants
        
        #endregion

        #region Fields

        private readonly ICandidaturaRepository _candidaturaRepository;
        private readonly IEntrevistaRepository _entrevistaRepository;
        private readonly IBecarioRepository _becarioRepository;
        private readonly ICartaOfertaRepository _cartaOfertaRepository;
        private readonly IRolRepository _rolRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly RolService _rolService;
        private readonly ISubEntrevistaRepository _subEntrevistaRepository;

        private readonly IRelacionEtapaRepository _relacionEtapaRepository;
        private readonly IRelacionVistaEtapaRepository _relacionVistaEtapaRepository;
        private readonly IWorkflowCandidaturaService _workflowCandidaturaService;
        private readonly INecesidadRepository _necesidadRepository;
        private readonly IAdministradorDashboardRepository _administradorDashboardRepository;

        #endregion

        #region Properties

        #endregion

        #region Constructors

        public DashboardService(IBecarioRepository becarioRepository, IEntrevistaRepository entrevistaRepository,
            ICandidaturaRepository candidaturaRepository, ICartaOfertaRepository cartaOfertaRepository,
            IRelacionEtapaRepository relacionEtapaRepository, IRelacionVistaEtapaRepository relacionVistaEtapaRepository, INecesidadRepository necesidadRepository, ISubEntrevistaRepository subEntrevistaRepository)
        {
            _becarioRepository = becarioRepository;
            _entrevistaRepository = entrevistaRepository;
            _cartaOfertaRepository = cartaOfertaRepository;
            _candidaturaRepository = candidaturaRepository;
            _rolRepository = new RolRepository();
            _usuarioRepository = new UsuarioRepository();
            _rolService = new RolService();

            _relacionEtapaRepository =relacionEtapaRepository;
            _relacionVistaEtapaRepository = relacionVistaEtapaRepository;
            _workflowCandidaturaService = new WorkflowCandidaturaService(_relacionEtapaRepository, _relacionVistaEtapaRepository);
            _necesidadRepository = necesidadRepository;

            _subEntrevistaRepository = subEntrevistaRepository;
            _administradorDashboardRepository = new AdministradorDashboardRepository();
        }

        #endregion


        #region IDashboardService members

        public GetDashboardResponse GetDashboard(List<int> roles, string userName, int? CentroIdUsuario = null, int? usuarioId = null)
        {
            var response = new GetDashboardResponse();
            response.DashboardViewModel = new DashboardViewModel();         

            try
            {
                if ((roles.Contains((int)TipoRolUsuario.Administrador))
                    || (roles.Contains((int)TipoRolUsuario.People)))
                {
                    response.DashboardViewModel.InfoAdministradorViewModel = GetInfoAdministrador(CentroIdUsuario, usuarioId);
                }
                if (roles.Contains((int)TipoRolUsuario.Entrevistador))
                {
                    response.DashboardViewModel.InfoEntrevistadorViewModel = GetInfoEntrevistador(userName, CentroIdUsuario);
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

        public SaveAlertasAdminResponse SaveAlertasAdmin(AlertasAdministradorViewModel alertasAdminViewModel)
        {
            var response = new SaveAlertasAdminResponse();

            try
            {

                var administradorDashboard = _administradorDashboardRepository.GetOne(x => x.UsuarioId == alertasAdminViewModel.UsuarioId && x.IsActivo);
                if (administradorDashboard == null)
                {
                    administradorDashboard = new AdministradorDashboard()
                    {
                        UsuarioId = alertasAdminViewModel.UsuarioId,
                        NecesidadesCreadasModificadas = alertasAdminViewModel.NecesidadesCreadasModificadas,
                        PrimeraEntrevista = alertasAdminViewModel.PrimeraEntrevista,
                        SubEntrevistaPrimeraEntrevista = alertasAdminViewModel.SubEntrevistaPrimeraEntrevista,
                        SegundaEntrevista = alertasAdminViewModel.SegundaEntrevista,
                        SubEntrevistaSegundaEntrevista = alertasAdminViewModel.SubEntrevistaSegundaEntrevista,
                        CartaOferta = alertasAdminViewModel.CartaOferta,
                        CvPendienteFiltro = alertasAdminViewModel.CvPendienteFiltro,
                        CandidaturaStandBy = alertasAdminViewModel.CandidaturaStandBy,
                        BecarioStandBy = alertasAdminViewModel.BecarioStandBy,
                        IsActivo = true
                    };
                    _administradorDashboardRepository.Create(administradorDashboard);
                    
                }
                else
                {
                    administradorDashboard = administradorDashboard.UpdateAdministradorDashboard(alertasAdminViewModel);
                    _administradorDashboardRepository.Update(administradorDashboard);
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
        #endregion

        private InfoAdministradorViewModel GetInfoAdministrador(int? CentroIdUsuario, int? usuarioId)
        {
            var response = new InfoAdministradorViewModel();
            try
            {
                var today = DateTime.Now;
                var aMonthEarlier = today.AddMonths(-1);
                var nextFifteenDays = DateTime.Now.AddDays(15);

                //Generamos alerta para la primera entrevista fuera de fecha
                response.ListPrimeraEntrevistaViewModel = new List<EntrevistasFueraFechaRowViewModel>();
                response.ListPrimeraEntrevistaViewModel = getListaPrimeraEntrevistaFueraDeFechaAlert(today, CentroIdUsuario);

                //Generamos alerta para las sub entrevistas pertenecientes a la primera entrevista que están fuera de fecha
                response.ListSubEntrevistasPrimeraEntrevistaViewModel = new List<EntrevistasFueraFechaRowViewModel>();
                response.ListSubEntrevistasPrimeraEntrevistaViewModel = getListaSubEntrevistaPrimeraEntrevistaFueraDeFechaAlert(today, CentroIdUsuario);

                //Generamos alerta para la segunda entrevista fuera de fecha
                response.ListSegundaEntrevistaViewModel = new List<EntrevistasFueraFechaRowViewModel>();
                response.ListSegundaEntrevistaViewModel = getListaSegundaEntrevistaFueraDeFechaAlert(today, CentroIdUsuario);

                //Generamos alerta para las sub entrevistas pertenecientes a la segunda entrevista que están fuera de fecha
                response.ListSubEntrevistasSegundaEntrevistaViewModel = new List<EntrevistasFueraFechaRowViewModel>();
                response.ListSubEntrevistasSegundaEntrevistaViewModel = getListaSubEntrevistaSegundaEntrevistaFueraDeFechaAlert(today, CentroIdUsuario);

                //Generamos alerta para la carta oferta fuera de fecha
                response.ListCartaOfertaViewModel = new List<EntrevistasFueraFechaRowViewModel>();
                response.ListCartaOfertaViewModel = getListaCartaOfertaFueraDeFechaAlert(today, CentroIdUsuario);

                //Generamos alerta para las candidaturas pendientes a filtrar
                response.ListFiltradoPendienteViewModel = new List<FiltradoPendienteViewModel>();
                response.ListFiltradoPendienteViewModel = getListaCandidaturasAFiltrarAlert(aMonthEarlier, CentroIdUsuario);
                
                //Generamos alerta para las candidaturas en standby con fecha de contacto caducadas y por caducar en los proximos 15 dias
                response.ListCandidaturasPendienteCartaOfertaViewModel = new List<CandidaturasPendienteEntrevistaOCartaOfertaViewModel>();
                response.ListCandidaturasPendienteStandByViewModel = getListaCandidaturasStandByAlert(nextFifteenDays, CentroIdUsuario);

                response.ListBecariosPendienteEntrevistaViewModel = new List<BecariosPendienteEntrevistaViewModel>();
                response.ListBecariosPendientesStandByViewModel = getListaBecariosStandByAlert(nextFifteenDays, CentroIdUsuario);

                response.AlertasAdministradorViewModel = new AlertasAdministradorViewModel();
                response.AlertasAdministradorViewModel = getAlertasAdministrador(usuarioId);
                

                
            }
            catch (Exception)
            {
                return new InfoAdministradorViewModel();

            }
            return response;
        }

        private InfoEntrevistadorViewModel GetInfoEntrevistador(string UserName, int? CentroIdUsuario)
        {
            var response = new InfoEntrevistadorViewModel();
            try
            {
                var ListEntrevistas = _entrevistaRepository.GetByCriteria(x => x.Entrevistador.UserName == UserName && x.Candidatura.IsActivo && 
                                        (!(CentroIdUsuario.HasValue) || x.Candidatura.Usuario.CentroId == CentroIdUsuario.Value) &&
                                        x.Candidatura.EstadoCandidaturaId != (int)TipoEstadoCandidaturaEnum.Descartado &&
                                        x.Candidatura.EstadoCandidaturaId != (int)TipoEstadoCandidaturaEnum.Renuncia &&
                                        x.Candidatura.EstadoCandidaturaId != (int)TipoEstadoCandidaturaEnum.RechazaOferta).ToList();

                var ListSubEntrevistas = new List<SubEntrevista>();
                var ListEntrevistasConSubEntrevistas = _entrevistaRepository.GetByCriteria(x => x.SubEntrevista.Any(y => y.Entrevistador.UserName == UserName && y.IsActivo) && x.Candidatura.IsActivo &&
                                        (!(CentroIdUsuario.HasValue) || x.Candidatura.Usuario.CentroId == CentroIdUsuario.Value) &&
                                        x.Candidatura.EstadoCandidaturaId != (int)TipoEstadoCandidaturaEnum.Descartado &&
                                        x.Candidatura.EstadoCandidaturaId != (int)TipoEstadoCandidaturaEnum.Renuncia &&
                                        x.Candidatura.EstadoCandidaturaId != (int)TipoEstadoCandidaturaEnum.RechazaOferta).ToList();

                foreach (var entrevista in ListEntrevistasConSubEntrevistas)
                {
                    var subEntrevistas = from subEntrevista in entrevista.SubEntrevista
                                         where subEntrevista.Entrevistador.UserName == UserName
                                         select subEntrevista;
                    foreach (var subEntrevista in subEntrevistas)
                    {
                        if (subEntrevista.IsActivo)
                        {
                            ListSubEntrevistas.Add(subEntrevista);
                        }
                    }
                }

                var listaEntrevistasPlanificadas = ListEntrevistas.ConvertToEntrevistasPlanificadasRowViewModel().ToList();
                var listaSubEntrevistasPlanificadas = ListSubEntrevistas.ConvertToEntrevistasPlanificadasRowViewModel().ToList();               

                foreach (var entrevistaPlanificada in listaSubEntrevistasPlanificadas)
                {
                    listaEntrevistasPlanificadas.Add(entrevistaPlanificada);
                }

                response.ListEntrevistasPlanificadasViewModel = listaEntrevistasPlanificadas;

                _cartaOfertaRepository.GetByCriteria(x => x.Entrevistador.UserName == UserName && x.Candidatura.IsActivo && x.Candidatura.Usuario.CentroId==CentroIdUsuario);

                var userId = _usuarioRepository.GetOne(x => x.UserName == UserName).UsuarioId;

                var currentDateTime = DateTime.Now;
                var aMonthEarlier = currentDateTime.AddMonths(-1);

                var ListaCandidaturasAFiltrar = _candidaturaRepository.GetByCriteria(x => (x.FiltradorId == userId) && 
                                                (x.EtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.FiltradoTecnico) &&
                                                (x.EstadoCandidaturaId == (int)TipoEstadoCandidaturaEnum.FiltradoPeople) &&
                                                (x.Created > aMonthEarlier));

                response.ListFiltradoPendienteViewModel = ListaCandidaturasAFiltrar.ConvertToFiltradoPendienteViewModelList().ToList();
               


            }
            catch (Exception)
            {
                return new InfoEntrevistadorViewModel();
            }

            return response;
        }

        private AlertasAdministradorViewModel getAlertasAdministrador(int? usuarioId)
        {
            var response = new AlertasAdministradorViewModel();
            try
            {

                var alertasAdministrador = _administradorDashboardRepository.GetOne(x => x.IsActivo && x.UsuarioId == usuarioId);
                if (alertasAdministrador != null)
                {
                    response = alertasAdministrador.ConvertToAlertasAdministradorViewModel();
                }    

            }
            catch (Exception)
            {
                return new AlertasAdministradorViewModel();
            }

            return response;
        }

        #region Alert lists generators

        private List<EntrevistasFueraFechaRowViewModel> getListaPrimeraEntrevistaFueraDeFechaAlert(DateTime today, int? CentroIdUsuario)
        {
            List<EntrevistasFueraFechaRowViewModel> response;
            try
            {
                var ListEntrevistas = _entrevistaRepository.GetByCriteria(x => x.FechaEntrevista <= today &&
                                       x.TipoEntrevistaId == (int)TipoEntrevistaEnum.PrimeraEntrevista &&
                                       x.Candidatura.EstadoCandidatura.TipoEstadoCandidaturaId == (int)TipoEstadoCandidaturaEnum.Entrevista &&
                                       x.Candidatura.EtapaCandidatura.TipoEtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.FeedbackPrimeraEntrevista &&
                                       x.Candidatura.IsActivo &&
                                       (!(CentroIdUsuario.HasValue) || x.Usuario.CentroId == CentroIdUsuario)).OrderBy(x => x.CandidaturaId).AsQueryable();
                response = ListEntrevistas.ConvertToEntrevistasFueraFechaRowViewModel().ToList();
            }
            catch (Exception)
            {
                return new List<EntrevistasFueraFechaRowViewModel>();
            }
            return response;
        }

        private List<EntrevistasFueraFechaRowViewModel> getListaSubEntrevistaPrimeraEntrevistaFueraDeFechaAlert(DateTime today, int? CentroIdUsuario)
        {
            List<EntrevistasFueraFechaRowViewModel> response;
            try
            {
                var listaSubEntrevistaQueryable = _subEntrevistaRepository.GetByCriteria(x => x.IsActivo && x.Entrevista.TipoEntrevistaId == 1 && !x.Completada && x.FechaEntrevista <= today &&
                                                     x.Entrevista.Candidatura.EstadoCandidatura.TipoEstadoCandidaturaId == (int)TipoEstadoCandidaturaEnum.Entrevista &&
                                                     x.Entrevista.Candidatura.EtapaCandidatura.TipoEtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.FeedbackPrimeraEntrevista &&
                                                     x.Entrevista.Candidatura.IsActivo &&
                                                     (!(CentroIdUsuario.HasValue) || x.Entrevista.Usuario.CentroId == CentroIdUsuario)
                                                     ).AsQueryable();

                List<EntrevistasFueraFechaRowViewModel> listaSubEntrevistas = new List<EntrevistasFueraFechaRowViewModel>();

                listaSubEntrevistas.AddRange(listaSubEntrevistaQueryable.ConvertToEntrevistasFueraFechaRowViewModel());

                response = listaSubEntrevistas;
            }
            catch (Exception)
            {
                return new List<EntrevistasFueraFechaRowViewModel>();
            }
            return response;
        }

        private List<EntrevistasFueraFechaRowViewModel> getListaSegundaEntrevistaFueraDeFechaAlert(DateTime today, int? CentroIdUsuario)
        {
            List<EntrevistasFueraFechaRowViewModel> response;
            try
            {
                var ListEntrevistas = _entrevistaRepository.GetByCriteria(x => x.FechaEntrevista <= today &&
                                       x.TipoEntrevistaId == (int)TipoEntrevistaEnum.SegundaEntrevista &&
                                       x.Candidatura.EstadoCandidatura.TipoEstadoCandidaturaId == (int)TipoEstadoCandidaturaEnum.SegundaEntrevista &&
                                       x.Candidatura.EtapaCandidatura.TipoEtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.FeedbackSegundaEntrevista &&
                                       x.Candidatura.IsActivo &&
                                       (!(CentroIdUsuario.HasValue) || x.Usuario.CentroId == CentroIdUsuario)).OrderBy(x => x.CandidaturaId).AsQueryable();
                response = ListEntrevistas.ConvertToEntrevistasFueraFechaRowViewModel().ToList();
            }
            catch (Exception)
            {
                return new List<EntrevistasFueraFechaRowViewModel>();
            }
            return response;
        }

        private List<EntrevistasFueraFechaRowViewModel> getListaSubEntrevistaSegundaEntrevistaFueraDeFechaAlert(DateTime today, int? CentroIdUsuario)
        {
            List<EntrevistasFueraFechaRowViewModel> response;
            try
            {
                var listaSubEntrevistaQueryable = _subEntrevistaRepository.GetByCriteria(x => x.IsActivo && x.Entrevista.TipoEntrevistaId == 2 && !x.Completada && x.FechaEntrevista <= today &&
                                                     x.Entrevista.Candidatura.EstadoCandidatura.TipoEstadoCandidaturaId == (int)TipoEstadoCandidaturaEnum.SegundaEntrevista &&
                                                     x.Entrevista.Candidatura.EtapaCandidatura.TipoEtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.FeedbackSegundaEntrevista &&
                                                     x.Entrevista.Candidatura.IsActivo &&
                                                     (!(CentroIdUsuario.HasValue) || x.Entrevista.Usuario.CentroId == CentroIdUsuario)
                                                     ).AsQueryable();

                List<EntrevistasFueraFechaRowViewModel> listaSubEntrevistas = new List<EntrevistasFueraFechaRowViewModel>();

                listaSubEntrevistas.AddRange(listaSubEntrevistaQueryable.ConvertToEntrevistasFueraFechaRowViewModel());

                response = listaSubEntrevistas;
            }
            catch (Exception)
            {
                return new List<EntrevistasFueraFechaRowViewModel>();
            }
            return response;
        }

        private List<EntrevistasFueraFechaRowViewModel> getListaCartaOfertaFueraDeFechaAlert(DateTime datePeriod, int? CentroIdUsuario)
        {
            List<EntrevistasFueraFechaRowViewModel> response;
            try
            {
                var LisCartaOferta = _cartaOfertaRepository.GetByCriteria(x => x.FechaCartaOferta < datePeriod &&
                                       x.Candidatura.EstadoCandidatura.TipoEstadoCandidaturaId == (int)TipoEstadoCandidaturaEnum.CartaOferta &&
                                       x.Candidatura.EtapaCandidatura.TipoEtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.FeedbackCartaOferta &&
                                       x.Candidatura.IsActivo &&
                                       (!(CentroIdUsuario.HasValue) || x.Candidatura.Usuario.CentroId == CentroIdUsuario));
                response = LisCartaOferta.ConvertToCartasFueraFechaRowViewModel().ToList();
            }
            catch (Exception)
            {
                return new List<EntrevistasFueraFechaRowViewModel>();
            }
            return response;
        }

        private List<FiltradoPendienteViewModel> getListaCandidaturasAFiltrarAlert(DateTime aMonthEarlier, int? CentroIdUsuario)
        {
            List<FiltradoPendienteViewModel> response;
            try
            {
                var ListaCandidaturasAFiltrar = _candidaturaRepository.GetByCriteria(x => (!(CentroIdUsuario.HasValue) || x.Usuario.CentroId == CentroIdUsuario) &&
                                                (x.EtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.FiltradoTecnico) &&
                                                (x.EstadoCandidaturaId == (int)TipoEstadoCandidaturaEnum.FiltradoPeople) &&
                                                (x.Created > aMonthEarlier));

                response = ListaCandidaturasAFiltrar.ConvertToFiltradoPendienteViewModelList().ToList();
            }
            catch (Exception)
            {
                return new List<FiltradoPendienteViewModel>();
            }
            return response;
        }
                
        private List<CandidaturasPendienteStandByViewModel> getListaCandidaturasStandByAlert(DateTime nextFifteenDays, int? CentroIdUsuario)
        {
            List<CandidaturasPendienteStandByViewModel> response;
            try
            {
                var ListaCandidaturasPendienteStandBy = _candidaturaRepository.GetByCriteria(x => x.EstadoCandidaturaId == (int)TipoEstadoCandidaturaEnum.StandBy &&
                                                            x.FechaContactoStandBy != null &&
                                                            x.FechaContactoStandBy <= nextFifteenDays &&
                                                            (!(CentroIdUsuario.HasValue) || x.Usuario.CentroId == CentroIdUsuario));
                response = ListaCandidaturasPendienteStandBy.ConvertToCandidaturaPendienteStandByViewModelList().OrderBy(x => x.FechaContactoStandBy).ToList();
            }
            catch (Exception)
            {
                return new List<CandidaturasPendienteStandByViewModel>();
            }
            return response;
        }

        private List<BecariosPendientesStandByViewModel> getListaBecariosStandByAlert(DateTime nextFifteenDays, int? CentroIdUsuario)
        {
            List<BecariosPendientesStandByViewModel> response;
            try
            {
                var ListaBecariosPendienteStandBy = _becarioRepository.GetByCriteria(x => x.TipoEstadoBecarioId == (int)TipoEstadoBecarioEnum.Stand_By &&
                                                    x.FechaContactoStandBy != null &&
                                                    x.FechaContactoStandBy <= nextFifteenDays &&
                                                    (!(CentroIdUsuario.HasValue) || x.Usuario.CentroId == CentroIdUsuario));

                response = ListaBecariosPendienteStandBy.ConvertToBecarioPendienteStandByViewModelList().OrderBy(x => x.FechaContactoStandBy).ToList();
            }
            catch (Exception)
            {
                return new List<BecariosPendientesStandByViewModel>();
            }
            return response;
        }
        #endregion
    }
}
