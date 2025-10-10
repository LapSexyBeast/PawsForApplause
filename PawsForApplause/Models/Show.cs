namespace PawsForApplause.Models
{

    //The event data will include the...
    public class Show
    {
        public int ShowId { get; set; }
        public string Name { get; set; } = string.Empty; // event's title
        public string Description { get; set; } = string.Empty; //description
        public string Type { get; set; } = string.Empty; // category maybe FK ?
        public DateTime Date { get; set; } //date and time
        public string Location { get; set; } = string.Empty; //location //unsure if want to connect this as a FK vs it being a google link
        public DateTime Created { get; set; } //date and time record created

        // Foreign Keys
        public int UserId { get; set; } // FK to User (who created the event)
        public int VenueId { get; set; } // FK to Venue

        //Navigation Properties

        public User? User { get; set; } // Navigation property to User
        public Venue? Venue { get; set; } // Navigation property to Venue

    }
}
