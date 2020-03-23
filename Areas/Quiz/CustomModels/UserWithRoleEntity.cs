using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using PersonalBlog.Models;

namespace PersonalBlog.Quizbee.CustomModels
{
    public class UserWithRoleEntity
    {
        public CustomUser User { get; set; }

        public List<IdentityRole> Roles { get; set; }
    }
}
