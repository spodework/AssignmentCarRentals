using CarRentalsAssignment.Models;

namespace CarRentalsAssignment.Data
{
    public class RentalRepository : IRental
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public RentalRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        void IRental.Add(Rental rental)
        {
            _applicationDbContext.Rentals.Add(rental);
            _applicationDbContext.SaveChanges();
        }

        void IRental.Delete(Rental rental)
        {
            _applicationDbContext.Rentals.Remove(rental);
            _applicationDbContext.SaveChanges();
        }

        IEnumerable<Rental> IRental.GetAll()
        {
            return _applicationDbContext.Rentals.OrderBy(x => x.RentalId);
        }

        Rental IRental.GetById(int id)
        {
            return _applicationDbContext.Rentals.FirstOrDefault(x => x.RentalId == id);
        }

        void IRental.Update(Rental rental)
        {
            _applicationDbContext.Rentals.Update(rental);
            _applicationDbContext.SaveChanges();
        }
    }
}
