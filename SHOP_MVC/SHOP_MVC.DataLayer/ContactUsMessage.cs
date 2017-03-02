using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHOP_MVC.DataLayer
{
    public class ContactUsMessage : EntityBase
    {
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Subject { get; set; }

        public string Message { get; set; }

        public Boolean IsRead { get; set; }


    }
}
