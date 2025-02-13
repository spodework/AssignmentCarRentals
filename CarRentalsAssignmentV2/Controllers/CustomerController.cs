using CarRentalsAssignmentV2.Data;
using CarRentalsAssignmentV2.Data.Repositories;
using CarRentalsAssignmentV2.Interfaces;
using CarRentalsAssignmentV2.Models;
using CarRentalsAssignmentV2.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalsAssignmentV2.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomer _customerRepository;
        private readonly IRental _rentalRepository;

        public CustomerController(ICustomer customerRepository, IRental rentalRepository)
        {
            _customerRepository = customerRepository;
            _rentalRepository = rentalRepository;
        }
        [AuthenticateUserFilter]
        // GET: CustomerController
        public ActionResult Index()
        {
            return View(_customerRepository.GetAll());
        }

        // GET: CustomerController
        public ActionResult Dashboard()
        {
            int userId = HttpContext.Session.GetInt32("UserId") ?? -1;

            if (userId != -1)
            {
                var customer = _customerRepository.GetById(userId);
                var rentals = _rentalRepository.GetRentalsByCustomer(userId);


                var viewModel = new CustomerDetailsViewModel
                {
                    Customer = customer,
                    Rentals = rentals
                };

                return View(viewModel);
            }

            return RedirectToAction("SignupOrLogin", "Home");

        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            var customer = _customerRepository.GetById(id);
            var rentals = _rentalRepository.GetRentalsByCustomer(id);

            var viewModel = new CustomerDetailsViewModel
            {
                Customer = customer,
                Rentals = rentals
            };

            return View(viewModel);
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {

            _customerRepository.Add(customer);

            if (HttpContext.Session.GetString("UserRole") == "Admin")
            {
                
                return RedirectToAction("Index", "Customer");
            }

            SessionHelper.SetSessionStrings(HttpContext, customer.CustomerId, customer.CustomerName, customer.Role, customer.Email);
            TempData["Message"] = "You successfully created an account!";

            return RedirectToAction("Dashboard", "Customer");
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_customerRepository.GetById(id));
        }

        // POST: CustomerController/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer customer)
        {
            try
            {
                _customerRepository.Update(customer);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_customerRepository.GetById(id));
        }

        // POST: CustomerController/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Customer customer)
        {
            try
            {
                _customerRepository.Delete(customer);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: CustomerController/<email>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            var myPassword = password;

            try
            {
                var customer = _customerRepository.GetByEmail(email);

                if (customer == null)
                {
                    TempData["ErrorMessage"] = "Could not find customer. Check email/password";

                    return RedirectToAction("SignupOrLogin", "Home");
                }


                if (customer.Password != password)
                {
                    TempData["ErrorMessage"] = "Could not find customer. Check email/password";

                    return RedirectToAction("SignupOrLogin", "Home");
                }

                SessionHelper.SetSessionStrings(HttpContext, customer.CustomerId, customer.Email, customer.Role, customer.Email);

                return RedirectToAction("Dashboard", "Customer");
            }
            catch
            {

                return RedirectToAction("Dashboard", "Customer");
            }
        }
    }
}
