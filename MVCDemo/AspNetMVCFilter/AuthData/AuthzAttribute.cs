using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetMVCFilter.AuthData
{
    public class AuthzAttribute: AuthorizeAttribute
    {
        private bool localAllowed;
        public AuthzAttribute(bool allowedParam)
        {
            localAllowed = allowedParam;
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if(httpContext.Request.IsLocal)
            {
                return localAllowed;
            }
            else
            {
                return true;
            }
            //return base.AuthorizeCore(httpContext);
        }
    }
}