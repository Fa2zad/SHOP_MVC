using SHOP_MVC.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SHOP_MVC.Models;

namespace SHOP_MVC.Services
{
    public class ProductsServices
    {
        public List<Product> Get()
        {
            using (var db = new EntityContext())
            {
                var productsList = db.Products.ToList();
                return productsList;
            }
        }

        public Product GetByID(int id)
        {
            using (var db = new EntityContext())
            {
                var product = db.Products.Single(item => item.ID == id);
                return product;
            }
        }

        public void Update(int id, ProductDTO productDTO)
        {
            using (var db = new EntityContext())
            {
                var p = db.Products.Single(item => item.ID == id);
                p.Title = productDTO.Title;
                p.Count = productDTO.Count;
                p.CategoryID = productDTO.CategoryID;
                p.Description = productDTO.Description;
                p.IsActive = productDTO.IsActive;
                p.Price = productDTO.Price;
                db.SaveChanges();
            }
        }

        public ProductDTO GetProductDTOByID(int id)
        {
            using (var db = new EntityContext())
            {
                var productsList = from item in db.Products
                                   where item.ID == id
                                   select new ProductDTO()
                                   {
                                       CategoryID = item.CategoryID,
                                       Count = item.Count,
                                       Description = item.Description,
                                       IsActive = item.IsActive,
                                       Price = item.Price,
                                       Title = item.Title,

                                       ProductImages = (from item2 in db.ProductsImages
                                                        where item2.ProductID == id
                                                        select new SimpleProductImage()
                                                        {
                                                            ID = item2.ID,
                                                            Image = item2.Image,
                                                            ProductID = item2.ProductID
                                                        }).ToList(),
                                       Categories = (from item3 in db.Categories
                                                    select new SimpleCategory()
                                                    {
                                                        ID = item3.ID,
                                                        Title = item3.Title
                                                    }).ToList()
                                   };
                return productsList.Single();
            }
        }

        public void Insert(Product product)
        {
            using (var db = new EntityContext())
            {
                db.Products.Add(product);
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var db = new EntityContext())
            {
                var pruduct = db.Products.Single(item => item.ID == id);
                db.Products.Remove(pruduct);
                db.SaveChanges();
            }
        }
    }
}
