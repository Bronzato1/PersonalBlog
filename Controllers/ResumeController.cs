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
        private readonly IResumeRepository _resumeRepository;
        private readonly UserManager<CustomUser> _userManager;

        public ResumeController(IResumeRepository resumeRepository, UserManager<CustomUser> userManager)
        {
            _resumeRepository = resumeRepository;
            _userManager = userManager;
        }
  
        [AllowAnonymous]
        public async Task<ActionResult> Profile()
        {
            ProfileViewModel viewModel = new ProfileViewModel();
            viewModel.CustomUser = await _userManager.GetUserAsync(User);
            viewModel.Missions = _resumeRepository.GetAllMissions();
            return View(viewModel);
        }
    }
}