using CarRentalsAssignmentV2.Data;
using CarRentalsAssignmentV2.Data.Repositories;
using CarRentalsAssignmentV2.Interfaces;
using CarRentalsAssignmentV2.Models;
using CarRentalsAssignmentV2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarRentalsAssignmentV2.Controllers
{
    public class RentalController : Controller
    {
        private readonly IRental _rentalRepository;
        private readonly ICustomer _customerRepository;
        private readonly ICar _carRepository;

        public RentalController(IRental rentalRepository, ICustomer customerRepository, ICar carRepository)
        {
            _rentalRepository = rentalRepository;
            _customerRepository = customerRepository;
            _carRepository = carRepository;
        }

        [AuthenticateUserFilter]
        // GET: RentalController
        public ActionResult Index()
        {
            var rentals = _rentalRepository.GetAll().Include(x => x.Renter);

            return View(rentals);
        }

        // GET: RentalController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RentalController/Create/<carId>
        public IActionResult Create(int id)
        {
            //var userRole = HttpContext.Session.GetString("UserRole");

            if (SessionHelper.IsGuestSession(HttpContext))
            {
                TempData["ErrorMessage"] = "You need to log in or sign up to book a car.";
                return RedirectToAction("SignupOrLogin", "Home");
            }

            var car = _carRepository.GetById(id);
            var rentals = _rentalRepository.GetRentalsByCar(id);

            ViewBag.Car = car;
            ViewBag.Rentals = rentals;

            return View();
        }

        // POST: RentalController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int id, DateTime startDate, DateTime endDate)
        {

            var userId = HttpContext.Session.GetInt32("UserId") ?? -1;
            var userName = HttpContext.Session.GetString("UserName");
            var userEmail = HttpContext.Session.GetString("UserEmail");

            var customer = _customerRepository.GetById(userId);

            startDate = startDate.Date.AddHours(6).AddMinutes(00).AddSeconds(0);
            endDate = endDate.Date.AddHours(23).AddMinutes(59).AddSeconds(0);

            _rentalRepository.Add(new Rental() { CarId = id, StartDate = startDate, EndDate = endDate, RenterId = userId, Renter = customer });

            TempData["Message"] = $"Booking confirmed! From: {startDate} to: {endDate}.";

            return RedirectToAction("Dashboard", "Customer");


        }


        // GET: RentalController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RentalController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RentalController/Delete/5
        public ActionResult Delete(int id)
        {

            return View(_rentalRepository.GetById(id));
        }

        // POST: RentalController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Rental rental)
        {

            try
            {

                _rentalRepository.Delete(rental);


                if (SessionHelper.IsAdminSession(HttpContext)) { 
                    return RedirectToAction(nameof(Index));
                }
                else
                { 
                    return RedirectToAction("Dashboard", "Customer");
                }

            }
            catch
            {
                return View();
            }
        }
    }
}
