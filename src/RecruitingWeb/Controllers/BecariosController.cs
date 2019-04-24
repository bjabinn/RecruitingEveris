using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Web.UI;
using System.Web.Mvc;
using System.Web.Routing;
using System.Configuration;
using System.Collections.Generic;

using RecruitingWeb.Enums;
using RecruitingWeb.Models;
using RecruitingWeb.Helpers;
using RecruitingWeb.Security;
using RecruitingWeb.Constantes;
using RecruitingWeb.Components.DataTable.ServerSide;

using Recruiting.Application.Maestros.Enums;
using Recruiting.Application.Becarios.Enums;
using Recruiting.Application.Roles.ViewModels;
using Recruiting.Application.Maestros.Services;
using Recruiting.Application.Becarios.Services;
using Recruiting.Application.Becarios.Messages;
using Recruiting.Application.Clientes.Services;
using Recruiting.Application.Proyectos.Services;
using Recruiting.Application.Candidatos.Services;
using Recruiting.Application.Usuarios.ViewModels;
using Recruiting.Application.Becarios.ViewModels;
using Recruiting.Application.Clientes.ViewModels;
using Recruiting.Application.Proyectos.ViewModels;
using Recruiting.Application.BitacorasBecarios.Messages;
using Recruiting.Application.BitacorasBecarios.Services;

using Recruiting.Business.Repositories;
using Recruiting.Business.BaseClasses.DataTable;

using Recruiting.Infra.Caching;
using Recruiting.Data.EntityFramework.Repositories;
using Recruiting.SendMailsService;
using Recruiting.Application.Candidaturas.Services;

namespace RecruitingWeb.Controllers
{
    public class BecariosController : Controller
    {
        #region Constants

        private const string SeparatorBar = "\\";

        #endregion

        #region Fields       

        private readonly IBecarioService _becarioService;
        private readonly IClienteService _clienteService;
        private readonly IProyectoService _proyectoService;
        private readonly ICandidatoService _candidatoService;
        private readonly IClienteRepository _clienteRepository;
        private readonly IBecarioRepository _becarioRepository;
        private readonly IMaestroRepository _maestroRepository;
        private readonly IProyectoRepository _proyectoRepository;
        private readonly ICandidatoRepository _candidatoRepository;
        private readonly IBecarioEstadoService _becarioEstadoService;
        private readonly IBecarioCentroService _becarioCentroService;
        private readonly ICandidaturaRepository _candidaturaRepository;
        private readonly IBitacoraBecarioService _bitacoraBecarioService;
        private readonly IBecarioCentroRepository _becarioCentroRepository;
        private readonly IBitacoraBecarioRepository _bitacoraBecarioRepository;
        private readonly ICandidatoIdiomaRepository _candidatoIdiomaRepository;
        private readonly ITipoEstadoBecarioRepository _becarioEstadoRepository;
        private readonly IBecarioConvocatoriaService _becarioConvocatoriaService;
        private readonly ICandidatoContactoRepository _candidatoContactoRepository;
        private readonly IBecarioObservacionRepository _becarioObservacionRepository;
        private readonly IBecarioConvocatoriaRepository _becarioConvocatoriaRepository;
        private readonly ICandidatoExperienciaRepository _candidatoExperienciaRepository;

        private readonly MaestroService _maestroService;
        private readonly SessionCacheStorageService _sessionBecarios;

        #endregion

        #region Construct

        public BecariosController()
        {
            _becarioEstadoRepository = new TipoEstadoBecarioRepository();
            _becarioRepository = new BecarioRepository();
            _becarioObservacionRepository = new BecarioObservacionRepository();
            _becarioCentroRepository = new BecarioCentroRepository();
            _candidatoRepository = new CandidatoRepository();
            _candidatoIdiomaRepository = new CandidatoIdiomaRepository();
            _candidatoContactoRepository = new CandidatoContactoRepository();
            _candidatoExperienciaRepository = new CandidatoExperienciaRepository();

            _candidaturaRepository = new CandidaturaRepository();
            _clienteRepository = new ClienteRepository();
            _proyectoRepository = new ProyectoRepository();

            _bitacoraBecarioRepository = new BitacoraBecarioRepository();
            _bitacoraBecarioService = new BitacoraBecarioService(_bitacoraBecarioRepository);

            _becarioEstadoService = new BecarioEstadoService(_becarioEstadoRepository);

            _becarioCentroService = new BecarioCentroService(_becarioCentroRepository);
            _sessionBecarios = new SessionCacheStorageService();
            _becarioService = new BecarioService(_becarioRepository, _becarioObservacionRepository, _bitacoraBecarioRepository);

            _candidatoService = new CandidatoService(_candidatoRepository, _candidatoIdiomaRepository,
               _candidatoExperienciaRepository, _candidatoContactoRepository, _candidaturaRepository, _becarioRepository);

            _maestroRepository = new MaestroRepository();
            _maestroService = new MaestroService(_maestroRepository);

            _clienteService = new ClienteService(_clienteRepository);
            _proyectoService = new ProyectoService(_proyectoRepository, _clienteRepository);

            _becarioConvocatoriaRepository = new BecarioConvocatoriaRepository();
            _becarioConvocatoriaService = new BecarioConvocatoriaService(_becarioConvocatoriaRepository);

        }

        #endregion

