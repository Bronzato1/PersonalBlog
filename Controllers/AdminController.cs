using System.Threading.Tasks;
using JsonNet.PrivateSettersContractResolvers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.IO.Compression;
using System;

namespace PersonalBlog
{
    public class AdminController : Controller
    {
        private const string POSTS = "posts";
        private const string FILES = "files";
        private const string ZIP = "zip";

        private readonly IBlogRepository _blogRepository;
        private readonly string _folder;

        public AdminController(IWebHostEnvironment env, IBlogRepository blogRepository)
        {
            _folder = Path.Combine(env.WebRootPath, POSTS);
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

        public FileResult DownloadAllImagesInZip()
        {
            string filesDirectory = Path.Combine(_folder, FILES);
            string zipFile = "blog_posts_" +  DateTime.Now.ToString("yyyy_MM_dd_hhmmss") + ".zip";
            string zipPath = Path.Combine(_folder, ZIP, zipFile);
            string zipDirectory = Path.GetDirectoryName(zipPath);

            Directory.CreateDirectory(zipDirectory);
            ZipFile.CreateFromDirectory(filesDirectory, zipPath);

            byte[] fileBytes = System.IO.File.ReadAllBytes(zipPath);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, zipFile);
        }
    }
}