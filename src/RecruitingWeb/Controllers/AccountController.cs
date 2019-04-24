using Recruiting.Application.Centros.Enums;
using Recruiting.Application.Usuarios.Services;
using Recruiting.Business.Repositories;
using Recruiting.Data.EntityFramework.Repositories;
using RecruitingWeb.Components.HttpClient;
using RecruitingWeb.Enums;
using RecruitingWeb.Models;
using System;
using System.Net.Http;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Security;

namespace RecruitingWeb.Controllers
{
    public class AccountController : Controller
    {
        #region Constants

        #endregion

        #region Fields

        private readonly IUsuarioService _usuarioService;
        private readonly IUsuarioRepository _usuarioRepository;

        #endregion

        #region Construct

        public AccountController()
        {
            _usuarioRepository = new UsuarioRepository();
            _usuarioService = new UsuarioService(_usuarioRepository);
        }

        #endregion

        #region Actions

        public ActionResult Login()
        {

            ViewResult ret;

            var authCookie = HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName];

            if (authCookie != null)
            {
                var url = Request.UrlReferrer;
                if (url != null)
                {
                    TempData["ErrorPermiso"] = true;
                    return Redirect(Request.UrlReferrer.PathAndQuery);
                }
                else
                {
                    ret = View(new LoginViewModel());
                }

            }
            else
            {
                ret = View(new LoginViewModel());
            }

            return ret;
        }


        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }


            // Check if user exist in recruiting app
            var response = _usuarioService.GetUsuarioByUserName(model.UserName);

            if (!response.IsValid)
            {
                return null;
            }
            //establecer condicion
            if (response.UsuarioViewModel != null)
            {
                //Primero probamos nuestro servicio REST de login
                EverisUserValidatorModel user = new EverisUserValidatorModel()
                {
                    UserName = model.UserName,
                    Password = model.Password
                };

                if (EverisValidateUser(user))//Esta es nuestra llamada al REST.
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);

                    if (Url.IsLocalUrl(returnUrl) &&
                        returnUrl.Length > 1 &&
                        returnUrl.StartsWith("/") &&
                        !returnUrl.StartsWith("//") &&
                        !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }

                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    var modelLogin = new LoginViewModel();
                    modelLogin.errorLogin = true;
                    return View(modelLogin);
                }
            }

            this.ModelState.AddModelError(string.Empty, "The user name or password provided is incorrect.");

            return this.View(model);
        }


        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            HttpContext.Session.Clear();

            return this.RedirectToAction("Login");
        }
        #endregion

        #region Private Methods

        private bool EverisValidateUser(EverisUserValidatorModel user)
        {
            HttpResponseMessage response;
            try
            {
                string ruta = WebConfigurationManager.AppSettings["rutaEverisValidateUser"];//La ruta del servicio esta definida en la configuración.
                response = HttpClientGlobal.client.PostAsJsonAsync(ruta, user).GetAwaiter().GetResult();//Con GetAwaiter podemos realizar nuestra llamada de forma sínscrona.
                response.EnsureSuccessStatusCode();
                bool result = Convert.ToBoolean(response.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        #endregion
    }
}
