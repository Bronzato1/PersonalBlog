using System;
using System.Collections.Generic;
using System.Linq;
using PersonalBlog.Models;

namespace PersonalBlog
{
    public class UserRepository: IUserRepository
    {
        private readonly MyDbContext _dbContext;

        public UserRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<CustomUser> GetAllUsers()
        {
            var users = _dbContext.Users.ToList();
            return users;
        }

        public CustomUser GetUserFromUserName(string userName)
        {
            var user = _dbContext.Users.Where(x => x.UserName == userName).FirstOrDefault();
            return user;
        }

        public CustomUser GetUserFromFullName(string fullName)
        {
            var user = _dbContext.Users
                                 .Where(x => x.FirstName.ToLower() + x.LastName.ToLower() == fullName.ToLower())
                                 .FirstOrDefault();
            return user;
        }
    }
}