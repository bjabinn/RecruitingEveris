using System;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Web.Mvc;
using System.Collections.Generic;

using RecruitingWeb.Enums;
using RecruitingWeb.Models;
using RecruitingWeb.Helpers;
using RecruitingWeb.Security;
using RecruitingWeb.Properties;
using RecruitingWeb.Constantes;
using RecruitingWeb.Components.DataTable.ServerSide;

using Recruiting.Application.Roles.ViewModels;
using Recruiting.Application.Maestros.Services;
using Recruiting.Application.Clientes.Services;
using Recruiting.Application.Proyectos.Services;
using Recruiting.Application.Clientes.ViewModels;
using Recruiting.Application.Usuarios.ViewModels;
using Recruiting.Application.Necesidades.Services;
using Recruiting.Application.Proyectos.ViewModels;
using Recruiting.Application.Necesidades.ViewModels;
using Recruiting.Application.PersonasLibres.Services;

using Recruiting.Application.Maestros.Enums;
using Recruiting.Application.Necesidades.Enums;
using Recruiting.Application.Candidaturas.Enums;
using Recruiting.Application.Candidatos.Services;

using Recruiting.Business.Repositories;
using Recruiting.Business.BaseClasses.DataTable;

using Recruiting.Infra.Caching;
using Recruiting.Data.EntityFramework.Repositories;
using Recruiting.Application.Necesidades.Messages;

namespace RecruitingWeb.Controllers
{
    public class NecesidadesController : Controller
    {
        #region Fields

        private readonly INecesidadService _necesidadService;
        private readonly INecesidadRepository _necesidadRepository;

        private readonly IMaestroRepository _maestroRepository;
        private readonly MaestroService _maestroService;

        private readonly IProyectoRepository _proyectoRepository;
        private readonly IProyectoService _proyectoService;

        private readonly IClienteRepository _clienteRepository;
        private readonly IClienteService _clienteService;
        private readonly SessionCacheStorageService _sesionNecesidad;
        private readonly SessionCacheStorageService _sessionStaffingNecesidad;

        private readonly IPersonaLibreRepository _personaLibreRepository;
        private readonly IPersonasLibresService _personasLibresService;
        private readonly IBecarioRepository _becarioRepository;


        private readonly ICandidatoRepository _candidatoRepository;
        private readonly ICandidaturaRepository _candidaturaRepository;
        private readonly ICandidatoExperienciaRepository _candidatoExperienciaRepository;
        private readonly ICandidatoIdiomaRepository _candidatoIdiomaRepository;
        private readonly ICandidatoContactoRepository _candidatoContactoRepository;
        private readonly ICandidatoService _candidatoService;

        private readonly IGrupoNecesidadService _grupoNecesidadService;
        private readonly IGrupoNecesidadRepository _grupoNecesidadRepository;

        #endregion

        #region Controller

        public NecesidadesController()
        {
            _clienteRepository = new ClienteRepository();
            _clienteService = new ClienteService(_clienteRepository);

            _becarioRepository = new BecarioRepository();

            _sesionNecesidad = new SessionCacheStorageService();
            _sessionStaffingNecesidad = new SessionCacheStorageService();
            _necesidadRepository = new NecesidadRepository();

            _maestroRepository = new MaestroRepository();
            _maestroService = new MaestroService(_maestroRepository);

            _proyectoRepository = new ProyectoRepository();
            _proyectoService = new ProyectoService(_proyectoRepository, _clienteRepository);

            _personaLibreRepository = new PersonaLibreRepository();
            _personasLibresService = new PersonaLibreService(_personaLibreRepository);

            _candidatoRepository = new CandidatoRepository();
            _candidaturaRepository = new CandidaturaRepository();
            _candidatoExperienciaRepository = new CandidatoExperienciaRepository();
            _candidatoIdiomaRepository = new CandidatoIdiomaRepository();
            _candidatoContactoRepository = new CandidatoContactoRepository();
            _candidatoService = new CandidatoService(_candidatoRepository, _candidatoIdiomaRepository,
                        _candidatoExperienciaRepository, _candidatoContactoRepository, _candidaturaRepository, _becarioRepository);

            _necesidadService = new NecesidadService(_necesidadRepository);


            _grupoNecesidadRepository = new GrupoNecesidadRepository();
            _grupoNecesidadService = new GrupoNecesidadService(_grupoNecesidadRepository, _necesidadRepository);

        }

        #endregion

