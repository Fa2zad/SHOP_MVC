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
        //[Display(Name = "عنوان")]
        //[Required]
        //[StringLength(50)]
        public string Title { get; set; }

        //[Display(Name = "توضیحات")]
        public string Description { get; set; }

        //[Display(Name = "قیمت")]
        //[Required]
        public int Price { get; set; }

        //[Display(Name = "تعداد")]
        //[Required]
        public int Count { get; set; }

        //[Display(Name = "فعال")]
        public Boolean IsActive { get; set; }

        public DateTime RegisterDate { get; set; }
    }
}
