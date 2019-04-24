using System;
using System.Web;

namespace Recruiting.Application.Helpers
{
    public static class ModifiableEntityHelper
    {
        #region Constants
        
        #endregion

        public static int GetCurrentUser() {


            int usuarioId = Convert.ToInt32(HttpContext.Current.Session["UsuarioId"]);

            return usuarioId;
        }

        public static DateTime GetCurrentDate()
        {
            return DateTime.Now;
        }
    }
}
