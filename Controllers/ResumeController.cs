using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PersonalBlog.Models;
using PersonalBlog.ViewModels;

namespace PersonalBlog
{
    [AllowAnonymous]
    public class ResumeController : Controller
    {
        MyDbContext _dbContext;

        public ResumeController(MyDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public ActionResult Index()
        {
            return View(_dbContext.Resumes.ToList());
        }

        public ActionResult Create()
        {
            var vm = new CreateResumeViewModel();
            
            vm.Companies = _dbContext.Companies
                          .Select(a => new SelectListItem() {  
                              Value = a.Id.ToString(),
                              Text = a.Name
                          }).ToList();

            vm.Databases = _dbContext.Databases
                          .Select(a => new SelectListItem() {  
                              Value = a.Id.ToString(),
                              Text = a.Name
                          }).ToList();

            return View(vm);
        }

        [HttpPost]
        public ActionResult CreateResume(CreateResumeViewModel createResumeVM) {
            _dbContext.Resumes.Add(createResumeVM.Resume);
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Resume");
        }


    }
}