using CarRentalsAssignmentV2.Models;

namespace CarRentalsAssignmentV2.Interfaces
{
    public interface ICustomer
    {
        Customer GetById(int id);
        Customer GetByCustomerName(string customerName);
        Customer GetByEmail(string email);
        IEnumerable<Customer> GetAll();        
        void Add(Customer customer);
        void Update(Customer customer);
        void Delete(Customer customer);
    }
}
