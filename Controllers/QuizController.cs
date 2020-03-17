using Microsoft.AspNetCore.Mvc;

namespace PersonalBlog
{
    public class QuizController : Controller
    {
        public QuizController()
        {

        }

        public ActionResult Index()
        {
            return View();
        }
    }
}