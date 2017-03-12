using SHOP_MVC.DataLayer;
using SHOP_MVC.Services;
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
        private ContactUsMessagesServices contactUsMessagesServices = new ContactUsMessagesServices();

        public ActionResult Index()
        {
            ViewBag.Title = "پیام ها";

            List<ContactUsMessage> model = contactUsMessagesServices.Get();
            return View(model);
        }

        public ActionResult Read(int id)
        {
            ViewBag.Title = "پیام ها";

            contactUsMessagesServices.ReadByID(id);
            return Redirect("/Dashboard/ContactUsMessages");
        }

        public ActionResult UnRead(int id)
        {
            ViewBag.Title = "پیام ها";

            contactUsMessagesServices.UnReadByID(id);
            return Redirect("/Dashboard/ContactUsMessages");
        }

        public ActionResult Delete(int id)
        {
            ViewBag.Title = "پیام ها";

            contactUsMessagesServices.Delete(id);
            return Redirect("/Dashboard/ContactUsMessages");
        }
    }
}