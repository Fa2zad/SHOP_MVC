using AutoMapper;
using SHOP_MVC.DataLayer;
using SHOP_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SHOP_MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            Mapper.Initialize(config => 
            {
                config.CreateMap<Product, ProductDTO>();
                config.CreateMap<ProductDTO, Product>();

                config.CreateMap<Category, SimpleCategory>();
                config.CreateMap<SimpleCategory, Category>();

                config.CreateMap<ProductImage, SimpleProductImage>();
                config.CreateMap<SimpleProductImage, ProductImage>();
            });
        }
    }
}
