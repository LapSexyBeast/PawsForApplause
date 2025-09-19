namespace PawsForApplause.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public int EventId { get; set; } // FK to Event
        public int UserId { get; set; } // FK to User (who purchased the ticket)
        public DateTime PurchaseDate { get; set; } // date and time of purchase
        public string SeatNumber { get; set; } = string.Empty; // seat number or section
        public decimal Price { get; set; } // price of the ticket
        public DateTime Created { get; set; } // date and time record created
    }
}
