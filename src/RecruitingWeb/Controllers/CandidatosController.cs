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
using Recruiting.Application.Usuarios.ViewModels;
using Recruiting.Application.Candidatos.Services;
using Recruiting.Application.Candidatos.ViewModels;

using Recruiting.Business.Repositories;
using Recruiting.Business.BaseClasses.DataTable;

using Recruiting.Infra.Caching;
using Recruiting.Data.EntityFramework.Repositories;
using Recruiting.Application.Candidaturas.Enums;
using Recruiting.Application.Candidaturas.ViewModel;
using Recruiting.Application.Candidaturas.Services;
using Recruiting.Application.Becarios.Enums;
using System.Web.Routing;
using Recruiting.Application.Candidatos.Messages;
using Recruiting.Application.Candidatos.Enums;

namespace RecruitingWeb.Controllers
{
    public class CandidatosController : Controller
    {
        #region Constants

        private const int MIN_PTUNTOS_EXP = 1;
        private const int MAX_PTUNTOS_EXP = 10;
        private const string SeparatorBar = "\\";

        #endregion

        #region Fields

        private readonly ICandidatoService _candidatoService;
        private readonly ICandidatoRepository _candidatoRepository;
        private readonly ICandidatoIdiomaRepository _candidatoIdiomaRepository;
        private readonly ICandidatoExperienciaRepository _candidatoExperienciaRepository;
        private readonly ICandidatoContactoRepository _candidatoContactoRepository;
        private readonly IBecarioRepository _becarioRepository;

        private readonly ICandidaturaRepository _candidaturaRepository;

        private readonly IMaestroRepository _maestroRepository;
        private readonly MaestroService _maestroService;
        private readonly SessionCacheStorageService _sesionCandidatos;

        private readonly ICandidaturaEstadoRepository _candidaturaEstadoRepository;
        private readonly ICandidaturaEstadoService _candidaturaEstadoService;

        private readonly ICandidatoCentroEducativoRepository _candidatoCentroEducativoRepository;
        private readonly ICandidatoCentroService _candidatoCentroService;

        #endregion

        #region Construct

        public CandidatosController()
        {

            _candidatoRepository = new CandidatoRepository();
            _candidatoIdiomaRepository = new CandidatoIdiomaRepository();
            _candidatoExperienciaRepository = new CandidatoExperienciaRepository();
            _candidatoContactoRepository = new CandidatoContactoRepository();
            _candidaturaRepository = new CandidaturaRepository();
            _becarioRepository = new BecarioRepository();

            _sesionCandidatos = new SessionCacheStorageService();
            _candidatoService = new CandidatoService(_candidatoRepository, _candidatoIdiomaRepository,
                _candidatoExperienciaRepository, _candidatoContactoRepository, _candidaturaRepository,_becarioRepository);

            _maestroRepository = new MaestroRepository();
            _maestroService = new MaestroService(_maestroRepository);

            _candidaturaEstadoRepository = new CandidaturaEstadoRepository();
            _candidaturaEstadoService = new CandidaturaEstadoService(_candidaturaEstadoRepository);

            _candidatoCentroEducativoRepository = new CandidatoCentroEducativoRepository();
            _candidatoCentroService = new CandidatoCentroService(_candidatoCentroEducativoRepository);
        }

        #endregion

