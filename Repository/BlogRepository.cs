using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using PersonalBlog;
using PersonalBlog.Models;

namespace PersonalBlog
{
    public class BlogRepository : IBlogRepository
    {
        private const string POSTS = "Posts";
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
    }
}
