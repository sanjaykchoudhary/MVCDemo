using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Routing;

namespace RoutingInWebDemo
{
    public partial class Sales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Page.RouteData.Values["country"]==null)
            {
                ltrCountry.Text = "All Countries";
            }
            else
            {
                ltrCountry.Text = RouteData.Values["country"].ToString();
            }
            ltrYear.Text = RouteData.Values["year"].ToString();
        }
    }
}