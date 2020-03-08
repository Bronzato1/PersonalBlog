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
    public partial class EditModel : PageModel
    {
        private readonly UserManager<CustomUser> _userManager;
        private readonly SignInManager<CustomUser> _signInManager;
        private readonly IExperienceRepository _experienceRepository;

        public EditModel(UserManager<CustomUser> userManager, SignInManager<CustomUser> signInManager, IExperienceRepository experienceRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _experienceRepository = experienceRepository;
        }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? Id { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        [BindProperty]
        public List<SelectListItem> Companies { set; get; }

        [BindProperty]
        public List<SelectListItem> Keywords { set; get; }
        

        public class InputModel
        {
            [Required]
            [Display(Name = "Date")]
            [DataType(DataType.DateTime)]
            public DateTime Date { get; set; }

            [Required]
            [Display(Name = "Title")]
            [DataType(DataType.Text)]
            public string Title { get; set; }

            [Required]
            [Display(Name = "Description")]
            public string Description { get; set; }

            [Required]
            [Display(Name = "Sector")]
            public EnumSector Sector { get; set; }

            [Required]
            [Display(Name = "CompanyId")]
            public int CompanyId { get; set; }
            public Company Company { get; set; }

            [Required]
            [Display(Name = "SelectedKeywordIds")]
            public int[] SelectedKeywordIds { set; get; }

            [Required]
            [Range(1,50)]
            public int Staff { get; set; }

            [Required]
            [Range(1,9999)]
            public int Duration { get; set; }
        }

        private void Load(Experience experience)
        {
            var keywordIds = experience.ExperienceKeywords.Select(x => x.KeywordId).ToArray();

            Input = new InputModel
            {
                Date = experience.Date,
                Title = experience.Title,
                Description = experience.Description,
                Sector = experience.Sector,
                CompanyId = experience.CompanyId,
                SelectedKeywordIds = keywordIds,
                Staff = experience.Staff,
                Duration = experience.Duration
            };
        }

        public IActionResult OnGet(int? id)
        {
            Companies = _experienceRepository.GetAllCompanies()
                            .OrderBy(x => x.Name)
                            .Select(a => new SelectListItem()
                            {
                                Value = a.Id.ToString(),
                                Text = a.Name
                            }).ToList();
                            
            Keywords = _experienceRepository.GetAllKeywords()
                            .OrderBy(x => x.Name)
                            .Select(a => new SelectListItem()
                            {
                                Value = a.Id.ToString(),
                                Text = a.Name
                            }).ToList();

            if (id == null)
            {
                Input = new InputModel();
                return Page();
            }

            var experience = _experienceRepository.GetExperienceById(id.Value);

            if (experience == null)
            {
                return NotFound($"Unable to load experience with ID '{id}'.");
            }

            Load(experience);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Experience experience;

            if (Id.HasValue)
            {
                experience = _experienceRepository.GetExperienceById(Id.Value);
            }
            else
            {
                experience = new Experience();
            }

            if (Input.Date != experience.Date)
            {
                experience.Date = Input.Date;
            }

            if (Input.Title != experience.Title)
            {
                experience.Title = Input.Title;
            }

            if (Input.Description != experience.Description)
            {
                experience.Description = Input.Description;
            }

            if (Input.Sector != experience.Sector)
            {
                experience.Sector = Input.Sector;
            }

            if (Input.CompanyId != experience.CompanyId)
            {
                experience.CompanyId = Input.CompanyId;
            }

            if (Input.Staff != experience.Staff)
            {
                experience.Staff = Input.Staff;
            }

            if (Input.Duration!= experience.Duration)
            {
                experience.Duration = Input.Duration;
            }

            if (Id.HasValue)
            {
                _experienceRepository.UpdateExperience(experience);
                _experienceRepository.UpdateExperienceKeywords(Id.Value, Input.SelectedKeywordIds);
            }
            else
            {
                var exp = await _experienceRepository.AddExperience(experience);
                _experienceRepository.UpdateExperienceKeywords(exp.Id, Input.SelectedKeywordIds);
            }

            StatusMessage = "Experience created/updated";

            return RedirectToPage("Index");
        }

        public async Task<JsonResult> OnPostCompanyTag()
        {
            using (var reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                var body = await reader.ReadToEndAsync();
                var values = JsonConvert.DeserializeObject<PostTagData>(body);
                var id = _experienceRepository.AddCompany(values.text);
                return new JsonResult( new { id = id });
            }
        }

        public async Task<JsonResult> OnPostKeywordTag()
        {
            using (var reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                var body = await reader.ReadToEndAsync();
                var values = JsonConvert.DeserializeObject<PostTagData>(body);
                var id = _experienceRepository.AddKeyword(values.text);
                return new JsonResult( new { id = id });
            }
        }
   
    }

    public class PostTagData
    {
        public int id { get; set; }
        public string text { get; set; }
    }
}

