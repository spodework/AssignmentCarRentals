using System.Collections.Generic;
using CarRentalsAssignment.Data;
using CarRentalsAssignment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace CarRentalsAssignment.Controllers
{
    public class AdminController : Controller
    {
        private readonly CarRentalsAssignment.Data.ICustomer _customerRepository;
        private readonly CarRentalsAssignment.Data.ICar _carRepository;
        private readonly CarRentalsAssignment.Data.IRental _rentalRepository;        
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AdminController(ICustomer customerRepository,
            ICar carRepository, IRental rentalRepository, IWebHostEnvironment webHostEnvironment)
        {
            _customerRepository = customerRepository;            
            _carRepository = carRepository;
            _rentalRepository = rentalRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        /* 
         * SECTION CUSTOMERS CUSTOMERS CUSTOMERS CUSTOMERS 
         * AND ADMINS AND THE LIKE
         * 
        */

        // Helper for Getting Roles
        private IEnumerable<SelectListItem> GetRoles()
        {            
            var roles = new List<string> { "Admin", "Customer" };
            return new SelectList(roles);
        }

        // (GET) ADMIN DASHBOARD
        public IActionResult Index()
        {            
            return View();
        }

        // (GET) CREATE CUSTOMER
        public IActionResult CreateCustomer()
        {
            
            ViewBag.Roles = GetRoles();

            return View();
        }

        // (GET) MANAGE/LIST CUSTOMERS
        public IActionResult ManageCustomers()
        {
            return View(_customerRepository.GetAll());
        }

        // (GET) EDIT CUSTOMER
        public IActionResult EditCustomer(int id)
        {
            ViewBag.Roles = GetRoles();

            return View(_customerRepository.GetById(id));
        }

        // (GET) DELETE CUSTOMER
        public IActionResult DeleteCustomer(int id)
        {
            return View(_customerRepository.GetById(id));
        }

        // (GET) DETAILS CUSTOMER
        public IActionResult DetailsCustomer(int id)
        {
            return View(_customerRepository.GetById(id));
        }

        // (POST) DELETE CUSTOMER
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCustomer(Customer customer)
        {

            try
            {
                _customerRepository.Delete(customer);            

                return RedirectToAction(nameof(ManageCustomers));
            }
            catch (Exception)
            {

                return View();
            }
        }

        // (POST) EDIT CUSTOMER
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditCustomer(Customer user)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _customerRepository.Update(user);
                }

                return RedirectToAction(nameof(ManageCustomers));
            }
            catch (Exception)
            {
                return View();
            }
        }

        // (POST) CREATE CUSTOMER
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateCustomer(Customer user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _customerRepository.Add(user);
            }
                return RedirectToAction(nameof(ManageCustomers));
            }
            catch (Exception)
            {

                return View();
            }
        }

        /* 
         * 
         * SECTION CARS CARS CARS CARS 
         * GO VROOM VROOM
         * 
        */

        // (GET) CREATE CAR
        public IActionResult CreateCar()
        {
            var carImageDirectory = Path.Combine(_webHostEnvironment.WebRootPath, "images", "cars");

            // Get all the image files from the cars directory
            var carImages = Directory.GetFiles(carImageDirectory)
                                       .Select(f => Path.GetFileName(f)) // Get only the filenames
                                       .ToList();

            // Pass the filenames to the view
            ViewBag.CarImages = new SelectList(carImages);

            return View();
        }

        // (GET) MANAGE/LIST CARS
        public IActionResult ManageCars()
        {
            return View(_carRepository.GetAll());
        }

        // (GET) EDIT CAR
        public IActionResult EditCar(int id)
        {
            ViewBag.Roles = GetRoles();

            var carImageDirectory = Path.Combine(_webHostEnvironment.WebRootPath, "images", "cars");

            // Get all the image files from the cars directory
            var carImages = Directory.GetFiles(carImageDirectory)
                                       .Select(f => Path.GetFileName(f)) // Get only the filenames
                                       .ToList();

            // Pass the filenames to the view
            ViewBag.CarImages = new SelectList(carImages);


            return View(_carRepository.GetById(id));
        }

        // (GET) DELETE CAR
        public IActionResult DeleteCar(int id)
        {
            return View(_carRepository.GetById(id));
        }

        // (GET) DETAILS CAR
        public IActionResult DetailsCar(int id)
        {
            return View(_carRepository.GetById(id));
        }

        // (POST) CREATE CAR
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateCar(Car car)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _carRepository.Add(car);
                }
                return RedirectToAction(nameof(ManageCars));
            }
            catch (Exception)
            {

                return View();
            }
        }

        // (POST) DELETE CAR
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCar(Car car)
        {

            try
            {
                _carRepository.Delete(car);

                return RedirectToAction(nameof(ManageCars));
            }
            catch (Exception)
            {

                return View();
            }
        }

        /* 
         * 
         * SECTION RENTALS 
         * WHAT HAVE BEEN 
         * 
        */

        // (GET) MANAGE/LIST RENTALS
        public IActionResult ManageRentals()
        {
            return View(_rentalRepository.GetAll());            
        }

    }

}
