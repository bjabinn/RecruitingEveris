using Recruiting.Application.BitacorasBecarios.Services;
using Recruiting.Application.BitacorasNecesidades.Services;
using Recruiting.Application.Roles.ViewModels;
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
    public class BitacorasBecariosController : Controller
    {
        #region Constants


        #endregion

        #region Fields
        private readonly IBitacoraNecesidadService _bitacoraNecesidadService;
        private readonly IMaestroRepository _maestroRepository;
        private readonly IBitacoraNecesidadRepository _bitacoraNecesidadRepository;
        private readonly INecesidadRepository _necesidadRepository;
        private readonly IBecarioRepository _becarioRepository;
        private readonly IBitacoraBecarioRepository _bitacoraBecarioRepository;
        private readonly IBitacoraBecarioService _bitacoraBecarioService;
        private readonly SessionCacheStorageService _sesionBitacorasBecarios;

        #endregion

        #region Construct

        public BitacorasBecariosController()
        {
            _maestroRepository = new MaestroRepository();
            _necesidadRepository = new NecesidadRepository();
            _bitacoraNecesidadRepository = new BitacoraNecesidadRepository();
            _bitacoraNecesidadService = new BitacoraNecesidadService(_bitacoraNecesidadRepository, _necesidadRepository,_maestroRepository);
            _becarioRepository = new BecarioRepository();
            _sesionBitacorasBecarios = new SessionCacheStorageService();
            _bitacoraBecarioRepository = new BitacoraBecarioRepository();
            _bitacoraBecarioService = new BitacoraBecarioService(_bitacoraBecarioRepository);
        }

        #endregion

        #region Actions

        #region Index UI
        // GET: Bitacoras
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.VerBitacora)]
        public ActionResult Index(int BecarioId)
        {
            var filtro = _sesionBitacorasBecarios.Get<FiltroBitacoraBecarioModels>("filtro_bitacoraNecesidad");

            if (filtro == null)
            {
                //orden por defecto
                filtro = new FiltroBitacoraBecarioModels()
                {
                    SortColumn = "BitacoraId",
                    SortOrder = Recruiting.Business.BaseClasses.DataTable.DataTableSortDirectionEnum.Descending
                };
            }
            _sesionBitacorasBecarios.Add("filtro_inicial_bitacora", filtro);
          
            PermisosMostrar();

            _sesionBitacorasBecarios.Add("BecarioId", BecarioId);

            filtro = GenerateViewElementsIndex(filtro);

            return View(filtro);
        }

        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.VerBitacora)]
        public virtual JsonResult LoadBitacoras([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
        {
            PermisosMostrar();

            var request = requestModel.ConvertToDataTableRequestViewModel();

            request.CustomFilters.Add("BecarioId", _sesionBitacorasBecarios.Get<int>("BecarioId").ToString());

            //recupero el filtro por defecto si hay
            var filtro = _sesionBitacorasBecarios.Get<FiltroBitacoraBecarioModels>("filtro_inicial_bitacora");
            if (filtro != null && filtro.SortColumn != string.Empty)
            {
                var Iterador = request.Columns.GetEnumerator();
                while (Iterador.MoveNext())
                {
                    if (Iterador.Current.Name == filtro.SortColumn)
                    {
                        Iterador.Current.SortDirection = filtro.SortOrder;
                    }
                    else
                    {
                        Iterador.Current.SortDirection = null;
                    }

                }
                _sesionBitacorasBecarios.Remove("filtro_inicial_bitacora");
            }
            var response = _bitacoraBecarioService.GetBitacorasByCandidaturaId(request);
           
            var filtroBitacoraModel = MappertoFiltroBitacorasBecarios(request.CustomFilters);

            // guardar el orden seleccionado por el usuario
            if (filtro != null)
            {
                filtroBitacoraModel.SortOrder = filtro.SortOrder;
                filtroBitacoraModel.SortColumn = filtro.SortColumn;
            }
            else
            {
                filtroBitacoraModel.SortOrder = request.Columns.FirstOrDefault(i => i.SortDirection != null).SortDirection.Value;
                filtroBitacoraModel.SortColumn = request.Columns.FirstOrDefault(i => i.SortDirection != null).Name;
            }


            _sesionBitacorasBecarios.Add("filtro_bitacoraNecesidad", filtroBitacoraModel);
            _sesionBitacorasBecarios.Add("pagina_actual", request.PageNumber);



            if (!response.IsValid)
            {
                return null;
            }

            var result = from c in response.BitacoraBecarioRowViewModel
                         select new object[]
            {   c.BitacoraId,            
                c.TipoCambio,
                c.MensajeSistema,
                c.Usuario,
                FormatHelper.Format(c.FechaCreacion, "dd/MM/yyyy"),
                c.Centro,

            };


            var centroUsuarioId = HttpContext.Session["CentroIdUsuario"];
            if ((centroUsuarioId != null) && result.Any())
            {
                var resultTemp = new List<object[]>();
                result.ToList().ForEach(x =>
                {
                    var item = x.ToList();
                    item.RemoveAt(5);
                    resultTemp.Add(item.ToArray());
                });
                result = resultTemp;
            }

            var jsonResponse = new DataTablesResponse(requestModel.Draw, result, response.TotalElementos, response.TotalElementos);
            return Json(jsonResponse, JsonRequestBehavior.AllowGet);
        }



        #endregion

        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.AniadirEliminarBitacora)]
        public ActionResult Create(int? BecarioId, string MensajeSistema)
        {
            BecarioId = Convert.ToInt32(_sesionBitacorasBecarios.Get<int>("BecarioId").ToString());

            var response = _bitacoraBecarioService.GenerateBitacoraBecarioManual(BecarioId ?? 0, MensajeSistema);

            if (!response.IsValid)
            {
                CreateMessageError(response.ErrorMessage);
            }
            else
            {
                CreateMessageNotify("Bitacora guardada correctamente");
            }
            
            var filtro = _sesionBitacorasBecarios.Get<FiltroBitacoraBecarioModels>("filtro_bitacoraNecesidad");
            if (filtro == null)
            {
                filtro = new FiltroBitacoraBecarioModels();
            }
            return RedirectToAction("Index", filtro);
        }

        public ActionResult IndexError()
        {
            TempData["ErrorPermiso"] = true;
            
            var filtro = _sesionBitacorasBecarios.Get<FiltroBitacoraNecesidadModels>("filtro_bitacoraNecesidad");

            if (filtro == null)
            {
                filtro = new FiltroBitacoraNecesidadModels();
            }
            return View("Index", filtro);
        }

        //Esta acción nos permite volver desde otra página con el filtro
        public ActionResult Volver()
        {
            _sesionBitacorasBecarios.Remove("pagina_actual");
            _sesionBitacorasBecarios.Remove("BecarioId");
            _sesionBitacorasBecarios.Remove("filtro_inicial_bitacora");
            _sesionBitacorasBecarios.Remove("filtro_bitacoraNecesidad");
            return RedirectToAction( "Index", "Becarios");
        }

        #region Limpiar


        #endregion



        #endregion

        #region Private Methods

        private void PermisosMostrar()
        {
            TempData["AniadirEliminarBitacora"] = false;
            TempData["ModificarBitacora"] = false;
            TempData["VerBitacora"] = false;
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

            if (privilegeLevels.Contains(PermisosConst.AniadirEliminarBitacora)) TempData["AniadirEliminarBitacora"] = true;
            if (privilegeLevels.Contains(PermisosConst.ModificarBitacora)) TempData["ModificarBitacora"] = true;
            if (privilegeLevels.Contains(PermisosConst.VerBitacora)) TempData["VerBitacora"] = true;
        }

        private FiltroBitacoraBecarioModels GenerateViewElementsIndex(FiltroBitacoraBecarioModels model)
        {
            int BecarioId = Convert.ToInt32(_sesionBitacorasBecarios.Get<int>("BecarioId").ToString());
            model.CentroIdUsuarioLogueado = HttpContext.Session["CentroIdUsuario"] != null ? HttpContext.Session["CentroIdUsuario"].ToString() : string.Empty;


            var becario = _becarioRepository.GetByCriteria(x => x.BecarioId == BecarioId).FirstOrDefault();

            if (becario != null)
            {
                model.BecarioId = becario.BecarioId;
                model.EstadoBecario = becario.TipoEstadoBecario.EstadoBecario;
                model.CentroProcedencia = becario.BecarioCentroProcedenciaId == null ? null : becario.BecarioCentroProcedencia.Centro;
                model.TipoBecario = becario.TipoBecario.Nombre;
                model.NombreBecario = becario.Candidato.Nombre + " " + becario.Candidato.Apellidos;
                model.CentroUsuarioCreacion = becario.Usuario.Centro != null ? becario.Usuario.Centro.Nombre : string.Empty;
            }

            return model;
        }   

        private void CreateMessageNotify(string textMessg)
        {
            @ViewBag.ShowMessage = true;
            @ViewBag.TypeMessage = TypeMessageEnum.AlertMessage;
            @ViewBag.TitleMessage = Properties.Resources.Bitacora_NotificacionTitulo;
            @ViewBag.TextMessage = textMessg;

        }

        private void CreateMessageError(string textMessg)
        {
            @ViewBag.ShowMessage = true;
            @ViewBag.TypeMessage = TypeMessageEnum.ErrorMessage;
            @ViewBag.TitleMessage = Properties.Resources.Bitacora_ErrorTitulo;
            @ViewBag.TextMessage = textMessg;

        }

        private FiltroBitacoraBecarioModels MappertoFiltroBitacorasBecarios(IDictionary<string, string> filtro)
        {
            var FiltroBitacoraBecarioModel = new FiltroBitacoraBecarioModels();

            if (filtro.Count != 0)
            {
                string value;

                if (filtro.ContainsKey("BitacoraId"))
                {
                    value = filtro["BitacoraId"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        FiltroBitacoraBecarioModel.BitacoraId = Convert.ToInt32(value);
                    }
                }

                if (filtro.ContainsKey("BecarioId"))
                {
                    value = filtro["BecarioId"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        FiltroBitacoraBecarioModel.BecarioId = Convert.ToInt32(value);
                    }
                }

                if (filtro.ContainsKey("TipoCambio"))
                {
                    value = filtro["TipoCambio"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        FiltroBitacoraBecarioModel.TipoCambio = value;
                    }
                }

                if (filtro.ContainsKey("MensajeSistema"))
                {
                    value = filtro["MensajeSistema"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        FiltroBitacoraBecarioModel.MensajeSistema = value;
                    }
                }

                if (filtro.ContainsKey("Usuario"))
                {
                    value = filtro["Usuario"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        FiltroBitacoraBecarioModel.UsuarioCreacionId = Convert.ToInt32(value);
                    }
                }

                if (filtro.ContainsKey("FechaCreacion"))
                {
                    value = filtro["FechaCreacion"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        FiltroBitacoraBecarioModel.FechaCreacion = Convert.ToDateTime(value);
                    }
                }

                if (filtro.ContainsKey("CentroUsuarioId"))
                {
                    value = filtro["CentroUsuarioId"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        FiltroBitacoraBecarioModel.CentroIdUsuario = Convert.ToInt32(value);
                    }
                }

                if (filtro.ContainsKey("CentroSearch"))
                {
                    value = filtro["CentroSearch"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        FiltroBitacoraBecarioModel.CentroIdUsuario = Convert.ToInt32(value);
                    }
                }
            }

            return FiltroBitacoraBecarioModel;
        }



        #endregion

    }
}