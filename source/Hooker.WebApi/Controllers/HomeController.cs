using System.Web.Mvc;

namespace Hooker.WebApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Hooker - Debug and/or process webhooks";

            return View();
        }
    }
}
