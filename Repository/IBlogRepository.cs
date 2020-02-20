using System.Collections.Generic;
using System.Threading.Tasks;
using PersonalBlog.Models;

namespace PersonalBlog
{
    public interface IBlogRepository
    {
        Task<IEnumerable<Post>> GetPosts();

        Task<IEnumerable<Post>> GetPostsByCategory(string category);

        Task<Post> GetPostById(int id);

        Task<IEnumerable<Category>> GetCategories();

        Task<Post> GetPostBySlug(string slug);

        Task SavePost(Post post);

        Task DeletePost(Post post);

        Task<string> SaveFile(byte[] bytes, string fileName, string suffix = null);

        Task SaveJsonPostsInDatabase();
    }
}