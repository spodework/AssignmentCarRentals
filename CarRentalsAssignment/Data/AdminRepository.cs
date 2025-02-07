using CarRentalsAssignment.Models;

namespace CarRentalsAssignment.Data
{
    public class AdminRepository : IAdmin
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public AdminRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        IEnumerable<Admin> IAdmin.GetAll()
        {
            return _applicationDbContext.Admins.OrderBy(x => x.AdminId);
        }

        Admin IAdmin.GetById(int id)
        {
            return _applicationDbContext.Admins.FirstOrDefault(x => x.AdminId == id);
        }
        void IAdmin.Add(Admin admin)
        {
            _applicationDbContext.Admins.Add(admin);
            _applicationDbContext.SaveChanges();
        }

        void IAdmin.Delete(Admin admin)
        {
            _applicationDbContext.Admins.Remove(admin);
            _applicationDbContext.SaveChanges();
        }     

        void IAdmin.Update(Admin admin)
        {
            _applicationDbContext.Admins.Update(admin);
            _applicationDbContext.SaveChanges();
        }
    }
}
