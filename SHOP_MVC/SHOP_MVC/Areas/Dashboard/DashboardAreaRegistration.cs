using System.Web.Mvc;

namespace SHOP_MVC.Areas.Dashboard
{
    public class DashboardAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Dashboard";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {

            context.MapRoute(
                "Dashboard_default",
                "Dashboard/{controller}/{action}/{id}",
                new { controller = "Default", action = "Index", id = UrlParameter.Optional }
            );

            //context.MapRoute(
            //    "Dashboard_products",
            //    "Dashboard/Products/{action}/{id}",
            //    new { action = "Index", id = UrlParameter.Optional },
            //    new { controller = "Products" }
            //);
            //context.MapRoute(
            //    "Dashboard_default",
            //    "Dashboard/{controller}/{action}/{id}",
            //    new { controller = "Default", action = "Index", id = UrlParameter.Optional },
            //    new { controller = "Default|Products" },
            //    new[] { "SHOP_MVC.Areas.Dashboard.Controllers" }
            //);

            //context.MapRoute(
            //    name: "Dashboard_default",
            //    url: "Dashboard/{controller}/{action}/{id}",
            //    defaults: new { controller = "Default", action = "Index", id = UrlParameter.Optional }
            //);

            //context.MapRoute(
            //"Admin_default",
            //"Admin/{controller}/{action}/{id}",
            //new { action = "Index", id = UrlParameter.Optional },
            //new { controller = "Branch|AdminHome|User" },
            //new[] { "MyApp.Areas.Admin.Controllers" }
            //);

        }
    }
}