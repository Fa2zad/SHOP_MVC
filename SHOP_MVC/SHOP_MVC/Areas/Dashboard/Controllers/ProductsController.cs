using AutoMapper;
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
            ViewBag.Title = "همه کالاها";

            using (var db = new EntityContext())
            {
                List<Product> model = db.Products.ToList();
                return View(model);
            }
        }
        public ActionResult Edit(int? id)
        {
            using (var db = new EntityContext())
            {
                ProductDTO productDTO = null;

                if (id.HasValue) //Edit
                {
                    ViewBag.Title = "ویرایش کالا";
                    var product = db.Products.Single(item => item.ID == id);
                    productDTO = Mapper.Map<ProductDTO>(product);
                    productDTO.ProductImages = Mapper.Map<List<SimpleProductImage>>(db.ProductsImages.Where(a => a.ProductID == id).ToList());
                    //productDTO.ProductImages = product.ProductsImages;
                }
                else
                {
                    ViewBag.Title = "کالای جدید";

                    productDTO = new ProductDTO();
                }

                productDTO.Categories = Mapper.Map<List<SimpleCategory>>(db.Categories.ToList());
               
                return View(productDTO);
            }
        }

        [HttpPost]
        public ActionResult Edit(int? id, ProductDTO productDTO)
        {
            using (var db = new EntityContext())
            {
                int pid = 0;

                if (ModelState.IsValid)
                {
                    if (id.HasValue)
                    {
                        ViewBag.Title = "ویرایش کالا";

                        var p = db.Products.Single(item => item.ID == id);
                        p.Title = productDTO.Title;
                        p.Count = productDTO.Count;
                        p.CategoryID = productDTO.CategoryID;
                        p.Description = productDTO.Description;
                        p.IsActive = productDTO.IsActive;
                        p.Price = productDTO.Price;
                        //all
                        //db.Products.Single(item => item.ID == id);
                        //var entity = Mapper.Map< Product>(productDTO);

                        pid = id.Value;
                        db.SaveChanges();
                    }
                    else
                    {
                        ViewBag.Title = "کالای جدید";

                        var entity = Mapper.Map<Product>(productDTO);
                        db.Products.Add(entity);
                        db.SaveChanges();
                        pid = entity.ID;
                    }
                    foreach (string fileuploadname in Request.Files)
                    {
                        var image = Request.Files[fileuploadname];
                        var imageid = int.Parse(fileuploadname.Remove(0, 6));
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

                            if (imageid > 0)
                            {
                                var productImage = db.ProductsImages.Where(a => a.ID == imageid).Single();
                                System.IO.File.Delete(path + productImage.Image);
                                productImage.Image = filename;
                            }
                            else
                            {
                                var productImage = new ProductImage();
                                productImage.ProductID = pid;
                                productImage.Image = filename;
                                db.ProductsImages.Add(productImage);
                            }
                            
                        }

                    }
                    db.SaveChanges();
                    ViewBag.IsSuccess = true;
                }

                productDTO.Categories = Mapper.Map<List<SimpleCategory>>(db.Categories.ToList());
                productDTO.ProductImages = Mapper.Map<List<SimpleProductImage>>(db.ProductsImages.Where(a => a.ProductID == id).ToList());

                return View(productDTO);
            }
        }

        public ActionResult Delete(int id)
        {
            using (var db = new EntityContext())
            {
                var pruduct = db.Products.Where(item => item.ID == id).Single();
                var productImages = db.ProductsImages.Where(item => item.ProductID == id).ToList();

                foreach (var item in productImages)
                {
                    System.IO.File.Delete(Server.MapPath("/images/Uploads/Products/") + item.Image);
                }

                db.Products.Remove(pruduct);
                db.SaveChanges();
            }
            return Redirect("/Dashboard/Products?success=true");
        }
    }
}