using Recruiting.Application.Roles.ViewModels;
using Recruiting.Application.Usuarios.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecruitingWeb.Security
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class RecruitingAuthorizeAttribute : AuthorizeAttribute
    {

        #region Construct

        public RecruitingAuthorizeAttribute()
        {
        }

        #endregion

        // Custom property
        public string AccessLevel { get; set; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var permisos = new List<PermisoRolViewModel>();

            if (httpContext.Session["Usuario"] != null)
            {
                var UsuarioRolPermisoViewModel = (UsuarioRolPermisoViewModel)httpContext.Session["Usuario"];
                if (UsuarioRolPermisoViewModel.UsuarioRol != null)
                {
                    foreach (var usuarioRol in UsuarioRolPermisoViewModel.UsuarioRol)
                    {
                        foreach (var permiso in usuarioRol.PermisoRol)
                        {
                            permisos.Add(permiso);
                        }
                    }

                }
                else
                {
                    return false;
                }
                
            }

            string privilegeLevels = string.Join("|", permisos.Select(x => x.PermisoNombre).ToArray());

            if (privilegeLevels.Contains(this.AccessLevel))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
