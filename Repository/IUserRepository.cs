using System.Collections.Generic;
using PersonalBlog.Models;

namespace PersonalBlog
{
    public interface IUserRepository
    {
        public List<CustomUser> GetAllUsers();

        public CustomUser GetUserFromUserName(string userName);

        public CustomUser GetUserFromFullName(string fullName);
    }
}