using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace PageLifeCycleDemo
{
    public partial class ContextObjDemo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int[] s = new int[] { 10, 20, 30 };

            for (var i= 0; i<s.Length;i++)
            {
                Console.WriteLine(i);
                Console.WriteLine("\t");
            }
          
            //HttpContext associated with the page can be accessed by the context property.
            StringBuilder sb = new StringBuilder();
            //use the current HttpContext objct to determine if custom errors are enabled.
            sb.Append("Is the custom errors enabled: " + Context.IsCustomErrorEnabled.ToString() + "<br/>");

            //Use the current HttpContext object to determine if the debugging is enabled.
            sb.Append("Is debugging enabled: " + Context.IsDebuggingEnabled.ToString() + "<br/>");
            //Use the current HttpContext object to access the current TraceContext object.
            sb.Append("Is Trace enabled: " + Context.Trace.IsEnabled.ToString() + "<br/>");

            //Use the HttpContext object to access the current HttpApplicationState object.
            sb.Append("Number of items in Application state: " + Context.Application.Count.ToString() + "<br/>");
            //Use the current HttpContext object to access the current HttpSessionState object.
            //Session state may not be configured.
            try
            {
                sb.Append("Number of items in session state: " + Context.Session.Count.ToString() + "<br/>");
            }
            catch
            {
                sb.Append("Session state not enabled.<br/>");
            }
            
            //Use the current HttpContext object to access the current cache object.
            sb.Append("Numbers of items in the cache: " + Context.Cache.Count.ToString() + "<br/>");
            //Use the current HttpContext object to determine the timestamp for the current Http Request.
            sb.Append("Timestamp for the Http Request: " + Context.Timestamp.ToString() + "<br/>");
            lblMsg.Text = sb.ToString();

        }
    }
}