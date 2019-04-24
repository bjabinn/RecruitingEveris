using Recruiting.Application.Clientes.Services;
using Recruiting.Application.Clientes.ViewModels;
using Recruiting.Application.Maestros.Enums;
using Recruiting.Application.Maestros.Services;
using Recruiting.Application.Permisos.Services;
using Recruiting.Application.Proyectos.Services;
using Recruiting.Application.Proyectos.ViewModels;
using Recruiting.Application.Roles.Services;
using Recruiting.Application.Roles.ViewModels;
using Recruiting.Application.Usuarios.Services;
using Recruiting.Application.Usuarios.ViewModels;
using Recruiting.Business.Repositories;
using Recruiting.Data.EntityFramework.Repositories;
using Recruiting.Infra.Caching;
using RecruitingWeb.Components.DataTable.ServerSide;
using RecruitingWeb.Constantes;
using RecruitingWeb.Enums;
using RecruitingWeb.Helpers;
using RecruitingWeb.Models;
using RecruitingWeb.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace RecruitingWeb.Controllers
{

    public class AdminController : Controller
    {        
        #region Constants
        private readonly string TAB_ROL = "tab-rol";
        private readonly string TAB_USER = "tab-user";
        private readonly string TAB_CLIENTES = "tab-clientes";
        private readonly string TAB_PROYECTOS = "tab-proyectos";
        #endregion

        #region Fields

        private readonly IUsuarioService _usuarioService;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IRolService _rolService;
        private readonly IRolRepository _rolRepository;
        private readonly IPermisoService _permisoService;
        private readonly IPermisoRepository _permisoRepository;

        private readonly IClienteRepository _clienteRepository;
        private readonly IClienteService _clienteService;

        private readonly IProyectoRepository _proyectoRepository;
        private readonly IProyectoService _proyectoService;

        private readonly IMaestroRepository _maestroRepository;
        private readonly MaestroService _maestroService;
        private readonly SessionCacheStorageService _sesionUsuario;

        #endregion

        #region Construct

        public AdminController()
        {
            _usuarioRepository = new UsuarioRepository();
            _usuarioService = new UsuarioService(_usuarioRepository);
            _rolRepository = new RolRepository();
            _rolService = new RolService(_rolRepository, _usuarioRepository);
            _permisoRepository = new PermisoRepository();
            _permisoService = new PermisoService(_permisoRepository);
            _sesionUsuario = new SessionCacheStorageService();

            _maestroRepository = new MaestroRepository();
            _maestroService = new MaestroService(_maestroRepository);

            _clienteRepository = new ClienteRepository();
            _clienteService = new ClienteService(_clienteRepository);

            _proyectoRepository = new ProyectoRepository();
            _proyectoService = new ProyectoService(_proyectoRepository, _clienteRepository);
        }

        #endregion

        #region Admin
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.AdministrarUsuariosClientesYProyectos)]
        public ActionResult Index(string tab = null, string message = null, bool isError = false)
        {
            GenerateViewBags();
            GenerateViewBagsPermisos();
            RellenarCentrosYClientes();          

            if (!string.IsNullOrWhiteSpace(message))
            {
                if (isError)
                {
                    CreateMessageError(message);
                }
                else
                {
                    CreateMessageNotify(message);
                }
            }

            return View(model: tab);
        }
        
        #endregion

        #region Usuarios

        public virtual JsonResult LoadUsuarios([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
        {
            var request = requestModel.ConvertToDataTableRequestViewModel();

            var response = _usuarioService.GetUsuarios(request);

            if (!response.IsValid)
            {
                return null;
            }


            //Almaceno el filtro en caché
            var filtroUsuariosModel = MappertoFiltroUsuarios(request.CustomFilters);
            _sesionUsuario.Add("filtro_usuario", filtroUsuariosModel);


            var result = from c in response.UsuarioViewModel
                         select new object[]
            {
                c.Usuario,
                String.Join(" , ",c.Roles.Select(x=> x.RolNombre)),
                this.RenderRazorViewToString("actionColumnUsuarios", c)
            };

            var jsonResponse = new DataTablesResponse(requestModel.Draw, result, response.TotalElementos, response.TotalElementos);
            return Json(jsonResponse, JsonRequestBehavior.AllowGet);
        }

        #region Create Usuarios UI

        [HttpPost]
        public JsonResult ComprobarUserNameUsado(int IdUsuario, string UserName)
        {
            var response = _usuarioService.SearchUserNameUsado(IdUsuario, UserName);
            return Json(response, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.AdministrarUsuariosClientesYProyectos)]
        public ActionResult CreateUsuarios(int? id = null)
        {
            var model = new CreateEditUsuarioViewModel();
            model.UsuarioRol = new List<UsuarioRolViewModel>();

            if (id.HasValue)
            {
                model = _usuarioService.GetUsuarioById((int)id).UsuarioViewModel;
            }

            RellenaRoles(model);
            RellenaCentros();
            return View("CreateUsuarios", model);
        }

        // POST: Usuarios/Create
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(CreateEditUsuarioViewModel viewModel, FormCollection collection)
        {
            viewModel.UsuarioRol = viewModel.UsuarioRol == null ? new List<UsuarioRolViewModel>() : viewModel.UsuarioRol;

            var response = _usuarioService.SaveUsuario(viewModel);

            return RedirectToAction("Index", routeValues: new { tab = TAB_USER, message = response.ErrorMessage, isError = !response.IsValid });
        }
        #endregion

        #region Edit Usuarios UI
        // GET: Usuarios/Edit/id
        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.AdministrarUsuariosClientesYProyectos)]
        public ActionResult Edit(int id)
        {
            var model = new CreateEditUsuarioViewModel();

            var response = _usuarioService.GetUsuarioById(id);

            if(response.UsuarioViewModel.Activo)
            {
                RellenaRoles(response.UsuarioViewModel);
                RellenaCentros();
            }           
            if (!response.IsValid)
            {
                CreateMessageError(response.ErrorMessage);
            }
            else
            {
                model = response.UsuarioViewModel;
            }

            return View("EditUsuarios", model);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit(CreateEditUsuarioViewModel viewModel, FormCollection collection)
        {
            var response = _usuarioService.SaveUsuario(viewModel);
            var usuarioActualId = (int)HttpContext.Session["UsuarioId"];

            if(response.IsValid && usuarioActualId == response.UsuarioId)
            {
                var responseUsuarioActualiza = _usuarioService.GetUsuarioRolPermisoByUserName(viewModel.UserName);
                HttpContext.Session.Add("Usuario", responseUsuarioActualiza.UsuarioRolPermisoViewModel);
            }

            return RedirectToAction("Index", routeValues: new { tab = TAB_USER, message = response.ErrorMessage, isError = !response.IsValid });
        }
        #endregion

        #region Delete UI

        // POST: Usuarios/Delete/*
        [ValidateInput(false)]
        [HttpPost]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.AdministrarUsuariosClientesYProyectos)]
        public JsonResult Delete(int id)
        {
            var respose = new JsonResult();
            respose.Data = _usuarioService.DeleteUsuario(id);
            return respose;
        }

        #endregion

        #region Autocomplete

        [HttpPost]
        public JsonResult GetUsuariosByNombreUsuario(string textSearch)
        {
            var response = _usuarioService.GetUsuariosByNombreUsuario(textSearch);

            var isValid = response.IsValid;
            var errorMessage = response.ErrorMessage;
            var usuarios = response.Usuarios.Select(x => new SelectListItem()
            {
                Text = x.Usuario,
                Value = x.UsuarioId.ToString()
            });

            return Json(new { IsValid = isValid, ErrorMessage = errorMessage, Items = usuarios });
        }//GetUsuariosByNombreUsuario

        [HttpPost]
        public JsonResult GetUsuariosEntrevistadoresByNombreUsuario(string textSearch)
        {
            var response = _usuarioService.GetUsuariosEntrevistadoresByNombreUsuarioYCentro(textSearch);

            var isValid = response.IsValid;
            var errorMessage = response.ErrorMessage;
            var usuarios = response.Usuarios.Select(x => new SelectListItem()
            {
                Text = x.Usuario,
                Value = x.UsuarioId.ToString()
            });

            return Json(new { IsValid = isValid, ErrorMessage = errorMessage, Items = usuarios });
        }

        #endregion
        #endregion

        #region Roles

        public virtual JsonResult LoadRoles([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
        {
            var request = requestModel.ConvertToDataTableRequestViewModel();

            var response = _rolService.GetRoles(request);

            if (!response.IsValid)
            {
                return null;
            }

            var result = from c in response.RolViewModel
                         select new object[]
            {
               c.Nombre,
               String.Join(" , ",c.Permisos.Select(x=> x.PermisoNombre)),
               this.RenderRazorViewToString("actionColumnRoles", c)
            };

            var jsonResponse = new DataTablesResponse(requestModel.Draw, result, response.TotalElementos, response.TotalElementos);
            return Json(jsonResponse, JsonRequestBehavior.AllowGet);
        }

        #region Create Roles UI
        [HttpGet]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.AdministrarRoles)]
        public ActionResult CreateRoles(int? id = null)
        {
            var model = new CreateEditRolViewModel();
            model.UsuarioRol = new List<UsuarioRolViewModel>();
            model.PermisoRol = new List<PermisoRolViewModel>();

            if (id.HasValue)
            {
                model = _rolService.GetRolById((int)id).RolViewModel;
            }
            RellenaPermisos(model);
            return View("CreateRoles", model);
        }

        // POST: Roles/Create
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult CreateRoles(CreateEditRolViewModel viewModel, FormCollection collection)
        {
            viewModel.UsuarioRol = viewModel.UsuarioRol == null ? new List<UsuarioRolViewModel>() : viewModel.UsuarioRol;
            viewModel.PermisoRol = viewModel.PermisoRol == null ? new List<PermisoRolViewModel>() : viewModel.PermisoRol;

            var response = _rolService.SaveRol(viewModel);

            return RedirectToAction("Index", routeValues: new { tab = TAB_ROL, message = response.ErrorMessage, isError = !response.IsValid });
        }
        #endregion

        #region Edit Roles UI
        // GET: Roles/Edit/id
        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.AdministrarRoles)]
        public ActionResult EditRoles(int id)
        {
            var model = new CreateEditRolViewModel();

            var response = _rolService.GetRolById(id);
            RellenaPermisos(response.RolViewModel);

            if (!response.IsValid)
            {
                CreateMessageError(response.ErrorMessage);
            }
            else
            {
                model = response.RolViewModel;
            }

            return View("EditRoles", model);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult EditRoles(CreateEditRolViewModel viewModel, FormCollection collection)
        {
            var response = _rolService.SaveRol(viewModel);

            return RedirectToAction("Index", routeValues: new { tab = TAB_ROL, message = response.ErrorMessage, isError = !response.IsValid });
        }
        #endregion

        #region Delete UI

        // POST: Roles/Delete/*
        [ValidateInput(false)]
        [HttpPost]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.AdministrarRoles)]
        public JsonResult DeleteRol(int id)
        {
            var response = new JsonResult();
            response.Data = _rolService.DeleteRol(id);
            return response;
        }

        #endregion
        #endregion Roles

        #region Clientes
        [ValidateInput(false)]
        [HttpPost]
        public JsonResult CheckClienteRepetido(int clienteId, string nombreCliente)
        {
            var response = new JsonResult();
            response.Data = _clienteService.CheckClienteRepetido(clienteId, nombreCliente);

            return response;
        }   
            
            
        


        public virtual JsonResult LoadClientes([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
        {
            var request = requestModel.ConvertToDataTableRequestViewModel();

            var response = _clienteService.GetClientes(request);

            if (!response.IsValid)
            {
                return null;
            }

            var result = from c in response.ClienteViewModel
                         select new object[]
            {
               c.Nombre,              
               this.RenderRazorViewToString("actionColumnClientes", c)
            };

            var jsonResponse = new DataTablesResponse(requestModel.Draw, result, response.TotalElementos, response.TotalElementos);
            return Json(jsonResponse, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        //[RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.AdministrarUsuariosClientesYProyectos)]
        public ActionResult CreateEditCliente(int? id = null)
        {
            RellenaCentros();
            if (!id.HasValue)
            {
                return View(new ClienteRowViewModel());
            }

            var response = _clienteService.GetCliente(id.Value);

            var model = response.Cliente;
            if (!response.IsValid)
            {
                CreateMessageError(response.ErrorMessage);
                model = new ClienteRowViewModel();
            }

            return View(model);
        }

        // POST: Cliente/Create or Edit
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult CreateEditCliente(ClienteRowViewModel viewModel, FormCollection collection)
        {
            var response = _clienteService.SaveCliente(viewModel);

            return RedirectToAction("Index", routeValues: new { tab = TAB_CLIENTES, message = response.ErrorMessage, isError = !response.IsValid });
        }

        [HttpPost]
        public JsonResult ComprobarClienteUsado(int ClienteId)
        {
            var response = _clienteService.SearchClienteUsado(ClienteId);
            return Json(response, JsonRequestBehavior.AllowGet);

        }

        // POST: Roles/Delete/*
        [ValidateInput(false)]
        [HttpPost]
        //[RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.AdministrarUsuariosClientesYProyectos)]
        public JsonResult DeleteCliente(int id)
        {
            var respose = new JsonResult();
            respose.Data = _clienteService.DeleteCliente(id);
            return respose;
        }


        #endregion

        #region Proyectos
        public virtual JsonResult LoadProyectos([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
        {
            var request = requestModel.ConvertToDataTableRequestViewModel();

            var response = _proyectoService.GetProyectos(request);

            if (!response.IsValid)
            {
                return null;
            }

            var result = from c in response.ProyectoViewModel
                         select new object[]
            {
               c.Nombre,
               c.Cliente,
               c.Persona,
               c.Centro,
               this.RenderRazorViewToString("actionColumnProyecto", c)
            };

            var jsonResponse = new DataTablesResponse(requestModel.Draw, result, response.TotalElementos, response.TotalElementos);
            return Json(jsonResponse, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        //[RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.AdministrarUsuariosClientesYProyectos)]
        public ActionResult CreateEditProyecto(int? id = null)
        {
            RellenarCentrosYClientes();
            ProyectoRowViewModel model;

            if (id.HasValue)
            {
                var response = _proyectoService.GetProyecto(id.Value);             
                if (!response.IsValid)
                {
                    CreateMessageError(response.ErrorMessage);
                    model = new ProyectoRowViewModel();
                }
                else
                {
                    model = response.Proyecto;
                }
            }
            else
            {
                model = new ProyectoRowViewModel();
            }

            model.SectorList = RellenaSectores();
            model.ServicioList = RellenaServicio();

            return View(model);
        }

        // POST: Cliente/Create or Edit
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult CreateEditProyecto(ProyectoRowViewModel viewModel, FormCollection collection)
        {
            var response = _proyectoService.SaveProyecto(viewModel);
            

            return RedirectToAction("Index", routeValues: new { tab = TAB_PROYECTOS, message = response.ErrorMessage, isError = !response.IsValid });
        }

        [HttpPost]
        public JsonResult ComprobarProyectoUsado(int ProyectoId)
        {
            var response = _proyectoService.SearchProyectoUsado(ProyectoId);
            return Json(response, JsonRequestBehavior.AllowGet);

        }


        // POST: Roles/Delete/*
        [ValidateInput(false)]
        [HttpPost]
        //[RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.AdministrarUsuariosClientesYProyectos)]
        public JsonResult DeleteProyecto(int id)
        {
            var respose = new JsonResult();
            respose.Data = _proyectoService.DeleteProyecto(id);
            return respose;
        }


        #endregion

        #region metodos privados
        private void GenerateViewBags()
        {
            var responseRol = _rolService.GetRoles();

            List<SelectListItem> listRoles = new List<SelectListItem>();
            SelectListItem aux;

            foreach (var rol in responseRol.RolViewModel)
            {
                aux = new SelectListItem();
                aux.Value = rol.RolId.ToString();
                aux.Text = rol.Nombre;
                listRoles.Add(aux);
            }

            ViewBag.listRoles = listRoles;

            if (TempData["ErrorPermiso"] != null)
            {
                bool varErrorPermiso = (bool)TempData["ErrorPermiso"];
                if (varErrorPermiso)
                {
                    ViewBag.ShowMessage = true;
                    ViewBag.TypeMessage = TypeMessageEnum.PermisoMessage;
                    ViewBag.TitleMessage = "Permiso";
                    ViewBag.TextMessage = "Usted no tiene permisos para realizar esta acción.";
                }
            }

        }

        private void GenerateViewBagsPermisos()
        {
            var responsePermiso = _permisoService.GetPermisos();

            List<SelectListItem> listPermisos = new List<SelectListItem>();
            SelectListItem aux;

            foreach (var permiso in responsePermiso.PermisoViewModel)
            {
                aux = new SelectListItem();
                aux.Value = permiso.PermisoId.ToString();
                aux.Text = permiso.Nombre;
                listPermisos.Add(aux);
            }

            ViewBag.listPermisos = listPermisos;
        }

        private void CreateMessageError(string textMessg)
        {
            @ViewBag.ShowMessage = true;
            @ViewBag.TypeMessage = TypeMessageEnum.ErrorMessage;
            @ViewBag.TitleMessage = Properties.Resources.Usuario_ErrorTitulo;
            @ViewBag.TextMessage = textMessg;

        }

        private void CreateMessageNotify(string textMessg)
        {
            @ViewBag.ShowMessage = true;
            @ViewBag.TypeMessage = TypeMessageEnum.AlertMessage;
            @ViewBag.TitleMessage = Properties.Resources.Usuario_NotificacionTitulo;
            @ViewBag.TextMessage = textMessg;

        }

        private void RellenaRoles(CreateEditUsuarioViewModel viewModel)
        {
            var listaRoles = new List<UsuarioRolViewModel>();

                     
                foreach (var rol in _rolService.GetRoles().RolViewModel)
                {

                    UsuarioRolViewModel usuarioRolViewModel = new UsuarioRolViewModel()
                    {
                        UsuarioId = viewModel.UsuarioId,
                        RolNombre = rol.Nombre,
                        RolId = rol.RolId,
                        ContieneRol = viewModel.UsuarioRol.Any((x => x.RolId == rol.RolId)) && viewModel.UsuarioRol.Single(x => x.RolId == rol.RolId).ContieneRol
                    };

                    listaRoles.Add(usuarioRolViewModel);


                }
                viewModel.UsuarioRol.Clear();
                viewModel.UsuarioRol = listaRoles;   
            
           
        }

        private void RellenaPermisos(CreateEditRolViewModel viewModel)
        {
            var listaPermisos = new List<PermisoRolViewModel>();

            foreach (var permiso in _permisoService.GetPermisos().PermisoViewModel)
            {
                PermisoRolViewModel permisoRolViewModel = new PermisoRolViewModel()
                {
                    RolId = viewModel.RolId,
                    PermisoNombre = permiso.Nombre,
                    PermisoId = permiso.PermisoId,
                    ContienePermiso = viewModel.PermisoRol.Any((x => x.PermisoId == permiso.PermisoId)) && viewModel.PermisoRol.Single(x => x.PermisoId == permiso.PermisoId).ContienePermiso,
                };

                listaPermisos.Add(permisoRolViewModel);
            }
            viewModel.PermisoRol.Clear();
            viewModel.PermisoRol = listaPermisos;
        }

        private FiltroUsuarioModels MappertoFiltroUsuarios(IDictionary<string, string> filtro)
        {
            var filtroUsuarioModels = new FiltroUsuarioModels();

            //si filtro.count = 0 significa que el diccionario aun no se ha creado
            if (filtro.Count != 0)
            {
                string value;
                if (filtro.ContainsKey("Usuario"))
                {
                    value = filtro["Usuario"];

                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroUsuarioModels.Usuario = value;
                    }
                }

                if (filtro.ContainsKey("Aplicacion"))
                {
                    value = filtro["Aplicacion"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroUsuarioModels.Aplicacion = value;
                    }
                }

                if (filtro.ContainsKey("Username"))
                {
                    value = filtro["Username"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroUsuarioModels.Username = filtro["Username"];
                    }
                }

                if (filtro.ContainsKey("CentroUsuarioId"))
                {
                    value = filtro["CentroUsuarioId"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroUsuarioModels.CentroIdUsuario = Convert.ToInt32(value);
                    }
                }

                if (filtro.ContainsKey("CentroSearch"))
                {
                    value = filtro["CentroSearch"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroUsuarioModels.CentroIdUsuario = Convert.ToInt32(value);
                    }
                }
            }

            return filtroUsuarioModels;
        }//MappertoFiltroNecesidades


        private void RellenaCentros()
        {
            int[] tipoMaestroId =
            {
                (int)MasterDataTypeEnum.Centro,
            };

            _maestroService.GetDatosMaestroByTipoId(tipoMaestroId);

            ViewBag.CentroList = (IEnumerable<SelectListItem>)HttpContext.Session["ListaCentros"];
            var hasCentro = false;
            //filtro por el centro del usuario
            if (HttpContext.Session["Usuario"] != null)
            {
                var UsuarioRolPermisoViewModel = (UsuarioRolPermisoViewModel)HttpContext.Session["Usuario"];
                if (UsuarioRolPermisoViewModel.CentroIdUsuario.HasValue)
                {
                    hasCentro = true;
                    ViewBag.CentroUsuarioId = UsuarioRolPermisoViewModel.CentroIdUsuario.Value;
                }
            }

            ViewBag.HasCentro = hasCentro;
        }

        private IEnumerable<SelectListItem> RellenaSectores()
        {
            int[] tipoMaestroId =
            {
                (int)MasterDataTypeEnum.Sector,
            };

            var response = _maestroService.GetDatosMaestroByTipoId(tipoMaestroId);

            var selectList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.Sector);

            return selectList;
        }

        private IEnumerable<SelectListItem> RellenaServicio()
        {
            int[] tipoMaestroId =
            {
                (int)MasterDataTypeEnum.TipoServicio,
            };

            var response = _maestroService.GetDatosMaestroByTipoId(tipoMaestroId);

            var selectList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.TipoServicio);

            return selectList;
        }

        private void RellenarCentrosYClientes()
        {
            RellenaCentros();         

            ViewBag.Clientes = GenerateClienteElements();
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

        #endregion
    }
}