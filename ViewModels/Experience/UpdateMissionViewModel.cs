using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PersonalBlog.Models;

namespace  PersonalBlog.ViewModels
{
    public class UpdateExperienceViewModel
    {
        public Experience Experience { get; set; }
        public List<SelectListItem> SelCompanies { get; set; }
        public List<SelectListItem> SelDatabases { get; set; }
        public List<SelectListItem> SelTags { get; set; }
        public List<Colors> ColorLanguages { get; set; }
        public int[] SelectedTagIds { get; set; }
    }

    public class Colors
    {
        public int Id { get; set; }
        public string Color { get; set; }
    }
}
