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
using RecruitingWeb.Constantes;
using RecruitingWeb.Components.DataTable.ServerSide;

using Recruiting.Application.Maestros.Enums;
using Recruiting.Application.Roles.ViewModels;
using Recruiting.Application.Maestros.Services;
using Recruiting.Application.Clientes.Services;
using Recruiting.Application.Proyectos.Services;
using Recruiting.Application.Usuarios.ViewModels;
using Recruiting.Application.Clientes.ViewModels;
using Recruiting.Application.Proyectos.ViewModels;
using Recruiting.Application.Necesidades.Services;
using Recruiting.Application.Necesidades.ViewModels;
using Recruiting.Application.PersonasLibres.Services;
using Recruiting.Application.PersonasLibres.ViewModels;

using Recruiting.Business.Repositories;
using Recruiting.Business.BaseClasses.DataTable;

using Recruiting.Infra.Caching;
using Recruiting.Data.EntityFramework.Repositories;

namespace RecruitingWeb.Controllers
{
    public class PersonasLibresController : Controller
    {
        #region Constants

        #endregion

        #region Fields

        private readonly IPersonasLibresService _PersonaLibreService;
        private readonly IPersonaLibreRepository _PersonaLibreRepository;

        private readonly IEmpleadoFenixService _EmpleadoFenixService;

        private readonly INecesidadRepository _necesidadRepository;
        private readonly INecesidadService _necesidadService;

        private readonly IMaestroRepository _maestroRepository;
        private readonly MaestroService _maestroService;
        private readonly SessionCacheStorageService _sesionPersonasLibres;
            private readonly SessionCacheStorageService _sesionEmpleadosFenix; 
        private readonly IClienteRepository _clienteRepository;
        private readonly IClienteService _clienteService;

        private readonly IProyectoRepository _proyectoRepository;
        private readonly IProyectoService _proyectoService;

        private readonly IGrupoNecesidadRepository _grupoNecesidadRepository;
        private readonly IGrupoNecesidadService _grupoNecesidadService;

        #endregion

        #region Construct

        public PersonasLibresController()
        {

            _PersonaLibreRepository = new PersonaLibreRepository();
            _sesionPersonasLibres = new SessionCacheStorageService();
            _PersonaLibreService = new PersonaLibreService(_PersonaLibreRepository);

            _sesionEmpleadosFenix = new SessionCacheStorageService();
            _EmpleadoFenixService = new EmpleadosFenixService();
            _necesidadRepository = new NecesidadRepository();
            _necesidadService = new NecesidadService(_necesidadRepository);
            _maestroRepository = new MaestroRepository();
            _maestroService = new MaestroService(_maestroRepository);

            _clienteRepository = new ClienteRepository();
            _clienteService = new ClienteService(_clienteRepository);

            _proyectoRepository = new ProyectoRepository();
            _proyectoService = new ProyectoService(_proyectoRepository, _clienteRepository);

            _grupoNecesidadRepository = new GrupoNecesidadRepository();
            _grupoNecesidadService = new GrupoNecesidadService(_grupoNecesidadRepository, _necesidadRepository);

        }

        #endregion

