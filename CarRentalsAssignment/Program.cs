using CarRentalsAssignment.Data;

using Microsoft.EntityFrameworkCore;


namespace CarRentalsAssignment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FribergCarRentalsDB_New;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

            // Add services to the container.
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
            
            builder.Services.AddTransient<CarRentalsAssignment.Data.IAdmin, AdminRepository>();
            builder.Services.AddTransient<CarRentalsAssignment.Data.ICustomer, CustomerRepository>();
            builder.Services.AddTransient<CarRentalsAssignment.Data.ICar, CarRepository>();
            builder.Services.AddTransient<CarRentalsAssignment.Data.IRental, RentalRepository>();
            //builder.Services.AddTransient<ICar, CarRepository>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();


            // Admin routing (this will map all admin-related actions in AdminController)
            app.MapControllerRoute(
                name: "admin",
                pattern: "Admin/{action=Index}/{id?}",
                defaults: new { controller = "Admin" });

            //DEFAULT
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");


            app.Run();
        }
    }
}
