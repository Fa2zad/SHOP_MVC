using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHOP_MVC.Models
{
    public class ContactUsModel
    {
        [Required(ErrorMessage = "لطفا نام خود را وارد نمایید.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "لطفا ایمیل خود را وارد نمایید.")]
        [EmailAddress(ErrorMessage = "لطفا ایمیل صحیح وارد نمایید.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "لطفا موضوع را وارد نمایید.")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "لطفا پیام خود را وارد نمایید.")]
        public string Message { get; set; }
    }
}
