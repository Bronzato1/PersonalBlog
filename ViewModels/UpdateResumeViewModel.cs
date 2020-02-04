using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using PersonalBlog.Models;

namespace  PersonalBlog.ViewModels
{
    public class UpdateResumeViewModel
    {
        public Resume Resume { get; set; }
        public List<SelectListItem> Companies { set; get; }
        public List<SelectListItem> Databases { set; get; }
    }    
}
