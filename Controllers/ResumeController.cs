using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PersonalBlog.Models;
using PersonalBlog.ViewModels;

namespace PersonalBlog
{
    [Authorize(Roles = "Admin")]
    public class ResumeController : Controller
    {
        MyDbContext _dbContext;
        UserManager<CustomUser> _userManager;

        public ResumeController(MyDbContext dbContext, UserManager<CustomUser> userManager) 
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public ActionResult Index()
        {
            List<Resume> resumes = _dbContext.Resumes.Include(x => x.Company).ToList();
            return View(resumes);
        }

        // For testing purpope only
        public async Task<IActionResult> LoggedUser()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId
            var userName = User.FindFirstValue(ClaimTypes.Name); // will give the user's userName

            CustomUser applicationUser = await _userManager.GetUserAsync(User);
            string userEmail = applicationUser?.Email; // will give the user's Email
            string userFirstName = applicationUser?.FirstName; // will give the user's FirstName
            string userLastName = applicationUser?.LastName; // will give the user's LastName

            var infos = string.Format(" UserId: {0} \n UserName: {1} \n Mail: {2} \n FirstName: {3} \n LastName: {4}", userId, userName, userEmail, userFirstName, userLastName);
            return Content(infos);
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
            createResumeVM.Resume.CreatedTime = DateTime.Now;
            createResumeVM.Resume.CreatedUser = User.FindFirstValue(ClaimTypes.Name); // will give the user's userName
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