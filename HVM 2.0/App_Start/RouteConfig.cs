using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HVM_2._0
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" }
                 //defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Patient",
                url: "{controller}/{action}/{crnPris}",
                defaults: new { controller = "Patients", action = "Index", crnPris = UrlParameter.Optional }
            );

           routes.MapRoute(
               name: "Visiteur2",
               url: "{controller}/{action}/{tempCreneau}",
               defaults: new { controller = "Visiteurs", action = "Index", tempCreneau = UrlParameter.Optional }
           );

            /*
            routes.MapRoute(
                name: "Patient2",
                url: "{controller}/{action}/{crnPris}",
                defaults: new { controller = "Patients", action = "Index", crnPris = UrlParameter.Optional }
            ); */
        }
    }
}
