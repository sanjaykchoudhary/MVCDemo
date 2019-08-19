using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace TestWebApplication
{
    public partial class ExceptionDemo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(Server.MapPath("~/File/Countries1.xml"));
            gvCountries.DataSource = ds;
            gvCountries.DataBind();
        }

        //protected void Page_Error(object sender, EventArgs e)
        //{
        //    // Get the exception details and log it in the database or event viewer
        //    Exception ex = Server.GetLastError();
        //    //Clear the exception.
        //    Server.ClearError();
        //    //Redirect User to Error page.
        //    Response.Redirect("Errors.aspx"); 
        //}
    }
}