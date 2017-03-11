using AutoMapper;
using SHOP_MVC.DataLayer;
using SHOP_MVC.Models;
using SHOP_MVC.Services;
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
        private ProductsServices productsServices = new ProductsServices();
        private ProductImagesServices productsImagesServices = new ProductImagesServices();
        private CategoriesServices categoriesServices = new CategoriesServices();

        public ActionResult Index()
        {
            ViewBag.Title = "همه کالاها";

            List<Product> model = productsServices.Get();
            return View(model);
        }
        public ActionResult Edit(int? id)
        {
                ProductDTO productDTO = null;

                if (id.HasValue) //Edit
                {
                    ViewBag.Title = "ویرایش کالا";
                    var product = productsServices.GetByID(id.Value);
                    productDTO = Mapper.Map<ProductDTO>(product);
                    productDTO.ProductImages = Mapper.Map<List<SimpleProductImage>>(productsImagesServices.GetByProductID(id.Value));
                    //productDTO.ProductImages = product.ProductsImages;
                }
                else
                {
                    ViewBag.Title = "کالای جدید";

                    productDTO = new ProductDTO();
                }

                productDTO.Categories = categoriesServices.GetForDropdown();
               
                return View(productDTO);
        }

        [HttpPost]
        public ActionResult Edit(int? id, ProductDTO productDTO)
        {
                if (ModelState.IsValid)
                {
                    if (id.HasValue)
                    {
                        ViewBag.Title = "ویرایش کالا";

                        productsServices.Update(id.Value, productDTO);
                    }
                    else
                    {
                        ViewBag.Title = "کالای جدید";

                        var entity = Mapper.Map<Product>(productDTO);
                        productsServices.Insert(entity);
                        
                        id = entity.ID;
                    }
                    foreach (string fileuploadname in Request.Files)
                    {
                        var image = Request.Files[fileuploadname];
                        var imageid = int.Parse(fileuploadname.Remove(0, 6));
                        if (image.ContentLength != 0)
                        {
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
                            var productImage = productsImagesServices.GetByID(imageid);
                            System.IO.File.Delete(path + productImage.Image);
                            productsImagesServices.UpdateImage(imageid, filename);
                        }
                            else
                            {
                                var productImage = new ProductImage();
                                productImage.ProductID = id.Value;
                                productImage.Image = filename;
                                productsImagesServices.Insert(productImage);
                                
                            }
                            
                        }

                    }
                    ViewBag.IsSuccess = true;
                }

            productDTO.Categories = categoriesServices.GetForDropdown();
            productDTO.ProductImages = productsImagesServices.GetSimpleImages(id.Value);

            return View(productDTO);
        }

        public ActionResult Delete(int id)
        {
            using (var db = new EntityContext())
            {
                var productImages = productsImagesServices.GetByProductID(id);

                foreach (var item in productImages)
                {
                    System.IO.File.Delete(Server.MapPath("/images/Uploads/Products/") + item.Image);
                }
                productsServices.Delete(id);
                
            }
            return Redirect("/Dashboard/Products?success=true");
        }
    }
}