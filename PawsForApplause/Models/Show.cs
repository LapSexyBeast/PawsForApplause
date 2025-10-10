using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 

namespace PawsForApplause.Models
{

    //The event data will include the...
    public class Show
    {
        public int ShowId { get; set; }
        public string Name { get; set; } = string.Empty; // event's title
        public string Description { get; set; } = string.Empty; //description
        public DateTime Date { get; set; } //date and time
        public DateTime Created { get; set; } //date and time record created
        public DateTime LastModified { get; set; } //date and time record last modified
        public string Filename { get; set; } = string.Empty;

        // Foreign Keys
        public int UserId { get; set; } // FK to User (who created the event)
        public int VenueId { get; set; } // FK to Venue
        public int CategoryId { get; set; } //FK to Category

        //Navigation Properties
        public Category? Category { get; set; }
        public User? User { get; set; } // Navigation property to User
        public Venue? Venue { get; set; } // Navigation property to Venue
        

        [NotMapped]
        [Display(Name = "Event Image")]
        public IFormFile? FormFile { get; set; } //nullable

    }
}
