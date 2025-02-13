namespace CarRentalsAssignmentV2.Models
{
    public class Car
    {
        public int CarId { get; set; }
        public string Name { get; set; }
        public List<string> ImageFilenames { get; set; } = new List<string>();
    }

}
