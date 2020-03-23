using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalBlog.Quizbee.Models;

namespace PersonalBlog.Quizbee.CustomModels
{
    public class QuizzesSearch
    {
        public List<Quiz> Quizzes { get; set; }
        public int TotalCount { get; set; }
    }
}
