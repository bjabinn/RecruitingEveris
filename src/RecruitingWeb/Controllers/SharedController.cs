using System.Web.Mvc;

namespace RecruitingWeb.Controllers
{
    public class SharedController : Controller
    {
        [ValidateInput(false)]      
        public ActionResult Borrado()
        {           
            return View();
        }


        [ValidateInput(false)]
        public ActionResult GenericsError()
        {
            return View();
        }
    }
}