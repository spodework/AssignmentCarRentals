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
                    AdminName = "Admin",
                    Password = "admin",
                    Role = "Admin",
                    Email = "admin@fbcarrentals.se"
                }
            );

            // Seed a default Admin if none exists
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    CustomerId = 1,
                    CustomerName = "kalle",
                    Password = "kalle",
                    Role = "Customer",
                    Email = "kalle"
                }
            );

            // Seed a default Admin if none exists
            modelBuilder.Entity<Car>().HasData(
                new Car
                {
                    CarId = 1337,
                    ImageFilenames = {"saab_900.jpg", "saab_900_2.jpg", "saab_900_3.jpg" },
                    Name = "Saab 900 (bra skick)"
                },
                new Car
                {
                    CarId = 1453,
                    ImageFilenames = { "opel_kadett-2.jpg", "opel_kadett-4.jpg", "opel-kadett.jpg" },
                    Name = "Opel Kadett"
                }
            );

        }


    }
}
