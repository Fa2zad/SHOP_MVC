using System.Web.Mvc;

namespace SHOP_MVC.Areas.Default
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
                new {controller= "Default", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}