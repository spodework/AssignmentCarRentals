using CarRentalsAssignmentV2.Models;

namespace CarRentalsAssignmentV2.Interfaces
{
    public interface IRental
    {
        Rental GetById(int id);
        IQueryable<Rental> GetAll();
        IEnumerable<Rental> GetRentalsByCustomer(int customerId);

        IEnumerable<Rental> GetRentalsByCar(int carId);
        void Add(Rental rental);
        void Update(Rental rental);
        void Delete(Rental rental);
    }
}
