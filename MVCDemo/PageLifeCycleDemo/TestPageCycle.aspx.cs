using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.SessionState;


namespace PageLifeCycleDemo
{
    public partial class TestPageCycle : System.Web.UI.Page, IPostBackEventHandler
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void RaisePostBackEvent(string eventArgument)
        {
            Response.Write("<b>This is the RaisePostBackEvent event </b><br/>");
        }

        protected override void LoadViewState(object savedState)
        {
            Response.Write("<b>This is the LoadViewState event.</b><br/>");
            base.LoadViewState(savedState);

            //The values are loaded from viewstate into controls.
            txtFName.Text = (string)ViewState["FName"];
        }
        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);
        }

    }
    
}