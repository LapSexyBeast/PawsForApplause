namespace PawsForApplause.Models
{
    public class Venue
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; // venue name
        public string Address { get; set; } = string.Empty; // venue address
        public string City { get; set; } = string.Empty; // venue city
        public string Province { get; set; } = string.Empty; // venue Province
        public string PostalCode { get; set; } = string.Empty; // venue postal code
        public int Capacity { get; set; } // venue capacity
        public DateTime Created { get; set; } // date and time record created
    }
}
