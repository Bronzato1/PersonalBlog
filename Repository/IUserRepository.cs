using System.Collections.Generic;
using PersonalBlog.Models;
using PersonalBlog.ViewModels;

namespace PersonalBlog
{
    public interface IUserRepository
    {
        public List<CustomUser> GetAllUsers();

        public List<UsersAndRolesViewModel> GetAllUsersWithRoles();

        public CustomUser GetUserFromUserName(string userName);

        public CustomUser GetUserFromFullName(string fullName);
    }
}