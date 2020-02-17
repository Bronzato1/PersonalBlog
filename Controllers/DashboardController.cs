using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace PersonalBlog
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            ViewData["sidebar-collapse"] = true;
            return View();
        }
    }
}