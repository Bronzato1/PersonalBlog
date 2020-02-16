using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PersonalBlog.Models;

namespace  PersonalBlog.ViewModels
{
    public class UpdatePostViewModel
    {
        public Post Post { get; set; }
        public List<SelectListItem> SelCategories { get; set; }
        //public int[] SelectedCategoriesIds { get; set; }
        //public List<int> SelectedCategoriesIds { get; set; }
        public List<string> SelectedCategories { get; set; }
    }
}
