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
    public class BitacorasNecesidadesController : Controller
    {
        #region Constants


        #endregion

        #region Fields
        private readonly IBitacoraNecesidadService _bitacoraNecesidadService;
        private readonly IMaestroRepository _maestroRepository;
        private readonly IBitacoraNecesidadRepository _bitacoraNecesidadRepository;
        private readonly INecesidadRepository _necesidadRepository; 
        private readonly SessionCacheStorageService _sesionBitacorasNecesidades;

        #endregion

        #region Construct

        public BitacorasNecesidadesController()
        {
            _maestroRepository = new MaestroRepository();
            _necesidadRepository = new NecesidadRepository();
            _bitacoraNecesidadRepository = new BitacoraNecesidadRepository();
            _bitacoraNecesidadService = new BitacoraNecesidadService(_bitacoraNecesidadRepository, _necesidadRepository,_maestroRepository);

            _sesionBitacorasNecesidades = new SessionCacheStorageService();
        }

        #endregion

        #region Actions

        #region Index UI
        // GET: Bitacoras
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.VerBitacora)]
        public ActionResult Index(int NecesidadId)
        {
            var filtro = _sesionBitacorasNecesidades.Get<FiltroBitacoraNecesidadModels>("filtro_bitacoraNecesidad");

            if (filtro == null)
            {
                //orden por defecto
                filtro = new FiltroBitacoraNecesidadModels()
                {
                    SortColumn = "BitacoraId",
                    SortOrder = Recruiting.Business.BaseClasses.DataTable.DataTableSortDirectionEnum.Descending
                };
            }
            _sesionBitacorasNecesidades.Add("filtro_inicial_bitacora", filtro);
          
            PermisosMostrar();

            _sesionBitacorasNecesidades.Add("NecesidadId", NecesidadId);

            filtro = GenerateViewElementsIndex(filtro);

            return View(filtro);
        }

        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.VerBitacora)]
        public virtual JsonResult LoadBitacoras([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
        {
            PermisosMostrar();

            var request = requestModel.ConvertToDataTableRequestViewModel();

            request.CustomFilters.Add("NecesidadId", _sesionBitacorasNecesidades.Get<int>("NecesidadId").ToString());

            //recupero el filtro por defecto si hay
            var filtro = _sesionBitacorasNecesidades.Get<FiltroBitacoraModels>("filtro_inicial_bitacora");
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
                _sesionBitacorasNecesidades.Remove("filtro_inicial_bitacora");
            }

            var response = _bitacoraNecesidadService.GetBitacorasByNecesidadId(request);
            var filtroBitacoraModel = MappertoFiltroBitacorasNecesidades(request.CustomFilters);

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


            _sesionBitacorasNecesidades.Add("filtro_bitacoraNecesidad", filtroBitacoraModel);
            _sesionBitacorasNecesidades.Add("pagina_actual", request.PageNumber);



            if (!response.IsValid)
            {
                return null;
            }

            var result = from c in response.BitacoraNecesidadRowViewModel
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
        public ActionResult Create(int? NecesidadId, string MensajeSistema)
        {
            NecesidadId = Convert.ToInt32(_sesionBitacorasNecesidades.Get<int>("NecesidadId").ToString());

            var response = _bitacoraNecesidadService.GenerateBitacoraNecesidadManual(NecesidadId ?? 0, MensajeSistema);

            if (!response.IsValid)
            {
                CreateMessageError(response.ErrorMessage);
            }
            else
            {
                CreateMessageNotify("Bitacora guardada correctamente");
            }
            
            var filtro = _sesionBitacorasNecesidades.Get<FiltroBitacoraNecesidadModels>("filtro_bitacoraNecesidad");
            if (filtro == null)
            {
                filtro = new FiltroBitacoraNecesidadModels();
            }
            return RedirectToAction("Index", filtro);
        }

        public ActionResult IndexError()
        {
            TempData["ErrorPermiso"] = true;
            
            var filtro = _sesionBitacorasNecesidades.Get<FiltroBitacoraNecesidadModels>("filtro_bitacoraNecesidad");

            if (filtro == null)
            {
                filtro = new FiltroBitacoraNecesidadModels();
            }
            return View("Index", filtro);
        }

        //Esta acción nos permite volver desde otra página con el filtro
        public ActionResult Volver()
        {
            _sesionBitacorasNecesidades.Remove("pagina_actual");
            _sesionBitacorasNecesidades.Remove("NecesidadId");
            _sesionBitacorasNecesidades.Remove("filtro_inicial_bitacora");
            _sesionBitacorasNecesidades.Remove("filtro_bitacoraNecesidad");
            return RedirectToAction( "Index", "Necesidades");
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

        private FiltroBitacoraNecesidadModels GenerateViewElementsIndex(FiltroBitacoraNecesidadModels model)
        {
            int NecesidadId = Convert.ToInt32(_sesionBitacorasNecesidades.Get<int>("NecesidadId").ToString());
            model.CentroIdUsuarioLogueado = HttpContext.Session["CentroIdUsuario"] != null ? HttpContext.Session["CentroIdUsuario"].ToString() : string.Empty;


            var necesidad = _necesidadRepository.GetByCriteria(x => x.NecesidadId == NecesidadId).FirstOrDefault();

            if (necesidad != null)
            {
                model.NecesidadId = necesidad.NecesidadId;
                model.EstadoNecesidad = necesidad.EstadoNecesidad.Nombre;
                model.Perfil = necesidad.TipoPerfil.Nombre;
                model.PersonaAsignada = necesidad.PersonaAsignada;
                model.TipoTecnologia = necesidad.TipoTecnologia.Nombre;
                model.CentroUsuarioCreacion = necesidad.Usuario.Centro != null ? necesidad.Usuario.Centro.Nombre : string.Empty;
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

        private FiltroBitacoraNecesidadModels MappertoFiltroBitacorasNecesidades(IDictionary<string, string> filtro)
        {
            var FiltroBitacoraNecesidadModel = new FiltroBitacoraNecesidadModels();

            if (filtro.Count != 0)
            {
                string value;

                if (filtro.ContainsKey("BitacoraId"))
                {
                    value = filtro["BitacoraId"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        FiltroBitacoraNecesidadModel.BitacoraId = Convert.ToInt32(value);
                    }
                }

                if (filtro.ContainsKey("NecesidadId"))
                {
                    value = filtro["NecesidadId"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        FiltroBitacoraNecesidadModel.NecesidadId = Convert.ToInt32(value);
                    }
                }

                if (filtro.ContainsKey("TipoCambio"))
                {
                    value = filtro["TipoCambio"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        FiltroBitacoraNecesidadModel.TipoCambio = value;
                    }
                }

                if (filtro.ContainsKey("MensajeSistema"))
                {
                    value = filtro["MensajeSistema"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        FiltroBitacoraNecesidadModel.MensajeSistema = value;
                    }
                }

                if (filtro.ContainsKey("Usuario"))
                {
                    value = filtro["Usuario"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        FiltroBitacoraNecesidadModel.UsuarioCreacionId = Convert.ToInt32(value);
                    }
                }

                if (filtro.ContainsKey("FechaCreacion"))
                {
                    value = filtro["FechaCreacion"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        FiltroBitacoraNecesidadModel.FechaCreacion = Convert.ToDateTime(value);
                    }
                }




                if (filtro.ContainsKey("CentroUsuarioId"))
                {
                    value = filtro["CentroUsuarioId"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        FiltroBitacoraNecesidadModel.CentroIdUsuario = Convert.ToInt32(value);
                    }
                }

                if (filtro.ContainsKey("CentroSearch"))
                {
                    value = filtro["CentroSearch"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        FiltroBitacoraNecesidadModel.CentroIdUsuario = Convert.ToInt32(value);
                    }
                }
            }

            return FiltroBitacoraNecesidadModel;
        }



        #endregion

    }
}