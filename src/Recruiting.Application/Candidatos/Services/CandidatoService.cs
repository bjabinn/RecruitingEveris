using Recruiting.Application.Becarios.Enums;
using Recruiting.Application.Candidatos.Enums;
using Recruiting.Application.Candidatos.Mappers;
using Recruiting.Application.Candidatos.Messages;
using Recruiting.Application.Candidatos.ViewModels;
using Recruiting.Application.Candidaturas.Enums;
using Recruiting.Application.Candidaturas.Messages;
using Recruiting.Application.Helpers;
using Recruiting.Business.BaseClasses.DataTable;
using Recruiting.Business.Entities;
using Recruiting.Business.Helpers;
using Recruiting.Business.Repositories;
using Recruiting.Infra.Helpers;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;

namespace Recruiting.Application.Candidatos.Services
{
    public class CandidatoService : ICandidatoService
    {
        #region Constants

        #endregion

        #region Fields

        private readonly ICandidatoRepository _candidatoRepository;
        private readonly ICandidatoIdiomaRepository _candidatoIdiomaRepository;
        private readonly ICandidatoExperienciaRepository _candidatoExperienciaRepository;
        private readonly ICandidatoContactoRepository _candidatoContactoRepository;
        private readonly ICandidaturaRepository _candidaturaRepository;
        private readonly IBecarioRepository _becarioRepository;
   

        #endregion

        #region Properties

        #endregion

        #region Constructors

        public CandidatoService(ICandidatoRepository candidatoRepository, ICandidatoIdiomaRepository candidatoIdiomaRepository,
            ICandidatoExperienciaRepository candidatoExperienciaRepository, ICandidatoContactoRepository candidatoContactoRepository,
            ICandidaturaRepository candidaturaRepository, IBecarioRepository becarioRepository)
        {
            _candidatoRepository = candidatoRepository;
            _candidatoIdiomaRepository = candidatoIdiomaRepository;
            _candidatoExperienciaRepository = candidatoExperienciaRepository;
            _candidatoContactoRepository = candidatoContactoRepository;
            _candidaturaRepository = candidaturaRepository;
            _becarioRepository = becarioRepository;
        }

        #endregion

        #region ICandidatoService members

        public GetCandidatosResponse GetCandidatosCandidatura(DataTableRequest request, bool contarCandidaturas = true)
        {
            var response = new GetCandidatosResponse();

            try
            {
                var candidatosDescartados = GetCandidatosDescartados();
                var candidatosBecasAbiertas = GetCandidatosEnBecasAbiertas();
                var candidatosCandidaturasAbiertas = GetCandidatosEnCandidaturasAbiertas();
                var candidatosOmitir = candidatosCandidaturasAbiertas.Union(candidatosBecasAbiertas).Union(candidatosDescartados).Distinct().ToList();

                var query = FilterString(request.CustomFilters);

                //si buscamos desde candidatos no es necesario buscar los que tienen becas y candidaturas abiertas
                if (!contarCandidaturas)
                {
                    //Es necesario convertir a lista para optimizar rendimiento en 10 segundos en prod.
                    query = query.ToList().Where(x => !candidatosOmitir.Contains(x.CandidatoId)).AsQueryable();
                }

                var filtered = query.ApplyColumnSettings(request, CandidatoMapper.GetPropertiePath);

                IDictionary<Candidato, GetDatosByCandidatoIdResponse> relacionCandidatoCandidatura = new Dictionary<Candidato, GetDatosByCandidatoIdResponse>();


                if (contarCandidaturas) //Esto sólo ocurre si buscamos desde candidatos, porque necesitamos saber el total de candidaturas que tiene un candidato
                {
                    foreach (var candidato in filtered)
                    {
                        relacionCandidatoCandidatura[candidato] = GetDatosByCandidatoId(candidato.CandidatoId);
                    }
                    response.CandidatoRowViewModel = relacionCandidatoCandidatura.ConvertToCandidatoRowViewModel(candidatosOmitir);
                }
                else //Esto ocurre desde el buscador de candidatos de candidaturas, donde no mostramos dicha cifra.
                {
                    response.CandidatoRowViewModel = filtered.ConvertToCandidatoRowViewModel();
                }

                foreach (var candidato in response.CandidatoRowViewModel)
                {
                    if (_candidaturaRepository.Contains(x => x.IsActivo && x.CandidatoId == candidato.CandidatoId))
                    {
                        candidato.ExistenCandidaturas = true;
                    }
                    if (_becarioRepository.Contains(x => x.IsActivo && x.CandidatoId == candidato.CandidatoId))
                    {
                        candidato.ExistenBecarios = true;
                    }
                }

                response.TotalElementos = query.Count();

                response.IsValid = true;
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }
            if (contarCandidaturas) //Igual que antes, sólo necesitamos la información del curriculum si buscamos desde Candidatos
            {
                foreach (var candidato in response.CandidatoRowViewModel)
                {
                    int id = candidato.CandidatoId;
                    var tieneCv = TieneCVEnBD(id); //Se hace aparte para no hacer consultas extra en el mapper en caso de que el usuario este buscando desde el buscador de candidatos de candidatura
                    candidato.CVAvailable = tieneCv.IsValid;
                }
            }
            return response;
        }

