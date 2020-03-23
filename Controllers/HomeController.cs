using Microsoft.AspNetCore.Mvc;

namespace PersonalBlog
{
    public class HomeController: Controller
    {
        public HomeController()
        {
        }

        public IActionResult Index() 
        {
            return RedirectToAction("Index", "Dashboard", new { area = "Dashboard" });
        }
    }
}