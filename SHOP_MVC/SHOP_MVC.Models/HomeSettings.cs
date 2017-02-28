using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHOP_MVC.Models
{
    public class HomeSettings
    {
        public List<SimpleProduct> Products { get; set; }

        public List<SimpleProductImage> ProductImages { get; set; }
    }
}
