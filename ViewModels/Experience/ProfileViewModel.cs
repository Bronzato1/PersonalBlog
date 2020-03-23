using System.Collections.Generic;
using PersonalBlog.Models;

namespace PersonalBlog
{
    public class ProfileViewModel
    {
        public CustomUser CustomUser { get; set; }
        public IEnumerable<Experience> Experiences { get; set; }
    }
}