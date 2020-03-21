using System.Threading.Tasks;
using JsonNet.PrivateSettersContractResolvers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.IO.Compression;
using System;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Xml;
using PersonalBlog.ViewModels;

namespace PersonalBlog
{
    public class AdminController : Controller
    {
        private const string FOLDER_POSTS = "posts";
        private const string FOLDER_IMAGES = "images";
        private const string FOLDER_ARCHIVES = "archives";
        private const string FILE_JSON_POSTS = "Secret-seed-blog.json";
        private const string FILE_JSON_RESUME = "Secret-seed-resume.json";

        private readonly IBlogRepository _blogRepository;
        private readonly IUserRepository _userRepository;
        private readonly string _webRootFolder;
        private readonly string _contentRootFolder;

        public AdminController(IWebHostEnvironment env, IBlogRepository blogRepository, IUserRepository userRepository)
        {
            _contentRootFolder = env.ContentRootPath;
            _webRootFolder = env.WebRootPath;
            _blogRepository = blogRepository;
            _userRepository = userRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        public FileResult ExportDatabase()
        {
            // Use this if you want App_Data off your project root folder
            string appDataFolder = Path.Combine(_contentRootFolder, "App_Data");
            string dbFile = "blogging.db";
            string dbPath = Path.Combine(appDataFolder, dbFile);

            byte[] fileBytes = System.IO.File.ReadAllBytes(dbPath);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, dbFile);
        }

        public async Task<FileResult> ExportBlogData()
        {
            // STEP 1 : get posts as json

            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ContractResolver = new PrivateSetterContractResolver()
            };

            var posts = await _blogRepository.GetPosts();
            var json = JsonConvert.SerializeObject(posts, settings);

            // STEP 2 : remove ids, CustomUser from json

            var parsedJson = JArray.Parse(json);

            parsedJson.Descendants()
                .OfType<JProperty>()
                .Where(attr => attr.Name == "Id" || attr.Name == "CustomUser")
                .ToList()
                .ForEach(attr => attr.Remove());

            json = parsedJson.ToString();

            // STEP 3 : save the file as json

            System.IO.File.WriteAllText(@"Secret-seed-blog.json", json);

            // STEP 4 : save images in zip file

            string filesDirectory = Path.Combine(_webRootFolder, FOLDER_POSTS, FOLDER_IMAGES);
            string zipFile = "blog_posts_" + DateTime.Now.ToString("yyyy_MM_dd_HHmmss") + ".zip";
            string zipPath = Path.Combine(_webRootFolder, FOLDER_POSTS, FOLDER_ARCHIVES, zipFile);
            string zipDirectory = Path.GetDirectoryName(zipPath);

            Directory.CreateDirectory(zipDirectory);
            ZipFile.CreateFromDirectory(filesDirectory, zipPath);

            // STEP 5 : add json file to zip

            var zipArchive = ZipFile.Open(zipPath, ZipArchiveMode.Update);
            zipArchive.CreateEntryFromFile(FILE_JSON_POSTS, FILE_JSON_POSTS);
            zipArchive.Dispose();

            // STEP 6 : let the user download the zip

            byte[] fileBytes = System.IO.File.ReadAllBytes(zipPath);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, zipFile);
        }

        [HttpPost("ImportBlogData")]
        public async Task<IActionResult> ImportBlogData(IFormFile file)
        {
            // STEP 1 : uploader le zip

            if (file == null || file.Length == 0)
                return NotFound("File Upload : file not found");

            string imagesDirectory = Path.Combine(_webRootFolder, FOLDER_POSTS, FOLDER_IMAGES);
            string zipFile = file.FileName;
            string zipPath = Path.Combine(_webRootFolder, FOLDER_POSTS, FOLDER_ARCHIVES, zipFile);
            string jsonPath = Path.Combine(imagesDirectory, FILE_JSON_POSTS);
            string zipDirectory = Path.GetDirectoryName(zipPath);

            if (System.IO.File.Exists(zipPath))
                System.IO.File.Delete(zipPath);

            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                var fileBytes = ms.ToArray();
                await System.IO.File.WriteAllBytesAsync(zipPath, fileBytes);
            }

            // STEP 2 : extraire les fichiers du zip

            var zipArchive = ZipFile.Open(zipPath, ZipArchiveMode.Read);
            zipArchive.ExtractToDirectory(imagesDirectory, true);
            zipArchive.Dispose();

            if (System.IO.File.Exists(jsonPath))
                System.IO.File.Move(jsonPath, FILE_JSON_POSTS, true);

            await _blogRepository.SaveJsonPostsInDatabase();

            return Ok("File Import: success");
        }

        [HttpPost("ImportDatabase")]
        public async Task<IActionResult> ImportDatabase(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return NotFound("File Upload : file not found");

            string appDataFolder = Path.Combine(_contentRootFolder, "App_Data");
            string dbFile = "blogging.db";
            string dbPath = Path.Combine(appDataFolder, dbFile);
            string dbDirectory = Path.GetDirectoryName(dbPath);

            if (System.IO.File.Exists(dbPath))
                System.IO.File.Delete(dbPath);

            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                var fileBytes = ms.ToArray();
                await System.IO.File.WriteAllBytesAsync(dbPath, fileBytes);
            }

            return Ok("File Import: success");
        }

        public async Task<ActionResult> DeleteUnusedImages()
        {
            var imgRegex = new Regex("<img[^>]+ />", RegexOptions.IgnoreCase | RegexOptions.Compiled);
            //var base64Regex = new Regex("data:[^/]+/(?<ext>[a-z]+);base64,(?<base64>.+)", RegexOptions.IgnoreCase);
            var imagesDirectory = Path.Combine(_webRootFolder, FOLDER_POSTS, FOLDER_IMAGES);

            var obsoleteImageList = new DirectoryInfo(imagesDirectory).GetFiles().ToList();
            var missingImageList = new List<string>();
            var posts = await _blogRepository.GetPosts();
            var viewModel = new ViewModels.DeleteUnusedImagesResuleViewModel();

            posts.ToList().ForEach(post =>
            {
                foreach (Match match in imgRegex.Matches(post.Content))
                {
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml("<root>" + match.Value + "</root>");

                    var img = doc.FirstChild.FirstChild;
                    var srcNode = img.Attributes["src"];

                    var filename = Path.GetFileName(srcNode.Value);
                    var fileInfo = obsoleteImageList.FirstOrDefault(x => x.FullName.EndsWith(filename));

                    if (fileInfo != null)
                        obsoleteImageList.Remove(fileInfo);
                    else
                        missingImageList.Add(filename);
                }
            });

            // Delete obsolete images
            obsoleteImageList.ForEach(fileInfo =>
            {
                System.IO.File.Delete(fileInfo.FullName);
            });

            viewModel.obsoleteImageList = obsoleteImageList.Select(x => x.Name).ToList();
            viewModel.missingImageList = missingImageList;

            return PartialView("_DeleteUnusedImagesResult", viewModel);
        }

        public ActionResult ManageUsersAndRoles()
        {
            var usersAndRolesViewModel = _userRepository.GetAllUsersWithRoles();
            return View(usersAndRolesViewModel);
        }
    }
}