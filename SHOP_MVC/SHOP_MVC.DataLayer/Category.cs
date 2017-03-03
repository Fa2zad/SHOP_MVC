using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHOP_MVC.DataLayer
{
    public class Category : EntityBase
    {
        public int? ParentID { get; set; }
        [ForeignKey("ParentID")]
        public Category ParentCategory { get; set; }
        public string Title { get; set; }
        public Boolean IsActive { get; set; }

    }
}
