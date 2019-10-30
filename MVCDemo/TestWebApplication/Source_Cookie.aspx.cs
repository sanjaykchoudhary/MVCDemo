﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestWebApplication
{
    public partial class Source_Cookie : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Check if the browser supports cookies
                if (Request.Browser.Cookies)
                {
                    if (Request.QueryString["CheckCookie"] == null)
                    {
                        // Create the test cookie object
                        HttpCookie cookie = new HttpCookie("TestCookie", "1");
                        Response.Cookies.Add(cookie);
                        // Redirect to the same webform
                        Response.Redirect("Dest_Cookies.aspx?CheckCookie=1");
                    }
                    else
                    {
                        //Check the existence of the test cookie
                        HttpCookie cookie = Request.Cookies["TestCookie"];
                        if(cookie == null)
                        {
                            lblMessage.Text = "We have detected that, the cookies are disabled on your browser. Please enable cookies.";
                        }
                    }
                }
                else
                {
                    lblMessage.Text = "Browser doesn't support cookies. Please install one of the modern browser's that support cookies.";
                }
            }
        }

        protected void btnSendData_Click(object sender, EventArgs e)
        {
            //HttpCookie cookie = new HttpCookie("UserDetails");
            //cookie["Name"] = txtName.Text;
            //cookie["Email"] = txtEmail.Text;
            //cookie.Expires = DateTime.Now.AddDays(30);

            //Response.Cookies.Add(cookie);
            //Response.Redirect("~/Dest_Cookies.aspx");

            
        }
    }
}