using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestWebApplication
{
    public partial class Dest_PostBackUrl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Page previousePage = Page.PreviousPage;
            //if(previousePage !=null && previousePage.IsCrossPagePostBack)
            //{
            //    lblName.Text = ((TextBox)previousePage.FindControl("txtName")).Text;
            //    lblEmail.Text = ((TextBox)previousePage.FindControl("txtEmail")).Text;
            //}
            //else
            //{
            //    lblStatus.Text = "Landed on this page using a technique other than cross page post back";
            //}


            //Using Strongly type-previouspage property
            //Source_PostBackUrl previousPage = (Source_PostBackUrl)Page.PreviousPage;
            //if(previousPage !=null && previousPage.IsCrossPagePostBack)
            //{
            //    lblName.Text = previousPage.Name;
            //    lblEmail.Text = previousPage.Email;
            //}
            //else
            //{
            //    lblStatus.Text = "Landed on this page using a technique other than cross page post back";
            //}


            //UsingPreviousPageType property in Page - VirtualPath
            Source_PostBackUrl previousPage = (Source_PostBackUrl)Page.PreviousPage;
            if(previousPage != null && previousPage.IsCrossPagePostBack)
            {
                lblName.Text = previousPage.Name;
                lblEmail.Text = previousPage.Email;
            }
            else
            {
                lblStatus.Text = "Landed on this page using a technique other than cross page post back";
            }

        }
    }
}