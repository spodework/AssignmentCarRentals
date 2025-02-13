namespace CarRentalsAssignmentV2.Models
{
    public class Admin
    {
        public int AdminId { get; set; }
        public string AdminName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Role { get; set; } = "Admin";
    }

}
