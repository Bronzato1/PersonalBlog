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

        [HttpPost]
        public bool Delete(int id)
        {
            try 
            {
                var resume = _dbContext.Resumes.Where(x => x.Id == id).First();
                _dbContext.Resumes.Remove(resume);
                _dbContext.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
    
        public ActionResult View(int id) 
        {
            var resume = _dbContext.Resumes.Where(x => x.Id == id).First();
            return View(resume);
        }
    
        public ActionResult Update(int id) {
            var vm = new UpdateResumeViewModel();
            var resume = _dbContext.Resumes.Where(x => x.Id == id).First();
            
            vm.Resume = resume;

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
        public ActionResult UpdateResume(Resume resume) 
        {
            Resume r = _dbContext.Resumes.Where(x => x.Id == resume.Id).First();
            r.Date = resume.Date;
            r.Title = resume.Title;
            r.Description = resume.Description;
            r.Sector = resume.Sector;
            r.CompanyId = resume.CompanyId;
            r.DatabaseId = resume.DatabaseId;
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Resume");
        }
    }
}