        #region Index Members

        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.VerPersonasLibres)]
        public ActionResult Index()
        {
            SetVisibilidadPorPermisos();
            var filtro = _sesionPersonasLibres.Get<FiltroPersonaLibreModels>("filtro_PersonaLibre");

            if (filtro == null)
            {
                //orden por defecto
                filtro = new FiltroPersonaLibreModels()
                {
                    SortColumn = "NroEmpleado",
                    SortOrder = Recruiting.Business.BaseClasses.DataTable.DataTableSortDirectionEnum.Descending
                };
            }
            _sesionPersonasLibres.Add("filtro_inicial_personasLibres", filtro);

            filtro = GenerateViewElementsIndex(filtro);

            return View(filtro);
        }
                                
        #endregion

        #region Edit Members

        // GET: PersonasLibres/Edit/5
        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.CrearModificarPersonasLibres)]
        public ActionResult Edit(int id)
        {
            var model = new CreateEditPersonaLibreViewModel();

            var responsePersonaLibre = _PersonaLibreService.GetPersonaLibreById(id);
            if (!responsePersonaLibre.IsValid)
            {
                CreateMessageError(responsePersonaLibre.ErrorMessage);
            }
            else
            {
                model = responsePersonaLibre.PersonaLibreViewModel;
            }

            model = GenerateViewElementsEdit(model);

            return View("Edit", model);
        }
                
        // POST: PersonasLibres/Edit/5
        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.CrearModificarPersonasLibres)]
        [HttpPost]
        public ActionResult Edit(CreateEditPersonaLibreViewModel ViewModel, FormCollection collection)
        {
            try
            {
                _PersonaLibreService.UpdatePersonaLibre(ViewModel);
                var filtro = new FiltroPersonaLibreModels();
                return RedirectToAction("index", filtro);
            }
            catch(Exception e)
            {
                return View();
            }
        }
        
        #endregion

        #region Details Members  

        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.VerPersonasLibres)]
        public ActionResult Details(int id)
        {
            var model = _PersonaLibreService.GetPersonaLibreById(id).PersonaLibreViewModel;
            
            return View(model);
        }

        #endregion

        #region Create Members

        [HttpGet]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.AdministrarEmpleadosFenix)]
        public ActionResult Create()
        {
            int centroId = 0;

            if (HttpContext.Session["Usuario"] != null)
            {
                var currentUser = (UsuarioRolPermisoViewModel)HttpContext.Session["Usuario"];
                centroId = currentUser.CentroIdUsuario.Value;
            }

            var filtro = _sesionEmpleadosFenix.Get<FiltroEmpleadosFenixModels>("filtro_EmpleadoFenix") ?? new FiltroEmpleadosFenixModels();
            
            filtro = GenerateViewElementsCreate(filtro, centroId);            

            SetVisibilidadPorPermisos();

            return View(filtro);

        }


        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.VerPersonasLibres)]
        public virtual JsonResult LoadEmpleadosFenix([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
        {
            SetVisibilidadPorPermisos();

            var request = requestModel.ConvertToDataTableRequestViewModel();

            int centroId = 0;
            if (HttpContext.Session["Usuario"] != null)
            {
                var UsuarioRolPermisoViewModel = (UsuarioRolPermisoViewModel)HttpContext.Session["Usuario"];
                centroId = UsuarioRolPermisoViewModel.CentroIdUsuario.Value;
            }

            var response = _EmpleadoFenixService.GetEmpleadosFenix(request, centroId);
            var filtroEmpleadosFenixModel = MappertoFiltroEmpleadosFenix(request.CustomFilters);
            _sesionPersonasLibres.Add("filtro_PersonaLibre", filtroEmpleadosFenixModel);
            _sesionPersonasLibres.Add("pagina_actual", request.PageNumber);

            if (!response.IsValid)
            {
                return null;
            }

            var result = from c in response.EmpleadoFenixRowViewModelList
                         select new object[]
            {
                c.NroEmpleado,
                c.Nombre,
                c.Apellidos,
                c.Categoria,
                c.Linea,
                c.Celda,
                this.RenderRazorViewToString("Table/actionColumnEmpleadosFenix", c)
            };

            var centroUsuarioId = HttpContext.Session["CentroIdUsuario"];
            if ((centroUsuarioId != null) && result.Any())
            {
                var resultTemp = new List<object[]>();
                result.ToList().ForEach(x =>
                {
                    var item = x.ToList();
                    resultTemp.Add(item.ToArray());
                });
                result = resultTemp;
            }

            var jsonResponse = new DataTablesResponse(requestModel.Draw, result, response.TotalElementos, response.TotalElementos);
            return Json(jsonResponse, JsonRequestBehavior.AllowGet);
        }


        // POST: PersonasLibres/Create
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult CreatePersonasLibres(FiltroEmpleadosFenixModels viewModelList, FormCollection collection)
        {
            var personasLibresToCreate = new PersonasLibresToCreateViewModel();
            personasLibresToCreate.PersonaLibreRowViewModelList = new List<PersonaLibreRowViewModel>();
            foreach (PersonaLibreRowViewModel personaLibre in viewModelList.PersonaLibreRowViewModelList)
            {
                if (personaLibre.isChecked)
                {
                    {
                        personasLibresToCreate.PersonaLibreRowViewModelList.Add(personaLibre);
                    }
                }
            }
            if (!personasLibresToCreate.PersonaLibreRowViewModelList.Any())
            {
                return View("Create", viewModelList);
            }
            int[] tipoMaestroId = { (int)MasterDataTypeEnum.TipoTecnologia , (int)MasterDataTypeEnum.NivelIdioma };
            var response = _maestroService.GetDatosMaestroByTipoId(tipoMaestroId);
            personasLibresToCreate.ListaTecnologias = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.TipoTecnologia);
            personasLibresToCreate.NivelIdiomaList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.NivelIdioma);
            return View("CreateStepTwo", personasLibresToCreate);
        }

        [HttpGet]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.ActualizarCategoriaLineaCelda)]
        public ActionResult UpdateCategoriaLineaCeldaInRecruitingDb()
        {
            int centroId = 0;
            if (HttpContext.Session["Usuario"] != null)
            {
                var UsuarioRolPermisoViewModel = (UsuarioRolPermisoViewModel)HttpContext.Session["Usuario"];
                centroId = UsuarioRolPermisoViewModel.CentroIdUsuario.Value;
            }

            _EmpleadoFenixService.UpdateCategoriaLineaCeldaInRecruitingDb(centroId);

            var filtro = _sesionEmpleadosFenix.Get<FiltroEmpleadosFenixModels>("filtro_EmpleadoFenix");
            var listaCategoriaLineaCelda = _EmpleadoFenixService.GetListEmpleadosFenixCategoriaLineaCelda(centroId);
            if (filtro == null)
            {
                filtro = new FiltroEmpleadosFenixModels();
            }
            filtro.EmpleadosFenixListCategoriaLineaCelda = listaCategoriaLineaCelda.EmpleadosFenixListCategoriaLineaCeldaviewModel;

            var categoriaLineaCeldaPersonasLibres = _PersonaLibreService.GetListCategoriaLineaCelda();
            if (categoriaLineaCeldaPersonasLibres.IsValid)
            {
                HttpContext.Session.Remove("CategoriaLineaCelda");
                HttpContext.Session.Add("CategoriaLineaCelda", categoriaLineaCeldaPersonasLibres.PersonasLibresListCategoriaLineaCeldaviewModel);
            }

            SetVisibilidadPorPermisos();

            var pagina = _sesionEmpleadosFenix.Get<int>("pagina_actual");
            if (pagina > 0)
            {
                filtro.Pagina = pagina;
            }
            
            return RedirectToAction("Create", filtro);

        }

        #endregion
        //---------------------------------------------- LIMITE ORDER ----------------------------------------------//

        #region Actions

        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.CrearModificarPersonasLibres)]
        [ValidateInput(false)]
        public JsonResult EnlazaNecesidadConPersonaLibre(string jsonData)
        {
            var jsonObject = Newtonsoft.Json.Linq.JObject.Parse(jsonData);
            var response = new JsonResult();

            var idNecesidad = jsonObject["idNecesidad"];
            var idEstadoNuevo = jsonObject["estadoNuevo"];
            var idPersonaLibre = jsonObject["idPersonaLibre"];

            var personaLibreAActualizar = _PersonaLibreService.GetPersonaLibreById((int)idPersonaLibre);
            var necesidadAActualizar = _necesidadService.GetNecesidadById((int)idNecesidad);
            if (necesidadAActualizar.IsValid && personaLibreAActualizar.IsValid)
            {
                necesidadAActualizar.NecesidadViewModel.EstadoNecesidadId = (int)idEstadoNuevo;
                necesidadAActualizar.NecesidadViewModel.PersonaAsignada = personaLibreAActualizar.PersonaLibreViewModel.Nombre + " " + personaLibreAActualizar.PersonaLibreViewModel.Apellidos;
                necesidadAActualizar.NecesidadViewModel.PersonaAsignadaId = (int)idPersonaLibre;
                necesidadAActualizar.NecesidadViewModel.PersonaAsignadaNroEmpleado = Convert.ToInt32(personaLibreAActualizar.PersonaLibreViewModel.NroEmpleado);
                if ((int)idEstadoNuevo == (int)EstadoNecesidadEnum.Cerrada)
                {
                    necesidadAActualizar.NecesidadViewModel.FechaCierre = System.DateTime.Now;
                }
                response.Data = _necesidadService.SaveNecesidad(necesidadAActualizar.NecesidadViewModel);
                if(necesidadAActualizar.NecesidadViewModel.GrupoNecesidad.HasValue &&
                    (int)idEstadoNuevo == (int)EstadoNecesidadEnum.Cerrada)
                {
                    _grupoNecesidadService.CheckGrupoCerrado(necesidadAActualizar.NecesidadViewModel.GrupoNecesidad.Value);
                }
            }
            return response;
        }

        #region Index UI
        // GET: PersonasLibres

        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.VerPersonasLibres)]
        public virtual JsonResult LoadPersonasLibres([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
        {
            SetVisibilidadPorPermisos();

            var request = requestModel.ConvertToDataTableRequestViewModel();
            request.CustomFilters.Add("IsActivo", "true");
            if (request.CustomFilters.ContainsKey("CentroSearch"))
            {
                var centroSearch = request.CustomFilters["CentroSearch"];
                request.CustomFilters.Add("Centro", centroSearch);
            }
            else if (HttpContext.Session["Usuario"] != null)
            {
                var UsuarioRolPermisoViewModel = (UsuarioRolPermisoViewModel)HttpContext.Session["Usuario"];
                var centroId = UsuarioRolPermisoViewModel.CentroIdUsuario.ToString();
                request.CustomFilters.Add("Centro", centroId);
            }

            var filtro = _sesionPersonasLibres.Get<FiltroPersonaLibreModels>("filtro_inicial_personasLibres");
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

            var response = _PersonaLibreService.GetPersonasLibres(request);

            var filtroPersonaLibreModel = MappertoFiltroPersonasLibres(request.CustomFilters);

            if (filtro != null)
            {
                filtroPersonaLibreModel.SortOrder = filtro.SortOrder;
                filtroPersonaLibreModel.SortColumn = filtro.SortColumn;
            }

            _sesionPersonasLibres.Add("filtro_PersonaLibre", filtroPersonaLibreModel);
            _sesionPersonasLibres.Add("pagina_actual", request.PageNumber);

            if (!response.IsValid)
            {
                return null;
            }

            int[] tipoMaestroId = { (int)MasterDataTypeEnum.TipoTecnologia };
            var maestroResponse = _maestroService.GetDatosMaestroByTipoId(tipoMaestroId);
            var listaTecnologias = ControllerHelper.GenerateElements(maestroResponse, MasterDataTypeEnum.TipoTecnologia).ToList();

            var result = from pl in response.PersonaLibreRowViewModel
                             select new object[]
            {
                pl.NroEmpleado,
                pl.Nombre,
                pl.Apellidos,
                pl.Categoria,
                pl.Linea,
                pl.Celda,
                (pl.TipoTecnologiaId == null)  ? "--------------------" : listaTecnologias.Single(x => x.Value == pl.TipoTecnologiaId.ToString()).Text,                
                (pl.NecesidadId == null)  ? "--------------------" : string.Format("<a href=\"/Necesidades/Details/{0}\">{0}</a>", pl.NecesidadId.ToString()),
                pl.NivelIdioma,
                FormatHelper.Format(pl.FechaLiberacion, "dd/MM/yyyy"),
                this.RenderRazorViewToString("Table/actionColumn", pl)
            };           

            var jsonResponse = new DataTablesResponse(requestModel.Draw, result, response.TotalElementos, response.TotalElementos);
            return Json(jsonResponse, JsonRequestBehavior.AllowGet);
        }

        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.VerPersonasLibres)]
        public virtual JsonResult LoadNecesidadesAbiertasCambioInterno([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
        {
            var request = requestModel.ConvertToDataTableRequestViewModel();
            request.CustomFilters.Add("Estados", ((int)EstadoNecesidadEnum.Abierta).ToString());
            request.CustomFilters.Add("TipoContratacionId", ((int)TipoContratacionEnum.CambioInterno).ToString());
            request.CustomFilters.Add("Prevision", ((int)TipoPrevisionEnum.Confirmado).ToString());
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
            var response = _necesidadService.GetNecesidadesPersonasLibres(request);

            if (!response.IsValid)
            {
                return null;
            }

            var seleccionadorEstado = new EstadoNecesidadSelectViewModel();
            seleccionadorEstado.NecesidadPreasignadaOCerrada = new List<SelectListItem>
            {
                new SelectListItem { Text=EstadoNecesidadEnum.Preasignada.ToString() ,Value=((int)EstadoNecesidadEnum.Preasignada).ToString() },
                new SelectListItem { Text=EstadoNecesidadEnum.Cerrada.ToString() ,Value=((int)EstadoNecesidadEnum.Cerrada).ToString() }
            };

            var result = from c in response.NecesidadViewModel
                         select new object[]
            {
                c.NecesidadId.ToString(),
                c.Cliente,
                c.Proyecto,
                c.Tecnologia,
                c.Perfil,
                FormatHelper.Format((c.FechaSolicitud), "dd/MM/yyyy"),
                FormatHelper.Format((c.FechaCompromiso), "dd/MM/yyyy"),
                this.RenderRazorViewToString("Table/actionSeleccionadorNecesidad", seleccionadorEstado),
                this.RenderRazorViewToString("Table/actionRadioButton",c),
                c.Nombre,
                c.NecesidadId,
                c.Modulo,
            };


            var jsonResponse = new DataTablesResponse(requestModel.Draw, result, response.TotalElementos, response.TotalElementos);

            return Json(jsonResponse, JsonRequestBehavior.AllowGet);
        }


        #endregion

        #region Delete UI

        // POST: PersonasLibres/Delete/*
        [ValidateInput(false)]
        [HttpPost]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.CrearModificarPersonasLibres)]
        public JsonResult Delete(int id)
        {
            var respose = new JsonResult();
            respose.Data = _PersonaLibreService.DeletePersonaLibre(id);
            return respose;
        }

        #endregion 

        public ActionResult IndexError()
        {
            TempData["ErrorPermiso"] = true;
            var filtro = _sesionPersonasLibres.Get<FiltroPersonaLibreModels>("filtro_PersonaLibre");

            if (filtro == null)
            {
                filtro = new FiltroPersonaLibreModels();
            }

            filtro = GenerateViewElementsIndex(filtro);

            return View("Index", filtro);
        }


        //Esta acción nos permite volver desde otra página con el filtro
        public ActionResult Volver()
        {
            return RedirectToAction("Index");
        }
        
        [ValidateInput(false)]
        [HttpPost]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.CrearModificarPersonasLibres)]
        public ActionResult CreateFinish(PersonasLibresToCreateViewModel personasAGuardar, FormCollection collection)
        {
            _PersonaLibreService.SavePersonasLibres(personasAGuardar);
            var filtro = new FiltroPersonaLibreModels();
            return RedirectToAction("index", filtro);
        }

        #region Limpiar

        public ActionResult Limpiar()
        {
            _sesionPersonasLibres.Remove("filtro_PersonaLibre");
            return RedirectToAction("Index");
        }

        public ActionResult LimpiarTablaCreacionEmpleadosFenix()
        {
            _sesionPersonasLibres.Remove("filtro_EmpleadoFenix");
            return RedirectToAction("Create");
        }

        #endregion


        #region ExportToExcel
        public void ExportToExcel(string filterNroEmpleado, string filterNombre, string filterApellidos, string filterCategoria, string filterLinea,
            string filterCelda, string filterFechaLiberacion,string filterTipoTecnologiaId, string filterCentro, string filterSinNecesidadAsignada, string filterNivelIdioma)
        {
            IDictionary<string, string> CustomFilters = new Dictionary<string, string> {
                    { "NroEmpleado", filterNroEmpleado },
                    { "Nombre", filterNombre },
                    { "Apellidos",filterApellidos},
                    { "Categoria",filterCategoria },
                    { "Linea", filterLinea},
                    { "Celda", filterCelda},
                    { "FechaLiberacion", filterFechaLiberacion },
                    {"TipoTecnologiaId" , filterTipoTecnologiaId },
                    { "CentroSearch", filterCentro },
                    { "SinNecesidadAsignada", filterSinNecesidadAsignada },
                    { "NivelIdioma" , filterNivelIdioma }
                };

            //filtro por el centro
            if (HttpContext.Session["Usuario"] != null)
            {
                var UsuarioRolPermisoViewModel = (UsuarioRolPermisoViewModel)HttpContext.Session["Usuario"];
                if (UsuarioRolPermisoViewModel.CentroIdUsuario != null)
                {
                    CustomFilters.Add("Centro", HttpContext.Session["CentroIdUsuario"].ToString());
                }

            }

            var request = new DataTableRequest();
            request.CustomFilters = CustomFilters;
            var response = _PersonaLibreService.GetPersonasLibresExportToExcel(request);



            var grid = new System.Web.UI.WebControls.GridView();
            grid.DataSource = response.PersonaLibreRowExportToExcelViewModel;
            grid.DataBind();
            Response.ClearContent();
            string filename = string.Format("Listado_de_PersonasLibres_{0}", DateTime.Now.ToShortDateString() + ".xls");
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

        #region Private Methods

        private void SetVisibilidadPorPermisos()
        {
            TempData[PermisosConst.VerPersonasLibres] = false;
            TempData[PermisosConst.CrearModificarPersonasLibres] = false;
            TempData[PermisosConst.ActualizarCategoriaLineaCelda] = false;
            TempData[PermisosConst.AdministrarEmpleadosFenix] = false;

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

            if (privilegeLevels.Contains(PermisosConst.VerPersonasLibres)) TempData[PermisosConst.VerPersonasLibres] = true;
            if (privilegeLevels.Contains(PermisosConst.CrearModificarPersonasLibres)) TempData[PermisosConst.CrearModificarPersonasLibres] = true;
            if (privilegeLevels.Contains(PermisosConst.AdministrarEmpleadosFenix)) TempData[PermisosConst.AdministrarEmpleadosFenix] = true;
            if (privilegeLevels.Contains(PermisosConst.ActualizarCategoriaLineaCelda)) TempData[PermisosConst.ActualizarCategoriaLineaCelda] = true;
        }
                
        private void CreateMessageError(string textMessg)
        {
            @ViewBag.ShowMessage = true;
            @ViewBag.TypeMessage = TypeMessageEnum.ErrorMessage;
            @ViewBag.TitleMessage = Properties.Resources.PersonaLibre_ErrorTitulo;
            @ViewBag.TextMessage = textMessg;

        }
        
        private FiltroPersonaLibreModels MappertoFiltroPersonasLibres(IDictionary<string, string> filtro)
        {
            var filtroPersonaLibreModels = new FiltroPersonaLibreModels();

            if (filtro.Count != 0)
            {
                string value;
                if (filtro.ContainsKey("Nombre"))
                {
                    value = filtro["Nombre"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroPersonaLibreModels.Nombre = value;
                    }
                }

                if (filtro.ContainsKey("Apellidos"))
                {
                    value = filtro["Apellidos"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroPersonaLibreModels.Apellidos = value;
                    }
                }

                if (filtro.ContainsKey("Categoria"))
                {
                    value = filtro["Categoria"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroPersonaLibreModels.Categoria = value;
                    }
                }

                if (filtro.ContainsKey("Linea"))
                {
                    value = filtro["Linea"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroPersonaLibreModels.Linea = value;
                    }
                }

                if (filtro.ContainsKey("Celda"))
                {
                    value = filtro["Celda"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroPersonaLibreModels.Celda = value;
                    }
                }

                if (filtro.ContainsKey("NroEmpleado"))
                {
                    value = filtro["NroEmpleado"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroPersonaLibreModels.NumeroEmpleado = Convert.ToInt32(value);
                    }
                }

                if (filtro.ContainsKey("SinNecesidadAsignada"))
                {
                    value = filtro["SinNecesidadAsignada"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroPersonaLibreModels.SinNecesidadAsignada = value;
                    }
                }

                if (filtro.ContainsKey("TipoTecnologiaId"))
                {
                    value = filtro["TipoTecnologiaId"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroPersonaLibreModels.TipoTecnologiaId = Convert.ToInt32(value);
                    }
                }

                if (filtro.ContainsKey("CentroUsuarioId"))
                {
                    value = filtro["CentroUsuarioId"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroPersonaLibreModels.CentroIdUsuario = Convert.ToInt32(value);
                    }
                }

                if (filtro.ContainsKey("CentroSearch"))
                {
                    
                    value = filtro["CentroSearch"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroPersonaLibreModels.CentroIdUsuario = Convert.ToInt32(value);
                       
                    }
                }
               
            }

            return filtroPersonaLibreModels;
        }

        private FiltroPersonaLibreModels MappertoFiltroEmpleadosFenix(IDictionary<string, string> filtro)
        {
            var filtroPersonaLibreModels = new FiltroPersonaLibreModels();

            if (filtro.Count != 0)
            {
                string value;
                if (filtro.ContainsKey("Nombre"))
                {
                    value = filtro["Nombre"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroPersonaLibreModels.Nombre = value;
                    }
                }

                if (filtro.ContainsKey("Apellidos"))
                {
                    value = filtro["Apellidos"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroPersonaLibreModels.Apellidos = value;
                    }
                }

                if (filtro.ContainsKey("Categoria"))
                {
                    value = filtro["Categoria"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroPersonaLibreModels.Categoria = value;
                    }
                }

                if (filtro.ContainsKey("Linea"))
                {
                    value = filtro["Linea"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroPersonaLibreModels.Linea = value;
                    }
                }

                if (filtro.ContainsKey("Celda"))
                {
                    value = filtro["Celda"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroPersonaLibreModels.Celda = value;
                    }
                }

                if (filtro.ContainsKey("NroEmpleado"))
                {
                    value = filtro["NroEmpleado"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroPersonaLibreModels.NumeroEmpleado = Convert.ToInt32(value);
                    }
                }

                if (filtro.ContainsKey("CentroUsuarioId"))
                {
                    value = filtro["CentroUsuarioId"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroPersonaLibreModels.CentroIdUsuario = Convert.ToInt32(value);
                    }
                }

                if (filtro.ContainsKey("CentroSearch"))
                {
                    value = filtro["CentroSearch"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroPersonaLibreModels.CentroIdUsuario = Convert.ToInt32(value);
                    }
                }               
            }

            return filtroPersonaLibreModels;
        }
     
        private IEnumerable<SelectListItem> GenerateNecesidadesProyectoElements()
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

        private IEnumerable<SelectListItem> GenerateNecesidadesClienteElements()
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


        private FiltroPersonaLibreModels GenerateViewElementsIndex(FiltroPersonaLibreModels filtro)
        {
            int[] tipoMaestroId =
            {
                (int)MasterDataTypeEnum.TipoTecnologia,
                (int)MasterDataTypeEnum.Categoria,
                (int)MasterDataTypeEnum.NivelIdioma,
            };

            var maestroResponse = _maestroService.GetDatosMaestroByTipoId(tipoMaestroId);

            filtro.ListasModalNecesidades.ClienteList = GenerateNecesidadesClienteElements();
            filtro.ListasModalNecesidades.PerfilList = ControllerHelper.GenerateElements(maestroResponse, MasterDataTypeEnum.Categoria);
            filtro.ListasModalNecesidades.ProyectoList = GenerateNecesidadesProyectoElements();
            filtro.TecnologiaList = ControllerHelper.GenerateElements(maestroResponse, MasterDataTypeEnum.TipoTecnologia);
            filtro.CentroList = (IEnumerable<SelectListItem>)HttpContext.Session["ListaCentros"];
            filtro.CentroIdUsuarioLogueado = HttpContext.Session["CentroIdUsuario"] != null ? HttpContext.Session["CentroIdUsuario"].ToString() : string.Empty;
            filtro.Pagina = _sesionPersonasLibres.Get<int>("pagina_actual") > 0 ? _sesionPersonasLibres.Get<int>("pagina_actual") : 0;
            filtro.NivelIdiomaList = ControllerHelper.GenerateElements(maestroResponse, MasterDataTypeEnum.NivelIdioma);

            return filtro;
        }

        private FiltroEmpleadosFenixModels GenerateViewElementsCreate(FiltroEmpleadosFenixModels filtro, int centroId)
        {
            var listaCategoriaLineaCelda = _EmpleadoFenixService.GetListEmpleadosFenixCategoriaLineaCelda(centroId);

            filtro.EmpleadosFenixListCategoriaLineaCelda = listaCategoriaLineaCelda.EmpleadosFenixListCategoriaLineaCeldaviewModel;

            filtro.CentroList = (IEnumerable<SelectListItem>)HttpContext.Session["ListaCentros"];
            filtro.CentroIdUsuarioLogueado = HttpContext.Session["CentroIdUsuario"] != null ? HttpContext.Session["CentroIdUsuario"].ToString() : string.Empty;
            filtro.Pagina = _sesionEmpleadosFenix.Get<int>("pagina_actual") > 0 ? _sesionEmpleadosFenix.Get<int>("pagina_actual") : 0;

            return filtro;
        }

        private CreateEditPersonaLibreViewModel GenerateViewElementsEdit(CreateEditPersonaLibreViewModel model)
        {
            int[] tipoMaestroId = {
                (int)MasterDataTypeEnum.TipoTecnologia,
                (int)MasterDataTypeEnum.NivelIdioma
            };

            var response = _maestroService.GetDatosMaestroByTipoId(tipoMaestroId);

            model.TecnologiaList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.TipoTecnologia);
            model.NivelIdiomaList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.NivelIdioma);

            return model;
        }

        #endregion

    }
}