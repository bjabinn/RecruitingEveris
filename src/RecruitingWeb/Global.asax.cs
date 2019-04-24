using Recruiting.Application.Centros.Services;
using Recruiting.Application.Oficinas.Services;
using Recruiting.Application.PersonasLibres.Services;
using Recruiting.Application.Usuarios.Services;
using Recruiting.Business.Repositories;
using Recruiting.Data.EntityFramework.Repositories;
using RecruitingWeb.Security;
using System;
using System.Configuration;
using System.Globalization;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace RecruitingWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ModelBinders.Binders.Add(typeof(decimal), new DecimalModelBinder());
            ModelBinders.Binders.Add(typeof(decimal?), new DecimalModelBinder());


        }

        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            var authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                string enc = authCookie.Value;
                if (!String.IsNullOrEmpty(enc) && HttpContext.Current.Session != null && HttpContext.Current.Session["Usuario"] == null)
                {


                    int nMaximoSubEntrevistas = Convert.ToInt16(ConfigurationManager.AppSettings["numeroMaximoSubEntrevistas"].ToString());
                    HttpContext.Current.Session.Add("NumeroSubEntrevistas", nMaximoSubEntrevistas);

                    var user = FormsAuthentication.Decrypt(enc);
                    var id = new UserIdentity(user);

                    IUsuarioRepository _usuarioRepository = new UsuarioRepository();
                    IUsuarioService _usuarioService = new UsuarioService(_usuarioRepository);

                    var responseUsuario = _usuarioService.GetUsuarioRolPermisoByUserName(id.Name);

                    if (responseUsuario.IsValid)
                    {
                        HttpContext.Current.Session.Add("Usuario", responseUsuario.UsuarioRolPermisoViewModel);
                        HttpContext.Current.Session.Add("UsuarioId", responseUsuario.UsuarioRolPermisoViewModel.UsuarioId);
                        if (responseUsuario.UsuarioRolPermisoViewModel.CentroIdUsuario != null)
                        {
                            HttpContext.Current.Session.Add("CentroIdUsuario", responseUsuario.UsuarioRolPermisoViewModel.CentroIdUsuario);
                        }
                        IOficinaRepository _oficinaRepository = new OficinaRepository();
                        IOficinaService _oficinaService = new OficinaService(_oficinaRepository);
                        var centroId = responseUsuario.UsuarioRolPermisoViewModel.CentroIdUsuario != null ? (int)responseUsuario.UsuarioRolPermisoViewModel.CentroIdUsuario : 0;
                        var responseOficina = _oficinaService.GetOficinasByCentro(centroId);
                        HttpContext.Current.Session.Add("OficinaIdCentroUsuario", responseOficina.ListaOficinasIdNombre);
                    }

                    ICentroRepository _centroRepository = new CentroRepository();
                    ICentroService _centroService = new CentroService(_centroRepository);

                    var centrosResponse = _centroService.GetCentros();

                    if (centrosResponse.IsValid)
                    {
                        HttpContext.Current.Session.Add("ListaCentros", centrosResponse.ListaCentrosIdNombre);
                    }

                    IPersonaLibreRepository _personaLibreRepository = new PersonaLibreRepository();
                    IPersonasLibresService _personaLibreService = new PersonaLibreService(_personaLibreRepository);

                    var categoriaLineaCeldaResponse = _personaLibreService.GetListCategoriaLineaCelda();

                    if (categoriaLineaCeldaResponse.IsValid)
                    {
                        HttpContext.Current.Session.Add("CategoriaLineaCelda", categoriaLineaCeldaResponse.PersonasLibresListCategoriaLineaCeldaviewModel);
                    }

                }
            }
        }


        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();
            Response.Clear();

            HttpException httpException = exception as HttpException;

            if (httpException != null)
            {
                string action;

                switch (httpException.GetHttpCode())
                {
                    case 404:
                        // page not found
                        action = "HttpError404";
                        break;
                    case 500:
                        // server error
                        action = "HttpError500";
                        break;
                    default:
                        action = "General";
                        break;
                }

                // clear error on server
                Server.ClearError();

                Response.Redirect(String.Format("~/Error/{0}/", action));
            }

        }
    }
}
