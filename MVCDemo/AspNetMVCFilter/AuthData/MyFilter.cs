using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AspNetMVCFilter.AuthData
{
    public class MyFilter : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if(filterContext.HttpContext.Request.IsAuthenticated)
            {
                if (!(Roles.IsUserInRole("Admin")))
                {
                    ViewResult viewResult = new ViewResult();
                    viewResult.ViewName = "Error";
                    viewResult.ViewBag.ErrorMessage = "Invalid User";
                    filterContext.Result = viewResult;
                }
                
            }
        }
    }
}