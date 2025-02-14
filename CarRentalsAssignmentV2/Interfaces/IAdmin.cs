using CarRentalsAssignmentV2.Models;

namespace CarRentalsAssignmentV2.Interfaces
{
    public interface IAdmin
    {
        Admin GetById(int id);
        Admin GetByAdminName(string adminName);
        Admin GetByEmail(string email);
        IEnumerable<Admin> GetAll();        
        void Add(Admin admin);
        void Update(Admin admin);
        void Delete(Admin admin);
    }
}
