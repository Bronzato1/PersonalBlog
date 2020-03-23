using Microsoft.AspNetCore.Identity;
using PersonalBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Quizbee.CustomModels
{
    public class RoleWithUsersEntity
    {
        public IdentityRole Role { get; set; }
        public List<CustomUser> Users { get; set; }
    }
}
