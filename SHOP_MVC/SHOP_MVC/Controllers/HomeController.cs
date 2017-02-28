using SHOP_MVC.DataLayer;
using SHOP_MVC.Models;
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
            var model = new HomeSettings();
            using (var db = new EntityContext())
            {
                model.ProductImages = (from item in db.ProductsImages
                                      select new SimpleProductImage
                                      {
                                          ID = item.ID,
                                          Image = item.Image,
                                          ProductID = item.ProductID
                                      }).ToList();

                model.Products = (from item in db.Products
                                       select new SimpleProduct
                                       {
                                           ID = item.ID,
                                           Title = item.Title,
                                           Price = item.Price,
                                           RegisterDate = item.RegisterDate,
                                           IsActive = item.IsActive
                                       }).ToList();
            }
                //var products = db.Products.ToList();
                
            ViewBag.Title = "فروشگاه اینترنتی";
            return View(model);
        }
    }
}