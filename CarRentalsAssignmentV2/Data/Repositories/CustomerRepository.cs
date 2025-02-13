using CarRentalsAssignmentV2.Interfaces;
using CarRentalsAssignmentV2.Models;

namespace CarRentalsAssignmentV2.Data.Repositories
{
    public class CustomerRepository : ICustomer
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CustomerRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        IEnumerable<Customer> ICustomer.GetAll()
        {
            return _applicationDbContext.Customers.OrderBy(x => x.CustomerId);
        }

        Customer ICustomer.GetById(int id)
        {

            return _applicationDbContext.Customers.FirstOrDefault(x => x.CustomerId == id);
        }

        Customer ICustomer.GetByEmail(string email)
        {
            return _applicationDbContext.Customers.FirstOrDefault(x => x.Email == email);
        }

        Customer ICustomer.GetByCustomerName(string customerName)
        {
            return _applicationDbContext.Customers.FirstOrDefault(x => x.CustomerName == customerName);
        }

        void ICustomer.Add(Customer customer)
        {
            _applicationDbContext.Customers.Add(customer);
            _applicationDbContext.SaveChanges();
        }

        void ICustomer.Delete(Customer customer)
        {
            _applicationDbContext.Customers.Remove(customer);
            _applicationDbContext.SaveChanges();
        }

        void ICustomer.Update(Customer customer)
        {
            _applicationDbContext.Customers.Update(customer);
            _applicationDbContext.SaveChanges();
        }


    }
}
