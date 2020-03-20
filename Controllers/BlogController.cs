using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PersonalBlog.Models;
using PersonalBlog.ViewModels;
using System.Collections.Generic;
using Newtonsoft.Json;
using JsonNet.PrivateSettersContractResolvers;
using System.Net;
using System.IO;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace PersonalBlog
{
    public class BlogController : Controller
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IOptionsSnapshot<BlogSettings> _settings;
        private readonly UserManager<CustomUser> _userManager;
        private static readonly int CHUNK_SIZE = 1024;

        public BlogController(IBlogRepository blogRepository, IOptionsSnapshot<BlogSettings> settings, UserManager<CustomUser> userManager)
        {
            _blogRepository = blogRepository;
            _settings = settings;
            _userManager = userManager;
        }

        [Route("/blog/{page:int?}")]
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
            ViewData["sidebar-collapse"] = true;
            return View("~/Views/Blog/Index.cshtml", filteredPosts);
        }

        [Route("/blog/category/{category}/{page:int?}")]
        public async Task<IActionResult> Category(string category, int page = 0)
        {
            // get posts for the selected category.
            var posts = await _blogRepository.GetPostsByCategory(category);

            // apply paging filter.
            var filteredPosts = posts.Skip(_settings.Value.PostsPerPage * page).Take(_settings.Value.PostsPerPage);

            // set the view option
            ViewData["ViewOption"] = _settings.Value.ListView;
            ViewData["TotalPostCount"] = posts.Count();
            ViewData["Title"] = "My title - " + category;
            ViewData["Description"] = $"Articles posted in the {category} category";
            ViewData["prev"] = $"/blog/category/{category}/{page + 1}/";
            ViewData["next"] = $"/blog/category/{category}/{(page <= 1 ? null : page - 1 + "/")}";
            return View("~/Views/Blog/Index.cshtml", filteredPosts);
        }

        [Route("/blog/{slug?}")]
        public async Task<IActionResult> Post(string slug)
        {
            var post = await _blogRepository.GetPostBySlug(slug);

            ViewData["sidebar-collapse"] = true;

            if (post != null)
            {
                return View(post);
            }



            return NotFound();
        }

        [Route("/blog/edit/{id?}")]
        [HttpGet, Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            var viewModel = new UpdatePostViewModel();



            viewModel.SelCategories = (await _blogRepository.GetCategories()).ToList()
                          .Select(a => new SelectListItem()
                          {
                              Value = a.Name, //a.Id.ToString(),
                              Text = a.Name
                          }).DistinctBy(x => x.Text).ToList();

            //viewModel.SelectedCategoriesIds = (await _blogRepository.GetCategories()).ToList().Select(x => x.Id).ToList();

            ViewData["sidebar-collapse"] = true;

            if (id == null)
            {
                viewModel.Post = new Post();

                var  userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId
                var userName =  User.FindFirstValue(ClaimTypes.Name); // will give the user's userName

                CustomUser applicationUser = await _userManager.GetUserAsync(User);
                string userEmail = applicationUser?.Email; // will give the user's Email

                viewModel.Post.CustomUser = applicationUser;
                viewModel.Post.CustomUserId = userId;
                return View(viewModel);
            }

            var post = await _blogRepository.GetPostById(id.Value);

            viewModel.SelectedCategories = post.Categories.Select(x => x.Name).ToList(); //(await _blogRepository.GetCategories()).ToList().Select(x => x.Name).ToList();

            viewModel.Post = post;

            if (post != null)
            {
                return View(viewModel);
            }

            return NotFound();
        }

        [HttpPost, Authorize, AutoValidateAntiforgeryToken]
        public async Task<IActionResult> UpdatePost(UpdatePostViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", viewModel);
            }

            var existing = await _blogRepository.GetPostById(viewModel.Post.Id) ?? viewModel.Post;
            //string categories = Request.Form["categories"];

            //var myCategories = categories.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(c => c.Trim().ToLowerInvariant()).ToList();

            existing.Categories.ToList().ForEach(x =>
            {
                existing.Categories.Remove(x);
            });

            if (viewModel.SelectedCategories != null)
                foreach (string category in viewModel.SelectedCategories)
                {
                    Category cat = new Category
                    {
                        Name = category
                    };
                    existing.Categories.Add(cat);
                }

            existing.Title = viewModel.Post.Title.Trim();
            existing.Slug = !string.IsNullOrWhiteSpace(viewModel.Post.Slug) ? viewModel.Post.Slug.Trim() : Models.Post.CreateSlug(viewModel.Post.Title);
            existing.IsPublished = viewModel.Post.IsPublished;
            existing.Content = viewModel.Post.Content.Trim();
            existing.Excerpt = viewModel.Post.Excerpt.Trim();

            await SaveFilesToDisk(existing);

            await _blogRepository.SavePost(existing);

            return Redirect(existing.GetEncodedLink());
        }

        public ActionResult _Chat(int myNumber)
        {
            return PartialView();
        }

        private async Task SaveFilesToDisk(Post post)
        {
            var imgRegex = new Regex("<img[^>]+ />", RegexOptions.IgnoreCase | RegexOptions.Compiled);
            var base64Regex = new Regex("data:[^/]+/(?<ext>[a-z]+);base64,(?<base64>.+)", RegexOptions.IgnoreCase);
            string[] allowedExtensions = new[] {
              ".jpg",
              ".jpeg",
              ".gif",
              ".png",
              ".webp"
            };

            foreach (Match match in imgRegex.Matches(post.Content))
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml("<root>" + match.Value + "</root>");

                var img = doc.FirstChild.FirstChild;
                var srcNode = img.Attributes["src"];
                var fileNameNode = img.Attributes["data-filename"];

                if (srcNode == null)
                    continue;

                if (srcNode.Value.StartsWith("/posts/images"))
                    continue;

                byte[] bytes = new byte[0];
                string fileName = null;
                string extension = null;

                if (fileNameNode != null)
                {
                    // Image in the editor is from local user
                    fileName = fileNameNode.Value;
                    extension = System.IO.Path.GetExtension(fileNameNode.Value);

                    // Only accept image files
                    if (!allowedExtensions.Contains(extension, StringComparer.OrdinalIgnoreCase))
                    {
                        continue;
                    }

                    var base64Match = base64Regex.Match(srcNode.Value);
                    if (base64Match.Success)
                    {
                        bytes = Convert.FromBase64String(base64Match.Groups["base64"].Value);
                    }
                }
                else
                {
                    // Image in the editor is from an external source (url)
                    fileName = Path.GetFileName(srcNode.Value);
                    extension = System.IO.Path.GetExtension(fileName);

                    // Only accept image files
                    if (!allowedExtensions.Contains(extension, StringComparer.OrdinalIgnoreCase))
                    {
                        continue;
                    }

                    HttpWebRequest imageRequest = (HttpWebRequest)WebRequest.Create(srcNode.Value);
                    WebResponse imageResponse = imageRequest.GetResponse();
                    Stream responseStream = imageResponse.GetResponseStream();

                    using (BinaryReader br = new BinaryReader(responseStream))
                    {
                        byte[] chunk;
                        chunk = br.ReadBytes(CHUNK_SIZE);
                        do
                        {
                            bytes = bytes.Concat(chunk).ToArray();
                            chunk = br.ReadBytes(CHUNK_SIZE);
                        } while (chunk.Length > 0);
                    }
                    responseStream.Close();
                    imageResponse.Close();
                }

                srcNode.Value = await _blogRepository.SaveFile(bytes, fileName).ConfigureAwait(false);
                img.Attributes.Remove(fileNameNode);
                post.Content = post.Content.Replace(match.Value, img.OuterXml);
            }
        }

        [Route("/blog/deletePostA/{id}")]
        [HttpPost, Authorize, AutoValidateAntiforgeryToken]
        public async Task<IActionResult> DeletePostA(int id)
        {
            var existing = await _blogRepository.GetPostById(id);

            if (existing != null)
            {
                await _blogRepository.DeletePost(existing);
                return Redirect("/blog");
            }

            return NotFound();
        }

        [Route("/blog/deletePostB/{id}")]
        [HttpPost, Authorize]
        public async Task<IActionResult> DeletePostB(int id)
        {
            var existing = await _blogRepository.GetPostById(id);

            if (existing != null)
            {
                await _blogRepository.DeletePost(existing);
                return Json(new { deleted = true });
            }

            return Json(new { deleted = false });
        }

        [Route("/blog/deletePosts/{ids}")]
        [HttpPost, Authorize]
        public async Task<JsonResult> DeletePosts(string ids)
        {
            var idList = ids.Split(';').Select(Int32.Parse).ToList();
            var total = idList.Count;
            var deleted = 0;

            foreach(int id in idList) 
            {
                var existing = await _blogRepository.GetPostById(id);

                if (existing != null)
                {
                    await _blogRepository.DeletePost(existing);
                    deleted++;
                }   
            };

            return Json(new { total = total, deleted = deleted });
        }
    }

    public static class ExtensionMethod
    {
        // https://stackoverflow.com/questions/2537823/distinct-by-property-of-class-with-linq
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> knownKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (knownKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }
    }
}