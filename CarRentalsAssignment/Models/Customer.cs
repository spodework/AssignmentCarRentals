namespace CarRentalsAssignment.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } = "Customer";
        public ICollection<Rental> Rentals { get; set; } = new List<Rental>();
    }

}
