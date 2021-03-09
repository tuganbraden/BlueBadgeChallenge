using BlueBadgeProject.WebAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlueBadgeProject.GUI.Models
{
    public class WebApiAuthorize:AuthorizeAttribute
    {
        public WebApiAuthorize():base()
        {
            
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return Startup.hasToken;


        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new HttpUnauthorizedResult();
        }


    }
}