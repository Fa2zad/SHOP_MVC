using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SHOP_MVC.Controllers
{
    public class ContactUsController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            ViewBag.Title = "تماس با ما";

            return View();
        }
    }
}