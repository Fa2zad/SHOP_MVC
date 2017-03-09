using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHOP_MVC.Models
{
    public class SimpleProduct
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string Image { get; set; }

        //public string Description { get; set; }

        public int Price { get; set; }

        public int Count { get; set; }

        //public Boolean IsActive { get; set; }

        //public DateTime RegisterDate { get; set; }
    }
}
