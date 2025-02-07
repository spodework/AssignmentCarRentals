using CarRentalsAssignment.Models;

namespace CarRentalsAssignment.Data
{
    public interface ICustomer
    {
        Customer GetById(int id);
        IEnumerable<Customer> GetAll();
        void Add(Customer customer);
        void Update(Customer customer);
        void Delete(Customer customer);
    }
}
