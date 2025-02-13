using CarRentalsAssignmentV2.Models;

namespace CarRentalsAssignmentV2.Interfaces
{
    public interface ICar
    {
        Car GetById(int id);
        IEnumerable<Car> GetAll();
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
    }
}
