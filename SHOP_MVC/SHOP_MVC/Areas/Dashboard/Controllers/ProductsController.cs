using SHOP_MVC.DataLayer;
using SHOP_MVC.Models;
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

            using (var db = new EntityContext())
            {
                List<Product> model = db.Products.ToList();
                return View(model);
            }
        }
        public ActionResult Add()
        {
            ViewBag.Title = "افزودن محصول";

            var model = new AddProductSettings();
            using (var db = new EntityContext())
            {
                model.Categories = (from item in db.Categories
                                    select new SimpleCategory
                                    {
                                        ID = item.ID,
                                        Title = item.Title
                                    }).ToList();
            }

            return View(model);
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
                    if (image.ContentLength != 0)
                    {
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
                    
                }
                db.SaveChanges();
            }

            var model = new AddProductSettings();
            using (var db = new EntityContext())
            {
                model.Categories = (from item in db.Categories
                                    select new SimpleCategory
                                    {
                                        ID = item.ID,
                                        Title = item.Title
                                    }).ToList();
            }
            return View(model);

        }
    }
}