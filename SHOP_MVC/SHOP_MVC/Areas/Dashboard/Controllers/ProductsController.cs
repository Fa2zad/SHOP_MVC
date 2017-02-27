using SHOP_MVC.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SHOP_MVC.Areas.Dashboard.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Dashboard/Products

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Product product)
        {
            if (ModelState.IsValid)
            {
                var image = Request.Files["Image"];
                //var extention = image.ContentType;
                var path = Server.MapPath("~/images/Uploads/Products/");
                var filename = "";
                if (System.IO.File.Exists(path + image.FileName))
                {
                    
                    filename = DateTime.UtcNow.Ticks + ".jpg";
                    image.SaveAs(path + filename);
                }
                else
                {
                    filename = image.FileName;
                    image.SaveAs(path + filename);
                }

                product.Image = filename;

                var db = new EntityContext();
                db.Products.Add(product);
                db.SaveChanges(); 
            }
            return View();

        }
    }
}