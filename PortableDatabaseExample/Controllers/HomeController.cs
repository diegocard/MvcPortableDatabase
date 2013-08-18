using PortableDatabaseExample.Models;
using System;
using System.Web.Mvc;

namespace PortableDatabaseExample.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            try
            {
                SQLiteTestModel testCE = new SQLiteTestModel();
                Purchase purchase = new Purchase()
                {
                    Date = DateTime.Now,
                    ID = 1,
                    Price = 100,
                    ProductName = "test",
                };
                testCE.Purchases.Add(purchase);
                testCE.SaveChanges();
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }
            return View();
        }

    }
}
