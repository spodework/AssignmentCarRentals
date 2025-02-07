using Microsoft.EntityFrameworkCore;
using CarRentalsAssignment.Models;

namespace CarRentalsAssignment.Data
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
                    Username = "admin",   // Default username
                    Password = "admin123",  // Hashed password
                    Role = "Admin"
                }
            );

            // Seed a default Admin if none exists
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    CustomerId = 1,
                    Username = "user",   // Default username
                    Password = "user123",  // Hashed password
                    Role = "User"
                }
            );

        }


    }
}
