using CarRentalsAssignmentV2.Models;

namespace CarRentalsAssignmentV2.ViewModels
{
    public class CarDetailsViewModel
    {
        // Customer information
        public Car Car { get; set; }

        // List of rentals associated with the customer
        public IEnumerable<Rental> Rentals { get; set; }
    }

}
