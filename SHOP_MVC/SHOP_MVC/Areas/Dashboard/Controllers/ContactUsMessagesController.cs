using SHOP_MVC.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SHOP_MVC.Areas.Dashboard.Controllers
{
    public class ContactUsMessagesController : Controller
    {
        // GET: Dashboard/ContactUsMessages
        public ActionResult Index()
        {
            ViewBag.Title = "پیام ها";

            using (var db = new EntityContext())
            {
                List<ContactUsMessage> model = db.ContactUsMessages.ToList();
                return View(model);
            }
        }
    }
}