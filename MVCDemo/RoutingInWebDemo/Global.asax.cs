using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Routing;

namespace RoutingInWebDemo
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            RouteTable.Routes.MapPageRoute("Default", "SalesReportSummary/{year}", "~/Sales.aspx");
            RouteTable.Routes.MapPageRoute("SalesRoute", "SalesReport/{country}/{year}", "~/Sales.aspx", true,
                new RouteValueDictionary   //Default values
                {
                    { "country","IND" },
                    {"year", DateTime.Now.Year.ToString() }
                },
                new RouteValueDictionary //Constraints
                {
                    {"country", "[a-z]{3}" },
                    {"year", @"/d{4}" }
                });
        }
    }
}