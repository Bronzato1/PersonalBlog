using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PersonalBlog.Models;
using PersonalBlog.ViewModels;

namespace PersonalBlog
{
    public class UserRepository : IUserRepository
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

        public List<UsersAndRolesViewModel> GetAllUsersWithRoles()
        {
            var usersWithRoles =
               (from user in _dbContext.Users
                select new
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    RoleNames = (from userRole in user.Roles
                                 join role in _dbContext.Roles 
                                 on userRole.RoleId equals role.Id
                                 select role.Name).ToList()
                }).ToList();
                
                var viewModel = usersWithRoles.Select(p => new UsersAndRolesViewModel()
                {
                    UserId = p.UserId,
                    UserName = p.UserName,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Email = p.Email,
                    Role = string.Join(",", p.RoleNames)
                }).ToList();

            return viewModel;
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