        public GetCandidatosResponse GetCandidatosBecario(DataTableRequest request, bool contarBecas = true)
        {
            var response = new GetCandidatosResponse();

            try
            {
                var candidatosDescartados = GetCandidatosDescartados();
                var candidatosBecasAbiertas = GetCandidatosEnBecasAbiertas();
                var candidatosCandidaturasAbiertas = GetCandidatosEnCandidaturasAbiertas();
                var candidatosOmitir = candidatosCandidaturasAbiertas.Union(candidatosBecasAbiertas).Union(candidatosDescartados).Distinct().ToList();

                var query = FilterString(request.CustomFilters);

                //Es necesario convertir a lista para optimizar rendimiento en 10 segundos en prod.
                query = query.ToList().Where(x => !candidatosOmitir.Contains(x.CandidatoId)).AsQueryable();

                var filtered = query.ApplyColumnSettings(request, CandidatoMapper.GetPropertiePath);

                response.CandidatoRowViewModel = filtered.ConvertToCandidatoRowViewModel();
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

        public GetCandidatosExportToExcelResponse GetCandidatosExportToExcel(DataTableRequest request)
        {
            var response = new GetCandidatosExportToExcelResponse();

            try
            {
                //establecer los filtros
                var query = FilterString(request.CustomFilters);
                var filtered = query.ApplyColumnSettings(request, CandidatoMapper.GetPropertiePath);

                IDictionary<Candidato, GetDatosByCandidatoIdResponse> relacionCandidatoCandidatura = new Dictionary<Candidato, GetDatosByCandidatoIdResponse>();

                foreach (var candidato in filtered)
                {
                    relacionCandidatoCandidatura[candidato] = GetDatosByCandidatoId(candidato.CandidatoId);
                }

                response.CandidatoRowExportToExcelViewModel = relacionCandidatoCandidatura.ConvertToCandidatoRowExportToExcelViewModel();
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

        public GetCandidatoByIdResponse GetCandidatoById(int candidatoId)
        {
            var response = new GetCandidatoByIdResponse();

            try
            {
                var candidato = _candidatoRepository.GetOne(x => x.CandidatoId == candidatoId);

                var createEditCandidatoViewModel = candidato.ConvertToCreateEditCandidatoViewModel();

                response.CandidatoViewModel = createEditCandidatoViewModel;

                response.IsValid = true;
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                //  response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public GetCandidatosResponse GetCandidatosByCentroUsuarioId(int CentroUsuarioId)
        {
            var request = new DataTableRequest
            {
                CustomFilters = new Dictionary<string, string>()
            };
            request.CustomFilters.Add("CentroUsuarioId", CentroUsuarioId.ToString());

            return GetCandidatosCandidatura(request);

        }

        public GetCandidatosQueCumplenPerfilResponse GetCandidatosQueCumplenPerfil(DataTableRequest request)
        {
            var response = new GetCandidatosQueCumplenPerfilResponse();
            try
            {
                bool b = request.CustomFilters.Contains(new KeyValuePair<string, string>("Buscar", "true"));
                if (b)
                {
                    var tecnologiaId = Convert.ToInt32(request.CustomFilters["TipoTecnologiaId"]);
                    var perfilId = Convert.ToInt32(request.CustomFilters["TipoPerfilId"]);
                    var centroId = Convert.ToInt32(request.CustomFilters["Centro"]);
                    //establecer los filtros
                    var listaDeCandidaturasQueCumplenElPerfil =
                        _candidaturaRepository.GetByCriteria(x =>
                       (x.TipoTecnologiaId == tecnologiaId || x.TipoTecnologiaId == null) &&
                       (x.CategoriaId == perfilId || x.CategoriaId == null) &&
                       (x.EstadoCandidaturaId != (int)TipoEstadoCandidaturaEnum.Contratado &&
                       x.EstadoCandidaturaId != (int)TipoEstadoCandidaturaEnum.Descartado &&
                       x.EstadoCandidaturaId != (int)TipoEstadoCandidaturaEnum.KOOferta &&
                       x.EstadoCandidaturaId != (int)TipoEstadoCandidaturaEnum.RechazaOferta &&
                       x.EstadoCandidaturaId != (int)TipoEstadoCandidaturaEnum.Renuncia
                       && x.EstadoCandidaturaId != (int)TipoEstadoCandidaturaEnum.Recontactado) &&
                       x.IsActivo &&
                       x.Usuario.CentroId == centroId
                       ).AsQueryable();

                    var listaCandidatosQueCumplenElPerfil = new List<CandidatoQueCumplePerfilRowViewModel>();

                    if (request.CustomFilters.ContainsKey("Nombre") && request.CustomFilters["Nombre"] != string.Empty)
                    {
                        string nombre = request.CustomFilters["Nombre"];
                        listaDeCandidaturasQueCumplenElPerfil = from c in listaDeCandidaturasQueCumplenElPerfil
                                                                where c.Candidato.Nombre.Contains(nombre)
                                                                select c;
                    }

                    if (request.CustomFilters.ContainsKey("Apellidos") && request.CustomFilters["Apellidos"] != string.Empty)
                    {
                        string apellidos = request.CustomFilters["Apellidos"];
                        listaDeCandidaturasQueCumplenElPerfil = from c in listaDeCandidaturasQueCumplenElPerfil
                                                                where c.Candidato.Apellidos.Contains(apellidos)
                                                                select c;
                    }

                    foreach (var candidatura in listaDeCandidaturasQueCumplenElPerfil)
                    {
                        if (candidatura.Candidato.IsActivo)
                        {
                            var candidato = CandidatoMapper.ConvertToCandidatoQueCumplePerfilRowViewModel(candidatura.Candidato, candidatura.CandidaturaId);
                            int Id = candidatura.EtapaCandidaturaId;
                            if (Id != 0)
                            {
                                var etapaNombre = (TipoEtapaCandidaturaEnum)Id;
                                candidato.EtapaCandidatura = etapaNombre.ToString();
                            }
                            else
                            {
                                candidato.EtapaCandidatura = "";
                            }

                            listaCandidatosQueCumplenElPerfil.Add(candidato);
                        }
                    }

                    var filtered = listaCandidatosQueCumplenElPerfil.AsQueryable().ApplyColumnSettings(request, CandidatoMapper.GetPropertiePath);

                    response.CandidatosQueCumplenPerfilRowViewModel = filtered;
                    response.TotalElementos = listaCandidatosQueCumplenElPerfil.Count;
                }
                else
                {
                    response.CandidatosQueCumplenPerfilRowViewModel = new List<CandidatoQueCumplePerfilRowViewModel>();
                    response.TotalElementos = 0;
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

        public Candidaturas.Messages.DownloadCVResponse DownloadLastCV(int candidatoId)
        {
            CandidatoCandidaturaHelper relacionCandidaturaCandidato = new CandidatoCandidaturaHelper();

            return relacionCandidaturaCandidato.GetLastCVCandidaturaByCandidatoId(_candidaturaRepository, candidatoId);
        }

        public SaveCandidatoResponse SaveCandidato(CreateEditCandidatoViewModel candidatoViewModel)
        {
            var response = new SaveCandidatoResponse();

            try
            {
                if (candidatoViewModel.CandidatoId == null || candidatoViewModel.CandidatoId == 0)
                {
                    response = InsertNewCandidato(candidatoViewModel);
                }
                else
                {
                    response = UpdateCandidato(candidatoViewModel);
                }
            }
            catch (DbEntityValidationException ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }
            catch (DbUpdateException ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public SearchCandidatoUsadoResponse SearchCandidatoUsado(int candidatoId)
        {
            var response = new SearchCandidatoUsadoResponse();

            try
            {
                var candidaturaConCandidato = _candidaturaRepository.Find(x => x.IsActivo && x.CandidatoId == candidatoId);
                var becaConCandidato = _becarioRepository.Find(x => x.IsActivo && x.CandidatoId == candidatoId);
                if (candidaturaConCandidato == null && becaConCandidato == null)
                {
                    response.Usado = false;
                }
                else
                {
                    response.Usado = true;
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

        public DeleteCandidatoResponse DeleteCandidato(int candidatoId)
        {
            var response = new DeleteCandidatoResponse();

            try
            {
                var candidato = _candidatoRepository.GetOne(x => x.CandidatoId == candidatoId);

                candidato.UpdateCandidato(GetCandidatoById(candidatoId).CandidatoViewModel);

                //change active to delete
                candidato.IsActivo = false;

                if (_candidatoRepository.Update(candidato) > 0)
                {
                    response.IsValid = true;
                }
                else
                {
                    response.IsValid = false;
                    response.ErrorMessage = "Error to delete Candidato";
                }

            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public TieneCVEnBDResponse TieneCVEnBD(int candidatoId)
        {
            var response = new TieneCVEnBDResponse();
            try
            {
                var candidatura = _candidaturaRepository.GetOne((x => (x.CandidatoId == candidatoId) && (x.UrlCV != null)));
                if (candidatura == null)
                {
                    response.IsValid = false;
                }
                else
                {
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

        public GetCandidatoCandidaturasModalResponse GetCandidatoCandidaturasModal(DataTableRequest request)
        {
            var response = new GetCandidatoCandidaturasModalResponse();

            try
            {

                if (request.CustomFilters.ContainsKey("BuscarModalCandidatura"))
                {
                    var buscar = request.CustomFilters["BuscarModalCandidatura"];
                    if (!string.IsNullOrEmpty(buscar))
                    {
                        var query = FilterStringCandidaturasModal(request.CustomFilters);
                        var filtered = query.ApplyColumnSettings(request, CandidatoMapper.GetPropertiePathCandidaturas);
                        response.CandidaturaModalRowViewModel = filtered.ConvertToCandidaturaModalRowViewModel();
                        response.TotalElementos = query.Count();
                    }
                    else
                    {
                        response.CandidaturaModalRowViewModel = new List<CandidaturaModalRowViewModel>();
                        response.TotalElementos = 0;
                    }


                }
                else
                {
                    response.CandidaturaModalRowViewModel = new List<CandidaturaModalRowViewModel>();
                    response.TotalElementos = 0;
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

        public GetCandidatoBecariosModalResponse GetCandidatoBecariosModal(DataTableRequest request)
        {
            var response = new GetCandidatoBecariosModalResponse();

            try
            {

                if (request.CustomFilters.ContainsKey("BuscarModalBecario"))
                {
                    var buscar = request.CustomFilters["BuscarModalBecario"];
                    if (!string.IsNullOrEmpty(buscar))
                    {
                        var query = FilterStringBecariosModal(request.CustomFilters);
                        var filtered = query.ApplyColumnSettings(request, CandidatoMapper.GetPropertiePathBecarios);
                        response.BecarioModalRowViewModel = filtered.ConvertToBecarioModalRowViewModel();
                        response.TotalElementos = query.Count();
                    }
                    else
                    {
                        response.BecarioModalRowViewModel = new List<BecarioModalRowViewModel>();
                        response.TotalElementos = 0;
                    }


                }
                else
                {
                    response.BecarioModalRowViewModel = new List<BecarioModalRowViewModel>();
                    response.TotalElementos = 0;
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

        public SearchCandidatoByNumeroIdentificacionResponse SearchCandidatoByNumeroIdentificacion(string numeroIdentificacion, int? idCandidato)
        {

            var response = new SearchCandidatoByNumeroIdentificacionResponse();
            try
            {
                var candidato = _candidatoRepository.GetOne(x => x.NumeroIdentificacion.Equals(numeroIdentificacion));

                if (candidato == null || candidato.CandidatoId == idCandidato)
                {
                    response.IsValid = true;
                }
                else if (candidato.IsActivo)
                {
                    response.IsValid = false;
                    if (candidato.Usuario.Centro == null)
                    {
                        response.ErrorMessage = string.Format("Ya existe el usuario {0},{1} con identificador:{2} en uno de los centros.",
                                            candidato.Apellidos, candidato.Nombre, candidato.NumeroIdentificacion);
                    }
                    else
                    {
                        response.ErrorMessage = string.Format("Ya existe el usuario {0},{1} con identificador:{2} en el centro {3} ",
                                         candidato.Apellidos, candidato.Nombre, candidato.NumeroIdentificacion, candidato.Usuario.Centro.Nombre);
                    }
                }
                else if (!candidato.IsActivo)
                {
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

        public SearchCandidatoByContactoResponse SearchCandidatoByContactoResponse(string contacto, int? idCandidato) {

            var response = new SearchCandidatoByContactoResponse();
            try
            {
                var contactoRes = _candidatoContactoRepository.GetOne(x => x.Contacto.Equals(contacto));
                var candidato = contactoRes != null ? _candidatoRepository.GetOne(x => x.CandidatoId.Equals(contactoRes.CandidatoId)) : null;

                if (candidato == null || candidato.CandidatoId == idCandidato)
                {
                    response.IsValid = true;
                }
                else if (candidato.IsActivo)
                {
                 
                    response.IsValid = false;
                    if (candidato.Usuario.Centro == null)
                    {
                        
                        response.ErrorMessage = string.Format("Ya existe el usuario {0},{1} con el dato de contacto:{2} en uno de los centros.",
                                        candidato.Apellidos, candidato.Nombre, contactoRes.Contacto); 
                    }
                    else
                    {
                        response.ErrorMessage = string.Format("Ya existe el usuario {0},{1} con el dato de contacto:{2} en el centro {3} ",
                                         candidato.Apellidos, candidato.Nombre, contactoRes.Contacto, candidato.Usuario.Centro.Nombre);
                    }
                }
                else if (!candidato.IsActivo)
                {
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


        public SearchCandidatoByNombreYApellidosResponse SearchCandidatoByNombreYApellidos(string Nombres, string apellidos, int? idCandidato)
        {
            var response = new SearchCandidatoByNombreYApellidosResponse();
            try
            {
                var candidato = _candidatoRepository.GetOne(x => x.Nombre.Equals(Nombres) && x.Apellidos.Equals(apellidos));

                if (candidato == null || candidato.CandidatoId == idCandidato)
                {
                    response.IsValid = true;
                }
                else if (candidato.IsActivo)
                {
                    response.IsValid = false;
                    if (candidato.Usuario.Centro == null)
                    {
                        response.ErrorMessage = string.Format("Ya existe el usuario {0},{1} con identificador:{2} en uno de los centros.",
                                         apellidos, Nombres, candidato.NumeroIdentificacion);
                    }
                    else
                    {
                        response.ErrorMessage = string.Format("Ya existe el usuario {0},{1} con identificador:{2} en el centro {3} ",
                                          apellidos, Nombres, candidato.NumeroIdentificacion, candidato.Usuario.Centro.Nombre);
                    }
                }
                else if (!candidato.IsActivo)
                {
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

        public GetEmailCandidatoResponse GetEmailCandidato(int CandidatoId, int tipoMedioContactoEmail)
        {
            var response = new GetEmailCandidatoResponse();
            try
            {


                var email = _candidatoContactoRepository.GetOne(x => x.CandidatoId == CandidatoId && x.IsActivo && x.TipoMedioContactoId == tipoMedioContactoEmail).Contacto;
                if (email != null)
                {

                    response.IsValid = true;
                    response.EmailCandidato = email;

                }
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public CheckCandidatoEnRecruitingResponse CheckCandidatoEnRecruiting(string Nombre, string Email, string Telefono, string NIF)
        {
            var response = new CheckCandidatoEnRecruitingResponse();

            try
            {

                if (!string.IsNullOrEmpty(Email))
                {
                    var query = _candidatoRepository.Find(x => x.IsActivo && x.CandidatoContactos.Any(y => y.IsActivo && y.Contacto.Equals(Email, StringComparison.InvariantCultureIgnoreCase)));
                    if (query != null)
                    {
                        response.ExistenteEnRecruiting = true;
                        response.IsValid = true;
                        response.CandidatoId = query.CandidatoId;
                        return response;
                    }
                }

                if (!string.IsNullOrEmpty(Telefono))
                {
                    var query = _candidatoRepository.Find(x => x.IsActivo && x.CandidatoContactos.Any(y => y.IsActivo && y.Contacto.Equals(Telefono, StringComparison.InvariantCultureIgnoreCase)));
                    if (query != null)
                    {
                        response.ExistenteEnRecruiting = true;
                        response.IsValid = true;
                        response.CandidatoId = query.CandidatoId;
                        return response;
                    }
                }

                if (!string.IsNullOrEmpty(Nombre))
                {
                    var query = _candidatoRepository.Find(x => x.IsActivo && (x.Nombre + " " + x.Apellidos).Equals(Nombre, StringComparison.InvariantCultureIgnoreCase));

                    if (query != null)
                    {
                        response.ExistenteEnRecruiting = true;
                        response.IsValid = true;
                        response.CandidatoId = query.CandidatoId;
                        return response;
                    }                 
                  
                }

                if (!string.IsNullOrEmpty(NIF))
                {
                    var query = _candidatoRepository.Find(x => x.IsActivo && x.NumeroIdentificacion.Equals(NIF, StringComparison.InvariantCultureIgnoreCase));
                    if (query != null)
                    {
                        response.ExistenteEnRecruiting = true;
                        response.IsValid = true;
                        response.CandidatoId = query.CandidatoId;
                        return response;
                    }
                }

                response.IsValid = true;
                response.ExistenteEnRecruiting = false;

                return response;
            }
            catch (Exception ex)
            {

                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }


            return response;
        }

        public UpdateCandidatoOtherInfoResponse UpdateCandidatoOtherInfo(CandidatoOtherInfoViewModel candidato)
        {
            var response = new UpdateCandidatoOtherInfoResponse();

            try
            {
                var candidatoModificar = _candidatoRepository.GetOne(x => x.CandidatoId == candidato.CandidatoId && x.IsActivo);

                candidatoModificar.Nombre = candidato.Nombre;
                candidatoModificar.Apellidos = candidato.Apellidos;
                candidatoModificar.NumeroIdentificacion = candidato.NIF;
                candidatoModificar.TitulacionId = candidato.TitulacionId;

                _candidatoRepository.Update(candidatoModificar);

                var responseUpdateCandidatoEmail = UpdateCandidatoContacto(candidatoModificar.CandidatoId, candidato.Email, (int)TipoContactoEnum.Email);
                if (responseUpdateCandidatoEmail.IsValid)
                {
                    var responseUpdateCandidatoTelefono = UpdateCandidatoContacto(candidatoModificar.CandidatoId, candidato.Telefono, (int)TipoContactoEnum.Telefono);
                    if (responseUpdateCandidatoTelefono.IsValid)
                    {
                        response.IsValid = true;
                        response.CandidatoId = candidatoModificar.CandidatoId;
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

        public CreateCandidatoOtherInfoResponse CreateCandidatoOtherInfo(CandidatoOtherInfoViewModel candidato)
        {
            var response = new CreateCandidatoOtherInfoResponse();

            try
            {
                var candidatoCrear = new Candidato()
                {
                    Nombre = candidato.Nombre,
                    Apellidos = candidato.Apellidos,
                    NumeroIdentificacion = candidato.NIF,
                    TitulacionId = candidato.TitulacionId,
                    IsActivo = true,
                    EstadoCandidatoId = 20,
                    DisponibilidadViaje = false,
                    CambioResidencia = false,
                    Created = DateTime.Now,
                    CreatedBy = candidato.UsuarioCreacionOtherInfo
                };

                _candidatoRepository.Create(candidatoCrear);

                var responseUpdateCandidatoEmail = UpdateCandidatoContacto(candidatoCrear.CandidatoId, candidato.Email, (int)TipoContactoEnum.Email);
                if (responseUpdateCandidatoEmail.IsValid)
                {
                    var responseUpdateCandidatoTelefono = UpdateCandidatoContacto(candidatoCrear.CandidatoId, candidato.Telefono, (int)TipoContactoEnum.Telefono);
                    if (responseUpdateCandidatoTelefono.IsValid)
                    {
                        response.IsValid = true;
                        response.CandidatoId = candidatoCrear.CandidatoId;
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

        #region Private Methods

        private SaveCandidatoResponse InsertNewCandidato(CreateEditCandidatoViewModel createEditCandidatoViewModel)
        {
            var response = new SaveCandidatoResponse();

            var candidato = new Candidato();

            candidato.UpdateCandidato(createEditCandidatoViewModel);

            var newCandidato = _candidatoRepository.Create(candidato);

            if (newCandidato != null)
            {
                response.IsValid = true;
                response.CandidatoId = newCandidato.CandidatoId;
            }
            else
            {
                response.IsValid = false;
                response.ErrorMessage = "Error to save Candidato";
            }

            return response;

        }

        private SaveCandidatoResponse UpdateCandidato(CreateEditCandidatoViewModel createEditCandidatoViewModel)
        {
            var response = new SaveCandidatoResponse();

            var candidato = _candidatoRepository.GetOne(x => x.CandidatoId == createEditCandidatoViewModel.CandidatoId);

            var candidatoIdiomaToRemove = GetCandidatoIdiomasToRemove(candidato, createEditCandidatoViewModel);
            var candidatoExperienciaToRemove = GetCandidatoExperienciasToRemove(candidato, createEditCandidatoViewModel);
            var candidatoContactoToRemove = GetCandidatoContactosToRemove(candidato, createEditCandidatoViewModel);
            candidato.UpdateCandidato(createEditCandidatoViewModel);

            var numCandidatosActualizados = _candidatoRepository.Update(candidato);

            foreach (var idioma in candidatoIdiomaToRemove)
            {
                _candidatoIdiomaRepository.Delete(x => x.CandidatoIdiomasId == idioma);
            }

            foreach (var experiencia in candidatoExperienciaToRemove)
            {
                _candidatoExperienciaRepository.Delete(x => x.CandidatoExperienciaId == experiencia);
            }

            foreach (var contacto in candidatoContactoToRemove)
            {
                _candidatoContactoRepository.Delete(x => x.CandidatoContactoId == contacto);
            }

            if (numCandidatosActualizados > 0)
            {
                response.IsValid = true;
                response.CandidatoId = (int)createEditCandidatoViewModel.CandidatoId;
            }
            else
            {
                response.IsValid = false;
                response.ErrorMessage = "Error to update Candidato";
            }

            return response;

        }

        private List<int> GetCandidatoIdiomasToRemove(Candidato candidato, CreateEditCandidatoViewModel createEditCandidatoViewModel)
        {
            var listCandidatoIdiomaToRemove = new List<int>();

            //obtener los idiomas a eliminar
            if (candidato.CandidatoIdiomas != null)
            {
                foreach (var idioma in candidato.CandidatoIdiomas.ToList())
                {
                    if (!createEditCandidatoViewModel.IdiomaCandidatoViewModel.Any(x => x.CandidatoIdiomasId == idioma.CandidatoIdiomasId))
                    {
                        listCandidatoIdiomaToRemove.Add(idioma.CandidatoIdiomasId);
                    }
                }
            }

            return listCandidatoIdiomaToRemove;
        }

        private List<int> GetCandidatoExperienciasToRemove(Candidato candidato, CreateEditCandidatoViewModel createEditCandidatoViewModel)
        {
            var listCandidatoExperienciaToRemove = new List<int>();

            if (candidato.CandidatoExperiencias != null)
            {
                foreach (var experiencia in candidato.CandidatoExperiencias.ToList())
                {
                    if (!createEditCandidatoViewModel.ExpCandidatoViewModel.Any(x => x.CandidatoExperienciaId == experiencia.CandidatoExperienciaId))
                    {
                        listCandidatoExperienciaToRemove.Add(experiencia.CandidatoExperienciaId);
                    }
                }
            }

            return listCandidatoExperienciaToRemove;
        }

        private List<int> GetCandidatoContactosToRemove(Candidato candidato, CreateEditCandidatoViewModel createEditCandidatoViewModel)
        {
            var listCandidatoContactoToRemove = new List<int>();

            if (candidato.CandidatoContactos != null)
            {
                foreach (var contacto in candidato.CandidatoContactos.ToList())
                {
                    if (!createEditCandidatoViewModel.ContactCandidatoViewModel.Any(x => x.CandidatoContactoId == contacto.CandidatoContactoId))
                    {
                        listCandidatoContactoToRemove.Add(contacto.CandidatoContactoId);
                    }
                }
            }

            return listCandidatoContactoToRemove;
        }

        private GetDatosByCandidatoIdResponse GetDatosByCandidatoId(int candidatoId)
        {
            var response = new GetDatosByCandidatoIdResponse();
            var candidato = _candidatoRepository.GetOne(x => x.CandidatoId == candidatoId);
            response.NivelIngles = "N/A";

            try
            {
                if (candidato.CandidatoIdiomas.Count > 0)
                {
                    foreach (CandidatoIdioma i in candidato.CandidatoIdiomas)
                    {
                        if (i.IdiomaId == 15)
                        {
                            response.NivelIngles = i.NivelIdioma.Nombre;
                        }
                    }
                }

                response.NumCandidaturas = _candidaturaRepository.CountByCriteria(x => x.CandidatoId == candidatoId && x.IsActivo);
                response.IsValid = true;
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        private IQueryable<Candidato> FilterString(IDictionary<string, string> customFilter)
        {
            var query = _candidatoRepository.GetAll();

            // Solo devolvemos candidatos activos.
            query = query.Where(x => x.IsActivo);

            if (customFilter.ContainsKey("Descartado"))
            {

                query = query.Where(x => !x.Candidaturas.Any(y => y.DescartarFuturasCandidaturas));
            }

            if (customFilter.ContainsKey("Nombre") && customFilter["Nombre"] != string.Empty)
            {
                var nombre = customFilter["Nombre"];
                query = query.Where(x => x.Nombre.Contains(nombre));
            }

            if (customFilter.ContainsKey("Apellidos") && customFilter["Apellidos"] != string.Empty)
            {
                var apellidos = customFilter["Apellidos"];
                query = query.Where(x => x.Apellidos.Contains(apellidos));
            }

            if (customFilter.ContainsKey("TipoTitulacion") && customFilter["TipoTitulacion"] != string.Empty)
            {
                var titulacionId = Convert.ToInt32(customFilter["TipoTitulacion"]);
                query = query.Where(x => x.TitulacionId == titulacionId);
            }

            if (customFilter.ContainsKey("TipoIdentificacion") && customFilter["TipoIdentificacion"] != string.Empty)
            {
                var tipoIdentificacionId = Convert.ToInt32(customFilter["TipoIdentificacion"]);
                query = query.Where(x => x.TipoIdentificacionId == tipoIdentificacionId);
            }

            if (customFilter.ContainsKey("NumeroIdentificacion") && customFilter["NumeroIdentificacion"] != string.Empty)
            {
                var numIdentificacion = customFilter["NumeroIdentificacion"];
                query = query.Where(x => string.Compare(x.NumeroIdentificacion, numIdentificacion, true) == 0);
            }


            //se filtra por el centro del usuario logado salvo cuando hay un Centro de busqueda que buscaria los del centro en cuestion (CentroSearch)
            if (customFilter.ContainsKey("CentroUsuarioId") && (customFilter["CentroUsuarioId"] != string.Empty || customFilter.ContainsKey("CentroSearch")))
            {
                if (customFilter.ContainsKey("CentroSearch"))
                {
                    if (customFilter["CentroSearch"] != string.Empty)
                    {
                        var CentroUsuarioId = Convert.ToInt32(customFilter["CentroSearch"]);
                        query = query.Where(x => x.Usuario.CentroId == CentroUsuarioId);
                    }
                    else
                    {
                        if (customFilter["CentroUsuarioId"] != string.Empty)
                        {
                            var CentroUsuarioId = Convert.ToInt32(customFilter["CentroUsuarioId"]);
                            query = query.Where(x => x.Usuario.CentroId == CentroUsuarioId);
                        }
                    }
                }
                else
                {
                    var CentroUsuarioId = Convert.ToInt32(customFilter["CentroUsuarioId"]);
                    query = query.Where(x => x.Usuario.CentroId == CentroUsuarioId);
                }
            }

            if (customFilter.ContainsKey("CentroSearch") && !customFilter.ContainsKey("CentroUsuarioId") && customFilter["CentroSearch"] != string.Empty)
            {
                var CentroUsuarioId = Convert.ToInt32(customFilter["CentroSearch"]);
                query = query.Where(x => x.Usuario.Centro.CentroId == CentroUsuarioId);
            }

            if (customFilter.ContainsKey("TipoTecnologia") && customFilter["TipoTecnologia"] != string.Empty)
            {
                var tipoTecnologiaId = Convert.ToInt32(customFilter["TipoTecnologia"]);
                query = query.Where(x => x.CandidatoExperiencias.Any(y => y.TipoTecnologiaId == tipoTecnologiaId));
            }

            if (customFilter.ContainsKey("Email") && customFilter["Email"] != string.Empty)
            {
                var email = customFilter["Email"].RemoveDiacritics();
                query = query.Where(x => x.CandidatoContactos.Any(y => y.IsActivo && y.Contacto.Contains(email) && y.TipoMedioContactoId == (int)TipoContactoEnum.Email));
            }

            if (customFilter.ContainsKey("Telefono") && customFilter["Telefono"] != string.Empty)
            {
                var telefono = customFilter["Telefono"].RemoveDiacritics().Replace(" ", "");
                query = query.Where(x => x.CandidatoContactos.Any(y => y.IsActivo && y.Contacto.Replace(" ", "").Contains(telefono) && y.TipoMedioContactoId == (int)TipoContactoEnum.Telefono));
            }

            if (customFilter.ContainsKey("CentroEducativoId") && customFilter["CentroEducativoId"] != string.Empty)
            {
                var centroEducativoId = Convert.ToInt32(customFilter["CentroEducativoId"]);
                query = query.Where(x => x.CandidatoCentroEducativoId == centroEducativoId);
            }

            if (customFilter.ContainsKey("AnioRegresado") && !string.IsNullOrEmpty(customFilter["AnioRegresado"]))
            {
                var anioRegresado = customFilter["AnioRegresado"];
                query = query.Where(x => x.AnioRegresado.Contains(anioRegresado));
            }

            if (customFilter.ContainsKey("NivelIdioma") && customFilter["NivelIdioma"] != string.Empty)
            {
                var nivelIdiomaId = Convert.ToInt32(customFilter["NivelIdioma"]);
                query = query.Where(x => x.CandidatoIdiomas.Any(y => y.NivelIdiomaId >= nivelIdiomaId && y.IdiomaId == 15));
            }

            return query;
        }

        private IQueryable<Candidatura> FilterStringCandidaturasModal(IDictionary<string, string> customFilter)
        {
            var query = _candidaturaRepository.GetAll();

            // Solo devolvemos candidaturas activas.
            query = query.Where(x => x.IsActivo);

            if (customFilter.ContainsKey("CandidatoId"))
            {
                var candidatoId = Convert.ToInt32(customFilter["CandidatoId"]);
                query = query.Where(x => x.CandidatoId == candidatoId);
            }

            return query;
        }

        private IQueryable<Becario> FilterStringBecariosModal(IDictionary<string, string> customFilter)
        {
            var query = _becarioRepository.GetAll();

            // Solo devolvemos candidaturas activas.
            query = query.Where(x => x.IsActivo);

            if (customFilter.ContainsKey("CandidatoId"))
            {
                var candidatoId = Convert.ToInt32(customFilter["CandidatoId"]);
                query = query.Where(x => x.CandidatoId == candidatoId);
            }

            return query;
        }


        private List<int> GetCandidatosDescartados()
        {
            var candidaturas = _candidaturaRepository.GetByCriteria(x =>
                (x.DescartarFuturasCandidaturas)
            );

            var candidatosIds = candidaturas.Select(x => x.CandidatoId).Distinct().ToList();

            return candidatosIds;
        }

        private List<int> GetCandidatosEnCandidaturasAbiertas()
        {
            var candidaturasCerradasIds = new int[]
            {
                (int)TipoEstadoCandidaturaEnum.Descartado,
                (int)TipoEstadoCandidaturaEnum.Contratado,
                (int)TipoEstadoCandidaturaEnum.Renuncia,
                (int)TipoEstadoCandidaturaEnum.RechazaOferta,
                (int)TipoEstadoCandidaturaEnum.Recontactado
            };

            var candidaturas = _candidaturaRepository.GetByCriteria(x =>
                !candidaturasCerradasIds.Contains(x.EstadoCandidaturaId) && x.IsActivo);

            var candidatosIds = candidaturas.Select(x => x.CandidatoId).Distinct().ToList();

            return candidatosIds;
        }

        private List<int> GetCandidatosEnBecasAbiertas()
        {
            var becasCerradasIds = new int[]
            {
                (int)TipoEstadoBecarioEnum.Descartado,
                (int)TipoEstadoBecarioEnum.Finalizado,
                (int)TipoEstadoBecarioEnum.Renuncia
            };

            var becas = _becarioRepository.GetByCriteria(x =>
                !becasCerradasIds.Contains(x.TipoEstadoBecarioId) && x.IsActivo);

            var candidatosIds = becas.Select(x => x.CandidatoId).Distinct().ToList();

            return candidatosIds;
        }

        private UpdateCandidatoContactoResponse UpdateCandidatoContacto(int candidatoId, string contacto, int tipoContacto)
        {
            var response = new UpdateCandidatoContactoResponse();

            try
            {
                if(!string.IsNullOrEmpty(contacto))
                {
                    var candidatoContacto = _candidatoContactoRepository.GetOne(x => x.IsActivo && x.TipoMedioContactoId == tipoContacto && x.CandidatoId == candidatoId);
                    if(candidatoContacto == null)
                    {
                        CandidatoContacto candidatoContactoCrear = new CandidatoContacto()
                        {
                            CandidatoId = candidatoId,
                            Contacto = contacto,
                            TipoMedioContactoId = tipoContacto,
                            IsActivo = true
                        };

                        _candidatoContactoRepository.Create(candidatoContactoCrear);
                    }
                    else
                    {
                        candidatoContacto.Contacto = contacto;
                        _candidatoContactoRepository.Update(candidatoContacto);
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



        #endregion
    }
}
