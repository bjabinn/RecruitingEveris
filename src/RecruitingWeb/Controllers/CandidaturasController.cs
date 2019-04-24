using System;
using System.IO;
using System.Web;
using System.Text;
using System.Linq;
using System.Web.UI;
using System.Web.Mvc;
using System.Web.Routing;
using System.Configuration;
using System.Threading.Tasks;
using Recruiting.Application.CandidaturasOfertas.Messages;
using Recruiting.Application.CandidaturasOfertas.Services;
using System.Collections.Generic;

using RecruitingWeb.Enums;
using RecruitingWeb.Models;
using RecruitingWeb.Helpers;
using RecruitingWeb.Security;
using RecruitingWeb.Constantes;
using RecruitingWeb.Properties;
using RecruitingWeb.Components.DataTable.ServerSide;

using Recruiting.Application.Helpers;
using Recruiting.Application.Graph.Messages;
using Recruiting.Application.Graph.Services;
using Recruiting.Application.Maestros.Enums;
using Recruiting.Application.Graph.ViewModels;
using Recruiting.Application.Candidatos.Enums;
using Recruiting.Application.Centros.Services;
using Recruiting.Application.Ofertas.Services;
using Recruiting.Application.Roles.ViewModels;
using Recruiting.Application.Clientes.Services;
using Recruiting.Application.Becarios.Services;
using Recruiting.Application.Maestros.Services;
using Recruiting.Application.Usuarios.Messages;
using Recruiting.Application.Usuarios.Services;
using Recruiting.Application.Bitacoras.Services;
using Recruiting.Application.Candidaturas.Enums;
using Recruiting.Application.Ofertas.ViewModels;
using Recruiting.Application.Proyectos.Services;
using Recruiting.Application.Clientes.ViewModels;
using Recruiting.Application.Candidatos.Services;
using Recruiting.Application.Usuarios.ViewModels;
using Recruiting.Application.Bitacoras.ViewModels;
using Recruiting.Application.Necesidades.Messages;
using Recruiting.Application.Necesidades.Services;
using Recruiting.Application.Proyectos.ViewModels;
using Recruiting.Application.Candidatos.ViewModels;
using Recruiting.Application.Candidaturas.Messages;
using Recruiting.Application.Candidaturas.Services;
using Recruiting.Application.Candidaturas.ViewModel;
using Recruiting.Application.Necesidades.ViewModels;

using Recruiting.Business.Entities;
using Recruiting.Business.Repositories;
using Recruiting.Business.BaseClasses.DataTable;

using Recruiting.Infra.Caching;
using Recruiting.Data.EntityFramework.Repositories;

using Recruiting.SendMailsService;
using Recruiting.SendMailsService.Enums;
using Recruiting.SendMailsService.Correos.Mappers;
using Recruiting.SendMailsService.Correos.Services;
using Recruiting.SendMailsService.Correos.Messages;
using Recruiting.Application.Oficinas.Services;

namespace RecruitingWeb.Controllers
{
    public class CandidaturasController : Controller
    {
        #region Constants
        private const int MIN_PTUNTOS_EXP = 1;
        private const int MAX_PTUNTOS_EXP = 10;
        private const string SeparatorBar = "\\";       

        #endregion

        #region Fields

        private readonly IEntrevistaRepository _entrevistaRepository;
        private readonly ICartaOfertaRepository _cartaOfertaRepository;
        private readonly ICandidatoIdiomaRepository _candidatoIdiomaRepository;
        private readonly ICandidatoExperienciaRepository _candidatoExperienciaRepository;
        private readonly ICandidatoContactoRepository _candidatoContactoRepository;
        private readonly IRelacionEtapaRepository _relacionEtapaRepository;
        private readonly IRelacionVistaEtapaRepository _relacionVistaEtapaRepository;


        private readonly ICandidatoService _candidatoService;
        private readonly ICandidatoRepository _candidatoRepository;

        private readonly ICandidaturaService _candidaturaService;
        private readonly ICandidaturaRepository _candidaturaRepository;

        private readonly IBecarioService _becarioService;
        private readonly IBecarioRepository _becarioRepository;
        private readonly IBecarioObservacionRepository _becarioObservacionRepository;
        private readonly IBitacoraBecarioRepository _bitacoraBecarioRepository;

        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUsuarioService _usuarioService;

        private readonly IMaestroRepository _maestroRepository;
        private readonly IMaestroService _maestroService;
        private readonly ICentroRepository _centroRepository;
        private readonly ICentroService _centroService;

        private readonly ICandidaturaEstadoRepository _candidaturaEstadoRepository;
        private readonly ICandidaturaEstadoService _candidaturaEstadoService;

        private readonly ICandidaturaEtapaRepository _candidaturaEtapaRepository;
        private readonly ICandidaturaEtapaService _candidaturaEtapaService;

        private readonly IOfertaRepository _ofertaRepository;
        private readonly IOfertaService _ofertaService;

        private readonly INecesidadRepository _necesidadRepository;
        private readonly INecesidadService _necesidadService;
        private readonly IClienteService _clienteService;
        private readonly IProyectoRepository _proyectoRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IProyectoService _proyectoService;
        private readonly SessionCacheStorageService _sesionCandidatura;



        private readonly SessionCacheStorageService _sesionViewBag_EtapaList;
        private readonly IBitacoraRepository _bitacoraRepository;
        private readonly IBitacoraService _bitacoraService;
        private readonly ITipoDecisionRepository _tipoDecisionRepository;
        private readonly ITipoEtapaCandidaturaRepository _tipoEtapaCandidaturaRepository;
        private readonly ITipoEstadoCandidaturaRepository _tipoEstadoCandidaturaRepository;

        private readonly IMonedasDeCentroRepository _monedasDeCentroRepository;
        private readonly ICandidaturaMonedaService _candidaturaMonedaService;

        private readonly ISubEntrevistaRepository _subentrevistaRepository;

        private readonly IGrupoNecesidadRepository _grupoNecesidadRepository;
        private readonly IGrupoNecesidadService _grupoNecesidadService;


        private readonly IGraphService _graphService;
        private readonly IEventosService _eventosService;

        private readonly ICorreoPlantillaRepository _correoPlantillaRepository;
        private readonly ICorreoPlantillaService _correoPlantillaService;

        private readonly ICorreoPlantillaVariableRepository _correoPlantillaVariableRepository;
        private readonly ICorreoPlantillaVariableService _correoPlantillaVariableService;

        private readonly ICandidaturaOfertaRepository _candidaturaOfertaRepository;
        private readonly ICandidaturaOfertaService _candidaturaOfertaService;


        private readonly IOficinaRepository _oficinaRepository;
        private readonly IOficinaService _oficinaService;
       


        #endregion

        #region Construct

        public CandidaturasController()
        {
            _subentrevistaRepository = new SubEntrevistaRepository();

            _clienteRepository = new ClienteRepository();
            _clienteService = new ClienteService(_clienteRepository);

            _entrevistaRepository = new EntrevistaRepository();
            _cartaOfertaRepository = new CartaOfertaRepository();
            _candidatoIdiomaRepository = new CandidatoIdiomaRepository();
            _candidatoExperienciaRepository = new CandidatoExperienciaRepository();
            _candidatoContactoRepository = new CandidatoContactoRepository();
            _relacionEtapaRepository = new RelacionEtapaRepository();
            _relacionVistaEtapaRepository = new RelacionVistaEtapaRepository();
            _bitacoraRepository = new BitacoraRepository();
            _bitacoraService = new BitacoraService(_bitacoraRepository, _candidaturaRepository, _tipoDecisionRepository, _tipoEtapaCandidaturaRepository, _tipoEstadoCandidaturaRepository, _maestroRepository);
            _tipoDecisionRepository = new TipoDecisionRepository();
            _tipoEtapaCandidaturaRepository = new TipoEtapaCandidaturaRepository();
            _tipoEstadoCandidaturaRepository = new TipoEstadoCandidaturaRepository();
            _necesidadRepository = new NecesidadRepository();
            _becarioRepository = new BecarioRepository();
            _becarioObservacionRepository = new BecarioObservacionRepository();
            _bitacoraBecarioRepository = new BitacoraBecarioRepository();
            _becarioService = new BecarioService(_becarioRepository, _becarioObservacionRepository, _bitacoraBecarioRepository);


            _sesionCandidatura = new SessionCacheStorageService();

            _necesidadService = new NecesidadService(_necesidadRepository);

            _maestroRepository = new MaestroRepository();
            _maestroService = new MaestroService(_maestroRepository);

            _usuarioRepository = new UsuarioRepository();
            _usuarioService = new UsuarioService(_usuarioRepository);

            _candidaturaRepository = new CandidaturaRepository();
            _candidaturaService = new CandidaturaService(_candidaturaRepository, _entrevistaRepository,
                _cartaOfertaRepository, _relacionEtapaRepository, _relacionVistaEtapaRepository, _bitacoraRepository, _tipoDecisionRepository,
                _tipoEtapaCandidaturaRepository, _tipoEstadoCandidaturaRepository, _necesidadRepository, _usuarioRepository, _subentrevistaRepository);

            _candidatoRepository = new CandidatoRepository();
            _candidatoService = new CandidatoService(_candidatoRepository, _candidatoIdiomaRepository,
                _candidatoExperienciaRepository, _candidatoContactoRepository, _candidaturaRepository, _becarioRepository);

            _candidaturaEtapaRepository = new CandidaturaEtapaRepository();
            _candidaturaEtapaService = new CandidaturaEtapaService(_candidaturaEtapaRepository, _tipoEtapaCandidaturaRepository);

            _candidaturaEstadoRepository = new CandidaturaEstadoRepository();
            _candidaturaEstadoService = new CandidaturaEstadoService(_candidaturaEstadoRepository);

            _ofertaRepository = new OfertaRepository();
            _ofertaService = new OfertaService(_ofertaRepository, _candidaturaRepository);

            _proyectoRepository = new ProyectoRepository();
            _proyectoService = new ProyectoService(_proyectoRepository, _clienteRepository);

            _sesionViewBag_EtapaList = new SessionCacheStorageService();

            _monedasDeCentroRepository = new MonedasDeCentroRepository();
            _candidaturaMonedaService = new CandidaturaMonedaService(_monedasDeCentroRepository);

            _grupoNecesidadRepository = new GrupoNecesidadRepository();
            _grupoNecesidadService = new GrupoNecesidadService(_grupoNecesidadRepository, _necesidadRepository);

            _graphService = new GraphService();
            _eventosService = new EventosService();

            _centroRepository = new CentroRepository();
            _centroService = new CentroService(_centroRepository);

            _correoPlantillaRepository = new CorreoPlantillaRepository();
            _correoPlantillaService = new CorreoPlantillaService(_correoPlantillaRepository);

            _correoPlantillaVariableRepository = new CorreoPlantillaVariableRepository();
            _correoPlantillaVariableService = new CorreoPlantillaVariableService(_correoPlantillaVariableRepository);

            _candidaturaOfertaRepository = new CandidaturaOfertaRepository();
            _candidaturaOfertaService = new CandidaturaOfertaService(_candidaturaOfertaRepository);

            _oficinaRepository = new OficinaRepository();
            _oficinaService = new OficinaService(_oficinaRepository);

        }

        #endregion

        #region Actions

