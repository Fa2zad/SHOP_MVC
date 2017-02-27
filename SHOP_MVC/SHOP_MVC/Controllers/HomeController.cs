using SHOP_MVC.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SHOP_MVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var db = new EntityContext();
            var list = db.Products.ToList();

            ViewBag.Title = "فروشگاه اینترنتی";

            return View();
        }
    }
}