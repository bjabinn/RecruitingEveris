using Recruiting.Application.Dashboard.Services;
using Recruiting.Application.Dashboard.ViewModels;
using Recruiting.Application.Necesidades.Services;
using Recruiting.Application.Roles.ViewModels;
using Recruiting.Application.Usuarios.ViewModels;
using Recruiting.Business.BaseClasses.DataTable;
using Recruiting.Business.Repositories;
using Recruiting.Data.EntityFramework.Repositories;
using RecruitingWeb.Components.DataTable.ServerSide;
using RecruitingWeb.Constantes;
using RecruitingWeb.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI;

namespace RecruitingWeb.Controllers
{
    public class DashboardController : Controller
    {
        #region Fields

        private readonly IDashboardService _dashboardService;
        private readonly INecesidadService _necesidadService;
        private readonly INecesidadRepository _necesidadRepository;

        #endregion

        #region Construct

        public DashboardController()
        {           
            _necesidadRepository = new NecesidadRepository();
            _necesidadService = new NecesidadService(_necesidadRepository);

            _dashboardService = new DashboardService(new BecarioRepository(), new EntrevistaRepository(), new CandidaturaRepository(), new CartaOfertaRepository(), new RelacionEtapaRepository(), new RelacionVistaEtapaRepository(), new NecesidadRepository(), new SubEntrevistaRepository());
        }
        
        #endregion
        // GET: Dashboard
        public ActionResult Index()
        {
            if (HttpContext.Session["Usuario"] != null)
            {
                var UsuarioRolPermisoViewModel = (UsuarioRolPermisoViewModel)HttpContext.Session["Usuario"];
                var RolsId = PerlfilesMostrar(UsuarioRolPermisoViewModel);             
                
                var response = _dashboardService.GetDashboard(RolsId, UsuarioRolPermisoViewModel.UserName, UsuarioRolPermisoViewModel.CentroIdUsuario, UsuarioRolPermisoViewModel.UsuarioId);

                response.DashboardViewModel.UsuarioIdLogueado = UsuarioRolPermisoViewModel.UsuarioId;
                response.DashboardViewModel.RolsId = RolsId;
                

                if (response.DashboardViewModel.InfoAdministradorViewModel != null)
                {
                    response.DashboardViewModel.InfoAdministradorViewModel.CentroIdUsuarioLogueado = HttpContext.Session["CentroIdUsuario"] != null ? HttpContext.Session["CentroIdUsuario"].ToString() : string.Empty;
                    response.DashboardViewModel.InfoAdministradorViewModel.AlertasAdministradorViewModel.UsuarioId = UsuarioRolPermisoViewModel.UsuarioId;
                }         

                return View(response.DashboardViewModel);
            }
            else {

                var response = new DashboardViewModel
                {
                    InfoAdministradorViewModel = new InfoAdministradorViewModel(),
                    InfoEntrevistadorViewModel = new InfoEntrevistadorViewModel()
                };

                return View(response);
            }
        }//Index

        private List<int> PerlfilesMostrar(UsuarioRolPermisoViewModel user)
        {
            List<int> listRoles = new List<int>();
        
            foreach (var usuarioRol in user.UsuarioRol)
            {
               listRoles.Add(usuarioRol.RolId);
            }
            return listRoles;
        }

        [ValidateInput(false)]
        public virtual JsonResult LoadAlertaNecesidades([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
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

            var response = _necesidadService.GetNecesidades(request);            
            
           
            if (!response.IsValid)
            {
                return null;
            }


            var result = from c in response.NecesidadViewModel
                         select new object[]
            {
                string.Format("<a href=\"/Necesidades/Details/{0}\">{0}</a>", c.NecesidadId.ToString()),
                c.Proyecto,
                c.Cliente,
                c.Tecnologia,
                FormatHelper.Format(c.FechaCreacion, "dd/MM/yyyy"),
                (FormatHelper.Format(c.FechaModificacion, "dd/MM/yyyy") == "01/01/0001") ? "-----------" : FormatHelper.Format(c.FechaModificacion, "dd/MM/yyyy"),
                FormatHelper.Format(c.FechaSolicitud, "dd/MM/yyyy"),
                FormatHelper.Format(c.FechaCompromiso, "dd/MM/yyyy"),
                c.Centro
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

        public ActionResult SaveAlertasAdmin(AlertasAdministradorViewModel alertasAdminViewModel)
        {
            var response = _dashboardService.SaveAlertasAdmin(alertasAdminViewModel);

            if (response.IsValid)
            {
                return Redirect("Index");

            }
            else
            {
                return Redirect("error");
            }
        }

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

        #region ExportToExcel
        public void ExportToExcel(string filterEstado, string filterPrevision, string filterFechaModificacion)
        {
            IDictionary<string, string> CustomFilters = new Dictionary<string, string> {
                    
                    { "Estado", filterEstado },
                    { "Prevision", filterPrevision },
                    { "FechaModificacion", filterFechaModificacion }
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

            var request = new DataTableRequest
            {
                CustomFilters = CustomFilters
            };
            var response = _necesidadService.GetNecesidadesExportToExcel(request);



            var grid = new System.Web.UI.WebControls.GridView
            {
                DataSource = response.NecesidadExportToExcellViewModel
            };
            grid.DataBind();
            Response.ClearContent();
            string filename = string.Format("Listado_de_Necesidades_Creadas_{0}", DateTime.Now.ToShortDateString() + ".xls");
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", filename));
            Response.ContentType = "application/excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);

            grid.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();
        }
        #endregion
      

    }
}