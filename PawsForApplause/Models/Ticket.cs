namespace PawsForApplause.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public DateTime PurchaseDate { get; set; } // date and time of purchase
        public string SeatNumber { get; set; } = string.Empty; // seat number or section
        public decimal Price { get; set; } // price of the ticket
        public DateTime Created { get; set; } // date and time record created

        // Foreign Keys
        public int ShowId { get; set; } // FK to Event
        public int UserId { get; set; } // FK to User (who purchased the ticket)

        // Navigation Properties
        public Show? Show { get; set; } // Navigation property to Event
        public User? User { get; set; } // Navigation property to User
    }
}
