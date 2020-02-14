using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace PersonalBlog
{
    public class BlogController : Controller
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IOptionsSnapshot<BlogSettings> _settings;

        public BlogController(IBlogRepository blogRepository, IOptionsSnapshot<BlogSettings> settings)
        {
            _blogRepository = blogRepository;
            _settings = settings;
        }

        [Route("/{page:int?}")]
        public async Task<IActionResult> Index([FromRoute]int page = 0)
        {
            // get published posts
            var posts = await _blogRepository.GetPosts();

            // apply paging filter
            var filteredPosts = posts.Skip(_settings.Value.PostsPerPage * page).Take(_settings.Value.PostsPerPage);

            // set the view option
            ViewData["ViewOption"] = _settings.Value.ListView;
            ViewData["TotalPostCount"] = posts.Count();
            ViewData["Title"] = "Title of the blog"; //_manifest.Name;
            ViewData["Description"] = "Description of the blog"; //_manifest.Description;
            ViewData["prev"] = $"/{page + 1}/";
            ViewData["next"] = $"/{(page <= 1 ? null : page - 1 + "/")}";

            return View("~/Views/Blog/Index.cshtml", filteredPosts);
        }

        [Route("/blog/{slug?}")]
        public async Task<IActionResult> Post(string slug)
        {
            var post = await _blogRepository.GetPostBySlug(slug);

            if (post != null)
            {
                return View(post);
            }

            return NotFound();
        }

        public ActionResult _Chat(int myNumber)
        {
            return PartialView();
        }
    }
}