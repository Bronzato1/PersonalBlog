using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PersonalBlog.Models;

namespace PersonalBlog.Areas.Identity.Pages.Account.Manage.Experiences
{
    public partial class DeleteModel : PageModel
    {
        private readonly UserManager<CustomUser> _userManager;
        private readonly SignInManager<CustomUser> _signInManager;
        private readonly IResumeRepository _resumeRepository;

        public DeleteModel(UserManager<CustomUser> userManager, SignInManager<CustomUser> signInManager, IResumeRepository resumeRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _resumeRepository = resumeRepository;
        }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? Id { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            public DateTime Id { get; set; }

            [Display(Name = "Date")]
            [DataType(DataType.DateTime)]
            public DateTime Date { get; set; }

            [Display(Name = "Title")]
            [DataType(DataType.Text)]
            public string Title { get; set; }

            [Display(Name = "Description")]
            public string Description { get; set; }

            [Display(Name = "Sector")]
            public EnumSector Sector { get; set; }

            [Display(Name = "CompanyId")]
            public int CompanyId { get; set; }
            public Company Company { get; set; }

            [DataType(DataType.Text)]
            [Display(Name = "DatabaseId")]
            public int? DatabaseId { get; set; }
        }

        private void Load(Experience experience)
        {
            Input = new InputModel
            {
                Date = experience.Date,
                Title = experience.Title,
                Description = experience.Description,
                Sector = experience.Sector,
                CompanyId = experience.CompanyId,
                DatabaseId = experience.DatabaseId
            };
        }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mission = _resumeRepository.GetExperienceById(id.Value);

            if (mission == null)
            {
                return NotFound($"Unable to load mission with ID '{id}'.");
            }

            Load(mission);
            return Page();
        }

        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var experience = _resumeRepository.GetExperienceById(id.Value);

            if (experience == null)
            {
                return NotFound($"Unable to load experience with ID '{id}'.");
            }

            try
            {
                _resumeRepository.DeleteExperience(experience);
                StatusMessage = "Experience deleted";
                return RedirectToPage("Index");
            }
            catch (Exception ex)
            {
                //Log the error
                var exception = ex;
                return RedirectToAction("./Delete", new { id, saveChangesError = true });
            }
        }
    }
}

