using CarRentalsAssignment.Models;

namespace CarRentalsAssignment.Data
{
    public interface IAdmin
    {
        Admin GetById(int id);
        IEnumerable<Admin> GetAll();
        void Add(Admin admin);
        void Update(Admin admin);
        void Delete(Admin admin);
    }
}
