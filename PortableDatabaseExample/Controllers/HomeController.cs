using System.Web.Mvc;

namespace PortableDatabaseExample.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return RedirectToAction("Index", "Tasks");
        }
    }
}
