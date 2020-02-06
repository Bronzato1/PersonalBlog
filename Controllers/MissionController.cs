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
    public class MissionController : Controller
    {
        MyDbContext _dbContext;
        UserManager<CustomUser> _userManager;

        public MissionController(MyDbContext dbContext, UserManager<CustomUser> userManager) 
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public ActionResult Index()
        {
            List<Mission> mission = _dbContext.Missions.Include(x => x.Company).ToList();
            return View(mission);
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
            var vm = new CreateMissionViewModel();
            
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
        public ActionResult CreateMission(CreateMissionViewModel createMissionVM) {
            createMissionVM.Mission.CreatedTime = DateTime.Now;
            createMissionVM.Mission.CreatedUser = User.FindFirstValue(ClaimTypes.Name); // will give the user's userName
            _dbContext.Missions.Add(createMissionVM.Mission);
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Mission");
        }

        [HttpPost]
        public bool Delete(int id)
        {
            try 
            {
                var mission = _dbContext.Missions.Where(x => x.Id == id).First();
                _dbContext.Missions.Remove(mission);
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
            var mission = _dbContext.Missions
                            .Where(x => x.Id == id)
                            .Include(x => x.Company)
                            .Include(x => x.Languages)
                            .First();
                            
            return View(mission);
        }
    
        public ActionResult Update(int id) {
            var vm = new UpdateMissionViewModel();
            var mission = _dbContext.Missions.Where(x => x.Id == id).First();
            
            vm.Mission = mission;

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
        public ActionResult UpdateMission(Mission mission) 
        {
            Mission r = _dbContext.Missions.Where(x => x.Id == mission.Id).First();
            r.Date = mission.Date;
            r.Title = mission.Title;
            r.Description = mission.Description;
            r.Sector = mission.Sector;
            r.CompanyId = mission.CompanyId;
            r.DatabaseId = mission.DatabaseId;
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Mission");
        }
    }
}