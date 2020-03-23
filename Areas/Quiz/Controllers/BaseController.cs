using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PersonalBlog.Quizbee.Commons;

namespace PersonalBlog.Quizbee.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        // protected override void OnException(ExceptionContext filterContext)
        // {
        //     Exception ex = filterContext.Exception;
            
        //     #if DEBUG
        //     throw ex;
        //     #endif

        //     //Log Exception e
        //     filterContext.ExceptionHandled = true;
        //     filterContext.Result = new ViewResult()
        //     {
        //         ViewName = "Error"
        //     };
        // }

        public bool UserHasRights()
        {
            return User.IsInRole(Variables.Administrator);
        }

        public ActionResult UnAuthorized()
        {
            Response.StatusCode = 403;

            return View();
        }
    }
}