using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace PersonalBlog
{
    [Area("Dashboard")]
    public class DashboardController : Controller
    {
        [Route("/dashboard/")]
        public ActionResult Index()
        {
            ViewData["sidebar-collapse"] = true;
            return View();
        }
    }
}