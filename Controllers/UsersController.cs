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
    public class UsersController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IExperienceRepository _experienceRepository;
        private readonly UserManager<CustomUser> _userManager;

        public UsersController(IUserRepository userRepository, IExperienceRepository experienceRepository,UserManager<CustomUser> userManager)
        {
            _userRepository = userRepository;
            _experienceRepository= experienceRepository;
            _userManager = userManager;
        }
  
        [AllowAnonymous]
        [Route("/users/{fullName}")]
        public ActionResult Profile([FromRoute] string fullName)
        {
            ProfileViewModel viewModel = new ProfileViewModel();
            //viewModel.CustomUser = await _userManager.GetUserAsync(User);

            viewModel.CustomUser = _userRepository.GetUserFromFullName(fullName);
            viewModel.Experiences = _experienceRepository.GetAllExperiences();
            return View(viewModel);
        }
    }
}