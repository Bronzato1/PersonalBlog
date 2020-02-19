using System.Threading.Tasks;
using JsonNet.PrivateSettersContractResolvers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace PersonalBlog
{
    public class AdminController : Controller
    {
        private readonly IBlogRepository _blogRepository;

        public AdminController(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        public async Task<ContentResult> GetPostsAsJson()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ContractResolver = new PrivateSetterContractResolver()
            };

            var posts = await _blogRepository.GetPosts();
            var json = JsonConvert.SerializeObject(posts, settings);

            return Content(json);
        }

    }
}