        #region Index Members

        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.VerBecario)]
        public ActionResult Index()
        {
            SetVisibilidadPorPermisos();
            var filtro = _sessionBecarios.Get<FiltroBecarioModels>("filtro_becario");

            if (filtro == null)
            {
                //orden por defecto
                filtro = new FiltroBecarioModels()
                {
                    SortColumn = "BecarioId",
                    SortOrder = Recruiting.Business.BaseClasses.DataTable.DataTableSortDirectionEnum.Descending
                };
            }
            _sessionBecarios.Add("filtro_inicial_becario", filtro);

            filtro = GenerateViewElementsIndex(filtro);

            return View(filtro);
        }

        #endregion

        #region Edit Members

        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.ModificarBecario)]
        public ActionResult Edit(int id, string errorMessage = null)
        {
            if (!string.IsNullOrWhiteSpace(errorMessage))
            {
                CreateMessageError(errorMessage);
            }

            var model = _becarioService.GetBecarioById(id);

            model.BecarioViewModel = GenerateViewElementsEdit(model.BecarioViewModel);

            return View("Edit", model.BecarioViewModel);
        }




        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.ModificarBecario)]
        [HttpPost]
        public ActionResult Edit(CreateEditBecarioViewModel viewModel, FormCollection collection)
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
                        var becarioId = viewModel.BecarioId.Value;
                        var respuestaCv = _becarioService.UploadCV(buffer.ToArray(), becarioId, file.FileName);
                        if (respuestaCv.IsValid)
                        {
                            viewModel.BecarioDatosBasicos.CV = null; //borro lo que haya en la BD del fichero de curriculum
                            viewModel.BecarioDatosBasicos.NombreCV = file.FileName;
                            viewModel.BecarioDatosBasicos.UrlCV = ConfigurationManager.AppSettings["rutaCvBecarios"].ToString();
                        }
                    }
                    if (inputName == "Anexo") //Esto significa que el archivo que nos llega es un anexo o un archivo vacío
                    {
                        var becarioId = viewModel.BecarioId.Value;
                        var respuestaAnexo = _becarioService.UploadAnexo(buffer.ToArray(), becarioId, file.FileName);
                        if (respuestaAnexo.IsValid)
                        {
                            viewModel.BecarioSeleccion.BecarioGestionDocumental.Anexo = null; //borro lo que haya en la BD del fichero de curriculum
                            viewModel.BecarioSeleccion.BecarioGestionDocumental.NombreAnexo = file.FileName;
                            viewModel.BecarioSeleccion.BecarioGestionDocumental.UrlAnexo = ConfigurationManager.AppSettings["rutaAnexoBecarios"].ToString();
                        }
                    }

                }
            }

            return GuardaEditBecario(viewModel);

        }

        #endregion

        #region Details Members

        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.VerBecario)]
        public ActionResult Details(int id)
        {
            var model = _becarioService.GetBecarioById(id).BecarioViewModel;

            return View(model);
        }

        #endregion

        #region Create Members

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(CreateEditBecarioViewModel viewModel, FormCollection collection)
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
                        viewModel.BecarioDatosBasicos.CV = null; //borro lo que haya en la BD del fichero de curriculum
                        viewModel.BecarioDatosBasicos.NombreCV = file.FileName;
                        var ruta = ConfigurationManager.AppSettings["rutaCVBecarios"].ToString();
                        viewModel.BecarioDatosBasicos.UrlCV = ruta;
                    }
                    catch
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            return CreateFinish(actualFile, viewModel);
        }

        #endregion 

        #region Load Table Members

        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.VerBecario)]
        public virtual JsonResult LoadBecarios([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
        {
            SetVisibilidadPorPermisos();

            var request = requestModel.ConvertToDataTableRequestViewModel();
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

            var filtro = _sessionBecarios.Get<FiltroBecarioModels>("filtro_inicial_becario");
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

            var response = _becarioService.GetBecarios(request);

            var filtroBecarioModel = MappertoFiltroBecarios(request.CustomFilters);

            if (filtro != null)
            {
                filtroBecarioModel.SortOrder = filtro.SortOrder;
                filtroBecarioModel.SortColumn = filtro.SortColumn;
            }

            _sessionBecarios.Add("filtro_becario", filtroBecarioModel);
            _sessionBecarios.Add("pagina_actual_becarios", request.PageNumber);

            if (!response.IsValid)
            {
                return null;
            }

            var result = from c in response.BecarioRowViewModel
                         select new object[]
            {
                c.BecarioId,
                c.BecarioNombre,
                c.CandidatoId,
                c.TipoBecario,
                c.Cliente,
                c.Proyecto,
                c.FechaInicio,
                c.FechaFin,
                c.FechaFinReal,
                c.EstadoBecarioId == (int)TipoEstadoBecarioEnum.Descartado || c.EstadoBecarioId == (int)TipoEstadoBecarioEnum.Renuncia ? string.Format("<span class=\"Statered\">{0}</span>", c.EstadoBecario) :  c.EstadoBecario,
                c.TipoDecisionFinal,
                c.NivelIdioma,
                this.RenderRazorViewToString("Table/actionColumnIndex", c),
                this.RenderRazorViewToString("Table/stateColumnIndex", c)
            };

            var jsonResponse = new DataTablesResponse(requestModel.Draw, result, response.TotalElementos, response.TotalElementos);
            return Json(jsonResponse, JsonRequestBehavior.AllowGet);
        }

        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.VerBecario)]
        public virtual JsonResult LoadCandidatos([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
        {
            var request = requestModel.ConvertToDataTableRequestViewModel();
            request.CustomFilters.Add("Descartado", "false");

            request.CustomFilters.Add("excluir-candidatos", "true");

            var response = _candidatoService.GetCandidatosBecario(request, false);

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
                this.RenderRazorViewToString("Table/actionColumnCandidato", c),
                c.CandidatoId
            };


            var jsonResponse = new DataTablesResponse(requestModel.Draw, result, response.TotalElementos, response.TotalElementos);
            return Json(jsonResponse, JsonRequestBehavior.AllowGet);
        }

        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.VerBecario)]
        public virtual JsonResult LoadCentrosProcedencia([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
        {
            var request = requestModel.ConvertToDataTableRequestViewModel();


            var response = _becarioCentroService.GetCentros(request);

            if (!response.IsValid)
            {
                return null;
            }

            var result = from c in response.CentroRowViewModel
                         select new object[]
            {
                c.Centro,
                c.Ciudad,
                c.Pais,
                this.RenderRazorViewToString("Table/actionColumnCentro", c),
                c.CentroId
            };

            var jsonResponse = new DataTablesResponse(requestModel.Draw, result, response.TotalElementos, response.TotalElementos);
            return Json(jsonResponse, JsonRequestBehavior.AllowGet);
        }

        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.VerBecario)]
        public virtual JsonResult LoadConvocatorias([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)

        {
            var request = requestModel.ConvertToDataTableRequestViewModel();

            var UsuarioRolPermisoViewModel = (UsuarioRolPermisoViewModel)HttpContext.Session["Usuario"];
            var centroId = UsuarioRolPermisoViewModel.CentroIdUsuario;

            if (centroId != null)
            {
                request.CustomFilters.Add("CentroId", centroId.ToString());
            }


            var response = _becarioConvocatoriaService.GetConvocatorias(request);

            if (!response.IsValid)
            {
                return null;
            }

            var result = from c in response.ConvocatoriaRowViewModel
                         select new object[]
            {
                c.NombreConvocatoria,
                this.RenderRazorViewToString("Table/actionColumnConvocatoria", c),
                c.ConvocatoriaId
            };

            var jsonResponse = new DataTablesResponse(requestModel.Draw, result, response.TotalElementos, response.TotalElementos);
            return Json(jsonResponse, JsonRequestBehavior.AllowGet);
        }

        #endregion

        //---------------------------------------------- LIMITE ORDER ----------------------------------------------//

        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.VerCandidato)]
        public ActionResult Desbloquear()
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult GetCentrosByNombreCentro(string textSearch)
        {
            var response = _becarioCentroService.GetCentrosByNombreCentro(textSearch);

            var isValid = response.IsValid;
            var errorMessage = response.ErrorMessage;
            var centros = response.CentrosProcedencia.Select(x => new SelectListItem()
            {
                Text = x.Centro + '(' + x.Ciudad + " - " + x.Pais + ')',
                Value = x.CentroId.ToString()
            });

            return Json(new { IsValid = isValid, ErrorMessage = errorMessage, Items = centros });
        }//GetCentrosByNombreCentro

        [HttpPost]
        public JsonResult GetConvocatoriasByNombre(string textSearch)
        {
            var UsuarioRolPermisoViewModel = (UsuarioRolPermisoViewModel)HttpContext.Session["Usuario"];
            var centroId = UsuarioRolPermisoViewModel.CentroIdUsuario;
            var response = _becarioConvocatoriaService.GetConvocatoriasByNombre(textSearch, centroId);
            var isValid = response.IsValid;
            var errorMessage = response.ErrorMessage;
            var convocatorias = response.Convocatorias.Select(x => new SelectListItem()
            {
                Text = x.NombreConvocatoria,
                Value = x.ConvocatoriaId.ToString()
            });

            return Json(new { IsValid = isValid, ErrorMessage = errorMessage, Items = convocatorias });
        }//GetCentrosByNombreCentro

        public void ExportToExcel(string filterBecarioId, string filterNombreBecario, string filterCandidatoId, string filterTipoBecarioId,
                        string filterTipoEstadoBecarioId, string filterBecarioCentroProcedencia, string filterClienteId,
                        string filterProyectoId, string filterFechaInicio, string filterFechaFin, string filterFechaFinReal, string filterTipoDecisionFinalId,
                        string filterGestionDocumentalCompleta, string filterBecarioConvocatoria, string filterCentro, string filterNivelIdioma)
        {
            IDictionary<string, string> CustomFilters = new Dictionary<string, string> {
                    { "BecarioId", filterBecarioId },
                    { "NombreBecario",filterNombreBecario},
                    { "CandidatoId",filterCandidatoId },
                    { "TipoBecario", filterTipoBecarioId },
                    { "TipoEstadoBecario", filterTipoEstadoBecarioId },
                    { "CentroProcedencia", filterBecarioCentroProcedencia },
                    { "Cliente", filterClienteId },
                    { "Proyecto", filterProyectoId },
                    { "FechaInicio", filterFechaInicio },
                    { "FechaFin", filterFechaFin },
                    { "FechaFinReal", filterFechaFinReal },
                    { "TipoDecisionFinalId", filterTipoDecisionFinalId },
                    { "GestionDocumentalCompleta", filterGestionDocumentalCompleta },
                    { "Convocatoria", filterBecarioConvocatoria },
                    { "CentroSearch", filterCentro },
                    { "NivelIdioma", filterNivelIdioma }
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
            var response = _becarioService.GetBecariosExportToExcel(request);



            var grid = new System.Web.UI.WebControls.GridView();
            grid.DataSource = response.BecarioRowExportToExcelViewModel;
            grid.DataBind();
            Response.ClearContent();
            string filename = string.Format("Listado_de_Becarios_{0}", DateTime.Now.ToShortDateString() + ".xls");
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", filename));
            Response.ContentType = "application/excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);

            grid.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();

        }

        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.AniadirEliminarBecario)]
        public ActionResult Create(int? id = null)
        {
            var model = new CreateEditBecarioViewModel();
            model.BecarioDatosBasicos = new BecarioDatosBasicosViewModel();

            if (id.HasValue)
            {
                model = _becarioService.GetBecarioById((int)id).BecarioViewModel;
            }

            model.BecarioDatosBasicos = GenerateViewElementsCreate(model.BecarioDatosBasicos);

            return View(model);
        }

        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.ModificarBecario)]
        public GetLastEstadoBitacoraByBecarioIdResponse GetLastEstadoBitacoraByBecarioId(int becarioId)
        {
            var response = _bitacoraBecarioService.GetLastEstadoBitacoraByBecarioId(becarioId);
            return response;
        }

        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.ModificarBecario)]
        public GetLastEstadoBitacoraByBecarioIdResponse GetLastEstadoBitacoraByBecarioIdStandBy(int becarioId)
        {
            var response = _bitacoraBecarioService.GetLastEstadoBitacoraByBecarioIdStandBy(becarioId);
            return response;
        }

        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.ModificarBecario)]
        public ActionResult Pausar(int BecarioId, DateTime? fechaContactoStandBy = null)
        {
            var parameters = new RouteValueDictionary();
            PauseBecarioResponse response = null;
            if (fechaContactoStandBy.HasValue)
            {
                response = _becarioService.PauseBecario(BecarioId, fechaContactoStandBy);
            }
            else
            {
                response = _becarioService.PauseBecario(BecarioId);
            }

            if (!response.IsValid)
            {
                parameters.Add("errorMessage", response.ErrorMessage);
            }

            return RedirectToAction("Index", "Candidaturas", parameters);
        }

        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.ModificarBecario)]
        public ActionResult Reanudar(int BecarioId)
        {
            var parameters = new RouteValueDictionary();
            var response = _becarioService.ResumeBecario(BecarioId);
            if (!response.IsValid)
            {
                parameters.Add("errorMessage", response.ErrorMessage);
            }

            return RedirectToAction("Index", "Becarios", parameters);
        }

        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.ModificarBecario)]
        public ActionResult Ejecutar(int id)
        {

            var BecarioViewModel = _becarioService.GetBecarioById(id).BecarioViewModel;
            var response = _becarioService.ExecuteBecario(id);
            if (response.VistaAMostrar.Equals("Index"))
            {
                return RedirectToAction("Index");

            }
            else
            {
                return RedirectToAction(response.VistaAMostrar, "Becarios", new { id = BecarioViewModel.BecarioId });
            }

        }

        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.ModificarBecario)]
        public ActionResult EnProceso(int? id = null)
        {
            var model = new CreateEditBecarioViewModel();
            model.BecarioObservaciones = new BecarioObservacionesViewModel();

            if (id.HasValue)
            {
                model = _becarioService.GetBecarioById((int)id).BecarioViewModel;
            }

            model.BecarioObservaciones = GenerateViewElementsEnProceso(model.BecarioObservaciones);

            return View(model.BecarioObservaciones);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Proceso(BecarioObservacionesViewModel viewModel, FormCollection collection)
        {
            if (collection["SubmitType"] == "guardar")
            {
                return ProcesoSave(viewModel);
            }

            return ProcesoFinish(viewModel);
        }

        public ActionResult ProcesoSave(BecarioObservacionesViewModel viewModel)
        {
            var model = GuardarProceso(false, viewModel);
            return View("EnProceso", model);
        }

        public ActionResult ProcesoFinish(BecarioObservacionesViewModel viewModel)
        {
            GuardarProceso(true, viewModel);
            return RedirectToAction("Index");
        }

        public BecarioObservacionesViewModel GuardarProceso(bool finish, BecarioObservacionesViewModel model)
        {
            model = GenerateViewElementsEnProceso(model);

            var response = _becarioService.SaveProcesoBecario(model, finish);

            if (!response.IsValid)
            {
                CreateMessageError(response.ErrorMessage);
            }
            else
            {
                CreateMessageNotify("Proceso Guardado Correctamente.");
            }

            return model;
        }

        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.ModificarBecario)]
        public ActionResult Seleccion(int? id = null)
        {
            var model = new CreateEditBecarioViewModel();
            model.BecarioSeleccion = new BecarioSeleccionViewModel();

            if (id.HasValue)
            {
                model = _becarioService.GetBecarioById((int)id).BecarioViewModel;
            }

            model.BecarioSeleccion = GenerateViewElementsSeleccion(model.BecarioSeleccion);

            return View(model.BecarioSeleccion);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Seleccion(BecarioSeleccionViewModel viewModel, FormCollection collection)
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
                        viewModel.BecarioGestionDocumental.Anexo = null; //borro lo que haya en la BD del fichero de curriculum
                        viewModel.BecarioGestionDocumental.NombreAnexo = file.FileName;
                        var ruta = ConfigurationManager.AppSettings["rutaAnexoBecarios"].ToString();
                        viewModel.BecarioGestionDocumental.UrlAnexo = ruta;
                    }
                    catch
                    {
                        return RedirectToAction("Index");
                    }
                }
            }

            if (collection["SubmitType"] == "guardar")
            {
                return SeleccionSave(actualFile, viewModel);
            }

            return SeleccionFinish(actualFile, viewModel);
        }

        public ActionResult SeleccionSave(Byte[] file, BecarioSeleccionViewModel viewModel)
        {
            var model = GuardarSeleccion(false, file, viewModel);
            return View("Seleccion", model);
        }

        public ActionResult SeleccionFinish(Byte[] file, BecarioSeleccionViewModel viewModel)
        {
            GuardarSeleccion(true, file, viewModel);
            return RedirectToAction("Index");
        }

        public BecarioSeleccionViewModel GuardarSeleccion(bool finish, byte[] file, BecarioSeleccionViewModel model)
        {
            if (!finish)
            {
                model = GenerateViewElementsSeleccion(model);
            }

            var responseSave = _becarioService.SaveSeleccionBecario(model, finish);

            if (!responseSave.IsValid)
            {
                CreateMessageError(responseSave.ErrorMessage);
            }
            else
            {
                CreateMessageNotify("Seleccion Guardada Correctamente.");
            }
            if (file != null && (responseSave.NombreAnexo != null) || (responseSave.NombreAnexo == ""))
            {
                _becarioService.UploadAnexo(file, responseSave.BecarioId, responseSave.NombreAnexo);

            }

            return model;
        }


        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.ModificarBecario)]
        public ActionResult Practicas(int? id = null)
        {
            var model = new CreateEditBecarioViewModel();
            model.BecarioDatosPracticas = new BecarioDatosPracticasViewModel();

            if (id.HasValue)
            {
                model = _becarioService.GetBecarioById((int)id).BecarioViewModel;
            }

            model.BecarioDatosPracticas = GenerateViewElementsPracticas(model.BecarioDatosPracticas);

            return View(model.BecarioDatosPracticas);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Practicas(BecarioDatosPracticasViewModel viewModel, FormCollection collection)
        {
            if (collection["SubmitType"] == "guardar")
            {
                return PracticasSave(viewModel);
            }

            return PracticasFinish(viewModel);
        }

        public ActionResult PracticasSave(BecarioDatosPracticasViewModel model)
        {
            model = GuardarPracticas(false, model);
            return View("Practicas", model);
        }

        public ActionResult PracticasFinish(BecarioDatosPracticasViewModel model)
        {
            GuardarPracticas(true, model);
            return RedirectToAction("Index");
        }

        public BecarioDatosPracticasViewModel GuardarPracticas(bool finish, BecarioDatosPracticasViewModel model)
        {
            model = GenerateViewElementsPracticas(model);

            var responseSave = _becarioService.SavePracticasBecario(model, finish);

            if (!responseSave.IsValid)
            {
                CreateMessageError(responseSave.ErrorMessage);
            }
            else
            {
                CreateMessageNotify("Practicas Guardadas Correctamente.");
            }

            return model;
        }

        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.AniadirEliminarBecario)]
        [ValidateInput(false)]
        [HttpPost]
        public JsonResult Delete(int id)
        {
            var respose = new JsonResult();
            respose.Data = _becarioService.RemoveBecario(id);
            return respose;

        }

        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.ModificarBecario)]
        public ActionResult Renunciar(int becarioId, string ComentariosRenunciaDescarte)
        {
            var parameters = new RouteValueDictionary();
            var response = _becarioService.RevokeBecario(becarioId, ComentariosRenunciaDescarte);
            if (!response.IsValid)
            {
                parameters.Add("errorMessage", response.ErrorMessage);
            }

            parameters.Add("IsValid", response.IsValid);
            return RedirectToAction("Index", "Becarios", parameters);
        }

        public ActionResult IndexError()
        {
            TempData["ErrorPermiso"] = true;
            var filtro = _sessionBecarios.Get<FiltroBecarioModels>("filtro_becario");

            if (filtro == null)
            {
                filtro = new FiltroBecarioModels();
            }
            return View("Index", filtro);
        }

        public ActionResult Volver()
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult ComprobarExisteCentro(string NombreCentro, string Ciudad, string Pais)
        {
            var respose = new JsonResult();
            if (!string.IsNullOrEmpty(NombreCentro) && !string.IsNullOrEmpty(Ciudad) && !string.IsNullOrEmpty(Pais))
            {
                var response = _becarioCentroService.SearchCentroByNombreCiudadPais(NombreCentro, Ciudad, Pais);
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
        public JsonResult ComprobarExisteConvocatoria(string NombreConvocatoria)
        {
            var respose = new JsonResult();
            if (!string.IsNullOrEmpty(NombreConvocatoria))
            {
                var UsuarioRolPermisoViewModel = (UsuarioRolPermisoViewModel)HttpContext.Session["Usuario"];
                var centroId = UsuarioRolPermisoViewModel.CentroIdUsuario == null ? 0 : UsuarioRolPermisoViewModel.CentroIdUsuario;

                var response = _becarioConvocatoriaService.SearchConvocatoriaByNombreCentroId(NombreConvocatoria, (int)centroId);
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
        public JsonResult ComprobarCentroUsado(int CentroId)
        {
            var response = _becarioCentroService.SearchCentroUsado(CentroId);
            return Json(response, JsonRequestBehavior.AllowGet);


        }

        [HttpPost]
        public JsonResult ComprobarConvocatoriaUsada(int ConvocatoriaId)
        {
            var response = _becarioConvocatoriaService.SearchConvocatoriaUsada(ConvocatoriaId);
            return Json(response, JsonRequestBehavior.AllowGet);


        }

        [ValidateInput(false)]
        [HttpPost]
        public JsonResult CheckBecasAbiertas(int CandidatoId)
        {
            var response = new JsonResult();
            response.Data = _becarioService.CheckBecasAbiertas(CandidatoId);

            return response;
        }

        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.ModificarBecario)]
        public ActionResult RetrocederEstado(int BecarioId)
        {
            var parameters = new RouteValueDictionary();
            var response = _becarioService.BacktrackBecario(BecarioId);
            if (!response.IsValid)
            {
                parameters.Add("errorMessage", response.ErrorMessage);
            }

            parameters.Add("IsValid", response.IsValid);
            return RedirectToAction("Index", "Becarios", parameters);
        }

        public ActionResult Limpiar()
        {
            _sessionBecarios.Remove("filtro_becario");
            return RedirectToAction("Index");
        }

        private void SetVisibilidadPorPermisos()
        {
            TempData["AniadirEliminarBecario"] = false;
            TempData["ModificarBecario"] = false;
            TempData["VerBecario"] = false;
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

            if (privilegeLevels.Contains(PermisosConst.AniadirEliminarBecario)) TempData["AniadirEliminarBecario"] = true;
            if (privilegeLevels.Contains(PermisosConst.ModificarBecario)) TempData["ModificarBecario"] = true;
            if (privilegeLevels.Contains(PermisosConst.VerBecario)) TempData["VerBecario"] = true;
        }

        private ActionResult GuardaEditBecario(CreateEditBecarioViewModel model)
        {


            EditBecarioResponse response;


            response = _becarioService.SaveEditBecario(model);
            ViewBag.ShowMessage = true;
            ViewBag.TypeMessage = TypeMessageEnum.AlertMessage;
            ViewBag.TitleMessage = "Cambios guardados.";
            ViewBag.TextMessage = "Becario guardado correctamente";

            return Json(response);

        }

        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.VerBecario)]
        public FileResult DownloadCV(int id)
        {
            try
            {
                var response = _becarioService.DownloadCV(id);
                var contentType = GetContentType(response.NombreCV);
                var rutaReal = System.IO.Path.Combine(response.UrlCV, response.BecarioId.ToString());
                return File(rutaReal + SeparatorBar + response.NombreCV, contentType, response.NombreCV);
            }
            catch
            {
                return null;
            }
        }

        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.VerBecario)]
        public FileResult DownloadAnexo(int id)
        {
            try
            {
                var response = _becarioService.DownloadAnexo(id);
                var contentType = GetContentType(response.NombreAnexo);
                var rutaReal = System.IO.Path.Combine(response.UrlAnexo, response.BecarioId.ToString());
                return File(rutaReal + SeparatorBar + response.NombreAnexo, contentType, response.NombreAnexo);
            }
            catch
            {
                return null;
            }
        }

        private FiltroBecarioModels MappertoFiltroBecarios(IDictionary<string, string> filtro)
        {
            var filtroBecarioModels = new FiltroBecarioModels();

            if (filtro.Count != 0)
            {
                string value;
                if (filtro.ContainsKey("BecarioId"))
                {
                    value = filtro["BecarioId"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroBecarioModels.BecarioId = Convert.ToInt32(value);
                    }
                }

                if (filtro.ContainsKey("NombreBecario"))
                {
                    value = filtro["NombreBecario"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroBecarioModels.NombreBecario = value;
                    }
                }

                if (filtro.ContainsKey("CandidatoId"))
                {
                    value = filtro["CandidatoId"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroBecarioModels.CandidatoId = Convert.ToInt32(value);
                    }
                }

                if (filtro.ContainsKey("TipoBecario"))
                {
                    value = filtro["TipoBecario"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroBecarioModels.TipoBecarioId = Convert.ToInt32(value);
                    }
                }

                if (filtro.ContainsKey("TipoEstadoBecario[]"))
                {
                    value = filtro["TipoEstadoBecario[]"];
                    if (!string.IsNullOrEmpty(value))
                    {

                        var etapas = value.Split(',').Select(Int32.Parse).ToArray();
                        filtroBecarioModels.TipoEstadoBecarioId = etapas;

                    }
                }

                if (filtro.ContainsKey("CentroProcedencia"))
                {
                    value = filtro["CentroProcedencia"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroBecarioModels.BecarioCentroProcedenciaId = Convert.ToInt32(value);
                    }
                }

                if (filtro.ContainsKey("CentroProcedenciaName"))
                {
                    value = filtro["CentroProcedenciaName"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroBecarioModels.BecarioCentroProcedencia = value;
                    }
                }

                if (filtro.ContainsKey("FechaInicio"))
                {
                    value = filtro["FechaInicio"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroBecarioModels.FechaInicio = Convert.ToDateTime(value);
                    }
                }

                if (filtro.ContainsKey("FechaFin"))
                {
                    value = filtro["FechaFin"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroBecarioModels.FechaFin = Convert.ToDateTime(value);
                    }
                }

                if (filtro.ContainsKey("FechaFinReal"))
                {
                    value = filtro["FechaFinReal"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroBecarioModels.FechaFinReal = Convert.ToDateTime(value);
                    }
                }

                if (filtro.ContainsKey("Cliente"))
                {
                    value = filtro["Cliente"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroBecarioModels.ClienteId = Convert.ToInt32(value);
                    }
                }
                if (filtro.ContainsKey("Proyecto"))
                {
                    value = filtro["Proyecto"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroBecarioModels.ProyectoId = Convert.ToInt32(value);
                    }
                }

                if (filtro.ContainsKey("TipoDecisionFinalId"))
                {
                    value = filtro["TipoDecisionFinalId"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroBecarioModels.TipoDecisionFinalId = Convert.ToInt32(value);
                    }
                }

                if (filtro.ContainsKey("GestionDocumentalCompleta"))
                {
                    value = filtro["GestionDocumentalCompleta"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroBecarioModels.GestionDocumentalCompleta = Convert.ToBoolean(value);
                    }
                }

                if (filtro.ContainsKey("Convocatoria"))
                {
                    value = filtro["Convocatoria"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroBecarioModels.BecarioConvocatoriaId = Convert.ToInt32(value);
                    }
                }

                if (filtro.ContainsKey("ConvocatoriaName"))
                {
                    value = filtro["ConvocatoriaName"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroBecarioModels.BecarioConvocatoria = value;
                    }
                }

                if (filtro.ContainsKey("CentroUsuarioId"))
                {
                    value = filtro["CentroUsuarioId"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroBecarioModels.CentroIdUsuario = Convert.ToInt32(value);
                    }
                }

                if (filtro.ContainsKey("CentroSearch"))
                {
                    value = filtro["CentroSearch"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroBecarioModels.CentroIdUsuario = Convert.ToInt32(value);
                    }
                }

            }

            return filtroBecarioModels;
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

        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.AniadirEliminarBecario)]
        public ActionResult CrearEditCentro(int CentroId, string Centro, string Ciudad, string Pais)
        {
            var parameters = new RouteValueDictionary();
            SaveCentroResponse response = null;

            response = _becarioCentroService.SaveCentro(CentroId, Centro, Ciudad, Pais);

            if (!response.IsValid)
            {
                parameters.Add("errorMessage", response.ErrorMessage);
            }

            return RedirectToAction("Create", "Becarios", parameters);
        }

        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.AniadirEliminarBecario)]
        public ActionResult CrearEditConvocatoria(int IdConvocatoria, string NombreConvocatoria)
        {
            var parameters = new RouteValueDictionary();
            SaveConvocatoriaResponse response = null;

            var UsuarioRolPermisoViewModel = (UsuarioRolPermisoViewModel)HttpContext.Session["Usuario"];
            var centroId = UsuarioRolPermisoViewModel.CentroIdUsuario == null ? 0 : UsuarioRolPermisoViewModel.CentroIdUsuario;

            response = _becarioConvocatoriaService.SaveConvocatoria(IdConvocatoria, NombreConvocatoria, (int)centroId);

            if (!response.IsValid)
            {
                parameters.Add("errorMessage", response.ErrorMessage);
            }

            return RedirectToAction("Create", "Becarios", parameters);
        }

        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.AniadirEliminarBecario)]
        [ValidateInput(false)]
        [HttpPost]
        public JsonResult DeleteCentro(int CentroId)
        {
            var response = new JsonResult();
            response.Data = _becarioCentroService.RemoveCentro(CentroId);
            return response;

        }

        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.AniadirEliminarBecario)]
        [ValidateInput(false)]
        [HttpPost]
        public JsonResult DeleteConvocatoria(int ConvocatoriaId)
        {
            var response = new JsonResult();
            response.Data = _becarioConvocatoriaService.RemoveConvocatoria(ConvocatoriaId);
            return response;

        }

        private IEnumerable<SelectListItem> GenerateEstadosBecariosElements()
        {
            var response = _becarioEstadoService.GetEstadosBecarios();
            if (response.IsValid)
            {
                IEnumerable<BecarioEstadoRowViewModel> estadoBecarioList;
                estadoBecarioList = from value in response.BecarioEstadoViewModel orderby value.Orden select value;
                return new SelectList(estadoBecarioList, "BecarioEstadoId", "BecarioEstado");
            }
            else
            {
                return new List<SelectListItem>();
            }
        }

        private void CreateMessageNotify(string textMessg)
        {
            @ViewBag.ShowMessage = true;
            @ViewBag.TypeMessage = TypeMessageEnum.AlertMessage;
            @ViewBag.TitleMessage = Properties.Resources.Becario_NotificacionTitulo;
            @ViewBag.TextMessage = textMessg;
        }

        private void CreateMessageError(string textMessg)
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

        private ActionResult CreateFinish(Byte[] file, CreateEditBecarioViewModel model)
        {
            GuardarBecario(true, file, model);
            _sessionBecarios.Get<FiltroBecarioModels>("filtro_becario");
            return RedirectToAction("Index");
        }

        private void GuardarBecario(bool finish, byte[] file, CreateEditBecarioViewModel model)
        {
            var response = _becarioService.SaveBecario(model.BecarioDatosBasicos, finish);

            if (!response.IsValid)
            {
                CreateMessageError(response.ErrorMessage);
            }
            else
            {
                CreateMessageNotify("Becario guardado correctamente");
            }

            model.BecarioId = response.BecarioId;

            if ((response.NombreCV != null) || (response.NombreCV == ""))
            {
                _becarioService.UploadCV(file, response.BecarioId, response.NombreCV);

            }
        }

        private FiltroBecarioModels GenerateViewElementsIndex(FiltroBecarioModels filtro)
        {
            int[] tiposMaestroId = { (int)MasterDataTypeEnum.TipoBecario,
                                    (int)MasterDataTypeEnum.DecisionFinalPracticas,
                                    (int)MasterDataTypeEnum.TipoTecnologia,
                                    (int)MasterDataTypeEnum.OrigenCv,
                                    (int)MasterDataTypeEnum.FuenteReclutamiento,
                                    (int)MasterDataTypeEnum.NivelIdioma
                                   };
            var response = _maestroService.GetDatosMaestroByTipoId(tiposMaestroId);

            filtro.CentroList = (IEnumerable<SelectListItem>)HttpContext.Session["ListaCentros"];
            filtro.TipoBecarioList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.TipoBecario);
            filtro.ClienteList = GenerateClienteElements();
            filtro.ProyectoList = GenerateProyectoElements();
            filtro.EstadoBecarioList = GenerateEstadosBecariosElements();
            filtro.CentroIdUsuarioLogueado = HttpContext.Session["CentroIdUsuario"] != null ? HttpContext.Session["CentroIdUsuario"].ToString() : string.Empty;
            filtro.TipoDecisionFinalPracticas = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.DecisionFinalPracticas);
            filtro.TipoTecnologiaList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.TipoTecnologia);
            filtro.OrigenCvList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.OrigenCv);
            filtro.FuenteReclutamientoList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.FuenteReclutamiento);
            filtro.NivelIdiomaList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.NivelIdioma);

            List<SelectListItem> gestionDocumentalList = new List<SelectListItem>() {
                    new SelectListItem  { Text = "Si", Value = true.ToString() },
                    new SelectListItem  { Text = "No", Value = false.ToString() }

            };
            filtro.GestionDocumentalList = gestionDocumentalList;
            filtro.Pagina = _sessionBecarios.Get<int>("pagina_actual_becarios") > 0 ? _sessionBecarios.Get<int>("pagina_actual_becarios") : 0;

            return filtro;
        }

        private BecarioDatosBasicosViewModel GenerateViewElementsCreate(BecarioDatosBasicosViewModel model)
        {
            int[] tipoMaestroId =
            {
                (int)MasterDataTypeEnum.TipoBecario,
                (int)MasterDataTypeEnum.TipoIdentificacion,
                (int)MasterDataTypeEnum.OrigenCv,
                (int)MasterDataTypeEnum.FuenteReclutamiento
            };

            var response = _maestroService.GetDatosMaestroByTipoId(tipoMaestroId);

            model.TipoBecarioList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.TipoBecario);
            model.TipoIdentificacionList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.TipoIdentificacion);
            model.OrigenCvList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.OrigenCv);
            model.FuenteReclutamientoList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.FuenteReclutamiento);
            model.Access = "BecarioDatosBasicos.";

            return model;
        }

        private CreateEditBecarioViewModel GenerateViewElementsEdit(CreateEditBecarioViewModel model)
        {
            model.BecarioDatosBasicos = GenerateViewElementsCreate(model.BecarioDatosBasicos);
            model.BecarioObservaciones = GenerateViewElementsEnProceso(model.BecarioObservaciones);
            model.BecarioSeleccion = GenerateViewElementsSeleccion(model.BecarioSeleccion);
            model.BecarioDatosPracticas = GenerateViewElementsPracticas(model.BecarioDatosPracticas);

            model.BecarioDatosBasicos.Access = "BecarioDatosBasicos.";
            model.BecarioObservaciones.AccessObservaciones = "BecarioObservaciones.";
            model.BecarioSeleccion.AccessSeleccion = "BecarioSeleccion.";
            model.BecarioSeleccion.BecarioAsignacion.AccessAsignacion = "BecarioSeleccion.BecarioAsignacion.";
            model.BecarioSeleccion.BecarioGestionDocumental.AccessGestion = "BecarioSeleccion.BecarioGestionDocumental.";
            model.BecarioDatosPracticas.AccessPracticas = "BecarioDatosPracticas.";

            return model;
        }

        private BecarioSeleccionViewModel GenerateViewElementsSeleccion(BecarioSeleccionViewModel model)
        {
            int[] tipoMaestroId =
            {
                (int)MasterDataTypeEnum.Asistencia,
                (int)MasterDataTypeEnum.DecisionFinalPracticas
            };

            var response = _maestroService.GetDatosMaestroByTipoId(tipoMaestroId);

            model.TipoAsistenciaList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.Asistencia);
            model.ClienteList = GenerateClienteElements();
            model.ProyectoList = GenerateProyectoElements();
            model.BecarioAsignacion.AccessAsignacion = "BecarioAsignacion.";
            model.BecarioGestionDocumental.AccessGestion = "BecarioGestionDocumental.";

            return model;
        }

        private BecarioObservacionesViewModel GenerateViewElementsEnProceso(BecarioObservacionesViewModel model)
        {
            int[] tipoMaestroId =
            {
                (int)MasterDataTypeEnum.TipoPrueba,
                (int)MasterDataTypeEnum.TipoResultado
            };

            var response = _maestroService.GetDatosMaestroByTipoId(tipoMaestroId);

            model.TipoPruebaList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.TipoPrueba);
            model.TipoResultadoList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.TipoResultado);

            return model;
        }

        private BecarioDatosPracticasViewModel GenerateViewElementsPracticas(BecarioDatosPracticasViewModel model)
        {
            int[] tipoMaestroId =
            {
                (int)MasterDataTypeEnum.DecisionFinalPracticas
            };

            var response = _maestroService.GetDatosMaestroByTipoId(tipoMaestroId);

            model.TipoDecisionFinalPracticas = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.DecisionFinalPracticas);

            return model;
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

        #region EnviarCorreos

        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.AdministrarRoles)]
        public ActionResult EnviarCorreosBecario(int? userId = null)
        {
            EnviarCorreos(userId);
            return RedirectToAction("Index", "Dashboard");
        }

        private void EnviarCorreos(int? userId = null)
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

            System.Collections.Specialized.NameValueCollection DiccEstadoBecarioPlantillaCorreo = (System.Collections.Specialized.NameValueCollection)ConfigurationManager.GetSection("DiccEstadoBecarioPlantillaCorreo");
            System.Collections.Specialized.NameValueCollection DiccConfiguracionServidorCorreo = (System.Collections.Specialized.NameValueCollection)ConfigurationManager.GetSection("DiccConfiguracionServidorCorreo");

            var Servicio = new SendMailsBecarioService(_becarioService, _candidaturaRepository, _candidatoService, _maestroService);
            
            Servicio.EnviarEmailBecario(DiccEstadoBecarioPlantillaCorreo, DiccConfiguracionServidorCorreo, idUsuario);

        }
        #endregion
    }
}
