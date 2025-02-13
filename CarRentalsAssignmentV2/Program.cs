using Microsoft.EntityFrameworkCore;
using CarRentalsAssignmentV2.Data;
using CarRentalsAssignmentV2.Data.Repositories;
using CarRentalsAssignmentV2.Interfaces;

namespace CarRentalsAssignmentV2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FribergCarRentalsDB_New;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

            // Add services to the container.
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

            builder.Services.AddTransient<ICar, CarRepository>();
            builder.Services.AddTransient<IRental, RentalRepository>();
            builder.Services.AddTransient<ICustomer, CustomerRepository>();
            builder.Services.AddTransient<IAdmin, AdminRepository>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDistributedMemoryCache();

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(2);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

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

            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
