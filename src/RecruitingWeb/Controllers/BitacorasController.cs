using Recruiting.Application.Bitacoras.Services;
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
    public class BitacorasController : Controller
    {
        #region Constants


        #endregion

        #region Fields
        private readonly IBitacoraService _bitacoraService;
        private readonly IMaestroRepository _maestroRepository;
        private readonly IBitacoraRepository _bitacoraRepository;
        private readonly ICandidaturaRepository _candidaturaRepository;
        private readonly ITipoDecisionRepository _tipoDecisionRepository;
        private readonly ITipoEtapaCandidaturaRepository _tipoEtapaCandidaturaRepository;
        private readonly ITipoEstadoCandidaturaRepository _tipoEstadoCandidaturaRepository;

        private readonly SessionCacheStorageService _sesionBitacoras;

        #endregion

        #region Construct

        public BitacorasController()
        {
            _maestroRepository = new MaestroRepository();
            _candidaturaRepository = new CandidaturaRepository();
            _bitacoraRepository = new BitacoraRepository();
            _tipoDecisionRepository = new TipoDecisionRepository();
            _tipoEtapaCandidaturaRepository = new TipoEtapaCandidaturaRepository();
            _tipoEstadoCandidaturaRepository = new TipoEstadoCandidaturaRepository();
            _bitacoraService = new BitacoraService(_bitacoraRepository, _candidaturaRepository,
                _tipoDecisionRepository, _tipoEtapaCandidaturaRepository, _tipoEstadoCandidaturaRepository, _maestroRepository);

            _sesionBitacoras = new SessionCacheStorageService();
        }

        #endregion

        #region Actions

        #region Index UI
        // GET: Bitacoras
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.VerBitacora)]
        public ActionResult Index(int CandidaturaId)
        {
            var filtro = _sesionBitacoras.Get<FiltroBitacoraModels>("filtro_bitacora");

            if (filtro == null)
            {
                //orden por defecto
                filtro = new FiltroBitacoraModels()
                {
                    SortColumn = "BitacoraId",
                    SortOrder = Recruiting.Business.BaseClasses.DataTable.DataTableSortDirectionEnum.Descending
                };
            }
             _sesionBitacoras.Add("filtro_inicial_bitacora", filtro);
          
            PermisosMostrar();
            
            _sesionBitacoras.Add("CandidaturaId", CandidaturaId);

            filtro = GenerateViewElementsIndex(filtro);

            return View(filtro);
        }

        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.VerBitacora)]
        public virtual JsonResult LoadBitacoras([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
        {
            PermisosMostrar();

            var request = requestModel.ConvertToDataTableRequestViewModel();

            request.CustomFilters.Add("CandidaturaId", _sesionBitacoras.Get<int>("CandidaturaId").ToString());
            
            //recupero el filtro por defecto si hay
            var filtro = _sesionBitacoras.Get<FiltroBitacoraModels>("filtro_inicial_bitacora");
            if (filtro != null && filtro.SortColumn != string.Empty) {
                var Iterador = request.Columns.GetEnumerator();
                while (Iterador.MoveNext())
                {
                    if (Iterador.Current.Name == filtro.SortColumn)
                    {
                        Iterador.Current.SortDirection = filtro.SortOrder;
                    }
                    else {
                        Iterador.Current.SortDirection = null;
                    }

                }
              _sesionBitacoras.Remove("filtro_inicial_bitacora");
            }

            var response = _bitacoraService.GetBitacorasByCandidaturaId(request);
            var filtroBitacoraModel = MappertoFiltroBitacoras(request.CustomFilters);

           // guardar el orden seleccionado por el usuario
            if (filtro != null)
            {
                filtroBitacoraModel.SortOrder = filtro.SortOrder;
                filtroBitacoraModel.SortColumn = filtro.SortColumn;
            }
            else {
                filtroBitacoraModel.SortOrder = request.Columns.FirstOrDefault(i => i.SortDirection != null).SortDirection.Value;
                filtroBitacoraModel.SortColumn = request.Columns.FirstOrDefault(i => i.SortDirection != null).Name;
            }


            _sesionBitacoras.Add("filtro_bitacora", filtroBitacoraModel);
            _sesionBitacoras.Add("pagina_actual", request.PageNumber);



            if (!response.IsValid)
            {
                return null;
            }

            var result = from c in response.BitacoraViewModel
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
        public ActionResult Create(int? CandidaturaId, string MensajeSistema)
        {
            CandidaturaId = Convert.ToInt32(_sesionBitacoras.Get<int>("CandidaturaId").ToString());

            var response = _bitacoraService.GenerateBitacoraManual(CandidaturaId ?? 0, MensajeSistema);

            if (!response.IsValid)
            {
                CreateMessageError(response.ErrorMessage);
            }
            else
            {
                CreateMessageNotify("Bitacora guardada correctamente");
            }
           
            var filtro = _sesionBitacoras.Get<FiltroBitacoraModels>("filtro_bitacora");
            if (filtro == null)
            {
                filtro = new FiltroBitacoraModels();
            }
            return RedirectToAction("Index", filtro);
        }






        public ActionResult IndexError()
        {
            TempData["ErrorPermiso"] = true;            
            var filtro = _sesionBitacoras.Get<FiltroBitacoraModels>("filtro_bitacora");

            if (filtro == null)
            {
                filtro = new FiltroBitacoraModels();
            }
            return View("Index", filtro);
        }

        //Esta acción nos permite volver desde otra página con el filtro
        public ActionResult Volver()
        {
            _sesionBitacoras.Remove("pagina_actual");
            _sesionBitacoras.Remove("CandidaturaId");
            _sesionBitacoras.Remove("filtro_inicial_bitacora");
            _sesionBitacoras.Remove("filtro_bitacora");
            return RedirectToAction( "Index", "Candidaturas");
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

        private FiltroBitacoraModels GenerateViewElementsIndex(FiltroBitacoraModels model)
        {
            int CandidaturaId = Convert.ToInt32(_sesionBitacoras.Get<int>("CandidaturaId").ToString());
            model.CentroIdUsuarioLogueado = HttpContext.Session["CentroIdUsuario"] != null ? HttpContext.Session["CentroIdUsuario"].ToString() : string.Empty;


            var candidatura = _candidaturaRepository.GetByCriteria(x => x.CandidaturaId == CandidaturaId).FirstOrDefault();

            if (candidatura != null)
            {
                model.CandidaturaId = candidatura.CandidaturaId;
                model.EstadoCandidatura = candidatura.EstadoCandidatura != null ? candidatura.EstadoCandidatura.EstadoCandidatura : string.Empty;
                model.EtapaCandidatura = candidatura.EtapaCandidatura != null ? candidatura.EtapaCandidatura.EtapaCandidatura : string.Empty;
                model.Perfil = candidatura.Categoria != null ? candidatura.Categoria.Nombre : string.Empty;
                model.Entrevistador = candidatura.Entrevistas.Count > 0 ? candidatura.Entrevistas.FirstOrDefault().Entrevistador.Nombre : string.Empty;
                model.NombreCandidato = string.Concat(candidatura.Candidato.Nombre, " ", candidatura.Candidato.Apellidos);
                model.TipoTecnologia = candidatura.TipoTecnologia != null ? candidatura.TipoTecnologia.Nombre : string.Empty;
                model.CentroUsuarioCreacion = candidatura.Usuario.Centro == null ? string.Empty : candidatura.Usuario.Centro.Nombre;
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

        private FiltroBitacoraModels MappertoFiltroBitacoras(IDictionary<string, string> filtro)
        {
            var FiltroBitacoraModels = new FiltroBitacoraModels();

            if (filtro.Count != 0)
            {
                string value;

                if (filtro.ContainsKey("BitacoraId"))
                {
                    value = filtro["BitacoraId"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        FiltroBitacoraModels.BitacoraId = Convert.ToInt32(value);
                    }
                }

                if (filtro.ContainsKey("CandidaturaId"))
                {
                    value = filtro["CandidaturaId"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        FiltroBitacoraModels.CandidaturaId = Convert.ToInt32(value);
                    }
                }

                if (filtro.ContainsKey("TipoCambio"))
                {
                    value = filtro["TipoCambio"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        FiltroBitacoraModels.TipoCambio = value;
                    }
                }

                if (filtro.ContainsKey("MensajeSistema"))
                {
                    value = filtro["MensajeSistema"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        FiltroBitacoraModels.MensajeSistema = value;
                    }
                }

                if (filtro.ContainsKey("Usuario"))
                {
                    value = filtro["Usuario"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        FiltroBitacoraModels.UsuarioCreacionId = Convert.ToInt32(value);
                    }
                }

                if (filtro.ContainsKey("FechaCreacion"))
                {
                    value = filtro["FechaCreacion"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        FiltroBitacoraModels.FechaCreacion = Convert.ToDateTime(value);
                    }
                }




                if (filtro.ContainsKey("CentroUsuarioId"))
                {
                    value = filtro["CentroUsuarioId"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        FiltroBitacoraModels.CentroIdUsuario = Convert.ToInt32(value);
                    }
                }

                if (filtro.ContainsKey("CentroSearch"))
                {
                    value = filtro["CentroSearch"];
                    if (!string.IsNullOrEmpty(value))
                    {
                        FiltroBitacoraModels.CentroIdUsuario = Convert.ToInt32(value);
                    }
                }
            }

            return FiltroBitacoraModels;
        }



        #endregion

    }
}