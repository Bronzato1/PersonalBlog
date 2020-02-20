using System.Threading.Tasks;
using JsonNet.PrivateSettersContractResolvers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using System.IO;

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

        public async Task<ContentResult> SavePostsAsJsonToDisk()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ContractResolver = new PrivateSetterContractResolver()
            };

            var posts = await _blogRepository.GetPosts();
            var json = JsonConvert.SerializeObject(posts, settings);

            System.IO.File.WriteAllText(@"Secret-seed-blog.json", json);
            return Content("Save Posts As Json To Disk : succeed");
        }

        public FileResult DownloadBlogPosts()
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes(@"Secret-seed-blog.json");
            string fileName = "Secret-seed-blog.json";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        [HttpPost("FileUpload")]
        public async Task<IActionResult> FileUpload(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return NotFound("File Upload : file not found");

            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                var fileBytes = ms.ToArray();
                await System.IO.File.WriteAllBytesAsync(@"Secret-seed-blog.json", fileBytes);
            }

            return Ok("File Upload: success");
        }

        public async Task<ContentResult> SaveJsonPostsInDatabase()
        {
            await _blogRepository.SaveJsonPostsInDatabase();
            return Content("Save Json Posts In Database : succeed");
        }
    }
}