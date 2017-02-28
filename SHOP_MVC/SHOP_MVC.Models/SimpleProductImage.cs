using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHOP_MVC.Models
{
    public class SimpleProductImage
    {
        public int ID { get; set; }
        public string Image { get; set; }
        public int ProductID { get; set; }
    }
}
