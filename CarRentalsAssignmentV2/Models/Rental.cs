namespace CarRentalsAssignmentV2.Models
{
    public class Rental
    {
        public int RentalId { get; set; }        
        public int CarId { get; set; }
        
        public int RenterId { get; set; }

        // for lazy Lazy Loading
        public Customer Renter { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }               

    }
}
