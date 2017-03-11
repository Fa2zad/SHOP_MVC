using SHOP_MVC.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SHOP_MVC.Models;

namespace SHOP_MVC.Services
{
    public class ProductImagesServices
    {
        public List<ProductImage> GetByProductID(int productID)
        {
            using (var db = new EntityContext())
            {
                var productImages = db.ProductsImages.Where(item => item.ProductID == productID).ToList();
                return productImages;
            }
        }

        public ProductImage GetByID(int id)
        {
            using (var db = new EntityContext())
            {
                var productImage = db.ProductsImages.Where(item => item.ID == id).Single();
                return productImage;
            }
        }

        public void UpdateImage(int id, string filename)
        {
            using (var db = new EntityContext())
            {
                var productImage = db.ProductsImages.Where(item => item.ID == id).Single();
                productImage.Image = filename;
                db.SaveChanges();
            }
        }

        public void Insert(ProductImage productImage)
        {
            using (var db = new EntityContext())
            {
                db.ProductsImages.Add(productImage);
                db.SaveChanges();
            }
        }

        public List<SimpleProductImage> GetSimpleImages(int productId)
        {
            using (var db = new EntityContext())
            {
                var query = from item in db.ProductsImages
                                   where (item.ProductID == productId)
                                   select new SimpleProductImage()
                                   {
                                       ID = item.ID,
                                       Image = item.Image
                                   };
                                   
                return query.ToList();
            }
        }
    }
}
