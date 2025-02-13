using CarRentalsAssignmentV2.Data;
using CarRentalsAssignmentV2.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace CarRentalsAssignmentV2.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdmin _adminRepository;

        public AdminController(IAdmin adminRepository)
        {
            _adminRepository = adminRepository;
        }
        // GET: Admin/Index
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/Index
        public ActionResult Dashboard()
        {
            return View();
        }


        // POST: Admin/Login
        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            var admin = _adminRepository.GetByEmail(email);

            if (admin == null)
            {
                return View();
            }

            SessionHelper.SetSessionStrings(HttpContext, admin.AdminId, admin.AdminName, admin.Role, admin.Email);

            return RedirectToAction("Dashboard", "Admin");
        }

    }

}
