using CarRentalsAssignment.Data;
using CarRentalsAssignment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarRentalsAssignment.Controllers
{
    public class RentalsController : Controller
    {

        private readonly CarRentalsAssignment.Data.IRental _rentalRepository;
        private readonly CarRentalsAssignment.Data.ICar _carRepository;
        private readonly CarRentalsAssignment.Data.ICustomer _customerRepository;

        public RentalsController(ICar carRepository, IRental rentalRepository, ICustomer customerRepository)
        {
            _carRepository = carRepository;
            _rentalRepository = rentalRepository;
            _customerRepository = customerRepository;
        }
        public IActionResult Index()
        {
            return View(_rentalRepository.GetAll());
        }

        // (GET) CREATE RENTAL
        public IActionResult CreateRental()
        {
            var cars = _carRepository.GetAll();           

            var rental = new Rental { Car = new Car(), StartDate = DateTime.Today, EndDate = DateTime.Today.AddDays(1) };

            ViewBag.Cars = new SelectList(cars, "CarId","Name");

            return View(rental);
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

            var myDebug = $"CarId: {rental.CarId}, StartDate: {rental.StartDate}, EndDate: {rental.EndDate}";

            Console.WriteLine("helo");

            // Hardcode while testing get first customer
            var allCars = _carRepository.GetAll();
            var allCustomers = _customerRepository.GetAll();
            var renter = allCustomers.FirstOrDefault();
            var car = _carRepository.GetById(rental.CarId);

            rental.CarId = car.CarId;
            rental.Car = car;
            rental.RenterId = renter.CustomerId;
            rental.Renter = renter;
                         
            try
            {   
                _rentalRepository.Add(rental);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                return View();
            }
        }
    }
}
