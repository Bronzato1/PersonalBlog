using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;
using JsonNet.PrivateSettersContractResolvers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PersonalBlog;
using PersonalBlog.Models;

namespace PersonalBlog
{
    public class BlogRepository : IBlogRepository
    {
        private const string POSTS = "posts";
        private const string FILES = "files";

        private readonly IHttpContextAccessor _contextAccessor;
        private readonly MyDbContext _dbContext;
        private readonly string _folder;

        public BlogRepository(IWebHostEnvironment env, IHttpContextAccessor contextAccessor, MyDbContext dbContext)
        {
            _folder = Path.Combine(env.WebRootPath, POSTS);
            _contextAccessor = contextAccessor;
            _dbContext = dbContext;
        }

        public virtual Task<IEnumerable<Post>> GetPosts()
        {
            bool isAdmin = IsAdmin();

            var posts = _dbContext.Posts
                .Where(p => p.PubDate <= DateTime.UtcNow && (p.IsPublished || isAdmin))
                .Include(p => p.Categories)
                .AsEnumerable();

            return Task.FromResult(posts);
        }

        public virtual Task<IEnumerable<Post>> GetPostsByCategory(string category)
        {
            bool isAdmin = IsAdmin();

            var posts = (from p in _dbContext.Posts.Include(x => x.Categories)
                         where p.PubDate <= DateTime.UtcNow && (p.IsPublished || isAdmin)
                         where p.Categories.Any(x => x.Name == category)
                         select p).AsEnumerable();

            return Task.FromResult(posts);
        }

        public virtual Task<Post> GetPostById(int id)
        {
            var post = _dbContext.Posts
                    .Include(x => x.Categories)
                    .FirstOrDefault(p => p.Id.Equals(id));

            bool isAdmin = IsAdmin();

            if (post != null && post.PubDate <= DateTime.UtcNow && (post.IsPublished || isAdmin))
            {
                return Task.FromResult(post);
            }

            return Task.FromResult<Post>(null);
        }

        public virtual Task<IEnumerable<Category>> GetCategories()
        {
            bool isAdmin = IsAdmin();

            var categories = _dbContext.Posts
                .Where(p => p.IsPublished || isAdmin)
                .SelectMany(post => post.Categories).Distinct().AsEnumerable();
            // .Select(cat => cat.Name.ToLowerInvariant())
            // .Distinct().AsEnumerable();

            return Task.FromResult(categories);
        }

        protected bool IsAdmin()
        {
            return _contextAccessor.HttpContext?.User?.Identity.IsAuthenticated == true;
        }

        public virtual Task<Post> GetPostBySlug(string slug)
        {
            var post = _dbContext.Posts
                            .Include(p => p.Categories)
                            .FirstOrDefault(p => p.Slug.Equals(slug));

            bool isAdmin = IsAdmin();

            if (post != null && post.PubDate <= DateTime.UtcNow && (post.IsPublished || isAdmin))
            {
                return Task.FromResult(post);
            }

            return Task.FromResult<Post>(null);
        }

        public async Task SavePost(Post post)
        {
            post.LastModified = DateTime.UtcNow;

            if (!_dbContext.Posts.Contains(post))
                _dbContext.Posts.Add(post);
            else
                _dbContext.Posts.Attach(post);

            await _dbContext.SaveChangesAsync();
        }

        public Task DeletePost(Post post)
        {
            if (_dbContext.Posts.Contains(post))
            {
                _dbContext.Posts.Remove(post);
            }
            _dbContext.SaveChanges();

            return Task.CompletedTask;
        }

        public async Task<string> SaveFile(byte[] bytes, string fileName, string suffix = null)
        {
            suffix = CleanFromInvalidChars(suffix ?? DateTime.UtcNow.Ticks.ToString());

            string ext = Path.GetExtension(fileName);
            string name = CleanFromInvalidChars(Path.GetFileNameWithoutExtension(fileName));

            string fileNameWithSuffix = $"{name}_{suffix}{ext}";

            string absolute = Path.Combine(_folder, FILES, fileNameWithSuffix);
            string dir = Path.GetDirectoryName(absolute);

            Directory.CreateDirectory(dir);
            using (var writer = new FileStream(absolute, FileMode.CreateNew))
            {
                await writer.WriteAsync(bytes, 0, bytes.Length).ConfigureAwait(false);
            }

            return $"/{POSTS}/{FILES}/{fileNameWithSuffix}";
        }

        private string GetFilePath(Post post)
        {
            return Path.Combine(_folder, post.Id + ".xml");
        }

        private static string CleanFromInvalidChars(string input)
        {
            // ToDo: what we are doing here if we switch the blog from windows
            // to unix system or vice versa? we should remove all invalid chars for both systems

            var regexSearch = Regex.Escape(new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars()));
            var r = new Regex($"[{regexSearch}]");
            return r.Replace(input, "");
        }

        private static string FormatDateTime(DateTime dateTime)
        {
            const string UTC = "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'";

            return dateTime.Kind == DateTimeKind.Utc
                ? dateTime.ToString(UTC)
                : dateTime.ToUniversalTime().ToString(UTC);
        }

        public async Task SaveJsonPostsInDatabase()
        {
            var jsonData = System.IO.File.ReadAllText(@"Secret-seed-blog.json");

            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ContractResolver = new PrivateSetterContractResolver()
            };

            List<Post> posts = JsonConvert.DeserializeObject<List<Post>>(jsonData, settings);

            _dbContext.AddRange(posts);

            if (_dbContext.ChangeTracker.HasChanges())
                await _dbContext.SaveChangesAsync();
        }
    }
}
