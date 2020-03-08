using PersonalBlog.Models;

namespace PersonalBlog
{
    public interface IUserRepository
    {
        public CustomUser GetUserFromUserName(string userName);

        public CustomUser GetUserFromFullName(string fullName);
    }
}