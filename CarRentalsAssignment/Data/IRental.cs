using CarRentalsAssignment.Models;

namespace CarRentalsAssignment.Data
{
    public interface IRental
    {
        Rental GetById(int id);
        IEnumerable<Rental> GetAll();
        void Add(Rental rental);
        void Update(Rental rental);
        void Delete(Rental rental);
    }
}
