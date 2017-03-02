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
            ViewBag.Title = "همه محصولات";
            return View();
        }
        public ActionResult Add()
        {
            ViewBag.Title = "افزودن محصول";

            return View();
        }

        [HttpPost]
        public ActionResult Add(Product product)
        {
            if (ModelState.IsValid)
            {
                var db = new EntityContext();
                db.Products.Add(product);
                db.SaveChanges();

                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var image = Request.Files["Image_" + i];
                    //var extention = image.ContentType;
                    var path = Server.MapPath("~/images/Uploads/Products/");
                    var filename = "";
                    if (System.IO.File.Exists(path + image.FileName))
                    {

                        filename = image.FileName + DateTime.UtcNow.Ticks + ".jpg";
                        image.SaveAs(path + filename);
                    }
                    else
                    {
                        filename = image.FileName;
                        image.SaveAs(path + filename);
                    }

                    var productImage = new ProductImage();
                    productImage.ProductID = product.ID;
                    productImage.Image = filename;
                    db.ProductsImages.Add(productImage);
                }
                db.SaveChanges();
            }
            return View();

        }
    }
}