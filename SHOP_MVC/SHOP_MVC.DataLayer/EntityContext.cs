using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHOP_MVC.DataLayer
{
    public class EntityContext : DbContext
    {
        public EntityContext() : base(System.Configuration.ConfigurationManager.ConnectionStrings["EntityConnectionString"].ConnectionString)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductsImages { get; set; }


    }
}