        #region Index Members
        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.VerCandidatura)]
        public ActionResult Index(string errorMessage = null)
        {
            var filtro = _sesionCandidatura.Get<FiltroCandidaturaModels>("filtro_candidatura");
            if (!string.IsNullOrWhiteSpace(errorMessage))
            {
                CreateMessageError(errorMessage);
            }

            if (filtro == null)
            {
                //orden por defecto
                filtro = new FiltroCandidaturaModels()
                {
                    SortColumn = "CandidaturaId",
                    SortOrder = Recruiting.Business.BaseClasses.DataTable.DataTableSortDirectionEnum.Descending
                };
            }
            _sesionCandidatura.Add("filtro_inicial_candidatura", filtro);

            filtro.Pagina = _sesionCandidatura.Get<int>("pagina_actual") > 0 ? _sesionCandidatura.Get<int>("pagina_actual") : 0;
            filtro = GenerateViewElementsIndex(filtro);
            return View(filtro);
        }

        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.VerCandidatura)]
        public ActionResult IndexByCandidato(int id)
        {
            var modeloCandi = _candidatoService.GetCandidatoById(id).CandidatoViewModel;
            var nombre = modeloCandi.Nombres;
            var apellidos = modeloCandi.Apellidos;
            var filtro = new FiltroCandidaturaModels();

            filtro.NombreCandidato = nombre + " " + apellidos;


            var pagina = _sesionCandidatura.Get<int>("pagina_actual");
            if (pagina > 0)
            {
                filtro.Pagina = 0;
                _sesionCandidatura.Add("pagina_actual", 0);
            }
            _sesionCandidatura.Add("filtro_candidatura", filtro);
            return RedirectToAction("Index");
        }

        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.VerCandidatura)]
        public ActionResult IndexByOfertas(int id)
        {
            var modelo = _ofertaService.GetOfertaById(id).OfertaViewModel;
            var nombre = modelo.Nombre;
            var filtro = new FiltroCandidaturaModels();

            filtro.Oferta = nombre;

            filtro.OfertaId = modelo.OfertaId;

            var pagina = _sesionCandidatura.Get<int>("pagina_actual");
            if (pagina > 0)
            {
                filtro.Pagina = 0;
                _sesionCandidatura.Add("pagina_actual", 0);
            }

            _sesionCandidatura.Add("filtro_candidatura", filtro);

            return RedirectToAction("Index");
        }
        #endregion

        #region Create Candidatura Members

        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.AniadirEliminarCandidatura)]
        public ActionResult Create(int? id = null)
        {
            var model = new CandidaturaDatosBasicosViewModel();
            model.DatosBasicos = new CandidaturaDatosBasicos();

            if (id.HasValue)
            {
                model = _candidaturaService.GetCandidaturaById((int)id).CandidaturaViewModel.CandidaturaDatosBasicosViewModel;
            }


            model.DatosBasicos = GenerateViewElementsDatosBasicos(model.DatosBasicos);
          
            model.DatosBasicos.Access = "DatosBasicos.";

            var moneda = GetCurrency();
            model.DatosBasicos.Moneda = moneda;
            
            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreateByCandidato(int id) { 
            var model = new CandidaturaDatosBasicosViewModel();
            var result = new JsonResult();
            var candidatoIdiomas = _candidatoService.GetCandidatoById(id).CandidatoViewModel.IdiomaCandidatoViewModel;
            var candidatoTecnologias = _candidatoService.GetCandidatoById(id).CandidatoViewModel.ExpCandidatoViewModel;

            model.DatosBasicos = new CandidaturaDatosBasicos();
            model.DatosBasicos.IdiomaCandidatoViewModel = new List<CreateEditRowIdiomaCandidaturaViewModel>();
            model.DatosBasicos.ExpCandidatoViewModel = new List<Recruiting.Application.Candidaturas.ViewModels.CreateEditRowExperienciaCandidatoViewModel>();

            if (candidatoIdiomas != null)
            {
                for (int i = 0; i < candidatoIdiomas.Count; i++)
                {
                    var idioma = new CreateEditRowIdiomaCandidaturaViewModel();
                    idioma.IdiomaId = candidatoIdiomas.ElementAt(i).IdiomaId;
                    idioma.NivelIdiomaId = candidatoIdiomas.ElementAt(i).NivelIdiomaId;

                    model.DatosBasicos.IdiomaCandidatoViewModel.Add(idioma);

                }
            }

            if (candidatoTecnologias != null) {
                for (int i = 0; i < candidatoTecnologias.Count; i++) {
                    var tecno = new Recruiting.Application.Candidaturas.ViewModels.CreateEditRowExperienciaCandidatoViewModel();
                    tecno.Experiencia = candidatoTecnologias.ElementAt(i).Experiencia;
                    tecno.CandidatoExperienciaId = candidatoTecnologias.ElementAt(i).CandidatoExperienciaId;
                    tecno.NivelTecnologia = candidatoTecnologias.ElementAt(i).NivelTecnologia;
                    tecno.TipoTecnologia = candidatoTecnologias.ElementAt(i).TipoTecnologia;
                    tecno.NivelTecnologiaId = candidatoTecnologias.ElementAt(i).NivelTecnologiaId;
                    tecno.TipoTecnologiaId = candidatoTecnologias.ElementAt(i).TipoTecnologiaId;

                    model.DatosBasicos.ExpCandidatoViewModel.Add(tecno);
                }
            }
                
            result.Data = model;
            return Json(result.Data);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(CandidaturaDatosBasicosViewModel viewModel, FormCollection collection)
        {
            byte[] actualFile = null;

            for (var i = 0; i < Request.Files.Count; i++)
            {
                var file = Request.Files[i];
                if ((file != null) && !string.IsNullOrWhiteSpace(file.FileName))
                {
                    try
                    {
                        var buffer = new MemoryStream();
                        file.InputStream.CopyTo(buffer);
                        actualFile = buffer.ToArray();
                        viewModel.DatosBasicos.CV = null; //borro lo que haya en la BD del fichero de curriculum
                        viewModel.DatosBasicos.NombreCV = file.FileName;
                        var ruta = ConfigurationManager.AppSettings["rutaCV"].ToString();
                        viewModel.DatosBasicos.UrlCV = ruta;
                    }
                    catch
                    {                        
                        return RedirectToAction("Index");
                    }
                }
            }        
            
            return CreateFinish(viewModel, actualFile);
        }


        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.AniadirEliminarCandidatura)]
        public ActionResult CreateByCandidato(int id, String nombre)
        {
            var moneda = GetCurrency();
            var model = new CandidaturaDatosBasicosViewModel();
            model.DatosBasicos = new CandidaturaDatosBasicos();
            model.DatosBasicos.CandidatoId = id;
            model.DatosBasicos.NombreCandidato = nombre;
            model.DatosBasicos.Moneda = moneda;

            model.DatosBasicos = GenerateViewElementsDatosBasicos(model.DatosBasicos);
            model.DatosBasicos.Access = "DatosBasicos.";

            return View("Create", model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreateCandidaturaFromBecario(DatosBecarioCrearViewModel datosBecarioCrear)
        {
            CrearCandidaturaBecarioResponse response = new CrearCandidaturaBecarioResponse();

            try
            {
                var becario = _becarioRepository.GetOne(x => x.IsActivo && x.BecarioId == datosBecarioCrear.IdBecarioCrear);
                if (becario != null)
                {
                    response = _candidaturaService.CrearCandidaturaBecario(datosBecarioCrear);
                }
                if (response.IsValid)
                {
                    var candidatura = _candidaturaRepository.GetOne(x => x.IsActivo && x.CandidatoId == becario.CandidatoId &&
                                                                    x.EstadoCandidaturaId == (int)TipoEstadoCandidaturaEnum.CartaOferta &&
                                                                    x.EtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.AgendarCartaOferta);

                    if (candidatura != null)
                    {
                        var responseBecarioCV = _becarioService.DownloadCV(datosBecarioCrear.IdBecarioCrear);
                        if (responseBecarioCV.NombreCV != null)
                        {                            
                            var rutaReal = System.IO.Path.Combine(responseBecarioCV.UrlCV, responseBecarioCV.BecarioId.ToString());
                            byte[] CVParsed = System.IO.File.ReadAllBytes(rutaReal + SeparatorBar + responseBecarioCV.NombreCV);

                            _candidaturaService.UploadCV(CVParsed, candidatura.CandidaturaId, responseBecarioCV.NombreCV);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            if (response.IsValid)
            {
                return RedirectToAction("Index", "Becarios");
            }
            else
                return RedirectToAction("General", "Error");

            
        }

        #endregion

        #region Details Members
        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.VerCandidatura)]
        public ActionResult Details(int id)
        {
            var model = _candidaturaService.GetCandidaturaById(id).CandidaturaViewModel;           

            return View(model);
        }
        #endregion

        #region Load Table Members
        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.VerCandidatura)]
        public virtual JsonResult LoadCandidatos([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
        {
            var request = requestModel.ConvertToDataTableRequestViewModel();
            request.CustomFilters.Add("Descartado", "false");
            
            request.CustomFilters.Add("excluir-candidatos", "true");

            var response = _candidatoService.GetCandidatosCandidatura(request, false);
            

           // response.CandidatoRowViewModel.ElementAt(0).

            if (!response.IsValid)
            {
                return null;
            }        

            var result = from c in response.CandidatoRowViewModel
                         select new object[]
            {
                c.Nombres,
                c.Apellidos,
                c.Centro,
                c.NumeroIdentificacion,
                this.RenderRazorViewToString("Table/actionColumnModal", c),
                c.CandidatoId
            };
            
            var jsonResponse = new DataTablesResponse(requestModel.Draw, result, response.TotalElementos, response.TotalElementos);
            return Json(jsonResponse, JsonRequestBehavior.AllowGet);
        }

        [ValidateInput(false)]
        public virtual JsonResult LoadNecesidades([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
        {
            var request = requestModel.ConvertToDataTableRequestViewModel();

            //filtro por el centro
            if (HttpContext.Session["Usuario"] != null)
            {
                var UsuarioRolPermisoViewModel = (UsuarioRolPermisoViewModel)HttpContext.Session["Usuario"];
                if (UsuarioRolPermisoViewModel.CentroIdUsuario != null)
                {
                    request.CustomFilters.Add("CentroUsuarioId", HttpContext.Session["CentroIdUsuario"].ToString());
                }
                else
                {
                    request.CustomFilters.Add("CentroUsuarioId", string.Empty);
                }
            }

            request.CustomFilters.Add("TipoContratacionId", ((int)TipoContratacionEnum.Contratación).ToString());
            var cadenaEstado = ((int)EstadoNecesidadEnum.Abierta).ToString() + ", " + ((int)EstadoNecesidadEnum.Preasignada).ToString();
            request.CustomFilters.Add("Estados", cadenaEstado);
            request.CustomFilters.Add("Prevision", ((int)TipoPrevisionEnum.Confirmado).ToString());

            var response = _necesidadService.GetNecesidadesCandidatura(request);

            if (!response.IsValid)
            {
                return null;
            }

            var result = from c in response.NecesidadViewModel
                         select new object[]
            {
                c.NecesidadId.ToString(),
                c.Cliente,
                c.Proyecto,
                c.Tecnologia,
                c.Perfil,
                (c.Estado == "Cerrada") ? string.Format("<span class=\"Statered\">{0}</span>", c.Estado) : c.Estado,
                FormatHelper.Format((c.FechaSolicitud), "dd/MM/yyyy"),
                FormatHelper.Format((c.FechaCompromiso), "dd/MM/yyyy"),
                this.RenderRazorViewToString("Table/actionColumnN",c),
                c.Nombre,
                c.NecesidadId,
                c.Modulo,
            };


            var jsonResponse = new DataTablesResponse(requestModel.Draw, result, response.TotalElementos, response.TotalElementos);

            return Json(jsonResponse, JsonRequestBehavior.AllowGet);
        }

        [ValidateInput(false)]
        public virtual JsonResult LoadCandidaturas([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
        {
            PermisosMostrar();
            var request = requestModel.ConvertToDataTableRequestViewModel();

            //filtro por el centro
            if (HttpContext.Session["Usuario"] != null)
            {
                var UsuarioRolPermisoViewModel = (UsuarioRolPermisoViewModel)HttpContext.Session["Usuario"];
                if (UsuarioRolPermisoViewModel.CentroIdUsuario != null)
                {
                    request.CustomFilters.Add("CentroUsuarioId", HttpContext.Session["CentroIdUsuario"].ToString());
                }
                else
                {
                    request.CustomFilters.Add("CentroUsuarioId", string.Empty);
                }
            }
                        
            var filtro = _sesionCandidatura.Get<FiltroCandidaturaModels>("filtro_inicial_candidatura");
            var Iterador = request.Columns.GetEnumerator();
            while (Iterador.MoveNext())
            {
                if (Iterador.Current.SortDirection == DataTableSortDirectionEnum.Ascending)
                {
                    Iterador.Current.SortDirection = filtro.SortOrder;
                }
                else if (Iterador.Current.SortDirection == DataTableSortDirectionEnum.Descending)
                {
                    Iterador.Current.SortDirection = DataTableSortDirectionEnum.Ascending;
                }
            }

            var response = _candidaturaService.GetCandidaturas(request);

            var filtroCandidaturaModel = MappertoFiltroCandidaturas(request.CustomFilters);

            if (filtro != null)
            {
                filtroCandidaturaModel.SortOrder = filtro.SortOrder;
                filtroCandidaturaModel.SortColumn = filtro.SortColumn;
            }

            _sesionCandidatura.Add("filtro_candidatura", filtroCandidaturaModel);
            _sesionCandidatura.Add("pagina_actual", request.PageNumber);


            if (!response.IsValid)
            {
                return null;
            }

            //Esto muestra el estado "Entrevista" aunque físicamente estemos en "Segunda Entrevista".
            var estadoCandidaturaEntrevista = GenerateEstadosElements().First(x => x.Value == ((int)TipoEstadoCandidaturaEnum.Entrevista).ToString()).Text;
            foreach (var candidaturaRow in response.CandidaturaViewModel)
            {
                if (candidaturaRow.EstadoId == (int)TipoEstadoCandidaturaEnum.SegundaEntrevista)
                {
                    candidaturaRow.Estado = estadoCandidaturaEntrevista;
                }
            }

            var result = from c in response.CandidaturaViewModel
                         select new object[]
                         {
                                c.CandidaturaId,
                                //c.Oferta,
                                c.OrigenCv == null ? "" : c.OrigenCv.ToString(),
                                //c.FuenteReclutamiento == null ? "" : c.FuenteReclutamiento.ToString(),
                                (c.EstadoId == (int)TipoEstadoCandidaturaEnum.Renuncia
                                || c.EstadoId == (int)TipoEstadoCandidaturaEnum.Descartado ) ? string.Format("<span class=\"Statered\">{0}</span>", c.Estado) :  c.Estado,
                                (c.EstadoId == (int)TipoEstadoCandidaturaEnum.Contratado) ? string.Format("<span class=\"hidden\">{0}</span>", c.Etapa) :   c.Etapa,
                                c.Candidato,
                                c.TipoTecnologia == null ? "" : c.TipoTecnologia.ToString(),
                                c.Entrevistador,
                                (c.EtapaId == (int)TipoEtapaCandidaturaEnum.FiltradoTecnico
                                ||c.EtapaId == (int)TipoEtapaCandidaturaEnum.FiltradoTelefonico
                                || c.EtapaId == (int)TipoEtapaCandidaturaEnum.Inicio
                                || c.EtapaId == (int)TipoEtapaCandidaturaEnum.AgendarEntrevistas ) ? "": FormatHelper.Format(c.Agendada.Date, "dd/MM/yyyy"),
                                //c.NumeroDeEntrevistas,
                                c.Perfil,
                                c.Modulo,
                                c.NivelIdioma,
                                c.Centro,
                                this.RenderRazorViewToString("Table/actionColumn", c),
                                this.RenderRazorViewToString ("Table/stateColumn", c)
                         };

            var centroUsuarioId = HttpContext.Session["CentroIdUsuario"];
            if ((centroUsuarioId != null) && result.Any())
            {
                var resultTemp = new List<object[]>();
                result.ToList().ForEach(x =>
                {
                    var item = x.ToList();
                    item.RemoveAt(11);
                    resultTemp.Add(item.ToArray());
                });
                result = resultTemp;
            }




            var jsonResponse = new DataTablesResponse(requestModel.Draw, result, response.TotalElementos, response.TotalElementos);

            return Json(jsonResponse, JsonRequestBehavior.AllowGet);

        }
        #endregion

        //---------------------------------------------- LIMITE ORDER ----------------------------------------------//


        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.VerCandidatura)]
        public ActionResult Desbloquear()
        {           
            return RedirectToAction("Index");
        }    
      
        #region Delete UI

        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.AniadirEliminarCandidatura)]
        [ValidateInput(false)]
        [HttpPost]
        public JsonResult Delete(int id)
        {
            var response = new JsonResult();
            response.Data = _candidaturaService.RemoveCandidatura(id);
            return response;

        }

        #endregion

        #region Action Buttons Members
        [ValidateInput(false)]
        [HttpPost]
        public JsonResult SeguirCandidatura(int id)
        {
            var usuario = (UsuarioRolPermisoViewModel)HttpContext.Session["Usuario"];
            var emailGuardar = usuario.Email;
            var response = _candidaturaService.SaveEmailSeguirCandidatura(id, emailGuardar);

            return Json(response, JsonRequestBehavior.AllowGet);

        }

        [ValidateInput(false)]
        [HttpPost]
        public JsonResult DejarSeguirCandidatura(int id)
        {
            var usuario = (UsuarioRolPermisoViewModel)HttpContext.Session["Usuario"];
            var emailGuardar = usuario.Email;
            var response = _candidaturaService.DeleteEmailSeguirCandidatura(id, emailGuardar);

            return Json(response, JsonRequestBehavior.AllowGet);

        }

        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.ModificarCandidatura)]
        public ActionResult Ejecutar(int CandidaturaId)
        {

            var CandidaturaViewModel = _candidaturaService.GetCandidaturaById(CandidaturaId).CandidaturaViewModel;
            var response = _candidaturaService.ExecuteCandidatura(CandidaturaId, false); //ejecuto sin salto
            if (response.VistaAMostrar.Equals("FiltradoCv"))
            {
                return RedirectToAction(response.VistaAMostrar, "Candidaturas", new { id = CandidaturaViewModel.CandidaturaId });

            }

            else if (response.VistaAMostrar.Equals("EntregaCartaOferta"))
            {
                return RedirectToAction(response.VistaAMostrar, "Candidaturas", new { id = CandidaturaViewModel.CandidaturaId });

            }

            else if (response.VistaAMostrar.Equals("DatosBasicos"))
            {
                return RedirectToAction("Create", "Candidaturas", new { id = CandidaturaViewModel.CandidaturaId });

            }

            else if (response.VistaAMostrar.Equals("CompletarSegundaEntrevista"))
            {
                return RedirectToAction(response.VistaAMostrar, "Candidaturas", new { id = CandidaturaViewModel.CandidaturaId });


            }

            else if (response.VistaAMostrar.Equals("CompletarPrimeraEntrevista"))
            {
                return RedirectToAction(response.VistaAMostrar, "Candidaturas", new { id = CandidaturaViewModel.CandidaturaId });
            }

            else if (response.VistaAMostrar.Equals("CompletarCartaOferta"))
            {
                return RedirectToAction(response.VistaAMostrar, "Candidaturas", new { id = CandidaturaViewModel.CandidaturaId });

            }

            else if (response.VistaAMostrar.Equals("AgendarSegundaEntrevista"))
            {
                return RedirectToAction(response.VistaAMostrar, "Candidaturas", new { id = CandidaturaViewModel.CandidaturaId });

            }

            else if (response.VistaAMostrar.Equals("AgendarPrimeraEntrevista"))
            {
                return RedirectToAction(response.VistaAMostrar, "Candidaturas", new { id = CandidaturaViewModel.CandidaturaId });


            }

            else if (response.VistaAMostrar.Equals("AgendarCartaOferta"))
            {
                return RedirectToAction(response.VistaAMostrar, "Candidaturas", new { id = CandidaturaViewModel.CandidaturaId });
            }

            else
            {
                var candidaturaCompleta = _candidaturaService.GetCandidaturaById(CandidaturaId);
                //ComprobarEmails(candidaturaCompleta.CandidaturaViewModel);
                return RedirectToAction("Index");
            }

        }

        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.ModificarCandidatura)]
        public ActionResult EjecutarSaltandoSegundaEntrevista(int CandidaturaId)
        {

            _candidaturaService.GetCandidaturaById(CandidaturaId);
            var response = _candidaturaService.ExecuteCandidatura(CandidaturaId, true); //ejecuto saltando
            if (response.IsValid)
            {
                var candidaturaCompleta = _candidaturaService.GetCandidaturaById(CandidaturaId);
                //ComprobarEmails(candidaturaCompleta.CandidaturaViewModel);
            }

            return RedirectToAction("Index");

        }

        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.ModificarCandidatura)]
        public ActionResult EjecutarODetalle(int CandidaturaId, int TipoEntrevistaProgramada)
        {

            var CandidaturaViewModel = _candidaturaService.GetCandidaturaById(CandidaturaId).CandidaturaViewModel;

            var estadoCandidatura = CandidaturaViewModel.CandidaturaDatosBasicosViewModel.DatosBasicos.EstadoCandidaturaId;
            var etapaCandidatura = CandidaturaViewModel.CandidaturaDatosBasicosViewModel.DatosBasicos.EtapaCandidaturaId;
            var ubicacion = CandidaturaViewModel.UbicacionCandidato; 

            if ((estadoCandidatura == (int)TipoEstadoCandidaturaEnum.Entrevista && etapaCandidatura == (int)TipoEtapaCandidaturaEnum.FeedbackPrimeraEntrevista) ||
                (estadoCandidatura == (int)TipoEstadoCandidaturaEnum.SegundaEntrevista && etapaCandidatura == (int)TipoEtapaCandidaturaEnum.FeedbackSegundaEntrevista) ||
                (estadoCandidatura == (int)TipoEstadoCandidaturaEnum.CartaOferta && etapaCandidatura == (int)TipoEtapaCandidaturaEnum.EntregaCartaOferta))
            {
                return Ejecutar(CandidaturaId);
            }
            else
            {
                return RedirectToAction("Details", new { id = CandidaturaId });
            }
        }

        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.ModificarCandidatura)]
        public ActionResult Pausar(int CandidaturaId, DateTime? fechaContactoStandBy = null)
        {
            var parameters = new RouteValueDictionary();
            PauseCandidaturaResponse response = null;
            if (fechaContactoStandBy.HasValue)
            {
                response = _candidaturaService.PauseCandidatura(CandidaturaId, fechaContactoStandBy);
            }
            else
            {
                response = _candidaturaService.PauseCandidatura(CandidaturaId);
            }

            if (!response.IsValid)
            {

                parameters.Add("errorMessage", response.ErrorMessage);
            }
            else
            {
                var candidaturaCompleta = _candidaturaService.GetCandidaturaById(CandidaturaId);
                ComprobarEmails(candidaturaCompleta.CandidaturaViewModel, "RefStandBy", "SegStandBy");
            }

            return RedirectToAction("Index", "Candidaturas", parameters);
        }

        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.ModificarCandidatura)]
        public ActionResult Reanudar(int CandidaturaId)
        {
            var parameters = new RouteValueDictionary();
            var response = _candidaturaService.ResumeCandidatura(CandidaturaId);
            if (!response.IsValid)
            {
                parameters.Add("errorMessage", response.ErrorMessage);
            }
            else
            {
                var candidaturaCompleta = _candidaturaService.GetCandidaturaById(CandidaturaId);
                ComprobarEmails(candidaturaCompleta.CandidaturaViewModel, "RefReanudar", "SegReanudar");
            }

            return RedirectToAction("Index", "Candidaturas", parameters);
        }

        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.ModificarCandidatura)]
        public ActionResult Renunciar(int CandidaturaId, int TipoRenunciaDescarte, string ComentariosRenunciaDescarte)
        {
            var parameters = new RouteValueDictionary();
            var response = _candidaturaService.RevokeCandidatura(CandidaturaId, TipoRenunciaDescarte, ComentariosRenunciaDescarte);
            if (!response.IsValid)
            {
                parameters.Add("errorMessage", response.ErrorMessage);
            }
            else
            {
                var candidaturaCompleta = _candidaturaService.GetCandidaturaById(CandidaturaId);
                ComprobarEmails(candidaturaCompleta.CandidaturaViewModel, "RefRenuncia", "SegRenuncia");
            }

            parameters.Add("IsValid", response.IsValid);
            return RedirectToAction("Index", "Candidaturas", parameters);
        }

        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.ModificarCandidatura)]
        public ActionResult Descartar(int CandidaturaId, int TipoRenunciaDescarte, string ComentariosRenunciaDescarte)
        {
            var parameters = new RouteValueDictionary();
            var response = _candidaturaService.DiscardCandidatura(CandidaturaId, TipoRenunciaDescarte, ComentariosRenunciaDescarte);
            if (!response.IsValid)
            {
                parameters.Add("errorMessage", response.ErrorMessage);
            }
            else
            {
                var candidaturaCompleta = _candidaturaService.GetCandidaturaById(CandidaturaId);
                ComprobarEmails(candidaturaCompleta.CandidaturaViewModel, "RefDescarte", "SegDescarte");
            }

            parameters.Add("IsValid", response.IsValid);
            return RedirectToAction("Index", "Candidaturas", parameters);
        }

        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.ModificarCandidatura)]
        public JsonResult Recontactar(int candidaturaId)
        {
            var response = _candidaturaService.GetCandidaturaById(candidaturaId);

            if (response.IsValid)
            {
                var responseRecontactado = _candidaturaService.RecontactarCandidaturaActual(response.CandidaturaViewModel);
                if (responseRecontactado.IsValid)
                {
                    var responseCrearRecontactado = _candidaturaService.CrearCandidaturaRecontactada(response.CandidaturaViewModel);
                    if (!responseCrearRecontactado.IsValid)
                    {
                        _candidaturaService.RevertirCandidaturaRecontactada(response.CandidaturaViewModel);
                        return Json(responseCrearRecontactado, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        var candidaturaCompleta = _candidaturaService.GetCandidaturaById(candidaturaId);
                        //ComprobarEmails(candidaturaCompleta.CandidaturaViewModel);
                    }

                }
                return Json(responseRecontactado, JsonRequestBehavior.AllowGet);
            }
            return Json(response, JsonRequestBehavior.AllowGet);

        }

        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.ModificarCandidatura)]
        public ActionResult RetrocederEstado(int CandidaturaId)
        {
            var parameters = new RouteValueDictionary();
            var response = _candidaturaService.BacktrackCandidatura(CandidaturaId);
            if (!response.IsValid)
            {
                parameters.Add("errorMessage", response.ErrorMessage);
            }
            else
            {
                var candidaturaCompleta = _candidaturaService.GetCandidaturaById(CandidaturaId);
                //ComprobarEmails(candidaturaCompleta.CandidaturaViewModel);
            }

            parameters.Add("IsValid", response.IsValid);
            return RedirectToAction("Index", "Candidaturas", parameters);
        }
        #endregion
        

        [ValidateInput(false)]        
        public ActionResult UploadCV(HttpPostedFileBase[] files, int candidaturaId)
        {
            UploadCVResponse response = null;
            if ((files != null) && files.Any())
            {

                foreach (var file in files)
                {
                    var buffer = new MemoryStream();
                    file.InputStream.CopyTo(buffer);
                    TempData["nombreCV"] = file.FileName;
                    var nombreCV = file.FileName;
                    response = _candidaturaService.UploadCV(buffer.ToArray(), candidaturaId, nombreCV);
                }
            }
            return Json(response);
        }

        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.ModificarCandidatura)]
        public JsonResult CompruebaEstadoPendienteEntrevistaDos(int candidaturaId)
        {
            var estoyEnSegundaEntrevistaPendiente = _candidaturaService.EstoyEnCandidaturaEstadoPendienteEntrevistaDos(candidaturaId);
            if (estoyEnSegundaEntrevistaPendiente.IsValid && estoyEnSegundaEntrevistaPendiente.estoy)
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }


        #region SubEntrevista Members
        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.VerCandidatura)]
        public ActionResult VerSubEntrevistasPrimeraEntrevista(int candidaturaId)
        {
            var ListaSubEntrevista = _candidaturaService.GetListaSubEntrevistas(candidaturaId, 1);
            var candidato = _candidaturaService.GetCandidatoByCandidatura(candidaturaId).CreateEditCandidatoViewModel;
            SubEntrevistaListViewModel subEntrevistaListViewModel = new SubEntrevistaListViewModel();
            subEntrevistaListViewModel.SubEntrevistaList = (ListaSubEntrevista.IsValid) ? ListaSubEntrevista.ListaSubEntrevistas : new List<SubEntrevistaViewModel>();
            subEntrevistaListViewModel.Editar = false;
            subEntrevistaListViewModel.TipoEntrevista = 1;
            subEntrevistaListViewModel.CandidaturaId = candidaturaId;
            subEntrevistaListViewModel.NombreCandidato = string.Concat(candidato.Nombres, " ", candidato.Apellidos);

            var candidaturaMonedaResponse = _candidaturaService.GetMonedaCandidatura(candidaturaId);
            subEntrevistaListViewModel.Moneda = candidaturaMonedaResponse.Moneda;

            return DetailsSubEntrevistas(subEntrevistaListViewModel);
        }

        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.VerCandidatura)]
        public ActionResult VerSubEntrevistasSegundaEntrevista(int candidaturaId)
        {
            var ListaSubEntrevista = _candidaturaService.GetListaSubEntrevistas(candidaturaId, 2);
            var candidato = _candidaturaService.GetCandidatoByCandidatura(candidaturaId).CreateEditCandidatoViewModel;
            SubEntrevistaListViewModel subEntrevistaListViewModel = new SubEntrevistaListViewModel();
            subEntrevistaListViewModel.SubEntrevistaList = (ListaSubEntrevista.IsValid) ? ListaSubEntrevista.ListaSubEntrevistas : new List<SubEntrevistaViewModel>();
            subEntrevistaListViewModel.Editar = false;
            subEntrevistaListViewModel.TipoEntrevista = 2;
            subEntrevistaListViewModel.CandidaturaId = candidaturaId;
            subEntrevistaListViewModel.NombreCandidato = string.Concat(candidato.Nombres, " ", candidato.Apellidos);

            var candidaturaMonedaResponse = _candidaturaService.GetMonedaCandidatura(candidaturaId);
            subEntrevistaListViewModel.Moneda = candidaturaMonedaResponse.Moneda;

            return DetailsSubEntrevistas(subEntrevistaListViewModel);
        }

        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.ModificarCandidatura)]
        public ActionResult EditarSubEntrevistas(int entrevistaId)
        {
            var ListaSubEntrevista = _candidaturaService.GetListaSubEntrevistasByEntrevistaId(entrevistaId);
            var candidato = _candidaturaService.GetCandidatoByCandidatura(ListaSubEntrevista.candidaturaId).CreateEditCandidatoViewModel;
            SubEntrevistaListViewModel subEntrevistaListViewModel;
            subEntrevistaListViewModel = (ListaSubEntrevista.IsValid) ? ListaSubEntrevista.subEntrevistalistViewModel : new SubEntrevistaListViewModel();
            subEntrevistaListViewModel.Editar = true;
            subEntrevistaListViewModel.CandidaturaId = ListaSubEntrevista.candidaturaId;
            subEntrevistaListViewModel.NombreCandidato = string.Concat(candidato.Nombres, " ", candidato.Apellidos);
            

            return EditSubEntrevistas(subEntrevistaListViewModel);
        }

        [HttpPost]
        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.VerCandidatura)]
        public ActionResult DetailsSubEntrevistas(SubEntrevistaListViewModel subEntrevistaListViewModel)
        {
            int[] tipoMaestroId =
            {
                (int)MasterDataTypeEnum.TipoSubEntrevista,
                (int)MasterDataTypeEnum.Categoria,
                (int)MasterDataTypeEnum.Incorporacion
            };

            var responseDatosMaestro = _maestroService.GetDatosMaestroByTipoId(tipoMaestroId);

            subEntrevistaListViewModel.TipoSubEntrevistaList = ControllerHelper.GenerateElements(responseDatosMaestro, MasterDataTypeEnum.TipoSubEntrevista);
            subEntrevistaListViewModel.CategoriaList = ControllerHelper.GenerateElements(responseDatosMaestro, MasterDataTypeEnum.Categoria);
            subEntrevistaListViewModel.IncorporacionList = ControllerHelper.GenerateElements(responseDatosMaestro, MasterDataTypeEnum.Incorporacion);

            return View("DetailsSubEntrevistas", subEntrevistaListViewModel);
        }

        [HttpPost]
        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.VerCandidatura)]
        public ActionResult EditSubEntrevistas(SubEntrevistaListViewModel subEntrevistaListViewModel)
        {
            int[] tipoMaestroId =
            {
                (int)MasterDataTypeEnum.TipoSubEntrevista,
                (int)MasterDataTypeEnum.Categoria,
                (int)MasterDataTypeEnum.Incorporacion
            };

            var responseDatosMaestro = _maestroService.GetDatosMaestroByTipoId(tipoMaestroId);

            subEntrevistaListViewModel.TipoSubEntrevistaList = ControllerHelper.GenerateElements(responseDatosMaestro, MasterDataTypeEnum.TipoSubEntrevista);
            subEntrevistaListViewModel.CategoriaList = ControllerHelper.GenerateElements(responseDatosMaestro, MasterDataTypeEnum.Categoria);
            subEntrevistaListViewModel.IncorporacionList = ControllerHelper.GenerateElements(responseDatosMaestro, MasterDataTypeEnum.Incorporacion);

            return View("EditSubEntrevistas", subEntrevistaListViewModel);
        }

        [HttpPost]
        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.ModificarCandidatura)]
        public JsonResult SaveSubEntrevistas(SubEntrevistaListViewModel subEntrevistas)
        {
            var responseUpdateSubEntrevistas = _candidaturaService.UpdateSubEntrevistas(subEntrevistas);
            if (!responseUpdateSubEntrevistas.IsValid)
            {
                return Json("error");
            }
            return Json("success");
        }

        [HttpPost]
        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.ModificarCandidatura)]
        public JsonResult AgregarUnaSubEntrevistaPrimeraEntrevista(SubEntrevistaModalViewModel subEntrevista)
        {
            var response = _candidaturaService.AddSubEntrevistaFromModal(subEntrevista, 1);
            if (response.IsValid)
            {
                return Json("success");
            }
            return Json("error");
        }

        [HttpPost]
        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.ModificarCandidatura)]
        public JsonResult AgregarUnaSubEntrevistaSegundaEntrevista(SubEntrevistaModalViewModel subEntrevista)
        {
            var response = _candidaturaService.AddSubEntrevistaFromModal(subEntrevista, 2);
            if (response.IsValid)
            {
                return Json("success");
            }
            return Json("error");
        }

        public JsonResult CompruebaMaximoSubEntrevistas(int CandidaturaId, int TipoEntrevista)
        {
            var response = _candidaturaService.GetListaSubEntrevistas(CandidaturaId, TipoEntrevista);
            var nSubEntrevistas = Convert.ToInt16(ConfigurationManager.AppSettings["numeroMaximoSubEntrevistas"].ToString());
            if (response.ListaSubEntrevistas.Count(x => x.SubEntrevistaId != null) >= nSubEntrevistas)
            {
                return Json("error");
            }
            return Json("success");
        }

        public JsonResult ComprobarFechaAviso(DateTime[] fechas, int candidaturaId, bool notificar, int tipoEntrevista)
        {
            if (!notificar)
            {
                return Json("success");
            }
            else
            {
                var response = _candidaturaService.TieneAvisoConLaMismaFechaSubEntrevista(fechas, candidaturaId, tipoEntrevista);
                if (response.IsValid && response.Tiene)
                {
                    return Json("error");
                }
                else if (response.IsValid && !response.Tiene)
                {
                    return Json("success");
                }
            }
            return Json("error");
        }

        public JsonResult ComprobarFechaAvisoEntrevistaPrincipal(DateTime[] fechas, int candidaturaId, bool notificar)
        {
            if (!notificar || fechas == null)
            {
                return Json("success");
            }
            else
            {
                var candidatura = _candidaturaService.GetCandidaturaById(candidaturaId);
                if (candidatura.IsValid)
                {
                    var fechaEntrevistaPrimera = candidatura.CandidaturaViewModel.PrimeraEntrevistaViewModel.AgendarPrimeraEntrevista.AgendarPrimeraEntrevista.FechaEntrevista.Value.Date;
                    if (fechas.Any(x => x.Date == fechaEntrevistaPrimera))
                    {
                        return Json("error");
                    }
                }
            }
            return Json("success");
        }

        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.ModificarCandidatura)]
        public ActionResult EditarSubEntrevistaSubEntrevistador(string candidaturaIdTipoEntrevistaEntrevistadorId)
        {
            var subEntrevistaList = new SubEntrevistaListViewModel();
            subEntrevistaList.SubEntrevistaList = new List<SubEntrevistaViewModel>();

            var parametro = Newtonsoft.Json.Linq.JObject.Parse(candidaturaIdTipoEntrevistaEntrevistadorId);

            var candidaturaId = (int)parametro["candidaturaId"];
            var tipoEntrevista = (int)parametro["tipoEntrevista"];
            var entrevistadorId = (int)parametro["entrevistadorId"];
            var vengoDeCandidaturas = (bool)parametro["vengoDeCandidaturas"];

            var listaSubEntrevistasResponse = _candidaturaService.GetListaSubEntrevistas(candidaturaId, tipoEntrevista);

            listaSubEntrevistasResponse.ListaSubEntrevistas.RemoveAll(subEntrevista => subEntrevista.EntrevistadorId != entrevistadorId);

            subEntrevistaList.CandidaturaId = candidaturaId;
            subEntrevistaList.SubEntrevistaList = listaSubEntrevistasResponse.ListaSubEntrevistas;
            subEntrevistaList.TipoEntrevista = tipoEntrevista;
            subEntrevistaList.Editar = true;

            subEntrevistaList.VengoDeCandidaturas = (vengoDeCandidaturas);

            return EditSubEntrevistas(subEntrevistaList);
        }

        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.VerCandidatura)]
        public ActionResult VolverSubEntrevistas(int entrevistaId)
        {
            var subEntrevistaList = new SubEntrevistaListViewModel();
            subEntrevistaList.SubEntrevistaList = new List<SubEntrevistaViewModel>();

            var ListaSubEntrevista = _candidaturaService.GetListaSubEntrevistasByEntrevistaId(entrevistaId);
            var candidato = _candidaturaService.GetCandidatoByCandidatura(ListaSubEntrevista.candidaturaId).CreateEditCandidatoViewModel;

            var getSubEntrevistasResponse = _candidaturaService.GetListaSubEntrevistasByEntrevistaId(entrevistaId);
            

            if (getSubEntrevistasResponse.IsValid)
            {
                subEntrevistaList = getSubEntrevistasResponse.subEntrevistalistViewModel;
                subEntrevistaList.Editar = false;

            }

            subEntrevistaList.NombreCandidato = string.Concat(candidato.Nombres, " ", candidato.Apellidos);

            return DetailsSubEntrevistas(subEntrevistaList);
        }

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult CompruebaSiTieneSubEntrevistas(CandidaturaIdYTipoEntrevistaViewModel candidaturaIdYTipoEntrevista)
        {
            var tieneSubEntrevistasResponse = _candidaturaService.TieneSubEntrevistasSinCompletar(candidaturaIdYTipoEntrevista.candidaturaId, candidaturaIdYTipoEntrevista.tipoEntrevista);
            if (tieneSubEntrevistasResponse.IsValid && tieneSubEntrevistasResponse.TieneSubentrevistas)
            {
                return Json(true);
            }
            else if (tieneSubEntrevistasResponse.IsValid && !(tieneSubEntrevistasResponse.TieneSubentrevistas))
            {
                return Json(false);
            }
            else
            {
                return Json("error");
            }
        }
        #endregion        
       
        #region FiltradoCV

        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.ModificarCandidatura)]
        public ActionResult FiltradoCv(int? id = null)
        {
            var model = new CandidaturaFiltradoCvViewModel();

            if (id.HasValue)
            {
                model = _candidaturaService.GetFiltradoCVCandidatura((int)id).CandidaturaFiltradoCvViewModel;
            }

            return View(model);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult FiltradoCv(CandidaturaFiltradoCvViewModel viewModel, FormCollection collection)
        {         

            if (collection["SubmitType"] == "guardar")
            {
                return FiltradoSave(viewModel);
            }

            return FiltradoFinish(viewModel);
        }

        public CandidaturaFiltradoCvViewModel GuardarFiltrado(CandidaturaFiltradoCvViewModel model, bool finish)
        {            
            var response = _candidaturaService.SaveFiltradoCVCandidatura(model, finish);

            if (!response.IsValid)
            {
                CreateMessageError(response.ErrorMessage);
            }
            else
            {
                CreateMessageNotify("Candidatura Guardada Correctamente.");

                if (finish)
                {
                    var candidaturaCompleta = _candidaturaService.GetCandidaturaById(model.CandidaturaId);
                    if(model.Filtrado)
                    {
                        ComprobarEmails(candidaturaCompleta.CandidaturaViewModel, "RefFiltroTelefonico", "SegFiltroTelefonico");
                    }
                    else
                    {
                        ComprobarEmails(candidaturaCompleta.CandidaturaViewModel, "RefDescarte", "SegDescarte");
                    }
                }
            }

            return model;
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult FiltradoSave(CandidaturaFiltradoCvViewModel viewModel)
        {
            var model = GuardarFiltrado(viewModel, false);
            return View("FiltradoCv", model);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult FiltradoFinish(CandidaturaFiltradoCvViewModel viewModel)
        {
            GuardarFiltrado(viewModel, true);
            return RedirectToAction("Index");
        }

        #endregion FiltradoCV

        #region Primera Entrevista

        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.ModificarCandidatura)]
        public ActionResult AgendarPrimeraEntrevista(int? id = null)
        {
            var model = new AgendarPrimeraEntrevistaViewModel();
            model.AgendarPrimeraEntrevista = new AgendarPrimeraEntrevista() { Presencial = true, AvisarAlCandidato = true };
            model.SubEntrevistaList = CargarSubEntrevistasVacias();


            if (id != null)
            {
                model.AgendarPrimeraEntrevista.CandidaturaId = (int)id;                
            }

            if (id.HasValue)
            {
                var agendarPrimeraEntrevista = _candidaturaService.GetSchedulePrimeraEntrevista((int)id).AgendarPrimeraEntrevistaViewModel;
                if (agendarPrimeraEntrevista != null)
                {
                    model = agendarPrimeraEntrevista;
                }
            }

            model = GenerateViewElementsAgendarPrimeraEntrevista(model, id.Value);
            

            return View(model);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult AgendarPrimeraEntrevista(AgendarPrimeraEntrevistaViewModel viewModel, FormCollection collection)
        {           

            if (Convert.ToInt16(collection["AgendarPrimeraEntrevista.EntrevistadorId"]) > 0)
            {
                viewModel.AgendarPrimeraEntrevista.EntrevistadorId = Convert.ToInt16(collection["AgendarPrimeraEntrevista.EntrevistadorId"]);
                viewModel.AgendarPrimeraEntrevista.EntrevistadorName = collection["AgendarPrimeraEntrevista.EntrevistadorId-Text"];

            }      

            if (collection["SubmitType"] == "guardar")
            {
                return AgendarPrimeraEntrevistaSave(viewModel);
            }
           
            return AgendarPrimeraEntrevistaFinish(viewModel);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult AgendarPrimeraEntrevistaSave(AgendarPrimeraEntrevistaViewModel viewModel)
        {
            GuardarPrimeraEntrevista(viewModel, false);
            var filtro = _sesionCandidatura.Get<FiltroCandidaturaModels>("filtro_candidatura");

            if (filtro == null)
            {
                filtro = new FiltroCandidaturaModels();
            }

            filtro = GenerateViewElementsIndex(filtro);

            var pagina = _sesionCandidatura.Get<int>("pagina_actual");
            if (pagina > 0)
            {
                filtro.Pagina = pagina;
            }         

           return View("Index", filtro);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult AgendarPrimeraEntrevistaFinish(AgendarPrimeraEntrevistaViewModel viewModel)
        {
            GuardarPrimeraEntrevista(viewModel, true);
            var filtro = _sesionCandidatura.Get<FiltroCandidaturaModels>("filtro_candidatura");

            if (filtro == null)
            {
                filtro = new FiltroCandidaturaModels();
            }

            filtro = GenerateViewElementsIndex(filtro);
           
            var pagina = _sesionCandidatura.Get<int>("pagina_actual");
            if (pagina > 0)
            {
                filtro.Pagina = pagina;
            }
            _candidaturaService.SaveNumeroDeEntrevistas(viewModel.AgendarPrimeraEntrevista.CandidaturaId);


            return View("Index", filtro);
        }

        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.ModificarCandidatura)]
        public ActionResult CompletarPrimeraEntrevista(int? id = null)
        {
            var model = new PrimeraEntrevistaViewModel();
            model.AgendarPrimeraEntrevista = new AgendarPrimeraEntrevistaViewModel()
            {
                AgendarPrimeraEntrevista = new AgendarPrimeraEntrevista()
            };
            model.RangoSalarialesyDisponibilidades = new RangoSalarialesyDisponibilidades();
            model.ResultadoPrimeraEntrevista = new ResultadoPrimeraEntrevista();

            if (id.HasValue)
            {
                model = _candidaturaService.GetPrimeraEntrevista((int)id).CompletarPrimeraEntrevistaViewModel;
            }

            model = GenerateViewElementsCompletarPrimeraEntrevista(model, id.Value);

            return View(model);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult CompletarPrimeraEntrevista(PrimeraEntrevistaViewModel viewModel, FormCollection collection)
        {

            for (var i = 0; i < Request.Files.Count; i++)
            {
                var file = Request.Files[i];
                if ((file != null) && !string.IsNullOrWhiteSpace(file.FileName))
                {
                    try
                    {
                        var buffer = new MemoryStream();
                        file.InputStream.CopyTo(buffer);

                        viewModel.ResultadoPrimeraEntrevista.TS = buffer.ToArray();
                        viewModel.ResultadoPrimeraEntrevista.NombreTS = file.FileName;
                    }
                    catch
                    {                        
                        return RedirectToAction("Index");
                    }
                }
            }            

            if (Convert.ToInt16(collection["AgendarPrimeraEntrevista.EntrevistadorId"]) > 0)
            {
                viewModel.AgendarPrimeraEntrevista.AgendarPrimeraEntrevista.EntrevistadorId = Convert.ToInt16(collection["AgendarPrimeraEntrevista.EntrevistadorId"]);
                viewModel.AgendarPrimeraEntrevista.AgendarPrimeraEntrevista.EntrevistadorName = collection["AgendarPrimeraEntrevista.EntrevistadorId-Text"];
            }

           

            if (collection["SubmitType"] == "guardar")
            {
                return PrimeraEntrevistaSave(viewModel);
            }
           
            return PrimeraEntrevistaFinish(viewModel);
        }

        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.ModificarCandidatura)]
        public ActionResult PrimeraEntrevistaReagendar(int candidaturaID)
        {
            var model = _candidaturaService.GetPrimeraEntrevista(candidaturaID).CompletarPrimeraEntrevistaViewModel.AgendarPrimeraEntrevista;
            _candidaturaService.ReschedulePrimeraEntrevista(candidaturaID);
            
            return View("AgendarPrimeraEntrevista", model);
        }

        #endregion Primera Entrevista

        #region Segunda Entrevista

        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.ModificarCandidatura)]
        public ActionResult AgendarSegundaEntrevista(int? id = null)
        {
            var model = new AgendarSegundaEntrevistaViewModel();
            model.AgendarSegundaEntrevista = new AgendarSegundaEntrevista() { Presencial = true, AvisarAlCandidato = true };
            model.SubEntrevistaList = CargarSubEntrevistasVacias();

            if (id != null)
            {
                model.AgendarSegundaEntrevista.CandidaturaId = (int)id;                
            }

            if (id.HasValue)
            {
                var agendarSegundaEntrevista = _candidaturaService.GetSegundaEntrevista((int)id).CompletarSegundaEntrevistaViewModel.AgendarSegundaEntrevista;
                if (agendarSegundaEntrevista != null)
                {
                    model = agendarSegundaEntrevista;
                }
            }

            model = GenerateViewElementsAgendarSegundaEntrevista(model, model.AgendarSegundaEntrevista.CandidaturaId);

            return View(model);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult AgendarSegundaEntrevista(AgendarSegundaEntrevistaViewModel viewModel, FormCollection collection)
        {          
            if (Convert.ToInt16(collection["AgendarSegundaEntrevista.EntrevistadorId"]) > 0)
            {
                viewModel.AgendarSegundaEntrevista.EntrevistadorId = Convert.ToInt16(collection["AgendarSegundaEntrevista.EntrevistadorId"]);
                viewModel.AgendarSegundaEntrevista.EntrevistadorName = collection["AgendarSegundaEntrevista.EntrevistadorId-Text"];
            }           

            if (collection["SubmitType"] == "guardar")
            {
                return AgendarSegundaEntrevistaSave(viewModel);
            }
            
            return AgendarSegundaEntrevistaFinish(viewModel);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult AgendarSegundaEntrevistaFinish(AgendarSegundaEntrevistaViewModel viewModel)
        {
            GuardarSegundaEntrevista(viewModel, true);
            var filtro = _sesionCandidatura.Get<FiltroCandidaturaModels>("filtro_candidatura");

            if (filtro == null)
            {
                filtro = new FiltroCandidaturaModels();
            }
            filtro = GenerateViewElementsIndex(filtro);

            var pagina = _sesionCandidatura.Get<int>("pagina_actual");
            if (pagina > 0)
            {
                filtro.Pagina = pagina;
            }

            _candidaturaService.SaveNumeroDeEntrevistas(viewModel.AgendarSegundaEntrevista.CandidaturaId);

            return View("Index", filtro);
        }

        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.ModificarCandidatura)]
        public ActionResult CompletarSegundaEntrevista(int? id = null)
        {
            var model = new SegundaEntrevistaViewModel();
            model.AgendarSegundaEntrevista = new AgendarSegundaEntrevistaViewModel()
            {
                AgendarSegundaEntrevista = new AgendarSegundaEntrevista()
            };
            model.RangoSalarialesyDisponibilidades = new RangoSalarialesyDisponibilidades();
            model.ResultadoSegundaEntrevista = new ResultadoSegundaEntrevista();

            if (id.HasValue)
            {
                model = _candidaturaService.GetSegundaEntrevista((int)id).CompletarSegundaEntrevistaViewModel;
            }

            model = GenerateViewElementsCompletarSegundaEntrevista(model, id.Value);

            return View(model);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult CompletarSegundaEntrevista(SegundaEntrevistaViewModel viewModel, FormCollection collection)
        {         

            if (collection["SubmitType"] == "guardar")
            {
                return SegundaEntrevistaSave(viewModel);
            }
            
            return SegundaEntrevistaFinish(viewModel);
        }

        public SegundaEntrevistaViewModel GuardarResultadoSegundaEntrevista(SegundaEntrevistaViewModel model, bool finish)
        {           
            var response = _candidaturaService.SaveSegundaEntrevista(model, finish);
            var listaDeSubEntrevistas = _candidaturaService.GetListaSubEntrevistas(model.AgendarSegundaEntrevista.AgendarSegundaEntrevista.CandidaturaId, 2);
            model.AgendarSegundaEntrevista.SubEntrevistaList = listaDeSubEntrevistas.ListaSubEntrevistas;

            if (!response.IsValid)
            {
                CreateMessageError(response.ErrorMessage);
            }
            else
            {
                CreateMessageNotify("Candidatura Guardada Correctamente.");
                if (finish)
                {
                    var candidaturaCompleta = _candidaturaService.GetCandidaturaById(model.AgendarSegundaEntrevista.AgendarSegundaEntrevista.CandidaturaId);
                    if (model.ResultadoSegundaEntrevista.SuperaEntrevista2Id != (int)TipoDecisionEnum.SUPERA_SEGUNDA_ENTREVISTA)
                    {
                        ComprobarEmails(candidaturaCompleta.CandidaturaViewModel, "RefDescarte", "SegDescarte");
                    }
                }
            }
           
            var responseCandidatura = _candidaturaService.GetCandidaturaById(model.AgendarSegundaEntrevista.AgendarSegundaEntrevista.CandidaturaId);
            if (responseCandidatura.IsValid)
            {
                model.AgendarSegundaEntrevista.AgendarSegundaEntrevista.EntrevistadorId = responseCandidatura.CandidaturaViewModel.SegundaEntrevistaViewModel.AgendarSegundaEntrevista.AgendarSegundaEntrevista.EntrevistadorId;
                model.AgendarSegundaEntrevista.AgendarSegundaEntrevista.EntrevistadorName = responseCandidatura.CandidaturaViewModel.SegundaEntrevistaViewModel.AgendarSegundaEntrevista.AgendarSegundaEntrevista.EntrevistadorName;
                model.AgendarSegundaEntrevista.AgendarSegundaEntrevista.FechaEntrevista = responseCandidatura.CandidaturaViewModel.SegundaEntrevistaViewModel.AgendarSegundaEntrevista.AgendarSegundaEntrevista.FechaEntrevista;
                model.AgendarSegundaEntrevista.AgendarSegundaEntrevista.Presencial = responseCandidatura.CandidaturaViewModel.SegundaEntrevistaViewModel.AgendarSegundaEntrevista.AgendarSegundaEntrevista.Presencial;
                model.AgendarSegundaEntrevista.AgendarSegundaEntrevista.AvisarAlCandidato = responseCandidatura.CandidaturaViewModel.SegundaEntrevistaViewModel.AgendarSegundaEntrevista.AgendarSegundaEntrevista.AvisarAlCandidato;
            }
            else
            {
                CreateMessageNotify(responseCandidatura.ErrorMessage);
            }

            model.AgendarSegundaEntrevista.AgendarSegundaEntrevista.EntrevistadorName = _usuarioService.GetUsuarioById((int)model.AgendarSegundaEntrevista.AgendarSegundaEntrevista.EntrevistadorId).UsuarioViewModel.Usuario;
            return model;
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult SegundaEntrevistaFinish(SegundaEntrevistaViewModel model)
        {
            GuardarResultadoSegundaEntrevista(model, true);
            var filtro = _sesionCandidatura.Get<FiltroCandidaturaModels>("filtro_candidatura");

            if (filtro == null)
            {
                filtro = new FiltroCandidaturaModels();
            }

            filtro = GenerateViewElementsIndex(filtro);

            var pagina = _sesionCandidatura.Get<int>("pagina_actual");
            if (pagina > 0)
            {
                filtro.Pagina = pagina;
            }

            return View("Index", filtro);
        }

        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.ModificarCandidatura)]
        public ActionResult SegundaEntrevistaReagendar(int candidaturaID)
        {
            var model = _candidaturaService.GetSegundaEntrevista(candidaturaID).CompletarSegundaEntrevistaViewModel.AgendarSegundaEntrevista;
            _candidaturaService.RescheduleSegundaEntrevista(candidaturaID);
           
            return View("AgendarSegundaEntrevista", model);
        }

        #endregion Segunda Entrevista

        #region Carta Oferta

        #region Agendar

        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.ModificarCandidatura)]
        public ActionResult AgendarCartaOferta(int? id = null)
        {
            var model = new AgendarCartaOfertaViewModel();
            model.AgendarCartaOferta = new AgendarCartaOferta();
            if (id != null)
            {
                model.AgendarCartaOferta.CandidaturaId = (int)id;                              
            }

            if (id.HasValue)
            {
                var agendarCartaOferta = _candidaturaService.GetCartaOferta((int)id).CompletarCartaOfertaViewModel.EntregaCartaOfertaViewModel.AgendarCartaOfertaViewModel;
                if (agendarCartaOferta != null)
                {
                    model = agendarCartaOferta;
                    model.AgendarCartaOferta.CandidaturaId = (int)id;
                }
            }

            model = GenerateViewElementsAgendarCartaOferta(model);

            return View(model);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult AgendarCartaOferta(AgendarCartaOfertaViewModel viewModel, FormCollection collection)
        {           
            if (Convert.ToInt16(collection["AgendarCartaOferta.EntrevistadorId"]) > 0)
            {
                viewModel.AgendarCartaOferta.EntrevistadorId = Convert.ToInt16(collection["AgendarCartaOferta.EntrevistadorId"]);
                viewModel.AgendarCartaOferta.EntrevistadorName = collection["AgendarCartaOferta.EntrevistadorId-Text"];
            }            

            if (collection["SubmitType"] == "guardar")
            {
                return AgendarCartaOfertaSave(viewModel);
            }
            
            return AgendarCartaOfertaFinish(viewModel);
        }

        public AgendarCartaOfertaViewModel GuardarCartaOferta(AgendarCartaOfertaViewModel model, bool finish)
        {            
            var response = _candidaturaService.SaveScheduleCartaOferta(model, finish);

            if (!response.IsValid)
            {
                CreateMessageError(response.ErrorMessage);
            }
            else
            {
                CreateMessageNotify("Candidatura Guardada Correctamente.");
                if (finish)
                {
                    var candidaturaCompleta = _candidaturaService.GetCandidaturaById(model.AgendarCartaOferta.CandidaturaId);
                    ComprobarEmails(candidaturaCompleta.CandidaturaViewModel, "RefCartaOferta", "SegCartaOferta");
                }

            }
           
            model.AgendarCartaOferta.CandidaturaId = response.CandidaturaId;
            return model;
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult AgendarCartaOfertaSave(AgendarCartaOfertaViewModel model)
        {
            model = GuardarCartaOferta(model, false);

            model = GenerateViewElementsAgendarCartaOferta(model);

            return View("AgendarCartaOferta", model);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult AgendarCartaOfertaFinish(AgendarCartaOfertaViewModel model)
        {
            GuardarCartaOferta(model, true);
            var filtro = _sesionCandidatura.Get<FiltroCandidaturaModels>("filtro_candidatura");

            if (filtro == null)
            {
                filtro = new FiltroCandidaturaModels();
            }

            filtro = GenerateViewElementsIndex(filtro);

            var pagina = _sesionCandidatura.Get<int>("pagina_actual");
            if (pagina > 0)
            {
                filtro.Pagina = pagina;
            }

            return View("Index", filtro);
        }

        #endregion Agendar

        #region Entrega

        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.ModificarCandidatura)]
        public ActionResult EntregaCartaOferta(int? id = null)
        {
            var model = new EntregaCartaOfertaViewModel();
            model.AgendarCartaOfertaViewModel = new AgendarCartaOfertaViewModel()
            {
                AgendarCartaOferta = new AgendarCartaOferta()
            };
            model.EntregaCartaOferta = new EntregaCartaOferta();

            if (id.HasValue)
            {
                model = _candidaturaService.GetCartaOferta((int)id).CompletarCartaOfertaViewModel.EntregaCartaOfertaViewModel;
            }

            return View(model);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult EntregaCartaOferta(EntregaCartaOfertaViewModel viewModel, FormCollection collection)
        {
            if (TempData.ContainsKey("viewModel"))
            {
                TempData.Remove("viewModel");
            }
            TempData.Add("viewModel", viewModel);

            if (collection["SubmitType"] == "guardar")
            {
                return EntregaCartaOfertaSave();
            }
            
            return EntregaCartaOfertaFinish();
        }

        public EntregaCartaOfertaViewModel GuardarEntregaCartaOferta(bool finish)
        {
            var model = (EntregaCartaOfertaViewModel)TempData["viewModel"];
            var response = _candidaturaService.SaveCartaOferta(model, finish);

            if (!response.IsValid)
            {
                CreateMessageError(response.ErrorMessage);
            }
            else
            {
                UploadCartaOfertaGenerada1(model.AgendarCartaOfertaViewModel.AgendarCartaOferta.CandidaturaId);
                CreateMessageNotify("Candidatura Guardada Correctamente.");
            }

            model.AgendarCartaOfertaViewModel.AgendarCartaOferta.EntrevistadorName = _usuarioService.GetUsuarioById((int)model.AgendarCartaOfertaViewModel.AgendarCartaOferta.EntrevistadorId).UsuarioViewModel.Usuario;


            return model;
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult EntregaCartaOfertaSave()
        {
            var model = GuardarEntregaCartaOferta(false);
            return View("EntregaCartaOferta", model);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult EntregaCartaOfertaFinish()
        {
            GuardarEntregaCartaOferta(true);
            var filtro = _sesionCandidatura.Get<FiltroCandidaturaModels>("filtro_candidatura");

            if (filtro == null)
            {
                filtro = new FiltroCandidaturaModels();
            }           

            var pagina = _sesionCandidatura.Get<int>("pagina_actual");
            if (pagina > 0)
            {
                filtro.Pagina = pagina;
            }

            return View("Index", filtro);
        }

        #endregion Entrega

        #region Completar

        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.ModificarCandidatura)]
        public ActionResult CompletarCartaOferta(int? id = null)
        {
            var model = new CompletarCartaOfertaViewModel();
            model.EntregaCartaOfertaViewModel = new EntregaCartaOfertaViewModel()
            {
                AgendarCartaOfertaViewModel = new AgendarCartaOfertaViewModel
                {
                    AgendarCartaOferta = new AgendarCartaOferta()
                },
                EntregaCartaOferta = new EntregaCartaOferta()
            };
            model.CompletarCartaOferta = new CompletarCartaOferta();

            if (id.HasValue)
            {
                model = _candidaturaService.GetCartaOferta((int)id).CompletarCartaOfertaViewModel;
                var candidaturaViewModel = _candidaturaService.GetCandidaturaById((int)id).CandidaturaViewModel;
                if (model.CompletarCartaOferta.NecesidadId == null)
                {
                    var posibleNecesidadAsignada = _necesidadService.GetNecesidadByCandidaturaIdAndCandidatoId(id.Value, candidaturaViewModel.CandidaturaDatosBasicosViewModel.DatosBasicos.CandidatoId);
                    if (posibleNecesidadAsignada.IsValid)
                    {
                        model.CompletarCartaOferta.NecesidadId = posibleNecesidadAsignada.necesidadId;
                        model.CompletarCartaOferta.NecesidadNombre = posibleNecesidadAsignada.necesidadNombre;
                    }
                }
                model.EntregaCartaOfertaViewModel.AgendarCartaOfertaViewModel.AgendarCartaOferta.AccessEtapa = candidaturaViewModel.CandidaturaDatosBasicosViewModel.DatosBasicos.EtapaCandidaturaId;
            }

            model = GenerateViewElementsCompletarCartaOferta(model);
            
            return View(model);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult CompletarCartaOferta(CompletarCartaOfertaViewModel viewModel, FormCollection collection)
        {
          

            if ((viewModel.CompletarCartaOferta.SuperaCartaOferta == ((int)TipoDecisionEnum.ACEPTA_CARTA_OFERTA)) && viewModel.necesidadAAbrir != null)
            {
                _necesidadService.AbrirNecesidad(viewModel.necesidadAAbrir.Value);
                var necesidad = _necesidadService.GetNecesidadById(viewModel.necesidadAAbrir.Value);
                if (necesidad.IsValid && necesidad.NecesidadViewModel.GrupoNecesidad.HasValue)
                {
                    _grupoNecesidadService.CheckGrupoCerrado(necesidad.NecesidadViewModel.GrupoNecesidad.Value);
                }
            }          

            if (collection["SubmitType"] == "guardar")
            {
                return CompletarCartaOfertaSave(viewModel);
            }            

            return CompletarCartaOfertaFinish(viewModel);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult CompletarCartaOfertaSave(CompletarCartaOfertaViewModel model)
        {
            model = GuardarCompletarCartaOferta(model, false);

            model.CompletarCartaOferta.AsignadaCorrectamente = (!model.CompletarCartaOferta.AsignadaCorrectamente.HasValue) ? false : model.CompletarCartaOferta.AsignadaCorrectamente;

            model = GenerateViewElementsCompletarCartaOferta(model);

            return View("CompletarCartaOferta", model);
        }

        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.ModificarCandidatura)]
        public ActionResult CompletarCartaOfertaReagendar(int candidaturaID)
        {
            var model = _candidaturaService.GetCartaOferta(candidaturaID).CompletarCartaOfertaViewModel.CompletarCartaOferta;
            _candidaturaService.RescheduleCartaOferta(candidaturaID);
            
            return View("AgendarCartaOferta", model);
        }

        #endregion Completar

        #endregion Carta Oferta

        #region Edicion Candidatura
        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.ModificarCandidatura)]
        public ActionResult EditExtend(int id, string errorMessage = null)
        {
            if (!string.IsNullOrWhiteSpace(errorMessage))
            {
                CreateMessageError(errorMessage);
            }

            var response = _candidaturaService.GetCandidaturaById(id);

            response.CandidaturaViewModel = GenerateViewElementsEditExtend(response.CandidaturaViewModel);

            return View("EditExtend", response.CandidaturaViewModel);
        }


        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.ModificarCandidatura)]
        [HttpPost]
        public ActionResult EditExtend(CandidaturaViewModel viewModel, FormCollection collection)
        {
            //se le actualizan los ficheros de curriculum que haya podido subir
            foreach (var fileKey in Request.Files) // Creamos un foreach que nos permite saber si hemos obtenido algun archivo de la coleccion
            {//variable que nos saca el/los archivos obtenidos

                var inputName = fileKey.ToString();
                var file = Request.Files[inputName];
                //con esto obtenemos los bytes del/los archivos
                var buffer = new MemoryStream();
                file.InputStream.CopyTo(buffer);
                var nombreFichero = file.FileName;
                //si el archivo es igual al nombre que tiene en el javascript, en este caso "file"
                if ((nombreFichero == null) || (nombreFichero != "")) //Comprobamos si nos estan pasando fichero. Ya que en Request.Files siempre se envía un fichero aunque esté vacío.
                {
                    if (inputName == "CV") //Esto significa que el archivo que nos llega es un curriculum o un archivo vacío
                    {
                        var candidaturaId = viewModel.CandidaturaId.Value;
                        var respuestaCv = _candidaturaService.UploadCV(buffer.ToArray(), candidaturaId, file.FileName);
                        if (respuestaCv.IsValid)
                        {
                            viewModel.CandidaturaDatosBasicosViewModel.DatosBasicos.CV = null; //borro lo que haya en la BD del fichero de curriculum
                            viewModel.CandidaturaDatosBasicosViewModel.DatosBasicos.NombreCV = file.FileName;
                            viewModel.CandidaturaDatosBasicosViewModel.DatosBasicos.UrlCV = ConfigurationManager.AppSettings["rutaCV"].ToString();
                        }
                    }
                    else if (inputName == "archivoTest") //esto indica que nos estan pasando un archivo del Test de la entrevista.
                    {
                        try
                        {//tenemos el otro archivo
                            viewModel.PrimeraEntrevistaViewModel.ResultadoPrimeraEntrevista.TS = buffer.ToArray();
                            viewModel.PrimeraEntrevistaViewModel.ResultadoPrimeraEntrevista.NombreTS = file.FileName;
                        }
                        catch (Exception ex)
                        {
                            CreateMessageError(ex.Message);
                            return null;
                        }
                    }
                }
            }

            //guardamos el archivo            
            return GuardaEditCandidatura(viewModel);

        }


        private ActionResult GuardaEditCandidatura(CandidaturaViewModel model)
        {

            int Centroid = _candidaturaService.GetCentroCandidatura(model.CandidaturaId.Value).CentroId;
            EditCandidaturaResponse response;

            var ServicioCorreos = new SendMailsPlaningBatchService(_candidaturaRepository, _candidaturaService, _candidatoService, _maestroService, _bitacoraRepository,
                _tipoDecisionRepository, _tipoEtapaCandidaturaRepository, _tipoEstadoCandidaturaRepository);

            var responseCO = ServicioCorreos.GetPlantillaCorreoByNombreCentroId("CartaOferta", Centroid);
            if (responseCO.IsValid)
            {
                string nombreEntregaCarta = ServicioCorreos.GetValorDefectoNombreVariablePlantillaCorreo(responseCO.correoPlantilla.PlantillaId, "NombreEntregaCarta").VarlorDefecto;
                string cargoEntregaCarta = ServicioCorreos.GetValorDefectoNombreVariablePlantillaCorreo(responseCO.correoPlantilla.PlantillaId, "CargoEntregaCarta").VarlorDefecto;
                string telefono = ServicioCorreos.GetValorDefectoNombreVariablePlantillaCorreo(responseCO.correoPlantilla.PlantillaId, "Telefono").VarlorDefecto;
                string telefonoContratacion = ServicioCorreos.GetValorDefectoNombreVariablePlantillaCorreo(responseCO.correoPlantilla.PlantillaId, "Telefono Contratacion").VarlorDefecto;
                string mailTo = ServicioCorreos.GetValorDefectoNombreVariablePlantillaCorreo(responseCO.correoPlantilla.PlantillaId, "MailTo").VarlorDefecto;
                string atencionTelefonica = ServicioCorreos.GetValorDefectoNombreVariablePlantillaCorreo(responseCO.correoPlantilla.PlantillaId, "AtencionTelefonica").VarlorDefecto;
                string ayudaComedor = ServicioCorreos.GetValorDefectoNombreVariablePlantillaCorreo(responseCO.correoPlantilla.PlantillaId, "AyudaComedor").VarlorDefecto;
                string fax = ServicioCorreos.GetValorDefectoNombreVariablePlantillaCorreo(responseCO.correoPlantilla.PlantillaId, "Fax").VarlorDefecto;

                response = _candidaturaService.SaveEditCandidatura(model, nombreEntregaCarta, cargoEntregaCarta,
                     telefono, telefonoContratacion, mailTo, atencionTelefonica, ayudaComedor, fax, responseCO.correoPlantilla.TextoPlantilla);             
            }
            else
            {
                response = _candidaturaService.SaveEditCandidatura(model, "", "", "", "", "", "", "", "", "");             
            }

            return Json(response);

        }



        #endregion region

        #region ComprobarEmails

        public void ComprobarEmails(CandidaturaViewModel model, string asuntoRef, string asuntoSeg)
        {
            var ServicioCorreos = new SendMailsPlaningBatchService(_candidaturaRepository, _candidaturaService, _candidatoService, _maestroService, _bitacoraRepository,
                _tipoDecisionRepository, _tipoEtapaCandidaturaRepository, _tipoEstadoCandidaturaRepository);

            if (model.EmailsSeguimiento != null && model.EmailsSeguimiento != "")
            {
                var destinatarios = model.EmailsSeguimiento.Split(';');
                foreach (var destinatario in destinatarios)
                {
                    if (destinatario != null && destinatario != "")
                    {
                        var usuario = _usuarioService.GetUsuarioByEmail(destinatario);
                        var bitacora = _bitacoraService.GetLastBitacoraByCandidaturaId((int)model.CandidaturaId);
                        var mensajeNotificacion = formatearMensajeSistema(bitacora.BitacoraCorreoViewModel);
                        var centro = usuario.UsuarioViewModel.CentroIdUsuario;
                        var candidatoId = model.CandidaturaDatosBasicosViewModel.DatosBasicos.CandidatoId;
                        ServicioCorreos.EnviarNotificacionesCandidaturas((int)model.CandidaturaId, candidatoId, destinatario, asuntoSeg, mensajeNotificacion, centro);
                    }
                }
            }
            if (model.CandidaturaDatosBasicosViewModel.DatosBasicos.ListEmailReferenciados != null)
            {
                foreach (var destinatario in model.CandidaturaDatosBasicosViewModel.DatosBasicos.ListEmailReferenciados)
                {
                    if (destinatario != null && destinatario != "")
                    {
                        var usuario = _usuarioService.GetUsuarioById((int)model.UsuarioCreacionId);
                        var bitacora = _bitacoraService.GetLastBitacoraByCandidaturaId((int)model.CandidaturaId);
                        var mensajeNotificacion = formatearMensajeSistema(bitacora.BitacoraCorreoViewModel);
                        var centro = usuario.UsuarioViewModel.CentroIdUsuario;
                        var candidatoId = model.CandidaturaDatosBasicosViewModel.DatosBasicos.CandidatoId;
                        ServicioCorreos.EnviarNotificacionesCandidaturas((int)model.CandidaturaId, candidatoId, destinatario, asuntoRef, mensajeNotificacion, centro);
                    }
                }
            }

        }

        public string formatearMensajeSistema(BitacoraCorreoViewModel bitacora)
        {
            var mensajeSistema = "";
            if (bitacora.TipoCambio == "Retroceder" || bitacora.TipoCambio == "Pausar" || bitacora.TipoCambio == "Reanudar")
            {
                return bitacora.MensajeSistema;
            }
            else
            {
                var usuario = _usuarioService.GetUsuarioById((int)bitacora.Usuario).UsuarioViewModel.Usuario.ToString();
                var estadoAnterior = _tipoEstadoCandidaturaRepository.GetOne(x => x.TipoEstadoCandidaturaId == bitacora.EstadoAnterior).EstadoCandidatura.ToString();
                var estadoNuevo = _tipoEstadoCandidaturaRepository.GetOne(x => x.TipoEstadoCandidaturaId == bitacora.EstadoNuevo).EstadoCandidatura.ToString();
                var etapaAnterior = _tipoEtapaCandidaturaRepository.GetOne(x => x.TipoEtapaCandidaturaId == bitacora.EtapaAnterior).EtapaCandidatura.ToString();
                var etapaNueva = _tipoEtapaCandidaturaRepository.GetOne(x => x.TipoEtapaCandidaturaId == bitacora.EtapaNueva).EtapaCandidatura.ToString();
                if (bitacora.EstadoAnterior == bitacora.EstadoNuevo)
                {
                    if (bitacora.EtapaAnterior != bitacora.EtapaNueva)
                    {
                        mensajeSistema = (string.Format("La candidatura con referencia {0} ha pasado del estado '{1}' y etapa '{2}' a la etapa '{3}'.",
                                            bitacora.CandidaturaId, estadoAnterior, etapaAnterior, etapaNueva));
                    }
                }
                else
                {
                    if (bitacora.EtapaAnterior == bitacora.EtapaNueva)
                    {
                        mensajeSistema = (string.Format("La candidatura con referencia {0} ha pasado del estado '{1}' al estado '{2}'.",
                                            bitacora.CandidaturaId, estadoAnterior, estadoNuevo));
                    }
                    else
                    {
                        mensajeSistema = (string.Format("La candidatura con referencia {0} ha pasado del estado '{1}' y etapa '{2}' al estado '{3}' y etapa '{4}'.",
                                            bitacora.CandidaturaId, estadoAnterior, etapaAnterior, estadoNuevo, etapaNueva));
                    }

                }
                mensajeSistema = mensajeSistema + "\nEsta acción ha sido tomada por el usuario " + usuario + " en la fecha " + bitacora.FechaCreacion;
            }
            return mensajeSistema;
        }

        #endregion

        public ActionResult ActualizarNumeroDeEntrevistas()
        {
            var filtro = _sesionCandidatura.Get<FiltroCandidaturaModels>("filtro_candidatura");

            if (filtro == null)
            {
                filtro = new FiltroCandidaturaModels();
            }

            _candidaturaService.UpdateNumeroDeEntrevistas();
            
            return View("Index", filtro);
        }

        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.VerCandidatura)]
        public FileResult DownloadCV(int id)
        {
            try
            {
                var response = _candidaturaService.DownloadCV(id);
                var contentType = GetContentType(response.NombreCV);
                var rutaReal = System.IO.Path.Combine(response.UrlCV, response.CandidaturaId.ToString());
                return File(rutaReal + SeparatorBar + response.NombreCV, contentType, response.NombreCV);
            }
            catch
            {
                return null;
            }
        }

        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.VerCandidatura)]
        public FileResult DownloadTest(int id)
        {
            try
            {
                var response = _candidaturaService.GetPrimeraEntrevista(id);
                var nombreTest = response.CompletarPrimeraEntrevistaViewModel.ResultadoPrimeraEntrevista.NombreTS;
                var test = response.CompletarPrimeraEntrevistaViewModel.ResultadoPrimeraEntrevista.TS;
                var contentType = GetContentType(nombreTest);
                return File(test, contentType, nombreTest);
            }
            catch
            {
                return null;
            }
        }

        //Esta acción nos permite volver desde otra página con el filtro
        public ActionResult Volver()
        {
            return RedirectToAction("Index");
        }

        #region Limpiar

        public ActionResult Limpiar()
        {            
            _sesionCandidatura.Remove("filtro_candidatura");
            return RedirectToAction("Index");
        }

        #endregion

        #region ExportToExcel
        public void ExportToExcel(string filterEstado, string filterEtapa, string filterPerfil, string filterEntrevistador,
                        string filterCandidato, string filterCandidaturaId, string filterAgendadaDesde, string filterAgendadaHasta,
                        string filterTipoTecnologia, string filterOrigenCv, string filterCentro, string filterIdioma, 
                        string filterNivelIdioma, string filterModulo, string filterCandidaturaOferta)
        {
            IDictionary<string, string> CustomFilters = new Dictionary<string, string> {
                    { "Estado", filterEstado },
                    { "Etapa",filterEtapa},
                    { "Perfil",filterPerfil },
                    { "Entrevistador", filterEntrevistador },
                    { "Candidato", filterCandidato },
                    { "CandidaturaId", filterCandidaturaId },
                    { "AgendadaDesde", filterAgendadaDesde },
                    { "AgendadaHasta", filterAgendadaHasta },
                    { "TipoTecnologiaId",filterTipoTecnologia },
                    { "OrigenCv",filterOrigenCv },                    
                    { "CentroSearch", filterCentro },
                    { "Idioma",filterIdioma },
                    { "NivelIdioma",filterNivelIdioma },
                    { "ModuloId", filterModulo },
                    {"CandidaturaOferta" , filterCandidaturaOferta }
                };

            //filtro por el centro
            if (HttpContext.Session["Usuario"] != null)
            {
                var UsuarioRolPermisoViewModel = (UsuarioRolPermisoViewModel)HttpContext.Session["Usuario"];
                if (UsuarioRolPermisoViewModel.CentroIdUsuario != null)
                {
                    CustomFilters.Add("CentroUsuarioId", HttpContext.Session["CentroIdUsuario"].ToString());
                }

            }

            var request = new DataTableRequest();
            request.CustomFilters = CustomFilters;
            var response = _candidaturaService.GetCandidaturasExportToExcel(request);



            var grid = new System.Web.UI.WebControls.GridView();
            grid.DataSource = response.CandidaturaExportToExcelViewModel;
            grid.DataBind();
            Response.ClearContent();
            string filename = string.Format("Listado_de_Candidaturas_{0}", DateTime.Now.ToShortDateString() + ".xls");
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", filename));
            Response.ContentType = "application/excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);

            grid.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();

        }

        #endregion
        #endregion

        [ValidateInput(false)]
        [HttpPost]
        public JsonResult CheckCandidaturasAbiertas(int candidatoId)
        {
            var response = new JsonResult();
            response.Data = _candidaturaService.CheckCandidaturasAbiertas(candidatoId);

            return response;
        }

        #region Private Methods



        [ValidateInput(false)]
        private ActionResult PrimeraEntrevistaSave(PrimeraEntrevistaViewModel model)
        {
            model = GuardarResultadoPrimeraEntrevista(model, false);

            model = GenerateViewElementsCompletarPrimeraEntrevista(model, model.AgendarPrimeraEntrevista.AgendarPrimeraEntrevista.CandidaturaId);

            return View("CompletarPrimeraEntrevista", model);
        }

        private PrimeraEntrevistaViewModel GuardarResultadoPrimeraEntrevista(PrimeraEntrevistaViewModel model, bool finish)
        {            
            var response = _candidaturaService.SavePrimeraEntrevista(model, finish);
            var listaDeSubEntrevistas = _candidaturaService.GetListaSubEntrevistas(model.AgendarPrimeraEntrevista.AgendarPrimeraEntrevista.CandidaturaId, 1);
            model.AgendarPrimeraEntrevista.SubEntrevistaList = listaDeSubEntrevistas.ListaSubEntrevistas;

            if (!response.IsValid)
            {
                CreateMessageError(response.ErrorMessage);
            }
            else
            {
                CreateMessageNotify("Candidatura Guardada Correctamente.");
                if (finish)
                {
                    var candidaturaCompleta = _candidaturaService.GetCandidaturaById(model.AgendarPrimeraEntrevista.AgendarPrimeraEntrevista.CandidaturaId);
                    if(model.ResultadoPrimeraEntrevista.SuperaEntrevistaId != (int)TipoDecisionEnum.SUPERA_PRIMERA_ENTREVISTA)
                    {
                        ComprobarEmails(candidaturaCompleta.CandidaturaViewModel, "RefDescarte", "SegDescarte");
                    }
                }
            }
            
            model.AgendarPrimeraEntrevista.AgendarPrimeraEntrevista.EntrevistadorName = _usuarioService.GetUsuarioById((int)model.AgendarPrimeraEntrevista.AgendarPrimeraEntrevista.EntrevistadorId).UsuarioViewModel.Usuario;
            return model;
        }

        [ValidateInput(false)]
        private ActionResult PrimeraEntrevistaFinish(PrimeraEntrevistaViewModel model)
        {
            GuardarResultadoPrimeraEntrevista(model, true);
            var filtro = _sesionCandidatura.Get<FiltroCandidaturaModels>("filtro_candidatura");

            if (filtro == null)
            {
                filtro = new FiltroCandidaturaModels();
            }

            filtro = GenerateViewElementsIndex(filtro);
            
            var pagina = _sesionCandidatura.Get<int>("pagina_actual");
            if (pagina > 0)
            {
                filtro.Pagina = pagina;
            }

            return View("Index", filtro);
        }

        private void GuardarSegundaEntrevista(AgendarSegundaEntrevistaViewModel model, bool finish)
        {           

            var response = _candidaturaService.SaveScheduleSegundaEntrevista(model, finish);

            if (!response.IsValid)
            {
                CreateMessageError(response.ErrorMessage);
            }
            else
            {
                CreateMessageNotify("Candidatura Guardada Correctamente.");
                if (finish)
                {
                    var candidaturaCompleta = _candidaturaService.GetCandidaturaById(model.AgendarSegundaEntrevista.CandidaturaId);
                    ComprobarEmails(candidaturaCompleta.CandidaturaViewModel, "RefAgendarEntrevistaComplementaria", "SegAgendarEntrevistaComplementaria");
                }
            }          
          
        }

        private void GuardarPrimeraEntrevista(AgendarPrimeraEntrevistaViewModel model, bool finish)
        {            
            var response = _candidaturaService.SaveSchedulePrimeraEntrevista(model, finish);

            if (!response.IsValid)
            {
                CreateMessageError(response.ErrorMessage);
            }
            else
            {
                CreateMessageNotify("Candidatura Guardada Correctamente.");
                if (finish)
                {
                    var candidaturaCompleta = _candidaturaService.GetCandidaturaById(model.AgendarPrimeraEntrevista.CandidaturaId);
                    ComprobarEmails(candidaturaCompleta.CandidaturaViewModel, "RefAgendarEntrevista", "SegAgendarEntrevista");
                }
            }
        }

        [ValidateInput(false)]
        private ActionResult AgendarSegundaEntrevistaSave(AgendarSegundaEntrevistaViewModel viewModel)
        {
            GuardarSegundaEntrevista(viewModel, false);

            var filtro = _sesionCandidatura.Get<FiltroCandidaturaModels>("filtro_candidatura");

            if (filtro == null)
            {
                filtro = new FiltroCandidaturaModels();
            }

            filtro = GenerateViewElementsIndex(filtro);

            var pagina = _sesionCandidatura.Get<int>("pagina_actual");
            if (pagina > 0)
            {
                filtro.Pagina = pagina;
            }

            return View("Index", filtro);
        }

        [ValidateInput(false)]
        private ActionResult SegundaEntrevistaSave(SegundaEntrevistaViewModel model)
        {
            model = GuardarResultadoSegundaEntrevista(model, false);

            model = GenerateViewElementsCompletarSegundaEntrevista(model, model.AgendarSegundaEntrevista.AgendarSegundaEntrevista.CandidaturaId);

            return View("CompletarSegundaEntrevista", model);
        }

        private CompletarCartaOfertaViewModel GuardarCompletarCartaOferta(CompletarCartaOfertaViewModel model, bool finish)
        {            
            _candidaturaService.GetCandidatoByCandidatura(model.EntregaCartaOfertaViewModel.AgendarCartaOfertaViewModel.AgendarCartaOferta.CandidaturaId);

            var response = _candidaturaService.SaveCartaOfertaAndNecesidad(model, finish);

            if (!response.IsValid)
            {

                CreateMessageError(response.ErrorMessage);
            }

            else
            {

                if (model.CompletarCartaOferta.NecesidadId != null)
                {
                    var necesidadResponse = CerrarNecesidad(model);

                    var getNecesidadResponse = _necesidadService.GetNecesidadById(model.CompletarCartaOferta.NecesidadId.Value);
                    if (getNecesidadResponse.IsValid && getNecesidadResponse.NecesidadViewModel.GrupoNecesidad.HasValue)
                    {
                        _grupoNecesidadService.CheckGrupoCerrado(getNecesidadResponse.NecesidadViewModel.GrupoNecesidad.Value);
                    }

                    if (!necesidadResponse.IsValid)
                    {
                        CreateMessageError(necesidadResponse.ErrorMessage);
                    }
                    else
                    {
                        UploadCartaOfertaGenerada1(model.EntregaCartaOfertaViewModel.AgendarCartaOfertaViewModel.AgendarCartaOferta.CandidaturaId);
                        CreateMessageNotify("Candidatura Guardada Correctamente.");
                    }
                }
                else
                {

                    UploadCartaOfertaGenerada1(model.EntregaCartaOfertaViewModel.AgendarCartaOfertaViewModel.AgendarCartaOferta.CandidaturaId);
                    CreateMessageNotify("Candidatura Guardada Correctamente.");
                }
                if (finish)
                {
                    var candidaturaCompleta = _candidaturaService.GetCandidaturaById(model.EntregaCartaOfertaViewModel.AgendarCartaOfertaViewModel.AgendarCartaOferta.CandidaturaId);
                    if (model.CompletarCartaOferta.SuperaCartaOferta == (int)TipoDecisionEnum.ACEPTA_CARTA_OFERTA)
                    {
                        ComprobarEmails(candidaturaCompleta.CandidaturaViewModel, "RefAceptaCO", "SegAceptaCO");
                    }
                    else
                    {
                        ComprobarEmails(candidaturaCompleta.CandidaturaViewModel, "RefRechazaCO", "SegRechazaCO");
                    }
                    
                }

            }            
           
            model.EntregaCartaOfertaViewModel.AgendarCartaOfertaViewModel.AgendarCartaOferta.EntrevistadorName = _usuarioService.GetUsuarioById((int)model.EntregaCartaOfertaViewModel.AgendarCartaOfertaViewModel.AgendarCartaOferta.EntrevistadorId).UsuarioViewModel.Usuario;
            return model;
        }

        [ValidateInput(false)]
        private ActionResult CompletarCartaOfertaFinish(CompletarCartaOfertaViewModel model)
        {
            GuardarCompletarCartaOferta(model, true);
            var filtro = _sesionCandidatura.Get<FiltroCandidaturaModels>("filtro_candidatura");

            if (filtro == null)
            {
                filtro = new FiltroCandidaturaModels();
            }

            filtro = GenerateViewElementsIndex(filtro);

            var pagina = _sesionCandidatura.Get<int>("pagina_actual");
            if (pagina > 0)
            {
                filtro.Pagina = pagina;
            }

            return View("Index", filtro);
        }

        private void GuardarCandidatura(CandidaturaDatosBasicosViewModel model, bool finish, byte[] file)
        {     

            var response = _candidaturaService.SaveCandidatura(model, finish);

            if (!response.IsValid)
            {
                CreateMessageError(response.ErrorMessage);
            }
            else
            {
                CreateMessageNotify("Candidatura guardada correctamente");
            }
            
            model.DatosBasicos.CandidaturaId = response.CandidaturaId;

            if ((response.NombreCV != null) || (response.NombreCV == ""))
            {
                _candidaturaService.UploadCV(file, response.CandidaturaId, response.NombreCV);
               
            }
        }
   
        [ValidateInput(false)]
        private ActionResult CreateFinish(CandidaturaDatosBasicosViewModel model, Byte[] file)
        {
            GuardarCandidatura(model, true, file);
            _sesionCandidatura.Get<FiltroCandidaturaModels>("filtro_candidatura");
            return RedirectToAction("Index");
        }    

        private IEnumerable<SelectListItem> GenerateEstadosElements()
        {
            var response = _candidaturaEstadoService.GetEstadosCandidatura();

            if (response.IsValid)
            {
                if ((from value in response.CandidaturaEstadosViewModel where value.Orden == null select value).Any()) //si hay ALGUN estado con el orden sin definir
                {
                    IEnumerable<CandidaturaEstadoRowViewModel> estadosList;
                    estadosList = from value in response.CandidaturaEstadosViewModel orderby value.EstadoCandidatura select value;
                    return new SelectList(estadosList, "EstadoCandidaturaId", "EstadoCandidatura");
                }
                else
                {
                    IEnumerable<CandidaturaEstadoRowViewModel> estadosList;
                    estadosList = from value in response.CandidaturaEstadosViewModel orderby value.Orden select value;
                    return new SelectList(estadosList, "EstadoCandidaturaId", "EstadoCandidatura");
                }
            }
            else
            {
                return new List<SelectListItem>();
            }
        }



        private IEnumerable<SelectListItem> GenerateEtapasElements()
        {
            var filtro = _sesionCandidatura.Get<FiltroCandidaturaModels>("filtro_candidatura");
            if (filtro != null && filtro.EstadoCandidaturaId != null && filtro.EstadoCandidaturaId.Any())
            {
                int[] filtroEstadoCandidaturaId = filtro.EstadoCandidaturaId;
                return DevuelveEtapas(filtroEstadoCandidaturaId);
            }
            else
            {
                var response = _candidaturaEtapaService.GetEtapasCandidatura();

                if (response.IsValid)
                {
                    IEnumerable<CandidaturaEtapaRowViewModel> etapasList; 
                    if ((from value in response.CandidaturaEtapasViewModel where value.Orden == null select value).Any()) //Si algun valor del campo orden dentro de la tabla de estapas es null
                    {
                        etapasList = from value in response.CandidaturaEtapasViewModel orderby value.EtapaCandidatura select value;
                        return new SelectList(etapasList, "EtapaCandidaturaId", "EtapaCandidatura");
                    }
                    else
                    {
                        etapasList = from value in response.CandidaturaEtapasViewModel orderby value.Orden select value;
                        return new SelectList(etapasList, "EtapaCandidaturaId", "EtapaCandidatura");
                    }

                }
                else
                {
                    return new List<SelectListItem>();
                }
            }
        }
        public IEnumerable<SelectListItem> DevuelveEtapas(int[] idEstado)
        {
            if (idEstado != null)
            {
                IEnumerable<CandidaturaEtapaRowViewModel> lista = new List<CandidaturaEtapaRowViewModel>();
                TipoEstadoCandidaturaEnum[] te = new TipoEstadoCandidaturaEnum[idEstado.Length];
                for (var i = 0; i < idEstado.Length; i++)
                {
                    te[i] = (TipoEstadoCandidaturaEnum)idEstado[i];
                }
                var etapas = _candidaturaEtapaService.GetEtapasCandidatura();
                lista = from item in ExtensionsTipoEstadoCandidaturaEnum.GetTiposEstadosCandidaturas(te)
                        select new CandidaturaEtapaRowViewModel()
                        {
                            EtapaCandidaturaId = (int)item,
                            EtapaCandidatura = etapas.CandidaturaEtapasViewModel.Single(x => x.EtapaCandidaturaId == (int)item).EtapaCandidatura,
                            Orden = etapas.CandidaturaEtapasViewModel.Single(x => x.EtapaCandidaturaId == (int)item).Orden
                        };
                lista = from item in lista orderby item.Orden select item;
                return new SelectList(lista, "EtapaCandidaturaId", "EtapaCandidatura");
            }
            else
            {
                int[] muestraTodasLasEtapas = new int[1] { (int)TipoEtapaCandidaturaEnum.Inicio };
                return DevuelveEtapas(muestraTodasLasEtapas);
            }
        }

        public JsonResult GenerateEtapasElementsPorEstado(string idEstado)
        {
            int[] idsADevolver = null;
            if ((idEstado != null) && (idEstado != ""))
            {
                var ids = idEstado.Split(',');

                if (ids[0] == "") //Esto comprueba si el usuario ha seleccionado "ninguno" y cualquier otra categoria en el desplegable
                {
                    return Json(DevuelveEtapas(idsADevolver));
                }
                idsADevolver = new int[ids.Length];
                for (int i = 0; i < ids.Length; i++)
                {
                    idsADevolver[i] = Convert.ToInt16(ids[i]);
                }
            }
            return Json(DevuelveEtapas(idsADevolver));
        }

        public JsonResult GetNecesidadEditar(int necesidadId)
        {
            var response = _necesidadService.GetNecesidadById(necesidadId);
            if (response.IsValid)
            {
                Json(response.NecesidadViewModel);
                return Json(response.NecesidadViewModel, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false);
            }
        }

        public JsonResult EditarNecesidadModal(CreateEditNecesidadViewModel necesidad)
        {
            var response = _necesidadService.SaveNecesidad(necesidad);

            if (response.IsValid)
            {
                return Json("success", JsonRequestBehavior.AllowGet);

            }
            else
            {
                return Json("error");
            }
        }

        private SaveNecesidadResponse CerrarNecesidad(CompletarCartaOfertaViewModel cartaOferta)
        {
            SaveNecesidadResponse necesidadResponseSave = new SaveNecesidadResponse();

            if (cartaOferta != null && cartaOferta.CompletarCartaOferta.FechaIncorporacion != null && cartaOferta.CompletarCartaOferta.NecesidadId != null)
            {
                var necesidadId = (int)cartaOferta.CompletarCartaOferta.NecesidadId;
                var necesidadResponseGet = _necesidadService.GetNecesidadById(necesidadId);
                var candidatoResponseGet = _candidaturaService.GetCandidatoByCandidatura(cartaOferta.EntregaCartaOfertaViewModel.AgendarCartaOfertaViewModel.AgendarCartaOferta.CandidaturaId);

                if (necesidadResponseGet.IsValid)
                {
                    var model = necesidadResponseGet.NecesidadViewModel;
                    model.FechaCierre = cartaOferta.CompletarCartaOferta.FechaIncorporacion;
                    model.EstadoNecesidadId = 11;
                    model.AsignadaCorrectamente = cartaOferta.CompletarCartaOferta.AsignadaCorrectamente;

                    if (candidatoResponseGet.IsValid)
                    {
                        var candidatoViewModel = candidatoResponseGet.CreateEditCandidatoViewModel;
                        model.DetalleTecnologia += " Asignado:" + candidatoViewModel.Nombres + " " + candidatoViewModel.Apellidos;
                    }
                    necesidadResponseSave = _necesidadService.SaveNecesidad(model);
                }
                else
                {
                    necesidadResponseSave.IsValid = false;
                    necesidadResponseSave.ErrorMessage = "Error al Recuperar la Necesidad";
                }
            } else if (cartaOferta!= null && cartaOferta.CompletarCartaOferta.NecesidadId != null) {
                necesidadResponseSave.IsValid = true;
            }

            return necesidadResponseSave;
        }


        private void PermisosMostrar()
        {
            TempData["AniadirEliminarCandidatura"] = false;
            TempData["ModificarCandidatura"] = false;
            TempData["AdministrarCandidatura"] = false;
            TempData["VerCandidato"] = false;
            TempData["VerCandidatura"] = false;
            TempData["GenerarCartaOferta"] = true;

            var permisos = new List<PermisoRolViewModel>();

            if (HttpContext.Session["Usuario"] != null)
            {
                var UsuarioRolPermisoViewModel = (UsuarioRolPermisoViewModel)HttpContext.Session["Usuario"];

                foreach (var usuarioRol in UsuarioRolPermisoViewModel.UsuarioRol)
                {
                    foreach (var permiso in usuarioRol.PermisoRol)
                    {
                        permisos.Add(permiso);
                    }
                }
            }



            string privilegeLevels = string.Join("|", permisos.Select(x => x.PermisoNombre).ToArray());
            if (privilegeLevels.Contains(PermisosConst.AniadirEliminarCandidatura)) TempData["AniadirEliminarCandidatura"] = true;
            if (privilegeLevels.Contains(PermisosConst.ModificarCandidatura)) TempData["ModificarCandidatura"] = true;
            if (privilegeLevels.Contains(PermisosConst.AdministrarCandidatura)) TempData["AdministrarCandidatura"] = true;
            if (privilegeLevels.Contains(PermisosConst.VerCandidato)) TempData["VerCandidato"] = true;
            if (privilegeLevels.Contains(PermisosConst.VerCandidatura)) TempData["VerCandidatura"] = true;

        }       

        private void CreateMessageNotify(String textMessg)
        {
            @ViewBag.ShowMessage = true;
            @ViewBag.TypeMessage = TypeMessageEnum.AlertMessage;
            @ViewBag.TitleMessage = Properties.Resources.Candidato_NotificacionTitulo;
            @ViewBag.TextMessage = textMessg;

        }

        private void CreateMessageError(String textMessg)
        {
            @ViewBag.ShowMessage = true;
            @ViewBag.TypeMessage = TypeMessageEnum.ErrorMessage;
            @ViewBag.TitleMessage = Properties.Resources.Candidato_ErrorTitulo;
            @ViewBag.TextMessage = textMessg;

        }

        private string GetContentType(string fileName)
        {
            string contentType = "application/octetstream";
            string ext = System.IO.Path.GetExtension(fileName).ToLower();
            Microsoft.Win32.RegistryKey registryKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
            if (registryKey != null && registryKey.GetValue("Content Type") != null)
                contentType = registryKey.GetValue("Content Type").ToString();
            return contentType;
        }

        

        private FiltroCandidaturaModels MappertoFiltroCandidaturas(IDictionary<string, string> filtro)
        {
            var filtroCandidaturasModels = new FiltroCandidaturaModels();

            if (filtro.Count != 0)
            {
                string value;

                if (filtro.ContainsKey("Estado[]"))
                {
                    value = filtro["Estado[]"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        var estados = value.Split(',').Select(Int32.Parse).ToArray();
                        filtroCandidaturasModels.EstadoCandidaturaId = estados;
                    }
                }

                if (filtro.ContainsKey("NombreOferta"))
                {
                    value = filtro["NombreOferta"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroCandidaturasModels.Oferta = value;
                    }
                }

                if (filtro.ContainsKey("OfertaId"))
                {
                    value = filtro["OfertaId"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroCandidaturasModels.OfertaId = Convert.ToInt32(value);
                    }
                }

                if (filtro.ContainsKey("OrigenCv"))
                {
                    value = filtro["OrigenCv"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroCandidaturasModels.OrigenCvId = Convert.ToInt32(value);
                    }
                }



                if (filtro.ContainsKey("Etapa[]"))
                {
                    value = filtro["Etapa[]"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        var etapas = value.Split(',').Select(Int32.Parse).ToArray();
                        filtroCandidaturasModels.EtapaCandidaturaId = etapas;
                    }
                }

                if (filtro.ContainsKey("Perfil"))
                {
                    value = filtro["Perfil"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroCandidaturasModels.PerfilId = Convert.ToInt32(value);
                    }
                }

                if (filtro.ContainsKey("Entrevistador"))
                {
                    value = filtro["Entrevistador"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroCandidaturasModels.EntrevistadorId = Convert.ToInt32(value);
                    }
                }

                if (filtro.ContainsKey("EntrevistadorName"))
                {
                    value = filtro["EntrevistadorName"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroCandidaturasModels.EntrevistadorName = value;
                    }
                }

                if (filtro.ContainsKey("Candidato"))
                {
                    value = filtro["Candidato"].ToString();
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroCandidaturasModels.NombreCandidato = value;
                    }
                }

                if (filtro.ContainsKey("CandidaturaId"))
                {
                    value = filtro["CandidaturaId"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroCandidaturasModels.Referencia = Convert.ToInt32(value);
                    }
                }

                if (filtro.ContainsKey("AgendadaDesde"))
                {
                    value = filtro["AgendadaDesde"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroCandidaturasModels.AgendadaEntre = Convert.ToDateTime(value);
                    }
                }

                if (filtro.ContainsKey("AgendadaHasta"))
                {
                    value = filtro["AgendadaHasta"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroCandidaturasModels.AgendadaHasta = Convert.ToDateTime(value);
                    }

                }

                if (filtro.ContainsKey("TipoTecnologiaId"))
                {
                    value = filtro["TipoTecnologiaId"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroCandidaturasModels.TipoTecnologiaId = Convert.ToInt32(value);
                    }
                }

                if (filtro.ContainsKey("CentroUsuarioId"))
                {
                    value = filtro["CentroUsuarioId"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroCandidaturasModels.CentroIdUsuario = Convert.ToInt32(value);
                    }
                }

                if (filtro.ContainsKey("CentroSearch"))
                {
                    value = filtro["CentroSearch"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroCandidaturasModels.CentroIdUsuario = Convert.ToInt32(value);
                    }
                }

                if (filtro.ContainsKey("Idioma"))
                {
                    value = filtro["Idioma"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroCandidaturasModels.Idioma = value;
                    }
                }

                if (filtro.ContainsKey("NivelIdioma"))
                {
                    value = filtro["NivelIdioma"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroCandidaturasModels.NivelIdioma = value;
                    }
                }

                if (filtro.ContainsKey("ModuloId"))
                {
                    value = filtro["ModuloId"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroCandidaturasModels.ModuloId = Convert.ToInt32(value);
                    }
                }

                if (filtro.ContainsKey("CandidaturaOferta"))
                {
                    value = filtro["CandidaturaOferta"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroCandidaturasModels.CandidaturaOfertaId = Convert.ToInt32(value);
                    }
                }

                if (filtro.ContainsKey("CandidaturaOfertaName"))
                {
                    value = filtro["CandidaturaOfertaName"].ToString();
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroCandidaturasModels.CandidaturaOferta = value;
                    }
                }
                if (filtro.ContainsKey("UbicacionCandidato"))
                {
                    value = filtro["UbicacionCandidato"].ToString();
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroCandidaturasModels.UbicacionCandidato = value;
                    }
                }
                if (filtro.ContainsKey("AnioExperiencia"))
                {
                    value = filtro["AnioExperiencia"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroCandidaturasModels.AnioExperiencia = Convert.ToDateTime(value);
                    }
                }
                if (filtro.ContainsKey("Keyword"))
                {
                    value = filtro["Keyword"].ToString();
                    if (!string.IsNullOrEmpty(value))
                    {

                        filtroCandidaturasModels.Keyword = value;
                    }
                }
            }


            return filtroCandidaturasModels;
        }

        private IEnumerable<SelectListItem> GenerateProyectoElements()
        {
            var response = _proyectoService.GetProyectosNombreId();

            if (response.IsValid)
            {
                IEnumerable<ProyectoNombreIdViewModel> proyectoList;
                proyectoList = from value in response.ProyectoViewModel orderby value.Nombre select value;

                var selectList = new SelectList(proyectoList, "ProyectoId", "Nombre");

                return selectList;
            }
            else
            {
                return new List<SelectListItem>();
            }

        }

        private IEnumerable<SelectListItem> GenerateClienteElements()
        {
            var response = _clienteService.GetClientes();

            if (response.IsValid)
            {
                IEnumerable<ClienteRowViewModel> clienteList;
                clienteList = from value in response.ClienteViewModel orderby value.Nombre select value;

                return new SelectList(clienteList, "ClienteId", "Nombre");
            }
            else
            {
                return new List<SelectListItem>();
            }
        }

        private string GetCurrency()
        {
            int centroId = 0;
            if (HttpContext.Session["Usuario"] != null)
            {
                var UsuarioRolPermisoViewModel = (UsuarioRolPermisoViewModel)HttpContext.Session["Usuario"];
                centroId = UsuarioRolPermisoViewModel.CentroIdUsuario.Value;
            }
            var response = _candidaturaMonedaService.GetMonedaByCentroId(centroId);
            if (response.IsValid || (!response.IsValid && response.Moneda == "default"))
            {
                return response.Moneda;
            }
            else
            {
                return "error";
            }
        }

        private List<SubEntrevistaViewModel> CargarSubEntrevistasVacias()
        {
            int nSubEntrevistas = Convert.ToInt16(ConfigurationManager.AppSettings["numeroMaximoSubEntrevistas"].ToString());

            var listaVacia = new List<SubEntrevistaViewModel>();
            for (int i = 0; i < nSubEntrevistas; i++)
            {
                var elementoVacio = new SubEntrevistaViewModel();
                listaVacia.Add(elementoVacio);
            }
            return listaVacia;
        }

        private FiltroCandidaturaModels GenerateViewElementsIndex(FiltroCandidaturaModels filtro)
        {
            int[] tipoMaestroId =
         {
                (int)MasterDataTypeEnum.Categoria,
                (int)MasterDataTypeEnum.TipoTecnologia,
                (int)MasterDataTypeEnum.OrigenCv,
                (int)MasterDataTypeEnum.Idioma,
                (int)MasterDataTypeEnum.NivelIdioma,
                (int)MasterDataTypeEnum.TipoModulo,
                (int)MasterDataTypeEnum.TipoRenuncia,
                (int)MasterDataTypeEnum.MotivoDescarte            

            };

            var response = _maestroService.GetDatosMaestroByTipoId(tipoMaestroId);

            filtro.EstadoList = GenerateEstadosElements();
            filtro.EtapaList = GenerateEtapasElements();
            filtro.CategoriaList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.Categoria);
            filtro.TecnologiaList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.TipoTecnologia);
            filtro.OrigenCvList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.OrigenCv);
            filtro.IdiomaList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.Idioma);
            filtro.NivelIdiomaList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.NivelIdioma);
            filtro.ModuloList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.TipoModulo);
            filtro.CentroList = (IEnumerable<SelectListItem>)HttpContext.Session["ListaCentros"];
            filtro.MotivoRenunciaList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.TipoRenuncia);
            filtro.MotivoDescarteList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.MotivoDescarte);
            filtro.CentroIdUsuarioLogueado = HttpContext.Session["CentroIdUsuario"] != null ? HttpContext.Session["CentroIdUsuario"].ToString() : string.Empty;

            return filtro;
        }

        private CandidaturaDatosBasicos GenerateViewElementsDatosBasicos(CandidaturaDatosBasicos model)
        {
            int[] tipoMaestroId =
     {
                (int)MasterDataTypeEnum.Categoria,
                (int)MasterDataTypeEnum.TipoTecnologia,
                (int)MasterDataTypeEnum.NivelTecnologia,
                (int)MasterDataTypeEnum.OrigenCv,
                (int)MasterDataTypeEnum.FuenteReclutamiento,
                (int)MasterDataTypeEnum.TipoModulo,
                (int)MasterDataTypeEnum.TipoIdentificacion,
                (int)MasterDataTypeEnum.Idioma,
                (int)MasterDataTypeEnum.NivelIdioma
            };

            var response = _maestroService.GetDatosMaestroByTipoId(tipoMaestroId);

            if(model.IdiomaCandidatoViewModel == null){
                model.IdiomaCandidatoViewModel = new List<CreateEditRowIdiomaCandidaturaViewModel>();
            }
            if (model.ExpCandidatoViewModel == null) {
                model.ExpCandidatoViewModel = new List<Recruiting.Application.Candidaturas.ViewModels.CreateEditRowExperienciaCandidatoViewModel>();
            }
            
            model.CategoriaList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.Categoria);
            model.TecnologiaList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.TipoTecnologia);
            model.OrigenCvList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.OrigenCv);
            model.FuenteReclutamientoList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.FuenteReclutamiento);
            model.ModuloList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.TipoModulo);
            model.TipoIdentificacionList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.TipoIdentificacion);
            model.IdiomaList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.Idioma);
            model.NivelIdiomaList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.NivelIdioma);
            model.TipoTecnologiaList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.TipoTecnologia);
            model.NivelExpList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.NivelTecnologia);
            model.ExperienciaList = ControllerHelper.GenerateElements(MIN_PTUNTOS_EXP, MAX_PTUNTOS_EXP);

            return model;
        }

        private AgendarPrimeraEntrevistaViewModel GenerateViewElementsAgendarPrimeraEntrevista(AgendarPrimeraEntrevistaViewModel model, int id)
        {
            int[] tipoMaestroId =
           {
                (int)MasterDataTypeEnum.TipoSubEntrevista
            };
            var responseDatosMaestro = _maestroService.GetDatosMaestroByTipoId(tipoMaestroId);
            var candidato = _candidaturaService.GetCandidatoByCandidatura(id).CreateEditCandidatoViewModel;
            model.TipoSubEntrevistaList = ControllerHelper.GenerateElements(responseDatosMaestro, MasterDataTypeEnum.TipoSubEntrevista);
            model.AccessAgendar1 = "AgendarPrimeraEntrevista.";
            model.AccessEtapa = (int)TipoEtapaCandidaturaEnum.AgendarEntrevistas;
            model.NombreCandidato = string.Concat(candidato.Nombres, " ", candidato.Apellidos);

            return model;
        }

        private PrimeraEntrevistaViewModel GenerateViewElementsCompletarPrimeraEntrevista(PrimeraEntrevistaViewModel model, int id)
        {
            int[] tipoMaestroId =
            {
                (int)MasterDataTypeEnum.TipoSubEntrevista,
                (int)MasterDataTypeEnum.Categoria,
                (int)MasterDataTypeEnum.Incorporacion,
                (int)MasterDataTypeEnum.MotivoDescarte,
                (int)MasterDataTypeEnum.EstadosFeedback



            };
            var responseDatosMaestro = _maestroService.GetDatosMaestroByTipoId(tipoMaestroId);
            var candidato = _candidaturaService.GetCandidatoByCandidatura(id).CreateEditCandidatoViewModel;
            model.AgendarPrimeraEntrevista.TipoSubEntrevistaList = ControllerHelper.GenerateElements(responseDatosMaestro, MasterDataTypeEnum.TipoSubEntrevista);
            model.RangoSalarialesyDisponibilidades.CategoriaList = ControllerHelper.GenerateElements(responseDatosMaestro, MasterDataTypeEnum.Categoria);
            model.RangoSalarialesyDisponibilidades.IncorporacionList = ControllerHelper.GenerateElements(responseDatosMaestro, MasterDataTypeEnum.Incorporacion);
            model.ResultadoPrimeraEntrevista.MotivoDescarteList = ControllerHelper.GenerateElements(responseDatosMaestro, MasterDataTypeEnum.MotivoDescarte);
           

            model.AgendarPrimeraEntrevista.AccessAgendar1 = "AgendarPrimeraEntrevista.AgendarPrimeraEntrevista.";
            model.RangoSalarialesyDisponibilidades.AccessRango = "RangoSalarialesyDisponibilidades.";
            model.ResultadoPrimeraEntrevista.AccessResultado = "ResultadoPrimeraEntrevista.";
            model.NombreCandidato = string.Concat(candidato.Nombres, " ", candidato.Apellidos);

            return model;
        }

        

        private AgendarSegundaEntrevistaViewModel GenerateViewElementsAgendarSegundaEntrevista(AgendarSegundaEntrevistaViewModel model, int id)
        {
            int[] tipoMaestroId =
           {
                (int)MasterDataTypeEnum.TipoSubEntrevista
            };
            var responseDatosMaestro = _maestroService.GetDatosMaestroByTipoId(tipoMaestroId);
            var candidato = _candidaturaService.GetCandidatoByCandidatura(id).CreateEditCandidatoViewModel;
            model.TipoSubEntrevistaList = ControllerHelper.GenerateElements(responseDatosMaestro, MasterDataTypeEnum.TipoSubEntrevista);

            model.AccessEtapa = (int)TipoEtapaCandidaturaEnum.AgendarSegundaEntrevista;
            model.AccessAgendar2 = "AgendarSegundaEntrevista.";
            model.AgendarSegundaEntrevista.NombreCandidato = string.Concat(candidato.Nombres, " ", candidato.Apellidos);

            return model;
        }

        private SegundaEntrevistaViewModel GenerateViewElementsCompletarSegundaEntrevista(SegundaEntrevistaViewModel model, int id)
        {
            int[] tipoMaestroId =
          {
                (int)MasterDataTypeEnum.TipoSubEntrevista,
                (int)MasterDataTypeEnum.Categoria,
                (int)MasterDataTypeEnum.Incorporacion,
                (int)MasterDataTypeEnum.MotivoDescarte
            };
            var responseDatosMaestro = _maestroService.GetDatosMaestroByTipoId(tipoMaestroId);
            var candidato = _candidaturaService.GetCandidatoByCandidatura(id).CreateEditCandidatoViewModel;
            model.AgendarSegundaEntrevista.TipoSubEntrevistaList = ControllerHelper.GenerateElements(responseDatosMaestro, MasterDataTypeEnum.TipoSubEntrevista);
            model.RangoSalarialesyDisponibilidades.CategoriaList = ControllerHelper.GenerateElements(responseDatosMaestro, MasterDataTypeEnum.Categoria);
            model.RangoSalarialesyDisponibilidades.IncorporacionList = ControllerHelper.GenerateElements(responseDatosMaestro, MasterDataTypeEnum.Incorporacion);
            model.ResultadoSegundaEntrevista.MotivoDescarteList = ControllerHelper.GenerateElements(responseDatosMaestro, MasterDataTypeEnum.MotivoDescarte);

            model.AgendarSegundaEntrevista.AccessAgendar2 = "AgendarSegundaEntrevista.AgendarSegundaEntrevista.";
            model.RangoSalarialesyDisponibilidades.AccessRango = "RangoSalarialesyDisponibilidades.";
            model.ResultadoSegundaEntrevista.AccessResultado2 = "ResultadoSegundaEntrevista.";
            model.AgendarSegundaEntrevista.AgendarSegundaEntrevista.NombreCandidato = string.Concat(candidato.Nombres, " ", candidato.Apellidos);

            return model;
        }

        private AgendarCartaOfertaViewModel GenerateViewElementsAgendarCartaOferta(AgendarCartaOfertaViewModel model)
        {
            var candidato = _candidaturaService.GetCandidatoByCandidatura(model.AgendarCartaOferta.CandidaturaId).CreateEditCandidatoViewModel;
            model.AgendarCartaOferta.AccessAgendarCarta = "AgendarCartaOferta.";
            model.AgendarCartaOferta.AccessEtapa = (int)TipoEtapaCandidaturaEnum.AgendarCartaOferta;
            model.AgendarCartaOferta.NombreCandidato = string.Concat(candidato.Nombres, " ",candidato.Apellidos);

            return model;
        }

        private CompletarCartaOfertaViewModel GenerateViewElementsCompletarCartaOferta(CompletarCartaOfertaViewModel model)
        {
            int[] tipoMaestroId =
            {
                (int)MasterDataTypeEnum.MotivoRechazoCartaOferta,
                (int)MasterDataTypeEnum.Oficina,
                (int)MasterDataTypeEnum.Sector,
                (int)MasterDataTypeEnum.TipoTecnologia,
                (int)MasterDataTypeEnum.TipoServicio,
                (int)MasterDataTypeEnum.Categoria,
                (int)MasterDataTypeEnum.MesesAsignacion,
                (int)MasterDataTypeEnum.TipoContratacion,
                (int)MasterDataTypeEnum.TipoPrevision

            };
            var responseDatosMaestro = _maestroService.GetDatosMaestroByTipoId(tipoMaestroId);
            var candidato = _candidaturaService.GetCandidatoByCandidatura(model.EntregaCartaOfertaViewModel.AgendarCartaOfertaViewModel.AgendarCartaOferta.CandidaturaId).CreateEditCandidatoViewModel;
            model.CompletarCartaOferta.MotivoRechazoCartaOfertaList = ControllerHelper.GenerateElements(responseDatosMaestro, MasterDataTypeEnum.MotivoRechazoCartaOferta);
            model.CompletarCartaOferta.OficinaList = ControllerHelper.GenerateElements(responseDatosMaestro, MasterDataTypeEnum.Oficina);
            model.CompletarCartaOferta.SectorList = ControllerHelper.GenerateElements(responseDatosMaestro, MasterDataTypeEnum.Sector);
            model.CompletarCartaOferta.ClienteList = GenerateClienteElements();
            model.CompletarCartaOferta.ProyectoList = GenerateProyectoElements();
            model.CompletarCartaOferta.TecnologiaList = ControllerHelper.GenerateElements(responseDatosMaestro, MasterDataTypeEnum.TipoTecnologia);
            model.CompletarCartaOferta.ServicioList = ControllerHelper.GenerateElements(responseDatosMaestro, MasterDataTypeEnum.TipoServicio);
            model.CompletarCartaOferta.CategoriaList = ControllerHelper.GenerateElements(responseDatosMaestro, MasterDataTypeEnum.Categoria);
            model.CompletarCartaOferta.DuracionList = ControllerHelper.GenerateElements(responseDatosMaestro, MasterDataTypeEnum.MesesAsignacion);
            model.CompletarCartaOferta.ContratacionList = ControllerHelper.GenerateElements(responseDatosMaestro, MasterDataTypeEnum.TipoContratacion);
            model.CompletarCartaOferta.PrevisionList = ControllerHelper.GenerateElements(responseDatosMaestro, MasterDataTypeEnum.TipoPrevision);
            model.CompletarCartaOferta.ModuloList = ControllerHelper.GenerateElements(responseDatosMaestro, MasterDataTypeEnum.TipoModulo);

            model.EntregaCartaOfertaViewModel.AgendarCartaOfertaViewModel.AgendarCartaOferta.AccessAgendarCarta = "EntregaCartaOfertaViewModel.AgendarCartaOfertaViewModel.AgendarCartaOferta.";
            model.EntregaCartaOfertaViewModel.EntregaCartaOferta.AccessEntrega = "EntregaCartaOfertaViewModel.EntregaCartaOferta.";
            model.CompletarCartaOferta.AccessCompletar = "CompletarCartaOferta.";
            model.NombreCandidato = string.Concat(candidato.Nombres, " ", candidato.Apellidos);

            return model;
        }

        private CandidaturaViewModel GenerateViewElementsEditExtend(CandidaturaViewModel model)
        {
            //DATOS BASICOS
            model.CandidaturaDatosBasicosViewModel.DatosBasicos = GenerateViewElementsDatosBasicos(model.CandidaturaDatosBasicosViewModel.DatosBasicos);
            model.CandidaturaDatosBasicosViewModel.DatosBasicos.Access = "CandidaturaDatosBasicosViewModel.DatosBasicos.";

            //FILTRADO CV
            model.FiltroCVViewModel.AccessFiltro = "FiltroCVViewModel.";

            //AGENDAR PRIMERA ENTREVISTA
            model.PrimeraEntrevistaViewModel.AccessEtapa = model.CandidaturaDatosBasicosViewModel.DatosBasicos.EtapaCandidaturaId;
            model.PrimeraEntrevistaViewModel.AccessEstado = model.CandidaturaDatosBasicosViewModel.DatosBasicos.EstadoCandidaturaId;

            if (model.PrimeraEntrevistaViewModel.AgendarPrimeraEntrevista != null)
            {
                model.PrimeraEntrevistaViewModel.AgendarPrimeraEntrevista.AccessAgendar1 = "PrimeraEntrevistaViewModel.AgendarPrimeraEntrevista.AgendarPrimeraEntrevista.";
            }

            //COMPLETAR PRIMERA ENTREVISTA

            int[] tipoMaestroIdPrimeraEntrevista =
          {
                (int)MasterDataTypeEnum.Categoria,
                (int)MasterDataTypeEnum.Incorporacion,
                (int)MasterDataTypeEnum.MotivoDescarte,
            };
            var responseDatosMaestroPrimeraEntrevista = _maestroService.GetDatosMaestroByTipoId(tipoMaestroIdPrimeraEntrevista);

            if (model.PrimeraEntrevistaViewModel.RangoSalarialesyDisponibilidades != null)
            {
                model.PrimeraEntrevistaViewModel.RangoSalarialesyDisponibilidades.CategoriaList = ControllerHelper.GenerateElements(responseDatosMaestroPrimeraEntrevista, MasterDataTypeEnum.Categoria);
                model.PrimeraEntrevistaViewModel.RangoSalarialesyDisponibilidades.IncorporacionList = ControllerHelper.GenerateElements(responseDatosMaestroPrimeraEntrevista, MasterDataTypeEnum.Incorporacion);
                model.PrimeraEntrevistaViewModel.RangoSalarialesyDisponibilidades.AccessRango = "PrimeraEntrevistaViewModel.RangoSalarialesyDisponibilidades.";
            }
            if (model.PrimeraEntrevistaViewModel.ResultadoPrimeraEntrevista != null)
            {
                model.PrimeraEntrevistaViewModel.ResultadoPrimeraEntrevista.MotivoDescarteList = ControllerHelper.GenerateElements(responseDatosMaestroPrimeraEntrevista, MasterDataTypeEnum.MotivoDescarte);
                model.PrimeraEntrevistaViewModel.ResultadoPrimeraEntrevista.AccessResultado = "PrimeraEntrevistaViewModel.ResultadoPrimeraEntrevista.";
            }

            //AGENDAR SEGUNDA ENTREVISTA

            if (model.SegundaEntrevistaViewModel != null)
            {
                model.SegundaEntrevistaViewModel.AccessEtapa = model.CandidaturaDatosBasicosViewModel.DatosBasicos.EtapaCandidaturaId;
                model.SegundaEntrevistaViewModel.AccessEstado = model.CandidaturaDatosBasicosViewModel.DatosBasicos.EstadoCandidaturaId;
            }

            if (model.SegundaEntrevistaViewModel.AgendarSegundaEntrevista != null)
            {
                model.SegundaEntrevistaViewModel.AgendarSegundaEntrevista.AccessAgendar2 = "SegundaEntrevistaViewModel.AgendarSegundaEntrevista.AgendarSegundaEntrevista.";
            }


            //COMPLETAR SEGUNDA ENTREVISTA

            int[] tipoMaestroIdSegundaEntrevista =
          {
                (int)MasterDataTypeEnum.Categoria,
                (int)MasterDataTypeEnum.Incorporacion,
                (int)MasterDataTypeEnum.MotivoDescarte,
            };
            var responseDatosMaestroSegundaEntrevista = _maestroService.GetDatosMaestroByTipoId(tipoMaestroIdSegundaEntrevista);

            if (model.SegundaEntrevistaViewModel.RangoSalarialesyDisponibilidades != null)
            {
                model.SegundaEntrevistaViewModel.RangoSalarialesyDisponibilidades.CategoriaList = ControllerHelper.GenerateElements(responseDatosMaestroSegundaEntrevista, MasterDataTypeEnum.Categoria);
                model.SegundaEntrevistaViewModel.RangoSalarialesyDisponibilidades.IncorporacionList = ControllerHelper.GenerateElements(responseDatosMaestroSegundaEntrevista, MasterDataTypeEnum.Incorporacion);
                model.SegundaEntrevistaViewModel.RangoSalarialesyDisponibilidades.AccessRango = "SegundaEntrevistaViewModel.RangoSalarialesyDisponibilidades.";
            }
            if (model.SegundaEntrevistaViewModel.ResultadoSegundaEntrevista != null)
            {
                model.SegundaEntrevistaViewModel.ResultadoSegundaEntrevista.MotivoDescarteList = ControllerHelper.GenerateElements(responseDatosMaestroSegundaEntrevista, MasterDataTypeEnum.MotivoDescarte);
                model.SegundaEntrevistaViewModel.ResultadoSegundaEntrevista.AccessResultado2 = "SegundaEntrevistaViewModel.ResultadoSegundaEntrevista.";
            }

            //AGENDAR CARTA OFERTA

            if (model.CompletarCartaOfertaViewModel != null)
            {
                model.CompletarCartaOfertaViewModel.AccessEtapa = model.CandidaturaDatosBasicosViewModel.DatosBasicos.EtapaCandidaturaId;
            }

            if (model.CompletarCartaOfertaViewModel.EntregaCartaOfertaViewModel.AgendarCartaOfertaViewModel.AgendarCartaOferta != null)
            {
                model.CompletarCartaOfertaViewModel.EntregaCartaOfertaViewModel.AgendarCartaOfertaViewModel.AgendarCartaOferta.AccessAgendarCarta = "CompletarCartaOfertaViewModel.EntregaCartaOfertaViewModel.AgendarCartaOfertaViewModel.AgendarCartaOferta.";
            }

            //ENTREGA CARTA OFERTA
            if (model.CompletarCartaOfertaViewModel.EntregaCartaOfertaViewModel.EntregaCartaOferta != null)
            {
                model.CompletarCartaOfertaViewModel.EntregaCartaOfertaViewModel.EntregaCartaOferta.AccessEntrega = "CompletarCartaOfertaViewModel.EntregaCartaOfertaViewModel.EntregaCartaOferta.";
            }

            //COMPLETAR CARTA OFERTA
            int[] tipoMaestroIdCartaOferta =
            {
                (int)MasterDataTypeEnum.MotivoRechazoCartaOferta,
                (int)MasterDataTypeEnum.TipoTecnologia,
                (int)MasterDataTypeEnum.Categoria
            };
            var responseDatosMaestroCartaOferta = _maestroService.GetDatosMaestroByTipoId(tipoMaestroIdCartaOferta);

            if (model.CompletarCartaOfertaViewModel.CompletarCartaOferta != null)
            {
                model.CompletarCartaOfertaViewModel.CompletarCartaOferta.AccessCompletar = "CompletarCartaOfertaViewModel.CompletarCartaOferta.";
                model.CompletarCartaOfertaViewModel.CompletarCartaOferta.ClienteList = GenerateClienteElements();
                model.CompletarCartaOfertaViewModel.CompletarCartaOferta.ProyectoList = GenerateProyectoElements();
                model.CompletarCartaOfertaViewModel.CompletarCartaOferta.TecnologiaList = ControllerHelper.GenerateElements(responseDatosMaestroCartaOferta, MasterDataTypeEnum.TipoTecnologia);
                model.CompletarCartaOfertaViewModel.CompletarCartaOferta.CategoriaList = ControllerHelper.GenerateElements(responseDatosMaestroCartaOferta, MasterDataTypeEnum.Categoria);
                model.CompletarCartaOfertaViewModel.CompletarCartaOferta.MotivoRechazoCartaOfertaList = ControllerHelper.GenerateElements(responseDatosMaestroCartaOferta, MasterDataTypeEnum.MotivoRechazoCartaOferta);
            }

            //RENUNCIA O DESCARTE

            int[] tipoMaestroIdRenunciaDescarte =
            {
                (int)MasterDataTypeEnum.TipoRenuncia,
                (int)MasterDataTypeEnum.MotivoDescarte
            };
            var responseDatosMaestroRenunciaDescarte = _maestroService.GetDatosMaestroByTipoId(tipoMaestroIdRenunciaDescarte);


            model.MotivoRenunciaList = ControllerHelper.GenerateElements(responseDatosMaestroRenunciaDescarte, MasterDataTypeEnum.TipoRenuncia);
            model.MotivoDescarteList = ControllerHelper.GenerateElements(responseDatosMaestroRenunciaDescarte, MasterDataTypeEnum.MotivoDescarte);

            return model;
        }

        #endregion

        #region GraphMethods


        public JsonResult SendMeetings(SendMeetingViewModel model)
        {

            SendMeetingResponse response = new SendMeetingResponse();
            model.Fecha = DateTime.Parse(model.Fecha.ToUniversalTime().ToString());
            try
            {
                var Servicio = new SendMailsPlaningBatchService(_candidaturaRepository, _candidaturaService, _candidatoService, _maestroService,
                   _bitacoraRepository, _tipoDecisionRepository, _tipoEtapaCandidaturaRepository, _tipoEstadoCandidaturaRepository, _usuarioService);

                var candidato = _candidaturaService.GetCandidatoByCandidatura(model.CandidaturaId).CreateEditCandidatoViewModel;

                var plantillaCorreo = _correoPlantillaService.GetPlantillaIdByNombrePlantilla("Meeting", model.CentroId, model.OficinaId);
                if (!plantillaCorreo.IsValid)
                {
                    response.IsValid = false;
                    response.ErrorMessage = "No se ha encontrado la plantilla para enviar la meeting";
                    return Json(response, JsonRequestBehavior.AllowGet);

                }
                var correo = _correoPlantillaService.GetPlantillaCorreoById(plantillaCorreo.PlantillaId);
                if (!correo.IsValid)
                {
                    response.IsValid = false;
                    response.ErrorMessage = "No se ha encontrado la plantilla para enviar la meeting";
                    return Json(response, JsonRequestBehavior.AllowGet);
                }

                var tokenId = _centroService.GetTokenIdByCentroId(model.CentroId).tokenId;
                var token = _graphService.GetTokenById(tokenId);

                List<string> dest = new List<string>();
                var entrevistadorMail = _usuarioService.GetUsuarioById(model.EntrevistadorId).UsuarioViewModel.Email;

                if(model.SendMeetingSubEntrevistas != null)
                {
                    foreach (var lista in model.SendMeetingSubEntrevistas)
                    {
                        var subEntrevistadorMail = _usuarioService.GetUsuarioById(lista.EntrevistadorId).UsuarioViewModel.Email;
                        if (!dest.Contains(subEntrevistadorMail))
                        {
                            dest.Add(subEntrevistadorMail);
                        }
                    }
                }
                
                var UsuarioRolPermisoViewModel = (UsuarioRolPermisoViewModel)HttpContext.Session["Usuario"];
                var organizadorMail = UsuarioRolPermisoViewModel.Email;


                var candidatura = _candidaturaService.GetCandidaturaById(model.CandidaturaId);
                var asunto = correo.correoPlantilla.NombrePlantilla;

                if (candidatura.IsValid)
                {
                    switch (candidatura.CandidaturaViewModel.CandidaturaDatosBasicosViewModel.DatosBasicos.EstadoCandidaturaId)
                    {
                        case (int)TipoEstadoCandidaturaEnum.Entrevista:
                            {
                                asunto = "1ª Entrevista ";
                                break;
                            }
                        case (int)TipoEstadoCandidaturaEnum.SegundaEntrevista:
                            {
                                asunto = "Entrevista Complementaria ";
                                break;
                            }
                        case (int)TipoEstadoCandidaturaEnum.CartaOferta:
                            {
                                asunto = "Carta Oferta ";
                                break;
                            }
                    }
                }

                var PresencialTextPrincipal = "";
                if (model.Presencial)
                {
                    PresencialTextPrincipal = "Presencial";
                }
                else
                {
                    PresencialTextPrincipal = "No presencial";
                }

                var nombreCandidato = string.Concat(candidato.Nombres, " ", candidato.Apellidos);
                asunto = string.Concat(asunto, " ", PresencialTextPrincipal, " ", nombreCandidato);

                if (model.SendMeetingSubEntrevistas != null)
                {
                    var mensaje = "<table style=\"padding: 20px; border: 2px solid #9aad04; border-radius: 2px; width: 700px; height: 100px;\">" +
                        "<tr><td style=\"padding: 10px; border-bottom-style:solid; border-bottom-color:#9aad04; width:200px; height:50px;\">" + "<b>" + "SubEntrevistas" + "</b>" +
                            "</td><td></td><td></td><td></td></tr>";
                    foreach (var lista in model.SendMeetingSubEntrevistas)
                    {
                        var PresencialText = "";
                        if (lista.Presencial)
                        {
                            PresencialText = "Sí";
                        }
                        else
                        {
                            PresencialText = "No";
                        }                        

                        var tipoSubEntrevistaText = _maestroRepository.GetOne(x => x.MaestroId == lista.TipoSubEntrevista).Nombre;

                        var fila = "<tr><td style=\"padding: 10px; width: 200px; height: 50px; \">" + "Entrevistador: " + lista.Entrevistador +
                                   "</td><td style=\"padding: 10px; width: 200px; height: 50px; \">" + "Tipo: " + tipoSubEntrevistaText +
                                   "</td><td style=\"padding: 10px; width: 200px; height: 50px; \">" + "Presencial: " + PresencialText +
                                   "</td><td style=\"padding: 10px; width: 200px; height: 50px; \">" + "Fecha: " + lista.Fecha + "</td></tr>";
                        mensaje = String.Concat(mensaje, fila);
                    }

                    mensaje += "</table>";

                    model.MensajeSubEntrevistas = mensaje;

                }


                //Descomentar para que envie CV como adjunto, pero no aparece en outlook como meeting sino como mensaje normal.

                var responseCV = _candidaturaService.DownloadCV(model.CandidaturaId);
                byte[] byteCV = null;
                if(responseCV.UrlCV != null)
                {
                    var rutaReal = System.IO.Path.Combine(responseCV.UrlCV, responseCV.CandidaturaId.ToString());
                    rutaReal = rutaReal + "\\" + responseCV.NombreCV;
                    byteCV = new System.Net.WebClient().DownloadData(rutaReal);

                }

                if (!dest.Contains(entrevistadorMail))
                {
                    dest.Add(entrevistadorMail);
                }

                if (!dest.Contains(organizadorMail))
                {
                    dest.Add(organizadorMail);
                }

                if (!dest.Contains(entrevistadorMail))
                {
                    dest.Add(entrevistadorMail);
                }

                if (!dest.Contains(organizadorMail))
                {
                    dest.Add(organizadorMail);
                }

                Servicio.EnviarNotificacionesCandidaturasMeeting(model, candidato, asunto, dest, token.cuentaToken.Email, byteCV, responseCV.NombreCV);

                if (!dest.Contains(model.EmailSala))
                {
                    dest.Add(model.EmailSala);
                }

                EventoRowViewModel evento = new EventoRowViewModel()
                {
                    Asunto = asunto,
                    Body = correo.correoPlantilla.TextoPlantilla,
                    Destinatarios = dest,
                    Inicio = model.Fecha,
                    Fin = model.Fecha.AddHours(1),
                    identificador = Guid.NewGuid(),
                    From = token.cuentaToken.Email,
                    //attachment = bytecv,
                    //nombreAttachment = responseCV.NombreCV

                    //Attachment = Imagen,
                };


                _eventosService.EnviarCitas(evento);
                response.IsValid = true;
            }
            catch (Exception e)
            {
                response.IsValid = false;
                response.ErrorMessage = e.Message;

            }
            return Json(response, JsonRequestBehavior.AllowGet);

        }

        public string GetBodyMeeting(int plantillaId, string textoPlantilla)
        {
            CorreoPlantillaVariable cpv = new CorreoPlantillaVariable()
            {
                PlantillaId = plantillaId,
            };
            SendMailsPlaningBatchService sendmails = new SendMailsPlaningBatchService(_candidaturaRepository, _candidaturaService, _candidatoService, _maestroService, _bitacoraRepository, _tipoDecisionRepository, _tipoEtapaCandidaturaRepository, _tipoEstadoCandidaturaRepository, _usuarioService);

            var responseRemitente = _correoPlantillaVariableService.GetValorDefectoNombreVariablePlantillaCorreo(plantillaId, NombresVariablesPlantillaCorreoEnum.Remitente.ToString());
            var responseImagenCabecera = _correoPlantillaVariableService.GetValorDefectoNombreVariablePlantillaCorreo(plantillaId, NombresVariablesPlantillaCorreoEnum.LogoCabecera.ToString());
            var responseAsunto = _correoPlantillaVariableService.GetValorDefectoNombreVariablePlantillaCorreo(plantillaId, NombresVariablesPlantillaCorreoEnum.Asunto.ToString());
            var responseImagenFirma = _correoPlantillaVariableService.GetValorDefectoNombreVariablePlantillaCorreo(plantillaId, NombresVariablesPlantillaCorreoEnum.imagenFirma.ToString());         
            var cr = CorreoPlantillaVariableMapper.ConvertToCorreoPlantillaVariableRowViewModel(cpv, responseAsunto.VarlorDefecto, responseRemitente.VarlorDefecto, "", responseImagenFirma.VarlorDefecto, responseImagenCabecera.VarlorDefecto, "", "", "", "", "", "", "", null, "",0, "", "", "");
            string body = sendmails.GetBodyMail(textoPlantilla, cr);

            return body;
        }

        #endregion

        #region GenerarCartaOferta

        public ActionResult ElegirOficinasCartaOferta(int candidaturaId)
        {
            var response = new GetDropdownOficinaCartaOfertaResponse();

            int Centroid = _candidaturaService.GetCentroCandidatura(candidaturaId).CentroId;
            
            List<SelectListItem> oficinas = new List<SelectListItem>();

            var responseOicinas = _oficinaService.GetOficinasByCentro(Centroid);

            if (responseOicinas.IsValid)
            {             

                foreach (var oficina in responseOicinas.ListaOficinasIdNombre)
                {
                    var oficinaAñadir = new SelectListItem()
                    {
                        Text = oficina.Text,
                        Value = oficina.Value
                    };
                    oficinas.Add(oficinaAñadir);
                }

                response.IsValid = true;
                response.oficinas = oficinas;
            }
            else
            {
                response.IsValid = false;
            }

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ElegirCartaOferta (int candidaturaId)
        {
            var response = new GetDropdownCartaOfertaResponse();

            int Centroid = _candidaturaService.GetCentroCandidatura(candidaturaId).CentroId;

            var ServicioCorreos = new SendMailsPlaningBatchService(_candidaturaRepository, _candidaturaService, _candidatoService, _maestroService, _bitacoraRepository,
                _tipoDecisionRepository, _tipoEtapaCandidaturaRepository, _tipoEstadoCandidaturaRepository, _usuarioService);

            List<string> nombresCO = new List<string>();
            nombresCO.Add("CO Junior En Practicas");       
            nombresCO.Add("CO Junior Indefinido");
            nombresCO.Add("CO Perfiles Con Experiencia");

            List<SelectListItem> dropdown = new List<SelectListItem>();

            foreach (var nombre in nombresCO)
            {
                var responseCO = ServicioCorreos.GetPlantillaCorreoByNombreCentroId(nombre.Replace(" ",""), Centroid);

                if (responseCO.IsValid)
                {
                    var plantilla = new SelectListItem()
                    {
                        Text = nombre,
                        Value = responseCO.correoPlantilla.PlantillaId.ToString()
                    };
                    dropdown.Add(plantilla);
                }
            }

            if (dropdown.Count != 0)
            {
                response.IsValid = true;
                response.plantillas = dropdown;
            }
            else
            {
                response.IsValid = false;
            }

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [ValidateInput(false)]        
        public ActionResult UploadCartaOfertaGenerada(int candidaturaId, int plantillaId)
        {
            string nombreEntregaCarta = string.Empty;
            string cargoEntregaCarta = string.Empty;
            string telefono = string.Empty;
            string telefonoContratacion = string.Empty;
            string mailTo = string.Empty;
            string atencionTelefonica = string.Empty;
            string ayudaComedor = string.Empty;
            string fax = string.Empty;
                        
            var ServicioCorreos = new SendMailsPlaningBatchService(_candidaturaRepository, _candidaturaService, _candidatoService, _maestroService, _bitacoraRepository,
                _tipoDecisionRepository, _tipoEtapaCandidaturaRepository, _tipoEstadoCandidaturaRepository, _usuarioService);

            var responseCO = ServicioCorreos.GetPlantillaCorreoByPlantillaId(plantillaId);

            if (responseCO.IsValid)
            {
                nombreEntregaCarta = ServicioCorreos.GetValorDefectoNombreVariablePlantillaCorreo(responseCO.correoPlantilla.PlantillaId, "NombreEntregaCarta").VarlorDefecto;
                cargoEntregaCarta = ServicioCorreos.GetValorDefectoNombreVariablePlantillaCorreo(responseCO.correoPlantilla.PlantillaId, "CargoEntregaCarta").VarlorDefecto;
                telefono = ServicioCorreos.GetValorDefectoNombreVariablePlantillaCorreo(responseCO.correoPlantilla.PlantillaId, "Telefono").VarlorDefecto;
                telefonoContratacion = ServicioCorreos.GetValorDefectoNombreVariablePlantillaCorreo(responseCO.correoPlantilla.PlantillaId, "Telefono Contratacion").VarlorDefecto;
                mailTo = ServicioCorreos.GetValorDefectoNombreVariablePlantillaCorreo(responseCO.correoPlantilla.PlantillaId, "MailTo").VarlorDefecto;
                atencionTelefonica = ServicioCorreos.GetValorDefectoNombreVariablePlantillaCorreo(responseCO.correoPlantilla.PlantillaId, "AtencionTelefonica").VarlorDefecto;
                ayudaComedor = ServicioCorreos.GetValorDefectoNombreVariablePlantillaCorreo(responseCO.correoPlantilla.PlantillaId, "AyudaComedor").VarlorDefecto;
                fax = ServicioCorreos.GetValorDefectoNombreVariablePlantillaCorreo(responseCO.correoPlantilla.PlantillaId, "Fax").VarlorDefecto;



                GetCandidaturaToGeneratePDFbyIdResponse response = _candidaturaService.GetCandidaturaToGeneratePDFbyId(candidaturaId, nombreEntregaCarta,
                    cargoEntregaCarta, telefono, telefonoContratacion, mailTo, atencionTelefonica, ayudaComedor, fax);

                if (response.IsValid)
                {

                    byte[] cartaOfertaGenerada = PdfHelper.GenerarCartaOfertaForCartaOfertaPdfViewModel("Carta Oferta", "Everis",
                        response.CartaOfertaPdfViewModel, responseCO.correoPlantilla.TextoPlantilla);
                    UploadCartaOfertaGeneradaResponse responseUpload = _candidaturaService.UploadCartaOfertaGenerada(cartaOfertaGenerada, response.CartaOfertaPdfViewModel.CandidaturaId);
                    return Json(responseUpload, JsonRequestBehavior.AllowGet);
                }
                return Json(response, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(responseCO, JsonRequestBehavior.AllowGet);
            }

        }

        [ValidateInput(false)]
        public ActionResult UploadCartaOfertaGenerada1(int candidaturaId)
        {
            string nombreEntregaCarta = string.Empty;
            string cargoEntregaCarta = string.Empty;
            string telefono = string.Empty;
            string telefonoContratacion = string.Empty;
            string mailTo = string.Empty;
            string atencionTelefonica = string.Empty;
            string ayudaComedor = string.Empty;
            string fax = string.Empty;

            int Centroid = _candidaturaService.GetCentroCandidatura(candidaturaId).CentroId;
            var ServicioCorreos = new SendMailsPlaningBatchService(_candidaturaRepository, _candidaturaService, _candidatoService, _maestroService, _bitacoraRepository,
                _tipoDecisionRepository, _tipoEtapaCandidaturaRepository, _tipoEstadoCandidaturaRepository, _usuarioService);

            var responseCO = ServicioCorreos.GetPlantillaCorreoByNombreCentroId("CartaOferta", Centroid);

            if (responseCO.IsValid)
            {
                nombreEntregaCarta = ServicioCorreos.GetValorDefectoNombreVariablePlantillaCorreo(responseCO.correoPlantilla.PlantillaId, "NombreEntregaCarta").VarlorDefecto;
                cargoEntregaCarta = ServicioCorreos.GetValorDefectoNombreVariablePlantillaCorreo(responseCO.correoPlantilla.PlantillaId, "CargoEntregaCarta").VarlorDefecto;
                telefono = ServicioCorreos.GetValorDefectoNombreVariablePlantillaCorreo(responseCO.correoPlantilla.PlantillaId, "Telefono").VarlorDefecto;
                telefonoContratacion = ServicioCorreos.GetValorDefectoNombreVariablePlantillaCorreo(responseCO.correoPlantilla.PlantillaId, "Telefono Contratacion").VarlorDefecto;
                mailTo = ServicioCorreos.GetValorDefectoNombreVariablePlantillaCorreo(responseCO.correoPlantilla.PlantillaId, "MailTo").VarlorDefecto;
                atencionTelefonica = ServicioCorreos.GetValorDefectoNombreVariablePlantillaCorreo(responseCO.correoPlantilla.PlantillaId, "AtencionTelefonica").VarlorDefecto;
                ayudaComedor = ServicioCorreos.GetValorDefectoNombreVariablePlantillaCorreo(responseCO.correoPlantilla.PlantillaId, "AyudaComedor").VarlorDefecto;
                fax = ServicioCorreos.GetValorDefectoNombreVariablePlantillaCorreo(responseCO.correoPlantilla.PlantillaId, "Fax").VarlorDefecto;



                GetCandidaturaToGeneratePDFbyIdResponse response = _candidaturaService.GetCandidaturaToGeneratePDFbyId(candidaturaId, nombreEntregaCarta,
                    cargoEntregaCarta, telefono, telefonoContratacion, mailTo, atencionTelefonica, ayudaComedor, fax);

                if (response.IsValid)
                {

                    byte[] cartaOfertaGenerada = PdfHelper.GenerarCartaOfertaForCartaOfertaPdfViewModel("Carta Oferta", "Everis",
                        response.CartaOfertaPdfViewModel, responseCO.correoPlantilla.TextoPlantilla);
                    UploadCartaOfertaGeneradaResponse responseUpload = _candidaturaService.UploadCartaOfertaGenerada(cartaOfertaGenerada, response.CartaOfertaPdfViewModel.CandidaturaId);
                    return Json(responseUpload, JsonRequestBehavior.AllowGet);
                }
                return Json(response, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(responseCO, JsonRequestBehavior.AllowGet);
            }

        }

        [ValidateInput(false)]
        public ActionResult UploadCartaOfertaGeneradaIndex(int candidaturaId, int plantillaId)
        {
            string nombreEntregaCarta = string.Empty;
            string cargoEntregaCarta = string.Empty;
            string telefono = string.Empty;
            string mailTo = string.Empty;
            string atencionTelefonica = string.Empty;
            string ayudaComedor = string.Empty;
            string fax = string.Empty;

            var ServicioCorreos = new SendMailsPlaningBatchService(_candidaturaRepository, _candidaturaService, _candidatoService, _maestroService, _bitacoraRepository,
                _tipoDecisionRepository, _tipoEtapaCandidaturaRepository, _tipoEstadoCandidaturaRepository, _usuarioService);

            var responseCO = ServicioCorreos.GetPlantillaCorreoByPlantillaId(plantillaId);

            if (responseCO.IsValid)
            {
                nombreEntregaCarta = ServicioCorreos.GetValorDefectoNombreVariablePlantillaCorreo(responseCO.correoPlantilla.PlantillaId, "NombreEntregaCarta").VarlorDefecto;
                cargoEntregaCarta = ServicioCorreos.GetValorDefectoNombreVariablePlantillaCorreo(responseCO.correoPlantilla.PlantillaId, "CargoEntregaCarta").VarlorDefecto;
                telefono = ServicioCorreos.GetValorDefectoNombreVariablePlantillaCorreo(responseCO.correoPlantilla.PlantillaId, "Telefono").VarlorDefecto;
                mailTo = ServicioCorreos.GetValorDefectoNombreVariablePlantillaCorreo(responseCO.correoPlantilla.PlantillaId, "MailTo").VarlorDefecto;
                atencionTelefonica = ServicioCorreos.GetValorDefectoNombreVariablePlantillaCorreo(responseCO.correoPlantilla.PlantillaId, "AtencionTelefonica").VarlorDefecto;
                ayudaComedor = ServicioCorreos.GetValorDefectoNombreVariablePlantillaCorreo(responseCO.correoPlantilla.PlantillaId, "AyudaComedor").VarlorDefecto;
                fax = ServicioCorreos.GetValorDefectoNombreVariablePlantillaCorreo(responseCO.correoPlantilla.PlantillaId, "Fax").VarlorDefecto;



                GetCandidaturaToGeneratePDFbyIdResponse response = _candidaturaService.GetCandidaturaToGeneratePDFbyIdIndex(candidaturaId, nombreEntregaCarta,
                    cargoEntregaCarta, telefono, mailTo, atencionTelefonica, ayudaComedor, fax);

                if (response.IsValid)
                {

                    byte[] cartaOfertaGenerada = PdfHelper.GenerarCartaOfertaForCartaOfertaPdfViewModel("Carta Oferta", "Everis",
                        response.CartaOfertaPdfViewModel, responseCO.correoPlantilla.TextoPlantilla);
                    var responseUpload = new DownloadCartaGeneradaResponse();
                    
                    if(cartaOfertaGenerada != null)
                    {
                        responseUpload.CartaOfertaGenerada = cartaOfertaGenerada;
                        responseUpload.IsValid = true;
                    }
                    else
                    {
                        responseUpload.IsValid = false;
                    }

                    if (responseUpload.IsValid)
                    {
                        string filename = string.Format("CartaOfertaGenerada_{0}", DateTime.Now.ToShortDateString() + ".pdf");
                        var contentType = GetContentType(filename);

                        Response.ClearContent();
                        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", filename));
                        Response.ContentType = contentType;

                        Response.BinaryWrite(responseUpload.CartaOfertaGenerada.ToArray());
                        Response.Flush();
                        Response.End();

                        return Json(responseUpload, JsonRequestBehavior.AllowGet);
                    }                    
                }
                return Json(response, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(responseCO, JsonRequestBehavior.AllowGet);
            }

        }

        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.VerCandidatura)]
        public ActionResult DownloadCartaOferta(int candidaturaId)
        {
            try
            {
                var respoCartaOfertaId = _candidaturaService.GetCartaOfertaIdByCandidaturaId(candidaturaId);
                if (respoCartaOfertaId.IsValid)
                {
                    var response = _candidaturaService.DownloadCartaOfertaGenerada(respoCartaOfertaId.CartaOfertaId);
                    if (response.IsValid)
                    {
                        string filename = string.Format("CartaOfertaGenerada_{0}", DateTime.Now.ToShortDateString() + ".pdf");
                        var contentType = GetContentType(filename);

                        Response.ClearContent();
                        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", filename));
                        Response.ContentType = contentType;

                        Response.BinaryWrite(response.CartaOfertaGenerada.ToArray());
                        Response.Flush();
                        Response.End();

                        return Json(response, JsonRequestBehavior.AllowGet);
                    }
                }

                return null;
            }
            catch
            {
                return null;
            }
        }

        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.VerCandidatura)]
        public bool ComprobacionExisteCartaOferta(int candidaturaId)
        {
            try
            {
                var respoCartaOfertaId = _candidaturaService.GetCartaOfertaIdByCandidaturaId(candidaturaId);
                if (respoCartaOfertaId.IsValid)
                {
                    return true;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }

        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.AdministrarRoles)]
        public ActionResult enviarCorreosDePrueba(int? userId = null)
        {
            EnviarCorreosDePrueba(userId);
            return RedirectToAction("Index", "Dashboard");
        }

        private void EnviarCorreosDePrueba(int? userId = null)
        {
            int idUsuario;
            if (userId != null)
            {
                idUsuario = Convert.ToInt32(userId);
            }
            else
            {
                var UsuarioRolPermisoViewModel = (UsuarioRolPermisoViewModel)HttpContext.Session["Usuario"];
                idUsuario = UsuarioRolPermisoViewModel.UsuarioId;
            }

            System.Collections.Specialized.NameValueCollection DiccEstadoCandidaturaPlantillaCorreo = (System.Collections.Specialized.NameValueCollection)ConfigurationManager.GetSection("DiccEstadoCandidaturaPlantillaCorreo");
            System.Collections.Specialized.NameValueCollection DiccAvisoEntrevistaProgramada = (System.Collections.Specialized.NameValueCollection)ConfigurationManager.GetSection("DiccAvisoEntrevistaProgramada");
            System.Collections.Specialized.NameValueCollection DiccConfiguracionServidorCorreo = (System.Collections.Specialized.NameValueCollection)ConfigurationManager.GetSection("DiccConfiguracionServidorCorreo");


            var Servicio = new SendMailsPlaningBatchService(_candidaturaRepository, _candidaturaService, _candidatoService, _maestroService,
                   _bitacoraRepository, _tipoDecisionRepository, _tipoEtapaCandidaturaRepository, _tipoEstadoCandidaturaRepository, _usuarioService);
            Servicio.EnviarAvisosEntrevistas(DiccAvisoEntrevistaProgramada, DiccConfiguracionServidorCorreo, Convert.ToInt32(ConfigurationManager.AppSettings.Get("diasAviso")),
                idUsuario, Resources.urlRecruiting);

            Servicio.EnviarEmail(DiccEstadoCandidaturaPlantillaCorreo, DiccConfiguracionServidorCorreo, idUsuario);
                        
        }

        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.AdministrarRoles)]
        public ActionResult enviarCorreosRecordatorioFeedback(int? userId = null)
        {
            EnviarCorreosRecordatorioFeedbacks(userId);
            return RedirectToAction("Index", "Dashboard");
        }

        private void EnviarCorreosRecordatorioFeedbacks(int? userId = null)
        {

            var usuViewModel= new UsuarioRolPermisoViewModel();

            if (userId != null)
            {
                _usuarioRepository.GetOne(x => x.UsuarioId == userId.Value);
            }
            else
            {
                usuViewModel = (UsuarioRolPermisoViewModel)HttpContext.Session["Usuario"];
            }

            System.Collections.Specialized.NameValueCollection DiccionarioFinalizarFeedback = (System.Collections.Specialized.NameValueCollection)ConfigurationManager.GetSection("DiccionarioFinalizarFeedback");
            System.Collections.Specialized.NameValueCollection DiccConfiguracionServidorCorreo = (System.Collections.Specialized.NameValueCollection)ConfigurationManager.GetSection("DiccConfiguracionServidorCorreo");

            var Servicio = new SendMailsPlaningBatchService(_candidaturaRepository, _candidaturaService, _candidatoService, _maestroService,
                   _bitacoraRepository, _tipoDecisionRepository, _tipoEtapaCandidaturaRepository, _tipoEstadoCandidaturaRepository, _usuarioService);

            Servicio.EnviarEmailFinalizarFeedbacks(DiccionarioFinalizarFeedback, DiccConfiguracionServidorCorreo, usuViewModel);     

        }


        #endregion


        #region CandidaturaOferta

        public virtual JsonResult LoadOfertas([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)

        {
            var request = requestModel.ConvertToDataTableRequestViewModel();

            var UsuarioRolPermisoViewModel = (UsuarioRolPermisoViewModel)HttpContext.Session["Usuario"];
            var centroId = UsuarioRolPermisoViewModel.CentroIdUsuario;

            if (centroId != null)
            {
                request.CustomFilters.Add("CentroId", centroId.ToString());
            }


            var response = _candidaturaOfertaService.GetOfertas(request);

            if (!response.IsValid)
            {
                return null;
            }

            var result = from c in response.OfertaRowViewModel
                         select new object[]
            {
                c.NombreOferta,
                this.RenderRazorViewToString("Table/actionColumnOferta", c),
                c.OfertaId
            };
            
            var jsonResponse = new DataTablesResponse(requestModel.Draw, result, response.TotalElementos, response.TotalElementos);
            return Json(jsonResponse, JsonRequestBehavior.AllowGet);
        }

        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.AniadirEliminarCandidatura)]
        public ActionResult CrearEditOferta(int IdOferta, string NombreOferta)
        {
            var parameters = new RouteValueDictionary();
            SaveOfertaResponse response = null;

            var UsuarioRolPermisoViewModel = (UsuarioRolPermisoViewModel)HttpContext.Session["Usuario"];
            var centroId = UsuarioRolPermisoViewModel.CentroIdUsuario == null ? 0 : UsuarioRolPermisoViewModel.CentroIdUsuario;

            response = _candidaturaOfertaService.SaveOferta(IdOferta, NombreOferta, (int)centroId);

            if (!response.IsValid)
            {
                parameters.Add("errorMessage", response.ErrorMessage);
            }

            return RedirectToAction("Create", "Candidaturas", parameters);
        }

        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.AniadirEliminarCandidatura)]
        [ValidateInput(false)]
        [HttpPost]
        public JsonResult DeleteOferta(int OfertaId)
        {
            var response = new JsonResult();
            response.Data = _candidaturaOfertaService.RemoveOferta(OfertaId);
            return response;

        }

        [HttpPost]
        public JsonResult ComprobarOfertaUsada(int OfertaId)
        {
            var response = _candidaturaOfertaService.SearchOfertaUsada(OfertaId);
            return Json(response, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult ComprobarExisteOferta(string NombreOferta)
        {
            var respose = new JsonResult();
            if (!string.IsNullOrEmpty(NombreOferta))
            {
                var UsuarioRolPermisoViewModel = (UsuarioRolPermisoViewModel)HttpContext.Session["Usuario"];
                var centroId = UsuarioRolPermisoViewModel.CentroIdUsuario == null ? 0 : UsuarioRolPermisoViewModel.CentroIdUsuario;

                var response = _candidaturaOfertaService.SearchOfertaByNombreCentroId(NombreOferta, (int)centroId);
                if (!response.IsValid)
                {
                    respose.Data = response.ErrorMessage;
                    return respose;
                }
                else
                {
                    return Json(false);
                }
            }
            else
            {
                return Json(false);
            }
        }

        [HttpPost]
        public JsonResult GetOfertasByNombre(string textSearch)
        {
            var UsuarioRolPermisoViewModel = (UsuarioRolPermisoViewModel)HttpContext.Session["Usuario"];
            var centroId = UsuarioRolPermisoViewModel.CentroIdUsuario;
            var response = _candidaturaOfertaService.GetOfertasByNombre(textSearch, centroId);
            var isValid = response.IsValid;
            var errorMessage = response.ErrorMessage;
            var ofertas = response.Ofertas.Select(x => new SelectListItem()
            {
                Text = x.NombreOferta,
                Value = x.OfertaId.ToString()
            });

            return Json(new { IsValid = isValid, ErrorMessage = errorMessage, Items = ofertas });
        }
        

        #endregion
    }
}