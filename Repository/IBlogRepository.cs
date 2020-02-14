using System.Collections.Generic;
using System.Threading.Tasks;
using PersonalBlog.Models;

namespace PersonalBlog
{
    public interface IBlogRepository
    {
        Task<IEnumerable<Post>> GetPosts();

        Task<IEnumerable<Post>> GetPostsByCategory(string category);

        Task<Post> GetPostBySlug(string slug);
    }
}