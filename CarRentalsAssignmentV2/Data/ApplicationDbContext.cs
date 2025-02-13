using Microsoft.EntityFrameworkCore;
using CarRentalsAssignmentV2.Models;

namespace CarRentalsAssignmentV2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Rental> Rentals { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed a default Admin if none exists
            modelBuilder.Entity<Admin>().HasData(
                new Admin
                {
                    AdminId = 1,
                    AdminName = "admin",
                    Password = "admin",
                    Role = "Admin",
                    Email = "admin"
                }
            );

            // Seed a default Admin if none exists
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    CustomerId = 1,
                    CustomerName = "Kalle",
                    Password = "kalle123",
                    Role = "Customer",
                    Email = "coolcustoemr@carrentals.ab"
                }
            );

            // Seed a default Admin if none exists
            modelBuilder.Entity<Car>().HasData(
                new Car
                {
                    CarId = 1337,
                    ImageFilenames = {"saab_900.jpg", "saab_900.jpg", "saab_900.jpg" },
                    Name = "Saab 900 (bra skick)"
                }
            );

        }


    }
}
