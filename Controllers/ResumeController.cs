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
        private readonly IDataRepository _dataRepository;
        private readonly UserManager<CustomUser> _userManager;

        public ResumeController(IDataRepository dataRepository, UserManager<CustomUser> userManager)
        {
            _dataRepository = dataRepository;
            _userManager = userManager;
        }

        public ActionResult Index()
        {
            List<Mission> missions = _dataRepository.GetAllMissions();
            return View(missions);
        }

        [AllowAnonymous]
        public ActionResult About()
        {
            List<Mission> missions = _dataRepository.GetAllMissions();
            return View(missions);
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

            vm.Companies = _dataRepository.GetAllCompanies()
                          .Select(a => new SelectListItem()
                          {
                              Value = a.Id.ToString(),
                              Text = a.Name
                          }).ToList();

            vm.Databases = _dataRepository.GetAllDatabases()
                          .Select(a => new SelectListItem()
                          {
                              Value = a.Id.ToString(),
                              Text = a.Name
                          }).ToList();

            return View(vm);
        }

        [HttpPost]
        public ActionResult CreateMission(CreateMissionViewModel createMissionVM)
        {
            createMissionVM.Mission.CreatedTime = DateTime.Now;
            createMissionVM.Mission.CreatedUser = User.FindFirstValue(ClaimTypes.Name); // will give the user's userName
            _dataRepository.AddMission(createMissionVM.Mission);
            return RedirectToAction("Index", "Mission");
        }

        [HttpPost]
        public bool Delete(int id)
        {
            try
            {
                var mission = _dataRepository.GetMissionById(id);
                _dataRepository.DeleteMission(mission);
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public ActionResult View(int id)
        {
            var mission = _dataRepository.GetMissionById(id);
            return View(mission);
        }

        public ActionResult Update(int id)
        {
            var viewModel = new UpdateMissionViewModel();
            var mission = _dataRepository.GetMissionById(id);
            var companies = _dataRepository.GetAllCompanies();
            var databases = _dataRepository.GetAllDatabases();
            var languages = _dataRepository.GetAllLanguages();

            viewModel.Mission = mission;

            viewModel.SelCompanies = _dataRepository.GetAllCompanies()
                          .Select(a => new SelectListItem()
                          {
                              Value = a.Id.ToString(),
                              Text = a.Name
                          }).ToList();

            viewModel.SelDatabases = _dataRepository.GetAllDatabases()
                          .Select(a => new SelectListItem()
                          {
                              Value = a.Id.ToString(),
                              Text = a.Name
                          }).ToList();

            viewModel.SelLanguages = _dataRepository.GetAllLanguages()
                          .Select(a => new SelectListItem() {
                              Value = a.Id.ToString(),
                              Text = a.Name
                          }).ToList();

            var colors = _dataRepository.GetAllLanguages().Select(x => new Colors { Id = x.Id, Color = x.Color.ToString() }).ToList();
            var languageIds = mission.MissionLanguages.Select(x => x.LanguageId).ToArray();

            viewModel.ColorLanguages = colors; 
            viewModel.SelectedLanguageIds = languageIds;

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult UpdateMission(UpdateMissionViewModel updateMissionViewModel)
        {
            Mission m = _dataRepository.GetMissionById(updateMissionViewModel.Mission.Id);
            m.Date = updateMissionViewModel.Mission.Date;
            m.Title = updateMissionViewModel.Mission.Title;
            m.Description = updateMissionViewModel.Mission.Description;
            m.Sector = updateMissionViewModel.Mission.Sector;
            m.CompanyId = updateMissionViewModel.Mission.CompanyId;
            m.DatabaseId = updateMissionViewModel.Mission.DatabaseId;
            _dataRepository.UpdateMission(m);
            _dataRepository.UpdateMissionLanguages(updateMissionViewModel.Mission.Id, updateMissionViewModel.SelectedLanguageIds);
            return RedirectToAction("Index", "Mission");
        }
    }


}