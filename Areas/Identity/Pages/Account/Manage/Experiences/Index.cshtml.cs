using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonalBlog.Models;

namespace PersonalBlog.Areas.Identity.Pages.Account.Manage.Experiences
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<CustomUser> _userManager;
        private readonly SignInManager<CustomUser> _signInManager;
        private readonly IResumeRepository _resumeRepository;

        public IndexModel(UserManager<CustomUser> userManager, SignInManager<CustomUser> signInManager, IResumeRepository resumeRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _resumeRepository = resumeRepository;
        }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public List<Experience> Input { get; set; }

        public IActionResult OnGet()
        {
            Input = _resumeRepository.GetAllExperiences();
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            return RedirectToPage();
        }
    }
}
