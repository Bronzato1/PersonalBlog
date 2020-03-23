using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PersonalBlog.Quizbee.Models;

namespace PersonalBlog.Quizbee.ViewModels
{
    public class HomeViewModel : ListingBaseViewModel
    {
        public List<Quiz> Quizzes { get; set; }
    }
}