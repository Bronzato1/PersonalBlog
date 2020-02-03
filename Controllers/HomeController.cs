using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace PersonalBlog
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}