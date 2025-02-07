namespace CarRentalsAssignment.Models
{
    public class Rental
    {
        public int RentalId { get; set; }        
        public int CarId { get; set; }
        public Car Car { get; set; }
        
        public int RenterId { get; set; }
        public Customer Renter { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        
        

    }
}
