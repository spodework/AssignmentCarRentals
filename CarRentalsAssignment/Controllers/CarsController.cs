using CarRentalsAssignment.Data;
using CarRentalsAssignment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarRentalsAssignment.Controllers
{
    public class CarsController : Controller
    {

        private readonly CarRentalsAssignment.Data.IRental _rentalRepository;
        private readonly CarRentalsAssignment.Data.ICar _carRepository;
        private readonly CarRentalsAssignment.Data.IAdmin _adminRepository;
        private readonly CarRentalsAssignment.Data.ICustomer _customerRepository;

        public CarsController(ICar carRepository, IRental rentalRepository, ICustomer customerRepository)
        {
            _carRepository = carRepository;
            _rentalRepository = rentalRepository;
            _customerRepository = customerRepository;
        }
        public IActionResult Index()
        {
            return View(_carRepository.GetAll());
        }

        // (GET) CREATE RENTAL
        public IActionResult CreateRental()
        {
            var cars = _carRepository.GetAll();

            ViewBag.Cars = new SelectList(cars, "CarId","Name");

            return View(cars);
        }

        // (GET) DELETE RENTAL
        public IActionResult DeleteRental(int id)
        {
            return View(_rentalRepository.GetById(id));
        }

        // (GET) DETAILS RENTAL
        public IActionResult DetailsRental(int id)
        {
            return View(_rentalRepository.GetById(id));
        }

        // (POST) DELETE USER
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteRental(Rental rental)
        {

            try
            {
                _rentalRepository.Delete(rental);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                return View();
            }
        }

        // (POST) EDIT RENTAL
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditRental(Rental rental)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _rentalRepository.Update(rental);
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View();
            }
        }

        // (POST) CREATE RENTAL
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateRental(Rental rental)
        {

            var renter = _customerRepository.GetById(0);

            var car = _carRepository.GetById(rental.CarId);

            rental.RenterId = renter.CustomerId;

            try
            {
                if (ModelState.IsValid)
                {
                    _rentalRepository.Add(rental);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                return View();
            }
        }
    }
}
