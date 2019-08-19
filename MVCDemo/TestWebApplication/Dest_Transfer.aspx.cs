using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;

namespace TestWebApplication
{
    public partial class Dest_Transfer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NameValueCollection previousFormCollection = Request.Form;
            lblName.Text = previousFormCollection["txtName"];
            lblEmail.Text = previousFormCollection["txtEmail"];
        }
    }
}