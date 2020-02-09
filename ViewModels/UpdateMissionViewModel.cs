using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PersonalBlog.Models;

namespace  PersonalBlog.ViewModels
{
    public class UpdateMissionViewModel
    {
        public Mission Mission { get; set; }
        public List<SelectListItem> SelCompanies { get; set; }
        public List<SelectListItem> SelDatabases { get; set; }
        public List<SelectListItem> SelLanguages { get; set; }
        public List<Colors> ColorLanguages { get; set; }
        public int[] SelectedLanguageIds { get; set; }
    }

    public class Colors
    {
        public int Id { get; set; }
        public string Color { get; set; }
    }
}
