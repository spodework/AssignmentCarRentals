using CarRentalsAssignmentV2.Interfaces;
using CarRentalsAssignmentV2.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentalsAssignmentV2.Data.Repositories
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

        IQueryable<Rental> IRental.GetAll()
        {
            return _applicationDbContext.Rentals.OrderBy(x => x.RentalId);
        }

        IEnumerable<Rental> IRental.GetRentalsByCustomer(int customerId)
        {
            return _applicationDbContext.Rentals.Where(x => customerId == x.RenterId).OrderBy(r => r.RentalId); ;
        }

        IEnumerable<Rental> IRental.GetRentalsByCar(int carId)
        {
            return _applicationDbContext.Rentals.Where(x => carId == x.CarId);
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
