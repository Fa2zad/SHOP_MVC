using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHOP_MVC.DataLayer
{
    public class Product : EntityBase
    {
        public int CategoryID { get; set; }
        [ForeignKey("CategoryID")]
        public Category Category { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public int Count { get; set; }

        public Boolean IsActive { get; set; }
    }
}
