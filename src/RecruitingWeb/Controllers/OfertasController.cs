using Recruiting.Application.Maestros.Services;
using Recruiting.Application.Ofertas.Services;
using Recruiting.Application.Ofertas.ViewModels;
using Recruiting.Application.Roles.ViewModels;
using Recruiting.Application.Usuarios.ViewModels;
using Recruiting.Business.Repositories;
using Recruiting.Data.EntityFramework.Repositories;
using RecruitingWeb.Components.DataTable.ServerSide;
using RecruitingWeb.Constantes;
using RecruitingWeb.Enums;
using RecruitingWeb.Helpers;
using RecruitingWeb.Security;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Recruiting.Infra.Caching;
using RecruitingWeb.Models;
using System;
using Recruiting.Business.BaseClasses.DataTable;
using System.IO;
using System.Web.UI;
using Recruiting.Application.Maestros.Enums;

namespace RecruitingWeb.Controllers
{
    public class OfertasController : Controller
    {
        #region Fields

        private readonly IOfertaService _ofertaService;
        private readonly IOfertaRepository _ofertaRepository = new OfertaRepository();

        private readonly IMaestroRepository _maestroRepository;
        private readonly MaestroService _maestroService;
        private readonly SessionCacheStorageService _sesionOferta;
        private readonly ICandidaturaRepository _candidaturaRepository;

        #endregion

        #region Construct
        public OfertasController()
        {
            _candidaturaRepository = new CandidaturaRepository();

            _sesionOferta = new SessionCacheStorageService();
            _ofertaService = new OfertaService(_ofertaRepository, _candidaturaRepository);

            _maestroRepository = new MaestroRepository();
            _maestroService = new MaestroService(_maestroRepository);
        }
        #endregion

