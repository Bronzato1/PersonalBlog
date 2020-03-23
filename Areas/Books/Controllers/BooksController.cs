using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;

namespace PersonalBlog
{
    [Area("Books")]
    public class BooksController : Controller
    {
        [Route("/books/")]
        public ActionResult Index()
        {
            ViewData["sidebar-collapse"] = true;
            return View();
        }
    }
}
