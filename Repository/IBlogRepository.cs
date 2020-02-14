using System.Collections.Generic;
using System.Threading.Tasks;
using PersonalBlog.Models;

namespace PersonalBlog
{
    public interface IBlogRepository
    {
        Task<IEnumerable<Post>> GetPosts();

        Task<Post> GetPostBySlug(string slug);
    }
}