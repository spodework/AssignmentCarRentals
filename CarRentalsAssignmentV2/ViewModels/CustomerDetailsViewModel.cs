using CarRentalsAssignmentV2.Models;

namespace CarRentalsAssignmentV2.ViewModels
{
    public class CustomerDetailsViewModel
    {
        // Customer information
        public Customer Customer { get; set; }

        // List of rentals associated with the customer
        public IEnumerable<Rental> Rentals { get; set; }
    }

}
