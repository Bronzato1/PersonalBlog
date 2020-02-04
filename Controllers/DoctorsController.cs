using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using PersonalBlog.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace PersonalBlog
{
    [Authorize(Roles = "Admin")]
    public class DoctorsController : Controller
    {
        MyDbContext _dbContext;
        private readonly UserManager<CustomUser> _userManager;


        public DoctorsController(MyDbContext dbContext, UserManager<CustomUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public ActionResult Index()
        {
            return View(_dbContext.Doctors.ToList());
        }

        public async Task<IActionResult> LoggedUser()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId
            var userName = User.FindFirstValue(ClaimTypes.Name); // will give the user's userName

            CustomUser applicationUser = await _userManager.GetUserAsync(User);
            string userEmail = applicationUser?.Email; // will give the user's Email
            string userFirstName = applicationUser?.FirstName; // will give the user's FirstName

            return Content("UserID: " + userId + " - Username: " + userName + " - mail: " + userEmail + " - firstname: " + userFirstName);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateDoctor(Doctor doctor)
        {
            _dbContext.Doctors.Add(doctor);
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Doctors");
        }

        [HttpPost]
        public bool Delete(int id)
        {
            try
            {
                Doctor doctor = _dbContext.Doctors.Where(s => s.Id == id).First();
                _dbContext.Doctors.Remove(doctor);
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
            return View(_dbContext.Doctors.Where(s => s.Id == id).First());
        }

        public ActionResult Update(int id)
        {
            return View(_dbContext.Doctors.Where(s => s.Id == id).First());
        }

        [HttpPost]
        public ActionResult UpdateDoctor(Doctor doctor)
        {
            Doctor d = _dbContext.Doctors.Where(s => s.Id == doctor.Id).First();
            d.Name = doctor.Name;
            d.Phone = doctor.Phone;
            d.Specialist = doctor.Specialist;
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Doctors");
        }
    }
}