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

namespace PersonalBlog.Areas.Identity.Pages.Account.Manage.Missions
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
        public List<SelectListItem> Languages { set; get; }
        

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

            [Display(Name = "SelectedLanguageIds")]
            public int[] SelectedLanguageIds { set; get; }
        }

        private void Load(Mission mission)
        {
            var languageIds = mission.MissionLanguages.Select(x => x.LanguageId).ToArray();

            Input = new InputModel
            {
                Date = mission.Date,
                Title = mission.Title,
                Description = mission.Description,
                Sector = mission.Sector,
                CompanyId = mission.CompanyId,
                DatabaseId = mission.DatabaseId,
                SelectedLanguageIds = languageIds
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

            Languages = _resumeRepository.GetAllLanguages()
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

            var mission = _resumeRepository.GetMissionById(id.Value);

            if (mission == null)
            {
                return NotFound($"Unable to load mission with ID '{id}'.");
            }

            Load(mission);
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Mission mission;

            if (Id.HasValue)
            {
                mission = _resumeRepository.GetMissionById(Id.Value);
            }
            else
            {
                mission = new Mission();
            }

            if (Input.Date != mission.Date)
            {
                mission.Date = Input.Date;
            }

            if (Input.Title != mission.Title)
            {
                mission.Title = Input.Title;
            }

            if (Input.Description != mission.Description)
            {
                mission.Description = Input.Description;
            }

            if (Input.Sector != mission.Sector)
            {
                mission.Sector = Input.Sector;
            }

            if (Input.CompanyId != mission.CompanyId)
            {
                mission.CompanyId = Input.CompanyId;
            }

            if (Input.DatabaseId != mission.DatabaseId)
            {
                mission.DatabaseId = Input.DatabaseId;
            }

            if (Id.HasValue)
            {
                _resumeRepository.UpdateMission(mission);
                _resumeRepository.UpdateMissionLanguages(Id.Value, Input.SelectedLanguageIds);
            }
            else
            {
                _resumeRepository.AddMission(mission);
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
   
        public async Task<JsonResult> OnPostLanguageTag()
        {
            using (var reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                var body = await reader.ReadToEndAsync();
                var values = JsonConvert.DeserializeObject<PostTagData>(body);
                var id = _resumeRepository.AddLanguage(values.text);
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

