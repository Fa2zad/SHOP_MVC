using SHOP_MVC.DataLayer;
using SHOP_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHOP_MVC.Services
{
    public class CategoriesServices
    {
        public List<Category> Get()
        {
            using (var db = new EntityContext())
            {
                var categories = db.Categories.ToList();
                return categories;
            }
        }

        public List<SimpleCategory> GetForDropdown()
        {
            using (var db = new EntityContext())
            {
                var categories = from item in db.Categories
                                 select new SimpleCategory()
                                 {
                                     ID = item.ID,
                                     Title = item.Title
                                 };
                return categories.ToList();
            }
        }
    }
}