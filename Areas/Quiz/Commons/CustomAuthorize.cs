using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace PersonalBlog.Quizbee.Commons
{
    public class CustomAuthorize : AuthorizeAttribute
    {
        // protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        // {
        //     if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
        //     {
        //         //if not logged, it will work as normal Authorize and redirect to the Login
        //         base.HandleUnauthorizedRequest(filterContext);
        //     }
        //     else
        //     {
        //         //logged and wihout the role to access it - redirect to the custom controller action
        //         filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Base", action = "UnAuthorized" }));
        //     }
        // }
    }
}