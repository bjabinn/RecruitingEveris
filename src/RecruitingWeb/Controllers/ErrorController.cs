using System.Web.Mvc;

namespace RecruitingWeb.Controllers
{
    public class ErrorController : Controller
    {
        // GET: /Error/HttpError404
        public ActionResult HttpError404(string message)
        {
            return View("GenericError", message);
        }

        public ActionResult HttpError500(string message)
        {
            return View("GenericError", message);
        }

        public ActionResult General(string message)
        {
            return View("GenericError", message);
        }



    }
}