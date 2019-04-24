using System.Web.Mvc;

namespace RecruitingWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Necesidades");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public EmptyResult SideBarHidden()
        {
            if (HttpContext.Session["SideBarHidden"] == null)
            {
                HttpContext.Session.Add("SideBarHidden", true);
            }
            else
            {
                HttpContext.Session["SideBarHidden"] = true;
            }
            
            return null;
        }

        public EmptyResult SideBarDisplayed()
        {
            if (HttpContext.Session["SideBarHidden"] == null)
            {
                HttpContext.Session.Add("SideBarHidden", false);
            }
            else
            {
                HttpContext.Session["SideBarHidden"] = false;
            }
            return null;
        }
    }
}