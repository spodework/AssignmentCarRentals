using CarRentalsAssignmentV2.Data.Repositories;
using CarRentalsAssignmentV2.Interfaces;
using CarRentalsAssignmentV2.Models;
using CarRentalsAssignmentV2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarRentalsAssignmentV2.Controllers
{
    public class CarController : Controller
    {
        private readonly ICar _carRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CarController(ICar carRepository, IWebHostEnvironment webHostEnvironment)
        {
            _carRepository = carRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public ActionResult Index()
        {
            var carImageDirectory = Path.Combine(_webHostEnvironment.WebRootPath, "images", "cars");

            // Get all the image files from the cars directory
            var carImages = Directory.GetFiles(carImageDirectory)
                                       .Select(f => Path.GetFileName(f)) // Get only the filenames
                                       .ToList();

            ViewBag.CarImages = carImages;

            return View(_carRepository.GetAll());
        }

        public ActionResult Create()
        {
            var carImageDirectory = Path.Combine(_webHostEnvironment.WebRootPath, "images", "cars");

            // Get all the image files from the cars directory
            var carImages = Directory.GetFiles(carImageDirectory)
                                       .Select(f => Path.GetFileName(f)) // Get only the filenames
                                       .ToList();

            carImages.Insert(0, "--Please choose an option--");

            ViewBag.CarImages = new SelectList(carImages);          

            return View();
        }

        // POST: Cars/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Car car)
        {

            if (ModelState.IsValid)
            {
                // Code to save the car
                _carRepository.Add(car);

                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Cars/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_carRepository.GetById(id));
        }


        // POST: Cars/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Car car)
        {

            //if (ModelState.IsValid)
            //{
                // Code to save the car
                _carRepository.Delete(car);

                return RedirectToAction("Index");
            //}
            
            //return RedirectToAction("Index");
        }

        // GET: CarController/Edit/5
        public ActionResult Edit(int id)
        {
            var carImageDirectory = Path.Combine(_webHostEnvironment.WebRootPath, "images", "cars");

            // Get all the image files from the cars directory
            var carImages = Directory.GetFiles(carImageDirectory)
                                       .Select(f => Path.GetFileName(f)) // Get only the filenames
                                       .ToList();

            carImages.Insert(0, "--Please choose an option--");

            ViewBag.CarImages = new SelectList(carImages);

            return View(_carRepository.GetById(id));
        }

        // POST: CarController/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Car car)
        {
            try
            {
                _carRepository.Update(car);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


    }
}
