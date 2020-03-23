using Microsoft.AspNetCore.Mvc;

namespace PersonalBlog
{
    [Area("Quiz")]
    public class QuizController : Controller
    {
        public QuizController()
        {

        }

        [Route("/quiz/")]
        public ActionResult Index()
        {
            return View();
        }
    }
}