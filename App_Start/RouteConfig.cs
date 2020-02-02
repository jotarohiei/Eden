using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Eden
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();


            /* Conventional way of mapping routes:
            
            routes.MapRoute(
                "MoviesByReleaseDate",
                "movies/released/{year}/{month}",
                new { controller = "Movies", action = "ByReleaseDate" });
                
                new { year = @"\d{4}", month = @"\d{2}" }, // this restricts the year and month to be of 4 and 2 digits respectively.
                new { year = @"2015|2016" month = @"\d{2}" } // this restricts the year to be only between 2015 or 2016 and the month to be of 2 digits.
                ); 
                */


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
