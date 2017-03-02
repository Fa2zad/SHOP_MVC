using SHOP_MVC.DataLayer;
using SHOP_MVC.Models;
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
        [HttpGet]
        public ViewResult Index()
        {
            ViewBag.Title = "تماس با ما";

            return View();
        }

        [HttpPost]
        public ViewResult Index(ContactUsMessage contactus)
        {

            if (ModelState.IsValid)
            {
                var db = new EntityContext();
                db.ContactUsMessages.Add(contactus);
                db.SaveChanges();

                
            }

            return View();
        }
    }
}