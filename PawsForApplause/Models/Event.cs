namespace PawsForApplause.Models
{

    //The event data will include the...
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; // event's title
        public string Description { get; set; } = string.Empty; //description
        public string Type { get; set; } = string.Empty; // category maybe FK ?
        public DateTime Date { get; set; } //date and time
        public string Location { get; set; } = string.Empty; //location //unsure if want to connect this as a FK vs it being a google link
        public int UserId { get; set; } // FK to User (who created the event)
        public string Owner { get; set; } = string.Empty; // owner (who is running the event) //THIS NEEDS TO BECOME FK
        public DateTime Created { get; set; } //date and time record created

    }
}