        #region Actions

        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.VerOferta)]
        public ActionResult Desbloquear()
        {
            bool b = true;
            _sesionOferta.Add("buscar_bool_oferta", b);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult GetOfertasSearchable(string textSearch)
        {

            int? centro = null;

            if (HttpContext.Session["Usuario"] != null)
            {
                var UsuarioRolPermisoViewModel = (UsuarioRolPermisoViewModel)HttpContext.Session["Usuario"];
                if (UsuarioRolPermisoViewModel.CentroIdUsuario != null)
                {
                    centro = UsuarioRolPermisoViewModel.CentroIdUsuario;
                }
            }

            var response = _ofertaService.GetOfertasByNameAndCentro(textSearch, centro);

            var isValid = response.IsValid;
            var errorMessage = response.ErrorMessage;
            var ofertas = response.Ofertas.Select(x => new SelectListItem()
            {
                Text = x.Nombre,
                Value = x.OfertaId.ToString()
            });

            return Json(new { IsValid = isValid, ErrorMessage = errorMessage, Items = ofertas });
        }

        #region Index UI

        // GET: Necesidades
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.VerOferta)]
        public ActionResult Index()
        {
            var buscar = _sesionOferta.Get<bool>("buscar_bool_oferta");
            ViewBag.BuscarOferta = buscar;
            var filtro = _sesionOferta.Get<FiltroOfertaModels>("filtro_oferta");

            if (filtro == null)
            {
                filtro = new FiltroOfertaModels();
            }
            PermisosMostrar();


            var pagina = _sesionOferta.Get<int>("pagina_actual");
            if (pagina > 0)
            {
                ViewBag.Pagina = pagina;
            }


            GenerateViewBags();
            return View(filtro);
        }


        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.VerOferta)]
        public virtual JsonResult LoadOfertas([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
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
                else {
                    request.CustomFilters.Add("CentroUsuarioId", string.Empty);
                }
            }


            var response = _ofertaService.GetOfertas(request);
            bool a = _sesionOferta.Get<bool>("buscar_bool_oferta");
            bool b = request.CustomFilters.Contains(new KeyValuePair<string, string>("Buscar", "true"));
            if (a || b)
            {
                b = true;
                _sesionOferta.Add("buscar_bool_oferta", b);
            }
            ViewBag.BuscarOferta = b;
            var filtroOfertaModel = MappertoFiltroOfertas(request.CustomFilters);
            _sesionOferta.Add("filtro_oferta", filtroOfertaModel);
            _sesionOferta.Add("pagina_actual", request.PageNumber);

            if (!response.IsValid)
            {
                return null;
            }

            var result = from c in response.OfertaViewModel
                         select new object[]
            {
                c.Nombre,
                FormatHelper.Format(c.FechaPublicacion, "dd/MM/yyyy"),
                c.Estado,
                c.Candidatos,
                c.Centro,
                this.RenderRazorViewToString("actionColumn", c),
                c.OfertaId
            };

            var centroUsuarioId = HttpContext.Session["CentroIdUsuario"];
            if ((centroUsuarioId != null) && result.Any())
            {
                var resultTemp = new List<object[]>();
                result.ToList().ForEach(x =>
                {
                    var item = x.ToList();
                    item.RemoveAt(4);
                    resultTemp.Add(item.ToArray());
                });
                result = resultTemp;
            }

            var jsonResponse = new DataTablesResponse(requestModel.Draw, result, response.TotalElementos, response.TotalElementos);
            return Json(jsonResponse, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Create UI
        // GET: Necesidades/Create
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.AniadirEliminarOferta)]
        public ActionResult Create(int? id = null)
        {
            var model = new CreateEditOfertaViewModel();

            if (id.HasValue)
            {
                var response = _ofertaService.GetOfertaById((int)id);
                if (!response.IsValid)
                    CreateMessageError(response.ErrorMessage);
                else
                    model = response.OfertaViewModel;
            }

            return View(model);
        }

        // POST: Ofertas/Create
        [HttpPost]
        public ActionResult Create(CreateEditOfertaViewModel viewModel, FormCollection collection)
        {
            if (TempData.ContainsKey("viewModel"))
            {
                TempData.Remove("viewModel");
            }
            TempData.Add("viewModel", viewModel);

            if (collection["SubmitType"] == "guardar")
            {
                return CreateSave();
            }

            return CreateFinish();


        }

        [HttpPost]
        public ActionResult CreateSave()
        {
            var model = (CreateEditOfertaViewModel)TempData["viewModel"];

            var response = _ofertaService.SaveOferta(model);

            if (!response.IsValid)
            {
                CreateMessageError(response.ErrorMessage);
            }
            else
            {
                CreateMessageNotify("Oferta Guardada Correctamente");
            }
            model.OfertaId = response.OfertaId;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult CreateFinish()
        {
            _sesionOferta.Get<FiltroOfertaModels>("filtro_oferta");
            var model = (CreateEditOfertaViewModel)TempData["viewModel"];

            var response = _ofertaService.SaveOferta(model);

            if (!response.IsValid)
            {
                CreateMessageError(response.ErrorMessage);

                return RedirectToAction("Index");
            }

            CreateMessageNotify("Oferta Finalizada Correctamente");

            GenerateViewBags();
            return RedirectToAction("Index");
        }
        #endregion

        #region Edit UI

        // GET: Ofertas/Create/id
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.ModificarOferta)]
        public ActionResult Edit(int id)
        {
            var model = new CreateEditOfertaViewModel();
            var response = _ofertaService.GetOfertaById(id);
            if (!response.IsValid)
            {
                CreateMessageError(response.ErrorMessage);
            }
            else
            {
                model = response.OfertaViewModel;
            }
            GenerateViewBags();
            return View("Edit", model);

        }

        // POST: Ofertas/Create
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        #endregion

        #region Details UI

        // GET: Necesidades/Details/5
        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.VerOferta)]
        public ActionResult Details(int id)
        {
            var model = _ofertaService.GetOfertaById(id).OfertaViewModel;
            GenerateViewBags();
            ViewBag.AtrNav = "Detail";
            return View(model);
        }
        #endregion

        #region Delete UI

        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.AniadirEliminarOferta)]
        [HttpPost]
        public JsonResult Delete(int id)
        {
            var respose = new JsonResult();
            respose.Data = _ofertaService.DeleteOferta(id);
            return respose;

        }


        #endregion


        //Esta acción nos permite volver desde otra página con el filtro
        public ActionResult Volver()
        {

            return RedirectToAction("Index");

        }

        #region Limpiar

        public ActionResult Limpiar()
        {
            _sesionOferta.Remove("buscar_bool_oferta");
            _sesionOferta.Remove("filtro_oferta");
            return RedirectToAction("Index");
        }

        #endregion


        #region ExportToExcel
        public void ExportToExcel(string filterNombre, string filterDescripcion,
            string filterEstado, string filterPublicadaDesde, string filterPublicadaHasta, string filterCentro)
        {
            IDictionary<string, string> CustomFilters = new Dictionary<string, string> {
                    { "Nombre", filterNombre },
                    { "Descripcion",filterDescripcion},
                    { "Estado",filterEstado },
                    { "PublicadaDesde", filterPublicadaDesde },
                    { "PublicadaHasta", filterPublicadaHasta },
                    { "CentroSearch", filterCentro }
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
            var response = _ofertaService.GetOfertasExportToExcel(request);



            var grid = new System.Web.UI.WebControls.GridView();
            grid.DataSource = response.OfertaViewModel;
            grid.DataBind();
            Response.ClearContent();
            string filename = string.Format("Listado_de_Ofertas_{0}", DateTime.Now.ToShortDateString() + ".xls");
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", filename));
            Response.ContentType = "application/excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);

            grid.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();

        }

        #endregion
        #region Private Methods

        private void GenerateViewBags()
        {
            int[] tipoMaestroId =
            {
                (int)MasterDataTypeEnum.EstadoOferta,
                (int)MasterDataTypeEnum.Centro,
            };

            var response = _maestroService.GetDatosMaestroByTipoId(tipoMaestroId);

            ViewBag.EstadoList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.EstadoOferta);
            ViewBag.CentroList = (IEnumerable<SelectListItem>)HttpContext.Session["ListaCentros"];

            ViewBag.CentroIdUsuario = HttpContext.Session["CentroIdUsuario"] != null ? HttpContext.Session["CentroIdUsuario"].ToString() : string.Empty;

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

        private void PermisosMostrar()
        {
            TempData["AniadirEliminarOferta"] = false;
            TempData["ModificarOferta"] = false;
            TempData["VerOferta"] = false;
            TempData["CandidatosInscritos"] = false;
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
            if (privilegeLevels.Contains(PermisosConst.AniadirEliminarOferta)) TempData["AniadirEliminarOferta"] = true;
            if (privilegeLevels.Contains(PermisosConst.ModificarOferta)) TempData["ModificarOferta"] = true;
            if (privilegeLevels.Contains(PermisosConst.VerOferta)) TempData["VerOferta"] = true;
            if (privilegeLevels.Contains(PermisosConst.VerOferta)) TempData["CandidatosInscritos"] = true;
        }

        private void CreateMessageNotify(string textMessg)
        {
            @ViewBag.ShowMessage = true;
            @ViewBag.TypeMessage = TypeMessageEnum.AlertMessage;
            @ViewBag.TitleMessage = Properties.Resources.Oferta_NotificacionTitulo;
            @ViewBag.TextMessage = textMessg;

        }

        private void CreateMessageError(string textMessg)
        {
            @ViewBag.ShowMessage = true;
            @ViewBag.TypeMessage = TypeMessageEnum.ErrorMessage;
            @ViewBag.TitleMessage = Properties.Resources.Oferta_ErrorTitulo;
            @ViewBag.TextMessage = textMessg;

        }

        private FiltroOfertaModels MappertoFiltroOfertas(IDictionary<string, string> filtro)
        {
            var filtroOfertaModels = new FiltroOfertaModels();

            if (filtro.Count != 0)
            {
                string value;
                if (filtro.ContainsKey("Nombre"))
                {
                    value = filtro["Nombre"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroOfertaModels.Nombre = value;
                    }
                }

                if (filtro.ContainsKey("Descripcion"))
                {
                    value = filtro["Descripcion"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroOfertaModels.Descripcion = value;
                    }
                }

                if (filtro.ContainsKey("Estado"))
                {
                    value = filtro["Estado"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroOfertaModels.EstadoOfertaId = Convert.ToInt32(value);
                    }
                }

                if (filtro.ContainsKey("PublicadaDesde"))
                {
                    value = filtro["PublicadaDesde"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroOfertaModels.FechaEntre = Convert.ToDateTime(value);
                    }
                }

                if (filtro.ContainsKey("PublicadaHasta"))
                {
                    value = filtro["PublicadaHasta"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroOfertaModels.FechaHasta = Convert.ToDateTime(value);
                    }
                }

                if (filtro.ContainsKey(""))
                {
                    value = filtro["CentroUsuarioId"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroOfertaModels.CentroIdUsuario = Convert.ToInt32(value);
                    }
                }

                if (filtro.ContainsKey("CentroSearch"))
                {
                    value = filtro["CentroSearch"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroOfertaModels.CentroIdUsuario = Convert.ToInt32(value);
                    }
                }

            }
            return filtroOfertaModels;
        }

        #endregion
        #endregion
    }
}