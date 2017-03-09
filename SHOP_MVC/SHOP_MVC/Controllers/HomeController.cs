using AutoMapper;
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
            using (var db = new EntityContext())
            {
                var products = db.Products.Where(p => p.IsActive == true).OrderByDescending(p => p.RegisterDate).Take(10).ToList();
                var homeDTO = new HomeDTO();
                homeDTO.Products = Mapper.Map<List<SimpleProduct>>(products);
                foreach (var item in homeDTO.Products)
                {
                    item.Image = db.ProductsImages.Where(image => image.ProductID == item.ID).FirstOrDefault()?.Image ?? @"product_default.jpg";
                }

                ViewBag.Title = "فروشگاه اینترنتی";
                return View(homeDTO);
            }
        }
    }
}