using Recruiting.Application.BitacorasNecesidades.Services;
using Recruiting.Application.BitacorasNecesidades.ViewModels;
using Recruiting.Application.Candidaturas.Enums;
using Recruiting.Application.Clientes.Services;
using Recruiting.Application.Helpers;
using Recruiting.Application.Maestros.Enums;
using Recruiting.Application.Maestros.ViewModels;
using Recruiting.Application.Necesidades.Enums;
using Recruiting.Application.Necesidades.Mappers;
using Recruiting.Application.Necesidades.Messages;
using Recruiting.Application.Necesidades.ViewModels;
using Recruiting.Application.PersonasLibres.Services;
using Recruiting.Application.Proyectos.Services;
using Recruiting.Application.Usuarios.ViewModels;
using Recruiting.Business.BaseClasses.DataTable;
using Recruiting.Business.Entities;
using Recruiting.Business.Helpers;
using Recruiting.Business.Repositories;
using Recruiting.Data.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recruiting.Application.Necesidades.Services
{
    public class NecesidadService : INecesidadService
    {
        #region Constants

        #endregion

        #region Fields

        private readonly INecesidadRepository _necesidadRepository;
        private readonly IGrupoNecesidadRepository _grupoNecesidadRepository;
        private IGrupoNecesidadService _grupoNecesidadService;
        private readonly IProyectoRepository _proyectoRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly ICandidaturaRepository _candidaturaRepository;
        private readonly IPersonaLibreRepository _personaLibreRepository;
        private readonly IPersonasLibresService _personaLibreService;
        private readonly IProyectoService _proyectoService;
        private readonly IClienteService _clienteService;
        private readonly IMaestroRepository _maestroRepository;
        private readonly IBitacoraNecesidadRepository _bitacoraNecesidadRepository;
        private readonly IBitacoraNecesidadService _bitacoraNecesidadService;
        private readonly ICandidatoRepository _candidatoRepository;
        private readonly IPersonaLibreIdiomaRepository _personaLibreIdiomaRepository;


        #endregion

        #region Properties

        #endregion

        #region Constructors

        public NecesidadService(INecesidadRepository necesidadRepository)
        {
            _necesidadRepository = necesidadRepository;
            _grupoNecesidadRepository = new GrupoNecesidadRepository();
            _personaLibreRepository = new Data.EntityFramework.Repositories.PersonaLibreRepository();
            _personaLibreService = new PersonaLibreService(_personaLibreRepository);
            _clienteRepository = new Data.EntityFramework.Repositories.ClienteRepository();
            _clienteService = new ClienteService(_clienteRepository);
            _proyectoRepository = new Data.EntityFramework.Repositories.ProyectoRepository();
            _proyectoService = new ProyectoService(_proyectoRepository, _clienteRepository);
            _maestroRepository = new MaestroRepository();
            _bitacoraNecesidadRepository = new BitacoraNecesidadRepository();
            _bitacoraNecesidadService = new BitacoraNecesidadService(_bitacoraNecesidadRepository, _necesidadRepository, _maestroRepository);
            _candidaturaRepository = new CandidaturaRepository();
            _candidatoRepository = new CandidatoRepository();
        }

        #endregion

        #region INecesidadService members

        public GetNecesidadesResponse GetNecesidades(DataTableRequest request)
        {
            var response = new GetNecesidadesResponse();

            try
            {
                var query = FilterString(request.CustomFilters);
                var filtered = query.ApplyColumnSettings(request, NecesidadMapper.GetPropertiePath);
                response.NecesidadViewModel = filtered.ConvertToNecesidadRowViewModel();
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

        public GetStaffingNecesidadesResponse GetStaffingNecesidades(DataTableRequest request)
        {
            var response = new GetStaffingNecesidadesResponse();

            try
            {

                //establecer los filtros
                var query = FilterString(request.CustomFilters);
                var filtered = query.ApplyColumnSettings(request, NecesidadMapper.GetPropertiePath);
                response.StaffingNecesidadViewModel = filtered.ConvertToStaffingNecesidadViewModel();
                response.StaffingNecesidadViewModel = response.StaffingNecesidadViewModel.OrderByDescending(x => x.Prioridad.HasValue).ThenBy(x => x.Prioridad).ThenBy(x => x.NecesidadId);
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

        public GetStaffingPersonasResponse GetStaffingPersonas(DataTableRequest request)
        {
            var response = new GetStaffingPersonasResponse();

            try
            {
                //obtener candidaturas filtradas
                var queryCandidaturas = FilterStringCandidaturas(request.CustomFilters);

                var listaCandidatosNecesidadesActivas = _necesidadRepository.GetByCriteria(x => x.PersonaAsignadaId != null &&
                                                        (x.EstadoNecesidadId == (int)EstadoNecesidadEnum.Cerrada || x.EstadoNecesidadId == (int)EstadoNecesidadEnum.Preasignada) &&
                                                        x.IsActivo).ToList();
                var idsCandidatos = new List<int>();

                foreach (var necesidad in listaCandidatosNecesidadesActivas)
                {
                    idsCandidatos.Add((int)necesidad.PersonaAsignadaId);
                }

                var listaCandidaturasExcluir = _candidaturaRepository.GetByCriteria(x => idsCandidatos.Contains(x.CandidatoId)).ToList();

                var idsCandidaturasExcluir = new List<int>();

                foreach (var candidatura in listaCandidaturasExcluir)
                {
                    idsCandidaturasExcluir.Add(candidatura.CandidaturaId);
                }

                queryCandidaturas = queryCandidaturas.Where(x => !idsCandidaturasExcluir.Contains(x.CandidaturaId));


                var filteredCandidaturas = queryCandidaturas.ApplyColumnSettings(request, NecesidadMapper.GetPropertiePathCandidatura);
                var listaCandidaturas = filteredCandidaturas.ConvertToStaffingPersonaViewModel();

                //obtener personas libres filtradas
                var queryPersonasLibres = FilterStringPersonasLibres(request.CustomFilters);
                var filteredPersonasLibres = queryPersonasLibres.ApplyColumnSettings(request, NecesidadMapper.GetPropertiePathPersonaLibre);

                var listaPersonasLibres = filteredPersonasLibres.ConvertToStaffingPersonaViewModel();
                                
                //unir las candidaturas y personas libres en la respuesta
                response.StaffingPersonaViewModel = listaCandidaturas.Union(listaPersonasLibres);
                response.TotalElementos = queryCandidaturas.Count() + queryPersonasLibres.Count();
                response.IsValid = true;
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public GetNecesidadesExportToExcellResponse GetNecesidadesExportToExcel(DataTableRequest request)
        {
            var response = new GetNecesidadesExportToExcellResponse();

            try
            {
                //establecer los filtros
                var query = FilterString(request.CustomFilters);
                var filtered = query.ApplyColumnSettings(request, NecesidadMapper.GetPropertiePath);

                response.NecesidadExportToExcellViewModel = filtered.ConvertToNecesidadRowExportToExcelViewModel();
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
        public GetNecesidadesStaffingExportToExcelResponse GetNecesidadesStaffingExportToExcel(DataTableRequest request)
        {
            var response = new GetNecesidadesStaffingExportToExcelResponse();

            try
            {
                //establecer los filtros
                var query = FilterString(request.CustomFilters);
                query = query.OrderBy(x => x.Prioridad).ThenBy(x => x.NecesidadId);
                var filtered = query.ApplyColumnSettings(request, NecesidadMapper.GetPropertiePath);

                response.NecesidadStaffingExportToExcelViewModel = filtered.ConvertToNecesidadStaffingRowExportToExcelViewModel();
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
        public GetNecesidadesCandidaturaResponse GetNecesidadesCandidatura(DataTableRequest request)
        {
            var response = new GetNecesidadesCandidaturaResponse();

            try
            {
                var query = FilterString(request.CustomFilters);

                var filtered = query.ApplyColumnSettings(request, NecesidadMapper.GetPropertiePath);

                response.NecesidadViewModel = filtered.ConvertToNecesidadRowViewModel();
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

        public GetNecesidadesPersonaLibreResponse GetNecesidadesPersonasLibres(DataTableRequest request)
        {
            var response = new GetNecesidadesPersonaLibreResponse();

            try
            {

                var query = FilterString(request.CustomFilters);

                var filtered = query.ApplyColumnSettings(request, NecesidadMapper.GetPropertiePath);

                response.NecesidadViewModel = filtered.ConvertToNecesidadRowViewModel();
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

        public GetNecesidadesResponse GetNecesidades()
        {
            var request = new DataTableRequest();

            request.CustomFilters = new Dictionary<string, string>();

            return GetNecesidades(request);
        }

        public GetNecesidadesPersonaLibreResponse GetNecesidadesPersonasLibres()
        {
            var response = new GetNecesidadesPersonaLibreResponse();

            try
            {
                int CentroUsuarioId = 0;

                //filtro por el centro del usuario
                if (HttpContext.Current.Session["Usuario"] != null)
                {

                    var UsuarioRolPermisoViewModel = (UsuarioRolPermisoViewModel)HttpContext.Current.Session["Usuario"];
                    if (UsuarioRolPermisoViewModel.CentroIdUsuario != null)
                    {
                        CentroUsuarioId = Convert.ToInt16(HttpContext.Current.Session["CentroIdUsuario"]);
                    }
                }

                if (CentroUsuarioId == 0)
                {
                    response.NecesidadViewModel = NecesidadMapper.ConvertToNecesidadViewModel(_necesidadRepository.GetByCriteria(x => x.IsActivo));
                }
                else
                {
                    //x => x.CentroId.Equals(CentroUsuarioId) && x.IsActivo == true
                    var necesidadList = _necesidadRepository.GetByCriteria(x => x.CentroId == CentroUsuarioId && x.IsActivo);
                    response.NecesidadViewModel = NecesidadMapper.ConvertToNecesidadViewModel(necesidadList);
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

        public GetNecesidadesResponse GetNecesidadesByCentroUsuarioId(int CentroUsuarioId)
        {
            var request = new DataTableRequest();

            request.CustomFilters = new Dictionary<string, string>();
            request.CustomFilters.Add("CentroUsuarioId", CentroUsuarioId.ToString());

            return GetNecesidades(request);
        }



        public GetNecesidadByIdResponse GetNecesidadById(int necesidadId)
        {
            var response = new GetNecesidadByIdResponse();

            try
            {
                var necesidad = _necesidadRepository.GetOne(x => x.NecesidadId == necesidadId);

                response.NecesidadViewModel = necesidad.ConvertToCreateEditNecesidadViewModel();
                response.IsValid = true;
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public GetNecesidadByNombreCandidatoResponse GetNecesidadByNombreCandidato(string candidato)
        {
            var response = new GetNecesidadByNombreCandidatoResponse();

            try
            {
                var necesidad = _necesidadRepository.GetOne(x => x.PersonaAsignada.Replace(" ", "") == candidato);

                response.necesidadId = necesidad.NecesidadId;
                response.IsValid = true;
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public CloneNecesidadResponse CloneNecesidad(int necesidadId)
        {
            var response = new CloneNecesidadResponse();

            try
            {
                response.CreateEditNecesidadViewModel = NecesidadMapper.ConvertToCreateEditNecesidadViewModel(_necesidadRepository.GetOne(x => x.NecesidadId == necesidadId));
                response.IsValid = true;
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public DeleteNecesidadResponse DeleteNecesidad(int necesidadId, bool ultNecesidadGrupo)
        {
            _grupoNecesidadService = new GrupoNecesidadService(_grupoNecesidadRepository, _necesidadRepository);

            var response = new DeleteNecesidadResponse();

            try
            {
                var necesidad = _necesidadRepository.GetOne(x => x.NecesidadId == necesidadId);
                if (ultNecesidadGrupo)
                {
                    _grupoNecesidadService.DeleteGrupoNecesidad((int)necesidad.GrupoNecesidadId);
                    response.IsValid = true;
                }
                else
                {
                    //change active to delete
                    necesidad.IsActivo = false;

                    if (((necesidad.EstadoNecesidadId == (int)EstadoNecesidadEnum.Preasignada || necesidad.EstadoNecesidadId == (int)EstadoNecesidadEnum.Cerrada)
                            && necesidad.TipoContratacionId == (int)TipoContratacionEnum.CambioInterno)
                            && necesidad.PersonaAsignadaId != null && necesidad.PersonaAsignadaNroEmpleado != null)
                    {
                        _personaLibreService.LiberatePersonaLibre(necesidad.PersonaAsignadaId.Value, necesidad.PersonaAsignadaNroEmpleado.Value, necesidad.NecesidadId);
                    }

                    if (_necesidadRepository.Update(necesidad) > 0)
                    {
                        response.IsValid = true;
                    }
                    else
                    {
                        response.IsValid = false;
                        response.ErrorMessage = "Error to delete Necesidad";
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

        public SaveNecesidadResponse SaveNecesidad(CreateEditNecesidadViewModel necesidadViewModel)
        {
            var response = new SaveNecesidadResponse();

            try
            {
                if (necesidadViewModel.NecesidadId == null)
                {
                    var newNecesidad = Save(necesidadViewModel);
                    if (newNecesidad != null)
                    {
                        response.IsValid = true;
                        response.NecesidadId = newNecesidad.NecesidadId;
                        _bitacoraNecesidadService.GenerateBitacoraCreateNecesidad(newNecesidad.NecesidadId);

                    }
                    else
                    {
                        response.IsValid = false;
                        response.ErrorMessage = "Error to save Necesidad";
                    }
                }
                else
                {
                    //cargamos los datos para comprobar la bitacora
                    var necesidad = _necesidadRepository.GetOne(x => x.NecesidadId == (int)necesidadViewModel.NecesidadId);
                    DatosComparativaBitacoraViewModel datosComparativaBitacoraViewModel = new DatosComparativaBitacoraViewModel();
                    datosComparativaBitacoraViewModel.EstadoAnteriorId = necesidad.EstadoNecesidadId;
                    datosComparativaBitacoraViewModel.PerfilAnteriorId = necesidad.TipoPerfilId;
                    datosComparativaBitacoraViewModel.FechaSolicitudAnterior = necesidad.FechaSolicitud;
                    datosComparativaBitacoraViewModel.FechaCompromisoAnterior = necesidad.FechaCompromiso;
                    datosComparativaBitacoraViewModel.FechaCierreAnterior = necesidad.FechaCierre;
                    datosComparativaBitacoraViewModel.PersonaAsignadaAnterior = necesidad.PersonaAsignada;


                    if (Update(necesidadViewModel) > 0)
                    {
                        if (necesidad.GrupoNecesidadId != null)
                        {
                            _grupoNecesidadService = new GrupoNecesidadService(_grupoNecesidadRepository, _necesidadRepository);
                            _grupoNecesidadService.CheckGrupoCerrado(necesidad.GrupoNecesidadId ?? default(int));
                        }

                        response.IsValid = true;
                        response.NecesidadId = (int)necesidadViewModel.NecesidadId;
                        datosComparativaBitacoraViewModel.NecesidadId = (int)necesidadViewModel.NecesidadId;
                        datosComparativaBitacoraViewModel.EstadoNuevoId = necesidadViewModel.EstadoNecesidadId;
                        datosComparativaBitacoraViewModel.PerfilNuevoId = necesidadViewModel.TipoPerfilId;
                        datosComparativaBitacoraViewModel.FechaSolicitudNueva = necesidadViewModel.FechaSolicitud;
                        datosComparativaBitacoraViewModel.FechaCompromisoNueva = necesidadViewModel.FechaCompromiso;
                        datosComparativaBitacoraViewModel.FechaCierreNueva = necesidadViewModel.FechaCierre;
                        datosComparativaBitacoraViewModel.PersonaAsignadaNueva = necesidadViewModel.PersonaAsignada;
                        _bitacoraNecesidadService.GenerateBitacoraEditNecesidad(datosComparativaBitacoraViewModel);

                    }
                    else
                    {
                        response.IsValid = false;
                        response.ErrorMessage = "Error to update Necesidad";
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

        public SaveNecesidadResponse AbrirNecesidad(int idNecesidad)
        {
            SaveNecesidadResponse necesidadResponseSave = new SaveNecesidadResponse() { NecesidadId = idNecesidad };
            try
            {
                var necesidad = _necesidadRepository.GetOne(x => x.NecesidadId == idNecesidad);
                if (necesidad != null)
                {
                    if (((necesidad.EstadoNecesidadId == (int)EstadoNecesidadEnum.Preasignada || necesidad.EstadoNecesidadId == (int)EstadoNecesidadEnum.Cerrada)
                    && necesidad.TipoContratacionId == (int)TipoContratacionEnum.CambioInterno)
                    && necesidad.PersonaAsignadaId != null && necesidad.PersonaAsignadaNroEmpleado != null)
                    {
                        _personaLibreService.LiberatePersonaLibre(necesidad.PersonaAsignadaId.Value, necesidad.PersonaAsignadaNroEmpleado.Value, necesidad.NecesidadId);
                    }
                    necesidad.CandidaturaId = null;
                    necesidad.PersonaAsignada = "";
                    necesidad.PersonaAsignadaId = null;
                    necesidad.PersonaAsignadaNroEmpleado = null;

                    necesidad.EstadoNecesidadId = (int)EstadoNecesidadEnum.Abierta;
                    necesidad.FechaCierre = null;
                    necesidad.AsignadaCorrectamente = null;

                    necesidadResponseSave.IsValid = Update(necesidad.ConvertToCreateEditNecesidadViewModel()) > 0;
                }
            }
            catch (Exception ex)
            {
                necesidadResponseSave.ErrorMessage = ex.Message;
                necesidadResponseSave.IsValid = false;
            }

            return necesidadResponseSave;
        }

        public bool ComprobarTecnologia(int tecnologia, string centro)
        {
            var salida = false;

            if(!string.IsNullOrEmpty(centro))
            {
                int centroId = Convert.ToInt32(centro);

                var response = _necesidadRepository.Find(x => x.TipoTecnologiaId == tecnologia && x.IsActivo && x.Usuario.CentroId == centroId && (x.EstadoNecesidadId == (int)EstadoNecesidadEnum.Preasignada || x.EstadoNecesidadId == (int)EstadoNecesidadEnum.Abierta) && x.TipoPrevisionId == (int)TipoPrevisionEnum.Confirmado);

                if (response != null)
                {
                    salida = true;
                }
                else
                {
                    salida = false;
                }
            }
            else
            {
                var response = _necesidadRepository.Find(x => x.TipoTecnologiaId == tecnologia && x.IsActivo && (x.EstadoNecesidadId == (int)EstadoNecesidadEnum.Preasignada || x.EstadoNecesidadId == (int)EstadoNecesidadEnum.Abierta));

                if (response != null)
                {
                    salida = true;
                }
                else
                {
                    salida = false;
                }
            }                      

            return salida;
        }

        public bool ComprobarPerfil(int perfil, string centro)
        {
            var salida = false;

            if (!string.IsNullOrEmpty(centro))
            {
                int centroId = Convert.ToInt32(centro);

                var response = _necesidadRepository.Find(x => x.TipoPerfilId == perfil && x.IsActivo && x.Usuario.CentroId == centroId && (x.EstadoNecesidadId == (int)EstadoNecesidadEnum.Preasignada || x.EstadoNecesidadId == (int)EstadoNecesidadEnum.Abierta) && x.TipoPrevisionId == (int)TipoPrevisionEnum.Confirmado);

                if (response != null)
                {
                    salida = true;
                }
                else
                {
                    salida = false;
                }
            }
            else
            {
                var response = _necesidadRepository.Find(x => x.TipoPerfilId == perfil && x.IsActivo && (x.EstadoNecesidadId == (int)EstadoNecesidadEnum.Preasignada || x.EstadoNecesidadId == (int)EstadoNecesidadEnum.Abierta));

                if (response != null)
                {
                    salida = true;
                }
                else
                {
                    salida = false;
                }
            }

            return salida;
        }

        public SaveNecesidadResponse CerrarNecesidad(int idNecesidad, DateTime FechaIncorporacion)
        {
            SaveNecesidadResponse necesidadResponseSave = new SaveNecesidadResponse() { NecesidadId = idNecesidad };
            try
            {
                var necesidad = _necesidadRepository.GetOne(x => x.NecesidadId == idNecesidad);
                if (necesidad != null)
                {
                    if (((necesidad.EstadoNecesidadId == (int)EstadoNecesidadEnum.Preasignada || necesidad.EstadoNecesidadId == (int)EstadoNecesidadEnum.Cerrada)
                        && necesidad.TipoContratacionId == (int)TipoContratacionEnum.CambioInterno)
                        && necesidad.PersonaAsignadaId != null && necesidad.PersonaAsignadaNroEmpleado != null)
                    {
                        _personaLibreService.LiberatePersonaLibre(necesidad.PersonaAsignadaId.Value, necesidad.PersonaAsignadaNroEmpleado.Value, necesidad.NecesidadId);
                        necesidad.PersonaAsignada = "";
                        necesidad.PersonaAsignadaId = null;
                        necesidad.PersonaAsignadaNroEmpleado = null;
                    }
                    necesidad.EstadoNecesidadId = (int)EstadoNecesidadEnum.Cerrada;
                    necesidad.FechaCierre = FechaIncorporacion;
                    necesidadResponseSave.IsValid = Update(necesidad.ConvertToCreateEditNecesidadViewModel()) > 0;
                }
            }
            catch (Exception ex)
            {
                necesidadResponseSave.ErrorMessage = ex.Message;
                necesidadResponseSave.IsValid = false;
            }

            return necesidadResponseSave;
        }

        public SaveStaffingNecesidadResponse SaveStaffingNecesidad(SaveStaffingNecesidadViewModel staffingNecesidad)
        {
            var response = new SaveStaffingNecesidadResponse();


            try
            {
                var necesidad = _necesidadRepository.GetOne(x => x.NecesidadId == staffingNecesidad.NecesidadId && x.IsActivo);
               

                if (staffingNecesidad.PersonaAsignadaId != null && staffingNecesidad.TipoPersonaId != null)
                {
                    if (staffingNecesidad.TipoPersonaId == (int)TipoPersonaEnum.Candidatura)
                    {
                        CheckLiberateNecesidad(necesidad.NecesidadId);

                        var candidatura = _candidaturaRepository.GetOne(x => x.CandidaturaId == staffingNecesidad.PersonaAsignadaId);
                        var personaAsignada = _candidatoRepository.GetOne(x => x.CandidatoId == candidatura.CandidatoId);
                        necesidad.CandidaturaId = staffingNecesidad.PersonaAsignadaId;
                        necesidad.PersonaAsignadaId = personaAsignada.CandidatoId;
                        necesidad.PersonaAsignada = personaAsignada.Nombre + " " + personaAsignada.Apellidos;
                        necesidad.PersonaAsignadaNroEmpleado = null;
                        necesidad.EstadoNecesidadId = (int)EstadoNecesidadEnum.Preasignada;
                        necesidad.TipoContratacionId = (int)TipoContratacionEnum.Contratación;

                        if (candidatura.CategoriaId != null && (necesidad.TipoPerfilId != candidatura.CategoriaId))
                        {
                                necesidad.TipoPerfilId = (int)candidatura.CategoriaId;
                        }

                        if (candidatura.CartaOfertas.Count > 0)
                        {
                            candidatura.CartaOfertas.First().NecesidadId = necesidad.NecesidadId;
                            _candidaturaRepository.Update(candidatura);
                        }
                    }
                    else
                    {
                        CheckLiberateNecesidad(necesidad.NecesidadId);
                        var personaLibre = _personaLibreRepository.GetOne(x => x.PersonaLibreId == staffingNecesidad.PersonaAsignadaId && x.IsActivo);
                        necesidad.PersonaAsignadaId = staffingNecesidad.PersonaAsignadaId;
                        necesidad.PersonaAsignadaNroEmpleado = personaLibre.NroEmpleado;
                        necesidad.PersonaAsignada = personaLibre.Nombre + " " + personaLibre.Apellidos;
                        necesidad.CandidaturaId = null;
                        necesidad.EstadoNecesidadId = (int)EstadoNecesidadEnum.Preasignada;
                        necesidad.TipoContratacionId = (int)TipoContratacionEnum.CambioInterno;
                        _personaLibreService.UpdatePersonaLibreByNecesidadIdAndPersonaLibreId(staffingNecesidad.NecesidadId, (int)staffingNecesidad.PersonaAsignadaId);
                    }
                }
                _necesidadRepository.Update(necesidad);
                response.IsValid = true;
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }


            return response;
        }
        
        public SaveObservacionesStaffingResponse SaveObservacionesStaffing(int necesidadId, string observacionesStaffing)
        {
            var response = new SaveObservacionesStaffingResponse();


            try
            {
                var necesidad = _necesidadRepository.GetOne(x => x.NecesidadId == necesidadId && x.IsActivo);
                necesidad.ObservacionesStaffing = observacionesStaffing;
                _necesidadRepository.Update(necesidad);
                response.IsValid = true;
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }


            return response;
        }

        public SavePrioridadNecesidadResponse SavePrioridadNecesidad(SavePrioridadNecesidadViewModel staffingNecesidad)
        {
            var response = new SavePrioridadNecesidadResponse();


            try
            {
                var necesidad = _necesidadRepository.GetOne(x => x.NecesidadId == staffingNecesidad.NecesidadId && x.IsActivo);
                necesidad.Prioridad = staffingNecesidad.Prioridad;
                _necesidadRepository.Update(necesidad);
                response.IsValid = true;                
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }


            return response;
        }
        

        public GetNecesidadByCandidaturaIdAndCandidatoIdResponse GetNecesidadByCandidaturaIdAndCandidatoId(int candidaturaId, int candidatoId)
        {
            var response = new GetNecesidadByCandidaturaIdAndCandidatoIdResponse();
            try
            {
                var necesidadesQueCumplen = _necesidadRepository.GetByCriteria(x => x.CandidaturaId == candidaturaId &&
                                                                    (x.PersonaAsignadaId == candidatoId || (x.PersonaAsignada.Contains(x.Candidatura.Candidato.Nombre) && x.PersonaAsignada.Contains(x.Candidatura.Candidato.Apellidos)))).AsQueryable();

                if (necesidadesQueCumplen.Count() > 0)
                {
                    var fechaNecesidadAMostrar = necesidadesQueCumplen.Max(x => x.Created);

                    var necesidadAMostrar = from n in necesidadesQueCumplen
                                            where n.Created == fechaNecesidadAMostrar
                                            select n;

                    foreach (var necesidad in necesidadesQueCumplen)
                    {
                        if (necesidad.Modified != null)
                        {
                            fechaNecesidadAMostrar = necesidadesQueCumplen.Max(x => x.Modified).Value;
                            necesidadAMostrar = from n in necesidadesQueCumplen
                                                where n.Modified == fechaNecesidadAMostrar
                                                select n;
                            break;
                        }
                    }

                    response.necesidadId = necesidadAMostrar.FirstOrDefault().NecesidadId;
                    response.necesidadNombre = necesidadAMostrar.FirstOrDefault().Nombre;
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

        public CheckLiberateNecesidadResponse CheckLiberateNecesidad(int necesidadId)
        {
            var response = new CheckLiberateNecesidadResponse();
            try
            {
                var necesidad = _necesidadRepository.GetOne(x => x.NecesidadId == necesidadId && x.IsActivo);

                if (necesidad.TipoContratacionId == (int)TipoContratacionEnum.Contratación)
                {
                    if (necesidad.CandidaturaId != null)
                    {
                        var candidatura = _candidaturaRepository.GetOne(x => x.CandidaturaId == necesidad.CandidaturaId && x.IsActivo);
                        if (candidatura.CartaOfertas.Count > 0)
                        {
                            candidatura.CartaOfertas.FirstOrDefault().NecesidadId = null;
                        }

                    }
                        necesidad.PersonaAsignadaId = null;
                        necesidad.PersonaAsignada = null;
                        necesidad.CandidaturaId = null;
                        necesidad.EstadoNecesidadId = (int)EstadoNecesidadEnum.Abierta;
                }
                else if (necesidad.TipoContratacionId == (int)TipoContratacionEnum.CambioInterno)
                {
                    if (necesidad.PersonaAsignadaNroEmpleado != null && necesidad.PersonaAsignadaId != null)
                    {
                        _personaLibreService.LiberatePersonaLibre((int)necesidad.PersonaAsignadaId, (int)necesidad.PersonaAsignadaNroEmpleado, necesidad.NecesidadId);
                    }
                    necesidad.PersonaAsignadaId = null;
                    necesidad.PersonaAsignada = null;
                    necesidad.PersonaAsignadaNroEmpleado = null;
                    necesidad.EstadoNecesidadId = (int)EstadoNecesidadEnum.Abierta;
                }
                _necesidadRepository.Update(necesidad);

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

        #region Private Methods


        private Necesidad Save(CreateEditNecesidadViewModel createEditNecesidadViewModel)
        {
            var necesidad = new Necesidad();

            var proyecto = _proyectoRepository.GetOne(x => x.ProyectoId == createEditNecesidadViewModel.ProyectoId);

            necesidad.UpdateNecesidad(createEditNecesidadViewModel, proyecto);
            var newNecesidad = _necesidadRepository.Create(necesidad);

            return newNecesidad;
        }

        private int Update(CreateEditNecesidadViewModel createEditNecesidadViewModel)
        {
            var necesidad = _necesidadRepository.GetOne(x => x.NecesidadId == createEditNecesidadViewModel.NecesidadId);

            if (((necesidad.EstadoNecesidadId == (int)EstadoNecesidadEnum.Preasignada || necesidad.EstadoNecesidadId == (int)EstadoNecesidadEnum.Cerrada)
                && necesidad.TipoContratacionId == (int)TipoContratacionEnum.CambioInterno)
                && (createEditNecesidadViewModel.EstadoNecesidadId == (int)EstadoNecesidadEnum.Cancelado || createEditNecesidadViewModel.EstadoNecesidadId == (int)EstadoNecesidadEnum.Abierta
                || createEditNecesidadViewModel.TipoContratacionId != (int)TipoContratacionEnum.CambioInterno
                || necesidad.PersonaAsignadaId != createEditNecesidadViewModel.PersonaAsignadaId)
                && necesidad.PersonaAsignadaId.HasValue && necesidad.PersonaAsignadaNroEmpleado.HasValue)
            {
                _personaLibreService.LiberatePersonaLibre(necesidad.PersonaAsignadaId.Value, necesidad.PersonaAsignadaNroEmpleado.Value, necesidad.NecesidadId);
            }

            if ((createEditNecesidadViewModel.EstadoNecesidadId == (int)EstadoNecesidadEnum.Preasignada
             || createEditNecesidadViewModel.EstadoNecesidadId == (int)EstadoNecesidadEnum.Cerrada)
              && createEditNecesidadViewModel.TipoContratacionId == (int)TipoContratacionEnum.CambioInterno
              && (createEditNecesidadViewModel.PersonaAsignada != "" && createEditNecesidadViewModel.PersonaAsignada != null)
              && createEditNecesidadViewModel.PersonaAsignadaId != null)
            {
                var personaLibre = _personaLibreRepository.GetOne(x => x.PersonaLibreId == createEditNecesidadViewModel.PersonaAsignadaId);
                if (personaLibre != null)
                {
                    createEditNecesidadViewModel.PersonaAsignadaNroEmpleado = personaLibre.NroEmpleado;
                }
                _personaLibreService.UpdatePersonaLibreByNecesidadIdAndPersonaLibreId(createEditNecesidadViewModel.NecesidadId.Value, createEditNecesidadViewModel.PersonaAsignadaId.Value);
            }

            necesidad.UpdateNecesidad(createEditNecesidadViewModel, null);
            return _necesidadRepository.Update(necesidad);

        }

        private IQueryable<Necesidad> FilterString(IDictionary<string, string> customFilter)
        {
            var query = _necesidadRepository.GetAll();

            // Solo devolvemos candidatos activos.
            query = query.Where(x => x.IsActivo);

            if (customFilter.ContainsKey("Cliente") && (customFilter["Cliente"] != string.Empty))
            {
                    var clienteId = Convert.ToInt32(customFilter["Cliente"]);
                    query = query.Where(x => x.Proyecto.ClienteId == clienteId);
            }

            if (customFilter.ContainsKey("Proyecto") && (customFilter["Proyecto"] != string.Empty))
            {
                    var proyectoId = Convert.ToInt32(customFilter["Proyecto"]);
                    query = query.Where(x => x.ProyectoId == proyectoId);
            }

            if (customFilter.ContainsKey("Tecnologia") && (customFilter["Tecnologia"] != string.Empty))
            {
                    var tipoTecnologiaId = Convert.ToInt32(customFilter["Tecnologia"]);
                    query = query.Where(x => x.TipoTecnologiaId == tipoTecnologiaId);
            }

            if (customFilter.ContainsKey("Estados[]") && (customFilter["Estados[]"] != string.Empty))
            {
                    var ids = customFilter["Estados[]"].Split(',').Select(x => int.Parse(x.Trim()));                    
                    query = query.Where(x => ids.Contains(x.EstadoNecesidadId));
            }

            if (customFilter.ContainsKey("Estados") && (customFilter["Estados"] != string.Empty))
            {
                    var ids = customFilter["Estados"].Split(',').Select(x => int.Parse(x.Trim()));
                    query = query.Where(x => ids.Contains(x.EstadoNecesidadId));
            }

            if(customFilter.ContainsKey("EstadoStaffing") && (customFilter["EstadoStaffing"] != string.Empty))
            {
                    var estadoStaffingNecesidadId = Convert.ToInt32(customFilter["EstadoStaffing"]);
                    List<int> ids = new List<int>();
                    if (estadoStaffingNecesidadId == (int)EstadoStaffingNecesidadEnum.SoloAbiertas)
                    {
                        ids.Add((int)EstadoNecesidadEnum.Abierta);
                    }
                    else
                    {
                        ids.Add((int)EstadoNecesidadEnum.Abierta);
                        ids.Add((int)EstadoNecesidadEnum.Preasignada);
                    }
                    query = query.Where(x => ids.Contains(x.EstadoNecesidadId));
            }

            if (customFilter.ContainsKey("Perfil") && (customFilter["Perfil"] != string.Empty))
            {
                    var tipoPerfilId = Convert.ToInt32(customFilter["Perfil"]);
                    query = query.Where(x => x.TipoPerfilId == tipoPerfilId);
            }

            if (customFilter.ContainsKey("SolicitadoDesde") && (customFilter["SolicitadoDesde"] != string.Empty))
            {
                    var fechaSolicitud = Convert.ToDateTime(customFilter["SolicitadoDesde"]);
                    query = query.Where(x => x.FechaSolicitud >= fechaSolicitud);
            }

            if (customFilter.ContainsKey("SolicitadoHasta") && (customFilter["SolicitadoHasta"] != string.Empty))
            {
                    var fechaSolicitud = Convert.ToDateTime(customFilter["SolicitadoHasta"]);
                    query = query.Where(x => x.FechaSolicitud <= fechaSolicitud);
            }

            if (customFilter.ContainsKey("CerradoDesde") && (customFilter["CerradoDesde"] != string.Empty))
            {
                    var fechaCierre = Convert.ToDateTime(customFilter["CerradoDesde"]);
                    query = query.Where(x => x.FechaCierre >= fechaCierre);
            }

            if (customFilter.ContainsKey("CerradoHasta") && (customFilter["CerradoHasta"] != string.Empty))
            {
                    var fechaCierre = Convert.ToDateTime(customFilter["CerradoHasta"]);
                    query = query.Where(x => x.FechaCierre <= fechaCierre);
            }

            if (customFilter.ContainsKey("IdNecesidad") && (customFilter["IdNecesidad"] != string.Empty))
            {
                    var necesidadId = Convert.ToInt32(customFilter["IdNecesidad"]);
                    query = query.Where(x => x.NecesidadId == necesidadId);
            }

            if (customFilter.ContainsKey("FechaCompromiso") && (customFilter["FechaCompromiso"] != string.Empty))
            {
                    var fechaCompromiso = Convert.ToDateTime(customFilter["FechaCompromiso"]);
                    query = query.Where(x => x.FechaCompromiso <= fechaCompromiso);
            }
            if (customFilter.ContainsKey("Prevision") && (customFilter["Prevision"] != string.Empty))
            {
                    var prevision = Convert.ToUInt32(customFilter["Prevision"]);
                    query = query.Where(x => x.TipoPrevisionId == prevision);
            }
            if (customFilter.ContainsKey("FechaModificacion") && (customFilter["FechaModificacion"] != string.Empty))
            {
                    var dayPeriod = Convert.ToUInt32(customFilter["FechaModificacion"]);
                    var datePeriod = DateTime.Now.Date.AddDays(-dayPeriod);
                    query = query.Where(x => x.Modified > datePeriod || x.Created > datePeriod);
            }

            //las necesidades se filtran por el centro de la necesidad, no por el del idcentro del usuario que la crea
            //se filtra por el centro del usuario logado salvo cuando hay un Centro de busqueda que buscaria los del centro en cuestion (CentroSearch)
            if (customFilter.ContainsKey("CentroUsuarioId") && (customFilter["CentroUsuarioId"] != string.Empty || customFilter.ContainsKey("CentroSearch")))
            {
                    if (customFilter.ContainsKey("CentroSearch"))
                    {
                        if (customFilter["CentroSearch"] != string.Empty)
                        {
                            var CentroUsuarioId = Convert.ToInt32(customFilter["CentroSearch"]);
                            query = query.Where(x => x.CentroId == CentroUsuarioId);
                        }
                        else
                        {
                            if (customFilter["CentroUsuarioId"] != string.Empty)
                            {
                                var CentroUsuarioId = Convert.ToInt32(customFilter["CentroUsuarioId"]);
                                query = query.Where(x => x.CentroId == CentroUsuarioId);
                            }
                        }
                    }
                    else
                    {
                        var CentroUsuarioId = Convert.ToInt32(customFilter["CentroUsuarioId"]);
                        query = query.Where(x => x.CentroId == CentroUsuarioId);
                    }
            }

            if (customFilter.ContainsKey("CentroSearch") && !customFilter.ContainsKey("CentroUsuarioId") && (customFilter["CentroSearch"] != string.Empty))
            {
                    var CentroUsuarioId = Convert.ToInt32(customFilter["CentroSearch"]);
                    query = query.Where(x => x.CentroId == CentroUsuarioId);
            }


            if (customFilter.ContainsKey("MisNecesidades"))
            {
                string value = customFilter["MisNecesidades"];

                if (!string.IsNullOrEmpty(value) && (value == "true"))
                {
                        int usuarioLogado = ModifiableEntityHelper.GetCurrentUser();
                        query = query.Where(x => x.Usuario.UsuarioId == usuarioLogado);
                }
            }

            if (customFilter.ContainsKey("NecesidadIdioma"))
            {
                string value = customFilter["NecesidadIdioma"];

                if (!string.IsNullOrEmpty(value) && (value == "true"))
                {
                        var NecesidadIdioma = Convert.ToBoolean(customFilter["NecesidadIdioma"]);
                        query = query.Where(x => x.NecesidadIdioma == NecesidadIdioma);
                }
            }

            if (customFilter.ContainsKey("TipoContratacionId"))
            {
                var value = customFilter["TipoContratacionId"];
                if (!string.IsNullOrWhiteSpace(value))
                {
                    var id = Convert.ToInt32(value);
                    query = query.Where(x => x.TipoContratacionId == id);
                }
            }

            if (customFilter.ContainsKey("AsignadoCorrectamente") && (customFilter["AsignadoCorrectamente"] != string.Empty))
            {
                    var asignadoCorrectamente = Convert.ToBoolean(customFilter["AsignadoCorrectamente"]);
                    query = query.Where(x => x.AsignadaCorrectamente == asignadoCorrectamente);
            }

            return query;
        }
        private IQueryable<Candidatura> FilterStringCandidaturas(IDictionary<string, string> customFilter)
        {
            var query = _candidaturaRepository.GetAll();

            query = query.Where(x => x.IsActivo);

            if (customFilter.ContainsKey("Estados[]") && (customFilter["Estados[]"] != string.Empty))
            {
                    var ids = customFilter["Estados[]"].Split(',').Select(x => int.Parse(x.Trim()));
                    if (ids.Contains((int)TipoEstadoCandidaturaEnum.Entrevista))
                    {
                        var idsList = ids.ToList();
                        idsList.Add((int)TipoEstadoCandidaturaEnum.SegundaEntrevista);
                        ids = idsList.AsEnumerable();
                    }
                    query = query.Where(x => ids.Contains(x.EstadoCandidaturaId));
            }

            if (customFilter.ContainsKey("Etapas[]") && (customFilter["Etapas[]"] != string.Empty))
            {
                    var ids = customFilter["Etapas[]"].Split(',').Select(x => int.Parse(x.Trim()));
                    query = query.Where(x => ids.Contains(x.EtapaCandidaturaId));
            }

            if (customFilter.ContainsKey("Etapas") && (customFilter["Etapas"] != string.Empty))
            {
                    var ids = customFilter["Etapas"].Split(',').Select(x => int.Parse(x.Trim()));
                    query = query.Where(x => ids.Contains(x.EtapaCandidaturaId));
            }

            if (customFilter.ContainsKey("Perfil") && (customFilter["Perfil"] != string.Empty))
            {
                    var categoriaId = Convert.ToInt32(customFilter["Perfil"]);
                    query = query.Where(x => x.CategoriaId == categoriaId || x.CategoriaId == null);
            }

            if (customFilter.ContainsKey("Tecnologia") && (customFilter["Tecnologia"] != string.Empty))
            {
                    var Tecnologia = Convert.ToInt32(customFilter["Tecnologia"]);
                    query = query.Where(x => x.TipoTecnologiaId == Tecnologia || x.TipoTecnologiaId == null);
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
            return query;
        }

        private IQueryable<PersonaLibre> FilterStringPersonasLibres(IDictionary<string, string> customFilter)
        {
            var query = _personaLibreRepository.GetAll();

            query = query.Where(x => x.IsActivo);
            query = query.Where(x => x.SinNecesidadAsignada);

            if (customFilter.ContainsKey("Tecnologia") && (customFilter["Tecnologia"] != string.Empty))
            {
                    var Tecnologia = Convert.ToInt32(customFilter["Tecnologia"]);
                    query = query.Where(x => x.TipoTecnologiaId == Tecnologia);
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
            return query;
        }
               
        public bool CheckUltimaNecesidadEnGrupo(int id)
        {
            var ultimaNeceisdad = false;

            var necesidad = _necesidadRepository.GetOne(x => x.NecesidadId == id);
            var grupoNecesidad = _grupoNecesidadRepository.GetOne(x => x.GrupoNecesidadId == necesidad.GrupoNecesidadId);


            if (grupoNecesidad != null && grupoNecesidad.NecesidadesAsignadas.Count(x => x.IsActivo) == 1)
            {
                ultimaNeceisdad = true;

            }
            else
            {
                ultimaNeceisdad = false;
            }



            return ultimaNeceisdad;
        }            
        #endregion
    }
}
