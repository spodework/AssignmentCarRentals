using CarRentalsAssignment.Models;

namespace CarRentalsAssignment.Data
{
    public class CarRepository : ICar
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CarRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        IEnumerable<Car> ICar.GetAll()
        {
            return _applicationDbContext.Cars.OrderBy(x => x.CarId);
        }

        Car ICar.GetById(int id)
        {
            return _applicationDbContext.Cars.FirstOrDefault(x => x.CarId == id);
        }

        void ICar.Add(Car car)
        {
            _applicationDbContext.Cars.Add(car);
            _applicationDbContext.SaveChanges();
        }

        void ICar.Delete(Car car)
        {
            _applicationDbContext.Cars.Remove(car);
            _applicationDbContext.SaveChanges();
        }

        void ICar.Update(Car car)
        {
            _applicationDbContext.Cars.Update(car);
            _applicationDbContext.SaveChanges();
        }
    }
}
