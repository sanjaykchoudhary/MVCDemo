using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace CustomHttpHandler.App_Start
{
    public class CustomHandler : IHttpHandler
    {
        public RequestContext RequestContext { get; set; }
        public CustomHandler( RequestContext context)
        {
            RequestContext = context;
        }
        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.Write("Hello Custom Handler");
        }
    }
}