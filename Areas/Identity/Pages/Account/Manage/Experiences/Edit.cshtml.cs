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
        private readonly IResumeRepository _resumeRepository;

        public EditModel(UserManager<CustomUser> userManager, SignInManager<CustomUser> signInManager, IResumeRepository resumeRepository)
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

        [BindProperty]
        public List<SelectListItem> Companies { set; get; }

        [BindProperty]
        public List<SelectListItem> Databases { set; get; }

        [BindProperty]
        public List<SelectListItem> Tags { set; get; }
        

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

            [Display(Name = "Sector")]
            public EnumSector Sector { get; set; }

            [Display(Name = "CompanyId")]
            public int CompanyId { get; set; }
            public Company Company { get; set; }

            [Display(Name = "DatabaseId")]
            public int? DatabaseId { get; set; }
            public Database Database { get; set; }

            [Display(Name = "SelectedTagIds")]
            public int[] SelectedTagIds { set; get; }
        }

        private void Load(Experience experience)
        {
            var tagIds = experience.ExperienceTags.Select(x => x.TagId).ToArray();

            Input = new InputModel
            {
                Date = experience.Date,
                Title = experience.Title,
                Description = experience.Description,
                Sector = experience.Sector,
                CompanyId = experience.CompanyId,
                DatabaseId = experience.DatabaseId,
                SelectedTagIds = tagIds
            };
        }

        public IActionResult OnGet(int? id)
        {
            Companies = _resumeRepository.GetAllCompanies()
                            .OrderBy(x => x.Name)
                            .Select(a => new SelectListItem()
                            {
                                Value = a.Id.ToString(),
                                Text = a.Name
                            }).ToList();

            Databases = _resumeRepository.GetAllDatabases()
                            .OrderBy(x => x.Name)
                            .Select(a => new SelectListItem()
                            {
                                Value = a.Id.ToString(),
                                Text = a.Name
                            }).ToList();

            Tags = _resumeRepository.GetAllTags()
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

            var experience = _resumeRepository.GetExperienceById(id.Value);

            if (experience == null)
            {
                return NotFound($"Unable to load experience with ID '{id}'.");
            }

            Load(experience);
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Experience experience;

            if (Id.HasValue)
            {
                experience = _resumeRepository.GetExperienceById(Id.Value);
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

            if (Input.DatabaseId != experience.DatabaseId)
            {
                experience.DatabaseId = Input.DatabaseId;
            }

            if (Id.HasValue)
            {
                _resumeRepository.UpdateExperience(experience);
                _resumeRepository.UpdateExperienceTags(Id.Value, Input.SelectedTagIds);
            }
            else
            {
                _resumeRepository.AddExperience(experience);
            }

            StatusMessage = "Mission created/updated";

            return RedirectToPage("Index");
        }

        public async Task<JsonResult> OnPostCompanyTag()
        {
            using (var reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                var body = await reader.ReadToEndAsync();
                var values = JsonConvert.DeserializeObject<PostTagData>(body);
                var id = _resumeRepository.AddCompany(values.text);
                return new JsonResult( new { id = id });
            }
        }

        public async Task<JsonResult> OnPostDatabaseTag()
        {
            using (var reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                var body = await reader.ReadToEndAsync();
                var values = JsonConvert.DeserializeObject<PostTagData>(body);
                var id = _resumeRepository.AddDatabase(values.text);
                return new JsonResult( new { id = id });
            }
        }
   
        public async Task<JsonResult> OnPostTagTag()
        {
            using (var reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                var body = await reader.ReadToEndAsync();
                var values = JsonConvert.DeserializeObject<PostTagData>(body);
                var id = _resumeRepository.AddTag(values.text);
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

