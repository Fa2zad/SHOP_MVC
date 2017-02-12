using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SHOP_MVC.Models;

namespace SHOP_MVC.Controllers
{
    public class AboutUsController : Controller
    {
        // GET: About
        public ActionResult Index()
        {
            ViewBag.Title = "درباره ما";

            var model = new PageSettings();
            model.Title = "درباره ما";
            model.Text = "توسعه اینترنت روش‌های خرید ما را به کلی دگرگون کرده است. منافع موجود در خرید اینترنتی هر روز تعداد بیشتری از مردم را به تجربه آن و ایجاد تغییر در الگوهای متداول خرید ترغیب می‏‌کند. امروز دیگر افراد این روش خرید را بیشتر منطبق بر شرایط زندگی مدرن می‏‏‏‌بینند. ویژگی‏‏‏‌ها و طبیعت خرید اینترنتی با روحیات و نیازهای رو به رشد ما هماهنگ‏‏‌تر شده است. همه سخت در حال تلاش برای پیشرفت‏‏‌های شخصی و جمعی خود هستیم.";

            return View(model: model);
        }
    }
}