        #region Actions

        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.VerNecesidad)]
        public ActionResult Desbloquear()
        {           
            return RedirectToAction("Index");
        }

        #region Index Members
                
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.VerNecesidad)]
        [ValidateInput(false)]
        public ActionResult Index()
        {
            var filtro = _sesionNecesidad.Get<FiltroNecesidadesModels>("filtro_necesidad");          
            PermisosMostrar();

            if (filtro == null)
            {
                //orden por defecto
                filtro = new FiltroNecesidadesModels()
                {
                    SortColumn = "NecesidadId",
                    SortOrder = Recruiting.Business.BaseClasses.DataTable.DataTableSortDirectionEnum.Descending
                };
            }
            _sesionNecesidad.Add("filtro_inicial_necesidad", filtro);

            filtro = GenerateViewElementsIndex(filtro);        

            return View(filtro);
        }
        #endregion
               

        #region Create Grupo Members

        // GET: Necesidades/CreateGrupoNecesidad
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.AniadirEliminarNecesidad)]
        [ValidateInput(false)]
        public ActionResult CreateGrupoNecesidad()
        {
            var model = new CreateEditGrupoNecesidadViewModel();

            model = GenerateViewElementsGrupoNecesidadCreateEdit(model);

            return View("CreateGrupoNecesidad", model);
        }

        

        [HttpPost]
        public JsonResult ComprobarExisteGrupo(string nombreGrupo)
        {
            var respose = new JsonResult();
            if (!string.IsNullOrEmpty(nombreGrupo))
            {
                var response = _grupoNecesidadService.SearchGrupoNecesidadByNombre(nombreGrupo);
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

        // POST: Necesidades/CreateGrupoNecesidad
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.AniadirEliminarNecesidad)]
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult CreateGrupoNecesidad(CreateEditGrupoNecesidadViewModel viewModel, FormCollection collection)
        {
            int? centro = null;
            if (HttpContext.Session["Usuario"] != null)
            {
                var UsuarioRolPermisoViewModel = (UsuarioRolPermisoViewModel)HttpContext.Session["Usuario"];
                centro = UsuarioRolPermisoViewModel.CentroIdUsuario;
            }
            var model = MappertoSoloGrupoNecesidad(viewModel);
            var response = _grupoNecesidadService.SaveGrupoNecesidad(model, centro);
            if (response.IsValid)
            {
                var listaNecesidades = viewModel.ListaNecesidades.ToList();
                int numeroPerfilesCreados = viewModel.Multiplicadores.Count;
                for (int i = 0; i < numeroPerfilesCreados; i++)
                {
                    var numeroDeMultiplicaciones = viewModel.Multiplicadores[i];
                    var NecesidadACrear = MapeaGrupoNecesidadesANecesidad(viewModel, listaNecesidades[i], response.GrupoNecesidadId);
                    for (int j = 1; j <= numeroDeMultiplicaciones; j++)
                    {
                        _necesidadService.SaveNecesidad(NecesidadACrear);
                    }
                }
            }
            return RedirectToAction("Index");
        }

        public CreateEditSoloGrupoNecesidadViewModel MappertoSoloGrupoNecesidad(CreateEditGrupoNecesidadViewModel viewModel)
        {
            CreateEditSoloGrupoNecesidadViewModel model = new CreateEditSoloGrupoNecesidadViewModel();

            model.GrupoNecesidadId = viewModel.GrupoNecesidadId;
            model.NombreGrupo = viewModel.NombreGrupo;
            model.DescripcionGrupo = viewModel.DescripcionGrupo;
            model.EstadoGrupo = viewModel.EstadoGrupo;

            return model;
        }
     
       
        #region Seguimiento Grupo
        //Pulsar SeguimientoGrupo
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.VerNecesidad)]
        public ActionResult GrupoNecesidades()
        {
            PermisosMostrar();
            var filtroGrupoNecesidadesModel = _sesionNecesidad.Get<FiltroGrupoNecesidadesModels>("filtro_gruponecesidad");

            if (filtroGrupoNecesidadesModel == null)
            {
                //orden por defecto
                filtroGrupoNecesidadesModel = new FiltroGrupoNecesidadesModels()
                {
                    SortColumn = "GrupoNecesidadId",
                    SortOrder = Recruiting.Business.BaseClasses.DataTable.DataTableSortDirectionEnum.Descending
                };
            }
            _sesionNecesidad.Add("filtro_inicial_grupoNecesidad", filtroGrupoNecesidadesModel);

            filtroGrupoNecesidadesModel = GenerateViewElementsGrupoNecesidadesIndex(filtroGrupoNecesidadesModel);
            
            return View(filtroGrupoNecesidadesModel);
        }
                
        // GET: Necesidades/SeguimientoGrupoNecesidad //detalleSeguimientoGrupo
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.AniadirEliminarNecesidad)]
        [ValidateInput(false)]
        public ActionResult SeguimientoGrupoNecesidad(int grupoId)
        {
            var model = new CreateEditGrupoNecesidadViewModel();
            var responseGrupo = _grupoNecesidadService.GetGrupoNecesidadById(grupoId);
            if (responseGrupo.IsValid)
            {
                model = responseGrupo.GrupoNecesidadViewModel;
            }

            model = GenerateViewElementsGrupoNecesidadCreateEdit(model);

            return View("SeguimientoGrupoNecesidad", model);
        }

        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.ModificarNecesidad)]
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult SeguimientoGrupoNecesidad(CreateEditGrupoNecesidadViewModel grupoNecesidad)
        {
            grupoNecesidad = SaveSeguimientoGrupoNecesidad(grupoNecesidad);

            grupoNecesidad = GenerateViewElementsGrupoNecesidadCreateEdit(grupoNecesidad);

            return View(grupoNecesidad);
        }

        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.ModificarNecesidad)]
        [ValidateInput(false)]
        public ActionResult SeguimientoGrupoNecesidadTable(int grupoId)
        {
            var model = new CreateEditGrupoNecesidadViewModel();
            var responseGrupo = _grupoNecesidadService.GetGrupoNecesidadById(grupoId);
            if (responseGrupo.IsValid)
            {
                model = responseGrupo.GrupoNecesidadViewModel;
            }

            model = GenerateViewElementsGrupoNecesidadTableCreateEdit(model);
                        
            return View(model);
        }

        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.ModificarNecesidad)]
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult SeguimientoGrupoNecesidadTable(CreateEditGrupoNecesidadViewModel model)
        {
            model = SaveSeguimientoGrupoNecesidad(model);

            model = GenerateViewElementsGrupoNecesidadTableCreateEdit(model);

            return View(model);
        }

        public CreateEditGrupoNecesidadViewModel SaveSeguimientoGrupoNecesidad(CreateEditGrupoNecesidadViewModel model)
        {
            int? centro = null;
            if (HttpContext.Session["Usuario"] != null)
            {
                var UsuarioRolPermisoViewModel = (UsuarioRolPermisoViewModel)HttpContext.Session["Usuario"];
                centro = UsuarioRolPermisoViewModel.CentroIdUsuario;
            }
            var informacionGrupo = MappertoSoloGrupoNecesidad(model);
            var saveGrupoResponse = _grupoNecesidadService.SaveGrupoNecesidad(informacionGrupo, centro);

            if (saveGrupoResponse.IsValid)
            {
                if (model.NecesidadesBorradas != null && model.NecesidadesBorradas != "")
                {
                    var necesidadesABorrar = model.NecesidadesBorradas.Split(',');
                    foreach (var necesidadABorrar in necesidadesABorrar)
                    {
                        _necesidadService.DeleteNecesidad(Convert.ToInt32(necesidadABorrar), false);
                    }
                }

                if (model.ListaNecesidades != null)
                {
                    var listaNecesidades = model.ListaNecesidades.ToList();
                    for (int i = 0; i < listaNecesidades.Count; i++)
                    {
                        var NecesidadACrear = MapeaGrupoNecesidadesANecesidad(model, listaNecesidades[i], model.GrupoNecesidadId.Value);
                        _necesidadService.SaveNecesidad(NecesidadACrear);
                    }
                }
                else
                {
                    model.ListaNecesidades = new List<CreateEditNecesidadViewModel>();
                }

                _grupoNecesidadService.CheckGrupoCerrado(model.GrupoNecesidadId.Value);

                var response = _grupoNecesidadService.GetGrupoNecesidadById(model.GrupoNecesidadId.Value);
                if (response.IsValid)
                {
                    model = response.GrupoNecesidadViewModel;
                }
            }
            return model;
        }
      
        #endregion

        #region Details Members
        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.VerNecesidad)]
        public ActionResult Details(int id)
        {
            var model = _necesidadService.GetNecesidadById(id).NecesidadViewModel;            
           
            return View(model);
        }
        #endregion

        #region Edit Members

        // GET: Necesidades/Create/id
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.ModificarNecesidad)]
        [ValidateInput(false)]
        public ActionResult Edit(int id)
        {
            var model = new CreateEditNecesidadViewModel();

            var responseNecesidad = _necesidadService.GetNecesidadById(id);

            if (!responseNecesidad.IsValid)
            {
                CreateMessageError(responseNecesidad.ErrorMessage);
            }
            else
            {
                model = responseNecesidad.NecesidadViewModel;
            }

            model = GenerateViewElementsNecesidadEdit(model);
                      
            return View("Edit", model);
        }

        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.AniadirEliminarNecesidad)]
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit(CreateEditNecesidadViewModel viewModel, FormCollection collection)
        {
            if (viewModel.EstadoNecesidadId != (int)EstadoNecesidadEnum.Cerrada)
            {
                viewModel.AsignadaCorrectamente = null;
            }
          
            
            return EditFinish(viewModel);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult EditFinish(CreateEditNecesidadViewModel viewModel)
        {
            SaveNecesidad(viewModel);                      
            return RedirectToAction("Index");
        }

        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.VerNecesidad)]
        public virtual JsonResult LoadPersonasLibres([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
        {
            var request = requestModel.ConvertToDataTableRequestViewModel();
            request.CustomFilters.Add("SinNecesidadAsignada", "true");
            request.CustomFilters.Add("IsActivo", "true");

            if (HttpContext.Session["Usuario"] != null)
            {
                var UsuarioRolPermisoViewModel = (UsuarioRolPermisoViewModel)HttpContext.Session["Usuario"];
                var centroId = UsuarioRolPermisoViewModel.CentroIdUsuario.ToString();
                request.CustomFilters.Add("Centro", centroId);
            }

            int[] tipoMaestroId = { (int)MasterDataTypeEnum.TipoTecnologia };
            var maestroResponse = _maestroService.GetDatosMaestroByTipoId(tipoMaestroId);
            var listaTecnologias = ControllerHelper.GenerateElements(maestroResponse, MasterDataTypeEnum.TipoTecnologia).ToList();

            var response = _personasLibresService.GetPersonasLibres(request);

            if (!response.IsValid)
            {
                return null;
            }

            var result = from c in response.PersonaLibreRowViewModel
                         select new object[]
            {
                c.Nombre,
                c.Apellidos,
                (c.TipoTecnologiaId != null) ? listaTecnologias.Single(x => x.Value == c.TipoTecnologiaId.ToString()).Text : c.TipoTecnologiaId.ToString(),
                c.Categoria,
                c.Linea,
                c.Celda,
                this.RenderRazorViewToString("Table/actionColumnModalPersonaLibre", c),
            };
            var jsonResponse = new DataTablesResponse(requestModel.Draw, result, response.TotalElementos, response.TotalElementos);
            return Json(jsonResponse, JsonRequestBehavior.AllowGet);
        }
        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.VerNecesidad)]
        public virtual JsonResult LoadCandidatosQueCumplenPerfil([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
        {
            var request = requestModel.ConvertToDataTableRequestViewModel();
            request.CustomFilters.Add("IsActivo", "true");

            if (HttpContext.Session["Usuario"] != null)
            {
                var UsuarioRolPermisoViewModel = (UsuarioRolPermisoViewModel)HttpContext.Session["Usuario"];
                var centroId = UsuarioRolPermisoViewModel.CentroIdUsuario.ToString();
                request.CustomFilters.Add("Centro", centroId);
            }

            var response = _candidatoService.GetCandidatosQueCumplenPerfil(request);

            if (!response.IsValid)
            {
                return null;
            }

            var result = from c in response.CandidatosQueCumplenPerfilRowViewModel
                         select new object[]
            {
                string.Format("<a href=\"/Candidatos/Details/{0}\" target=\"_blank\">{0}</a>", c.CandidatoId.ToString()),
                c.Nombre,
                c.Apellidos,
                c.NumeroIdentificacion,
                c.EtapaCandidatura,
                string.Format("<a href=\"/Candidaturas/Details/{0}\" target=\"_blank\">{0}</a>", c.candidaturaIdAsociado.ToString()),
                this.RenderRazorViewToString("Table/actionColumnCandidatosQueCumplenPerfil", c),
                c.Centro,
                c.IsActivo
            };
            var jsonResponse = new DataTablesResponse(requestModel.Draw, result, response.TotalElementos, response.TotalElementos);
            return Json(jsonResponse, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Staffing Necesidades

        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.VerStaffingNecesidades)]
        public ActionResult StaffingNecesidades()
        {
            var filtro = _sessionStaffingNecesidad.Get<FiltroStaffingNecesidadesViewModel>("filtro_staffingNecesidad");

            if (filtro == null)
            {
                filtro = new FiltroStaffingNecesidadesViewModel();                
            }

            filtro = GenerateViewElementsStaffingIndex(filtro);

            filtro.modalEdicionNecesidad = new ModalEdicionNecesidadViewModel();
            filtro.modalEdicionNecesidad = GenerateModeloStaffingNecesidadModal(filtro.modalEdicionNecesidad);
            return View(filtro);
        }
                
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.ModificarStaffingNecesidades)]
        public JsonResult SaveStaffingNecesidades(SaveStaffingNecesidadViewModel necesidad)
        {
            var response = new JsonResult();


            response.Data = _necesidadService.SaveStaffingNecesidad(necesidad);


            return Json(response.Data, JsonRequestBehavior.AllowGet);

        }

        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.ModificarStaffingNecesidades)]
        public JsonResult LiberateStaffingNecesidades(int necesidadId)
        {
            var response = new JsonResult();


            response.Data = _necesidadService.CheckLiberateNecesidad(necesidadId);


            return Json(response.Data, JsonRequestBehavior.AllowGet);

        }

        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.ModificarStaffingNecesidades)]
        public JsonResult SavePrioridadesNecesidades(IEnumerable<SavePrioridadNecesidadViewModel> ListaStaffingNecesidades)
        {
            var response = new JsonResult();

            foreach (var necesidad in ListaStaffingNecesidades)
            {
                response.Data = _necesidadService.SavePrioridadNecesidad(necesidad);
            }

            return Json(response.Data, JsonRequestBehavior.AllowGet);

        }

        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.ModificarStaffingNecesidades)]
        public JsonResult SaveObservacionesNecesidades(int NecesidadId, string observacionesStaffing)
        {
            var response = new JsonResult();

            response.Data = _necesidadService.SaveObservacionesStaffing(NecesidadId, observacionesStaffing);


            return Json(response.Data, JsonRequestBehavior.AllowGet);

        }

        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.VerStaffingNecesidades)]
        public void ExportToExcelStaffingNecesidades( string filterTecnologia, string filterPerfil, string filterEstado, string filterPrevision)
        {
            IDictionary<string, string> CustomFilters = new Dictionary<string, string> {
                        { "Tecnologia",filterTecnologia },
                        { "Perfil", filterPerfil },
                        { "EstadoStaffing", filterEstado },
                        { "Prevision", filterPrevision },
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
            var response = _necesidadService.GetNecesidadesStaffingExportToExcel(request);
            
            var grid = new System.Web.UI.WebControls.GridView();
            grid.DataSource = response.NecesidadStaffingExportToExcelViewModel;
            grid.DataBind();
            Response.ClearContent();
            string filename = string.Format("Listado_de_Necesidades_{0}", DateTime.Now.ToShortDateString() + ".xls");
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", filename));
            Response.ContentType = "application/excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);

            grid.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();

        }
     


        #endregion

        #region Load Table Members

        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.VerNecesidad)]
        public virtual JsonResult LoadGrupoNecesidades([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
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

            var filtro = _sesionNecesidad.Get<FiltroGrupoNecesidadesModels>("filtro_inicial_grupoNecesidad");
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

            var response = _grupoNecesidadService.GetGruposNecesidades(request);

            var filtroNecesidadesModel = MappertoFiltroGrupoNecesidades(request.CustomFilters);

            if (filtro != null)
            {
                filtroNecesidadesModel.SortOrder = filtro.SortOrder;
                filtroNecesidadesModel.SortColumn = filtro.SortColumn;
            }

            _sesionNecesidad.Add("filtro_gruponecesidad", filtroNecesidadesModel);
            _sesionNecesidad.Add("pagina_gruponecesidad", request.PageNumber);


            if (!response.IsValid)
            {
                return null;
            }

            var result = from c in response.GrupoNecesidadesRowViewModel
                         select new object[]
            {
                c.GrupoNecesidadId,
                c.NombreGrupo,
                c.NombreCliente,
                c.NombreProyecto,
                c.EstadoGrupo,
                c.NecesidadesAsignadas,
                c.NecesidadesAbiertas,
                c.NecesidadesPreasignadas,
                c.NecesidadesCerradas,
                this.RenderRazorViewToString("Table/actionColumnGrupoNecesidades", c)
            };

            var jsonResponse = new DataTablesResponse(requestModel.Draw, result, response.TotalElementos, response.TotalElementos);

            return Json(jsonResponse, JsonRequestBehavior.AllowGet);

        }

        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.VerNecesidad)]
        public virtual JsonResult LoadNecesidades([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
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

            var filtro = _sesionNecesidad.Get<FiltroNecesidadesModels>("filtro_inicial_necesidad");
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

            var response = _necesidadService.GetNecesidades(request);

            var filtroNecesidadesModel = MappertoFiltroNecesidades(request.CustomFilters);

            if (filtro != null)
            {
                filtroNecesidadesModel.SortOrder = filtro.SortOrder;
                filtroNecesidadesModel.SortColumn = filtro.SortColumn;
            }

            _sesionNecesidad.Add("filtro_necesidad", filtroNecesidadesModel);
            _sesionNecesidad.Add("pagina_necesidad", request.PageNumber);


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
                c.TipoPrevisionId,
                FormatHelper.Format(c.FechaCompromiso, "dd/MM/yyyy"),
                FormatHelper.Format(c.FechaCierre, "dd/MM/yyyy"),
                c.TipoContratacion,
                c.PersonaAsignada,
                c.AsignadaCorrectamente,
                (c.Estado == "Cerrada") ? string.Format("<span class=\"Statered\">{0}</span>", c.Estado) : c.Estado,
                c.Centro,
                this.RenderRazorViewToString("Table/actionColumn", c),
                c.Modulo
            };

            var centroUsuarioId = HttpContext.Session["CentroIdUsuario"];
            if ((centroUsuarioId != null) && result.Any())
            {
                var resultTemp = new List<object[]>();
                result.ToList().ForEach(x =>
                {
                    var item = x.ToList();
                    item.RemoveAt(12);
                    resultTemp.Add(item.ToArray());
                });
                result = resultTemp;
            }

            var jsonResponse = new DataTablesResponse(requestModel.Draw, result, response.TotalElementos, response.TotalElementos);

            return Json(jsonResponse, JsonRequestBehavior.AllowGet);
        }


        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.VerStaffingNecesidades)]
        public virtual JsonResult LoadStaffingNecesidades([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
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

            var response = _necesidadService.GetStaffingNecesidades(request);

            
            //Almaceno el filtro en caché

            var filtroStaffingNecesidadesModel = MappertoFiltroStaffingNecesidades(request.CustomFilters);
            _sessionStaffingNecesidad.Add("filtro_staffingNecesidad", filtroStaffingNecesidadesModel);

            if (!response.IsValid)
            {
                return null;
            }

            var result = from c in response.StaffingNecesidadViewModel
                         select new object[]
            {
                string.Format("<a name=\"NecesidadId\">{0}</a>", c.NecesidadId.ToString()),
                c.Cliente,
                c.Proyecto,
                FormatHelper.Format(c.FechaCompromiso, "dd/MM/yyyy"),
                c.Perfil,
                this.RenderRazorViewToString("Table/personaAsignadaColumnStaffingNecesidad", c),
                this.RenderRazorViewToString("Table/observacionesColumnStaffingNecesidad", c),
                this.RenderRazorViewToString("Table/hiddenDataColumnStaffingNecesidad", c)
            };            

            var jsonResponse = new DataTablesResponse(requestModel.Draw, result, response.TotalElementos, response.TotalElementos);

            return Json(jsonResponse, JsonRequestBehavior.AllowGet);
        }

        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.VerStaffingNecesidades)]
        public virtual JsonResult LoadStaffingPersonas([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
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

            string listaEstados = (int)TipoEstadoCandidaturaEnum.Entrevista + "," +
                                 (int)TipoEstadoCandidaturaEnum.SegundaEntrevista + "," +
                                 (int)TipoEstadoCandidaturaEnum.CartaOferta;

            string listaEtapas = (int)TipoEtapaCandidaturaEnum.PendienteDecisionSegundaEntrevista + "," +
                                (int)TipoEtapaCandidaturaEnum.AgendarSegundaEntrevista + "," +
                                (int)TipoEtapaCandidaturaEnum.FeedbackSegundaEntrevista + "," +
                                (int)TipoEtapaCandidaturaEnum.PendienteDecisionCartaOferta + "," +
                                (int)TipoEtapaCandidaturaEnum.AgendarCartaOferta + "," +
                                (int)TipoEtapaCandidaturaEnum.FeedbackCartaOferta;



            request.CustomFilters.Add("Estados[]", listaEstados);
            request.CustomFilters.Add("Etapas[]", listaEtapas);

            var response = _necesidadService.GetStaffingPersonas(request);

            
            //Almaceno el filtro en caché        

            var filtroStaffingNecesidadesModel = MappertoFiltroStaffingNecesidades(request.CustomFilters);
            _sessionStaffingNecesidad.Add("filtro_staffingNecesidad", filtroStaffingNecesidadesModel);

            if (!response.IsValid)
            {
                return null;
            }


            var result = from c in response.StaffingPersonaViewModel
                         select new object[]
            {
                c.TipoPersonaId == (int)TipoPersonaEnum.Candidatura ?
                string.Format("<a href=\"/Candidaturas/Details/{0}\" target=\"_blank\">{0}</a>", c.PersonaId.ToString()) :
                string.Format("<a href=\"/PersonasLibres/Details/{0}\" target=\"_blank\">{0}</a>", c.PersonaId.ToString()),
                c.NombreCompleto,
                c.Categoria,
                c.TipoPersona,
                this.RenderRazorViewToString("Table/hiddenDataColumnStaffingPersona", c)
            };

            var jsonResponse = new DataTablesResponse(requestModel.Draw, result, response.TotalElementos, response.TotalElementos);

            return Json(jsonResponse, JsonRequestBehavior.AllowGet);
        }

        #region ModalEditStaffingNecesidad

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

        private ModalEdicionNecesidadViewModel GenerateModeloStaffingNecesidadModal(ModalEdicionNecesidadViewModel modalEdicionNecesidadViewModel)
        {
            int[] tipoMaestroId =
            {
                (int)MasterDataTypeEnum.Oficina,
                (int)MasterDataTypeEnum.Sector,
                (int)MasterDataTypeEnum.TipoServicio,
                (int)MasterDataTypeEnum.MesesAsignacion,
                (int)MasterDataTypeEnum.TipoContratacion,
                (int)MasterDataTypeEnum.TipoPrevision,
                (int)MasterDataTypeEnum.Categoria,
                (int)MasterDataTypeEnum.TipoTecnologia,
                (int)MasterDataTypeEnum.EstadoNecesidad,
                (int)MasterDataTypeEnum.TipoModulo

            };
                        
            var response = _maestroService.GetDatosMaestroByTipoId(tipoMaestroId);
            modalEdicionNecesidadViewModel.Oficina = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.Oficina);
            modalEdicionNecesidadViewModel.Sector = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.Sector);
            modalEdicionNecesidadViewModel.Cliente = GenerateClienteElements();
            modalEdicionNecesidadViewModel.Proyecto = GenerateProyectoElements();
            modalEdicionNecesidadViewModel.Tecnologia = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.TipoTecnologia);
            modalEdicionNecesidadViewModel.Servicio = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.TipoServicio);
            modalEdicionNecesidadViewModel.Perfil = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.Categoria);
            modalEdicionNecesidadViewModel.Duracion = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.MesesAsignacion);
            modalEdicionNecesidadViewModel.Contratacion = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.TipoContratacion);
            modalEdicionNecesidadViewModel.Prevision = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.TipoPrevision);
            modalEdicionNecesidadViewModel.Modulo = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.TipoModulo);
            modalEdicionNecesidadViewModel.Estado = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.EstadoNecesidad);

            return modalEdicionNecesidadViewModel;
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

        #endregion




        #endregion
        //---------------------------------------------- LIMITE ORDER ----------------------------------------------//

        #region Create UI

        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.AniadirEliminarNecesidad)]
        public CreateEditNecesidadViewModel SaveNecesidad(CreateEditNecesidadViewModel model)
        {
            // OJO: ESTO SOBRA CUANDO LA VISTA APORTE EL VALOR //
            model.EstadoNecesidadId = model.EstadoNecesidadId != 0 ? model.EstadoNecesidadId : 10;

            var response = _necesidadService.SaveNecesidad(model);
            if (model.GrupoNecesidad.HasValue)
            {
                _grupoNecesidadService.CheckGrupoCerrado(model.GrupoNecesidad.Value);
            }

            if (!response.IsValid)
            {
                CreateMessageError(response.ErrorMessage);
            }
            else
            {
                CreateMessageNotify("Necesidad Guardada Correctamente");
            }
            
            model.NecesidadId = response.NecesidadId;
            return model;
        }

        #endregion     
        
        #region Volver
        //Esta acción nos permite volver desde otra página con el filtro
        public ActionResult Volver()
        {

            return RedirectToAction("Index");

        }
        #endregion

        #region Limpiar

        public ActionResult Limpiar()
        {            
            _sesionNecesidad.Remove("filtro_necesidad");
            return RedirectToAction("Index");
        }

        public ActionResult LimpiarGrupoNecesidad()
        {            
            _sesionNecesidad.Remove("filtro_gruponecesidad");
            return RedirectToAction("GrupoNecesidades");
        }

        #endregion

        #region ExportToExcel
        public void ExportToExcel(string filterCliente, string filterProyecto, string filterTecnologia,
            string filterEstado, string filterPrevision, string filterPerfil,
            string filterSolicitadoDesde, string filterSolicitadoHasta, string filterCentro,
            string filterMisNecesidades, string filterNecesidadIdioma, string filterCerradoDesde,
            string filterCerradoHasta, string filterIdNecesidad, string filterTipoContratacionId, string filterAsignadoCorrectamente)
        {
            IDictionary<string, string> CustomFilters = new Dictionary<string, string> {
                    { "Cliente", filterCliente },
                    { "Proyecto",filterProyecto},
                    { "Tecnologia",filterTecnologia },
                    { "Estados", filterEstado },
                    { "Prevision", filterPrevision },
                    { "Perfil", filterPerfil },
                    { "SolicitadoDesde", filterSolicitadoDesde},
                    {"SolicitadoHasta", filterSolicitadoHasta } ,
                    { "CentroSearch", filterCentro },
                    {"MisNecesidades", filterMisNecesidades },
                    {"NecesidadIdioma", filterNecesidadIdioma },
                    { "CerradoDesde", filterCerradoDesde},
                    {"CerradoHasta", filterCerradoHasta } ,
                    {"IdNecesidad", filterIdNecesidad } ,
                    {"TipoContratacionId", filterTipoContratacionId } ,
                    {"AsignadoCorrectamente", filterAsignadoCorrectamente }
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
            var response = _necesidadService.GetNecesidadesExportToExcel(request);



            var grid = new System.Web.UI.WebControls.GridView();
            grid.DataSource = response.NecesidadExportToExcellViewModel;
            grid.DataBind();
            Response.ClearContent();
            string filename = string.Format("Listado_de_Necesidades_{0}", DateTime.Now.ToShortDateString() + ".xls");
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", filename));
            Response.ContentType = "application/excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);

            grid.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();

        }
        #endregion
        #region ExportToExcelSeguimientoGrupo
        public void ExportToExcelSeguimientoGrupo(string filterGrupoNecesidadId, string filterNombreGrupoNecesidad, string filterCentro,
            string filterCliente, string filterProyecto, string filterEstadoGrupoNecesidad)
        {
            IDictionary<string, string> CustomFilters = new Dictionary<string, string> {
                    { "GrupoNecesidadId", filterGrupoNecesidadId},
                    { "NombreGrupoNecesidad", filterNombreGrupoNecesidad},
                    { "CentroSearch", filterCentro},
                    { "Cliente", filterCliente },
                    { "Proyecto",filterProyecto},
                    { "EstadoGrupoNecesidad", filterEstadoGrupoNecesidad}
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
            var response = _grupoNecesidadService.GetNecesidadesGrupoExportToExcel(request);



            var grid = new System.Web.UI.WebControls.GridView();
            grid.DataSource = response.NecesidadGrupoExportToExcellViewModel;
            grid.DataBind();
            Response.ClearContent();
            string filename = string.Format("Listado_de_NecesidadesGrupo_{0}", DateTime.Now.ToShortDateString() + ".xls");
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", filename));
            Response.ContentType = "application/excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);

            grid.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();

        }
        #endregion
        #region Delete UI

        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.AniadirEliminarNecesidad)]
        [ValidateInput(false)]
        [HttpPost]
        public JsonResult Delete(int id, bool ultNecesidadGrupo)
        {
            var respose = new JsonResult();
            respose.Data = _necesidadService.DeleteNecesidad(id, ultNecesidadGrupo);
            return respose;

        }

        [ValidateInput(false)]  
        public JsonResult CheckUltimaNecesidadDeGrupo(int id)
        {
            var response = new JsonResult();

            response.Data = _necesidadService.CheckUltimaNecesidadEnGrupo(id);

            return Json(response.Data, JsonRequestBehavior.AllowGet);

        }

        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.AniadirEliminarNecesidad)]
        [ValidateInput(false)]
        [HttpPost]
        public JsonResult DeleteGrupoNecesidades(int id)
        {
            var response = new JsonResult();
            response.Data = _grupoNecesidadService.DeleteGrupoNecesidad(id);
            return response;

        }
        #endregion

       
        #region Private Methods
        private void PermisosMostrar()
        {
            TempData["AniadirEliminarNecesidad"] = false;
            TempData["ModificarNecesidad"] = false;
            TempData["VerNecesidad"] = false;
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

            if (privilegeLevels.Contains(PermisosConst.AniadirEliminarNecesidad)) TempData["AniadirEliminarNecesidad"] = true;
            if (privilegeLevels.Contains(PermisosConst.ModificarNecesidad)) TempData["ModificarNecesidad"] = true;
            if (privilegeLevels.Contains(PermisosConst.VerNecesidad)) TempData["VerNecesidad"] = true;
        }     

        private void CreateMessageNotify(string textMessg)
        {
            @ViewBag.ShowMessage = true;
            @ViewBag.TypeMessage = TypeMessageEnum.AlertMessage;
            @ViewBag.TitleMessage = Properties.Resources.Necesidad_NotificacionTitulo;
            @ViewBag.TextMessage = textMessg;

        }

        private void CreateMessageError(string textMessg)
        {
            @ViewBag.ShowMessage = true;
            @ViewBag.TypeMessage = TypeMessageEnum.AlertMessage;
            @ViewBag.TitleMessage = Properties.Resources.Necesidad_ErrorTitulo;
            @ViewBag.TextMessage = textMessg;

        }

        private IEnumerable<SelectListItem> GenerateProyectoElements()
        {
            var response = _proyectoService.GetProyectosNombreId();

            if (response.IsValid)
            {
                IEnumerable<ProyectoNombreIdViewModel> proyectoList;
                proyectoList = from value in response.ProyectoViewModel orderby value.Nombre select value;

                return new SelectList(proyectoList, "ProyectoId", "Nombre");
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

        [ValidateInput(false)]
        public JsonResult GeneraProyectosFromClientes(int? clienteId)
        {

            var response = _proyectoService.GetProyectosByCliente(clienteId);

            var colec = response.ProyectoViewModel;

            return Json(colec, JsonRequestBehavior.AllowGet);
        }

        [ValidateInput(false)]
        public JsonResult GeneraSectorYServicioFromProyecto(int? proyectoId)
        {
            var response = _proyectoService.GetSectorServicioClienteFromProyecto(proyectoId);

            var jsonToReturn = new SectorIdServicioIdClienteIdModel()
            {
                SectorId = response.SectorId,
                ServicioId = response.ServicioId,
                ClienteId = response.ClienteId
            };

            return Json(jsonToReturn);
        }

        private IEnumerable<SelectListItem> GenerateEstadosStaffingNecesidad()
        {
            var todasNecesidades = (int)EstadoStaffingNecesidadEnum.Todas;
            var abiertasNecesidades = (int)EstadoStaffingNecesidadEnum.SoloAbiertas;

            List<SelectListItem> estadosStaffingNecesidadList = new List<SelectListItem>();
            SelectListItem todas = new SelectListItem
            {
                Text = Resources.EstadoStaffingEnum_Todas,
                Value = todasNecesidades.ToString()
            };
            SelectListItem abiertas = new SelectListItem
            {
                Text = Resources.EstadoStaffingEnum_SoloAbiertas,
                Value = abiertasNecesidades.ToString()
            };

            estadosStaffingNecesidadList.Add(todas);
            estadosStaffingNecesidadList.Add(abiertas);

            return estadosStaffingNecesidadList;
        }

        private CreateEditNecesidadViewModel MapeaGrupoNecesidadesANecesidad(CreateEditGrupoNecesidadViewModel grupoNecesidadVM, CreateEditNecesidadViewModel perfilVM, int grupoId)
        {
            var NecesidadADevolver = new CreateEditNecesidadViewModel();
            NecesidadADevolver.CentroId = grupoNecesidadVM.CentroId;
            NecesidadADevolver.ClienteId = grupoNecesidadVM.ClienteId;
            NecesidadADevolver.DisponibilidadReubicacion = grupoNecesidadVM.DisponibilidadReubicacion;
            NecesidadADevolver.DisponibilidadViajes = grupoNecesidadVM.DisponibilidadViajes;
            NecesidadADevolver.EstadoNecesidadId = (perfilVM.EstadoNecesidadId != 0) ? perfilVM.EstadoNecesidadId : (int)EstadoNecesidadEnum.Abierta;
            NecesidadADevolver.FechaCompromiso = perfilVM.FechaCompromiso;
            NecesidadADevolver.FechaSolicitud = grupoNecesidadVM.FechaSolicitud;
            NecesidadADevolver.GrupoNecesidad = grupoId;
            NecesidadADevolver.MesesAsignacionId = grupoNecesidadVM.MesesAsignacionId;
            NecesidadADevolver.Modulo = perfilVM.Modulo;
            NecesidadADevolver.NecesidadIdioma = grupoNecesidadVM.NecesidadIdioma;
            NecesidadADevolver.Nombre = grupoNecesidadVM.NombreGrupo + "_NecesidadIndividual";
            NecesidadADevolver.OficinaId = grupoNecesidadVM.OficinaId;
            NecesidadADevolver.ProyectoId = grupoNecesidadVM.ProyectoId;
            NecesidadADevolver.SectorId = grupoNecesidadVM.SectorId;
            NecesidadADevolver.TipoContratacionId = perfilVM.TipoContratacionId;
            NecesidadADevolver.TipoPerfilId = perfilVM.TipoPerfilId;
            NecesidadADevolver.TipoPrevisionId = perfilVM.TipoPrevisionId;
            NecesidadADevolver.TipoServicioId = perfilVM.TipoServicioId;
            NecesidadADevolver.TipoTecnologiaId = perfilVM.TipoTecnologiaId;
            NecesidadADevolver.NecesidadId = perfilVM.NecesidadId;
            NecesidadADevolver.DetalleTecnologia = perfilVM.DetalleTecnologia;
            NecesidadADevolver.PersonaAsignada = perfilVM.PersonaAsignada;
            NecesidadADevolver.PersonaAsignadaId = perfilVM.PersonaAsignadaId;
            NecesidadADevolver.PersonaAsignadaNroEmpleado = perfilVM.PersonaAsignadaNroEmpleado;
            NecesidadADevolver.AsignadaCorrectamente = perfilVM.AsignadaCorrectamente;
            NecesidadADevolver.FechaCierre = perfilVM.FechaCierre;
            
            return NecesidadADevolver;
        }

       
        private FiltroGrupoNecesidadesModels MappertoFiltroGrupoNecesidades(IDictionary<string, string> filtro)
        {
            var filtroGrupoNecesidadModels = new FiltroGrupoNecesidadesModels();

            //si filtro.count = 0 significa que el diccionario aun no se ha creado
            if (filtro.Count != 0)
            {
                string value;
                if (filtro.ContainsKey("Cliente"))
                {
                    value = filtro["Cliente"];

                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroGrupoNecesidadModels.Cliente = Convert.ToInt32(value);
                    }
                }
                if (filtro.ContainsKey("Proyecto"))
                {
                    value = filtro["Proyecto"];

                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroGrupoNecesidadModels.Proyecto = Convert.ToInt32(value);
                    }
                }
                if (filtro.ContainsKey("GrupoNecesidadId"))
                {
                    value = filtro["GrupoNecesidadId"];

                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroGrupoNecesidadModels.GrupoNecesidadId = Convert.ToInt32(value);
                    }
                }
                if (filtro.ContainsKey("NombreGrupoNecesidad"))
                {
                    value = filtro["NombreGrupoNecesidad"];

                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroGrupoNecesidadModels.GrupoNecesidadNombre = Convert.ToString(value);
                    }
                }
                if (filtro.ContainsKey("EstadoGrupoNecesidad"))
                {
                    value = filtro["EstadoGrupoNecesidad"];

                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroGrupoNecesidadModels.EstadoGrupoNecesidad = Convert.ToBoolean(value);
                    }
                }
                if (filtro.ContainsKey("Centro"))
                {
                    value = filtro["Centro"];

                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroGrupoNecesidadModels.Centro = Convert.ToInt32(value);
                    }
                }

            }

            return filtroGrupoNecesidadModels;
        }//MappertoFiltroGrupoNecesidades


        private FiltroNecesidadesModels MappertoFiltroNecesidades(IDictionary<string, string> filtro)
        {
            var filtroNecesidadModels = new FiltroNecesidadesModels();

            //si filtro.count = 0 significa que el diccionario aun no se ha creado
            if (filtro.Count != 0)
            {
                string value;
                if (filtro.ContainsKey("Cliente"))
                {
                    value = filtro["Cliente"];

                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroNecesidadModels.ClienteId = Convert.ToInt32(value);
                    }
                }

                if (filtro.ContainsKey("Proyecto"))
                {
                    value = filtro["Proyecto"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroNecesidadModels.ProyectoId = Convert.ToInt32(value);
                    }
                }

                if (filtro.ContainsKey("Tecnologia"))
                {
                    value = filtro["Tecnologia"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroNecesidadModels.TipoTecnologiaId = Convert.ToInt32(value);
                    }
                }

                if (filtro.ContainsKey("Estados[]"))
                {
                    value = filtro["Estados[]"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroNecesidadModels.Estado = value;
                    }
                }

                if (filtro.ContainsKey("Perfil"))
                {
                    value = filtro["Perfil"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroNecesidadModels.Perfil = filtro["Perfil"];
                    }
                }

                if (filtro.ContainsKey("SolicitadoDesde"))
                {
                    value = filtro["SolicitadoDesde"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroNecesidadModels.FechaEntre = Convert.ToDateTime(filtro["SolicitadoDesde"]);
                    }
                }

                if (filtro.ContainsKey("SolicitadoHasta"))
                {
                    value = filtro["SolicitadoHasta"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroNecesidadModels.FechaHasta = Convert.ToDateTime(value);
                    }
                }

                if (filtro.ContainsKey("Prevision"))
                {
                    value = filtro["Prevision"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroNecesidadModels.TipoPrevisionId = Convert.ToInt32(value);
                    }
                }

                if (filtro.ContainsKey("CentroUsuarioId"))
                {
                    value = filtro["CentroUsuarioId"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroNecesidadModels.CentroIdUsuario = Convert.ToInt32(value);
                    }
                }

                if (filtro.ContainsKey("CentroSearch"))
                {
                    value = filtro["CentroSearch"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroNecesidadModels.CentroIdUsuario = Convert.ToInt32(value);
                    }
                }

                if (filtro.ContainsKey("CerradoDesde"))
                {
                    value = filtro["CerradoDesde"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroNecesidadModels.FechaCierreEntre = Convert.ToDateTime(value);
                    }
                }

                if (filtro.ContainsKey("CerradoHasta"))
                {
                    value = filtro["CerradoHasta"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroNecesidadModels.FechaCierreHasta = Convert.ToDateTime(value);
                    }
                }

                if (filtro.ContainsKey("IdNecesidad"))
                {
                    value = filtro["IdNecesidad"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroNecesidadModels.IdNecesidad = Convert.ToInt32(value);
                    }
                }

                if (filtro.ContainsKey("TipoContratacionId"))
                {
                    value = filtro["TipoContratacionId"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroNecesidadModels.TipoContratacionId = Convert.ToInt32(value);
                    }
                }

                if (filtro.ContainsKey("MisNecesidades"))
                {
                    value = filtro["MisNecesidades"];

                    if (!string.IsNullOrEmpty(value) && (value == "true"))
                    {
                        filtroNecesidadModels.MisNecesidades = Convert.ToBoolean(value);
                    }
                }
                if (filtro.ContainsKey("NecesidadIdioma"))
                {
                    value = filtro["NecesidadIdioma"];

                    if (!string.IsNullOrEmpty(value) && (value == "true"))
                    {
                        filtroNecesidadModels.NecesidadIdioma = Convert.ToBoolean(value);
                    }
                }
                if (filtro.ContainsKey("AsignadoCorrectamente"))
                {
                    value = filtro["AsignadoCorrectamente"];

                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroNecesidadModels.AsignadoCorrectamente = Convert.ToBoolean(value);
                    }
                }
            }

            return filtroNecesidadModels;
        }//MappertoFiltroNecesidades

        private FiltroStaffingNecesidadesViewModel MappertoFiltroStaffingNecesidades(IDictionary<string, string> filtro)
        {
            var filtroStaffingNecesidades = new FiltroStaffingNecesidadesViewModel();

            //si filtro.count = 0 significa que el diccionario aun no se ha creado
            if (filtro.Count != 0)
            {
                string value;               

                if (filtro.ContainsKey("Tecnologia"))
                {
                    value = filtro["Tecnologia"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroStaffingNecesidades.TipoTecnologiaId = Convert.ToInt32(value);
                    }
                }

                if (filtro.ContainsKey("Perfil"))
                {
                    value = filtro["Perfil"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroStaffingNecesidades.TipoPerfilId = Convert.ToInt32(value);
                    }
                }

                if (filtro.ContainsKey("CentroUsuarioId"))
                {
                    value = filtro["CentroUsuarioId"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroStaffingNecesidades.CentroIdUsuario = Convert.ToInt32(value);
                    }
                }

                if (filtro.ContainsKey("CentroSearch"))
                {
                    value = filtro["CentroSearch"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroStaffingNecesidades.CentroIdUsuario = Convert.ToInt32(value);
                    }
                }   
                
                if(filtro.ContainsKey("EstadoStaffing"))
                {
                    value = filtro["EstadoStaffing"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroStaffingNecesidades.EstadoStaffingNecesidadId = Convert.ToInt32(value);
                    }
                }

                if(filtro.ContainsKey("Proyecto"))
                {
                    value = filtro["Proyecto"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroStaffingNecesidades.ProyectoId = Convert.ToInt32(value);
                    }
                }

            }

            return filtroStaffingNecesidades;
        }

        private FiltroNecesidadesModels GenerateViewElementsIndex(FiltroNecesidadesModels filtro)
        {
            int[] tipoMaestroId =
            {
                (int)MasterDataTypeEnum.Centro,
                (int)MasterDataTypeEnum.TipoTecnologia,
                (int)MasterDataTypeEnum.EstadoNecesidad,
                (int)MasterDataTypeEnum.TipoPrevision,
                (int)MasterDataTypeEnum.TipoContratacion,
                (int)MasterDataTypeEnum.Categoria,

            };

            var response = _maestroService.GetDatosMaestroByTipoId(tipoMaestroId);

            filtro.ClienteList = GenerateClienteElements();
            filtro.ProyectoList = GenerateProyectoElements();
            filtro.PerfilList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.Categoria);
            filtro.EstadoList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.EstadoNecesidad);
            filtro.PrevisionList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.TipoPrevision);
            filtro.TecnologiaList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.TipoTecnologia);
            filtro.ContratacionList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.TipoContratacion);
            filtro.CentroList = (IEnumerable<SelectListItem>)HttpContext.Session["ListaCentros"];
            filtro.CentroIdUsuarioLogueado = HttpContext.Session["CentroIdUsuario"] != null ? HttpContext.Session["CentroIdUsuario"].ToString() : string.Empty;

            filtro.Pagina = _sesionNecesidad.Get<int>("pagina_necesidad") > 0 ? _sesionNecesidad.Get<int>("pagina_necesidad") : 0;
            return filtro;
        }

        private FiltroStaffingNecesidadesViewModel GenerateViewElementsStaffingIndex(FiltroStaffingNecesidadesViewModel filtro)
        {
            int[] tipoMaestroId =
            {
                (int)MasterDataTypeEnum.TipoTecnologia,
                (int)MasterDataTypeEnum.TipoPerfil,
                (int)MasterDataTypeEnum.Categoria,
            };

            var response = _maestroService.GetDatosMaestroByTipoId(tipoMaestroId);

            filtro.CentroIdUsuarioLogueado = HttpContext.Session["CentroIdUsuario"] != null ? HttpContext.Session["CentroIdUsuario"].ToString() : string.Empty;
            filtro.TecnologiaList = ControllerHelper.GenerateElementsStaffingTecnologia(response, MasterDataTypeEnum.TipoTecnologia, filtro.CentroIdUsuarioLogueado);
            filtro.CategoriaList = ControllerHelper.GenerateElementsStaffingPerfil(response, MasterDataTypeEnum.Categoria, filtro.CentroIdUsuarioLogueado);
            filtro.PerfilList = filtro.CategoriaList;
            filtro.ProyectoList = GenerateProyectoElements();
            filtro.EstadoStaffingNecesidadList = GenerateEstadosStaffingNecesidad();


            return filtro;
        }

        private CreateEditNecesidadViewModel GenerateViewElementsNecesidadEdit(CreateEditNecesidadViewModel model)
        {
            int[] tipoMaestroId =
            {
                (int)MasterDataTypeEnum.Centro,
                (int)MasterDataTypeEnum.Oficina,
                (int)MasterDataTypeEnum.Sector,
                (int)MasterDataTypeEnum.TipoTecnologia,
                (int)MasterDataTypeEnum.TipoServicio,
                (int)MasterDataTypeEnum.TipoPerfil,
                (int)MasterDataTypeEnum.MesesAsignacion,
                (int)MasterDataTypeEnum.TipoContratacion,
                (int)MasterDataTypeEnum.TipoPrevision,
                (int)MasterDataTypeEnum.EstadoNecesidad,
                (int)MasterDataTypeEnum.Categoria,
                (int)MasterDataTypeEnum.TipoModulo,
            };



            var response = _maestroService.GetDatosMaestroByTipoId(tipoMaestroId);


            model.CentroList = (IEnumerable<SelectListItem>)HttpContext.Session["ListaCentros"];
            model.OficinaList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.Oficina);
            model.SectorList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.Sector);
            model.CategoriaList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.Categoria);
            model.EstadoList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.EstadoNecesidad);

            model.ClienteList = GenerateClienteElements();
            model.ProyectoList = GenerateProyectoElements();

            model.TecnologiaList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.TipoTecnologia);
            model.ServicioList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.TipoServicio);
            model.PerfilList = model.CategoriaList;
            model.ModuloList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.TipoModulo);

            model.MesesAsignacionList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.MesesAsignacion);
            model.ContratacionList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.TipoContratacion);
            model.PrevisionList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.TipoPrevision);

            model.CentroIdUsuarioLogueado = HttpContext.Session["CentroIdUsuario"] != null ? HttpContext.Session["CentroIdUsuario"].ToString() : string.Empty;

            return model;
        }

        private CreateEditGrupoNecesidadViewModel GenerateViewElementsGrupoNecesidadCreateEdit(CreateEditGrupoNecesidadViewModel model)
        {
            int[] tipoMaestroId =
            {
                (int)MasterDataTypeEnum.Centro,
                (int)MasterDataTypeEnum.Oficina,
                (int)MasterDataTypeEnum.Sector,
                (int)MasterDataTypeEnum.TipoTecnologia,
                (int)MasterDataTypeEnum.TipoServicio,
                (int)MasterDataTypeEnum.TipoPerfil,
                (int)MasterDataTypeEnum.MesesAsignacion,
                (int)MasterDataTypeEnum.TipoContratacion,
                (int)MasterDataTypeEnum.TipoPrevision,
                (int)MasterDataTypeEnum.EstadoNecesidad,
                (int)MasterDataTypeEnum.Categoria,
                (int)MasterDataTypeEnum.TipoModulo,
            };

            var response = _maestroService.GetDatosMaestroByTipoId(tipoMaestroId);

            model.CentroList = (IEnumerable<SelectListItem>)HttpContext.Session["ListaCentros"];
            model.OficinaList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.Oficina);
            model.SectorList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.Sector);
            model.CategoriaList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.Categoria);
            model.EstadoList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.EstadoNecesidad);

            model.ClienteList = GenerateClienteElements();
            model.ProyectoList = GenerateProyectoElements();

            model.TecnologiaList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.TipoTecnologia);
            model.ServicioList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.TipoServicio);
            model.MesesAsignacionList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.MesesAsignacion);
            model.PerfilList = model.CategoriaList;
            model.ModuloList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.TipoModulo);

            model.ContratacionList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.TipoContratacion);
            model.PrevisionList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.TipoPrevision);

            ModalEdicionPerfilViewModel modalEdicionPerfilViewModel = new ModalEdicionPerfilViewModel();

            modalEdicionPerfilViewModel.Perfil = model.CategoriaList;
            modalEdicionPerfilViewModel.Contratacion = model.ContratacionList;
            modalEdicionPerfilViewModel.Estado = model.EstadoList;
            modalEdicionPerfilViewModel.Tecnologia = model.TecnologiaList;
            modalEdicionPerfilViewModel.Modulo = model.ModuloList;
            modalEdicionPerfilViewModel.Servicio = model.ServicioList;
            modalEdicionPerfilViewModel.Prevision = model.PrevisionList;
            model.ModalEdicionPerfil = modalEdicionPerfilViewModel;

            return model;
        }

        private CreateEditGrupoNecesidadViewModel GenerateViewElementsGrupoNecesidadTableCreateEdit(CreateEditGrupoNecesidadViewModel model)
        {
            int[] tipoMaestroId =
            {
                (int)MasterDataTypeEnum.Centro,
                (int)MasterDataTypeEnum.Oficina,
                (int)MasterDataTypeEnum.Sector,
                (int)MasterDataTypeEnum.TipoTecnologia,
                (int)MasterDataTypeEnum.TipoServicio,
                (int)MasterDataTypeEnum.TipoPerfil,
                (int)MasterDataTypeEnum.MesesAsignacion,
                (int)MasterDataTypeEnum.TipoContratacion,
                (int)MasterDataTypeEnum.TipoPrevision,
                (int)MasterDataTypeEnum.EstadoNecesidad,
                (int)MasterDataTypeEnum.Categoria,
                (int)MasterDataTypeEnum.TipoModulo,
            };

            var response = _maestroService.GetDatosMaestroByTipoId(tipoMaestroId);

            model.CentroList = (IEnumerable<SelectListItem>)HttpContext.Session["ListaCentros"];
            model.OficinaList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.Oficina);
            model.SectorList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.Sector);
            model.CategoriaList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.Categoria);
            model.EstadoList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.EstadoNecesidad);

            model.ClienteList = GenerateClienteElements();
            model.ProyectoList = GenerateProyectoElements();

            model.TecnologiaList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.TipoTecnologia);
            model.ServicioList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.TipoServicio);
            model.PerfilList = model.CategoriaList;
            model.ModuloList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.TipoModulo);

            model.MesesAsignacionList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.MesesAsignacion);
            model.ContratacionList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.TipoContratacion);
            model.PrevisionList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.TipoPrevision);
            
            return model;
        }

        private FiltroGrupoNecesidadesModels GenerateViewElementsGrupoNecesidadesIndex(FiltroGrupoNecesidadesModels filtroGrupoNecesidadesModel)
        {
            filtroGrupoNecesidadesModel.ClienteList = GenerateClienteElements();
            filtroGrupoNecesidadesModel.ProyectoList = GenerateProyectoElements();            
            filtroGrupoNecesidadesModel.CentroList = (IEnumerable<SelectListItem>)HttpContext.Session["ListaCentros"];
            filtroGrupoNecesidadesModel.CentroIdUsuarioLogueado = HttpContext.Session["CentroIdUsuario"] != null ? HttpContext.Session["CentroIdUsuario"].ToString() : string.Empty;

            return filtroGrupoNecesidadesModel;
        }

        #endregion
    }
}

#endregion
#endregion