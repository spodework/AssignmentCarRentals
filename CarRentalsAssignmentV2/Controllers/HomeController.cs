using System.Diagnostics;
using CarRentalsAssignmentV2.Data;
using CarRentalsAssignmentV2.Interfaces;
using CarRentalsAssignmentV2.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalsAssignmentV2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICustomer _customerRepository;

        public HomeController(ILogger<HomeController> logger, ICustomer customerRepository)
        {
            _logger = logger;
            _customerRepository = customerRepository;
        }

        public IActionResult Index()
        {
            //var firstCustomer = _customerRepository.GetAll().First();

            SessionHelper.SetSessionStrings(HttpContext, -5, "Guest", "Guest", "");

            return View();
        }

        public IActionResult SignupOrLogin()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