        #region Index Members
        
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.VerCandidato)]
        public ActionResult Index()
        {
            var filtro = _sesionCandidatos.Get<FiltroCandidatoModels>("filtro_candidato") ?? new FiltroCandidatoModels();

            filtro = GenerateViewElementsIndex(filtro);

           
            PermisosMostrar();

            return View(filtro);
        }



        [HttpPost]
        public JsonResult ComprobarExisteUsuario(string contacto, int? idCandidato)
        {
            var respose = new JsonResult();
          
                if (!string.IsNullOrEmpty(contacto))
                {
                    var response = _candidatoService.SearchCandidatoByContactoResponse(contacto, idCandidato);

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
        public JsonResult GetCentrosEducativosByNombreCentro(string textSearch)
        {
            var response = _candidatoCentroService.GetCentrosByNombreCentro(textSearch);

            var isValid = response.IsValid;
            var errorMessage = response.ErrorMessage;
            var usuarios = response.CentrosProcedencia.Select(x => new SelectListItem()
            {
                Text = x.Centro,
                Value = x.CentroId.ToString()
            });

            return Json(new { IsValid = isValid, ErrorMessage = errorMessage, Items = usuarios });
        }

        #endregion

        #region Edit Members

        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.ModificarCandidato)]
        public ActionResult Edit(int id)
        {
            var model = new CreateEditCandidatoViewModel();
            var responseCandidato = _candidatoService.GetCandidatoById(id);
            if (!responseCandidato.IsValid)
            {
                CreateMessageError(responseCandidato.ErrorMessage);
            }
            else
            {
                model = responseCandidato.CandidatoViewModel;
            }

            model = GenerateViewElementsCreateEdit(model);

            return View("Edit", model);
        }   
        
        

        [ValidateInput(false)]
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

        #region Details Members
        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.VerCandidato)]
        public ActionResult Details(int id)
        {
            var model = _candidatoService.GetCandidatoById(id).CandidatoViewModel;
            
            return View(model);
        }
        #endregion

        #region Create Members
        [HttpGet]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.AniadirEliminarCandidato)]
        public ActionResult Create(int? id = null)
        {

            var model = new CreateEditCandidatoViewModel
            {
                ContactCandidatoViewModel = new List<CreateEditRowContactoCandidatoViewModel>(),
                ExpCandidatoViewModel = new List<CreateEditRowExperienciaCandidatoViewModel>(),
                IdiomaCandidatoViewModel = new List<CreateEditRowIdiomaCandidatoViewModel>()
            };

            if (id.HasValue)
            {
                model = _candidatoService.GetCandidatoById((int)id).CandidatoViewModel;
            }

            model = GenerateViewElementsCreateEdit(model);

            return View(model);
        }
       
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(CreateEditCandidatoViewModel viewModel, FormCollection collection)
        {
            viewModel.ExpCandidatoViewModel = viewModel.ExpCandidatoViewModel ?? new List<CreateEditRowExperienciaCandidatoViewModel>();
            viewModel.ContactCandidatoViewModel = viewModel.ContactCandidatoViewModel ?? new List<CreateEditRowContactoCandidatoViewModel>();
            viewModel.IdiomaCandidatoViewModel = viewModel.IdiomaCandidatoViewModel ?? new List<CreateEditRowIdiomaCandidatoViewModel>();
          
            return CreateFinish(viewModel);
        }

        [ValidateInput(false)]
        private ActionResult CreateFinish(CreateEditCandidatoViewModel viewModel)
        { 
            SaveCandidato(viewModel);            
            return RedirectToAction("Index");
        }

        private void SaveCandidato(CreateEditCandidatoViewModel viewModel)
        {
            var response = _candidatoService.SaveCandidato(viewModel);
            if (!response.IsValid)
            {
                CreateMessageError(response.ErrorMessage);
            }
            else
            {
                CreateMessageNotify("Candidato Guardado Correctamente");
            }
            viewModel.CandidatoId = response.CandidatoId;
        }
        #endregion

        #region Load Table Members
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.VerCandidato)]
        public virtual JsonResult LoadCandidatos([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
        {
            PermisosMostrar();

            var request = requestModel.ConvertToDataTableRequestViewModel();

            var response = _candidatoService.GetCandidatosCandidatura(request);
            var filtroCandidatoModel = MappertoFiltroCandidatos(request.CustomFilters);
            _sesionCandidatos.Add("filtro_candidato", filtroCandidatoModel);
            _sesionCandidatos.Add("pagina_actual", request.PageNumber);

            if (!response.IsValid)
            {
                return null;
            }

            var result = from c in response.CandidatoRowViewModel
                         select new object[]
            {
                c.Nombres,
                c.Apellidos,
                c.NumeroIdentificacion,
                c.Titulacion,
                FormatHelper.Format(c.FechaNacimiento, "dd/MM/yyyy"),
                c.NumCandidaturasAsociadas,
                c.Centro,
                c.NivelIdioma,
                this.RenderRazorViewToString("Table/actionColumn", c)
            };

            var jsonResponse = new DataTablesResponse(requestModel.Draw, result, response.TotalElementos, response.TotalElementos);
            return Json(jsonResponse, JsonRequestBehavior.AllowGet);
        }

        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.VerCandidatura)]
        [ValidateInput(false)]
        public virtual JsonResult LoadCandidaturasModal([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
        {
            var request = requestModel.ConvertToDataTableRequestViewModel();        
          
            var response = _candidatoService.GetCandidatoCandidaturasModal(request);

            if (!response.IsValid)
            {
                return null;
            }

            ////Esto muestra el estado "Entrevista" aunque físicamente estemos en "Segunda Entrevista".
            var estadoCandidaturaEntrevista = GenerateEstadosElements().First(x => x.Value == ((int)TipoEstadoCandidaturaEnum.Entrevista).ToString()).Text;
            foreach (var candidaturaRow in response.CandidaturaModalRowViewModel)
            {
                if (candidaturaRow.EstadoId == (int)TipoEstadoCandidaturaEnum.SegundaEntrevista)
                {
                    candidaturaRow.Estado = estadoCandidaturaEntrevista;
                }
            }

            var result = from c in response.CandidaturaModalRowViewModel
                         select new object[]
                            {
                            c.CandidaturaId,
                            c.OrigenCv == null ? "" : c.OrigenCv.ToString(),
                            (c.EstadoId == (int)TipoEstadoCandidaturaEnum.Renuncia
                            || c.EstadoId == (int)TipoEstadoCandidaturaEnum.Descartado ) ? string.Format("<span class=\"Statered\">{0}</span>", c.Estado) :  c.Estado,
                            (c.EstadoId == (int)TipoEstadoCandidaturaEnum.Contratado) ? string.Format("<span class=\"hidden\">{0}</span>", c.Etapa) :   c.Etapa,
                            c.Candidato,
                            c.TipoTecnologia == null ? "" : c.TipoTecnologia.ToString(),
                            c.Entrevistador,
                            (c.EtapaId == (int)TipoEtapaCandidaturaEnum.FiltradoTecnico
                            || c.EtapaId == (int)TipoEtapaCandidaturaEnum.Inicio
                            || c.EtapaId == (int)TipoEtapaCandidaturaEnum.AgendarEntrevistas ) ? "": FormatHelper.Format(c.Agendada.Date, "dd/MM/yyyy"),
                            c.Perfil,
                            c.Modulo,
                            c.PersonaCreacion,
                            c.Centro,
                            this.RenderRazorViewToString("Table/actionColumnModalCandidatura", c),
                            };

            var jsonResponse = new DataTablesResponse(requestModel.Draw, result, response.TotalElementos, response.TotalElementos);

            return Json(jsonResponse, JsonRequestBehavior.AllowGet);           

        }
        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.VerBecario)]
        public virtual JsonResult LoadCentrosProcedencia([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
        {
            var request = requestModel.ConvertToDataTableRequestViewModel();


            var response = _candidatoCentroService.GetCentros(request);

            if (!response.IsValid)
            {
                return null;
            }

            var result = from c in response.CentroEducativo
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


        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.VerBecario)]
        [ValidateInput(false)]
        public virtual JsonResult LoadBecariosModal([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
        {
            var request = requestModel.ConvertToDataTableRequestViewModel();

            var response = _candidatoService.GetCandidatoBecariosModal(request);

            if (!response.IsValid)
            {
                return null;
            }     

            var result = from c in response.BecarioModalRowViewModel
                         select new object[]
                            {
                            c.BecarioId,
                            c.BecarioNombre,
                            c.CandidatoId,
                            c.TipoBecario,
                            c.CentroProcedencia,
                            c.Cliente,
                            c.Proyecto,
                            c.FechaInicio,
                            c.FechaFin,
                            c.FechaFinReal,
                            c.EstadoBecarioId == (int)TipoEstadoBecarioEnum.Descartado || c.EstadoBecarioId == (int)TipoEstadoBecarioEnum.Renuncia ? string.Format("<span class=\"Statered\">{0}</span>", c.EstadoBecario) :  c.EstadoBecario,
                            c.Centro,
                            c.PersonaCreacion,
                            
                            this.RenderRazorViewToString("Table/actionColumnModalBecario", c),
                            };

            var jsonResponse = new DataTablesResponse(requestModel.Draw, result, response.TotalElementos, response.TotalElementos);

            return Json(jsonResponse, JsonRequestBehavior.AllowGet);

        }
        #endregion
        //---------------------------------------------- LIMITE ORDER ----------------------------------------------//
        #region Actions

        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.VerCandidato)]
        public ActionResult Desbloquear()
        {           
            return RedirectToAction("Index");
        }

        #region Delete UI


        [HttpPost]
        public JsonResult ComprobarCandidatoUsado(int CandidatoId)
        {
            var response = _candidatoService.SearchCandidatoUsado(CandidatoId);
            return Json(response, JsonRequestBehavior.AllowGet);

        }
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.AniadirEliminarCandidato)]
        [ValidateInput(false)]
        [HttpPost]
        public JsonResult DeleteCentro(int CentroId)
        {
            var response = new JsonResult();
            response.Data = _candidatoCentroService.RemoveCentro(CentroId);
            return response;

        }

        [HttpPost]
        public JsonResult ComprobarCentroUsado(int CentroId)
        {
            var response = _candidatoCentroService.SearchCentroUsado(CentroId);
            return Json(response, JsonRequestBehavior.AllowGet);


        }

        [HttpPost]
        public JsonResult ComprobarExisteCentro(string NombreCentro, string Ciudad, string Pais)
        {
            var respose = new JsonResult();
            if (!string.IsNullOrEmpty(NombreCentro) && !string.IsNullOrEmpty(Ciudad) && !string.IsNullOrEmpty(Pais))
            {
                var response = _candidatoCentroService.SearchCentroByNombreCiudadPais(NombreCentro, Ciudad, Pais);
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

        // POST: Candidatos/Delete/*
        [ValidateInput(false)]
        [HttpPost]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.AniadirEliminarCandidato)]
        public JsonResult Delete(int id)
        {
            var respose = new JsonResult
            {
                Data = _candidatoService.DeleteCandidato(id)
            };
            return respose;
        }

        #endregion 

        public FileResult DownloadCV(int id)
        {
            try
            {
                var response = _candidatoService.DownloadLastCV(id);
                var contentType = GetContentType(response.NombreCV);
                var rutaReal = System.IO.Path.Combine(response.UrlCV, response.CandidaturaId.ToString());
                return File(rutaReal + SeparatorBar + response.NombreCV, contentType, response.NombreCV);
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
            _sesionCandidatos.Remove("filtro_candidato");
            return RedirectToAction("Index");
        }

        #endregion


        #region ExportToExcel
        public void ExportToExcel(string filterNombre, string filterApellidos, string filterTipoTitulacion,
            string filterTipoIdentificacion, string filterNumeroIdentificacion, string filterTipoTecnologia, string filterCentro,
            string filterEmail, string filterTelefono, string filterCentroEducativoId, string filterAnioRegresado, string filterNivelIdioma)
        {
            IDictionary<string, string> CustomFilters = new Dictionary<string, string> {
                    { "Nombre", filterNombre },
                    { "Apellidos",filterApellidos},
                    { "TipoTitulacion",filterTipoTitulacion },
                    { "TipoIdentificacion", filterTipoIdentificacion},
                    { "NumeroIdentificacion", filterNumeroIdentificacion },
                    { "TipoTecnologia", filterTipoTecnologia },
                    { "CentroSearch", filterCentro },
                    { "Email", filterEmail },
                    { "Telefono", filterTelefono },
                    { "CentroEducativoId", filterCentroEducativoId },
                    { "AnioRegresado", filterAnioRegresado },
                    { "NivelIdioma", filterNivelIdioma}

            };

            var request = new DataTableRequest
            {
                CustomFilters = CustomFilters
            };
            var response = _candidatoService.GetCandidatosExportToExcel(request);

            var grid = new System.Web.UI.WebControls.GridView
            {
                DataSource = response.CandidatoRowExportToExcelViewModel
            };
            grid.DataBind();
            Response.ClearContent();
            string filename = string.Format("Listado_de_Candidatos_{0}", DateTime.Now.ToShortDateString() + ".xls");
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
        public ActionResult CrearEditCentro(int CentroId, string Centro, string Ciudad, string Pais)
        {
            var parameters = new RouteValueDictionary();
            SaveCentroResponse response = null;

            response = _candidatoCentroService.SaveCentro(CentroId, Centro, Ciudad, Pais);

            if (!response.IsValid)
            {
                parameters.Add("errorMessage", response.ErrorMessage);
            }

            return RedirectToAction("Create", "Candidatos", parameters);
        }
        [HttpPost]
        public JsonResult GetCentrosByNombreCentro(string textSearch)
        {
            var response = _candidatoCentroService.GetCentrosByNombreCentro(textSearch);

            var isValid = response.IsValid;
            var errorMessage = response.ErrorMessage;
            var centros = response.CentrosProcedencia.Select(x => new SelectListItem()
            {
                Text = x.Centro + '(' + x.Ciudad + " - " + x.Pais + ')',
                Value = x.CentroId.ToString()
            });

            return Json(new { IsValid = isValid, ErrorMessage = errorMessage, Items = centros });
        }//GetCentrosByNombreCentro


        #endregion
        #endregion

        #region Private Methods

        private void PermisosMostrar()
        {
            TempData["AniadirEliminarCandidato"] = false;
            TempData["AniadirEliminarCandidatura"] = false;
            TempData["ModificarCandidato"] = false;
            TempData["VerCandidato"] = false;
            TempData["VerCandidaturas"] = false;
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

            if (privilegeLevels.Contains(PermisosConst.AniadirEliminarCandidato)) TempData["AniadirEliminarCandidato"] = true;
            if (privilegeLevels.Contains(PermisosConst.ModificarCandidato)) TempData["ModificarCandidato"] = true;
            if (privilegeLevels.Contains(PermisosConst.AniadirEliminarCandidatura)) TempData["AniadirEliminarCandidatura"] = true;
            if (privilegeLevels.Contains(PermisosConst.AniadirEliminarCandidatura)) TempData["VerCandidaturas"] = true;
            if (privilegeLevels.Contains(PermisosConst.VerCandidato)) TempData["VerCandidato"] = true;
        }
                
        private void CreateMessageNotify(string textMessg)
        {
            @ViewBag.ShowMessage = true;
            @ViewBag.TypeMessage = TypeMessageEnum.AlertMessage;
            @ViewBag.TitleMessage = Properties.Resources.Candidato_NotificacionTitulo;
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


        private FiltroCandidatoModels MappertoFiltroCandidatos(IDictionary<string, string> filtro)
        {
            var filtroCandidatoModels = new FiltroCandidatoModels();

            if (filtro.Count != 0)
            {
                string value;
                if (filtro.ContainsKey("Nombre"))
                {
                    value = filtro["Nombre"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroCandidatoModels.Nombre = value;
                    }
                }

                if (filtro.ContainsKey("Apellidos"))
                {
                    value = filtro["Apellidos"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroCandidatoModels.Apellidos = value;
                    }
                }

                if (filtro.ContainsKey("TipoTitulacion"))
                {
                    value = filtro["TipoTitulacion"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroCandidatoModels.TipoTitulacionId = Convert.ToInt32(value);
                    }
                }

                if (filtro.ContainsKey("TipoIdentificacion"))
                {
                    value = filtro["TipoIdentificacion"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroCandidatoModels.TipoIdentificacionId = Convert.ToInt32(value);
                    }
                }

                if (filtro.ContainsKey("NumeroIdentificacion"))
                {
                    value = filtro["NumeroIdentificacion"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroCandidatoModels.NumeroIdentificacion = value;
                    }
                }

                if (filtro.ContainsKey("CentroUsuarioId"))
                {
                    value = filtro["CentroUsuarioId"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroCandidatoModels.CentroIdUsuario = Convert.ToInt32(value);
                    }
                }

                if (filtro.ContainsKey("CentroSearch"))
                {
                    value = filtro["CentroSearch"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroCandidatoModels.CentroIdUsuario = Convert.ToInt32(value);
                    }
                }               
                if (filtro.ContainsKey("TipoTecnologia"))
                {
                    value = filtro["TipoTecnologia"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroCandidatoModels.TipoTecnologiaId = Convert.ToInt32(value);
                    }
                }
                if (filtro.ContainsKey("Email"))
                {
                    value = filtro["Email"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroCandidatoModels.Email = value;
                    }
                }
                if (filtro.ContainsKey("Telefono"))
                {
                    value = filtro["Telefono"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroCandidatoModels.Telefono = value;
                    }
                }
                if (filtro.ContainsKey("CentroEducativoId"))
                {
                    value = filtro["CentroEducativoId"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroCandidatoModels.CentroEducativoId = Convert.ToInt32(value);
                    }
                }
                if (filtro.ContainsKey("CentroEducativoName"))
                {
                    value = filtro["CentroEducativoName"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroCandidatoModels.CentroEducativoName = value;
                    }
                }
                if (filtro.ContainsKey("AnioRegresado"))
                {
                    value = filtro["AnioRegresado"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroCandidatoModels.AnioRegresado = value;
                    }
                }

                if (filtro.ContainsKey("NivelIdioma"))
                {
                    value = filtro["NivelIdioma"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        filtroCandidatoModels.NivelIdioma = value;
                    }
                }

            }

            return filtroCandidatoModels;
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
        
        private FiltroCandidatoModels GenerateViewElementsIndex(FiltroCandidatoModels filtro)
        {
            int[] tipoMaestroId =
          {
                (int)MasterDataTypeEnum.TipoIdentificacion,
                (int)MasterDataTypeEnum.TipoTecnologia,
                (int)MasterDataTypeEnum.Titulacion,
                (int)MasterDataTypeEnum.Centro,
                (int)MasterDataTypeEnum.Idioma,
                (int)MasterDataTypeEnum.NivelIdioma
            };
            var response = _maestroService.GetDatosMaestroByTipoId(tipoMaestroId);
            filtro.TipoIdentificacionList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.TipoIdentificacion);
            filtro.TipoTecnologiaList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.TipoTecnologia);
            filtro.TitulacionList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.Titulacion);
            filtro.CentroList = (IEnumerable<SelectListItem>)HttpContext.Session["ListaCentros"];
            filtro.Centro = (IEnumerable<SelectListItem>)HttpContext.Session["ListaCentros"];
            filtro.Pagina = _sesionCandidatos.Get<int>("pagina_actual") > 0 ? _sesionCandidatos.Get<int>("pagina_actual") : 0;
            filtro.IdiomaList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.Idioma);
            filtro.NivelIdiomaList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.NivelIdioma);


            return filtro;
        }

        private CreateEditCandidatoViewModel GenerateViewElementsCreateEdit(CreateEditCandidatoViewModel model)
        {
            int[] tipoMaestroId =
            {
                (int)MasterDataTypeEnum.TipoIdentificacion,
                (int)MasterDataTypeEnum.Titulacion,
                (int)MasterDataTypeEnum.TipoMedioContacto,
                (int)MasterDataTypeEnum.TipoTecnologia,
                (int)MasterDataTypeEnum.NivelTecnologia,
                (int)MasterDataTypeEnum.Idioma,
                (int)MasterDataTypeEnum.NivelIdioma,
            };            

            var response = _maestroService.GetDatosMaestroByTipoId(tipoMaestroId);

            model.TipoIdentificacionList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.TipoIdentificacion);
            model.TipoContactoList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.TipoMedioContacto);
            model.TipoTecnologiaList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.TipoTecnologia);
            model.NivelExpList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.NivelTecnologia);
            model.ExperienciaList = ControllerHelper.GenerateElements(MIN_PTUNTOS_EXP, MAX_PTUNTOS_EXP);
            model.IdiomaList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.Idioma);
            model.NivelIdiomaList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.NivelIdioma);
            model.TitulacionList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.Titulacion);

            return model;
        }

        #endregion

    }
}