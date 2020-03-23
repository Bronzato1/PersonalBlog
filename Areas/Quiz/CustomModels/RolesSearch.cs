using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Quizbee.CustomModels
{
    public class RolesSearch
    {
        public List<IdentityRole> Roles { get; set; }
        public int TotalCount { get; set; }
    }
}
