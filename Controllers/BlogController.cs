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

                // The HTML editor creates base64 DataURIs which we'll have to convert to image files on disk
                if (srcNode != null && fileNameNode != null)
                {
                    string extension = System.IO.Path.GetExtension(fileNameNode.Value);

                    // Only accept image files
                    if (!allowedExtensions.Contains(extension, StringComparer.OrdinalIgnoreCase))
                    {
                        continue;
                    }

                    var base64Match = base64Regex.Match(srcNode.Value);
                    if (base64Match.Success)
                    {
                        byte[] bytes = Convert.FromBase64String(base64Match.Groups["base64"].Value);
                        srcNode.Value = await _blogRepository.SaveFile(bytes, fileNameNode.Value).ConfigureAwait(false);

                        img.Attributes.Remove(fileNameNode);
                        post.Content = post.Content.Replace(match.Value, img.OuterXml);
                    }
                }
            }
        }

        [Route("/blog/deletepost/{id}")]
        [HttpPost, Authorize, AutoValidateAntiforgeryToken]
        public async Task<IActionResult> DeletePost(int id)
        {
            var existing = await _blogRepository.GetPostById(id);

            if (existing != null)
            {
                await _blogRepository.DeletePost(existing);
                return Redirect("/");
            }

            return NotFound();
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