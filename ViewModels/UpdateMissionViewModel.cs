using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using PersonalBlog.Models;

namespace  PersonalBlog.ViewModels
{
    public class UpdateMissionViewModel
    {
        public Mission Mission { get; set; }
        public List<SelectListItem> Companies { set; get; }
        public List<SelectListItem> Databases { set; get; }
    }    
}
